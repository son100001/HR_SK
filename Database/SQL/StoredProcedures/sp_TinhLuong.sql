CREATE PROCEDURE [dbo].[sp_TinhLuong]    
 -- Add the parameters for the stored procedure here    
 --exec [dbo].[sp_TinhLuong]   1,null,null,11,2025,'MonthlySalary','2022-04-10','admin',null,null,null,null,null,null
 --exec [dbo].[sp_TinhLuong]   1,'2025-11-01','2025-11-30',null,null,'MonthlySalary','2022-04-10','admin',null,null,null,null,null,null
	@TypeOfReport INT=1, --1: Lương chính thức, 2: Lương nghỉ việc 05, 3: Lương nghỉ việc 15, 4: Lương nghỉ việc 25, 5: Lương 2 mức
	@SLRfromdate datetime,
	@SLRtodate datetime,
	@Month INT=10,    
	@Year INT=2024,    
	@SalaryKey varchar(50)='MonthlySalary',
	@NgayThanhToan datetime,
	@UserName nvarchar(50)=null,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@ListOfEmployee nvarchar(max)=null
AS 
BEGIN
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
 
	 DECLARE
		@SalaryComponent nvarchar(50)
		,@Employee_ID nvarchar(50),@OldEmployee_ID nvarchar(50)
		,@Value float,@ValueConvert nvarchar(50)
		,@MaCong nvarchar(50),@MaPhep nvarchar(50)
		,@LuongToiThieuVung FLOAT
		,@LuongCoBanTV FLOAT
		,@TroCapDiLaiTV FLOAT
		,@TroCapNhaTV FLOAT
        
	 DECLARE
		@queryUpdate nvarchar(max)
		,@fromdate datetime,@todate DATETIME
		,@NgayDauThangTruoc datetime,@NgayCuoiThangTruoc DATETIME
		,@dnext DATETIME
		,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan INT
		,@TrangThaiKH int
		,@NgayCongTieuChuan INT, @NgayCongThucTe INT
		,@DauThang datetime,@CuoiThang DATETIME
		,@isNghiToanCty BIT
		,@BHTNCtyTra float, @BHTNNLDTra float, @BHXHCtyDongNguoiNN float, @BHXHCtyTra FLOAT
		,@ChuyenCan FLOAT
		,@HuuTriTuTuatCTyTra float, @HuuTriTuTuatNLDTra FLOAT
		,@LuongCoSo float, @LuongTinhCovid FLOAT
		,@TienCongDoan FLOAT
		,@CongDoanNLDTra float, @CongDoanCtyTra FLOAT
		,@SinhNhat float
		,@TyGiaUSD float, @NgayApDungTyGia datetime, @LuongTinhBH float
		,@TienCom float, @XangXe float, @PCCC float, @ThuongABC float
		,@Ngay2 datetime,@Ngay3 datetime, @Ngay12 datetime, @Ngay13 datetime, @Ngay22 datetime, @Ngay23ThangTruoc datetime, @Ngay2ThangSau datetime, @Ngay3ThangSau datetime, @Ngay15 datetime
		
	 set @TrangThaiKH=[dbo].[udf_TrangThaiKH](@UserName)
	
	set @fromdate=DATEFROMPARTS(@Year,@Month,1)
	set @Ngay2 = DATEFROMPARTS(@Year,@Month,2)
	set @Ngay3 = DATEFROMPARTS(@Year,@Month,3)
	set @Ngay12 = DATEFROMPARTS(@Year,@Month,12)
	set @Ngay13 = DATEFROMPARTS(@Year,@Month,13)
	set @Ngay15 = DATEFROMPARTS(@Year,@Month,15)
	set @Ngay22 = DATEFROMPARTS(@Year,@Month,22)
	set @todate=EOMONTH(@fromdate)
	set @NgayDauThangTruoc=dateadd(month,-1,@fromdate)
	set @NgayCuoiThangTruoc=@fromdate-1	
	set @Ngay23ThangTruoc = DATEFROMPARTS(Year(@NgayDauThangTruoc),Month(@NgayDauThangTruoc),23)
	set @Ngay2ThangSau = dateadd(Month,1,@Ngay2)
	set @Ngay3ThangSau = dateadd(Month,1,@Ngay3)

	if @TypeOfReport = 2
		set @fromdate = @NgayDauThangTruoc
	
	set @NgayCongTieuChuan=26--dbo.udf_CountWorkingDay(@fromdate,@todate)	
	set @NgayCongThucTe = dbo.udf_CountDayExceptSunday(@fromdate,case when @TypeOfReport = 2 then @NgayCuoiThangTruoc else @todate end)
	
	IF @SLRfromdate is NULL
	BEGIN
		if @TrangThaiKH=1
		BEGIN
			set @SalaryKey=@SalaryKey+'_TachCong'
		end
		else if @TrangThaiKH = 2 begin
			set @SalaryKey = @SalaryKey + '_Diff'
		end
	END
    ------------------------------------

	Declare @DiffTax table (Employee_ID nvarchar(50), PIT float, primary key (Employee_ID))
	insert into @DiffTax (Employee_ID, PIT)
	select sal.Employee_ID, isnull(sal.s39,0) - isnull(salTC.s39,0) as PIT
	from
	Smartbooks_Salary sal
	left join
	Smartbooks_Salary salTC
	on sal.Salary_Month = salTC.Salary_Month and sal.Salary_Year = salTC.Salary_Year 
		and salTC.[key] = 'MonthlySalary_TachCong' and sal.[Key] = 'MonthlySalary'
		and sal.Employee_ID = salTC.Employee_ID
	where sal.Salary_Month = @Month and sal.Salary_Year = @Year and sal.[Key] = 'MonthlySalary'

	SELECT @LuongToiThieuVung=Value
	FROM HR_SetUpFollowDate
	WHERE Group_='Salary' and Code = 'LuongToiThieuVung' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate)
	ORDER by Fromdate ASC
    
	select @LuongCoSo=Value
	FROM HR_SetUpFollowDate
	WHERE Group_='Salary' and Code = 'LuongCoSo' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate)
	ORDER by Fromdate ASC	
    
	select @ChuyenCan=Value
	FROM HR_SetUpFollowDate
	WHERE Group_='Salary' and Code = 'ChuyenCan' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate)
	ORDER by Fromdate ASC
    
	select @SinhNhat=Value
	FROM HR_SetUpFollowDate
	WHERE Group_='TienTroCap' and Code = 'SinhNhat' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate)
	ORDER by Fromdate asc
	
	SELECT @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan=[Value]
	FROM [dbo].[SetUp]
	WHERE ID='SoNgaySauKhiMangBauDuocHuongThaiSan'

	select @TienCongDoan=Value
	FROM HR_SetUpFollowDate 
	WHERE Group_='Salary' and Code = 'CongDoanNLDTra' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate)
	ORDER by Fromdate asc

	select @CongDoanNLDTra=Value from HR_SetUpFollowDate where Group_='CongDoanNLDTra' and Code = 'LuongCoBan' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
	select @CongDoanCtyTra=Value from HR_SetUpFollowDate where Group_='CongDoanCtyTra' and Code = 'LuongCoBan' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
	select @BHTNCtyTra=Value from HR_SetUpFollowDate where Group_='Salary' and Code = 'BHTNCtyTra' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
	select @BHTNNLDTra=Value from HR_SetUpFollowDate where Group_='Salary' and Code = 'BHTNNLDTra' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
	select @BHXHCtyDongNguoiNN=Value from HR_SetUpFollowDate where Group_='Salary' and Code = 'BHXHCtyDongNguoiNN' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
	select @BHXHCtyTra=Value from HR_SetUpFollowDate where Group_='Salary' and Code = 'BHXHCtyTra' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
	select @TyGiaUSD = [Value] from HR_SetUpFollowDate where Group_='Salary' and Code = 'TyGiaUSD' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
	select @NgayApDungTyGia = Fromdate from HR_SetUpFollowDate where Group_='Salary' and Code = 'TyGia' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
	select @LuongTinhBH = [Value] from HR_SetUpFollowDate where Group_='Salary' and Code = 'LuongTinhBH' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
	select @TienCom = [Value] from HR_SetUpFollowDate where Group_='Salary' and Code = 'TienCom' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
	select @XangXe = [Value] from HR_SetUpFollowDate where Group_='Salary' and Code = 'XangXe' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
	select @PCCC = [Value] from HR_SetUpFollowDate where Group_='Salary' and Code = 'PCCC' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
	select @ThuongABC = [Value] from HR_SetUpFollowDate where Group_='Salary' and Code = 'ThuongABC' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
	
	
	
	
	
	--------------------------------------
		

	 --Tạo bảng ngày
	declare @tabDate table(Ngay datetime,primary key (Ngay))
	declare @dtnext datetime
	set @dtnext=@fromdate
	while @dtnext<=@todate
	BEGIN
		insert into @tabDate (Ngay) values(@dtnext)
		set @dtnext=@dtnext+1
	end
		

	-- nguoi phu thuoc
	DECLARE @dependentPerson TABLE
	(
		Employee_ID nvarchar(50) NOT NULL, 
		DependentPerson int NULL,
		primary key ([Employee_ID])
	)
	insert into @dependentPerson
	select Employee_ID,count(Employee_ID) as DependentPerson
	FROM HR_DanhSachNguoiPhuThuoc
	WHERE DependFromMonth<=@todate and (DependToMonth is null or DependToMonth>=@fromdate)
	AND (case when isnull(@ListOfEmployee,'')='' then '' else employee_id end) in (select data from split((case when isnull(@ListOfEmployee,'')='' then '' else @ListOfEmployee end),','))
	group by Employee_ID
	-------------------
	
	--Đêm số ngày công để tính bảo hiểm begin
	DECLARE @tabDemNgayBH as table(
					Employee_ID nvarchar(50)
					,cong float					
					PRIMARY key(Employee_ID)
					)
	insert into @tabDemNgayBH
	SELECT
		Employee_ID
		,COUNT(DISTINCT Ngay)
	FROM
	(
		SELECT wt.Employee_ID,Ngay,SUM(wt) AS wt
		FROM
		HR_WTDaily	wt
		LEFT JOIN 
		dbo.udf_NgayKyHDChinhThuc(@fromdate,@todate,@Employee_ID) nkhdct
		ON wt.Employee_ID=nkhdct.Employee_ID
		WHERE wt.Ngay between @fromdate AND @todate AND wt.Ngay >=ISNULL(nkhdct.NgayKyHDChinhThuc,@fromdate)
		AND MaCong IN (SELECT MaCong FROM dbo.HR_LoaiCong WHERE ISNULL(isWorkingTime,0)=1)
		GROUP BY wt.Employee_ID,Ngay
	) wt
	
	WHERE ISNULL(wt.wt,0)>0 
	GROUP BY wt.Employee_ID

	--Đếm số ngày được ăn bữa phụ
	DECLARE @tabDemNgayOT as table(
					Employee_ID nvarchar(50)
					,SoNgay float					
					PRIMARY key(Employee_ID)
					)
	insert into @tabDemNgayOT
	SELECT
		Employee_ID
		,COUNT(DISTINCT Ngay)
	FROM
	(
		SELECT Employee_ID,Ngay,SUM(wt) AS wt
		FROM HR_WTDaily		
		WHERE Ngay BETWEEN @fromdate and @todate
		AND MaCong NOT IN ('wt1','wt9','CN_wt4','wt4','CN_wt6','wt6')--(SELECT MaCong FROM dbo.HR_LoaiCong WHERE ISNULL(isWorkingTime,0)=0)
		GROUP BY Employee_ID,Ngay
	) wt
	WHERE ISNULL(wt.wt,0)>=3
	GROUP BY wt.Employee_ID
	
	

	DECLARE @tabDiMuonVeSom table(
					Employee_ID nvarchar(50)
					,SoLanDMVS_CT INT
					,SoLanDMVS_TV INT
					,ThoiGianDTVS_CT FLOAT
                    ,ThoiGianDTVS_TV float
					, SoLanQuenQuetThe_CT INT
					, SoLanQuenQuetThe_TV INT
					, Primary key(Employee_ID)
					)
	INSERT into @tabDiMuonVeSom
	SELECT 
		dmvs.Employee_ID AS employee_id
		,isnull(SoLanDiTreVeSom_CT,0) as SoLanDMVS_NghiKL_CT
		,isnull(SoLanDiTreVeSom_TV,0) as SoLanDMVS_NghiKL_TV
		,ISNULL(dmvs.ThoiGianDiTreVeSom_CT,0) AS ThoiGianDTVS_CT
		,ISNULL(dmvs.ThoiGianDiTreVeSom_TV,0) AS ThoiGianDTVS_TV
		,SoLanQuenQuetVanTay_CT
		,SoLanQuenQuetVanTay_TV
	FROM 
	[dbo].[udf_DiTreVeSomVaXinRaNgoai](@fromdate,@todate,'VN',NULL,NULL,NULL,NULL,NULL,NULL,NULL) dmvs
	
	 
	----Bảng công tạm theo tháng
	--Declare @tabBangCongTamTheoThang table (
	--				Employee_ID nvarchar(50)
	--				, cct_wt1 float, cct_wt9 float, cct_CN_wt3 FLOAT, cct_CN_wt5 FLOAT
	--				, ctv_wt1 float, ctv_wt9 float, ctv_CN_wt3 float, ctv_CN_wt5 FLOAT
	--				, primary key (Employee_ID)
	--				)
	--insert into @tabBangCongTamTheoThang
	--SELECT
	--	thc.Employee_ID
	--	, sum(cct_wt1) as cct_wt1, sum(cct_wt9) as cct_wt9
	--	, sum(cct_CN_wt3) as cct_CN_wt3, sum(cct_CN_wt5) as cct_CN_wt5
	--	, sum(ctv_wt1) as ctv_wt1, sum(ctv_wt9) as ctv_wt9
	--	, sum(ctv_CN_wt3) as ctv_CN_wt3, sum(ctv_CN_wt5) as ctv_CN_wt5
	--from
	--(
	--	SELECT
	--		dkc.AccessDate, dkc.Employee_ID
	--		,CASE
	--			WHEN dkc.ShiftName like N'%Shift0' and isnull(nkhdct.NgayKyHDChinhThuc,dkc.AccessDate-1) < AccessDate then 8
	--			WHEN dkc.ShiftName like N'%Shift3' and isnull(nkhdct.NgayKyHDChinhThuc,dkc.AccessDate-1) < AccessDate then 4
	--			ELSE 0
	--		END as cct_wt1
	--		,CASE
	--			WHEN dkc.ShiftName like N'%Shift3' and isnull(nkhdct.NgayKyHDChinhThuc,dkc.AccessDate-1) < AccessDate then 4
	--			ELSE 0 
	--		END as cct_wt9
	--		,CASE
	--			WHEN dkc.ShiftName like N'%Shift0' and dkc.CheDo in (0,3) and isnull(nkhdct.NgayKyHDChinhThuc,dkc.AccessDate-1) < AccessDate then 3
	--			ELSE 0
	--		END as cct_CN_wt3
	--		,CASE
	--			WHEN dkc.ShiftName like N'%Shift3' and dkc.CheDo in (0,3) and isnull(nkhdct.NgayKyHDChinhThuc,dkc.AccessDate-1) < AccessDate then 3
	--			ELSE 0
	--		END as cct_CN_wt5
	--		,CASE
	--			WHEN dkc.ShiftName like N'%Shift0' and isnull(nkhdct.NgayKyHDChinhThuc,dkc.AccessDate-1) >= AccessDate then 8
	--			WHEN dkc.ShiftName like N'%Shift3' and isnull(nkhdct.NgayKyHDChinhThuc,dkc.AccessDate-1) >= AccessDate then 4
	--			ELSE 0
	--		END as ctv_wt1
	--		,CASE
	--			WHEN dkc.ShiftName like N'%Shift3' and isnull(nkhdct.NgayKyHDChinhThuc,dkc.AccessDate-1) >= AccessDate then 4
	--			ELSE 0
	--		END as ctv_wt9
	--		,CASE
	--			WHEN dkc.ShiftName like N'%Shift0' and dkc.CheDo in (0,3) and isnull(nkhdct.NgayKyHDChinhThuc,dkc.AccessDate-1) >= AccessDate then 3 
	--			ELSE 0 
	--		END as ctv_CN_wt3
	--		,CASE
	--			WHEN dkc.ShiftName like N'%Shift3' and dkc.CheDo in (0,3) and isnull(nkhdct.NgayKyHDChinhThuc,dkc.AccessDate-1) >= AccessDate then 3
	--			ELSE 0
	--		END as ctv_CN_wt5
	--	from
	--	udf_DangKyCa (@fromdate,@todate,182,null,null,null,null,null,null,null) dkc
	--	left join
	--	HR_Shifts shi
	--	on dkc.ShiftName = shi.ShiftName
	--	left join
	--	udf_NgayKyHDChinhThuc (@fromdate, @todate, null) nkhdct
	--	on dkc.AccessDate >= nkhdct.NgayKyHDChinhThuc and dkc.Employee_ID = nkhdct.Employee_ID
	--	where datepart(dw,dkc.AccessDate) <> 1
	--) thc
	--group by thc.Employee_ID
	-------------------------------------------

	--SHOW RA
	SELECT 
		@SalaryKey as [Key]
		,@Month as Salary_Month,@Year as Salary_Year
		,@LuongToiThieuVung as LuongToiThieuVung
		,@fromdate as NgayDauKyLuong,@todate as NgayCuoiKyLuong
		
		,empl.Employee_ID
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName    
		,empl.StartedDate,empl.BankAccount
		,empl.PositionName
		,CASE
			WHEN empl.OfficialDate <= @fromdate THEN 2
			WHEN empl.OfficialDate BETWEEN @fromdate AND @todate THEN 1
			ELSE 0
		END AS CT_TV
		
		,@NgayCongTieuChuan*8 AS GioCongTieuChuan
		--,CASE WHEN empl.DepartmentCode like '%Soi%' THEN 8 ELSE 8 END AS GioCongTieuChuan1Ngay
		,@NgayCongTieuChuan as NgayCongTieuChuan
		--Cho phép DTVS 2 lần/tháng, <=1h/lần
		--,NuoiCNDuoi6Tuoi.TienTroCap AS TCConNho
		,CASE when empl.OfficialDate between @fromdate and @todate AND MONTH(empl.BirthDate) =@Month and day(empl.BirthDate) >= day(empl.OfficialDate) then @SinhNhat WHEN empl.OfficialDate<=@fromdate AND MONTH(empl.BirthDate) =@Month THEN @SinhNhat ELSE 0 END AS SinhNhat
		
		,case when empl.position like N'Production_Soi%' or empl.position like N'Production_Det%' then ISNULL(ngayOT.SoNgay,0) else 0 end AS SoNgayOT
		,ISNULL(ngayBH.cong,0) AS SoNgayBH
		
		,isnull(lcdCu.CD1,0) as OldCD1, isnull(lcdCu.CD2,0) as OldCD2, isnull(lcdCu.CD3,0) as OldCD3,lcdCu.CD4 as OldCD4,lcdCu.CD5 as OldCD5
		,lcdCu.CD6 as OldCD6,lcdCu.CD7 as OldCD7,lcdCu.CD8 as OldCD8,lcdCu.CD9 as OldCD9,lcdCu.CD10 as OldCD10
		,lcdCu.CD11 as OldCD11
		,lcdCu.CD12 as OldCD12,lcdCu.CD13 as OldCD13,lcdCu.CD14 as OldCD14,lcdCu.CD15 as OldCD15
		,lcdCu.CD16 as OldCD16
		,lcdCu.CD17 as OldCD17,lcdCu.CD18 as OldCD18,lcdCu.CD19 as OldCD19,lcdCu.CD20 as OldCD20
		
		,isnull(lcd.CD1,0) as CD1, isnull(lcd.CD2,0) as CD2, isnull(lcd.CD3,dbo.udf_PCThamNien(empl.OfficialDate+1,@todate,'')) as CD3, isnull(lcd.CD4,0) as CD4, isnull(lcd.CD5,0) as CD5
		,isnull(lcd.CD6,0) as CD6,lcd.[CD7],lcd.[CD8],lcd.[CD9],lcd.[CD10]
		,lcd.CD11 as CD11
		,lcd.[CD12],lcd.[CD13],lcd.[CD14],lcd.[CD15]
		,lcd.CD16 as CD16,lcd.[CD17],lcd.[CD18],lcd.[CD19],lcd.[CD20]
		
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT1],0)  end as HT1
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT2],0)  end as HT2
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT3],0)  end as HT3
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT4],0)  end as HT4
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT5],0)  end as HT5
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT6],0)  end as HT6
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT7],0)  end as HT7
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT8],0)  end as HT8
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT9],0)  end as HT9
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT10],0) end as HT10
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT11],0) end as HT11
		,case when @TrangThaiKH = 1 then ltd.HT20 when @TrangThaiKH = 2 then isnull(ltd.HT12,0) - isnull(ltd.HT20,0) else ltd.[HT12] end as HT12
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT13],0) end as HT13
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT14],0) end as HT14
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT15],0) end as HT15
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT16],0) end as HT16
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT17],0) end as HT17
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT18],0) end as HT18
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT19],0) end as HT19
		,case when @TrangThaiKH = 2 then 0 else isnull(ltd.[HT20],0) end as HT20
		
		,ISNULL(cct.wt1,0) as cct_wt1,ISNULL(cct.wt2,0) as cct_wt2,ISNULL(cct.wt3,0) as cct_wt3
		,ISNULL(cct.wt4,0) as cct_wt4,ISNULL(cct.wt5,0) as cct_wt5,ISNULL(cct.wt6,0) as cct_wt6
		,ISNULL(cct.wt7,0) as cct_wt7,ISNULL(cct.wt8,0) as cct_wt8,ISNULL(cct.wt9,0) as cct_wt9
		,ISNULL(cct.wt10,0) as cct_wt10,ISNULL(cct.wt11,0) as cct_wt11,ISNULL(cct.wt12,0) as cct_wt12
		,ISNULL(cct.wt13,0) as cct_wt13,ISNULL(cct.wt14,0) as cct_wt14,ISNULL(cct.wt15,0) as cct_wt15

		,ISNULL(cct.CN_wt3,0) as cct_CN_wt3
		,ISNULL(cct.CN_wt4,0) as cct_CN_wt4,ISNULL(cct.CN_wt5,0) as cct_CN_wt5,ISNULL(cct.CN_wt6,0) as cct_CN_wt6
		,ISNULL(cct.CN_wt7,0) as cct_CN_wt7,ISNULL(cct.CN_wt8,0) as cct_CN_wt8
		,ISNULL(cct.CN_wt10,0) as cct_CN_wt10,ISNULL(cct.CN_wt11,0) as cct_CN_wt11,ISNULL(cct.CN_wt12,0) as cct_CN_wt12
		,ISNULL(cct.CN_wt13,0) as cct_CN_wt13,ISNULL(cct.CN_wt14,0) as cct_CN_wt14,ISNULL(cct.CN_wt15,0) as cct_CN_wt15
		
		,ISNULL(ctv.wt1,0) as ctv_wt1,ISNULL(ctv.wt2,0) as ctv_wt2,ISNULL(ctv.wt3,0) as ctv_wt3
		,ISNULL(ctv.wt4,0) as ctv_wt4,ISNULL(ctv.wt5,0) as ctv_wt5,ISNULL(ctv.wt6,0) as ctv_wt6
		,ISNULL(ctv.wt7,0) as ctv_wt7,ISNULL(ctv.wt8,0) as ctv_wt8,ISNULL(ctv.wt9,0) as ctv_wt9
		,ISNULL(ctv.wt10,0) as ctv_wt10,ISNULL(ctv.wt11,0) as ctv_wt11,ISNULL(ctv.wt12,0) as ctv_wt12
		,ISNULL(ctv.wt13,0) as ctv_wt13,ISNULL(ctv.wt14,0) as ctv_wt14,ISNULL(ctv.wt15,0) as ctv_wt15

		,ISNULL(ctv.CN_wt3,0) as ctv_CN_wt3
		,ISNULL(ctv.CN_wt4,0) as ctv_CN_wt4,ISNULL(ctv.CN_wt5,0) as ctv_CN_wt5,ISNULL(ctv.CN_wt6,0) as ctv_CN_wt6
		,ISNULL(ctv.CN_wt7,0) as ctv_CN_wt7,ISNULL(ctv.CN_wt8,0) as ctv_CN_wt8
		,ISNULL(ctv.CN_wt10,0) as ctv_CN_wt10,ISNULL(ctv.CN_wt11,0) as ctv_CN_wt11,ISNULL(ctv.CN_wt12,0) as ctv_CN_wt12
		,ISNULL(ctv.CN_wt13,0) as ctv_CN_wt13,ISNULL(ctv.CN_wt14,0) as ctv_CN_wt14,ISNULL(ctv.CN_wt15,0) as ctv_CN_wt15
		

		,dmvs.SoLanDMVS_CT,dmvs.ThoiGianDTVS_CT
		,dmvs.SoLanDMVS_TV,dmvs.ThoiGianDTVS_TV
		,pct.PhepHuongLuong as pct_PhepHuongLuong
		--,pct.KhongPhep as pct_KhongPhep
		,pct.KLKhongMatCC as pct_KLKhongMatCC
		--,pct.PhepNam as pct_PhepNam
		--,pct.NghiLe as pct_NghiLe,pct.NgungViec as pct_NgungViec
		--,pct.NghiKhongLuong as pct_NghiKhongLuong,pct.KetHon as pct_KetHon
		--,pct.BoMeMat as pct_BoMeMat
		--,pct.NghiTuan as pct_NghiTuan,pct.CongTac as pct_Congtac
		--,pct.NghiDich as pct_NghiDichchuyen
	
		,ptv.PhepHuongLuong as ptv_PhepHuongLuong,ptv.KhongPhep as ptv_KhongPhep
		,ptv.KLKhongMatCC as ptv_KLKhongMatCC,ptv.PhepNam as ptv_PhepNam
		--,ptv.NghiLe as ptv_NghiLe,ptv.NgungViec as ptv_NgungViec
		--,ptv.CongTac as ptv_Congtac,ptv.NghiDich as ptv_NghiDich
	   	  
		,depen.DependentPerson as NguoiPhuThuoc
		,isnull(depen.DependentPerson,0)*4400000 + 11000000 as GiamTruCaNhan
		,CASE
			when datediff(year,empl.BirthDate,@todate) >= 60 then 0
			WHEN IU.SocialInsurance IS NULL THEN 2
			ELSE IU.SocialInsurance END
		AS SocialInsurance
		,CASE
			when datediff(year,empl.BirthDate,@todate) >= 60 then 0
			WHEN IU.UnemploymentInsurance IS NULL THEN 2
			ELSE IU.UnemploymentInsurance
		END AS UnemploymentInsurance
		,CASE
			when datediff(year,empl.BirthDate,@todate) >= 60 then 0
			WHEN IU.HealthInsurance is null 
				then (
						case when ((empl.OfficialDate between @fromdate and @todate) or empl.OfficialDate > @fromdate) and (ISNULL(cct.wt1,0) + isnull(cct.wt9,0) + isnull(pct.PhepHuongLuong,0))/(CASE WHEN empl.DepartmentCode='Production_Soi' THEN 9 ELSE 8 END) < @NgayCongTieuChuan - 14 then 0
							else 1 end
					)
			ELSE IU.HealthInsurance END
		AS HealthInsurance
		,CASE
			WHEN IU.UnionFee is null then 2
			ELSE IU.UnionFee 
		END as UnionFee		
					
	  --,isnull(pn.PhepNamTon,0) as PhepNamTon,isnull(pn.PhepNamDuocHuongDenHienTai,0) as PhepNamDuocHuongDenHienTai, isnull(pn.TongPhepNamDaNghi,0) as TongPhepNamDaNghi
			  
		,CASE
			when isnull(erpm.ParameterValue,'') = 'ThamGiaCongDoan' then 1
			WHEN isnull(erpm.ParameterValue,'') = 'KhongThamGiaCongDoan' then 0
			ELSE 1
		END as KhongThamGiaCongDoan

		,@BHTNCtyTra as BHTNCtyTra, @BHTNNLDTra as BHTNNLDTra
		,@BHXHCtyDongNguoiNN as BHXHCtyDongNguoiNN, @BHXHCtyTra as BHXHCtyTra
		,@HuuTriTuTuatCTyTra as HuuTriTuTuatCTyTra, @HuuTriTuTuatNLDTra as HuuTriTuTuatNLDTra
		,@LuongCoSo as LuongCoSo		
		,@TienCongDoan as TienCongDoan
		,@CongDoanNLDTra as CongDoanNLDTra, @CongDoanCtyTra as CongDoanCtyTra
		,ndl.Ngay as NgayDoiLuong
		,DATEFROMPARTS(Year(@todate),Month(@todate),15) as ngay15
		,case when isnull(empl.TernimationDate,@todate+1) between @fromdate and @todate and (isnull(cct.wt1,0) + isnull(cct.wt9,0) + isnull(pct.PhepHuongLuong,0)) / (CASE WHEN empl.DepartmentCode='Production_Soi' THEN 9 ELSE 8 END) <= @NgayCongTieuChuan - 14 then 1
				else 0 end as DongBHLuongCu
		,empl.KhuVuc, empl.BankAccount, @NgayApDungTyGia as NgayApDungTyGia, @TyGiaUSD as TyGiaUSD, @LuongTinhBH as LuongTinhBH
		, @NgayCongThucTe as NgayCongThucTe
		, case when isnull(ltd.HT5,0) <> 0 then ltd.HT5 when (isnull(cct.wt1,0) + isnull(cct.wt9,0) + isnull(ctv.wt1,0) + isnull(ctv.wt9,0) + isnull(pct.PhepHuongLuong,0) + isnull(ptv.PhepHuongLuong,0))/8 >= 13 then isnull(lcd.CD8,0) else 0 end as PCCC
		, case when ltd.ht2 is not null then ltd.ht2 when isnull(empl.TernimationDate,@Ngay3ThangSau) between @Ngay23ThangTruoc and @Ngay2ThangSau or @Month = 12 then pn.PhepNamConLai else 0 end as PhepNamConLai
		, case when ltd.ht3 is null then 0 when ltd.ht3 is not null and ltd.ht3 = 0 then 1 else ltd.ht3 end as SoTienThanhToanPhepNamConLai
		, case when isnull(empl.OfficialDate,@todate+2) > @todate then 2 when isnull(empl.OfficialDate,@todate+2) between @fromdate and @todate then 1 else 0 end isThuViec
		, empl.Sex, empl.Factory_ID, empl.DepartmentCode1, empl.PositionCategory_ID as Position_ID, empl.Employee_Firstname, empl.Employee_LastName
		, Upper(dbo.udf_RemoveDiacritics(dbo.udf_Fullname(empl.Employee_Firstname, empl.Employee_LastName))) as FullNameKhongDau
		, SoCaDem, TienCaDem as TienCom
		--, case when isnull(empl.isManager,0) = 1 then 0 when empl.StartedDate between @fromdate and @todate then round(500000 / @NgayCongTieuChuan / 8.0 * (isnull(cct.wt1,0) + isnull(cct.wt9,0) + isnull(ctv.wt1,0) + isnull(ctv.wt9,0) + isnull(pct.PhepHuongLuong,0) + isnull(ptv.PhepHuongLuong,0)),-3) when isnull(cct.wt1,0) + isnull(cct.wt9,0) + isnull(ctv.wt1,0) + isnull(ctv.wt9,0) + isnull(pct.PhepHuongLuong,0) + isnull(ptv.PhepHuongLuong,0) + isnull(pct.PKT,0) + isnull(ptv.PKT,0) >= @NgayCongTieuChuan * 8 - 4 then 500000 else 0 end as ChuyenCan
		, case when isnull(empl.isManager,0) = 1 or isnull(erpm.ParameterValue,'') = 'KhongDuocTienXangXeNhaO' then 0 when empl.StartedDate between @fromdate and @todate then round(200000 / @NgayCongThucTe * Round((isnull(cct.wt1,0) + isnull(cct.wt9,0) + isnull(ctv.wt1,0) + isnull(ctv.wt9,0) + isnull(pct.PhepHuongLuong,0) + isnull(ptv.PhepHuongLuong,0))/8.0,2),-3) when isnull(cct.wt1,0) + isnull(cct.wt9,0) + isnull(ctv.wt1,0) + isnull(ctv.wt9,0) + isnull(pct.PhepHuongLuong,0) + isnull(ptv.PhepHuongLuong,0) >= 13 * 8 then 200000 else 0 end as XangXe 
		--, case when isnull(empl.isManager,0) = 1 then 0 when lcd.CD6 is null then 0 when empl.StartedDate between @fromdate and @todate then Round(lcd.CD6 / (@NgayCongThucTe*8) * (isnull(cct.wt1,0) + isnull(cct.wt9,0) + isnull(ctv.wt1,0) + isnull(ctv.wt9,0) + isnull(pct.PhepHuongLuong,0) + isnull(ptv.PhepHuongLuong,0)),-3) when (isnull(cct.wt1,0) + isnull(cct.wt9,0) + isnull(ctv.wt1,0) + isnull(ctv.wt9,0) + isnull(pct.PhepHuongLuong,0) + isnull(ptv.PhepHuongLuong,0))/8 >= 13 then lcd.CD6 else 0 end as XangXe
		, case when @TrangThaiKH = 2 then 0 when ltd.HT1 is not null then ltd.HT1 when isnull(empl.isManager,0) = 1 then 0 when empl.StartedDate between @fromdate and @todate then Round( isnull(lcd.CD10,@ChuyenCan) / (@NgayCongThucTe) * Round((isnull(cct.wt1,0) + isnull(cct.wt9,0) + isnull(ctv.wt1,0) + isnull(ctv.wt9,0) + isnull(pct.PhepHuongLuong,0) + isnull(ptv.PhepHuongLuong,0) /*+ isnull(pct.PB,0) + isnull(ptv.PB,0)*/)/8.0,2),-3) when (isnull(cct.wt1,0) + isnull(cct.wt9,0) + isnull(ctv.wt1,0) + isnull(ctv.wt9,0) + isnull(pct.PhepHuongLuong,0) + isnull(ptv.PhepHuongLuong,0) + isnull(pct.PKT,0) + isnull(ptv.PKT,0) + isnull(pct.KLKhongMatCC,0) + isnull(ptv.KLKhongMatCC,0) /*+ isnull(pct.PB,0) + isnull(ptv.PB,0)*/) >= @NgayCongThucTe*8 - 4 then isnull(lcd.CD10,@ChuyenCan) else 0 end as ChuyenCan
		, case when @TrangThaiKH = 2 then 0 when empl.StartedDate between @fromdate and @todate then Round(150000 / @NgayCongThucTe * Round((isnull(cct.wt1,0) + isnull(cct.wt9,0) + isnull(ctv.wt1,0) + isnull(ctv.wt9,0) + isnull(pct.PhepHuongLuong,0) + isnull(ptv.PhepHuongLuong,0))/8.0,2),-3) when (isnull(cct.wt1,0) + isnull(cct.wt9,0) + isnull(ctv.wt1,0) + isnull(ctv.wt9,0) + isnull(pct.PhepHuongLuong,0) + isnull(ptv.PhepHuongLuong,0))/8 >= 13 then ltd.HT10 else 0 end as ThuongABC
		, case when @TrangThaiKH = 2 then 0 when isnull(empl.TernimationDate,@Ngay3ThangSau) between @Ngay23ThangTruoc and @Ngay2ThangSau then 0 else (case when isnull(cct.wt1,0) + isnull(cct.wt9,0) + isnull(ctv.wt1,0) + isnull(ctv.wt9,0) + isnull(pct.PhepHuongLuong,0) + isnull(ptv.PhepHuongLuong,0) >= 13 * 8 then isnull(ef.TienConNho,0) else 0 end) end as TCConNho
		, case when @TrangThaiKH = 2 then 0 when isnull(empl.OfficialDate,@fromdate) > @todate then 1 when empl.OfficialDate between @fromdate and @todate and day(empl.OfficialDate) > 15 then 1 else 0 end as TinhThueThuViec
		, case when @TrangThaiKH = 2 then 0 when isnull(ltd.HT4,0) = 1 then 2 when empl.OfficialDate > @todate then 0 when IU.SocialInsurance is not null and isnull(IU.SocialInsurance,0) = 0 then 3 when IU.SocialInsurance is not null and isnull(IU.SocialInsurance,0) = 1 and (empl.TernimationDate between @Ngay23ThangTruoc and @Ngay2ThangSau) then 1 when IU.SocialInsurance is not null and isnull(IU.SocialInsurance,0) = 1 then 1 when isnull(cct.wt1,0) + isnull(cct.wt9,0) + isnull(pct.PhepHuongLuong,0) > (@NgayCongThucTe - 14) * 8 and (empl.OfficialDate <= @fromdate or (isnull(cct.TongCongCT,0) + isnull(pct.TongPhepCT,0) > (@NgayCongThucTe - 14) * 8 and empl.OfficialDate between @fromdate and @todate)) then 1 else 0 end as DuieuKienBH
		, case when @TrangThaiKH = 2 then 0 when IU.UnionFee is not null and isnull(IU.UnionFee,-1) = 0 then 1 when IU.UnionFee is not null and isnull(IU.UnionFee,0) = 1 then 2 when isnull(lcd.CD9,-1) <> -1 then lcd.CD9 when empl.OfficialDate > @todate then 1 when empl.OfficialDate between @fromdate and @todate and day(empl.OfficialDate) > 15 then 1 else 2 end as DongCD --1 là không đóng, 2 là đóng
		, empl.TernimationDate, @Ngay23ThangTruoc
		, case when @TrangThaiKH = 2 then dt.PIT else 0 end as PITDiff
	from       
	[dbo].[udf_EmployeeFilter_Full]('VN',@fact,@dept,@sect,@team,@pos,@posc,null,isnull(@todate,getdate())) empl
	left join
	[dbo].[udf_BangLuongCoDinh](@todate,null) lcd
	 on empl.Employee_ID=lcd.Employee_ID
	 left join
	--[dbo].[udf_BangLuongCoDinh_Cu](@fromdate,@todate,null)lcdCu
	[dbo].[udf_BangLuongCoDinh](@fromdate,null) lcdCu
	on empl.Employee_ID=lcdCu.Employee_ID
	left join
	[dbo].[udf_BangLuongThayDoiTheoThang](@Month,@Year,null) ltd
	on empl.Employee_ID=ltd.Employee_ID
	left join
	[dbo].[udf_TongHopCong](@fromdate,@todate,case when @TypeOfReport in (1,2,3,4) then 1 else 3 end,@UserName) cct
	on empl.Employee_ID=cct.Employee_ID
	left join
	[dbo].[udf_TongHopCong](@fromdate,@todate,case when @TypeOfReport in (1,2,3,4) then 4 else 2 end,@UserName) ctv
	on empl.Employee_ID=ctv.Employee_ID
	left join
	[dbo].[udf_TongHopPhep](@fromdate,@todate,case when @TrangThaiKH = 2 then 5 when @TypeOfReport in (1,2,3,4) then 1 else 3 end) pct
	on empl.Employee_ID=pct.Employee_ID
	left join
	[dbo].[udf_TongHopPhep](@fromdate,@todate,case when @TrangThaiKH = 2 then 5 when @TypeOfReport in (1,2,3,4) then 4 else 2 end) ptv
	on empl.Employee_ID=ptv.Employee_ID
	left join
	dbo.udf_NgayKyHDChinhThuc(@fromdate,@todate,@Employee_ID) nct
	on empl.Employee_ID=nct.Employee_ID
	left join
	HR_EmpNonRegisInsuranceAndUnion IU
	on empl.Employee_ID=IU.Employee_ID and iu.Thang=@Month and iu.Nam=@Year
	--left join
	--udf_TroCapConNho (@Month, @Year) NuoiCNDuoi6Tuoi
	--on empl.Employee_ID=NuoiCNDuoi6Tuoi.Employee_ID
	left join
	[dbo].[udf_QuanLyPhepNam](@year,@todate,'VN',@fact,@dept,@sect,@team,@pos,@posc,null) pn
	on empl.Employee_ID=pn.Employee_ID
	left join
	@dependentPerson depen
	on empl.Employee_ID=depen.Employee_ID
	--left join
	--[dbo].[HR_TerminationAsignment] ta
	--on empl.Employee_ID=ta.Employee_ID and ta.DecisionStatus='Approved'
	--left join
	--SmartBooks_Salary ResignSalary
	--on empl.Employee_ID=ResignSalary.Employee_ID and ResignSalary.[key]='ResignSalary' and TrangThai=1
	--left join
	--SmartBooks_Section sect
	--on empl.SectionCode=sect.Factory_ID+'_'+sect.DepartmentCode+'_'+sect.SectionCode
	left join
	HR_EmployeeRegisMaternityLeave erml
	on empl.Employee_ID=erml.Employee_ID and erml.Fromdate<=@fromdate and erml.ToDate>=@todate and erml.LeaveType_ID='24'
	left join
	@tabDiMuonVeSom dmvs
	on empl.Employee_ID=dmvs.Employee_ID
	--left join
	--@tabTongGioDiMuonVeSomDuocGiamTru tgdmvs
	--on empl.Employee_ID = tgdmvs.Employee_ID
	left join
	@tabDemNgayOT ngayOT
	on empl.Employee_ID=ngayOT.Employee_ID
	left join
	@tabDemNgayBH ngayBH
	on empl.Employee_ID=ngayBH.Employee_ID
	left join
	[dbo].[udf_NgayDoiLuong](@fromdate,@todate) ndl
	on empl.Employee_ID=ndl.Employee_ID
	--left join
	--[dbo].[udf_Position]('VN',1) p
	--on empl.position=p.Code
	left join
	HR_EmpRegisParameter erpm
	on empl.Employee_ID=erpm.Employee_ID and erpm.ParameterValue in ('ThamGiaCongDoan','KhongThamGiaCongDoan','KhongDuocTienXangXeNhaO') and @todate between erpm.fromdate and erpm.todate
	--left join
	--udf_TinhCC (@fromdate,@todate,@ChuyenCan,@Employee_ID) tcc
	--on empl.Employee_ID = tcc.Employee_ID
	left join
	udf_TinhTienAn (@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc) tta
	on empl.Employee_ID = tta.Employee_ID
	left join
	udf_SoTienCaDem (@fromdate, @todate, @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan, @UserName, @fact, @dept, @sect, @team, @pos, @posc, null) cadem
	on empl.Employee_ID = cadem.Employee_ID
	left join
	(
		select Employee_ID, sum(case when dateadd(year,1,BirthDate) between @fromdate and @todate and day(BirthDate) < 15 then 1 when dateadd(year,6,Birthdate) between @fromdate and @todate and day(Birthdate) > 15 then 1 when dateadd(year,6,Birthdate) >= @todate then 1 else 0 end) * 100000 as TienConNho
		from
		SmartBooks_Employee_Family
		where RelatedType = 6 and dateadd(year,6,Birthdate) >= @fromdate and dateadd(year,1,Birthdate) <= @Ngay15
		group by Employee_ID
	) ef
	on empl.Employee_ID = ef.Employee_ID
	left join
	SmartBooks_Department dep
	on empl.DepartmentCode = dep.Factory_ID + '_' + dep.DepartmentCode
	left join
	SmartBooks_Section sec
	on empl.position = sec.Factory_ID + '_' + sec.DepartmentCode + '_' + sec.SectionCode
	left join
	@DiffTax dt
	on empl.Employee_ID = dt.Employee_ID
	--left join
	--HR_EmployeeRegisPregnant dshcd
	--on empl.Employee_ID = dshcd.Employee_ID and (@fromdate between dshcd.Fromdate and isnull(dshcd.MiscarriageDate,dshcd.ToDate) or (@todate between dshcd.Fromdate and isnull(dshcd.MiscarriageDate,dshcd.ToDate)))
	where	
		empl.StartedDate<= @todate --AND ISNULL(empl.TernimationDate,@todate)>=@fromdate
		and empl.Employee_ID not like N'BV%'
		and 
		(
			(
				@TypeOfReport = 1 and isnull(empl.TernimationDate,@Ngay3ThangSau) > @Ngay2ThangSau
				and (
						(isnull(cct.wt1,0) + isnull(cct.wt9,0) + isnull(ctv.wt1,0) + isnull(ctv.wt9,0) + isnull(pct.PhepHuongLuong,0) + isnull(ptv.PhepHuongLuong,0) > 0)
						or
						@TrangThaiKH = 2
					)
				and ndl.Employee_ID is null
			)
			or
			(
				@TypeOfReport = 2 and empl.TernimationDate between @Ngay23ThangTruoc and @Ngay2
				and ndl.Employee_ID is null
			)
			or
			(
				@TypeOfReport = 3 and empl.TernimationDate between @Ngay3 and @Ngay12
				and ndl.Employee_ID is null
			)
			or
			(
				@TypeOfReport = 4 and empl.TernimationDate between @Ngay13 and @Ngay22
				and ndl.Employee_ID is null
			)
			or
			(
				@TypeOfReport = 5 and ndl.Employee_ID is not null
			)
		)
	order by  isnull(dep.OrderBy,200), isnull(sec.SectionCode,''), empl.Employee_ID

END

GO
