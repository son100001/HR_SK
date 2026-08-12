
CREATE FUNCTION [dbo].[udf_QuanLyPhepNamTest]
(	
	-- Add the parameters for the function here
	--select * from udf_QuanLyPhepNamTest(2022,'2022-11-01','VN',null,null,null,null,null,null,null)
	@year int,
	@todate datetime,
	@Lan nvarchar(50),
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
    [Employee_ID] nvarchar(50),PhepNamDuocHuong Float,PhepNamTon float,TongPhepNamDaNghi float,PhepNamDuocHuongDenHienTai_ChuaLamTron float,PhepNamDuocHuongDenHienTai float,PhepThamNien float, ThangThamNien float, PhepNamThamNienTinhDenCuoiNam float, PhepNamNNDHTinhDenCuoiNam float
		, jan float, feb float, mar float, apr float, may float, jun float, jul float, aug float, sep float, oct float, nov float, [dec] float--, primary key ([Employee_ID])
)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @NgayDauNam datetime, @NgayCuoiNam datetime, @NgayHienTai date, @NgayPhepNam int
	set @NgayDauNam=cast(@year as varchar)+'-1-1'
	set @NgayCuoiNam=DATEADD(year,1,@NgayDauNam)-1
	set @NgayHienTai=@todate
	select @NgayPhepNam =Value from HR_SetUpFollowDate where Group_='NghiPhepNam' and Code = 'PhepNam' and Fromdate<=@NgayHienTai and (Todate is null or Todate>=@NgayHienTai) order by Fromdate asc
	if @NgayHienTai>@NgayCuoiNam begin
		set @NgayHienTai=@NgayCuoiNam
	end
	-- Add the T-SQL statements to compute the return value here
	insert into @rtnTable
	select empl.Employee_ID
		,round(
			(isnull(f.AnnualLeaveDays,@NgayPhepNam)+empl.NamThamNien/5)
			/12.0
			*(
				pntt.jan + pntt.feb + pntt.mar + pntt.apr + pntt.may + pntt.jun + pntt.jul + pntt.aug + pntt.sep + pntt.oct + pntt.nov + pntt.[dec]
			)
		,0) as PhepNamDuocHuong
		,dvr.DaysRemain as PhepNamTon
		,isnull(pndanghi.TongPhepNamDaNghi,0) as TongPhepNamDaNghi
		,(isnull(f.AnnualLeaveDays,@NgayPhepNam)+empl.NamThamNien/5)
		/12
		*(
			(case when @NgayHienTai > cast(@year as varchar) + '-1-1' then pntt.jan else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-2-1' then pntt.feb else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-3-1' then pntt.mar else 0 end)
			+ (case when @NgayHienTai > cast(@year as varchar) + '-4-1' then pntt.apr else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-5-1' then pntt.may else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-6-1' then pntt.jun else 0 end)
			+ (case when @NgayHienTai > cast(@year as varchar) + '-7-1' then pntt.jul else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-8-1' then pntt.aug else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-9-1' then pntt.sep else 0 end)
			+ (case when @NgayHienTai > cast(@year as varchar) + '-10-1' then pntt.oct else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-11-1' then pntt.nov else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-12-1' then pntt.[dec] else 0 end)
		)
		as PhepNamDuocHuongDenHienTai_ChuaLamTron
		,round(
			(isnull(f.AnnualLeaveDays,@NgayPhepNam)+empl.NamThamNien/5)
			/12
			*(
				(case when @NgayHienTai > cast(@year as varchar) + '-1-1' then pntt.jan else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-2-1' then pntt.feb else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-3-1' then pntt.mar else 0 end)
				+ (case when @NgayHienTai > cast(@year as varchar) + '-4-1' then pntt.apr else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-5-1' then pntt.may else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-6-1' then pntt.jun else 0 end)
				+ (case when @NgayHienTai > cast(@year as varchar) + '-7-1' then pntt.jul else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-8-1' then pntt.aug else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-9-1' then pntt.sep else 0 end)
				+ (case when @NgayHienTai > cast(@year as varchar) + '-10-1' then pntt.oct else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-11-1' then pntt.nov else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-12-1' then pntt.[dec] else 0 end)
			)
		,0) as PhepNamDuocHuongDenHienTai
		,empl.NamThamNien/5 as PhepThamNien, empl.ThangThamNien, floor(empl.NamThamNien/5) as PhepNamThamNienTinhDenCuoiNam, dbo.udf_CompareGetMax (isnull(f.AnnualLeaveDays,@NgayPhepNam) - 12, 0) as PhepNamNNDHTinhDenCuoiNam
		, (isnull(f.AnnualLeaveDays,@NgayPhepNam)+empl.NamThamNien/5)/12.0*pntt.jan, (isnull(f.AnnualLeaveDays,@NgayPhepNam)+empl.NamThamNien/5)/12.0*pntt.feb, (isnull(f.AnnualLeaveDays,@NgayPhepNam)+empl.NamThamNien/5)/12.0*pntt.mar, (isnull(f.AnnualLeaveDays,@NgayPhepNam)+empl.NamThamNien/5)/12.0*pntt.apr
		, (isnull(f.AnnualLeaveDays,@NgayPhepNam)+empl.NamThamNien/5)/12.0*pntt.may, (isnull(f.AnnualLeaveDays,@NgayPhepNam)+empl.NamThamNien/5)/12.0*pntt.jun, (isnull(f.AnnualLeaveDays,@NgayPhepNam)+empl.NamThamNien/5)/12.0*pntt.jul, (isnull(f.AnnualLeaveDays,@NgayPhepNam)+empl.NamThamNien/5)/12.0*pntt.aug
		, (isnull(f.AnnualLeaveDays,@NgayPhepNam)+empl.NamThamNien/5)/12.0*pntt.sep, (isnull(f.AnnualLeaveDays,@NgayPhepNam)+empl.NamThamNien/5)/12.0*pntt.oct, (isnull(f.AnnualLeaveDays,@NgayPhepNam)+empl.NamThamNien/5)/12.0*pntt.nov, (isnull(f.AnnualLeaveDays,@NgayPhepNam)+empl.NamThamNien/5)/12.0*pntt.[dec]
	from
	(select datediff(day,StartedDate,isnull(empl.TernimationDate,@NgayCuoiNam))/365 as NamThamNien,datediff(MONTH,StartedDate,isnull(empl.TernimationDate,@NgayCuoiNam)) as ThangThamNien
	,(datediff(day,StartedDate,@NgayCuoiNam)/365-datediff(day,StartedDate,@NgayCuoiNam)/365)/12.0 as ThangThamNienLe
	,* from [dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@ngaycuoinam,getdate())) empl) empl
	left join
	(
		select Employee_ID,sum(HourLeave)/8.0 as TongPhepNamDaNghi
		from [dbo].[udf_BangPhepTheoNgay](2,@NgayDauNam,@NgayCuoiNam,@fact,@dept,@sect,@team,@pos,@posc,@emp,'11,31,32') group by Employee_ID
	)pndanghi
	on empl.Employee_ID=pndanghi.Employee_ID
	left join
	udf_PhepNamTheoThang (@year,@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,GetDate()) pntt
	on empl.Employee_ID = pntt.Employee_ID
	--left join
	--HR_EmployeeRegisMaternityLeave ermlSending
	--on empl.Employee_ID=ermlSending.Employee_ID and ermlSending.LeaveType_ID='28' and ermlSending.Fromdate between @NgayDauNam and @NgayCuoiNam and min(ermlSending.Fromdate)
	left join
	HR_DayVacationRemain dvr
	on empl.Employee_ID=dvr.Employee_ID 
	left join
	HR_Factory f
	on empl.factory_id=f.factory_id
	where empl.StartedDate<=@NgayCuoiNam and (empl.TernimationDate is null or empl.TernimationDate>@NgayDauNam)


	-- Return the result of the function
	RETURN

END


GO
