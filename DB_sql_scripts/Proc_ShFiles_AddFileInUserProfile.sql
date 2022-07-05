use ShFiles
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 


CREATE PROCEDURE dbo.ShFiles_AddFileInUserProfile
	@iduser int
AS
BEGIN

	SET	NOCOUNT OFF;
	DECLARE @IDfile int = (SELECT MAX(ID) FROM ShFile)
	INSERT INTO dbo.FileList(ID_User, ID)
	VALUES(@iduser, @IDfile)
END
go


select * from  FileList

select * from  ShFile