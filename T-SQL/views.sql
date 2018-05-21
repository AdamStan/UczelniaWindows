USE Uczelnia
go
CREATE VIEW StudentsView AS 
SELECT dbo.Students.index_number, dbo.Students.s_name, 
	dbo.Students.surname, dbo.Faculties.faculty_name
FROM dbo.Faculties INNER JOIN
dbo.Students ON dbo.Faculties.id = dbo.Students.faculty_id;
GO

CREATE VIEW TutorsView AS 
SELECT dbo.Faculties.faculty_name, dbo.Tutors.t_name, dbo.Tutors.surname
FROM dbo.Faculties INNER JOIN
dbo.Tutors ON dbo.Faculties.id = dbo.Tutors.faculty_id
GO

CREATE VIEW MarksView AS
SELECT dbo.Students.index_number, dbo.Subjects.subject_name, dbo.Marks.mark_value
FROM dbo.Marks INNER JOIN
dbo.Students ON dbo.Marks.student_id = dbo.Students.index_number INNER JOIN
dbo.StudentToSubject ON dbo.Students.index_number = dbo.StudentToSubject.student_id INNER JOIN
dbo.Subjects ON dbo.Marks.subject_id = dbo.Subjects.id 
AND dbo.StudentToSubject.subject_id = dbo.Subjects.id