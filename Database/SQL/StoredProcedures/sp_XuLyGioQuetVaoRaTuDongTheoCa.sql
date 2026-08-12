
CREATE PROCEDURE [dbo].[sp_XuLyGioQuetVaoRaTuDongTheoCa]
	-- Add the parameters for the stored procedure here
	--exec [dbo].[sp_XuLyGioQuetVaoRaTuDongTheoCa] '2019-6-25','19001015','00-Shift0',0,null,1
	@TimeDate datetime,
	@Employee_ID nvarchar(50),
	@ShiftName nvarchar(50),
	@InOutStatus int,
	@LeaveType_ID varchar(50)=null,
	@CheDo as bit,
	@MOT float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ShiftFromTime datetime,@ShiftToTime datetime,@ShiftRestFromTime datetime,@ShiftRestToTime datetime,@maxovertime float,@AccessTime datetime
	select @ShiftFromTime=fromtime,@ShiftToTime=totime,@ShiftRestFromTime=RestTimeFrom,@ShiftRestToTime=RestTimeTo from hr_shifts where shiftname=@ShiftName
	set @ShiftFromTime=[dbo].[GhepGioVaoNgay](@TimeDate,@ShiftFromTime)
	if isnull(@CheDo,0)=1 begin
		set @ShiftToTime=[dbo].[GhepGioVaoNgay]((case when DATEPART(hour,@ShiftToTime)>DATEPART(hour,@ShiftFromTime) then @TimeDate else @TimeDate+1 end),dateadd(Hour,-1,@ShiftToTime))
	end else begin
		set @ShiftToTime=[dbo].[GhepGioVaoNgay]((case when DATEPART(hour,@ShiftToTime)>DATEPART(hour,@ShiftFromTime) then @TimeDate else @TimeDate+1 end),@ShiftToTime)
	end

	--xử lý giờ nghỉ giữa ca
	if DATEDIFF(MINUTE,@ShiftFromTime,@ShiftToTime)>480 begin
		if DATEPART(HOUR,@ShiftFromTime)<=DATEPART(HOUR,@ShiftRestFromTime) begin
			set @ShiftRestFromTime=[dbo].[GhepGioVaoNgay](@TimeDate,@ShiftRestFromTime)
		end else begin
			set @ShiftRestFromTime=[dbo].[GhepGioVaoNgay](@TimeDate+1,@ShiftRestFromTime)
		end
		if DATEPART(HOUR,@ShiftFromTime)<=DATEPART(HOUR,@ShiftRestToTime) begin
			set @ShiftRestToTime=[dbo].[GhepGioVaoNgay](@TimeDate,@ShiftRestToTime)
		end else begin
			set @ShiftRestToTime=[dbo].[GhepGioVaoNgay](@TimeDate+1,@ShiftRestToTime)
		end
	end else begin
		set @ShiftRestFromTime=null
		set @ShiftRestToTime=null
	end

	if @InOutStatus=0 begin
		if @MOT is null begin
			set @maxovertime=0
			select @maxovertime=isnull(maxovertime,0) from HR_MaxOverTime where Employee_ID=@Employee_ID and [TypeOfOT]=2 and workingdate=@TimeDate
		end else begin
			set @maxovertime=@MOT
		end
		if @LeaveType_ID='31' begin
			set @ShiftFromTime=DATEADD(hour,4,@ShiftFromTime) 
			if @ShiftRestToTime is not null begin
				if @ShiftFromTime between @ShiftRestFromTime and @ShiftRestToTime begin
					set @ShiftFromTime=dateadd(minute,datediff(minute,@ShiftRestFromTime,@ShiftFromTime),@ShiftRestToTime)
				end
			end
			set @AccessTime=@ShiftFromTime
		end else begin
			set @AccessTime=dateadd(MINUTE,0-@maxovertime*60,@ShiftFromTime)
		end
	end else begin
		if DATENAME(WEEKDAY,@TimeDate)='Sunday' or exists(select * from SmartBooks_HolidaysPlan where H_date=@TimeDate) begin
			select (case when dateadd(MINUTE,(isnull(mot.maxovertime,0))*60,s.FromTime)>s.RestTimeFrom then dateadd(MINUTE,(isnull(mot.maxovertime,0))*60+DATEDIFF(minute,s.RestTimeFrom,s.RestTimeTo),s.FromTime) else dateadd(MINUTE,(isnull(mot.maxovertime,0))*60,s.FromTime) end) as AccessTime
				from
				HR_Shifts s
				left join
				HR_MaxOverTime mot
				on s.ShiftName=mot.ShiftName and mot.Employee_ID=@Employee_ID and mot.[TypeOfOT] in ('4','5') and workingdate=@TimeDate
				where s.ShiftName=@ShiftName
		end else begin
			if @LeaveType_ID='32' begin
				set @ShiftToTime=DATEADD(hour,-4,@ShiftToTime) 
				if @ShiftRestFromTime is not null begin
					if @ShiftToTime between @ShiftRestFromTime and @ShiftRestToTime begin
						set @ShiftToTime=dateadd(minute,-datediff(minute,@ShiftToTime,@ShiftRestToTime),@ShiftRestFromTime)
					end
				end
				set @AccessTime=@ShiftToTime
			end else begin
				if @MOT is null begin
					set @maxovertime=0
					select @maxovertime=isnull(maxovertime,0) from HR_MaxOverTime where Employee_ID=@Employee_ID and [TypeOfOT]=1 and workingdate=@TimeDate
				end else begin
					set @maxovertime=@MOT
				end
				set @AccessTime=dateadd(MINUTE,@maxovertime*60,@ShiftToTime)
			end
		end
	end
	select @AccessTime as AccessTime
END




GO
