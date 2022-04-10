--Creating tables
CREATE TABLE Users(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserName NVARCHAR(50) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	Password NVARCHAR(50) NOT NULL,
);

CREATE TABLE Books(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Title NVARCHAR(50) NOT NULL,
	Author NVARCHAR(50) NOT NULL,
	Description NVARCHAR(150) NOT NULL,
);

CREATE TABLE Reviews(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Rating INT NOT NULL,
	Description NVARCHAR(100) NOT NULL,
	UserId INT NOT NULL FOREIGN KEY REFERENCES Users(ID),
	BookId INT NOT NULL FOREIGN KEY REFERENCES Books(ID),
);

CREATE TABLE BookLists(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserId INT NOT NULL FOREIGN KEY REFERENCES Users(ID),
	BookId INT NOT NULL FOREIGN KEY REFERENCES Books(ID),
	ListType NVARCHAR(20) NOT NULL,
	);

--Seeding tables
INSERT INTO dbo.Users (UserName, Email, Password)
VALUES
('Ana', 'ana@gmail.com', '1234'),
('Maria', 'maria@gmail.com', '1234'),
('Vlad', 'vlad@gmail.com', '1234'),
('Catalina', 'catalina@gmail.com', '1234'),
('Lila', 'lila@gmail.com', '1234'),
('Mihai', 'mihai@gmail.com', '1234'),
('Mimi', 'mimi@gmail.com', '1234'),
('Alex', 'alex@gmail.com', '1234'),
('Mircea', 'mircea@gmail.com', '1234'),
('Stefan', 'stefan@gmail.com', '1234');

INSERT INTO dbo.Books (Title, Author, Description)
VALUES
('Book1', 'Author1', 'Description1'),
('Book2', 'Author2', 'Description2'),
('Book3', 'Author3', 'Description3'),
('Book4', 'Author4', 'Description4'),
('Book5', 'Author5', 'Description5'),
('Book6', 'Author6', 'Description6'),
('Book7', 'Author7', 'Description7'),
('Book8', 'Author8', 'Description8'),
('Book9', 'Author9', 'Description9'),
('Book10', 'Author10', 'Description10');

INSERT INTO dbo.Reviews (Rating, Description, UserId, BookId)
VALUES
(3, 'review', 2, 5),
(4, 'review', 2, 4),
(5, 'review', 1, 5),
(3, 'review', 6, 1),
(3, 'review', 2, 8),
(1, 'review', 8, 3),
(5, 'review', 5, 2),
(4, 'review', 3, 3),
(3, 'review', 3, 3),
(3, 'review', 7, 2);

INSERT INTO dbo.BookLists (UserId, BookId, ListType)
VALUES
(1, 2, 'Read'),
(2, 3, 'Read'),
(2, 4, 'Read'),
(2, 4, 'CurrentlyReading'),
(3, 2, 'WantToRead'),
(4, 6, 'Read'),
(5, 6, 'Read'),
(6, 9, 'Read'),
(7, 1,  'Read'),
(8, 1, 'Read'),
(9, 7, 'Read');

--Queries
--1. The names from all users
SELECT u.UserName from dbo.Users as u;

--2. Total number of users
SELECT COUNT(UserName) FROM dbo.Users;

--3. ReadList from the 2nd user
SELECT u.UserName, b.Title
FROM dbo.Users AS u
INNER JOIN dbo.BookLists AS bl ON u.ID = bl.UserId
INNER JOIN dbo.Books AS b ON b.ID = bl.BookId
WHERE bl.ListType = 'Read' AND u.ID = 2;

--4. CurrentlyReadingList from 2nd user
SELECT u.UserName, b.Title
FROM dbo.Users AS u
INNER JOIN dbo.BookLists AS bl ON u.ID = bl.UserId
INNER JOIN dbo.Books AS b ON b.ID = bl.BookId
WHERE bl.ListType = 'CurrentlyReading' AND u.ID = 2;

--5. Rating from book 3
SELECT AVG(Rating)
FROM dbo.Reviews
WHERE BookId = 3;

--6. Description of the 3rd book
SELECT Description
FROM dbo.Books
WHERE ID = 3;

--7. All reviews from the 2nd book
SELECT Rating, Description
FROM dbo.Reviews
WHERE BookId = 2;

--8. Total sum of ratings
SELECT SUM(Rating)
FROM dbo.Reviews;

--9. The min rating on the 3rd book
SELECT MIN(Rating)
FROM dbo.Reviews
WHERE BookId = 3;

--10. The max rating on the 5th book
SELECT MAX(Rating)
FROM dbo.Reviews
WHERE BookId =5;


UPDATE Users
SET Email = 'ana.ana@gmail.com'
WHERE ID = 1;

UPDATE Books
SET Description = 'an updated descrition'
WHERE ID = 2;

UPDATE Reviews
SET Description = 'updated review description',
	Rating = 4
WHERE UserId = 2 AND BookId = 8;

BEGIN TRY
	BEGIN TRANSACTION
		UPDATE dbo.Users SET Email = 'ana.ana@gmail.com'
			WHERE ID = 1
		UPDATE dbo.Books SET Description = 'an updated descrition'
			WHERE ID = 2
		UPDATE dbo.Reviews SET Description = 'updated review description',
							Rating = 4
			WHERE UserId = 2 AND BookId = 8
		DELETE FROM dbo.Users WHERE ID = 5
		DELETE FROM dbo.Books WHERE ID = 20
	COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH