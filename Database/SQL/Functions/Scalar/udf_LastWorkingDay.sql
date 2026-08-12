CREATE FUNCTION [dbo].[udf_LastWorkingDay]
(
	-- Add the parameters for the function here
	--select [dbo].[udf_LastWorkingDay]('2019-7-15')
	@Date datetime
)
RETURNS datetime
AS
BEGIN
	-- Declare the return variable here
		set @Date=@Date-1
		Declare @Thu7DuocNghi datetime
		select @Thu7DuocNghi = [Value] from Setup where FunctionID = 'Thu7DuocNghi' and ID = 'T7DN'
		while @Date in (select H_date from SmartBooks_HolidaysPlan where H_date=@Date) or DATENAME(WEEKDAY,@Date)='Sunday' or datediff(day,@Thu7DuocNghi,@Date) % 14 = 0 begin
			set @Date=@Date-1
		end
		
		RETURN @Date

END




GO
