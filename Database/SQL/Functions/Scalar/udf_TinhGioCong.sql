
CREATE FUNCTION [dbo].[udf_TinhGioCong](@TimeIn datetime, @TimeOut datetime,@ShiftFrom datetime,@ShiftTo datetime,@RestTimeFrom datetime, @RestTimeTo datetime
				,@isPushWorkingTime bit,@MinMinute int,@BlockMinute int,@BlockDownMinute int,@Round int,@MaCong nvarchar(50)
				)
RETURNS float
            AS
    BEGIN
		declare @GioCong float
		set @ShiftTo=(case when @ShiftTo is null then @TimeOut else @ShiftTo end)
		set @TimeIn=(case when @TimeIn<@ShiftFrom then @ShiftFrom else @TimeIn end)
		set @TimeOut=(case when @TimeOut>@ShiftTo then @ShiftTo else @TimeOut end)
		set @GioCong= 
				(case when @TimeIn>=@ShiftTo or @TimeOut<=@ShiftFrom then 0 else
					DATEDIFF(minute,@TimeIn,@TimeOut)
					-- TRỪ NGHỈ GIỮA TRƯA
					-
					(case when @RestTimeFrom is null or @RestTimeTo is null or @TimeOut <= @RestTimeFrom or @TimeIn >= @RestTimeTo then 0 else
						(case when @TimeIn between @RestTimeFrom and @RestTimeTo and @TimeOut between @RestTimeFrom and @RestTimeTo then datediff(minute,@TimeIn,@TimeOut) else
						(case when @TimeIn between @RestTimeFrom and @RestTimeTo then datediff(minute,@TimeIn, @RestTimeTo) else
						(case when @TimeOut between @RestTimeFrom and @RestTimeTo then datediff(minute, @RestTimeFrom, @TimeOut) else
						datediff(MINUTE, @RestTimeFrom, @RestTimeTo)
				end)end)end)end)end)
		if @isPushWorkingTime is null or @isPushWorkingTime=0 begin
			set @GioCong=[dbo].[udf_XuLyGioCong](@GioCong,@BlockMinute,@BlockDownMinute,@MinMinute)
			set @GioCong=round(@GioCong/60.0,@Round)
		end
		return @GioCong
	END

 --select [dbo].[udf_TinhGioCong]('2017-11-01 08:00:00','2017-11-01 16:05:30','2017-11-01 08:00:00','2017-11-01 17:00:00','2017-11-01 12:00:00','2017-11-01 13:00:00',0,0,0,0,2)
 

 --select round(cast([dbo].[udf_XuLyGioCong](465,15,7,30) as float)/60,2)
 --select round(7.75,2)
 --select round(cast(425 as float)/60,2)*60




GO
