CREATE FUNCTION [dbo].[udf_TraVeNgayHetHanHD]
(
	-- Add the parameters for the function here
	--select [dbo].[udf_TraVeNgayHetHanHD]('2019-7-23',6,0,0,1)
	--select dateadd(day,6,'2019-9-3')-1
	@CL_Startdate datetime,
	@NumberOfDay int,
	@NumberOfMonth int,
	@NumberOfYear int,
	@isOnlyWorkingDay bit
)
RETURNS datetime
AS
BEGIN
	-- Declare the return variable here
	DECLARE @CL_ExpiredDate datetime
	if @NumberOfYear is null and @NumberOfMonth is null and @NumberOfDay is null begin
		set @CL_ExpiredDate=null
	end else begin
		if isnull(@NumberOfDay,0)>0 begin
			set @CL_ExpiredDate=dateadd(day,isnull(@NumberOfDay,0),@CL_Startdate)-1
			if isnull(@isOnlyWorkingDay,0)=1 begin
				while [dbo].[udf_CountWorkingDay](@CL_StartDate,@CL_ExpiredDate)<@NumberOfDay begin
					set @CL_ExpiredDate=@CL_ExpiredDate+1
				end
				--set @CL_ExpiredDate=@CL_ExpiredDate+1
			end
		end else begin
			set @CL_ExpiredDate=@CL_StartDate
		end
		set @CL_ExpiredDate=dateadd(year,isnull(@NumberOfYear,0),dateadd(month,isnull(@NumberOfMonth,0),@CL_ExpiredDate))- (case when isnull(@NumberOfDay,0)>0 then 0 else 1 end)
	end

	-- Return the result of the function
	RETURN @CL_ExpiredDate

END




GO
