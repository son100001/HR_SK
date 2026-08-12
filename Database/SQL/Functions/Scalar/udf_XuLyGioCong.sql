-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[udf_XuLyGioCong]
(
	-- Add the parameters for the function here
	@WorkingTime int,
	@BlockMinute int,
	@BlockMinuteDown int,
	@MinMinute int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	Declare @Result int

	-- Add the T-SQL statements to compute the return value here
	if @WorkingTime<@MinMinute begin
		set @Result=0
	end else begin
		set @Result=[dbo].[udf_LamTronGioCong](@WorkingTime,@BlockMinuteDown,@BlockMinute)
	end
	-- Return the result of the function
	RETURN @Result

END




GO
