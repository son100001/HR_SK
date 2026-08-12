-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DangKyPhepBatThuong]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@LAN nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select ctn.Employee_ID,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName) as FullName
		,empl.DepartmentName,empl.SectionName,empl.TeamName,empl.PositionName,empl.PositionCategoryName
		,isnull(ctn.wt1,0)+isnull(ctn.wt2,0) as CongHanhChinh,ctn.Ngay,erl.HourLeave,erl.LeaveType_ID
	 from 
	udf_CongTheoNgay(@fromdate,@todate) ctn
	left join
	HR_EmpRegisLeave erl
	on ctn.Employee_ID=erl.Employee_ID and ctn.Ngay=erl.DateLeave
	left join
	udf_Smartbooks_Employee(@LAN) empl
	on ctn.Employee_ID=empl.Employee_ID
	where isnull(ctn.wt1,0)+isnull(ctn.wt2,0)+isnull(erl.HourLeave,0)>8
END




GO
