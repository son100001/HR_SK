CREATE FUNCTION [dbo].[udf_SoNgayPhepNam]
(
	-- Add the parameters for the function here
	@NamThamNien float,
	@ThangThamNienLe float,
	@SoNgayPNTheoQuyDinh float
)
RETURNS float
AS
BEGIN

	-- Return the result of the function
	RETURN round(case
					when @SoNgayPNTheoQuyDinh=0 then 0
					when @NamThamNien<=0 then @ThangThamNienLe*@SoNgayPNTheoQuyDinh/12
					when @NamThamNien<5 then @SoNgayPNTheoQuyDinh
					when @NamThamNien>=5 and @NamThamNien<10 then @SoNgayPNTheoQuyDinh+1
					when @NamThamNien>=10 and @NamThamNien<15 then @SoNgayPNTheoQuyDinh+2
					when @NamThamNien>=15 and @NamThamNien<20 then @SoNgayPNTheoQuyDinh+3
					when @NamThamNien=20 then @SoNgayPNTheoQuyDinh+4
				end,0)

END



GO
