CREATE PROCEDURE [dbo].[sp_BangNguoiPhuThuocChiTiet]
	-- Add the parameters for the stored procedure here
	@month int,
	@year int,
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
	declare @NgayDauThang datetime,@NgayCuoiThang datetime
	set @NgayDauThang=datefromparts(@year,@month,1)
	set @NgayCuoiThang=dateadd(month,1,@NgayDauThang)-1
	if @TypeOfReport=1 begin
		select [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		, empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
		,empl.StartedDate,empl.TernimationDate,npt.*
		from
		[dbo].[HR_DanhSachNguoiPhuThuoc] npt
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,@NgayCuoiThang) empl
		on npt.Employee_ID=empl.Employee_ID
		where datefromparts(@year,@month,1)>=datefromparts(datepart(year,npt.DependFromMonth),datepart(month,npt.DependFromMonth),1) and (datefromparts(@year,@month,1)<=datefromparts(datepart(year,npt.DependToMonth),datepart(month,npt.DependToMonth),1) or npt.DependToMonth is null)
		and empl.starteddate<=@NgayCuoiThang and (empl.TernimationDate is null or empl.TernimationDate>@NgayDauThang)
		and empl.Employee_ID is not null
	end else if @TypeOfReport=2 begin
		select [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		, empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
		,empl.StartedDate,empl.TernimationDate,npt.*
		from
		[dbo].[HR_DanhSachNguoiPhuThuoc] npt
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@NgayCuoiThang,getdate())) empl
		on npt.Employee_ID=empl.Employee_ID
		where empl.Employee_ID is not null
	end
END




GO
