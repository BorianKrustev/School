CREATE DATABASE School

USE School

--1

CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT CHECK(Age >= 1),
	[Address] NVARCHAR(50),
	Phone NCHAR(10)
)

CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY, 
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL
)

CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY, 
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(15,2) NOT NULL CHECK(Grade >= 2 AND Grade <= 6)
)

CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY, 
	Date DATE,
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE StudentsExams
(
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
	ExamId INT NOT NULL FOREIGN KEY REFERENCES Exams(Id),
	Grade DECIMAL(15,2) NOT NULL CHECK(Grade >= 2 AND Grade <= 6)
)

ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentId, ExamId)

CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Address NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE StudentsTeachers
(
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
	TeacherId INT NOT NULL FOREIGN KEY REFERENCES Teachers(Id)

	CONSTRAINT PK_StudentsTeachers PRIMARY KEY(StudentId, TeacherId)
)

--2

INSERT INTO Teachers(FirstName, LastName, Address, Phone, SubjectId) VALUES
('Ruthanne',	'Bamb',			'84948 Mesta Junction',		'3105500146',	6),
('Gerrard',		'Lowin',		'370 Talisman Plaza',		'3324874824',	2),
('Merrile',		'Lambdin',		'81 Dahle Plaza',			'4373065154',	5),
('Bert',		'Ivie',			'2 Gateway Circle',			'4409584510',	4)

INSERT INTO Subjects(Name, Lessons) VALUES
('Geometry',		12),
('Health',		10),
('Drama',		7),
('Sports',		9)

--3

UPDATE StudentsSubjects
	SET Grade = 6.00
	WHERE SubjectId IN (1, 2) AND Grade >= 5.50

--4

DELETE FROM StudentsTeachers
	WHERE TeacherId IN (SELECT t.ID 
							FROM Teachers AS t
							WHERE t.Phone LIKE '%72%')

DELETE FROM Teachers
	WHERE Phone LIKE '%72%'

--5

SELECT FirstName, LastName, Age
	FROM Students
	WHERE Age >= 12
 ORDER BY FirstName, LastName

--6

SELECT (FirstName + ' ' + ISNULL(MiddleName + ' ', ' ') + LastName) AS [Full Name], Address
	FROM Students
	WHERE Address LIKE '%road%'
 ORDER BY FirstName, LastName, Address

--7

SELECT FirstName, Address, Phone
	FROM Students
	WHERE Phone LIKE '42%' AND MiddleName IS NOT NULL
 ORDER BY FirstName

--8

SELECT FirstName, LastName, COUNT(st.StudentId)
	FROM Students AS s
	JOIN StudentsTeachers AS st ON s.Id = st.StudentId
	GROUP BY FirstName, LastName

--9

SELECT (t.FirstName + ' ' + t.LastName), s.Name + '-' + CONVERT(VARCHAR(10), s.Lessons) , COUNT(st.StudentId)
	FROM Teachers AS t
	JOIN Subjects AS s ON t.SubjectId = s.Id
	JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
	GROUP BY t.FirstName, t.LastName, s.Name, s.Lessons
 ORDER BY COUNT(st.StudentId) DESC

--10

SELECT (s.FirstName + ' ' + s.LastName) AS [FullName]
	FROM Students AS s
	LEFT JOIN StudentsExams AS se ON se.StudentId = s.Id
	WHERE se.ExamId IS NULL
 ORDER BY [FullName]

--11

SELECT TOP(10) t.FirstName, t.LastName, COUNT(st.StudentId) AS Cou
	FROM Teachers AS t
	JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
	GROUP BY t.FirstName, t.LastName
 ORDER BY Cou DESC, t.FirstName, t.LastName

--12

SELECT TOP(10) s.FirstName, s.LastName, STR(AVG(se.Grade), 15, 2)
	FROM Students AS s
	JOIN StudentsExams AS se ON se.StudentId = s.Id
	GROUP BY s.FirstName, s.LastName
 ORDER BY AVG(se.Grade) DESC, s.FirstName, s.LastName

--13

SELECT k.FirstName, k.LastName, k.Grade
	FROM(
		SELECT s.FirstName, s.LastName, se.Grade, 
				ROW_NUMBER() OVER(PARTITION BY s.Id ORDER BY se.Grade DESC) AS RowNumber
			FROM Students AS s
			JOIN StudentsSubjects AS se ON se.StudentId = s.Id
		) AS k
	WHERE k.RowNumber = 2
 ORDER BY k.FirstName, k.LastName
	
--14

SELECT (s.FirstName + ' ' + ISNULL(s.MiddleName + ' ', '') + s.LastName) AS [FullName]
	FROM Students AS s
	LEFT JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
	WHERE ss.SubjectId IS NULL
 ORDER BY [FullName]

--15

SELECT k.[Teacher Full Name], k.[Subject Name], k.[Student Full Name], k.Grade
	FROM(
		SELECT	(t.FirstName + ' ' + t.LastName) AS [Teacher Full Name],
				sub.Name AS [Subject Name],
				(s.FirstName + ' ' + ISNULL(s.MiddleName + ' ', '') + s.LastName) AS [Student Full Name],
				Str(AVG(ss.Grade), 15, 2) AS [Grade],
				ROW_NUMBER() OVER(PARTITION BY t.FirstName ORDER BY AVG(ss.Grade) DESC) AS RowNumber
			FROM Teachers AS t
			JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
			JOIN Students AS s ON st.StudentId = s.Id
			JOIN Subjects AS sub ON t.SubjectId = sub.Id
			JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
			GROUP BY t.FirstName, t.LastName, sub.Name, s.FirstName, s.MiddleName, s.LastName
		) AS k
	WHERE k.RowNumber = 1
 ORDER BY k.[Subject Name], k.[Teacher Full Name], k.Grade DESC

--16

SELECT s.Name, AVG(ss.Grade)
	FROM Subjects AS s
	JOIN StudentsSubjects AS ss ON s.Id = ss.SubjectId
	GROUP BY s.Name, s.Id
 ORDER BY s.Id

--17

SELECT k.Quarter, k.SubjectName, SUM(k.StudentsCount)
	FROM(
		SELECT CASE WHEN MONTH(e.Date) <= 3
					THEN 'Q1'
					WHEN MONTH(e.Date) >= 4 AND MONTH(e.Date) <=6
					THEN 'Q2'
					WHEN MONTH(e.Date) >= 7 AND MONTH(e.Date) <= 9
					THEN 'Q3'
					WHEN MONTH(e.Date) >= 10 AND MONTH(e.Date) <= 12
					THEN 'Q4'
					ELSE 'TBA'
				END AS [Quarter],
				s.Name AS [SubjectName],
				COUNT(se.StudentId) AS [StudentsCount]
			FROM Exams AS e
			JOIN Subjects AS s ON s.Id = e.SubjectId
			JOIN StudentsExams AS se ON e.Id = se.ExamId
			WHERE se.Grade >= 4.00
			GROUP BY e.Date, s.Name
		) AS k
	GROUP BY k.Quarter, k.SubjectName
 ORDER BY k.Quarter

--18

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15, 2))
RETURNS VARCHAR(MAX)
BEGIN
	DECLARE @FirstName NVARCHAR(50) = (SELECT FirstName
										FROM Students
										WHERE Id = @studentId)

	IF(@FirstName IS NULL)
	BEGIN
		RETURN 'The student with provided id does not exist in the school!'
	END

	IF(@grade > 6.00)
	BEGIN
		RETURN 'Grade cannot be above 6.00!'
	END

	DECLARE @Count INT = (SELECT COUNT(ss.Grade)
							FROM Students AS s
							JOIN StudentsExams AS ss ON ss.StudentId = s.Id
							WHERE Grade >= @grade AND Grade <= (@grade + 0.50) AND s.Id = @studentId)

	RETURN 'You have to update ' + CAST(ROUND(@Count,2) as varchar) + ' grades for the student ' + @FirstName
END

--19

CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	DECLARE @CHeck NVARCHAR(100) = (SELECT FirstName
										FROM Students
										WHERE Id = @StudentId)

	IF(@CHeck IS NULL)
	BEGIN
		;THROW 51000, 'This school has no student with the provided id!', 1
	END

	DELETE FROM StudentsExams
			WHERE StudentId IN (SELECT Id
									FROM Students
									WHERE Id = @StudentId)

	DELETE FROM StudentsTeachers
			WHERE StudentId IN (SELECT Id
									FROM Students
									WHERE Id = @StudentId)

	DELETE FROM StudentsSubjects
			WHERE StudentId IN (SELECT Id
									FROM Students
									WHERE Id = @StudentId)

	DELETE FROM Students
			WHERE Id = @StudentId
END

--20

CREATE TABLE ExcludedStudents
(
	StudentId INT PRIMARY KEY,
	StudentName NVARCHAR(50)
)

CREATE TRIGGER t_DeletedStudent ON Students AFTER DELETE
AS
BEGIN
	INSERT INTO ExcludedStudents(StudentId, StudentName)
	SELECT d.Id, (d.FirstName + ' ' + d.LastName)
		FROM deleted AS d
END