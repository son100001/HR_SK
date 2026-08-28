/*
    Mục đích: Thêm index hỗ trợ lọc HR_TimeKeeping_Data theo AccessDate (bảng ~950k+ dòng, PK hiện tại
    là (Employee_ID, AccessTime, CardNumber) - không có gì hỗ trợ lọc chỉ theo ngày, nên mọi truy vấn
    lọc theo khoảng ngày (dbo.DuLieuQuet và các nơi gọi nó) đều full scan).
    Áp dụng cho: HR_SnK_Dev_260811.
    Tham khảo: markdowns/SQL_PERFORMANCE_PLAYBOOK.md mục A6 bước 1, markdowns/SQL_PERFORMANCE_HISTORY.md.
    Idempotent: chỉ thêm 1 index, additive, không đổi hành vi/kết quả truy vấn nào.

    Lưu ý: đây chỉ là bước 1/2 của mục A6 trong playbook (thêm index). Bước 2 (convert dbo.DuLieuQuet
    sang inline TVF) CHƯA áp dụng trong lần deploy này vì thân hàm DuLieuQuet của DB này có logic
    INSERT + DELETE + UNION ALL (đối chiếu dữ liệu quẹt thẻ với chỉnh sửa tay HR_DuLieuQuetVaoRa),
    KHÁC với mô tả "1 SELECT đơn giản" trong playbook (viết cho HR_KIDO_35) - cần rewrite + verify kỹ
    hơn trước khi áp dụng, xem SQL_PERFORMANCE_HISTORY.md.
*/

IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE object_id = OBJECT_ID('dbo.HR_TimeKeeping_Data') AND name = 'IX_HR_TimeKeeping_Data_AccessDate'
)
CREATE NONCLUSTERED INDEX [IX_HR_TimeKeeping_Data_AccessDate]
    ON [dbo].[HR_TimeKeeping_Data] ([AccessDate] ASC);
GO
