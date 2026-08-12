CREATE PROCEDURE [dbo].[sp_BangQuanLyPhepNam]
	-- Add the parameters for the stored procedure here
	--exec sp_BangQuanLyPhepNam '2023-01-31',4,'VN',null,null,null,null,null,null,null,1,null
	@NgayChot datetime,
	@TypeOfReport int=1,
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Emp nvarchar(50)=null,
	@IsActive bit=1,
	@ListOfLeaveType_ID varchar(100)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @NgayDauNam datetime, @NgayCuoiNam datetime, @NgayDauThang datetime, @NgayCuoiThang datetime
	Declare @year int = Year(@NgayChot)
	print @year
	set @NgayDauNam=cast(@year as varchar)+'-1-1'
	set @NgayCuoiNam=DATEADD(year,1,@NgayDauNam)-1
	select @NgayCuoiThang = EOMONTH(@NgayChot)
	Select @NgayDauThang = dateadd(month,-1,@NgayCuoiThang+1)
	if @TypeOfReport=1 begin
		declare @tabPhep table(Employee_ID nvarchar(50),jan float,feb float,mar float,apr float,may float,jun float,jul float,aug float,sep float,oct float,nov float,[Dec] float primary key(Employee_ID))
		insert into @tabPhep
		select Employee_ID
			,sum(case when DATEPART(month,DateLeave)=1 then HourLeave/8.0 else 0 end) as jan
			,sum(case when DATEPART(month,DateLeave)=2 then HourLeave/8.0 else 0 end) as feb
			,sum(case when DATEPART(month,DateLeave)=3 then HourLeave/8.0 else 0 end) as mar
			,sum(case when DATEPART(month,DateLeave)=4 then HourLeave/8.0 else 0 end) as apr
			,sum(case when DATEPART(month,DateLeave)=5 then HourLeave/8.0 else 0 end) as may
			,sum(case when DATEPART(month,DateLeave)=6 then HourLeave/8.0 else 0 end) as jun	
			,sum(case when DATEPART(month,DateLeave)=7 then HourLeave/8.0 else 0 end) as jul
			,sum(case when DATEPART(month,DateLeave)=8 then HourLeave/8.0 else 0 end) as aug
			,sum(case when DATEPART(month,DateLeave)=9 then HourLeave/8.0 else 0 end) as sep
			,sum(case when DATEPART(month,DateLeave)=10 then HourLeave/8.0 else 0 end) as oct
			,sum(case when DATEPART(month,DateLeave)=11 then HourLeave/8.0 else 0 end) as nov
			,sum(case when DATEPART(month,DateLeave)=12 then HourLeave/8.0 else 0 end) as [Dec]
		from [dbo].[udf_BangPhepTheoNgay](2,@NgayDauNam,@NgayChot,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) bptn
		left join
		SmartBooks_LeaveType lt
		on bptn.LeaveType_ID = lt.LeaveType_ID
		where isnull(lt.PhepNam,0) = 1 or bptn.LeaveType_ID in ('31','32') and bptn.Employee_ID is not null
		group by Employee_ID

		select empl.factoryname,empl.departmentname,empl.sectionname,empl.teamname,empl.Positionname
		,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.birthdate,empl.StartedDate,empl.ComStartedDate,empl.Employee_Status,empl.TernimationDate
		,pn.PhepNamTon,pn.PhepNamDuocHuong
		,pn.PhepNamDuocHuongDenHienTai_ChuaLamTron
		,pn.PhepNamDuocHuongDenHienTai
		,pn.PhepNamConLai
		--,isnull(pn.PhepNamDuocHuongDenHienTai,0)+isnull(pn.PhepNamTon,0)-(isnull(jan,0)+isnull(feb,0)+isnull(mar,0)+isnull(apr,0)+isnull(may,0)+isnull(jun,0)+isnull(jul,0)+isnull(aug,0)+isnull(sep,0)+isnull(oct,0)+isnull(nov,0)+isnull([Dec],0)) as PhepNamConLaiDenHienTai
		--,(case when isnull(pnchitiet.jan,0)=0 then null else pnchitiet.jan end) as jan
		--,(case when isnull(pnchitiet.feb,0)=0 then null else pnchitiet.feb end) as feb
		--,(case when isnull(pnchitiet.mar,0)=0 then null else pnchitiet.mar end) as mar
		--,(case when isnull(pnchitiet.apr,0)=0 then null else pnchitiet.apr end) as apr
		--,(case when isnull(pnchitiet.may,0)=0 then null else pnchitiet.may end) as may
		--,(case when isnull(pnchitiet.jun,0)=0 then null else pnchitiet.jun end) as jun
		--,(case when isnull(pnchitiet.jul,0)=0 then null else pnchitiet.jul end) as jul
		--,(case when isnull(pnchitiet.aug,0)=0 then null else pnchitiet.aug end) as aug
		--,(case when isnull(pnchitiet.sep,0)=0 then null else pnchitiet.sep end) as sep
		--,(case when isnull(pnchitiet.oct,0)=0 then null else pnchitiet.oct end) as oct
		--,(case when isnull(pnchitiet.nov,0)=0 then null else pnchitiet.nov end) as nov
		--,(case when isnull(pnchitiet.[Dec],0)=0 then null else pnchitiet.[Dec] end) as [Dec]
		,pnchitiet.jan,pnchitiet.feb,pnchitiet.mar,pnchitiet.apr,pnchitiet.may,pnchitiet.jun,pnchitiet.jul,pnchitiet.aug,pnchitiet.sep,pnchitiet.oct,pnchitiet.nov,pnchitiet.[Dec]
		
		from
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,@NgayCuoiNam) empl
		left join
		[dbo].[udf_QuanLyPhepNam](@year,@NgayChot,@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp) pn
		on empl.Employee_ID=pn.Employee_ID
		left join
		@tabPhep pnchitiet
		on empl.Employee_ID=pnchitiet.Employee_ID
		where pn.PhepNamDuocHuong>0 and isnull(empl.TernimationDate,@NgayChot) >= @NgayChot
	end if @TypeOfReport=2 begin
		select isnull(p.Name,empl.Position) as Position
		,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate,empl.ComStartedDate,empl.Employee_Status,empl.TernimationDate
		,pn.PhepNamDuocHuong,pn.PhepNamTon,pn.TongPhepNamDaNghi
		,(Case when isnull(pn.PhepNamDuocHuong,0)+isnull(pn.PhepNamTon,0)-isnull(pn.TongPhepNamDaNghi,0)>0 then isnull(pn.PhepNamDuocHuong,0)+isnull(pn.PhepNamTon,0)-isnull(pn.TongPhepNamDaNghi,0) else 0 end) as TongPhepNamConLai
		from
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,@NgayCuoiNam) empl
		left join
		[dbo].[udf_QuanLyPhepNam](@year,@NgayChot,@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp) pn
		on empl.Employee_ID=pn.Employee_ID
		left join
		udf_Position(@LAN,0) p
		on empl.Position=p.Code
		left join
		HR_EmployeeRegisMaternityLeave ermlSending
		on empl.Employee_ID=ermlSending.Employee_ID and ermlSending.LeaveType_ID='28' and GETDATE() between ermlSending.Fromdate and ermlSending.ToDate
		where (case when (empl.TernimationDate is null or empl.TernimationDate>@NgayCuoiNam) and ermlSending.Employee_ID is null then 1 else 0 end)=isnull(@IsActive,0)
			and pn.PhepNamDuocHuong>0
	end if @TypeOfReport=3 begin
		declare @tabKhongPhep table(Employee_ID nvarchar(50),jan float,feb float,mar float,apr float,may float,jun float,jul float,aug float,sep float,oct float,nov float,[Dec] float primary key(Employee_ID))
		insert into @tabKhongPhep
		select Employee_ID
			,sum(case when DATEPART(month,DateLeave)=1 then HourLeave/8.0 else 0 end) as jan
			,sum(case when DATEPART(month,DateLeave)=2 then HourLeave/8.0 else 0 end) as feb
			,sum(case when DATEPART(month,DateLeave)=3 then HourLeave/8.0 else 0 end) as mar
			,sum(case when DATEPART(month,DateLeave)=4 then HourLeave/8.0 else 0 end) as apr
			,sum(case when DATEPART(month,DateLeave)=5 then HourLeave/8.0 else 0 end) as may
			,sum(case when DATEPART(month,DateLeave)=6 then HourLeave/8.0 else 0 end) as jun	
			,sum(case when DATEPART(month,DateLeave)=7 then HourLeave/8.0 else 0 end) as jul
			,sum(case when DATEPART(month,DateLeave)=8 then HourLeave/8.0 else 0 end) as aug
			,sum(case when DATEPART(month,DateLeave)=9 then HourLeave/8.0 else 0 end) as sep
			,sum(case when DATEPART(month,DateLeave)=10 then HourLeave/8.0 else 0 end) as oct
			,sum(case when DATEPART(month,DateLeave)=11 then HourLeave/8.0 else 0 end) as nov
			,sum(case when DATEPART(month,DateLeave)=12 then HourLeave/8.0 else 0 end) as [Dec]
		from
		[dbo].[udf_BangPhepTheoNgay](2,@NgayDauNam,@NgayChot,@fact,@dept,@sect,@team,@pos,@posc,@emp,@ListOfLeaveType_ID)
		group by Employee_ID

		select empl.PositionFullName
		,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.birthdate,empl.StartedDate,empl.Employee_Status,empl.TernimationDate
		,kp.jan,kp.feb,kp.mar,kp.apr,kp.may,kp.jun,kp.jul,kp.aug,kp.sep,kp.oct,kp.nov,kp.[Dec]
		,isnull(jan,0)+isnull(feb,0)+isnull(mar,0)+isnull(apr,0)+isnull(may,0)+isnull(jun,0)+isnull(jul,0)+isnull(aug,0)+isnull(sep,0)+isnull(oct,0)+isnull(nov,0)+isnull([Dec],0) as TongCong
		from
		@tabKhongPhep kp
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,@NgayCuoiNam) empl	
		on empl.Employee_ID=kp.Employee_ID
		where empl.Employee_ID is not null and isnull(empl.TernimationDate,@NgayChot) >= @NgayChot
	end if @TypeOfReport = 4 begin
		select empl.DepartmentGroup, empl.DepartmentCode1, count(empl.Employee_ID) as ManPower, sum(isnull(qlpn.PhepNamConLai,0) + isnull(qlpn.PhepNamDaNghiTrongThang,0)) as PhepNamDauThang, sum(isnull(qlpn.PhepNamConLai,0)) as PhepNamConLai
		from
		udf_EmployeeFilter('VN',null,null,null,null,null,null,null,GETDATE()) empl
		left join
		udf_QuanLyPhepNam(Year(@NgayDauThang),@NgayCuoiThang,'VN',null,null,null,null,null,null,null) qlpn
		on empl.Employee_ID = qlpn.Employee_ID
		where empl.StartedDate <= @NgayCuoiThang and isnull(empl.TernimationDate,@NgayCuoiThang) > @NgayDauThang
		group by empl.DepartmentGroup, empl.DepartmentCode1
		order by empl.DepartmentGroup, empl.DepartmentCode1
	end
END




GO
