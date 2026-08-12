--select * from [udf_TraVeBangTongHopPhep]('2019-10-1','2019-10-31') where employee_id='S000087'
CREATE FUNCTION [dbo].[udf_TraVeBangTongHopPhep]
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),Annual float,LeaveNonPay float,LeaveComPay float, KH_TL float, NL float,KT float,CTCN float,NT float,primary key ([Employee_ID])
)
AS
BEGIN
	insert into @rtnTable
	select Employee_ID
	,sum(case when lt.PhepNam=1 then (case when erml.LeaveType_ID='11' then [dbo].[udf_CountWorkingDay](case when fromdate>=@fromdate then fromdate else @fromdate end,case when ToDate>@todate then @todate else ToDate end)
											else [dbo].[udf_CountWorkingDay](case when fromdate>=@fromdate then fromdate else @fromdate end,case when ToDate>@todate then @todate else ToDate end)/2.0 end) else 0 end) as Annual
	,sum(case when lt.isLeave_nonPay=1 then [dbo].[udf_CountWorkingDay](case when fromdate>=@fromdate then fromdate else @fromdate end,case when ToDate>@todate then @todate else ToDate end) else 0 end) as LeaveNonPay
	,sum(case when lt.isLeave_ComPay=1 then (case when erml.LeaveType_ID='50' then 1
													when erml.LeaveType_ID not in ('31','32') then [dbo].[udf_CountWorkingDay](case when fromdate>=@fromdate then fromdate else @fromdate end,case when ToDate>@todate then @todate else ToDate end) 
													else [dbo].[udf_CountWorkingDay](case when fromdate>=@fromdate then fromdate else @fromdate end,case when ToDate>@todate then @todate else ToDate end)/2.0 end) else 0 end) as LeaveComPay
	,sum(case when erml.LeaveType_ID in (12,33) then [dbo].[udf_CountWorkingDay](case when fromdate>=@fromdate then fromdate else @fromdate end,case when ToDate>@todate then @todate else ToDate end) else 0 end) as KH_TL
	,sum(case when erml.LeaveType_ID=50 then [dbo].[udf_CountWorkingDay](case when fromdate>=@fromdate then fromdate else @fromdate end,case when ToDate>@todate then @todate else ToDate end) else 0 end) as NL
	,sum(case when erml.LeaveType_ID=25 then [dbo].[udf_CountWorkingDay](case when fromdate>=@fromdate then fromdate else @fromdate end,case when ToDate>@todate then @todate else ToDate end) else 0 end) as KT
	,sum(case when erml.LeaveType_ID=52 then [dbo].[udf_CountWorkingDay](case when fromdate>=@fromdate then fromdate else @fromdate end,case when ToDate>@todate then @todate else ToDate end) else 0 end) as CTCN
	,sum(case when erml.LeaveType_ID=51 and datename(weekday,fromdate)<>'Sunday' then [dbo].[udf_CountWorkingDay](case when fromdate>=@fromdate then fromdate else @fromdate end,case when ToDate>@todate then @todate else ToDate end) else 0 end) as NT
	from
	(
		select Employee_ID,LeaveType_ID,Fromdate,ToDate from [dbo].[udf_BangPhep](@fromdate,@todate,null)
		union all
		select Employee_ID,typeofleave as LeaveType_ID,H_date as fromdate,H_date as todate from udf_DanhSachNhanVienDuocHuongNghiLe(@fromdate,@todate)
	) erml
	left join
	SmartBooks_LeaveType lt
	on erml.LeaveType_ID=lt.LeaveType_ID
		where Fromdate<=@todate and ToDate>=@fromdate
	group by Employee_ID

	-- Return the result of the function
	RETURN 

END




GO
