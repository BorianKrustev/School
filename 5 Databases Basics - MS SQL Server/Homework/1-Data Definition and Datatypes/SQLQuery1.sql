--1
CREATE DATABASE Minions

USE Minions
--2
CREATE TABLE Minions(
Id INT PRIMARY KEY,
[Name] NVARCHAR(20) NOT NULL,
Age INT
)

CREATE TABLE Towns(
Id INT PRIMARY KEY,
[Name] NVARCHAR(20) NOT NULL,
)
--3
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)
--4

--SET IDENTITY_INSERT Minions ON

INSERT INTO Towns(Id, [Name])
VALUES	(1, 'Sofia')
		,(2, 'Plovdiv')
		,(3, 'Varna')

INSERT INTO Minions(Id, [Name], Age, TownId)
VALUES	(1, 'Kevin', 22, 1)
		,(2, 'Bob', 15, 3)
		,(3, 'Steward', NULL, 2)
--5
TRUNCATE TABLE Minions
--6
DROP TABLE Minions, Towns
--7
CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX),
Height DECIMAL(8, 2),
[Weight] DECIMAL(8,2),
Gender CHAR(1) NOT NULL,
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People([Name], Gender, Birthdate)
VALUES	('bob', 'm', '11-11-1111')
		,('asd', 'm', '11-11-1112')
		,('dsa', 'm', '11-11-1113')
		,('fgh', 'm', '11-11-1114')
		,('hgf', 'm', '11-11-1115')
--8
CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
LastLoginTime DATE,
IsDeleted NVARCHAR(5)
)

INSERT INTO Users(Username, [Password])
VALUES	('bob', '123')
		,('asd', '123')
		,('dsa', '123')
		,('fgh', '123')
		,('hgf', '123')
--13
CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(200)
)

INSERT INTO Directors(DirectorName)
VALUES	('bob')
		,('asd')
		,('dsa')
		,('qwe')
		,('ewq')


CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(200)
)

INSERT INTO Genres(GenreName)
VALUES	('bob')
		,('asd')
		,('dsa')
		,('qwe')
		,('ewq')


CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(200)
)

INSERT INTO Categories(CategoryName)
VALUES	('bob')
		,('asd')
		,('dsa')
		,('qwe')
		,('ewq')

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(30) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
CopyrightYear DATE,
[Length] INT,
GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
Rating NVARCHAR(20),
Notes NVARCHAR(200)
)

INSERT INTO Movies(Title, DirectorId, GenreId, CategoryId)
VALUES	('asd', 1, 1, 1)
		,('dsa', 1, 1, 1)
		,('qwe', 1, 1, 1)
		,('ewq', 1, 1, 1)
		,('bob', 1, 1, 1)
--14
