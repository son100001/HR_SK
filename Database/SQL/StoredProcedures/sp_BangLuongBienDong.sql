--[dbo].[sp_BangLuongBienDong] '2022','02',1,'VN',N'',N'',N'',N'',N'','',N''
CREATE PROCEDURE [dbo].[sp_BangLuongBienDong]
	--exec sp_BangLuongBienDong '2018','8','2','VN',null,null,null,null,null
	-- Add the parameters for the stored procedure here
	@Year int,
	@Month int,
	@TypeOfReport int=1,--1:xem lương theo bảng dọc, 2: xem lương theo bảng ngang
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

    -- Insert statements for procedure here
	declare @SalaryCatogory varchar(200),@DynamicPivotQuery AS NVARCHAR(MAX),@NgayDauThang datetime
	set @NgayDauThang=cast(@Year as varchar)+'-'+cast(@Month as varchar)+'-1'
	Declare @ID int,@Emp_ID nvarchar(50),@Amount float,@ValueConvert varchar(50),@Period datetime
	create table #tabSalaryComponent (Period datetime,[ID] int,[Employee_ID] nvarchar(50),[SalaryComponent] nvarchar(50),[Amount] float,[Fromdate] datetime,[Todate] datetime,[Remark] nvarchar(max),[InsertDate] datetime,[UserName] nvarchar(50),[InsertSource] varchar(50))
	-- TẠO DANH MỤC PIVOT
	set @SalaryCatogory=''
	select @SalaryCatogory=@SalaryCatogory+SalaryComponent+',' from HR_SalaryComponentCategory where isnull(MonthlyChanging,0)=1 order by OrderBy
	if @SalaryCatogory<>'' begin
		set @SalaryCatogory=left(@SalaryCatogory,len(@SalaryCatogory)-1)
	end

	if @TypeOfReport=1 begin
		SELECT 
		[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
		,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
		,sc.Employee_ID,sc.SalaryComponent,case when @LAN = 'EN' then scc.NameEN when @LAN = 'KR' then scc.NameKR else scc.NameVN end as [Name],sc.Amount,sc.Year_,sc.Month_,sc.Remark,sc.InsertDate,sc.UserName,sc.ID
		from
		[dbo].[HR_SalaryComponentFollowMonth] sc
		left join
		udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@NgayDauThang,getdate())) empl
		on sc.Employee_ID=empl.Employee_ID
		left join
		[dbo].[HR_SalaryComponentCategory] scc
		on sc.[SalaryComponent]=scc.[SalaryComponent]
		where sc.Month_=@Month and sc.Year_=@Year and empl.Employee_ID is not null
	end else if @TypeOfReport=2 begin
		IF OBJECT_ID('tempdb..#tabSalaryHorizontal') IS NOT NULL DROP TABLE #tabSalaryHorizontal
		SELECT 
		[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
		,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
		,sc.Employee_ID,sc.SalaryComponent,sc.Amount,sc.Year_,sc.Month_ into #tabSalaryHorizontal
		from
		[dbo].[HR_SalaryComponentFollowMonth] sc
		left join
		udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@NgayDauThang,getdate())) empl
		on sc.Employee_ID=empl.Employee_ID
		left join
		[dbo].[HR_SalaryComponentCategory] scc
		on sc.[SalaryComponent]=scc.[SalaryComponent]
		where sc.Month_=@Month and sc.Year_=@Year and empl.Employee_ID is not null
		-- TẠO QUERY PIVOT
		SET @DynamicPivotQuery = 'select * from #tabSalaryHorizontal ' + N' PIVOT ( SUM(Amount) FOR SalaryComponent IN ('+ @SalaryCatogory +')) AS pv'
		exec (@DynamicPivotQuery)
	end
END




GO
