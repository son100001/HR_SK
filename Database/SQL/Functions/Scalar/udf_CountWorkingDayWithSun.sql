
create FUNCTION [dbo].[udf_CountWorkingDayWithSun](@Fromdate datetime, @ToDate datetime)
-- returns only the time portion of a DateTime, at the "base" date (1/1/1900)
returns float
as
	 begin  
		DECLARE @Date  datetime
		DECLARE @Count  smallint
		DECLARE @hol_sun  smallint
		--set @D1 = '2008-08-01'
		--set @D2 = '2008-08-15'
		set @Date = @Fromdate
		set @Count = 0
		while @Date <= @ToDate
		BEGIN
			
			--select @hol_sun = count(sbhp.H_date) from SmartBooks_HolidaysPlan sbhp
			--WHERE sbhp.H_date = @Date and sbhp.TypeOfLeave='50'
			
			--if Upper(left(datename(dw,@Date),3)) = 'SUN'
			--begin
			--	set @hol_sun = @hol_sun + 1
			--end

			--if @hol_sun = 0
			--begin
			set @Count = @Count + 1
			--end
			set @Date = @Date + 1
		end
		
		Return @Count
   	 end











GO
