
CREATE FUNCTION [dbo].[udf_DanhSachConNho]     
(
@Month int,        
@Year int,
@fromdate as datetime
)      
RETURNS table      
AS                
RETURN (
	select count(bl1.Employee_ID) as soconnho,bl1.Employee_ID from SmartBooks_Employee_Family bl1
	where dateadd(year,6,BirthDate) >@fromdate
	group by bl1.Employee_ID
)

-- select * from udf_DanhSachConNho(5,2019,'2019/05/01') where employee_id='19001047'
-- select * from SmartBooks_Employee_Family where Employee_ID='19001047'






GO
