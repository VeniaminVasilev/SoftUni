USE SoftUni;
GO

-- Exercise 1: Employees with Salary Above 35000
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT
		FirstName AS [First Name],
		LastName AS [Last Name]
	FROM Employees
	WHERE Salary > 35000;
END;

-- Example usage:
EXEC usp_GetEmployeesSalaryAbove35000;
GO

-- Exercise 2: Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber 
	@Number DECIMAL(18,4)
AS
BEGIN
	SELECT
		FirstName AS [First Name],
		LastName AS [Last Name]
	FROM Employees
	WHERE Salary >= @Number;
END;

-- Example usage:
EXEC usp_GetEmployeesSalaryAboveNumber 48100;
GO

-- Exercise 3: Town Names Starting With
CREATE PROCEDURE usp_GetTownsStartingWith
	@StartString NVARCHAR(100)
AS
BEGIN
	SELECT
		Name AS [Town]
	FROM Towns
	WHERE Name LIKE @StartString + '%'
END;

-- Example usage:
EXEC usp_GetTownsStartingWith b
GO

-- Exercise 4: Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown
	@Town NVARCHAR(100)
AS
BEGIN
	SELECT
		FirstName AS [First Name],
		LastName AS [Last Name]
	FROM Employees AS e
	JOIN Addresses AS a
		ON e.AddressID = a.AddressID
	JOIN Towns AS t
		ON a.TownID = t.TownID
	WHERE t.[Name] = @Town
END;

-- Example usage:
EXEC usp_GetEmployeesFromTown Sofia
GO

-- Exercise 5: Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4)) 
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @result NVARCHAR(10);

	IF (@salary < 30000)
		SET @result = 'Low';
	ELSE IF (@salary <= 50000)
		SET @result = 'Average';
	ELSE
		SET @result = 'High';

	RETURN @result;
END;

GO
-- Example usage:
SELECT
	Salary,
	dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel
FROM Employees;

GO
-- Exercise 6: Employees by Salary Level
CREATE PROCEDURE usp_EmployeesBySalaryLevel 
	@Level NVARCHAR(10)
AS
BEGIN
	SELECT
		FirstName AS [First Name],
		LastName AS [Last Name]
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @Level
END;

-- Example usage:
EXEC usp_EmployeesBySalaryLevel high;
GO

-- Exercise 7: Define Function
CREATE FUNCTION ufn_IsWordComprised 
(
	@setOfLetters NVARCHAR(100), 
	@word NVARCHAR(100)
) 
RETURNS BIT
AS
BEGIN
	DECLARE @i INT = 1;
	DECLARE @len INT = LEN(@word);
	DECLARE @result BIT = 1;

	WHILE (@i <= @len)
	BEGIN
		IF (CHARINDEX(LOWER(SUBSTRING(@word, @i, 1)), LOWER(@setOfLetters)) = 0)
		BEGIN
			SET @result = 0;
			BREAK;
		END

		SET @i = @i + 1;
	END

	RETURN @result;
END;

GO
-- Example usage:
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia');
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves');
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob');
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy');

GO

-- Exercise 8: Delete Employees and Departments
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment 
	(@departmentId INT)
AS
BEGIN
	-- 1. Temporarily REMOVE Foreign Key Constraints for cascading delete
	-- This section is included only for exercise purposes

	-- a. EmployeesProjects references Employees
	IF OBJECT_ID('FK_EmployeesProjects_Employees') IS NOT NULL
		ALTER TABLE EmployeesProjects DROP CONSTRAINT FK_EmployeesProjects_Employees;

	-- b. Employees references Departments
	IF OBJECT_ID('FK_Employees_Departments') IS NOT NULL
		ALTER TABLE Employees DROP CONSTRAINT FK_Employees_Departments;

	-- c. Employees self-references for ManagerID
	IF OBJECT_ID('FK_Employees_Employees') IS NOT NULL
		ALTER TABLE Employees DROP CONSTRAINT FK_Employees_Employees;

	-- d. Departments references Employees for ManagerID
	IF OBJECT_ID('FK_Departments_Employees') IS NOT NULL
		ALTER TABLE Departments DROP CONSTRAINT FK_Departments_Employees;

	-- 2. DELETE DATA

	-- Delete all project records related to the employees in the given department
	DELETE ep
	FROM EmployeesProjects AS ep
	JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
	WHERE e.DepartmentID = @departmentId;

	-- Delete all employees in the given department
	DELETE FROM Employees
	WHERE DepartmentId = @departmentId; 

	-- Delete the department itself
	DELETE FROM Departments
	WHERE DepartmentId = @departmentId;

	-- 3. CHECK RESULT

	-- SELECT the number of employees remaining (Should return 0)
	SELECT COUNT(*) AS [Employees Remaining]
	FROM Employees
	WHERE DepartmentID = @departmentId;
END;

GO
-- Exercise 9: Find Full Name
-- Prerequisites:
USE Bank;
GO

-- Actual exercise:
CREATE PROCEDURE usp_GetHoldersFullName 
AS
BEGIN
	SELECT
		FirstName + ' ' + LastName AS [Full Name]
	FROM AccountHolders;
END;

-- Example usage:
EXEC usp_GetHoldersFullName;
GO

-- Exercise 10: People with Balance Higher Than
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@minBalance MONEY)
AS
BEGIN
	SELECT
		ah.FirstName AS [First Name],
		ah.LastName AS [Last Name]
	FROM AccountHolders AS ah
	JOIN Accounts AS a
		ON ah.Id = a.AccountHolderId
	GROUP BY
		ah.Id, ah.FirstName, ah.LastName
	HAVING 
		SUM(a.Balance) > @minBalance
	ORDER BY FirstName ASC, LastName ASC;
END;

EXEC usp_GetHoldersWithBalanceHigherThan 50000.00;

GO
-- Exercise 11: Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue
(
	@initialSum DECIMAL(18,4),	-- I: Initial sum
	@yearlyInterestRate FLOAT,	-- R: Yearly interest rate (FLOAT for precision)
	@years INT					-- T: Number of years
)
RETURNS DECIMAL(18,4)
AS
BEGIN
	-- Calculate the future value using the formula: FV = I * (1 + R)^T
	DECLARE @futureValue DECIMAL(18,4);

	SET @futureValue = @initialSum * POWER((1 + @yearlyInterestRate), @years)

	RETURN ROUND(@futureValue,4);
END;

GO
-- Example usage:
SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5) AS FutureValue;
GO

-- Exercise 12: Calculating Interest
CREATE PROCEDURE usp_CalculateFutureValueForAccount
	(@accountId INT, @interestRate FLOAT)
AS
BEGIN
	SELECT
		a.Id AS [Account Id],
		ah.FirstName AS [First Name],
		ah.LastName AS [Last Name],
		a.Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM Accounts AS a
	JOIN AccountHolders AS ah
		ON a.AccountHolderId = ah.Id
	WHERE a.Id = @accountId;
END;

-- Example usage:
EXEC usp_CalculateFutureValueForAccount 1, 0.1;
GO

-- Exercise 13: Cash in User Games Odd Rows
USE Diablo;
GO

CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
	WITH RankedGames AS
	(
		SELECT 
			ug.Cash,
			ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNumber
		FROM UsersGames AS ug
		JOIN Games AS g
			ON ug.GameId = g.Id
		WHERE g.Name = @gameName
	)

	SELECT
		SUM(Cash) AS [SumCash]
	FROM RankedGames
	WHERE RowNumber % 2 = 1
);

GO

-- Example usage:
SELECT *
FROM dbo.ufn_CashInUsersGames('Love in a mist');