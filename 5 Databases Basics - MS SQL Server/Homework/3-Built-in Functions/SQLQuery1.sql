USE SoftUni
--1
SELECT FirstName, LastName FROM Employees WHERE FirstName LIKE 'SA%'
--2
SELECT FirstName, LastName FROM Employees WHERE LastName LIKE '%ei%'
--3
SELECT FirstName FROM Employees WHERE DepartmentID IN (3, 10) AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005
															--DATEPART(YEAR, HireDate) - Returns the specified part of the date as a int
--4
SELECT FirstName, LastName FROM Employees WHERE JobTitle NOT LIKE '%engineer%'
--5
SELECT [Name] FROM Towns WHERE LEN([Name]) = 5 OR LEN([Name]) = 6 ORDER BY [Name]
--6
SELECT * FROM Towns WHERE LEFT([Name], 1) LIKE '[MKBE]' ORDER BY [Name]
--7
SELECT * FROM Towns WHERE LEFT([Name], 1) NOT LIKE '[RBD]' ORDER BY [Name]
--8
CREATE VIEW V_EmployeesHiredAfter2000
AS
	SELECT FirstName, LastName FROM Employees WHERE DATEPART(YEAR, HireDate) > 2000
--9
SELECT FirstName, LastName FROM Employees WHERE LEN(LastName) = 5
--10

--11

--12
SELECT CountryName, IsoCode FROM Countries WHERE CountryName LIKE '%a%%a%%a%' ORDER BY IsoCode
--13

--14