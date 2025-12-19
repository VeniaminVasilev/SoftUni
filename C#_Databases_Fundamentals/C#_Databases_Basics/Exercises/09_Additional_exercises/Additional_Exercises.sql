-- 1. Number of Users for Email Provider
USE Diablo;
GO

SELECT 
	SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider],
	COUNT(*) AS [Number of Users]
FROM Users
GROUP BY 
	SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email))
ORDER BY 
	[Number of Users] DESC,
	[Email Provider] ASC;

-- 2. All Users in Games
SELECT
	g.Name AS [Game],
	gt.Name AS [Game Type],
	u.Username AS [Username],
	ug.[Level] AS [Level],
	ug.Cash AS [Cash],
	c.Name AS [Character]
FROM Users AS u
JOIN UsersGames AS ug
	ON u.Id = ug.UserId
JOIN Games AS g
	ON ug.GameId = g.Id
JOIN GameTypes AS gt
	ON g.GameTypeId = gt.Id
JOIN Characters AS c
	ON ug.CharacterId = c.Id
ORDER BY
	[Level] DESC,
	[Username], [Game] ASC;

-- 3. Users in Games with Their Items
SELECT 
	u.Username,
	g.Name AS [Game],
	COUNT(ugi.ItemId) AS [Items Count],
	SUM(i.Price) AS [Items Price]
FROM Users AS u
JOIN UsersGames AS ug
	ON u.Id = ug.UserId
JOIN Games AS g
	ON ug.GameId = g.Id
JOIN UserGameItems AS ugi
	ON ug.Id = ugi.UserGameId
JOIN Items AS i
	ON ugi.ItemId = i.Id
GROUP BY u.Username, g.Name
HAVING COUNT(ugi.ItemId) >= 10
ORDER BY 
	[Items Count] DESC,
	[Items Price] DESC,
	u.Username ASC;

-- 4. User in Games with Their Statistics
SELECT
	u.Username,
    g.Name AS [Game],
    MAX(c.Name) AS [Character],
    SUM(i_s.Strength) + MAX(gt_s.Strength) + MAX(c_s.Strength) AS [Strength],
    SUM(i_s.Defence) + MAX(gt_s.Defence) + MAX(c_s.Defence) AS [Defence],
    SUM(i_s.Speed) + MAX(gt_s.Speed) + MAX(c_s.Speed) AS [Speed],
    SUM(i_s.Mind) + MAX(gt_s.Mind) + MAX(c_s.Mind) AS [Mind],
    SUM(i_s.Luck) + MAX(gt_s.Luck) + MAX(c_s.Luck) AS [Luck]
FROM Users AS u
JOIN UsersGames AS ug ON u.Id = ug.UserId
JOIN Games AS g ON ug.GameId = g.Id
JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
JOIN [Statistics] AS gt_s ON gt.BonusStatsId = gt_s.Id
JOIN Characters AS c ON ug.CharacterId = c.Id
JOIN [Statistics] AS c_s ON c.StatisticId = c_s.Id
JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
JOIN Items AS i ON ugi.ItemId = i.Id
JOIN [Statistics] AS i_s ON i.StatisticId = i_s.Id
GROUP BY u.Username, g.Name
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC;

-- 5. All items with Greater than Average Statistics
SELECT 
	i.Name,
	i.Price,
	i.MinLevel,
	s.Strength,
	s.Defence,
	s.Speed,
	s.Luck,
	s.Mind
FROM Items AS i
JOIN [Statistics] AS s
	ON i.StatisticId = s.Id
WHERE s.Mind > (SELECT AVG(Mind) FROM [Statistics])
	AND s.Luck > (SELECT AVG(Luck) FROM [Statistics])
	AND s.Speed > (SELECT AVG(Speed) FROM [Statistics])
ORDER BY i.Name ASC;

-- 6. Display all items with information about Forbidden Game Type
SELECT 
	i.Name AS [Item],
	i.Price,
	i.MinLevel,
	gt.Name AS [Forbidden Game Type]
FROM Items AS i
LEFT JOIN GameTypeForbiddenItems AS gtfi
	ON i.Id = gtfi.ItemId
LEFT JOIN GameTypes AS gt
	ON gtfi.GameTypeId = gt.Id
ORDER BY 
	gt.Name DESC,
	i.Name ASC;

-- 7. Buy Items for User in Game
DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username = 'Alex');
DECLARE @GameId INT = (SELECT Id FROM Games WHERE Name = 'Edinburgh');
DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId);

DECLARE @ItemNames TABLE (Name NVARCHAR(MAX));
INSERT INTO @ItemNames (Name) VALUES 
('Blackguard'), 
('Bottomless Potion of Amplification'), 
('Eye of Etlich (Diablo III)'), 
('Gem of Efficacious Toxin'), 
('Golden Gorget of Leoric'), 
('Hellfire Amulet');

INSERT INTO UserGameItems (ItemId, UserGameId)
SELECT Id, @UserGameId 
FROM Items 
WHERE Name IN (SELECT Name FROM @ItemNames);

UPDATE UsersGames
SET Cash -= (SELECT SUM(Price) FROM Items WHERE Name IN (SELECT Name FROM @ItemNames))
WHERE Id = @UserGameId;

SELECT 
    u.Username,
    g.Name AS [Name],
    ug.Cash,
    i.Name AS [Item Name]
FROM Users AS u
JOIN UsersGames AS ug ON u.Id = ug.UserId
JOIN Games AS g ON ug.GameId = g.Id
JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
JOIN Items AS i ON ugi.ItemId = i.Id
WHERE g.Name = 'Edinburgh'
ORDER BY [Item Name] ASC;

-- 8. Peaks and Mountains
USE Geography;
GO

SELECT
	p.PeakName,
	m.MountainRange AS [Mountain],
	p.Elevation
FROM Peaks AS p
JOIN Mountains AS m
	ON p.MountainId = m.Id
ORDER BY 
	p.Elevation DESC,
	p.PeakName ASC;

-- 9. Peaks with Their Mountain, Country and Continent
SELECT
	p.PeakName,
	m.MountainRange AS [Mountain],
	c.CountryName,
	con.ContinentName
FROM Peaks AS p
JOIN Mountains AS m
	ON p.MountainId = m.Id
JOIN MountainsCountries AS mc
	ON m.Id = mc.MountainId
JOIN Countries AS c
	ON mc.CountryCode = c.CountryCode
JOIN Continents AS con
	ON c.ContinentCode = con.ContinentCode
ORDER BY
	p.PeakName ASC,
	c.CountryName ASC;

-- 10. Rivers by Country
SELECT
	c.CountryName,
	con.ContinentName,
	COUNT(cr.RiverId) AS [RiversCount],
	ISNULL(SUM(r.Length), 0) AS [TotalLength]
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
	ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
	ON cr.RiverId = r.Id
LEFT JOIN Continents AS con
	ON c.ContinentCode = con.ContinentCode
GROUP BY 
	c.CountryName, 
	con.ContinentName
ORDER BY
	[RiversCount] DESC,
	[TotalLength] DESC,
	c.CountryName ASC;

-- 11. Count of Countries by Currency
SELECT
	currencies.CurrencyCode,
	currencies.Description AS [Currency],
	COUNT(countries.CountryCode) AS [NumberOfCountries]
FROM Currencies AS currencies
LEFT JOIN Countries AS countries
	ON currencies.CurrencyCode = countries.CurrencyCode
GROUP BY 
	currencies.CurrencyCode,
	currencies.Description
ORDER BY
	[NumberOfCountries] DESC,
	[Currency] ASC;

-- 12. Population and Area by Continent
SELECT
	Continents.ContinentName,
	SUM(CAST(Countries.AreaInSqKm AS BIGINT)) AS [CountriesArea],
	SUM(CAST(Countries.Population AS BIGINT)) AS [CountriesPopulation]
FROM Continents
JOIN Countries
	ON Continents.ContinentCode = Countries.ContinentCode
GROUP BY 
	Continents.ContinentName
ORDER BY
	[CountriesPopulation] DESC;

-- 13. Monasteries by Country
CREATE TABLE Monasteries
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL,
	CountryCode CHAR(2) NOT NULL,

	CONSTRAINT FK_Monasteries_Countries FOREIGN KEY (CountryCode) REFERENCES Countries(CountryCode)
);

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

ALTER TABLE Countries
ADD IsDeleted BIT NOT NULL DEFAULT 0;

UPDATE Countries
SET IsDeleted = 1
WHERE CountryCode IN (
	SELECT CountryCode
	FROM CountriesRivers
	GROUP BY CountryCode
	HAVING COUNT(RiverId) > 3
)

SELECT
	m.Name AS [Monastery],
	c.CountryName AS [Country]
FROM Monasteries AS m
JOIN Countries AS c
	ON m.CountryCode = c.CountryCode
ORDER BY 
	m.Name ASC;

-- 14. Monasteries by Continents and Countries
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar';

INSERT INTO Monasteries (Name, CountryCode)
VALUES
('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania'))

INSERT INTO Monasteries (Name, CountryCode)
VALUES
('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Burma'))

SELECT
	continents.ContinentName,
	countries.CountryName,
	COUNT(m.Id) AS [MonasteriesCount]
FROM Continents AS continents
JOIN Countries AS countries
	ON continents.ContinentCode = countries.ContinentCode
LEFT JOIN Monasteries AS m
	ON countries.CountryCode = m.CountryCode
WHERE countries.IsDeleted = 0
GROUP BY continents.ContinentName, countries.CountryName
ORDER BY
	[MonasteriesCount] DESC,
	countries.CountryName ASC;
