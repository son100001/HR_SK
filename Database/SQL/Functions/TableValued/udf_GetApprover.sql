CREATE FUNCTION dbo.udf_GetApprover
(
    @Account NVARCHAR(50),
    @TypeOfReport INT,
    @LAN NVARCHAR(50) = 'VN',
    @Date DATETIME = NULL
)
--select * from udf_GetApprover (Null,1,'EN',GETDATE())
RETURNS @Result TABLE
(
    Factory_ID NVARCHAR(50),
    DepartmentCode NVARCHAR(50),
    Position NVARCHAR(50),
    PositionCategory_ID NVARCHAR(50),
    ChucDanh NVARCHAR(50),
    Employee_ID NVARCHAR(50),
    Code NVARCHAR(MAX),
    [Name] NVARCHAR(MAX),
    ChiGuiThongBao NVARCHAR(MAX)
)
AS
BEGIN
    IF @Date IS NULL SET @Date = GETDATE();

    DECLARE @ShiftName NVARCHAR(50);
    SELECT @ShiftName = ShiftName 
    FROM udf_DangKyCa(@Date,@Date,181,NULL,NULL,NULL,NULL,NULL,NULL,NULL);

    -- Nếu không phải shift3
    IF (@ShiftName NOT LIKE N'%shift3')
    BEGIN
        DECLARE @EmployeeFilter TABLE (
            Employee_ID NVARCHAR(50) PRIMARY KEY,
            FullName NVARCHAR(100),
            Factory_ID NVARCHAR(50),
            DepartmentCode NVARCHAR(50),
            Position NVARCHAR(50),
            PositionCategory_ID NVARCHAR(50),
            ChucDanh NVARCHAR(50),
            LvDuyet NVARCHAR(50),
            DepartmentCode1 NVARCHAR(100)
        );

        INSERT INTO @EmployeeFilter
        SELECT Employee_ID, dbo.udf_FullName(Employee_Firstname,Employee_LastName), Factory_ID, DepartmentCode, Position, PositionCategory_ID, ChucDanh, LvDuyet, DepartmentCode1
        FROM udf_EmployeeFilter(@LAN,NULL,NULL,NULL,NULL,NULL,NULL,NULL,@Date)
        WHERE Employee_ID NOT IN ('BOD01','BOD02') and isnull(TernimationDate,@Date) >= @Date;

        INSERT INTO @EmployeeFilter (Employee_ID, FullName, Factory_ID, DepartmentCode, Position, PositionCategory_ID, ChucDanh, LvDuyet)
        VALUES ('BOD02','Kim Jemin',NULL,NULL,NULL,NULL,'Director',1);

        INSERT INTO @EmployeeFilter (Employee_ID, FullName, Factory_ID, DepartmentCode, Position, PositionCategory_ID, ChucDanh, LvDuyet)
        VALUES ('BOD01','Kim Dong Woo',NULL,NULL,NULL,NULL,'General Director',0);

        ;WITH BaseCTE AS (
            SELECT empl.Employee_ID, empl.Factory_ID, empl.DepartmentCode, empl.Position, empl.PositionCategory_ID, empl.ChucDanh, empl.LvDuyet,
                   ld.ThuTuDuyet, 
                   ISNULL(ld.ChiGuiThongBao,0) AS ChiGuiThongBao,
                   ISNULL(emplCap5.Employee_ID, ISNULL(emplCap4.Employee_ID, ISNULL(emplCap3.Employee_ID,ISNULL(emplCap2.Employee_ID,ISNULL(emplCap1.Employee_ID,emplCap0.Employee_ID))))) AS Approver,
                   ISNULL(emplCap5.FullName, ISNULL(emplCap4.FullName, ISNULL(emplCap3.FullName,ISNULL(emplCap2.FullName,ISNULL(emplCap1.FullName,emplCap0.FullName))))) AS FullNameApprover
            FROM [User] us
            LEFT JOIN @EmployeeFilter empl ON us.Employee_ID = empl.Employee_ID
            LEFT JOIN HR_LuongDuyet ld ON empl.LvDuyet = ld.LuongDuyet
            LEFT JOIN @EmployeeFilter emplCap5 ON ld.CapBacDuyet = emplCap5.LvDuyet 
                AND LEFT(empl.DepartmentCode1,5) = LEFT(emplCap5.DepartmentCode1,5) 
                AND emplCap5.LvDuyet = 5
            LEFT JOIN @EmployeeFilter emplCap4 ON ld.CapBacDuyet = emplCap4.LvDuyet 
                AND LEFT(empl.DepartmentCode1, CASE WHEN empl.LvDuyet=6 THEN 5 ELSE 2 END) = LEFT(emplCap4.DepartmentCode1,CASE WHEN empl.LvDuyet=6 THEN 5 ELSE 2 END) 
                AND emplCap4.LvDuyet = 4
            LEFT JOIN @EmployeeFilter emplCap3 ON ld.CapBacDuyet = emplCap3.LvDuyet 
                AND (CASE WHEN empl.Factory_ID<>'SK2' THEN 'SK1' ELSE empl.Factory_ID END) = (CASE WHEN emplCap3.Factory_ID<>'SK2' THEN 'SK1' ELSE emplCap3.Factory_ID END)
                AND emplCap3.LvDuyet=3 
                AND emplCap3.Employee_ID IN ('C14908','C10537')
            LEFT JOIN @EmployeeFilter emplCap2 ON ld.CapBacDuyet=emplCap2.LvDuyet AND emplCap2.LvDuyet=2
            LEFT JOIN @EmployeeFilter emplCap1 ON ld.CapBacDuyet=emplCap1.LvDuyet AND emplCap1.LvDuyet=1
            LEFT JOIN @EmployeeFilter emplCap0 ON ld.CapBacDuyet=emplCap0.LvDuyet AND emplCap0.LvDuyet=0
            WHERE case when @Account is null then '' else us.UserName end = case when @Account is null then '' else @Account end
        )
        , D AS (
            SELECT Employee_ID, Factory_ID, DepartmentCode, Position, PositionCategory_ID, ChucDanh,
                   ThuTuDuyet, Approver, FullNameApprover, ChiGuiThongBao
            FROM BaseCTE
        )
        INSERT INTO @Result
        SELECT 
            D1.Factory_ID, D1.DepartmentCode, D1.Position, D1.PositionCategory_ID, D1.ChucDanh, D1.Employee_ID,
            D1.Approver + 
                (CASE WHEN D2.Approver IS NOT NULL AND D2.ChiGuiThongBao=0 THEN ','+D2.Approver ELSE '' END) +
                (CASE WHEN D3.Approver IS NOT NULL AND D3.ChiGuiThongBao=0 THEN ','+D3.Approver ELSE '' END) +
                (CASE WHEN D4.Approver IS NOT NULL AND D4.ChiGuiThongBao=0 THEN ','+D4.Approver ELSE '' END) +
                (CASE WHEN D5.Approver IS NOT NULL AND D5.ChiGuiThongBao=0 THEN ','+D5.Approver ELSE '' END) AS Code,
            D1.FullNameApprover + 
                (CASE WHEN D2.FullNameApprover IS NOT NULL AND D2.ChiGuiThongBao=0 THEN ', '+D2.FullNameApprover ELSE '' END) +
                (CASE WHEN D3.FullNameApprover IS NOT NULL AND D3.ChiGuiThongBao=0 THEN ', '+D3.FullNameApprover ELSE '' END) +
                (CASE WHEN D4.FullNameApprover IS NOT NULL AND D4.ChiGuiThongBao=0 THEN ', '+D4.FullNameApprover ELSE '' END) +
                (CASE WHEN D5.FullNameApprover IS NOT NULL AND D5.ChiGuiThongBao=0 THEN ', '+D5.FullNameApprover ELSE '' END) AS [Name],
            (CASE WHEN D1.Approver IS NOT NULL AND D1.ChiGuiThongBao=1 THEN ','+D1.Approver ELSE '' END) +
            (CASE WHEN D2.Approver IS NOT NULL AND D2.ChiGuiThongBao=1 THEN ','+D2.Approver ELSE '' END) +
            (CASE WHEN D3.Approver IS NOT NULL AND D3.ChiGuiThongBao=1 THEN ','+D3.Approver ELSE '' END) +
            (CASE WHEN D4.Approver IS NOT NULL AND D4.ChiGuiThongBao=1 THEN ','+D4.Approver ELSE '' END) +
            (CASE WHEN D5.Approver IS NOT NULL AND D5.ChiGuiThongBao=1 THEN ','+D5.Approver ELSE '' END) AS ChiGuiThongBao
        FROM D D1
        LEFT JOIN D D2 ON D1.Employee_ID=D2.Employee_ID AND D2.ThuTuDuyet=2
        LEFT JOIN D D3 ON D1.Employee_ID=D3.Employee_ID AND D3.ThuTuDuyet=3
        LEFT JOIN D D4 ON D1.Employee_ID=D4.Employee_ID AND D4.ThuTuDuyet=4
        LEFT JOIN D D5 ON D1.Employee_ID=D5.Employee_ID AND D5.ThuTuDuyet=5
        WHERE D1.ThuTuDuyet=1 and D1.Approver is not null;
    END
    ELSE
    BEGIN
        INSERT INTO @Result
        SELECT NULL,NULL,NULL,NULL,NULL,NULL,
               N'BV',
               CASE @LAN 
                    WHEN N'VN' THEN N'Bảo vệ'
                    WHEN N'EN' THEN 'Guard'
                    WHEN N'KR' THEN N'경비원'
                    WHEN N'JP' THEN N'警備員'
                    WHEN N'CN' THEN N'保安'
                    WHEN N'KH' THEN N'បាវេ'
               END,
               NULL;
    END

    RETURN;
END
GO
