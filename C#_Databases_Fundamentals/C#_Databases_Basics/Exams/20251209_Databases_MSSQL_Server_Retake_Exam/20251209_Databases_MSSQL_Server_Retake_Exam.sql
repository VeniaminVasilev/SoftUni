-- 1. Database design
CREATE DATABASE TechStore;
GO

USE TechStore;

CREATE TABLE Manufacturers
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	Country NVARCHAR(50) NOT NULL
);

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(30) UNIQUE NOT NULL
);

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL,
	Price DECIMAL(18,2) NOT NULL,
	Specifications NVARCHAR(1000) NULL,
	ManufacturerId INT NOT NULL,
	CategoryId INT NOT NULL,

	CONSTRAINT FK_Products_Manufacturers FOREIGN KEY (ManufacturerId) REFERENCES Manufacturers(Id),
	CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

CREATE TABLE Stores
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL,
	IsOnline BIT NOT NULL
);

CREATE TABLE StoresProducts
(
	StoreId INT NOT NULL,
	ProductId INT NOT NULL,

	CONSTRAINT PK_StoresProducts PRIMARY KEY (StoreId, ProductId),

	CONSTRAINT FK_StoresProducts_Stores FOREIGN KEY (StoreId) REFERENCES Stores(Id),
	CONSTRAINT FK_StoresProducts_Products FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(80) NOT NULL,
	PhoneNumber NVARCHAR(20) NOT NULL,
	Email NVARCHAR(80) NULL
);

CREATE TABLE Orders
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	OrderDate DATETIME2 NOT NULL,
	CustomerId INT NOT NULL,
	ProductId INT NOT NULL,
	StoreId INT NOT NULL,

	CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
	CONSTRAINT FK_Orders_Products FOREIGN KEY (ProductId) REFERENCES Products(Id),
	CONSTRAINT FK_Orders_Stores FOREIGN KEY (StoreId) REFERENCES Stores(Id)
);

-- 2. Insert
INSERT INTO Customers (Name, PhoneNumber, Email)
VALUES
('Marko Petrovic', '0888-123456', 'marko.petrovic@email.rs');

INSERT INTO Products (Name, Price, ManufacturerId, CategoryId)
VALUES
('Asus ZenBook 14', 1199.99, 6, 2),
('Sony WF-1000XM5', 299.99, 10, 10);

INSERT INTO StoresProducts (StoreId, ProductId)
VALUES
(2, 61),
(12, 62);

INSERT INTO Orders (OrderDate, CustomerId, ProductId, StoreId)
VALUES
('2025-03-04', 21, 61, 2),
('2024-12-20', 21, 62, 12),
('2025-01-25', 18, 14, 1),
('2025-02-26', 7, 31, 20);

-- 3. Update
UPDATE Products
SET Price = Price * 1.15
WHERE Price < 500.00;

-- 4. Delete
DELETE Orders
WHERE CustomerId IN 
(
	SELECT Id FROM Customers
	WHERE Email IS NULL
);

DELETE Customers
WHERE Email IS NULL;

-- 5. Find Recent Orders
SELECT 
	Id AS [OrderId],
	FORMAT(OrderDate, 'MM-dd') AS [OrderDate],
	CustomerId,
	StoreId,
	ProductId
FROM Orders
WHERE OrderDate > '2025-01-01'
ORDER BY 
	OrderDate DESC,
	CustomerId ASC,
	StoreId ASC,
	ProductId ASC;

-- 6. Manufacturers From Specific Countries
SELECT 
	Name AS [Manufacturer],
	Country
FROM Manufacturers
WHERE Country LIKE 'S%'
ORDER BY Country ASC, Name ASC;

-- 7. Customers Ordered Products Produces in China
SELECT DISTINCT
	c.Name AS [CustomerName],
	c.PhoneNumber,
	c.Email
FROM Customers AS c
JOIN Orders AS o
	ON c.Id = o.CustomerId
JOIN Products AS p
	ON o.ProductId = p.Id
JOIN Manufacturers AS m
	ON p.ManufacturerId = m.Id
WHERE Email IS NOT NULL AND m.Country = 'China'
ORDER BY c.Name ASC;

-- 8. Customers with Multiple Orders
SELECT
	c.Name AS [CustomerName],
	COUNT(o.Id) AS OrdersCount
FROM Customers AS c
JOIN Orders AS o
	ON c.Id = o.CustomerId
GROUP BY c.Name
HAVING COUNT(o.Id) > 1
ORDER BY 
	OrdersCount DESC,
	c.Name ASC;

-- 9. Average Price of Products Produced by Country
SELECT
	m.Country AS [CountryName],
	COUNT(DISTINCT m.Id) AS [ProducersCount],
	FORMAT(AVG(p.Price), 'N2') AS [AvgProductPrice]
FROM Manufacturers AS m
JOIN Products AS p
	ON m.Id = p.ManufacturerId
GROUP BY m.Country
ORDER BY 
	ProducersCount DESC,
	AvgProductPrice ASC;

-- 10. High-Value Store Analysis
SELECT
	s.Name AS [StoreName],
	COUNT(sp.ProductId) AS [ProductCount],
	FORMAT(AVG(p.Price), 'N2') AS [AveragePrice]
FROM Stores AS s
JOIN StoresProducts AS sp
	ON s.Id = sp.StoreId
JOIN Products AS p
	ON sp.ProductId = p.Id
WHERE 
	p.Price > 800
GROUP BY s.Name
HAVING COUNT(sp.ProductId) >= 4
ORDER BY AveragePrice DESC;

GO;
-- 11. Count Products by Manufacturer
CREATE FUNCTION udf_GetProductCountByManufacturer (@manufacturerName NVARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @ProductCount INT = 0;

	SELECT
		@ProductCount = COUNT(p.Id)
	FROM Products AS p
	JOIN Manufacturers AS m
		ON p.ManufacturerId = m.Id
	WHERE m.Name = @manufacturerName;

	RETURN @ProductCount;
END;

GO
SELECT dbo.udf_GetProductCountByManufacturer ('Apple');

GO
-- 12. Get Orders by Customer
CREATE PROCEDURE usp_GetOrdersByCustomer (@CustomerName NVARCHAR(80))
AS
BEGIN
	SELECT
		p.Name AS [ProductName],
		s.Name AS [StoreName],
		FORMAT(o.OrderDate, 'MM-dd-yyyy') AS OrderDate,
		FORMAT(p.Price, 'N2') AS Price
	FROM Customers AS c
	JOIN Orders AS o
		ON c.Id = o.CustomerId
	JOIN Products AS p
		ON o.ProductId = p.Id
	JOIN Stores AS s
		ON o.StoreId = s.Id
	WHERE c.Name = @CustomerName
	ORDER BY 
		OrderDate DESC,
		ProductName ASC;
END;

EXEC dbo.usp_GetOrdersByCustomer 'Carlos Fernández';
