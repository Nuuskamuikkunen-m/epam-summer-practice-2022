use ShFiles
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

CREATE PROCEDURE dbo.ShFiles_CheckLog
	@pas nvarchar(255),
	@log nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	select count(Login) from AccountDetails where Login = @log and Pass = HASHBYTES('SHA2-256', @pas)

END
go


drop PROCEDURE dbo.ShFiles_CheckLog