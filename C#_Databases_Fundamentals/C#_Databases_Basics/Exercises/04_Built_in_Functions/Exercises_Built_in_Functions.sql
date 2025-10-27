-- Exercise 1: Find Names of All Employees by First Name
-- Prerequisites:
USE SoftUni;
GO

-- Actual exercise:
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'Sa%';

-- Exercise 2: Find Names of All Employees by Last Name
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%';

-- Exercise 3: Find First Names of All Employees
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10)
AND YEAR(HireDate) BETWEEN 1995 AND 2005;

-- Exercise 4: Find All Employees Except Engineers
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%';

-- Exercise 5: Find Towns with Name Length
SELECT Name
FROM Towns
WHERE LEN(Name) IN (5, 6)
ORDER BY Name;

-- Exercise 6: Find Towns Starting With
SELECT [TownID], [Name]
FROM Towns
WHERE [Name] LIKE 'M%'
   OR [Name] LIKE 'K%'
   OR [Name] LIKE 'B%'
   OR [Name] LIKE 'E%'
ORDER BY [Name];

-- Exercise 7: Find Towns Not Starting With
SELECT [TownID], [Name]
FROM Towns
WHERE [Name] NOT LIKE 'R%'
  AND [Name] NOT LIKE 'B%'
  AND [Name] NOT LIKE 'D%'
ORDER BY [Name];

GO

-- Exercise 8: Create View Employees Hired After 2000 Year
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE YEAR(HireDate) > 2000;

GO

-- Exercise 9: Length of Last Name
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5;

-- Exercise 10: Rank Employees by Salary
SELECT EmployeeID, FirstName, LastName, Salary,
       DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS RANK
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC;

-- Exercise 11: Find All Employees with Rank 2
SELECT EmployeeID, FirstName, LastName, Salary, Rank
FROM (
    SELECT EmployeeID, FirstName, LastName, Salary,
           DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS RANK
    FROM Employees
    WHERE Salary BETWEEN 10000 AND 50000
) AS RankedEmployees
WHERE RANK = 2
ORDER BY Salary DESC;

-- Exercise 12: Countries Holding 'A' 3 or More Times
-- Prerequisites:
USE Geography;
GO

-- Actual exercise:
SELECT [CountryName], 
       [IsoCode] AS 'ISO Code'
FROM Countries
WHERE LOWER([CountryName]) LIKE '%a%a%a%'
ORDER BY [IsoCode];

-- Exercise 13: Mix of Peak and River Names
SELECT p.PeakName,
       r.RiverName,
       LOWER(
            p.PeakName +
            SUBSTRING(r.RiverName, 2, LEN(r.RiverName) - 1)
       ) AS Mix
FROM Peaks AS p
JOIN Rivers AS r
    ON LOWER(RIGHT(p.PeakName, 1)) = LOWER(LEFT(r.RiverName, 1))
ORDER BY Mix;

-- Exercise 14: Games from 2011 and 2012 Year
-- Prerequisites:
USE Diablo;
GO

-- Actual Exercise:
SELECT TOP 50
    [Name], 
    FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY [Start], [Name];

-- Exercise 15: User Email Providers
SELECT 
    [Username], 
    RIGHT([Email], LEN([Email]) - CHARINDEX('@', [Email])) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], [Username];

-- Exercise 16: Get Users with IP Address Like Pattern
SELECT
    [Username],
    [IpAddress] AS [IP Address]
FROM Users
WHERE [IpAddress] LIKE '___.1%.%.___'
ORDER BY [Username];

-- Exercise 17: Show All Games with Duration and Part of the Day
SELECT 
    [Name] AS [Game],
    CASE
        WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
        WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
        WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
    END AS [Part of the Day],
    CASE
        WHEN [Duration] IS NULL THEN 'Extra Long'
        WHEN [Duration] <= 3 THEN 'Extra Short'
        WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
        WHEN [Duration] >= 6 THEN 'Long'
    END AS [Duration]
FROM Games
ORDER BY 
    [Game],
    [Duration],
    [Part of the Day];

-- Exercise 18: Orders Table
-- Prerequisites:
USE Orders;
GO

-- Actual Exercise:
SELECT 
    [ProductName],
    [OrderDate],
    DATEADD(DAY, 3, [OrderDate]) AS [Pay Due],
    DATEADD(MONTH, 1, [OrderDate]) AS [Delivery Due]
FROM Orders;

-- Exercise 19: People Table
CREATE DATABASE People;
GO
USE People;
GO

CREATE TABLE People
(
    [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Name] VARCHAR(50) NOT NULL,
    [BirthDate] DATETIME2 NOT NULL,
);

INSERT INTO People ([Name], [Birthdate]) VALUES
    ('Victor', '2000-12-07 00:00:00.000'),
    ('Steven', '1992-09-10 00:00:00.000'),
    ('Stephen', '1910-09-19 00:00:00.000'),
    ('John', '2010-01-06 00:00:00.000'),
    ('Veniamin', '1994-06-24 00:00:00.000'),
    ('Spaska', '1997-06-28 00:00:00.000'),
    ('Ivan', '2016-02-01 00:00:00.000');

SELECT 
    [Name],
    DATEDIFF(YEAR, [BirthDate], GETDATE()) AS [Age in Years],
    DATEDIFF(MONTH, [BirthDate], GETDATE()) AS [Age in Months],
    DATEDIFF(DAY, [BirthDate], GETDATE()) AS [Age in Days],
    DATEDIFF(MINUTE, [BirthDate], GETDATE()) AS [Age in Minutes]
FROM People;
