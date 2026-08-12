-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[udf_TinhNghiTuNgayDenNgayCoBuChuNhat]
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
		if DATENAME(DW,@dtNext)='Sunday' or @dtNext IN (select H_date from SmartBooks_HolidaysPlan) begin
			set @todate=DATEADD(day,1,@todate)
		end
		set @dtNext=DATEADD(day,1,@dtNext)
	end
	return @todate
END




GO
