
--USE ShFiles
--GO

--Id, Name, Extension, CreationDate

--create table ShFile (
--ID int identity(1,1) constraint PK_ShFile primary key not null,
--Name varchar(max) not null, 
--Extension varchar(20),
--CreationDate DateTime not null)

--create table Users (
--ID_User int identity(1,1) constraint PK_User primary key not null,
--Name varchar(max) not null,
--Date_of_Birth DateTime,
--RegistrationDate DateTime not null,
--Email nvarchar(255) NOT NULL)

--create table FileList (
--ID_User int FOREIGN KEY REFERENCES Users(ID_User) not null,
--ID int FOREIGN KEY REFERENCES ShFile(ID) not null)

--create table AccountDetails (
--ID int identity(1,1) constraint PK_Pass primary key not null,
--Login varchar(max) not null,
--Pass varchar(max) not null,
--AdminRole bit not null,
--ID_User int FOREIGN KEY REFERENCES Users(ID_User) not null)

--insert ShFile
--values
--('Sochi2010', 'jpg', GETDATE()),
--('kursach', 'docx', GETDATE())




insert ShFile
values
('More2020', 'jpg', GETDATE()),
('sqlcode', 'txt', GETDATE())

insert Users
values
('Lera', '2022-10-04', GETDATE(), 'mymail@gmail.com'),
('Ksu', '2002-10-04', GETDATE(), 'ksumail@gmail.com')


insert FileList
values
(1,1),
(1,2),
(2,3),
(2,4)

insert AccountDetails
values
('myhardlogin', HASHBYTES('SHA2_256', 'lerasuper9000'), 1, 1),
('tihon2022', HASHBYTES('SHA2_256','ksupass9090'), 0, 2)


insert Users
values
('UserPuser', '2022-10-04', GETDATE(), 'email@gmail.com')


insert AccountDetails
values
('log', HASHBYTES('SHA2_256', 'pass'), 0, 3)

select count(Login) from AccountDetails where Login = 'log' and Pass = HASHBYTES('SHA2-256', 'pass')

insert AccountDetails
values
('loglog', 'passpass', 0, 3)

select count(Login) from AccountDetails where Login = '123' and Pass = '123'

insert AccountDetails
values
('блин', 'давайуже', 0, 3)

EXEC dbo.ShFiles_CheckLogNONHASH '123', '123';  
GO  

insert AccountDetails
values
('admin', 'admin', 1, 1)