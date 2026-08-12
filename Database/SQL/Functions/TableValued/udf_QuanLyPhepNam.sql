
CREATE FUNCTION [dbo].[udf_QuanLyPhepNam]
(	
	-- Add the parameters for the function here
	--select * from udf_QuanLyPhepNam(2025,'2025-10-31','VN',null,null,null,null,null,null,'C4860')
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
RETURNS  @rtnQuanLyPhepNam TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),PhepNamDuocHuong Float,PhepNamTon float,TongPhepNamDaNghi float,PhepNamDuocHuongDenHienTai_ChuaLamTron float,PhepNamDuocHuongDenHienTai float,PhepThamNien float, ThangThamNien float, PhepNamThamNienTinhDenCuoiNam float, PhepNamNNDHTinhDenCuoiNam float, PhepNamConLai float, PhepNamDaNghiTrongThang float
		, jan float, feb float, mar float, apr float, may float, jun float, jul float, aug float, sep float, oct float, nov float, [dec] float, primary key ([Employee_ID])
)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @NgayDauNam datetime, @NgayCuoiNam datetime, @NgayHienTai date, @NgayPhepNam int, @NgayDauThang datetime, @NgayCuoiThang datetime
	set @NgayDauNam=cast(@year as varchar)+'-1-1'
	set @NgayCuoiNam=DATEADD(year,1,@NgayDauNam)-1
	set @NgayHienTai=@todate
	select @NgayPhepNam =Value from HR_SetUpFollowDate where Group_='NghiPhepNam' and Code = 'PhepNam' and Fromdate<=@NgayHienTai and (Todate is null or Todate>=@NgayHienTai) order by Fromdate asc
	if @NgayHienTai>@NgayCuoiNam begin
		set @NgayHienTai=@NgayCuoiNam
	end
	select @NgayCuoiThang = EOMONTH(@NgayHienTai)
	Select @NgayDauThang = dateadd(month,-1,@NgayCuoiThang+1)
	-- Add the T-SQL statements to compute the return value here
	insert into @rtnQuanLyPhepNam
	select empl.Employee_ID
		,Round((case when empl.OfficialDate > @NgayHienTai then 0 else round(
			(isnull(f.AnnualLeaveDays,@NgayPhepNam) + empl.NamThamNien/5)
			/12.0
			*(
				pntt.jan + pntt.feb + pntt.mar + pntt.apr + pntt.may + pntt.jun + pntt.jul + pntt.aug + pntt.sep + pntt.oct + pntt.nov + pntt.[dec]
			)
		,0) end),2) + Round((isnull(TongNgayLamDocHai,0)/365.0)*2/12,2) as PhepNamDuocHuong
		,Round(dvr.DaysRemain,2) as PhepNamTon
		,Round(isnull(pndanghi.TongPhepNamDaNghi,0),2) as TongPhepNamDaNghi
		,Round((case when empl.OfficialDate > @NgayHienTai then 0 else (isnull(f.AnnualLeaveDays,@NgayPhepNam) + dbo.udf_CompareGetMax(0, dbo.udf_CompareGetMax(empl.NamThamNien/5, (empl.NamThamNien-1)/5)))
		/12
		*(
			(case when @NgayHienTai > cast(@year as varchar) + '-1-1' then pntt.jan else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-2-1' then pntt.feb else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-3-1' then pntt.mar else 0 end)
			+ (case when @NgayHienTai > cast(@year as varchar) + '-4-1' then pntt.apr else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-5-1' then pntt.may else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-6-1' then pntt.jun else 0 end)
			+ (case when @NgayHienTai > cast(@year as varchar) + '-7-1' then pntt.jul else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-8-1' then pntt.aug else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-9-1' then pntt.sep else 0 end)
			+ (case when @NgayHienTai > cast(@year as varchar) + '-10-1' then pntt.oct else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-11-1' then pntt.nov else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-12-1' then pntt.[dec] else 0 end)
		) end),2)  + Round((isnull(TongNgayLamDocHai,0)/365.0)*2/12,2)
		as PhepNamDuocHuongDenHienTai_ChuaLamTron
		,Round((case when empl.OfficialDate > @NgayHienTai then 0 else round(
			(isnull(f.AnnualLeaveDays,@NgayPhepNam) + dbo.udf_CompareGetMax(0, dbo.udf_CompareGetMax(empl.NamThamNien/5, (empl.NamThamNien-1)/5)))
			/12
			*(
				(case when @NgayHienTai > cast(@year as varchar) + '-1-1' then pntt.jan else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-2-1' then pntt.feb else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-3-1' then pntt.mar else 0 end)
				+ (case when @NgayHienTai > cast(@year as varchar) + '-4-1' then pntt.apr else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-5-1' then pntt.may else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-6-1' then pntt.jun else 0 end)
				+ (case when @NgayHienTai > cast(@year as varchar) + '-7-1' then pntt.jul else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-8-1' then pntt.aug else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-9-1' then pntt.sep else 0 end)
				+ (case when @NgayHienTai > cast(@year as varchar) + '-10-1' then pntt.oct else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-11-1' then pntt.nov else 0 end) + (case when @NgayHienTai > cast(@year as varchar) + '-12-1' then pntt.[dec] else 0 end)
			)
		,0) end),2) + Round((isnull(TongNgayLamDocHai,0)/365.0)*2/12,2) as PhepNamDuocHuongDenHienTai
		, + dbo.udf_CompareGetMax(0, dbo.udf_CompareGetMax(empl.NamThamNien/5, (empl.NamThamNien-1)/5)) as PhepThamNien, empl.ThangThamNien, floor(empl.NamThamNien/5) as PhepNamThamNienTinhDenCuoiNam, dbo.udf_CompareGetMax (isnull(f.AnnualLeaveDays,@NgayPhepNam) - 12, 0) as PhepNamNNDHTinhDenCuoiNam
		, 0 as PhepNamConLai, pndanghiTT.TongPhepNamDaNghi as PhepNamDaNghiTrongThang
		, (isnull(f.AnnualLeaveDays,@NgayPhepNam))/12.0*pntt.jan, (isnull(f.AnnualLeaveDays,@NgayPhepNam))/12.0*pntt.feb, (isnull(f.AnnualLeaveDays,@NgayPhepNam))/12.0*pntt.mar, (isnull(f.AnnualLeaveDays,@NgayPhepNam))/12.0*pntt.apr
		, (isnull(f.AnnualLeaveDays,@NgayPhepNam))/12.0*pntt.may, (isnull(f.AnnualLeaveDays,@NgayPhepNam))/12.0*pntt.jun, (isnull(f.AnnualLeaveDays,@NgayPhepNam))/12.0*pntt.jul, (isnull(f.AnnualLeaveDays,@NgayPhepNam))/12.0*pntt.aug
		, (isnull(f.AnnualLeaveDays,@NgayPhepNam))/12.0*pntt.sep, (isnull(f.AnnualLeaveDays,@NgayPhepNam))/12.0*pntt.oct, (isnull(f.AnnualLeaveDays,@NgayPhepNam))/12.0*pntt.nov, (isnull(f.AnnualLeaveDays,@NgayPhepNam))/12.0*pntt.[dec]
	from
	(
		select datediff(day,StartedDate,isnull(empl.TernimationDate,@NgayCuoiNam))/365 as NamThamNien,datediff(MONTH,StartedDate,isnull(empl.TernimationDate,@NgayCuoiNam)) as ThangThamNien
				,(datediff(day,StartedDate,@NgayCuoiNam)/365-datediff(day,StartedDate,@NgayCuoiNam)/365)/12.0 as ThangThamNienLe
				,* 
		from [dbo].[udf_EmployeeFilter_Full](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@ngaycuoinam,getdate())) empl
	) empl
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
	on empl.Employee_ID=dvr.Employee_ID and dvr.[Year]=@year-1
	left join
	HR_Factory f
	on empl.factory_id=f.factory_id
	left join
	(
		select Employee_ID,sum(HourLeave)/8.0 as TongPhepNamDaNghi
		from [dbo].[udf_BangPhepTheoNgay](2,@NgayDauThang,@NgayCuoiThang,@fact,@dept,@sect,@team,@pos,@posc,@emp,'11,31,32') group by Employee_ID
	)pndanghiTT
	on empl.Employee_ID=pndanghiTT.Employee_ID
	left join
	(
		select Employee_ID, sum(datediff(day, case when Fromdate <= @NgayDauNam then @NgayDauNam else Fromdate end
									, case when isnull(Todate,@NgayHienTai) >= @NgayHienTai then @NgayHienTai else Todate end) + 1) as TongNgayLamDocHai
		from
		HR_TransferFloatType tft
		where isnull(Todate,@NgayHienTai) >= @NgayDauNam and Fromdate < @NgayHienTai
		group by Employee_ID
	) tft
	on empl.Employee_ID = tft.Employee_ID
	where empl.StartedDate<=@NgayCuoiNam and (empl.TernimationDate is null or empl.TernimationDate>@NgayDauNam)

	update @rtnQuanLyPhepNam
	set PhepNamConLai = PhepNamDuocHuongDenHienTai - TongPhepNamDaNghi + isnull(PhepNamTon,0)

	--update @rtnQuanLyPhepNam
	--set PhepNamDuocHuong = round(PhepNamDuocHuong,2)
	--	, PhepNamTon = round(PhepNamTon,2)
	--	, TongPhepNamDaNghi = round(TongPhepNamDaNghi,2)
	--	, PhepNamDuocHuongDenHienTai_ChuaLamTron = round(PhepNamDuocHuongDenHienTai_ChuaLamTron,2)
	--	, PhepNamConLai = round(PhepNamConLai,2)

	-- Return the result of the function
	RETURN

END


GO
