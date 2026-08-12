
CREATE   PROCEDURE [dbo].[sp_TinhCongParallel]
(
    @FromDate DATETIME,
    @ToDate DATETIME,
    @UserName NVARCHAR(50) = N'admin',

    @BatchCount INT = 8,                 -- Số batch (thread) muốn chạy song song
    @Server NVARCHAR(200) = N'WIN-MAJPEA6KJ2S',  -- Tên/địa chỉ SQL Server
    @DbName NVARCHAR(128) = N'HR_SnK_Dev',       -- Tên DB đích để chạy sp_TinhCongTheoBatch
    @UseTrusted BIT = 0,                          -- 1: -E (Integrated), 0: dùng @SqlUser/@SqlPassword
    @SqlUser SYSNAME = NULL,
    @SqlPassword NVARCHAR(256) = NULL,

    @WaitForCompletion BIT = 1,           -- Chờ đến khi tất cả batch xong
    @PollSeconds INT = 2,                 -- Tần suất kiểm tra tiến độ
    @TimeoutMinutes INT = NULL            -- NULL: không timeout; >0: timeout tính bằng phút
)
AS
BEGIN
    SET NOCOUNT ON;

    -- 1) Bảng staging: 1 dòng/nhân viên
    IF OBJECT_ID('dbo.HR_TinhCongBatchEmp','U') IS NULL
    BEGIN
        CREATE TABLE dbo.HR_TinhCongBatchEmp
        (
            RunID UNIQUEIDENTIFIER NOT NULL,
            BatchID INT NOT NULL,
            SeqNo INT NULL,                 -- Thứ tự chung trong toàn danh sách
            Employee_ID NVARCHAR(50) NOT NULL,
            Status NVARCHAR(20) NULL,       -- NULL, Running, Done, Error
            StartTime DATETIME NULL,
            EndTime DATETIME NULL,
            Message NVARCHAR(MAX) NULL,
            CONSTRAINT PK_HR_TinhCongBatchEmp PRIMARY KEY (RunID, BatchID, Employee_ID)
        );
        CREATE INDEX IX_HR_TinhCongBatchEmp_Batch ON dbo.HR_TinhCongBatchEmp (RunID, BatchID);
    END;

    -- Bổ sung cột SeqNo nếu thiếu
    IF COL_LENGTH('dbo.HR_TinhCongBatchEmp','SeqNo') IS NULL
    BEGIN
        ALTER TABLE dbo.HR_TinhCongBatchEmp ADD SeqNo INT NULL;
    END;

    -- 2) Bảng log tổng hợp
    IF OBJECT_ID('dbo.HR_TinhCongLog','U') IS NULL
    BEGIN
        CREATE TABLE dbo.HR_TinhCongLog
        (
            ID INT IDENTITY(1,1) PRIMARY KEY,
            RunID UNIQUEIDENTIFIER NULL,      -- thêm RunID để phân biệt các phiên chạy
            BatchID INT NULL,                 -- NULL: log tổng, NOT NULL: log theo batch
            Employee_ID NVARCHAR(50) NULL,    -- NULL: log batch, NOT NULL: log theo nhân viên
            StartTime DATETIME NULL,
            EndTime DATETIME NULL,
            Status NVARCHAR(50) NULL,         -- STARTED, Running, Done, Error, DoneWithErrors,...
            Message NVARCHAR(MAX) NULL
        );
        CREATE INDEX IX_HR_TinhCongLog_RunBatchEmp ON dbo.HR_TinhCongLog(RunID, BatchID, Employee_ID, ID);
    END;

    -- Bổ sung RunID nếu bảng cũ
    IF COL_LENGTH('dbo.HR_TinhCongLog','RunID') IS NULL
    BEGIN
        ALTER TABLE dbo.HR_TinhCongLog ADD RunID UNIQUEIDENTIFIER NULL;
    END;

    -- 3) Bảng log chi tiết
    IF OBJECT_ID('dbo.HR_TinhCongLogDetail','U') IS NULL
    BEGIN
        CREATE TABLE dbo.HR_TinhCongLogDetail
        (
            ID INT IDENTITY(1,1) PRIMARY KEY,
            RunID UNIQUEIDENTIFIER NOT NULL,
            BatchID INT NOT NULL,
            Employee_ID NVARCHAR(50) NULL,
            Step NVARCHAR(50) NOT NULL, -- SpawnCmd, EmpStart, EmpDone, EmpError, BatchStart, BatchDone
            LogTime DATETIME NOT NULL CONSTRAINT DF_HR_TinhCongLogDetail_LogTime DEFAULT (GETDATE()),
            Info NVARCHAR(MAX) NULL
        );
        CREATE INDEX IX_HR_TinhCongLogDetail_RunBatch ON dbo.HR_TinhCongLogDetail (RunID, BatchID, ID);
    END;

    -- 4) Lấy danh sách nhân viên theo kỳ
    IF OBJECT_ID('tempdb..#EmpList') IS NOT NULL DROP TABLE #EmpList;

    SELECT 
        ROW_NUMBER() OVER (ORDER BY Employee_ID) AS RowNum,
        Employee_ID
    INTO #EmpList
    FROM dbo.SmartBooks_Employee
    WHERE (TernimationDate IS NULL OR TernimationDate >= @FromDate)
      AND StartedDate <= @ToDate;

    DECLARE @TotalEmp INT = (SELECT COUNT(*) FROM #EmpList);
    IF @TotalEmp = 0
    BEGIN
        PRINT N'Không có nhân viên cần tính công.';
        RETURN;
    END;

    IF @BatchCount < 1 SET @BatchCount = 1;
    IF @BatchCount > @TotalEmp SET @BatchCount = @TotalEmp;

    DECLARE @BatchSize INT = CEILING(1.0 * @TotalEmp / @BatchCount);

    -- 5) RunID cho phiên
    DECLARE @RunID UNIQUEIDENTIFIER = NEWID();

    -- 6) Đổ vào staging theo batch
    ;WITH EmpBatch AS
    (
        SELECT 
            CEILING(1.0 * RowNum / @BatchSize) AS BatchID,
            RowNum AS SeqNo,
            Employee_ID
        FROM #EmpList
    )
    INSERT dbo.HR_TinhCongBatchEmp (RunID, BatchID, SeqNo, Employee_ID, Status)
    SELECT @RunID, BatchID, SeqNo, Employee_ID, NULL
    FROM EmpBatch;

    DECLARE @MaxBatch INT = (SELECT MAX(BatchID) FROM dbo.HR_TinhCongBatchEmp WHERE RunID = @RunID);

    -- 7) Tham số xác thực cho sqlcmd
    DECLARE @Auth NVARCHAR(400) =
        CASE WHEN @UseTrusted = 1
             THEN N'-E'
             ELSE N'-U "' + ISNULL(@SqlUser,N'') + N'" -P "' + ISNULL(@SqlPassword,N'') + N'"'
        END;

    -- 8) Log folder
    BEGIN TRY
        EXEC xp_cmdshell 'if not exist C:\Temp mkdir C:\Temp', NO_OUTPUT;
    END TRY BEGIN CATCH END CATCH;

    PRINT N'Bắt đầu chạy song song ' + CAST(@MaxBatch AS NVARCHAR(10)) 
        + N' batch. RunID=' + CAST(@RunID AS NVARCHAR(36))
        + N'; TotalEmp=' + CAST(@TotalEmp AS NVARCHAR(20))
        + N'; BatchSize~=' + CAST(@BatchSize AS NVARCHAR(20));

    -- 9) Spawn các batch
    DECLARE @BatchID INT = 1;
    DECLARE @EmpListStr NVARCHAR(MAX);
    DECLARE @Cmd NVARCHAR(4000);
    DECLARE @Cmd_varchar VARCHAR(8000);
    DECLARE @LogFile NVARCHAR(400);

    WHILE @BatchID <= @MaxBatch
    BEGIN
        SELECT @EmpListStr = STRING_AGG(CONCAT(SeqNo,':',Employee_ID), ';')
        FROM dbo.HR_TinhCongBatchEmp
        WHERE RunID = @RunID AND BatchID = @BatchID;

        SET @LogFile = N'C:\Temp\TinhCong_Run' 
                       + REPLACE(CAST(@RunID AS NVARCHAR(36)),'-','')
                       + N'_Batch' + CAST(@BatchID AS NVARCHAR(10)) + N'.log';

        -- Ghi log batch START
        INSERT INTO dbo.HR_TinhCongLog (RunID, BatchID, Employee_ID, StartTime, Status, Message)
        VALUES
        (
            @RunID, @BatchID, NULL, GETDATE(), N'STARTED',
            N'EmpList=' + ISNULL(@EmpListStr,N'') + N'; LogFile=' + @LogFile
        );
        DECLARE @SqlCmdExe NVARCHAR(260) = N'C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\130\Tools\Binn\SQLCMD.EXE';

        -- Trong vòng WHILE @BatchID:
        SET @Cmd =
        N'start "" cmd /c "' +
        N'"' + @SqlCmdExe + N'" ' +
        N'-S ' + @Server +
        N' -d "' + @DbName + N'" ' + @Auth + N' ' +
        N'-Q "EXEC dbo.sp_TinhCongTheoBatch ' +
        N'@RunID=''' + CAST(@RunID AS NVARCHAR(36)) + N''', ' +
        N'@BatchID=' + CAST(@BatchID AS NVARCHAR(10)) + N', ' +
        N'@FromDate=''' + CONVERT(NVARCHAR(19), @FromDate, 120) + N''', ' +
        N'@ToDate='''  + CONVERT(NVARCHAR(19), @ToDate,   120) + N''', ' +
        N'@UserName=N''' + ISNULL(@UserName, N'admin') + N'''"' +  -- kết thúc tham số -Q
        N' -e -b -t 0 -o "' + @LogFile + N'"' +                     -- output ra file
        N'"';                                                       -- đóng dấu " của cmd /c

        -- Log và execute
        INSERT dbo.HR_TinhCongLogDetail(RunID,BatchID,Step,Info)
        VALUES (@RunID,@BatchID,N'SpawnCmd',N'Cmd='+@Cmd);
        
        PRINT N'>> Spawn Batch ' + CAST(@BatchID AS NVARCHAR(10));

        SET @Cmd_varchar = CONVERT(VARCHAR(8000), @Cmd);
        EXEC xp_cmdshell @Cmd_varchar, NO_OUTPUT;

        SET @BatchID += 1;
    END;

    -- 10) Chờ hoàn tất (tùy chọn)
    IF @WaitForCompletion = 1
    BEGIN
        DECLARE 
            @StartWait DATETIME = GETDATE(),
            @Deadline DATETIME = CASE WHEN @TimeoutMinutes IS NULL THEN NULL ELSE DATEADD(MINUTE, @TimeoutMinutes, GETDATE()) END,
            @Remaining INT,
            @Done INT,
            @Err INT;

        WHILE 1=1
        BEGIN
            SELECT
                @Remaining = SUM(CASE WHEN Status IS NULL OR Status = N'Running' THEN 1 ELSE 0 END),
                @Done      = SUM(CASE WHEN Status = N'Done' THEN 1 ELSE 0 END),
                @Err       = SUM(CASE WHEN Status = N'Error' THEN 1 ELSE 0 END)
            FROM dbo.HR_TinhCongBatchEmp
            WHERE RunID = @RunID;

            PRINT CONCAT(N'[', CONVERT(nvarchar(19), GETDATE(), 120), N'] Progress: Done=', @Done, 
                         N'; Error=', @Err, N'; Remaining=', @Remaining);

            IF @Remaining IS NULL SET @Remaining = 0; -- an toàn
            IF @Remaining = 0 BREAK;

            IF @Deadline IS NOT NULL AND GETDATE() > @Deadline
            BEGIN
                PRINT N'⏰ Hết thời gian chờ.';
                BREAK;
            END

            DECLARE @TargetTime DATETIME = DATEADD(SECOND, @PollSeconds, GETDATE());

            WAITFOR TIME @TargetTime;  
        END;

        PRINT N'✅ Tất cả batch đã hoàn tất (hoặc timeout).';

        -- Tổng kết phiên
        SELECT 
            RunID = @RunID,
            TotalEmp = @TotalEmp,
            Done = SUM(CASE WHEN Status = N'Done' THEN 1 ELSE 0 END),
            Error = SUM(CASE WHEN Status = N'Error' THEN 1 ELSE 0 END),
            DurationSec = DATEDIFF(SECOND, @StartWait, GETDATE())
        FROM dbo.HR_TinhCongBatchEmp
        WHERE RunID = @RunID;
    END
    ELSE
    BEGIN
        PRINT N'Đã spawn toàn bộ batch. Xem tiến độ tại HR_TinhCongBatchEmp/HR_TinhCongLog/HR_TinhCongLogDetail và C:\Temp\*.log';
    END
END

GO
