
create FUNCTION [dbo].[udf_BangCongKhongCanCuDuLieuQuetThe]
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_DanhSachNhanVienDuocHuongNghiLe]('2020-2-1','2020-2-14')
	--select * from [dbo].[udf_BangCongKhongCanCuDuLieuQuetThe]('2021-2-1','2021-2-28','Korean',null,null,null,null,null,null)
	@fromdate datetime,
	@todate datetime,
	@fact nvarchar(50),
	@dept nvarchar(50),
	@sect nvarchar(50),
	@team nvarchar(50),
	@pos nvarchar(50),
	@posc nvarchar(50),
	@emp nvarchar(50)
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),Ngay datetime,Cong float,primary key ([Employee_ID],Ngay)
)
AS
BEGIN
	insert into @rtnTable
	select
		empl.Employee_ID,tg.Date_,1
		
		from
		[dbo].[udf_EmployeeFilter]('VN',@fact,@dept,@sect,@team,@pos,@posc,null,@todate) empl
		left join
		[dbo].[udf_BangThoiGian](@fromdate,@todate) tg
		on empl.StartedDate<=tg.Date_ and (empl.TernimationDate is null or empl.TernimationDate>tg.Date_)
		left join
		HR_EmployeeRegisMaternityLeave erml
		on empl.Employee_ID=erml.Employee_ID and tg.Date_ between erml.Fromdate and erml.ToDate
		left join
		SmartBooks_LeaveType lt
		on erml.LeaveType_ID=lt.LeaveType_ID
		where DATENAME(dw,tg.Date_)<>'Sunday' and erml.Employee_ID is null

	RETURN

END



GO
