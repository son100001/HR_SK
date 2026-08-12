
CREATE   PROCEDURE [dbo].[usp_InsertUpdateHR_RequestLeaveGoOut]
    @ID             int,
    @Employee_ID    nvarchar(50),
    @TimeDate       datetime,
    @TimeOut_       datetime,
    @TimeIn         datetime,
    @LeaveType_ID   nvarchar(50),
    @ShiftName      nvarchar(50),
    @Remark         nvarchar(max),
    @UserName       nvarchar(50),
    @InsertDate     datetime,
    @Approver       NVARCHAR(200),
    @ApproveDate    datetime,
    @TrangThai      NVARCHAR(50) = null
AS
BEGIN
    SET NOCOUNT ON;

    SET @TrangThai = N'Pending';

    DECLARE
        @ThongBao           nvarchar(max),
        @Shiftfromtime      datetime,
        @ApproveLevel       nvarchar(200),
        @ApproveLevelFirst  nvarchar(50),
        @ThuTuDuyet         int            = 1,
        @Fullname           nvarchar(50),
        @Email              nvarchar(100),
        @FlowCode           nvarchar(50),
        @RequestType        nvarchar(50)   = N'RequestGoOut';

    SELECT @ShiftName = dkc.ShiftName
    FROM udf_DangKyCa(@TimeDate, @TimeDate, 181, NULL, NULL, NULL, NULL, NULL, NULL, @Employee_ID) dkc;

    SET @ThongBao = [dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID, @TimeDate, @UserName, N'HR_GoOut');
    SELECT @ShiftName = shiftname FROM hr_shifts WHERE shiftname = @shiftname OR [ShiftSign] = @shiftname;

    SELECT @ApproveLevelFirst = [Data] FROM Split(@Approver, ',') WHERE Order_ = 1;

    SELECT
        @ApproveLevel = STRING_AGG(CAST(ap.[Data] AS nvarchar(max)), ',') WITHIN GROUP (ORDER BY ap.Order_)
    FROM Split(@Approver, ',') ap
    WHERE EXISTS (
        SELECT 1
        FROM HR_ApprovalLevelMember firstMember
        INNER JOIN HR_ApprovalLevelMember sameLevel
            ON  sameLevel.LevelCode  = firstMember.LevelCode
            AND sameLevel.IsActive   = 1
        WHERE firstMember.Employee_ID = @ApproveLevelFirst
          AND firstMember.IsActive    = 1
          AND sameLevel.Employee_ID   = ap.[Data]
    );

    SET @ApproveLevel = ISNULL(NULLIF(@ApproveLevel, ''), @ApproveLevelFirst);
    SELECT @ApproveDate = ISNULL(@ApproveDate, GETDATE());
    SELECT @Fullname = Employee_FirstName + N' ' + Employee_Lastname FROM SmartBooks_Employee WHERE Employee_ID = @Employee_ID;
    SELECT @Email    = Email FROM SmartBooks_Employee WHERE Employee_ID = @ApproveLevelFirst;

    SELECT @FlowCode = dbo.udf_ResolveApprovalFlow(@Employee_ID, @RequestType, GETDATE());
    IF @FlowCode IS NULL
    BEGIN
        SELECT TOP 1 @FlowCode = NULLIF(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N'')
        FROM udf_EmployeeFilter_Web(N'VN', NULL, NULL, NULL, NULL, NULL, NULL, @Employee_ID, GETDATE()) ef;
    END

    IF @FlowCode IS NOT NULL AND @ApproveLevelFirst IS NOT NULL
    BEGIN
        SET @ThuTuDuyet = dbo.udf_GetApprovalStepOrderForApprover_Web(
            @FlowCode,
            @RequestType,
            @ApproveLevelFirst
        );
    END

    DECLARE @ChiGuiThongBao NVARCHAR(MAX);

    SELECT @ChiGuiThongBao = ISNULL(ga.ChiGuiThongBao, N'')
    FROM HR_GetApprover ga
    WHERE ga.Code        = @Approver
      AND ga.Employee_ID = @Employee_ID
      AND ga.RequestType = @RequestType;

    SET @ChiGuiThongBao = ISNULL(@ChiGuiThongBao, N'');

    IF ISNULL(@ThongBao, N'') = N''
    BEGIN
        SELECT @Shiftfromtime = FromTime FROM HR_Shifts WHERE ShiftName = @ShiftName;

        IF DATEPART(hour, @Shiftfromtime) <= DATEPART(hour, @TimeOut_)
            SET @TimeOut_ = [dbo].[GhepGioVaoNgay](@TimeDate,     @TimeOut_);
        ELSE
            SET @TimeOut_ = [dbo].[GhepGioVaoNgay](@TimeDate + 1, @TimeOut_);

        IF DATEPART(hour, @TimeOut_) <= DATEPART(hour, @TimeIn)
            SET @TimeIn = [dbo].[GhepGioVaoNgay](@TimeOut_,     @TimeIn);
        ELSE
            SET @TimeIn = [dbo].[GhepGioVaoNgay](@TimeOut_ + 1, @TimeIn);

        -- Block save when an active (Pending/Approved) request overlaps the requested time range.
        -- Two intervals [A,B] and [C,D] overlap when A < D AND C < B.
        IF EXISTS (
            SELECT 1
            FROM HR_LeaveRequestGoOut
            WHERE Employee_ID             = @Employee_ID
              AND CONVERT(date, TimeDate) = CONVERT(date, @TimeDate)
              AND TrangThai               IN (N'Pending', N'Approved')
              AND TimeOut_                < @TimeIn
              AND @TimeOut_               < TimeIn
              AND (@ID IS NULL OR ID     <> @ID)
        )
        BEGIN
            SET @ThongBao = N'GoOutTimeOverlap';
        END
        ELSE
        BEGIN
            IF EXISTS (
                SELECT Employee_ID
                FROM HR_LeaveRequestGoOut
                WHERE Employee_ID = @Employee_ID AND TimeOut_ = @TimeOut_ AND ID IS NOT NULL
            )
            BEGIN
                UPDATE HR_LeaveRequestGoOut
                SET Employee_ID      = @Employee_ID,
                    TimeDate         = @TimeDate,
                    LeaveType_ID     = @LeaveType_ID,
                    ShiftName        = @ShiftName,
                    TimeOut_         = @TimeOut_,
                    TimeIn           = @TimeIn,
                    Remark           = @Remark,
                    UserName         = @UserName,
                    InsertDate       = GETDATE(),
                    TrangThai        = @TrangThai,
                    ApproveDate      = @ApproveDate,
                    ApproverName     = @Approver,
                    ApproveLevel     = @ApproveLevel,
                    ThuTuDuyet       = @ThuTuDuyet,
                    CurrentStepSince = GETDATE()
                WHERE (Employee_ID = @Employee_ID AND TimeDate = @TimeDate) OR ID = ISNULL(@ID, 0);
            END
            ELSE
            BEGIN
                INSERT INTO HR_LeaveRequestGoOut (
                    Employee_ID, TimeDate, TimeOut_, TimeIn, LeaveType_ID, ShiftName, Remark,
                    UserName, InsertDate, TrangThai, ApproveDate, ApproverName, ApproveLevel,
                    ThuTuDuyet, CurrentStepSince
                )
                VALUES (
                    @Employee_ID, @TimeDate, @TimeOut_, @TimeIn, @LeaveType_ID, @ShiftName, @Remark,
                    @UserName, GETDATE(), @TrangThai, @ApproveDate, @Approver, @ApproveLevel,
                    @ThuTuDuyet, GETDATE()
                );
            END

            -- Rebuild notification recipient list only when save succeeds.
            IF @ApproveLevel IS NULL
            BEGIN
                DELETE HR_DanhSachNguoiNhanThongBao
                WHERE Employee_ID = @Employee_ID AND Type_ = N'RequestGoOut';

                INSERT INTO HR_DanhSachNguoiNhanThongBao (
                    Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao,
                    NotifyViaWeb, NotifyViaEmail, NotifyViaZalo
                )
                SELECT @Employee_ID, dt.[Data], @Fullname, N'RequestGoOut', ISNULL(empl.Email, N''), 0,
                    CASE WHEN @ApproveLevel IS NULL THEN 1 ELSE 0 END,
                    ch.NotifyViaWeb, ch.NotifyViaEmail, ch.NotifyViaZalo
                FROM Split(@ChiGuiThongBao, ',') dt
                LEFT JOIN SmartBooks_Employee empl ON dt.[Data] = empl.Employee_ID
                CROSS APPLY dbo.udf_ApprovalNotifyChannels_Web(@RequestType, @FlowCode, NULL, 1) ch
                WHERE dt.[Data] <> N'';
            END
            ELSE
            BEGIN
                DELETE HR_DanhSachNguoiNhanThongBao
                WHERE Employee_ID = @Employee_ID AND Type_ = N'RequestGoOut';

                INSERT INTO HR_DanhSachNguoiNhanThongBao (
                    Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao,
                    NotifyViaWeb, NotifyViaEmail, NotifyViaZalo
                )
                SELECT @Employee_ID, dt.[Data], @Fullname, N'RequestGoOut', ISNULL(empl.Email, N''), 0, 0,
                    ch.NotifyViaWeb, ch.NotifyViaEmail, ch.NotifyViaZalo
                FROM Split(@ApproveLevel, ',') dt
                LEFT JOIN SmartBooks_Employee empl ON dt.[Data] = empl.Employee_ID
                CROSS APPLY dbo.udf_ApprovalNotifyChannels_Web(@RequestType, @FlowCode, @ThuTuDuyet, 0) ch
                WHERE dt.[Data] <> N'';
            END
        END
    END

    SELECT @ID = ID FROM HR_LeaveRequestGoOut WHERE Employee_ID = @Employee_ID AND TimeDate = @TimeDate;
    SELECT @ThongBao AS ThongBao, @ID AS ID;
END

GO
