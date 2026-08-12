CREATE FUNCTION [dbo].[udf_DanhSachChuaTinhLuongNghiViec] 
(	
	-- Add the parameters for the function here
	@fromdate as datetime,
	@todate as datetime
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select emp.Employee_ID,Employee_Firstname,Employee_LastName,BirthDate,Sex,StartedDate,TernimationDate,getdate() as todate
	,emp.DepartmentCode,emp.SectionCode,emp.Position_ID, N'Nghỉ việc' as ResonTerminated,1 as ispaid
	from SmartBooks_Employee emp where (Employee_Status='Terminated'  and TernimationDate>=@fromdate and TernimationDate<=@todate)
	and emp.Employee_ID  COLLATE DATABASE_DEFAULT not in (select Employee_ID from SmartBooks_Salary_Off where Salary_Month=datepart(month,@fromdate) and Salary_Year=datepart(YEAR,@fromdate))

)




GO
