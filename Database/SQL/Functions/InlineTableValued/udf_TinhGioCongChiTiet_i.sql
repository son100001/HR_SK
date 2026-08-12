CREATE   FUNCTION dbo.udf_TinhGioCongChiTiet_i(
    @TimeIn datetime, @TimeOut datetime,@ShiftFrom datetime,@ShiftTo datetime,@RestTimeFrom datetime, @RestTimeTo datetime
	,@isPushWorkingTime bit,@MinMinute int,@BlockMinute int,@BlockDownMinute int,@Round int
	,@WorkingDay datetime,@NumberOfDay int,@MaCong [nvarchar](50)
)
RETURNS TABLE
AS RETURN
    SELECT CAST(case when @ShiftTo is null then
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
						end AS float) AS WTMin;
GO
