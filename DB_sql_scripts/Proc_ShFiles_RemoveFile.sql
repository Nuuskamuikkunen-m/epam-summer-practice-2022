use ShFiles
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

CREATE PROCEDURE dbo.ShFiles_RemoveFile
	@Id int

AS
BEGIN
	SET NOCOUNT ON;

	SET	NOCOUNT OFF;
	DELETE FROM dbo.ShFile where id = @Id
END
go