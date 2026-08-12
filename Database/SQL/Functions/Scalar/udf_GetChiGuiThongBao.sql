CREATE FUNCTION dbo.udf_GetChiGuiThongBao
(
    @Account NVARCHAR(50),
    @LAN NVARCHAR(50) = 'VN',
    @Date DATETIME = NULL
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Result NVARCHAR(MAX) = N'';

    IF @Date IS NULL SET @Date = GETDATE();

    DECLARE @ShiftName NVARCHAR(50);
    SELECT @ShiftName = ShiftName 
    FROM udf_DangKyCa(@Date,@Date,181,NULL,NULL,NULL,NULL,NULL,NULL,NULL);

    -- Nếu ca không phải shift3 thì mới xét phê duyệt
    IF (@ShiftName NOT LIKE N'%shift3')
    BEGIN
        ;WITH EmployeeFilter AS (
            SELECT Employee_ID, dbo.udf_FullName(Employee_Firstname,Employee_LastName) AS FullName,
                   Factory_ID, DepartmentCode, Position, PositionCategory_ID, ChucDanh, LvDuyet, DepartmentCode1
            FROM udf_EmployeeFilter(@LAN,NULL,NULL,NULL,NULL,NULL,NULL,NULL,@Date)
            WHERE Employee_ID NOT IN ('BOD01','BOD02')
            UNION ALL
            SELECT 'BOD02','Kim Jemin',NULL,NULL,NULL,NULL,'Director',1,NULL
            UNION ALL
            SELECT 'BOD01','Kim Dong Woo',NULL,NULL,NULL,NULL,'General Director',0,NULL
        )
        , BaseCTE AS (
            SELECT empl.Employee_ID,
                   ld.ThuTuDuyet,
                   ISNULL(ld.ChiGuiThongBao,0) AS ChiGuiThongBao,
                   ISNULL(emplCap5.Employee_ID, ISNULL(emplCap4.Employee_ID, ISNULL(emplCap3.Employee_ID,ISNULL(emplCap2.Employee_ID,ISNULL(emplCap1.Employee_ID,emplCap0.Employee_ID))))) AS Approver
            FROM [User] us
            LEFT JOIN EmployeeFilter empl ON us.Employee_ID = empl.Employee_ID
            LEFT JOIN HR_LuongDuyet ld ON empl.LvDuyet = ld.LuongDuyet
            LEFT JOIN EmployeeFilter emplCap5 ON ld.CapBacDuyet = emplCap5.LvDuyet AND emplCap5.LvDuyet=5
            LEFT JOIN EmployeeFilter emplCap4 ON ld.CapBacDuyet = emplCap4.LvDuyet AND emplCap4.LvDuyet=4
            LEFT JOIN EmployeeFilter emplCap3 ON ld.CapBacDuyet = emplCap3.LvDuyet AND emplCap3.LvDuyet=3
            LEFT JOIN EmployeeFilter emplCap2 ON ld.CapBacDuyet = emplCap2.LvDuyet AND emplCap2.LvDuyet=2
            LEFT JOIN EmployeeFilter emplCap1 ON ld.CapBacDuyet = emplCap1.LvDuyet AND emplCap1.LvDuyet=1
            LEFT JOIN EmployeeFilter emplCap0 ON ld.CapBacDuyet = emplCap0.LvDuyet AND emplCap0.LvDuyet=0
            WHERE us.UserName = @Account
        )
        SELECT @Result = STRING_AGG(Approver, ',')
        FROM BaseCTE
        WHERE ChiGuiThongBao = 1 AND Approver IS NOT NULL;
    END
    ELSE
    BEGIN
        -- Nếu ca đêm → trả về Guard
        SET @Result = 
            CASE @LAN 
                WHEN N'VN' THEN N'Bảo vệ'
                WHEN N'EN' THEN 'Guard'
                WHEN N'KR' THEN N'경비원'
                WHEN N'JP' THEN N'警備員'
                WHEN N'CN' THEN N'保安'
                WHEN N'KH' THEN N'បាវេ'
            END;
    END

    RETURN @Result;
END
GO
