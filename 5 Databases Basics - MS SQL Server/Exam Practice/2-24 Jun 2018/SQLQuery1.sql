CREATE DATABASE TripService

USE TripService

--1

CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15,2)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(15,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id)
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id),
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE
)

ALTER TABLE Trips
ADD CONSTRAINT CHK_BookBeforArivel CHECK(BookDate < ArrivalDate)

ALTER TABLE Trips
ADD CONSTRAINT CHK_ArivelBeforReturn CHECK(ArrivalDate < ReturnDate)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(20) NOT NULL,
	CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips
(
	AccountId INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
	TripId INT NOT NULL FOREIGN KEY REFERENCES Trips(Id),
	Luggage INT NOT NULL,

	CONSTRAINT PK_AccountsTrips PRIMARY KEY(AccountId, TripId)
)

ALTER TABLE AccountsTrips
ADD CONSTRAINT CHK_LuggageAtlistZero CHECK(Luggage >= 0)

--2

INSERT INTO Accounts(FirstName, MiddleName, LastName, CityId, BirthDate, Email) VALUES
('John',		'Smith',	'Smith',	34,	'1975-07-21',	'j_smith@gmail.com'),
('Gosho',		NULL,		'Petrov',	11,	'1978-05-16',	'g_petrov@gmail.com'),
('Ivan',		'Petrovich','Pavlov',	59,	'1849-09-26',	'i_pavlov@softuni.bg'),
('Friedrich',	'Wilhelm',	'Nietzsche',2,	'1844-10-15',	'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate) VALUES
(101,	'2015-04-12',	'2015-04-14',	'2015-04-20',	'2015-02-02'),
(102,	'2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29'),
(103,	'2013-07-17',	'2013-07-23',	'2013-07-24',	NULL),
(104,	'2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10'),
(109,	'2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)

--3

UPDATE Rooms
	SET Price += (Price * 14 / 100)
	WHERE HotelId IN (5, 7, 9)

--4

DELETE FROM AccountsTrips
	WHERE AccountId = 47

--5

SELECT Id, Name
	FROM Cities
	WHERE CountryCode = 'BG'
 ORDER BY Name

--6

SELECT	(FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName) AS [Full Name],
		YEAR(BirthDate)
	FROM Accounts
	WHERE YEAR(BirthDate) > 1991
 ORDER BY YEAR(BirthDate) DESC, FirstName

--7

SELECT a.FirstName, a.LastName, FORMAT(a.BirthDate, 'MM-dd-yyyy'), c.[Name], a.Email
	FROM Accounts AS a
	JOIN Cities AS c ON c.Id = a.CityId
	WHERE Email LIKE 'e%'
 ORDER BY c.Name DESC

--8

SELECT c.Name, COUNT(h.Id) AS [Hotels]
	FROM Cities AS c
	LEFT JOIN Hotels AS h ON h.CityId = c.Id
	GROUP BY c.Name
 ORDER BY [Hotels] DESC, c.Name

--9

SELECT r.Id, r.Price, h.Name, c.Name
	FROM Rooms AS r
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS c ON c.Id = h.CityId
	WHERE r.Type = 'First Class'
 ORDER BY r.Price DESC, r.Id

--10

SELECT a.Id, 
		(a.FirstName + ' ' + a.LastName) AS [FullName], 
		MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS [Max],
		MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS [Min]
	FROM Accounts AS a
	JOIN AccountsTrips AS act ON a.Id = act.AccountId
	JOIN Trips AS t ON act.TripId = t.Id
	WHERE t.CancelDate IS NULL AND a.MiddleName IS NULL
	GROUP BY a.Id, a.FirstName, a.LastName
 ORDER BY [Max] DESC, a.Id

--11

SELECT TOP(5) c.Id, c.Name, c.CountryCode, COUNT(a.Id)
	FROM Cities AS c
	JOIN Accounts AS a ON a.CityId = c.Id
	GROUP BY c.Id, c.Name, c.CountryCode
	ORDER BY COUNT(a.Id) DESC

--12

SELECT a.Id, a.Email, c.Name, COUNT(t.Id)
	FROM Accounts AS a
	JOIN AccountsTrips AS ac ON ac.AccountId = a.Id
	JOIN Trips AS t ON ac.TripId = t.Id
	JOIN Rooms AS r ON t.RoomId = r.Id
	JOIN Hotels AS h ON r.HotelId = h.Id
	JOIN Cities AS c ON h.CityId = c.Id
	WHERE a.CityId = h.CityId
	GROUP BY a.Id, a.Email, c.Name
 ORDER BY COUNT(t.Id) DESC, a.Id

--13

SELECT TOP(10) c.Id, c.Name, SUM(h.BaseRate + r.Price), COUNT(t.Id)
	FROM Cities AS c
	JOIN Hotels AS h ON c.Id = h.CityId
	JOIN Rooms AS r ON r.HotelId = h.Id
	JOIN Trips AS t ON t.RoomId = r.Id
	WHERE YEAR(t.BookDate) = 2016
	GROUP BY c.Id, c.Name
 ORDER BY SUM(h.BaseRate + r.Price) DESC, COUNT(t.Id) DESC

--14

SELECT	ac.TripId, 
		h.Name, 
		r.Type, 
		CASE WHEN t.CancelDate IS NULL
			 THEN SUM(h.BaseRate + r.Price)
			 ELSE 0
			 END AS [Revenu]
	FROM Trips AS t
	JOIN Rooms AS r ON t.RoomId = r.Id
	JOIN Hotels AS h ON r.HotelId = h.Id
	JOIN AccountsTrips AS ac ON ac.TripId = t.Id
	GROUP BY ac.TripId, h.Name, r.Type, t.CancelDate
 ORDER BY r.Type, ac.TripId

--15

SELECT k.Id, k.Email, k.CountryCode, k.Somting
	FROM(
		SElECT	a.id, 
				a.Email, 
				c.CountryCode, 
				COUNT(t.Id) AS Somting, 
				ROW_NUMBER() OVER(PARTITION BY c.CountryCode ORDER BY COUNT(t.Id) DESC) AS RowNumber
			FROM Accounts AS a
			JOIN AccountsTrips AS att ON a.Id = att.AccountId
			JOIN Trips AS t ON att.TripId = t.Id
			JOIN Rooms AS r ON t.RoomId = r.Id
			JOIN Hotels AS h ON r.HotelId = h.Id
			JOIN Cities AS c ON h.CityId = c.Id
			GROUP BY a.id, a.Email, c.CountryCode
		) AS k
	WHERE k.RowNumber = 1
 ORDER BY k.Somting DESC, k.Id

--16
	--VLOZENIA SELECKT NE E NYZEN
SELECT k.TripId, k.SumLug, CASE WHEN k.SumLug > 5
								THEN '$' + CONVERT(VARCHAR(10), (k.SumLug * 5))
								ELSE '$' + CONVERT(VARCHAR(10), 0)
							END AS [Revenu]
	FROM(
		SELECT att.TripId, SUM(att.Luggage) AS[SumLug]
			FROM AccountsTrips AS att
			GROUP BY att.TripId
			HAVING SUM(att.Luggage) > 0
		) AS k
 ORDER BY k.SumLug DESC

--17

SELECT	t.Id, 
		(FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName) AS [Full Name],
		c.Name,
		cc.Name,
		CASE WHEN t.CancelDate IS NULL
			 THEN CONVERT(VARCHAR(20), (DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate))) + ' days'
			 ELSE 'Canceled'
		END AS [Time]
	FROM Trips AS t
	JOIN AccountsTrips AS att ON t.Id = att.TripId
	JOIN Accounts AS a ON att.AccountId = a.Id
	JOIN Cities AS c ON a.CityId = c.Id
	JOIN Rooms AS r on t.RoomId = r.Id
	JOIN Hotels AS h ON r.HotelId = h.Id
	JOIN Cities AS cc ON h.CityId = cc.Id
 ORDER BY [Full Name], t.Id

--18

--19

CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @targetHotelId INT = (SELECT h.Id 
									FROM Hotels AS h
									JOIN Rooms AS r ON r.HotelId = h.Id
									WHERE r.Id = @TargetRoomId)
	DECLARE @curentHotelId INt = (SELECT h.Id
									FROM Trips AS t
									JOIN Rooms AS r ON r.Id = t.RoomId
									JOIN Hotels AS h ON h.Id = r.HotelId
									WHERE t.Id = @TripId)

	IF(@targetHotelId != @curentHotelId)
	BEGIN
		RAISERROR('Target room is in another hotel!' ,16 ,1)
		RETURN
	END

	DECLARE @bedCount INT = (SELECT Beds
								FROM Rooms
								WHERE Id = @TargetRoomId)
	DECLARE @needBeds INT = (SELECT COUNT(*)
								FROM AccountsTrips
								WHERE TripId = @TripId)
								
	IF(@bedCount < @needBeds)
	BEGIN
		RAISERROR('Not enough beds in target room!' ,16 ,2)
		RETURN
	END

	UPDATE Trips
		SET RoomId = @TargetRoomId
		WHERE Id = @TripId
END

--20

CREATE TRIGGER t_CancelTrip ON Trips INSTEAD OF DELETE
AS
BEGIN
	UPDATE Trips
		SET CancelDate = GETDATE()
		WHERE Id IN (SELECT Id
						FROM deleted
						WHERE CancelDate IS NULL)
END