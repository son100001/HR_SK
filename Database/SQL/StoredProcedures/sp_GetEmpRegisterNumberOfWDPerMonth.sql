-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetEmpRegisterNumberOfWDPerMonth]
	-- Add the parameters for the stored procedure here
	@Month int,
	@Year int,
	@Lan nvarchar(50)=N'VN'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select
	er.*
	,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName) as FullName
	,empl.StartedDate,empl.TernimationDate,empl.DepartmentName,empl.SectionName,empl.TeamName,empl.PositionName,empl.PositionCategoryName
	from
	[dbo].[HR_EmpRegisterNumberOfWDPerMonth] er
	left join
	udf_Smartbooks_Employee(@Lan) empl
	on er.Employee_ID=empl.Employee_ID
END




GO
