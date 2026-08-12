-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BangViPhamKyLuat]

--exec [dbo].[sp_BangViPhamKyLuat] '1900-1-1','2020-04-07',1,'VN',N'X03,X05,TV03,TV05',N'',N'',N'',N'','',N'0011'
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Emp nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @TypeOfReport=1 begin--Danh sách lập biên bản vi phạm kỷ luật theo ngày lập biên bản
		select empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,dcp.*
		from
		--(
		--	select * from HR_Discipline where DisciplineBegin between @fromdate and @todate
		--	union
		--	select -1 as ID,employee_id, N'Nghỉ không phép' as BehaviorCode, 'NghiKhongPhep' as DisciplineCode, fromdate as DisciplineBegin, todate as DisciplineEnd, fromdate as ViolationDate, Fromdate as salaryIncreaseDate,null as ProcAsign, Remark, InsertDate, UserName from HR_EmployeeRegisMaternityLeave where leaveType_ID=14 and Fromdate<=@todate and todate>=@fromdate
		--)as dcp
		HR_Discipline dcp
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
		on dcp.Employee_ID=empl.Employee_ID
		left join
		HR_Behavior b
		on dcp.BehaviorCode=b.BehaviorCode
		where empl.Employee_ID is not null and (case when @Emp is null or @Emp='' then '' else dcp.Employee_ID end)=ISNULL(@Emp,'')
			AND dcp.DisciplineBegin between @fromdate and @todate
	end else if @TypeOfReport=2 begin--Danh sách lập biên bản theo ngày kết thúc kỷ luật
		select empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,dcp.*
		from
		--(
		--	select * from HR_Discipline where DisciplineBegin between @fromdate and @todate
		--	union
		--	select -1 as ID,employee_id, N'Nghỉ không phép' as BehaviorCode, 'NghiKhongPhep' as DisciplineCode, fromdate as DisciplineBegin, todate as DisciplineEnd, fromdate as ViolationDate, Fromdate as salaryIncreaseDate,null as ProcAsign, Remark, InsertDate, UserName from HR_EmployeeRegisMaternityLeave where leaveType_ID=14 and Fromdate<=@todate and todate>=@fromdate
		--)as dcp
		HR_Discipline dcp
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
		on dcp.Employee_ID=empl.Employee_ID
		left join
		HR_Behavior b
		on dcp.BehaviorCode=b.BehaviorCode
		where empl.Employee_ID is not null and dcp.DisciplineBegin between @fromdate and @todate
	end else if @TypeOfReport=3 begin-- danh sách đang trong thời gian vi phạm
		select empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,dcp.*
		from
		--(
		--	select * from HR_Discipline where DisciplineBegin between @fromdate and @todate
		--	union
		--	select -1 as ID,employee_id, N'Nghỉ không phép' as BehaviorCode, 'NghiKhongPhep' as DisciplineCode, fromdate as DisciplineBegin, todate as DisciplineEnd, fromdate as ViolationDate, Fromdate as salaryIncreaseDate,null as ProcAsign, Remark, InsertDate, UserName from HR_EmployeeRegisMaternityLeave where leaveType_ID=14 and Fromdate<=@todate and todate>=@fromdate
		--)as dcp
		HR_Discipline dcp
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
		on dcp.Employee_ID=empl.Employee_ID
		left join
		HR_Behavior b
		on dcp.BehaviorCode=b.BehaviorCode
		where empl.Employee_ID is not null and dcp.DisciplineBegin between @fromdate and @todate
	end else if @TypeOfReport = 4 begin
		--exec [dbo].[sp_BangViPhamKyLuat] '2023-01-01','2023-08-31',4
		select dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName, empl.FactoryName, empl.DepartmentName,empl.TernimationDate,empl.StartedDate,empl.Employee_Status, bpdn.*, bpdn.KP45Ngay - bpdn.KP15Ngay as KPTu15Den45, bpdn.KP60Ngay - bpdn.KP30Ngay as KPTu30Den60--, dis.*
		from
		(
			select Employee_ID, sum(case when bpdn.DateLeave between dateadd(day,-15,@todate) and @todate then 1 else 0 end) as KP15Ngay, sum(case when bpdn.DateLeave between dateadd(day,-30,@todate) and @todate then 1 else 0 end) as KP30Ngay
					, sum(case when bpdn.DateLeave between dateadd(day,-45,@todate) and @todate then 1 else 0 end) as KP45Ngay, sum(case when bpdn.DateLeave between dateadd(day,-60,@todate) and @todate then 1 else 0 end) as KP60Ngay
					, sum(case when bpdn.DateLeave between dateadd(day,-365,@todate) and @todate then 1 else 0 end) KP365Ngay
			from udf_BangPhepTheoNgay(2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@Emp,null) bpdn
			where LeaveType_ID = 14 --and bpdn.Employee_ID = 'ydc392'
			group by Employee_ID
		) bpdn
		left join
		udf_EmployeeFilter (@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
		on bpdn.Employee_ID = empl.Employee_ID
		--left join
		--(
		--	select Employee_ID, sum(case when dis.ViolationDate between dateadd(day,-15,@todate) and @todate then 1 else 0 end) as KyLuat15Ngay, sum(case when dis.ViolationDate between dateadd(day,-30,@todate) and @todate then 1 else 0 end) as KyLuat30Ngay
		--			, sum(case when dis.ViolationDate between dateadd(day,-45,@todate) and @todate then 1 else 0 end) as KyLuat45Ngay, sum(case when dis.ViolationDate between dateadd(day,-60,@todate) and @todate then 1 else 0 end) as KyLuat60Ngay
		--			, sum(case when dis.ViolationDate between dateadd(day,-365,@todate) and @todate then 1 else 0 end) KyLuat365Ngay
		--	from
		--	HR_Discipline dis
		--	group by Employee_ID
		--) dis
		--on bpdn.Employee_ID = dis.Employee_ID
		where (/*KP30Ngay > 0 or KP365Ngay > 15 or KP45Ngay > 0 or */ KP365Ngay >= 10 or KP60Ngay >= 5) and empl.StartedDate <= @todate and isnull(empl.TernimationDate,@fromdate) >= @fromdate
	end
END




GO
