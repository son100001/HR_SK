
CREATE PROCEDURE [dbo].[sp_ApproveLeaveRequestGoOutGuard]
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
        @RecordTimeDate datetime,
        @RecordShiftName nvarchar(50),
        @ShiftFromTime datetime,
        @ShiftToTime datetime,
        @CaStart datetime,
        @CaEnd datetime,
        @Now datetime = GETDATE(),
        @Employee_Name nvarchar(100),
        @EmailDuPhong nvarchar(100);

    IF @ID IS NULL
        SELECT @ID = ID
        FROM HR_LeaveRequestGoOut
        WHERE Employee_ID = @Employee_ID
          AND TimeDate = @TimeDate
          AND TimeOut_ = @TimeOut_
          AND TimeIn = @TimeIn;

    SELECT
        @ExistingGioVaoThucTe = goout.GioVaoThucTe,
        @GoOutEmployee_ID = goout.Employee_ID,
        @RecordTimeOut = goout.TimeOut_,
        @RecordTimeDate = goout.TimeDate,
        @RecordShiftName = goout.ShiftName
    FROM HR_GoOut goout
    WHERE goout.ID = @ID;

    IF @ExistingGioVaoThucTe IS NOT NULL
    BEGIN
        SELECT 'DaNhapDuLieuVao' AS Thongbao;
        RETURN;
    END;

    IF @GioVaoThucTe IS NULL
        SET @GioVaoThucTe = @Now;

    SELECT
        @ShiftFromTime = shifts.FromTime,
        @ShiftToTime = shifts.ToTime
    FROM HR_Shifts shifts
    WHERE shifts.ShiftName = @RecordShiftName;

    IF ISNULL(@RecordShiftName, '') = '' OR @ShiftFromTime IS NULL OR @ShiftToTime IS NULL
        THROW 50001, 'HRReport.GuardConfirmShiftNotFound', 1;

    SET @CaStart = CAST([dbo].[GhepGioVaoNgay](@RecordTimeDate, @ShiftFromTime) AS datetime);
    SET @CaEnd = CAST([dbo].[GhepGioVaoNgay](
        CASE
            WHEN DATEPART(HOUR, @ShiftToTime) > DATEPART(HOUR, @ShiftFromTime) THEN @RecordTimeDate
            ELSE DATEADD(DAY, 1, @RecordTimeDate)
        END,
        @ShiftToTime) AS datetime);

    IF @GioVaoThucTe < @RecordTimeOut
        THROW 50002, 'HRReport.GuardConfirmBeforeTimeOut', 1;

    IF @GioVaoThucTe > @Now
        THROW 50003, 'HRReport.GuardConfirmFutureTime', 1;

    IF @GioVaoThucTe < @CaStart OR @GioVaoThucTe > @CaEnd
        THROW 50004, 'HRReport.GuardConfirmOutsideShift', 1;

    IF @Now < @CaStart OR @Now > @CaEnd
        THROW 50005, 'HRReport.GuardConfirmActionOutsideShift', 1;

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
