CREATE PROCEDURE [dbo].[sp_BangCapPhatAo]
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
	if @TypeOfReport=1 begin
		select Empl.PositionFullName,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,CPAo.* from HR_CapPhatAo CPAo
		left join [dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		on Empl.Employee_ID=CPAo.Employee_ID
		where DateIssued between @fromdate and @todate and empl.Employee_ID is not null
	end
END




GO
