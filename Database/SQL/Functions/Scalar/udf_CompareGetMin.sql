create function [dbo].[udf_CompareGetMin]
(
	@Number1 float,
	@Number2 float
)
returns float
as
begin
	return case when @Number1 >= @Number2 then @Number2 else @Number1 end
end
GO
