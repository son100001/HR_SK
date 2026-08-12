CREATE PROCEDURE [dbo].[sp_BangMucLuongNhanVien]
	-- Add the parameters for the stored procedure here
	--exec [dbo].[sp_BangCong] '2019-9-1','2019-9-30','115','VN',null,null,null,null,null,null,'S000862',null
	@Month int,
	@Year int,
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
	declare @NgayDauThang datetime
	set @NgayDauThang=cast(@year as varchar)+'-'+cast(@Month as varchar)+'-1'
	if @TypeOfReport=1 begin
		select empl.PositionFullName
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		,empl.starteddate,mlnv.*
		from HR_MucLuongNhanVien mlnv
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(dateadd(month,1,@NgayDauThang)-1,getdate())) empl
		on mlnv.Employee_ID=empl.Employee_ID and empl.Employee_ID is not null
	end
END




GO
