







CREATE FUNCTION [dbo].[udf_DayOfWeek](@dtDate DATETIME)
RETURNS VARCHAR(10)
            AS
    BEGIN
    DECLARE @rtDayofWeek VARCHAR(10)
    DECLARE @weekDay INT
        -- Here I have subtracted 7 For keeping Sunday as the First day like wise for Monday we need to subtract 2 and so on
        SET @weekDay=((DATEPART(dw,@dtDate)+@@DATEFIRST-7)%7)
    SELECT @rtDayofWeek = CASE @weekDay
                    WHEN 1 THEN 'Sunday'
                    WHEN 2 THEN 'Monday'
                    WHEN 3 THEN 'Tuesday'
                    WHEN 4 THEN 'Wednesday'
                    WHEN 5 THEN 'Thursday'
                    WHEN 6 THEN 'Friday'
                    WHEN 0 THEN 'Saturday'
        END
    RETURN (@rtDayofWeek)
    END











GO
