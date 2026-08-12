

--select * from [dbo].[udf_BangTongPhepNamDNghKoPhep]('2025-1-1','2025-1-31',null,null,null,null,null,null,'10502',null) 


create FUNCTION [dbo].[udf_BangTongPhepNamDNghKoPhep]
(
	-- Add the parameters for the function here
	
	@fromdate DATETIME,
	@todate DATETIME,
	@fact nvarchar(50),
	@dept nvarchar(50),
	@sect nvarchar(50),
	@team nvarchar(50),
	@pos nvarchar(50),
	@posc nvarchar(50),
	@emp nvarchar(50),
	@ListOfLeaveType_ID varchar(100)
)
RETURNS @rtnTongPhep  TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50)
	,TongPhepNamDaNghi FLOAT
	,TongHL FLOAT
    ,TongTS float
	,primary key ([Employee_ID])
)
AS
BEGIN
	
	DECLARE @NgayHienTai as datetime
	set @NgayHienTai=GETDATE()

	
	DECLARE @rtnTongPhepNamDaNgh TABLE (
					[Employee_ID] nvarchar(50)
					,[LeaveType_ID] nvarchar(50)
					,DateLeave DATETIME
					,HourLeave FLOAT
					,Remark_ varchar(50)
					--,MaEID nvarchar(50)
					,Ngay datetime
					,primary key ([Employee_ID],DateLeave)
					)

	insert into @rtnTongPhepNamDaNgh(Employee_ID,LeaveType_ID,HourLeave,DateLeave)
	SELECT
		empl.Employee_ID
		,CASE
			WHEN pheple.TypeOfLeave is not null then pheple.TypeOfLeave
			when phep.LeaveType_ID is not null then phep.LeaveType_ID
		END as LeaveType_ID
		,CASE
			WHEN pheple.Employee_ID is not null then 8
			when phep.Employee_ID is not null then case when phep.LeaveType_ID in (31,32) then 4 else 8 end
		end as HourLeave
		,ngay.Date_ as DateLeave	
	from
	[dbo].[udf_BangThoiGian](@fromdate,@todate) ngay
	left join
	SmartBooks_Employee empl
	on ngay.Date_>=empl.StartedDate and (empl.ternimationdate is null or empl.ternimationdate>ngay.Date_)
	left join	
	udf_BangPhep(@fromdate,@todate,@emp) phep
	on ngay.Date_ between phep.fromdate and phep.todate and phep.Employee_ID=empl.Employee_ID
	left join
	[dbo].[udf_DanhSachNhanVienDuocHuongNghiLe](@fromdate,@todate) PhepLe
	on ngay.Date_=pheple.[H_date] and PhepLe.Employee_ID=empl.Employee_ID
	where 
	(datename(weekday,ngay.Date_)<>'Sunday' or (datename(weekday,ngay.Date_)='Sunday' and phep.LeaveType_ID='53'))
	and isnull(empl.Nationality,'')<>'Non-Vietnamese'
	and (case when @Emp is null or @emp='' then '' else empl.Employee_ID end)=(case when @emp is null or @emp='' then '' else @emp end)
	

	INSERT into @rtnTongPhep
	SELECT
		Employee_ID
		,sum(case when dngh.LeaveType_ID in ('11','31','32') then HourLeave else 0 end)/8.0 as TongPhepNamDaNghi
		,SUM(case when lt.isLeave_ComPay=1 then HourLeave else 0 end)/8.0 as TongHL
		,SUM(CASE WHEN dngh.LeaveType_ID IN (24,25,48,49) then HourLeave else 0 end)/8.0 AS TongTS
	FROM @rtnTongPhepNamDaNgh dngh
	LEFT JOIN
    dbo.SmartBooks_LeaveType lt
	ON dngh.LeaveType_ID=lt.LeaveType_ID	
	group by Employee_ID
	RETURN
END
--select * from [dbo].[udf_DanhSachNhanVienDuocHuongNghiLe]('2022-01-01','2022-12-31') where Employee_ID=N'1072'
--select * from SmartBooks_HolidaysPlan

GO
