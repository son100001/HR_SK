CREATE PROCEDURE [dbo].[sp_BangDangKyTangCa]
	-- Add the parameters for the stored procedure here
	--exec sp_BangDangKyTangCa '2019-07-5 00:00:00','2019-07-5 00:00:00',4,N'VN',N'PRO',N'PRO_JH1001',N'',N'',N'',N''
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,--1: xem bảng tang ca theo chiều dọc; 2: xem bảng tăng ca theo chiều ngang
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Emp nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @workingdate datetime,@maxovertime float,@TypeOfOT varchar(20),@NgayNghiBu datetime,@ShiftName nvarchar(50),@PrintStatus bit,@Remark nvarchar(max),@KiemTraDuLieuNhap nvarchar(max),@InsertDate datetime, @UserName nvarchar(50),@UpdateDate datetime,@UpdateUserName nvarchar(50),@ID as int
		,@NgayCuoiThang datetime,@NgayDauThang datetime,@SoNgayCongToiDaCuaThang float
		set @NgayDauThang=DATEADD(day,1-datepart(day,@fromdate),@fromdate)
		set @NgayCuoiThang=DATEADD(month,1,@NgayDauThang)-1
		set @SoNgayCongToiDaCuaThang=DAY(@NgayCuoiThang)-dbo.udf_CountSunDay(@NgayDauThang,@NgayCuoiThang)
    -- Insert statements for procedure here
	if @TypeOfReport=1 begin
		select
		empl.Factory_ID,empl.DepartmentCode,empl.SectionCode
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
		,mot.*
		from
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,GETDATE())) empl
		inner join
		[dbo].[HR_MaxOvertime] mot
		on empl.Employee_ID COLLATE DATABASE_DEFAULT=mot.Employee_ID
		where mot.workingdate between @fromdate and @todate and (case when @Emp is null or @Emp='' then '' else mot.Employee_ID end)=ISNULL(@Emp,'')
		order by empl.DepartmentCode,empl.SectionCode,empl.Position_ID,empl.PositionCategory_ID,empl.StartedDate
	end else if @TypeOfReport=2 begin
		declare @s nvarchar(max); set @s=''
		select @s=@s + '[' + CONVERT(varchar(12),Date_,111) + '],' From [udf_BangThoiGian](@fromdate, @todate)
		set @s= left(@s,len(@s)-1)
		 IF OBJECT_ID('tempdb..#tab') IS NOT NULL DROP TABLE #tab
		 create table #tab(Employee_ID nvarchar(50))
		 Declare @dtNext datetime,@sql nvarchar(max)
		 set @dtNext=@fromdate
		 while @dtNext<=@todate begin
			set @sql='alter table #tab add [' + CONVERT(varchar(12),@dtNext,103) + '] nvarchar(20)'
			exec (@sql)
			set @dtNext=@dtNext+1
		 end
		set @sql = 'insert into #tab
					SELECT * FROM  
					(	SELECT Employee_ID,workingdate,sum(isnull(maxovertime,0)) as maxovertime
						FROM [dbo].[HR_MaxOvertime] where workingdate between @fromdate and @todate group by Employee_ID,workingdate) AS SourceTable  
					PIVOT  
					( 
						
						Max(maxovertime) FOR workingdate IN (@s1)
					) AS PivotTable '

		set @sql = REPLACE(@sql, '@s1', @s)
		EXECUTE sp_executesql @sql
				  , N'@fromdate datetime, @todate datetime'
				  , @fromdate = @fromdate  
				  , @todate = @todate
		select
		empl.Factory_ID,empl.DepartmentCode,empl.SectionCode
		,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
		,mot.*
		from
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,GETDATE())) empl
		left join
		#tab mot
		on mot.Employee_ID COLLATE DATABASE_DEFAULT = empl.Employee_ID
		order by empl.DepartmentCode,empl.SectionCode,empl.Position_ID,empl.PositionCategory_ID, empl.StartedDate
	end else if @TypeOfReport=4 begin--Tổng hợp đăng ký tăng ca theo khoa
		select
			empl.DepartmentName,ISNULL(empl.TeamName,isnull(empl.DepartmentName,'')) as TeamName
			,sum(case when maxovertime between 0.1 and 0.5 then 1 else 0 end) as CounT05
			,sum(case when maxovertime between 0.6 and 1 then 1 else 0 end) as CounT01
			,sum(case when maxovertime between 1.1 and 1.5 then 1 else 0 end) as CounT15
			,sum(case when maxovertime between 1.6 and 3 then 1 else 0 end) as CounT03
			,sum(case when maxovertime between 3.1 and 4 then 1 else 0 end) as CounT04
			,sum(case when maxovertime>4 then 1 else 0 end) as CounTLonHon45
			,sum(case when maxovertime>0 then 1 else 0 end) as EmployeeTotal
			,sum(isnull(maxovertime,0)) as HourTotal
			,sum(
					(
						(case when ISNULL(pro.SalaryBasic,0)>0 then pro.SalaryBasic else isnull(lcb.MucLuong,0) end)--salarbasic
						+isnull(pccodinh.pcKyThuat,0)+isnull(pccodinh.pcNgoaiNgu,0)+isnull(pccodinh.pcDichThuat,0)+pcCongViec-- các khoản phụ cấp cộng trực tiếp
						+isnull(pccodinh.pcChucDanh,0)+isnull(pccodinh.pcTiemNang,0)+(case when empl.Position_ID='TL B' then 400000 when empl.Position_ID='TL C' then 350000 else pccodinh.pcChucvu end)-- PC chức vụ, chức danh Hipo
						+(case when dbo.udf_NamkinhNghiem(empl.StartedDate,@todate)=0 then 0
							when dbo.udf_NamkinhNghiem(empl.StartedDate,@NgayCuoiThang)>=1 and dbo.udf_NamkinhNghiem(empl.StartedDate,@NgayCuoiThang)<2 then 30000
							when dbo.udf_NamkinhNghiem(empl.StartedDate,@NgayCuoiThang)+1>=2 and dbo.udf_NamkinhNghiem(empl.StartedDate,@NgayCuoiThang)+1<5 then 15000*(dbo.udf_NamkinhNghiem(empl.StartedDate,@NgayCuoiThang)+1)
							when dbo.udf_NamkinhNghiem(empl.StartedDate,@NgayCuoiThang)+1>=5 and dbo.udf_NamkinhNghiem(empl.StartedDate,@NgayCuoiThang)+1<10 then 20000*(dbo.udf_NamkinhNghiem(empl.StartedDate,@NgayCuoiThang)+1)
							else 25000*(dbo.udf_NamkinhNghiem(empl.StartedDate,@NgayCuoiThang)+1)
						end)--Thâm niên
						+(case when ISNULL(pro.SalaryBasic,0)>0 then pro.SalaryBasic else isnull(lcb.MucLuong,0) end)*isnull(pcDochai.Amount,0)/100.0--PC độc hại
					)/@SoNgayCongToiDaCuaThang/8.0*ISNULL(maxovertime,0)*(case when hp.H_date is not null and (ShiftName like '%Shift0' or ShiftName like '%Shift1' or ShiftName like '%Shift2') then 300
																				when hp.H_date is not null and ShiftName like '%Shift3' then 425
																				when DATENAME(WEEKDAY,mot.workingdate)='Sunday' and (ShiftName like '%Shift0' or ShiftName like '%Shift1' or ShiftName like '%Shift2') then 200
																				when DATENAME(WEEKDAY,mot.workingdate)='Sunday' and ShiftName like '%Shift3' then 290
																			else 150 end)
					 /100
			)/23000.0 as TongSoTienTangCa
		from
		HR_MaxOvertime mot
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,GETDATE())) empl
		on mot.Employee_ID=empl.Employee_ID
		left join
		(
			select pcct.Employee_ID,
			sum(case when pcct.Allowance_Code=25 then pcct.Amount else 0 end) as pcChucvu,
			sum(case when pcct.Allowance_Code=27 then pcct.Amount else 0 end) as pcChucDanh,
			--sum(case when pcct.Allowance_Code=26 then pcct.Amount else 0 end) as pcDochai,--
			sum(case when pcct.Allowance_Code=20 then pcct.Amount else 0 end) as pcNgoaiNgu,
			sum(case when pcct.Allowance_Code=21 then pcct.Amount else 0 end) as pcDichThuat,
			sum(case when pcct.Allowance_Code=22 then pcct.Amount else 0 end) as pcKyThuat,
			sum(case when pcct.Allowance_Code=23 then pcct.Amount else 0 end) as pcCongViec,
			sum(case when pcct.Allowance_Code=24 then pcct.Amount else 0 end) as pcTiemNang
			from HR_PhuCapCoDinh_Chitiet pcct
			inner join
			(
				select Employee_ID,Allowance_Code, max(Fromdate) as fromdate from HR_PhuCapCoDinh_Chitiet
				where fromdate<=@todate
				group by Employee_ID,Allowance_Code
			)pcct1 on pcct1.Employee_ID=pcct.Employee_ID and pcct1.Allowance_Code=pcct.Allowance_Code
			--inner join HR_PhuCapCoDinh pc on pc.Allowance_Code = pcct.Allowance_Code
			group by pcct.Employee_ID
		)pccodinh on empl.Employee_ID COLLATE DATABASE_DEFAULT= pccodinh.Employee_ID
		left join
		(
			select * from udf_LuongCoBan(@fromdate,@todate)
		)lcb on empl.Employee_ID COLLATE DATABASE_DEFAULT= lcb.Employee_ID
		left join
		(	
			select sp1.employee_id, sp1.SalaryBasic,sp1.InsuranceSalary,sp1.EffectiveDate,sp1.PromotionDate from SmartBooks_Promotion sp1
			inner join
			(
				select employee_id, max(EffectiveDate) as EffectiveDate from SmartBooks_Promotion
				where EffectiveDate <=@todate and isnull(EndDate,@todate)>=@todate
				group by employee_id
			)sp2 on sp1.Employee_ID = sp2.Employee_ID and sp1.EffectiveDate = sp2.EffectiveDate 
			where sp1.EffectiveDate <=@todate  and isnull(sp1.EndDate,@todate)>@fromdate
		) pro on empl.Employee_ID COLLATE DATABASE_DEFAULT= pro.Employee_ID
		left join
		SmartBooks_HolidaysPlan hp
		on mot.workingdate=hp.H_date
		left join
		(
			SELECT [TID],MaLoai,Employee_ID,Amount,Thang,Nam,IsIncrease,remark FROM HR_PhuCapDacBiet
			where thang=DATEPART(MONTH,@fromdate) and nam=DATEPART(YEAR,@fromdate)
		)pcDochai  on empl.Employee_ID COLLATE DATABASE_DEFAULT= pcDochai.Employee_ID
		where workingdate between @fromdate and @todate and empl.Employee_ID is not null
		group by empl.DepartmentName,empl.TeamName
	end else if @TypeOfReport=5 begin--Đăng ký tăng ca theo khoa: @fromdate=@todate
		select empl.DepartmentName as DepartmentCode,empl.Employee_ID
			,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.PositionName as Position_ID
			,OTLuyTien.OTLuyTien
			,mot.maxovertime,mot.ShiftName
			,(case when mot.TypeOfOT=1 then left(convert(varchar, s.ToTime, 108),5)+'~'+left(convert(varchar, dateadd(minute,isnull(mot.maxovertime,0)*60, s.ToTime), 108),5) 
					when mot.TypeOfOT=2 then left(convert(varchar,dateadd(minute,-isnull(mot.maxovertime,0)*60, s.FromTime),108),5)+'~'+left(convert(varchar, s.FromTime, 108),5) 
					else left(convert(varchar, s.FromTime, 108),5)+'~'+
						left((case when DATEDIFF(minute, [dbo].[GhepGioVaoNgay](s.FromTime,s.FromTime),[dbo].[GhepGioVaoNgay]((case when datepart(HOUR,s.FromTime)<datepart(HOUR,s.ToTime) then s.FromTime else s.FromTime+1 end),s.ToTime))<=480 then convert(varchar, dateadd(minute,isnull(mot.maxovertime,0)*60, s.FromTime), 108) 
							else (case when dateadd(minute,isnull(mot.maxovertime,0)*60, s.FromTime)>(case when DATEPART(HOUR,s.FromTime)<DATEPART(HOUR,s.RestTimeFrom) then [dbo].[GhepGioVaoNgay](s.FromTime,s.RestTimeFrom) else [dbo].[GhepGioVaoNgay](s.FromTime+1,s.RestTimeFrom) end) then convert(varchar, dateadd(minute,isnull(mot.maxovertime,0)*60+DATEDIFF(minute,(case when DATEPART(HOUR,s.FromTime)<DATEPART(HOUR,s.RestTimeFrom) then [dbo].[GhepGioVaoNgay](s.FromTime,s.RestTimeFrom) else [dbo].[GhepGioVaoNgay](s.FromTime+1,s.RestTimeFrom) end),(case when DATEPART(HOUR,s.FromTime)<DATEPART(HOUR,s.RestTimeTo) then [dbo].[GhepGioVaoNgay](s.FromTime,s.RestTimeTo) else [dbo].[GhepGioVaoNgay](s.FromTime+1,s.RestTimeTo) end)), s.FromTime), 108)
										else convert(varchar, dateadd(minute,isnull(mot.maxovertime,0)*60, s.FromTime), 108)
									end)
						end),5)
				end) as ThoiGian
			,
			(case when tito.RealTimeIn is not null or tito.realTimeOut is not null then
				(case when tito.RealTimeIn is not null then left(convert(varchar, tito.RealTimeIn, 108),5) else '' end)+'~'+(case when tito.realTimeOut is not null then left(convert(varchar, tito.RealTimeOut, 108),5) else '' end)
			else null end) as ThucTe
			,mot.NgayNghiBu
		from
		HR_MaxOvertime mot
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,GETDATE())) empl
		on mot.Employee_ID=empl.Employee_ID
		left join
		HR_Shifts s
		on mot.ShiftName=s.ShiftName
		left join
		[dbo].[udf_ReturnTableOTLuyTien](@fromdate) OTLuyTien
		on mot.Employee_ID=OTLuyTien.Employee_ID
		left join
		HR_TimeIn_TimeOut tito
		on mot.Employee_ID=tito.Employee_ID and mot.workingdate=tito.ot_date
		where empl.Employee_ID is not null
			and mot.workingdate between @fromdate and @todate
			and ISNULL(mot.printstatus,0)=0
	end else if @TypeOfReport = 6 begin
		select *
		from
		HR_TangCaNgoaiLe_SK1
		where Ngay_SK1 between @NgayDauThang and @NgayCuoiThang
	end else if @TypeOfReport = 7 begin
		select *
		from
		HR_TangCaNgoaiLe_SK2
		where Ngay_SK2 between @NgayDauThang and @NgayCuoiThang
	end
END




GO
