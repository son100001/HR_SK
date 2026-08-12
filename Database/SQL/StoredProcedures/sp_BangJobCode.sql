-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BangJobCode]
	-- Add the parameters for the stored procedure here
	--exec sp_BangTanTat
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select empl.DepartmentName,empl.SectionName,empl.TeamName,empl.PositionName,empl.PositionCategoryName
	,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
	,jc.*
	 from
	HR_EmpRegisJobCode jc
	left join
	udf_Smartbooks_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc) empl
	on jc.Employee_ID=empl.Employee_ID
END




GO
