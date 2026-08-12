
--EXEC sp_XuLyGioDayDuLieu 6, 2026
CREATE proc [dbo].[sp_XuLyGioDayDuLieu]
	@Month int, 
	@Year int,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Emp nvarchar(50)=null 
as
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		declare @NgayDauThang datetime, @NgayCuoiThang datetime, @SoNgayHuongCheDoSauKhiMangBau int = 182, @Empl nvarchar(50)

		select @NgayDauThang = DATEFROMPARTS (@Year, @Month, 1)
		select @NgayCuoiThang = EOMONTH(@NgayDauThang)

		Declare @tblNumericDataPV table (Employee_ID nvarchar(50), Thang int, Nam int, DayNumber datetime, d1 float, [d1.3] float, [d1.5] float, [d2] float, [d2.1] float, [d2.7] float, [d3] float, [d3.9] float, [d4] float, [d4.9] float, [dDM/VS] float, primary key (Employee_ID, Thang, Nam, DayNumber))
		Declare @tblNumericData table (Employee_ID nvarchar(50), Thang int, Nam int, LoaiGio nvarchar(50), DayNumber datetime, ConvertedValue float)

		Declare @InsertDateTD datetime = dateadd(hour,9,dateadd(day,1,@NgayCuoiThang))
		Declare @InsertDateDkc datetime = dateadd(MINUTE,8.5*60,dateadd(day,1,@NgayCuoiThang))

		Delete HR_WTDaily
		where Ngay between @NgayDauThang and @NgayCuoiThang and Remark = 'Auto1'

		Delete HR_TimeKeeping_Data
		where AccessDate between @NgayDauThang and @NgayCuoiThang and InsertSource = 'Auto1'

		--Xử lý công
		update HR_GioDayDuLieu
		set LoaiGio = case	when LoaiGio = N'Giờ vào' then N'GV'
							when LoaiGio = N'Giờ ra' then N'GR'
							when LoaiGio like N'%100%' then '1'
							when LoaiGio like N'%130%' then '1.3'
							when LoaiGio like N'%150%' then '1.5'
							when LoaiGio like N'%200%' then '2'
							when LoaiGio like N'%210%' then '2.1'
							when LoaiGio like N'%270%' then '2.7'
							when LoaiGio like N'%300%' then '3'
							when LoaiGio like N'%390%' then '3.9'
							when LoaiGio like N'%400%' then '4'
							when LoaiGio like N'%490%' then '4.9'
							when LoaiGio = '220' then '2.2' 
							when LoaiGio = '50' then '1.5' 
					  else LoaiGio end
		

		;WITH SourceData AS (
			SELECT 
				Employee_ID,
				Thang, Nam, LoaiGio,
				Day1, Day2, Day3, Day4, Day5, Day6, Day7, Day8, Day9, Day10,
				Day11, Day12, Day13, Day14, Day15, Day16, Day17, Day18, Day19, Day20,
				Day21, Day22, Day23, Day24, Day25, Day26, Day27, Day28, Day29, Day30, Day31
			FROM HR_GioDayDuLieu
			where Thang = @Month and Nam = @Year
		),
		
		
		-- Bước 2: Unpivot các cột Day
		UnpivotedData AS (
			SELECT 
			   Employee_ID,
				Thang, Nam, LoaiGio,
				TRY_CAST((CAST(@Year AS VARCHAR(4)) + '-' + CAST(@Month AS VARCHAR(2)) + '-' + Replace(ColName,'Day','')) AS DATE) AS DayNumber,
				Value = ColValue
			FROM SourceData
			UNPIVOT (
				ColValue FOR ColName IN (
					Day1, Day2, Day3, Day4, Day5, Day6, Day7, Day8, Day9, Day10,
					Day11, Day12, Day13, Day14, Day15, Day16, Day17, Day18, Day19, Day20,
				Day21, Day22, Day23, Day24, Day25, Day26, Day27, Day28, Day29, Day30, Day31
				)
			) AS Unpvt
			WHERE ColValue IS NOT NULL -- Loại bỏ giá trị NULL
		),

		-- Bước 3: Tách dữ liệu số
		#NumericData AS (
			SELECT 
				Employee_ID,
				Thang, Nam, 'd' + LoaiGio as LoaiGio,
				DayNumber,
				TRY_CAST(Value AS FLOAT) AS ConvertedValue
			FROM UnpivotedData
			WHERE TRY_CAST(Value AS FLOAT) IS NOT NULL -- Chỉ lấy giá trị có thể chuyển thành số
			  AND Value NOT LIKE '%[^0-9.]%' -- Chỉ chứa số và dấu chấm
			  AND Value NOT LIKE '%.%.%' -- Không có nhiều hơn 1 dấu chấm
			  and DayNumber is not null
		)
		--,

		---- Bước 4: Tách dữ liệu chữ
		--#TextData AS (
		--    SELECT 
		--        Employee_ID,
		--        Thang, Nam, LoaiGio,
		--        DayNumber,
		--        Value AS TextValue
		--    FROM UnpivotedData
		--    WHERE TRY_CAST(Value AS FLOAT) IS NULL -- Không phải số
		--       OR Value LIKE '%[^0-9.]%' -- Chứa ký tự không phải số
		--       OR Value LIKE '%.%.%' -- Nhiều hơn 1 dấu chấm
		--)
		
		insert into @tblNumericData 
		select *
		from
		#NumericData
		
		Delete HR_WTDaily_GioDayDuLieu
		where Ngay between @NgayDauThang and @NgayCuoiThang
		
		insert into HR_WTdaily_GioDayDuLieu (Employee_ID, Ngay, MaCong, InsertSource, wt, Remark, InsertDate, UserName)
		select Employee_ID, DayNumber
				, case LoaiGio 
							when 'd1'   then 'wt1'
							when 'd1.3' then 'wt9' 
							when 'd1.5' then 'CN_wt3'
							when 'd2'	then 'CN_wt4'
							when 'd2.1'	then 'CN_wt5'
							when 'd2.7'	then 'CN_wt6'
							when 'd3'	then 'CN_wt7'
							when 'd3.9'	then 'CN_wt8'
							when 'd4'	then 'CN_wt7'
							when 'd4.9'	then 'CN_wt8'
					else LoaiGio end
				, 'Auto1', ConvertedValue, null, GETDATE(), ''
		from
		@tblNumericData

		--Tạo bảng pivot dữ liêu công
		insert into @tblNumericDataPV
		SELECT * FROM 
			@tblNumericData src
			pivot
			(
				max(ConvertedValue) 
				for LoaiGio in ([d1],[d1.3],[d1.5],[d2],[d2.1],[d2.7],[d3],[d3.9],[d4],[d4.9],[dDM/VS])
			) pv;
		
		Delete HR_TimeKeeping_Data
		where AccessDate between @NgayDauThang and @NgayCuoiThang and UserName = 'Auto1'
		--select * from @tblNumericDataPV
		-- Insert giờ ra
		
		insert into HR_TimeKeeping_Data (Employee_ID, AccessDate, AccessTime, Device_ID, CardNumber, DeviceIP, InOutStatus, InsertSource, Reason, Remark, UserName, InsertDate)
		select src.Employee_ID, src.AccessDate, dateadd(minute,2,src.AccessTime) as AccessTime, src.Device_ID, src.CardNumber, src.DeviceIP, src.InOutStatus, src.InsertSource, src.Reason, src.Remark, src.UserName, src.InsertDate
		from
		(
			select src.Employee_ID
					, dateadd(day, case when dkc.ShiftName like '%Shift3%' and CONVERT(VARCHAR(8),ISNULL(TRY_CAST(src.ThoiGian AS TIME), TRY_CAST(CAST(TRY_CAST(src.ThoiGian AS FLOAT) AS DATETIME) AS TIME))) < CAST('17:00:00' AS TIME) then 1 else 0 end, src.OT_Date) as AccessDate
					, TRY_CAST(CONVERT(VARCHAR(10), dateadd(day, case when dkc.ShiftName like '%Shift3%' and CONVERT(VARCHAR(8),ISNULL(TRY_CAST(src.ThoiGian AS TIME), TRY_CAST(CAST(TRY_CAST(src.ThoiGian AS FLOAT) AS DATETIME) AS TIME))) < '17:00:00' then 1 else 0 end, src.OT_Date), 120) + ' ' + CONVERT(VARCHAR(8),ISNULL(TRY_CAST(src.ThoiGian AS TIME), TRY_CAST(CAST(TRY_CAST(src.ThoiGian AS FLOAT) AS DATETIME) AS TIME))) AS DATETIME) AS AccessTime
					, 'MCC' as Device_ID, src.Employee_ID as CardNumber, null as DeviceIP, null as InOutStatus, 'Auto1' as InsertSource, null as Reason, null as Remark, 'admin' as UserName, @InsertDateTD as InsertDate
			from
			(
				SELECT Employee_ID, LoaiGio, TRY_CAST((CAST(Nam AS VARCHAR(4)) + '-' + CAST(Thang AS VARCHAR(2)) + '-' + Replace(NgayThang,'Day','')) AS DATE) as OT_Date, ThoiGian
				FROM (
					SELECT 
						Employee_ID, Thang, Nam, LoaiGio,
						Day1, Day2, Day3, Day4, Day5, Day6, Day7, Day8, Day9, Day10, Day11, Day12, Day13, Day14, Day15, Day16, Day17
						, Day18, Day19, Day20, Day21, Day22, Day23, Day24, Day25, Day26, Day27, Day28, Day29, Day30, Day31
					FROM HR_GioDayDuLieu
					WHERE LoaiGio = 'QR' and Thang = @Month and Nam = @Year
				) src
				UNPIVOT (
					ThoiGian FOR NgayThang IN (
						Day1, Day2, Day3, Day4, Day5, Day6, Day7, Day8, Day9, Day10, Day11, Day12, Day13, Day14, Day15, Day16, Day17
						, Day18, Day19, Day20, Day21, Day22, Day23, Day24, Day25, Day26, Day27, Day28, Day29, Day30, Day31
					)
				) AS unpvt
			) src
			left join
			udf_DangKyCa (@NgayDauThang, @NgayCuoiThang, 182, null, null, null, null, null, null, null) dkc
			on dkc.Employee_ID = src.Employee_ID and dkc.AccessDate = src.OT_Date
			where src.ThoiGian is not null and OT_Date is not null
		) src
		left join
		HR_TimeKeeping_Data wt
		on src.Employee_ID = wt.Employee_ID and src.AccessDate = wt.AccessDate and src.AccessTime = wt.AccessTime
		where wt.Employee_ID is null

		/*insert into HR_TimeKeeping_Data (Employee_ID, AccessDate, AccessTime, Device_ID, CardNumber, DeviceIP, InOutStatus, InsertSource, Reason, Remark, UserName, InsertDate)
		select src.Employee_ID, src.DayNumber
				, dbo.GhepGioVaoNgay (src.DayNumber,case when  /*dateadd(ms,10,dateadd(minute, (- [d1] - case when [d1] > 4 and RestTimeFrom is not null then 1 else 0 end) * 60 - ABS(CHECKSUM(NEWID())) % 16, dbo.GhepGioVaoNgay(src.DayNumber,ToTime)))*/ as AccessTime
				, 'MCC' as Device_ID, src.Employee_ID as CardNumber, null as DeviceIP, 1 as InOutStatus, 'Auto' as InsertSource, null as Reason, null as Remark, 'Auto' as UserName, getdate() as InsertDate
		from
		@tblNumericDataPV src
		left join
		udf_DangKyCa (@NgayDauThang, @NgayCuoiThang,@SoNgayHuongCheDoSauKhiMangBau,null,null,null,null,null,null,@Empl) dkc
		on src.DayNumber = dkc.AccessDate and src.Employee_ID = dkc.Employee_ID
		left join
		HR_Shifts sh
		on dkc.ShiftName = sh.ShiftName
		where [d1] is not null and sh.ToTime is not null --and src.Employee_ID = 'MS0008'
		--where dateadd(minute, (- [d1] - case when [d1] > 4 and RestTimeFrom is not null then 1 else 0 end) * 60 - ABS(CHECKSUM(NEWID())) % 16, dbo.GhepGioVaoNgay(src.DayNumber,ToTime)) is null
		order by src.Employee_ID, src.Thang, src.Nam, src.DayNumber
		*/
		-- Insert giờ vao
		insert into HR_TimeKeeping_Data (Employee_ID, AccessDate, AccessTime, Device_ID, CardNumber, DeviceIP, InOutStatus, InsertSource, Reason, Remark, UserName, InsertDate)
		select src.Employee_ID, src.AccessDate, dateadd(minute,-2,src.AccessTime) as AccessTime, src.Device_ID, src.CardNumber, src.DeviceIP, src.InOutStatus, src.InsertSource, src.Reason, src.Remark, src.UserName, src.InsertDate
		from
		(
			select src.Employee_ID
				, dateadd(day, case when dkc.ShiftName like '%Shift3%' and CONVERT(VARCHAR(8),ISNULL(TRY_CAST(src.ThoiGian AS TIME), TRY_CAST(CAST(TRY_CAST(src.ThoiGian AS FLOAT) AS DATETIME) AS TIME))) < '06:00:00' then 1 else 0 end, src.OT_Date) as AccessDate
				, TRY_CAST(CONVERT(VARCHAR(10), dateadd(day, case when dkc.ShiftName like '%Shift3%' and CONVERT(VARCHAR(8),ISNULL(TRY_CAST(src.ThoiGian AS TIME), TRY_CAST(CAST(TRY_CAST(src.ThoiGian AS FLOAT) AS DATETIME) AS TIME))) < '06:00:00' then 1 else 0 end, src.OT_Date), 120) + ' ' + CONVERT(VARCHAR(8),ISNULL(TRY_CAST(src.ThoiGian AS TIME), TRY_CAST(CAST(TRY_CAST(src.ThoiGian AS FLOAT) AS DATETIME) AS TIME))) AS DATETIME) AS AccessTime
				, 'MCC' as Device_ID, src.Employee_ID as CardNumber, null as DeviceIP, null as InOutStatus, 'Auto1' as InsertSource, null as Reason, null as Remark, 'admin' as UserName, @InsertDateTD as InsertDate
			from
			(
				SELECT Employee_ID, LoaiGio, TRY_CAST((CAST(Nam AS VARCHAR(4)) + '-' + CAST(Thang AS VARCHAR(2)) + '-' + Replace(NgayThang,'Day','')) AS DATE) as OT_Date, ThoiGian
				FROM (
					SELECT 
						Employee_ID, Thang, Nam, LoaiGio,
						Day1, Day2, Day3, Day4, Day5, Day6, Day7, Day8, Day9, Day10, Day11, Day12, Day13, Day14, Day15, Day16, Day17
						, Day18, Day19, Day20, Day21, Day22, Day23, Day24, Day25, Day26, Day27, Day28, Day29, Day30, Day31
					FROM HR_GioDayDuLieu
					WHERE LoaiGio = 'QV' and Thang = @Month and Nam = @Year
				) src
				UNPIVOT (
					ThoiGian FOR NgayThang IN (
						Day1, Day2, Day3, Day4, Day5, Day6, Day7, Day8, Day9, Day10, Day11, Day12, Day13, Day14, Day15, Day16, Day17
						, Day18, Day19, Day20, Day21, Day22, Day23, Day24, Day25, Day26, Day27, Day28, Day29, Day30, Day31
					)
				) AS unpvt
			) src
			left join
			udf_DangKyCa (@NgayDauThang, @NgayCuoiThang, 182, null, null, null, null, null, null, null) dkc
			on dkc.Employee_ID = src.Employee_ID and dkc.AccessDate = src.OT_Date
			where src.ThoiGian is not null and src.OT_Date is not null
		) src
		left join
		HR_TimeKeeping_Data wt
		on src.Employee_ID = wt.Employee_ID and src.AccessDate = wt.AccessDate and src.AccessTime = wt.AccessTime
		where wt.Employee_ID is null
		/*insert into HR_TimeKeeping_Data (Employee_ID, AccessDate, AccessTime, Device_ID, CardNumber, DeviceIP, InOutStatus, InsertSource, Reason, Remark, UserName, InsertDate)
		select src.Employee_ID, src.DayNumber, dateadd(ms,10,dateadd(MINUTE, (isnull([d1.5],0) + isnull([d2.1],0))*60 + ABS(CHECKSUM(NEWID())) % 16, dbo.GhepGioVaoNgay(src.DayNumber,ToTime))) as AccessTime, 'MCC' as Device_ID, src.Employee_ID as CardNumber, null as DeviceIP, 2 as InOutStatus, 'Auto' as InsertSource, null as Reason, null as Remark, 'Auto' as UserName, getdate() as InsertDate
		from
		@tblNumericDataPV src
		left join
		udf_DangKyCa (@NgayDauThang, @NgayCuoiThang,@SoNgayHuongCheDoSauKhiMangBau,null,null,null,null,null,null,@Empl) dkc
		on src.DayNumber = dkc.AccessDate and src.Employee_ID = dkc.Employee_ID
		left join
		HR_Shifts sh
		on dkc.ShiftName = sh.ShiftName
		where sh.ToTime is not null --and src.Employee_ID = 'MS0008'
		order by src.Employee_ID, src.Thang, src.Nam, src.DayNumber
		*/
		/*
		--Xử lý công 200% - 300%
		delete HR_WTDaily
		where Ngay between @NgayDauThang and @NgayCuoiThang and UserName = 'Auto1'
		*/
		/*
		--Theem dang ky tang ca
		Declare @tblHR_MaxOverTime table (Employee_ID nvarchar(50), TongGio float, OT_Date datetime, primary key (Employee_ID, OT_Date))
		Insert into @tblHR_MaxOverTime (Employee_ID, TongGio, OT_Date)
		SELECT Employee_ID, isnull(SUM(TRY_CAST(ThoiGian AS FLOAT)),0) AS TongGio, TRY_CAST((CAST(Nam AS VARCHAR(4)) + '-' + CAST(Thang AS VARCHAR(2)) + '-' + Replace(NgayThang,'Day','')) AS DATE) as OT_Date
		FROM (
			SELECT 
				Employee_ID, Thang, Nam, LoaiGio,
				Day1, Day2, Day3, Day4, Day5, Day6, Day7, Day8, Day9, Day10, Day11, Day12, Day13, Day14, Day15, Day16, Day17
				, Day18, Day19, Day20, Day21, Day22, Day23, Day24, Day25, Day26, Day27, Day28, Day29, Day30, Day31
			FROM HR_GioDayDuLieu
			WHERE LoaiGio in ('1.5','2.15') and Thang = @Month and Nam = @Year
		) src
		UNPIVOT (
			ThoiGian FOR NgayThang IN (
				Day1, Day2, Day3, Day4, Day5, Day6, Day7, Day8, Day9, Day10, Day11, Day12, Day13, Day14, Day15, Day16, Day17
				, Day18, Day19, Day20, Day21, Day22, Day23, Day24, Day25, Day26, Day27, Day28, Day29, Day30, Day31
			)
		) AS unpvt
		where TRY_CAST((CAST(Nam AS VARCHAR(4)) + '-' + CAST(Thang AS VARCHAR(2)) + '-' + Replace(NgayThang,'Day','')) AS DATE) is not null
		GROUP BY Employee_ID, Thang, Nam, NgayThang

		--select * from @tblHR_MaxOverTime

		Delete mot
		from
		HR_MaxOvertime mot
		left join
		@tblHR_MaxOverTime motOT
		on mot.Employee_ID = motOT.Employee_ID and mot.workingdate = motOT.OT_Date
		where mot.workingdate between @NgayDauThang and @NgayCuoiThang and mot.TypeOfOT = 1 and motOT.Employee_ID is not null

		insert into HR_MaxOvertime (Employee_ID, workingdate, maxovertime, TypeOfOT, NgayNghiBu, ShiftName, PrintStatus, Remark, InsertDate, UserName, UpdateDate, UpdateUserName)
		select Employee_ID, OT_Date, TongGio, 1, null, null, null, 'Auto', @InsertDateDkc as InsertDate, 'admin', null, null
		from
		@tblHR_MaxOverTime
		*/
		--insert into HR_WTDaily (Employee_ID, Ngay, MaCong, InsertSource, wt, Remark, InsertDate, UserName)
		--select src.Employee_ID, src.DayNumber
		--		, case LoaiGio when 'd2' then 'CN_wt4' when 'd2.7' then 'CN_wt6'
		--						when 'd3' then 'CN_wt7' when 'd3.9' then 'CN_wt8'
		--			else null end
		--		, 'NhapTay', src.ConvertedValue, 'Auto1', Getdate(), 'Auto1'
		--from
		--@tblNumericData src
		--where LoaiGio in ('d2','d2.7','d3','d3.9')
		/*
		--Xử lý phép
		Delete from HR_DangKyPhepTheoGio
		where Remark = 'Auto'

		insert into HR_DangKyPhepTheoGio (Employee_ID, DateLeave, TypeOfLeave, HourLeave, LeaveType_ID, Remark, InsertDate, UserName)
		select src.Employee_ID, src.Ngay, 1 as TypeOfLeave, case when cast(GioNghi as float) = 0 then 8.0 else cast(GioNghi as float) end as GioNghi, lt.LeaveType_ID, 'Auto' as Remark, GETDATE() as InsertDate, 'Auto' as UserName
		from
		(
			select Employee_ID, Thang, Nam, LoaiGio1, loaigio2, SUBSTRING(LoaiGio2,1,PATINDEX('%[^0-9.]%', LoaiGio2 + ' ') - 1) as GioNghi, SUBSTRING(replace(LoaiGio2,N'Ô','O'), PATINDEX('%[^0-9.]%', replace(LoaiGio2,N'Ô','O') + ' '), LEN(replace(LoaiGio2,N'Ô','O'))) AS LoaiNghi , DATEFROMPARTS(Nam,Thang,case when LEN(LoaiGio1) = 4 then right(LoaiGio1,1) else right(LoaiGio1,2) end) as Ngay
			from
			(
				SELECT *
				FROM HR_GioDayDuLieu gddl
				WHERE (TRY_CAST(Day1 AS FLOAT) IS NULL OR Day1 LIKE '%[^0-9.]%' OR Day1 LIKE '%.%.%') And (TRY_CAST(Day2 AS FLOAT) IS NULL OR Day2 LIKE '%[^0-9.]%' OR Day2 LIKE '%.%.%') And (TRY_CAST(Day3 AS FLOAT) IS NULL OR Day3 LIKE '%[^0-9.]%' OR Day3 LIKE '%.%.%') 
					And (TRY_CAST(Day4 AS FLOAT) IS NULL OR Day4 LIKE '%[^0-9.]%' OR Day4 LIKE '%.%.%') And (TRY_CAST(Day5 AS FLOAT) IS NULL OR Day5 LIKE '%[^0-9.]%' OR Day5 LIKE '%.%.%') And (TRY_CAST(Day6 AS FLOAT) IS NULL OR Day6 LIKE '%[^0-9.]%' OR Day6 LIKE '%.%.%')
					And (TRY_CAST(Day7 AS FLOAT) IS NULL OR Day7 LIKE '%[^0-9.]%' OR Day7 LIKE '%.%.%') And (TRY_CAST(Day8 AS FLOAT) IS NULL OR Day8 LIKE '%[^0-9.]%' OR Day8 LIKE '%.%.%') And (TRY_CAST(Day9 AS FLOAT) IS NULL OR Day9 LIKE '%[^0-9.]%' OR Day9 LIKE '%.%.%') 
					And (TRY_CAST(Day10 AS FLOAT) IS NULL OR Day10 LIKE '%[^0-9.]%' OR Day10 LIKE '%.%.%') And (TRY_CAST(Day11 AS FLOAT) IS NULL OR Day11 LIKE '%[^0-9.]%' OR Day11 LIKE '%.%.%') And (TRY_CAST(Day12 AS FLOAT) IS NULL OR Day12 LIKE '%[^0-9.]%' OR Day12 LIKE '%.%.%') 
					And (TRY_CAST(Day13 AS FLOAT) IS NULL OR Day13 LIKE '%[^0-9.]%' OR Day13 LIKE '%.%.%') And (TRY_CAST(Day14 AS FLOAT) IS NULL OR Day14 LIKE '%[^0-9.]%' OR Day14 LIKE '%.%.%') And (TRY_CAST(Day15 AS FLOAT) IS NULL OR Day15 LIKE '%[^0-9.]%' OR Day15 LIKE '%.%.%') 
					And (TRY_CAST(Day16 AS FLOAT) IS NULL OR Day16 LIKE '%[^0-9.]%' OR Day16 LIKE '%.%.%') And (TRY_CAST(Day17 AS FLOAT) IS NULL OR Day17 LIKE '%[^0-9.]%' OR Day17 LIKE '%.%.%') And (TRY_CAST(Day18 AS FLOAT) IS NULL OR Day18 LIKE '%[^0-9.]%' OR Day18 LIKE '%.%.%') 
					And (TRY_CAST(Day19 AS FLOAT) IS NULL OR Day19 LIKE '%[^0-9.]%' OR Day19 LIKE '%.%.%') And (TRY_CAST(Day20 AS FLOAT) IS NULL OR Day20 LIKE '%[^0-9.]%' OR Day20 LIKE '%.%.%') And (TRY_CAST(Day21 AS FLOAT) IS NULL OR Day21 LIKE '%[^0-9.]%' OR Day21 LIKE '%.%.%') 
					And (TRY_CAST(Day22 AS FLOAT) IS NULL OR Day22 LIKE '%[^0-9.]%' OR Day22 LIKE '%.%.%') And (TRY_CAST(Day23 AS FLOAT) IS NULL OR Day23 LIKE '%[^0-9.]%' OR Day23 LIKE '%.%.%') And (TRY_CAST(Day24 AS FLOAT) IS NULL OR Day24 LIKE '%[^0-9.]%' OR Day24 LIKE '%.%.%') 
					And (TRY_CAST(Day25 AS FLOAT) IS NULL OR Day25 LIKE '%[^0-9.]%' OR Day25 LIKE '%.%.%') And (TRY_CAST(Day26 AS FLOAT) IS NULL OR Day26 LIKE '%[^0-9.]%' OR Day26 LIKE '%.%.%') And (TRY_CAST(Day27 AS FLOAT) IS NULL OR Day27 LIKE '%[^0-9.]%' OR Day27 LIKE '%.%.%') 
					And (TRY_CAST(Day28 AS FLOAT) IS NULL OR Day28 LIKE '%[^0-9.]%' OR Day28 LIKE '%.%.%') And (TRY_CAST(Day29 AS FLOAT) IS NULL OR Day29 LIKE '%[^0-9.]%' OR Day29 LIKE '%.%.%') And (TRY_CAST(Day30 AS FLOAT) IS NULL OR Day30 LIKE '%[^0-9.]%' OR Day30 LIKE '%.%.%') 
					And (TRY_CAST(Day31 AS FLOAT) IS NULL OR Day31 LIKE '%[^0-9.]%' OR Day31 LIKE '%.%.%') 
					And Thang = @Month and Nam = @Year
			) src
			unpivot
			(
				LoaiGio2 for LoaiGio1
				in (Day1,Day2,Day3,Day4,Day5,Day6,Day7,Day8,Day9,Day10,Day11,Day12,Day13,Day14,Day15,Day16,Day17,Day18,Day19,Day20,Day21,Day22,Day23,Day24,Day25,Day26,Day27,Day28,Day29,Day30,Day31)
			) pv
		) src
		left join
		SmartBooks_LeaveType lt
		on src.LoaiNghi = lt.AbsentSign
		where lt.LeaveType_ID is not null --and src.Employee_ID = 'MS2307'
		*/
		/*
		--Chu y xoa du lieu cong goc
		delete tito
		from
		HR_TimeKeeping_Data tito
		left join
		(
			select distinct Employee_ID, AccessDate
			from
			HR_TimeKeeping_Data tito2
			where tito2.UserName = 'Auto' and tito2.AccessDate between @NgayDauThang and @NgayCuoiThang
		) tito2
		on tito.Employee_ID = tito2.Employee_ID and tito.AccessDate = tito2.AccessDate
		where tito.AccessDate between @NgayDauThang and @NgayCuoiThang and tito.UserName <> 'Auto' and tito2.Employee_ID is not null
		*/
		--exec sp_XuLyPhepDayDuLieu @Month, @Year, @fact, @dept, @sect, @team, @pos, @posc, @Emp
		
		select 'ThanhCong' as ThongBao
		
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; -- Hủy bỏ tất cả thay đổi nếu có lỗi
    
		-- Xử lý lỗi
		SELECT 
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_MESSAGE() AS ErrorMessage,
			ERROR_MESSAGE() as ThongBao;
	END CATCH
END
GO
