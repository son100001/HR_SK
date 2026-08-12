CREATE FUNCTION ufn_RemoveDiacritics (@input NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @output NVARCHAR(MAX) = @input
    DECLARE @Accents NVARCHAR(MAX) = N'áàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴĐ'
    DECLARE @Plain NVARCHAR(MAX)   = N'aaaaaaaaaaaaaaaaaeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyydAAAAAAAAAAAAAAAAAEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYD'

    DECLARE @i INT = 1
    WHILE @i <= LEN(@Accents)
    BEGIN
        SET @output = REPLACE(@output, SUBSTRING(@Accents, @i, 1), SUBSTRING(@Plain, @i, 1))
        SET @i += 1
    END

    RETURN @output
END
GO
