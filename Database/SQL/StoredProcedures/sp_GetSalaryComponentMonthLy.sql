-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec [dbo].[sp_TinhLuong] '6','2017','2017-6-1','2017-6-30',null,null,null,null,null,1,1,1,1,1,1,1
CREATE PROCEDURE [dbo].[sp_GetSalaryComponentMonthLy]
	-- Add the parameters for the stored procedure here
	@Month int,
	@Year int,
	@DepartmentCode nvarchar(50)=null,
	@SectionCode nvarchar(50)=null,
	@TeamCode nvarchar(50)=null,
	@Position_ID nvarchar(50)=null,
	@PositionCategory_ID nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @SalaryComponent nvarchar(50),@Employee_ID nvarchar(50),@Value float,@ValueConvert nvarchar(50)
	create table #tabSalaryComponent (Employee_ID nvarchar(50))
	insert into #tabSalaryComponent
	select distinct Employee_ID from HR_SalaryComponentFollowMonth where Month_=@Month and Year_=@Year
	DECLARE cur_SalaryComponentType CURSOR FOR
	select SalaryComponent from HR_SalaryComponentCategory where SalaryComponent in (select SalaryComponent from [dbo].[HR_SalaryComponentCategory] where [MonthlyChanging]=1) order by SalaryComponent
	OPEN  cur_SalaryComponentType 
	FETCH NEXT FROM cur_SalaryComponentType INTO @SalaryComponent
	WHILE @@FETCH_STATUS = 0
	BEGIN
		exec ('alter table #tabSalaryComponent add '+@SalaryComponent+' float')
		DECLARE cur_SalaryComponent CURSOR FOR
		select Employee_ID,isnull(Amount,0) from HR_SalaryComponentFollowMonth where Year_=@Year and Month_=@Month and SalaryComponent=@SalaryComponent
		OPEN  cur_SalaryComponent 
		FETCH NEXT FROM cur_SalaryComponent INTO @Employee_ID,@Value
		WHILE @@FETCH_STATUS = 0
		BEGIN
			set @ValueConvert=convert(VARCHAR(50), @Value,128)
			exec ('update #tabSalaryComponent set '+@SalaryComponent+'='+@ValueConvert+' where Employee_ID='+@Employee_ID)
		FETCH NEXT FROM cur_SalaryComponent INTO @Employee_ID,@Value
		END
		CLOSE cur_SalaryComponent
		DEALLOCATE cur_SalaryComponent
	FETCH NEXT FROM cur_SalaryComponentType INTO @SalaryComponent
	END
	CLOSE cur_SalaryComponentType
	DEALLOCATE cur_SalaryComponentType
	--Show ra
	select sc.*,empl.Employee_ID,empl.Employee_Firstname,empl.Employee_LastName,empl.Employee_Firstname+(case when empl.Employee_LastName is null or empl.Employee_LastName='' then '' else ' '+empl.Employee_LastName end)as FullName,
			empl.StartedDate,empl.Employee_Status,empl.TernimationDate,empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,Empl.PositionCategory_ID,empl.Sex
	from
	#tabSalaryComponent sc
	left join
	SmartBooks_Employee empl
	on sc.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
	where
	(case when @DepartmentCode is null then '' else empl.DepartmentCode end)=(case when @DepartmentCode is null then '' else @DepartmentCode end)
	and (case when @SectionCode is null then '' else empl.Sectioncode end)=(case when @SectionCode is null then '' else @SectionCode end)
	and (case when @TeamCode is null then '' else empl.TeamCode end)=(case when @TeamCode is null then '' else @TeamCode end)
	and (case when @Position_ID is null then '' else empl.Position_ID end)=(case when @Position_ID is null then '' else @Position_ID end)
	and (case when @PositionCategory_ID is null then '' else empl.PositionCategory_ID end)=(case when @PositionCategory_ID is null then '' else @PositionCategory_ID end)
END






GO
