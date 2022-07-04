use ShFiles
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

CREATE PROCEDURE dbo.ShFiles_GetInfoById
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Name, Extension, CreationDate 
	FROM  dbo.ShFile join dbo.FileList 
	ON (dbo.FileList.ID = dbo.ShFile.ID)
	WHERE ID_User = @id

END
go


