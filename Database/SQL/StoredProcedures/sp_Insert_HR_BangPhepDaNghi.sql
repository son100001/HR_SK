
CREATE proc [dbo].[sp_Insert_HR_BangPhepDaNghi]
@fromdate datetime,
@todate datetime,
@fact nvarchar(50) = null,
@dept nvarchar(50) = null,
@sect nvarchar(50) = null,
@team nvarchar(50) = null,
@pos nvarchar(50) = null,
@posc nvarchar(50) = null,
@emp nvarchar(50) = null
as
begin
	--exec sp_Insert_HR_BangPhepDaNghi '2025-08-26','2025-08-26',null,null,null,null,null,null,N'C15521'
	Declare @ThongBao nvarchar(50) = 'ThanhCong'
	Delete HR_BangPhepDaNghi 
	where DateLeave between @fromdate and @todate and (case when @Emp is null or @emp='' then '' else Employee_ID end)=(case when @emp is null or @emp='' then '' else @emp end) --and LeaveType_ID = 32

	Insert into HR_BangPhepDaNghi (Employee_ID, LeaveType_ID, DateLeave, HourLeave, Remark)
	select Employee_ID, LeaveType_ID, DateLeave, isnull(HourLeave,0), Remark_
	from
	[dbo].[udf_BangPhepTheoNgayTinhPhep](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp,null)
	select @ThongBao as ThongBao
end 
GO
