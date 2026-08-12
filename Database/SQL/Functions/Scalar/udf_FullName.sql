-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[udf_FullName]
(
	-- Add the parameters for the function here
	@FirsName as nvarchar(50),
	@LastName as nvarchar(50)
)
RETURNS nvarchar(50)
AS
BEGIN
	return @FirsName+(case when @LastName is null or @LastName='' then '' else ' '+@LastName end)

END




GO
