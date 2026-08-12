CREATE PROCEDURE [dbo].[sp_BangCong]
	-- Add the parameters for the stored procedure here
	--exec [dbo].[sp_BangCong] '2025-08-30','2025-08-30', 3,'VN','ADMIN',NULL,NULL,NULL,NULL,NULL,NULL,'C0015',null
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,
	@LAN nvarchar(50)='VN',
	@UserName nvarchar(50)=null,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@emp nvarchar(50)=null,
	@ListOfKey nvarchar(max)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @tabDate table(Ngay datetime, primary key (Ngay))
	declare @dtnext datetime,@AccessTime time,@ShiftName nvarchar(50),@Reason nvarchar(50),@Remark nvarchar(max),@RealTimeIn time(0),@RealTimeOut time(0),@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan int
		,@SQLMaCong nvarchar(1000),@SQLSumMaCong nvarchar(1000),@MaCong varchar(10),@SQL nvarchar(max),@DSMaCong varchar(1000),@SQLViewCong nvarchar(1000)
		,@TrangThaiKH int, @Thu7DuocNghi datetime, @Thu7DuocNghiNvarchar nvarchar(50)
		,@NgayDauThang datetime, @NgayCuoiThang datetime, @Ngay15 datetime
	--select @Thu7DuocNghi = [Value] from SetUp where FunctionID = 'Thu7DuocNghi' and ID = 'T7DN'
	--select @Thu7DuocNghiNvarchar = CONVERT(nvarchar(50),@Thu7DuocNghi,111)
	set @TrangThaiKH=[dbo].[udf_TrangThaiKH](@UserName)
	select @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan=[Value] from [dbo].[SetUp] where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
	set @NgayDauThang = DATEFROMPARTS (Year(@fromdate),Month(@todate),1)
	set @Ngay15 = DATEFROMPARTS (Year(@fromdate),Month(@todate),15)
	set @NgayCuoiThang = EOMONTH(@NgayDauThang)
	set @dtnext=@fromdate
	while @dtnext<=@todate begin
		insert into @tabDate (Ngay) values(@dtnext)
		set @dtnext=@dtnext+1
	end
	if @TypeOfReport=1 begin--=1 thì xem all
		SELECT	
				[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Employee_ID
				,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
				,empl.Tel
				,empl.StartedDate,tabdate.Ngay
				,cast((case when @TrangThaiKH=1 then isnull(tito.TimeIn_KH,dlqkh.TimeIn)
					else tito.RealTimeIn end) as time(0)) as RealTimeIn
				,cast((case when @TrangThaiKH=1 then isnull(tito.TimeOut_KH,dlqkh.[TimeOut])
				else tito.RealTimeOut end) as time(0)) as RealTimeOut
				,tito.LateIn,tito.EarlyOut
				,ctn.wt,lc.MaCong,lc.LoaiCong,ctn.InsertSource
				,mot.maxovertime
				,ptn.LeaveType_ID
				,ctn.Remark,ctn.InsertDate,ctn.UserName
		from
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		left join
		@tabDate tabdate
		on empl.ComStartedDate<=tabdate.Ngay and (empl.TernimationDate is null or empl.TernimationDate>tabdate.Ngay)
		left join
		[dbo].[HR_WTDaily] as ctn
		on ctn.Ngay=tabdate.Ngay and empl.Employee_ID=ctn.Employee_ID
		left join
		HR_MaxOvertime mot
		on empl.Employee_ID = mot.Employee_id and tabdate.Ngay = mot.workingdate
		left join
		HR_TimeIn_TimeOut tito
		on empl.Employee_ID = tito.Employee_ID and tabdate.Ngay = tito.OT_date
		left join
		[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) ptn
		on empl.Employee_ID=ptn.Employee_ID and tabdate.Ngay=ptn.Dateleave
		left join
		HR_LoaiCong lc
		on ctn.MaCong=lc.MaCong
		--left join
		--udf_DanhSachNhanVienDuocHuongNghiLe(@fromdate,@todate) hp
		--on tabdate.Ngay=hp.H_date and empl.Employee_ID=hp.Employee_ID
		left join
		HR_DuLieuQuetKhachHang dlqkh
		on empl.Employee_ID=dlqkh.Employee_ID and tabdate.Ngay=dlqkh.workingdate
		where tabdate.Ngay is not null and (ctn.Employee_ID is not null or ptn.Employee_ID is not null)
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID, StartedDate,ctn.Ngay,lc.LoaiCong
	end else if @TypeOfReport in (2,3,4,93) begin
		declare @SummaryOfMaxOT as table(
			[Employee_ID] [nvarchar](50) NOT NULL,
			[workingdate] [datetime] NOT NULL,
			maxovertime [float] NULL,
			primary key ([Employee_ID],[workingdate])
		)
		insert into @SummaryOfMaxOT
		select Employee_ID,workingdate,sum(maxovertime) from HR_MaxOvertime where workingdate between @fromdate and @todate group by Employee_ID,workingdate
		IF OBJECT_ID('tempdb..#tabBangCong') IS NOT NULL DROP TABLE #tabBangCong
			SELECT	
					[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Employee_ID
					,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName, empl.Tel
					,empl.StartedDate,empl.TernimationDate,tabdate.Ngay
					,cast((case when @TrangThaiKH=1 then isnull(tito.TimeIn_KH,dlqkh.TimeIn)
						else tito.RealTimeIn end) as time(0)) as RealTimeIn
					,cast((case when @TrangThaiKH=1 then isnull(tito.TimeOut_KH,dlqkh.[TimeOut])
						else tito.RealTimeOut end) as time(0)) as RealTimeOut
					,tito.LateIn,tito.EarlyOut
					,wtTinhCong.wt
					,lc.MaCong,lc.LoaiCong
					,wtTinhCong.InsertSource
					,mot.maxovertime,isnull(tito.ShiftName,erts.ShiftName) as ShiftName
					,ptn.HourLeave
					,ptn.LeaveType_ID
					,lt.AbsentSign
					,wtTinhCong.Remark
					,wtTinhCong.InsertDate
					,wtTinhCong.UserName
					,lt.isLeave_ComPay
					,s.ShiftSign
					,f.OrderBy
					into #tabBangCong
			from
			[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
			left join
			@tabDate tabdate
			on empl.ComStartedDate<=tabdate.Ngay and (empl.TernimationDate is null or empl.TernimationDate>tabdate.Ngay)
			left join
			HR_LoaiCong lc
			on empl.ComStartedDate<=tabdate.Ngay and (empl.TernimationDate is null or empl.TernimationDate>tabdate.Ngay)
			left join
			[dbo].[udf_BangCong](@fromdate,@todate,case when @TypeOfReport<100 then 0 else 1 end) as wtTinhCong
			on wtTinhCong.Ngay=tabdate.Ngay and empl.Employee_ID=wtTinhCong.Employee_ID and lc.MaCong=wtTinhCong.MaCong
			left join
			@SummaryOfMaxOT mot
			on empl.Employee_ID = mot.Employee_id and tabdate.Ngay = mot.workingdate
			left join
			HR_TimeIn_TimeOut tito
			on empl.Employee_ID = tito.Employee_ID and tabdate.Ngay = tito.OT_date
			left join
			udf_DangKyCa(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@emp) erts
			on empl.Employee_ID COLLATE DATABASE_DEFAULT=erts.Employee_ID and tabdate.Ngay=erts.AccessDate
			left join
			HR_Shifts s
			on isnull(tito.ShiftName,erts.ShiftName)=s.ShiftName
			left join
			HR_DuLieuQuetKhachHang dlqkh
			on empl.Employee_ID=dlqkh.Employee_ID and tabdate.Ngay=dlqkh.workingdate
			left join
			[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) ptn
			on empl.Employee_ID=ptn.Employee_ID and tabdate.Ngay=ptn.Dateleave
			--left join
			--udf_DanhSachNhanVienDuocHuongNghiLe(@fromdate,@todate) hp
			--on tabdate.Ngay=hp.H_date and empl.Employee_ID=hp.Employee_ID
			left join
			SmartBooks_LeaveType lt
			on ptn.LeaveType_ID=lt.LeaveType_ID
			left join
			HR_Factory f
			on empl.Factory_ID=f.Factory_ID

			--left join
			--udf_NgayKyHDChinhThuc(@fromdate,@todate,@emp) nct
			--on empl.Employee_ID=nct.Employee_ID
			--where tabdate.Ngay is not null
			where tabdate.Ngay is not null --and isnull(empl.Nationality,'')<>'Non-Vietnamese'-- and isnull(ptn.LeaveType_ID,'')<>'24'
				and empl.Employee_ID not in (select Employee_ID from HR_EmployeeRegisMaternityLeave where Fromdate<=@fromdate and todate>=@todate and LeaveType_ID='24')
		
		if @TypeOfReport=2 begin--=2 xem công tính lương theo chiều dọc
			select * from #tabBangCong where wt>0 or isnull(LeaveType_ID,'')<>'' order by FactoryName,DepartmentName,SectionName,StartedDate,Ngay,LoaiCong
		end else if @TypeOfReport=3 begin--=3 xem côgn tính lương theo chiều ngang

			--select * from #tabBangCong where Employee_ID = @emp

			set @SQLMaCong=''
			set @SQLSumMaCong=''
			set @SQLViewCong=''
			DECLARE cur CURSOR LOCAL FOR
			SELECT MaCong FROM HR_LoaiCong order by OrderBy asc
			OPEN  cur 
			FETCH NEXT FROM cur INTO @MaCong
			WHILE @@FETCH_STATUS = 0
			BEGIN
				if @TrangThaiKH=1 begin
					if @MaCong not like 'CN%' begin
						set @SQLMaCong=@SQLMaCong+@MaCong+','
						set @SQLViewCong=@SQLViewCong+@MaCong+','
						set @SQLSumMaCong=@SQLSumMaCong+'isnull('+@MaCong+',0)+'
					end
				end else if @TrangThaiKH = 2 begin
					if @MaCong like 'CN%' begin
						set @SQLMaCong=@SQLMaCong+@MaCong+','
						set @SQLViewCong=@SQLViewCong+@MaCong+','
						set @SQLSumMaCong=@SQLSumMaCong+'isnull('+@MaCong+',0)+'
					end
				end else begin
					print 'a'
					set @SQLMaCong=@SQLMaCong+@MaCong+','
					set @SQLSumMaCong=@SQLSumMaCong+'isnull('+@MaCong+',0)+'
					if @MaCong like 'CN%' begin
						print'b'
						print @SQLViewCong
						set @SQLViewCong=left(@SQLViewCong,len(@SQLViewCong)-8)
						set @SQLViewCong=@SQLViewCong + ' + isnull(' +@MaCong+',0) as ' + SUBSTRING(@MaCong,4,15) + ','
						print 'c'
						print @SQLViewCong
					end else begin
						set @SQLViewCong=@SQLViewCong+ 'isnull(' +@MaCong+',0) as ' + @MaCong + ','
					end
					print 'd'
					print @SQLViewCong
				end
				FETCH NEXT FROM cur INTO @MaCong
			END
			CLOSE cur
			DEALLOCATE cur
			set @SQLMaCong=left(@SQLMaCong,len(@SQLMaCong)-1)
			set @SQLSumMaCong=left(@SQLSumMaCong,len(@SQLSumMaCong)-1)
			set @SQLViewCong=left(@SQLViewCong,len(@SQLViewCong)-1)
			--set @SQL='select ctn.PositionFullName,ctn.FactoryName,ctn.DepartmentName,ctn.SectionName,ctn.PositionName,ctn.ChucDanh,ctn.FullName,ctn.Employee_ID,StartedDate,ctn.TernimationDate,ctn.Ngay,cast(RealTimeIn as time(0)) as RealTimeIn,cast(RealTimeOut as time(0)) as RealTimeOut,ShiftName
			set @SQL='select ctn.FullName,ctn.Employee_ID, ctn.FactoryName, ctn.DepartmentName, ctn.SectionName, ctn.ChucDanhName, ctn.StartedDate,ctn.TernimationDate,ctn.Ngay,cast(RealTimeIn as time(0)) as RealTimeIn,cast(RealTimeOut as time(0)) as RealTimeOut,ShiftName
			,case when LeaveType_ID = 53 then absentSign when (DATENAME(DW,ctn.Ngay)=''Sunday'' and wds.WorkingDayType is null) or wds.WorkingDayType=''Sun'' then N''ChuNhat'' when '+@SQLSumMaCong+'=0 and isnull(LeaveType_ID,'''')='''' then N''KhongPhep'' else AbsentSign end as GhiChu, 
			'+@SQLViewCong+',LateIn,EarlyOut,maxovertime,AbsentSign,LeaveType_ID,HourLeave,isLeave_ComPay,ShiftSign
				from (select FactoryName,DepartmentName,SectionName,ChucDanhName,FullName,Employee_ID,StartedDate,TernimationDate,Ngay,RealTimeIn,RealTimeOut,wt,macong,LateIn,EarlyOut,maxovertime,ShiftName,LeaveType_ID,HourLeave,AbsentSign,isLeave_ComPay,ShiftSign,orderby '
				+'from #tabBangCong) a pivot(sum(wt) for macong in ('+@SQLMaCong+'))ctn left join HR_WorkingDaySpecial wds on ctn.Ngay=wds.WorkingDate and ctn.Employee_ID=wds.Employee_ID
				order by ctn.orderby,ctn.FactoryName,ctn.DepartmentName,ctn.SectionName,ctn.Employee_ID, ctn.Ngay'
			print @sql
			exec sp_executesql @SQL
				,N'@Thu7DuocNghi datetime', @Thu7DuocNghi = @Thu7DuocNghi
			--exec [dbo].[sp_BangCong] '2025-07-01','2025-07-31', 3,'VN','ADMIN',NULL,NULL,NULL,NULL,NULL,NULL,'C10851',null
			end else if @TypeOfReport=93 begin--=3 xem côgn tính lương theo chiều ngang
			set @SQLMaCong=''
			set @SQLSumMaCong=''
			set @SQLViewCong=''
			DECLARE cur CURSOR LOCAL FOR
			SELECT MaCong FROM HR_LoaiCong order by OrderBy asc
			OPEN  cur 
			FETCH NEXT FROM cur INTO @MaCong
			WHILE @@FETCH_STATUS = 0
			BEGIN
				if @TrangThaiKH=1 begin
					if @MaCong not like 'CN%' begin
						set @SQLMaCong=@SQLMaCong+@MaCong+','
						set @SQLViewCong=@SQLViewCong+@MaCong+','
						set @SQLSumMaCong=@SQLSumMaCong+'isnull('+@MaCong+',0)+'
					end
				end else begin
					print 'a'
					set @SQLMaCong=@SQLMaCong+@MaCong+','
					set @SQLSumMaCong=@SQLSumMaCong+'isnull('+@MaCong+',0)+'
					if @MaCong like 'CN%' begin
						print'b'
						print @SQLViewCong
						set @SQLViewCong=left(@SQLViewCong,len(@SQLViewCong)-8)
						set @SQLViewCong=@SQLViewCong + ' + isnull(' +@MaCong+',0) as ' + SUBSTRING(@MaCong,4,15) + ','
						print 'c'
						print @SQLViewCong
					end else begin
						set @SQLViewCong=@SQLViewCong+ 'isnull(' +@MaCong+',0) as ' + @MaCong + ','
					end
					print 'd'
					print @SQLViewCong
				end
				FETCH NEXT FROM cur INTO @MaCong
			END
			CLOSE cur
			DEALLOCATE cur
			set @SQLMaCong=left(@SQLMaCong,len(@SQLMaCong)-1)
			set @SQLSumMaCong=left(@SQLSumMaCong,len(@SQLSumMaCong)-1)
			set @SQLViewCong=left(@SQLViewCong,len(@SQLViewCong)-1)
			set @SQL='select ctn.FullName,ctn.Employee_ID, ctn.FactoryName, ctn.DepartmentName, ctn.SectionName, ctn.ChucDanhName,ctn.Tel,ctn.FullName,ctn.Employee_ID,StartedDate,ctn.TernimationDate,ctn.Ngay,cast(RealTimeIn as time(0)) as RealTimeIn,cast(RealTimeOut as time(0)) as RealTimeOut,ShiftName
			,case when LeaveType_ID = 53 then absentSign when (DATENAME(DW,ctn.Ngay)=''Sunday'' and wds.WorkingDayType is null) or wds.WorkingDayType=''Sun'' then N''ChuNhat'' when '+@SQLSumMaCong+'=0 and isnull(LeaveType_ID,'''')='''' then N''KhongPhep'' else AbsentSign end as GhiChu, 
			'+@SQLViewCong+',LateIn,EarlyOut,maxovertime,AbsentSign,LeaveType_ID,HourLeave,isLeave_ComPay,ShiftSign, blcd.*
				from (select PositionFullName, FactoryName,DepartmentName,SectionName,PositionName,ChucDanh,Tel,FullName,Employee_ID,StartedDate,TernimationDate,Ngay,RealTimeIn,RealTimeOut,wt,macong,LateIn,EarlyOut,maxovertime,ShiftName,LeaveType_ID,HourLeave,AbsentSign,isLeave_ComPay,ShiftSign,orderby '
				+'from #tabBangCong) a pivot(sum(wt) for macong in ('+@SQLMaCong+'))ctn left join HR_WorkingDaySpecial wds on ctn.Ngay=wds.WorkingDate and ctn.Employee_ID=wds.Employee_ID
				left join udf_BangLuongCoDinh (@todate,@Emp) blcd on ctn.Employee_ID = blcd.Employee_ID
				order by ctn.orderby,ctn.FactoryName,ctn.DepartmentName,ctn.SectionName,ctn.Employee_ID, ctn.Ngay'
			print @sql
			exec sp_executesql @SQL
				,N'@Thu7DuocNghi datetime, @todate datetime, @Emp nvarchar(50)'
				, @Thu7DuocNghi = @Thu7DuocNghi
				, @todate = @todate
				, @Emp = @Emp
			--exec [dbo].[sp_BangCong] '2025-07-01','2025-07-31', 93,'VN','ADMIN',NULL,NULL,NULL,NULL,NULL,NULL,'C10851',null
		end else if @TypeOfReport=4 begin --xuất bảng công chi tiết theo tháng
			set @SQLMaCong=''
			DECLARE cur CURSOR LOCAL FOR
			SELECT MaCong FROM HR_LoaiCong
			OPEN  cur 
			FETCH NEXT FROM cur INTO @MaCong
			WHILE @@FETCH_STATUS = 0
			BEGIN
				set @SQLMaCong=@SQLMaCong+@MaCong+','
			END
			CLOSE cur
				FETCH NEXT FROM cur INTO @MaCong
			DEALLOCATE cur
			set @SQLMaCong=left(@SQLMaCong,len(@SQLMaCong)-1)
			set @SQL='select Position,FullName,Employee_ID,StartedDate,Ngay,cast(RealTimeIn as time(0)) as RealTimeIn,cast(RealTimeOut as time(0)) as RealTimeOut,'+@SQLMaCong+',maxovertime,ShiftName,LeaveType_ID from (select Position,FullName,Employee_ID,StartedDate,Ngay,RealTimeIn,RealTimeOut,wt,macong,maxovertime,ShiftName,LeaveType_ID '
				+'from #tabBangCong where Ngay between '''+CONVERT(varchar,@fromdate,112)+''' and '''+CONVERT(varchar,@todate,112)+''') a pivot(sum(wt) for macong in ('+@SQLMaCong+')) ctn'
			exec (@SQL)
		end
	end else if @TypeOfReport=5 begin-- danh sách chỉ có quẹt vào
			select 
			[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Employee_ID
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,tito.OT_date as Ngay,cast(tito.RealTimeIn as time) as RealTimeIn,cast(tito.RealTimeOut as time) as RealTimeOut,@Reason as Reason,@Remark as Remark,tito.ShiftName,mot.maxovertime
			,ptn.LeaveType_ID
			,(case when cdo.Employee_ID is not null then 'CheDo' else null end) CheDo
			from
			[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
			left join
			HR_TimeIn_TimeOut tito
			on empl.Employee_ID=tito.Employee_ID
			left join
			[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) ptn
			on empl.Employee_ID=ptn.Employee_ID and tito.OT_date = ptn.DateLeave
			left join
			(select Employee_ID,workingdate,sum(maxovertime) as maxovertime from HR_MaxOvertime where workingdate between @fromdate and @todate group by Employee_ID,workingdate) mot
			on empl.Employee_ID = mot.Employee_id and tito.OT_date = mot.workingdate
			left join
			udf_DanhSachHuongCheDo(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan) cdo
			on tito.Employee_ID=cdo.Employee_ID and (tito.OT_date between cdo.babyFromdate and cdo.babyTodate or tito.OT_date between cdo.pregFromdate and cdo.pregTodate or tito.OT_date between cdo.DisableFromDate and cdo.DisableToDate or tito.OT_date between cdo.OldFromdate and cdo.OldTodate)-- or tito.OT_date between cdo.Duoi18Fromdate and cdo.Duoi18Todate)

			where (tito.RealTimeIn is not null and tito.RealTimeOut is null
				and tito.OT_date between @fromdate and @todate
				and (ptn.Employee_ID is null or ptn.LeaveType_ID in ('31','31','14','60')))
				or 
				(tito.RealTimeIn is not null and tito.RealTimeOut is null
				and tito.OT_date between @fromdate and @todate)
	end else if @TypeOfReport=6 begin-- danh sách chỉ có quẹt ra
			select 
			[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Employee_ID
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,tito.OT_date as Ngay,cast(tito.RealTimeIn as time) as RealTimeIn,cast(tito.RealTimeOut as time) as RealTimeOut,@Reason as Reason,@Remark as Remark,tito.ShiftName,mot.maxovertime
			,(case when cdo.Employee_ID is not null then 'CheDo' else null end) CheDo
			from
			[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
			left join
			HR_TimeIn_TimeOut tito
			on empl.Employee_ID=tito.Employee_ID
			left join
			[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) ptn
			on empl.Employee_ID=ptn.Employee_ID and tito.OT_date=ptn.DateLeave
			left join
			(select Employee_ID,workingdate,sum(maxovertime) as maxovertime from HR_MaxOvertime where workingdate between @fromdate and @todate group by Employee_ID,workingdate) mot
			on empl.Employee_ID = mot.Employee_id and tito.OT_date = mot.workingdate
			left join
			udf_DanhSachHuongCheDo(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan) cdo
			on tito.Employee_ID=cdo.Employee_ID and (tito.OT_date between cdo.babyFromdate and cdo.babyTodate or tito.OT_date between cdo.pregFromdate and cdo.pregTodate or tito.OT_date between cdo.DisableFromDate and cdo.DisableToDate or tito.OT_date between cdo.OldFromdate and cdo.OldTodate)-- or tito.OT_date between cdo.Duoi18Fromdate and cdo.Duoi18Todate)
			where (tito.RealTimeIn is null and tito.RealTimeOut is not null
				and tito.OT_date between @fromdate and @todate
				and (ptn.Employee_ID is null or ptn.LeaveType_ID in ('31','31','14','61')))
				or
				(tito.RealTimeIn is null and tito.RealTimeOut is not null
				and tito.OT_date between @fromdate and @todate)
	end else if @TypeOfReport=7 begin-- late in EarlyOut
			select [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Employee_ID
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,tito.OT_date as Ngay,cast(tito.RealTimeIn as time) as RealTimeIn,cast(tito.RealTimeOut as time) as RealTimeOut,@Reason as Reason,@Remark as Remark,tito.ShiftName,tito.LateIn,tito.EarlyOut,mot.maxovertime
			,ptn.LeaveType_ID
			,(case when cdo.Employee_ID is not null then 'CheDo' else null end) CheDo
			,(case when empl.sex='Male' then dateadd(year,60,empl.BirthDate) else dateadd(year,55,empl.BirthDate) end) as RetireDate
			from
			[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
			left join
			HR_TimeIn_TimeOut tito
			on empl.Employee_ID=tito.Employee_ID
			left join
			[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) ptn
			on empl.Employee_ID=ptn.Employee_ID and tito.OT_date=ptn.DateLeave
			left join
			(select Employee_ID,workingdate,sum(maxovertime) as maxovertime from HR_MaxOvertime where workingdate between @fromdate and @todate group by Employee_ID,workingdate) mot
			on empl.Employee_ID = mot.Employee_id and tito.OT_date = mot.workingdate
			left join
			udf_DanhSachHuongCheDo(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan) cdo
			on tito.Employee_ID=cdo.Employee_ID and (tito.OT_date between cdo.babyFromdate and cdo.babyTodate or tito.OT_date between cdo.pregFromdate and cdo.pregTodate or tito.OT_date between cdo.DisableFromDate and cdo.DisableToDate or tito.OT_date between cdo.OldFromdate and cdo.OldTodate)-- or tito.OT_date between cdo.Duoi18Fromdate and cdo.Duoi18Todate)
			left join
			udf_Position(@LAN,0) p
			on empl.Position=p.Code
			where (tito.LateIn is not null or tito.EarlyOut is not null)
				and tito.OT_date between @fromdate and @todate
				and (ptn.Employee_ID is null or ptn.LeaveType_ID in ('31','31')) and isnull(tito.LateIn,0) + isnull(tito.EarlyOut,0) > 0

	end else if @TypeOfReport=8 begin-- danh sách tăng ca bất thường
			select [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Employee_ID
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,mot.workingdate as Ngay,cast(tito.RealTimeIn as time) as RealTimeIn,cast(tito.RealTimeOut as time) as RealTimeOut,@Reason as Reason,@Remark as Remark,ot.WokingTime as RealOT,mot.maxovertime,erts.ShiftName,ptn.LeaveType_ID
			from
			(select Employee_ID,workingdate,sum(maxovertime) as maxovertime from HR_MaxOvertime where workingdate between @fromdate and @todate group by Employee_ID,workingdate) mot
			left join
			(select Employee_ID,Ngay,sum(isnull(wt,0)) as WokingTime from HR_WTDaily where Ngay between @fromdate and @todate and MaCong in (select MaCong from HR_LoaiCong where isnull(isWorkingTime,0)=0) and MaCong not in ('wt11','wt12') group by Employee_ID,Ngay) as ot
			on mot.Employee_ID=ot.Employee_ID and mot.workingdate=ot.Ngay
			left join
			[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
			on mot.Employee_ID=empl.Employee_ID
			left join
			HR_TimeIn_TimeOut tito
			on mot.Employee_ID=tito.Employee_ID and mot.workingdate=tito.OT_date
			left join
			udf_DangKyCa(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@emp) erts
			on mot.Employee_ID COLLATE DATABASE_DEFAULT=erts.Employee_ID and mot.workingdate=erts.AccessDate
			left join
			[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) ptn
			on mot.Employee_ID=ptn.Employee_ID and mot.workingdate=ptn.DateLeave
			where empl.Employee_ID is not null and isnull(ot.WokingTime,0)<>mot.maxovertime
	end else if @TypeOfReport=9 begin-- danh sách không có công bất thường
			select empl.Employee_ID
			,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,wd.Ngay,cast(tito.RealTimeIn as time) as RealTimeIn,cast(tito.RealTimeOut as time) as RealTimeOut,@Reason as Reason,erts.ShiftName,mot.maxovertime,ptn.LeaveType_ID
			,(case when tito.RealTimeIn is null and tito.RealTimeOut is null then 'No Scan'
					when tito.RealTimeIn is null and tito.RealTimeOut is not null then 'In'
					when tito.RealTimeIn is not null and tito.RealTimeOut is null then 'Out'
			 end) as Remark
			 ,(case when cdo.Employee_ID is not null then 'CheDo' else null end) CheDo
			from
			[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
			left join
			@tabDate wd
			on empl.ComStartedDate<=wd.Ngay and (empl.TernimationDate is null or empl.TernimationDate>wd.Ngay)
			left join
			(select Employee_ID,Ngay,sum(wt) as wt from HR_WTDaily where ngay between @fromdate and @todate group by Employee_ID,Ngay) wt
			on empl.Employee_ID=wt.Employee_ID and wd.Ngay=wt.Ngay
			left join
			[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) ptn
			on empl.Employee_ID=ptn.Employee_ID and wd.Ngay=ptn.Dateleave
			left join
			HR_MaxOvertime motSunHol
			on empl.Employee_ID=motSunHol.Employee_ID and wd.Ngay=motSunHol.workingdate and motSunHol.TypeOfOT in ('4','5')
			left join
			HR_MaxOvertime motNNB
			on empl.Employee_ID=motNNB.Employee_ID and wd.Ngay=motNNB.NgayNghiBu
			left join
			(select Employee_ID,workingdate,sum(maxovertime) as maxovertime from HR_MaxOvertime where workingdate between @fromdate and @todate group by Employee_ID,workingdate) mot
			on empl.Employee_ID=mot.Employee_ID and wd.Ngay=mot.workingdate
			left join
			SmartBooks_HolidaysPlan hp
			on wd.Ngay=hp.H_date
			left join
			udf_DangKyCa(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@emp) erts
			on empl.Employee_ID COLLATE DATABASE_DEFAULT=erts.Employee_ID and wd.Ngay=erts.AccessDate
			left join
			HR_TimeIn_TimeOut tito
			on empl.Employee_ID=tito.Employee_ID and wd.Ngay=tito.OT_date
			left join
			udf_Position(@LAN,0) p
			on ISNULL(empl.TeamCode,isnull(empl.sectioncode,isnull(empl.DepartmentCode,isnull(factory_ID,''))))=p.Code
			left join
			SmartBooks_Department dept
			on empl.DepartmentCode=dept.Factory_ID+'_'+dept.DepartmentCode
			left join
			udf_DanhSachHuongCheDo(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan) cdo
			on empl.Employee_ID=cdo.Employee_ID and (wd.Ngay between cdo.babyFromdate and cdo.babyTodate or wd.Ngay between cdo.pregFromdate and cdo.pregTodate or wd.Ngay between cdo.DisableFromDate and cdo.DisableToDate or wd.Ngay between cdo.OldFromdate and cdo.OldTodate)-- or wd.Ngay between cdo.Duoi18Fromdate and cdo.Duoi18Todate)

			where wt.Employee_ID is null
				and (
						(ptn.LeaveType_ID in ('31','32','14') or (ptn.LeaveType_ID is null and motNNB.Employee_ID is null))
						
					)
				and ((motSunHol.Employee_ID is not null) or (DATENAME(WEEKDAY,wd.Ngay)<>'Sunday' and hp.H_date is null))
			order by empl.Factory_ID,empl.DepartmentCode,empl.SectionCode,empl.TeamCode
	end else if @TypeOfReport=10 begin
		-- lấy danh danh sách công, phép
		set @SQLMaCong=''
			DECLARE cur CURSOR LOCAL FOR
			select lable from
			(SELECT MaCong as Lable,'A' as Nhom FROM HR_LoaiCong where macong not like 'CN_%'
			union all
			SELECT MaCong as Lable,'B' as Nhom FROM HR_LoaiCong where macong like 'CN_%' and isnull(@trangthaikh,0)=0
			union all
			select AbsentSign as Lable, 'C' as Nhom from SmartBooks_LeaveType
			) macong
			order by Nhom, lable asc
			OPEN  cur 
			FETCH NEXT FROM cur INTO @MaCong
			WHILE @@FETCH_STATUS = 0
			BEGIN
				set @SQLMaCong=@SQLMaCong+replace(@MaCong,'/','')+','
				FETCH NEXT FROM cur INTO @MaCong
			END
			CLOSE cur
			DEALLOCATE cur
			set @SQLMaCong=@SQLMaCong+'LateIn,EarlyOut,GoOut,QuenQuet'
		IF OBJECT_ID('tempdb..#tabTongHopCongPhep') IS NOT NULL DROP TABLE #tabTongHopCongPhep
		select * into #tabTongHopCongPhep from
		(
		--Tổng công
		select Employee_ID,sum(isnull(wt,0)) as Value, MaCong as Lable from hr_wtdaily where ngay between @fromdate and @todate group by Employee_ID, macong
		union all
		--Tổng giờ nghỉ phép
		select Employee_ID,sum(isnull(HourLeave,0)) as Value, lt.AbsentSign as Lable from
		udf_BangPhepTheoNgay(2,@fromdate,@todate,null,null,null,null,null,null,null,null) ptn
		left join
		SmartBooks_LeaveType lt
		on ptn.LeaveType_ID=lt.LeaveType_ID
		where DateLeave between @fromdate and @todate group by Employee_ID,lt.AbsentSign
		--Đếm số giờ lần đi muộn
		union all
		select Employee_ID,count(Employee_ID) as Value,'LateIn' as Lable from HR_TimeIn_TimeOut where ot_date between @fromdate and @todate and latein>0 group by Employee_ID
		--Đếm số lần về sớm
		union all
		select Employee_ID,count(Employee_ID) as Value,'EarlyOut' as Lable from HR_TimeIn_TimeOut where ot_date between @fromdate and @todate and EarlyOut>0 group by Employee_ID
		--Đếm số lần đi ra ngoài giữa giờ
		union all
		select Employee_ID,count(Employee_ID) as Value,'GoOut' as Lable from HR_GoOut where TimeDate between @fromdate and @todate group by Employee_ID
		--Đêm số lần quên quẹt thẻ
		union all
		(
			select Employee_ID,count(Employee_ID),'QuenQuet' as Lable from
			(select distinct Employee_ID,AccessDate as Ngay from HR_TimeKeeping_Data where AccessDate between @fromdate and @todate and insertsource='NhapTay'
			union
			select Employee_ID,Ngay from HR_DuLieuQuetVaoRa where Ngay between @fromdate and @todate
			)abc group by Employee_ID
		)
		--select Employee_ID,count(Employee_ID) as Value,'QuenQuet' as Lable from HR_TimeKeeping_Data where accessdate between @fromdate and @todate and InsertSource='NhapTay' group by Employee_ID
		)as tonghop
		set @SQL='select ctN.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
					,ctn.FactoryName, ctn.DepartmentName, ctn.SectionName, ctn.ChucDanhName,'+@SQLMaCong+'
				from (select Employee_ID,Lable,Value '
				+'from #tabTongHopCongPhep) a pivot(sum(Value) for lable in ('+@SQLMaCong+'))ctn left join [dbo].[udf_EmployeeFilter]('''+@LAN+''',null,null,null,null,null,null,null,'''+convert(nvarchar(10), @todate, 111)+''') empl on ctn.Employee_ID=empl.Employee_ID
				order by empl.PositionFullName,ctn.Employee_ID'
			exec (@SQL)
		--exec [dbo].[sp_BangCong] '2022-1-01','2022-2-28', 10,'VN','ADMIN',NULL,NULL,NULL,NULL,NULL,NULL,null,null
	end else if @TypeOfReport=11 begin-- DANH SÁCH CHẾ ĐỘ làm 7h CHỈ LÂY BIẾN FROMDATE=TODATE
			select empl.Employee_ID
			,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,(case when @fromdate between cdo.DisableFromDate and cdo.DisableToDate then 'x' else null end) as TanTat
			,(case when @fromdate between cdo.pregFromdate and cdo.pregTodate then 'x' else null end) as MangThai
			,(case when @fromdate between cdo.babyFromdate and cdo.babyTodate then 'x' else null end) as ConNhoDuoi1Tuoi
			--,(case when @fromdate between cdo.Duoi18Fromdate and cdo.Duoi18Todate then 'x' else null end) as Duoi18
			--,(case when @fromdate between cdo.OldFromdate and cdo.OldTodate then 'x' else null end) as CaoTuoi
			,tito.ShiftName,cast(tito.RealTimeIn as time(0)) as RealTimeIn,cast(tito.RealTimeOut as time(0)) as RealTimeOut
			from
			[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
			left join
			[dbo].[udf_DanhSachHuongCheDo](@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan) cdo
			on empl.Employee_ID=cdo.Employee_ID
			left join
			HR_TimeIn_TimeOut tito
			on empl.Employee_ID=tito.Employee_ID and tito.OT_date=@fromdate
			left join
			SmartBooks_Position pos
			on empl.Position_ID=pos.Position_ID
			where cdo.Employee_ID is not null and cdo.Employee_ID not like N'BV%'
			--select * from [dbo].[udf_DanhSachHuongCheDo]('2025-09-30','2025-09-30',182) where Employee_ID='C0816'
	end else if @TypeOfReport=12 begin-- DANH SÁCH QUẸT SAI QUY ĐỊNH CỦA CA
			select 
			empl.Employee_ID
			,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,tito.OT_date as Ngay,'' as LeaveType_ID,cast(tito.RealTimeIn as time) as RealTimeIn,cast(tito.RealTimeOut as time) as RealTimeOut
			,@Reason as Reason,@Remark as Remark,tito.ShiftName,cast(s.fromtime as time) as fromtime,cast(s.totime as time) as totime
			from 
			[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
			left join
			HR_TimeIn_TimeOut tito
			on empl.Employee_ID=tito.Employee_ID
			left join
			HR_Shifts s
			on tito.ShiftName=s.ShiftName
			left join
			[dbo].[HR_MaxOvertime] motBF
			on empl.Employee_ID=motBF.Employee_ID and tito.OT_date=motBF.workingdate and motBF.[TypeOfOT]=2
			left join
			[dbo].[HR_MaxOvertime] motAT
			on empl.Employee_ID=motAT.Employee_ID and tito.OT_date=motAT.workingdate and motAT.[TypeOfOT]=1
			where
			tito.OT_date between @fromdate and @todate
			and
			(
				DATEADD(second,0-datepart(SECOND,RealTimeIn),RealTimeIn)<[dbo].[GhepGioVaoNgay](tito.OT_date,dateadd(minute,-15-isnull(motBF.maxovertime,0)*60,s.FromTime))
				or
				DATEADD(second,0-datepart(SECOND,RealTimeOut),RealTimeOut)>[dbo].[GhepGioVaoNgay]((case when DATEPART(HOUR,s.FromTime)>DATEPART(HOUR,s.ToTime) then tito.OT_date+1 else tito.OT_date end),dateadd(minute,15+isnull(motAT.maxovertime,0)*60,s.ToTime))
			)
			--union
			--select * from udf_DangKyPhepBatThuong(@fromdate,@todate,@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp) where LeaveType_ID in (31,32)
	end else if @TypeOfReport=13 begin--Tổng hợp tăng ca lũy tiến theo tháng
			select empl.PositionFullName,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Position,empl.Position_ID
			,Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Decem
			from
			(
				select wt.Employee_ID
				,sum(case when DATEPART(MONTH,wt.Ngay)=1 then isnull(wt.wt,0) else 0 end)as Jan
				,sum(case when DATEPART(MONTH,wt.Ngay)=2 then isnull(wt.wt,0) else 0 end)as Feb
				,sum(case when DATEPART(MONTH,wt.Ngay)=3 then isnull(wt.wt,0) else 0 end)as Mar
				,sum(case when DATEPART(MONTH,wt.Ngay)=4 then isnull(wt.wt,0) else 0 end)as Apr
				,sum(case when DATEPART(MONTH,wt.Ngay)=5 then isnull(wt.wt,0) else 0 end)as May
				,sum(case when DATEPART(MONTH,wt.Ngay)=6 then isnull(wt.wt,0) else 0 end)as Jun
				,sum(case when DATEPART(MONTH,wt.Ngay)=7 then isnull(wt.wt,0) else 0 end)as Jul
				,sum(case when DATEPART(MONTH,wt.Ngay)=8 then isnull(wt.wt,0) else 0 end)as Aug
				,sum(case when DATEPART(MONTH,wt.Ngay)=9 then isnull(wt.wt,0) else 0 end)as Sep
				,sum(case when DATEPART(MONTH,wt.Ngay)=10 then isnull(wt.wt,0) else 0 end)as Oct
				,sum(case when DATEPART(MONTH,wt.Ngay)=11 then isnull(wt.wt,0) else 0 end)as Nov
				,sum(case when DATEPART(MONTH,wt.Ngay)=12 then isnull(wt.wt,0) else 0 end)as Decem
				,sum(isnull(wt.wt,0))as Total
				from
				[dbo].[HR_WTDaily] wt
				left join
				HR_LoaiCong lc
				on wt.macong=lc.macong
				where isnull(lc.isWorkingTime,0)=0 and lc.MaCong not in ('wt11','wt12') and InsertSource not like 'Alt%'
				group by wt.Employee_ID
			)OT
			left join
			[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
			on OT.Employee_ID=empl.Employee_ID
			where empl.Employee_ID is not null
	end else if @TypeOfReport=14 begin
		declare @tabDKOTTheoNgay table(Employee_ID nvarchar(50),OT float,primary key(Employee_ID))
		insert into @tabDKOTTheoNgay
		select Employee_ID,sum(maxovertime) from HR_MaxOvertime where workingdate between @fromdate and @todate group by Employee_ID
		declare @tabCong table(Employee_ID nvarchar(50),wt3 float,wt4 float,wt5 float,wt6 float,wt7 float,wt8 float,wt9 float,TongGioTC float primary key(Employee_ID))
		insert into @tabCong
		select Employee_ID
			,isnull(wt3,0) as wt3
			,isnull(wt4,0) as wt4
			,isnull(wt5,0) as wt5
			,isnull(wt6,0) as wt6
			,isnull(wt7,0) as wt7
			,isnull(wt8,0) as wt8
			,isnull(wt9,0) as wt9
			,isnull(wt3,0)+isnull(wt4,0)+isnull(wt5,0)+isnull(wt6,0)+isnull(wt7,0)+isnull(wt8,0)
		from udf_TongHopCong(@fromdate,@todate,1,@UserName)
		
		select TongGioTC
		,sum(case when isnull(TongGioTC,0)>0 then 1 else 0 end) as SoNguoiTC
		,sum(isnull(wt3,0)) as wt3
		,sum(isnull(wt4,0)) as wt4
		,sum(isnull(wt5,0)) as wt5
		,sum(isnull(wt6,0)) as wt6
		,sum(isnull(wt7,0)) as wt7
		,sum(isnull(wt8,0)) as wt8
		,sum(isnull(wt9,0)) as wt9
		,sum(case when isnull(dkot.OT,0)>0 then 1 else 0 end) as SoNguoiDKTC
		from @tabCong c
		left join
		@tabDKOTTheoNgay dkot
		on c.Employee_ID=dkot.Employee_ID
		group by TongGioTC
		order by TongGioTC
	end else if @TypeOfReport=15 begin
		--exec [dbo].[sp_BangCong] '2021-5-01','2021-5-31', 15,'VN','ADMIN',NULL,NULL,NULL,NULL,NULL,NULL,'WS000259',null
		declare @s nvarchar(max) set @s=''; set @DSMaCong=''
		select @s=@s + '[' + CONVERT(varchar(12),Date_,111) + '],' From [udf_BangThoiGian](@fromdate, @todate)
		set @s= left(@s,len(@s)-1)
		
		IF OBJECT_ID('tempdb..#tabCTH') IS NOT NULL DROP TABLE #tabCTH
		select  empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName--,empl.ComStartedDate,empl.TernimationDate,empl.Position,empl.DepartmentName,empl.PositionName,empl.PositionCategoryName
		,tabdate.Ngay,isnull((case 
							--when CongHC_TC.wt=8 and erp.Employee_ID is not null then 'CB7'
							--when CongHC_TC.wt=8 and fml.Employee_ID is not null then 'NCN7'
							when cast(CongHC_TC.wt as varchar)='8' then (case when isnull(tito.ShiftName,erts.ShiftName) like '%Shift3' then 'D' else (case when NgayChinhThuc.NgayKyHDChinhThuc<=tabdate.Ngay then 'X' else 'Y' end) end)+(case when isnull(CongHC_TC.OTNB,0)>0 then cast(CongHC_TC.OTNB as varchar) else '' end)
							when CongHC_TC.wt<8 then cast(CongHC_TC.wt as varchar) + (case when isnull(tito.ShiftName,erts.ShiftName) like '%Shift3' then 'D' else (case when NgayChinhThuc.NgayKyHDChinhThuc<=tabdate.Ngay then 'X' else 'Y' end) end)+(case when isnull(CongHC_TC.OTNB,0)>0 then cast(CongHC_TC.OTNB as varchar) else '' end)
							when ((DATENAME(WEEKDAY,tabdate.Ngay)='Sunday' and wds.WorkingDayType is null) or isnull(wds.WorkingDayType,'')='Sun') and CongHC_TC.OTNB>0 then cast(CongHC_TC.OTNB as varchar)
							when isnull(CongHC_TC.wt,0)>0 then (case when isnull(tito.ShiftName,erts.ShiftName) like '%Shift3' then 'D' else (case when NgayChinhThuc.NgayKyHDChinhThuc<=tabdate.Ngay then 'X' else 'Y' end) end)+cast(CongHC_TC.wt as varchar)+(case when isnull(CongHC_TC.OTNB,0)>0 then 'T'+ cast(CongHC_TC.OTNB as varchar) else '' end) else '' end),'')
							+ (case when lt.AbsentSign is not null then lt.AbsentSign when ((DATENAME(WEEKDAY,tabdate.Ngay)='Sunday' and wds.WorkingDayType is null) or isnull(wds.WorkingDayType,'')='Sun') and isnull(CongHC_TC.wt,0)+isnull(CongHC_TC.OTNB,0)=0 then 'OFF' else isnull(lt.AbsentSign,'')end) as wt
		into #tabCTH
		from
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		left join
		@tabDate tabdate
		on empl.ComStartedDate<=tabdate.Ngay and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)
		left join
		[dbo].[udf_CongHC_TC](@fromdate,@todate,@TrangThaiKH) CongHC_TC
		on empl.Employee_ID=CongHC_TC.Employee_ID and tabdate.Ngay=CongHC_TC.Ngay
		left join
		HR_EmployeeRegisPregnant erp
		on empl.Employee_ID=erp.Employee_ID and tabdate.Ngay between erp.Fromdate+@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan and ISNULL(MiscarriageDate-1,DATEADD(month,9,erp.Fromdate)+10)
		left join
		SmartBooks_Employee_Family fml
		on empl.Employee_ID=fml.Employee_ID and empl.Sex='Female' and tabdate.Ngay between fml.BirthDate and DATEADD(year,1,fml.BirthDate) and fml.RelatedType in ('6','7')
		left join
		HR_TimeIn_TimeOut tito
		on empl.Employee_ID=tito.Employee_ID and tabdate.Ngay=tito.OT_date
		left join
		[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) ptn
		on empl.Employee_ID=ptn.Employee_ID and tabdate.Ngay=ptn.DateLeave
		left join
		SmartBooks_LeaveType lt
		on ptn.LeaveType_ID=lt.LeaveType_ID
		left join
		HR_WorkingDaySpecial wds
		on empl.Employee_ID=wds.Employee_ID and tabdate.Ngay=wds.WorkingDate
		--left join
		--[dbo].[udf_NgayKyHDChinhThuc](@fromdate,@todate,@emp) NgayKyHDCT
		--on empl.Employee_ID=NgayKyHDCT.Employee_ID
		left join
		udf_DanhSachNhanVienDuocHuongNghiLe(@fromdate,@todate) hp
		on tabdate.Ngay=hp.H_date and empl.Employee_ID=hp.Employee_ID
		--left join
		--(select distinct Employee_ID,ngay from HR_WTDaily where ngay between @fromdate and @todate and MaCong in ('wt9','wt6','wt8')) cadem
		--on empl.Employee_ID=cadem.Employee_ID and tabdate.Ngay=cadem.Ngay
		left join
		udf_DangKyCa(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan,@fact,@dept,@sect,@team,@pos,@posc,null) erts
		on empl.Employee_ID=erts.Employee_ID and tabdate.Ngay=erts.AccessDate
		left join
		udf_NgayKyHDChinhThuc(@fromdate,@todate,null) NgayChinhThuc
		on empl.Employee_ID=NgayChinhThuc.Employee_ID

		where empl.ComStartedDate<=@todate and (TernimationDate is null or TernimationDate>@fromdate)
		
		 create table #tabCTH1(Employee_ID nvarchar(50))
		 set @dtNext=@fromdate
		 while @dtNext<=@todate begin
			set @sql='alter table #tabCTH1 add [N'+ cast(day(@dtNext) as varchar)+'] nvarchar(20)'
			exec (@sql)
			set @dtNext=@dtNext+1
		 end

		set @sql = 'insert into #tabCTH1 SELECT Employee_ID, '+@s+' FROM #tabCTH 
					PIVOT  
					( 
						Max(wt) FOR Ngay IN (@s1)
					) AS PivotTable '

		set @sql = REPLACE(@sql, '@s1', @s)
		EXECUTE sp_executesql @sql
				  , N'@fromdate datetime, @todate datetime'
				  , @fromdate = @fromdate  
				  , @todate = @todate

		select empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
		,empl.ComStartedDate,NgayKyHDCT.NgayKyHDChinhThuc as OfficialDate,empl.TernimationDate,empl.BirthDate
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,cth.*
		 ,isnull(thc.wt1,0) as thc_wt1,isnull(thc.wt9,0) as thc_wt9
		 ,isnull(thc.wt3,0) as thc_wt3
		 ,isnull(thc.wt4,0) as thc_wt4
		 ,isnull(thc.wt5,0) as thc_wt5
		 ,isnull(thc.wt6,0) as thc_wt6
		 ,isnull(thc.wt7,0) as thc_wt7
		 ,isnull(thc.wt8,0) as thc_wt8
		 ,isnull(thc.wt9,0) as thc_wt9
		 ,isnull(thc.wt10,0) as thc_wt10
		 ,isnull(thc.wt11,0) as thc_wt11
		 ,isnull(thc.wt12,0) as thc_wt12
		 ,isnull(thc.wt13,0) as thc_wt13
		 ,isnull(thc.wt14,0) as thc_wt14
		 ,isnull(thc.wt15,0) as thc_wt15
		 ,isnull(ctv.wt1,0) as ctv_wt1,isnull(ctv.wt9,0) as ctv_wt9
		,isnull(ctv.wt3,0) as ctv_wt3
		,isnull(ctv.wt4,0) as ctv_wt4
		,isnull(ctv.wt5,0) as ctv_wt5
		,isnull(ctv.wt6,0) as ctv_wt6
		,isnull(ctv.wt7,0) as ctv_wt7
		,isnull(ctv.wt8,0) as ctv_wt8
		,isnull(ctv.wt9,0) as ctv_wt9
		,isnull(ctv.wt10,0) as ctv_wt10
		,isnull(ctv.wt11,0) as ctv_wt11
		,isnull(ctv.wt12,0) as ctv_wt12
		,isnull(ctv.wt13,0) as ctv_wt13
		,isnull(ctv.wt14,0) as ctv_wt14
		,isnull(ctv.wt15,0) as ctv_wt15
		,isnull(ctv.wt1,0)+isnull(ctv.wt9,0) as Gio85
		,thp.PhepHuongLuong as thp_PhepHuongLuong,thp.KhongPhep as thp_KhongPhep,thp.KLKhongMatCC as thp_KLKhongMatCC,thp.PhepNam as thp_PhepNam,thp.NghiLe as thp_NghiLe,thp.NgungViec as thp_NgungViec,thp.NghiKhongLuong as thp_NghiKhongLuong,thp.KetHon as thp_KetHon,thp.BoMeMat as thp_BoMeMat,thp.KhamThai as thp_KhamThai,thp.NghiTuan as thp_NghiTuan,thp.NghiDich as thp_NghiDich
		,ptv.PhepHuongLuong as ptv_PhepHuongLuong,ptv.KhongPhep as ptv_KhongPhep,ptv.KLKhongMatCC as ptv_KLKhongMatCC,ptv.PhepNam as ptv_PhepNam,ptv.NghiLe as ptv_NghiLe,ptv.NgungViec as ptv_NgungViec,ptv.NghiDich as ptv_NghiDich
		,wd.SoNgayDiLamHC
		from
		#tabCTH1 cth
		left join
		[dbo].[udf_TongHopCong](@fromdate,@todate,1,@UserName) thc
		on cth.Employee_ID=thc.Employee_ID
		left join
		[dbo].[udf_TongHopCong](@fromdate,@todate,2,@UserName) ctv
		on cth.Employee_ID=ctv.Employee_ID
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		on cth.Employee_ID=empl.Employee_ID
		left join
		[dbo].[udf_TongHopPhep](@fromdate,@todate,1) thp
		on cth.Employee_ID=thp.Employee_ID
		left join
		[dbo].[udf_TongHopPhep](@fromdate,@todate,2) ptv
		on cth.Employee_ID=ptv.Employee_ID
		left join
		(
			select Employee_ID,count(Employee_ID) as SoNgayDiLamHC from
			(select distinct Employee_ID,Ngay from [dbo].[udf_BangCong](@fromdate,@todate,case when @TypeOfReport<100 then 0 else 1 end) wt where isnull(wt,0)>0 and MaCong in ('wt1','wt9'))as wd
			group by Employee_ID
		)wd
		on cth.Employee_ID=wd.Employee_ID
		left join
		[dbo].[udf_NgayKyHDChinhThuc](@fromdate,@todate,@emp) NgayKyHDCT
		on empl.Employee_ID=NgayKyHDCT.Employee_ID
		WHERE --isnull(tc.wt1,0)+isnull(tc.wt9,0)+isnull(tc.wt3,0)+isnull(tc.wt5,0)+isnull(tc.wt4,0)+isnull(tc.wt6,0)+isnull(tc.wt7,0)+isnull(tc.wt8,0)>0
			empl.Employee_ID is not null
		--left join
		--[dbo].[udf_TinhThuongLamDu](@fromdate,@todate) tld
		--on cth.Employee_ID=tld.Employee_ID
		--where cth.Employee_ID='s000834'
	end else if @TypeOfReport = 18 begin
		select [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Employee_ID
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,tito.OT_date as Ngay,cast(tito.RealTimeIn as time) as RealTimeIn,cast(tito.RealTimeOut as time) as RealTimeOut,@Reason as Reason,@Remark as Remark,tito.ShiftName,mot.maxovertime
			, tkd.Reason as ReasonForgot,ptn.LeaveType_ID
			,(case when cdo.Employee_ID is not null then 'CheDo' else null end) CheDo
			from
			[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
			left join
			HR_TimeIn_TimeOut tito
			on empl.Employee_ID=tito.Employee_ID
			left join
			HR_TimeKeeping_Data tkd
			on empl.Employee_ID = tkd.Employee_ID and tkd.AccessDate = tito.OT_date and tkd.Reason = 'ForgotScan'
			left join
			[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) ptn
			on empl.Employee_ID=ptn.Employee_ID and tito.OT_date = ptn.DateLeave
			left join
			(select Employee_ID,workingdate,sum(maxovertime) as maxovertime from HR_MaxOvertime where workingdate between @fromdate and @todate group by Employee_ID,workingdate) mot
			on empl.Employee_ID = mot.Employee_id and tito.OT_date = mot.workingdate
			left join
			udf_DanhSachHuongCheDo(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan) cdo
			on tito.Employee_ID=cdo.Employee_ID and (tito.OT_date between cdo.babyFromdate and cdo.babyTodate or tito.OT_date between cdo.pregFromdate and cdo.pregTodate or tito.OT_date between cdo.DisableFromDate and cdo.DisableToDate or tito.OT_date between cdo.OldFromdate and cdo.OldTodate)-- or tito.OT_date between cdo.Duoi18Fromdate and cdo.Duoi18Todate)

			where (tito.RealTimeIn is not null and tito.RealTimeOut is null) or (tito.RealTimeIn is null and tito.RealTimeOut is not null) or tkd.Reason is not null
				and tito.OT_date between @fromdate and @todate
				and (ptn.Employee_ID is null or ptn.LeaveType_ID in ('31','31','14'))
			order by Position, Employee_ID
	end else if @TypeOfReport = 19 begin -- có phép và quẹt đi làm
		--exec [dbo].[sp_BangCong] '2023-01-01','2023-01-31', 19,'VN','ADMIN',NULL,NULL,NULL,NULL,NULL,NULL,NULL,null
		select empl.Employee_ID, dbo.udf_FullName(empl.Employee_Firstname, empl.Employee_LastName) as FullName
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName, bptn.LeaveType_ID, td.AccessTime
		from
		udf_EmployeeFilter (@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,@todate) empl
		left join
		udf_BangPhepTheoNgay (1,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) bptn
		on empl.Employee_ID = bptn.Employee_ID
		left join
		(
		select Employee_ID, td.AccessDate, td.AccessTime, ROW_NUMBER() Over(partition by td.AccessDate Order by td.AccessTime) as rownum from
			HR_TimeKeeping_Data td
			where td.AccessDate between @fromdate and @todate
		) td
		on empl.Employee_ID = td.Employee_ID and bptn.DateLeave = td.AccessDate and rownum = 1
		left join
		HR_WTDaily wt
		on empl.Employee_ID = wt.Employee_ID and wt.Ngay = bptn.DateLeave and wt.Ngay between @fromdate and @todate
		where bptn.Employee_ID is not null and td.Employee_ID is not null and wt.Employee_ID is null
	end else if @TypeOfReport = 20 begin
		select * from
		(
			select  empl.DepartmentCode1 + '1.Emp' as DepartmentCode1, 'd' + cast(day(btg.Date_) as nvarchar(3)) as Ngay, count(empl.Employee_ID) as countEmployee_ID--, count(tito.Employee_ID) as titoEmployee_ID, sum(case when tito.Employee_ID is null and bptn.Employee_ID is not null then 1 else 0 end) as bptnEmployee_ID
			from
			udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,GETDATE()) empl
			left join
			udf_BangThoiGian (@fromdate,@todate) btg
			on empl.StartedDate <= btg.Date_ and isnull(empl.TernimationDate,@todate) >= btg.Date_
			where empl.DepartmentCode1 in ('MAT','QCT') and isnull(empl.TernimationDate,@fromdate) >= @fromdate
			group by empl.DepartmentCode1, btg.Date_
		) as pvsource
		pivot
		(
			sum(CountEmployee_ID)
			for Ngay in (d1,d2,d3,d4,d5,d6,d7,d8,d9,d10,d11,d12,d13,d14,d15,d16,d17,d18,d19,d20,d21,d22,d23,d24,d25,d26,d27,d28,d29,d30,d31)
		)piv
		union
		select * from
		(
			select empl.DepartmentCode1 + '2.tito' as DepartmentCode1, 'd' + cast(day(btg.Date_) as nvarchar(3)) as Ngay, count(tito.Employee_ID) as titoEmployee_ID--, count(tito.Employee_ID) as titoEmployee_ID, sum(case when tito.Employee_ID is null and bptn.Employee_ID is not null then 1 else 0 end) as bptnEmployee_ID
			from
			udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,GETDATE()) empl
			left join
			udf_BangThoiGian (@fromdate,@todate) btg
			on empl.StartedDate <= btg.Date_ and isnull(empl.TernimationDate,@todate) >= btg.Date_
			left join
			HR_TimeIn_TimeOut tito
			on empl.Employee_ID = tito.Employee_ID and tito.TimeIn is not null and tito.[TimeOut] is not null and tito.OT_date between @fromdate and @todate and tito.OT_date = btg.Date_
			left join
			udf_BangPhepTheoNgay (2,@fromdate,@todate,null,null,null,null,null,null,null,null) bptn
			on empl.Employee_ID = bptn.Employee_ID and btg.Date_ = bptn.DateLeave
			where empl.DepartmentCode1 in ('MAT','QCT') and isnull(empl.TernimationDate,@fromdate) >= @fromdate
			group by empl.DepartmentCode1, btg.Date_
		) as pvsource
		pivot
		(
			sum(titoEmployee_ID)
			for Ngay in (d1,d2,d3,d4,d5,d6,d7,d8,d9,d10,d11,d12,d13,d14,d15,d16,d17,d18,d19,d20,d21,d22,d23,d24,d25,d26,d27,d28,d29,d30,d31)
		)piv
		union
		select * from
		(
			select empl.DepartmentCode1 + '3.bptn' as DepartmentCode1, 'd' + cast(day(btg.Date_) as nvarchar(3)) as Ngay, sum(case when tito.Employee_ID is null and bptn.Employee_ID is not null then 1 else 0 end) as bptnEmployee_ID--, count(tito.Employee_ID) as titoEmployee_ID, sum(case when tito.Employee_ID is null and bptn.Employee_ID is not null then 1 else 0 end) as bptnEmployee_ID
			from
			udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,GETDATE()) empl
			left join
			udf_BangThoiGian (@fromdate,@todate) btg
			on empl.StartedDate <= btg.Date_ and isnull(empl.TernimationDate,@todate) >= btg.Date_
			left join
			HR_TimeIn_TimeOut tito
			on empl.Employee_ID = tito.Employee_ID and tito.TimeIn is not null and tito.[TimeOut] is not null and tito.OT_date between @fromdate and @todate and tito.OT_date = btg.Date_
			left join
			udf_BangPhepTheoNgay (2,@fromdate,@todate,null,null,null,null,null,null,null,null) bptn
			on empl.Employee_ID = bptn.Employee_ID and btg.Date_ = bptn.DateLeave
			where empl.DepartmentCode1 in ('MAT','QCT') and isnull(empl.TernimationDate,@fromdate) >= @fromdate
			group by empl.DepartmentCode1, btg.Date_
		) as pvsource
		pivot
		(
			sum(bptnEmployee_ID)
			for Ngay in (d1,d2,d3,d4,d5,d6,d7,d8,d9,d10,d11,d12,d13,d14,d15,d16,d17,d18,d19,d20,d21,d22,d23,d24,d25,d26,d27,d28,d29,d30,d31)
		)piv

		order by DepartmentCode1
	end else if @TypeOfReport in (20,26,27,28,120,126,127,128) begin--=3 xem côgn tính luong theo chi?u ngang
			--exec [dbo].[sp_BangCong] '2025-11-01','2025-11-30',27,'VN','admin',NULL,NULL,NULL,NULL,NULL,NULL,'C13228',Null
			print @TrangThaiKH
			select FactoryName, DepartmentName, SectionName, ChucDanh, StartedDate--, DepartmentCode
					, Employee_ID, Employee_Firstname + ' ' + Employee_LastName as FullName, Ngay
					, case when @TrangThaiKH = 2 and isnull(CN_wt3,0) + isnull(CN_wt5,0) = 0 then NULL when @TrangThaiKH = 2 and isnull(CN_wt3,0) + isnull(CN_wt5,0) > 0 and RealTimeIn < ShiftToTime then ShiftToTime else RealTimeIn end as RealTimeIn
					, case when @TrangThaiKH = 2 and isnull(CN_wt3,0) + isnull(CN_wt5,0) = 0 then NULL else [RealTimeOut] end as RealTimeOut
					, case when @TrangThaiKH = 2 then null else isnull(wt1,0) + (case when isnull(LeaveType_ID,0) in (52,60) and isnull(wt1,0) + HourLeave > 8 then 18 - isnull(wt1,0) when isnull(LeaveType_ID,0) in (52,60) and isnull(wt1,0) + HourLeave <= 8 then HourLeave else 0 end) end as wt1
					, case when @TrangThaiKH = 2 then null else wt2 end as wt2, case when @TrangThaiKH = 2 then 0 else wt9 end as wt9
					, case when @TrangThaiKH = 2 then CN_wt3 when isnull(wt3,0) + isnull(CN_wt3,0) = 0 then null else isnull(wt3,0) + isnull(CN_wt3,0) end as wt3
					, case when @TrangThaiKH = 2 then CN_wt4 when @TrangThaiKH = 1 then null when isnull(wt4,0) + isnull(CN_wt4,0) = 0 then null else isnull(wt4,0) + isnull(CN_wt4,0) end as wt4
					, case when @TrangThaiKH = 2 then CN_wt5 when isnull(wt5,0) + isnull(CN_wt5,0) = 0 then null else isnull(wt5,0) + isnull(CN_wt5,0) end as wt5
					, case when @TrangThaiKH = 2 then CN_wt10 when isnull(wt10,0) + isnull(CN_wt10,0) = 0 then null else isnull(wt10,0) + isnull(CN_wt10,0) end as wt10
					, case when @TrangThaiKH = 2 then CN_wt6 when @TrangThaiKH = 1 then null when isnull(wt6,0) + isnull(CN_wt6,0) = 0 then null else isnull(wt6,0) + isnull(CN_wt6,0) end as wt6
					, case when @TrangThaiKH = 2 then CN_wt7 when @TrangThaiKH = 1 then null when isnull(wt7,0) + isnull(CN_wt7,0) = 0 then null else isnull(wt7,0) + isnull(CN_wt7,0) end as wt7
					, case when @TrangThaiKH = 2 then CN_wt8 when @TrangThaiKH = 1 then null when isnull(wt8,0) + isnull(CN_wt8,0) = 0 then null else isnull(wt8,0) + isnull(CN_wt8,0) end as wt8
					, case when @TrangThaiKH = 2 then CN_wt11 when isnull(wt11,0) + isnull(CN_wt11,0) = 0 then null else isnull(wt11,0) + isnull(CN_wt11,0) end as wt11
					, case when @TrangThaiKH = 2 then null else LeaveType_ID end as LeaveType_ID
					, Case when @TrangThaiKH = 2 then 0 else (isnull(PhepHuongLuong,0) - isnull(thp_CongThucTeDiLam,0))/8 end as PhepHuongLuong
					, Case when @TrangThaiKH = 2 then 0 else isnull(NghiKhongLuong,0)/8 end as NghiKhongLuong
					, Case when @TrangThaiKH = 2 then 0 else Round((isnull(thc_wt1,0) + isnull(thc_wt9,0) + isnull(PhepHuongLuong,0))/8.0,2) end as TongNgayCong
					, Case when @TrangThaiKH = 2 then 0 else Round((isnull(thc_wt1,0) + isnull(thc_wt9,0))/8.0 + isnull(thp_CongThucTeDiLam,0)/8.0,2) end as TongNgayCongThucTe
					, PCAnToi, PCFood
					, 0 as LateIn, 0 as EarlyOut, 0 as maxovertime, ShiftName, AbsentSign
					, isnull(case when isnull(isManager,0) = 1 then 0 when StartedDate between @NgayDauThang and @NgayCuoiThang then ROUND(500000 / NgayCongTieuChuan / 8 * TongGioCong, -3) when TongGioCong + PhepKhamThai >= NgayCongTieuChuan * 8 - 4 then 500000 else 0 end,0) as TienCC
					, isnull(case when isnull(isManager,0) = 1 then 0 when StartedDate between @NgayDauThang and @NgayCuoiThang then ROUND(200000 / NgayCongTieuChuan / 8 * TongGioCong, -3) when TongGioCong >= 13 * 8 then 200000 else 0 end,0) as TienXX
					, case when Round((isnull(thc_wt1,0) + isnull(thc_wt9,0) + isnull(PhepHuongLuong,0))/8.0,2) >= 13 then isnull(TienConNho,0) else 0 end as TienConNho
					, isnull(SoCaDem,0) as SoCaDem, isnull(TienCaDem,0) as TienCaDem
					, isnull(LuongCoDinh,0) as LuongCoDinh, isnull(TienTrachNhiem,0) as TienTrachNhiem, isnull(TienDienThoai,0) as TienDienThoai
					, PhepNam/8 as PhepNam, PhepNamConLai, OrderBy, SectionCode
					,case when isleave_compay = 1 then (isnull(wt1,0) + isnull(wt2,0) + HourLeave)/8 else  (isnull(wt1,0) + isnull(wt2,0))/8 end as sumTNC

					--, th
					--, case when isnull(wt00,0) = 0 then null else isnull(wt00,0) end as wt00, case when isnull(wt0,0) = 0 then null else isnull(wt0,0) end as wt0
			from
			(
				select empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanh
						, empl.Employee_ID, empl.Employee_Firstname, empl.Employee_LastName, empl.StartedDate, empl.DepartmentCode1, btg.Date_ as Ngay
						, case when @TrangThaiKH = 1 and tito.RealTimeIn is not null then tito.TimeIn_KH else tito.RealTimeIn end as RealTimeIn, case when @TrangThaiKH = 1 and tito.RealTimeOut is not null then tito.TimeOut_KH else tito.RealTimeOut end as [RealTimeOut], wt.wt, wt.MaCong
						, case when @TrangThaiKH = 2 then null else bpdn.LeaveType_ID end as LeaveType_ID, case when @TrangThaiKH = 2 then null else bpdn.HourLeave end as HourLeave
						, thp.PhepHuongLuong, thp.NghiKhongLuong, thp.CongThucTeDiLam as thp_CongThucTeDiLam
						, thc.wt1 as thc_wt1, thc.wt9 as thc_wt9
						, 0 as PCAnToi, 0 as PCFood
						, tito.ShiftName, lt.AbsentSign --+ case when bpdn.HourLeave < 8 then '/' + cast(round(bpdn.HourLeave,2) as nvarchar(5)) else '' end as AbsentSign
						, isnull(thc.wt1,0) + isnull(thc.wt9,0) + isnull(thp.PhepHuongLuong,0) as TongGioCong
						, dbo.udf_CountDayExceptSunday(@fromdate,@todate) as NgayCongTieuChuan
						, ef.TienConNho
						--, SoCaDem * 35000 as TienCaDem
						, cadem.SoCaDem, cadem.TienCaDem
						, blcd.CD1 as LuongCoDinh, blcd.CD2 as TienTrachNhiem, blcd.CD5 as TienDienThoai
						, isnull(thp.PhepNam,0) as PhepNam, isnull(qlpn.PhepNamConLai,0) PhepNamConLai
						, isnull(empl.isManager,0) as isManager, isnull(thp.PKT,0) as PhepKhamThai
						, dep.OrderBy, sec.SectionCode, dbo.GhepGioVaoNgay(btg.Date_,sh.ToTime) as ShiftToTime,
						lt.isleave_compay
						--, (case when cast(case when @TrangThaiKH = 1 then tito.TimeOut_KH else tito.RealTimeOut end as time) >= '20:00:00.000' and mot.Remark = 1 then 1 else 0 end) as wt00
						--, (case when cast(case when @TrangThaiKH = 1 then tito.TimeOut_KH else tito.RealTimeOut end as time) between '19:00:00.000' and '20:00:00.000' then 1 else 0 end) as wt0
				from
				udf_BangThoiGian (@fromdate,@todate) btg
				left join
				--SmartBooks_Employee empl
				udf_EmployeeFilter ('VN',@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
				on empl.StartedDate <= btg.Date_ and isnull(empl.TernimationDate,btg.Date_) >= btg.Date_
				left join
				(
					select wt.Employee_ID, wt.Ngay, wt.MaCong, sum(wt.wt) as wt
					from
					HR_WTDaily wt
					where Ngay between @fromdate and @todate
					group by wt.Employee_ID, wt.Ngay, wt.MaCong--, case when wt.MaCong like 'CN_%' then right(wt.MaCong,len(MaCong)-3) else wt.MaCong end
				) wt
				on empl.Employee_ID = wt.Employee_ID and btg.Date_ = wt.Ngay and ((MaCong not like case when @TrangThaiKH = 1 then N'CN_%' else '' end and @TrangThaiKH <> 2) or (@TrangThaiKH = 2 and MaCong like 'CN_%'))
				left join
				HR_TimeIn_TimeOut tito
				on empl.Employee_ID = tito.Employee_ID and btg.Date_ = tito.OT_date
				left join
				HR_BangPhepDaNghi bpdn
				on empl.Employee_ID = bpdn.Employee_ID and btg.Date_ = bpdn.DateLeave
				left join
				SmartBooks_LeaveType lt
				on bpdn.LeaveType_ID = lt.LeaveType_ID
				left join
				udf_TongHopCong(@fromdate,@todate,1,@UserName) thc
				on empl.Employee_ID = thc.Employee_ID
				left join
				udf_TongHopPhep (@fromdate,@todate,case when @TrangThaiKH = 2 then 5 else 1 end) thp
				on thp.Employee_ID = empl.Employee_ID
				--left join
				--udf_TinhTienAn (@fromdate,@todate,@emp) tta
				--on empl.Employee_ID = tta.Employee_ID
				left join
				HR_MaxOvertime mot
				on empl.Employee_ID = mot.Employee_ID and wt.Ngay = mot.workingdate and mot.TypeOfOT = 1
				left join
				(
					select Employee_ID, sum(case when dateadd(year,1,BirthDate) between @fromdate and @todate and day(BirthDate) < 15 then 1 when dateadd(year,6,Birthdate) between @fromdate and @todate and day(Birthdate) > 15 then 1 when dateadd(year,6,Birthdate) >= @todate then 1 else 0 end) * 100000 as TienConNho
					from
					SmartBooks_Employee_Family
					where RelatedType = 6 and dateadd(year,6,Birthdate) >= @fromdate and dateadd(year,1,Birthdate) <= @Ngay15
					group by Employee_ID
				) ef
				on empl.Employee_ID = ef.Employee_ID
				left join
				udf_BangLuongCoDinh(@todate,@emp) blcd
				on empl.Employee_ID = blcd.Employee_ID
				left join
				udf_SoTienCaDem (@fromdate, @todate, @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan, @UserName, @fact, @dept, @sect, @team, @pos, @posc, @Emp) cadem
				on empl.Employee_ID = cadem.Employee_ID
				left join
				udf_QuanLyPhepNam (Year(@fromdate),@todate,@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp) qlpn
				on qlpn.Employee_ID = empl.Employee_ID
				left join
				SmartBooks_Department dep
				on empl.FactoryName = dep.Factory_ID and empl.DepartmentName = dep.DepartmentCode
				left join
				SmartBooks_Section sec
				on empl.FactoryName = sec.Factory_ID and empl.DepartmentName = sec.DepartmentCode and empl.SectionName = sec.SectionCode
				left join
				HR_Shifts sh
				on tito.ShiftName = sh.ShiftName
				where --(tito.Employee_ID is not null or bptn.Employee_ID is not null) and 
						empl.StartedDate <= @todate
						and
						(
							(@TrangThaiKH = 1 and Datename(dw,btg.Date_) <> ('Sunday')) or @TrangThaiKH in (0,2)
						)
						and (isnull(thc.wt1,0) + isnull(thc.wt9,0) + isnull(thp.PhepHuongLuong,0) > 0 or (@TrangThaiKH = 2 and isnull(thc.wt3,0) + isnull(thc.wt5,0) + isnull(thc.wt4,0) + isnull(thc.wt6,0) + isnull(thc.wt7,0) + isnull(thc.wt8,0) > 0))
						and (
								(
									isnull(empl.Factory_ID,'') = 'SK2' and @TypeOfReport in (27,127)
								)	 
								or 
								(
									isnull(empl.Factory_ID,'') <> 'SK2' and @TypeOfReport in (28,128)
								)
								or
								(
									@TypeOfReport in (26,126)
								)
							)
			) src
			pivot
			(
				sum(src.wt)
				for MaCong in (wt1,wt2,wt3,wt4,wt5,wt6,wt7,wt8,wt9,wt10,wt11,CN_wt3,CN_wt5,CN_wt4,CN_wt6,CN_wt7,CN_wt8,CN_wt10,CN_wt11)
			) pv
			order by isnull(OrderBy,200),SectionName,Employee_ID, Ngay
	end else if @TypeOfReport=21 begin-- late in EarlyOut
			select [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Employee_ID
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,tito.OT_date as Ngay,cast(tito.RealTimeIn as time) as RealTimeIn,cast(tito.RealTimeOut as time) as RealTimeOut,@Reason as Reason,@Remark as Remark,tito.ShiftName,tito.LateIn,tito.EarlyOut,mot.maxovertime
			,ptn.LeaveType_ID
			,(case when cdo.Employee_ID is not null then 'CheDo' else null end) CheDo
			,(case when empl.sex='Male' then dateadd(year,60,empl.BirthDate) else dateadd(year,55,empl.BirthDate) end) as RetireDate
			from
			[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
			left join
			HR_TimeIn_TimeOut tito
			on empl.Employee_ID=tito.Employee_ID
			left join
			[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) ptn
			on empl.Employee_ID=ptn.Employee_ID and tito.OT_date=ptn.DateLeave
			left join
			(select Employee_ID,workingdate,sum(maxovertime) as maxovertime from HR_MaxOvertime where workingdate between @fromdate and @todate group by Employee_ID,workingdate) mot
			on empl.Employee_ID = mot.Employee_id and tito.OT_date = mot.workingdate
			left join
			udf_DanhSachHuongCheDo(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan) cdo
			on tito.Employee_ID=cdo.Employee_ID and (tito.OT_date between cdo.babyFromdate and cdo.babyTodate or tito.OT_date between cdo.pregFromdate and cdo.pregTodate or tito.OT_date between cdo.DisableFromDate and cdo.DisableToDate or tito.OT_date between cdo.OldFromdate and cdo.OldTodate)-- or tito.OT_date between cdo.Duoi18Fromdate and cdo.Duoi18Todate)
			left join
			udf_Position(@LAN,0) p
			on empl.Position=p.Code
			where (tito.LateIn is not null)
				and tito.OT_date between @fromdate and @todate
				and (ptn.Employee_ID is null or ptn.LeaveType_ID in ('31','31')) and isnull(tito.LateIn,0) > 0

	end else if @TypeOfReport=22 begin-- late in EarlyOut
			select [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Employee_ID
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,tito.OT_date as Ngay,cast(tito.RealTimeIn as time) as RealTimeIn,cast(tito.RealTimeOut as time) as RealTimeOut,@Reason as Reason,@Remark as Remark,tito.ShiftName,tito.LateIn,tito.EarlyOut,mot.maxovertime
			,ptn.LeaveType_ID
			,(case when cdo.Employee_ID is not null then 'CheDo' else null end) CheDo
			,(case when empl.sex='Male' then dateadd(year,60,empl.BirthDate) else dateadd(year,55,empl.BirthDate) end) as RetireDate
			from
			[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
			left join
			HR_TimeIn_TimeOut tito
			on empl.Employee_ID=tito.Employee_ID
			left join
			[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) ptn
			on empl.Employee_ID=ptn.Employee_ID and tito.OT_date=ptn.DateLeave
			left join
			(select Employee_ID,workingdate,sum(maxovertime) as maxovertime from HR_MaxOvertime where workingdate between @fromdate and @todate group by Employee_ID,workingdate) mot
			on empl.Employee_ID = mot.Employee_id and tito.OT_date = mot.workingdate
			left join
			udf_DanhSachHuongCheDo(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan) cdo
			on tito.Employee_ID=cdo.Employee_ID and (tito.OT_date between cdo.babyFromdate and cdo.babyTodate or tito.OT_date between cdo.pregFromdate and cdo.pregTodate or tito.OT_date between cdo.DisableFromDate and cdo.DisableToDate or tito.OT_date between cdo.OldFromdate and cdo.OldTodate)-- or tito.OT_date between cdo.Duoi18Fromdate and cdo.Duoi18Todate)
			left join
			udf_Position(@LAN,0) p
			on empl.Position=p.Code
			where (tito.EarlyOut is not null)
				and tito.OT_date between @fromdate and @todate
				and (ptn.Employee_ID is null or ptn.LeaveType_ID in ('31','31')) and isnull(tito.EarlyOut,0) > 0

	end
END
GO
