use ShFiles
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

CREATE PROCEDURE dbo.ShFiles_CheckLogNONHASHwithROLE
	
	@pas nvarchar(255),
	@log nvarchar(255),
	@role nvarchar(255) output

	
AS
BEGIN
	SET NOCOUNT ON;
	 declare @n int
	 set @n = (select count(Login) from AccountDetails where Login = @log and Pass =  @pas)
	 if (@n = 1)
		set @role= (select AdminRole from AccountDetails where Pass = @pas)
	 select @role
END
go

drop PROCEDURE ShFiles_CheckLogNONHASHwithROLE