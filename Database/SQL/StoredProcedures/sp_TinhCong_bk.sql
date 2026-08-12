--exec [dbo].[sp_TinhCong] '2023-06-06','2023-06-06',N'admin',N'',N'',N'',N'',N'','','M01394'
create PROCEDURE [dbo].[sp_TinhCong_bk]
	-- Add the parameters for the stored procedure here
	--select * from HR_TimeIn_TimeOut where Employee_ID='2666' and OT_date='2020-2-22'
	--select * from HR_WTDaily where Employee_ID='2666' and ngay between '2020-2-1' and '2020-2-29'
	--exec [dbo].[sp_TinhCong] '2025-07-01','2025-07-31','admin',null,null,null,null,null,null,'C16357'
	@fromdate datetime,
	@todate datetime,
	@UserName nvarchar(50)=null,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Emp nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	Declare @ThongBao nvarchar(max), @sqlquery nvarchar(500)
	set @ThongBao=''
	if exists(select TableName from HR_Khoa where TableName='HR_WTDaily' and Block_Date>=@fromdate and Block_User=@UserName) begin
		set @ThongBao=N'Dulieudabikhoa'
	end
	if isnull(@ThongBao,'')='' begin
		declare @InsertDate datetime,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan int
			,@Employee_ID nvarchar(50),@TimeDate datetime,@AccessTime datetime,@ShiftName nvarchar(50),@OldShiftName nvarchar(50) 
			,@OldEmployee_ID nvarchar(50),@OldTimeDate datetime,@FirstAccessTime datetime,@LastAccessTime datetime,@FirstAccessTimeEditted datetime,@LastAccessTimeEditted datetime
			,@ShiftFromTime datetime,@OldShiftFromTime datetime,@ShiftToTime datetime,@OldShiftToTime datetime,@AllowLateIn int,@AllowEarlyOut int,@OldAllowLateIn int,@OldAllowEarlyOut int,@MinMinute int
			,@MaxOverTime float,@OldMaxOverTime float,@MaxOverTimeBefore float,@OldMaxOverTimeBefore float,@MaxOverTimeHol float,@OldMaxOverTimeHol float,@maxovertimeLunch float, @OldmaxovertimeLunch float
			,@OldInputEmployee_ID nvarchar(50),@OldInputTimeOut datetime
			,@InOutStatus varchar(10),@OldInOutStatus varchar(10)
			,@LateIn float,@EarlyOut float,@ShiftRestFromTime datetime,@ShiftRestToTime datetime,@OldShiftRestFromTime datetime,@OldShiftRestToTime datetime
			,@LeaveType_ID nvarchar(50),@OldLeaveType_ID nvarchar(50)
			,@CheDo int,@OldCheDo int,@MaCong varchar(50)
			,@InertSourceHolSun varchar(50),@HolSunTypeOfOT varchar(20),@OldHolSunTypeOfOT varchar(20),@Block_Date_Termination datetime
			,@GioTangCaToiDaTheoNam_Goc float,@GioTangCaToiDaTheoNam float,@GioTangCaToiDaTheoThang_Goc float,@GioTangCaToiDaTheoThang float, @GioTangCaToiDaTheoNgay_Goc float,@GioTangCaToiDaTheoNgay float,@GioDaTangCaTrongNam float
			,@NgayDauNam datetime, @NgayCuoiNam datetime
			,@SoPhutRanDomGioRa int, @SoPhutRanDomGioVao int,@SoPhutTieuChuan int
			,@TongGioTangCa float,@GioTangCa float
			,@StartedDate datetime,@OldStartedDate datetime
			,@CongHCNguoiMoi float,@GoutTimeIn datetime, @GoutTimeOut datetime, @GoutLeaveType nvarchar(50),@OldGoutTimeIn datetime, @OldGoutTimeOut datetime, @OldGoutLeaveType nvarchar(50)
			,@RealLateIn float, @RealEarlyOut float, @Thu7DuocNghi datetime = null, @SoPhutChoDiMuon float, @OldSoPhutChoDiMuon float
			set @SoPhutTieuChuan=14
		set @NgayDauNam=DATEFROMPARTS(datepart(year,@fromdate),datepart(MONTH,@fromdate),1)
		set @NgayCuoiNam=dateadd(year,1,@NgayDauNam)-1
		set @GioTangCaToiDaTheoNam_Goc=300
		select @GioTangCaToiDaTheoNam_Goc=Value from HR_SetUpFollowDate where Group_='TangCaToiDaTheoNam' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
		set @GioTangCaToiDaTheoThang_Goc=30
		select @GioTangCaToiDaTheoThang_Goc=Value from HR_SetUpFollowDate where Group_='TangCaToiDaTheoThang' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
		select @GioTangCaToiDaTheoNgay_Goc=Value from Setup where FunctionID = 'TangCaToiDa' and ID = 'TangCaToiDa_Ngay'
		--select @GioTangCaToiDaTheoNgay_Goc=Value from HR_SetUpFollowDate where Group_='TangCaToiDaTheoNgay' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
		set @OldEmployee_ID=null set @OldTimeDate=null set @OldInputEmployee_ID=''
		select @Block_Date_Termination=Block_Date from HR_Khoa where TableName='HR_WTDaily_Termination'
		select @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan=[Value] from [dbo].[SetUp] where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
		--select @Thu7DuocNghi = [Value] from Setup where FunctionID = 'Thu7DuocNghi' and ID = 'T7DN'
		--Xóa công
		delete from [dbo].[HR_WTDaily] where Ngay between @fromdate and @todate AND insertsource<>'NhapTay'
														and Employee_ID in (select Employee_ID from udf_EmployeeFilter('',@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,getdate())))
														and Employee_ID not in (select Employee_ID from SmartBooks_Employee where ternimationdate<=@Block_Date_Termination)
		delete from [dbo].[HR_TimeIn_TimeOut] where OT_date between @fromdate and @todate
														and Employee_ID in (select Employee_ID from udf_EmployeeFilter('',@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,getdate())))
														and Employee_ID not in (select Employee_ID from SmartBooks_Employee where ternimationdate<=@Block_Date_Termination)

		set @sqlquery = N'exec sp_Insert_HR_BangPhepDaNghi @fromdate, @todate, null, null, null, null, null, null, @Emp'

		execute sp_executesql @sqlQuery
					, N'@fromdate datetime, @todate datetime, @Emp nvarchar(50)'
					, @fromdate = @fromdate, @todate = @todate, @Emp = @Emp

		set @ThongBao=N'Thanhcong'

		DECLARE @HR_WTDAILY TABLE
		(
			Employee_ID nvarchar(50)
			,Ngay datetime
			,MaCong varchar(50)
			,wt float
			,InsertSource varchar(50)
		)
		DECLARE @TabTongGioDaTangCaTrongNam TABLE
		(
			Employee_ID nvarchar(50)
			,GioTangCa float
			,primary key (Employee_ID)
		)
		insert into @TabTongGioDaTangCaTrongNam
		select Employee_ID,sum(wt) from HR_WTDaily where MaCong in (select MaCong from HR_LoaiCong where ISNULL(isWorkingTime,0)=1 and MaCong not like 'CN%') and ngay between @NgayDauNam and @NgayCuoiNam group by Employee_ID

		DECLARE cur CURSOR LOCAL FOR
		select
		tc.Employee_ID, erml.LeaveType_ID
		,tc.TimeDate,AccessTime,tc.InOutStatus,tc.ShiftName,tc.maxovertime,ISNULL(tc.maxovertimeB,0),isnull(tc.MaxOverTimeHol,0),isnull(tc.maxovertimeLunch,0),tc.CheDo,tc.HolSunTypeOfOT
		,shifts.FromTime,shifts.ToTime,shifts.RestTimeFrom,shifts.RestTimeTo,shifts.AllowLateIn as AllowLateIn,shifts.AllowEarlyOut,shifts.MinMinute,empl.StartedDate,gout.TimeIn as GoutTimeIn,gout.TimeOut_ as GoutTimeOut,gout.LeaveType_ID as GoutLeaveType
		,isnull(erp.remark,empl.ChoPhepSoPhutMuon) as ChoPhepSoPhutMuon
		from
		[dbo].[udf_TinhCong](@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan,@fact,@Dept,@Sect,@Team,@Pos,@PosC,@Emp) tc
		left join
		HR_Shifts shifts
		on tc.ShiftName=shifts.ShiftName
		left join
		HR_EmployeeRegisMaternityLeave erml
		on tc.Employee_ID=erml.Employee_ID and tc.TimeDate between erml.Fromdate and erml.ToDate
		left join
		[dbo].[SmartBooks_HolidaysPlan] hp
		on tc.TimeDate=hp.h_date
		left join
		udf_EmployeeFilter ('VN',@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
		on tc.Employee_ID=empl.Employee_ID
		left join
		HR_GoOut gout
		on tc.Employee_ID = gout.Employee_ID and tc.AccessDate = gout.TimeDate
		left join
		HR_EmpRegisParameter erp
		on tc.Employee_ID = erp.Employee_ID and tc.AccessDate between erp.Fromdate and erp.Todate and erp.Parameter = 'DiMuon' and erp.ParameterValue = 'DiMuonSoPhut'
		--left join
		--@TabTongGioDaTangCaTrongNam tctn
		--on tc.Employee_ID=tctn.Employee_ID
		where (empl.TernimationDate is null or empl.TernimationDate >= @fromdate) and empl.StartedDate <= @todate
		union
		select 'ws900000000',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null
		order by tc.Employee_ID,tc.TimeDate,tc.AccessTime
		OPEN  cur
		FETCH NEXT FROM cur INTO @Employee_ID,@LeaveType_ID,@TimeDate,@AccessTime,@InOutStatus,@ShiftName,@MaxOverTime,@MaxOverTimeBefore,@MaxOverTimeHol,@maxovertimeLunch,@CheDo,@HolSunTypeOfOT,@ShiftFromTime,@ShiftToTime,@ShiftRestFromTime,@ShiftRestToTime,@AllowLateIn,@AllowEarlyOut,@MinMinute,@StartedDate,@GoutTimeIn,@GoutTimeOut,@GoutLeaveType,@SoPhutChoDiMuon
		WHILE @@FETCH_STATUS = 0
		BEGIN
			if @OldEmployee_ID is null or @FirstAccessTime is null begin
				if @AccessTime>@OldInputTimeOut or @OldInputTimeOut is null
					set @FirstAccessTime=@AccessTime
			end else begin
				print @OldEmployee_ID
				print 'a'
				print @TimeDate
				print @OldTimeDate
				print 'b'
				if @OldEmployee_ID<>@Employee_ID or @OldTimeDate<>@TimeDate begin
				------------------TÍNH CÔNG----------------------
					--xử lý giờ vào và tan ca
					set @ShiftFromTime=[dbo].[GhepGioVaoNgay](@OldTimeDate,@OldShiftFromTime)
					if isnull(@OldCheDo,0)>=1 begin
						set @ShiftToTime=[dbo].[GhepGioVaoNgay]((case when DATEPART(hour,@OldShiftTotime)>DATEPART(hour,@OldShiftFromTime) then @OldTimeDate else @OldTimeDate+1 end),dateadd(Hour,-1,@OldShiftTotime))
					end else begin
						set @ShiftToTime=[dbo].[GhepGioVaoNgay]((case when DATEPART(hour,@OldShiftTotime)>DATEPART(hour,@OldShiftFromTime) then @OldTimeDate else @OldTimeDate+1 end),@OldShiftTotime)
					end
				
					if not (@OldEmployee_ID=@OldInputEmployee_ID and @LastAccessTime<=@OldInputTimeOut) begin
						print 'e'
						print @LastAccessTime
						print @OldInputTimeOut
						print 'f'
						if datediff(minute,@FirstAccessTime,@LastAccessTime)>=isnull(@MinMinute,15) begin
							--xử lý giờ nghỉ giữa ca
							if @OldShiftRestFromTime is not null and @OldShiftRestToTime is not null begin
								if DATEPART(HOUR,@ShiftFromTime)<=DATEPART(HOUR,@OldShiftRestFromTime) begin
									set @ShiftRestFromTime=[dbo].[GhepGioVaoNgay](@OldTimeDate,@OldShiftRestFromTime)
								end else begin
									set @ShiftRestFromTime=[dbo].[GhepGioVaoNgay](@OldTimeDate+1,@OldShiftRestFromTime)
								end
								if DATEPART(HOUR,@ShiftFromTime)<=DATEPART(HOUR,@OldShiftRestToTime) begin
									set @ShiftRestToTime=[dbo].[GhepGioVaoNgay](@OldTimeDate,@OldShiftRestToTime)
								end else begin
									set @ShiftRestToTime=[dbo].[GhepGioVaoNgay](@OldTimeDate+1,@OldShiftRestToTime)
								end
							end else begin
								set @ShiftRestFromTime=null
								set @ShiftRestToTime=null
							end
							print 'a111'
							print @ShiftToTime
							--xử lý co dk nghi phep
							if @OldLeaveType_ID is not null begin
								if isnull(@OldCheDo,0) > 0 begin
									set @ShiftToTime = DATEADD(hour,1,@ShiftToTime)
								end
								print 'a112'
								print @ShiftToTime
								if @OldLeaveType_ID='31' begin
									set @ShiftFromTime=DATEADD(hour,4,@ShiftFromTime) 
									if @ShiftRestToTime is not null begin
										if @ShiftFromTime between @ShiftRestFromTime and @ShiftRestToTime begin
											set @ShiftFromTime=dateadd(minute,datediff(minute,@ShiftRestFromTime,@ShiftFromTime),@ShiftRestToTime)
										end
									end
								end else if @OldLeaveType_ID='32' begin
									set @ShiftToTime=DATEADD(hour,-4,@ShiftToTime) 
									if @ShiftRestFromTime is not null begin
										--print convert(nvarchar(MAX), @ShiftToTime, 20)
										if @ShiftToTime>@ShiftRestFromTime and @ShiftToTime<@ShiftRestToTime begin
											set @ShiftToTime=dateadd(minute,-datediff(minute,@ShiftToTime,@ShiftRestToTime),@ShiftRestFromTime)
										end else if @ShiftToTime<=@ShiftRestFromTime begin
											set @ShiftToTime=dateadd(minute,-datediff(minute,@ShiftRestFromTime,@ShiftRestToTime),@ShiftToTime)
											--print cast (datediff(minute,@ShiftRestFromTime,@ShiftRestToTime) as varchar(10))
											--print convert(nvarchar(MAX), @ShiftToTime, 20)
										end
										if @LastAccessTime> case when isnull(@OldCheDo,0) in (1,3) then dateadd(hour,1,@ShiftToTime) else @ShiftRestToTime end begin
											select @LastAccessTime = case when isnull(@OldCheDo,0) in (1,3) then dateadd(hour,1,@ShiftToTime) else @ShiftRestToTime end
										end
										--print convert(nvarchar(MAX), @ShiftToTime, 20)
									end
								end
							end
							print 'a113'
							print @ShiftToTime
							set @FirstAccessTime=dateadd(second,-datepart(second,@FirstAccessTime),@FirstAccessTime)
							set @LastAccessTime=dateadd(second,-datepart(second,@LastAccessTime),@LastAccessTime)
							set @LastAccessTimeEditted=@LastAccessTime
							print 'c'
							print @FirstAccessTime
							print @LastAccessTime
							print 'd'
						--print convert(nvarchar(MAX), @LastAccessTimeEditted, 20)
							--xử lý giờ quẹt vào ra/ 
							set @FirstAccessTimeEditted=[dbo].[udf_DieuChinhGioQuetVao](case when @FirstAccessTime <= dateadd(Minute,-55,@ShiftFromTime) or @FirstAccessTime >= @ShiftFromTime then @FirstAccessTime else @ShiftFromTime end,dateadd(minute,-(case when @FirstAccessTime > @ShiftFromTime then 0 else @OldMaxOverTime end)*60,@ShiftFromTime),isnull(@OldSoPhutChoDiMuon,@OldAllowLateIn),null,null)
							set @LastAccessTimeEditted=[dbo].[udf_DieuChinhGioQuetRa](@LastAccessTimeEditted,@ShiftToTime,isnull(@OldMaxOverTime,200),null,null,isnull(@OldAllowEarlyOut,0))
							
							
							set @LastAccessTimeEditted=(case when @OldSoPhutChoDiMuon is not null and @LastAccessTimeEditted >= @ShiftToTime then dateadd(minute,FLOOR(RAND() * 14),@ShiftToTime)
																when datediff(MINUTE,@ShiftToTime,@LastAccessTimeEditted)<=@OldMaxOverTime*60
																then @LastAccessTimeEditted
																else dateadd(minute,@OldMaxOverTime*60,@ShiftToTime)
																end)
							--print convert(nvarchar(MAX), @LastAccessTimeEditted, 20)
							--xử lý chủ nhật - ngày lễ
							if (DATENAME(WEEKDAY,@OldTimeDate)='Sunday') or exists(select H_date from SmartBooks_HolidaysPlan where H_date=@OldTimeDate and TypeOfLeave='50') begin
								--xử lý loại tăng ca chủ nhât, ngày lễ
								if DATENAME(WEEKDAY,@OldTimeDate)='Sunday' begin
									if @OldHolSunTypeOfOT=4 begin
										set @InertSourceHolSun= 'Alt'
									--end else begin
									--	set @InertSourceHolSun= 'Sun'
									end
								end else begin
									if @OldHolSunTypeOfOT=4 begin
										set @InertSourceHolSun= 'Alt'
									--end else begin
									--	set @InertSourceHolSun= 'Hol'
									end
								end
							end else begin
								set @InertSourceHolSun=null
							end

							if @OldLeaveType_ID is not null begin
								if @OldLeaveType_ID not in ('31','32','53') begin
									set @FirstAccessTimeEditted=null
									set @LastAccessTimeEditted=null
								end
							end
						
							--Nhập dữ liệu quẹt tính công
							print 'cdefg456'
							print @FirstAccessTimeEditted
							print @LastAccessTimeEditted
							print @OldCheDo
							Declare @float float = (case when DATENAME(WEEKDAY,@OldTimeDate)='Sunday' or exists(select H_date from SmartBooks_HolidaysPlan where H_date=@OldTimeDate and TypeOfLeave in ('50','99')) then 0 else 1 end)
							print @float
							if @LastAccessTimeEditted>@FirstAccessTimeEditted begin
								if isnull(@OldCheDo,0)>=1 begin
									insert into HR_WTDAILY (Employee_ID,Ngay,MaCong,wt,InsertSource) values(@OldEmployee_ID,@OldTimeDate, 'wt1' ,case when DATENAME(WEEKDAY,@OldTimeDate)='Sunday' or exists(select H_date from SmartBooks_HolidaysPlan where H_date=@OldTimeDate and TypeOfLeave in ('50','99')) then 0 else 1 end,'TS')
								end

								if	@FirstAccessTimeEditted<=dateadd(minute,-30,@ShiftRestToTime) and @LastAccessTimeEditted>=@ShiftRestToTime and @OldmaxovertimeLunch>0 begin
									if @OldShiftName not like '%Shift3' begin
										insert into HR_WTDAILY (Employee_ID,Ngay,MaCong,wt,InsertSource) values(@OldEmployee_ID,@OldTimeDate,case when exists(select H_date from SmartBooks_HolidaysPlan where H_date=@OldTimeDate and TypeOfLeave in ('50')) then 'CN_wt7' when DATENAME(WEEKDAY,@OldTimeDate)='Sunday' or exists(select H_date from SmartBooks_HolidaysPlan where H_date=@OldTimeDate and TypeOfLeave in ('99')) then 'CN_wt4' else 'CN_wt3' end,@OldmaxovertimeLunch,'GiuaGio')
									end else begin
										insert into HR_WTDAILY (Employee_ID,Ngay,MaCong,wt,InsertSource) values(@OldEmployee_ID,@OldTimeDate,case when exists(select H_date from SmartBooks_HolidaysPlan where H_date=@OldTimeDate and TypeOfLeave in ('50')) then 'CN_wt8' when DATENAME(WEEKDAY,@OldTimeDate)='Sunday' or exists(select H_date from SmartBooks_HolidaysPlan where H_date=@OldTimeDate and TypeOfLeave in ('99')) then 'CN_wt6' else 'CN_wt5' end,@OldmaxovertimeLunch,'GiuaGio')
									end
								end

								set @GioTangCaToiDaTheoNgay=@GioTangCaToiDaTheoNgay_Goc
								if @GioTangCaToiDaTheoNgay<=@GioTangCaToiDaTheoNam begin
									if @GioTangCaToiDaTheoNgay>@GioTangCaToiDaTheoThang begin
										set @GioTangCaToiDaTheoNgay=@GioTangCaToiDaTheoThang
									end
								end else begin
									set @GioTangCaToiDaTheoNgay=@GioTangCaToiDaTheoNam
									if @GioTangCaToiDaTheoNgay>@GioTangCaToiDaTheoThang begin
										set @GioTangCaToiDaTheoNgay=@GioTangCaToiDaTheoThang
									end
								end
								delete @HR_WTDAILY
								insert into @HR_WTDAILY (Employee_ID,Ngay,MaCong,wt,InsertSource)
								select @OldEmployee_ID,@OldTimeDate,MaCong
								,[dbo].[udf_TinhGioCongChiTiet](@FirstAccessTimeEditted,@LastAccessTimeEditted,FromTime,ToTime,RestTimeFrom,RestTimeTo
																,null,MinMinute,BlockMinute,BlockDownMinute,Round_,@OldTimeDate,NumberOfDay,MaCong)
																/(case when isnull(SoPhutCoSoDeQuyDoi,0)=0 then (case when isnull(SoPhutDuocTinhLaMotNgayCong,0)=0 then 480 else SoPhutDuocTinhLaMotNgayCong end) else SoPhutCoSoDeQuyDoi end)
																*(case when isnull(SoPhutDuocTinhLaMotNgayCong,0)=0 then 480 else SoPhutDuocTinhLaMotNgayCong end)
																as WorkingTime
																,case when isnull(@OldCheDo,0) >= 1 then 'TS' else '' end + isnull(@InertSourceHolSun,'')+LEFT(REPLACE(convert(varchar, FromTime, 108),':',''),4)+cast(No_ as varchar)+case when isTCTruoc=1 then 'TCT' else '' end
																
								from [dbo].[udf_ReturnTableSetupHourTimeKeeping](@OldEmployee_ID,@OldShiftName,@OldTimeDate,case when isnull(@OldCheDo,0) > 0 and isnull(@OldLeaveType_ID,'0') <> '0' then 0 else @OldCheDo end,(case when @GioTangCaToiDaTheoNgay<0 then 0 else @GioTangCaToiDaTheoNgay end))
								where fromtime<@LastAccessTimeEditted and ToTime>@FirstAccessTimeEditted
								order by No_
								set @TongGioTangCa=0
								
								--select *, @FirstAccessTimeEditted, @LastAccessTimeEditted, @ShiftFromTime, @ShiftToTime from @HR_WTDAILY

								select @TongGioTangCa=@TongGioTangCa+wt, @GioTangCaToiDaTheoNam=@GioTangCaToiDaTheoNam-wt,@GioTangCaToiDaTheoThang=@GioTangCaToiDaTheoThang-wt from @HR_WTDAILY where macong in (select MaCong from HR_LoaiCong where isnull(isWorkingTime,0)=0 and MaCong not like 'CN%')
								
								-- XỬ LÝ NGƯỜI MỚI VÀO
								set @CongHCNguoiMoi=0
								if @OldStartedDate=@OldTimeDate begin
									select @CongHCNguoiMoi=@CongHCNguoiMoi+wt,@macong=macong from @HR_WTDAILY where MaCong in (select macong from hr_loaicong where isnull(isWorkingTime,0)=1)
									if @CongHCNguoiMoi<8 begin
										insert into @HR_WTDAILY (Employee_ID,Ngay,MaCong,wt,InsertSource) values(@OldEmployee_ID,@OldTimeDate,@macong,8-@CongHCNguoiMoi,case when isnull(@OldCheDo,0) >= 1 then 'TS' else '' end + 'NguoiMoi')
									end
								end
								-- END
								--select [dbo].[udf_TraVeLoaiNgayCong](@OldEmployee_ID,Ngay), @Employee_ID, Ngay, @OldEmployee_ID,@OldShiftName,@OldTimeDate,case when isnull(@OldCheDo,0) > 0 and isnull(@OldLeaveType_ID,'0') <> '0' then 0 else @OldCheDo end,(case when @GioTangCaToiDaTheoNgay<0 then 0 else @GioTangCaToiDaTheoNgay end), * from @HR_WTDAILY
								--select * from [dbo].[udf_ReturnTableSetupHourTimeKeeping](@OldEmployee_ID,@OldShiftName,@OldTimeDate,case when isnull(@OldCheDo,0) > 0 and isnull(@OldLeaveType_ID,'0') <> '0' then 0 else @OldCheDo end,(case when @GioTangCaToiDaTheoNgay<0 then 0 else @GioTangCaToiDaTheoNgay end))
								--where fromtime<@LastAccessTimeEditted and ToTime>@FirstAccessTimeEditted
								--order by No_

								if @OldShiftName = '02-Shift2' begin
									if cast(@FirstAccessTimeEditted as time) <= '17:34:00.000' and (cast(@LastAccessTimeEditted as time) >= '23:00:00.000' or cast(@LastAccessTimeEditted as time) <= '05:00:00.000') begin
										delete @HR_WTdaily where MaCong in ('wt1','wt9')
										insert into @HR_WTdaily (Employee_ID,Ngay,MaCong,wt,InsertSource)
										values (@OldEmployee_ID, @OldTimeDate, 'wt1', 8, '17302')
									end
								end

								insert into HR_WTDAILY (Employee_ID,Ngay,MaCong,wt,InsertSource,UserName)
								select *,@UserName from @HR_WTDAILY
							end
						end
						--Gán để kiểm tra dữ liệu có bị trùng nhau
						set @OldInputEmployee_ID=@OldEmployee_ID set @OldInputTimeOut=@LastAccessTime
						--Nếu quẹt vào ra trùng nhau thì xử lý

						--xử lý lại giờ tan ca của chế độ thai sản. Nếu không quẹt ra đúng giờ thì ko đc tính là ca thai sản
						if isnull(@OldCheDo,0)>=1 and @LastAccessTime<@ShiftToTime begin
							set @ShiftToTime=dateadd(hour,1,@ShiftToTime)
						end
						print 'a114'
						print @ShiftRestFromTime
						print @ShiftRestToTime
						print @ShiftFromTime
						print @ShiftToTime

						set @LateIn=null
						set @EarlyOut=null
						set @RealLateIn = null
						set @RealEarlyOut = null
						if @OldLeaveType_ID is not null and @OldLeaveType_ID not in (31,32,14,60,61,53) begin
							--set @FirstAccessTime=null
							set @FirstAccessTimeEditted=null
							--set @LastAccessTime=null
							set @LastAccessTimeEditted=null
						end else if DATEDIFF(minute,@FirstAccessTime,@LastAccessTime)<=5 begin
							if @OldInOutStatus is not null begin
								if @OldInOutStatus='O' begin
									--set @FirstAccessTime=null
									set @FirstAccessTimeEditted=null
								end else begin
									--set @LastAccessTime=null
									set @LastAccessTimeEditted=null
								end
							end else begin
								if @FirstAccessTime<=DATEADD(hour,4,@ShiftFromTime) begin
									set @LastAccessTime=null
									set @LastAccessTimeEditted=null
								end else begin
									--set @FirstAccessTime=null
									set @FirstAccessTimeEditted=null
								end
							end
						end else begin
							--Tính giờ đi làm muộn
							if @FirstAccessTime>dateadd(minute,isnull(@OldSoPhutChoDiMuon,@OldAllowLateIn),@ShiftFromTime) and @FirstAccessTime<@ShiftToTime begin
								set @LateIn=datediff(minute,@ShiftFromTime,case when isnull(@OldGoutTimeOut,@FirstAccessTime + 1) <= @FirstAccessTime and isnull(@OldGoutLeaveType,'') in ('Business','KhongTruCC') then isnull(@OldGoutTimeOut,@FirstAccessTime) else @FirstAccessTime end)--[dbo].[udf_TinhGioCong](@ShiftFromTime,@FirstAccessTimeEditted,@ShiftFromTime,@ShiftToTime,@ShiftRestFromTime,@ShiftRestToTime,null,0,0,0,2,null)
								set @RealLateIn = datediff(minute,@ShiftFromTime,case when isnull(@OldGoutTimeOut,@FirstAccessTime + 1) <= @FirstAccessTime and isnull(@OldGoutLeaveType,'') in ('Business','KhongTruCC') then isnull(@OldGoutTimeOut,@FirstAccessTime) else @FirstAccessTime end)
								--set @LateIn=datediff(minute,dateadd(minute,@OldAllowLateIn,@ShiftFromTime),@FirstAccessTime)--[dbo].[udf_TinhGioCong](@ShiftFromTime,@FirstAccessTimeEditted,@ShiftFromTime,@ShiftToTime,@ShiftRestFromTime,@ShiftRestToTime,null,0,0,0,2,null)
							end
							--Tính giờ về sớm
							if @LastAccessTime<@ShiftToTime and @LastAccessTime>@ShiftFromTime begin
								set @EarlyOut=datediff(minute,case when isnull(@OldGoutTimeIn,@LastAccessTime - 1) >= @LastAccessTime and isnull(@OldGoutLeaveType,'') in ('Business','KhongTruCC') then isnull(@OldGoutTimeIn,@LastAccessTime) else @LastAccessTime end,@ShiftToTime) --[dbo].[udf_TinhGioCong](@LastAccessTimeEditted,@ShiftToTime,@ShiftFromTime,@ShiftToTime,@ShiftRestFromTime,@ShiftRestToTime,null,0,0,0,2,null)
								set @RealEarlyOut = datediff(minute,case when isnull(@OldGoutTimeIn,@LastAccessTime - 1) >= @LastAccessTime and isnull(@OldGoutLeaveType,'') in ('Business','KhongTruCC') then isnull(@OldGoutTimeIn,@LastAccessTime) else @LastAccessTime end,@ShiftToTime)
								--set @EarlyOut=datediff(minute,@LastAccessTime,@ShiftToTime) --[dbo].[udf_TinhGioCong](@LastAccessTimeEditted,@ShiftToTime,@ShiftFromTime,@ShiftToTime,@ShiftRestFromTime,@ShiftRestToTime,null,0,0,0,2,null)
							end
						end
						--print @FirstAccessTime
						--print @LastAccessTime
						--print @ShiftFromTime
						--print @LateIn
						--Nhập quẹt vào lần đầu và ra lần cuối
						set @SoPhutRanDomGioRa=RAND()*(@SoPhutTieuChuan-0)+0
						set @SoPhutRanDomGioVao=-RAND()*(@SoPhutTieuChuan-0)+0
						print 'abc'
						print @FirstAccessTime
						print @LastAccessTime
						print 'cde'
						insert into HR_TimeIn_TimeOut (Employee_ID,OT_date,ShiftName,RealTimeIn,RealTimeOut,TimeIn,[TimeOut],LateIn,EarlyOut,TimeIn_KH,TimeOut_KH,RealLateIn,RealEarlyOut)
						values(@OldEmployee_ID,@OldTimeDate,@OldShiftName,case when @FirstAccessTime > @ShiftToTime then null else @FirstAccessTime end,@LastAccessTime,@FirstAccessTimeEditted,@LastAccessTimeEditted
						,case when @CongHCNguoiMoi > 0 then 0 else @LateIn end,case when @CongHCNguoiMoi > 0 then 0 else @EarlyOut end
						,case when @FirstAccessTime between dateadd(minute,-@SoPhutTieuChuan,@ShiftFromTime) and dateadd(minute,@SoPhutTieuChuan,@ShiftToTime) then @FirstAccessTime
							else dateadd(minute,@SoPhutRanDomGioVao,@ShiftFromTime) end
						,case when @LastAccessTime between dateadd(minute,-@SoPhutTieuChuan,@ShiftFromTime) and dateadd(minute,@SoPhutTieuChuan,@ShiftToTime) then @LastAccessTime
							else dateadd(minute,@SoPhutRanDomGioRa,dateadd(MINUTE,@TongGioTangCa*60,@ShiftToTime)) end
						,@RealLateIn, @RealEarlyOut)
						-- gán lần quẹt đầu tiếp theo
						if @OldEmployee_ID=@Employee_ID begin
							if @AccessTime>@OldInputTimeOut begin
								set @FirstAccessTime=@AccessTime
							end else begin
								set @FirstAccessTime=null
							end
						end else begin
							set @FirstAccessTime=@AccessTime
						end
					end
				end
			end
			if isnull(@OldEmployee_ID,'')<>@Employee_ID begin
				set @FirstAccessTime=@AccessTime
				set @GioTangCaToiDaTheoNam=@GioTangCaToiDaTheoNam_Goc set @GioTangCaToiDaTheoThang=@GioTangCaToiDaTheoThang_Goc
				set @GioDaTangCaTrongNam=0
				select @GioDaTangCaTrongNam=GioTangCa from @TabTongGioDaTangCaTrongNam where Employee_ID=@Employee_ID
				set @GioTangCaToiDaTheoNam=@GioTangCaToiDaTheoNam-@GioDaTangCaTrongNam
			end
			set @LastAccessTime=@AccessTime
			set @OldEmployee_ID=@Employee_ID set @OldTimeDate=@TimeDate set @OldMaxOverTime=@MaxOverTime set @OldMaxOverTimeBefore=@MaxOverTimeBefore set @OldMaxOverTimeHol=@MaxOverTimeHol set @OldmaxovertimeLunch=@maxovertimeLunch
			set @OldTimeDate = @TimeDate
			set @OldShiftName=@ShiftName
			set @OldShiftFromTime=@ShiftFromTime set @OldShiftTotime=@ShiftToTime
			set @OldInOutStatus=@InOutStatus
			set @OldShiftRestFromTime=@ShiftRestFromTime set @OldShiftRestToTime=@ShiftRestToTime
			set @OldLeaveType_ID=@LeaveType_ID
			set @OldAllowEarlyOut=@AllowEarlyOut set @OldAllowLateIn=@AllowLateIn
			set @OldCheDo=@CheDo set @OldHolSunTypeOfOT=@HolSunTypeOfOT
			set @OldStartedDate=@StartedDate
			set @OldGoutTimeIn = @GoutTimeIn
			set @OldGoutTimeOut = @GoutTimeOut
			set @OldGoutLeaveType = @GoutLeaveType
			set @OldSoPhutChoDiMuon = @SoPhutChoDiMuon
		FETCH NEXT FROM cur INTO @Employee_ID,@LeaveType_ID,@TimeDate,@AccessTime,@InOutStatus,@ShiftName,@MaxOverTime,@MaxOverTimeBefore,@MaxOverTimeHol,@maxovertimeLunch,@CheDo,@HolSunTypeOfOT,@ShiftFromTime,@ShiftToTime,@ShiftRestFromTime,@ShiftRestToTime,@AllowLateIn,@AllowEarlyOut,@MinMinute,@StartedDate,@GoutTimeIn,@GoutTimeOut,@GoutLeaveType,@SoPhutChoDiMuon
		END
		CLOSE cur
		DEALLOCATE cur
	select 'a' as ab
		--Xử lý giờ xin ra ngoài
		exec [dbo].[sp_TinhGioXinRaNgoai] @fromdate,@todate,@UserName,@fact,@Dept,@Sect,@Team,@Pos,@PosC,@Emp
		-- xoa gio cong =0
		delete HR_WTDaily where isnull(wt,0)=0 and ngay between @fromdate and @todate
		-- xu ly thai san
		delete HR_WTDaily
		from HR_WTDaily dl
		inner join
		(
			select ts.Employee_ID,ts.ngay
					,sum(wt.wt) as wt
					--,sum(wt.wt)+sum(isnull(erml.hourleave,0)) as wt
			from
			(
				select * from HR_WTDaily where InsertSource='TS' and ngay between @fromdate and @todate
			)ts
			inner join
			HR_WTDaily wt
			on ts.Employee_ID=wt.Employee_ID and ts.Ngay=wt.Ngay and wt.InsertSource<>'TS'
			left join
			HR_LoaiCong lc
			on wt.MaCong=lc.MaCong
			--left join
			--(select Employee_ID,HourLeave,DateLeave from [dbo].HR_BangPhepDaNghi where DateLeave between @fromdate and @todate and LeaveType_ID in ('31','32')
			--)erml
			--on ts.Employee_ID=erml.Employee_ID and ts.Ngay = erml.DateLeave
			where lc.isWorkingTime=1
			group by ts.Employee_ID,ts.ngay
		) dlxoa
		on dl.Employee_ID=dlxoa.Employee_ID and dl.Ngay=dlxoa.Ngay and dlxoa.wt<4 and dl.InsertSource='TS'
		where dl.Employee_ID in (select Employee_ID from udf_EmployeeFilter('',@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,getdate())))

		update wt
		set wt.wt = 8 - dlxoa.wt
		from
		HR_wtdaily wt
		inner join
		(
			select ts.Employee_ID,ts.ngay,sum(wt.wt)+sum(isnull(erml.hourleave,0)) as wt
			from
			(
				select * from HR_WTDaily where InsertSource='TS' and ngay between @fromdate and @todate
			)ts
			inner join
			HR_WTDaily wt
			on ts.Employee_ID=wt.Employee_ID and ts.Ngay=wt.Ngay and wt.InsertSource<>'TS'
			left join
			HR_LoaiCong lc
			on wt.MaCong=lc.MaCong
			left join
			(select Employee_ID,HourLeave,DateLeave from [dbo].HR_BangPhepDaNghi where DateLeave between @fromdate and @todate and LeaveType_ID in ('31','32')
			)erml
			on ts.Employee_ID=erml.Employee_ID and ts.Ngay = erml.DateLeave
			where lc.isWorkingTime=1
			group by ts.Employee_ID,ts.ngay
		) dlxoa
		on wt.Employee_ID=dlxoa.Employee_ID and wt.Ngay=dlxoa.Ngay
		where wt.Employee_ID in (select Employee_ID from udf_EmployeeFilter('',@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,getdate()))) and wt.InsertSource = 'TS' and dlxoa.wt > 7

		--Xử lý đặc thù: làm đủ thứ 7 S&K
		insert into HR_WTDaily (Employee_ID, Ngay, MaCong, InsertSource, wt, Remark, InsertDate, UserName)
		select erp.Employee_ID, btg.Date_, 'wt1', 'DuGioT7', 8 as TongWt, 'DuGioT7', GETDATE(), @UserName
		from
		udf_BangThoiGian (@fromdate,@todate) btg
		left join
		HR_EmpRegisParameter erp
		on btg.Date_ between erp.Fromdate and erp.Todate
		left join
		(
			select Employee_ID, sum(swt.wt) as TongWt, Ngay
			from
			HR_WTDaily swt
			where swt.Ngay between @fromdate and @todate and MaCong = 'wt1' and swt.InsertSource not in ('DuGioT7')
			group by Employee_ID, Ngay
		) swt
		on swt.Employee_ID = erp.Employee_ID and swt.Ngay = btg.Date_ and swt.Ngay between @fromdate and @todate
		where isnull(swt.Employee_ID,0) >= isnull(erp.Remark,0) and erp.Parameter = 'VeSom' and erp.ParameterValue in ('LamDuThu7','LamDuThu7ToiThieu') and (erp.Fromdate <= btg.Date_ or erp.Todate >= btg.Date_)
				and (case when @Emp is null then '' else erp.Employee_ID end) = (case when @Emp is null then '' else @Emp end)


		Delete wt
		from
		HR_WTDaily wt
		left join
		(
			select Employee_ID, sum(swt.wt) as TongWt, Ngay
			from
			HR_WTDaily swt
			where swt.Ngay between @fromdate and @todate and MaCong = 'wt1' and swt.InsertSource not in ('DuGioT7')
			group by Employee_ID, Ngay
		) swt
		on wt.Employee_ID = swt.Employee_ID and wt.Ngay = swt.Ngay
		left join
		HR_EmpRegisParameter erp
		on wt.Employee_ID = erp.Employee_ID and wt.Ngay between erp.Fromdate and erp.Todate and erp.Parameter = 'VeSom' and erp.ParameterValue in ('LamDuThu7','LamDuThu7ToiThieu')
		where wt.Ngay between @fromdate and @todate and isnull(swt.Employee_ID,0) >= isnull(erp.Remark,0) and wt.MaCong = 'wt1' and wt.InsertSource not in ('NhapTay','DuGioT7') and erp.Employee_ID is not null
				and (case when @Emp is null then '' else wt.Employee_ID end) = (case when @Emp is null then '' else @Emp end)

		--Kết thúc xử lý đặc thù

		--Bắt đầu Xử lý Không quẹt thẻ Shinsung
		delete wt
		from 
		HR_WTDaily wt
		left join
		HR_EmpRegisParameter erp
		on wt.Employee_ID = erp.Employee_ID and wt.Ngay between erp.Fromdate and erp.Todate and erp.ParameterValue = 'KhongQuetThe' and erp.Parameter = 'KhongQuetThe'
		where ngay between @fromdate and @todate and InsertSource <> 'NhapTay' and InsertSource not like '%wt%' and MaCong in ('wt1','wt9') and erp.Employee_ID is not null and (case when @emp is null then '' else erp.Employee_ID end) = (case when @emp is null then '' else @Emp end)

		insert into HR_WTDaily(employee_id,ngay,macong,wt,insertsource,username,insertdate)
		select dkc.Employee_ID,dkc.AccessDate,'wt1',8-isnull(ptn.HourLeave,0),'KhongQuetT',@username,getdate() 
		from
		udf_DangKyCa (@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@Emp) dkc
		left join
		HR_Shifts shi
		on dkc.ShiftName = shi.ShiftName
		left join
		HR_EmpRegisParameter erp
		on dkc.Employee_ID = erp.Employee_ID and dkc.AccessDate between erp.Fromdate and erp.Todate and erp.ParameterValue = 'KhongQuetThe' and erp.Parameter = 'KhongQuetThe'
		left join
		[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) ptn
		on dkc.Employee_ID=ptn.Employee_ID and dkc.AccessDate=ptn.DateLeave and ptn.Remark_ not in ('14.','18.','20.') --and ptn.LeaveType_ID not in (60, 61)
		left join
		SmartBooks_HolidaysPlan hp
		on dkc.AccessDate=hp.H_date
		where isnull(erp.Employee_ID,'') <> '' and dkc.Employee_ID is not null and datename(weekday,dkc.AccessDate)<>'Sunday' /*and datediff(day,@Thu7DuocNghi,dkc.AccessDate) % 14 <> 0*/ and dkc.AccessDate < GETDATE()
				and isnull(ptn.HourLeave,0)<8 and hp.H_date is null and dkc.AccessDate between @fromdate and @todate and dkc.AccessDate <= GETDATE()
				 and (case when @emp is null then '' else erp.Employee_ID end) = (case when @emp is null then '' else @Emp end)

		update tito
		set LateIn = 0, EarlyOut = 0, RealLateIn = 0, RealEarlyOut = 0
		from
		HR_TimeIn_TimeOut tito
		left join
		HR_EmpRegisParameter erp
		on tito.Employee_ID = erp.Employee_ID and tito.OT_date between erp.Fromdate and erp.Todate and erp.ParameterValue = 'KhongQuetThe' and erp.Parameter = 'KhongQuetThe'
		where erp.Employee_ID is not null and (case when @emp is null then '' else erp.Employee_ID end) = (case when @emp is null then '' else @Emp end)
		--Kết thúc xử lý Không quẹt thẻ Shinsung

		--Xử lý công tăng ca chủ nhật
		insert into HR_WTDaily (employee_id,ngay,macong,wt,insertsource,username,insertdate)
		select wt.employee_id,ngay,'CN_wt10', TongWT - (case when empl.DepartmentCode like N'Production_Soi%' then 9 else 8 end), 'AutoWT10',@UserName,GETDATE()
		from
		(
			select employee_id,ngay,sum(wt) as TongWT
			from
			HR_WTDaily
			where MaCong in ('wt4','CN_wt4') and Ngay between @fromdate and @todate
			group by employee_id,ngay
		) wt
		left join
		udf_EmployeeFilter ('VN',null,null,null,null,null,null,@Emp,GETDATE()) empl
		on wt.Employee_ID = empl.Employee_ID
		where wt.TongWT > (case when empl.DepartmentCode like N'Production_Soi%' then 9 else 8 end) and (case when @emp is null then '' else wt.Employee_ID end) = (case when @emp is null then '' else @Emp end)

		insert into HR_WTDaily (employee_id,ngay,macong,wt,insertsource,username,insertdate)
		select wt.employee_id,ngay,'CN_wt11', TongWT - (case when empl.DepartmentCode like N'Production_Soi%' then 9 else 8 end), 'AutoWT11',@UserName,GETDATE()
		from
		(
			select employee_id,ngay,sum(wt) as TongWT
			from
			HR_WTDaily
			where MaCong in ('wt6','CN_wt6') and Ngay between @fromdate and @todate
			group by employee_id,ngay
		) wt
		left join
		udf_EmployeeFilter ('VN',null,null,null,null,null,null,@Emp,GETDATE()) empl
		on wt.Employee_ID = empl.Employee_ID
		where wt.TongWT > (case when empl.DepartmentCode like N'Production_Soi%' then 9 else 8 end) and (case when @emp is null then '' else wt.Employee_ID end) = (case when @emp is null then '' else @Emp end)

		insert into HR_WTDaily (employee_id,ngay,macong,wt,insertsource,username,insertdate)
		select employee_id,ngay,case when InsertSource = 'AutoWT10' then 'CN_wt4' when InsertSource = 'AutoWT11' then 'CN_wt6' end as MaCong, -wt, InsertSource,username,insertdate
		from
		HR_WTDaily
		where InsertSource in ('AutoWT10','AutoWT11') and Ngay between @fromdate and @todate 
			and (case when @emp is null then '' else Employee_ID end) = (case when @emp is null then '' else @Emp end)
		--Kết thúc xử lý công chủ nhật

		--Xử lý đặc thù Shinsung - Đầu bếp k tính chủ nhật và ngày lễ
		Delete wt
		from
		HR_WTDaily wt
		left join
		udf_EmployeeFilter ('VN',@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
		on wt.Employee_ID = empl.Employee_ID and empl.Position_ID = 'Chef'
		where empl.Employee_ID is not null and wt.Ngay between @fromdate and @todate and DATENAME(dw,wt.Ngay) = 'Sunday' and wt.InsertSource <> 'NhapTay'
		--Kết thúc xử lý đặc thù Shinsung - Đầu bếp k tính chủ nhật và ngày lễ

		--xoa cong trung voi lich nghi le, phep nam
		delete wt from
		HR_WTDaily wt
		inner join
		SmartBooks_HolidaysPlan hp
		on wt.Ngay=hp.H_date
		where wt.Ngay between @fromdate and @todate
			and wt.Employee_ID in (select Employee_ID from udf_EmployeeFilter('VN',@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,getdate())) where Employee_ID='21111930')

			 

		set @sqlquery = N'exec sp_Insert_HR_BangPhepDaNghi @fromdate, @todate, null, null, null, null, null, null, @Emp'

		execute sp_executesql @sqlQuery
					, N'@fromdate datetime, @todate datetime, @Emp nvarchar(50)'
					, @fromdate = @fromdate, @todate = @todate, @Emp = @Emp

		
		--Update giờ làm sau khi trừ giờ nghỉ
		insert into HR_WTDaily (Employee_ID, Ngay, MaCong, InsertSource, wt, Remark, InsertDate, UserName)
		select bpdn.Employee_ID, bpdn.DateLeave, 'wt1', 'AutoTruP', 8 - bpdn.HourLeave - wt.TongWT, 'AutoTruPhep', GETDATE(), @UserName
		from
		HR_BangPhepDaNghi bpdn
		left join
		(
			select Employee_ID, Ngay, sum(wt.wt) as TongWT
			from
			HR_WTDaily wt
			where Ngay between @fromdate and @todate and wt.MaCong in ('wt1','wt9') and InsertSource not in ('NhapTay')
			group by Employee_ID, Ngay
		) wt
		on bpdn.Employee_ID = wt.Employee_ID and bpdn.DateLeave = wt.Ngay
		where (isnull(wt.TongWT,0) = 8 or isnull(wt.TongWT,0) + bpdn.HourLeave > 8) and wt.TongWT is not null and bpdn.DateLeave between @fromdate and @todate
				and (case when @Emp is null then '' else bpdn.Employee_ID end) = (case when @Emp is null then '' else @Emp end)

		set @ThongBao=N'Thanhcong'
		
	end
	select @ThongBao as ThongBao
END

GO
