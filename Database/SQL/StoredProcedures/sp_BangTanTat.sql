-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BangTanTat]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@emp nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select empl.FactoryName,empl.DepartmentName,empl.SectionName,empl.ChucDanhName
	,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
	,d.*
	 from
	HR_Disable d
	left join
	[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,getdate()) empl
	on d.Employee_ID=empl.Employee_ID
	where empl.Employee_ID is not null and (d.Fromdate between @fromdate and @todate or d.Todate between @fromdate and @todate or @todate between d.Fromdate and d.Todate)
END




GO
