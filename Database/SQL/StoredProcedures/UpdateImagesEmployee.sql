CREATE PROCEDURE [dbo].[UpdateImagesEmployee]
	@Picture Image,
	@Employee_ID nvarchar(50)
AS

UPDATE SmartBooks_Employee
SET Picture = @Picture
WHERE Employee_ID = @Employee_ID




GO
