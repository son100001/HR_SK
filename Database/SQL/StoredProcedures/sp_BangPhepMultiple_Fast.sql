
CREATE   PROCEDURE [dbo].[sp_BangPhepMultiple_Fast]
(
	@fromdate DATETIME,
	@todate DATETIME,
	@TypeOfReport INT = 10,
	@LAN NVARCHAR(50) = 'VN',
	@fact NVARCHAR(50) = NULL,
	@dept NVARCHAR(50) = NULL,
	@sect NVARCHAR(50) = NULL,
	@team NVARCHAR(50) = NULL,
	@pos NVARCHAR(50) = NULL,
	@posc NVARCHAR(50) = NULL,
	@Emp NVARCHAR(50) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	/* =============================================================
	   1️⃣  Nếu chỉ lọc theo 1 nhân viên → chạy nhanh theo Employee_ID
	=============================================================*/
	IF @Emp IS NOT NULL AND @TypeOfReport IN (10, 11)
	BEGIN
		SELECT 
			elr.TrangThai,
			elr.LeaveType_ID,
			elr.FromDate,
			elr.ToDate,
			ROUND(
				CASE 
					WHEN elr.LeaveType_ID IN ('49','24') 
						THEN dbo.udf_CountWorkingDayWithSun(elr.FromDate, elr.ToDate)
					ELSE dbo.udf_CountWorkingDay(elr.FromDate, elr.ToDate) / 
						(CASE WHEN elr.LeaveType_ID IN ('31','32') THEN 2.0 ELSE 1 END)
				END, 2
			) AS NumberOfDate,
			ISNULL(elr.HourLeave, 8) * 
				(CASE 
					WHEN elr.LeaveType_ID IN ('49','24') 
						THEN dbo.udf_CountWorkingDayWithSun(elr.FromDate, elr.ToDate)
					ELSE dbo.udf_CountWorkingDay(elr.FromDate, elr.ToDate) / 
						(CASE WHEN elr.LeaveType_ID IN ('31','32') THEN 2.0 ELSE 1 END)
				END) AS HourLeave,
			elr.isChoUngPhep,
			elr.ID,
			elr.InsertDate,
			elr.UserName,
			elr.ApproverName,
			elr.ApproveLevel,
			elr.ImageBinary,
			elr.ImageFileName,
			elr.ImageFileType,
			elr.ImageFileSize
		FROM dbo.HR_EmployeeLeaveRequests elr WITH (NOLOCK)
		WHERE elr.Employee_ID = @Emp
		  AND elr.FromDate BETWEEN @fromdate AND @todate
		  AND elr.LeaveType_ID <> '14'
		ORDER BY elr.FromDate DESC;
		RETURN;
	END;

	/* =============================================================
	   2️⃣  Danh sách chờ duyệt / từ chối (TypeOfReport = 10 hoặc 11)
	=============================================================*/
	IF @TypeOfReport IN (10, 11)
	BEGIN
		;WITH Empl AS (
			SELECT 
				Employee_ID, 
				DepartmentName, 
				PositionFullName,
				dbo.udf_FullName(Employee_FirstName, Employee_LastName) AS FullName
			FROM dbo.udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate)
		)
		SELECT 
			ISNULL(elr.TrangThai, 'Approved') AS TrangThai,
			ISNULL(elr.LeaveType_ID, ml.LeaveType_ID) AS LeaveType_ID,
			ISNULL(elr.FromDate, ml.FromDate) AS FromDate,
			ISNULL(elr.ToDate, ml.ToDate) AS ToDate,
			ROUND(
				CASE 
					WHEN ISNULL(elr.LeaveType_ID, ml.LeaveType_ID) IN ('49','24')
						THEN dbo.udf_CountWorkingDayWithSun(ISNULL(elr.FromDate, ml.FromDate), ISNULL(elr.ToDate, ml.ToDate))
					ELSE dbo.udf_CountWorkingDay(ISNULL(elr.FromDate, ml.FromDate), ISNULL(elr.ToDate, ml.ToDate)) / 
						(CASE WHEN ISNULL(elr.LeaveType_ID, ml.LeaveType_ID) IN ('31','32') THEN 2.0 ELSE 1 END)
				END, 2
			) AS NumberOfDate,
			ISNULL(elr.HourLeave, 8) *
				(CASE 
					WHEN ISNULL(elr.LeaveType_ID, ml.LeaveType_ID) IN ('49','24')
						THEN dbo.udf_CountWorkingDayWithSun(ISNULL(elr.FromDate, ml.FromDate), ISNULL(elr.ToDate, ml.ToDate))
					ELSE dbo.udf_CountWorkingDay(ISNULL(elr.FromDate, ml.FromDate), ISNULL(elr.ToDate, ml.ToDate)) / 
						(CASE WHEN ISNULL(elr.LeaveType_ID, ml.LeaveType_ID) IN ('31','32') THEN 2.0 ELSE 1 END)
				END) AS HourLeave,
			elr.isChoUngPhep,
			elr.ID,
			elr.InsertDate,
			elr.UserName,
			elr.ApproverName,
			elr.ApproveLevel,
			elr.ImageBinary,
			elr.ImageFileName,
			elr.ImageFileType,
			elr.ImageFileSize,
			empl.Employee_ID,
			empl.FullName,
			empl.DepartmentName,
			empl.PositionFullName
		FROM Empl
		LEFT JOIN dbo.HR_EmployeeLeaveRequests elr WITH (NOLOCK)
			ON elr.Employee_ID = Empl.Employee_ID 
			AND elr.FromDate BETWEEN @fromdate AND @todate
			AND elr.TrangThai IN ('Pending','Rejected')
			AND elr.LeaveType_ID <> '14'
		LEFT JOIN dbo.HR_EmployeeRegisMaternityLeave ml WITH (NOLOCK)
			ON ml.Employee_ID = empl.Employee_ID 
			AND (ml.FromDate BETWEEN @fromdate AND @todate OR ml.ToDate BETWEEN @fromdate AND @todate)
		ORDER BY FromDate DESC;
		RETURN;
	END;

	/* =============================================================
	   3️⃣  Danh sách cần duyệt (TypeOfReport = 12)
	=============================================================*/
	IF @TypeOfReport = 12
	BEGIN
		SELECT elr.Employee_ID, elr.LeaveType_ID, elr.TrangThai,
			   elr.FromDate, elr.ToDate, elr.InsertDate,
			   rlh.Approver_Name AS LastApprover,
			   rlh.Approve_Date AS ApproveDate
		FROM HR_EmployeeLeaveRequests elr
		LEFT JOIN (
			SELECT Request_ID, Approver_Name, Approve_Date,
			       ROW_NUMBER() OVER (PARTITION BY Request_ID ORDER BY Approve_Date DESC) rn
			FROM HR_RequestLeave_History
		) rlh ON elr.ID = rlh.Request_ID AND rlh.rn = 1
		WHERE elr.ApproveLevel = @Emp
		  AND elr.TrangThai = 'Pending'
		  AND (elr.FromDate BETWEEN @fromdate AND @todate OR elr.ToDate BETWEEN @fromdate AND @todate)
		ORDER BY elr.FromDate;
		RETURN;
	END;
END

GO
