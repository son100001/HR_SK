/*
    ROLLBACK cho 2026-08-28_HR_SnK_Dev_Optimize_Indexes.sql
    Xoá 3 index đã thêm ngày 2026-08-28 trên HR_SnK_Dev. Chỉ chạy khi cần quay lui.
    Index là additive nên bình thường KHÔNG cần rollback — chỉ dùng nếu phát hiện chi phí ghi
    (INSERT/UPDATE vào 3 bảng này) tăng đáng kể và không chấp nhận được.
    Idempotent: bọc IF EXISTS, chạy lại nhiều lần an toàn.
*/

IF EXISTS (SELECT 1 FROM sys.indexes WHERE object_id = OBJECT_ID('dbo.SmartBooks_Employee') AND name = 'IX_SmartBooks_Employee_ID_number')
    DROP INDEX [IX_SmartBooks_Employee_ID_number] ON [dbo].[SmartBooks_Employee];
GO

IF EXISTS (SELECT 1 FROM sys.indexes WHERE object_id = OBJECT_ID('dbo.HR_TimeKeeping_Data') AND name = 'IX_HR_TimeKeeping_Data_AccessDate')
    DROP INDEX [IX_HR_TimeKeeping_Data_AccessDate] ON [dbo].[HR_TimeKeeping_Data];
GO

IF EXISTS (SELECT 1 FROM sys.indexes WHERE object_id = OBJECT_ID('dbo.HR_WTDaily') AND name = 'IX_HR_WTDaily_Ngay')
    DROP INDEX [IX_HR_WTDaily_Ngay] ON [dbo].[HR_WTDaily];
GO
