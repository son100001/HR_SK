CREATE FUNCTION [dbo].[udf_Department]
(	
	-- Add the parameters for the function here
	--select * from udf_Department('','VN','True')
	@Fact nvarchar(50),
	@Lan varchar(50)='VN',
	@Chart bit
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select dept.Factory_ID+'_'+dept.DepartmentCode as Code
	,(case when @Chart=0 then (case when @Lan='VN' then isnull(f.NameVN,'') when @lan='EN' then isnull(f.NameEN,'') else isnull(f.NameKR,'') end) + ' | ' else '' end)
		 + (case when @Lan='VN' then isnull(dept.DepartmentName_VN,'') when @lan='EN' then isnull(dept.DepartmentName_EN,'') else isnull(dept.DepartmentName_KR,'') end) as Name
	from SmartBooks_Department dept
	left join
	HR_Factory f
	on dept.Factory_ID=f.Factory_ID
	where (case when @Fact is null or @Fact='' then '' else dept.Factory_ID end)=isnull(@Fact,'')
)




GO
