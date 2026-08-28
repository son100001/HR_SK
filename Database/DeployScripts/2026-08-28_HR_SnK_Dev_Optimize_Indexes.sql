/*
    Mục đích: thêm 3 index còn thiếu trên HR_SnK_Dev — port từ các fix đã làm trên HR_SnK_Dev_260811
    ngày 2026-08-12 (đã xác nhận cả 3 đều CHƯA tồn tại trên HR_SnK_Dev tính đến 2026-08-28).
    Áp dụng cho: HR_SnK_Dev (113.161.180.44). Ngày: 2026-08-28.
    Tham khảo: markdowns/SQL_PERFORMANCE_PLAYBOOK.md mục A2 + A6 bước 1 + A8,
               markdowns/SQL_PERFORMANCE_HISTORY.md.

    Idempotent: cả 3 đều bọc IF NOT EXISTS, chạy lại nhiều lần an toàn.
    An toàn về kết quả: index là additive — không thể làm sai kết quả truy vấn, chỉ đổi execution plan.

    ⚠️ LƯU Ý VẬN HÀNH (DB có người dùng thật): SQL Server Standard Edition KHÔNG hỗ trợ ONLINE index
    build, nên mỗi lệnh CREATE INDEX dưới đây sẽ giữ khoá làm CHẶN GHI (INSERT/UPDATE/DELETE) trên
    bảng tương ứng trong suốt thời gian build. Ước tính vài giây/bảng ở quy mô hiện tại
    (HR_TimeKeeping_Data ~1.07 triệu dòng, HR_WTDaily ~634 nghìn dòng, SmartBooks_Employee ~9,2 nghìn
    dòng) nhưng nên chạy ngoài giờ cao điểm / ngoài lúc đang chạy tính công - tính lương.

    Baseline đo được trước khi thêm (2026-08-28, trên chính HR_SnK_Dev):
      - Lọc SmartBooks_Employee theo ID_number       : 1.519 logical reads (full scan), ~7 ms
      - Lọc HR_TimeKeeping_Data theo AccessDate (1 tháng): scan count 9, 20.774 logical reads, ~43-45 ms
      - Tổng hợp HR_WTDaily theo Ngay cả năm (sp_TinhCong dòng 160): scan count 9, 12.588 logical reads,
        ~120-126 ms
    Kết quả sau khi thêm: xem markdowns/SQL_PERFORMANCE_HISTORY.md.

    Rollback: 2026-08-28_HR_SnK_Dev_Rollback_Indexes.sql
*/

-- ============================================================
-- 1) dbo.SmartBooks_Employee -> index trên ID_number (CMND/CCCD)
--    Bảng chỉ có PK CLUSTERED (Employee_ID) nên mọi tra cứu theo ID_number đều full scan.
-- ============================================================
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE object_id = OBJECT_ID('dbo.SmartBooks_Employee') AND name = 'IX_SmartBooks_Employee_ID_number'
)
CREATE NONCLUSTERED INDEX [IX_SmartBooks_Employee_ID_number]
    ON [dbo].[SmartBooks_Employee] ([ID_number] ASC)
    INCLUDE ([Employee_ID]);
GO

-- ============================================================
-- 2) dbo.HR_TimeKeeping_Data -> index trên AccessDate
--    PK CLUSTERED là (Employee_ID, AccessTime, CardNumber, InsertSource) - không hỗ trợ lọc CHỈ theo
--    ngày, nên dbo.DuLieuQuet và mọi nơi gọi nó đều phải quét toàn bảng ~1,07 triệu dòng.
-- ============================================================
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE object_id = OBJECT_ID('dbo.HR_TimeKeeping_Data') AND name = 'IX_HR_TimeKeeping_Data_AccessDate'
)
CREATE NONCLUSTERED INDEX [IX_HR_TimeKeeping_Data_AccessDate]
    ON [dbo].[HR_TimeKeeping_Data] ([AccessDate] ASC);
GO

-- ============================================================
-- 3) dbo.HR_WTDaily -> index trên Ngay
--    PK CLUSTERED là (Employee_ID, Ngay, MaCong, InsertSource) - dẫn đầu bằng Employee_ID nên truy vấn
--    lọc CHỈ theo Ngay (vd sp_TinhCong dòng 160: tổng hợp giờ làm cả NĂM cho TẤT CẢ nhân viên) phải
--    quét gần hết bảng ~634 nghìn dòng, bất kể đang tính công cho 1 hay nhiều nhân viên.
-- ============================================================
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE object_id = OBJECT_ID('dbo.HR_WTDaily') AND name = 'IX_HR_WTDaily_Ngay'
)
CREATE NONCLUSTERED INDEX [IX_HR_WTDaily_Ngay]
    ON [dbo].[HR_WTDaily] ([Ngay] ASC)
    INCLUDE ([Employee_ID],[MaCong],[wt],[InsertSource]);
GO
