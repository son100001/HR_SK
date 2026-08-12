-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE sp_BangCaiDatCa
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ID],[ShiftName],[ShiftSign],[FromTime],cast([FromTime] as time(0)) as FromTime_Edit,[ToTime],cast([ToTime] as time(0)) as ToTime_Edit,[RestTimeFrom],cast([RestTimeFrom] as time(0)) as RestTimeFrom_Edit,[RestTimeTo],cast([RestTimeTo] as time(0)) as RestTimeTo_Edit,[RestTimeFrom1],[RestTimeTo1],[MinMinute],[AllowLateIn],[AllowEarlyOut],[ChanDau],[ChanCuoi],[ShiftGroup],[Remark],[InsertDate],[UserName]
	from HR_Shifts
END

GO
