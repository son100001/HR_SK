-- =============================================  
-- Author:  Nguyen Tran Hieu 
-- ALTER  date: 6/05/2016  
-- Description: so tieng thai san

CREATE FUNCTION [dbo].[udf_ThaiSan]     
( 
	@fromdate datetime,   
	@todate datetime
) 
RETURNS table      
AS                 
RETURN (
	select Employee_ID,
	(case when dateadd(day,26*7,fromdate)<@fromdate then datediff(d,@fromdate,@todate)+1-dbo.udf_CountSunDay(@fromdate,@todate)
		when  dateadd(day,26*7,fromdate)>=@fromdate and  dateadd(day,26*7,fromdate)<@todate  then datediff(d,dateadd(day,26*7,fromdate),@todate)+1-dbo.udf_CountSunDay(dateadd(day,26*7,fromdate),@todate)		
	else 0 end) as addtime
	from HR_EmployeeRegisPregnant where ToDate> @fromdate
	and Employee_ID COLLATE SQL_Latin1_General_CP437_CI_AS not in (select Employee_ID from dbo.SmartBooks_Employee_Family where BirthDate<= @todate and DATEADD(year,1,BirthDate)>=@fromdate)

	--and Employee_ID in (select Employee_ID from dbo.SmartBooks_Promotion)

	union

	select  Employee_ID COLLATE SQL_Latin1_General_CP437_CI_AS as Employee_ID,
	(case when BirthDate<@fromdate and DATEADD(year,1,BirthDate)>=@todate then datediff(d,@fromdate,@todate)+1-dbo.udf_CountSunDay(@fromdate,@todate)
		when BirthDate<@fromdate and DATEADD(year,1,BirthDate)<=@todate then datediff(d,@fromdate,DATEADD(year,1,BirthDate))+1-dbo.udf_CountSunDay(@fromdate,DATEADD(year,1,BirthDate))
		when BirthDate>=@fromdate then datediff(d,BirthDate,@todate)+1-dbo.udf_CountSunDay(BirthDate,@todate)	
	else 0 end) as addtime
	from SmartBooks_Employee_Family where BirthDate<= @todate and DATEADD(year,1,BirthDate)>=@fromdate 
	
	--and Employee_ID in (select Employee_ID from dbo.SmartBooks_Promotion)

	--union all

	--  select Employee_ID,isnull(addtime,0) as addtime from SmartBooks_Addtime 
	--  where WorkingDate between @fromdate and @todate


)




GO
