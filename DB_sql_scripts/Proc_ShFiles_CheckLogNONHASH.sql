use ShFiles
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

CREATE PROCEDURE dbo.ShFiles_CheckLogNONHASH
	
	@pas nvarchar(255),
	@log nvarchar(255)
	
AS
BEGIN
	SET NOCOUNT ON;

	 select count(Login) from AccountDetails where Login = @log and Pass =  @pas

END
go

drop PROCEDURE dbo.ShFiles_CheckLogNONHASH