-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--select * from udf_GetSalaryComponentNewest('2017-07-2','2017-7-2') where Employee_ID='1002'
CREATE FUNCTION [dbo].[udf_GetSalaryComponentNewest]
(	
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT sc.ID,sc.Employee_ID,sc.SalaryComponent,sc.Amount,sc.Fromdate,sc.Todate,sc.Remark,sc.InsertDate,sc.UserName,sc.InsertSource,
		empl.Employee_Firstname+(case when empl.Employee_LastName is null then '' else ' '+empl.Employee_LastName end) as FullName,empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID,empl.Employee_Status,empl.StartedDate,empl.TernimationDate
		,scc.NameEN,scc.NameVN,scc.NameKR
	from
	(
		select sc.* from
		(
			select Employee_ID,max([Fromdate]) as Fromdate,SalaryComponent from [dbo].[HR_SalaryComponent] where [Fromdate]<=@todate group by Employee_ID, SalaryComponent
		)scmax
		left join
		[dbo].[HR_SalaryComponent] sc
		on scmax.Employee_ID=sc.Employee_ID and scmax.Fromdate=sc.Fromdate and scmax.SalaryComponent=sc.SalaryComponent
	)sc
	left join
	[dbo].[SmartBooks_Employee] empl
	on sc.Employee_ID=empl.Employee_ID
	left join
	HR_SalaryComponentCategory scc
	on sc.SalaryComponent=scc.SalaryComponent
	where empl.StartedDate<=@todate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)
)




GO
