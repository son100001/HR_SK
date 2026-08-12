






CREATE FUNCTION [dbo].[isLeave]( @FStatus varchar(100))
-- returns only the time portion of a DateTime, at the "base" date (1/1/1900)
returns bit
as
	BEGIN
	
		declare @status  bit 
		SET @status = CAST ('0' as bit)
  		IF @FStatus = 'BABY' OR @FStatus = 'PR7'
			SET @status = '0'
		ELSE	
			SET @status = '1'
		 return @status
	END
   	














GO
