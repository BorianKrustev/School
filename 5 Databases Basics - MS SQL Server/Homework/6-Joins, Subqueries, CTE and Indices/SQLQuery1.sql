USE SoftUni

--1

SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
 ORDER BY e.AddressID

--2

SELECT TOP(50) e.FirstName, e.LastName, t.Name, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
 ORDER BY e.FirstName, e.LastName

--3

SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS 'DepartmentName'
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] = 'Sales'
 ORDER BY e.EmployeeID

--4

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name]
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary >= 15000
 ORDER BY e.DepartmentID

--5

SELECT TOP(3) e.EmployeeID, e.FirstName
	FROM Employees AS e
	LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	WHERE ep.ProjectID IS NULL
 ORDER BY e.EmployeeID

 --DRYGO RE6ENIE

SELECT TOP(3) EmployeeID, FirstName 
	FROM Employees
	WHERE EmployeeID NOT IN (SELECT EmployeeID FROM EmployeesProjects)
 ORDER BY EmployeeID

--6

SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE YEAR(e.HireDate) > 1998 
	AND d.[Name] IN ('Sales', 'Finance')
 ORDER BY e.HireDate

--7

SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name]
	FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects as p ON ep.ProjectID = p.ProjectID
	WHERE p.StartDate > '2002.08.13'
	AND p.EndDate IS NULL
 ORDER BY e.EmployeeID

 --WHERE p.StartDate > CONVERT(smalldatetime, '13/08/2002', 103)

--8

SELECT e.EmployeeID, e.FirstName, IIF(YEAR(p.StartDate) >= 2005, NULL, p.[Name]) AS ProjectName
	FROM Employees AS e
	JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
 WHERE e.EmployeeID = 24

 --CASE
 --WHEN YEAR(p.StartDate) >= 2005 
 --THEN NUll ELSE p.[Name] 
 --END AS ProjectName

--9

SELECT e.EmployeeID, e.FirstName, ee.EmployeeID, ee.FirstName AS ManagerName
	FROM Employees AS e
	JOIN Employees AS ee ON e.ManagerID = ee.EmployeeID
	WHERE ee.EmployeeID IN (3, 7)
 ORDER BY e.EmployeeID

--10

SELECT TOP(50) e.EmployeeID, (e.FirstName + ' ' + e.LastName) AS EmployeeName, (ee.FirstName + ' ' + ee.LastName) AS ManagerName, d.[Name] AS DepartmentName
	FROM Employees AS e
	JOIN Employees AS ee ON e.ManagerID = ee.EmployeeID
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
 ORDER BY e.EmployeeID

--11

SELECT MIN(a.AVGSalary)
	FROM(
		 SELECT AVG(Salary) AS AVGSalary
		 FROM Employees
		 GROUP BY DepartmentID
		 ) AS a

--12
USE [Geography]

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains AS m ON m.Id = mc.MountainId
	JOIN Peaks AS p ON p.MountainId = m.Id
	WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
 ORDER BY p.Elevation DESC

--13

SELECT c.CountryCode, COUNT(mc.CountryCode)
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	WHERE c.CountryCode IN ('US', 'RU', 'BG')
 GROUP BY c.CountryCode

--14

SELECT TOP(5) c.CountryName, r.RiverName
	FROM Countries AS c
	JOIN Continents AS co ON c.ContinentCode = co.ContinentCode
	LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	WHERE co.ContinentName = 'Africa'
 ORDER BY c.CountryName

--15

SELECT mcu.ContinentCode, mcu.CurrencyCode, mcu.CurrencyUsage
	FROM(
	SELECT	c.ContinentCode, 
			c.CurrencyCode, 
			COUNT(c.CurrencyCode) AS CurrencyUsage,
			DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [rank]
		FROM Countries AS c
		GROUP BY c.ContinentCode, c.CurrencyCode
		HAVING COUNT(c.CurrencyCode) > 1
		) AS mcu
	WHERE mcu.[rank] = 1
 ORDER BY mcu.ContinentCode

--16

SELECT COUNT(c.CountryCode) AS CountryCode
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	WHERE mc.CountryCode IS NULL

--17

SELECT TOP(5) c.CountryName, MAX(p.Elevation) AS HighestPeakElevation, MAX(r.[Length]) AS LongestRiverLength
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId
	LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	GROUP BY c.CountryName
 ORDER BY MAX(p.Elevation) DESC, MAX(r.[Length]) DESC, c.CountryName

--18

SELECT TOP(5)	k.CountryName, 
		IIF(k.PeakName IS NULL, '(no highest peak)',k.PeakName) AS 'Highest Peak Name', 
		IIF(k.MaxElevation IS NULL, '0',k.MaxElevation) AS 'Highest Peak Elevation', 
		IIF(k.MountainRange IS NULL, '(no mountain)', k.MountainRange) AS 'Mountain'
	FROM(
		SELECT	c.CountryName,
				p.PeakName,
				MAX(p.Elevation) AS MaxElevation,
				m.MountainRange,
				DENSE_RANK () OVER (PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS ElevationRank
			FROM Countries AS c
			LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
			LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
			LEFT JOIN Peaks AS p ON m.Id = p.MountainId
			GROUP BY c.CountryName, p.PeakName, m.MountainRange
		) AS k
		WHERE k.ElevationRank = 1
 ORDER BY k.CountryName, k.PeakName

 --DRYGO RE6ENIE KOETO NE E VIARNO NO MINAVA V JUDJ

SELECT 	c.CountryName AS Country,
		ISNULL(p.PeakName, '(no highest peak)') AS 'Highest Peak Name',
		ISNULL(MAX(p.Elevation), '0') AS 'Highest Peak Elevation',
		ISNULL(m.MountainRange, '(no mountain)') AS 'Mountain'
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId
	GROUP BY c.CountryName, p.PeakName, m.MountainRange
 ORDER BY c.CountryName, p.PeakName