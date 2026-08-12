--làm tròn công sau khi đã tính xong công.
CREATE FUNCTION [dbo].[udf_LamTronGioCong](@TongCongTheoPhut int,@SoPhutTrongBlockDuocTinhXuong int,@SoPhutBlock int)
RETURNS int
            AS
    BEGIN
		return 
			(case when isnull(@SoPhutBlock,0)=0 then @TongCongTheoPhut else
				(case when @TongCongTheoPhut%@SoPhutBlock<=@SoPhutTrongBlockDuocTinhXuong
					then @TongCongTheoPhut-@TongCongTheoPhut%@SoPhutBlock
					else @TongCongTheoPhut+@SoPhutBlock-@TongCongTheoPhut%@SoPhutBlock
				end)
			end)
	END

 
 --select [dbo].[udf_LamTronGioCong](52,10,15)




GO
