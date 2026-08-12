CREATE FUNCTION [dbo].[udf_BangPhepTheoNgayTinhPhep]
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_DanhSachNhanVienDuocHuongNghiLe]('2022-05-20','2022-05-20')
	--select * from [dbo].[udf_BangPhepTheoNgayTinhPhep](2,'2025-11-01','2025-11-30',null,null,null,null,null,null,null,null) where Employee_ID = 'C16734'
	@TypeOfReport int,--2 theo công, 1-- theo giờ quẹt vào
	@fromdate datetime,
	@todate datetime,
	@fact nvarchar(50),
	@dept nvarchar(50),
	@sect nvarchar(50),
	@team nvarchar(50),
	@pos nvarchar(50),
	@posc nvarchar(50),
	@emp nvarchar(50),
	@ListOfLeaveType_ID varchar(100)
)
RETURNS  @rtnBangPhepTheoNgayTinhPhep TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),[LeaveType_ID] nvarchar(50),DateLeave datetime,HourLeave float,Remark_ varchar(50),primary key ([Employee_ID],DateLeave)
)
AS
BEGIN
	declare @NgayHienTai as datetime, @Thu7DuocNghi datetime
	--select @Thu7DuocNghi = [Value] from Setup where FunctionID = 'Thu7DuocNghi' and ID = 'T7DN'
	set @NgayHienTai=DATEFROMPARTS(year(getdate()),month(getdate()),day(getdate()))
	declare @SoNgaySauKhiMangBauDuocHuongThaiSan int
	select @SoNgaySauKhiMangBauDuocHuongThaiSan=[Value] from [dbo].[SetUp] where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
	declare @tabCong table(Employee_ID nvarchar(50), Ngay datetime primary key (Employee_ID, Ngay))
	if @TypeOfReport=1 begin
		insert into @tabCong
		select Employee_ID,AccessDate from udf_TinhCong_QuetVao(@fromdate,@todate,@SoNgaySauKhiMangBauDuocHuongThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@emp)
	end else begin
		insert into @tabCong
		select distinct Employee_ID,Ngay from HR_WTDaily where ngay between @fromdate and @todate
	end

	Declare @tabNghiMacDinh table (Employee_ID nvarchar(50), Ngay datetime, LeaveType_ID nvarchar(5), primary key(Employee_ID, Ngay))
	insert into @tabNghiMacDinh
	select dkc.Employee_ID, dkc.LeaveDate, '53'
	from
	(
		select dkc.Employee_ID, dkc.ToDate as LeaveDate, ROW_NUMBER () over (Partition by dkc.Employee_ID, Todate order by dkc.Employee_ID, Todate) as rn
		from
		HR_RoundShift dkc
		left join
		udf_EmployeeFilter ('VN',@fact,@dept,@sect,@team,@pos,@posc,@emp,@todate) empl
		on dkc.Employee_ID = empl.Employee_ID
		where dkc.ShiftName in ('83-Shift3','93-Shift3','70-Shift0','80-Shift0') and dkc.ToDate between @fromdate and @todate and empl.DepartmentCode like N'Production_Soi%'
				and empl.Employee_ID is not null
	) dkc 
	where rn = 1

	insert into @tabNghiMacDinh
	select dkc.Employee_ID, LeaveDate, '53'
	from
	(
		select dkc.Employee_ID, dkc.ToDate - 1 as LeaveDate, ROW_NUMBER () over (Partition by dkc.Employee_ID, Todate order by dkc.Employee_ID, Todate) as rn
		from
		HR_RoundShift dkc
		left join
		udf_EmployeeFilter ('VN',@fact,@dept,@sect,@team,@pos,@posc,@emp,@todate) empl
		on dkc.Employee_ID = empl.Employee_ID
		where dkc.ShiftName in ('93-Shift3','80-Shift0') and dkc.ToDate between @fromdate and @todate and empl.DepartmentCode like N'Production_Soi%'
				and empl.Employee_ID is not null
	) dkc 
	where rn = 1 
	
	declare @tabTimeInTimeOut table(Employee_ID nvarchar(50), Ngay datetime, RealTimeIn datetime, RealTimeOut datetime, primary key (Employee_ID, Ngay))
	insert into @tabTimeInTimeOut
	select Employee_ID,OT_date,RealTimeIn,RealTimeOut from HR_TimeIn_TimeOut where OT_date between @fromdate and @todate and (TimeIn is null or [TimeOut] is null)

	insert into @rtnBangPhepTheoNgayTinhPhep (Employee_ID,LeaveType_ID,DateLeave,HourLeave)
	select empl.Employee_ID
	,(case
			when empl.ternimationdate is not null and empl.ternimationdate <= ngay.Date_ then '58'
			when phep.LeaveType_ID is not null then phep.LeaveType_ID
			when erl.LeaveType_ID is not null then erl.LeaveType_ID
			when nmd.LeaveType_ID is not null then nmd.LeaveType_ID
			when pheple.TypeOfLeave is not null then pheple.TypeOfLeave--#TRUNGLOGIC
			--when cong.Employee_ID is null and tito.RealTimeOut is not null and tito.RealTimeIn is null then '60' -- thiếu giờ vào
			--when cong.Employee_ID is null and tito.RealTimeIn is not null and tito.RealTimeOut is null then '61' -- thiếu giờ ra
			when ngay.Date_<=DATEFROMPARTS(year(getdate()),month(getdate()),day(getdate())) and cong.Employee_ID is null then '14.' --nghỉ không phép
		end) as LeaveType_ID
	,ngay.Date_ as DateLeave
	,case 
			when empl.ternimationdate is not null and empl.ternimationdate <= ngay.Date_ then 8
			when phep.Employee_ID is not null then case when phep.LeaveType_ID in (31,32) then 4 else 8 end
			when erl.Employee_ID is not null then erl.HourLeave
			when nmd.Employee_ID is not null then 8
			when pheple.Employee_ID is not null then 8--#TRUNGLOGIC
			--when cong.Employee_ID is null and tito.RealTimeOut is not null and tito.RealTimeIn is null then 8
			--when cong.Employee_ID is null and tito.RealTimeIn is not null and tito.RealTimeOut is null then 8
			when ngay.Date_<=DATEFROMPARTS(year(getdate()),month(getdate()),day(getdate())) and cong.Employee_ID is null then 8
	end as HourLeave
	from
	[dbo].[udf_BangThoiGian](@fromdate,@todate) ngay
	left join
	SmartBooks_Employee empl
	on ngay.Date_>=empl.StartedDate and (empl.ternimationdate is null or empl.ternimationdate between @fromdate and @todate)
	left join
	--[dbo].[udf_TraVeBangTransfer_Horizontal](@todate,@emp)tf
	--on empl.Employee_ID=tf.Employee_ID
	--left join
	udf_BangPhep(@fromdate,@todate,@emp) phep
	on ngay.Date_ between phep.fromdate and phep.todate and phep.Employee_ID=empl.Employee_ID
	left join
	[dbo].[udf_DanhSachNhanVienDuocHuongNghiLe](@fromdate,@todate) PhepLe
	on ngay.Date_=pheple.[H_date] and PhepLe.Employee_ID=empl.Employee_ID
	left join
	HR_DangKyPhepTheoGio erl
	on ngay.Date_=erl.DateLeave and erl.Employee_ID=empl.Employee_ID
	left join
	@tabCong cong
	on ngay.Date_=cong.Ngay and empl.Employee_ID=cong.Employee_ID
	left join
	[dbo].[HR_WorkingDaySpecial] wds
	on empl.Employee_ID=wds.Employee_ID and ngay.Date_=wds.WorkingDate
	--left join
	--@tabTimeInTimeOut tito
	--on empl.Employee_ID=tito.Employee_ID and ngay.Date_=tito.Ngay
	left join
	@tabNghiMacDinh nmd
	on empl.Employee_ID = nmd.Employee_ID and ngay.Date_ = nmd.Ngay
	where (empl.Employee_ID is not null and
	--(pheple.Employee_ID is not null
	--	or
	--	(phep.LeaveType_ID is not null and (datename(weekday,ngay.Date_)<>'Sunday' or datename(weekday,ngay.Date_)='Sunday' and phep.LeaveType_ID='53'))
	--	or erl.Employee_ID is not null
	--	) and (
	--			(case when isnull(@ListOfLeaveType_ID,'')='' then '' else phep.LeaveType_ID end) in (select data from [dbo].[Split](isnull(@ListOfLeaveType_ID,''),','))
	--			or (case when isnull(@ListOfLeaveType_ID,'')='' then '' else PhepLe.TypeOfLeave end) in (select data from [dbo].[Split](isnull(@ListOfLeaveType_ID,''),','))
	--			)
	/*PhepLe.Employee_ID is not null or*/ (nmd.Employee_ID is not null or 
											/*tito.Employee_ID is not null or*/ (((((datename(weekday,ngay.Date_)<>'Sunday' and isnull(wds.WorkingDayType,'')<>'Sun') or empl.DepartmentCode like N'Production_Soi%') or (datename(weekday,ngay.Date_)='Sunday' or empl.DepartmentCode like N'Production_Soi%' and isnull(wds.WorkingDayType,'')<>'')) or (datename(weekday,ngay.Date_)<>'Sunday' and isnull(wds.WorkingDayType,'')<>'Sun'))
	and
	(
		(case when isnull(@ListOfLeaveType_ID,'')='' then '' else phep.LeaveType_ID end) in (select data from [dbo].[Split](isnull(@ListOfLeaveType_ID,''),','))
		or (case when isnull(@ListOfLeaveType_ID,'')='' then '' else PhepLe.TypeOfLeave end) in (select data from [dbo].[Split](isnull(@ListOfLeaveType_ID,''),','))
		or (case when isnull(@ListOfLeaveType_ID,'')='' then '' else erl.TypeOfLeave end) in (select data from [dbo].[Split](isnull(@ListOfLeaveType_ID,''),','))
		or (case when isnull(@ListOfLeaveType_ID,'')='' then '' else (case when cong.Employee_ID is null and phep.LeaveType_ID is null and PhepLe.TypeOfLeave is null and erl.TypeOfLeave is null then '14' else '' end) end) in (select data from [dbo].[Split](isnull(@ListOfLeaveType_ID,''),','))
	)
	and isnull(empl.Nationality,'')<>'Non-Vietnamese'))
	and (case when @Emp is null or @emp='' then '' else empl.Employee_ID end)=(case when @emp is null or @emp='' then '' else @emp end)
	and (isnull(phep.LeaveType_ID,'')<>'' or isnull(PhepLe.TypeOfLeave,'')<>'' or isnull(erl.TypeOfLeave,'')<>'' or (case when cong.Employee_ID is null and phep.LeaveType_ID is null and PhepLe.TypeOfLeave is null and erl.TypeOfLeave is null then '14' else '' end)='14')
	and
		(case when pheple.TypeOfLeave is not null then pheple.TypeOfLeave--#TRUNGLOGIC
			when phep.LeaveType_ID is not null then phep.LeaveType_ID
			when erl.LeaveType_ID is not null then erl.LeaveType_ID
			when nmd.LeaveType_ID is not null then nmd.LeaveType_ID
			when ngay.Date_<=DATEFROMPARTS(year(getdate()),month(getdate()),day(getdate())) and cong.Employee_ID is null then '14' --nghỉ không phép
		end) is not null)
		 or nmd.Employee_ID is not null

		--xóa phép tự nhập như code 14
	delete @rtnBangPhepTheoNgayTinhPhep where DateLeave>@NgayHienTai and LeaveType_ID like '%.'
	-- Cập nhật nghỉ không phép tự động 14_ thành 14
	update @rtnBangPhepTheoNgayTinhPhep set LeaveType_ID=(case when LeaveType_ID like '%.' then replace(LeaveType_ID,'.','') else LeaveType_ID end),Remark_=LeaveType_ID
	-- Return the result of the function
	
	--Đặc thù Shinsung sợi 9h
	update bptntp
	set bptntp.HourLeave = case when bptntp.HourLeave = 4 then 4.5 when bptntp.HourLeave = 8 then 9 else bptntp.HourLeave/8*9 end
	from
	@rtnBangPhepTheoNgayTinhPhep bptntp
	left join
	udf_EmployeeFilter ('VN',null,null,null,null,null,null,@emp,GETDATE()) emp
	on bptntp.Employee_ID = emp.Employee_ID
	where emp.DepartmentCode like N'Production_Soi%'

	delete @rtnBangPhepTheoNgayTinhPhep
	where Employee_ID in (select Employee_ID from udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,@todate) where DepartmentCode not like N'Production_Soi%')
			and datename(weekday,DateLeave) = 'Sunday' and LeaveType_ID = 14


	RETURN

END



GO
