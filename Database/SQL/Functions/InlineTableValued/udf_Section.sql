CREATE FUNCTION [dbo].[udf_Section]
(	
	-- Add the parameters for the function here
	--select * from udf_Department('','VN')
	@Fact nvarchar(50),
	@Dept nvarchar(50),
	@Lan varchar(50),
	@Chart bit
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select dept.Factory_ID+'_'+dept.DepartmentCode+'_'+sect.SectionCode as Code
	,(case when @Chart=0 then (case when @Lan='VN' then isnull(f.NameVN,'') when @lan='EN' then isnull(f.NameEN,'') else isnull(f.NameKR,'') end)
		+' | ' + (case when @Lan='VN' then isnull(dept.DepartmentName_VN,'') when @lan='EN' then isnull(dept.DepartmentName_EN,'') else isnull(dept.DepartmentName_KR,'') end)
		+' | ' else '' end)
		+ (case when @Lan='VN' then isnull(sect.SectionName_VN,'') when @lan='EN' then isnull(sect.SectionName_EN,'') else isnull(sect.SectionName_KR,'') end)
		as Name
	from
	SmartBooks_Section sect
	left join
	SmartBooks_Department dept
	on sect.DepartmentCode=dept.DepartmentCode and sect.Factory_ID=dept.Factory_ID
	left join
	HR_Factory f
	on sect.Factory_ID=f.Factory_ID
	where (case when @Fact is null or @Fact='' then '' else sect.Factory_ID end)=isnull(@Fact,'')
		and (case when @Dept is null or @Dept='' then '' else sect.DepartmentCode end)=isnull(@Dept,'')
)




GO
