
CREATE PROCEDURE [dbo].[sp_TongHopBangViPhamKyLuat]
	-- Add the parameters for the stored procedure here
	@year int,
	@TypeOfReport int=1,
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @NgayDauNam datetime,@NgayCuoiNam datetime, @b1 datetime, @e1 datetime, @b2 datetime, @e2 datetime, @b3 datetime, @e3 datetime, @b4 datetime, @e4 datetime, @b5 datetime, @e5 datetime, @b6 datetime, @e6 datetime
	,@b7 datetime, @e7 datetime, @b8 datetime, @e8 datetime, @b9 datetime, @e9 datetime, @b10 datetime, @e10 datetime, @b11 datetime, @e11 datetime, @b12 datetime, @e12 datetime
	if @TypeOfReport=1 begin
		set @b1=DATEFROMPARTS(@year,1,1) set @e1=dateadd(month,1,@b1)-1
		set @b2=DATEFROMPARTS(@year,2,1) set @e2=dateadd(month,1,@b2)-1
		set @b3=DATEFROMPARTS(@year,3,1) set @e3=dateadd(month,1,@b3)-1
		set @b4=DATEFROMPARTS(@year,4,1) set @e4=dateadd(month,1,@b4)-1
		set @b5=DATEFROMPARTS(@year,5,1) set @e5=dateadd(month,1,@b5)-1
		set @b6=DATEFROMPARTS(@year,6,1) set @e6=dateadd(month,1,@b6)-1
		set @b7=DATEFROMPARTS(@year,7,1) set @e7=dateadd(month,1,@b7)-1
		set @b8=DATEFROMPARTS(@year,8,1) set @e8=dateadd(month,1,@b8)-1
		set @b9=DATEFROMPARTS(@year,9,1) set @e9=dateadd(month,1,@b9)-1
		set @b10=DATEFROMPARTS(@year,10,1) set @e10=dateadd(month,1,@b10)-1
		set @b11=DATEFROMPARTS(@year,11,1) set @e11=dateadd(month,1,@b11)-1
		set @b12=DATEFROMPARTS(@year,12,1) set @e12=dateadd(month,1,@b12)-1
		set @NgayDauNam=DATEFROMPARTS(@year,1,1)
		set @NgayCuoiNam=dateadd(year,1,@NgayDauNam)-1
	
		select empl.Employee_ID,empl.SectionName,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
				,empl.StartedDate,empl.TernimationDate,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12 from
		(
			select empl.Employee_ID
			,sum(case when datepart(month,d.DisciplineBegin)=1 then 1 else 0 end)
			+sum(case when erml.ToDate>=@b1 and erml.Fromdate<=@e1 then [dbo].[udf_CountWorkingDay](case when erml.fromdate<@b1 then @b1 else erml.fromdate end,case when erml.todate>@e1 then @e1 else erml.ToDate end) else 0 end)
			as T1
			,sum(case when datepart(month,d.DisciplineBegin)=2 then 1 else 0 end)
			+sum(case when erml.ToDate>=@b2 and erml.Fromdate<=@e2 then [dbo].[udf_CountWorkingDay](case when erml.fromdate<@b2 then @b2 else erml.fromdate end,case when erml.todate>@e2 then @e2 else erml.ToDate end) else 0 end)
			as T2
			,sum(case when datepart(month,d.DisciplineBegin)=3 then 1 else 0 end)
			+sum(case when erml.ToDate>=@b3 and erml.Fromdate<=@e3 then [dbo].[udf_CountWorkingDay](case when erml.fromdate<@b3 then @b3 else erml.fromdate end,case when erml.todate>@e3 then @e3 else erml.ToDate end) else 0 end)
			as T3
			,sum(case when datepart(month,d.DisciplineBegin)=4 then 1 else 0 end)
			+sum(case when erml.ToDate>=@b4 and erml.Fromdate<=@e4 then [dbo].[udf_CountWorkingDay](case when erml.fromdate<@b4 then @b4 else erml.fromdate end,case when erml.todate>@e4 then @e4 else erml.ToDate end) else 0 end)
			as T4
			,sum(case when datepart(month,d.DisciplineBegin)=5 then 1 else 0 end)
			+sum(case when erml.ToDate>=@b5 and erml.Fromdate<=@e5 then [dbo].[udf_CountWorkingDay](case when erml.fromdate<@b5 then @b5 else erml.fromdate end,case when erml.todate>@e5 then @e5 else erml.ToDate end) else 0 end)
			as T5
			,sum(case when datepart(month,d.DisciplineBegin)=6 then 1 else 0 end)
			+sum(case when erml.ToDate>=@b6 and erml.Fromdate<=@e6 then [dbo].[udf_CountWorkingDay](case when erml.fromdate<@b6 then @b6 else erml.fromdate end,case when erml.todate>@e6 then @e6 else erml.ToDate end) else 0 end)
			as T6
			,sum(case when datepart(month,d.DisciplineBegin)=7 then 1 else 0 end)
			+sum(case when erml.ToDate>=@b7 and erml.Fromdate<=@e7 then [dbo].[udf_CountWorkingDay](case when erml.fromdate<@b7 then @b7 else erml.fromdate end,case when erml.todate>@e7 then @e7 else erml.ToDate end) else 0 end)
			as T7
			,sum(case when datepart(month,d.DisciplineBegin)=8 then 1 else 0 end)
			+sum(case when erml.ToDate>=@b8 and erml.Fromdate<=@e8 then [dbo].[udf_CountWorkingDay](case when erml.fromdate<@b8 then @b8 else erml.fromdate end,case when erml.todate>@e8 then @e8 else erml.ToDate end) else 0 end)
			as T8
			,sum(case when datepart(month,d.DisciplineBegin)=9 then 1 else 0 end)
			+sum(case when erml.ToDate>=@b9 and erml.Fromdate<=@e9 then [dbo].[udf_CountWorkingDay](case when erml.fromdate<@b9 then @b9 else erml.fromdate end,case when erml.todate>@e9 then @e9 else erml.ToDate end) else 0 end)
			as T9
			,sum(case when datepart(month,d.DisciplineBegin)=10 then 1 else 0 end)
			+sum(case when erml.ToDate>=@b10 and erml.Fromdate<=@e10 then [dbo].[udf_CountWorkingDay](case when erml.fromdate<@b10 then @b10 else erml.fromdate end,case when erml.todate>@e10 then @e10 else erml.ToDate end) else 0 end)
			as T10
			,sum(case when datepart(month,d.DisciplineBegin)=11 then 1 else 0 end)
			+sum(case when erml.ToDate>=@b11 and erml.Fromdate<=@e11 then [dbo].[udf_CountWorkingDay](case when erml.fromdate<@b11 then @b11 else erml.fromdate end,case when erml.todate>@e11 then @e11 else erml.ToDate end) else 0 end)
			as T11
			,sum(case when datepart(month,d.DisciplineBegin)=12 then 1 else 0 end)
			+sum(case when erml.ToDate>=@b12 and erml.Fromdate<=@e12 then [dbo].[udf_CountWorkingDay](case when erml.fromdate<@b12 then @b12 else erml.fromdate end,case when erml.todate>@e12 then @e12 else erml.ToDate end) else 0 end)
			as T12
			from
			smartbooks_employee empl
			left join
			HR_Discipline d
			on empl.Employee_ID=d.Employee_ID and d.DisciplineBegin between @NgayDauNam and @NgayCuoiNam
			left join
			HR_EmployeeRegisMaternityLeave erml
			on empl.Employee_ID=erml.Employee_ID and erml.Fromdate<=@NgayCuoiNam and erml.ToDate>=@NgayDauNam and erml.LeaveType_ID='14'
			where (d.Employee_ID is not null or erml.Employee_ID is not null) and empl.StartedDate<=@NgayCuoiNam and (empl.TernimationDate is null or empl.TernimationDate>@NgayDauNam)
			group by empl.Employee_ID
		) vpkl
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@NgayCuoiNam) empl
		on vpkl.Employee_ID=empl.Employee_ID
	end
END



GO
