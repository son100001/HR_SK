CREATE FUNCTION [dbo].[udf_DanhSachNhanVienDuocHuongNghiLe]
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_DanhSachNhanVienDuocHuongNghiLe]('2020-2-1','2020-2-14')
	--select * from [dbo].[udf_BangPhepTheoNgay]('2021-5-1','2021-5-31',null,null,null,null,null,null,null,null) where hourleave is null
	@fromdate datetime,
	@todate datetime
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    Employee_ID nvarchar(50),[H_date] datetime,TypeOfLeave varchar(50),[Description] nvarchar(max),primary key ([Employee_ID],H_date)
)
AS
BEGIN
	insert into @rtnTable
	select  empl.Employee_ID,hp.[H_date],HP.TypeOfLeave,HP.[Description] from 
	SmartBooks_Employee empl
	left join
	SmartBooks_HolidaysPlan hp
	on empl.[ComStartedDate]<=hp.[H_date] and (empl.ternimationdate is null or empl.ternimationdate>hp.[H_date])
	left join
	[dbo].[HR_EmployeeRegisMaternityLeave] phepdadk
	on empl.Employee_ID=phepdadk.Employee_ID and hp.H_date between phepdadk.Fromdate and phepdadk.ToDate
	left join
	SmartBooks_LeaveType lt
	on phepdadk.LeaveType_ID=lt.LeaveType_ID
	left join
	[dbo].[HR_EmployeeRegisMaternityLeave] sending
	on empl.Employee_ID=sending.Employee_ID and hp.H_date>=sending.Fromdate and sending.LeaveType_ID='28'
	left join
	HR_MaxOvertime mot
	on empl.Employee_ID=mot.Employee_ID and hp.H_date=mot.NgayNghiBu
	--left join
	--HR_TimeIn_TimeOut tito
	--on hp.H_date=tito.OT_date and empl.Employee_ID=tito.Employee_ID
	left join
	HR_DanhSachDangKyDiLam dkdl
	on empl.Employee_ID=dkdl.Employee_ID and hp.[H_date]=dkdl.Ngay
	left join
	udf_TongHopCong (@fromdate,@todate,1,'admin') thc
	on empl.Employee_ID=thc.Employee_ID and isnull(thc.wt1,0) + isnull(thc.wt9,0) + isnull(thc.wt2,0) > 0
	where hp.[H_date] between @FromDate and @ToDate
		and (phepdadk.LeaveType_ID is null or isnull(lt.LongTermLeaving,0)=0)--phepdadk.LeaveType_ID not in ('24','26','15','51'))
		and sending.Employee_ID is null
		and (
				hp.TypeOfLeave='50'
				or (phepdadk.LeaveType_ID is null and mot.Employee_ID is null and hp.TypeOfLeave<>'50')
			)
		--and tito.Employee_ID is null-- or not(tito.shiftname='03-Shift3' and ot_date='2020-1-1'))
		and dkdl.Employee_ID is null and thc.Employee_ID is not null
	-- Return the result of the function
	RETURN

END



GO
