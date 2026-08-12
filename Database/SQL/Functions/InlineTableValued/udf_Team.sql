CREATE FUNCTION [dbo].[udf_Team]
(	
	-- Add the parameters for the function here
	--select * from udf_Team('','','','VN',0)
	@Fact nvarchar(50),
	@Dept nvarchar(50),
	@Sect nvarchar(50),
	@Lan varchar(50),
	@Chart bit
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select dept.Factory_ID+'_'+dept.DepartmentCode+'_'+isnull(sect.SectionCode,'')+'_'+team.TeamCode as Code
	,(case when @Chart=0 then (case when @Lan='VN' then isnull(f.NameVN,'') when @lan='EN' then isnull(f.NameEN,'') else isnull(f.NameKR,'') end)
		+' | ' + (case when @Lan='VN' then isnull(dept.DepartmentName_VN,'') when @lan='EN' then isnull(dept.DepartmentName_EN,'') else isnull(dept.DepartmentName_KR,'') end)
		+' | ' + (case when @Lan='VN' then isnull(sect.SectionName_VN,'') when @lan='EN' then isnull(sect.SectionName_EN,'') else isnull(sect.SectionName_KR,'') end)
		+' | ' else '' end)
		+ (case when @Lan='VN' then isnull(team.Description_VN,'') when @lan='EN' then isnull(team.Description_EN,'') else isnull(team.Description_KR,'') end)
		as Name
	from
	SmartBooks_Team team
	left join
	SmartBooks_Section sect
	on team.SectionCode=sect.SectionCode and team.DepartmentCode=sect.DepartmentCode and team.Factory_ID=sect.Factory_ID
	left join
	SmartBooks_Department dept
	on team.DepartmentCode=dept.DepartmentCode and team.Factory_ID=dept.Factory_ID
	left join
	HR_Factory f
	on team.Factory_ID=f.Factory_ID
	where (case when @Fact is null or @Fact='' then '' else team.Factory_ID end)=isnull(@Fact,'')
		and (case when @Dept is null or @Dept='' then '' else team.DepartmentCode end)=isnull(@Dept,'')
		and (case when @Sect is null or @Sect='' then '' else team.SectionCode end)=isnull(@Sect,'')
)




GO
