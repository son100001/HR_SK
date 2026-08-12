CREATE FUNCTION [dbo].[udf_Luong6ThangGanNhat] 
(
	-- Add the parameters for the function here
	--select * from udf_Luong6ThangGanNhat('2020-5-01','2020-5-1',null,null,null,null,null,null,null)
	@fromdate datetime,
	@todate datetime,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Empl nvarchar(50)=null
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
     [Employee_ID] nvarchar(50),TienLuong1 float,TienLuong2 float,TienLuong3 float,TienLuong4 float,TienLuong5 float,TienLuong6 float,LuongBQ float,primary key ([Employee_ID])
)
AS
BEGIN
	declare @Employee_ID nvarchar(50),@TienLuong float,@ternimationdate datetime,@starteddate datetime,@F datetime,@T datetime,@iNext int
	insert into @rtnTable (Employee_ID) select Employee_ID from [dbo].[udf_EmployeeFilter]('VN',@fact,@dept,@sect,@team,@pos,@posc,@Empl,@todate) where ternimationdate between @fromdate and @todate
	DECLARE cur CURSOR LOCAL FOR
	select Employee_ID,starteddate,ternimationdate from [dbo].[udf_EmployeeFilter]('VN',@fact,@dept,@sect,@team,@pos,@posc,@Empl,@todate) where ternimationdate between @fromdate and @todate
	OPEN  cur 
	FETCH NEXT FROM cur INTO @Employee_ID,@starteddate,@ternimationdate
	WHILE @@FETCH_STATUS = 0
	BEGIN
		set @iNext=6
		set @T=dateadd(day,-1,DATEFROMPARTS(DATEPART(year,@ternimationdate),DATEPART(MONTH,@ternimationdate),1))
		--set @F=DATEFROMPARTS(DATEPART(year,@T),DATEPART(MONTH,@T),1)
		while @iNext>=1 begin
			SELECT @TienLuong=TienLuong from [dbo].[udf_TienLuong](datepart(MONTH,@T),datepart(YEAR,@T),null,null,null,null,null,null,@Employee_ID)
			--select @TienLuong=sum(isnull(Amount,0)) from
			--(
			--	select max([Fromdate]) as Fromdate,SalaryComponent from [dbo].[HR_SalaryComponent]
			--	where [Fromdate]<=@T and employee_id=@Employee_ID and salarycomponent in (select salarycomponent from HR_SalaryComponentCategory where insurance=1)
			--	group by SalaryComponent
			--)scmax
			--left join
			--[dbo].[HR_SalaryComponent] sc
			--on sc.Employee_ID=@Employee_ID and scmax.Fromdate=sc.Fromdate and scmax.SalaryComponent=sc.SalaryComponent
			--set @TienLuong=@TienLuong+[dbo].[udf_PCThamNien](@starteddate,case when @T<@ternimationdate then @T else @ternimationdate-1 end)
			if @iNext=6 begin
				update @rtnTable set TienLuong6=@TienLuong where Employee_ID=@Employee_ID
			end else if @iNext=5 begin
				update @rtnTable set TienLuong5=@TienLuong where Employee_ID=@Employee_ID
			end else if @iNext=4 begin
				update @rtnTable set TienLuong4=@TienLuong where Employee_ID=@Employee_ID
			end else if @iNext=3 begin
				update @rtnTable set TienLuong3=@TienLuong where Employee_ID=@Employee_ID
			end else if @iNext=2 begin
				update @rtnTable set TienLuong2=@TienLuong where Employee_ID=@Employee_ID
			end else if @iNext=1 begin
				update @rtnTable set TienLuong1=@TienLuong where Employee_ID=@Employee_ID
				update @rtnTable set LuongBQ=(isnull(TienLuong1,0)+isnull(TienLuong2,0)+isnull(TienLuong3,0)+isnull(TienLuong4,0)+isnull(TienLuong5,0)+isnull(TienLuong6,0))
				/case when(
					case when isnull(TienLuong1,0)>0 then 1 else 0 end
					+case when isnull(TienLuong2,0)>0 then 1 else 0 end
					+case when isnull(TienLuong3,0)>0 then 1 else 0 end
					+case when isnull(TienLuong4,0)>0 then 1 else 0 end
					+case when isnull(TienLuong5,0)>0 then 1 else 0 end
					+case when isnull(TienLuong6,0)>0 then 1 else 0 end
				)=0 then 1 else case when isnull(TienLuong1,0)>0 then 1 else 0 end
					+case when isnull(TienLuong2,0)>0 then 1 else 0 end
					+case when isnull(TienLuong3,0)>0 then 1 else 0 end
					+case when isnull(TienLuong4,0)>0 then 1 else 0 end
					+case when isnull(TienLuong5,0)>0 then 1 else 0 end
					+case when isnull(TienLuong6,0)>0 then 1 else 0 end
				end
				where employee_id=@employee_id
			end
			set @iNext=@iNext-1
			set @T=dateadd(month,-1,@T)
		end
	FETCH NEXT FROM cur INTO @Employee_ID,@starteddate,@ternimationdate
	END
	CLOSE cur    
	DEALLOCATE cur
	
	-- Return the result of the function
	RETURN

END





GO
