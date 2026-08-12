-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--select * from udf_Team('','','','VN')
CREATE FUNCTION [dbo].[udf_Factory]
(	
	-- Add the parameters for the function here
	@Lan varchar(50)
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select Factory_ID as Code
	,(case when @Lan='VN' then isnull(NameVN,'') when @lan='EN' then isnull(NameEN,'') else isnull(NameKR,'') end) as Name
	from
	HR_Factory
)





GO
