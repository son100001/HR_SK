

CREATE FUNCTION [dbo].[udf_CountHoliday](@Fromdate datetime, @ToDate datetime)
-- returns only the time portion of a DateTime, at the "base" date (1/1/1900)
returns float
as
	 begin  
		DECLARE @Date  datetime
		DECLARE @Count  smallint
		DECLARE @hol  smallint
		--set @D1 = '2008-08-01'
		--set @D2 = '2008-08-15'
		set @Date = @Fromdate
		set @Count = 0
		set @hol = 0
		
		while @Date <= @ToDate
		BEGIN
			
			select @hol = count(sbhp.H_date) from SmartBooks_HolidaysPlan sbhp
			WHERE sbhp.H_date = @Date
			
			if @hol > 0
			begin
			set @Count = @Count + 1
			end
			set @Date = @Date + 1
		end
		
		Return @Count
   	 end

-- select udf_CountHoliday('2019/05/01','2019/05/31')


















GO
