CREATE PROCEDURE [dbo].[sp_BangLuongCoDinh]
	--exec sp_BangLuongCoDinh '2025-08-01','2025-08-31',2,'VN',null,null,null,null,null,null
	--exec sp_BangLuongCoDinh '2025-08-01','2025-08-31',3,'VN',null,null,null,null,null,null
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,--1:xem lương theo bảng dọc, 2: xem lương theo bảng ngang
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@emp nvarchar(50)=null
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @SalaryCatogory varchar(500),@DynamicPivotQuery AS NVARCHAR(MAX)
	Declare @ID int,@Emp_ID nvarchar(50),@Amount float,@ValueConvert varchar(50),@Period datetime
	--create table #tabSalaryComponent (Period datetime,[ID] int,[Employee_ID] nvarchar(50),[SalaryComponent] nvarchar(50),[Amount] float,[Fromdate] datetime,[Todate] datetime,[Remark] nvarchar(max),[InsertDate] datetime,[UserName] nvarchar(50),[InsertSource] varchar(50))
	--CREATE INDEX index_Employee
	--ON #tabSalaryComponent (Employee_ID)
	DECLARE @tabSalaryComponent as table(Period datetime,[ID] int,[Employee_ID] nvarchar(50),[SalaryComponent] nvarchar(50),[Amount] float,[Fromdate] datetime,[Todate] datetime,[Remark] nvarchar(max),[InsertDate] datetime,[UserName] nvarchar(50),[InsertSource] varchar(50))--, primary key([Employee_ID],[SalaryComponent],[Fromdate]))
	-- TẠO DANH MỤC PIVOT
	set @SalaryCatogory=''
	select @SalaryCatogory=@SalaryCatogory+SalaryComponent+',' from HR_SalaryComponentCategory where isnull(MonthlyChanging,0)=0 order by OrderBy
	set @SalaryCatogory=left(@SalaryCatogory,len(@SalaryCatogory)-1)

	DECLARE cur_Employee CURSOR LOCAL FOR
		select Employee_ID from smartbooks_employee where Employee_ID in (select Employee_ID from HR_SalaryComponent) and (case when isnull(@emp,'')='' then '' else Employee_ID end)=isnull(@emp,'')
		OPEN  cur_Employee
		FETCH NEXT FROM cur_Employee INTO @Emp_ID
		WHILE @@FETCH_STATUS = 0
		BEGIN
			DECLARE cur_Period CURSOR LOCAL FOR
			select distinct [Fromdate] from [dbo].[HR_SalaryComponent] where Employee_ID=@Emp_ID and [Fromdate]<=@todate and (Todate is null or Todate>=@fromdate)
			OPEN  cur_Period
			FETCH NEXT FROM cur_Period INTO @Period
			WHILE @@FETCH_STATUS = 0
			BEGIN
				insert into @tabSalaryComponent
				select @Period,sc.ID,sc.Employee_ID,sc.SalaryComponent,case when sc.SalaryComponent = 'TCC' then isnull(sc.Amount,500000) else sc.Amount end as Amount,sc.Fromdate,sc.Todate,sc.Remark,sc.InsertDate,sc.UserName,sc.InsertSource from
				(select [SalaryComponent],max(Fromdate) as Fromdate from [dbo].[HR_SalaryComponent] where Employee_ID=@Emp_ID and Fromdate<=@Period and (Todate is null or Todate>=@Period) group by [SalaryComponent]) as scmax
				left join
				(select * from [dbo].[HR_SalaryComponent] where Employee_ID=@Emp_ID)sc
				on scmax.[SalaryComponent]=sc.[SalaryComponent] and scmax.Fromdate=sc.Fromdate
			FETCH NEXT FROM cur_Period INTO @Period
			END
			CLOSE cur_Period
			DEALLOCATE cur_Period
		FETCH NEXT FROM cur_Employee INTO @Emp_ID
		END
		CLOSE cur_Employee
		DEALLOCATE cur_Employee
		--select * from #tabSalaryComponent where Employee_ID='20140006' and Fromdate='2018-2-1'
	if @TypeOfReport=1 begin
		--show
		select sc.Period, empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
				,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
				,sc.[SalaryComponent],case when @LAN = 'EN' then scc.NameEN when @LAN = 'KR' then scc.NameKR else scc.NameVN end as [Name],sc.[Amount],sc.[Fromdate],sc.[Todate],sc.[InsertSource],sc.[Remark],sc.[InsertDate],sc.[UserName],sc.ID
			from
			@tabSalaryComponent  sc
			left join
			--smartbooks_employee empl
			udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,getdate())) empl
			on sc.Employee_ID=empl.Employee_ID
			left join
			HR_SalaryComponentCategory scc
			on sc.SalaryComponent=scc.SalaryComponent
			where empl.employee_id is not null
	end else if @TypeOfReport=2 begin
		IF OBJECT_ID('tempdb..#tabSalaryHorizontal') IS NOT NULL DROP TABLE #tabSalaryHorizontal
		select sc.Period, empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
				,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
				,sc.[SalaryComponent],sc.[Amount]--, ROW_NUMBER () over (partition by empl.Employee_ID, sc.[Period] order by sc.[Period] desc) as rn
				into #tabSalaryHorizontal
			from
			@tabSalaryComponent sc
			left join
			udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,getdate())) empl
			on sc.Employee_ID=empl.Employee_ID
			left join
			HR_SalaryComponentCategory scc
			on sc.SalaryComponent=scc.SalaryComponent
			where empl.employee_id is not null

		-- TẠO QUERY PIVOT
		SET @DynamicPivotQuery = 'select * from #tabSalaryHorizontal ' + N' PIVOT ( SUM(Amount) FOR SalaryComponent IN ('+ @SalaryCatogory +')) AS pv'
		exec (@DynamicPivotQuery)
	end else if @TypeOfReport=3 begin
		--select *, ROW_NUMBER () over (partition by Employee_ID order by [Period] desc) as rn from
		--@tabSalaryComponent
		if @fromdate = @todate
			set @todate = EOMONTH(@fromdate)
		IF OBJECT_ID('tempdb..#tabSalaryHorizontal1') IS NOT NULL DROP TABLE #tabSalaryHorizontal1
		select sc.Period, empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
				,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
				,sc.[SalaryComponent],sc.[Amount]--, ROW_NUMBER () over (partition by sc.Employee_ID, sc.[Period] order by sc.[Period] desc) as rn
				into #tabSalaryHorizontal1
			from
			@tabSalaryComponent sc
			left join
			udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,getdate())) empl
			on sc.Employee_ID=empl.Employee_ID
			left join
			HR_SalaryComponentCategory scc
			on sc.SalaryComponent=scc.SalaryComponent
			where empl.employee_id is not null and isnull(empl.TernimationDate,@Fromdate) >= @fromdate

		-- TẠO QUERY PIVOT
		SET @DynamicPivotQuery = 'Select * from (select *, ROW_NUMBER () over (partition by Employee_ID order by [Period] desc) as rn from (select * from #tabSalaryHorizontal1 PIVOT ( SUM(Amount) FOR SalaryComponent IN ('+ @SalaryCatogory +')) AS pv) pv) pv where rn = 1'
		--print @DynamicPivotQuery
		exec (@DynamicPivotQuery)
	end
END




GO
