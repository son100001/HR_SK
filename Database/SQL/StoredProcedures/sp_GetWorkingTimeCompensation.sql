
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetWorkingTimeCompensation]
	-- Add the parameters for the stored procedure here
	@Month int,
	@Year int,
	@dep nvarchar(50)=null,
	@sec nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select wtc.Employee_ID,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName)as FullName,empl.StartedDate,empl.Employee_Status,empl.TernimationDate,empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID,wtc.[Month_],wtc.[Year_],wtc.MaCong,wtc.WorkingTime,wtc.Remark,wtc.InsertDate,wtc.UserName,wtc.ID from
	HR_WorkingTimeCompensation wtc
	left join
	SmartBooks_Employee empl
	on wtc.Employee_ID=empl.Employee_ID
	where [Month_]=@Month and [Year_]=@Year
	and (case when @dep is null or @dep='' then '' else empl.DepartmentCode end)=(case when @dep is null or @dep='' then '' else @dep end)
																			and (case when @sec is null or @sec='' then '' else empl.SectionCode end)=(case when @sec is null or @sec='' then '' else @sec end)
																			and (case when @team is null or @team='' then '' else empl.TeamCode end)=(case when @team is null or @team='' then '' else @team end)
																			and (case when @pos is null or @pos='' then '' else empl.Position_ID end)=(case when @pos is null or @pos='' then '' else @pos end)
																			and (case when @posc is null or @posc='' then '' else empl.PositionCategory_ID end)=(case when @posc is null or @posc='' then '' else @posc end)
END





GO
