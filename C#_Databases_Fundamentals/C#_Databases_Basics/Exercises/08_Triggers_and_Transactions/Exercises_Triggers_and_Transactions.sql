-- 1. Create Table Logs
CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY(1,1),
	AccountId INT NOT NULL,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL,

	CONSTRAINT FK_Logs_Accounts FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
);

GO

CREATE TRIGGER tr_AccountBalanceChange
ON Accounts
AFTER UPDATE
AS
BEGIN
	IF UPDATE(Balance)
	BEGIN
		INSERT INTO Logs (AccountId, OldSum, NewSum)
		SELECT 
			i.Id,
			d.Balance,
			i.Balance
		FROM
			INSERTED AS i
		JOIN
			DELETED AS d ON i.Id = d.Id
		WHERE
			i.Balance <> d.Balance	-- Only log if the balance actually changed
	END
END

-- 2. Create Table Emails
CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Recipient INT NOT NULL,
	[Subject] NVARCHAR(250) NOT NULL,
	Body NVARCHAR(MAX) NOT NULL,

	CONSTRAINT FK_NotificationEmails_Accounts FOREIGN KEY (Recipient) REFERENCES Accounts(Id)
);

GO

CREATE TRIGGER tr_NewLogEntryEmail
ON Logs
AFTER INSERT
AS
BEGIN
	INSERT INTO NotificationEmails (Recipient, [Subject], Body)
	SELECT
		i.AccountId,
		CONCAT('Balance change for account: ', i.AccountId),
		CONCAT(
			'On ',
			FORMAT(GETDATE(), 'MM dd yyyy h:mm tt'),
			' your balance was changed from ',
			i.OldSum,
			' to ',
			i.NewSum,
			'.'
		)
	FROM
		INSERTED AS i;
END

GO

-- 3. Deposit Money
CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount MONEY)
AS
BEGIN
	BEGIN TRANSACTION;

	UPDATE Accounts
	SET Balance = Balance + @MoneyAmount
	WHERE Id = @AccountId;

	COMMIT TRANSACTION;
END;
GO

-- Example usage:
EXEC dbo.usp_DepositMoney @AccountId = 1, @MoneyAmount = 10.000;

GO

-- 4. Withdraw Money Procedure
CREATE PROCEDURE usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY)
AS
BEGIN
	BEGIN TRANSACTION;

	UPDATE Accounts
	SET Balance = Balance - @MoneyAmount
	WHERE Id = @AccountId;

	COMMIT TRANSACTION;
END;
GO

-- Example usage:
EXEC dbo.usp_WithdrawMoney @AccountId = 1, @MoneyAmount = 10.000;
GO

-- 5. Money Transfer
CREATE PROCEDURE usp_TransferMoney (@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
BEGIN
	BEGIN TRANSACTION;

	EXEC usp_WithdrawMoney @SenderId, @Amount;
	EXEC usp_DepositMoney @ReceiverId, @Amount;

	COMMIT TRANSACTION;
END;
GO

-- 6. Trigger
USE Diablo;
GO

CREATE TRIGGER tr_RestrictHighLevelItems
ON UserGameItems
INSTEAD OF INSERT
AS
BEGIN
	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT
		i.ItemId,
		i.UserGameId
	FROM
		INSERTED AS i
	JOIN
		Items AS it ON i.ItemId = it.Id
	JOIN 
		UsersGames AS ug ON i.UserGameId = ug.Id
	WHERE
		it.MinLevel <= ug.[Level];

	IF @@ROWCOUNT < (SELECT COUNT(*) FROM INSERTED)
	BEGIN
		RAISERROR('One or more items were blocked from being purchased because their minimum level was higher than the user''s current level.', 10, 1);
	END
END
GO

-- 7. Massive shopping

-- 8. Employees with Three Projects
USE SoftUni;
GO

CREATE PROCEDURE usp_AssignProject (@emloyeeId INT, @projectID INT) 
AS
BEGIN
	DECLARE @projectCount INT;

	SELECT @projectCount = COUNT(ProjectId)
	FROM EmployeesProjects
	WHERE EmployeeID = @emloyeeId;

	IF @projectCount >= 3
	BEGIN
		RAISERROR('The employee has too many projects!', 16, 1);
		RETURN;
	END
	ELSE
	BEGIN TRANSACTION;

	INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
	VALUES 
		(@emloyeeId, @projectID);

	COMMIT TRANSACTION;
END;

-- 9. Delete Employees
CREATE TABLE Deleted_Employees
(
	EmployeeID INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50) NULL,
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentID INT NOT NULL,
	Salary MONEY NOT NULL,

	CONSTRAINT FK_Deleted_Employees_Departments FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

GO

CREATE TRIGGER tr_DeletedUser
ON Employees
AFTER DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees (
		FirstName,
		LastName,
		MiddleName,
		JobTitle,
		DepartmentID,
		Salary
	)
	SELECT
		d.FirstName,
		d.LastName,
		d.MiddleName,
		d.JobTitle,
		d.DepartmentID,
		d.Salary
	FROM 
		DELETED AS d;
END;
