use ShFiles
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

CREATE PROCEDURE dbo.ShFiles_CheckLog
	@Pass nvarchar(255),
	@Login nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	select count(Login) from AccountDetails where Login = @Login and Pass = HASHBYTES('SHA2-512', @Pass)

END
go


