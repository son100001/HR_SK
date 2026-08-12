
CREATE FUNCTION [dbo].[udf_Position]
(	
	-- Add the parameters for the function here
	@Lan varchar(50),
	@Chart bit
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select Factory_ID as Code,(case when @Lan='VN' then isnull(NameVN,'') when @lan='EN' then isnull(NameEN,'') else isnull(NameKR,'') end) as Name from HR_Factory
	union
	select * from udf_Department(null,@lan,@Chart)
	union
	select * from udf_Section(null,null,@lan,@Chart)
	union
	select * from udf_Team(null,null,null,@lan,@Chart)
)
GO
