CREATE FUNCTION [dbo].[udf_XuatDanhSachSoBaoHiem]
(	
	-- Add the parameters for the function here
	
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select ins.Employee_ID, ins.BookCode, ins.InsertDate, ins.UserName,
	empl.Employee_Firstname, empl.Employee_LastName, empl.StartedDate, empl.TernimationDate, empl.DepartmentCode, empl.TeamCode, empl.SectionCode, empl.Position_ID, empl.PositionCategory_ID, empl.ChucDanh, empl.Factory_ID
	from
	HR_Insurance ins
	left join
	SmartBooks_Employee empl
	on ins.Employee_ID = empl.Employee_ID
)




GO
