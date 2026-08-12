
CREATE FUNCTION [dbo].[udf_DieuChinhGioQuetVao](@QuetVao datetime, @GioVaoCa datetime, @SoPhutMuonDuocTinhDungGio int, @SoPhutTrongBlockDuocTinhXuong int, @SoPhutBlock int)
RETURNS datetime
            AS
    BEGIN
		return 
			(case when @QuetVao < dateadd(second,59,@GioVaoCa) then @GioVaoCa else
							(case when @QuetVao <= DATEADD(minute,@SoPhutMuonDuocTinhDungGio,@GioVaoCa) then @GioVaoCa else
							(case when isnull(@SoPhutBlock,0)=0 then @QuetVao else
							(case when DATEPART(minute,@QuetVao)%@SoPhutBlock<=@SoPhutTrongBlockDuocTinhXuong then DATEADD(minute,0-DATEPART(minute,@QuetVao)%@SoPhutBlock,@QuetVao) else
							 DATEADD(minute,@SoPhutBlock-DATEPART(minute,@QuetVao)%@SoPhutBlock,@QuetVao)
							end)end)end)end)
	END

 





GO
