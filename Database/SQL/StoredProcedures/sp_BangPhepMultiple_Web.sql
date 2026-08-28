-- exec [dbo].[sp_BangPhepMultiple_Web] '2026-01-01', '2026-12-31', 10, 'VN', null, null, null, null, null, null, 'C6745'
CREATE PROCEDURE [dbo].[sp_BangPhepMultiple_Web]
    @fromdate datetime,
    @todate datetime,
    @TypeOfReport int = 10,
    @LAN nvarchar(50) = 'VN',
    @fact nvarchar(50) = null,
    @dept nvarchar(50) = null,
    @sect nvarchar(50) = null,
    @team nvarchar(50) = null,
    @pos nvarchar(50) = null,
    @posc nvarchar(50) = null,
    @Emp nvarchar(50) = null,
    @ListOfLeaveType varchar(max) = null
AS
BEGIN
    SET NOCOUNT ON;

    -- Mode 10: Employee leave request list.
    IF @TypeOfReport = 10
    BEGIN
        SELECT
            elr.TrangThai,
            elr.LeaveType_ID,
            elr.Fromdate,
            elr.Todate,
            ROUND(
                CASE
                    WHEN elr.LeaveType_ID IN ('49', '24') THEN
                        [dbo].[udf_CountWorkingDayWithSun](elr.[Fromdate], elr.ToDate) / 1
                    ELSE
                        [dbo].[udf_CountWorkingDay](elr.[Fromdate], elr.ToDate) /
                        (CASE WHEN elr.LeaveType_ID IN ('31', '32') THEN 2.0 ELSE 1 END)
                END,
                2
            ) AS NumberOfDate,
            CASE
                WHEN elr.LeaveType_ID IN ('49', '24') THEN
                    8 * ([dbo].[udf_CountWorkingDayWithSun](elr.[Fromdate], elr.ToDate))
                ELSE
                    8 * ([dbo].[udf_CountWorkingDay](elr.[Fromdate], elr.ToDate)) /
                    (CASE WHEN elr.LeaveType_ID IN ('31', '32') THEN 2.0 ELSE 1 END)
            END AS HourLeave,
            elr.RaSomVaoMuon,
            elr.ApproverName AS Approver,
            elr.ApproveLevel AS ApproverCurrent,
            ISNULL(gap.[Name], elr.ApproverName) AS ApproverText,
            ISNULL(currentApproverAgg.FullNames, elr.ApproveLevel) AS ApproverCurrentText,
            elr.isChoUngPhep,
            elr.ID,
            elr.InsertDate,
            elr.ImageBinary,
            elr.ImageFileName,
            elr.ImageFileType,
            elr.ImageFileSize,
            ISNULL((
                SELECT COUNT(*)
                FROM HR_RequestLeave_History h
                WHERE h.Request_ID = elr.ID
            ), 0) AS ApprovedStepCount
        FROM udf_EmployeeFilter(@LAN, @fact, @dept, @sect, @team, @pos, @posc, @Emp, @todate) empl
        LEFT JOIN HR_EmployeeLeaveRequests elr
            ON elr.Employee_ID = empl.Employee_ID
        LEFT JOIN HR_GetApprover gap
            ON gap.Employee_ID = elr.Employee_ID
            AND gap.Code = elr.ApproverName
        OUTER APPLY (
            SELECT STRING_AGG(CAST(ISNULL(dbo.udf_FullName(currentApprover.Employee_Firstname, currentApprover.Employee_LastName), dt.[Data]) AS nvarchar(max)), N', ')
                WITHIN GROUP (ORDER BY dt.Order_) AS FullNames
            FROM Split(elr.ApproveLevel, ',') dt
            LEFT JOIN SmartBooks_Employee currentApprover
                ON currentApprover.Employee_ID = dt.[Data]
            WHERE dt.[Data] <> ''
        ) currentApproverAgg
        WHERE elr.Fromdate BETWEEN @fromdate AND @todate
            AND elr.TrangThai IN ('Pending', 'Rejected')
            AND elr.LeaveType_ID <> '14'

        UNION

        SELECT
            'Approved' AS TrangThai,
            ISNULL(erml.LeaveType_ID, bptn.LeaveType_ID) AS LeaveType_ID,
            ISNULL(erml.Fromdate, bptn.DateLeave) AS Fromdate,
            ISNULL(erml.Todate, bptn.DateLeave) AS Todate,
            ROUND(
                (CASE
                    WHEN erml.LeaveType_ID IN ('24', '49') THEN [dbo].[udf_CountWorkingDayWithSun](erml.[Fromdate], erml.ToDate) / 1
                    WHEN erml.Employee_ID IS NOT NULL THEN [dbo].[udf_CountWorkingDay](erml.[Fromdate], erml.ToDate)
                    ELSE bptn.HourLeave / 8.0
                END) /
                (CASE
                    WHEN erml.Employee_ID IS NOT NULL AND erml.LeaveType_ID IN ('31', '32') THEN 2.0
                    ELSE 1
                END),
                2
            ) AS NumberOfDate,
            ISNULL(bptn.HourLeave, 8) *
            (CASE
                WHEN erml.LeaveType_ID IN ('49', '24') THEN [dbo].[udf_CountWorkingDayWithSun](erml.[Fromdate], erml.ToDate) / 1
                WHEN erml.Employee_ID IS NOT NULL THEN [dbo].[udf_CountWorkingDay](erml.[Fromdate], erml.ToDate)
                WHEN bptn.LeaveType_ID IN ('31', '32') THEN 1
                ELSE 1
            END) AS HourLeave,
            NULL AS RaSomVaoMuon,
            COALESCE(approvedElr.ApproverName, erml.UserName) AS Approver,
            COALESCE(approvedElr.ApproveLevel, lastApprovedHist.Approver_ID) AS ApproverCurrent,
            ISNULL(
                gapApproved.[Name],
                ISNULL(
                    dbo.udf_FullName(insertUser.Employee_Firstname, insertUser.Employee_LastName),
                    COALESCE(approvedElr.ApproverName, erml.UserName)
                )
            ) AS ApproverText,
            COALESCE(
                approvedCurrentApproverAgg.FullNames,
                lastApprovedHist.Approver_Name,
                approvedElr.ApproveLevel
            ) AS ApproverCurrentText,
            erml.isChoUngPhep,
            approvedElr.ID,
            COALESCE(erml.InsertDate, approvedElr.InsertDate) AS InsertDate,
            '' AS ImageBinary,
            '' AS ImageFileName,
            '' AS ImageFileType,
            '' AS ImageFileSize,
            ISNULL((
                SELECT COUNT(*)
                FROM HR_RequestLeave_History h
                WHERE h.Request_ID = approvedElr.ID
            ), 0) AS ApprovedStepCount
        FROM udf_EmployeeFilter(@LAN, @fact, @dept, @sect, @team, @pos, @posc, @Emp, @todate) empl
        LEFT JOIN udf_BangThoiGian(@fromdate, @todate) btg
            ON btg.Date_ >= empl.StartedDate
        LEFT JOIN HR_EmployeeRegisMaternityLeave erml
            ON empl.Employee_ID = erml.Employee_ID
            AND erml.Fromdate <> erml.ToDate
            AND (erml.Fromdate BETWEEN @fromdate AND @todate OR erml.ToDate BETWEEN @fromdate AND @todate)
            AND btg.Date_ BETWEEN erml.Fromdate AND erml.ToDate
        LEFT JOIN udf_BangPhepTheoNgay(2, @fromdate, @todate, @fact, @dept, @sect, @team, @pos, @posc, @Emp, NULL) bptn
            ON bptn.Employee_ID = empl.Employee_ID
            AND bptn.DateLeave NOT BETWEEN ISNULL(erml.Fromdate, @fromdate - 1) AND ISNULL(erml.ToDate, @fromdate - 1)
            AND bptn.DateLeave = btg.Date_
        LEFT JOIN SmartBooks_Employee insertUser
            ON insertUser.Employee_ID = erml.UserName
        OUTER APPLY (
            SELECT TOP 1
                elr.ID,
                elr.InsertDate,
                elr.ApproverName,
                elr.ApproveLevel
            FROM HR_EmployeeLeaveRequests elr
            WHERE elr.Employee_ID = empl.Employee_ID
                AND elr.TrangThai = 'Approved'
                AND elr.LeaveType_ID = ISNULL(erml.LeaveType_ID, bptn.LeaveType_ID)
                AND ISNULL(erml.Fromdate, bptn.DateLeave) BETWEEN elr.Fromdate AND elr.Todate
            ORDER BY elr.InsertDate DESC
        ) approvedElr
        LEFT JOIN HR_GetApprover gapApproved
            ON gapApproved.Employee_ID = empl.Employee_ID
            AND gapApproved.Code = approvedElr.ApproverName
        OUTER APPLY (
            SELECT STRING_AGG(CAST(ISNULL(dbo.udf_FullName(currentApprover.Employee_Firstname, currentApprover.Employee_LastName), dt.[Data]) AS nvarchar(max)), N', ')
                WITHIN GROUP (ORDER BY dt.Order_) AS FullNames
            FROM Split(approvedElr.ApproveLevel, ',') dt
            LEFT JOIN SmartBooks_Employee currentApprover
                ON currentApprover.Employee_ID = dt.[Data]
            WHERE dt.[Data] <> ''
        ) approvedCurrentApproverAgg
        OUTER APPLY (
            SELECT TOP 1
                rlh.Approver_ID,
                rlh.Approver_Name
            FROM HR_RequestLeave_History rlh
            WHERE rlh.Request_ID = approvedElr.ID
            ORDER BY rlh.Approve_Date DESC
        ) lastApprovedHist
        WHERE erml.Employee_ID IS NOT NULL
            OR (bptn.DateLeave IS NOT NULL AND bptn.LeaveType_ID <> '14')
        ORDER BY Fromdate DESC;
    END
    -- Mode 11: Pending employee leave requests (legacy/filter).
    ELSE IF @TypeOfReport = 11
    BEGIN
        SELECT
            empl.DepartmentName,
            elr.Employee_ID,
            dbo.udf_FullName(empl.Employee_FirstName, empl.Employee_LastName) AS FullName,
            elr.TrangThai,
            elr.LeaveType_ID,
            elr.Fromdate,
            elr.Todate,
            ROUND(
                CASE
                    WHEN elr.LeaveType_ID = 49 THEN
                        [dbo].[udf_CountWorkingDayWithSun](elr.[Fromdate], elr.ToDate) / 1
                    ELSE
                        [dbo].[udf_CountWorkingDay](elr.[Fromdate], elr.ToDate) /
                        (CASE WHEN elr.LeaveType_ID IN ('31', '32') THEN 2.0 ELSE 1 END)
                END,
                2
            ) AS NumberOfDate,
            8 * ([dbo].[udf_CountWorkingDay](elr.[Fromdate], elr.ToDate) /
                (CASE WHEN elr.LeaveType_ID IN ('31', '32') THEN 2.0 ELSE 1 END)) AS HourLeave,
            elr.RaSomVaoMuon,
            elr.ApproverName AS Approver,
            elr.ApproveLevel AS ApproverCurrent,
            ISNULL(gap.[Name], elr.ApproverName) AS ApproverText,
            ISNULL(currentApproverAgg.FullNames, elr.ApproveLevel) AS ApproverCurrentText,
            elr.isDaNopGiay,
            elr.isChoUngPhep,
            elr.ID,
            elr.InsertDate,
            elr.ImageBinary,
            elr.ImageFileName,
            elr.ImageFileType,
            elr.ImageFileSize
        FROM udf_EmployeeFilter(@LAN, @fact, @dept, @sect, @team, @pos, @posc, @Emp, @todate) empl
        LEFT JOIN HR_EmployeeLeaveRequests elr
            ON elr.Employee_ID = empl.Employee_ID
        LEFT JOIN HR_GetApprover gap
            ON gap.Employee_ID = elr.Employee_ID
            AND gap.Code = elr.ApproverName
        OUTER APPLY (
            SELECT STRING_AGG(CAST(ISNULL(dbo.udf_FullName(currentApprover.Employee_Firstname, currentApprover.Employee_LastName), dt.[Data]) AS nvarchar(max)), N', ')
                WITHIN GROUP (ORDER BY dt.Order_) AS FullNames
            FROM Split(elr.ApproveLevel, ',') dt
            LEFT JOIN SmartBooks_Employee currentApprover
                ON currentApprover.Employee_ID = dt.[Data]
            WHERE dt.[Data] <> ''
        ) currentApproverAgg
        WHERE elr.Fromdate BETWEEN @fromdate AND @todate
            AND elr.TrangThai IN ('Pending')
        ORDER BY Fromdate DESC;
    END
    -- Mode 12: Pending leave approvals for the current approver.
    ELSE IF @TypeOfReport = 12
    BEGIN
        SELECT
            empl.PositionFullName AS DepartmentName,
            empl.ChucDanh,
            elr.Employee_ID,
            dbo.udf_FullName(empl.Employee_Firstname, empl.Employee_LastName) AS FullName,
            elr.TrangThai,
            elr.LeaveType_ID,
            ISNULL(CASE WHEN @LAN = 'EN' THEN lt.LeaveType_EN ELSE lt.LeaveType_VN END, elr.LeaveType_ID) AS LeaveTypeName,
            elr.Fromdate,
            elr.Todate,
            CASE
                WHEN elr.LeaveType_ID IN ('49', '24') THEN
                    [dbo].[udf_CountWorkingDayWithSun](elr.[Fromdate], elr.ToDate) / 1
                ELSE
                    [dbo].[udf_CountWorkingDay](elr.[Fromdate], elr.ToDate) /
                    (CASE WHEN elr.LeaveType_ID IN ('31', '32') THEN 2.0 ELSE 1 END)
            END AS NumberOfDate,
            ISNULL(elr.HourLeave, 8) /
                (CASE WHEN elr.LeaveType_ID IN ('31', '32') THEN 2.0 ELSE 1 END) AS HourLeave,
            elr.isChoUngPhep,
            elr.ID,
            rlh.Approver_Name AS LastestApprover,
            rlh.Approve_Date AS LastestApproveDate,
            elr.InsertDate
        FROM HR_EmployeeLeaveRequests elr
        OUTER APPLY (
            SELECT TOP 1
                employeeInfo.PositionFullName,
                employeeInfo.ChucDanh,
                employeeInfo.Employee_Firstname,
                employeeInfo.Employee_LastName
            FROM udf_EmployeeFilter(@LAN, NULL, NULL, NULL, NULL, NULL, NULL, elr.Employee_ID, GETDATE()) employeeInfo
        ) empl
        LEFT JOIN (
            SELECT
                Request_ID,
                Approver_Name,
                Approve_Date,
                ROW_NUMBER() OVER (PARTITION BY Request_ID ORDER BY Approve_Date DESC) AS rn
            FROM HR_RequestLeave_History
        ) rlh
            ON elr.ID = rlh.Request_ID
            AND rlh.rn = 1
        LEFT JOIN SmartBooks_LeaveType lt ON CAST(lt.LeaveType_ID AS varchar(50)) = elr.LeaveType_ID
        WHERE EXISTS (
                SELECT 1
                FROM Split(elr.ApproveLevel, ',') currentLevel
                WHERE currentLevel.[Data] = @Emp
            )
            AND elr.TrangThai = 'Pending'
            AND (elr.Fromdate BETWEEN @fromdate AND @todate OR elr.Todate BETWEEN @fromdate AND @todate)
        ORDER BY elr.Fromdate;
    END
    -- Mode 13: Leave approval history handled by the current approver.
    ELSE IF @TypeOfReport = 13
    BEGIN
        SELECT
            empl.PositionFullName AS DepartmentName,
            empl.ChucDanh,
            elr.Employee_ID,
            dbo.udf_FullName(empl.Employee_Firstname, empl.Employee_LastName) AS FullName,
            elr.TrangThai,
            elr.LeaveType_ID,
            ISNULL(CASE WHEN @LAN = 'EN' THEN lt.LeaveType_EN ELSE lt.LeaveType_VN END, elr.LeaveType_ID) AS LeaveTypeName,
            elr.Fromdate,
            elr.Todate,
            CASE
                WHEN elr.LeaveType_ID IN ('49', '24') THEN
                    [dbo].[udf_CountWorkingDayWithSun](elr.[Fromdate], elr.ToDate) / 1
                ELSE
                    [dbo].[udf_CountWorkingDay](elr.[Fromdate], elr.ToDate) /
                    (CASE WHEN elr.LeaveType_ID IN ('31', '32') THEN 2.0 ELSE 1 END)
            END AS NumberOfDate,
            ISNULL(elr.HourLeave, 8) /
                (CASE WHEN elr.LeaveType_ID IN ('31', '32') THEN 2.0 ELSE 1 END) AS HourLeave,
            elr.isChoUngPhep,
            elr.ID,
            rlh.Approver_Name AS LastestApprover,
            rlh.Approve_Date AS LastestApproveDate,
            elr.InsertDate
        FROM HR_EmployeeLeaveRequests elr
        OUTER APPLY (
            SELECT TOP 1
                employeeInfo.PositionFullName,
                employeeInfo.ChucDanh,
                employeeInfo.Employee_Firstname,
                employeeInfo.Employee_LastName
            FROM udf_EmployeeFilter(@LAN, NULL, NULL, NULL, NULL, NULL, NULL, elr.Employee_ID, GETDATE()) employeeInfo
        ) empl
        INNER JOIN (
            SELECT
                Request_ID,
                MAX(Approve_Date) AS MyApproveDate
            FROM HR_RequestLeave_History
            WHERE Approver_ID = @Emp
            GROUP BY Request_ID
        ) myHist
            ON elr.ID = myHist.Request_ID
        LEFT JOIN (
            SELECT
                Request_ID,
                Approver_Name,
                Approve_Date,
                ROW_NUMBER() OVER (PARTITION BY Request_ID ORDER BY Approve_Date DESC) AS rn
            FROM HR_RequestLeave_History
        ) rlh
            ON elr.ID = rlh.Request_ID
            AND rlh.rn = 1
        LEFT JOIN SmartBooks_LeaveType lt ON CAST(lt.LeaveType_ID AS varchar(50)) = elr.LeaveType_ID
        WHERE NOT (
                elr.TrangThai = 'Pending'
                AND EXISTS (
                    SELECT 1
                    FROM Split(elr.ApproveLevel, ',') currentLevel
                    WHERE currentLevel.[Data] = @Emp
                )
            )
            AND (elr.Fromdate BETWEEN @fromdate AND @todate OR elr.Todate BETWEEN @fromdate AND @todate)
        ORDER BY myHist.MyApproveDate DESC;
    END
END

GO
