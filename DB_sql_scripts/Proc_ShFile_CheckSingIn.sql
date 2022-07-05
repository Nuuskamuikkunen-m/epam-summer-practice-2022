use ShFiles
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.ShFile_CheckSingIn
	@log nvarchar(255),
	@pas nvarchar(255),
	@role nvarchar(255) output
as
BEGIN

	--declare @role nvarchar(255) output

	declare @Login nvarchar(20)
	declare @Pass nvarchar(20)
	set @role=-2
	set @Login = (select Login from AccountDetails where Login = @log)
	set @Pass = (select Pass from AccountDetails where Login = @Login)
	if (@Pass = @pas)
	set @role= (select AdminRole from AccountDetails where Pass = @Pass)
	select @role

	--else return 0


END