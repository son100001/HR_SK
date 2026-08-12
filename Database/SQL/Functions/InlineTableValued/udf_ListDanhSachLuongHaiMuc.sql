CREATE FUNCTION [dbo].[udf_ListDanhSachLuongHaiMuc]     
(
@fromdate datetime,    
@todate datetime
)      
RETURNS table      
AS     
RETURN (
	SELECT distinct
	empl.Employee_ID,
	empl.Employee_Firstname,
	empl.Employee_LastName,
	Empl.OfficialDate,
	empl.PositionCategory_ID,
	empl.DepartmentCode,
	empl.SectionCode,
	empl.TeamCode,
	empl.Position_ID,
	empl.Chucdanh
from
-- Load thông tin nhân viên
SmartBooks_Employee empl
where isnull(empl.OfficialDate,@fromdate)>@fromdate 
and isnull(empl.OfficialDate,DATEADD(day,1,@fromdate))<@todate

)

-- select * from udf_ListDanhSachLuongHaiMuc('2019/05/01','2019/05/31')




GO
