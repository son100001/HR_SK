-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec [dbo].[sp_GetSalaryComponentLongTermManyPeriod] '',1
CREATE PROCEDURE [dbo].[sp_GetSalaryComponentLongTermManyPeriod]
	-- Add the parameters for the stored procedure here
	@Employee_ID nvarchar(50)=null,
	@ViewEmployeeInfor bit=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @Emp_ID nvarchar(50),@Fromdate datetime,@FromdateDetail datetime,@SalaryComponent nvarchar(50),@Amount float,@ValueConvert varchar(50),@DateTimeConvert varchar(10),@InsertQuery nvarchar(256),@ValuesInsert nvarchar(256)
	create table #tabSalaryComponent (Employee_ID nvarchar(50),Fromdate datetime)
	DECLARE cur_sc CURSOR LOCAL FOR
	select [SalaryComponent] from [dbo].[HR_SalaryComponentCategory]
	OPEN  cur_sc
	FETCH NEXT FROM cur_sc INTO @SalaryComponent
	WHILE @@FETCH_STATUS = 0
	BEGIN
		exec ('alter table #tabSalaryComponent add ['+@SalaryComponent+'] float')
	FETCH NEXT FROM cur_sc INTO @SalaryComponent
	END
	CLOSE cur_sc
	DEALLOCATE cur_sc
    -- Insert statements for procedure here
	DECLARE cur_Employee CURSOR LOCAL FOR
	select Employee_ID from smartbooks_Employee where (case when @Employee_ID is null or @Employee_ID='' then '' else Employee_ID end)=(case when @Employee_ID is null or @Employee_ID='' then '' else @Employee_ID end)
	OPEN  cur_Employee
	FETCH NEXT FROM cur_Employee INTO @Emp_ID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE cur_Fromdate CURSOR LOCAL FOR
		select distinct [Fromdate] from [dbo].[HR_SalaryComponent] where Employee_ID=@Emp_ID
		OPEN  cur_Fromdate
		FETCH NEXT FROM cur_Fromdate INTO @Fromdate
		WHILE @@FETCH_STATUS = 0
		BEGIN
			set @DateTimeConvert=convert(VARCHAR(10), @Fromdate,111)
			set @InsertQuery='insert into #tabSalaryComponent (Employee_ID,Fromdate'
			set @ValuesInsert='N'''+@Emp_ID+''','''+@DateTimeConvert+''''
			DECLARE cur_sc CURSOR LOCAL FOR
			select [SalaryComponent],max(Fromdate) as Fromdate from [dbo].[HR_SalaryComponent] where Employee_ID=@Emp_ID and Fromdate<=@Fromdate group by [SalaryComponent]
			OPEN  cur_sc
			FETCH NEXT FROM cur_sc INTO @SalaryComponent,@FromdateDetail
			WHILE @@FETCH_STATUS = 0
			BEGIN
				select @Amount=Amount from [dbo].[HR_SalaryComponent] where Employee_ID=@Emp_ID and Fromdate=@FromdateDetail and [SalaryComponent]=@SalaryComponent
				set @ValueConvert=convert(VARCHAR(50), @Amount,128)
				set @InsertQuery=@InsertQuery+',['+@SalaryComponent+']'
				set @ValuesInsert=@ValuesInsert+','+@ValueConvert
				--exec ('update #tabSalaryComponent set '+@SalaryComponent+'='+@ValueConvert+' where Employee_ID=N'''+@Emp_ID+''' and Fromdate='''+@DateTimeConvert+'''')
			FETCH NEXT FROM cur_sc INTO @SalaryComponent,@FromdateDetail
			END
			CLOSE cur_sc
			DEALLOCATE cur_sc
			exec (@InsertQuery+') values('+@ValuesInsert+')')
		FETCH NEXT FROM cur_Fromdate INTO @Fromdate
		END
		CLOSE cur_Fromdate
		DEALLOCATE cur_Fromdate
	FETCH NEXT FROM cur_Employee INTO @Emp_ID
	END
	CLOSE cur_Employee
	DEALLOCATE cur_Employee
	--show
	if @ViewEmployeeInfor=0 begin
		select * from #tabSalaryComponent
	end else begin
		select [dbo].[udf_FullName]([Employee_Firstname],[Employee_LastName]) as FullName,[StartedDate],[DepartmentCode],[SectionCode],[TeamCode],[Position_ID],[PositionCategory_ID]
		,sc.*
		from 
		#tabSalaryComponent sc
		left join
		[dbo].[SmartBooks_Employee] empl
		on sc.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
	end
END




GO
