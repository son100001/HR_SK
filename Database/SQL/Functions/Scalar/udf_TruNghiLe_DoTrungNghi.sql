
create    FUNCTION [dbo].[udf_TruNghiLe_DoTrungNghi](@Fromdate datetime, @ToDate datetime,@empID nvarchar(50))
returns float
as
	 begin  
		DECLARE @Date  datetime
		DECLARE @Count  smallint
		DECLARE @hol  smallint
		
		set @Date = @Fromdate
		set @Count = 0
		set @hol = 0
		
		while @Date <= @ToDate
		BEGIN
			select @hol=1 from HR_EmployeeRegisMaternityLeave  
			where (@Date between Fromdate and ISNULL(ToDate,NgayDuKienQuayLai)) 
			and @Date in (select H_date from SmartBooks_HolidaysPlan)
			and Employee_ID=@empID


			if @hol > 0
			begin
				set @Count = @Count + 1
			end
			set @Date = @Date + 1
		end
		
		Return @Count
   	 end




















GO
