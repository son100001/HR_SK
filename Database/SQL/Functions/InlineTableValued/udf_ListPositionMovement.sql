CREATE FUNCTION [dbo].[udf_ListPositionMovement]     
(
@fromdate datetime,    
@todate datetime
)      
RETURNS table      
AS     
RETURN (
select	* from HR_Transfer smp
where EffectiveDate between @fromdate and @todate
)




GO
