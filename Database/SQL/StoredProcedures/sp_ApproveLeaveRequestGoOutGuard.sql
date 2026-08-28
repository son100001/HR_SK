
CREATE   PROCEDURE [dbo].[sp_ApproveLeaveRequestGoOutGuard]
    @ID INT,
    @GioVaoThucTe datetime = NULL,
    @Employee_ID nvarchar(50) = null,
    @TimeDate datetime = null,
    @TimeOut_ datetime = null,
    @TimeIn datetime = null,
    @LeaveType_ID nvarchar(50) = null,
    @ShiftName nvarchar(50) = null,
    @Remark nvarchar(MAX) = null,
    @UserName nvarchar(50) = null,
    @InsertDate datetime = null,
    @ApproveDate datetime = null,
    @TrangThai nvarchar(50) = null
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE
        @ExistingGioVaoThucTe datetime,
        @GoOutEmployee_ID nvarchar(50),
        @RecordTimeOut datetime,
        @MaxHours int,
        @Now datetime = GETDATE(),
        @Employee_Name nvarchar(100),
        @EmailDuPhong nvarchar(100);

    SELECT
        @ExistingGioVaoThucTe = goout.GioVaoThucTe,
        @GoOutEmployee_ID = goout.Employee_ID,
        @RecordTimeOut = goout.TimeOut_
    FROM HR_GoOut goout
    WHERE goout.ID = @ID;

    -- Phải chặn tường minh: bỏ 50001 rồi thì không còn gì đỡ hộ trường hợp ID sai.
    IF @GoOutEmployee_ID IS NULL
        THROW 50007, 'HRReport.GuardConfirmRequestNotFound', 1;

    IF @ExistingGioVaoThucTe IS NOT NULL
        THROW 50006, 'HRReport.GuardConfirmAlreadyDone', 1;

    IF @GioVaoThucTe IS NULL
        SET @GioVaoThucTe = @Now;

    SELECT @MaxHours = TRY_CAST([Value] AS int)
    FROM SetUp
    WHERE FunctionID = 'HR'
      AND ID = 'GuardConfirmMaxHours';

    IF ISNULL(@MaxHours, 0) <= 0
        SET @MaxHours = 12;

    IF @GioVaoThucTe < @RecordTimeOut
        THROW 50002, 'HRReport.GuardConfirmBeforeTimeOut', 1;

    IF @GioVaoThucTe > @Now
        THROW 50003, 'HRReport.GuardConfirmFutureTime', 1;

    -- Neo vào giờ ra của chính đơn, KHÔNG neo vào khung ca — xem ghi chú đầu file.
    IF @GioVaoThucTe > DATEADD(HOUR, @MaxHours, @RecordTimeOut)
        THROW 50004, 'HRReport.GuardConfirmExceedMaxHours', 1;

    SELECT @Employee_Name = Employee_Firstname + ' ' + Employee_LastName
    FROM SmartBooks_Employee
    WHERE Employee_ID = @GoOutEmployee_ID;

    SELECT @EmailDuPhong = [Value]
    FROM SetUp
    WHERE FunctionID = 'Email'
      AND ID = 'EmailDuPhong';

    BEGIN TRANSACTION InsertApprove;

    BEGIN TRY
        UPDATE HR_GoOut
        SET GioVaoThucTe = @GioVaoThucTe
        WHERE ID = @ID;

        DELETE HR_DanhSachNguoiNhanThongBao
        WHERE Employee_ID = @GoOutEmployee_ID
          AND Type_ = 'GoOutGuardConfirmed';

        INSERT INTO HR_DanhSachNguoiNhanThongBao (Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao)
        SELECT
            @GoOutEmployee_ID,
            @GoOutEmployee_ID,
            @Employee_Name,
            'GoOutGuardConfirmed',
            CASE WHEN ISNULL(empl.Email, '') = '' THEN ISNULL(@EmailDuPhong, '') ELSE empl.Email END,
            0,
            1
        FROM SmartBooks_Employee empl
        WHERE empl.Employee_ID = @GoOutEmployee_ID;

        IF @@ROWCOUNT = 0
        BEGIN
            INSERT INTO HR_DanhSachNguoiNhanThongBao (Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao)
            VALUES (@GoOutEmployee_ID, @GoOutEmployee_ID, ISNULL(@Employee_Name, @GoOutEmployee_ID), 'GoOutGuardConfirmed', ISNULL(@EmailDuPhong, ''), 0, 1);
        END;

        COMMIT TRANSACTION InsertApprove;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION InsertApprove;
        THROW;
    END CATCH
END

GO
