-- Exercise 1: Create Database
CREATE DATABASE Minions
GO

USE Minions

-- Exercise 2: Create Tables
CREATE TABLE Minions (
	Id INT PRIMARY KEY,
	Name VARCHAR(50),
	Age INT
)
GO

CREATE TABLE Towns (
	Id INT PRIMARY KEY,
	Name VARCHAR(50)
)
GO

-- Exercise 3: Alter Minions Table
ALTER TABLE Minions
ADD TownId INT;
GO

ALTER TABLE Minions
ADD CONSTRAINT FK_Minions_Towns
FOREIGN KEY (TownId) REFERENCES Towns(Id);
GO

-- Exercise 4: Insert Records in Both Tables
INSERT INTO Towns (Id, Name)
VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna');

INSERT INTO Minions (Id, Name, Age, TownId)
VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2);

-- Exercise 5: Truncate Table Minions
DELETE FROM Minions;

-- Exercise 6: Drop All Tables
---- Disable foreign key constraints temporarily
EXEC sp_MSforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT ALL";
GO

---- Drop all tables
EXEC sp_MSforeachtable "DROP TABLE ?"
GO

-- Exercise 7: Create Table People
CREATE TABLE People(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) NULL,
	Height DECIMAL(5,2) NULL,
	Weight DECIMAL(6,2) NULL,
	Gender CHAR(1) NOT NULL CHECK (Gender IN ('m', 'f')),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX) NULL,
)

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES
(N'Ivan Ivanov', NULL, '1.70', '100.00', 'm', '1990-06-01', N'Ivan Ivanov is great person.'),
(N'Boris Borisov', NULL, '1.90', '100.00', 'm', '1900-02-22', N'Boris Borisov is great person.'),
(N'Magdalena Morska', NULL, '1.66', '76.20', 'f', '2000-01-10', N'Magdalena Morska is great person.'),
(N'Petyr Petrov', NULL, '1.55', '50.12', 'm', '2010-03-21', N'Petyr Petrov is great person.'),
(N'Venelin Venelinov', NULL, '1.92', '92.22', 'm', '2000-01-02', N'Venelin Venelinov is great person.');
GO

-- Exercise 8: Create Table Users
CREATE TABLE Users(
	Id BIGINT IDENTITY(1,1) PRIMARY KEY,
	Username VARCHAR(30) NOT NULL UNIQUE,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) NULL,
	LastLoginTime DATETIME NULL,
	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT CK_ProfilePicture_Size
		CHECK (ProfilePicture IS NULL OR DATALENGTH(ProfilePicture) <= 921600)
);

INSERT INTO Users (Username, Password, ProfilePicture, LastLoginTime, IsDeleted) 
VALUES
('username1', '123abc123', CAST(0x1234 AS VARBINARY), '2025-10-01 09:15:00', 0),
('bob_smith123', '123abc123qw', NULL, NULL, 0),
('maria_petrova', '123maria', CAST(0x1234 AS VARBINARY), '2025-10-01 19:15:00', 0),
('john_atanasov', 'johnpassword123', CAST(0x1234 AS VARBINARY), '2025-10-01 6:15:10', 0),
('benjamin23', 'benpassword123', CAST(0x1234 AS VARBINARY), '2025-10-01 6:15:10', 1);
GO

-- Exercise 9: Change Primary Key
---- Drop the current primary key constraint
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC0736BD370E

---- Create new composite primary key (Id + Username)
ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id_Username PRIMARY KEY (Id, Username);
GO

-- Exercise 10: Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CK_Users_Password_Length
	CHECK (LEN(Password) >= 5);
GO

-- Exercise 11: Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT (GETDATE()) FOR LastLoginTime;
GO

-- Exercise 12: Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT PK_Users_Id_Username;

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id PRIMARY KEY (Id);

ALTER TABLE Users
ADD CONSTRAINT UQ_Users_Username UNIQUE (Username),
	CONSTRAINT CK_Users_Username_Length CHECK (LEN(Username) >= 3);
GO

-- Exercise 13: Movies Database
---- Prerequisites:
CREATE DATABASE Movies;
GO

USE Movies;
GO
---- Actual exercise:
CREATE TABLE Directors
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	DirectorName VARCHAR(100) NOT NULL,
	Notes VARCHAR(500) NULL
);

CREATE TABLE Genres
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	GenreName VARCHAR(50) NOT NULL,
	Notes VARCHAR(500) NULL
);

CREATE TABLE Categories
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	CategoryName VARCHAR(50) NOT NULL,
	Notes VARCHAR(500) NULL
);

CREATE TABLE Movies
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Title VARCHAR(200) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear INT NOT NULL,
	Length INT NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating DECIMAL(2,1) NULL,
	Notes VARCHAR(1000) NULL,

	CONSTRAINT FK_Movies_Directors FOREIGN KEY (DirectorId) REFERENCES Directors(Id),
	CONSTRAINT FK_Movies_Genres FOREIGN KEY (GenreId) REFERENCES Genres(Id),
	CONSTRAINT FK_Movies_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

INSERT INTO Directors (DirectorName, Notes) VALUES
('Christopher Nolan', 'Known for mind-bending films'),
('Steven Spielberg', 'Famous for blockbusters'),
('Quentin Tarantino', 'Unique dialogue-driven style'),
('Martin Scorsese', 'Focuses on crime and drama'),
('James Cameron', 'Sci-fi and epic scale films');

INSERT INTO Genres (GenreName, Notes) VALUES
('Action', 'High intensity movies'),
('Drama', 'Character driven stories'),
('Comedy', 'Humorous plots'),
('Sci-Fi', 'Science fiction themes'),
('Thriller', 'Suspense and excitement');

INSERT INTO Categories (CategoryName, Notes) VALUES
('Blockbuster', 'Big budget, mainstream'),
('Indie', 'Independent production'),
('Classic', 'Timeless old films'),
('Documentary', 'Non-fiction stories'),
('Animated', 'Cartoons and CGI films');

INSERT INTO Movies (Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes) VALUES
('Inception', 1, 2010, 148, 4, 1, 8.8, 'Dream within a dream'),
('Jurassic Park', 2, 1993, 127, 1, 1, 8.1, 'Dinosaurs reborn'),
('Pulp Fiction', 3, 1994, 154, 2, 2, 8.9, 'Non-linear storytelling'),
('The Irishman', 4, 2019, 209, 2, 2, 7.8, 'Crime and aging'),
('Avatar', 5, 2009, 162, 4, 1, 7.9, 'Epic sci-fi world');
GO

-- Exercise 14: Car Rental Database
---- Prerequisites:
CREATE DATABASE CarRental
GO

USE CarRental
GO

---- Actual exercise:
CREATE TABLE Categories
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate DECIMAL(10,2) NOT NULL,
	WeeklyRate DECIMAL(10,2) NOT NULL,
	MonthlyRate DECIMAL(10,2) NOT NULL,
	WeekendRate DECIMAL(10,2) NOT NULL
);

CREATE TABLE Cars
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	PlateNumber VARCHAR(15) NOT NULL UNIQUE,
	Manufacturer VARCHAR(50) NOT NULL,
	Model VARCHAR(50) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT NOT NULL,
	Doors TINYINT NOT NULL,
	Picture VARBINARY(MAX) NULL,
	Condition VARCHAR(100) NULL,
	Available BIT NOT NULL DEFAULT 1,
	CONSTRAINT FK_Cars_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

CREATE TABLE Employees
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Title VARCHAR(50) NULL,
	Notes VARCHAR(1000) NULL
);

CREATE TABLE Customers
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	DriverLicenceNumber VARCHAR(20) NOT NULL UNIQUE,
	FullName VARCHAR(100) NOT NULL,
	Address VARCHAR(200) NOT NULL,
	City VARCHAR(100) NOT NULL,
	ZipCode VARCHAR(10) NOT NULL,
	Notes VARCHAR(500) NULL,
);

CREATE TABLE RentalOrders
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel DECIMAL(4,1) NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NULL,
	TotalKilometrage INT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NULL,
	TotalDays INT NULL,
	RateApplied DECIMAL(10,2) NOT NULL, 
	TaxRate DECIMAL(4,2) NOT NULL,
	OrderStatus VARCHAR(20) NOT NULL,
	Notes VARCHAR(1000) NULL,

	CONSTRAINT FK_RentalOrders_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_RentalOrders_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
	CONSTRAINT FK_RentalOrders_Cars FOREIGN KEY (CarId) REFERENCES Cars(Id),
);

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Economy', 30.00, 180.00, 700.00, 50.00),
('SUV', 60.00, 350.00, 1300.00, 90.00),
('Luxury', 120.00, 700.00, 2500.00, 180.00);

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('ABC123', 'Toyota', 'Corolla', 2020, 1, 4, NULL, 'Good condition', 1),
('XYZ789', 'BMW', 'X5', 2021, 2, 5, NULL, 'Excellent condition', 1),
('LMN456', 'Mercedes', 'S-Class', 2019, 3, 4, NULL, 'Minor scratches', 0);

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
('John', 'Smith', 'Manager', 'Oversees rental operations'),
('Alice', 'Johnson', 'Sales Rep', 'Handles customer interactions'),
('Robert', 'Brown', 'Mechanic', 'Responsible for vehicle maintenance');

INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes) VALUES
('DL1001', 'Michael Green', '123 Main St', 'New York', '10001', 'Frequent renter'),
('DL1002', 'Sarah White', '456 Oak Ave', 'Los Angeles', '90001', NULL),
('DL1003', 'David Black', '789 Pine Rd', 'Chicago', '60601', 'VIP customer');

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1, 1, 1, 100.0, 15000, 15200, 200, '2025-09-01', '2025-09-05', 4, 30.00, 0.10, 'Completed', 'No issues'),
(2, 2, 2, 80.0, 5000, 5150, 150, '2025-09-10', '2025-09-13', 3, 60.00, 0.10, 'Completed', 'Returned early'),
(3, 3, 3, 90.0, 25000, NULL, NULL, '2025-10-01', NULL, NULL, 120.00, 0.15, 'Ongoing', 'Luxury rental still active');

-- Exercise 15: Hotel Database
---- Prerequsites:
CREATE DATABASE Hotel
GO

USE Hotel
GO

---- Actual Exercise:
CREATE TABLE Employees
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50), 
	Notes NVARCHAR(255)
);

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
('John', 'Smith', 'Manager', 'Oversees operations'),
('Anna', 'Brown', 'Receptionist', 'Handles front desk duties'),
('Mark', 'Taylor', 'Accountant', 'Manages financials');

CREATE TABLE Customers
(
	AccountNumber INT IDENTITY(1001,1) PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber NVARCHAR(15) NOT NULL,
	EmergencyName NVARCHAR(100),
	EmergencyNumber NVARCHAR(15),
	Notes NVARCHAR(255),
);

INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
('Michael', 'Green', '555-1000', 'Sarah Green', '555-2000', 'Regular guest'),
('Emily', 'Johnson', '555-3000', 'Tom Johnson', '555-4000', 'Prefers sea view'),
('David', 'Lee', '555-5000', NULL, NULL, 'New customer');

CREATE TABLE RoomStatus
(
	RoomStatus NVARCHAR(20) PRIMARY KEY,
	Notes NVARCHAR(255) NULL,
);

INSERT INTO RoomStatus (RoomStatus, Notes) VALUES
('Available', 'Room is ready for booking'),
('Occupied', 'Currently occupied by a guest'),
('Maintenance', 'Undergoing repairs');

CREATE TABLE RoomTypes
(
	RoomType NVARCHAR(20) PRIMARY KEY,
	Notes NVARCHAR(255) NULL,
);

INSERT INTO RoomTypes (RoomType, Notes) VALUES
('Single', 'Single bed for one person'),
('Double', 'Double bed for two persons'),
('Suite', 'Luxury suite with living area');

CREATE TABLE BedTypes
(
	BedType NVARCHAR(20) PRIMARY KEY,
	Notes NVARCHAR(255) NULL,
);

INSERT INTO BedTypes (BedType, Notes) VALUES
('Twin', 'Two single beds'),
('Queen', 'One queen bed'),
('King', 'One king-sized bed');

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType NVARCHAR(20) NOT NULL,
	BedType NVARCHAR(20) NOT NULL,
	Rate DECIMAL(10,2) NOT NULL,
	RoomStatus NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(255) NULL,

	CONSTRAINT FK_Rooms_RoomTypes FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType),
	CONSTRAINT FK_Rooms_BedTypes FOREIGN KEY (BedType) REFERENCES BedTypes(BedType),
	CONSTRAINT FK_Rooms_RoomStatus FOREIGN KEY (RoomStatus) REFERENCES RoomStatus(RoomStatus)
);

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(101, 'Single', 'Queen', 80.00, 'Available', 'Near lobby'),
(202, 'Double', 'Twin', 120.00, 'Occupied', 'Has balcony'),
(303, 'Suite', 'King', 250.00, 'Maintenance', 'Sea view suite');

CREATE TABLE Payments
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	EmployeeId INT NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(10,2) NOT NULL,
	TaxRate DECIMAL(5,2) NOT NULL,
	TaxAmount AS (AmountCharged * (TaxRate / 100)) PERSISTED,
	PaymentTotal AS (AmountCharged + (AmountCharged * (TaxRate / 100))) PERSISTED,
	Notes NVARCHAR(255),

	CONSTRAINT FK_Payments_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_Payments_Customers FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber),
);

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, Notes) VALUES
(1, '2025-09-01', 1001, '2025-08-25', '2025-08-30', 5, 500.00, 10.00, 'Paid in full'),
(2, '2025-09-10', 1002, '2025-09-05', '2025-09-08', 3, 360.00, 8.00, 'Credit card'),
(3, '2025-09-20', 1003, '2025-09-15', '2025-09-19', 4, 480.00, 9.00, 'Late payment');

CREATE TABLE Occupancies
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	EmployeeId INT NOT NULL,
	DateOccupied DATE NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied DECIMAL(10,2) NOT NULL,
	PhoneCharge DECIMAL(10,2) DEFAULT 0.00,
	Notes NVARCHAR(255),

	CONSTRAINT FK_Occupancies_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_Occupancies_Customers FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber),
	CONSTRAINT FK_Occupancies_Rooms FOREIGN KEY (RoomNumber) REFERENCES Rooms(RoomNumber),
);

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(2, '2025-08-25', 1001, 101, 80.00, 5.00, 'Checked in at 2 PM'),
(1, '2025-09-05', 1002, 202, 120.00, 0.00, 'Business stay'),
(3, '2025-09-15', 1003, 303, 250.00, 10.00, 'VIP guest');

-- Exercise 16: Create SoftUni Database
CREATE DATABASE SoftUni;
GO

USE SoftUni;
GO

CREATE TABLE Towns
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
);
GO

CREATE TABLE Addresses
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	AddressText NVARCHAR(200) NOT NULL,
	TownId INT NULL,

	CONSTRAINT FK_Addresses_Towns FOREIGN KEY (TownId) 
		REFERENCES Towns(Id)
		ON DELETE SET NULL
		ON UPDATE CASCADE
);
GO

CREATE TABLE Departments
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
);
GO

CREATE TABLE Employees
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50) NULL,
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(100) NOT NULL,
	DepartmentId INT NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(15,2) NOT NULL,
	AddressId INT NULL,

	CONSTRAINT FK_Employees_Departments FOREIGN KEY (DepartmentId) 
		REFERENCES Departments(Id)
		ON DELETE NO ACTION
		ON UPDATE CASCADE,
	CONSTRAINT FK_Employees_Addresses FOREIGN KEY (AddressId) 
		REFERENCES Addresses(Id)
		ON DELETE SET NULL
		ON UPDATE CASCADE
);
GO

-- Exercise 17: Backup Database
BACKUP DATABASE SoftUni
TO DISK = 'C:\Trainings\softuni-backup.bak'
WITH FORMAT,
	INIT,
	NAME = 'SoftUni-Full Backup',
	SKIP,
	NOREWIND,
	NOUNLOAD,
	STATS = 10;
GO

---- Delete (drop) the SoftUni database
USE master;
GO
DROP DATABASE SoftUni;
GO

---- Restore the SoftUni database from backup
RESTORE DATABASE SoftUni
FROM DISK = 'C:\Trainings\softuni-backup.bak'
WITH MOVE 'SoftUni' TO 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SoftUni.mdf',
	 MOVE 'SoftUni_log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SoftUni_log.ldf',
     REPLACE,
	 STATS = 10;

---- For finding the correct file path execute: SELECT SERVERPROPERTY('InstanceDefaultDataPath') AS DefaultDataPath;

-- Exercise 18: Basic insert
USE SoftUni
GO

INSERT INTO Towns (Name) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas');

INSERT INTO Departments (Name) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance');

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 
	(SELECT Id FROM Departments WHERE Name = 'Software Development'),
	'2013-02-01', 3500.00, NULL),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer',
    (SELECT Id FROM Departments WHERE Name = 'Engineering'),
    '2004-03-02', 4000.00, NULL),
('Maria', 'Petrova', 'Ivanova', 'Intern',
    (SELECT Id FROM Departments WHERE Name = 'Quality Assurance'),
    '2016-08-28', 525.25, NULL),
('Georgi', 'Teziev', 'Ivanov', 'CEO',
    (SELECT Id FROM Departments WHERE Name = 'Sales'),
    '2007-12-09', 3000.00, NULL),
('Peter', 'Pan', 'Pan', 'Intern',
    (SELECT Id FROM Departments WHERE Name = 'Marketing'),
    '2016-08-28', 599.88, NULL);

-- Exercise 19: Basic Select All Fields
SELECT * FROM Towns;
SELECT * FROM Departments;
SELECT * FROM Employees;

-- Exercise 20: Basic Select All Fields and Order Them
SELECT * FROM Towns 
ORDER BY Name ASC;

SELECT * FROM Departments
ORDER BY Name ASC;

SELECT * FROM Employees
ORDER BY Salary DESC;

-- Exercise 21: Basic Select Some Fields
SELECT Name FROM Towns
ORDER BY Name ASC;

SELECT Name FROM Departments
ORDER BY Name ASC;

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC;

-- Exercise 22: Increase Employees Salary
UPDATE Employees
SET Salary = Salary * 1.10;

SELECT Salary FROM Employees;

-- Exercise 23: Decrease Tax Rate
---- Prerequisites:
USE Hotel;

---- Actual Exercise:
UPDATE Payments
SET TaxRate = TaxRate * 0.97;

SELECT TaxRate FROM Payments;

-- Exercise 24: Delete All Records
---- Solution 1:
TRUNCATE TABLE Occupancies;

---- Solution 2:
DELETE FROM Occupancies;