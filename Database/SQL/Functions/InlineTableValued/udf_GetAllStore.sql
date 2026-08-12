
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[udf_GetAllStore]
(	
	-- Add the parameters for the function here
	
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT name
	,SCHEMA_NAME(schema_id) AS schema_name
	,type_desc
	FROM sys.objects
	WHERE type_desc LIKE '%STORED%'
)






GO
