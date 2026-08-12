
create PROCEDURE [dbo].[SubmitLeaveRequest] (
    @Employee_ID nvarchar(50),
    @LeaveType_ID nvarchar(50),
    @Fromdate datetime,
    @ToDate datetime,
    @Reason nvarchar(255),
    @PlanStatus varchar(50),
    @Remark nvarchar(225),  
    @UserName nvarchar(50),
    @isDaNopGiay bit,
    @isBlock bit,
    @isChoUngPhep bit,
    @Request_ID INT OUTPUT
)
AS
BEGIN
    INSERT INTO HR_EmployeeLeaveRequests (
        [Employee_ID],
        [LeaveType_ID],
        [Fromdate],
        [ToDate],
        [Reason],
        [PlanStatus],
        [Remark],
        [TrangThai],
        [InsertDate],
        [UserName],
        [isDaNopGiay],
        [isBlock],
        [isChoUngPhep]
    )
    VALUES (
        @Employee_ID,
        @LeaveType_ID,
        @Fromdate,
        @ToDate,
        @Reason,
        @PlanStatus,
        @Remark,
        N'Pending',
        GETDATE(),
        @UserName,
        @isDaNopGiay,
        @isBlock,
        @isChoUngPhep
    );
    
    SET @Request_ID = SCOPE_IDENTITY();
END;

GO
