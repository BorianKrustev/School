--1
USE SoftUni

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
SELECT FirstName, LastName
	FROM Employees
 WHERE Salary > 35000
 
 --ALTER PROC usp_GetEmployeesSalaryAbove35000 OR CREATE OR ALTER PROC usp_GetEmployeesSalaryAbove35000

--2

CREATE PROC usp_GetEmployeesSalaryAboveNumber @inputNUmber DECIMAL(18,4)
AS
SELECT FirstName, LastName
	FROM Employees
 WHERE Salary >= @inputNUmber

EXEC usp_GetEmployeesSalaryAboveNumber 48100

DROP PROC usp_GetEmployeesSalaryAboveNumber

--3

CREATE PROC usp_GetTownsStartingWith @input VARCHAR(20)
AS
SELECT [Name]
	FROM Towns
 WHERE [Name] LIKE @input + '%'

EXEC usp_GetTownsStartingWith 'b'

--4

CREATE PROC usp_GetEmployeesFromTown @inputTownName VARCHAR(MAX)
AS
SELECT e.FirstName, e.LastName
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
 WHERE t.[Name] = @inputTownName

--5

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(20)
BEGIN
	DECLARE @salaryLevel VARCHAR(20)

	IF(@salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low'
	END

	ELSE IF(@salary BETWEEN 30000 AND 50000)
	BEGIN
		SET @salaryLevel = 'Average'
	END

	ELSE
	BEGIN
		SET @salaryLevel = 'High'
	END

RETURN @salaryLevel
END

SELECT dbo.ufn_GetSalaryLevel(20000)

DROP FUNCTION ufn_GetSalaryLevel

--6

CREATE PROC usp_EmployeesBySalaryLevel @levelIfSalary VARCHAR(20)
AS
SELECT FirstName, LastName
	FROM Employees
 WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelIfSalary

EXEC usp_EmployeesBySalaryLevel 'High'

--7

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS INT
BEGIN
	DECLARE @count INT = 1

	WHILE(@count <= LEN(@word))
	BEGIN
		DECLARE @curentChar CHAR(1) = SUBSTRING(@word, @count, 1)

		IF(CHARINDEX(@curentChar, @setOfLetters) = 0)
		BEGIN
			RETURN 0
		END

		SET @count += 1
	END

	RETURN 1
END
 -- Retuns 1 for tru 0 for falls
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')

--8

--9
USE Bank

CREATE PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT (FirstName + ' ' + LastName) AS 'Full Name'
		FROM AccountHolders
END

EXEC usp_GetHoldersFullName

--10

CREATE PROC usp_GetHoldersWithBalanceHigherThan  @inputMony DECIMAL(18,4)
AS
BEGIN
	SELECT k.FirstName, k.LastName
		FROM(
			SELECT ah.id, ah.FirstName, ah.LastName
				FROM AccountHolders AS ah
				JOIN Accounts AS a ON ah.Id = a.AccountHolderId
				GROUP BY ah.Id, ah.FirstName, ah.LastName
			 HAVING SUM(a.Balance) > @inputMony
			 ) AS k
		 ORDER BY k.FirstName, k.LastName
END

--11

CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(18,4)
BEGIN
	DECLARE @result DECIMAL(18,4) = @sum * (POWER(1 + @yearlyInterestRate,@numberOfYears))
	RETURN @result
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--12

CREATE PROC usp_CalculateFutureValueForAccount @accountId  INT, @interestRate FLOAT
AS
BEGIN
	SELECT a.id, ac.FirstName, ac.LastName, a.Balance, dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS 'Balance in 5 years'
		FROM AccountHolders AS ac
		JOIN Accounts AS a ON ac.Id = a.AccountHolderId
		WHERE a.Id = @accountId
END

EXEC usp_CalculateFutureValueForAccount 1, 0.1

DROP PROC usp_CalculateFutureValueForAccount

--13
USE Diablo

CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(max))
RETURNS TABLE
RETURN(
		SELECT SUM(k.Cash) AS 'SumCash'
			FROM(
				SELECT g.[Name], ug.Cash, ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS 'RowNumber'
					FROM Games AS g
					JOIN UsersGames AS ug ON g.Id = ug.GameId
				 WHERE g.[Name] = @gameName
				) AS k
			 WHERE k.RowNumber % 2 = 1
	  )

SELECT * 
	FROM dbo.ufn_CashInUsersGames('Love in a mist')

--14
USE Bank

CREATE TABLE Logs 
(
	LogId INT PRIMARY KEY IDENTITY, 
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id), 
	OldSum DECIMAL(15,2), 
	NewSum DECIMAL(15,2)
)

CREATE TRIGGER tr_InsertAccountInfo ON Accounts FOR UPDATE
AS
	DECLARE @newSum DECIMAL(15,2) = (SELECT Balance FROM inserted)
	DECLARE @oldSum DECIMAL(15,2) = (SELECT Balance FROM deleted)
	DECLARE @accountId INT = (SELECT Id FROM inserted)

	INSERT INTO Logs (AccountId, NewSum, OldSum) VALUES
	(
		@accountId, @newSum, @oldSum
	)

--15

CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY, 
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id), 
	[Subject] VARCHAR(50), 
	Body VARCHAR(MAX)
)

CREATE TRIGGER tr_LogEmail ON Logs FOR INSERT
AS
	DECLARE @accountId INT = (SELECT TOP(1) AccountId FROM inserted)
	DECLARE @newSum DECIMAL(15,2) = (SELECT NewSUm FROM inserted)
	DECLARE @oldSum DECIMAL(15,2) = (SELECT OldSUm FROM inserted)

	INSERT INTO NotificationEmails(Recipient, [Subject], Body) VALUES
	(
		@accountId, 
		'Balance change for account: ' + CAST(@accountId AS VARCHAR(20)), 
		'On '+ CONVERT(VARCHAR(30), GETDATE(), 103) + ' your balance was changed from ' + CAST(@oldSum AS VARCHAR(20)) + ' to ' + CAST(@newSum AS VARCHAR(20)) + '.'
	)
