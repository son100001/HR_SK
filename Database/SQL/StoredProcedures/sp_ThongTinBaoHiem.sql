-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ThongTinBaoHiem]
	-- Add the parameters for the stored procedure here
	@TypeOfReport int=1,--1 View sổ BH; View thẻ BHYT
	@LAN nvarchar (50)='VN',
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
		select empl.Position,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName) as FullName,ins.* from
		HR_Insurance ins
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,GETDATE()) empl
		on ins.Employee_ID=empl.Employee_ID
		where empl.Employee_ID is not null
	end else if @TypeOfReport=2 begin
		select empl.Position,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName) as FullName,bhyt.* from
		HR_TheBHYT bhyt
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,GETDATE()) empl
		on bhyt.Employee_ID=empl.Employee_ID
		where empl.Employee_ID is not null
	end
	
END




GO
