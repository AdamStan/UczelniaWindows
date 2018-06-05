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

CREATE VIEW View_Marks AS
SELECT        dbo.Marks.mark_value, dbo.Subjects.subject_name, dbo.Tutors.t_name, dbo.Tutors.surname, dbo.Marks.student_id, dbo.Marks.id, dbo.Tutors.username
FROM            dbo.Marks INNER JOIN
                         dbo.Subjects ON dbo.Marks.id = dbo.Subjects.id LEFT OUTER JOIN
                         dbo.SubjectToTutors ON dbo.Subjects.id = dbo.SubjectToTutors.subject_id LEFT OUTER JOIN
                         dbo.Tutors ON dbo.SubjectToTutors.tutor_id = dbo.Tutors.id