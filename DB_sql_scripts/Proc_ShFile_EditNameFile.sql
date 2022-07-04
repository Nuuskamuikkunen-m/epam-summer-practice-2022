use ShFiles
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

CREATE PROCEDURE dbo.ShFiles_EditNameFile
	@Id int,
	@NewName nvarchar(255)

AS
BEGIN
	SET NOCOUNT ON;

	SET	NOCOUNT OFF;
	UPDATE dbo.ShFile
	SET Name = @NewName where id = @Id
END
go