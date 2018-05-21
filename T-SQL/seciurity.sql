-- na początek, pewnie trzeba będzie to lepiej zrobić
USE [master]
GO
CREATE LOGIN [administrator] WITH PASSWORD=N'12345678',
DEFAULT_DATABASE=[Uczelnia], DEFAULT_LANGUAGE=[polski], 
CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [Uczelnia]
GO
CREATE USER [administrator] FOR LOGIN [administrator]
GO
USE [Uczelnia]
GO
ALTER ROLE [db_owner] ADD MEMBER [administrator]
GO
--------------
USE [master]
GO
CREATE LOGIN [tutor] WITH PASSWORD=N'tutor123', 
DEFAULT_DATABASE=[Uczelnia], DEFAULT_LANGUAGE=[polski], 
CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [Uczelnia]
GO
CREATE USER [tutor] FOR LOGIN [tutor]
GO
USE [Uczelnia]
GO
ALTER ROLE [db_datareader] ADD MEMBER [tutor]
GO
USE [Uczelnia]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [tutor]
GO
------------
USE [master]
GO
CREATE LOGIN [student] WITH PASSWORD=N'student123', 
DEFAULT_DATABASE=[Uczelnia], 
DEFAULT_LANGUAGE=[polski], 
CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [Uczelnia]
GO
CREATE USER [student] FOR LOGIN [student]
GO
USE [Uczelnia]
GO
ALTER ROLE [db_datareader] ADD MEMBER [student]
GO
