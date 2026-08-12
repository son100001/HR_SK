






CREATE FUNCTION [dbo].[ToString](@number int, @type varchar(100))
-- returns only the time portion of a DateTime, at the "base" date (1/1/1900)
returns varchar(100)
as
	 begin   
  		 declare @chuoi varchar(100)
			IF @type = 'mm'
				BEGIN
				Set @chuoi = case when @number >= 30  then   cast (@number as varchar) else cast ('35' as nvarchar) end
				 
				END
	 		ELSE
				BEGIN
				 Set @chuoi = case when @number < 10 then  Cast ('0' as varchar) + cast (@number as varchar) else cast (@number as nvarchar) end
				END 
		
		 return @chuoi
   	 end













GO
