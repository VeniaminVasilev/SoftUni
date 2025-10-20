-- Exercise 1: One-To-One Relationship
-- Prerequsites:
CREATE DATABASE Exercise1;
GO

USE Exercise1;

-- Actual Exercise:
CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	PassportNumber CHAR(8) NOT NULL,
);

INSERT INTO Passports (PassportNumber) 
VALUES
	('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2');

CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	Salary DECIMAL(12,2) NOT NULL,
	PassportID INT UNIQUE NOT NULL,

	CONSTRAINT FK_Persons_Passports FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)
);

INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101);

-- Exercise 2: One-To-Many-Relationship
-- Prerequisites:
CREATE DATABASE Exercise2;
GO

USE Exercise2;

-- Actual exercise:
CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	EstablishedOn DATE NOT NULL,
);

CREATE TABLE Models
(
	ModelID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	ManufacturerID INT NOT NULL,

	CONSTRAINT FK_Models_Manufacturers FOREIGN KEY ([ManufacturerID]) REFERENCES Manufacturers([ManufacturerID])
);

INSERT INTO Manufacturers(Name, EstablishedOn)
VALUES
	('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966');

INSERT INTO Models(Name, ManufacturerID)
VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3);

-- Exercise 3: Many-To-Many Relationship
-- Prerequisites:
CREATE DATABASE Exercise3;
GO

USE Exercise3;

-- Actual Exercise:
CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) NOT NULL,
);

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	Name VARCHAR(50) NOT NULL,
);

CREATE TABLE StudentsExams
(
	StudentID INT FOREIGN KEY REFERENCES Students([StudentID]),
	ExamID INT FOREIGN KEY REFERENCES Exams([ExamID]),

	CONSTRAINT PK_StudentsExams_Students_Exams PRIMARY KEY ([StudentID], [ExamID])
);

INSERT INTO Students([Name])
VALUES
	('Mila'),
	('Toni'),
	('Ron');

INSERT INTO Exams([Name])
VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g');

INSERT INTO StudentsExams(StudentID, ExamID)
VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103);

-- Exercise 4: Self-Referencing
-- Prerequisites:
CREATE DATABASE Exercise4;
GO

USE Exercise4;

-- Actual Exercise:
CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	ManagerID INT NULL,

	CONSTRAINT FK_ManagerID_TeacherID FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
);

INSERT INTO Teachers(Name, ManagerID)
VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101);

-- Exercise 5: Online Store Database
-- Prerequisites:
CREATE DATABASE OnlineStoreDatabase;
GO

USE OnlineStoreDatabase;

-- Actual Exercise:
CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) NOT NULL
);

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	ItemTypeID INT NOT NULL,

	CONSTRAINT FK_Items_ItemTypes FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
);

CREATE TABLE Cities
(
	CityID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) NOT NULL
);

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,
	CityID INT NOT NULL,

	CONSTRAINT FK_Customers_Cities FOREIGN KEY (CityID) REFERENCES Cities(CityID)
);

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CustomerID INT NOT NULL,

	CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderItems
(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID) NOT NULL,
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID) NOT NULL,

	CONSTRAINT PK_OrderItems_Orders_Items PRIMARY KEY ([OrderID], [ItemID])
);

-- Exercise 6: University Database
-- Prerequisites:
CREATE DATABASE UniversityDatabase;
GO

USE UniversityDatabase;

-- Actual Exercise:
CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) NOT NULL
);

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	StudentNumber INT NOT NULL,
	StudentName VARCHAR(50) NOT NULL,
	MajorID INT NOT NULL,

	CONSTRAINT FK_Students_Majors FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)
);

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(12,2) NOT NULL,
	StudentID INT NOT NULL,

	CONSTRAINT FK_Payments_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
);

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	SubjectName VARCHAR(50) NOT NULL
);

CREATE TABLE Agenda
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID) NOT NULL,

	CONSTRAINT PK_Agenda_Students_Subjects PRIMARY KEY ([StudentID], [SubjectID])
);

-- Exercise 9: Peaks in Rila
SELECT
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM Peaks AS p
JOIN Mountains AS m
	ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC;
