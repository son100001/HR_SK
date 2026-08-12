









CREATE FUNCTION [dbo].[udf_ConvertTime] ( @hh int, @mm int, @ss int, @eWpart nvarchar(10),@OT_Normal float,@OT_Night float )
RETURNS varchar(100)
AS
  BEGIN
  DECLARE @rtDate varchar(100)
  DECLARE @ss1 int
  DECLARE @ot int
	--Set @rtDate = CASE WHEN CAST(SubString (@myDateTime,4,2) as Int) > 44  THEN Cast( '16:44:' + CAST(Right(@myDateTime,2) as varchar) as varchar)  ELSE  CAST('16:' +  CAST(Right(@myDateTime,5) as varchar) as varchar)  END
	
		IF @eWpart = '1'
		BEGIN
			SET @ot = (@OT_Normal + @OT_Night ) * 3600
			SET @ss1 = @hh * 3600 + @mm * 60 + @ss
			SET @ss1 = @ss1 - @ot
				 
		    	SET @rtDate = (CASE WHEN @ss1/3600 < '10' THEN '0' ELSE '' END)
						+ RTRIM(@ss1/3600)
						+ ':' + RIGHT('0'+RTRIM((@ss1 % 3600) / 60),2) 
		    				+ ':' + RIGHT('0'+RTRIM((@ss1 % 3600) % 60),2)    	
		    	/*			 
			SET @rtDate = CASE 
			                   WHEN @mm > 44 THEN CAST('16:' AS nvarchar ) + CAST('44:' AS nvarchar) + CAST (dbo.ToString(@ss,'ss') AS nvarchar)
			                   ELSE CAST ('16:' AS nvarchar) + CAST (dbo.ToString(@mm,
			                   'mm') AS nvarchar)
			                   + ':'+CAST (dbo.ToString(@ss,'ss') AS nvarchar)
			END */
			
		END
			
		ELSE
			BEGIN
				SET @ot = @OT_Normal * 3600
				SET @ss1 = @hh * 3600 + @mm * 60 + @ss
				SET @ss1 = @ss1 - @ot
			
				SET @rtDate = (CASE WHEN @ss1/3600 < '10' THEN '0' ELSE '' END)
						+ RTRIM(@ss1/3600)
						+ ':' + RIGHT('0'+RTRIM((@ss1 % 3600) / 60),2) 
		    				+ ':' + RIGHT('0'+RTRIM((@ss1 % 3600) % 60),2)    	
			END		      
  RETURN @rtDate
  
END




	










































GO
