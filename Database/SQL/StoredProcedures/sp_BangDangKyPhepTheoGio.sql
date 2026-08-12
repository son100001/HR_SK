-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--select * from hr_category
CREATE PROCEDURE [dbo].[sp_BangDangKyPhepTheoGio] 
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
		select 
			[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,empl.starteddate,empl.ternimationdate,ptg.*
		from
		[dbo].[HR_DangKyPhepTheoGio] ptg
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		on ptg.Employee_ID=empl.Employee_ID
		where ptg.DateLeave between @fromdate and @todate and empl.Employee_ID is not null
	end else if @TypeOfReport=2 begin -- danh sách đi muộn về sớm theo phân tích công
		select 
			[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,tito.Employee_ID,tito.DateLeave,tito.TypeOfLeave,tito.HourLeave,ptg.LeaveType_ID,ptg.Remark,ptg.InsertDate,ptg.UserName,ptg.ID
		from
		(
			select Employee_ID,ot_Date as DateLeave,LateIn as HourLeave, 'VaoMuon' as TypeOfLeave from HR_TimeIn_TimeOut where ot_date between @fromdate and @todate and LateIn is not null
			union all
			select Employee_ID,ot_Date as DateLeave,EarlyOut as HourLeave, 'RaSom' as TypeOfLeave from HR_TimeIn_TimeOut where ot_date between @fromdate and @todate and EarlyOut is not null
		)tito
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		on tito.Employee_ID=empl.Employee_ID
		left join
		[dbo].[HR_DangKyPhepTheoGio] ptg
		on tito.Employee_ID=ptg.Employee_ID and tito.DateLeave=ptg.DateLeave
		where  empl.Employee_ID is not null
	end
END




GO
