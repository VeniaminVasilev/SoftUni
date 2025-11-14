-- Exercise 1: Records' Count
USE Gringotts
GO

SELECT COUNT(*) AS [Count]
FROM WizzardDeposits;

-- Exercise 2: Longest Magic Wand
SELECT MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits

-- Exercise 3: Longest Magic Wand Per Deposit Groups
SELECT 
	DepositGroup,
	MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup

-- Exercise 4: Smallest Deposit Group Per Magic Wand Size
SELECT TOP 2
	DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

-- Exercise 5: Deposits Sum
SELECT
	DepositGroup,
	SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
GROUP BY DepositGroup

-- Exercise 6: Deposits Sum for Ollivander Family
SELECT
	DepositGroup,
	SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

-- Exercise 7: Deposits Filter
SELECT
	DepositGroup,
	SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY SUM(DepositAmount) DESC;

-- Exercise 8: Deposit Charge
SELECT 
	DepositGroup,
	MagicWandCreator,
	MIN(DepositCharge) AS [MinDepositCharge]
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup;

-- Exercise 9: Age Groups
SELECT
	CASE
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
	END AS [AgeGroup],
	COUNT(*) AS [WizardCount]
FROM WizzardDeposits
GROUP BY
	CASE
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
	END
ORDER BY [AgeGroup];

-- Exercise 10: First Letter
SELECT
	SUBSTRING(FirstName, 1, 1) AS [FirstLetter]
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY SUBSTRING(FirstName, 1, 1)
ORDER BY [FirstLetter];

-- Exercise 11: Average Interest
SELECT 
	DepositGroup,
	IsDepositExpired,
	AVG(DepositInterest) AS [AverageInterest]
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC;

-- Exercise 12: Rich Wizard, Poor Wizard
SELECT 
	SUM(DepositAmount - NextDeposit) AS [SumDifference]
FROM (
		SELECT
			DepositAmount,
			LEAD(DepositAmount) OVER (ORDER BY Id) AS NextDeposit
		FROM WizzardDeposits
	 ) AS t
WHERE NextDeposit IS NOT NULL;

-- Exercise 13: Departments Total Salaries
USE SoftUni;
GO

SELECT
	DepartmentID,
	SUM(Salary) AS [TotalSalary]
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID;

-- Another way (include all departments, even those with no employees):
SELECT 
	d.DepartmentID,
	SUM(e.Salary) AS [TotalSalary]
FROM Departments AS d
LEFT JOIN Employees AS e
	ON d.DepartmentID = e.DepartmentID
GROUP BY d.DepartmentID

-- Exercise 14: Employees Minimum Salaries
SELECT 
	DepartmentID,
	MIN(Salary) AS [MinimumSalary]
FROM Employees
WHERE DepartmentID IN (2, 5, 7)
	AND HireDate > '2000-01-01'
GROUP BY DepartmentID;

-- Exercise 15: Employees Average Salaries
SELECT *
INTO HighSalaryEmployees
FROM Employees
WHERE Salary > 30000;

DELETE FROM HighSalaryEmployees
WHERE ManagerID = 42;

UPDATE HighSalaryEmployees
SET Salary = Salary + 5000
WHERE DepartmentID = 1;

SELECT 
	DepartmentID,
	AVG(Salary) AS [AverageSalary]
FROM HighSalaryEmployees
GROUP BY DepartmentID;

-- Exercise 16: Employees Maximum Salaries
SELECT
	DepartmentID,
	MAX(Salary) AS [MaxSalary]
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) < 30000 OR MAX(Salary) > 70000

-- Another way:
SELECT
	DepartmentID,
	MAX(Salary) AS [MaxSalary]
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000;

-- Exercise 17: Employees Count Salaries
SELECT
	COUNT(*) AS [Count]
FROM Employees
WHERE ManagerID IS NULL;

-- Exercise 18: 3rd Highest Salary
SELECT DISTINCT
	DepartmentID,
	Salary AS [ThirdHighestSalary]
FROM (
		SELECT 
			DepartmentID,
			Salary,
			DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
		FROM Employees
	) AS t
WHERE SalaryRank = 3

-- Second way to solve the problem:
WITH RankedSalary AS (
	SELECT
		DepartmentID,
		Salary,
		DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
	FROM Employees
)
SELECT DISTINCT
	DepartmentID,
	Salary AS [ThirdHighestSalary]
FROM RankedSalary
WHERE SalaryRank = 3;

-- Exercise 19: Salary Challenge
SELECT TOP 10
	e.FirstName,
	e.LastName,
	e.DepartmentID
FROM Employees AS e
JOIN (
		SELECT
			DepartmentID,
			AVG(Salary) AS [AverageSalary]
		FROM Employees
		GROUP BY DepartmentID
	) AS avgTable
	ON e.DepartmentID = avgTable.DepartmentID
WHERE e.Salary > avgTable.AverageSalary
