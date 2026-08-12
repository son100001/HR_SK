
CREATE PROCEDURE [dbo].[sp_BangCongTheoThang]
	-- Add the parameters for the stored procedure here
	--exec sp_BangCongTheoThang 4,2023,1,'VN','admin'

	@Month int,
	@Year int,
	@TypeOfReport int=1, --1: all, 2: Thử việc, 3: chính thức, 4: Học việc, 5: Người Hàn, 6: Nghỉ việc, 7: Đang làm việc
	@LAN nvarchar(50)='VN',
	@UserName nvarchar(50),
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @NgayDauThang datetime,@NgayCuoiThang datetime,@TrangThaiKH bit, @NgayHuongCheDo float, @GioHoTroSinhLy float, @Nationality nvarchar(50), @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan int
	declare @tabCongNgay table(Employee_ID nvarchar(50), TypeOfWT nvarchar(50),day1 float,day2 float,day3 float,day4 float,day5 float,day6 float,day7 float,day8 float,day9 float,day10 float,day11 float,day12 float,day13 float,day14 float,day15 float,day16 float,day17 float,day18 float,day19 float,day20 float,day21 float,day22 float,day23 float,day24 float,day25 float,day26 float,day27 float,day28 float,day29 float,day30 float,day31 float, primary key (Employee_ID,TypeOfWT))
	--declare @tabTongHopCong table (Employee_ID nvarchar(50), TotalWT float, TotalOT float, TotalNightShift float, Total_wt3 float, TotalCongTruThu7 float, TotalCongTruDemThu7 float, Total_wt2 float, Total_wt9 float, Total_wt5 float, Total_wt10 float, Total_wt11 float, Total_wt12 float, Total_wt6 float, Total_wt13 float, Total_wt4 float, Total_wt15 float, Total_wt14 float, Total_wt8 float, Total_wt7 float, primary key (Employee_ID))
	declare @tabPhep table(Employee_ID nvarchar(50),p1 varchar(50),p2 varchar(50),p3 varchar(50),p4 varchar(50),p5 varchar(50),p6 varchar(50),p7 varchar(50),p8 varchar(50),p9 varchar(50),p10 varchar(50),p11 varchar(50),p12 varchar(50),p13 varchar(50),p14 varchar(50),p15 varchar(50),p16 varchar(50),p17 varchar(50),p18 varchar(50),p19 varchar(50),p20 varchar(50),p21 varchar(50),p22 varchar(50),p23 varchar(50),p24 varchar(50),p25 varchar(50),p26 varchar(50),p27 varchar(50),p28 varchar(50),p29 varchar(50),p30 varchar(50),p31 varchar(50),primary key(Employee_ID))
	--declare @tabPhepChiTiet table([Employee_ID] nvarchar(50),[LeaveType_ID] nvarchar(50),DateLeave datetime,HourLeave float,primary key ([Employee_ID],DateLeave))
	--declare @tabPhepTongHop
	select @Nationality = case when @TypeOfReport = 5 then 'Non-Vietnamese' else 'Vietnamese' end
	select @NgayHuongCheDo = Value from SetUp where ID = 'SoNgaySauKhiMangBauDuocHuongThaiSan'
	set @NgayDauThang=DATEFROMPARTS(@Year,@Month,1)
	set @NgayCuoiThang=DATEADD(month,1,@NgayDauThang)-1
	set @TrangThaiKH=[dbo].[udf_TrangThaiKH](@UserName)
	select @GioHoTroSinhLy = Value from HR_SetUpFollowDate where Group_ = 'MenstrualDay' and Fromdate <= @NgayCuoiThang and isnull(Todate,@NgayCuoiThang) >= @NgayCuoiThang order by Fromdate
	
	declare @rtn_BangCongTheoThang table (Employee_ID nvarchar(50), FullName nvarchar(255), FactoryName nvarchar(255),DepartmentName nvarchar(255),SectionName nvarchar(255)
								,PositionFullname nvarchar(255), orderBy int, PositionName nvarchar(255), StartedDate datetime, ContractDate datetime, TernimationDate datetime, TypeOfWT nvarchar(50)
								,GioTangCa1H float,TongGioTangCa float,SoNgayCongTV float,SoNgayCongCT float
								, day1 nvarchar(20), day2 nvarchar(20), day3 nvarchar(20), day4 nvarchar(20), day5 nvarchar(20), day6 nvarchar(20), day7 nvarchar(20), day8 nvarchar(20), day9 nvarchar(20), day10 nvarchar(20)
								, day11 nvarchar(20), day12 nvarchar(20), day13 nvarchar(20), day14 nvarchar(20), day15 nvarchar(20), day16 nvarchar(20), day17 nvarchar(20), day18 nvarchar(20), day19 nvarchar(20), day20 nvarchar(20)
								, day21 nvarchar(20), day22 nvarchar(20), day23 nvarchar(20), day24 nvarchar(20), day25 nvarchar(20), day26 nvarchar(20), day27 nvarchar(20), day28 nvarchar(20), day29 nvarchar(20), day30 nvarchar(20), day31 nvarchar(20)
								, Employee_ID1 nvarchar(50), Total_wt1 float, Total_wt2 float, Total_wt3 float, Total_wt4 float, Total_wt5 float, Total_wt6 float, Total_wt7 float, Total_wt8 float, Total_wt9 float, Total_wt10 float, Total_wt11 float, Total_wt12 float, Total_wt13 float, MenstrualDay float
								, NghiLe float, TongPN float, NghiKhongLuong float, NghiKhongPhep float
								, ThoiGianDiTreVeSom float, SoLanDiTreVeSom float, ThoiGianXinRaNgoai float, SoLanXinRaNgoai float,SoLanQuenQuetVanTay int, SoNgayCongTieuChuan float
								, Gio100CT float, Gio100TV float, PhepHuongLuong float, Gio130CT float, Gio130TV float, Gio150CT float, Gio150TV float, Gio200CT float, Gio200TV float, Gio210CT float, Gio210TV float, Gio270CT float, Gio270TV float, Gio300CT float, Gio300TV float, Gio390CT float, Gio390TV float, PhepNamConLai float, PhepNamTon float, primary key (Employee_ID,TypeOfWT))

	
	declare @rtnCaDem table (Employee_ID nvarchar(50), day1 nvarchar(20), day2 nvarchar(20), day3 nvarchar(20), day4 nvarchar(20), day5 nvarchar(20), day6 nvarchar(20), day7 nvarchar(20), day8 nvarchar(20), day9 nvarchar(20), day10 nvarchar(20)
								, day11 nvarchar(20), day12 nvarchar(20), day13 nvarchar(20), day14 nvarchar(20), day15 nvarchar(20), day16 nvarchar(20), day17 nvarchar(20), day18 nvarchar(20), day19 nvarchar(20), day20 nvarchar(20)
								, day21 nvarchar(20), day22 nvarchar(20), day23 nvarchar(20), day24 nvarchar(20), day25 nvarchar(20), day26 nvarchar(20), day27 nvarchar(20), day28 nvarchar(20), day29 nvarchar(20), day30 nvarchar(20), day31 nvarchar(20), primary key (Employee_ID))

	Declare @BangCongNghiViec bit
	if @TypeOfReport = 6 begin
		set @TypeOfReport = 1
		set @BangCongNghiViec = 1
	end else if @TypeOfReport = 7 begin
		set @TypeOfReport = 1
		set @BangCongNghiViec = 0
	end
	select @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan=[Value] from [dbo].[SetUp] where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
	if @TypeOfReport in (1,2,3,4) begin
		--Công tăng ca
		declare @tabCongTongHop table(Employee_ID nvarchar(50),TongGioTangCa float,GioTangCa1H float,SoNgayCongTV float,SoNgayCongCT float,primary key(Employee_ID))
		insert into @tabCongTongHop
		select empl.Employee_ID
			,SUM(case when isnull(lc.[isWorkingTime],0)=0 then wt.wt else 0 end) as TongTangCa
			,SUM(case when isnull(lc.[isWorkingTime],0)=0 and lc.MaCong not like 'CN%' then wt.wt else 0 end) as GioTangCa1H
			,SUM(case when nkhdct.NgayKyHDChinhThuc>wt.Ngay and isnull(lc.[isWorkingTime],0)=1 then wt.wt else 0 end)/8.0 + SUM(case when nkhdct.NgayKyHDChinhThuc>ptn.DateLeave and lt.isLeave_ComPay=1 then ptn.HourLeave else 0 end)/8.0 as SoNgayCongTV
			,SUM(case when nkhdct.NgayKyHDChinhThuc<=wt.Ngay and isnull(lc.[isWorkingTime],0)=1 then wt.wt else 0 end)/8.0 + SUM(case when nkhdct.NgayKyHDChinhThuc<=ptn.DateLeave and lt.isLeave_ComPay=1 then ptn.HourLeave else 0 end)/8.0 as SoNgayCongCT
		from
		smartbooks_employee empl
		left join
		udf_BangThoiGian(@ngaydauthang,@NgayCuoiThang) btg
		on empl.starteddate<=btg.date_ and (empl.TernimationDate is null or empl.TernimationDate>btg.date_)
		left join
		hr_wtdaily wt
		on empl.Employee_ID=wt.Employee_ID and btg.date_=wt.ngay
		left join
		udf_BangPhepTheoNgay(2,@ngaydauthang,@NgayCuoiThang,null,null,null,null,null,null,null,null) ptn
		on empl.Employee_ID=ptn.Employee_ID and btg.date_=ptn.dateleave
		left join
		SmartBooks_LeaveType lt
		on ptn.LeaveType_ID=lt.LeaveType_ID
		left join
		hr_loaicong lc
		on wt.MaCong=lc.MaCong
		left join
		udf_NgayKyHDChinhThuc (@NgayDauThang, @NgayCuoiThang, null) nkhdct
		on empl.Employee_ID=nkhdct.Employee_ID
		 group by empl.Employee_ID

		--Công chính thức ngày
		insert into @tabCongNgay
		select *
		from
		(
			select empl.Employee_ID, '1.WTDay(H)' as WT, 'day' + cast(day(wt.Ngay) as nvarchar(3)) as Ngay, sum(case when dkc.ShiftName not like '%Shift3' and lc.isWorkingTime=1 then wt else 0 end) as Gio
			from
			udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,@NgayCuoiThang) empl
			left join
			HR_WTDaily wt
			on empl.Employee_ID = wt.Employee_ID and ngay between @NgayDauThang and @NgayCuoiThang
			left join
			HR_LoaiCong lc
			on wt.MaCong=lc.MaCong
			left join
			udf_NgayKyHDChinhThuc(@NgayDauThang,@NgayCuoiThang,NULL)CT_TV
			on wt.Employee_ID=CT_TV.Employee_ID
			left join
			udf_NgayHetHanHDThuViec(@NgayDauThang,@NgayCuoiThang,NULL) HHHDTV
			on wt.Employee_ID = HHHDTV.Employee_ID
			left join
			udf_DangKyCa (@NgayDauThang,@NgayCuoiThang,@NgayHuongCheDo,null,null,null,null,null,null,null) dkc
			on empl.Employee_ID = dkc.Employee_ID and wt.Ngay = dkc.AccessDate
			where isnull(empl.Nationality,'Vietnamese') = @Nationality and empl.StartedDate <= @NgayCuoiThang and isnull(empl.TernimationDate,'3099-1-1') >= @NgayDauThang
				and (
						(@TrangThaiKH=1 and wt.MaCong not like 'cn%')
						or @TrangThaiKH=0
					)
				and (
						(@TypeOfReport=2 and wt.Ngay<=  (case when HHHDTV.NgayHetHanHDThuViec = CT_TV.NgayKyHDChinhThuc then DATEADD(day, -1, HHHDTV.NgayHetHanHDThuViec) else HHHDTV.NgayHetHanHDThuViec end) /*and isnull(empl.isThuViec85PhanTram,0)=1*/)
						or (@TypeOfReport=3 and (wt.Ngay>=CT_TV.NgayKyHDChinhThuc /*or isnull(empl.isThuViec85PhanTram,0)=0*/))
						or (@TypeOfReport = 4 and wt.Ngay > HHHDTV.NgayHetHanHDThuViec and wt.Ngay < CT_TV.NgayKyHDChinhThuc)
						or @TypeOfReport=1
					) or wt.Employee_ID is null
			group by empl.Employee_ID, Ngay
		) TableSource
		pivot
		(
			sum(Gio)
			For Ngay in ([day1],[day2],[day3],[day4],[day5],[day6],[day7],[day8],[day9],[day10],[day11],[day12],[day13],[day14],[day15],[day16],[day17],[day18],[day19],[day20],[day21],[day22],[day23],[day24],[day25],[day26],[day27],[day28],[day29],[day30],[day31])
		) as PivotTable
		
		-- Công tăng ca ngày
		--declare @NgayDauThang datetime = '2021-2-1', @NgayCuoiThang datetime = '2021-2-28', @TrangThaiKH bit = 0
		insert into @tabCongNgay	
		select *
		from
		(
			select empl.Employee_ID, '2.OTDay(H)' as WT, 'day' + cast(day(wt.Ngay) as nvarchar(3)) as Ngay, sum(case when dkc.ShiftName not like '%Shift3' and isnull(lc.isWorkingTime,0)=0 then wt else 0 end) as Gio
			from
			udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,@NgayCuoiThang) empl
			left join
			HR_WTDaily wt
			on empl.Employee_ID = wt.Employee_ID and ngay between @NgayDauThang and @NgayCuoiThang
			left join
			HR_LoaiCong lc
			on wt.MaCong=lc.MaCong
			left join
			udf_NgayKyHDChinhThuc(@NgayDauThang,@NgayCuoiThang,NULL)CT_TV
			on wt.Employee_ID=CT_TV.Employee_ID
			left join
			udf_NgayHetHanHDThuViec(@NgayDauThang,@NgayCuoiThang,NULL) HHHDTV
			on wt.Employee_ID = HHHDTV.Employee_ID
			left join
			udf_DangKyCa (@NgayDauThang,@NgayCuoiThang,@NgayHuongCheDo,null,null,null,null,null,null,null) dkc
			on empl.Employee_ID = dkc.Employee_ID and wt.Ngay = dkc.AccessDate
			where isnull(empl.Nationality,'Vietnamese') = @Nationality and empl.StartedDate <= @NgayCuoiThang and isnull(empl.TernimationDate,'3099-1-1') >= @NgayDauThang
				and (
						(@TrangThaiKH=1 and wt.MaCong not like 'cn%')
						or @TrangThaiKH=0
					)
				and (
						(@TypeOfReport=2 and wt.Ngay<=  (case when HHHDTV.NgayHetHanHDThuViec = CT_TV.NgayKyHDChinhThuc then DATEADD(day, -1, HHHDTV.NgayHetHanHDThuViec) else HHHDTV.NgayHetHanHDThuViec end) /*and isnull(empl.isThuViec85PhanTram,0)=1*/)
						or (@TypeOfReport=3 and (wt.Ngay>=CT_TV.NgayKyHDChinhThuc /*or isnull(empl.isThuViec85PhanTram,0)=0*/))
						or (@TypeOfReport = 4 and wt.Ngay > HHHDTV.NgayHetHanHDThuViec and wt.Ngay < CT_TV.NgayKyHDChinhThuc)
						or @TypeOfReport=1
					) or wt.Employee_ID is null
			group by empl.Employee_ID, Ngay
		) TableSource
		pivot
		(
			sum(Gio)
			For Ngay in ([day1],[day2],[day3],[day4],[day5],[day6],[day7],[day8],[day9],[day10],[day11],[day12],[day13],[day14],[day15],[day16],[day17],[day18],[day19],[day20],[day21],[day22],[day23],[day24],[day25],[day26],[day27],[day28],[day29],[day30],[day31])
		) as PivotTable

		--Công chính thức đêm
		insert into @tabCongNgay
		select *
		from
		(
			select empl.Employee_ID, '3.WTNight(H)' as WT, 'day' + cast(day(wt.Ngay) as nvarchar(3)) as Ngay, sum(case when dkc.ShiftName like '%Shift3' and lc.isWorkingTime=1 then wt else 0 end) as Gio
			from
			udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,@NgayCuoiThang) empl
			left join
			HR_WTDaily wt
			on empl.Employee_ID = wt.Employee_ID and ngay between @NgayDauThang and @NgayCuoiThang
			left join
			HR_LoaiCong lc
			on wt.MaCong=lc.MaCong
			left join
			udf_NgayKyHDChinhThuc(@NgayDauThang,@NgayCuoiThang,NULL)CT_TV
			on wt.Employee_ID=CT_TV.Employee_ID
			left join
			udf_NgayHetHanHDThuViec(@NgayDauThang,@NgayCuoiThang,NULL) HHHDTV
			on wt.Employee_ID = HHHDTV.Employee_ID
			left join
			udf_DangKyCa (@NgayDauThang,@NgayCuoiThang,@NgayHuongCheDo,null,null,null,null,null,null,null) dkc
			on empl.Employee_ID = dkc.Employee_ID and wt.Ngay = dkc.AccessDate
			where isnull(empl.Nationality,'Vietnamese') = @Nationality and empl.StartedDate <= @NgayCuoiThang and isnull(empl.TernimationDate,'3099-1-1') >= @NgayDauThang
				and (
						(@TrangThaiKH=1 and wt.MaCong not like 'cn%')
						or @TrangThaiKH=0
					)
				and (
						(@TypeOfReport=2 and wt.Ngay<=  (case when HHHDTV.NgayHetHanHDThuViec = CT_TV.NgayKyHDChinhThuc then DATEADD(day, -1, HHHDTV.NgayHetHanHDThuViec) else HHHDTV.NgayHetHanHDThuViec end) /*and isnull(empl.isThuViec85PhanTram,0)=1*/)
						or (@TypeOfReport=3 and (wt.Ngay>=CT_TV.NgayKyHDChinhThuc /*or isnull(empl.isThuViec85PhanTram,0)=0*/))
						or (@TypeOfReport = 4 and wt.Ngay > HHHDTV.NgayHetHanHDThuViec and wt.Ngay < CT_TV.NgayKyHDChinhThuc)
						or @TypeOfReport=1
					) or wt.Employee_ID is null
			group by empl.Employee_ID, Ngay
		) TableSource
		pivot
		(
			sum(Gio)
			For Ngay in ([day1],[day2],[day3],[day4],[day5],[day6],[day7],[day8],[day9],[day10],[day11],[day12],[day13],[day14],[day15],[day16],[day17],[day18],[day19],[day20],[day21],[day22],[day23],[day24],[day25],[day26],[day27],[day28],[day29],[day30],[day31])
		) as PivotTable
		
		-- Công tăng ca đêm
		--declare @NgayDauThang datetime = '2021-2-1', @NgayCuoiThang datetime = '2021-2-28', @TrangThaiKH bit = 0
		insert into @tabCongNgay	
		select *
		from
		(
			select empl.Employee_ID, '4.OTNight(H)' as WT, 'day' + cast(day(wt.Ngay) as nvarchar(3)) as Ngay, sum(case when dkc.ShiftName like '%Shift3' and isnull(lc.isWorkingTime,0)=0 then wt else 0 end) as Gio
			from
			udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,@NgayCuoiThang) empl
			left join
			HR_WTDaily wt
			on empl.Employee_ID = wt.Employee_ID and ngay between @NgayDauThang and @NgayCuoiThang
			left join
			HR_LoaiCong lc
			on wt.MaCong=lc.MaCong
			left join
			udf_NgayKyHDChinhThuc(@NgayDauThang,@NgayCuoiThang,NULL)CT_TV
			on wt.Employee_ID=CT_TV.Employee_ID
			left join
			udf_NgayHetHanHDThuViec(@NgayDauThang,@NgayCuoiThang,NULL) HHHDTV
			on wt.Employee_ID = HHHDTV.Employee_ID
			left join
			udf_DangKyCa (@NgayDauThang,@NgayCuoiThang,@NgayHuongCheDo,null,null,null,null,null,null,null) dkc
			on empl.Employee_ID = dkc.Employee_ID and wt.Ngay = dkc.AccessDate
			where isnull(empl.Nationality,'Vietnamese') = @Nationality and empl.StartedDate <= @NgayCuoiThang and isnull(empl.TernimationDate,'3099-1-1') >= @NgayDauThang
				and (
						(@TrangThaiKH=1 and wt.MaCong not like 'cn%')
						or @TrangThaiKH=0
					)
				and (
						(@TypeOfReport=2 and wt.Ngay<=  (case when HHHDTV.NgayHetHanHDThuViec = CT_TV.NgayKyHDChinhThuc then DATEADD(day, -1, HHHDTV.NgayHetHanHDThuViec) else HHHDTV.NgayHetHanHDThuViec end) /*and isnull(empl.isThuViec85PhanTram,0)=1*/)
						or (@TypeOfReport=3 and (wt.Ngay>=CT_TV.NgayKyHDChinhThuc /*or isnull(empl.isThuViec85PhanTram,0)=0*/))
						or (@TypeOfReport = 4 and wt.Ngay > HHHDTV.NgayHetHanHDThuViec and wt.Ngay < CT_TV.NgayKyHDChinhThuc)
						or @TypeOfReport=1
					) or wt.Employee_ID is null
			group by empl.Employee_ID, Ngay
		) TableSource
		pivot
		(
			sum(Gio)
			For Ngay in ([day1],[day2],[day3],[day4],[day5],[day6],[day7],[day8],[day9],[day10],[day11],[day12],[day13],[day14],[day15],[day16],[day17],[day18],[day19],[day20],[day21],[day22],[day23],[day24],[day25],[day26],[day27],[day28],[day29],[day30],[day31])
		) as PivotTable

		-- ĐẾM ĐI MUỘN VỀ SỚM VÀ NGHỈ KHÔNG PHÉP
		DECLARE @tabDemDiMuonVeSomPhepKL table(Employee_ID nvarchar(50),SoLanDMVS_NghiKL_CT int,SoLanDMVS_NghiKL_TV int, SoLanQuenQuetThe_CT int, SoLanQuenQuetThe_TV int, ThoiGianDMVS float, Primary key(Employee_ID))
		insert into @tabDemDiMuonVeSomPhepKL
		select dmvs.Employee_ID,isnull(SoLanDiTreVeSom_CT,0)+isnull(SoLanXinRaNgoai_CT,0) as SoLanDMVS_NghiKL_CT,isnull(SoLanDiTreVeSom_TV,0)+isnull(SoLanXinRaNgoai_TV,0) as SoLanDMVS_NghiKL_TV, SoLanQuenQuetVanTay_CT, SoLanQuenQuetVanTay_TV, dmvs.ThoiGianDiTreVeSom_CT + dmvs.ThoiGianDiTreVeSom_TV
		from 
		[dbo].[udf_DiTreVeSomVaXinRaNgoai](@NgayDauThang,@NgayCuoiThang,'VN',NULL,NULL,NULL,NULL,NULL,NULL,NULL) dmvs

		--declare @NgayDauThang datetime = '2021-2-1', @NgayCuoiThang datetime = '2021-2-28', @fact nvarchar(50) = null, @dept nvarchar(50) = null, @sect nvarchar(50) = null, @team nvarchar(50) = null, @pos nvarchar(50) = null, @posc nvarchar(50) = null
		insert into @tabPhep
		select Employee_ID,p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16,p17,p18,p19,p20,p21,p22,p23,p24,p25,p26,p27,p28,p29,p30,p31
		from
		(
		select ptn.Employee_ID, (case when dkc.ShiftName like '%Shift3' then 'd' else 'n' end) + (case when l.AbsentSign='AL/2' then l.AbsentSign else l.AbsentSign+(case when ptn.HourLeave=8 then '' else '.'+cast(ptn.HourLeave as varchar(50)) end) end) as AbsentSign
		, 'p' + cast(day(ptn.DateLeave) as nvarchar(3)) as p
		from
		udf_BangPhepTheoNgay(2,@NgayDauThang,@NgayCuoiThang,@fact,@dept,@sect,@team,@pos,@posc,null,null) ptn
		left join
		udf_NgayKyHDChinhThuc(@NgayDauThang,@NgayCuoiThang,NULL)CT_TV
		on ptn.Employee_ID=CT_TV.Employee_ID
		left join
		udf_NgayHetHanHDThuViec(@NgayDauThang,@NgayCuoiThang,NULL) HHHDTV
		on ptn.Employee_ID = HHHDTV.Employee_ID
		left join
		SmartBooks_LeaveType l
		on ptn.LeaveType_ID=l.LeaveType_ID
		left join
		SmartBooks_Employee empl
		on ptn.Employee_ID = empl.Employee_ID
		left join
		udf_DangKyCa (@NgayDauThang,@NgayCuoiThang,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan,@fact,@dept,@sect,@team,@pos,@posc,null) dkc
		on ptn.Employee_ID = dkc.Employee_ID and ptn.DateLeave = dkc.AccessDate
		where	isnull(empl.Nationality,'Vietnamese') = @Nationality and (
					(@TypeOfReport=2 and ptn.DateLeave <=  (case when HHHDTV.NgayHetHanHDThuViec = CT_TV.NgayKyHDChinhThuc then DATEADD(day, -1, HHHDTV.NgayHetHanHDThuViec) else HHHDTV.NgayHetHanHDThuViec end) /*and isnull(empl.isThuViec85PhanTram,0)=1*/)
					or (@TypeOfReport=3 and (ptn.DateLeave >=CT_TV.NgayKyHDChinhThuc /*or isnull(empl.isThuViec85PhanTram,0)=0*/))
					or (@TypeOfReport = 4 and ptn.DateLeave > HHHDTV.NgayHetHanHDThuViec and ptn.DateLeave < CT_TV.NgayKyHDChinhThuc)
					or @TypeOfReport=1
				)
		) st
		pivot
		(
			max(AbsentSign) for p in (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16,p17,p18,p19,p20,p21,p22,p23,p24,p25,p26,p27,p28,p29,p30,p31)
		) as pvtable
		
		--select * from @tabPhep
		
		insert into @rtn_BangCongTheoThang
		select
		empl.Employee_ID
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		,empl.FactoryName,empl.DepartmentName,empl.SectionName,empl.PositionFullname,f.OrderBy, empl.PositionName,empl.StartedDate, hdct.NgayKyHDChinhThuc, empl.TernimationDate, cn.TypeOfWT
		,cth.GioTangCa1H,cth.TongGioTangCa,cth.SoNgayCongTV,cth.SoNgayCongCT
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p1,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p1,''),1) = 'd') then SubString(p.p1,2,10)+ (case when isnull(cn.day1,0) <> 8 and isnull(cn.day1,0) <> 0 then '-' + cast(cn.day1 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p1,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p1,'d'),1) = 'd') then isnull(cast(cn.day1 as nvarchar(5)),substring(isnull(p.p1,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day1 as nvarchar(5)) end) as day1
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p2,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p2,''),1) = 'd') then SubString(p.p2,2,10)+ (case when isnull(cn.day2,0) <> 8 and isnull(cn.day2,0) <> 0 then '-' + cast(cn.day2 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p2,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p2,'d'),1) = 'd') then isnull(cast(cn.day2 as nvarchar(5)),substring(isnull(p.p2,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day2 as nvarchar(5)) end) as day2
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p3,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p3,''),1) = 'd') then SubString(p.p3,2,10)+ (case when isnull(cn.day3,0) <> 8 and isnull(cn.day3,0) <> 0 then '-' + cast(cn.day3 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p3,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p3,'d'),1) = 'd') then isnull(cast(cn.day3 as nvarchar(5)),substring(isnull(p.p3,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day3 as nvarchar(5)) end) as day3
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p4,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p4,''),1) = 'd') then SubString(p.p4,2,10)+ (case when isnull(cn.day4,0) <> 8 and isnull(cn.day4,0) <> 0 then '-' + cast(cn.day4 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p4,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p4,'d'),1) = 'd') then isnull(cast(cn.day4 as nvarchar(5)),substring(isnull(p.p4,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day4 as nvarchar(5)) end) as day4
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p5,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p5,''),1) = 'd') then SubString(p.p5,2,10)+ (case when isnull(cn.day5,0) <> 8 and isnull(cn.day5,0) <> 0 then '-' + cast(cn.day5 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p5,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p5,'d'),1) = 'd') then isnull(cast(cn.day5 as nvarchar(5)),substring(isnull(p.p5,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day5 as nvarchar(5)) end) as day5
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p6,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p6,''),1) = 'd') then SubString(p.p6,2,10)+ (case when isnull(cn.day6,0) <> 8 and isnull(cn.day6,0) <> 0 then '-' + cast(cn.day6 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p6,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p6,'d'),1) = 'd') then isnull(cast(cn.day6 as nvarchar(5)),substring(isnull(p.p6,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day6 as nvarchar(5)) end) as day6
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p7,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p7,''),1) = 'd') then SubString(p.p7,2,10)+ (case when isnull(cn.day7,0) <> 8 and isnull(cn.day7,0) <> 0 then '-' + cast(cn.day7 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p7,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p7,'d'),1) = 'd') then isnull(cast(cn.day7 as nvarchar(5)),substring(isnull(p.p7,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day7 as nvarchar(5)) end) as day7
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p8,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p8,''),1) = 'd') then SubString(p.p8,2,10)+ (case when isnull(cn.day8,0) <> 8 and isnull(cn.day8,0) <> 0 then '-' + cast(cn.day8 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p8,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p8,'d'),1) = 'd') then isnull(cast(cn.day8 as nvarchar(5)),substring(isnull(p.p8,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day8 as nvarchar(5)) end) as day8
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p9,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p9,''),1) = 'd') then SubString(p.p9,2,10)+ (case when isnull(cn.day9,0) <> 8 and isnull(cn.day9,0) <> 0 then '-' + cast(cn.day9 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p9,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p9,'d'),1) = 'd') then isnull(cast(cn.day9 as nvarchar(5)),substring(isnull(p.p9,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day9 as nvarchar(5)) end) as day9
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p10,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p10,''),1) = 'd') then SubString(p.p10,2,10) + (case when isnull(cn.day10,0) <> 8 and isnull(cn.day10,0) <> 0 then '-' + cast(cn.day10 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p10,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p10,'d'),1) = 'd') then isnull(cast(cn.day10 as nvarchar(5)),substring(isnull(p.p10,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day10 as nvarchar(5)) end) as day10
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p11,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p11,''),1) = 'd') then SubString(p.p11,2,10) + (case when isnull(cn.day11,0) <> 8 and isnull(cn.day11,0) <> 0 then '-' + cast(cn.day11 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p11,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p11,'d'),1) = 'd') then isnull(cast(cn.day11 as nvarchar(5)),substring(isnull(p.p11,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day11 as nvarchar(5)) end) as day11
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p12,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p12,''),1) = 'd') then SubString(p.p12,2,10) + (case when isnull(cn.day12,0) <> 8 and isnull(cn.day12,0) <> 0 then '-' + cast(cn.day12 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p12,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p12,'d'),1) = 'd') then isnull(cast(cn.day12 as nvarchar(5)),substring(isnull(p.p12,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day12 as nvarchar(5)) end) as day12
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p13,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p13,''),1) = 'd') then SubString(p.p13,2,10) + (case when isnull(cn.day13,0) <> 8 and isnull(cn.day13,0) <> 0 then '-' + cast(cn.day13 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p13,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p13,'d'),1) = 'd') then isnull(cast(cn.day13 as nvarchar(5)),substring(isnull(p.p13,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day13 as nvarchar(5)) end) as day13
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p14,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p14,''),1) = 'd') then SubString(p.p14,2,10) + (case when isnull(cn.day14,0) <> 8 and isnull(cn.day14,0) <> 0 then '-' + cast(cn.day14 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p14,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p14,'d'),1) = 'd') then isnull(cast(cn.day14 as nvarchar(5)),substring(isnull(p.p14,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day14 as nvarchar(5)) end) as day14
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p15,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p15,''),1) = 'd') then SubString(p.p15,2,10) + (case when isnull(cn.day15,0) <> 8 and isnull(cn.day15,0) <> 0 then '-' + cast(cn.day15 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p15,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p15,'d'),1) = 'd') then isnull(cast(cn.day15 as nvarchar(5)),substring(isnull(p.p15,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day15 as nvarchar(5)) end) as day15
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p16,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p16,''),1) = 'd') then SubString(p.p16,2,10) + (case when isnull(cn.day16,0) <> 8 and isnull(cn.day16,0) <> 0 then '-' + cast(cn.day16 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p16,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p16,'d'),1) = 'd') then isnull(cast(cn.day16 as nvarchar(5)),substring(isnull(p.p16,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day16 as nvarchar(5)) end) as day16
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p17,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p17,''),1) = 'd') then SubString(p.p17,2,10) + (case when isnull(cn.day17,0) <> 8 and isnull(cn.day17,0) <> 0 then '-' + cast(cn.day17 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p17,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p17,'d'),1) = 'd') then isnull(cast(cn.day17 as nvarchar(5)),substring(isnull(p.p17,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day17 as nvarchar(5)) end) as day17
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p18,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p18,''),1) = 'd') then SubString(p.p18,2,10) + (case when isnull(cn.day18,0) <> 8 and isnull(cn.day18,0) <> 0 then '-' + cast(cn.day18 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p18,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p18,'d'),1) = 'd') then isnull(cast(cn.day18 as nvarchar(5)),substring(isnull(p.p18,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day18 as nvarchar(5)) end) as day18
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p19,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p19,''),1) = 'd') then SubString(p.p19,2,10) + (case when isnull(cn.day19,0) <> 8 and isnull(cn.day19,0) <> 0 then '-' + cast(cn.day19 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p19,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p19,'d'),1) = 'd') then isnull(cast(cn.day19 as nvarchar(5)),substring(isnull(p.p19,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day19 as nvarchar(5)) end) as day19
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p20,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p20,''),1) = 'd') then SubString(p.p20,2,10) + (case when isnull(cn.day20,0) <> 8 and isnull(cn.day20,0) <> 0 then '-' + cast(cn.day20 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p20,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p20,'d'),1) = 'd') then isnull(cast(cn.day20 as nvarchar(5)),substring(isnull(p.p20,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day20 as nvarchar(5)) end) as day20
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p21,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p21,''),1) = 'd') then SubString(p.p21,2,10) + (case when isnull(cn.day21,0) <> 8 and isnull(cn.day21,0) <> 0 then '-' + cast(cn.day21 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p21,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p21,'d'),1) = 'd') then isnull(cast(cn.day21 as nvarchar(5)),substring(isnull(p.p21,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day21 as nvarchar(5)) end) as day21
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p22,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p22,''),1) = 'd') then SubString(p.p22,2,10) + (case when isnull(cn.day22,0) <> 8 and isnull(cn.day22,0) <> 0 then '-' + cast(cn.day22 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p22,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p22,'d'),1) = 'd') then isnull(cast(cn.day22 as nvarchar(5)),substring(isnull(p.p22,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day22 as nvarchar(5)) end) as day22
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p23,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p23,''),1) = 'd') then SubString(p.p23,2,10) + (case when isnull(cn.day23,0) <> 8 and isnull(cn.day23,0) <> 0 then '-' + cast(cn.day23 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p23,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p23,'d'),1) = 'd') then isnull(cast(cn.day23 as nvarchar(5)),substring(isnull(p.p23,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day23 as nvarchar(5)) end) as day23
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p24,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p24,''),1) = 'd') then SubString(p.p24,2,10) + (case when isnull(cn.day24,0) <> 8 and isnull(cn.day24,0) <> 0 then '-' + cast(cn.day24 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p24,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p24,'d'),1) = 'd') then isnull(cast(cn.day24 as nvarchar(5)),substring(isnull(p.p24,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day24 as nvarchar(5)) end) as day24
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p25,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p25,''),1) = 'd') then SubString(p.p25,2,10) + (case when isnull(cn.day25,0) <> 8 and isnull(cn.day25,0) <> 0 then '-' + cast(cn.day25 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p25,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p25,'d'),1) = 'd') then isnull(cast(cn.day25 as nvarchar(5)),substring(isnull(p.p25,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day25 as nvarchar(5)) end) as day25
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p26,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p26,''),1) = 'd') then SubString(p.p26,2,10) + (case when isnull(cn.day26,0) <> 8 and isnull(cn.day26,0) <> 0 then '-' + cast(cn.day26 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p26,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p26,'d'),1) = 'd') then isnull(cast(cn.day26 as nvarchar(5)),substring(isnull(p.p26,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day26 as nvarchar(5)) end) as day26
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p27,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p27,''),1) = 'd') then SubString(p.p27,2,10) + (case when isnull(cn.day27,0) <> 8 and isnull(cn.day27,0) <> 0 then '-' + cast(cn.day27 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p27,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p27,'d'),1) = 'd') then isnull(cast(cn.day27 as nvarchar(5)),substring(isnull(p.p27,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day27 as nvarchar(5)) end) as day27
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p28,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p28,''),1) = 'd') then SubString(p.p28,2,10) + (case when isnull(cn.day28,0) <> 8 and isnull(cn.day28,0) <> 0 then '-' + cast(cn.day28 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p28,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p28,'d'),1) = 'd') then isnull(cast(cn.day28 as nvarchar(5)),substring(isnull(p.p28,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day28 as nvarchar(5)) end) as day28
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p29,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p29,''),1) = 'd') then SubString(p.p29,2,10) + (case when isnull(cn.day29,0) <> 8 and isnull(cn.day29,0) <> 0 then '-' + cast(cn.day29 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p29,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p29,'d'),1) = 'd') then isnull(cast(cn.day29 as nvarchar(5)),substring(isnull(p.p29,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day29 as nvarchar(5)) end) as day29
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p30,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p30,''),1) = 'd') then SubString(p.p30,2,10) + (case when isnull(cn.day30,0) <> 8 and isnull(cn.day30,0) <> 0 then '-' + cast(cn.day30 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p30,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p30,'d'),1) = 'd') then isnull(cast(cn.day30 as nvarchar(5)),substring(isnull(p.p30,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day30 as nvarchar(5)) end) as day30
		,(case when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p31,''),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p31,''),1) = 'd') then SubString(p.p31,2,10) + (case when isnull(cn.day31,0) <> 8 and isnull(cn.day31,0) <> 0 then '-' + cast(cn.day31 as nvarchar(5)) else '' end) when (cn.TypeOfWT = '1.WTDay(H)' and left(isnull(p.p31,'n'),1) = 'n') or (cn.TypeOfWT = '3.WTNight(H)' and left(isnull(p.p31,'d'),1) = 'd') then isnull(cast(cn.day31 as nvarchar(5)),substring(isnull(p.p31,''),2,10)) when cn.TypeOfWT in ('2.OTDay(H)','4.OTNight(H)') then cast(cn.day31 as nvarchar(5)) end) as day31
		,thc.*, case when erp.Employee_ID is not null then 0 when Upper(empl.Sex) = 'FEMALE' and isnull(thc.wt1,0) + isnull(thc.wt9,0) > 0 and isnull(empl.TernimationDate,@NgayCuoiThang) not between @NgayDauThang and DATEFROMPARTS(year(@NgayDauThang),Month(@NgayDauThang),15) then @GioHoTroSinhLy else 0 end as MenstrualDay
		, isnull(thp.NghiLe,0)/8.0 as NghiLe, isnull(thp.PhepNam,0)/8.0 as TongPN, isnull(thp.NghiKhongLuong,0) as NghiKhongLuong, isnull(thp.KhongPhep,0) as KhongPhep
		, (case when dtvs.SoLanDiTreVeSom_CT + dtvs.SoLanDiTreVeSom_TV > 2 then dtvs.ThoiGianDiTreVeSom_CT + dtvs.ThoiGianDiTreVeSom_TV else 0 end) as ThoiGianDiTreVeSom, (case when dtvs.SoLanDiTreVeSom_CT + dtvs.SoLanDiTreVeSom_TV > 2 then dtvs.SoLanDiTreVeSom_CT + dtvs.SoLanDiTreVeSom_TV else 0 end) as SoLanDiTreVeSom, dtvs.ThoiGianXinRaNgoai_CT + dtvs.ThoiGianXinRaNgoai_TV as ThoiGianXinRaNgoai, dtvs.SoLanXinRaNgoai_CT + dtvs.SoLanXinRaNgoai_TV as SoLanXinRaNgoai,dtvs.SoLanQuenQuetVanTay_CT + dtvs.SoLanQuenQuetVanTay_TV as SoLanQuenQuetVanTay
		,[dbo].[udf_CountDayExceptSunday](@ngaydauthang,@ngaycuoithang) as SoNgayCongTieuChuan
		,(isnull(cct.wt1,0) + isnull(cct.wt9,0))/8.0 /*+ isnull(pct.PhepHuongLuong,0)*/ as Gio100CT, (isnull(ctv.wt1,0) + isnull(ctv.wt9,0))/8.0 /*+ isnull(ptv.PhepHuongLuong,0)*/ as Gio100TV, isnull(thp.PhepHuongLuong,0)/8.0 as PhepHuongLuong, isnull(cct.wt9,0) as Gio130CT, isnull(ctv.wt9,0) as Gio130TV, isnull(cct.wt3,0) as Gio150CT, isnull(ctv.wt3,0) as Gio150TV, isnull(cct.wt4,0) as Gio200CT, isnull(ctv.wt4,0) as Gio200TV, isnull(cct.wt5,0) as Gio210CT, isnull(ctv.wt5,0) as Gio210TV, isnull(cct.wt6,0) as Gio270CT, isnull(ctv.wt6,0) as Gio270TV, isnull(cct.wt7,0) as Gio300CT, isnull(ctv.wt7,0) as Gio300TV, isnull(cct.wt8,0) as Gio390CT, isnull(ctv.wt8,0) as Gio390TV
		,qlpn.PhepNamConLai, qlpn.PhepNamTon
		from
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@NgayCuoiThang) empl
		left join
		HR_Factory f
		on empl.Factory_ID = f.Factory_ID
		left join
		@tabCongNgay cn
		on empl.Employee_ID=cn.Employee_ID
		left join
		@tabPhep p
		on empl.Employee_ID=p.Employee_ID
		left join
		(
			select empl.Employee_ID, thc.wt1, thc.wt2, thc.wt3, thc.wt4, thc.wt5, thc.wt6, thc.wt7, thc.wt8, thc.wt9, thc.wt10, thc.wt11, thc.wt12, thc.wt13--, thc.wt14, thc.wt15
			from 
			udf_EmployeeFilter (@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@NgayCuoiThang) empl
			left join
			udf_TongHopCong(@NgayDauThang,@NgayCuoiThang,@TypeOfReport,@UserName) thc
			on empl.Employee_ID = thc.Employee_ID
			/*left join
			udf_TongHopPhep(@NgayDauThang,@NgayCuoiThang,@TypeOfReport) thp
			on empl.Employee_ID = thp.Employee_ID*/
		) thc
		on empl.Employee_ID = thc.Employee_ID
		left join
		udf_TongHopPhep(@NgayDauThang,@NgayCuoiThang,@TypeOfReport) thp
		on empl.Employee_ID=thp.Employee_ID
		left join
		udf_TongHopPhep(@NgayDauThang,@NgayCuoiThang,3) pct
		on empl.Employee_ID=pct.Employee_ID
		left join
		udf_TongHopPhep(@NgayDauThang,@NgayCuoiThang,2) ptv
		on empl.Employee_ID=ptv.Employee_ID
		left join
		udf_TongHopCong(@NgayDauThang,@NgayCuoiThang,3,@UserName) cct
		on empl.Employee_ID = cct.Employee_ID
		left join
		udf_TongHopCong(@NgayDauThang,@NgayCuoiThang,2,@UserName) ctv
		on empl.Employee_ID = ctv.Employee_ID
		left join
		HR_EmployeeRegisMaternityLeave erml
		on empl.Employee_ID=erml.Employee_ID and erml.LeaveType_ID='24' and erml.Fromdate<=@NgayDauThang and erml.ToDate>=@NgayCuoiThang
		left join
		HR_EmployeeRegisPregnant erp
		on empl.Employee_ID = erp.Employee_ID and @NgayCuoiThang between erp.Fromdate and isnull (erp.MiscarriageDate, erp.ToDate)
		left join
		@tabDemDiMuonVeSomPhepKL dmvs_PhepKL
		on empl.Employee_ID=dmvs_PhepKL.Employee_ID
		left join
		udf_DiTreVeSomVaXinRaNgoai (@NgayDauThang,@NgayCuoiThang,@LAN,@fact,@dept,@sect,@team,@pos,@posc,null) dtvs
		on empl.Employee_ID = dtvs.Employee_ID
		left join
		udf_NgayKyHDChinhThuc(@NgayDauThang,@NgayCuoiThang,NULL) hdct
		on empl.Employee_ID=hdct.Employee_ID
		left join
		@tabCongTongHop cth
		on empl.Employee_ID=cth.Employee_ID
		left join
		[dbo].[udf_BangLuongCoDinh](@NgayCuoiThang,null) lcd
		on empl.Employee_ID=lcd.Employee_ID
		left join
		[dbo].[udf_BangLuongCoDinh](@NgayDauThang,null) ldt
		on empl.Employee_ID=ldt.Employee_ID
		left join
		udf_QuanLyPhepNam(@Year,@NgayCuoiThang,@LAN,@fact,@dept,@sect,@team,@pos,@posc,null) qlpn
		on empl.Employee_ID = qlpn.Employee_ID
		where empl.StartedDate<=@NgayCuoiThang /*and (empl.TernimationDate is null or empl.TernimationDate>@NgayDauThang)*/ and (empl.ThangTinhLuong is null or empl.ThangTinhLuong between @NgayDauThang and @NgayCuoiThang)
			and erml.Employee_ID is null
			and isnull(TernimationDate,@NgayCuoiThang + 2) between (case when isnull(@BangCongNghiViec,0) = 1 then @NgayDauThang + 1 else @NgayCuoiThang + 2 end) and (case when isnull(@BangCongNghiViec,0) = 1 then @NgayCuoiThang else @NgayCuoiThang + 2 end)
		
		insert into @rtnCaDem
		select *
		from 
		(
			select dkc.Employee_ID, 'day' + cast(day(AccessDate) as nvarchar(3)) as Ngay, case when ShiftName like '%Shift3' then N'Đ' else '' end as ShiftName
			from udf_DangKyCa (@NgayDauThang,@NgayCuoiThang,@NgayHuongCheDo,null,null,null,null,null,null,null) dkc
			left join
			SmartBooks_Employee empl
			on dkc.Employee_ID = empl.Employee_ID
			where isnull(empl.Nationality,'Vietnamese') = @Nationality and ShiftName like '%Shift3'
		) st
		pivot
		(
			Max(ShiftName)
			For Ngay in ([day1],[day2],[day3],[day4],[day5],[day6],[day7],[day8],[day9],[day10],[day11],[day12],[day13],[day14],[day15],[day16],[day17],[day18],[day19],[day20],[day21],[day22],[day23],[day24],[day25],[day26],[day27],[day28],[day29],[day30],[day31])
		) pivottable
		
		--select * from @rtnCaDem
		update bctt
			set bctt.day1 = isnull(bctt.day1,'') + isnull(dkc.day1,'')
				, bctt.day2 = isnull(bctt.day2,'') + isnull(dkc.day2,'')
				, bctt.day3 = isnull(bctt.day3,'') + isnull(dkc.day3,'')
				, bctt.day4 = isnull(bctt.day4,'') + isnull(dkc.day4,'')
				, bctt.day5 = isnull(bctt.day5,'') + isnull(dkc.day5,'')
				, bctt.day6 = isnull(bctt.day6,'') + isnull(dkc.day6,'')
				, bctt.day7 = isnull(bctt.day7,'') + isnull(dkc.day7,'')
				, bctt.day8 = isnull(bctt.day8,'') + isnull(dkc.day8,'')
				, bctt.day9 = isnull(bctt.day9,'') + isnull(dkc.day9,'')
				, bctt.day10 = isnull(bctt.day10,'') + isnull(dkc.day10,'')
				, bctt.day11 = isnull(bctt.day11,'') + isnull(dkc.day11,'')
				, bctt.day12 = isnull(bctt.day12,'') + isnull(dkc.day12,'')
				, bctt.day13 = isnull(bctt.day13,'') + isnull(dkc.day13,'')
				, bctt.day14 = isnull(bctt.day14,'') + isnull(dkc.day14,'')
				, bctt.day15 = isnull(bctt.day15,'') + isnull(dkc.day15,'')
				, bctt.day16 = isnull(bctt.day16,'') + isnull(dkc.day16,'')
				, bctt.day17 = isnull(bctt.day17,'') + isnull(dkc.day17,'')
				, bctt.day18 = isnull(bctt.day18,'') + isnull(dkc.day18,'')
				, bctt.day19 = isnull(bctt.day19,'') + isnull(dkc.day19,'')
				, bctt.day20 = isnull(bctt.day20,'') + isnull(dkc.day20,'')
				, bctt.day21 = isnull(bctt.day21,'') + isnull(dkc.day21,'')
				, bctt.day22 = isnull(bctt.day22,'') + isnull(dkc.day22,'')
				, bctt.day23 = isnull(bctt.day23,'') + isnull(dkc.day23,'')
				, bctt.day24 = isnull(bctt.day24,'') + isnull(dkc.day24,'')
				, bctt.day25 = isnull(bctt.day25,'') + isnull(dkc.day25,'')
				, bctt.day26 = isnull(bctt.day26,'') + isnull(dkc.day26,'')
				, bctt.day27 = isnull(bctt.day27,'') + isnull(dkc.day27,'')
				, bctt.day28 = isnull(bctt.day28,'') + isnull(dkc.day28,'')
				, bctt.day29 = isnull(bctt.day29,'') + isnull(dkc.day29,'')
				, bctt.day30 = isnull(bctt.day30,'') + isnull(dkc.day30,'')
				, bctt.day31 = isnull(bctt.day31,'') + isnull(dkc.day31,'')
			from
			@rtn_BangCongTheoThang bctt
			left join
			@rtnCaDem dkc
			on bctt.Employee_ID = dkc.Employee_ID
			where bctt.TypeOfWT = 'OT(H)'


				select distinct * from @rtn_BangCongTheoThang --where Employee_ID = '21111931'
				order by sectionName,employee_id,TypeOfWT
	end
END

GO
