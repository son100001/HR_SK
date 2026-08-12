CREATE PROCEDURE [dbo].[sp_PaySlip]
	-- Add the parameters for the stored procedure here
	@Month int,
	@Year int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @NgayDauThang datetime,@NgayCuoiThang datetime
	set @NgayDauThang= cast(@Year as varchar)+'-'+cast(@Month as varchar)+'-1'
	set @NgayCuoiThang=DATEADD(month,1,@NgayDauThang)-1

	select 
	[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,
	empl.Employee_ID,
	empl.StartedDate,
	empl.TernimationDate,
	empl.ComStartedDate,
	empl.PositionCategory_ID,
	isnull(empl.DepartmentName,'') AS DepartmentCode,
	ISNULL(empl.SectionName,'') as SectionCode,
	ISNULL(empl.TeamName,'') as TeamCode,
	ISNULL(empl.PositionName,'') as Position_ID,
	empl.Employee_Status,
	empl.OfficialDate,
	empl.Sex,
	empl.MaritalStatus,
	empl.Nationality,
	empl.BirthDate,
	empl.BirthPlace,
	empl.ID_number,
	empl.ID_date,
	empl.ID_place,
	empl.Address_Temporary,
	empl.Address_Permanent,
	empl.Tel,
	isnull(empl.Email,'') as Email,
	empl.BankAccount,
	empl.BankName,
	empl.Card_Code,
	empl.Card_No,
	empl.ChucDanh,
	isnull(empl.MaSoThue,'') as MaSoThue,
	'' as LabourContract_No
		,ss.*
		,isnull(phepnam_danghi.tongphepdanghi,0) as tongphepdanghi
		from
		[dbo].[udf_EmployeeFilter]('VN',null,null,null,null,null,null,null,@NgayCuoiThang) empl
		left join
		SmartBooks_Salary ss
		on empl.Employee_ID=ss.Employee_ID
		left join
		(
			select employee_id,	sum(HourLeave/8.0) as tongphepdanghi
			from HR_EmpRegisLeave
			where (LeaveType_ID=11 or LeaveType_ID=31 or LeaveType_ID=32)
			and DateLeave between DATEFROMPARTS(@year,1,1) and DATEADD(day,-1, DATEADD(MONTH,1, DATEFROMPARTS(@year,@month,1)))
			group by employee_id
		)as phepnam_danghi on phepnam_danghi.employee_id COLLATE DATABASE_DEFAULT= empl.Employee_ID


		where ss.Salary_Month = @month and ss.Salary_Year = @year
		and empl.Employee_ID not in (
			select Employee_ID from SmartBooks_Salary_Off where Salary_Month = @month and Salary_Year = @year
		)
	
END




GO
