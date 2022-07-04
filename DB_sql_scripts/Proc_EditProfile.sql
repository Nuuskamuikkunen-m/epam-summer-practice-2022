use ShFiles
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

CREATE PROCEDURE dbo.ShFiles_EditNameProfile
	@Id int,
	@NewName nvarchar(255)

AS
BEGIN
	SET NOCOUNT ON;

	SET	NOCOUNT OFF;
	UPDATE dbo.Users
	SET Name = @NewName where ID_User = @Id
END
go


--------------------------------------------------------------


CREATE PROCEDURE dbo.ShFiles_EditDateProfile
	@Id int,
	@newdate datetime

AS
BEGIN
	SET NOCOUNT ON;

	SET	NOCOUNT OFF;
	UPDATE dbo.Users
	SET Date_of_Birth = @newdate where ID_User = @Id
END
go


----------------------------------


CREATE PROCEDURE dbo.ShFiles_EditEmailProfile
	@Id int,
	@NewEmail nvarchar(255)

AS
BEGIN
	SET NOCOUNT ON;

	SET	NOCOUNT OFF;
	UPDATE dbo.Users
	SET Email = @NewEmail where ID_User = @Id
END
go


-------------------------------------------


CREATE PROCEDURE dbo.ShFiles_EditLoginProfile
	@Id int,
	@newlog nvarchar(255)

AS
BEGIN
	SET NOCOUNT ON;

	SET	NOCOUNT OFF;
	UPDATE dbo.AccountDetails
	SET Login = @newlog where ID = @Id
END
go


--------------------------------------------------



CREATE PROCEDURE dbo.ShFiles_EditPasswordProfile
	@Id int,
	@newpass nvarchar(255)

AS
BEGIN
	SET NOCOUNT ON;

	SET	NOCOUNT OFF;
	UPDATE dbo.AccountDetails
	SET Pass = @newpass where ID = @Id
END
go