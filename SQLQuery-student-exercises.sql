--CREATE TABLE Cohort (
--    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--    Name VARCHAR(55) NOT NULL
--);

--CREATE TABLE Exercise (
--    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--    Name VARCHAR(55) NOT NULL,
--    Language VARCHAR(55) NOT NULL
--);

--CREATE TABLE Student (
--    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--    FirstName VARCHAR(55) NOT NULL,
--    LastName VARCHAR(55) NOT NULL,
--    SlackHandle VARCHAR(55) NOT NULL,
--    CohortId INTEGER,
--    CONSTRAINT FK_Student_Cohort FOREIGN KEY(CohortId) REFERENCES Cohort(Id)

--);

--CREATE TABLE Instructor (
--    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--    FirstName VARCHAR(55) NOT NULL,
--    LastName VARCHAR(55) NOT NULL,
--    SlackHandle VARCHAR(55) NOT NULL,
--    Specialty VARCHAR(55) NOT NULL,
--    CohortId INTEGER,
--    CONSTRAINT FK_Instructor_Cohort FOREIGN KEY(CohortId) REFERENCES Cohort(Id)

--);

--CREATE TABLE StudentExercise (
--    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--    StudentId INTEGER,
--    ExerciseId INTEGER,
--    CONSTRAINT FK_StudentExercise_Student FOREIGN KEY(StudentId) REFERENCES Student(Id),
--    CONSTRAINT FK_StudentExercise_Exercise FOREIGN KEY(ExerciseId) REFERENCES Exercise(Id)
--);


--INSERT INTO Cohort (Name) VALUES ('Cohort 35');
--INSERT INTO Cohort (Name) VALUES ('Cohort 36');
--INSERT INTO Cohort (Name) VALUES ('Cohort 37');
--INSERT INTO Cohort (Name) VALUES ('Cohort 34');

--INSERT INTO Exercise (Name, Language) VALUES ('Heist', 'C#');
--INSERT INTO Exercise (Name, Language) VALUES ('Student Exercises', 'C#');
--INSERT INTO Exercise (Name, Language) VALUES ('Journal', 'JS');
--INSERT INTO Exercise (Name, Language) VALUES ('Welcome to Nashville', 'JS');

--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Steve', 'Jones', 'SJones', 3);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Paul', 'Wallace', 'PWallace', 4);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Lamar', 'Francis', 'LFrances', 1);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Jo', 'Bob', 'JOBOB', 3);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Whitney', 'Pearce', 'WPearce', 3);

--INSERT INTO Instructor (FirstName, LastName, SlackHandle, Specialty, CohortId) VALUES ('Whitney', 'Pearce', 'WPearce', 'fun', 3);
--INSERT INTO Instructor (FirstName, LastName, SlackHandle, Specialty, CohortId) VALUES ('Whitney', 'Pearce', 'WPearce', 'C#', 4);
--INSERT INTO Instructor (FirstName, LastName, SlackHandle, Specialty, CohortId) VALUES ('Whitney', 'Pearce', 'WPearce', 'JS', 2);
--INSERT INTO Instructor (FirstName, LastName, SlackHandle, Specialty, CohortId) VALUES ('Whitney', 'Pearce', 'WPearce', 'Git', 1);


--INSERT INTO StudentExercise (StudentId, ExerciseId) VALUES (1, 1);
--INSERT INTO StudentExercise (StudentId, ExerciseId) VALUES (1, 2);
--INSERT INTO StudentExercise (StudentId, ExerciseId) VALUES (2, 1);
--INSERT INTO StudentExercise (StudentId, ExerciseId) VALUES (2, 3);
--INSERT INTO StudentExercise (StudentId, ExerciseId) VALUES (3, 1);
--INSERT INTO StudentExercise (StudentId, ExerciseId) VALUES (3, 4);
--INSERT INTO StudentExercise (StudentId, ExerciseId) VALUES (4, 1);
--INSERT INTO StudentExercise (StudentId, ExerciseId) VALUES (4, 2);
--INSERT INTO StudentExercise (StudentId, ExerciseId) VALUES (5, 1);
--INSERT INTO StudentExercise (StudentId, ExerciseId) VALUES (5, 2);

