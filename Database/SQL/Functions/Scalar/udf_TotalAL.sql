






-- select dbo.udf_TotalAL ('01/01/2008','01/31/2009','16','7060001')

CREATE FUNCTION [dbo].[udf_TotalAL](@StartedDate datetime, @todate datetime, @ALDay float, @Employee_ID nvarchar(100))
RETURNS int
as
	BEGIN
	
		DECLARE @totalAL float 
		DECLARE @bonus int
		DECLARE @sonam int
		DECLARE @first_date_of_year datetime
		--DECLARE @leave int
		DECLARE @key nvarchar(100)
		--DECLARE @runmonth INT
		DECLARE @bitru INT

		
		 -- key cua thang can chk tong so ngay nghi/ neu sai thi truyen them bien ngay cua thang can chk		
		SET @key = dbo.fn_getperiod(@todate,'CKEY')
		SET @totalAL = 0
		SET @bonus = 0
		SET @sonam = Datediff(year,@StartedDate,@todate)
		SET @first_date_of_year = CONVERT(datetime,N'1/1/' + cast(year(@todate) AS nvarchar),103)
		
		IF @ALDay = '0' OR @ALDay IS null
			SET @ALDay = 12
  		IF Datediff(MONTH,@StartedDate,@todate)>= 60
  			BEGIN
  	  			SET @bonus = @sonam/5
	  			SET @ALDay = @ALDay + @bonus
			END
		IF @first_date_of_year < @StartedDate
			SET @totalAL = round(datediff(day,@StartedDate,@todate) / 365.0 * @ALDay, 0)
		ELSE
			SET @totalAL = round(datediff(day,@first_date_of_year,@todate) / 365.0 * @ALDay, 0)
			
		--tru di so ngay bi tru do nghi qua 15 ngay/thang
		SELECT
			@bitru = ISNULL(SUM(ha.ALMinus), 0)
		FROM
			HR_ALMinus ha
		WHERE
			ha.Employee_ID = @Employee_ID
			AND ha.ALYear = YEAR(@todate)
		
		/*
		SET @runmonth=1
		SET @bitru=0
		
		WHILE @runmonth<=MONTH(@todate)
		BEGIN
			SELECT @leave = count(sbtkd.Leave_NonPaid)
			FROM SmartBooks_TimeKeeping_Date sbtkd
			WHERE 	
				sbtkd.Leave_Type NOT IN ('MAT-IN') 
				AND sbtkd.Leave_NonPaid = 1
				AND sbtkd.Employee_ID = @Employee_ID
				AND YEAR(sbtkd.OT_date)=YEAR(@todate)
				AND MONTH(sbtkd.OT_date)=@runmonth
			
			IF @leave > 15 SET @bitru = @bitru + 1
			SET @runmonth = @runmonth +1
		END
		*/

		SET @totalAL = @totalAL - @bitru
		
  		RETURN @totalAL
	END













GO
