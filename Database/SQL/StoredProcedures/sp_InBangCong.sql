CREATE PROCEDURE [dbo].[sp_InBangCong]
	-- Add the parameters for the stored procedure here
	--exec [dbo].[sp_BangCong] '2019-6-1','2019-6-15','12','VN'
	@fromdate datetime,
	@todate datetime,
	@LAN nvarchar(50)='VN',
	@ListOfKey nvarchar(max)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @tabDate table(Ngay datetime)
	declare @dtnext datetime,@AccessTime time,@ShiftName nvarchar(50),@Reason nvarchar(50),@Remark nvarchar(max),@RealTimeIn time(0),@RealTimeOut time(0),@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan int
	select @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan=[Value] from [dbo].[SetUp] where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
	set @dtnext=@fromdate
	while @dtnext<=@todate begin
		insert into @tabDate (Ngay) values(@dtnext)
		set @dtnext=@dtnext+1
	end
	select empl.DepartmentName as DepartmentCode,empl.DepartmentName+(case when empl.TeamName is null then '' else ' | '+empl.TeamName end) as TeamCode,empl.Employee_ID
			,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.Employee_Status,empl.ComStartedDate,empl.TernimationDate
			,CountDay.Shift1_2,CountDay.Shift2,CountDay.Shift3,wt1,wt2,wt9,wt3,wt5,wt4,wt6,wt7,wt8
			,LateIn_EarlyOut
			,Annual,LeaveNonPay,LeaveComPay
			,wt4_Alter as SunDay_Alter,wt6_Alter as SunNight_Alter
			
			from 
			[dbo].[udf_EmployeeFilter](@LAN,null,null,null,null,null,null,null,isnull(@todate,getdate())) empl
			left join
			(
				select tito.Employee_ID
					,Count(case when ShiftName like '%Shift0' or ShiftName like '%Shift1' then 1 else null end) as Shift1_2
					,Count(case when ShiftName like '%Shift2' then 1 else null end) as Shift2
					,Count(case when ShiftName like '%Shift3' then 1 else null end) as Shift3
					,sum(isnull(tito.LateIn,0))+sum(isnull(tito.EarlyOut,0)) as LateIn_EarlyOut
				from
				HR_TimeIn_TimeOut tito
				left join
				HR_EmployeeRegisMaternityLeave erml
				on tito.Employee_ID=erml.Employee_ID and tito.OT_date between erml.Fromdate and erml.ToDate
				left join
				SmartBooks_HolidaysPlan hp
				on tito.OT_Date=hp.H_date
				where erml.Employee_ID is null and tito.OT_date between @Fromdate and @ToDate and DATENAME(WEEKDAY,OT_date)<>'Sunday' and hp.H_date is null
				group by tito.Employee_ID
			) as CountDay
			on empl.Employee_ID=CountDay.Employee_ID
			left join
			(
				select Employee_ID,
				sum(case when d.MaCong='wt1' then wt else 0 end) as wt1,
				sum(case when d.MaCong='wt2' then wt else 0 end) as wt2,
				sum(case when d.MaCong='wt3' then wt else 0 end) as wt3,
				sum(case when d.MaCong='wt4' and InsertSource='Sun' then wt else 0 end) as wt4,
				sum(case when d.MaCong='wt4' and InsertSource='Sun-Alt' then wt else 0 end) as wt4_Alter,
				sum(case when d.MaCong='wt5' then wt else 0 end) as wt5,
				sum(case when d.MaCong='wt6' and InsertSource='Sun' then wt else 0 end) as wt6,
				sum(case when d.MaCong='wt6' and InsertSource='Sun-Alt' then wt else 0 end) as wt6_Alter,
				sum(case when d.MaCong='wt7' then wt else 0 end) as wt7,
				sum(case when d.MaCong='wt8' then wt else 0 end) as wt8,
				sum(case when d.MaCong='wt9' then wt else 0 end) as wt9,
				sum(case when d.MaCong='wt10' then wt else 0 end) as wt10,
				sum(case when d.MaCong='wt11' then wt else 0 end) as wt11,
				sum(case when d.MaCong='wt12' then wt else 0 end) as wt12
				from dbo.HR_WTDaily d
				where Ngay between @fromdate and @todate
				group by Employee_ID
			)wt
			on empl.Employee_ID=wt.Employee_ID
			left join
			(
				select Employee_ID
				,sum(case when lt.PhepNam=1 then (case when erml.LeaveType_ID='11' then [dbo].[udf_CountWorkingDay](case when fromdate>=@fromdate then fromdate else @fromdate end,case when ToDate>@todate then @todate else ToDate end)
														else [dbo].[udf_CountWorkingDay](case when fromdate>=@fromdate then fromdate else @fromdate end,case when ToDate>@todate then @todate else ToDate end)/2.0 end) else 0 end) as Annual
				,sum(case when lt.isLeave_nonPay=1 then [dbo].[udf_CountWorkingDay](case when fromdate>=@fromdate then fromdate else @fromdate end,case when ToDate>@todate then @todate else ToDate end) else 0 end) as LeaveNonPay
				,sum(case when lt.isLeave_ComPay=1 then (case when erml.LeaveType_ID not in ('31','32') then [dbo].[udf_CountWorkingDay](case when fromdate>=@fromdate then fromdate else @fromdate end,case when ToDate>@todate then @todate else ToDate end) 
																else [dbo].[udf_CountWorkingDay](case when fromdate>=@fromdate then fromdate else @fromdate end,case when ToDate>@todate then @todate else ToDate end)/2.0 end) else 0 end) as LeaveComPay
				from
				HR_EmployeeRegisMaternityLeave erml
				left join
				SmartBooks_LeaveType lt
				on erml.LeaveType_ID=lt.LeaveType_ID
				 where Fromdate<=@todate and ToDate>=@fromdate
				group by Employee_ID
			) erml
			on empl.Employee_ID=erml.Employee_ID
			where empl.Employee_ID in (select [Data] from Split(@ListOfKey,','))
END




GO
