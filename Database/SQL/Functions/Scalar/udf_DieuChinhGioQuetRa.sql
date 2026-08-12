--select dbo.[udf_DieuChinhGioQuetRa] ('2022-05-01 16:29:00', '2022-05-01 16:30:00',20,30,61,
CREATE FUNCTION [dbo].[udf_DieuChinhGioQuetRa](@QuetRa datetime, @GioTanCa datetime, @SoPhutKhongDuocTinhTangCa int, @SoPhutTrongBlockDuocTinhXuong int, @SoPhutBlock int,@AllowEarlyOut int)
RETURNS datetime
            AS
    BEGIN
		if Datepart(Hour, @QuetRa) in (16,17,19) and Datepart(Minute,@QuetRa) = 29
			set @QuetRa = dateadd(Minute,1,@QuetRa)
		return 
			(case when @QuetRa between dateadd(MINUTE,-@AllowEarlyOut,@GioTanCa) and dateadd(MINUTE,@SoPhutKhongDuocTinhTangCa,@GioTanCa) then @GioTanCa else
							(case when isnull(@SoPhutBlock,0)=0 then @QuetRa else
							(case when DATEPART(minute,@QuetRa)%@SoPhutBlock<=@SoPhutTrongBlockDuocTinhXuong then DATEADD(minute,0-DATEPART(minute,@QuetRa)%@SoPhutBlock,@QuetRa) else
							 DATEADD(minute,@SoPhutBlock-DATEPART(minute,@QuetRa)%@SoPhutBlock,@QuetRa)
							end)end)end)
	END




GO
