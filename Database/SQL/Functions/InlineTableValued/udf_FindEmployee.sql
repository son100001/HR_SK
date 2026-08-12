-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION udf_FindEmployee
(	
	-- Add the parameters for the function here
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select Employee_ID, [dbo].[udf_FullName]([Employee_Firstname],Employee_LastName)+' | '+Employee_ID +' | ' + ID_Number as EmployeeInformation,StartedDate from smartbooks_employee
)

GO
