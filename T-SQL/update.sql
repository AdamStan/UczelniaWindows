/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [student_id]
      ,[subject_id]
  FROM [Uczelnia].[dbo].[StudentToSubject]

 Select * from StudentToSubject
 SELECT * from SubjectToTutors
 SELECT * FROM Subjects
 SELECT * FROM Students
 SELECT * FROM Faculties
 Select * from Tutors

update Students set faculty_id = 2 where index_number = 1 OR index_number = 2;
update Students set faculty_id = 5 where index_number = 3;
update Students set faculty_id = 7 where index_number = 4;

Insert into StudentToSubject values (1,1)

update Tutors set faculty_id = 1

Insert into SubjectToTutors values (1,1),(1,2),(1,3)
