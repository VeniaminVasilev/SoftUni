-- Exercise 1: Employee Address
SELECT TOP 5
	e.EmployeeID, 
	e.JobTitle, 
	e.AddressID,
	a.AddressText
FROM Employees AS e
JOIN Addresses AS a
	ON e.AddressID = a.AddressID
ORDER BY e.AddressID;

-- Exercise 2: Addresses with Towns
SELECT TOP 50
	e.FirstName,
	e.LastName,
	t.Name AS [Town],
	a.AddressText
FROM Employees AS e
JOIN Addresses AS a
	ON e.AddressID = a.AddressID
JOIN Towns AS t
	ON a.TownID = t.TownID
ORDER BY e.FirstName ASC, e.LastName ASC;

-- Exercise 3: Sales Employee
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.Name AS [DepartmentName]
FROM Employees AS e
JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID ASC;

-- Exercise 4: Employee Departments
SELECT TOP 5
	e.EmployeeID,
	e.FirstName,
	e.Salary,
	d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID ASC;

-- Exercise 5: Employees Without Project
SELECT TOP 3
	e.EmployeeID,
	e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep
	ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID ASC;

-- Exercise 6: Employees Hired After
SELECT 
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.[Name] AS [DeptName]
FROM Employees AS e
JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01'
	AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate ASC;

-- Exercise 7: Employees with Project
SELECT TOP 5 
	e.EmployeeID,
	e.FirstName,
	p.[Name] AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS ep
	ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
	ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13'
	AND p.EndDate IS NULL
ORDER BY e.EmployeeID ASC;

-- Exercise 8: Employee 24
SELECT
	e.EmployeeID,
	e.FirstName,
	CASE
		WHEN p.StartDate >= '2005-01-01' THEN NULL
		ELSE p.[Name]
	END AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS ep
	ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
	ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24;

-- Exercise 9: Employee Manager
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.ManagerID,
	m.FirstName AS [ManagerName]
FROM Employees AS e
JOIN Employees AS m
	ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID ASC;

-- Exercise 10: Employees Summary
SELECT TOP 50
	e.EmployeeID,
	CONCAT_WS(' ', e.FirstName, e.LastName) AS [EmployeeName],
	CONCAT_WS(' ', m.FirstName, m.LastName) AS [ManagerName],
	d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Employees AS m
	ON e.ManagerID = m.EmployeeID
JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID ASC;

-- Exercise 11: Min Average Salary
SELECT
	MIN(AvgSalary) AS [MinAvgSalary]
FROM (
	SELECT
		AVG(Salary) AS [AvgSalary]
	FROM Employees
	GROUP BY DepartmentID
) AS DeptAverages;

-- Exercise 12: Highest Peaks in Bulgaria
USE Geography;
GO

SELECT
	c.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m
	ON mc.MountainId = m.Id
JOIN Peaks AS p
	ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG'
	AND p.Elevation > 2835
ORDER BY p.Elevation DESC;

-- Exercise 13: Count Mountain Ranges
SELECT
	c.CountryCode,
	COUNT(m.MountainRange) AS [MountainRanges]
FROM Countries AS c
JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m
	ON mc.MountainId = m.Id
WHERE c.CountryCode IN ('US', 'RU', 'BG')
GROUP BY c.CountryCode;

-- Exercise 14: Countries With or Withour Rivers
SELECT TOP 5
	c.CountryName,
	r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
	ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
	ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName ASC;

-- Exercise 15: Continents and Currencies
-- Solution using Common Table Expression (CTE)
WITH CurrencyStats AS (
	SELECT
		c.ContinentCode,
		c.CurrencyCode,
		COUNT(c.CountryCode) AS [CurrencyUsage],
		RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CountryCode) DESC) AS [RankByUsage]
	FROM Countries AS c
	GROUP BY c.ContinentCode, c.CurrencyCode
	HAVING Count(c.CountryCode) > 1
)
SELECT
	ContinentCode,
	CurrencyCode,
	CurrencyUsage
FROM CurrencyStats
WHERE [RankByUsage] = 1
ORDER BY ContinentCode ASC;

-- Exercise 16: Countries Without Any Mountains
SELECT
	COUNT(*) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
WHERE mc.MountainId IS NULL;

-- Exercise 17: Highest Peak and Longest River by Country
SELECT TOP 5
	c.CountryName,
	MAX(p.Elevation) AS [HighestPeakElevation],
	MAX(r.[Length]) AS [LongestRiverLength]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m
	ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p
	ON m.Id = p.MountainId
LEFT JOIN CountriesRivers AS cr
	ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
	ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY 
	MAX(p.Elevation) DESC, 
	MAX(r.[Length]) DESC, 
	c.CountryName ASC;

-- Exercise 18: Highest Peak Name and Elevation by Country
WITH HighestPeaks AS
(
	SELECT 
		c.CountryName AS [Country],
		p.PeakName,
		p.Elevation,
		m.MountainRange,
		RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeakRank
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
		ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m
		ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p
		ON m.Id = p.MountainId
)
SELECT TOP 5
	Country,
	ISNULL(PeakName, '(no highest peak)') AS [Highest Peak Name],
	ISNULL(Elevation, '0') AS [Highest Peak Elevation],
	ISNULL(MountainRange, '(no mountain)') AS [Mountain]
FROM HighestPeaks
WHERE PeakRank = 1 OR PeakRank IS NULL
ORDER BY 
	Country ASC,
	[Highest Peak Name] ASC;