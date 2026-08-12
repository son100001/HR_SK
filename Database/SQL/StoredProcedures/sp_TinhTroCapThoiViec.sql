
CREATE proc [dbo].[sp_TinhTroCapThoiViec]
@fromdate datetime,
@todate datetime,
@TypeOfReport int, --1: Nghỉ việc từ 23 tháng trước đến 02, 2: Nghỉ việc từ 03 > 12, 3: Nghỉ việc từ 13 > 22
@LAN nvarchar(50)='VN',
@fact nvarchar(50)=null,
@dept nvarchar(50)=null,
@sect nvarchar(50)=null,
@team nvarchar(50)=null,
@pos nvarchar(50)=null,
@posc nvarchar(50)=null
as
begin
	--exec sp_TinhTroCapThoiViec '2025-09-01', '2025-09-30', 3
	Declare @LuongBinhQuan6Thang table (Employee_ID nvarchar(50), LuongBinhQuan6Thang float)
	Declare @EndOfMonth datetime, @Lastmonth datetime, @Last2month datetime, @Last3month datetime, @Last4month datetime, @FirstOfLastMonth datetime, @EndOfLastMonth datetime, @Last5month datetime, @Last6month datetime
			,@Ngay2 datetime,@Ngay3 datetime, @Ngay12 datetime, @Ngay13 datetime, @Ngay22 datetime, @Ngay23ThangTruoc datetime, @Ngay2ThangSau datetime, @Ngay3ThangSau datetime
	set @EndOfMonth = EOMONTH(@fromdate)
	set @Lastmonth = EOMONTH(Dateadd(Month, -1, @todate))
	set @Last2month = EOMONTH(Dateadd(Month, -2, @todate))
	set @Last3month = EOMONTH(Dateadd(Month, -3, @todate))
	set @Last4month = EOMONTH(Dateadd(Month, -4, @todate))
	set @Last5month = EOMONTH(Dateadd(Month, -4, @todate))
	set @Last6month = EOMONTH(Dateadd(Month, -4, @todate))
	set @Ngay2 = DATEFROMPARTS(Year(@EndOfMonth),Month(@EndOfMonth),2)
	set @Ngay3 = DATEFROMPARTS(Year(@EndOfMonth),Month(@EndOfMonth),3)
	set @Ngay12 = DATEFROMPARTS(Year(@EndOfMonth),Month(@EndOfMonth),12)
	set @Ngay13 = DATEFROMPARTS(Year(@EndOfMonth),Month(@EndOfMonth),13)
	set @Ngay22 = DATEFROMPARTS(Year(@EndOfMonth),Month(@EndOfMonth),22)
	set @Ngay23ThangTruoc = DATEFROMPARTS(Year(@Lastmonth),Month(@Lastmonth),23)

	insert into @LuongBinhQuan6Thang (Employee_ID, LuongBinhQuan6Thang)
	select empl.Employee_ID
			, (isnull(blcd.CD1,0) + isnull(blcdL1.CD1,0) + isnull(blcdL2.CD1,0) + isnull(blcdL3.CD1,0) + isnull(blcdL4.CD1,0) + isnull(blcdL5.CD1,0))
				/ dbo.udf_CompareGetMax(((case when blcd.CD1 is null then 0 else 1 end) + (case when blcdL1.CD1 is null then 0 else 1 end) + (case when blcdL2.CD1 is null then 0 else 1 end) 
					+ (case when blcdL3.CD1 is null then 0 else 1 end) + (case when blcdL4.CD1 is null then 0 else 1 end) + (case when blcdL5.CD1 is null then 0 else 1 end)),1)
	from
	SmartBooks_Employee empl
	left join
	udf_BangLuongCoDinh (@todate,null) blcd
	on empl.Employee_ID = blcd.Employee_ID
	left join
	udf_BangLuongCoDinh (@Lastmonth,null) blcdL1
	on empl.Employee_ID = blcdL1.Employee_ID
	left join
	udf_BangLuongCoDinh (@Last2month,null) blcdL2
	on empl.Employee_ID = blcdL2.Employee_ID
	left join
	udf_BangLuongCoDinh (@Last3month,null) blcdL3
	on empl.Employee_ID = blcdL3.Employee_ID
	left join
	udf_BangLuongCoDinh (@Last4month,null) blcdL4
	on empl.Employee_ID = blcdL4.Employee_ID
	left join
	udf_BangLuongCoDinh (@Last5month,null) blcdL5
	on empl.Employee_ID = blcdL5.Employee_ID
	where 
		(
			@TypeOfReport = 1 and empl.TernimationDate between @Ngay23ThangTruoc and @Ngay2
		)
		or
		(
			@TypeOfReport = 2 and empl.TernimationDate between @Ngay3 and @Ngay12
		)
		or
		(
			@TypeOfReport = 3 and empl.TernimationDate between @Ngay13 and @Ngay22
		)

	select *
	from 
	@LuongBinhQuan6Thang

	--Declare @rtnTinhTroCapThoiViec table 

	--declare @rtnTinhTraLaiLuongThuViec table (Employee_ID nvarchar(50), FullName nvarchar(50), Factory_ID nvarchar(50), OrderBy int, Factory nvarchar(50), StartedDate datetime, LastDayOfProbation datetime, [Luong15thang-3] float, [Luong15Thang-2] float, [Luong15Thang-1] float, TongLuong85 float, TongLuong100 float, NhanLaiLuong15 float, primary key(Employee_ID))
	--insert into @rtnTinhTraLaiLuongThuViec (Employee_ID, FullName, Factory_ID, OrderBy, Factory, StartedDate, LastDayOfProbation, [Luong15Thang-3], [Luong15thang-2], [Luong15Thang-1], TongLuong85, TongLuong100)
	--select empl.Employee_ID, dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName, empl.Factory_ID, f.OrderBy, empl.FactoryName, empl.StartedDate, Dateadd(day,-1,nkhdct.NgayKyHDChinhThuc) as LastDayOfProbation
	--		, isnull(sallast3month.TongLuongThuViec,0)/85*15 as [LuongThang-3], isnull(sallast2month.TongLuongThuViec,0)/85*15 as [LuongThang-2], isnull(sallastmonth.TongLuongThuViec,0)/85*15 as [LuongThang-1]
	--		, isnull(sallastmonth.TongLuongThuViec,0) + isnull(sallast2month.TongLuongThuViec,0) + isnull(sallast3month.TongLuongThuViec,0) /*+ isnull(sallast4month.TongLuongThuViec,0)*/ as TongLuong85
	--		, (isnull(sallastmonth.TongLuongThuViec,0) + isnull(sallast2month.TongLuongThuViec,0) + isnull(sallast3month.TongLuongThuViec,0) /*+ isnull(sallast4month.TongLuongThuViec,0)*/)/85*100 as TongLuong100
	--from 
	--udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@todate) empl
	--left join
	--HR_Factory f
	--on empl.Factory_ID = f.Factory_ID
	--left join
	--udf_NgayKyHDChinhThuc(@FirstOfLastMonth,@todate,null) nkhdct
	--on empl.Employee_ID = nkhdct.Employee_ID
	--left join
	--SmartBooks_Salary sallastmonth
	--on empl.Employee_ID = sallastmonth.Employee_ID and sallastmonth.Salary_Year = Year(@Lastmonth) and sallastmonth.Salary_Month = MONTH(@Lastmonth) and sallastmonth.[key] = @SalaryKey
	--left join
	--SmartBooks_Salary sallast2month
	--on empl.Employee_ID = sallast2month.Employee_ID and sallast2month.Salary_Year = Year(@Last2month) and sallast2month.Salary_Month = MONTH(@Last2month) and sallast2month.[key] = @SalaryKey
	--left join
	--SmartBooks_Salary sallast3month
	--on empl.Employee_ID = sallast3month.Employee_ID and sallast3month.Salary_Year = Year(@Last3month) and sallast3month.Salary_Month = MONTH(@Last3month) and sallast3month.[key] = @SalaryKey
	--/*left join
	--SmartBooks_Salary sallast4month
	--on empl.Employee_ID = sallast4month.Employee_ID and sallast4month.Salary_Year = Year(@Last4month) and sallast4month.Salary_Month = MONTH(@Last4month) and sallast4month.[key] = @SalaryKey*/
	--where dateadd(day,-1,nkhdct.NgayKyHDChinhThuc) between @FirstOfLastMonth and @EndOfLastMonth and isnull(empl.Nationality,'Vietnamese') = 'Vietnamese' and nkhdct.NgayKyHDChinhThuc > '2022-03-01'

	--Delete from HR_SalaryComponentFollowMonth
	--where SalaryComponent = 'HTTV' and Remark = cast(MONTH(@FirstOfLastMonth) as nvarchar(3)) + '_' + cast(YEAR(@FirstOfLastMonth) as nvarchar(5)) and Employee_ID in (select Employee_ID from @rtnTinhTraLaiLuongThuViec) and UserName = 'auto'

	--update ttlltv 
	--set NhanLaiLuong15 = TongLuong100 - TongLuong85 - isnull(scfmpaid.sumpaid,0)
	--from @rtnTinhTraLaiLuongThuViec ttlltv
	--left join
	--(
	--	select Employee_ID, sum(isnull(Amount,0)) as sumpaid from HR_SalaryComponentFollowMonth where SalaryComponent = 'HTTV' and (Year_ < Year(@todate) or Month_ < (@todate)) group by Employee_ID
	--) scfmpaid
	--on ttlltv.Employee_ID = scfmpaid.Employee_ID

	----Nhập vào bảng Lương theo tháng
	--insert into HR_SalaryComponentFollowMonth (Employee_ID, SalaryComponent, Amount, Year_, Month_, Remark, InsertDate, UserName)
	--select Employee_ID, 'HTTV', NhanLaiLuong15/(case when day(StartedDate) <= 1 then 2 else 3 end) as NhanLaiLuong15, YEAR(Dateadd(Month, 1, LastDayOfProbation)), MONTH(Dateadd(Month, 1, LastDayOfProbation)), cast(MONTH(LastDayOfProbation) as nvarchar(3)) + '_' + cast(YEAR(LastDayOfProbation) as nvarchar(5)) as Remark, GETDATE(), 'auto'
	--from @rtnTinhTraLaiLuongThuViec
	
	--insert into HR_SalaryComponentFollowMonth (Employee_ID, SalaryComponent, Amount, Year_, Month_, Remark, InsertDate, UserName)
	--select Employee_ID, 'HTTV', NhanLaiLuong15/(case when day(StartedDate) <= 1 then 2 else 3 end) as NhanLaiLuong15, YEAR(Dateadd(Month, 2, LastDayOfProbation)), MONTH(Dateadd(Month, 2, LastDayOfProbation)), cast(MONTH(LastDayOfProbation) as nvarchar(3)) + '_' + cast(YEAR(LastDayOfProbation) as nvarchar(5)) as Remark, GETDATE(), 'auto'
	--from @rtnTinhTraLaiLuongThuViec

	----Block
	--/*insert into HR_SalaryComponentFollowMonth (Employee_ID, SalaryComponent, Amount, Year_, Month_, Remark, InsertDate, UserName)
	--select Employee_ID, 'HTTV', NhanLaiLuong15/(case when day(StartedDate) <= 15 then 2 else 3 end) as NhanLaiLuong15, YEAR(Dateadd(Month, 3, LastDayOfProbation)), MONTH(Dateadd(Month, 3, LastDayOfProbation)), cast(MONTH(LastDayOfProbation) as nvarchar(3)) + '_' + cast(YEAR(LastDayOfProbation) as nvarchar(5)) as Remark, GETDATE(), 'auto'
	--from @rtnTinhTraLaiLuongThuViec*/

	--insert into HR_SalaryComponentFollowMonth (Employee_ID, SalaryComponent, Amount, Year_, Month_, Remark, InsertDate, UserName)
	--select Employee_ID, 'HTTV', (case when day(StartedDate) <= 1 then 0 else NhanLaiLuong15/3 end) as NhanLaiLuong15, YEAR(Dateadd(Month, 3, LastDayOfProbation)), MONTH(Dateadd(Month, 3, LastDayOfProbation)), cast(MONTH(LastDayOfProbation) as nvarchar(3)) + '_' + cast(YEAR(LastDayOfProbation) as nvarchar(5)) as Remark, GETDATE(), 'auto'
	--from @rtnTinhTraLaiLuongThuViec

	--select ttltv.*, sc.Amount
	--from @rtnTinhTraLaiLuongThuViec ttltv
	--left join
	--HR_SalaryComponentFollowMonth sc
	--on ttltv.Employee_ID = sc.Employee_ID and sc.SalaryComponent = 'HTTV'
	--where sc.Month_ = month(@fromdate) and sc.Year_ = year(@fromdate)
	--order by OrderBy, ttltv.Employee_ID

	--select * from @rtnTinhTraLaiLuongThuViec
end
GO
