
CREATE   PROCEDURE [dbo].[sp_BangCongEmployeeMobile_Web]
    @fromdate DATETIME,
    @todate DATETIME,
    @LAN NVARCHAR(50) = N'VN',
    @UserName NVARCHAR(50),
    @Emp NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TrangThaiKH INT = dbo.udf_TrangThaiKH(@UserName);
    DECLARE @NgayDauThang DATETIME = DATEFROMPARTS(YEAR(@fromdate), MONTH(@todate), 1);
    DECLARE @NgayCuoiThang DATETIME = EOMONTH(@NgayDauThang);
    DECLARE @Ngay15 DATETIME = DATEFROMPARTS(YEAR(@fromdate), MONTH(@todate), 15);
    DECLARE @NgayCongTieuChuan INT = dbo.udf_CountDayExceptSunday(@fromdate, @todate);
    DECLARE @PhepType INT = CASE WHEN @TrangThaiKH = 2 THEN 5 ELSE 1 END;

    DECLARE @ThcWt1 DECIMAL(18, 4) = 0;
    DECLARE @ThcWt3 DECIMAL(18, 4) = 0;
    DECLARE @ThcWt4 DECIMAL(18, 4) = 0;
    DECLARE @ThcWt5 DECIMAL(18, 4) = 0;
    DECLARE @ThcWt6 DECIMAL(18, 4) = 0;
    DECLARE @ThcWt7 DECIMAL(18, 4) = 0;
    DECLARE @ThcWt8 DECIMAL(18, 4) = 0;
    DECLARE @ThcWt9 DECIMAL(18, 4) = 0;
    DECLARE @PhepHuongLuong DECIMAL(18, 4) = 0;
    DECLARE @CongThucTeDiLam DECIMAL(18, 4) = 0;
    DECLARE @NghiKhongLuong DECIMAL(18, 4) = 0;
    DECLARE @PhepKhamThai DECIMAL(18, 4) = 0;
    DECLARE @PhepNamConLai DECIMAL(18, 4) = 0;
    DECLARE @TongGioCong DECIMAL(18, 4) = 0;
    DECLARE @TongNgayCongThucTe DECIMAL(18, 4) = 0;
    DECLARE @TongNgayCong DECIMAL(18, 4) = 0;
    DECLARE @PhepHuongLuongDays DECIMAL(18, 4) = 0;
    DECLARE @TienCC DECIMAL(18, 0) = 0;
    DECLARE @TienXX DECIMAL(18, 0) = 0;
    DECLARE @TienConNho DECIMAL(18, 0) = 0;
    DECLARE @PCFood DECIMAL(18, 0) = 0;
    DECLARE @TienDienThoai DECIMAL(18, 0) = 0;
    DECLARE @StartedDate DATETIME;
    DECLARE @isManager BIT = 0;
    DECLARE @HasMonthlyData BIT = 0;

    SELECT TOP (1)
        @StartedDate = empl.StartedDate,
        @isManager = ISNULL(empl.isManager, 0)
    FROM dbo.udf_EmployeeFilter(@LAN, NULL, NULL, NULL, NULL, NULL, NULL, @Emp, @todate) empl;

    SELECT
        @ThcWt1 = ISNULL(thc.wt1, 0),
        @ThcWt3 = ISNULL(thc.wt3, 0),
        @ThcWt4 = ISNULL(thc.wt4, 0),
        @ThcWt5 = ISNULL(thc.wt5, 0),
        @ThcWt6 = ISNULL(thc.wt6, 0),
        @ThcWt7 = ISNULL(thc.wt7, 0),
        @ThcWt8 = ISNULL(thc.wt8, 0),
        @ThcWt9 = ISNULL(thc.wt9, 0)
    FROM dbo.udf_TongHopCong(@fromdate, @todate, 1, @UserName) thc
    WHERE thc.Employee_ID = @Emp;

    SELECT
        @PhepHuongLuong = ISNULL(thp.PhepHuongLuong, 0),
        @CongThucTeDiLam = ISNULL(thp.CongThucTeDiLam, 0),
        @NghiKhongLuong = ISNULL(thp.NghiKhongLuong, 0),
        @PhepKhamThai = ISNULL(thp.PKT, 0)
    FROM dbo.udf_TongHopPhep(@fromdate, @todate, @PhepType) thp
    WHERE thp.Employee_ID = @Emp;

    SELECT @PhepNamConLai = ISNULL(qlpn.PhepNamConLai, 0)
    FROM dbo.udf_QuanLyPhepNam(YEAR(@fromdate), @todate, @LAN, NULL, NULL, NULL, NULL, NULL, NULL, @Emp) qlpn;

    SELECT @TienDienThoai = ISNULL(blcd.CD5, 0)
    FROM dbo.udf_BangLuongCoDinh(@todate, @Emp) blcd;

    SELECT @TienConNho = ISNULL(SUM(
        CASE
            WHEN DATEADD(YEAR, 1, BirthDate) BETWEEN @fromdate AND @todate AND DAY(BirthDate) < 15 THEN 1
            WHEN DATEADD(YEAR, 6, BirthDate) BETWEEN @fromdate AND @todate AND DAY(BirthDate) > 15 THEN 1
            WHEN DATEADD(YEAR, 6, BirthDate) >= @todate THEN 1
            ELSE 0
        END) * 100000, 0)
    FROM dbo.SmartBooks_Employee_Family
    WHERE Employee_ID = @Emp
        AND RelatedType = 6
        AND DATEADD(YEAR, 6, BirthDate) >= @fromdate
        AND DATEADD(YEAR, 1, BirthDate) <= @Ngay15;

    SET @TongGioCong = @ThcWt1 + @ThcWt9 + @PhepHuongLuong;
    SET @TongNgayCongThucTe = CASE WHEN @TrangThaiKH = 2 THEN 0 ELSE ROUND((@ThcWt1 + @ThcWt9) / 8.0 + @CongThucTeDiLam / 8.0, 2) END;
    SET @TongNgayCong = CASE WHEN @TrangThaiKH = 2 THEN 0 ELSE ROUND((@ThcWt1 + @ThcWt9 + @PhepHuongLuong) / 8.0, 2) END;
    SET @PhepHuongLuongDays = CASE WHEN @TrangThaiKH = 2 THEN 0 ELSE (@PhepHuongLuong - @CongThucTeDiLam) / 8.0 END;

    SET @TienCC = ISNULL(CASE
        WHEN @isManager = 1 THEN 0
        WHEN @StartedDate BETWEEN @NgayDauThang AND @NgayCuoiThang THEN ROUND(500000.0 / @NgayCongTieuChuan / 8.0 * @TongGioCong, -3)
        WHEN @TongGioCong + @PhepKhamThai >= @NgayCongTieuChuan * 8 - 4 THEN 500000
        ELSE 0
    END, 0);

    SET @TienXX = ISNULL(CASE
        WHEN @isManager = 1 THEN 0
        WHEN @StartedDate BETWEEN @NgayDauThang AND @NgayCuoiThang THEN ROUND(200000.0 / @NgayCongTieuChuan / 8.0 * @TongGioCong, -3)
        WHEN @TongGioCong >= 13 * 8 THEN 200000
        ELSE 0
    END, 0);

    IF @TongNgayCong >= 13
        SET @TienConNho = ISNULL(@TienConNho, 0);

    SET @HasMonthlyData = CASE
        WHEN @ThcWt1 + @ThcWt9 + @PhepHuongLuong > 0 THEN 1
        WHEN @TrangThaiKH = 2 AND @ThcWt3 + @ThcWt4 + @ThcWt5 + @ThcWt6 + @ThcWt7 + @ThcWt8 > 0 THEN 1
        ELSE 0
    END;

    IF @StartedDate IS NULL
        RETURN;

    IF @HasMonthlyData = 0
        RETURN;

    IF OBJECT_ID('tempdb..#DailyResult') IS NOT NULL
        DROP TABLE #DailyResult;

    CREATE TABLE #DailyResult
    (
        Ngay DATETIME NOT NULL PRIMARY KEY,
        RealTimeIn DATETIME NULL,
        RealTimeOut DATETIME NULL,
        wt1 DECIMAL(18, 4) NULL,
        wt2 DECIMAL(18, 4) NULL,
        wt3 DECIMAL(18, 4) NULL,
        wt4 DECIMAL(18, 4) NULL,
        wt5 DECIMAL(18, 4) NULL,
        wt6 DECIMAL(18, 4) NULL,
        wt7 DECIMAL(18, 4) NULL,
        wt8 DECIMAL(18, 4) NULL,
        wt9 DECIMAL(18, 4) NULL,
        wt10 DECIMAL(18, 4) NULL,
        wt11 DECIMAL(18, 4) NULL,
        sumTNC DECIMAL(18, 4) NULL,
        AbsentSign NVARCHAR(50) NULL,
        ShiftName NVARCHAR(50) NULL
    );

    ;WITH wtAgg AS
    (
        SELECT
            wt.Ngay,
            wt.MaCong,
            SUM(wt.wt) AS wt
        FROM dbo.HR_WTDaily wt
        WHERE wt.Employee_ID = @Emp
            AND wt.Ngay BETWEEN @fromdate AND @todate
        GROUP BY wt.Ngay, wt.MaCong
    ),
    wtPivot AS
    (
        SELECT
            p.Ngay,
            p.[wt1], p.[wt2], p.[wt3], p.[wt4], p.[wt5], p.[wt6], p.[wt7], p.[wt8], p.[wt9], p.[wt10], p.[wt11],
            p.[CN_wt3], p.[CN_wt4], p.[CN_wt5], p.[CN_wt6], p.[CN_wt7], p.[CN_wt8], p.[CN_wt10], p.[CN_wt11]
        FROM
        (
            SELECT Ngay, MaCong, wt
            FROM wtAgg
            WHERE (@TrangThaiKH = 2 AND MaCong LIKE N'CN_%')
                OR (@TrangThaiKH <> 2 AND (@TrangThaiKH = 0 OR MaCong NOT LIKE N'CN_%'))
        ) src
        PIVOT
        (
            SUM(wt)
            FOR MaCong IN (
                [wt1], [wt2], [wt3], [wt4], [wt5], [wt6], [wt7], [wt8], [wt9], [wt10], [wt11],
                [CN_wt3], [CN_wt4], [CN_wt5], [CN_wt6], [CN_wt7], [CN_wt8], [CN_wt10], [CN_wt11]
            )
        ) p
    )
    INSERT INTO #DailyResult
    (
        Ngay, RealTimeIn, RealTimeOut, wt1, wt2, wt3, wt4, wt5, wt6, wt7, wt8, wt9, wt10, wt11, sumTNC, AbsentSign, ShiftName
    )
    SELECT
        btg.Date_ AS Ngay,
        CASE WHEN @TrangThaiKH = 2 AND ISNULL(pv.[CN_wt3], 0) + ISNULL(pv.[CN_wt5], 0) = 0 THEN NULL
             WHEN @TrangThaiKH = 2 AND ISNULL(pv.[CN_wt3], 0) + ISNULL(pv.[CN_wt5], 0) > 0 AND tito.RealTimeIn < dbo.GhepGioVaoNgay(btg.Date_, sh.ToTime) THEN dbo.GhepGioVaoNgay(btg.Date_, sh.ToTime)
             WHEN @TrangThaiKH = 1 AND tito.RealTimeIn IS NOT NULL THEN tito.TimeIn_KH
             ELSE tito.RealTimeIn END AS RealTimeIn,
        CASE WHEN @TrangThaiKH = 2 AND ISNULL(pv.[CN_wt3], 0) + ISNULL(pv.[CN_wt5], 0) = 0 THEN NULL
             WHEN @TrangThaiKH = 1 AND tito.RealTimeOut IS NOT NULL THEN tito.TimeOut_KH
             ELSE tito.RealTimeOut END AS RealTimeOut,
        CASE WHEN @TrangThaiKH = 2 THEN NULL
             ELSE ISNULL(pv.[wt1], 0) + CASE
                 WHEN ISNULL(bpdn.LeaveType_ID, 0) IN (52, 60) AND ISNULL(pv.[wt1], 0) + ISNULL(bpdn.HourLeave, 0) > 8 THEN 18 - ISNULL(pv.[wt1], 0)
                 WHEN ISNULL(bpdn.LeaveType_ID, 0) IN (52, 60) AND ISNULL(pv.[wt1], 0) + ISNULL(bpdn.HourLeave, 0) <= 8 THEN ISNULL(bpdn.HourLeave, 0)
                 ELSE 0
             END END AS wt1,
        CASE WHEN @TrangThaiKH = 2 THEN NULL ELSE pv.[wt2] END AS wt2,
        CASE WHEN @TrangThaiKH = 2 THEN pv.[CN_wt3]
             WHEN ISNULL(pv.[wt3], 0) + ISNULL(pv.[CN_wt3], 0) = 0 THEN NULL
             ELSE ISNULL(pv.[wt3], 0) + ISNULL(pv.[CN_wt3], 0) END AS wt3,
        CASE WHEN @TrangThaiKH = 2 THEN pv.[CN_wt4]
             WHEN @TrangThaiKH = 1 THEN NULL
             WHEN ISNULL(pv.[wt4], 0) + ISNULL(pv.[CN_wt4], 0) = 0 THEN NULL
             ELSE ISNULL(pv.[wt4], 0) + ISNULL(pv.[CN_wt4], 0) END AS wt4,
        CASE WHEN @TrangThaiKH = 2 THEN pv.[CN_wt5]
             WHEN ISNULL(pv.[wt5], 0) + ISNULL(pv.[CN_wt5], 0) = 0 THEN NULL
             ELSE ISNULL(pv.[wt5], 0) + ISNULL(pv.[CN_wt5], 0) END AS wt5,
        CASE WHEN @TrangThaiKH = 2 THEN pv.[CN_wt6]
             WHEN @TrangThaiKH = 1 THEN NULL
             WHEN ISNULL(pv.[wt6], 0) + ISNULL(pv.[CN_wt6], 0) = 0 THEN NULL
             ELSE ISNULL(pv.[wt6], 0) + ISNULL(pv.[CN_wt6], 0) END AS wt6,
        CASE WHEN @TrangThaiKH = 2 THEN pv.[CN_wt7]
             WHEN @TrangThaiKH = 1 THEN NULL
             WHEN ISNULL(pv.[wt7], 0) + ISNULL(pv.[CN_wt7], 0) = 0 THEN NULL
             ELSE ISNULL(pv.[wt7], 0) + ISNULL(pv.[CN_wt7], 0) END AS wt7,
        CASE WHEN @TrangThaiKH = 2 THEN pv.[CN_wt8]
             WHEN @TrangThaiKH = 1 THEN NULL
             WHEN ISNULL(pv.[wt8], 0) + ISNULL(pv.[CN_wt8], 0) = 0 THEN NULL
             ELSE ISNULL(pv.[wt8], 0) + ISNULL(pv.[CN_wt8], 0) END AS wt8,
        CASE WHEN @TrangThaiKH = 2 THEN 0 ELSE ISNULL(pv.[wt9], 0) END AS wt9,
        CASE WHEN @TrangThaiKH = 2 THEN pv.[CN_wt10]
             WHEN ISNULL(pv.[wt10], 0) + ISNULL(pv.[CN_wt10], 0) = 0 THEN NULL
             ELSE ISNULL(pv.[wt10], 0) + ISNULL(pv.[CN_wt10], 0) END AS wt10,
        CASE WHEN @TrangThaiKH = 2 THEN pv.[CN_wt11]
             WHEN ISNULL(pv.[wt11], 0) + ISNULL(pv.[CN_wt11], 0) = 0 THEN NULL
             ELSE ISNULL(pv.[wt11], 0) + ISNULL(pv.[CN_wt11], 0) END AS wt11,
        CASE
            WHEN ISNULL(lt.isleave_compay, 0) = 1 THEN (ISNULL(pv.[wt1], 0) + ISNULL(pv.[wt2], 0) + ISNULL(bpdn.HourLeave, 0)) / 8.0
            ELSE (ISNULL(pv.[wt1], 0) + ISNULL(pv.[wt2], 0)) / 8.0
        END AS sumTNC,
        CASE WHEN @TrangThaiKH = 2 THEN NULL ELSE lt.AbsentSign END AS AbsentSign,
        CASE
            WHEN sh.FromTime IS NOT NULL AND sh.ToTime IS NOT NULL THEN
                CASE
                    WHEN ISNULL(sh.ShiftSign, N'') <> N'' AND sh.ShiftSign <> tito.ShiftName THEN sh.ShiftSign + N' ('
                    ELSE ISNULL(sh.ShiftSign, ISNULL(tito.ShiftName, N'')) + N' ('
                END +
                SUBSTRING(CONVERT(varchar(10), CAST(sh.FromTime AS time), 108), 1, 5) + N' - ' +
                SUBSTRING(CONVERT(varchar(10), CAST(sh.ToTime AS time), 108), 1, 5) + N')'
            WHEN ISNULL(sh.ShiftSign, N'') <> N'' THEN sh.ShiftSign
            ELSE tito.ShiftName
        END AS ShiftName
    FROM dbo.udf_BangThoiGian(@fromdate, @todate) btg
    LEFT JOIN wtPivot pv ON pv.Ngay = btg.Date_
    LEFT JOIN dbo.HR_TimeIn_TimeOut tito ON tito.Employee_ID = @Emp AND tito.OT_date = btg.Date_
    LEFT JOIN dbo.HR_BangPhepDaNghi bpdn ON bpdn.Employee_ID = @Emp AND bpdn.DateLeave = btg.Date_
    LEFT JOIN dbo.SmartBooks_LeaveType lt ON lt.LeaveType_ID = bpdn.LeaveType_ID
    LEFT JOIN dbo.HR_Shifts sh ON (tito.ShiftName = sh.ShiftName OR tito.ShiftName = sh.ShiftSign)
    WHERE @StartedDate <= @todate
        AND btg.Date_ >= @StartedDate
        AND ((@TrangThaiKH = 1 AND DATENAME(dw, btg.Date_) <> N'Sunday') OR @TrangThaiKH IN (0, 2));

    -- RS1 Summary (BE ghep Format / DecimalPlaces)
    SELECT
        v.SortOrder,
        v.FieldKey,
        CASE WHEN @LAN = N'EN' THEN v.LabelEN ELSE v.LabelVN END AS Label,
        v.Value
    FROM
    (
        SELECT 1 AS SortOrder, N'TongNgayCongThucTe' AS FieldKey, N'Ngày làm việc thực tế' AS LabelVN, N'Actual working days' AS LabelEN,
            @TongNgayCongThucTe AS Value
        UNION ALL
        SELECT 2, N'PhepHuongLuong', N'Ngày nghỉ có hưởng lương', N'Paid leave days', @PhepHuongLuongDays
        UNION ALL
        SELECT 3, N'PhepNamConLai', N'Phép năm tồn', N'Annual leave remain', @PhepNamConLai
        UNION ALL
        SELECT 4, N'TienXX', N'Hỗ trợ xăng + nhà trọ', N'Fuel + housing allowance', @TienXX
        UNION ALL
        SELECT 5, N'TienCC', N'Chuyên cần', N'Attendance bonus', @TienCC
        UNION ALL
        SELECT 6, N'PCFood', N'Tiền cơm', N'Meal allowance', @PCFood
        UNION ALL
        SELECT 7, N'TienConNho', N'Con nhỏ', N'Child allowance', @TienConNho
        UNION ALL
        SELECT 8, N'TienDienThoai', N'Điện thoại', N'Phone allowance', @TienDienThoai
    ) v
    ORDER BY v.SortOrder;

    -- RS2 Daily
    SELECT
        Ngay, RealTimeIn, RealTimeOut,
        wt1, wt2, wt3, wt4, wt5, wt6, wt7, wt8, wt9, wt10, wt11,
        sumTNC, AbsentSign, ShiftName
    FROM #DailyResult
    ORDER BY Ngay;

    -- RS3 DailyTotals
    SELECT
        CASE WHEN @LAN = N'EN' THEN N'Total' ELSE N'Tổng' END AS Label,
        SUM(ISNULL(wt1, 0)) AS wt1,
        SUM(ISNULL(wt2, 0)) AS wt2,
        SUM(ISNULL(wt3, 0)) AS wt3,
        SUM(ISNULL(wt4, 0)) AS wt4,
        SUM(ISNULL(wt5, 0)) AS wt5,
        SUM(ISNULL(wt6, 0)) AS wt6,
        SUM(ISNULL(wt7, 0)) AS wt7,
        SUM(ISNULL(wt8, 0)) AS wt8,
        SUM(ISNULL(wt9, 0)) AS wt9,
        SUM(ISNULL(wt10, 0)) AS wt10,
        SUM(ISNULL(wt11, 0)) AS wt11,
        SUM(ISNULL(sumTNC, 0)) AS sumTNC
    FROM #DailyResult;

    DROP TABLE #DailyResult;
END

GO
