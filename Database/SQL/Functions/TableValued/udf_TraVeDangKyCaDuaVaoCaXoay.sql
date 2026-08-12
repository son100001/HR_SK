CREATE FUNCTION [dbo].[udf_TraVeDangKyCaDuaVaoCaXoay]
(
	-- Add the parameters for the function here
	--select * from udf_TraVeDangKyCaDuaVaoCaXoay('2019-9-1','2019-9-30',null,null,null,null,null,null,null) order by Employee_ID,TimeDate
	--select * from udf_TraVeDangKyCaDuaVaoCaXoay('2021-02-1','2021-02-28',null,null,null,null,null,null,'cg00354')
	@fromdate datetime,
	@todate datetime,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Empl nvarchar(50)=null
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),[TimeDate] datetime,[ShiftName] nvarchar(50),ExtraHours float,GioTCTruoc float,primary key ([Employee_ID],[TimeDate])

)
AS
BEGIN
	declare @Employee_ID nvarchar(50),@dnext datetime,@dRoundStartedDate datetime,@dOldRoundEndDate datetime,@FD datetime, @TD datetime,@MinFD datetime, @ShiftName nvarchar(50),@RoundShiftName nvarchar(50), @RoundCode varchar(50),@RoundDays int,@RoundMonths int,@MaxRoundOrder int,@RoundOrder int
		,@ExtraHours float,@GioTCTruoc float
	DECLARE cur CURSOR LOCAL FOR
	select rs.Employee_ID,(case when CHARINDEX(' ', ShiftName)=0 then rs.ShiftName else RIGHT(rs.ShiftName,LEN(rs.ShiftName)-3) end) as ShiftName
	,rs.FromDate,rs.ToDate,rsmin.FromDate as minFromDate
	,(case when CHARINDEX(' ', ShiftName)=0 then null else LEFT(ShiftName, 2) end) as RoundCode
	,rs.ExtraHours,rs.GioTCTruoc
	from
	HR_RoundShift rs
	left join
	(select Employee_ID,max(FromDate) as FromDate from HR_RoundShift where FromDate<=@fromdate and (ToDate is null or ToDate>=@todate) group by Employee_ID) rsmin
	on rs.Employee_ID=rsmin.Employee_ID
	where rs.Employee_ID in (select Employee_ID from udf_EmployeeFilter('VN',@fact,@dept,@sect,@team,@pos,@posc,@Empl,@todate))
	order by rs.Employee_ID,rs.TypeOfRegister,rs.FromDate
	OPEN  cur
	FETCH NEXT FROM cur INTO @Employee_ID,@ShiftName,@FD,@TD,@MinFD,@RoundCode,@ExtraHours,@GioTCTruoc
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if @FD>=@MinFD or @MinFD is null begin
			if @RoundCode is not null begin --xử lý ca xoay
				select @RoundOrder=RoundOrder,@RoundDays=RoundDays from HR_RoundShiftDetail where ShiftName=@ShiftName and RoundCode=@RoundCode
				select @MaxRoundOrder=max(RoundOrder) from HR_RoundShiftDetail where RoundCode=@RoundCode
				set @dRoundStartedDate=(case when DATENAME(WEEKDAY,@FD)='Monday' then @FD
								when DATENAME(WEEKDAY,@FD)='Tuesday' then @FD-1
								when DATENAME(WEEKDAY,@FD)='Wednesday' then @FD-2
								when DATENAME(WEEKDAY,@FD)='Thursday' then @FD-3
								when DATENAME(WEEKDAY,@FD)='Friday' then @FD-4
								when DATENAME(WEEKDAY,@FD)='Saturday' then @FD-5
								when DATENAME(WEEKDAY,@FD)='Sunday' then @FD-6
							end)
				while @dRoundStartedDate+@RoundDays<@fromdate begin
					set @dRoundStartedDate=@dRoundStartedDate+@RoundDays
					if @RoundOrder=@MaxRoundOrder begin
						set @RoundOrder=1
					end else begin
						set @RoundOrder=@RoundOrder+1
					end
					select @RoundDays=RoundDays from HR_RoundShiftDetail where ShiftName=@ShiftName and RoundCode=@RoundCode
				end
				set @dOldRoundEndDate=@dRoundStartedDate
				while @RoundOrder<=@MaxRoundOrder begin
					select @RoundDays=RoundDays,@RoundShiftName=ShiftName from HR_RoundShiftDetail where RoundCode=@RoundCode and RoundOrder=@RoundOrder
					if @dRoundStartedDate+@RoundDays>=@fromdate begin
						if @dRoundStartedDate+@RoundDays=@fromdate begin
							select @RoundDays=RoundDays,@RoundShiftName=ShiftName from HR_RoundShiftDetail where RoundCode=@RoundCode and RoundOrder=(case when @RoundOrder>1 then @RoundOrder-1 else @MaxRoundOrder end)
						end
						set @dnext=@dRoundStartedDate+@RoundDays
						while @dnext between (case when @dOldRoundEndDate<@fromdate then @fromdate else @dOldRoundEndDate end) and (case when @dOldRoundEndDate+@RoundDays<=@todate then @dOldRoundEndDate+@RoundDays else @todate+@RoundDays end) begin
							--if @dnext between @fromdate and @todate and @dnext>=@FD and DATENAME(WEEKDAY,@dnext)<>'Sunday' and not exists(select H_date from [dbo].[SmartBooks_HolidaysPlan] where H_date=@dnext) begin
								if exists (select * from @rtnTable where [Employee_ID]=@Employee_ID and TimeDate=@dnext)
								BEGIN
									update @rtnTable set ShiftName=@RoundShiftName where [Employee_ID]=@Employee_ID and TimeDate=@dnext
								END ELSE IF not exists (select * from @rtnTable where [Employee_ID]=@Employee_ID and TimeDate=@dnext)
								BEGIN
									insert into @rtnTable([Employee_ID],[TimeDate],[ShiftName]) values(@Employee_ID,@dnext,@RoundShiftName)
								END
							--end
							set @dnext=@dnext-1
						end
					end
					if @RoundOrder=@MaxRoundOrder and @dOldRoundEndDate<@todate begin
						set @RoundOrder=1
					end else begin
						set @RoundOrder=@RoundOrder+1
					end
					set @dOldRoundEndDate=(case when @dRoundStartedDate+@RoundDays<=@todate then @dRoundStartedDate+@RoundDays else @todate end)
					set @dRoundStartedDate=@dRoundStartedDate+@RoundDays
				end
			end else begin-- xử lý không phải ca xoay
				if @FD>=@fromdate begin
					set @dnext=@FD
				end else begin
					set @dnext=@fromdate
				end
				if @TD is null or @TD>@todate begin
					set @TD=@todate
				end
				while @dnext<=@TD begin
					--if DATENAME(WEEKDAY,@dnext)<>'Sunday' begin and not exists(select H_date from [dbo].[SmartBooks_HolidaysPlan] where H_date=@dnext) begin
						if exists (select * from @rtnTable where [Employee_ID]=@Employee_ID and TimeDate=@dnext)
						BEGIN
							update @rtnTable set ShiftName=@ShiftName,ExtraHours=@ExtraHours,GioTCTruoc=@GioTCTruoc where [Employee_ID]=@Employee_ID and TimeDate=@dnext
						END ELSE IF not exists (select * from @rtnTable where [Employee_ID]=@Employee_ID and TimeDate=@dnext)
						BEGIN
							insert into @rtnTable([Employee_ID],[TimeDate],[ShiftName],ExtraHours,GioTCTruoc) values(@Employee_ID,@dnext,@ShiftName,@ExtraHours,@GioTCTruoc)
						END
					--end
					set @dnext=@dnext+1
				end
			end
			
		end
	FETCH NEXT FROM cur INTO @Employee_ID,@ShiftName,@FD,@TD,@MinFD,@RoundCode,@ExtraHours,@GioTCTruoc
	END
	CLOSE cur
	DEALLOCATE cur

	--xet ca chu nhat
	--insert into @rtnTable([Employee_ID],[TimeDate],[ShiftName])
	--select Employee_ID,workingdate,ShiftName from HR_MaxOvertime where TypeOfOT in ('4','5') and workingdate between @fromdate and @todate
	--and Employee_ID in (select Employee_ID from udf_EmployeeFilter('VN',@fact,@dept,@sect,@team,@pos,@posc,@Empl,@todate))

	update rt set rt.[ShiftName]=mot.ShiftName
	from
	@rtnTable rt
	inner join
	HR_MaxOvertime mot
	on rt.Employee_ID=mot.Employee_ID and rt.[TimeDate]=mot.workingdate
	where TypeOfOT in ('4','5')

	----xóa ca ngày nghỉ phép
	--delete @rtnTable 
	--From @rtnTable rt
	--inner join
	--udf_BangPhep(@fromdate,@todate,@Empl) erml
	--on rt.Employee_ID=erml.Employee_ID and rt.TimeDate between erml.Fromdate and erml.ToDate and erml.LeaveType_ID not in ('31','32')
	Return
	
END



GO
