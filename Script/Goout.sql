USE [HR_GWFNV]
GO
/****** Object:  StoredProcedure [dbo].[sp_TinhGioXinRaNgoai]    Script Date: 11/07/2022 3:40:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [sp_TinhGioXinRaNgoai] '2022-06-30','2022-06-30','admin',null,null,null,null,null,null,'22062110'
ALTER PROCEDURE [dbo].[sp_TinhGioXinRaNgoai]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@UserName nvarchar(50)=null,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Empl nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	DECLARE @Employee_ID nvarchar(50),@workingday datetime,@TimeOut datetime,@TimeIn datetime,@SoNgaySauKhiMangBauDuocHuongThaiSan int
			,@InsertDate datetime,@qv_SoPhutMuonDuocTinhDungGio int,@qv_SoPhutTrongBlockDuocTinhXuong int,@qv_SoPhutBlock int,@qr_SoPhutKhongDuocTinhTangCa int,@qr_SoPhutTrongBlockDuocTinhXuong int,@qr_SoPhutBlock int,@LamTronGioCong_SoPhutTrongBlockDuocTinhXuong int,@LamTronGioCong_SoPhutBlock int
			,@ShiftName nvarchar(50)
			,@ShiftFromTime datetime,@ShiftToTime datetime,@AllowLateIn int,@MinOverTime int,@MinMinute int
			,@MaxOverTime int,@FirstTimeIn datetime,@LastTimeOut datetime
			,@CheDo int, @LeaveType_ID nvarchar(50), @RealTimeIn datetime, @RealTimeOut datetime
			--,@SU_MinMinute int,@SU_BlockMinute int,@SU_BlockDownMinute int
	select @SoNgaySauKhiMangBauDuocHuongThaiSan=Value from [dbo].[SetUp] where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'

	DECLARE @HR_WTDAILY TABLE
	(
		Employee_ID nvarchar(50)
		,Ngay datetime
		,MaCong varchar(50)
		,wt float
		,InsertSource varchar(50)
	)

	DECLARE cur CURSOR LOCAL FOR
	select goout.Employee_ID,goout.TimeDate,goout.TimeOut_,goout.TimeIn,erts.CheDo
	,erts.ShiftName,shifts.FromTime,shifts.ToTime,shifts.AllowLateIn,shifts.MinMinute, goout.LeaveType_ID, tito.RealTimeIn, tito.RealTimeOut
	from
	HR_GoOut goout
	left join
	udf_DangKyCa(@fromdate,@todate,@SoNgaySauKhiMangBauDuocHuongThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@Empl) erts
	on goout.Employee_ID=erts.Employee_ID and goout.TimeDate=erts.AccessDate
	left join
	HR_Shifts shifts
	on erts.ShiftName=shifts.ShiftName
	left join
	HR_TimeIn_TimeOut tito
	on goout.Employee_ID = tito.Employee_ID and goout.TimeDate = tito.OT_date
	where goout.TimeDate between @fromdate and @todate --and goout.LeaveType_ID<>'Business'
							and goout.Employee_ID in (select Employee_ID from udf_EmployeeFilter('VN',@fact,@dept,@sect,@team,@pos,@posc,@Empl,@todate))
	OPEN  cur
	FETCH NEXT FROM cur INTO @Employee_ID,@WorkingDay,@TimeOut,@TimeIn,@CheDo,@ShiftName,@ShiftFromTime,@ShiftToTime,@AllowLateIn,@MinMinute,@LeaveType_ID,@RealTimeIn,@RealTimeOut
	WHILE @@FETCH_STATUS = 0
	BEGIN
		/*if @LeaveType_ID = 'Business' begin
			if @TimeIn not between @RealTimeIn and @RealTimeOut begin
				select @FirstTimeIn=AccessTime from [dbo].[udf_TinhCong_QuetVao](@WorkingDay,@WorkingDay,@SoNgaySauKhiMangBauDuocHuongThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@Employee_ID)
				select @LastTimeOut=AccessTime from [dbo].[udf_TinhCong_QuetRa](@WorkingDay,@WorkingDay,@SoNgaySauKhiMangBauDuocHuongThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@Employee_ID)
			end
		end else begin*/
		select @FirstTimeIn=AccessTime from [dbo].[udf_TinhCong_QuetVao](@WorkingDay,@WorkingDay,@SoNgaySauKhiMangBauDuocHuongThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@Employee_ID)
		select @LastTimeOut=AccessTime from [dbo].[udf_TinhCong_QuetRa](@WorkingDay,@WorkingDay,@SoNgaySauKhiMangBauDuocHuongThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@Employee_ID)
		--xử lý dữ liệu xin ra ngooài
		if DATEPART(Hour,@FirstTimeIn)<=DATEPART(Hour,@TimeOut) begin
			set @TimeOut=[dbo].[GhepGioVaoNgay](@FirstTimeIn,@TimeOut)
		end else begin
			set @TimeOut=[dbo].[GhepGioVaoNgay](@FirstTimeIn+1,@TimeOut)
		end
		if DATEPART(Hour,@FirstTimeIn)<=DATEPART(Hour,@TimeIn) begin
			set @TimeIn=[dbo].[GhepGioVaoNgay](@FirstTimeIn,@TimeIn)
		end else begin
			set @TimeIn=[dbo].[GhepGioVaoNgay](@FirstTimeIn+1,@TimeIn)
		end
		if not (@TimeOut>=@LastTimeOut or @TimeIn<=@FirstTimeIn) begin
			if @TimeIn>=@LastTimeOut begin
				set @TimeIn=@LastTimeOut
			end
			if @TimeOut<@FirstTimeIn begin
				set @TimeOut=@FirstTimeIn
			end
			--xử lý giờ vào và tan ca
			set @ShiftFromTime=[dbo].[GhepGioVaoNgay](@WorkingDay,@ShiftFromTime)
			set @ShiftToTime=[dbo].[GhepGioVaoNgay]((case when DATEPART(hour,@ShiftToTime)>DATEPART(hour,@ShiftFromTime) then @WorkingDay else @WorkingDay+1 end),@ShiftToTime)
			--xử lý giờ quẹt vào ra
			set @TimeOut=[dbo].[udf_DieuChinhGioQuetVao](@TimeOut,@ShiftFromTime,@AllowLateIn,NULL,NULL)
			set @TimeIn=[dbo].[udf_DieuChinhGioQuetRa](@TimeIn,@ShiftToTime,@MinOverTime,NULL,NULL,0)
			--Nhập dữ liệu quẹt tính công
			delete @HR_WTDAILY

			print @TimeIn
			print @TimeOut

			insert into @HR_WTDAILY(Employee_ID,Ngay,MaCong,wt,InsertSource)
			select @Employee_ID,@WorkingDay,MaCong
			,[dbo].[udf_TinhGioCongChiTiet](@TimeOut,@TimeIn,FromTime,ToTime,RestTimeFrom,resttimeto
											,NULL,0,0,0,Round_,@WorkingDay,NumberOfDay,macong) as WorkingTime,'GOOUT_'+LEFT(REPLACE(convert(varchar, @TimeOut, 108),':',''),4)
			from udf_ReturnTableSetupHourTimeKeeping(@Employee_ID,@ShiftName,@WorkingDay,@CheDo,1.5)
			where FromTime<@TimeIn
				and ToTime>@TimeOut
			order by No_

			select * from @HR_WTDAILY
			--begin xử lý đặc thù cho woosin
			if @LeaveType_ID = 'Business' begin
				update @HR_WTDAILY set wt=round((cast(wt*60 as float)/30*30/*-(case when cast(wt*60 as int)%30 between 1 and 29 then 30 else 0 end)*/)/60.0,1)
			end else begin
				update @HR_WTDAILY set wt=round((-cast(wt*60 as float)/30*30/*-(case when cast(wt*60 as int)%30 between 1 and 29 then 30 else 0 end)*/)/60.0,1)
			end
			
			--end
			insert into HR_WTDAILY(Employee_ID,Ngay,MaCong,wt,InsertSource) select * from @HR_WTDAILY
		end
	FETCH NEXT FROM cur INTO @Employee_ID,@WorkingDay,@TimeOut,@TimeIn,@CheDo,@ShiftName,@ShiftFromTime,@ShiftToTime,@AllowLateIn,@MinMinute,@LeaveType_ID,@RealTimeIn,@RealTimeOut
	END
	CLOSE cur
	DEALLOCATE cur
END