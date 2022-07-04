use ShFiles
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

CREATE PROCEDURE dbo.ShFiles_AddUser
	@Name nvarchar(255),
	@DateB datetime,
	@regdate datetime,
	@email nvarchar(255),
	@Pass nvarchar(255),
	@Login nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	declare @usid int = (select max(ID_User) from Users)
	set @usid = @usid + 1
	insert into Users values 
	(@Name, @DateB, @regdate, @email)
	insert into AccountDetails values
	(@Login, HASHBYTES('SHA2_512', @Pass), 0, @usid)

END
go


