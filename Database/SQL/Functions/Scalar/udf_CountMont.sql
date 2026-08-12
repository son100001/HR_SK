
CREATE FUNCTION [dbo].[udf_CountMont](@fromdate datetime, @todate datetime)
RETURNS float
            AS
    BEGIN
    return
		case when datepart(day,dateadd(month,datediff(month,@fromdate,@todate),@fromdate)) = datepart(day,@todate)
			then datediff(month,@fromdate,@todate)
			else
				(
					case when datepart(day,@fromdate) > datepart(day,@todate)
						then datediff(month,@fromdate,@todate)
							- 1
							+ cast(30-(datepart(day,@fromdate) - datepart(day,@todate)) as float)/30
						else datediff(month,@fromdate,@todate)
							+ cast((datepart(day,@todate) - datepart(day,@fromdate)) as float)/30
					end
				)
		end
	END


	--select [dbo].[udf_CountMont]('2016-7-15','2017-1-17')




GO
