






CREATE FUNCTION [dbo].[TimeOnly](@DateTime DateTime)
-- returns only the time portion of a DateTime, at the "base" date (1/1/1900)
returns datetime
as
    begin
    return @DateTime - dbo.DateOnly(@DateTime)
    end










GO
