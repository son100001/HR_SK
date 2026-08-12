CREATE FUNCTION [dbo].[NewDate]     
(
@year int,
@month int,
@day int
)      
RETURNS datetime      
AS     

	begin
		declare @date datetime
		SELECT @date =  CAST(CONVERT(VARCHAR, @year) + '-' + CONVERT(VARCHAR, @month) + '-' + CONVERT(VARCHAR, @day)
		AS DATETIME)

		return @date
	end




GO
