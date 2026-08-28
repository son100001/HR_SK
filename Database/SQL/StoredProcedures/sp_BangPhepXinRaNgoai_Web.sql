-- exec [dbo].[sp_BangPhepXinRaNgoai_Web] '2026-01-01', '2026-12-31',4,null,null,null,null,null,null,null,'C6745'
CREATE   PROCEDURE [dbo].[sp_BangPhepXinRaNgoai_Web]
    @fromdate datetime,
    @todate datetime,
    @TypeOfReport int = 4,
    @LAN nvarchar(50) = 'VN',
    @fact nvarchar(50) = null,
    @dept nvarchar(50) = null,
    @sect nvarchar(50) = null,
    @team nvarchar(50) = null,
    @pos nvarchar(50) = null,
    @posc nvarchar(50) = null,
    @Emp nvarchar(50) = null
AS
BEGIN
    SET NOCOUNT ON;

    -- Mode 4: Employee go-out requests (pending, rejected, or approved).
    IF @TypeOfReport = 4
    BEGIN
        SELECT
            lrg.TrangThai,
            lrg.LeaveType_ID,
            lrg.TimeDate,
            lrg.TimeOut_,
            lrg.TimeIn,
            lrg.ShiftName,
            lrg.Remark,
            lrg.ApproveDate,
            lrg.ApproverName AS Approver,
            lrg.ApproveLevel AS ApproverCurrent,
            ISNULL(gap.[Name], lrg.ApproverName) AS ApproverText,
            ISNULL(currentApproverAgg.FullNames, lrg.ApproveLevel) AS ApproverCurrentText,
            lrg.ID,
            lrg.InsertDate,
            CAST(NULL AS datetime) AS GioVaoThucTe,
            ISNULL((
                SELECT COUNT(*)
                FROM HR_RequestLeaveGoOut_History h
                WHERE h.Request_ID = lrg.ID
            ), 0) AS ApprovedStepCount
        FROM udf_EmployeeFilter(@LAN, @fact, @dept, @sect, @team, @pos, @posc, @Emp, @todate) empl
        LEFT JOIN HR_LeaveRequestGoOut lrg
            ON lrg.Employee_ID = empl.Employee_ID
        LEFT JOIN HR_GetApprover gap
            ON gap.Employee_ID = lrg.Employee_ID
            AND gap.Code = lrg.ApproverName
        OUTER APPLY (
            SELECT STRING_AGG(CAST(ISNULL(dbo.udf_FullName(currentApprover.Employee_Firstname, currentApprover.Employee_LastName), dt.[Data]) AS nvarchar(max)), N', ')
                WITHIN GROUP (ORDER BY dt.Order_) AS FullNames
            FROM Split(lrg.ApproveLevel, ',') dt
            LEFT JOIN SmartBooks_Employee currentApprover
                ON currentApprover.Employee_ID = dt.[Data]
            WHERE dt.[Data] <> ''
        ) currentApproverAgg
        WHERE lrg.TimeDate BETWEEN @fromdate AND @todate
            AND lrg.TrangThai IN ('Pending', 'Rejected')

        UNION

        SELECT
            'Approved' AS TrangThai,
            goout.LeaveType_ID,
            goout.TimeDate,
            goout.TimeOut_,
            goout.TimeIn,
            goout.ShiftName,
            goout.Remark,
            goout.InsertDate AS ApproveDate,
            goout.UserName AS Approver,
            NULL AS ApproverCurrent,
            ISNULL(
                dbo.udf_FullName(insertUser.Employee_Firstname, insertUser.Employee_LastName),
                goout.UserName
            ) AS ApproverText,
            NULL AS ApproverCurrentText,
            goout.ID,
            goout.InsertDate,
            goout.GioVaoThucTe,
            0 AS ApprovedStepCount
        FROM udf_EmployeeFilter(@LAN, @fact, @dept, @sect, @team, @pos, @posc, @Emp, @todate) empl
        LEFT JOIN HR_GoOut goout
            ON empl.Employee_ID = goout.Employee_ID
        LEFT JOIN SmartBooks_Employee insertUser
            ON insertUser.Employee_ID = goout.UserName
        WHERE goout.TimeDate BETWEEN @fromdate AND @todate
        ORDER BY TimeDate DESC, InsertDate DESC;
    END
    -- Mode 5: Pending go-out requests for the current approver.
    ELSE IF @TypeOfReport = 5
    BEGIN
        SELECT
            empl.PositionFullName AS DepartmentName,
            empl.ChucDanh,
            lrg.Employee_ID,
            dbo.udf_FullName(empl.Employee_Firstname, empl.Employee_LastName) AS FullName,
            lrg.TrangThai,
            lrg.LeaveType_ID,
            lrg.TimeDate,
            lrg.TimeOut_,
            lrg.TimeIn,
            lrg.ShiftName,
            lrg.Remark,
            rlh.Approver_Name AS LastestApprover,
            rlh.Approve_Date AS LastestApproveDate,
            lrg.ID,
            lrg.InsertDate
        FROM HR_LeaveRequestGoOut lrg
        OUTER APPLY (
            SELECT TOP 1
                employeeInfo.PositionFullName,
                employeeInfo.ChucDanh,
                employeeInfo.Employee_Firstname,
                employeeInfo.Employee_LastName
            FROM udf_EmployeeFilter(@LAN, NULL, NULL, NULL, NULL, NULL, NULL, lrg.Employee_ID, GETDATE()) employeeInfo
        ) empl
        LEFT JOIN (
            SELECT
                Request_ID,
                Approver_Name,
                Approve_Date,
                ROW_NUMBER() OVER (PARTITION BY Request_ID ORDER BY Approve_Date DESC) AS rn
            FROM HR_RequestLeaveGoOut_History
        ) rlh
            ON lrg.ID = rlh.Request_ID
            AND rlh.rn = 1
        WHERE lrg.TimeDate BETWEEN @fromdate AND @todate
            AND EXISTS (
                SELECT 1
                FROM Split(lrg.ApproveLevel, ',') currentLevel
                WHERE currentLevel.[Data] = @Emp
            )
            AND lrg.TrangThai = 'Pending'
        ORDER BY lrg.TimeOut_ DESC;
    END
    -- Mode 6: Guard confirmation pending (actual return time is missing).
    ELSE IF @TypeOfReport = 6
    BEGIN
        CREATE TABLE #EmployeeInfo (
            Employee_ID nvarchar(50) NOT NULL PRIMARY KEY,
            DepartmentName nvarchar(500) NULL,
            FullName nvarchar(500) NULL
        );

        INSERT INTO #EmployeeInfo (Employee_ID, DepartmentName, FullName)
        SELECT
            empl.Employee_ID,
            empl.PositionFullName,
            dbo.udf_FullName(empl.Employee_Firstname, empl.Employee_LastName)
        FROM udf_EmployeeFilter(@LAN, @fact, @dept, @sect, @team, @pos, @posc, NULL, @todate) empl;

        SELECT
            empl.DepartmentName,
            got.Employee_ID,
            ISNULL(empl.FullName, got.Employee_ID) AS FullName,
            'Pending' AS TrangThai,
            got.LeaveType_ID,
            got.TimeDate,
            got.TimeOut_,
            got.TimeIn,
            got.GioVaoThucTe,
            got.ShiftName,
            got.Remark,
            ISNULL(approver.FullName, got.UserName) AS Approver,
            got.InsertDate AS ApproveDate,
            got.ID,
            got.InsertDate
        FROM HR_GoOut got
        LEFT JOIN #EmployeeInfo empl
            ON got.Employee_ID = empl.Employee_ID
        LEFT JOIN #EmployeeInfo approver
            ON got.UserName = approver.Employee_ID
        WHERE got.TimeDate >= @fromdate
          AND got.TimeDate < DATEADD(DAY, 1, @todate)
          AND got.GioVaoThucTe IS NULL
        ORDER BY got.TimeOut_;
    END
    -- Mode 7: Guard confirmation history (actual return time is recorded).
    ELSE IF @TypeOfReport = 7
    BEGIN
        CREATE TABLE #EmployeeInfoHistory (
            Employee_ID nvarchar(50) NOT NULL PRIMARY KEY,
            DepartmentName nvarchar(500) NULL,
            FullName nvarchar(500) NULL
        );

        INSERT INTO #EmployeeInfoHistory (Employee_ID, DepartmentName, FullName)
        SELECT
            empl.Employee_ID,
            empl.PositionFullName,
            dbo.udf_FullName(empl.Employee_Firstname, empl.Employee_LastName)
        FROM udf_EmployeeFilter(@LAN, @fact, @dept, @sect, @team, @pos, @posc, NULL, @todate) empl;

        SELECT
            empl.DepartmentName,
            got.Employee_ID,
            ISNULL(empl.FullName, got.Employee_ID) AS FullName,
            'Approved' AS TrangThai,
            got.LeaveType_ID,
            got.TimeDate,
            got.TimeOut_,
            got.TimeIn,
            got.GioVaoThucTe,
            got.ShiftName,
            got.Remark,
            ISNULL(approver.FullName, got.UserName) AS Approver,
            got.InsertDate AS ApproveDate,
            got.ID,
            got.InsertDate
        FROM HR_GoOut got
        LEFT JOIN #EmployeeInfoHistory empl
            ON got.Employee_ID = empl.Employee_ID
        LEFT JOIN #EmployeeInfoHistory approver
            ON got.UserName = approver.Employee_ID
        WHERE got.TimeDate >= @fromdate
          AND got.TimeDate < DATEADD(DAY, 1, @todate)
          AND got.GioVaoThucTe IS NOT NULL
        ORDER BY got.GioVaoThucTe DESC;
    END
    -- Mode 8: Go-out request history handled by the current approver.
    ELSE IF @TypeOfReport = 8
    BEGIN
        SELECT
            empl.PositionFullName AS DepartmentName,
            empl.ChucDanh,
            lrg.Employee_ID,
            dbo.udf_FullName(empl.Employee_Firstname, empl.Employee_LastName) AS FullName,
            lrg.TrangThai,
            lrg.LeaveType_ID,
            lrg.TimeDate,
            lrg.TimeOut_,
            lrg.TimeIn,
            lrg.ShiftName,
            lrg.Remark,
            rlh.Approver_Name AS LastestApprover,
            rlh.Approve_Date AS LastestApproveDate,
            lrg.ID,
            lrg.InsertDate
        FROM HR_LeaveRequestGoOut lrg
        OUTER APPLY (
            SELECT TOP 1
                employeeInfo.PositionFullName,
                employeeInfo.ChucDanh,
                employeeInfo.Employee_Firstname,
                employeeInfo.Employee_LastName
            FROM udf_EmployeeFilter(@LAN, NULL, NULL, NULL, NULL, NULL, NULL, lrg.Employee_ID, GETDATE()) employeeInfo
        ) empl
        INNER JOIN (
            SELECT
                Request_ID,
                MAX(Approve_Date) AS MyApproveDate
            FROM HR_RequestLeaveGoOut_History
            WHERE Approver_ID = @Emp
            GROUP BY Request_ID
        ) myHist
            ON lrg.ID = myHist.Request_ID
        LEFT JOIN (
            SELECT
                Request_ID,
                Approver_Name,
                Approve_Date,
                ROW_NUMBER() OVER (PARTITION BY Request_ID ORDER BY Approve_Date DESC) AS rn
            FROM HR_RequestLeaveGoOut_History
        ) rlh
            ON lrg.ID = rlh.Request_ID
            AND rlh.rn = 1
        WHERE lrg.TimeDate BETWEEN @fromdate AND @todate
            AND NOT (
                lrg.TrangThai = 'Pending'
                AND EXISTS (
                    SELECT 1
                    FROM Split(lrg.ApproveLevel, ',') currentLevel
                    WHERE currentLevel.[Data] = @Emp
                )
            )
        ORDER BY myHist.MyApproveDate DESC;
    END
END

GO
