CREATE FUNCTION [dbo].[udf_TinhNghiTuNgayDenNgayCoBuNgayNghiTheoLuatTruNgayCN]
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime
)
RETURNS datetime
AS
BEGIN
	declare @dtNext datetime
	set @dtNext=@fromdate
	while @dtNext<=@todate
	begin
		if @dtNext IN (select H_date from SmartBooks_HolidaysPlan where H_date between @fromdate and @todate) begin
			set @todate=DATEADD(day,1,@todate)
		end
		set @dtNext=DATEADD(day,1,@dtNext)
	end
	return @todate
END




GO
