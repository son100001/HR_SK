
CREATE   FUNCTION [dbo].[udf_GetNguoiNhanThongBao]
(
    @Employee_ID nvarchar(50),
    @TypeOfNoti nvarchar(50)
)
RETURNS @rtnGetNguoiNhanThongBao TABLE (
    Employee_ID nvarchar(50),
    Approver_ID nvarchar(50),
    Fullname nvarchar(100),
    Type_ nvarchar(50),
    Email nvarchar(100),
    Sended bit,
    ChiNhanThongBao bit,
    NotifyViaWeb bit,
    NotifyViaEmail bit,
    NotifyViaZalo bit,
    [EmailSender] nvarchar(100),
    PassEmail nvarchar(100),
    SMTP_Client nvarchar(50),
    [Port] nvarchar(100),
    [SSL] nvarchar(100),
    UrlApprove nvarchar(100),
    UrlApproveGoOut nvarchar(100),
    ApprovedBy_ID nvarchar(50),
    ApprovedByName nvarchar(200),
    Request_ID nvarchar(50),
    -- Chi tiet don (moi)
    ReqFromDate datetime,
    ReqToDate datetime,
    ReqTimeOut datetime,
    ReqTimeIn datetime,
    ReqReason nvarchar(500),
    LeaveTypeVN nvarchar(100),
    LeaveTypeEN nvarchar(255),
    LeaveTypeKR nvarchar(100)
)
AS
BEGIN
    INSERT INTO @rtnGetNguoiNhanThongBao (
        Employee_ID, Approver_ID, Fullname, Type_, Email, Sended, ChiNhanThongBao,
        NotifyViaWeb, NotifyViaEmail, NotifyViaZalo,
        [EmailSender], PassEmail, SMTP_Client, [Port], [SSL], UrlApprove, UrlApproveGoOut,
        ApprovedBy_ID, ApprovedByName, Request_ID,
        ReqFromDate, ReqToDate, ReqTimeOut, ReqTimeIn, ReqReason,
        LeaveTypeVN, LeaveTypeEN, LeaveTypeKR
    )
    SELECT
        dsnntb.Employee_ID,
        dsnntb.Approver_ID,
        dsnntb.Fullname,
        dsnntb.Type_,
        dsnntb.Email1,
        dsnntb.Sended,
        dsnntb.ChiNhanThongBao,
        ISNULL(dsnntb.NotifyViaWeb, 1),
        ISNULL(dsnntb.NotifyViaEmail, 1),
        ISNULL(dsnntb.NotifyViaZalo, 1),
        su.Email,
        su.PassEmail,
        su.SMTP_Client,
        su.[Port],
        su.[SSL],
        su.UrlApprove,
        su.UrlApproveGoOut,
        COALESCE(goOutApproved.Approver_ID, leaveApproved.Approver_ID) AS ApprovedBy_ID,
        COALESCE(goOutApproved.ApproverName, leaveApproved.ApproverName) AS ApprovedByName,
        COALESCE(goOutReq.Request_ID, leaveReq.Request_ID) AS Request_ID,
        COALESCE(goOutReq.ReqFromDate, leaveReq.ReqFromDate) AS ReqFromDate,
        leaveReq.ReqToDate                                    AS ReqToDate,
        goOutReq.ReqTimeOut                                   AS ReqTimeOut,
        goOutReq.ReqTimeIn                                    AS ReqTimeIn,
        COALESCE(goOutReq.ReqReason, leaveReq.ReqReason)      AS ReqReason,
        leaveReq.LeaveTypeVN                                  AS LeaveTypeVN,
        leaveReq.LeaveTypeEN                                  AS LeaveTypeEN,
        leaveReq.LeaveTypeKR                                  AS LeaveTypeKR
    FROM HR_DanhSachNguoiNhanThongBao dsnntb
    LEFT JOIN (
        SELECT
            MAX(CASE WHEN su.ID = 'Email' THEN su.[Value] END) AS Email,
            MAX(CASE WHEN su.ID = 'PassEmail' THEN su.[Value] END) AS PassEmail,
            MAX(CASE WHEN su.ID = 'SMTP_Client' THEN su.[Value] END) AS SMTP_Client,
            MAX(CASE WHEN su.ID = 'Port' THEN su.[Value] END) AS [Port],
            MAX(CASE WHEN su.ID = 'SSL' THEN su.[Value] END) AS [SSL],
            MAX(CASE WHEN su.ID = 'UrlApprove' THEN su.[Value] END) AS [UrlApprove],
            MAX(CASE WHEN su.ID = 'UrlApproveGoOut' THEN su.[Value] END) AS [UrlApproveGoOut]
        FROM setup su
        WHERE su.FunctionID = 'Email'
    ) su ON 1 = 1
    OUTER APPLY (
        SELECT TOP 1
            h.Approver_ID,
            COALESCE(
                NULLIF(LTRIM(RTRIM(dbo.udf_FullName(empl.Employee_Firstname, empl.Employee_LastName))), ''),
                h.Approver_Name,
                h.Approver_ID
            ) AS ApproverName
        FROM HR_LeaveRequestGoOut req
        INNER JOIN HR_RequestLeaveGoOut_History h ON h.Request_ID = req.ID
        LEFT JOIN SmartBooks_Employee empl ON empl.Employee_ID = h.Approver_ID
        WHERE dsnntb.Type_ IN ('RequestGoOut', 'RejectGoOut', 'RequestGoOutGuard', 'GoOutGuardConfirmed')
          AND req.Employee_ID = dsnntb.Employee_ID
        ORDER BY h.Approve_Date DESC, h.Request_ID DESC
    ) goOutApproved
    OUTER APPLY (
        SELECT TOP 1
            h.Approver_ID,
            COALESCE(
                NULLIF(LTRIM(RTRIM(dbo.udf_FullName(empl.Employee_Firstname, empl.Employee_LastName))), ''),
                h.Approver_Name,
                h.Approver_ID
            ) AS ApproverName
        FROM HR_EmployeeLeaveRequests req
        INNER JOIN HR_RequestLeave_History h ON h.Request_ID = req.ID
        LEFT JOIN SmartBooks_Employee empl ON empl.Employee_ID = h.Approver_ID
        WHERE dsnntb.Type_ IN ('RequestLeave', 'RejectLeave')
          AND req.Employee_ID = dsnntb.Employee_ID
        ORDER BY h.Approve_Date DESC, h.Request_ID DESC
    ) leaveApproved
    OUTER APPLY (
        SELECT TOP 1
            CAST(req.ID AS nvarchar(50)) AS Request_ID,
            req.TimeDate  AS ReqFromDate,
            req.TimeOut_  AS ReqTimeOut,
            req.TimeIn    AS ReqTimeIn,
            req.Remark    AS ReqReason
        FROM HR_LeaveRequestGoOut req
        WHERE dsnntb.Type_ IN ('RequestGoOut', 'RejectGoOut', 'RequestGoOutGuard', 'GoOutGuardConfirmed')
          AND req.Employee_ID = dsnntb.Employee_ID
        ORDER BY req.InsertDate DESC, req.ID DESC
    ) goOutReq
    OUTER APPLY (
        SELECT TOP 1
            CAST(req.ID AS nvarchar(50)) AS Request_ID,
            req.Fromdate AS ReqFromDate,
            req.Todate   AS ReqToDate,
            req.Reason   AS ReqReason,
            lt.LeaveType_VN AS LeaveTypeVN,
            lt.LeaveType_EN AS LeaveTypeEN,
            lt.LeaveType_KR AS LeaveTypeKR
        FROM HR_EmployeeLeaveRequests req
        LEFT JOIN SmartBooks_LeaveType lt ON lt.LeaveType_ID = req.LeaveType_ID
        WHERE dsnntb.Type_ IN ('RequestLeave', 'RejectLeave')
          AND req.Employee_ID = dsnntb.Employee_ID
        ORDER BY req.InsertDate DESC, req.ID DESC
    ) leaveReq
    WHERE CASE WHEN @Employee_ID IS NULL THEN '' ELSE Employee_ID END =
          CASE WHEN @Employee_ID IS NULL THEN '' ELSE @Employee_ID END
      AND Type_ = @TypeOfNoti
      AND Sended = 0;

    RETURN;
END

GO
