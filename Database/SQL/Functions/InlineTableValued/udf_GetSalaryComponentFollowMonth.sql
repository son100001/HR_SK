-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--select * from udf_GetSalaryComponent('2016-04-12','2017-11-03',null,null)
CREATE FUNCTION [dbo].[udf_GetSalaryComponentFollowMonth]
(	
	-- Add the parameters for the function here
	@Year int,
	@Month int,
	@SalaryComponentCode nvarchar(50),
	@ViewAll bit
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT sc.ID,sc.Employee_ID,sc.SalaryComponent,sc.Amount,sc.Year_,sc.Month_,sc.Remark,sc.InsertDate,sc.UserName,
		scc.NameVN,
		empl.Employee_Firstname+(case when empl.Employee_LastName is null then '' else ' '+empl.Employee_LastName end) as FullName,empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID,empl.Employee_Status,empl.StartedDate,empl.TernimationDate
	from
	[dbo].[HR_SalaryComponentFollowMonth] sc
	left join
	[dbo].[SmartBooks_Employee] empl
	on sc.Employee_ID=empl.Employee_ID
	left join
	[dbo].[HR_SalaryComponentCategory] scc
	on sc.[SalaryComponent]=scc.[SalaryComponent]
	where (case when @SalaryComponentCode is null then '' else sc.SalaryComponent end)=isnull(@SalaryComponentCode,'')
		and (case when @ViewAll is null or @ViewAll=0 then @Year else 0 end)=(case when @ViewAll is null or @ViewAll=0 then Year_ else 0 end)
		and (case when @ViewAll is null or @ViewAll=0 then @Month else 0 end)=(case when @ViewAll is null or @ViewAll=0 then Month_ else 0 end)
)




GO
