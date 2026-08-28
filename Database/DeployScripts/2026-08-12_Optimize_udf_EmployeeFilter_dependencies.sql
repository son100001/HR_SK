/*
    Mục đích: Tối ưu hiệu năng 2 dependency của dbo.udf_EmployeeFilter (không sửa udf_EmployeeFilter).
    Áp dụng cho: HR_SnK_Dev_260811 (và các DB khác cùng hệ thống POCONS/SmartBooks HR có cùng triệu chứng).
    Tham khảo: markdowns/SQL_PERFORMANCE_PLAYBOOK.md mục A1 + A2, markdowns/SQL_PERFORMANCE_HISTORY.md.
    Idempotent: chạy lại nhiều lần không lỗi, không đổi dữ liệu, chỉ đổi định nghĩa function + thêm index.

    1) dbo.Split: multi-statement TVF (WHILE loop) -> inline TVF (XML nodes()).
       Giữ nguyên tên hàm/tham số/tên cột kết quả (Data)/hành vi trim + token rỗng
       -> tương thích ngược 100% với toàn bộ caller hiện có (35 object đã xác nhận gọi Split
       trong HR_SnK_Dev_260811 ngày 2026-08-12), không cần sửa bất kỳ caller nào.

    2) dbo.SmartBooks_Employee: thêm index hỗ trợ tra cứu theo ID_number (CMND/CCCD).
       Additive - không đổi hành vi gì, chỉ thêm 1 index.
*/

-- ============================================================
-- 1) dbo.Split -> inline TVF
-- ============================================================
IF OBJECT_ID('dbo.Split', 'IF') IS NOT NULL DROP FUNCTION [dbo].[Split];
IF OBJECT_ID('dbo.Split', 'TF') IS NOT NULL DROP FUNCTION [dbo].[Split];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE FUNCTION [dbo].[Split]
    (
      @RowData NVARCHAR(max),
      @SplitOn NVARCHAR(5)
    )
RETURNS TABLE
AS
RETURN
(
    SELECT CAST(LTRIM(RTRIM(t.value('.', 'nvarchar(1000)'))) AS NVARCHAR(1000)) AS Data
    FROM (
        SELECT CAST(N'<x>' + REPLACE((SELECT @RowData AS [*] FOR XML PATH('')), @SplitOn, N'</x><x>') + N'</x>' AS XML) AS xdata
    ) AS src
    CROSS APPLY src.xdata.nodes('/x') AS t2(t)
);
GO

-- ============================================================
-- 2) dbo.SmartBooks_Employee -> index trên ID_number
-- ============================================================
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE object_id = OBJECT_ID('dbo.SmartBooks_Employee') AND name = 'IX_SmartBooks_Employee_ID_number'
)
CREATE NONCLUSTERED INDEX [IX_SmartBooks_Employee_ID_number]
    ON [dbo].[SmartBooks_Employee] ([ID_number] ASC)
    INCLUDE ([Employee_ID]);
GO
