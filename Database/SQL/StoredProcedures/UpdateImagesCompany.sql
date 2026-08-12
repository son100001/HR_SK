CREATE PROCEDURE [dbo].[UpdateImagesCompany]
	@Picture Image,
	@Employee_ID nvarchar(50)
AS

UPDATE SmartBooks_Company
SET Picture = @Picture
WHERE CompanyID = @Employee_ID



GO
