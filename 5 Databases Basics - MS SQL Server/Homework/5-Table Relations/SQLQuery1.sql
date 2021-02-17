CREATE DATABASE Test

USE Test

--1

CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY,
	FirstName VARCHAR(20) NOT NULL,
	Salary DECIMAL(15,2),
	PassportID INT NOT NULL
)

CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY,
	PassportNumber CHAR(8) NOT NULL
)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)

ALTER TABLE Persons
ADD UNIQUE (PassportID)

ALTER TABLE Passports
ADD UNIQUE (PassportNumber)

INSERT INTO Passports (PassportID, PassportNumber) VALUES
(101, 'N34FG21B')
,(102, 'K65LO4R7')
,(103, 'ZE657QP2')

INSERT INTO Persons (PersonID, FirstName, Salary, PassportID) VALUES
(1, 'Roberto', 43300.00, 102)
,(2, 'Tom',	56100.00, 103)
,(3, 'Yana',	60200.00, 101)

--2

CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(15) NOT NULL,
	EstablishedOn DATE NOT NULL
)

CREATE TABLE Models
(
	ModelID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(15) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers ([Name], EstablishedOn) VALUES
('BMW', '1916-03-07')
,('Tesla', '2003-01-01')
,('Lada', '1966-05-01')

INSERT INTO Models ([Name], ManufacturerID) VALUES
('X1', 1)
,('i6', 1)
,('Model S', 2)
,('Model X', 2)
,('Model 3', 2)
,('Nova', 3)

--3

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(20) NOT NULL
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
	[Name] VARCHAR(20) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID INT,
	ExamID INT
)

ALTER TABLE StudentsExams
ALTER COLUMN StudentID INT NOT NULL

ALTER TABLE StudentsExams
ALTER COLUMN ExamID INT NOT NULL

ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID, ExamID)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_StudentsExams_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)


INSERT INTO Students ([Name]) VALUES
('Mila')
,('Toni')
,('Ron')

INSERT INTO Exams ([Name]) VALUES
('SpringMVC')
,('Neo4j')
,('Oracle 11g')

INSERT INTO StudentsExams (StudentID, ExamID) VALUES
(1, 101)
,(1, 102)
,(2, 101)
,(3, 103)
,(2, 102)
,(2, 103)

--4

CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(20) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers (Name, ManagerID) VALUES
( 'John', NULL)
,('Maya', 106)
,('Silvia', 106)
,('Ted', 105)
,('Mark	101', 101)
,('Greta',101)

TRUNCATE TABLE Teachers

--5
