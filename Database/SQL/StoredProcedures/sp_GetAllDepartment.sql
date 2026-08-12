create procedure [dbo].[sp_GetAllDepartment]
	@Fact nvarchar(50)='',
	@Lan varchar(50)='VN',
	@Chart bit=0
as
begin
select * from udf_Department(@Fact, @Lan, @Chart)
End


GO
