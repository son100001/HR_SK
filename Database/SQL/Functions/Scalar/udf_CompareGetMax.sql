create function [dbo].[udf_CompareGetMax]
(
	@Number1 float,
	@Number2 float
)
returns float
as
begin
	Declare @Result float
	if @Number1 >= @Number2
		set @Result = @Number1
	else
		set @Result = @Number2
	return @Result
end
GO
