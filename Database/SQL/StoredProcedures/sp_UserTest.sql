-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UserTest]
	-- Add the parameters for the stored procedure here
	@TypeOfReport int=2
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @TypeOfReport=1 begin
		SELECT * from [User]
	end else begin
		SELECT * from [User] where UserName=N'Admin'
	end
END




GO
