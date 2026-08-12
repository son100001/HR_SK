
CREATE FUNCTION [dbo].[udf_GetReportByPermission] 
(	
	-- Add the parameters for the function here
	@User nvarchar(50)
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select r.*,rp.[User_] from
	[dbo].[HR_Report] r
	left join
	(select * from [dbo].[HR_ReportPermission] where [User_]=@User) rp
	on rp.[ReportCode]=r.[ReportCode]
)




GO
