
CREATE FUNCTION [dbo].[udf_TinhPIT]
(
	-- Add the parameters for the function here
	@ThuNhapChiuThue float
)
RETURNS float
AS
BEGIN
	-- Declare the return variable here
	DECLARE @PIT float

	-- Add the T-SQL statements to compute the return value here
	set @PIT=ROUND(case when @ThuNhapChiuThue>80000000 then @ThuNhapChiuThue*35/100-9850000
				when @ThuNhapChiuThue>52000000 then @ThuNhapChiuThue*30/100-5850000
				when @ThuNhapChiuThue>32000000 then @ThuNhapChiuThue*25/100-3250000
				when @ThuNhapChiuThue>18000000 then @ThuNhapChiuThue*20/100-1650000
				when @ThuNhapChiuThue>10000000 then @ThuNhapChiuThue*15/100-750000
				when @ThuNhapChiuThue>5000000 then @ThuNhapChiuThue*10/100-250000
				when @ThuNhapChiuThue>0 then @ThuNhapChiuThue*5/100
				else 0
			end,0)

	-- Return the result of the function
	RETURN @PIT

END



GO
