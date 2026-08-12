-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[udf_NgayCuoiThang]
(
	-- Add the parameters for the function here
	@Date datetime
)
RETURNS datetime
AS
BEGIN
	return dateadd(day,-1,dateadd(month,1,cast(datepart(year,@Date) as nvarchar(4)) + '-' + cast(datepart(Month,@Date) as nvarchar(2)) + '-1'))

END




GO
