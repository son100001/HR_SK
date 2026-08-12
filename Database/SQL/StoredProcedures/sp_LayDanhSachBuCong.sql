-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec sp_LayDanhSachBuCong '2017-9-15',182
--select * from HR_TimeIn_TimeOut where Employee_ID='1104001' and OT_date='2017-9-15'
CREATE PROCEDURE [dbo].[sp_LayDanhSachBuCong]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select empl.Employee_ID,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName)as FullName
	,empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID,empl.StartedDate,empl.TernimationDate
	,(case when ts.Employee_ID is not null then N'TS' else null end) as TS
	,ctn.wt1
	from
	[dbo].[udf_CongTheoNgay](@fromdate,@todate) ctn
	left join
	udf_DanhSachHuongCheDo(@fromdate, @todate, @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan) ts
	on ctn.Employee_ID=ts.Employee_ID and ctn.Ngay between ts.Fromdate and ts.ToDate
	left join
	SmartBooks_Employee empl
	on ctn.Employee_ID=empl.Employee_ID
	where wt1>0
END




GO
