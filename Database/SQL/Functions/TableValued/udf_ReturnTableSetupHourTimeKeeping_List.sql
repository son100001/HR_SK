CREATE function [dbo].[udf_ReturnTableSetupHourTimeKeeping_List]
(
	@Emp nvarchar(50),
	@fromdate datetime,
	@todate datetime,
	@SoNgaySauKhiMangBauDuocHuongThaiSan int
)
Returns @rtnReturnTableSetupHourTimeKeeping table
(
--select * from udf_ReturnTableSetupHourTimeKeeping_List ('C11749','2026-02-02','2026-02-07',182)
--select * from udf_DanhSachHuongCheDo ('2026-02-02','2026-02-07',182) where Employee_ID = 'C11749'
	Date_ datetime,
	Employee_ID nvarchar(50),
	[ShiftName] [nvarchar](50) NOT NULL,
	[FromTime] [datetime] NOT NULL,
	[ToTime] [datetime] NULL,
	[RestTimeFrom] [datetime] NULL,
	[RestTimeTo] [datetime] NULL,
	[MaCong] [nvarchar](50) NULL,
	TrongCa nvarchar(50),
	TCNgayThuong nvarchar(50),
	TCChuNhat nvarchar(50),
	TCNgayLe nvarchar(50),
	Note nvarchar(100),
	No_ int,
	MaxMinute int,
	isTCTruoc bit,
	ShiftFromTime datetime,
	ShiftToTime datetime,
	NumberOfDay int,
	MinMinute int,
	BlockMinute int,
	BlockDownMinute int,
	[PushWorkingTimeNo] [int] NULL,
	[Round_] [int] NULL,
	[GioTieuChuan] [int] NULL,
	[DuGioTieuChuanDuocCong] [int] NULL,
	[SoPhutCoSoDeQuyDoi] [int] NULL,
	[SoPhutDuocTinhLaMotNgayCong] [int] NULL,
	[BreakTimeFrom] [datetime] NULL,
	[BreakTimeTo] [datetime] NULL
	, primary key (Date_, Employee_ID, FromTime)
)
as
begin
	insert into @rtnReturnTableSetupHourTimeKeeping (Date_, Employee_ID, ShiftName, FromTime, ToTime, RestTimeFrom, RestTimeTo/*, MaCong*/, TrongCa, TCNgayThuong, TCChuNhat, TCNgayLe, Note, No_, MaxMinute, ShiftFromTime, ShiftToTime, BlockMinute, BlockDownMinute, Round_)
	SELECT 
		btg.Date_,
		dkc.Employee_ID,
		dkc.ShiftName,

		-- Ghép giờ vào ngày + cộng thêm offset theo ngày lặp
		DATEADD(
			MILLISECOND,
			DATEDIFF(MILLISECOND, CAST(CAST(plgc.FromTime AS date) AS datetime), CAST(plgc.FromTime AS datetime)),
			DATEADD(DAY, d.DayOffset, btg.Date_)
		) AS FromTime,

		DATEADD(
			MILLISECOND,
			DATEDIFF(MILLISECOND, CAST(CAST(plgc.ToTime AS date) AS datetime), CAST(plgc.ToTime AS datetime) + case when plgc.ToTime < plgc.fromtime then 1 else 0 end),
			DATEADD(DAY, d.DayOffset, btg.Date_)
		) AS ToTime,
		--Null as RestTimeFrom,
		--Null as RestTimeTo,
		case when CAST(sh.RestTimeFrom AS time) between cast(plgc.fromtime as time) and cast(plgc.totime as time) then DATEADD(SECOND, DATEDIFF(SECOND, 0, CAST(sh.RestTimeFrom AS time)), DATEADD(DAY, d.DayOffset, btg.Date_)) else null end as RestTimeFrom,
		case when CAST(sh.RestTimeFrom AS time) between cast(plgc.fromtime as time) and cast(plgc.totime as time) then DATEADD(SECOND, DATEDIFF(SECOND, 0, CAST(sh.RestTimeTo AS time)), DATEADD(DAY, d.DayOffset, btg.Date_)) else null end as RestTimeTo,
		--case when hp.H_date is not null or isnull(sufd.Code,'') = 'Hol' then 'CN_' + plgc.TCNgayLe when isnull(sufd.Code,'') = 'Sun' then 'CN_' + plgc.TCChuNhat
		--	else (case when Cast(plgc.FromTime as time) between Cast(sh.Fromtime as time) and Cast(sh.Totime as time) then plgc.TrongCa else 'CN_' + plgc.TCNgayThuong end) end as MaCong,
		plgc.TrongCa,
		plgc.TCNgayThuong,
		plgc.TCChuNhat,
		plgc.TCNgayLe,
		plgc.Note,
		ROW_NUMBER() OVER (PARTITION BY btg.Date_, dkc.Employee_ID ORDER BY d.DayOffset, plgc.FromTime) AS No_,
		Null AS MaxMinute,
		DATEADD(
			MILLISECOND,
			DATEDIFF(MILLISECOND, CAST(CAST(sh.FromTime AS date) AS datetime), CAST(sh.FromTime AS datetime)),
			btg.Date_
		) AS ShiftFromTime, 
		DATEADD(
			MILLISECOND,
			DATEDIFF(MILLISECOND, CAST(CAST(sh.ToTime AS date) AS datetime), CAST(sh.ToTime AS datetime) + case when cast(sh.ToTime as time) < cast(sh.fromtime as time) then 1 else 0 end),
			btg.Date_
		) AS ShiftToTime
		, 30 as BlockMinute
		, 29 as BlockDownMinute
		, 1 as Round_

	FROM udf_BangThoiGian(@fromdate, @todate) btg
	LEFT JOIN udf_DangKyCa(@Fromdate, @todate, @SoNgaySauKhiMangBauDuocHuongThaiSan, NULL, NULL, NULL, NULL, NULL, NULL, @Emp) dkc
		ON btg.Date_ = dkc.AccessDate --OR btg.Date_ + 1 = dkc.AccessDate

	LEFT JOIN HR_Shifts sh 
		ON dkc.ShiftName = sh.ShiftName

	-- Lặp ca cho 2 ngày liên tiếp
	CROSS APPLY (
		SELECT DayOffset
		FROM (VALUES (0), (1)) AS Days(DayOffset)
	) d

	-- Lấy dữ liệu khung giờ chuẩn từ HR_PhanLoaiGioCong
	CROSS APPLY (
		SELECT 
			plgc.FromTime,
			plgc.totime,
			plgc.TrongCa,
			plgc.TCNgayThuong,
			plgc.TCChuNhat,
			plgc.TCNgayLe,
			CASE 
				WHEN plgc.ToTime < plgc.FromTime THEN N'Ca đêm (qua ngày)'
				ELSE N'Ca bình thường'
			END AS Note
		FROM HR_PhanLoaiGioCong plgc
		WHERE plgc.ShiftName = 
			CASE 
				WHEN EXISTS (SELECT 1 FROM HR_PhanLoaiGioCong WHERE ShiftName = sh.ShiftName) THEN sh.ShiftName
				WHEN sh.ShiftName LIKE '%Shift3' THEN 'Shift3'
				ELSE 'General'
			END
	) plgc
	where dkc.Employee_ID is not null

	--WHERE dkc.ShiftName LIKE '%Shift3'
	--ORDER BY dkc.Employee_ID, btg.Date_, d.DayOffset, plgc.FromTime;

	Update @rtnReturnTableSetupHourTimeKeeping
	set isTCTruoc = 1 
	where No_ <= 2

	update rt
	set isTCTruoc = case when cast(rt.FromTime as time) < cast(sh.FromTime as time) and No_ < 7 then 1 else 0 end
		, MaxMinute = DATEDIFF(MINUTE, rt.FromTime, rt.ToTime)
	from @rtnReturnTableSetupHourTimeKeeping rt
	left join
	HR_Shifts sh
	on rt.ShiftName = sh.ShiftName

	update rt
	set MaCong = case when hp.H_date is not null or isnull(sufd.Code,'') = 'Hol' then 'CN_' + TCNgayLe when isnull(sufd.Code,'') = 'Sun' or datename(weekday,Date_) = 'Sunday' then 'CN_' + TCChuNhat
					else (case when FromTime between ShiftFromTime and dateadd(minute,-1,cast(ShiftToTime as datetime)) then TrongCa else 'CN_' + TCNgayThuong end) end
		,RestTimeFrom = case when FromTime between ShiftFromTime and dateadd(minute,-1,cast(ShiftToTime as datetime)) then RestTimeFrom else NULL end
		,RestTimeTo = case when FromTime between ShiftFromTime and dateadd(minute,-1,cast(ShiftToTime as datetime)) then RestTimeTo else NULL end
		,BlockMinute = case when FromTime between ShiftFromTime and dateadd(minute,-1,cast(ShiftToTime as datetime)) then 0 else 30 end
		,BlockDownMinute = case when FromTime between ShiftFromTime and dateadd(minute,-1,cast(ShiftToTime as datetime)) then 0 else 29 end
		,Round_ = case when FromTime between ShiftFromTime and dateadd(minute,-1,cast(ShiftToTime as datetime)) then 1 else 2 end
	from @rtnReturnTableSetupHourTimeKeeping rt
	left join SmartBooks_HolidaysPlan hp
		on rt.Date_ = hp.H_date
	left join HR_SetUpFollowDate sufd
		on rt.Date_ between sufd.Fromdate and sufd.Todate and sufd.Group_ = 'Cong' and sufd.Code in ('Hol','Sun','Nor')

	-- Xử lý thai sản
	Declare @rtnDSHuongCheDo table (Employee_ID nvarchar(50), pregFromdate datetime, pregTodate datetime, babyFromdate datetime, babyTodate datetime, primary key (Employee_ID))
	insert into @rtnDSHuongCheDo (Employee_ID, pregFromdate, pregTodate, babyFromdate, babyTodate)
	select Employee_ID, pregFromdate, pregTodate, babyFromdate, babyTodate
	from 
	udf_DanhSachHuongCheDo (@fromdate,@todate,@SoNgaySauKhiMangBauDuocHuongThaiSan)
	where @Emp is null or Employee_ID = @Emp

	Delete rt
	from @rtnReturnTableSetupHourTimeKeeping rt
	left join
	@rtnDSHuongCheDo dshcd
	on rt.Employee_ID = dshcd.Employee_ID and ((rt.Date_ between dshcd.pregFromdate and dshcd.pregTodate) or (rt.Date_ between dshcd.babyFromdate and dshcd.babyTodate))
	where dshcd.Employee_ID is not null and rt.Fromtime >= rt.ShiftToTime

	update rt
	set Totime = case when ToTime = ShiftToTime then dateadd(hour,case when dshcd.pregFromdate is not null or dshcd.babyFromdate is not null then -1 else 0 end,ToTime) else ToTime end
		, FromTime = case when FromTime = ShiftToTime then dateadd(hour,case when dshcd.pregFromdate is not null or dshcd.babyFromdate is not null then -1 else 0 end,FromTime) else FromTime end
	from @rtnReturnTableSetupHourTimeKeeping rt
	left join
	@rtnDSHuongCheDo dshcd
	on rt.Employee_ID = dshcd.Employee_ID and (rt.Date_ between dshcd.pregFromdate and dshcd.pregTodate or rt.Date_ between dshcd.babyFromdate and dshcd.babyTodate)
	where dshcd.Employee_ID is not null and (ToTime = ShiftToTime or Fromtime = ShiftToTime)

	return;
end

GO
