CREATE FUNCTION [dbo].[udf_TinhGioXinRaNgoai]
(
	-- Add the parameters for the function here
	@ShiftName nvarchar(50),
	@TimeDate datetime,
	@TimeOut datetime,
	@TimeIn datetime,
	@isRealTime bit
)
RETURNS float 
AS
BEGIN
	-- Declare the return variable here
	declare @fromtime datetime,@totime datetime,@Restfromtime datetime,@Resttotime datetime
	select @fromtime= [dbo].[GhepGioVaoNgay](@TimeDate,FromTime)
	,@totime=[dbo].[GhepGioVaoNgay]((case when DATEPART(hour,ToTime)>DATEPART(hour,FromTime) then @TimeDate else @TimeDate+1 end),ToTime)
	,@Restfromtime=[dbo].[GhepGioVaoNgay]((case when DATEPART(hour,RestTimeFrom)>DATEPART(hour,FromTime) then @TimeDate else @TimeDate+1 end),RestTimeFrom)
	,@Resttotime=[dbo].[GhepGioVaoNgay]((case when DATEPART(hour,RestTimeTo)>DATEPART(hour,FromTime) then @TimeDate else @TimeDate+1 end),RestTimeTo)
	from HR_Shifts where ShiftName=@ShiftName
	if DATEPART(HOUR,@TimeOut)>=DATEPART(HOUR,@fromtime) begin
		set @TimeOut=[dbo].[GhepGioVaoNgay](@TimeDate,@TimeOut)
	end else begin
		set @TimeOut=[dbo].[GhepGioVaoNgay](@TimeDate+1,@TimeOut)
	end
	if DATEPART(HOUR,@TimeIn)>=DATEPART(HOUR,@fromtime) begin
		set @TimeIn=[dbo].[GhepGioVaoNgay](@TimeDate,@TimeIn)
	end else begin
		set @TimeIn=[dbo].[GhepGioVaoNgay](@TimeDate+1,@TimeIn)
	end
	--insert into @rtnTable (RealMinute,TotalMinute) values(ROUND([dbo].[udf_TinhGioCong](@TimeOut,@TimeIn,@fromtime,@totime,@restfromtime,@resttotime,null,null,null,null,2)/60,2),ROUND([dbo].[udf_TinhGioCong](@TimeOut,@TimeIn,@fromtime,@totime,null,null,null,null,null,null,2)/60,2))
	-- Add the T-SQL statements to compute the return value here

	-- Return the result of the function
	RETURN [dbo].[udf_TinhGioCong](@TimeOut,@TimeIn,@fromtime,@totime,(case when @isRealTime = 1 then @restfromtime else null end),(case when @isRealTime = 1 then @resttotime else null end),null,null,null,null,2)
END

--select * from HR_Shifts




GO
