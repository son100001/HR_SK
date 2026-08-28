/*
    Mục đích: chuyển toàn bộ việc QUY ĐỔI GIỜ TĂNG CA ĐĂNG KÝ (CN_wt3/CN_wt5 -> wt3/wt5) từ
    dbo.sp_TinhCong sang dbo.sp_XuLyGioDayDuLieu.
    Áp dụng cho: HR_SnK_Dev (113.161.180.44). Ngày: 2026-08-28.

    LÝ DO: khi khách hàng sửa tay bảng công rồi đẩy ngược lên (HR_GioDayDuLieu), việc quy đổi vẫn đang
    nằm trong cursor của sp_TinhCong (khối if @OldGioDayDuLieu is not null, dòng ~458-542), làm
    sp_TinhCong chậm từ ~3 phút lên ~10 phút. Chuyển sang đây thì chạy 1 lần cho cả tháng, không còn
    ảnh hưởng tốc độ tính công.

    QUY TẮC NGHIỆP VỤ (giữ đúng như sp_TinhCong, chỉ bổ sung thứ tự ưu tiên theo ca):
      - "CN_" = công ngoài (ngoài đăng ký). Ngày nào Factory có đăng ký tăng ca (udf_TongTangCaNgoaiLe)
        thì chuyển bớt sang dạng không có "CN_", lấy min(giờ thực tế, giờ đăng ký).
        Không đăng ký (hoặc đăng ký 0 giờ) -> giữ nguyên toàn bộ dạng CN_.
      - CHỈ áp dụng cho CN_wt3 và CN_wt5. wt1, wt9 và các mã CN_wt4/6/7/8 giữ nguyên.
      - THỨ TỰ ƯU TIÊN THEO CA (điểm MỚI so với sp_TinhCong - bản cũ dùng ROW_NUMBER() không có tiêu
        chí sắp xếp nên thứ tự là tuỳ execution plan):
            ca ngày (ShiftName KHÔNG chứa 'Shift3') -> quy đổi wt3 trước, hết wt3 mới tràn sang wt5
            ca đêm  (ShiftName CÓ chứa 'Shift3')    -> quy đổi wt5 trước, hết wt5 mới tràn sang wt3
        Ca lấy từ udf_DangKyCa.
      - Vẫn chặn bởi trần THÁNG và trần NĂM, đọc từ HR_SetUpFollowDate (cùng nguồn với sp_TinhCong:
        Group_ = 'TangCaToiDaTheoThang' / 'TangCaToiDaTheoNam'). Hết trần thì quy đổi = 0.

    ⚠️ PHẢI DEPLOY KÈM: 2026-08-28_HR_SnK_Dev_Disable_sp_TinhCong_QuyDoiTangCa_GioDayDuLieu.sql
    Nếu chỉ chạy script này mà không tắt khối quy đổi cũ trong sp_TinhCong thì sẽ QUY ĐỔI 2 LẦN
    (sp_TinhCong sẽ lại quy đổi tiếp trên phần CN_ còn dư).

    CÁCH GHI KẾT QUẢ: khác sp_TinhCong ở chỗ KHÔNG chèn dòng CN_ âm để bù trừ, mà trừ thẳng vào dòng
    CN_ gốc rồi thêm dòng wt3/wt5 (InsertSource = 'AutoK'). Tổng giờ giống hệt nhưng bảng công sạch,
    không có dòng âm. sp_TinhCong vẫn copy HR_WTDaily_GioDayDuLieu -> HR_WTDaily như cũ, không phải sửa.

    KIỂM CHỨNG (2026-08-28, chạy trên dữ liệu thật + bộ test tổng hợp, mọi thứ trên bảng tạm):
      - Dữ liệu thật tháng 6/2026: 18.323 dòng nguồn / 1.012 nhân viên. Bản set-based (dùng ở đây) so
        với bản WHILE tuần tự viết đúng theo mô tả nghiệp vụ: 4.705 dòng / 18.217 giờ, EXCEPT 2 chiều
        = 0 dòng lệch. Set-based nhanh hơn 4,6 lần (234 ms so với 1.079 ms).
      - Dữ liệu thật KHÔNG phủ được 3 đường quan trọng (không có ngày ca đêm nào có cả 2 mã; đăng ký
        luôn 4h <= CN_wt3 nên không bao giờ tràn sang mã thứ 2; không ai chạm trần) -> đã dựng bộ test
        tổng hợp 8 tình huống, so với KỲ VỌNG TÍNH TAY: khớp 11/11 dòng, không có dòng thừa.
        Gồm: ca ngày tràn wt3->wt5; ca đêm wt5 trước rồi tràn sang wt3; ca đêm wt5 ít phần còn lại vào
        wt3; lấy min(thực tế, đăng ký); không đăng ký -> không quy đổi; chạm trần tháng (4+4+2+0);
        chạm trần năm (còn 2h thì chỉ quy đổi 2h).

    GHI CHÚ VỀ TRẦN: DB đang cấu hình TangCaToiDaTheoNam = 10000, TangCaToiDaTheoThang = 40.
    Người yêu cầu nói muốn năm 300h / tháng 40h. Script này ĐỌC TỪ CẤU HÌNH nên chỉ cần UPDATE
    HR_SetUpFollowDate, không phải sửa lại proc.

    ⚠️ KHÁC BIỆT SO VỚI sp_TinhCong khi tính "giờ đã tăng ca trong năm" (cố ý, vì bản cũ SAI):
      - sp_TinhCong dòng 161 cộng các mã có isWorkingTime = 1, tức wt1/wt9 (GIỜ HÀNH CHÍNH), trong khi
        dòng 420/536 lại trừ trần bằng isWorkingTime = 0 (đúng là giờ tăng ca).
      - sp_TinhCong dòng 52 đặt @NgayDauNam = ngày đầu THÁNG rồi +1 năm, tức cửa sổ 12 tháng VỀ PHÍA
        TRƯỚC chứ không phải năm hiện tại.
      Với trần 10.000h thì không ai thấy, nhưng nếu hạ trần năm xuống 300h thì lỗi này sẽ làm mọi nhân
      viên cháy trần sau ~1,5 tháng. Ở đây tính đúng: cộng giờ TĂNG CA (isWorkingTime = 0, không CN_)
      trong NĂM DƯƠNG LỊCH của @Year, trừ đi tháng đang xử lý lại.

    Idempotent: dùng CREATE OR ALTER. Bản thân proc đã tự xoá + dựng lại HR_WTDaily_GioDayDuLieu cho
    tháng được truyền vào nên chạy lại nhiều lần cho cùng 1 tháng là an toàn.
    Rollback: 2026-08-28_HR_SnK_Dev_Rollback_sp_XuLyGioDayDuLieu.sql
*/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

--EXEC sp_XuLyGioDayDuLieu 6, 2026
CREATE OR ALTER proc [dbo].[sp_XuLyGioDayDuLieu]
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

		--==========================================================================================
		-- XỬ LÝ GIỜ TĂNG CA ĐĂNG KÝ — quy đổi CN_wt3/CN_wt5 sang wt3/wt5 (2026-08-28)
		--
		-- Trước đây việc này nằm trong sp_TinhCong (khối `if @OldGioDayDuLieu is not null`), chạy
		-- BÊN TRONG cursor nên làm sp_TinhCong chậm từ ~3 phút lên ~10 phút. Nay chuyển hẳn sang đây,
		-- chạy 1 lần cho cả tháng, không còn ảnh hưởng tốc độ tính công.
		--
		-- Quy tắc nghiệp vụ:
		--  - "CN_" = công ngoài (ngoài đăng ký). Ngày nào có đăng ký tăng ca thì chuyển bớt sang dạng
		--    không có "CN_", lấy min(giờ thực tế, giờ đăng ký). Không đăng ký thì giữ nguyên CN_.
		--  - Chỉ áp dụng cho CN_wt3 / CN_wt5. Mọi mã khác (wt1, wt9, CN_wt4/6/7/8) giữ nguyên.
		--  - Thứ tự ưu tiên theo ca (lấy ca từ udf_DangKyCa):
		--       ca ngày  (ShiftName KHÔNG chứa 'Shift3') -> quy đổi wt3 trước, hết mới tới wt5
		--       ca đêm   (ShiftName chứa 'Shift3')       -> quy đổi wt5 trước, hết mới tới wt3
		--  - Còn bị chặn bởi trần tháng và trần năm (đọc từ HR_SetUpFollowDate, cùng nguồn sp_TinhCong).
		--    Hết trần thì phần còn lại giữ nguyên CN_ (tức quy đổi = 0).
		--==========================================================================================

		declare @TranNam float = 10000, @TranThang float = 40
		select @TranNam   = [Value] from HR_SetUpFollowDate
		 where Group_ = 'TangCaToiDaTheoNam'   and Fromdate <= @NgayCuoiThang and (Todate is null or Todate >= @NgayDauThang) order by Fromdate asc
		select @TranThang = [Value] from HR_SetUpFollowDate
		 where Group_ = 'TangCaToiDaTheoThang' and Fromdate <= @NgayCuoiThang and (Todate is null or Todate >= @NgayDauThang) order by Fromdate asc

		-- Ca ngày / ca đêm theo từng (nhân viên, ngày)
		declare @CaLamViec table (Employee_ID nvarchar(50), Ngay datetime, LaCaDem bit, primary key (Employee_ID, Ngay))
		insert into @CaLamViec (Employee_ID, Ngay, LaCaDem)
		select Employee_ID, AccessDate, case when ShiftName like '%Shift3%' then 1 else 0 end
		from udf_DangKyCa (@NgayDauThang, @NgayCuoiThang, @SoNgayHuongCheDoSauKhiMangBau, @fact, @dept, @sect, @team, @pos, @posc, @Emp)

		-- Giờ tăng ca ĐĂNG KÝ, quy về từng (nhân viên, ngày) theo Factory của nhân viên
		declare @GioDangKy table (Employee_ID nvarchar(50), Ngay datetime, Gio float, primary key (Employee_ID, Ngay))
		insert into @GioDangKy (Employee_ID, Ngay, Gio)
		select e.Employee_ID, t.Ngay, max(t.Gio)
		from udf_TongTangCaNgoaiLe (@NgayDauThang, @NgayCuoiThang) t
		join SmartBooks_Employee e
		  on (e.Factory_ID = t.Factory_ID or (e.Factory_ID = 'SK2' and t.Factory_ID = 'SK2-Assembly'))
		where isnull(t.Gio,0) > 0
		group by e.Employee_ID, t.Ngay

		-- Giờ tăng ca ĐÃ dùng trong NĂM DƯƠNG LỊCH của @Year, KHÔNG tính tháng đang xử lý lại
		declare @DaTangCaTrongNam table (Employee_ID nvarchar(50), Gio float, primary key (Employee_ID))
		insert into @DaTangCaTrongNam (Employee_ID, Gio)
		select Employee_ID, sum(wt)
		from HR_WTDaily
		where Ngay >= DATEFROMPARTS(@Year,1,1) and Ngay < DATEFROMPARTS(@Year+1,1,1)
		  and not (Ngay between @NgayDauThang and @NgayCuoiThang)
		  and MaCong in (select MaCong from HR_LoaiCong where isnull(isWorkingTime,0) = 0 and MaCong not like 'CN%')
		group by Employee_ID

		-- Bảng kết quả quy đổi
		declare @QuyDoi table (Employee_ID nvarchar(50), Ngay datetime, MaCong varchar(50), GioQuyDoi float, primary key (Employee_ID, Ngay, MaCong))

		;with src as (
			-- các dòng có thể quy đổi, kèm thứ tự ưu tiên theo ca
			select  g.Employee_ID, g.Ngay, g.MaCong, g.wt
				  , UuTien = case when isnull(c.LaCaDem,0) = 1
								  then case g.MaCong when 'CN_wt5' then 1 else 2 end   -- ca đêm : wt5 trước
								  else case g.MaCong when 'CN_wt3' then 1 else 2 end   -- ca ngày: wt3 trước
							 end
			from HR_WTDaily_GioDayDuLieu g
			left join @CaLamViec c on c.Employee_ID = g.Employee_ID and c.Ngay = g.Ngay
			where g.Ngay between @NgayDauThang and @NgayCuoiThang
			  and g.MaCong in ('CN_wt3','CN_wt5')
			  and isnull(g.wt,0) > 0
		),
		theongay as (
			-- B = giờ tối đa được quy đổi trong NGÀY = min(tổng giờ CN thực tế, giờ đăng ký)
			select  s.Employee_ID, s.Ngay
				  , B = case when isnull(dk.Gio,0) < sum(s.wt) then isnull(dk.Gio,0) else sum(s.wt) end
			from src s
			left join @GioDangKy dk on dk.Employee_ID = s.Employee_ID and dk.Ngay = s.Ngay
			group by s.Employee_ID, s.Ngay, dk.Gio
		),
		luyke as (
			-- C = trần còn lại của nhân viên = min(trần năm còn lại, trần tháng)
			-- Luỹ kế B theo ngày tăng dần; A(ngày) = min(C, luỹ kế tới ngày) - min(C, luỹ kế trước ngày)
			-- (tương đương đúng vòng lặp trừ dần trần sau mỗi ngày)
			select  n.Employee_ID, n.Ngay, n.B
				  , C = case when (@TranNam - isnull(dd.Gio,0)) < @TranThang
							 then (@TranNam - isnull(dd.Gio,0)) else @TranThang end
				  , cumTruoc = isnull(sum(n.B) over (partition by n.Employee_ID order by n.Ngay
													 rows between unbounded preceding and 1 preceding), 0)
				  , cumDen   =        sum(n.B) over (partition by n.Employee_ID order by n.Ngay
													 rows between unbounded preceding and current row)
			from theongay n
			left join @DaTangCaTrongNam dd on dd.Employee_ID = n.Employee_ID
		),
		phanboNgay as (
			select  Employee_ID, Ngay
				  , A = case when C <= 0 then 0
							 else (case when C < cumDen   then C else cumDen   end)
								- (case when C < cumTruoc then C else cumTruoc end) end
			from luyke
		),
		phanboDong as (
			-- chia A của ngày cho từng dòng theo đúng thứ tự ưu tiên ca
			select  s.Employee_ID, s.Ngay, s.MaCong, s.wt, p.A
				  , truocDong = isnull(sum(s.wt) over (partition by s.Employee_ID, s.Ngay order by s.UuTien
													   rows between unbounded preceding and 1 preceding), 0)
			from src s
			join phanboNgay p on p.Employee_ID = s.Employee_ID and p.Ngay = s.Ngay
			where p.A > 0
		)
		insert into @QuyDoi (Employee_ID, Ngay, MaCong, GioQuyDoi)
		select Employee_ID, Ngay, MaCong
			 , case when (A - truocDong) <= 0 then 0
					when wt < (A - truocDong) then wt
					else (A - truocDong) end
		from phanboDong
		where case when (A - truocDong) <= 0 then 0
				   when wt < (A - truocDong) then wt
				   else (A - truocDong) end > 0

		-- (1) Thêm dòng công KHÔNG có CN_ (phần đã đăng ký)
		insert into HR_WTdaily_GioDayDuLieu (Employee_ID, Ngay, MaCong, InsertSource, wt, Remark, InsertDate, UserName)
		select Employee_ID, Ngay, REPLACE(MaCong,'CN_','') , 'AutoK', GioQuyDoi, null, GETDATE(), ''
		from @QuyDoi

		-- (2) Trừ đúng số giờ đó khỏi dòng CN_ tương ứng (thay cho cách chèn dòng CN_ âm bù trừ
		--     của sp_TinhCong — cùng kết quả tổng, nhưng bảng công sạch hơn, không có dòng âm)
		update g
		set g.wt = g.wt - q.GioQuyDoi
		from HR_WTdaily_GioDayDuLieu g
		join @QuyDoi q
		  on q.Employee_ID = g.Employee_ID and q.Ngay = g.Ngay and q.MaCong = g.MaCong
		where g.InsertSource = 'Auto1'

		-- (3) Bỏ các dòng CN_ đã bị trừ hết
		delete g
		from HR_WTdaily_GioDayDuLieu g
		where g.Ngay between @NgayDauThang and @NgayCuoiThang
		  and g.MaCong in ('CN_wt3','CN_wt5') and isnull(g.wt,0) = 0
		--========================= HẾT XỬ LÝ GIỜ TĂNG CA ĐĂNG KÝ =========================

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
		--select 'a' as a
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
					WHERE LoaiGio = 'GR' and Thang = @Month and Nam = @Year
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
		on src.Employee_ID = wt.Employee_ID and src.AccessDate = wt.AccessDate and DATEADD(minute, DATEDIFF(minute, 0, src.AccessTime), 0) = DATEADD(minute, DATEDIFF(minute, 0, wt.AccessTime), 0)
		where wt.Employee_ID is null and src.AccessTime is not null
		
		--select 'a1' as a
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
					WHERE LoaiGio = 'GV' and Thang = @Month and Nam = @Year
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
		on src.Employee_ID = wt.Employee_ID and src.AccessDate = wt.AccessDate and DATEADD(minute, DATEDIFF(minute, 0, src.AccessTime), 0) = DATEADD(minute, DATEDIFF(minute, 0, wt.AccessTime), 0)
		where wt.Employee_ID is null and src.AccessTime is not null
		--select 'a2' as a
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
		
		--Xử lý phép
		Delete from HR_DangKyPhepTheoGio
		where /*Remark = 'Auto1' and*/ DateLeave between @NgayDauThang and @NgayCuoiThang

		exec sp_Insert_HR_BangPhepDaNghi @NgayDauThang, @NgayCuoiThang

		insert into HR_DangKyPhepTheoGio (Employee_ID, DateLeave, TypeOfLeave, HourLeave, LeaveType_ID, Remark, InsertDate, UserName)
		select src.Employee_ID, src.Ngay, 'Rasom' as TypeOfLeave, case when cast(GioNghi as float) = 0 then 8.0 else cast(GioNghi as float) end as GioNghi, lt.LeaveType_ID, 'Auto1' as Remark, GETDATE() as InsertDate, 'Auto' as UserName
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
					and gddl.LoaiGio = 'LN'
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
		left join
		HR_BangPhepDaNghi bpdn
		on src.Employee_ID = bpdn.Employee_ID and src.Ngay = bpdn.DateLeave --and bpdn.LeaveType_ID = 14
		where lt.LeaveType_ID is not null --and src.Employee_ID = 'MS2307'
				and isnull(bpdn.LeaveType_ID,14) = 14
		
		exec sp_Insert_HR_BangPhepDaNghi @NgayDauThang, @NgayCuoiThang

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

		Delete HR_SalaryComponentFollowMonth
		where SalaryComponent = 'CCNT' and UserName = 'Auto1' and Month_ = @Month and Year_ = @Year

		insert into HR_SalaryComponentFollowMonth (Employee_ID, SalaryComponent, Amount, Year_, Month_, Remark, InsertDate, UserName)
		select Employee_ID, 'CCNT', ChuyenCan, @Year, @Month, null, GETDATE(), 'Auto1'
		from
		HR_GioDayDuLieu
		where Thang = @Month and Nam = @Year and LoaiGio = 'GV'

		--insert into HR_SalaryCoponent ()
		
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
