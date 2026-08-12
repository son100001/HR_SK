
CREATE FUNCTION [dbo].[udf_CountSaturDayWorking](@Fromdate datetime, @ToDate datetime)
-- returns only the time portion of a DateTime, at the "base" date (1/1/1900)
returns float 
--select [dbo].[udf_CountSaturDayWorking] ('2023-01-01','2023-01-31')
as
	 begin  
		DECLARE @Date  datetime
		DECLARE @Count  smallint
		Declare @Thu7DuocNghi datetime
		select @Thu7DuocNghi = [Value] from Setup where FunctionID = 'Thu7DuocNghi' and ID = 'T7DN'
		select @Thu7DuocNghi = dateadd(day,7,@Thu7DuocNghi)
		--set @D1 = '2008-08-01'
		--set @D2 = '2008-08-15'
		set @Date = @Fromdate
		set @Count = 0
		
		while @Date <= @ToDate
		begin
			if datediff(day,@Thu7DuocNghi,@Date) % 14 = 0 and DATENAME(DW, GETDATE()) = 'Saturday' and not exists (select H_date from SmartBooks_HolidaysPlan where H_date = @Date)
			begin
			set @Count = @Count + 1
			end
			set @Date = @Date + 1
		end
		
		Return @Count
   	 end









GO
