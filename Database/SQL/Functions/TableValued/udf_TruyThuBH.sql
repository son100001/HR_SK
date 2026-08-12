CREATE FUNCTION [dbo].[udf_TruyThuBH] 
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_TroCapConNho] (11,2019)
	@fromdate datetime,
	@todate datetime
)
RETURNS  @rtnTruyThuBH TABLE 
(
    -- columns returned by the function
     [Employee_ID] nvarchar(50),TienTruyThuBH float
	 ,primary key ([Employee_ID])
)
AS
BEGIN
 insert into @rtnTruyThuBH
 select empl.Employee_ID--,luong.s1 as luongcoban,luong.s2 as pctheoluong,luong.s3 as pctrachnhiem,luong.s4 as pcdochai
	,(LBH+[dbo].[udf_PCThamNien](empl.startedDate,isnull(empl.TernimationDate,@todate)))/26.0*4.5/100 as TienTruyThuBH
 from
	SmartBooks_Employee empl
	left join
	(
		select scmax.Employee_ID,sum(isnull(Amount,0)) as LBH from
		(
			select Employee_ID,max([Fromdate]) as Fromdate,SalaryComponent from [dbo].[HR_SalaryComponent]
			where [Fromdate]<=@todate and salarycomponent in (select salarycomponent from HR_SalaryComponentCategory where insurance=1)
			group by Employee_ID,SalaryComponent
		)scmax
		left join
		[dbo].[HR_SalaryComponent] sc
		on sc.Employee_ID=scmax.Employee_ID and scmax.Fromdate=sc.Fromdate and scmax.SalaryComponent=sc.SalaryComponent
		group by scmax.Employee_ID
		--select s.Employee_ID,s1,s2,s3,s4,s5,s7,s6
		--from
		--(select Employee_ID,max(DATEFROMPARTS(Salary_Year,Salary_Month,1)) as NgayDauThang from SmartBooks_Salary where s6>0 and DATEFROMPARTS(Salary_Year,Salary_Month,1)<DATEFROMPARTS(@Year,@Month,1) group by Employee_ID)as sMax
		--left join
		--SmartBooks_Salary s
		--on smax.Employee_ID=s.Employee_ID and smax.NgayDauThang=DATEFROMPARTS(s.Salary_Year,s.Salary_Month,1)
	)Luong
	on empl.Employee_ID=luong.Employee_ID
	where empl.ternimationdate between @fromdate and @todate
	
	-- Return the result of the function
	RETURN

END

--SELECT * FROM [dbo].[HR_SalaryComponentCategory]



GO
