CREATE FUNCTION dbo.RemoveVietnameseSigns_Short(@str NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Source NVARCHAR(500) = N'áàảãạăắằẳẵặâấầẩẫậđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ'
    DECLARE @Target NVARCHAR(500) = N'aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuueeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOUUUUUUUUEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOUUUUUUUUYYYYY'
    DECLARE @i INT = 1, @len INT = LEN(@Source)

    WHILE @i <= @len
    BEGIN
        SET @str = REPLACE(@str, SUBSTRING(@Source, @i, 1), SUBSTRING(@Target, @i, 1))
        SET @i = @i + 1
    END

    RETURN @str
END
GO
