
CREATE FUNCTION [dbo].[udf_DieuChinhGioXinRaNgoai_ToTime](@FromTime datetime,@ToTime datetime,@QuetVao datetime)
RETURNS datetime
            AS
    BEGIN
		return 
			(case when @fromtime<@QuetVao then
				(case when @ToTime>@QuetVao
						then @QuetVao
						else @ToTime
				end)
			else  @ToTime
			end)
	END

 





GO
