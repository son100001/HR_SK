
CREATE FUNCTION [dbo].[udf_DemSoNgayKhongDuocTinhLuong] 
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),SoNgayKhongDuocTinhLuong float primary key ([Employee_ID])
)
AS
BEGIN
	-- Declare the return variable here
	--DECLARE <@ResultVar, sysname, @Result> <Function_Data_Type, ,int>

	-- Add the T-SQL statements to compute the return value here
	insert into @rtnTable([Employee_ID],SoNgayKhongDuocTinhLuong)
	select empl.Employee_ID
	,sum((case when (hp.H_date is null or (erml.LeaveType_ID=28 and hp.H_date between erml.Fromdate and erml.ToDate))
					and DATENAME(WEEKDAY,tg.Date_)<>'Sunday' and wt.Employee_ID is null and isnull(lt.isLeave_ComPay,0)=0 then 1 else 0 end))
	from
	[dbo].[udf_BangThoiGian](@fromdate,@todate) tg
	left join
	SmartBooks_Employee empl
	on empl.ComStartedDate<=@todate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)
	left join
	udf_BangPhep(@fromdate,@todate,null) erml
	on empl.Employee_ID=erml.Employee_ID and tg.Date_ between erml.Fromdate and erml.ToDate
	left join
	(select distinct Employee_ID,Ngay from HR_WTDaily where ngay between @fromdate and @todate) wt
	on empl.Employee_ID=wt.Employee_ID and tg.Date_=wt.Ngay
	left join
	SmartBooks_HolidaysPlan hp
	on tg.Date_=hp.H_date and hp.H_date>=empl.ComStartedDate and (empl.TernimationDate is null or hp.H_date<empl.TernimationDate)
	left join
	SmartBooks_LeaveType lt
	on erml.LeaveType_ID=lt.LeaveType_ID
	--where empl.Employee_ID='19001000'
	group by empl.Employee_ID

	-- Return the result of the function
	RETURN 
END



GO
