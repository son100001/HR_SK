





--SELECT dbo.fn_GetPeriod('12/31/2009','LKEY')

CREATE FUNCTION [dbo].[fn_GetPeriod](@fromdate datetime,@Type nvarchar(10))
RETURNS nvarchar(10)
AS
BEGIN	
	DECLARE @mm AS int
	DECLARE @yy AS int
	DECLARE @str AS nvarchar(10)
	DECLARE @lstr AS nvarchar(10)
	DECLARE @Period AS nvarchar(10)
	DECLARE @LMM AS int
	DECLARE @LYY AS int
	DECLARE @Lastperiod AS nvarchar(10)
	DECLARE @dd AS nvarchar(10)
	
	SET @yy = year(@fromdate)
	SET @mm = month(@fromdate)	
	SET @dd = day(@fromdate)
	
	IF @mm = 1 
		BEGIN
			SET @LMM = 12
			SET @LYY = @yy - 1 
		END		
		
	IF @mm <> 1
		BEGIN
			SET @LMM = @mm - 1 
			SET @LYY = @yy	
		END		
			
	Set @str = case when @mm < 10 then  Cast ('0' as varchar) + cast (@mm as varchar) else cast (@mm as nvarchar) END
	SET @lstr = case when @LMM < 10 then  Cast ('0' as varchar) + cast (@LMM as varchar) else cast (@LMM as nvarchar) END
	Set @dd = case when @dd < 10 then  Cast ('0' as varchar) + cast (@dd as varchar) else cast (@dd as nvarchar) END
	
	IF @Type = 'CKEY' -- Ky nay
		SET @Period =  cast (@yy as varchar) + cast (@str as varchar)  + cast (@dd as varchar)
	IF @Type = 'LKEY' -- ky truoc
		SET @Period = cast (@LYY as varchar) + cast (@lstr as varchar) +  cast (@dd as varchar)
	
	RETURN(@Period) 
	--RETURN(@LYY)
END
















GO
