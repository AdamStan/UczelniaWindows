select * from StudentToSubject
select * from SubjectToTutors
select * from Marks
select * from Subjects
select * from Administrators
select * from Faculties
select * from Tutors
select * from Students

insert into Administrators values ('Administrator','Allariana','kinga.sochacka08@gmail.com')
insert into Administrators values ('Admin','123456','adam.stanczyk@gmail.com')

insert into Faculties values ('WM','Wydzia� Mechaniczny')
insert into Faculties values ('WEEIA','Wydzia� Elektrotechniki, Elektroniki, Informatyki i Automatyki')
insert into Faculties values ('WCH','Wydzia� Chemiczny')
insert into Faculties values ('WTMiWT','Wydzia� Technologii Materia�owych i Wzornictwa Tekstyli�w')
insert into Faculties values ('WBiNo�','Wydzia� Biotechnologii i Nauk o �ywno�ci')
insert into Faculties values('WBAiI�','Wydzia� Budownictwa, Architektoru i In�ynierii �rodowiska')
insert into Faculties values ('WFTIMS','Wydzia� Fizyki Technicznej, Informatyki i Matematyki Stosowanej')
insert into Faculties values ('WZiIP','Wydzia� Zarzadzania i In�ynierii Produkcji')
insert into Faculties values ('WIPiO�','Wydzia� In�ynierii Procesowej i Ochrony �rodowiska')

insert into Students values ('12345','Karolina','Piotrowska','informatyka','in�ynierskie','stacjonarne',2,2)
insert into Students values ('12345','Piotr','�uczak','eletrotechnika','magisterskie','niestacjonarne',1,2)
insert into Students values ('fsdff','Magdalena','Nowak','biotechnologia','doktoranckie','stacjonarne',2,5)
insert into Students values ('asfsfsvfsdf','Marcin','Pozna�ski','fizyka techniczna','in�ynierskie','niestacjonarne',6,7)

insert into Tutors values ('Pawe�','Nowacki','IIS','pnowacki','akijudasd',2)
insert into Tutors values ('Marek','Kowalski','KAE','mkowalski','gfdgdgn',2)
insert into Tutors values ('Ewa','Karwat','ICH','ekarwat','bdhdhdf',5)

insert into Subjects values ('Podstawy programowania 2')
insert into Subjects values ('Aparaty elektryczne')
insert into Subjects values ('Chemia organiczna')
insert into Subjects values ('Algorytmy i struktury danych')
insert into Subjects values ('Analiza matematyczna')
insert into Subjects values ('Chemia fizyczna')

insert into StudentToSubject values (1,1)
insert into StudentToSubject values (1,2)
insert into StudentToSubject values (1,3)

insert into SubjectToTutors values (1,1)
insert into SubjectToTutors values (1,2)
insert into SubjectToTutors values (1,3)

insert into Marks values (2.5,1,1),(3.5,1,2),(4.5,1,3)