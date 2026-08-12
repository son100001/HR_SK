CREATE FUNCTION [dbo].[udf_ReturnTableSetupHourTimeKeeping]
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_ReturnTableSetupHourTimeKeeping]('SS240611','70-Shift0','2024-11-06',0,0)
	--select 1
	@Employee_ID nvarchar(50),
	@ShiftName nvarchar(50),
	@DateTime datetime,
	@PregType int,--1 thai sản, 2 người cao tuổi, 3 con nhỏ
	@TangCaKH float
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
	[ShiftName] [nvarchar](50) NOT NULL,
	[FromTime] [datetime] NOT NULL,
	[ToTime] [datetime] NULL,
	[RestTimeFrom] [datetime] NULL,
	[RestTimeTo] [datetime] NULL,
	[MaCong] [nvarchar](50) NULL,
	[No_] [int] NULL,
	[MaxMinute] [float] NULL,
	[NumberOfDay] [int] NULL,
	[MinMinute] [int] NULL,
	[BlockMinute] [int] NULL,
	[BlockDownMinute] [int] NULL,
	[PushWorkingTimeNo] [int] NULL,
	[Round_] [int] NULL,
	[GioTieuChuan] [int] NULL,
	[DuGioTieuChuanDuocCong] [int] NULL,
	[SoPhutCoSoDeQuyDoi] [int] NULL,
	[SoPhutDuocTinhLaMotNgayCong] [int] NULL,
	[isTCTruoc] [bit] NULL,
	[BreakTimeFrom] [datetime] NULL,
	[BreakTimeTo] [datetime] NULL
	,primary key ([ShiftName],[FromTime])
)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @FromTime [datetime],@ToTime [datetime],@RestTimeFrom [datetime],@RestTimeTo [datetime],@MaCong [nvarchar](50),@No_ [int],@MaxMinute [float],@NumberOfDay [int],@MinMinute [int],@BlockMinute [int],@BlockDownMinute [int],@PushWorkingTimeNo [int],@Round_ [int],@GioTieuChuan [int],@DuGioTieuChuanDuocCong [int],@SoPhutCoSoDeQuyDoi [int],@SoPhutDuocTinhLaMotNgayCong [int],@isTCTruoc [bit]
		,@OTBefore datetime,@OTAfter datetime,@ShiftGroup nvarchar(50)
		,@FixToTime datetime,@FixFromTime datetime,@BreakTimeFrom datetime,@BreakTimeTo datetime
		,@PLC_FT datetime,@PLC_TT datetime,@trongca varchar(50),@TCNgayThuong varchar(50),@TCChuNhat varchar(50),@TCNgayLe varchar(50)
		,@FT0 datetime,@TT0 datetime,@isOT0 as bit
		,@FT datetime,@TT datetime,@RF datetime,@RT datetime,@isOT as bit
		,@FT1 datetime,@TT1 datetime,@isOT1 as bit
		,@FTLuu datetime,@TTLuu datetime,@RFLuu datetime,@RTLuu datetime,@isOTLuu as bit
		,@GioRaKH datetime
		,@LoaiCong1 varchar(50),@LoaiCong2 varchar(50),@Thu7DuocNghi datetime, @Department nvarchar(50), @Factory nvarchar(50)
	set @MinMinute=20
	set @BlockMinute=0 set @BlockDownMinute=0 set @Round_=2
	--select @Thu7DuocNghi = [Value] from Setup where FunctionID = 'Thu7DuocNghi' and ID = 'T7DN'
	set @LoaiCong1=[dbo].[udf_TraVeLoaiNgayCong](@Employee_ID,@DateTime)
	--set @LoaiCong2=[dbo].[udf_TraVeLoaiNgayCong](@Employee_ID,@DateTime+1)
			-- Add the T-SQL statements to compute the return value here
	SELECT @FromTime=FromTime,@ToTime=ToTime,@RestTimeFrom=RestTimeFrom,@RestTimeTo=RestTimeTo,@ShiftGroup=ShiftGroup from HR_Shifts where ShiftName=@ShiftName
	--select @Department = DepartmentCode from udf_EmployeeFilter ('VN',null,null,null,null,null,null,@Employee_ID,GETDATE())
	--select @Factory = Factory_ID from udf_EmployeeFilter ('VN',null,null,null,null,null,null,@Employee_ID,GETDATE())
	set @FromTime=[dbo].[GhepGioVaoNgay](@DateTime,@FromTime)
	if DATEPART(HOUR,@ToTime)>DATEPART(HOUR,@FromTime) begin
		set @ToTime=[dbo].[GhepGioVaoNgay](@DateTime,@ToTime)
	end else begin
		set @ToTime=[dbo].[GhepGioVaoNgay](@DateTime+1,@ToTime)
	end
	set @FixToTime=@ToTime
	set @FixFromTime=@FromTime
	set @OTBefore=DATEADD(HOUR,-4,@FromTime)
	set @OTAfter=DATEADD(HOUR,12,@ToTime)

	if DATEDIFF(MINUTE,@FromTime,@ToTime)>480 begin
		if @RestTimeFrom is not null and @RestTimeTo is not null begin
			if DATEPART(HOUR,@RestTimeFrom)>DATEPART(HOUR,@FromTime) begin
				set @RestTimeFrom=[dbo].[GhepGioVaoNgay](@DateTime,@RestTimeFrom)
			end else begin
				set @RestTimeFrom=[dbo].[GhepGioVaoNgay](@DateTime+1,@RestTimeFrom)
			end
			if DATEPART(HOUR,@RestTimeTo)>DATEPART(HOUR,@FromTime) begin
				set @RestTimeTo=[dbo].[GhepGioVaoNgay](@DateTime,@RestTimeTo)
			end else begin
				set @RestTimeTo=[dbo].[GhepGioVaoNgay](@DateTime+1,@RestTimeTo)
			end
		end
	end else begin
		set @RestTimeFrom=null set @RestTimeTo=null
	end
	if isnull(@PregType,0) in (1,3) begin
		set @ToTime=DATEADD(HOUR,-1,@ToTime)
		set @TangCaKH=0
	end
	set @GioRaKH=dateadd(MINUTE,@TangCaKH*60,@ToTime)
	set @No_=0
	
	DECLARE @HR_PhanLoaiGioCong TABLE(fromtime datetime,totime datetime,TrongCa varchar(50),TCNgayThuong varchar(50),TCChuNhat varchar(50),TCNgayLe varchar(50))
	if exists (select ShiftName from HR_PhanLoaiGioCong where ShiftName=@ShiftName) begin
		insert into @HR_PhanLoaiGioCong select fromtime,totime,trongca,TCNgayThuong,TCChuNhat,TCNgayLe from HR_PhanLoaiGioCong where ShiftName=@ShiftName 
	--Ca đêm shinsung
	end else if @ShiftName like '%Shift3' begin
		insert into @HR_PhanLoaiGioCong select fromtime,totime,trongca,TCNgayThuong,TCChuNhat,TCNgayLe from HR_PhanLoaiGioCong where ShiftName='Shift3'
	end else begin
		insert into @HR_PhanLoaiGioCong select fromtime,totime,trongca,TCNgayThuong,TCChuNhat,TCNgayLe from HR_PhanLoaiGioCong where ShiftName='General'
	end
	DECLARE cur CURSOR LOCAL FOR
	select ft,(case when DATEPART(hour,tt)=0 then tt+1 else tt end) as tt,TrongCa,TCNgayThuong,TCChuNhat,TCNgayLe from
	(
		select cast ([dbo].[GhepGioVaoNgay](@DateTime,fromtime) as datetime) as ft
			,cast ([dbo].[GhepGioVaoNgay](@DateTime,totime) as datetime) as tt
			,TrongCa,TCNgayThuong,TCChuNhat,TCNgayLe
		from @HR_PhanLoaiGioCong
		union
		select cast ([dbo].[GhepGioVaoNgay](dateadd(day,1,@DateTime),fromtime) as datetime) as ft
			,cast([dbo].[GhepGioVaoNgay](dateadd(day,1,@DateTime),totime)as datetime) as tt
			,TrongCa,TCNgayThuong,TCChuNhat,TCNgayLe
		from @HR_PhanLoaiGioCong
	)as plgc
	order by ft
	OPEN  cur
	FETCH NEXT FROM cur INTO @PLC_FT,@PLC_TT,@trongca,@TCNgayThuong,@TCChuNhat,@TCNgayLe
	WHILE @@FETCH_STATUS = 0
	BEGIN
		set @macong=null set @isOT0=1 set @isOT=1 set @isOT1=1 set @FT0=null set @FT=null set @FT1=null set @TT0=null set @TT=null set @TT1=null
		if @FromTime>@PLC_TT begin
			set @FT=@PLC_FT set @TT=@PLC_TT
			set @isOT=1
		end else if @FromTime between @PLC_FT and @PLC_TT and @ToTime between @PLC_FT and @PLC_TT begin
			set @FT0=@PLC_FT set @TT0=@FromTime 
			set @isOT0=1
			set @FT=@FromTime set @TT=@ToTime 
			set @isOT=0
			set @FT1=@ToTime set @TT1=@PLC_TT 
			set @isOT1=1
		end else if @FromTime between @PLC_FT and @PLC_TT begin
			set @FT=@FromTime set @TT=@PLC_TT 
			set @isOT=0
			set @FT1=@PLC_FT set @TT1=@FromTime 
			set @isOT1=1
		end else if @ToTime between @PLC_FT and @PLC_TT begin
			set @FT=@PLC_FT set @TT=@ToTime 
			set @isOT=0
			set @FT1=@ToTime set @TT1=@PLC_TT 
			set @isOT1=1
		end else if @ToTime<@PLC_FT begin
			set @FT=@PLC_FT set @TT=@PLC_TT
			set @isOT=1
		end else if @PLC_FT between @FromTime and @ToTime and @PLC_TT between @FromTime and @ToTime begin
			set @FT=@PLC_FT set @TT=@PLC_TT
			set @isOT=0
		end
		declare @i int
		set @i=0
		while @i<=2 begin
			if @i=0 begin
				set @FTLuu=@FT0
				set @TTLuu=@TT0
				set @isOTLuu=@isOT0
			end else if @i=1 begin
				set @FTLuu=@FT
				set @TTLuu=@TT
				set @isOTLuu=@isOT
			end else if @i=2 begin
				set @FTLuu=@FT1
				set @TTLuu=@TT1
				set @isOTLuu=@isOT1
			end
			--if DATEPART(day,@FT)<>DATEPART(day,@DateTime) begin
			--	set @isHol=@NextDateIsHol
			--	set @isSun=@NextDateIsSun
			--end
			if @LoaiCong1='Hol' begin
				set @macong=@TCNgayLe
			end else if @LoaiCong1='Sun' begin
				set @macong=@TCChuNhat
			end else begin
				if @isOTLuu=1 begin
					set @macong=@TCNgayThuong
				end else begin
					set @macong=@trongca
				end
			end
			set @RT=null set @RF=null
			if @RestTimeFrom between @FTLuu and @TTLuu begin
				set @RF=@RestTimeFrom
				if @RestTimeTo between @FTLuu and @TTLuu begin
					 set @RT=@RestTimeTo
				end else begin
					set @RT=@TTLuu
				end
			end
			set @MaxMinute=isnull(DATEDIFF(MINUTE,@FTLuu,@TTLuu),0) - isnull(DATEDIFF(MINUTE,@RF,@RT),0)
			if @MaxMinute>0 begin
				if not(@isOTLuu=1 and isnull(@PregType,0)=12) and @MaCong is not null begin
					if @FTLuu<@FixFromTime begin
						set @isTCTruoc=1
					end else begin
						set @isTCTruoc=0
					end
					set @No_=@No_+1
					if @GioRaKH<=@FTLuu begin
						insert into @rtnTable(ShiftName,FromTime,ToTime,RestTimeFrom,RestTimeTo,MaCong,No_,MaxMinute,NumberOfDay,MinMinute,BlockMinute,BlockDownMinute,PushWorkingTimeNo,Round_,GioTieuChuan,DuGioTieuChuanDuocCong,SoPhutCoSoDeQuyDoi,SoPhutDuocTinhLaMotNgayCong,isTCTruoc)
						values (@ShiftName,@FTLuu,@TTLuu,@RF,@RT,'CN_'+@MaCong,@No_,@MaxMinute,@NumberOfDay,@MinMinute,@BlockMinute,@BlockDownMinute,@PushWorkingTimeNo,@Round_,@GioTieuChuan,@DuGioTieuChuanDuocCong,@SoPhutCoSoDeQuyDoi,@SoPhutDuocTinhLaMotNgayCong,@isTCTruoc)
					end else if @GioRaKH>@FTLuu and @GioRaKH<@TTLuu begin
						insert into @rtnTable(ShiftName,FromTime,ToTime,RestTimeFrom,RestTimeTo,MaCong,No_,MaxMinute,NumberOfDay,MinMinute,BlockMinute,BlockDownMinute,PushWorkingTimeNo,Round_,GioTieuChuan,DuGioTieuChuanDuocCong,SoPhutCoSoDeQuyDoi,SoPhutDuocTinhLaMotNgayCong,isTCTruoc)
						values (@ShiftName,@FTLuu,@GioRaKH,@RF,@RT,(Case when @LoaiCong1='Sun' or @LoaiCong1='Hol' or @isTCTruoc=1 then 'CN_'+@MaCong else @MaCong end),@No_,DATEDIFF(minute,@FTLuu,@GioRaKH),@NumberOfDay,@MinMinute,@BlockMinute,@BlockDownMinute,@PushWorkingTimeNo,@Round_,@GioTieuChuan,@DuGioTieuChuanDuocCong,@SoPhutCoSoDeQuyDoi,@SoPhutDuocTinhLaMotNgayCong,@isTCTruoc)
						set @No_=@No_+1
						insert into @rtnTable(ShiftName,FromTime,ToTime,RestTimeFrom,RestTimeTo,MaCong,No_,MaxMinute,NumberOfDay,MinMinute,BlockMinute,BlockDownMinute,PushWorkingTimeNo,Round_,GioTieuChuan,DuGioTieuChuanDuocCong,SoPhutCoSoDeQuyDoi,SoPhutDuocTinhLaMotNgayCong,isTCTruoc)
						values (@ShiftName,@GioRaKH,@TTLuu,@RF,@RT,'CN_'+@MaCong,@No_,DATEDIFF(minute,@GioRaKH,@TTLuu),@NumberOfDay,@MinMinute,@BlockMinute,@BlockDownMinute,@PushWorkingTimeNo,@Round_,@GioTieuChuan,@DuGioTieuChuanDuocCong,@SoPhutCoSoDeQuyDoi,@SoPhutDuocTinhLaMotNgayCong,@isTCTruoc)
					end else begin
						insert into @rtnTable(ShiftName,FromTime,ToTime,RestTimeFrom,RestTimeTo,MaCong,No_,MaxMinute,NumberOfDay,MinMinute,BlockMinute,BlockDownMinute,PushWorkingTimeNo,Round_,GioTieuChuan,DuGioTieuChuanDuocCong,SoPhutCoSoDeQuyDoi,SoPhutDuocTinhLaMotNgayCong,isTCTruoc)
						values (@ShiftName,@FTLuu,@TTLuu,@RF,@RT,(Case when @LoaiCong1='Sun' or @LoaiCong1='Hol' or @isTCTruoc=1 then 'CN_'+@MaCong else @MaCong end),@No_,@MaxMinute,@NumberOfDay,@MinMinute,@BlockMinute,@BlockDownMinute,@PushWorkingTimeNo,@Round_,@GioTieuChuan,@DuGioTieuChuanDuocCong,@SoPhutCoSoDeQuyDoi,@SoPhutDuocTinhLaMotNgayCong,@isTCTruoc)
					end
				end
			end
			set @i=@i+1
		end
	FETCH NEXT FROM cur INTO @PLC_FT,@PLC_TT,@trongca,@TCNgayThuong,@TCChuNhat,@TCNgayLe
	END
	CLOSE cur
	DEALLOCATE cur
	
	
	--TH1 breaktimefrom va beaktimeto nam giua fromtim va totime
	update @rtnTable set BreakTimeFrom=@BreakTimeFrom, BreakTimeTo=@BreakTimeTo where @BreakTimeFrom between FromTime and ToTime and @BreakTimeTo between FromTime and ToTime
	--TH2 breaktimefrom <fromtime va beaktimeto<=totime
	update @rtnTable set BreakTimeFrom=fromtime, BreakTimeTo=@BreakTimeTo where @BreakTimeFrom<FromTime and @BreakTimeTo between FromTime and ToTime
	--TH3 breaktimefrom <fromtime va beaktimeto>totime
	update @rtnTable set BreakTimeFrom=fromtime, BreakTimeTo=@ToTime where @BreakTimeFrom<FromTime and @BreakTimeTo>ToTime
	--TH4 breaktimefrom>=fromtime va beaktimeto > totime
	update @rtnTable set BreakTimeFrom=@BreakTimeFrom, BreakTimeTo=@ToTime where @BreakTimeFrom between FromTime and ToTime and @BreakTimeTo>ToTime
	--xử lý làm tròn

	--set @MinMinute=30
	--set @BlockMinute=15 set @BlockDownMinute=14 set @Round_=2
	update @rtnTable set MinMinute=30, BlockDownMinute=29,BlockMinute=30 where isTCTruoc = 1
	update @rtnTable set MinMinute=0, BlockDownMinute=29,BlockMinute=30 where isTCTruoc = 0
	--where macong in (select macong from hr_loaicong where isnull(isWorkingTime,0)<>1)
	--update @rtnTable set MinMinute=60 where fromtime=@FixToTime
	

	RETURN
END


GO
