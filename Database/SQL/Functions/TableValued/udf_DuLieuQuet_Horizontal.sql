
create FUNCTION [dbo].[udf_DuLieuQuet_Horizontal]
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime,
	@Empl nvarchar(50)=null
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),AccessDate datetime,[Q01] datetime,[Q02] datetime,[Q03] datetime,[Q04] datetime,[Q05] datetime,[Q06] datetime,[Q07] datetime,[Q08] datetime,[Q09] datetime,[Q10] datetime, primary key ([Employee_ID],AccessDate)
)
AS
BEGIN
	insert into @rtnTable
	select Employee_ID,AccessDate,[01],[02],[03],[04],[05],[06],[07],[08],[09],[10] from
	(
		SELECT
			Employee_ID,AccessDate,AccessTime,
			s_index = ROW_NUMBER() OVER(PARTITION BY Employee_ID,accessdate ORDER BY accesstime)
		FROM
		HR_TimeKeeping_Data
		where AccessDate BETWEEN @fromdate AND @todate and (case when ISNULL(@Empl,'')='' then '' else Employee_ID end)=ISNULL(@Empl,'')
	)as st
	PIVOT  
	(  
	  max([accesstime])
	  FOR s_index IN ([01],[02],[03],[04],[05],[06],[07],[08],[09],[10])
	) AS PivotTable;

	-- Return the result of the function
	RETURN 

END




GO
