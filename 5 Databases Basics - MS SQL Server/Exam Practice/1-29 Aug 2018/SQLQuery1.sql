CREATE DATABASE Supermarket

USE Supermarket

--1

CREAtE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Items
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Price DECIMAL(15,2) NOT NULL,
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id)
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL,
	Salary DECIMAL(15,2) NOT NULL
)

CREATE TABLE Orders
(
	Id INT PRIMARY KEY IDENTITY,
	[DateTime] DATETIME NOT NULL,
	EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id)
)

CREATE TABLE OrderItems
(
	OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(Id),
	ItemId INT NOT NULL FOREIGN KEY REFERENCES Items(Id),
	Quantity INT NOT NULL CHECK(Quantity >= 1)

	CONSTRAINT PK_OrderItems PRIMARY KEY(OrderId, ItemId)
)

CREATE TABLE Shifts
(
	Id INT IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CheckIn DATETIME NOT NULL,
	CheckOut DATETIME NOT NULL

	CONSTRAINT PK_Shifts PRIMARY KEY(id, EmployeeId)
)

ALTER TABLE Shifts
ADD CONSTRAINT CHK_CheckDates CHECK(CheckIn < CheckOut)

--2

INSERT INTO Employees(FirstName, LastName, Phone, Salary) VALUES
('Stoyan',		'Petrov',	'888-785-8573',	500.25),
('Stamat',		'Nikolov',	'789-613-1122',	999995.25),
('Evgeni',		'Petkov',	'645-369-9517',	1234.51),
('Krasimir',	'Vidolov',	'321-471-9982',	50.25)

INSERT INTO Items([Name], Price, CategoryId) VALUES
('Tesla battery',	154.25,	8),
('Chess',			30.25,	8),
('Juice',			5.32,	1),
('Glasses',			10,		8),
('Bottle of water',	1,		1)

--3

UPDATE Items
	SET Price *= 1.27
	WHERE CategoryId IN (1, 2, 3)

--4

DELETE FROM OrderItems
	WHERE OrderId = 48

DELETE FROM Orders
	WHERE Id = 48

--5

SELECT Id, FirstName
	FROM Employees
	WHERE Salary > 6500
 ORDER BY FirstName, Id

--6

SELECT (FirstName + ' ' + LastName) AS 'Full Name', Phone AS 'Phone Number'
	FROM Employees
	WHERE Phone LIKE '3%'
 ORDER BY FirstName, Phone

--7

SELECT e.FirstName, e.LastName, COUNT(o.Id) AS 'Count'
	FROM Employees AS e
	JOIN Orders AS o ON e.Id = o.EmployeeId
	GROUP BY e.FirstName, e.LastName
 ORDER BY COUNT(o.Id) DESC, e.FirstName

--8

SELECT e.FirstName, e.LastName, AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS [Work Hours]
	FROM Employees AS e
	JOIN Shifts AS s ON e.Id = s.EmployeeId
	GROUP BY e.FirstName, e.LastName, e.Id
	HAVING AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) > 7
 ORDER BY [Work Hours] DESC, e.Id

--9

SELECT TOP(1) o.Id, SUM(i.Price * oi.Quantity) AS [TotalPrice]
	FROM Orders AS o
	JOIN OrderItems AS oi ON o.Id = oi.OrderId
	JOIN Items AS i ON oi.ItemId = i.Id
	GROUP BY o.Id
 ORDER BY [TotalPrice] DESC

--10

SELECT TOP(10) o.Id, MAX(i.Price) AS [ExpensivePrice], MIN(i.Price) AS [CheapPrice]
	FROM Orders AS o
	JOIN OrderItems AS oi ON o.Id = oi.OrderId
	JOIN Items AS i ON oi.ItemId = i.Id
	GROUP BY o.Id
 ORDER BY [ExpensivePrice] DESC, o.id

--11

SELECT e.Id, e.FirstName, e.LastName
	FROM Employees AS e
	JOIN Orders AS o ON e.Id = o.EmployeeId
	GROUP BY e.Id, e.FirstName, e.LastName
 ORDER BY e.Id

--12

SELECT DISTINCT e.Id, (e.FirstName + ' ' + e.LastName) AS [Full Name]
	FROM Employees AS e
	JOIN Shifts AS s ON e.Id = s.EmployeeId
	WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) < 4
 ORDER BY e.Id

--13

SELECT TOP(10) (e.FirstName + ' ' + e.LastName) AS [Full Name], SUM(i.Price * oi.Quantity), SUM(oi.Quantity) AS [Items]
	FROM Employees AS e
	JOIN Orders AS o ON o.EmployeeId = e.Id
	JOIN OrderItems AS oi ON oi.OrderId = o.Id
	JOIN Items AS i ON i.Id = oi.ItemId
	WHERE o.DateTime < '2018-06-15'
	GROUP BY e.FirstName, e.LastName
 ORDER BY SUM(i.Price * oi.Quantity) DESC, [Items]

--14

SELECT (e.FirstName + ' ' + e.LastName) AS [Full Name], DATENAME(WEEKDAY, s.CheckOut) AS [Day of week]
	FROM Employees AS e
	LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
	JOIN Shifts AS s ON e.Id = s.EmployeeId
	WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12 AND o.EmployeeId IS NULL
 ORDER BY e.Id

--15

SELECT k.[Full Name], DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS [WorkHours], k.TotalPrice
	FROM(
		SELECT o.Id AS OrderId,
				e.Id AS [EmploiId],
				o.DATETIME,
				(e.FirstName + ' ' + e.LastName) AS [Full Name], 
				SUM(i.Price * oi.Quantity) AS [TotalPrice],
				ROW_NUMBER() OVER (PARTITION BY e.Id ORDER BY SUM(i.Price * oi.Quantity) DESC) AS RowNumber
			FROM Employees AS e
			JOIN Orders AS o ON o.EmployeeId = e.Id
			JOIN OrderItems AS oi ON oi.OrderId = o.Id
			JOIN Items AS i ON i.Id = oi.ItemId
			GROUP BY o.Id, e.FirstName, e.LastName, e.Id, o.DATETIME
		) AS k
	JOIN Shifts AS s ON s.EmployeeId = k.EmploiId
	WHERE k.RowNumber = 1 AND k.DateTime BETWEEN s.CheckIn AND s.CheckOut
 ORDER BY k.[Full Name], [WorkHours] DESC, k.TotalPrice DESC

--16

SELECT DATEPART(DAY, o.[DateTime]) AS [Day], 
	   FORMAT(AVG(i.Price * oi.Quantity), 'N2') AS [Total profit]
	FROM Orders AS o
	JOIN OrderItems AS oi ON oi.OrderId = o.Id
	JOIN Items AS i ON i.Id = oi.ItemId
	GROUP BY DATEPART(DAY, o.[DateTime])
 ORDER BY [DAY]

--17

SELECT	i.[Name], 
		c.[Name], 
		SUM(oi.Quantity), 
		SUM(oi.Quantity * i.Price)
	FROM Items AS i
	LEFT JOIN Categories AS c ON c.ID = i.CategoryId
	LEFT JOIN OrderItems AS oi ON oi.ItemId = i.Id
	GROUP BY i.Name, c.Name
 ORDER BY SUM(oi.Quantity * i.Price) DESC, SUM(oi.Quantity) DESC

--18

CREATE FUNCTION udf_GetPromotedProducts(
				@CurrentDate DATE, @StartDate DATE, @EndDate DATE, @Discount INT, @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
RETURNS VARCHAR(100)
BEGIN

	DECLARE @nameA VARCHAR(100) = (SELECT [Name] FROM Items WHERE Id = @FirstItemId)
	DECLARE @nameB VARCHAR(100) = (SELECT [Name] FROM Items WHERE Id = @SecondItemId)
	DECLARE @nameC VARCHAR(100) = (SELECT [Name] FROM Items WHERE Id = @ThirdItemId)

	IF(@nameA IS NULL OR @nameB IS NULL OR @nameC IS NULL)
	BEGIN
		RETURN('One of the items does not exists!')
	END

	IF(@StartDate >=  @CurrentDate OR @StartDate >= @EndDate)
	BEGIN
		RETURN('The current date is not within the promotion dates!')
	END

	DECLARE @priceA DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @FirstItemId)
	DECLARE @priceB DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @SecondItemId)
	DECLARE @priceC DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @ThirdItemId)


	--SET @priceA = @priceA - (@priceA * @Discount / 100)
	--SET @priceB = @priceB - (@priceB * @Discount / 100)
	DECLARE @priceAA DECIMAL(15, 2) = @priceA - (@priceA * @Discount / 100)
	DECLARE @priceBB DECIMAL(15, 2) = @priceB - (@priceB * @Discount / 100)
	DECLARE @priceCC DECIMAL(15, 2) = @priceC - (@priceC * @Discount / 100)
	
	RETURN	(@nameA+' price: '+CAST(ROUND(@priceAA,2) as varchar)+' <-> '
			+@nameB+' price: '+CAST(ROUND(@priceBB,2) as varchar)+' <-> '
			+@nameC+' price: '+CAST(ROUND(@priceCC,2) as varchar))
END

SELECT dbo.udf_GetPromotedProducts('2018-08-02', '2018-08-01', '2018-08-03',13, 3,4,5)

DROP FUNCTION dbo.udf_GetPromotedProducts

--19

CREATE PROC usp_CancelOrder(@OrderId INT, @CancelDate DATE)
AS
BEGIN
	DECLARE @id INT = (SELECT Id FROM Orders WHERE Id = @OrderId)
	
	IF(@id IS NULL)
	BEGIN
		--RAISERROR('The order does not exist!' ,16 ,1)
		--RETURN
		;THROW 51000, 'The order does not exist!', 1
	END

	DECLARE @deatTime DATETIME = (SELECT [DateTime] FROM Orders WHERE Id = @OrderId)
	DECLARE @difDeatTime DATETIME = (SELECT DATEDIFF(DAY, @deatTime, @CancelDate))

	IF(@difDeatTime > 3)
	BEGIN
		--RAISERROR('You cannot cancel the order!' ,16 ,2)
		--RETURN
		;THROW 51000, 'You cannot cancel the order!', 2
	END

	DELETE FROM OrderItems
	WHERE OrderId = @OrderId

	DELETE FROM Orders
	WHERE Id = @OrderId
END

EXEC usp_CancelOrder 1, '2018-06-02'
--20

CREATE TABLE DeletedOrders
(
	OrderId INT,
	ItemId INT,
	ItemQuantity INT
)

CREATE TRIGGER t_DeleteOrders ON OrderItems AFTER DELETE
AS
BEGIN
	INSERT INTO DeletedOrders(OrderId, ItemId, ItemQuantity)
	SELECT d.OrderId, d.ItemId, d.Quantity
		FROM deleted AS d
END