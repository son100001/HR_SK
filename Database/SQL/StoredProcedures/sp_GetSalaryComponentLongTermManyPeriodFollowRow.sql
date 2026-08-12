CREATE PROCEDURE [dbo].[sp_GetSalaryComponentLongTermManyPeriodFollowRow]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@SalaryComponent_ nvarchar(50)=null,
	@dept as nvarchar(50)=null,
	@sect as nvarchar(50)=null,
	@team as nvarchar(50)=null,
	@pos as nvarchar(50)=null,
	@posc as nvarchar(50)=null,
	@Employee_ID_ nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @ID int,@Emp_ID nvarchar(50),@SalaryComponent nvarchar(50),@Amount float,@ValueConvert varchar(50),@Period datetime
	create table #tabSalaryComponent (Period datetime,[ID] int,[Employee_ID] nvarchar(50),[SalaryComponent] nvarchar(50),[Amount] float,[Fromdate] datetime,[Todate] datetime,[Remark] nvarchar(max),[InsertDate] datetime,[UserName] nvarchar(50),[InsertSouce] varchar(50))
	
    -- Insert statements for procedure here
	DECLARE cur_Employee CURSOR LOCAL FOR
	select Employee_ID from smartbooks_Employee where
				(case when @Employee_ID_ is null or @Employee_ID_='' then '' else Employee_ID end)=(case when @Employee_ID_ is null or @Employee_ID_='' then '' else @Employee_ID_ end)
				and (case when @dept is null or @dept='' then '' else DepartmentCode end)=(case when @dept is null or @dept='' then '' else @dept end)
				and (case when @sect is null or @sect='' then '' else SectionCode end)=(case when @sect is null or @sect='' then '' else @sect end)
				and (case when @team is null or @team='' then '' else TeamCode end)=(case when @team is null or @team='' then '' else @team end)
				and (case when @pos is null or @pos='' then '' else Position_ID end)=(case when @pos is null or @pos='' then '' else @pos end)
				and (case when @posc is null or @posc='' then '' else PositionCategory_ID end)=(case when @posc is null or @posc='' then '' else @posc end)
				and Employee_ID in (select distinct Employee_ID from HR_SalaryComponent)
	OPEN  cur_Employee
	FETCH NEXT FROM cur_Employee INTO @Emp_ID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE cur_Period CURSOR LOCAL FOR
		select distinct [Fromdate] from [dbo].[HR_SalaryComponent] where Employee_ID=@Emp_ID
		OPEN  cur_Period
		FETCH NEXT FROM cur_Period INTO @Period
		WHILE @@FETCH_STATUS = 0
		BEGIN
			insert into #tabSalaryComponent
			select @Period,sc.* from
			(select [SalaryComponent],max(Fromdate) as Fromdate from [dbo].[HR_SalaryComponent] where Employee_ID=@Emp_ID and Fromdate<=@Period group by [SalaryComponent]) as scmax
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
	--show
	select sc.Employee_ID,[dbo].[udf_FullName]([Employee_Firstname],[Employee_LastName]) as FullName,[StartedDate],[DepartmentCode],[SectionCode],[TeamCode],[Position_ID],[PositionCategory_ID]
		,sc.Period,sc.[SalaryComponent],scc.NameVN,scc.NameEN,scc.NameKR,sc.[Amount],sc.[Fromdate],sc.[Todate],sc.[InsertSouce],sc.[Remark],sc.[InsertDate],sc.[UserName],sc.ID
		from
		#tabSalaryComponent sc
		left join
		[dbo].[SmartBooks_Employee] empl
		on sc.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
		left join
		HR_SalaryComponentCategory scc
		on sc.SalaryComponent COLLATE DATABASE_DEFAULT=scc.SalaryComponent
		where sc.Period between @fromdate and @todate
			and (case when @SalaryComponent_ is null or @SalaryComponent_='' then '' else sc.SalaryComponent end)=(case when @SalaryComponent_ is null or @SalaryComponent_='' then '' else @SalaryComponent_ end)
END

--exec [dbo].[sp_GetSalaryComponentLongTermManyPeriodFollowRow] '2017-09-01','2017-09-30',N''

--select * from [HR_SalaryComponent]




GO
