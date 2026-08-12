create FUNCTION [dbo].[udf_IsWorkingDay](@Ngay datetime)
--
-- returns only the time portion of a DateTime, at the "base" date (1/1/1900)
returns float
as
	 begin  
		Declare @Thu7DuocNghi datetime
		--set @D1 = '2008-08-01'
		--set @D2 = '2008-08-15'
		select @Thu7DuocNghi = [Value] from Setup where FunctionID = 'Thu7DuocNghi' and ID = 'T7DN'
		If Upper(left(datename(dw,@Ngay),3)) = 'SUN' or datediff(day,@Thu7DuocNghi,@Ngay) % 14 = 0
			return 0
		else if exists (select sbhp.H_date from SmartBooks_HolidaysPlan sbhp
			WHERE sbhp.H_date = @Ngay)
			return 0
		
		Return 1
   	 end
GO
