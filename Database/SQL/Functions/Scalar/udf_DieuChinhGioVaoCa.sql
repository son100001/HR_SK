
CREATE FUNCTION [dbo].[udf_DieuChinhGioVaoCa](@TenCa nvarchar(50), @QuetVao datetime, @GioVaoCaHienTai datetime)
RETURNS datetime
            AS
    BEGIN
		return 
			(case when (@TenCa = 'CaMacDinh1' or @TenCa = 'CaMacDinh') and @QuetVao < DATEADD(minute,-30,@GioVaoCaHienTai)
					then dateadd(minute,-90,@GioVaoCaHienTai)
					else @GioVaoCaHienTai
			end)
	END

 





GO
