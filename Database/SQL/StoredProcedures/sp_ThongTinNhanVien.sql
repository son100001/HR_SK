-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ThongTinNhanVien]
	-- Add the parameters for the stored procedure here
	@DanhSachNV as nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from [dbo].[SmartBooks_Employee] where Employee_ID COLLATE DATABASE_DEFAULT in (select * from [dbo].[Split](@DanhSachNV,',')) order by departmentcode, sectioncode, teamcode, StartedDate
END




GO
