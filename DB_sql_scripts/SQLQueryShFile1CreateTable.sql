
--USE ShFiles
--GO

--Id, Name, Extension, CreationDate

--create table ShFile (
--ID int identity(1,1) constraint PK_ShFile primary key not null,
--Name varchar(max) not null, 
--Extension varchar(20),
--CreationDate DateTime not null)

--create table FileList (
--ID_List int identity(1,1) constraint PK_List primary key not null,
--ID int FOREIGN KEY REFERENCES ShFile(ID) not null)

--create table Users (
--ID_User int identity(1,1) constraint PK_User primary key not null,
--Name varchar(max) not null,
--Date_of_Birth DateTime,
--RegistrationDate DateTime not null,
--AdminFlag bit not null,
--ID_List int FOREIGN KEY REFERENCES FileList(ID_List) not null)



insert ShFile
values
('Sochi2010', 'jpg', GETDATE()),
('kursach', 'docx', GETDATE())




create table MailPass (
ID int identity(1,1) constraint PK_Pass primary key not null,
Mail varchar(max) not null,
Pass varchar(max) not null,
ID_User int FOREIGN KEY REFERENCES Users(ID_User) not null)