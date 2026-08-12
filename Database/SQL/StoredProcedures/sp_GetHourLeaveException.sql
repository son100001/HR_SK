
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec sp_GetHourLeaveException 2018
CREATE PROCEDURE [dbo].[sp_GetHourLeaveException]
	-- Add the parameters for the stored procedure here
	@Year int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select [dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName)as FullName,empl.StartedDate,empl.Employee_Status,empl.TernimationDate,empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID,hle.*
	from
	HR_HourLeaveException hle
	left join
	SmartBooks_Employee empl
	on hle.Employee_ID=empl.Employee_ID
	where [Year_]=@Year
END




GO
