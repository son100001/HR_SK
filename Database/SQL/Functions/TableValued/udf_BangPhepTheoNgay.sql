
CREATE FUNCTION [dbo].[udf_BangPhepTheoNgay]
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_DanhSachNhanVienDuocHuongNghiLe]('2020-2-1','2020-2-14')
	--select * from [dbo].[udf_BangPhepTheoNgay](2,'2023-01-1','2023-11-30',null,null,null,null,null,null,null,'11,31,32') where Employee_ID = 'WS000284'
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
RETURNS  @rtnBangPhepTheoNgay TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),[LeaveType_ID] nvarchar(50),DateLeave datetime,HourLeave float, Remark_ nvarchar(50),primary key ([Employee_ID],DateLeave)
)
AS
BEGIN
	Insert @rtnBangPhepTheoNgay(Employee_ID, LeaveType_ID, DateLeave, HourLeave, Remark_)
	Select Employee_ID, LeaveType_ID, DateLeave, HourLeave, Remark
	from
	HR_BangPhepDaNghi bpdn
	where bpdn.DateLeave between @fromdate and @todate 
			and (case when @ListOfLeaveType_ID is null then '' else bpdn.LeaveType_ID end) in (select Data from dbo.Split(isnull(@ListOfLeaveType_ID,''),','))
	-- Return the result of the function

	RETURN

END



GO
