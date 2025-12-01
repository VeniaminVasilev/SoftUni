-- Section 1. DDL
CREATE DATABASE LibraryDb;
GO

USE LibraryDb;

-- Actual exercise:
CREATE TABLE Contacts
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Email NVARCHAR(100) NULL,
	PhoneNumber NVARCHAR(20) NULL,
	PostAddress NVARCHAR(200) NULL,
	Website NVARCHAR(50) NULL
);

CREATE TABLE Authors
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL,
	ContactId INT NOT NULL,

	CONSTRAINT FK_Authors_Contacts FOREIGN KEY (ContactId) REFERENCES Contacts(Id)
);

CREATE TABLE Libraries
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	ContactId INT NOT NULL,

	CONSTRAINT FK_Libraries_Contacts FOREIGN KEY (ContactId) REFERENCES Contacts(Id)
);

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(30) NOT NULL
);

CREATE TABLE Books
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title NVARCHAR(100) NOT NULL,
	YearPublished INT NOT NULL,
	ISBN NVARCHAR(13) UNIQUE NOT NULL,
	AuthorId INT NOT NULL,
	GenreId INT NOT NULL,

	CONSTRAINT FK_Books_Authors FOREIGN KEY (AuthorId) REFERENCES Authors(Id),
	CONSTRAINT FK_Books_Genres FOREIGN KEY (GenreId) REFERENCES Genres(Id)
);

CREATE TABLE LibrariesBooks
(
	LibraryId INT NOT NULL,
	BookId INT NOT NULL,

	CONSTRAINT PK_LibrariesBooks PRIMARY KEY (LibraryId, BookId),
	CONSTRAINT FK_LibrariesBooks_Libraries FOREIGN KEY (LibraryId) REFERENCES Libraries(Id),
	CONSTRAINT FK_BookId_Books FOREIGN KEY (BookId) REFERENCES Books(Id)
);

-- Section 2. DML
-- 2. Insert
INSERT INTO Contacts (Email, PhoneNumber, PostAddress, Website)
VALUES 
(NULL, NULL, NULL, NULL),
(NULL, NULL, NULL, NULL),
('stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
('suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com');

INSERT INTO Authors (Name, ContactId)
VALUES
('George Orwell', 21),
('Aldous Huxley', 22),
('Stephen King', 23),
('Suzanne Collins', 24);

INSERT INTO Books (Title, YearPublished, ISBN, AuthorId, GenreId)
VALUES
('1984', 1949, '9780451524935', 16, 2),
('Animal Farm', 1945, '9780451526342', 16, 2),
('Brave New World', 1932, '9780060850524', 17, 2),
('The Doors of Perception', 1954, '9780060850531', 17, 2),
('The Shining', 1977, '9780307743657', 18, 9),
('It', 1986, '9781501142970', 18, 9),
('The Hunger Games', 2008, '9780439023481', 19, 7),
('Catching Fire', 2009, '9780439023498', 19, 7),
('Mockingjay', 2010, '9780439023511', 19, 7);

INSERT INTO LibrariesBooks (LibraryId, BookId)
VALUES
(1, 36),
(1, 37),
(2, 38),
(2, 39),
(3, 40),
(3, 41),
(4, 42),
(4, 43),
(5, 44);

-- 3. Update
UPDATE c
SET c.Website = 'www.' + REPLACE(LOWER(Name), ' ', '') + '.com'
FROM Contacts AS c
JOIN Authors AS a
	ON c.Id = a.ContactId
WHERE c.Website IS NULL

-- 4. Delete
DELETE FROM lb
FROM LibrariesBooks AS lb
JOIN Books AS b
	ON lb.BookId = b.Id
JOIN Authors AS a
	ON a.Id = b.AuthorId
WHERE a.Name = 'Alex Michaelides';

DELETE FROM b
FROM Books AS b
JOIN Authors AS a
	ON b.AuthorId = a.Id
WHERE a.Name = 'Alex Michaelides';

DELETE FROM Authors
WHERE Name = 'Alex Michaelides';
GO

-- Section 3: Querying
-- 5. Books by Year of Publication
SELECT 
	Title AS [Book Title],
	ISBN,
	YearPublished AS [YearReleased]
FROM Books
ORDER BY YearPublished DESC, Title ASC;

-- 6. Books by Genre
SELECT 
	b.Id,
	b.Title,
	b.ISBN,
	g.Name AS [Genre]
FROM Books AS b
JOIN Genres AS g
	ON b.GenreId = g.Id
WHERE g.Name = 'Biography' OR g.Name = 'Historical Fiction' 
ORDER BY g.Name, b.Title ASC;

-- 7. Libraries Missing Specific Genre
SELECT DISTINCT
	l.Name AS [Library],
	c.Email
FROM Libraries AS l
JOIN Contacts AS c
	ON l.ContactId = c.Id
WHERE l.Id NOT IN (
		SELECT 
			l.Id
		FROM Libraries AS l
		JOIN LibrariesBooks AS lb
			ON l.Id = lb.LibraryId
		JOIN Books AS b
			ON lb.BookId = b.Id
		JOIN Genres AS g
			ON b.GenreId = g.Id
		WHERE g.Name = 'Mystery'
)
ORDER BY l.Name ASC;

-- 8. First 3 Books
SELECT TOP 3
	b.Title,
	b.YearPublished AS [Year],
	g.Name AS [Genre]
FROM Books AS b
JOIN Genres AS g
	ON b.GenreId = g.Id
WHERE 
	(b.YearPublished > 2000
	AND b.Title LIKE '%a%') 
	OR 
	(b.YearPublished < 1950 
	AND g.Name LIKE '%Fantasy%')
ORDER BY b.Title ASC, b.YearPublished DESC;

-- 9. Authors from the UK
SELECT 
	a.Name AS [Author],
	c.Email, 
	c.PostAddress AS [Address]
FROM Authors AS a
JOIN Contacts AS c
	ON a.ContactId = c.Id
WHERE c.PostAddress LIKE '%UK%'
ORDER BY a.Name ASC;

-- 10. Fictions in Denver
SELECT
	a.Name AS [Author],
	b.Title,
	l.Name AS [Library],
	c.PostAddress AS [Library Address]
FROM Books AS b
JOIN Genres AS g
	ON b.GenreId = g.Id
JOIN Authors AS a
	ON b.AuthorId = a.Id
JOIN LibrariesBooks AS lb
	ON b.Id = lb.BookId
JOIN Libraries AS l
	ON lb.LibraryId = l.Id
JOIN Contacts AS c
	ON l.ContactId = c.Id
WHERE g.Name = 'Fiction'
	AND c.PostAddress LIKE '%Denver%'
ORDER BY b.Title ASC;

GO
-- Section 4. Programmability
-- 11. Authors with Books
CREATE FUNCTION udf_AuthorsWithBooks(@name NVARCHAR(100)) 
RETURNS INT
AS
BEGIN
	DECLARE @bookCount INT;

	SELECT
		@bookCount = COUNT(lb.BookId)
	FROM Books AS b
	JOIN Authors AS a
		ON b.AuthorId = a.Id
	JOIN LibrariesBooks AS lb
		ON b.Id = lb.BookId
	WHERE a.Name = @name

	RETURN @bookCount;
END
GO

SELECT dbo.udf_AuthorsWithBooks('J.K. Rowling');
GO

-- 12. Search for Books from a Specific Genre (optional City filter)
CREATE PROCEDURE usp_SearchBookByGenre (
	@genreName NVARCHAR(30),
	@city NVARCHAR(100) = NULL
)
AS
BEGIN
	SELECT DISTINCT
		b.Title,
		b.YearPublished AS [Year],
		b.ISBN,
		a.Name AS [Author],
		g.Name AS [Genre]
	FROM Books AS b
	JOIN Genres AS g
		ON b.GenreId = g.Id
	JOIN LibrariesBooks AS lb
		ON b.Id = lb.BookId
	JOIN Libraries AS l
		ON lb.LibraryId = l.Id
	JOIN Contacts AS c
		ON l.ContactId = c.Id
	JOIN Authors AS a
		ON b.AuthorId = a.Id
	WHERE 
		g.Name = @genreName 
		AND 
		(
			@city IS NULL
			OR
			c.PostAddress LIKE '%' + @city + '%'
		)
	ORDER BY 
		b.Title ASC, 
		b.YearPublished DESC;
END;

-- Example usage:
EXEC usp_SearchBookByGenre 'Fantasy';
EXEC usp_SearchBookByGenre 'Fantasy', 'Denver';