-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[udf_TinhSoThangSoNgay]
(
	--select [dbo].[udf_TinhSoThangSoNgay]('2011-8-8','2020-5-1')
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime
)
RETURNS varchar(5)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @SoThang int,@SoNgay int,@DNext datetime
	
	-- Add the T-SQL statements to compute the return value here
	set @DNext=@fromdate
	set @todate=@todate+1
	set @SoThang=0
	while DATEADD(month,1,@DNext)<=@todate begin
		set @SoThang=@SoThang+1
		set @DNext=DATEADD(month,1,@DNext)
	end
	set @SoNgay=DATEDIFF(day,@DNext,@todate)
	-- Return the result of the function
	RETURN case when @SoThang between 0 and 9 then '00' when @sothang between 10 and 99 then '0' else '' end+cast(@SoThang as varchar)+case when @SoNgay between 0 and 9 then '0' else '' end+cast(@SoNgay as varchar)

END




GO
