CREATE FUNCTION [dbo].[udf_TroCapConNho] 
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_TroCapConNho] (10,2024) where Employee_ID = 'SS200406'
	@Month int,
	@Year int
)
RETURNS  @rtnTroCapConNho TABLE 
(
    -- columns returned by the function
     [Employee_ID] nvarchar(50)
	 ,SoCon INT
	 ,TienTroCap FLOAT
	 , primary key (Employee_ID)
)
AS
BEGIN
	 DECLARE
		@fromdate DATETIME,@todate DATETIME
		,@NgayDauNam datetime,@NgayCuoiNam DATETIME
		,@NgayKhaiGiang datetime, @TienTroCapConNho float

	 set @fromdate=datefromparts(@year,@month,1)
	 set @todate=EOMONTH(@fromdate)
	 set @NgayDauNam=datefromparts(@year,1,1)
	 set @NgayCuoiNam=dateadd(year,1,@NgayDauNam)-1
	 set @NgayKhaiGiang = DATEFROMPARTS(@Year,9,1)
	 
	 SELECT @TienTroCapConNho=[Value]
	 FROM HR_SetUpFollowDate
	 WHERE Group_='Salary' and Code = 'TroCapConNho' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate)
	 ORDER by Fromdate ASC
     
	 insert into @rtnTroCapConNho (Employee_ID, SoCon)
	 SELECT
		empl.Employee_ID, ef.SoCon
	 from
	 udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,GETDATE()) empl
	 left join
	 (
		SELECT
			ef.Employee_ID
			,sum(CASE
					WHEN isnull(ef.DependFromMonth,ef.BirthDate) > @fromdate then 0
					WHEN dateadd(Year,6,ef.BirthDate) >= @fromdate then 1					
					ELSE 0 
				END) as SoCon			
		from
		SmartBooks_Employee_Family  ef
		group by ef.Employee_ID
	 ) ef
	 on empl.Employee_ID = ef.Employee_ID
	 where ef.Employee_ID is not NULL
     
	 UPDATE @rtnTroCapConNho
	 SET TienTroCap=ISNULL(SoCon,0)*@TienTroCapConNho

RETURN

END



GO
