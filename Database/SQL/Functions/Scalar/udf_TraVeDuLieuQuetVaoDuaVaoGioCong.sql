
--SELECT [dbo].[udf_TraVeDuLieuQuetVaoDuaVaoGioCong] ('2020-2-17','2020-2-17 7:30:0','2020-2-17 16:30:0','2020-2-17 12:0:0','2020-2-17 13:0:0',4)
CREATE FUNCTION [dbo].[udf_TraVeDuLieuQuetVaoDuaVaoGioCong] 
(
	-- Add the parameters for the function here
	@Ngay datetime,
	@fromtime datetime,
	@totime datetime,
	@resttimefrom datetime,
	@resttimeto datetime,
	@GioCong float
)
RETURNS datetime
AS
BEGIN
	-- Declare the return variable here
	DECLARE @rtn datetime
	set @fromtime = DATETIMEFROMPARTS(datepart(year,@Ngay),datepart(month,@Ngay),datepart(day,@Ngay),datepart(hour,@fromtime),datepart(minute,@fromtime),datepart(second,@fromtime),0)
	if datepart(hour,@fromtime)<datepart(hour,@totime) begin
		set @totime = DATETIMEFROMPARTS(datepart(year,@Ngay),datepart(month,@Ngay),datepart(day,@Ngay),datepart(hour,@totime),datepart(minute,@totime),datepart(second,@totime),0)
	end else begin
		set @totime = DATETIMEFROMPARTS(datepart(year,@Ngay+1),datepart(month,@Ngay+1),datepart(day,@Ngay+1),datepart(hour,@totime),datepart(minute,@totime),datepart(second,@totime),0)
	end

	if @resttimefrom is not null begin
		if datepart(hour,@resttimefrom)>datepart(hour,@fromtime) begin
			set @resttimefrom = DATETIMEFROMPARTS(datepart(year,@Ngay),datepart(month,@Ngay),datepart(day,@Ngay),datepart(hour,@resttimefrom),datepart(minute,@resttimefrom),datepart(second,@resttimefrom),0)
		end else begin
			set @resttimefrom = DATETIMEFROMPARTS(datepart(year,@Ngay+1),datepart(month,@Ngay+1),datepart(day,@Ngay+1),datepart(hour,@resttimefrom),datepart(minute,@resttimefrom),datepart(second,@resttimefrom),0)
		end

		if datepart(hour,@resttimeto)>datepart(hour,@fromtime) begin
			set @resttimeto = DATETIMEFROMPARTS(datepart(year,@Ngay),datepart(month,@Ngay),datepart(day,@Ngay),datepart(hour,@resttimeto),datepart(minute,@resttimeto),datepart(second,@resttimeto),0)
		end else begin
			set @resttimeto = DATETIMEFROMPARTS(datepart(year,@Ngay+1),datepart(month,@Ngay+1),datepart(day,@Ngay+1),datepart(hour,@resttimeto),datepart(minute,@resttimeto),datepart(second,@resttimeto),0)
		end
	end
	if @resttimefrom is not null begin
		if @resttimefrom>=@totime or @resttimeto<=@fromtime begin
			set @resttimefrom=null
			set @resttimeto=null
		end else begin
			if @resttimeto>@totime begin
				set @resttimeto=@totime
			end
		end
	end
	
	if @resttimefrom is null begin
		set @rtn=dateadd(minute,-@GioCong*60,@totime)
	end else begin
		if dateadd(minute,-@GioCong*60,@totime)>=@resttimeto begin
			set @rtn=dateadd(minute,-@GioCong*60,@totime)
		end else if dateadd(minute,-@GioCong*60,@totime)<=@resttimefrom begin
			set @rtn=dateadd(minute,-@GioCong*60-DATEDIFF(minute,@resttimefrom,@resttimeto),@totime)
		end else begin
			set @rtn=dateadd(minute,
									-datediff(minute
													,dateadd(minute,-@GioCong*60,@totime)
													,@resttimeto)
									,@resttimefrom)
		end
	end

	-- Return the result of the function
	RETURN @rtn

END



GO
