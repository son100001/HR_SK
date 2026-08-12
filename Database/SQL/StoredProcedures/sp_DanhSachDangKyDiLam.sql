CREATE PROCEDURE [dbo].[sp_DanhSachDangKyDiLam]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,
	@LAN nvarchar(50)='VN',
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
		SELECT empl.Position,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName, empl.StartedDate,empl.TernimationDate
		,dkdl.*
		from
		HR_DanhSachDangKyDiLam dkdl
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		on dkdl.Employee_ID=empl.Employee_ID
		where ngay between @fromdate and @todate and empl.Employee_ID is not null
	end
END



GO
