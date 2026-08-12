-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
--select [dbo].[udf_PCThamNien]('2020-12-15','2024-12-30','CNM')
CREATE FUNCTION [dbo].[udf_PCThamNien]
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime,
	@Employee_ID varchar(50)
)
RETURNS float
AS
BEGIN
	-- Declare the return variable here
	
	-- Return the result of the function
	declare @SoThangTN int
	set @SoThangTN=DATEDIFF(MONTH,@fromdate,@todate)
	RETURN  (case when @Employee_ID = 'SS-QLVP' then 1500000 when @SoThangTN/12 < 1 then 0 when @SoThangTN/12 >= 5 then 300000 * 5 when @SoThangTN/12 >= 1 then 300000* Floor(@SoThangTN/12) else 0 end)
			- (case when @SoThangTN/12 < 1 then 0 when Month(@fromdate) = Month(@todate) and day(@todate) < day(@fromdate) then 1 * 300000 else 0 end)
END



GO
