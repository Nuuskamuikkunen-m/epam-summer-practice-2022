use ShFiles
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

CREATE PROCEDURE dbo.ShFiles_GetById
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1
		Id, Name, Extension, CreationDate
		FROM ShFile
		WHERE Id = @id

END
go