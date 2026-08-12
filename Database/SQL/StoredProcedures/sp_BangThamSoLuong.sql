--[dbo].[sp_BangThamSoLuong] '2022-01-19','2022-01-19','',1,'VN',N'',N'',N'',N'',N'','',N'WS000001'
--select * from HR_EmpRegisParameter where Employee_ID='WS000001'
CREATE PROCEDURE [dbo].[sp_BangThamSoLuong]
	--[dbo].[sp_BangThamSoLuong] '2020-05-01','2020-05-31','HinhThucThanhToanLuong',1,'VN',N'',N'',N'',N'',N'','',N'0003'
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@parameter varchar(50),
	@TypeOfReport int=1,--1:xem lương theo bảng dọc, 2: xem lương theo bảng ngang
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
		select empl.Position,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		,erp.*
	from
		HR_EmpRegisParameter erp
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		on erp.Employee_ID=empl.Employee_ID
		where erp.Fromdate<=@todate and (erp.todate is null or erp.todate>=@fromdate)
		and empl.Employee_ID is not null
	end
END




GO
