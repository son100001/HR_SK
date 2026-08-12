-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_LayHDLD]
	-- Add the parameters for the stored procedure here
	@fromdatePara datetime,
	@todatePara datetime,
	@TypeOfReport int, --1 DU TINH KY MOI, 2 DU TINH HET HAN
	@TypeOfContract nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		select ct.Employee_ID,empl.Employee_Firstname+(case when empl.Employee_LastName is null then '' else ' '+empl.Employee_LastName end) as FullName,
			empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID,empl.StartedDate,empl.BirthDate,empl.TernimationDate,empl.Employee_Status,empl.ProbationDate,
			ct.CL_StartDate,ct.CL_ExpiredDate,ct.[Type],ct.Employee_ID+ct.[Type]+CONVERT (nvarchar(8),ct.CL_StartDate,112) as Contract_ID,ctl.SalaryBasic,ctl.InsuranceSalary,cast(null as datetime) as InsertDate,cast(null as nvarchar(50)) as UserName,cast(null as datetime) as CL_RegisterDate,cast(null as nvarchar(50)) as CL_FatherID,cast(null as float) as Allowance1,cast(null as float) as Allowance2,cast(null as float) as Allowance3,cast(null as float) as Allowance4,cast(null as float) as Allowance5,cast(null as float) as Allowance5,cast(null as float) as Allowance6,cast(null as float) as Allowance7,cast(null as float) as Allowance8,cast(null as float) as Allowance9,cast(null as float) as Allowance10,cast(null as float) as Allowance11,cast(null as float) as Allowance12,cast(null as float) as Allowance13,cast(null as float) as Allowance14,cast(null as float) as Allowance15,cast(null as nvarchar(max)) as CL_Remark,cast(null as bit) as [status],cast(null as int)as CL_ID,
			erml.[Type] as TypeOfLeave,erml.Fromdate as FromdateLeave,(case when erml.ToDate is null then erml.NgayDuKienQuayLai else erml.ToDate end) as ToDateLeave
		from
		udf_DanhSachDeXuatKyHD(@fromdatePara,@todatePara) ct
		left join
		SmartBooks_Employee empl
		on ct.Employee_ID=empl.Employee_ID
		left join
		(select * from [dbo].[HR_EmployeeRegisMaternityLeave] where fromtime is null and totime is null) erml
		on ct.Employee_ID COLLATE DATABASE_DEFAULT=erml.Employee_ID and ct.CL_StartDate between erml.Fromdate and (case when erml.ToDate is null then erml.NgayDuKienQuayLai else erml.ToDate end)
		left join
		SmartBooks_ContractList ctl
		on ct.Employee_ID=ctl.Employee_ID and ct.[Type]=ctl.[Type]
		
		where (case when @TypeOfReport=1 then ct.CL_StartDate else ct.CL_ExpiredDate end) between @fromdatePara and @todatePara
			and @TypeOfContract=(case when @TypeOfContract=N'' then N'' else ct.[Type] end)
			and ctl.Employee_ID is null
		order by departmentcode, sectioncode, teamcode, StartedDate
END




GO
