CREATE FUNCTION [dbo].[udf_DangKyPhepBatThuong]
(	
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime,
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@emp nvarchar(50)=null
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select 
	empl.DepartmentName as DepartmentCode,empl.TeamName as TeamCode,empl.PositionName as Position_ID,empl.Employee_ID
			,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,qv.DateLeave as Ngay,qv.LeaveType_ID,cast(qv.QuetVao as time) as RealTimeIn,cast(qr.QuetRa as time) as RealTimeOut
			,cast(null as nvarchar(50)) as Reason,N'Phép bất thường' as Remark,qv.ShiftName,cast(qv.GioNghiTu as time) as fromtime,cast(qv.GioNghiDen as time) as totime
	--empl.Position,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,qv.Employee_ID,qv.DateLeave,qv.LeaveType_ID,qv.ShiftName,cast(qv.GioNghiTu as time(0))as GioNghiTu,cast(qv.GioNghiDen as time(0)) as GioNghiDen,cast(qv.QuetVao as time(0)) as QuetVao,cast(qr.QuetRa as time(0)) as QuetRa
	from
		(
			select Employee_ID,DateLeave,LeaveType_ID,ShiftName,GioNghiTu,GioNghiDen,min(AccessTime) as QuetVao from [dbo].[udf_PhepVaDuLieuQuetLienQuan](@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp) group by Employee_ID,DateLeave,LeaveType_ID,GioNghiTu,GioNghiDen,ShiftName
		)qv
		left join
		(
			select Employee_ID,DateLeave,max(AccessTime) as QuetRa from [dbo].[udf_PhepVaDuLieuQuetLienQuan](@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp) group by Employee_ID,DateLeave
		)qr
		on qv.Employee_ID=qr.Employee_ID and qv.DateLeave=qr.DateLeave
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		on qv.Employee_ID=empl.Employee_ID
		where datediff(minute,case when qv.QuetVao<qv.GioNghiTu then qv.GioNghiTu else qv.QuetVao end,case when qr.QuetRa>qv.GioNghiDen then qv.GioNghiDen else qr.QuetRa end)>=60 
		 and empl.Employee_ID is not null
)



GO
