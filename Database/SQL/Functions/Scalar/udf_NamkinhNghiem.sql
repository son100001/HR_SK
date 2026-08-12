CREATE FUNCTION [dbo].[udf_NamkinhNghiem](@Startedate datetime, @ToDate datetime)
-- returns only the time portion of a DateTime, at the "base" date (1/1/1900)
returns float
as
	 begin  
		DECLARE @Count  smallint
		
		set @Count=(case when DATEADD(year,1,@Startedate)>=@ToDate then 0
			else datediff(year,@Startedate,@todate)+ (case when MONTH(@Startedate)>MONTH(@ToDate) then -1 else 0 end ) end)
		
		Return @Count
   	 end




GO
