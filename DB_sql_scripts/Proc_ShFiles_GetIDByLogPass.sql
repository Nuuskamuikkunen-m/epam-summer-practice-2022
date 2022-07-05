use ShFiles
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

CREATE PROCEDURE dbo.ShFiles_GetIDByLogPass
	
	@pas nvarchar(255),
	@log nvarchar(255)
	
AS
BEGIN
	SET NOCOUNT ON;
	
	select ID_User from AccountDetails where Login = @log and Pass =  @pas
END
go