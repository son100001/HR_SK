CREATE   PROCEDURE [dbo].[sp_HR_RequestLeave_GetDataBegin]
    @UserID NVARCHAR(50),
    @Language NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -------------------------------------------------
    -- 1. Loại nghỉ phép (TabLeaveType)
    -------------------------------------------------
	select * from udf_GetLeaveType ('')

    -------------------------------------------------
    -- 2. Loại nghỉ phép đầy đủ (TabLeaveTypeFull)
    -------------------------------------------------
    select * from Smartbooks_LeaveType

    -------------------------------------------------
    -- 3. Trạng thái duyệt (TabApproveStatus)
    -------------------------------------------------
    select * from HR_Category where CategoryFather = 'ApproveStatus'

    -------------------------------------------------
    -- 4. Loại chức vụ (TabLoaiChucVu)
    -------------------------------------------------
    select * from SmartBooks_PositionCategory

    -------------------------------------------------
    -- 5. Người duyệt chính (TabApprover)
    -------------------------------------------------
	exec sp_GetApprover @Account = @UserID, @TypeOfReport = 1, @LAN = @Language

    -------------------------------------------------
    -- 6. Người duyệt mở rộng (TabApproverExtend)
    -------------------------------------------------
	exec sp_GetApproverExtend @Account = @UserID, @TypeOfReport = 1, @LAN = @Language

    -------------------------------------------------
    -- 7. Người duyệt hiện tại (TabApproverCurrent)
    -------------------------------------------------
	exec sp_GetApproverCurrent @Account = @UserID, @TypeOfReport = 1, @LAN = @Language

    -------------------------------------------------
    -- 8. Loại nghỉ tính theo giờ (TabLateInEarlyOut)
    -------------------------------------------------
    select * from HR_Category where CategoryFather = 'LoaiDangKyPhepTheoGio'

    -------------------------------------------------
    -- 9. Kiểm tra thông tin người dùng (AD, FullName)
    -------------------------------------------------
	exec sp_GetUserInformation @Username = @UserID
	
    -------------------------------------------------
    -- 10. Vị trí tổng hợp (TabViTri)
    select * from udf_Position(@Language,0)
END

GO
