SELECT s.FirstName, s.LastName, e.Name, e.Language FROM StudentExercise se
JOIN Student s on s.Id = se.StudentId
JOIN Exercise e on e.Id = se.ExerciseId;

--groupby

SELECT s.CohortId, c.Name, COUNT(s.CohortId) StudentCount 
FROM Student s
JOIN Cohort c ON s.CohortId = c.Id
GROUP BY c.Name, CohortId;
