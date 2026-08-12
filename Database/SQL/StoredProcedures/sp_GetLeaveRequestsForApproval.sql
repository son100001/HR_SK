
--exec [dbo].[sp_GetLeaveRequestsForApproval] N'admin','2024-03-01','2024-03-31',1,'VN',N'',N'',N'',N'',N'','',N'00440'
--exec [dbo].[sp_GetLeaveRequestsForApproval] N'KR001','2024-03-01','2024-03-31',1,'VN',N'',N'',N'',N'',N'','',N'HQ001'
create PROCEDURE [dbo].[sp_GetLeaveRequestsForApproval]
	@UserName nvarchar(50),
	@fromdate datetime,
	@todate datetime,
	@type int,
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Emp nvarchar(50)
	
AS
BEGIN
	set @Emp= (select Employee_ID from [User] where UserName=@UserName)
    IF EXISTS  (SELECT DepartmentName FROM [dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,getdate()) WHERE Employee_ID = @Emp)
    BEGIN
        DECLARE @DepartmentID nvarchar(250);
        SELECT @DepartmentID = DepartmentName FROM [dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,getdate()) WHERE Employee_ID = @Emp;

		select
		erml.TrangThai	
		,empl.Employee_ID
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		,empl.ComStartedDate
		,empl.DepartmentName
		,empl.PositionName
		,(select AbsentSign from SmartBooks_LeaveType where LeaveType_ID=erml.LeaveType_ID) as AbsentSign
		,erml.LeaveType_ID
		,erml.[Fromdate]
		,erml.ToDate
		, case when LeaveType_ID=49 then 
		[dbo].[udf_CountWorkingDayWithSun](erml.[Fromdate],erml.ToDate) else
		[dbo].[udf_CountWorkingDay](erml.[Fromdate],erml.ToDate)/(case when LeaveType_ID in ('31','32') then 2.0 else 1 end) end as NumberOfDate	
		,erml.LeaveType_ID as MaNghiPhep
		,erml.Remark
		,erml.InsertDate
		,erml.UserName
		,erml.ID
        FROM HR_EmployeeLeaveRequests erml
		INNER JOIN
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,getdate()) empl
		ON erml.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
        WHERE (empl.DepartmentName = @DepartmentID ) 
        AND erml.TrangThai = 'Pending' and erml.Employee_ID<>@Emp;

    END
    ELSE IF @Emp = N'KR1' 
    BEGIN
       	select
		erml.TrangThai	
		,empl.Employee_ID
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		,empl.ComStartedDate
		,empl.DepartmentName
		,empl.PositionName
		,(select AbsentSign from SmartBooks_LeaveType where LeaveType_ID=erml.LeaveType_ID) as AbsentSign
		,erml.LeaveType_ID
		,erml.[Fromdate]
		,erml.ToDate
		, case when LeaveType_ID=49 then 
		[dbo].[udf_CountWorkingDayWithSun](erml.[Fromdate],erml.ToDate) else
		[dbo].[udf_CountWorkingDay](erml.[Fromdate],erml.ToDate)/(case when LeaveType_ID in ('31','32') then 2.0 else 1 end) end as NumberOfDate	
		--,erml.LeaveType_ID as MaNghiPhep
		,erml.Remark
		,erml.InsertDate
		,erml.UserName
		,erml.ID
        FROM HR_EmployeeLeaveRequests erml
		INNER JOIN
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,getdate()) empl
		ON erml.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
        WHERE  erml.TrangThai = 'Pending' and erml.Employee_ID in ( select RequesterID from HR_Approvers);
    END
    ELSE
    BEGIN
        RAISERROR ('Employee is not a valid approver.', 16, 1);
        RETURN;
    END
END;

--update Permission set UserName=N'KR1' where UserName=N'KR001'
--select * from HR_EmployeeLeaveRequests
--update HR_EmployeeLeaveRequests set TrangThai=N'Pending'
--select * from HR_Approvers
--update HR_Approvers set ApproverID=N'KR1'
GO
