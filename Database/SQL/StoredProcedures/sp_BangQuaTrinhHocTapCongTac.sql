-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_BangQuaTrinhHocTapCongTac]
	-- Add the parameters for the stored procedure here
	@TypeOfReport int=1,
	@LAN nvarchar(50)='VN',
	@UserName nvarchar(50)=null,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@emp nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @TypeOfReport=1 begin
		select empl.PositionFullName,qtct.*
		from
		HR_QuaTrinhHocTapCongTac qtct
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,getdate()) empl
		on qtct.Employee_ID=empl.Employee_ID
		where empl.Employee_ID is not null
	end
END

GO
