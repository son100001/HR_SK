-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_DeleteHR_TerminationAsignment]
	-- Add the parameters for the stored procedure here
	@Employee_ID nvarchar(50),
	@PlanTernimationDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if exists(select * from SmartBooks_Employee where Employee_ID=@Employee_ID and TernimationDate=@PlanTernimationDate)
	begin
		update SmartBooks_Employee set TernimationDate=null,Employee_Status='Incumbent' where Employee_ID=@Employee_ID
	end
	delete HR_TerminationAsignment where Employee_ID=@Employee_ID and PlanTernimationDate=@PlanTernimationDate
END




GO
