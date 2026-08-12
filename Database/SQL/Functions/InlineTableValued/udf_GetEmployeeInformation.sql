-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[udf_GetEmployeeInformation] 
(	
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select *,(case when Sex=N'Male' then N'Nam' else (case when Sex=N'Female' then N'Nữ' else N'Khác' end)end) as SexTranslate
		,@fromdate as fromdate,@todate as todate
	from SmartBooks_Employee
)




GO
