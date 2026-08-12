CREATE FUNCTION [dbo].[udf_BangThoiGian]
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime
)
--select * from udf_BangThoiGian ('2025-10-01','2025-10-31')
RETURNS @tabDate table (Date_ datetime primary key(Date_))
AS
BEGIN
	-- Declare the return variable here
	DECLARE @dtNext datetime

	-- Add the T-SQL statements to compute the return value here
	set @dtNext=@fromdate
	while @dtNext<=@todate
	begin
		insert into @tabDate (Date_) values(@dtNext)
		set @dtNext=@dtNext+1
	end

	-- Return the result of the function
	RETURN

END




GO
