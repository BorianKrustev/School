SELECT * FROM WizzardDeposits

--1
USE Gringotts

SELECT COUNT(*) 
	FROM WizzardDeposits
--2
SELECT MAX(MagicWandSize) AS LongestMagicWand 
	FROM WizzardDeposits
--3
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand 
	FROM WizzardDeposits 
	GROUP BY DepositGroup
--4

--5
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	GROUP BY DepositGroup
--6
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
--7
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
	HAVING SUM(DepositAmount) < 150000
	ORDER BY SUM(DepositAmount) DESC
--8
SELECT DepositGroup, MagicWandCreator,  MIN(DepositCharge) AS MinDepositCharge
	FROM WizzardDeposits
	GROUP BY DepositGroup, MagicWandCreator
	ORDER BY MagicWandCreator, DepositGroup