-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[udf_TinhGioCongChiTiet]
(
	-- Add the parameters for the function here
	--select [dbo].[udf_TinhGioCongChiTiet]('2020-4-20 10:23:00','2020-4-20 12:18:00','2020-4-20 07:30:00','2020-4-20 16:30:00','2020-4-20 11:30:00','2020-4-20 12:30:00',NULL,0,0,0,30,'2020-4-20',0,'wt1')
	@TimeIn datetime, @TimeOut datetime,@ShiftFrom datetime,@ShiftTo datetime,@RestTimeFrom datetime, @RestTimeTo datetime
				,@isPushWorkingTime bit,@MinMinute int,@BlockMinute int,@BlockDownMinute int,@Round int
				,@WorkingDay datetime,@NumberOfDay int,@MaCong [nvarchar](50)
)
RETURNS float
AS
BEGIN
	--if dateadd(minute,-6,@TimeIn) > @ShiftFrom and isnull(@BlockDownMinute,0) <> 0 begin
	--	select @TimeIn = dateadd(Minute,floor((datediff(Minute, @ShiftFrom, dateadd(minute,-6,@TimeIn))/60.0 + @BlockMinute/60.0) *60.0/@BlockMinute) / (60.0/@BlockMinute) * 60.0,@ShiftFrom)
	--end
	--if @TimeOut < @ShiftTo and isnull(@BlockDownMinute,0) <> 0 begin
	--	select @TimeOut = dateadd(Minute,Ceiling((datediff(Minute, @ShiftFrom, @TimeOut) / 60.0 - @BlockMinute/60.0) *60.0/@BlockMinute) / (60.0/@BlockMinute) * 60.0,@ShiftFrom)
	--end
	return
	(case when @ShiftTo is null then
						[dbo].[udf_TinhGioCong](@TimeIn,@TimeOut
												,[dbo].[GhepGioVaoNgay](dateadd(day,@NumberOfDay,@WorkingDay),@ShiftFrom),null,null,null
												,@isPushWorkingTime,@MinMinute,@BlockMinute,@BlockDownMinute,@Round,@MaCong
												)
					when DATEPART(hour,@ShiftFrom)<DATEPART(hour,@ShiftTo) then
								[dbo].[udf_TinhGioCong](@TimeIn,@TimeOut
															,@ShiftFrom
															,@ShiftTo
															,@RestTimeFrom
															,@RestTimeTo
															,@isPushWorkingTime,@MinMinute,@BlockMinute,@BlockDownMinute,@Round,@MaCong
														)
					when @RestTimeFrom is null or @RestTimeTo is null then
							[dbo].[udf_TinhGioCong](@TimeIn,@TimeOut
														,@ShiftFrom
														,@ShiftTo
														,null,null
														,@isPushWorkingTime,@MinMinute,@BlockMinute,@BlockDownMinute,@Round,@MaCong
													)
						else
							[dbo].[udf_TinhGioCong](@TimeIn,@TimeOut
														,@ShiftFrom
														,@ShiftTo
														,@RestTimeFrom
														,@RestTimeTo
														,@isPushWorkingTime,@MinMinute,@BlockMinute,@BlockDownMinute,@Round,@MaCong
													)
						end)

END




GO
