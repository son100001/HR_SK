-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[udf_TinhPhuCapCC]
(
	-- select * from udf_TongHopPhep('2022-07-01','2022-07-31',1) where Employee_ID = '22062104'
	-- select * from udf_DiTreVeSomVaXinRaNgoai ('2022-07-01','2022-07-31','VN',null,null,null,null,null,null,null) dtvs where Employee_ID = '22062104'
	-- select Employee_ID,isnull(SoLanDiTreVeSom,0)+isnull(SoLanXinRaNgoai,0) as SoLanDMVS_NghiKL from [dbo].[udf_DiTreVeSomVaXinRaNgoai]('2022-04-01','2022-04-30','VN',NULL,NULL,NULL,NULL,NULL,NULL,NULL) where Employee_ID = '21111941'
	-- select dbo.udf_TinhPhuCapCC(8,0,0,0,8,0,0,0,0,0,0,0,5,3,500000)
	-- Add the parameters for the function here
	@KhongPhep float,
	@TS float,
	@DS float,
	@PN2 float,
	@P1 float,
	@P float,
	@PB float,
	@PB1 float,
	@PB2 float,
	@PKT float,
	@PKT1 float,
	@NghiDich float,
	@SoLanDMVS_NghiKL float,
	@SoLanQuenQuetVanTay float,
	@PhuCapCCToiDa float
)
RETURNS float
AS
BEGIN
	-- Declare the return variable here
	declare @TruCC float
	-- Add the T-SQL statements to compute the return value here
	set @TruCC=(case when isnull(@KhongPhep,0)+isnull(@TS,0)+isnull(@DS,0)>0 
			or isnull(@PN2,0)+isnull(@P1,0)>=16
			or isnull(@P,0)>=24
			or isnull(@PB1,0)>=16
			or isnull(@PB2,0)>=48
			or isnull(@PKT,0)>=24
			or isnull(@PKT1,0)>=16
			or isnull(@NghiDich,0)>56
	then isnull(@PhuCapCCToiDa,0)
  else 
	(case when isnull(@PN2,0)+isnull(@P1,0)>1 then (isnull(@PhuCapCCToiDa,0)*(isnull(@PN2,0)+isnull(@P1,0))/8.0)/2.0 else 0 end)
	+(case when isnull(@P,0)>=16 then 200000 when isnull(@P,0) >=8 then 100000 else 0 end)
	+(case when isnull(@PB,0)>=16 then 100000 else 0 end)
	+(case when isnull(@PB1,0)>=8 then 100000 else 0 end)
	+(case when isnull(@PB2,0)>=40 then 200000 when isnull(@PB2,0) >= 32 then 100000 else 0 end)
	+(case when isnull(@PKT,0)>=16 then 100000 else 0 end)
	+(case when isnull(@PKT1,0)>=8 then isnull(@PhuCapCCToiDa,0)/2.0 else 0 end)
	+isnull(@PhuCapCCToiDa,0)*isnull(@SoLanDMVS_NghiKL,0)/10.0
	+ isnull(@SoLanQuenQuetVanTay,0) * 20000
  end)

	-- Return the result of the function
	RETURN case when @TruCC>@PhuCapCCToiDa then @PhuCapCCToiDa else @TruCC end
	

END

GO
