CREATE FUNCTION [dbo].[udf_BangQuetVao](@fromdate datetime, @todate datetime)
	--select * from [dbo].[udf_BangQuetVao]('2019-7-10','2019-7-11')
    RETURNS @BangQuetVao TABLE (
		Employee_ID nvarchar(50),
        AccessDate datetime,
        AccessTime datetime
		PRIMARY KEY CLUSTERED (Employee_ID, AccessDate)
    )
AS
BEGIN
    
    WITH tkdIn AS (
			SELECT tkdIn.Employee_ID, 
				   tkdIn.AccessDate, 
					tkdIn.AccessTime,
				   ROW_NUMBER() OVER(PARTITION BY tkdIn.Employee_ID,tkdIn.AccessDate
										 ORDER BY tkdIn.Employee_ID,tkdIn.AccessTime asc) AS rk
			  FROM
			  (
				select tkd.Employee_ID,btg.Date_ as AccessDate,tkd.AccessTime from
				[dbo].[udf_BangThoiGian](@fromdate,@todate) btg
				left join
				HR_TimeKeeping_Data tkd
				on btg.Date_=tkd.AccessDate and tkd.AccessTime between [dbo].[GhepGioVaoNgay](btg.Date_,'2000 03:00:00') and [dbo].[GhepGioVaoNgay](btg.Date_+1,'2000 02:00:00') and InOutStatus=0
				where tkd.AccessTime is not null
				)tkdIn)

	INSERT INTO @BangQuetVao
	SELECT Employee_ID,AccessDate,AccessTime
		  FROM tkdIn s
		 WHERE s.rk = 1
    RETURN;
END;




GO
