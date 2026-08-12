CREATE PROCEDURE [dbo].[sp_CapNhatHopDongLaoDong]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@InsertDate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert
	insert into [dbo].[SmartBooks_ContractList]([Contract_ID],[Employee_ID],[CL_RegisterDate],[CL_StartDate],[CL_ExpiredDate],[Type],[InsertDate],[UserName])
	select dsdt.Employee_ID+'_'+cast(YEAR(@fromdate)as nvarchar(50))+'_'+dsdt.LoaiHD as Contract_ID, dsdt.Employee_ID, dsdt.NgayKy, dsdt.NgayKy, dsdt.NgayHetHan,dsdt.LoaiHD, @InsertDate, @UserName
	from
	(
		[dbo].[DanhSachDuTinhKyHD](@fromdate, @todate) dsdt
		left join
		[dbo].[SmartBooks_ContractList] ctl
		on dsdt.Employee_ID COLLATE DATABASE_DEFAULT = ctl.Employee_ID and dsdt.NgayKy = ctl.[CL_StartDate]
	) where ctl.Employee_ID is null and dsdt.NgayKy is not null

	--update
	update [SmartBooks_ContractList]
	set [Contract_ID] = [SmartBooks_ContractList].Employee_ID+'_'+cast(YEAR(@fromdate)as nvarchar(50))+'_'+dsdt.LoaiHD
	,[CL_ExpiredDate] = dsdt.NgayHetHan
	,[Type]=dsdt.LoaiHD
	,[InsertDate]=@InsertDate
	,[UserName]=@UserName
	from
	[SmartBooks_ContractList]
	inner join
	[dbo].[DanhSachDuTinhKyHD](@fromdate, @todate) dsdt
	on dsdt.Employee_ID COLLATE DATABASE_DEFAULT = [SmartBooks_ContractList].Employee_ID and dsdt.NgayKy = [SmartBooks_ContractList].[CL_StartDate]
	where [SmartBooks_ContractList].Employee_ID COLLATE DATABASE_DEFAULT = dsdt.Employee_ID and [SmartBooks_ContractList].CL_StartDate = dsdt.NgayKy
END




GO
