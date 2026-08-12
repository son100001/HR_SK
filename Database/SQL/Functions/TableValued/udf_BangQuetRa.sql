CREATE FUNCTION [dbo].[udf_BangQuetRa](@fromdate datetime, @todate datetime)
	--select Employee_ID,accesstime,dateadd(hour,13,accesstime) from [dbo].[udf_BangQuetVao]('2019-7-11','2019-7-11') where employee_ID='19000365'
	--select * from [dbo].[udf_BangQuetRa]('2019-7-11','2019-7-11') where employee_ID='19000365'
    RETURNS @BangQuetRa TABLE (
		Employee_ID nvarchar(50),
        AccessDate datetime,
        AccessTime datetime
		PRIMARY KEY CLUSTERED (Employee_ID, AccessDate)
    )
AS
BEGIN
    
    WITH tkdOut AS (
			SELECT tkdOut.Employee_ID, 
				   tkdOut.AccessDate, 
					tkdOut.AccessTime,
				   ROW_NUMBER() OVER(PARTITION BY tkdOut.Employee_ID,tkdOut.AccessDate
										 ORDER BY tkdOut.Employee_ID,tkdOut.AccessTime desc) AS rk
			  FROM
			  (
				select tkd.Employee_ID,qv.AccessDate,tkd.AccessTime from
				[dbo].[udf_BangQuetVao](@fromdate,@todate) qv
				left join
				HR_TimeKeeping_Data tkd
				on tkd.InOutStatus=1 and qv.Employee_ID=tkd.Employee_ID and tkd.accesstime between qv.accesstime and dateadd(hour,13,qv.accesstime)
				where tkd.Employee_ID is not null
				)tkdOut)

	INSERT INTO @BangQuetRa
	SELECT Employee_ID,AccessDate,AccessTime
		  FROM tkdOut s
		 WHERE s.rk = 1
    RETURN;
END;




GO
