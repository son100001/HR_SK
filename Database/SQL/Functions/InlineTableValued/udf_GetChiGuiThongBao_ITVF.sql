CREATE FUNCTION dbo.udf_GetChiGuiThongBao_ITVF
(
    @Account NVARCHAR(50),
    @LAN NVARCHAR(50) = 'VN',
    @Date DATETIME = NULL
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        CASE 
            WHEN dkca.ShiftName NOT LIKE N'%shift3' 
            THEN (
                SELECT STRING_AGG(b.Approver, ',')
                FROM (
                    SELECT DISTINCT Approver
                    FROM (
                        SELECT ISNULL(emplCap5.Employee_ID, ISNULL(emplCap4.Employee_ID, ISNULL(emplCap3.Employee_ID,
                               ISNULL(emplCap2.Employee_ID, ISNULL(emplCap1.Employee_ID,emplCap0.Employee_ID))))) AS Approver,
                               ISNULL(ld.ChiGuiThongBao,0) AS ChiGuiThongBao
                        FROM [User] us
                        JOIN udf_EmployeeFilter(@LAN,NULL,NULL,NULL,NULL,NULL,NULL,NULL,ISNULL(@Date,GETDATE())) empl
                             ON us.Employee_ID = empl.Employee_ID
                        LEFT JOIN HR_LuongDuyet ld ON empl.LvDuyet = ld.LuongDuyet
                        LEFT JOIN udf_EmployeeFilter(@LAN,NULL,NULL,NULL,NULL,NULL,NULL,NULL,ISNULL(@Date,GETDATE())) emplCap5 ON ld.CapBacDuyet=emplCap5.LvDuyet AND emplCap5.LvDuyet=5
                        LEFT JOIN udf_EmployeeFilter(@LAN,NULL,NULL,NULL,NULL,NULL,NULL,NULL,ISNULL(@Date,GETDATE())) emplCap4 ON ld.CapBacDuyet=emplCap4.LvDuyet AND emplCap4.LvDuyet=4
                        LEFT JOIN udf_EmployeeFilter(@LAN,NULL,NULL,NULL,NULL,NULL,NULL,NULL,ISNULL(@Date,GETDATE())) emplCap3 ON ld.CapBacDuyet=emplCap3.LvDuyet AND emplCap3.LvDuyet=3
                        LEFT JOIN udf_EmployeeFilter(@LAN,NULL,NULL,NULL,NULL,NULL,NULL,NULL,ISNULL(@Date,GETDATE())) emplCap2 ON ld.CapBacDuyet=emplCap2.LvDuyet AND emplCap2.LvDuyet=2
                        LEFT JOIN udf_EmployeeFilter(@LAN,NULL,NULL,NULL,NULL,NULL,NULL,NULL,ISNULL(@Date,GETDATE())) emplCap1 ON ld.CapBacDuyet=emplCap1.LvDuyet AND emplCap1.LvDuyet=1
                        LEFT JOIN udf_EmployeeFilter(@LAN,NULL,NULL,NULL,NULL,NULL,NULL,NULL,ISNULL(@Date,GETDATE())) emplCap0 ON ld.CapBacDuyet=emplCap0.LvDuyet AND emplCap0.LvDuyet=0
                        WHERE us.UserName = @Account
                    ) x
                    WHERE ChiGuiThongBao = 1 AND Approver IS NOT NULL
                ) b
            )
            ELSE (
                CASE @LAN 
                    WHEN N'VN' THEN N'Bảo vệ'
                    WHEN N'EN' THEN 'Guard'
                    WHEN N'KR' THEN N'경비원'
                    WHEN N'JP' THEN N'警備員'
                    WHEN N'CN' THEN N'保安'
                    WHEN N'KH' THEN N'បាវេ'
                END
            )
        END AS ChiGuiThongBao
    FROM udf_DangKyCa(ISNULL(@Date,GETDATE()),ISNULL(@Date,GETDATE()),181,NULL,NULL,NULL,NULL,NULL,NULL,NULL) dkca
);
GO
