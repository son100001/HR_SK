CREATE PROCEDURE [dbo].[sp_BangLuongThoiViec]
	-- Add the parameters for the stored procedure here
	--exec [dbo].[sp_BangLuongThoiViec] '4','2020',3,'VN'
	@month int,
	@year int,
	@TypeOfReport int=1,
	@LAN nvarchar(50)='VN',
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
	declare @fromdate datetime, @todate datetime
	set @fromdate=DATEFROMPARTS(@year,@month,2)
	set @todate=dateadd(month,1,@fromdate)-1
	if @TypeOfReport=1 begin--trợ cấp thôi việc
		select 'TroCapThoiViec' as SalaryKey,datepart(month,@fromdate) as Salary_Month, datepart(year,@fromdate) as Salary_Year,null as PayDate
		,empl.sectionname,empl.PositionName,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		,empl.StartedDate,empl.ComStartedDate
		,(case when not(isnull(empl.bankaccount,'')='' or isnull(erp.ParameterValue,'2')='1') then empl.BankAccount else null end) as BankAccount
		,tctv.TienLuong1,tctv.TienLuong2,tctv.TienLuong3,tctv.TienLuong4,tctv.TienLuong5,tctv.TienLuong6,tctv.LuongBQ
		,tctv.SoThangTruoc2009,tctv.SoThangNghiBH,tctv.TongSoNam,tctv.TongSoThang,tctv.TroCapTV
		,tctv.GhiChuNghiBH
		from 
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@todate) empl
		inner join
		[dbo].[udf_TroCapTV](@Month,@Year) tctv
		on empl.Employee_ID=tctv.Employee_ID
		left join
		smartbooks_salary ss
		on empl.Employee_ID=ss.Employee_ID and ss.salary_month=@month and ss.salary_year=@year and ss.[Key]='TroCapThoiViec' and ss.TrangThai=1
		left join
		[dbo].[HR_EmpRegisParameter] erp
		on empl.Employee_ID=erp.Employee_ID and dateadd(day,-1,dateadd(month,1,DATEFROMPARTS(@year,@month,1))) between erp.Fromdate and erp.todate and erp.Parameter='HinhThucThanhToanLuong'
		where empl.TernimationDate between @fromdate and @todate and ss.Employee_id is null
	end else if @TypeOfReport=2 begin--Thanh toán phép năm
		select 'ThanhToanPhepNam' as SalaryKey,datepart(month,@fromdate) as Salary_Month, datepart(year,@fromdate) as Salary_Year,null as PayDate
		,empl.sectionname,empl.PositionName,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		,empl.StartedDate,empl.ComStartedDate
		,(case when not(isnull(empl.bankaccount,'')='' or isnull(erp.ParameterValue,'2')='1') then empl.BankAccount else null end) as BankAccount
		,ttpn.TienLuong1,ttpn.TienLuong2,ttpn.TienLuong3,ttpn.TienLuong4,ttpn.TienLuong5,ttpn.TienLuong6,ttpn.LuongBQ
		,ttpn.SoNgayPNTon,ttpn.TienPN
		from 
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@todate) empl
		inner join
		[dbo].[udf_ThanhToanPhepNam](@Month,@Year) ttpn
		on empl.Employee_ID=ttpn.Employee_ID
		left join
		smartbooks_salary ss
		on empl.Employee_ID=ss.Employee_ID and ss.salary_month=@month and ss.salary_year=@year and ss.[Key]='ThanhToanPhepNam' and ss.TrangThai=1
		left join
		[dbo].[HR_EmpRegisParameter] erp
		on empl.Employee_ID=erp.Employee_ID and dateadd(day,-1,dateadd(month,1,DATEFROMPARTS(@year,@month,1))) between erp.Fromdate and erp.todate and erp.Parameter='HinhThucThanhToanLuong'
		where empl.TernimationDate between @fromdate and @todate and ss.Employee_id is null
	end else if @TypeOfReport in (3,4) begin--trợ cấp con nhỏ
		IF OBJECT_ID('tempdb..#TroCapConNho') IS NOT NULL DROP TABLE #TroCapConNho
		select 'TroCapConNho' as SalaryKey,datepart(month,@fromdate) as Salary_Month, datepart(year,@fromdate) as Salary_Year,null as PayDate
		,empl.sectionname,empl.PositionName,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		,empl.StartedDate,empl.ComStartedDate
		,(case when not(isnull(empl.bankaccount,'')='' or isnull(erp.ParameterValue,'2')='1') then empl.BankAccount else null end) as BankAccount
		,tccn.TenCuaBe,tccn.NgaySinhCuaBe,tccn.NamSinh,tccn.TuoiCuaBe,tccn.TinhHoTroTu,tccn.TinhHoTroDen,tccn.SoThang,tccn.SoNgay,tccn.TienTroCapConNho
		into #TroCapConNho
		from 
		[dbo].[udf_TroCapConNho](@Month,@Year) tccn
		inner join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@todate) empl
		on empl.Employee_ID=tccn.Employee_ID
		left join
		smartbooks_salary ss
		on empl.Employee_ID=ss.Employee_ID and ss.salary_month=@month and ss.salary_year=@year and ss.[Key]='TroCapConNho' and ss.TrangThai=1
		left join
		[dbo].[HR_EmpRegisParameter] erp
		on empl.Employee_ID=erp.Employee_ID and dateadd(day,-1,dateadd(month,1,DATEFROMPARTS(@year,@month,1))) between erp.Fromdate and erp.todate and erp.Parameter='HinhThucThanhToanLuong'
		where empl.TernimationDate between @fromdate and @todate and ss.Employee_id is null
		if @TypeOfReport=3 begin
			select * from #TroCapConNho
		end else if @TypeOfReport=4 begin
			select SalaryKey,Salary_Month,Salary_Year,PayDate
			,sectionname,PositionName,Employee_ID,FullName
			,StartedDate,ComStartedDate,BankAccount
			,sum(isnull(TienTroCapConNho,0)) as TienTroCapConNho
			 from #TroCapConNho
			 group by
			 SalaryKey,Salary_Month,Salary_Year,PayDate
			,sectionname,PositionName,Employee_ID,FullName
			,StartedDate,ComStartedDate,BankAccount
		end
	end
END




GO
