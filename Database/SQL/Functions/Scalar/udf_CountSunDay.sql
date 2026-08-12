
CREATE FUNCTION [dbo].[udf_CountSunDay](@Fromdate datetime, @ToDate datetime)
-- returns only the time portion of a DateTime, at the "base" date (1/1/1900)
returns float
as
	 begin  
		DECLARE @Date  datetime
		DECLARE @Count  smallint
		Declare @Thu7DuocNghi datetime
		select @Thu7DuocNghi = [Value] from Setup where FunctionID = 'Thu7DuocNghi' and ID = 'T7DN'
		--set @D1 = '2008-08-01'
		--set @D2 = '2008-08-15'
		set @Date = @Fromdate
		set @Count = 0
		
		while @Date <= @ToDate
		begin
			if Upper(left(datename(dw,@Date),3)) = 'SUN' or datediff(day,@Thu7DuocNghi,@Date) % 14 = 0
			begin
			set @Count = @Count + 1
			end
			set @Date = @Date + 1
		end
		
		Return @Count
   	 end









GO
