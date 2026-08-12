
CREATE FUNCTION [dbo].[udf_ConNhoDuoiSauTuoi]     
(
@Month int,        
@Year int,
@todate as datetime
)      
RETURNS table      
AS                
RETURN (
select bl1.Employee_ID, bl1.BirthDate from SmartBooks_Employee_Family bl1
inner join
(
	select Employee_ID, min(BirthDate) as BabyDate from SmartBooks_Employee_Family
	where (@Year < year(dateadd(year,6,BirthDate)) 
	or (@Year = year(dateadd(year,6,BirthDate)) and @Month <= month(dateadd(year,6,BirthDate))))
	and ISNULL(InsertDate,cast('2010/01/01' as date) )<=DATEADD(day,10, @todate)
	group by Employee_ID
) bl2 on bl1.Employee_ID = bl2.Employee_ID and bl1.BirthDate = bl2.BabyDate

)

-- select * from udf_ConNhoDuoiSauTuoi(11,2017) where employee_id='1210039'

-- select * from SmartBooks_Employee_Family where employee_id='1210039'






GO
