
create PROCEDURE [dbo].[sp_BangEmployeeLeaveRequests]
--exec [dbo].[sp_BangEmployeeLeaveRequests] '2024-03-01','2024-03-31',1,'VN',N'',N'',N'',N'',N'','',N''
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
	@Emp nvarchar(50)=null,
	@ListOfLeaveType varchar(max)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @MaPhep as varchar(10),@SQLMaPhep as varchar(max),@SQL nvarchar(max)
	declare @KiemTraDuLieuNhap nvarchar(max),@NumberOfDate as int,@ID int,@SoNgaySauKhiMangBauDuocHuongThaiSan int
	select @SoNgaySauKhiMangBauDuocHuongThaiSan=Value from SetUp where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
	if @TypeOfReport=1 begin-- danh sách nghỉ theo khoảng thời gian
		select
		
		--,empl.Factory_ID,empl.DepartmentCode, empl.SectionCode, empl.TeamCode, empl.Position_ID
		--,empl.PositionCategory_ID
		empl.Employee_ID
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		,empl.ComStartedDate
		,empl.DepartmentName
		,empl.PositionName
		--,empl.Employee_Status
		--,empl.TernimationDate
		,erml.LeaveType_ID as code
		,erml.LeaveType_ID
		,erml.[Fromdate]
		,erml.ToDate
		, case when LeaveType_ID=49 then 
		[dbo].[udf_CountWorkingDayWithSun](erml.[Fromdate],erml.ToDate)/1 else
		[dbo].[udf_CountWorkingDay](erml.[Fromdate],erml.ToDate)/(case when LeaveType_ID in ('31','32') then 2.0 else 1 end) end as NumberOfDate
		,erml.TrangThai
		--,erml.Reason
		--,erml.PlanStatus
		--,cast(erml.isDaNopGiay as bit) as isDaNopGiay,cast(erml.isBlock as bit) as isBlock
		--,cast(erml.isChoUngPhep as bit) as isChoUngPhep
		--,empl.Position
		,erml.Remark
		,erml.InsertDate
		,erml.UserName
		,erml.ID
		
		from
		(
			select * from udf_EmployeeLeaveRequests('2022-01-01',@todate,@Emp)
			--union
			--select -1,Employee_ID,typeofleave as LeaveType_ID,[H_date] as fromdate,[H_date] as todate,null as Reason,N'Plan-PTCT' as PlanStatus,1 as isDaNopGiay, 1 as isBlock,null Remark,null as TrangThaiNghi,null as InsertDate,null as UserName from [dbo].udf_DanhSachNhanVienDuocHuongNghiLe(@fromdate,@todate)
		)erml
		inner join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		on erml.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
		where empl.ComStartedDate<=@todate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID, StartedDate,erml.Fromdate,erml.LeaveType_ID
	end
END




GO
