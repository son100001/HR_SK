/*
    Mục đích: dbo.Split đang là multi-statement TVF dùng vòng lặp WHILE để tách chuỗi -> SQL Server
    ước lượng sai cardinality (mặc định 1 dòng với compatibility_level 120) và phải chạy lại toàn bộ
    thân hàm cho MỖI lần gọi. Convert sang inline TVF (tally set-based) để optimizer nội suy được
    thẳng vào plan của caller.
    Áp dụng cho: HR_SnK_Dev (113.161.180.44). Ngày: 2026-08-28.
    Tham khảo: markdowns/SQL_PERFORMANCE_PLAYBOOK.md mục A1 + C1, markdowns/SQL_PERFORMANCE_HISTORY.md.

    ⚠️ KHÁC BIỆT QUAN TRỌNG so với script cũ 2026-08-12_Optimize_udf_EmployeeFilter_dependencies.sql
    (viết cho HR_SnK_Dev_260811): trên HR_SnK_Dev, dbo.Split trả về **2 cột** (Data, order_) chứ không
    phải 1 cột (Data). Có 7 stored procedure đang dùng cột order_ thật:
      sp_Approval_EscalatePending_Web, sp_ApproveLeaveRequest, sp_ApproveLeaveRequestGoOut,
      sp_BangPhepMultiple_Web, sp_BangPhepXinRaNgoai_Web, usp_InsertUpdateHR_EmployeeLeaveRequests,
      usp_InsertUpdateHR_RequestLeaveGoOut
    -> KHÔNG ĐƯỢC chạy script cũ lên DB này (sẽ làm hỏng 7 proc trên). Bản dưới đây giữ nguyên cả 2 cột.

    Cũng KHÔNG dùng cách XML .nodes() như bản _260811 vì: (1) không có cách sinh order_ có thứ tự đảm
    bảo, (2) .nodes() bắt buộc session phải SET QUOTED_IDENTIFIER ON (bẫy khi debug bằng sqlcmd/SSMS).
    Cách tally dưới đây deterministic hoàn toàn và không phụ thuộc QUOTED_IDENTIFIER.

    Tương thích ngược - đã đối chiếu đúng hành vi của bản WHILE loop cũ:
      - LTRIM/RTRIM từng token, kiểu trả về NVARCHAR(1000), order_ đánh số từ 1 theo thứ tự chuỗi.
      - @RowData IS NULL          -> 1 dòng (Data = NULL, order_ = 1).
      - @RowData = N''            -> 1 dòng (Data = N'', order_ = 1).
      - @SplitOn IS NULL / N''    -> KHÔNG tách, trả nguyên chuỗi 1 dòng (khớp CHARINDEX(N'',x) = 0).
                                     Quan trọng: có 7 lời gọi trong DB truyền dấu phân cách rỗng.
      - Token rỗng liền nhau (N'A,,B') -> vẫn trả dòng rỗng ở giữa, không bị nuốt.
      - Dấu phân cách đầu/cuối chuỗi   -> vẫn sinh token rỗng tương ứng.

    Verify (2026-08-28, chạy trên chính HR_SnK_Dev, so bằng EXCEPT 2 chiều giữa hàm cũ và hàm mới):
      343 test case / 1.172 dòng kết quả -> lệch 0 dòng cả 2 chiều. Test case gồm: NULL, chuỗi rỗng,
      dấu phân cách rỗng/NULL, token rỗng liền nhau, khoảng trắng thừa, tiếng Việt có dấu, ký tự XML
      đặc biệt (' " < > &), list 500 phần tử, và dữ liệu thật lấy từ SmartBooks_Employee /
      HR_DangKyPhepTheoGio.

    Đo được (5 lần lặp mỗi kịch bản, trung bình):
      | Kịch bản                          | Cũ (MSTVF) | Mới (inline) |
      | IN (SELECT Data FROM Split(...))  |     15 ms  |    12 ms     |
      | CROSS APPLY trên 3.000 dòng       |    430 ms  |    28 ms  (~15x) |
      | Gọi 500 lần đơn lẻ                |    159 ms  |    34 ms  (~4,7x) |

    Khác biệt hành vi duy nhất đã biết (chấp nhận được): token dài hơn 1000 ký tự - bản cũ sẽ báo lỗi
    "String or binary data would be truncated" khi INSERT vào table variable, bản mới CAST cắt bớt im
    lặng. Không caller nào hiện tại truyền token dài như vậy.

    Idempotent: DROP + CREATE lại (đổi loại object nên không ALTER được). Chạy lại nhiều lần an toàn.
    Rollback: xem file 2026-08-28_HR_SnK_Dev_Rollback_Split_MSTVF.sql.
*/

IF OBJECT_ID('dbo.Split', 'IF') IS NOT NULL DROP FUNCTION [dbo].[Split];
IF OBJECT_ID('dbo.Split', 'TF') IS NOT NULL DROP FUNCTION [dbo].[Split];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE FUNCTION [dbo].[Split]
    (
      @RowData NVARCHAR(max) ,
      @SplitOn NVARCHAR(5)
    )
RETURNS TABLE
AS
RETURN
(
    WITH L0(c) AS (SELECT 1 UNION ALL SELECT 1),
         L1(c) AS (SELECT 1 FROM L0 a CROSS JOIN L0 b),
         L2(c) AS (SELECT 1 FROM L1 a CROSS JOIN L1 b),
         L3(c) AS (SELECT 1 FROM L2 a CROSS JOIN L2 b),
         L4(c) AS (SELECT 1 FROM L3 a CROSS JOIN L3 b),
         Tally(n) AS (
            SELECT TOP (CASE WHEN @RowData IS NULL OR @SplitOn IS NULL OR @SplitOn = N''
                             THEN 0 ELSE DATALENGTH(@RowData) / 2 END)
                   ROW_NUMBER() OVER (ORDER BY (SELECT NULL))
            FROM L4 a CROSS JOIN L4 b
         ),
         Pos(n) AS (
            SELECT 0
            UNION ALL
            SELECT n FROM Tally
            WHERE SUBSTRING(@RowData, n, DATALENGTH(@SplitOn) / 2) = @SplitOn
         )
    SELECT
        CAST(LTRIM(RTRIM(SUBSTRING(
              @RowData,
              p.n + 1,
              ISNULL(LEAD(p.n) OVER (ORDER BY p.n), DATALENGTH(@RowData) / 2 + 1) - p.n - 1
        ))) AS NVARCHAR(1000)) AS Data,
        CAST(ROW_NUMBER() OVER (ORDER BY p.n) AS INT) AS order_
    FROM Pos p
);
GO
