
CREATE FUNCTION [dbo].[udf_TinhCongCoGioNghiGiuaGio](@TimeIn datetime, @TimeOut datetime, @RestTimeFrom datetime, @RestTimeTo datetime)
RETURNS float
            AS
    BEGIN
		return DATEDIFF(minute, @TimeIn, @TimeOut)
				-- TRỪ NGHỈ GIỮA TRƯA
				-
				(case when @RestTimeFrom is null or @TimeOut <= @RestTimeFrom or @TimeIn >= @RestTimeTo then 0 else
					(case when @TimeIn between @RestTimeFrom and @RestTimeTo and @TimeOut between @RestTimeFrom and @RestTimeTo then datediff(minute,@TimeIn,@TimeOut) else
					(case when @TimeIn between @RestTimeFrom and @RestTimeTo then datediff(minute,@TimeIn, @RestTimeTo) else
					(case when @TimeOut between @RestTimeFrom and @RestTimeTo then datediff(minute, @RestTimeFrom, @TimeOut) else
					datediff(MINUTE, @RestTimeFrom, @RestTimeTo)
				end)end)end)end)
	END

 





GO
