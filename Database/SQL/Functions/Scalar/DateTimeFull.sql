
CREATE FUNCTION [dbo].[DateTimeFull]
(
	@Date as datetime,
	@Time as datetime
)
RETURNS DateTime
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result as datetime
	

    Set @Result = cast( convert(varchar, @Date, 101)+ dbo.TimeOnly(@Time) as datetime)

	RETURN @Result

END





GO
