-- Exercise 2: Find all the Information About Departments
SELECT * FROM Departments;

-- Exercise 3: Find all Department Names
SELECT [Name] FROM Departments;

-- Exercise 4: Find Salary of Each Employee
SELECT [FirstName], [LastName], [Salary] FROM Employees;

-- Exercise 5: Find Full Name of Each Employee
SELECT [FirstName], [MiddleName], [LastName] FROM Employees;

-- Exercise 6: Find Email Address of Each Employee
SELECT 
	[FirstName] + '.' + [LastName] + '@softuni.bg' AS 'Full Email Address'
FROM 
	Employees;

-- Exercise 7: Find All Different Employees' Salaries
SELECT DISTINCT [Salary] FROM Employees;

-- Exercise 8: Find All Information About Employees
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative';

-- Exercise 9: Find Names of All Employees by Salary in Range
SELECT [FirstName], [LastName], [JobTitle]
FROM Employees
WHERE [Salary] >= 20000 AND [Salary] <= 30000;

---- Using Between:
SELECT [FirstName], [LastName], [JobTitle]
FROM Employees
WHERE [Salary] BETWEEN 20000 AND 30000;

-- Exercise 10: Find Names of All Employees
SELECT CONCAT_WS(' ', [FirstName], [MiddleName], [LastName]) AS 'Full Name' 
FROM Employees
WHERE [Salary] IN (25000, 14000, 12500, 23600);

-- Exercise 11: Find All Employees Without a Manager
SELECT [FirstName], [LastName] 
FROM Employees
WHERE [ManagerID] IS NULL;

-- Exercise 12: Find All Employees with a Salary More Than 50000
SELECT [FirstName], [LastName], [Salary]
FROM Employees
WHERE [Salary] > 50000
ORDER BY [Salary] DESC;

-- Exercise 13: Find 5 Best Paid Employees
SELECT TOP 5 [FirstName], [LastName]
FROM Employees
ORDER BY [Salary] DESC;

-- Exercise 14: Find All Employees Except Marketing
SELECT [FirstName], [LastName]
FROM Employees
WHERE DepartmentID <> 4;

---- Solution 2:
SELECT [FirstName], [LastName]
FROM Employees
WHERE DepartmentID != 4;

-- Exercise 15: Sort Employees Table
SELECT *
FROM Employees
ORDER BY 
	[Salary] DESC,
	[FirstName] ASC,
	[LastName] DESC,
	[MiddleName] ASC;

GO
-- Exercise 16: Create View Employees with Salaries
CREATE VIEW V_EmployeesSalaries AS
SELECT [FirstName], [LastName], [Salary]
FROM Employees;

GO
---- to query the view like a regular table: SELECT * FROM V_EmployeesSalaries;

-- Exercise 17: Create View Employees with Job Titles
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT 
	CONCAT_WS(' ', [FirstName], ISNULL([MiddleName], ''), [LastName]) AS [Full Name], 
	[JobTitle]
FROM Employees;

GO

-- Exercise 18: Distinct Job Titles
SELECT DISTINCT [JobTitle]
FROM Employees;

-- Exercise 19: Find First 10 Started Projects
SELECT TOP 10 *
FROM Projects
ORDER BY
	[StartDate] ASC,
	[Name] ASC;

-- Exercise 20: Last 7 Hired Employees
SELECT TOP 7 [FirstName], [LastName], [HireDate]
FROM Employees
ORDER BY
	[HireDate] DESC;

-- Exercise 21: Increase Salaries
BEGIN TRANSACTION;

UPDATE Employees
SET [Salary] = [Salary] * 1.12
WHERE DepartmentID IN (
	SELECT [DepartmentID]
	FROM Departments
	WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services'));

SELECT [Salary]
FROM Employees;

ROLLBACK TRANSACTION;

-- Exercise 22: All Mountain Peaks
-- Prerequisites:
USE Geography;
GO

-- Actual Exercise:
SELECT [PeakName]
FROM Peaks
ORDER BY PeakName ASC;

-- Exercise 23: Biggest Countries by Population
SELECT TOP 30 [CountryName], [Population]
FROM Countries
WHERE [ContinentCode] = 'EU'
ORDER BY 
	[Population] DESC,
	[CountryName] ASC;
	
-- Exercise 24: Countries and Currency (Euro / Not Euro)
SELECT 
	[CountryName], 
	[CountryCode],
		CASE
			WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
			ELSE 'Not Euro'
		END AS [Currency]
FROM 
	Countries
ORDER BY
	[CountryName] ASC;

-- Exercise 25: All Diablo Characters
-- Prerequisites:
USE Diablo;
GO

-- Actual Exercise:
SELECT [Name] FROM Characters
ORDER BY [Name] ASC;