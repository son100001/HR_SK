/*
    ROLLBACK cho 2026-08-28_HR_SnK_Dev_Optimize_Split_inline.sql
    Khôi phục dbo.Split về đúng bản multi-statement TVF (WHILE loop) như trước ngày 2026-08-28 trên
    HR_SnK_Dev. Chỉ chạy khi cần quay lui - bản inline đã verify khớp 100% output (343 test case,
    EXCEPT 2 chiều lệch 0) và nhanh hơn 4,7-15x ở kịch bản gọi lặp.
    Nội dung dưới đây là bản gốc lấy nguyên văn từ sys.sql_modules của HR_SnK_Dev ngày 2026-08-28.
*/

IF OBJECT_ID('dbo.Split', 'IF') IS NOT NULL DROP FUNCTION [dbo].[Split];
IF OBJECT_ID('dbo.Split', 'TF') IS NOT NULL DROP FUNCTION [dbo].[Split];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE FUNCTION [dbo].[Split]
    (
      @RowData NVARCHAR(max) ,
      @SplitOn NVARCHAR(5)
    )
RETURNS @ReturnValue TABLE ( Data NVARCHAR(1000), order_ int )
AS
    BEGIN
        DECLARE @Counter INT
        SET @Counter = 1
        WHILE ( CHARINDEX(@SplitOn, @RowData) > 0 )
            BEGIN
                INSERT  INTO @ReturnValue
                        ( data, order_
                        )
                        SELECT  Data = LTRIM(RTRIM(SUBSTRING(@RowData, 1,
                                                             CHARINDEX(@SplitOn,
                                                              @RowData) - 1))), @Counter
                SET @RowData = SUBSTRING(@RowData,
                                         CHARINDEX(@SplitOn, @RowData) + 1,
                                         LEN(@RowData))
                SET @Counter = @Counter + 1
            END
        INSERT  INTO @ReturnValue
                ( data , order_ )
                SELECT  Data = LTRIM(RTRIM(@RowData)) , @Counter
        RETURN
    END
GO
