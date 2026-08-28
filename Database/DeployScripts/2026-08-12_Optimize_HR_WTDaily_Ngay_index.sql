/*
    Mục đích: Thêm index hỗ trợ các truy vấn lọc HR_WTDaily theo Ngay (không kèm Employee_ID) trong
    dbo.sp_TinhCong (và có thể các store/function khác dùng cùng pattern). Bảng chỉ có PK CLUSTERED
    (Employee_ID, Ngay, MaCong, InsertSource) - dẫn đầu bằng Employee_ID nên các truy vấn lọc CHỈ theo
    Ngay (vd tổng hợp giờ tăng ca đã dùng trong năm cho TẤT CẢ nhân viên, dòng ~159 của sp_TinhCong)
    phải quét toàn bảng.
    Áp dụng cho: HR_SnK_Dev_260811.
    Tham khảo: markdowns/SQL_PERFORMANCE_PLAYBOOK.md mục A8, markdowns/SQL_PERFORMANCE_HISTORY.md.
    Idempotent: chỉ thêm 1 index, additive, không đổi hành vi/kết quả truy vấn nào (index không thể
    làm sai kết quả, chỉ đổi execution plan).

    Đã đo trước/sau trên truy vấn thật lấy từ sp_TinhCong (tổng hợp giờ tăng ca theo năm):
    10.507 logical reads, scan count 9 -> 1.979 logical reads, scan count 1 (~5.3 lần).
*/

IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE object_id = OBJECT_ID('dbo.HR_WTDaily') AND name = 'IX_HR_WTDaily_Ngay'
)
CREATE NONCLUSTERED INDEX [IX_HR_WTDaily_Ngay]
    ON [dbo].[HR_WTDaily] ([Ngay] ASC)
    INCLUDE ([Employee_ID],[MaCong],[wt],[InsertSource]);
GO
