USE Uczelnia;


ALTER TABLE Administrators
	ADD CONSTRAINT pk_adm PRIMARY KEY (id),
		CONSTrAiNT unique_username UNIQUE (username);

ALTER TABLE Faculties
	ADD CONSTRAINT pk_fac PRIMARY KEY (id);

ALTER TABLE Subjects
	ADD CONSTRAINT pk_sub PRIMARY KEY (id);

ALTER TABLE Students
	ADD CONSTRAINT pk_stud PRIMARY KEY (index_number),
		faculty_id INTEGER,
		CONSTRAINT fk_fac_stud FOREIGN KEY (faculty_id) REFERENCES Faculties(id)
	;
ALTER TABLE Tutors
	ADD CONSTRAINT pk_tut PRIMARY KEY (id),
		faculty_id INTEGER,
		CONSTRAINT fk_fac_tut FOREIGN KEY (faculty_id) REFERENCES Faculties(id),
		CONSTRAINT unique_login UNIQUE (username)
	;

CREATE TABLE SubjectToTutors(
	subject_id INTEGER NOT NULL,
	tutor_id INTEGER NOT NULL
);
ALTER TABLE SubjectToTutors
	ADD CONSTRAINT fk_sub FOREIGN KEY (subject_id) REFERENCES Subjects(id),
		CONSTRAINT fk_tut FOREIGN KEY (tutor_id) REFERENCES Tutors(id),
		CONSTRAINT pk_stt PRIMARY KEY (tutor_id, subject_id)
	;
CREATE TABLE StudentToSubject (
	student_id INTEGER NOT NULL,
	subject_id INTEGER NOT NULL
);

ALTER TABLE StudentToSubject
	ADD CONSTRAINT fk_stud FOREIGN KEY (student_id) REFERENCES Students(index_number),
		CONSTRAINT fk_subj FOREIGN KEY (subject_id) REFERENCES Subjects(id),
		CONSTRAINT pk_sts PRIMARY KEY (student_id, subject_id)
	;

ALTER TABLE Marks
	ADD CONSTRAINT pk_mk PRIMARY KEY (id),
		student_id INTEGER,
		subject_id INTEGER,
		CONSTRAINT fk_std_sub_mk FOREIGN KEY (student_id,subject_id) REFERENCES StudentToSubject(student_id,subject_id)
	;