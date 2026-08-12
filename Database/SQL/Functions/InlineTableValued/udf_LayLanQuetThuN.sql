CREATE FUNCTION [dbo].[udf_LayLanQuetThuN]
(
@fromdate datetime,
@todate datetime,
@n int
)
RETURNS table      
AS                
RETURN (
	WITH tabAccessTime
	AS
	(
	SELECT HR_TimeKeeping_Data.* 
	,ROW_NUMBER() OVER (PARTITION BY Employee_ID, AccessDate ORDER BY Employee_ID, AccessTime asc) AS RowNum
	from HR_TimeKeeping_Data where AccessDate between @fromdate and @todate 
	)
	SELECT * FROM tabAccessTime WHERE RowNum = @n
)




GO
