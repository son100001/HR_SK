
CREATE   FUNCTION [dbo].[udf_TongHopCongEmployeeMobile_Web]
(
    @fromdate DATETIME,
    @todate DATETIME,
    @UserName NVARCHAR(50),
    @Emp NVARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        wt.Employee_ID,
        SUM(CASE WHEN (wt.MaCong = N'wt1' AND state.TrangThaiKH IN (0, 1))
                      OR (wt.MaCong = N'CN_wt1' AND state.TrangThaiKH IN (0, 2))
                 THEN wt.wt ELSE 0 END) AS wt1,
        SUM(CASE WHEN (wt.MaCong = N'wt3' AND state.TrangThaiKH IN (0, 1))
                      OR (wt.MaCong = N'CN_wt3' AND state.TrangThaiKH IN (0, 2))
                 THEN wt.wt ELSE 0 END) AS wt3,
        SUM(CASE WHEN (wt.MaCong = N'wt4' AND state.TrangThaiKH IN (0, 1))
                      OR (wt.MaCong = N'CN_wt4' AND state.TrangThaiKH IN (0, 2))
                 THEN wt.wt ELSE 0 END) AS wt4,
        SUM(CASE WHEN (wt.MaCong = N'wt5' AND state.TrangThaiKH IN (0, 1))
                      OR (wt.MaCong = N'CN_wt5' AND state.TrangThaiKH IN (0, 2))
                 THEN wt.wt ELSE 0 END) AS wt5,
        SUM(CASE WHEN (wt.MaCong = N'wt6' AND state.TrangThaiKH IN (0, 1))
                      OR (wt.MaCong = N'CN_wt6' AND state.TrangThaiKH IN (0, 2))
                 THEN wt.wt ELSE 0 END) AS wt6,
        SUM(CASE WHEN (wt.MaCong = N'wt7' AND state.TrangThaiKH IN (0, 1))
                      OR (wt.MaCong = N'CN_wt7' AND state.TrangThaiKH IN (0, 2))
                 THEN wt.wt ELSE 0 END) AS wt7,
        SUM(CASE WHEN (wt.MaCong = N'wt8' AND state.TrangThaiKH IN (0, 1))
                      OR (wt.MaCong = N'CN_wt8' AND state.TrangThaiKH IN (0, 2))
                 THEN wt.wt ELSE 0 END) AS wt8,
        SUM(CASE WHEN (wt.MaCong = N'wt9' AND state.TrangThaiKH IN (0, 1))
                      OR (wt.MaCong = N'CN_wt9' AND state.TrangThaiKH IN (0, 2))
                 THEN wt.wt ELSE 0 END) AS wt9
    FROM dbo.HR_WTDaily wt
    CROSS APPLY (SELECT dbo.udf_TrangThaiKH(@UserName) AS TrangThaiKH) state
    WHERE wt.Employee_ID = @Emp
        AND wt.Ngay BETWEEN @fromdate AND @todate
    GROUP BY wt.Employee_ID
);

GO
