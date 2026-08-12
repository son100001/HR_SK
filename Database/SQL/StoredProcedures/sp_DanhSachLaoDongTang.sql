CREATE proc [dbo].[sp_DanhSachLaoDongTang]
@fromdate datetime,
@todate datetime
as
begin

	set @fromdate=DATEFROMPARTS(datepart(year,@fromdate),datepart(MONTH,@fromdate),datepart(day,@fromdate))
	set @todate=DATEFROMPARTS(datepart(year,@todate),datepart(MONTH,@todate),datepart(day,@todate))
	select empl.*, hdtsMax.MaxStartDate
		, (case when hdts.[Type] = 'HDVTH' then 1 when hdts.[Type] like 'HD1NAM%' then 2 when hdts.[Type] like 'HDTV%' then 3 else 4 end) as TypeOfContract, sal.s13 as Salary
	from 
	udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,@todate) empl
	left join
	(
		select Employee_ID, Max(CL_StartDate) as MaxStartDate from udf_HopDongTuSinh ('1900-1-1', @todate, 1, 'VN', null, null, null, null, null, null, null) hdts group by Employee_ID
	) hdtsMax
	on empl.Employee_ID = hdtsMax.Employee_ID
	left join
	udf_HopDongTuSinh ('1900-1-1', @todate, 1, 'VN', null, null, null, null, null, null, null) hdts
	on hdts.Employee_ID = empl.Employee_ID and hdts.CL_StartDate = hdtsMax.MaxStartDate
	left join
	SmartBooks_Salary sal
	on empl.Employee_ID = sal.Employee_ID and sal.Salary_Month = MONTH(@fromdate) and sal.Salary_Year = YEAR(@fromdate)
	where ComStartedDate between @fromdate and @todate

end
GO
