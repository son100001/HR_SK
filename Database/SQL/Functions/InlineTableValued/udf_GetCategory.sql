-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[udf_GetCategory]
(	
	-- Add the parameters for the function here
	@CategoryFather varchar(50),
	@Lan varchar(50)
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select Category as Code,(case when @Lan='VN' then NameVN when @Lan='EN' then NameEN else NameKR end) as Name from HR_Category where CategoryFather=@CategoryFather
)




GO
