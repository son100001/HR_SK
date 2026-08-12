--select * from HR_EmployeeLeaveRequests
--exec sp_ApproveOrRejectLeaveRequest '2',N'00206',N'12','2024-03-04 00:00:00','2024-03-04 00:00:00',null,null,null,N'A','2024-03-04 16:13:28',N'admin',null,null,null
create PROCEDURE [dbo].[sp_ApproveOrRejectLeaveRequest] 
@ID int, 
@Employee_ID nvarchar(50),
@LeaveType_ID nvarchar(50),
@Fromdate datetime,
@ToDate datetime,
@Reason nvarchar(250),
@PlanStatus varchar(50),
@Remark nvarchar(250),
@TrangThai nvarchar(50),
@InsertDate datetime,
@UserName nvarchar(50),
@isDaNopGiay bit,
@isBlock bit,
@isChoUngPhep bit
AS
BEGIN
    IF @TrangThai in (N'A','Approved')
    BEGIN
        UPDATE HR_EmployeeLeaveRequests
        SET TrangThai = 'Approved', ApproverName=@UserName,ApproveDate=GETDATE()
        WHERE ID = @ID;
		INSERT INTO [dbo].[HR_EmployeeRegisMaternityLeave] (Employee_ID,LeaveType_ID,Fromdate,ToDate,Reason,PlanStatus,Remark,InsertDate,UserName,isDaNopGiay,isBlock,isChoUngPhep)
		SELECT [Employee_ID]
           ,[LeaveType_ID]
           ,[Fromdate]
           ,[ToDate]
           ,[Reason]
           ,[PlanStatus]
           ,[Remark]
           ,Getdate()
           ,@UserName
           ,[isDaNopGiay]
           ,[isBlock]
           ,[isChoUngPhep]
		   FROM [dbo].[HR_EmployeeLeaveRequests]
    END
    ELSE IF @TrangThai in ('R','Rejected')
    BEGIN
        UPDATE HR_EmployeeLeaveRequests
        SET TrangThai = 'Rejected'
        WHERE ID = @ID;
    END
END;
GO
