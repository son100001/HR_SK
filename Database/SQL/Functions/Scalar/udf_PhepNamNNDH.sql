--select dbo.udf_PhepNamNNDH ('2022-07-31','18050852','2018-06-28')
CREATE FUNCTION [dbo].[udf_PhepNamNNDH](@NgayHienTai datetime, @Employee_ID nvarchar(50), @OfficialDate datetime)
RETURNS float
            AS
    BEGIN
		declare @PhepNamNNDH int
		select @PhepNamNNDH = isnull(AnnualLeaveDays,12) - case when isnull(AnnualLeaveDays,12) >= 14 and datediff(month,empl.StartedDate,@NgayHienTai) < 10 then 1 else 0 end
		from 
		udf_TraVeBangTransfer_Horizontal (@OfficialDate,@Employee_ID) tf
		left join
		SmartBooks_Position pos
		on tf.Position_ID = pos.Position_ID
		left join
		SmartBooks_Employee empl
		on tf.Employee_ID = empl.Employee_ID
		where tf.Employee_ID = @Employee_ID
		--HR_Transfer tf
		/*left join
		SmartBooks_Position pos
		on tf.TransferCode = pos.Position_ID
		where tf.Employee_ID = @Employee_ID and tf.TypeOfTransfer = 'Position_ID' and EffectiveDate <= @NgayHienTai
		order by EffectiveDate*/
		return @PhepNamNNDH
	END


	--select [dbo].[udf_CountMont]('2016-7-15','2017-1-17')




GO
