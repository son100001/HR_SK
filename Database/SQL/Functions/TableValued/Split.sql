
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
