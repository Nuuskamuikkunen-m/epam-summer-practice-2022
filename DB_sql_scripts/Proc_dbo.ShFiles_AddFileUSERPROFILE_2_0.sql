use ShFiles
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

CREATE PROCEDURE dbo.ShFiles_AddFileUSERPROFILE_2_0
	@name nvarchar(255),
	@Extension nvarchar(255),
	@CreationDate datetime,
	@iduser int

AS
BEGIN

	SET	NOCOUNT OFF;
	INSERT INTO dbo.ShFile(Name, Extension, CreationDate)
	VALUES(@name, @Extension, @CreationDate)

	DECLARE @IDfile int = (SELECT MAX(ID) FROM ShFile)
	INSERT INTO dbo.FileList(ID_User, ID)
	VALUES(@iduser, @IDfile)
END
go