-- Railways Database
-- Section 1. DDL
CREATE DATABASE RailwaysDb;
GO

USE RailwaysDb;

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(80) NOT NULL
);

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(30) NOT NULL
);

CREATE TABLE RailwayStations
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	TownId INT NOT NULL,

	CONSTRAINT FK_RailwayStations_Towns FOREIGN KEY (TownId) REFERENCES Towns(Id)
);

CREATE TABLE Trains
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	HourOfDeparture VARCHAR(5) NOT NULL,
	HourOfArrival VARCHAR(5) NOT NULL,
	DepartureTownId INT NOT NULL,
	ArrivalTownId INT NOT NULL,

	CONSTRAINT FK_Trains_DepartureTowns FOREIGN KEY (DepartureTownId) REFERENCES Towns(Id),

	CONSTRAINT FK_Trains_ArrivalTowns FOREIGN KEY (ArrivalTownId) REFERENCES Towns(Id)
);

CREATE TABLE TrainsRailwayStations
(
	TrainId INT NOT NULL,
	RailwayStationId INT NOT NULL,

	CONSTRAINT PK_TrainId_RailwayStationId PRIMARY KEY (TrainId, RailwayStationId),

	CONSTRAINT FK_TrainsRailwayStations_Trains FOREIGN KEY (TrainId) REFERENCES Trains(Id),
	CONSTRAINT FK_TrainsRailwayStations_RailwayStations FOREIGN KEY (RailwayStationId) REFERENCES RailwayStations(Id)
);

CREATE TABLE MaintenanceRecords
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DateOfMaintenance DATE NOT NULL,
	Details VARCHAR(2000) NOT NULL,
	TrainId INT NOT NULL,

	CONSTRAINT FK_MaintenanceRecords_Trains FOREIGN KEY (TrainId) REFERENCES Trains(Id)
);

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Price DECIMAL(10,2) NOT NULL,
	DateOfDeparture DATE NOT NULL,
	DateOfArrival DATE NOT NULL,
	TrainId INT NOT NULL,
	PassengerId INT NOT NULL,

	CONSTRAINT FK_Tickets_Trains FOREIGN KEY (TrainId) REFERENCES Trains(Id),
	CONSTRAINT FK_Tickets_Passengers FOREIGN KEY (PassengerId) REFERENCES Passengers(Id)
);

-- 2. Insert
INSERT INTO Trains (HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId)
VALUES
('07:00', '19:00', 1, 3),
('08:30', '20:30', 5, 6),
('09:00', '21:00', 4, 8),
('06:45', '03:55', 27, 7),
('10:15', '12:15', 15, 5);

INSERT INTO TrainsRailwayStations (TrainId, RailwayStationId)
VALUES
(36, 1),
(36, 4),
(36, 31),
(36, 57),
(36, 7),
(37, 60),
(37, 16),
(37, 13),
(37, 54),
(38, 10),
(38, 50),
(38, 52),
(38, 22),
(39, 3),
(39, 31),
(39, 19),
(39, 68),
(40, 41),
(40, 7),
(40, 52),
(40, 13);

INSERT INTO Tickets (Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId)
VALUES
(90.00, '2023-12-01', '2023-12-01', 36, 1),
(115.00, '2023-08-02', '2023-08-02', 37, 2),
(160.00, '2023-08-03', '2023-08-03', 38, 3),
(255.00, '2023-09-01', '2023-09-02', 39, 21),
(95.00, '2023-09-02', '2023-09-03', 40, 22);

-- 3. Update
UPDATE Tickets
SET 
	DateOfDeparture = DATEADD(DAY, 7, DateOfDeparture),
	DateOfArrival = DATEADD(DAY, 7, DateOfArrival)
WHERE DateOfDeparture > '2023-10-31';

-- 4. Delete
DELETE FROM MaintenanceRecords
WHERE TrainId IN
	(SELECT t.Id
	FROM Trains AS t
	JOIN Towns AS town
		ON t.DepartureTownId = town.Id
	WHERE town.Name = 'Berlin');

DELETE FROM Tickets
WHERE TrainId IN
	(SELECT t.Id
	FROM Trains AS t
	JOIN Towns AS town
		ON t.DepartureTownId = town.Id
	WHERE town.Name = 'Berlin');

DELETE FROM TrainsRailwayStations
WHERE TrainId IN 
	(SELECT t.Id
	FROM Trains AS t
	JOIN Towns AS town
		ON t.DepartureTownId = town.Id
	WHERE town.Name = 'Berlin');

DELETE FROM Trains
WHERE Id IN 
	(SELECT t.Id
	FROM Trains AS t
	JOIN Towns AS town
		ON t.DepartureTownId = town.Id
	WHERE town.Name = 'Berlin');

-- 5. Tickets by Price and Date of Departure
SELECT 
	DateOfDeparture,
	Price AS [TicketPrice]
FROM Tickets
ORDER BY Price ASC, DateOfDeparture DESC;

-- 6. Passengers with their Tickets
SELECT
	p.Name AS [PassengerName],
	t.Price AS [TicketPrice],
	t.DateOfDeparture,
	t.TrainId AS [TrainID]
FROM Passengers AS p
JOIN Tickets AS t
	ON p.Id = t.PassengerId
ORDER BY t.Price DESC, p.Name ASC;

-- 7. Railway Stations without Passing Trains
SELECT
	t.Name AS [Town],
	rs.Name AS [RailwayStation]
FROM RailwayStations AS rs
JOIN Towns AS t
	ON rs.TownId = t.Id
LEFT JOIN TrainsRailwayStations AS trs
	ON rs.Id = trs.RailwayStationId
WHERE trs.RailwayStationId IS NULL
ORDER BY t.Name ASC, rs.Name ASC;

-- 8. First 3 Trains Between 8:00 and 8:59
SELECT TOP 3
	trains.Id AS [TrainId],
	trains.HourOfDeparture,
	tickets.Price AS [TicketPrice],
	towns.Name AS [Destination]
FROM Trains AS trains
JOIN Towns AS towns
	ON trains.ArrivalTownId = towns.Id
JOIN Tickets AS tickets
	ON trains.Id = tickets.TrainId
WHERE tickets.Price > 50
	AND CONVERT(TIME, trains.HourOfDeparture) >= '08:00:00'
	AND CONVERT(TIME, trains.HourOfDeparture) <= '08:59:00'
ORDER BY tickets.Price ASC;

-- 9. Count of Passengers Paid More Than Average With Arrival Towns
SELECT
	towns.Name AS [TownName],
	Count(p.Id) AS [PassengersCount]
FROM Passengers AS p
JOIN Tickets AS tickets
	ON p.Id = tickets.PassengerId
JOIN Trains AS trains
	ON tickets.TrainId = trains.Id
JOIN Towns AS towns
	ON trains.ArrivalTownId = towns.Id
WHERE tickets.Price > 76.99
GROUP BY towns.Name
ORDER BY towns.Name;

-- 10. Maintenance Inspection with Town
SELECT 
	trains.Id AS [TrainID],
	towns.Name AS [DepartureTown],
	mr.Details
FROM Trains AS trains
JOIN MaintenanceRecords AS mr
	ON trains.Id = mr.TrainId
JOIN Towns AS towns
	ON trains.DepartureTownId = towns.Id
WHERE mr.Details LIKE '%inspection%'
ORDER BY trains.Id;
GO

-- 11. Towns with Trains
CREATE FUNCTION udf_TownsWithTrains (@name NVARCHAR(100))
RETURNS INT
AS 
BEGIN
	DECLARE @totalTrains INT;

	SELECT @totalTrains = COUNT(t.Id)
	FROM Trains AS t
	JOIN Towns AS townA
		ON t.ArrivalTownId = townA.Id
	JOIN Towns AS townD
		ON t.DepartureTownId = townD.Id
	WHERE townA.Name = @name OR townD.Name = @name;

	RETURN @totalTrains;
END

GO;
SELECT dbo.udf_TownsWithTrains('Paris');

GO;
-- 12. Search Passenger Travelling to Specific Town
CREATE PROCEDURE usp_SearchByTown (@townName NVARCHAR(100))
AS
BEGIN
	SELECT
		p.Name AS [PassengerName],
		tickets.DateOfDeparture,
		trains.HourOfDeparture
	FROM Passengers AS p
	JOIN Tickets AS tickets
		ON p.Id = tickets.PassengerId
	JOIN Trains AS trains
		ON tickets.TrainId = trains.Id
	JOIN Towns AS towns
		ON trains.ArrivalTownId = towns.Id
	WHERE towns.Name = @townName
	ORDER BY tickets.DateOfDeparture DESC, p.Name ASC;
END

EXEC usp_SearchByTown 'Berlin';
