CREATE DATABASE Uczelnia;

USE Uczelnia;
CREATE TABLE Administrators(
	id INTEGER IDENTITY(1,1),
	username VARCHAR(64) NOT NULL,
	password VARCHAR(64) NOT NULL,
	email VARCHAR(64)
);

CREATE TABLE Students(
	index_number INTEGER IDENTITY(1,1), -- to bedzie login
	password VARCHAR(64) NOT NULL,
	s_name VARCHAR(32) NOT NULL,
	surname VARCHAR(32) NOT NULL,
	field_of_study CHAR(20) NOT NULL,
	degree VARCHAR(15) NOT NULL,
	mode CHAR(15) NOT NULL,
	semester INTEGER NOT NULL
);

CREATE TABLE Tutors(
	id INTEGER IDENTITY(1,1),
	t_name VARCHAR(32),
	surname VARCHAR(32),
	institute VARCHAR(50),
	username VARCHAR(64),
	password VARCHAR(64)
);

CREATE TABLE Faculties(
	id INTEGER IDENTITY(1,1),
	faculty_name VARCHAR(64),
	description VARCHAR(255)
);

CREATE TABLE Marks(
	id INTEGER IDENTITY(1,1),
	mark_value DECIMAL(2,1)
);

CREATE TABLE Subjects(
	id INTEGER IDENTITY(1,1),
	subject_name VARCHAR(32)
);