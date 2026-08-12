-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BangKhoa]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT k.TableName,c.NameVN,k.Block_Date,k.Block_User,k.[Status],k.Remark,k.InsertDate,k.UserName,k.ID from
	HR_Khoa k
	left join
	HR_Category c
	on k.TableName=c.Category
END




GO
