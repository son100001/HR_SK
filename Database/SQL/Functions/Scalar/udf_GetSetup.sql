-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[udf_GetSetup] 
(
	-- Add the parameters for the function here
	@Code nvarchar(50),
	@Fromdate datetime
)
RETURNS nvarchar(50)
AS
BEGIN
	-- Declare the return variable here
	declare @Value nvarchar(50)

	-- Add the T-SQL statements to compute the return value here
	select @Value=Value from [dbo].[HR_SetUpFollowDate] where Code=@Code and Fromdate<=@Fromdate order by Fromdate asc

	-- Return the result of the function
	RETURN @Value

END




GO
