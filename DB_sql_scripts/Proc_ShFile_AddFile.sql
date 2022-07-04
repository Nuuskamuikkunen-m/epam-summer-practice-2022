use ShFiles
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

CREATE PROCEDURE dbo.ShFiles_AddFile
	@name nvarchar(255),
	@Extension nvarchar(255),
	@CreationDate datetime

AS
BEGIN
	SET NOCOUNT ON;

	SET	NOCOUNT OFF;
	INSERT INTO dbo.ShFile(Name, Extension, CreationDate)
	VALUES(@name, @Extension, @CreationDate)
END
go