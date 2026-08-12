




CREATE FUNCTION [dbo].[udf_Addtime] 
(
	@fromdate datetime,
	@employee_id nvarchar(50)
)
RETURNS int
AS 

BEGIN
	DECLARE @Status AS int
	SET @Status = 0
	SELECT @Status  = count(sba.Employee_ID)
	FROM   SmartBooks_Addtime sba   
		WHERE  sba.FromDate <= @fromdate  AND  sba.ToDate  >= @fromdate
				AND sba.Employee_ID = @employee_id	
Return @Status				
END

			











GO
