
CREATE   FUNCTION [dbo].[udf_TongHopPhepEmployeeMobile_Web]
(
    @fromdate DATETIME,
    @todate DATETIME,
    @TypeOfReport INT,
    @Emp NVARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        bpdn.Employee_ID,
        SUM(CASE WHEN ISNULL(lt.isLeave_ComPay, 0) = 1 THEN bpdn.HourLeave ELSE 0 END) AS PhepHuongLuong,
        SUM(CASE WHEN lt.LeaveType_ID IN (N'52') THEN bpdn.HourLeave ELSE 0 END) AS CongThucTeDiLam
    FROM dbo.HR_BangPhepDaNghi bpdn
    LEFT JOIN dbo.SmartBooks_LeaveType lt ON bpdn.LeaveType_ID = lt.LeaveType_ID
    WHERE @TypeOfReport = 1
        AND bpdn.Employee_ID = @Emp
        AND bpdn.DateLeave BETWEEN @fromdate AND @todate
    GROUP BY bpdn.Employee_ID
);

GO
