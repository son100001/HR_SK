
CREATE FUNCTION [dbo].[udf_LamTron](@Value float, @GiaTriLamTronXuong as float, @GiaTriLamTronLen as float)
RETURNS float
            AS
    BEGIN
    DECLARE @PhanThapPhan VARCHAR(50);
    DECLARE @PhanNguyen INT;
    DECLARE @SoPhutLe VARCHAR(50);
    SET @PhanThapPhan =  CAST(@Value as nvarchar(50));
    DECLARE contact_cursor cursor scroll FOR
    SELECT Data FROM Split(@PhanThapPhan, '.')
    OPEN contact_cursor;
    FETCH ABSOLUTE 1 FROM contact_cursor into @PhanNguyen;
    FETCH ABSOLUTE 2 FROM contact_cursor into @SoPhutLe;
    CLOSE contact_cursor;
    DEALLOCATE contact_cursor;
    SET @SoPhutLe = cast('0.' + cast(@SoPhutLe as nvarchar(50)) as float)*60;
    return (Case when @SoPhutLe <= @GiaTriLamTronXuong then @PhanNguyen
		when @SoPhutLe > @GiaTriLamTronXuong and @SoPhutLe < @GiaTriLamTronLen then @PhanNguyen + 0.5
		when @SoPhutLe >= @GiaTriLamTronLen then @PhanNguyen + 1
		else @PhanNguyen end)
	END

 





GO
