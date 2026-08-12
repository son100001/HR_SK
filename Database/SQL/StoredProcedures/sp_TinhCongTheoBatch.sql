CREATE   PROCEDURE [dbo].[sp_TinhCongTheoBatch]
(
    @RunID UNIQUEIDENTIFIER,
    @BatchID INT,
    @FromDate DATETIME,
    @ToDate DATETIME,
    @UserName NVARCHAR(50)
)
AS
BEGIN
    SET NOCOUNT ON;

    PRINT '==========================================';
    PRINT CONCAT('🔹 BẮT ĐẦU BatchID = ', @BatchID, ' | RunID = ', @RunID);
    PRINT CONCAT('📅 From = ', CONVERT(nvarchar(19), @FromDate, 120),
                 ' | To = ', CONVERT(nvarchar(19), @ToDate, 120),
                 ' | User = ', @UserName);

    -- Đảm bảo bảng log chi tiết tồn tại
    IF OBJECT_ID('dbo.HR_TinhCongLogDetail','U') IS NULL
    BEGIN
        CREATE TABLE dbo.HR_TinhCongLogDetail
        (
            ID INT IDENTITY(1,1) PRIMARY KEY,
            RunID UNIQUEIDENTIFIER NOT NULL,
            BatchID INT NOT NULL,
            Employee_ID NVARCHAR(50) NULL,
            Step NVARCHAR(50) NOT NULL,
            LogTime DATETIME NOT NULL CONSTRAINT DF_HR_TinhCongLogDetail_LogTime DEFAULT (GETDATE()),
            Info NVARCHAR(MAX) NULL
        );
        CREATE INDEX IX_HR_TinhCongLogDetail_RunBatch ON dbo.HR_TinhCongLogDetail (RunID, BatchID, ID);
    END;

    DECLARE @BatchStart DATETIME = GETDATE();
    DECLARE @EmpID NVARCHAR(50);
    DECLARE @TotalInBatch INT, @i INT = 0;

    SELECT @TotalInBatch = COUNT(*) 
    FROM dbo.HR_TinhCongBatchEmp
    WHERE RunID = @RunID AND BatchID = @BatchID;

    PRINT CONCAT('👥 Tổng số nhân viên trong batch: ', @TotalInBatch);

    INSERT dbo.HR_TinhCongLogDetail(RunID,BatchID,Employee_ID,Step,Info)
    VALUES (@RunID,@BatchID,NULL,N'BatchStart',
            CONCAT('From=',CONVERT(nvarchar(19),@FromDate,120),
                   '; To=',CONVERT(nvarchar(19),@ToDate,120),
                   '; User=',ISNULL(@UserName,N''), 
                   '; TotalInBatch=',@TotalInBatch));

    DECLARE cur CURSOR LOCAL FAST_FORWARD FOR
        SELECT Employee_ID
        FROM dbo.HR_TinhCongBatchEmp
        WHERE RunID = @RunID AND BatchID = @BatchID
        ORDER BY SeqNo;

    OPEN cur;
    FETCH NEXT FROM cur INTO @EmpID;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @i += 1;
        PRINT '------------------------------------------';
        PRINT CONCAT('👤 [', @i, '/', @TotalInBatch, '] Đang tính công cho nhân viên: ', @EmpID);

        DECLARE @WT_Before INT, @WT_After INT, @WT_Added INT;
        DECLARE @TiTo_Before INT, @TiTo_After INT, @TiTo_Added INT;

        BEGIN TRY
            UPDATE dbo.HR_TinhCongBatchEmp
               SET Status = N'Running', StartTime = GETDATE(), Message = CONCAT(N'IdxInBatch=',@i,N'/',@TotalInBatch)
             WHERE RunID = @RunID AND BatchID = @BatchID AND Employee_ID = @EmpID;

            INSERT INTO dbo.HR_TinhCongLog (RunID, BatchID, Employee_ID, StartTime, Status, Message)
            VALUES (@RunID, @BatchID, @EmpID, GETDATE(), N'Running', CONCAT(N'IdxInBatch=',@i,N'/',@TotalInBatch));

            SELECT @WT_Before = COUNT(*) 
              FROM HR_WTDaily 
             WHERE Employee_ID=@EmpID AND Ngay BETWEEN @FromDate AND @ToDate;

            SELECT @TiTo_Before = COUNT(*)
              FROM HR_TimeIn_TimeOut 
             WHERE Employee_ID=@EmpID AND OT_Date BETWEEN @FromDate AND @ToDate;

            PRINT CONCAT('🔸 Trước khi tính: WTDaily=', ISNULL(@WT_Before,0), 
                         ' | TimeInOut=', ISNULL(@TiTo_Before,0));

            INSERT dbo.HR_TinhCongLogDetail(RunID,BatchID,Employee_ID,Step,Info)
            VALUES (@RunID,@BatchID,@EmpID,N'EmpStart',
                    CONCAT('IdxInBatch=',@i,'/',@TotalInBatch,
                           '; WT_before=',ISNULL(@WT_Before,0),
                           '; TiTo_before=',ISNULL(@TiTo_Before,0)));

            -- GỌI STORE CHÍNH
            PRINT '⚙️ Gọi sp_TinhCong...';
            EXEC dbo.sp_TinhCong @FromDate, @ToDate, @UserName, N'', N'', N'', N'', N'', N'', @EmpID;

            SELECT @WT_After = COUNT(*) 
              FROM HR_WTDaily 
             WHERE Employee_ID=@EmpID AND Ngay BETWEEN @FromDate AND @ToDate;

            SELECT @TiTo_After = COUNT(*)
              FROM HR_TimeIn_TimeOut 
             WHERE Employee_ID=@EmpID AND OT_Date BETWEEN @FromDate AND @ToDate;

            SET @WT_Added   = ISNULL(@WT_After,0)   - ISNULL(@WT_Before,0);
            SET @TiTo_Added = ISNULL(@TiTo_After,0) - ISNULL(@TiTo_Before,0);

            PRINT CONCAT('✅ Hoàn tất nhân viên: ', @EmpID, 
                         ' | WT +', @WT_Added, ' (', @WT_After, ')',
                         ' | TITO +', @TiTo_Added, ' (', @TiTo_After, ')');

            INSERT dbo.HR_TinhCongLogDetail(RunID,BatchID,Employee_ID,Step,Info)
            VALUES (@RunID,@BatchID,@EmpID,N'EmpDone',
                    CONCAT('IdxInBatch=',@i,'/',@TotalInBatch,
                           '; WT_added=',@WT_Added, '; WT_total=',ISNULL(@WT_After,0),
                           '; TiTo_added=',@TiTo_Added, '; TiTo_total=',ISNULL(@TiTo_After,0)));

            UPDATE dbo.HR_TinhCongBatchEmp
               SET Status = N'Done', EndTime = GETDATE(), 
                   Message = CONCAT(ISNULL(Message,N''), '; WT+',@WT_Added, '; TiTo+',@TiTo_Added)
             WHERE RunID = @RunID AND BatchID = @BatchID AND Employee_ID = @EmpID;

            UPDATE dbo.HR_TinhCongLog
               SET EndTime = GETDATE(), Status = N'Done',
                   Message = CONCAT(ISNULL(Message,N''), '; WT+', @WT_Added, '; TiTo+', @TiTo_Added)
             WHERE RunID = @RunID AND BatchID = @BatchID AND Employee_ID = @EmpID;
        END TRY
        BEGIN CATCH
            PRINT CONCAT('❌ LỖI nhân viên: ', @EmpID, ' | ', ERROR_MESSAGE());

            INSERT dbo.HR_TinhCongLogDetail(RunID,BatchID,Employee_ID,Step,Info)
            VALUES (@RunID,@BatchID,@EmpID,N'EmpError',
                    CONCAT('IdxInBatch=',@i,'/',@TotalInBatch,
                           '; Err=',ERROR_NUMBER(),'|',ERROR_SEVERITY(),'|',ERROR_STATE(),
                           '; Msg=',ERROR_MESSAGE()));

            UPDATE dbo.HR_TinhCongBatchEmp
               SET Status = N'Error', EndTime = GETDATE(), Message = ERROR_MESSAGE()
             WHERE RunID = @RunID AND BatchID = @BatchID AND Employee_ID = @EmpID;

            UPDATE dbo.HR_TinhCongLog
               SET EndTime = GETDATE(), Status = N'Error', Message = ERROR_MESSAGE()
             WHERE RunID = @RunID AND BatchID = @BatchID AND Employee_ID = @EmpID;
        END CATCH;

        FETCH NEXT FROM cur INTO @EmpID;
    END

    CLOSE cur;
    DEALLOCATE cur;

    -- Tổng kết batch
    DECLARE @EmpDone INT, @EmpErr INT;
    SELECT 
        @EmpDone = SUM(CASE WHEN Status = N'Done' THEN 1 ELSE 0 END),
        @EmpErr  = SUM(CASE WHEN Status = N'Error' THEN 1 ELSE 0 END)
    FROM dbo.HR_TinhCongBatchEmp
    WHERE RunID=@RunID AND BatchID=@BatchID;

    PRINT '------------------------------------------';
    PRINT CONCAT('🏁 KẾT THÚC Batch ', @BatchID, 
                 ' | Hoàn thành: ', ISNULL(@EmpDone,0),
                 ' | Lỗi: ', ISNULL(@EmpErr,0),
                 ' | Thời gian: ', DATEDIFF(SECOND,@BatchStart,GETDATE()), 's');

    INSERT dbo.HR_TinhCongLogDetail(RunID,BatchID,Employee_ID,Step,Info)
    VALUES (@RunID,@BatchID,NULL,N'BatchDone',
            CONCAT('DurationSec=',DATEDIFF(SECOND,@BatchStart,GETDATE()),
                   '; EmpDone=',ISNULL(@EmpDone,0),
                   '; EmpErr=',ISNULL(@EmpErr,0)));

    UPDATE dbo.HR_TinhCongLog
       SET EndTime = GETDATE(),
           Status  = CASE WHEN ISNULL(@EmpErr,0) > 0 THEN N'DoneWithErrors' ELSE N'Done' END,
           Message = CONCAT(ISNULL(Message,N''), 
                            '; DurationSec=',DATEDIFF(SECOND,@BatchStart,GETDATE()),
                            '; EmpDone=',ISNULL(@EmpDone,0),
                            '; EmpErr=',ISNULL(@EmpErr,0))
     WHERE RunID=@RunID AND BatchID=@BatchID AND Employee_ID IS NULL;

    PRINT '==========================================';
END

GO
