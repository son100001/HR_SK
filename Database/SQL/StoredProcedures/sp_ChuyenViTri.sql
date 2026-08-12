--select * from smartbooks_contractlist
create PROCEDURE [dbo].[sp_ChuyenViTri]
	--exec sp_ChuyenViTri '1','VN',null,null,null,null,null,null,'HT000972, HT000970'
	--select * from udf_EmployeeFilter('VN',null,null,null,null,null,null,null,getdate())
	-- Add the parameters for the stored procedure here
	@TypeOfReport int=1,--1: Don xin chuyen vi tri
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@ListOfID varchar(max)=null
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @TypeOfReport=1 begin
		--TẠO BẢNG THÔNG TIN
		select empl.Position
		,empl.Employee_ID, [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
		,empl.DepartmentCode, empl.DepartmentName, empl.ChucDanh, empl.ChucDanhName, empl.Factory_ID
		,empl.PositionName, empl.Position, empl.PositionCategoryName, empl.CongViecPhaiLam
		from
		udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,getdate()) empl
		where empl.Employee_ID in (select * from [dbo].[Split](@ListOfID, ','))
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID
	end
END




GO
