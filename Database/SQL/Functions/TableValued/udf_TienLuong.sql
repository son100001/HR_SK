CREATE FUNCTION [dbo].[udf_TienLuong] 
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_TienLuong] (3,2020,null,null,null,null,null,null,'2363')
	@Month int,
	@Year int,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Empl nvarchar(50)=null
)
RETURNS  @rtnTienLuong TABLE 
(
    -- columns returned by the function
     [Employee_ID] nvarchar(50),TienLuong float,primary key ([Employee_ID])
)
AS
BEGIN

	declare @Employee_ID nvarchar(50),@TienLuong float,@ThangThamNien int
	,@DT datetime,@CT datetime
	set @DT=DATEFROMPARTS(@Year,@Month,1)
	set @CT=DATEADD(MONTH,1,@DT)-1
	--insert into @rtnTable (Employee_ID) select Employee_ID from [dbo].[udf_EmployeeFilter]('VN',@fact,@dept,@sect,@team,@pos,@posc,@Empl,@CT) where ComStartedDate<=@CT and (ternimationdate is null or TernimationDate>@DT)
	insert into @rtnTienLuong
	select tl.Employee_ID,tl.TienLuong
							+isnull(lcb.Amount,isnull(ml.MucLuong,0))
							+ISNULL(btn.Amount,0)
							+[dbo].[udf_PCThamNien](empl.StartedDate,(case when empl.ternimationdate is null or empl.ternimationdate>@CT then @CT else empl.TernimationDate-1 end),empl.PositionCategory_ID)
	from
	(
		select sc.Employee_ID, sum(isnull(sc.Amount,0)) as TienLuong
		from
		(
			select Employee_ID,max([Fromdate]) as Fromdate,SalaryComponent from [dbo].[HR_SalaryComponent]
			where [Fromdate]<=@CT and salarycomponent in (select salarycomponent from HR_SalaryComponentCategory where insurance=1) and SalaryComponent<>'luongcoban'
			group by Employee_ID,SalaryComponent
		)scmax
		left join
		[dbo].[HR_SalaryComponent] sc
		on sc.Employee_ID=scmax.Employee_ID and scmax.Fromdate=sc.Fromdate and scmax.SalaryComponent=sc.SalaryComponent
		group by sc.Employee_ID
	)tl
	left join
	[dbo].[udf_EmployeeFilter]('VN',@fact,@dept,@sect,@team,@pos,@posc,@Empl,@CT) empl
	on tl.Employee_ID=empl.Employee_ID
	left join
	[dbo].[udf_MucLuongCuaCongNhanVien](@CT,@Empl) ml
	on empl.Employee_ID=ml.Employee_ID
	left join
	[dbo].[HR_SalaryComponent] lcb
	on empl.Employee_ID=lcb.Employee_ID and SalaryComponent='luongcoban'
	left join
	[dbo].[udf_BacTayNgheCuaCongNhanVien](@CT,@Empl) btn
	on empl.Employee_ID=btn.Employee_ID
	where empl.Employee_ID is not null and empl.ComStartedDate<=@CT and (empl.TernimationDate is null or empl.TernimationDate>@DT)
	
	-- Return the result of the function
	RETURN

END


--(DATEDIF(K27,CS27,"Y")+1)*(IF(J27="CN May",30000,20000))+250000


GO
