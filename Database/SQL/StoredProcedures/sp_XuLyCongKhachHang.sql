CREATE PROCEDURE [dbo].[sp_XuLyCongKhachHang] 
	-- Add the parameters for the stored procedure here
	--exec sp_XuLyCongKhachHang '2019-10-1','2019-10-31','admin'
	@fromdate datetime,
	@todate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @ThongBao nvarchar(max)
	set @ThongBao=''
	if exists(select TableName from HR_Khoa where TableName='HR_WTDaily' and Block_Date>=@fromdate and Block_User=@UserName) begin
		set @ThongBao=@ThongBao+N'Dữ liệu đã bị khóa;'
	end
	if @ThongBao='' begin
		Declare @SoGioChoPhepTCTrongThang float,@SoGioChoPhepTCTrongNgay float
		set @SoGioChoPhepTCTrongThang=30
		set @SoGioChoPhepTCTrongNgay=1.5
		Declare @TongTangCaTheoNgay table(Employee_ID nvarchar(50),Ngay datetime,OT float)
		insert into @TongTangCaTheoNgay
		select wt.Employee_ID,Ngay,sum(case when isnull(lc.isWorkingTime,0)=0 then wt.wt/(150.0/lc.LoaiCong) else 0 end) as OT
		from
		HR_WTDaily wt
		left join
		HR_LoaiCong lc
		on wt.MaCong=lc.MaCong
		--left join
		--SmartBooks_HolidaysPlan hp
		--on wt.Ngay=hp.H_date
		where wt.Ngay between @fromdate and @todate-- and wt.Employee_ID='S000007'
		group by Employee_ID,Ngay

		Declare @TongTangCaTheoThang table(Employee_ID nvarchar(50),OT float)
		insert into @TongTangCaTheoThang
		select Employee_ID,sum(OT) as OT from @TongTangCaTheoNgay group by Employee_ID

		declare @BangCongTCKH table(Employee_ID nvarchar(50),Ngay datetime,MaCong nvarchar(50),InsertSource varchar(10),wt float )

		declare @Employee_ID nvarchar(50),@Ngay datetime,@OTNgay float,@TrangThaiNgay varchar(10),@OldEmployee_ID nvarchar(50),@GioTCTieuChuan float,@GioTCVuot float,@GioTCSan as float,@GioTCCN_NL as float
			,@Factory_ID varchar(50)
		set @OldEmployee_ID=''
		DECLARE cur CURSOR LOCAL FOR
		select tctn.Employee_ID,Ngay,OT,case when hp.H_date is not null or DATENAME(weekday,ngay)='Sunday' then 'LCN' else 'T' end,empl.Factory_ID
		from @TongTangCaTheoNgay tctn
		left join
		SmartBooks_HolidaysPlan hp
		on tctn.Ngay=hp.H_date
		left join
		[dbo].[udf_EmployeeFilter]('VN',null,null,null,null,null,null,null,@todate) empl
		on tctn.Employee_ID=empl.Employee_ID
		where tctn.Employee_ID in (select Employee_ID from @TongTangCaTheoThang where ot>@SoGioChoPhepTCTrongThang union select distinct Employee_ID from @TongTangCaTheoNgay where ot>@SoGioChoPhepTCTrongNgay)
			--and tctn.Employee_ID='S000087'
			--and empl.TeamCode<>'SW_General_BV_Guard'
			order by Employee_ID,OT desc
		OPEN  cur     
		FETCH NEXT FROM cur INTO @Employee_ID, @Ngay,@OTNgay,@TrangThaiNgay,@Factory_ID
		WHILE @@FETCH_STATUS = 0    
		BEGIN   
			if @Employee_ID<>isnull(@OldEmployee_ID,'') begin
				select @GioTCVuot=OT-@SoGioChoPhepTCTrongThang from @TongTangCaTheoThang where Employee_ID=@Employee_ID
				set @GioTCSan=0
				set @GioTCCN_NL=0
			end
			set @SoGioChoPhepTCTrongNgay=1.5
			if @Factory_ID='PR' begin
				if @OTNgay>=4 begin
					set @SoGioChoPhepTCTrongNgay=4
				end
			end
			if @TrangThaiNgay='T' begin
				if @GioTCVuot>0 begin
					set @OTNgay=@OTNgay+@GioTCCN_NL
					set @GioTCCN_NL=0
					if @OTNgay>=@GioTCVuot begin
						if @OTNgay-@GioTCVuot<=1.5 or @OTNgay-@GioTCVuot=@SoGioChoPhepTCTrongNgay begin
							insert into @BangCongTCKH(Employee_ID,Ngay,MaCong,InsertSource,wt) values(@Employee_ID,@Ngay,'wt3','AutoAudit',@OTNgay-@GioTCVuot)
						end else if @OTNgay-@GioTCVuot>@SoGioChoPhepTCTrongNgay begin
							insert into @BangCongTCKH(Employee_ID,Ngay,MaCong,InsertSource,wt) values(@Employee_ID,@Ngay,'wt3','AutoAudit',@SoGioChoPhepTCTrongNgay)
							set @GioTCSan=@GioTCSan+@OTNgay-@GioTCVuot-@SoGioChoPhepTCTrongNgay
						end else begin
							insert into @BangCongTCKH(Employee_ID,Ngay,MaCong,InsertSource,wt) values(@Employee_ID,@Ngay,'wt3','AutoAudit',1.5)
							set @GioTCSan=@GioTCSan+@OTNgay-@GioTCVuot-1.5
						end
						set @GioTCVuot=0
					end else begin
						if @OTNgay>=1.5 begin
							set @GioTCVuot=@GioTCVuot-(@OTNgay-1)
							insert into @BangCongTCKH(Employee_ID,Ngay,MaCong,InsertSource,wt) values(@Employee_ID,@Ngay,'wt3','AutoAudit',1)
						end
					end
				end else begin
					set @OTNgay=@OTNgay+@GioTCCN_NL
					set @GioTCCN_NL=0
					if @OTNgay>@SoGioChoPhepTCTrongNgay begin
						set @GioTCSan=@GioTCSan+@OTNgay-@SoGioChoPhepTCTrongNgay
						insert into @BangCongTCKH(Employee_ID,Ngay,MaCong,InsertSource,wt) values(@Employee_ID,@Ngay,'wt3','AutoAudit',@SoGioChoPhepTCTrongNgay)
					end else begin
						if @GioTCSan>0 and @OTNgay<@SoGioChoPhepTCTrongNgay begin
							if @GioTCSan+@OTNgay>@SoGioChoPhepTCTrongNgay begin
								insert into @BangCongTCKH(Employee_ID,Ngay,MaCong,InsertSource,wt) values(@Employee_ID,@Ngay,'wt3','AutoAudit',@SoGioChoPhepTCTrongNgay)
								set @GioTCSan=@GioTCSan-(@SoGioChoPhepTCTrongNgay-@OTNgay)
							end else begin
								insert into @BangCongTCKH(Employee_ID,Ngay,MaCong,InsertSource,wt) values(@Employee_ID,@Ngay,'wt3','AutoAudit',@OTNgay+@GioTCSan)
								set @GioTCSan=0
							end
						end
					end
				end
			end else begin
				set @GioTCCN_NL=@GioTCCN_NL+@OTNgay
				--set @GioTCVuot=@GioTCVuot-@OTNgay
			end
			set @OldEmployee_ID=@Employee_ID
		FETCH NEXT FROM cur INTO @Employee_ID, @Ngay,@OTNgay,@TrangThaiNgay,@Factory_ID
		END    
		CLOSE cur    
		DEALLOCATE cur


		
		delete HR_WTDaily_Audit where ngay between @fromdate and @todate
		--Nhap cong hanh chinh goc
		insert into HR_WTDaily_Audit (Employee_ID,Ngay,MaCong,wt,InsertSource,InsertDate,UserName)
		select Employee_ID,Ngay,MaCong,wt,InsertSource,InsertDate,UserName from HR_WTDaily where macong in (select MaCong from HR_LoaiCong where isWorkingTime=1) and ngay between @fromdate and @todate

		--Nhap cong tang ca goc theo luat
		insert into HR_WTDaily_Audit (Employee_ID,Ngay,MaCong,wt,InsertSource,InsertDate,UserName)
		select wt.Employee_ID,wt.Ngay,wt.MaCong,wt.wt,'NhapTay',getdate(),@UserName
		from
		(select Employee_ID,Ngay,MaCong,sum(wt)as wt from HR_WTDaily where MaCong='wt3' group by Employee_ID,Ngay,MaCong)wt
		left join
		@BangCongTCKH ckh
		on wt.Employee_ID=ckh.Employee_ID and wt.Ngay=ckh.Ngay
		left join
		SmartBooks_HolidaysPlan hp
		on wt.Ngay=hp.H_date
		where ckh.Employee_ID is null
			--and DATENAME(weekday,wt.Ngay)<>'Sunday' and hp.H_date is null
			and wt.ngay between @fromdate and @todate

		--Nhap cong tang ca theo luat
		insert into HR_WTDaily_Audit (Employee_ID,Ngay,MaCong,wt,InsertSource,InsertDate,UserName)
		select Employee_ID,Ngay,MaCong,wt,'NhapTay',getdate(),@UserName
		from
		@BangCongTCKH

		-- xu ly lại voi truong hop chua du cong tieu chuan cua cong theo thang
		declare @CongNoiBo as float,@CongKH as float,@CongTCDieuChinh as float,@PhanCanXuLy as float
		DECLARE cur CURSOR LOCAL FOR
		select wt.Employee_ID,isnull(wtNoiBo.Gio150,0) as CongNoiBo, isnull(wt.Gio150,0) as CongKH,empl.Factory_ID from
			(
				select Employee_ID
					,sum(case when macong='wt3' then isnull(wt,0) else 0 end) as Gio150
				from HR_WTDAILY_AUDIT
					where Ngay between @fromdate and @todate
					group by Employee_ID
			)wt
			left join
			(
				select wt.Employee_ID,sum(case when lc.loaicong not in (100,130) then isnull(wt.wt,0)/(150.0/lc.LoaiCong) else 0 end) as Gio150
				from HR_WTDAILY wt
					left join
					HR_LoaiCong lc
					on wt.MaCong=lc.MaCong
					where wt.Ngay between @fromdate and @todate
					group by wt.Employee_ID
			)wtNoiBo
			on wt.Employee_ID=wtNoiBo.Employee_ID
			left join
			[dbo].[udf_EmployeeFilter]('VN',null,null,null,null,null,null,null,@todate) empl
			on wt.Employee_ID=empl.Employee_ID
		where isnull(wt.Gio150,0)<30 and isnull(wtNoiBo.Gio150,0)>isnull(wt.Gio150,0)-- and wt.Employee_ID='S000121'
		OPEN  cur     
		FETCH NEXT FROM cur INTO @Employee_ID,@CongNoiBo,@CongKH,@factory_id
		WHILE @@FETCH_STATUS = 0    
		BEGIN
			if 30-@CongKH<=@CongNoiBo-@CongKH begin
				set @PhanCanXuLy=30-@CongKH
			end else begin
				set @PhanCanXuLy=@CongNoiBo-@CongKH
			end
			set @SoGioChoPhepTCTrongNgay=1.5
			if @Factory_ID='PR' begin
				if @OTNgay>=4 begin
					set @SoGioChoPhepTCTrongNgay=4
				end
			end
			DECLARE cur1 CURSOR LOCAL FOR
			select Employee_ID,Ngay,sum(case when macong='wt3' then wt else 0 end) as OT
			from
			HR_WTDaily_Audit
			where Ngay between @fromdate and @todate and Employee_ID=@Employee_ID
			group by Employee_ID,Ngay
			OPEN  cur1    
			FETCH NEXT FROM cur1 INTO @Employee_ID,@ngay,@OTNgay
			WHILE @@FETCH_STATUS = 0    
			BEGIN
				if @PhanCanXuLy>=0.5 begin
					if @OTNgay<@SoGioChoPhepTCTrongNgay begin
						if @PhanCanXuLy>=@SoGioChoPhepTCTrongNgay-@OTNgay begin
							set @CongTCDieuChinh=@SoGioChoPhepTCTrongNgay
							set @PhanCanXuLy=@PhanCanXuLy-(@SoGioChoPhepTCTrongNgay-@OTNgay)
						end else begin
							set @CongTCDieuChinh=case when @PhanCanXuLy+@OTNgay>=1.5 then 1.5 else @PhanCanXuLy+@OTNgay end
							set @PhanCanXuLy=@PhanCanXuLy-(@CongTCDieuChinh-@OTNgay)
						end
					
						if exists(select * from HR_WTDaily_Audit where Employee_ID=@Employee_ID and ngay=@Ngay and MaCong='wt3') begin
							update HR_WTDaily_Audit set wt=@CongTCDieuChinh where Employee_ID=@Employee_ID and ngay=@Ngay and MaCong='wt3'
						end else begin
							insert into HR_WTDaily_Audit(Employee_ID,Ngay,MaCong,InsertSource,wt) values(@Employee_ID,@Ngay,'wt3','AutoAudit',@CongTCDieuChinh)
						end
					end
				end
			FETCH NEXT FROM cur1 INTO @Employee_ID,@ngay,@OTNgay
			END    
			CLOSE cur1
			DEALLOCATE cur1
		FETCH NEXT FROM cur INTO @Employee_ID, @CongNoiBo,@CongKH,@factory_id
		END    
		CLOSE cur    
		DEALLOCATE cur

		--xử lý công lẻ
		update  HR_WTDaily_Audit set wt=case when wt<0.5 then 0 when wt<1 then 0.5 when wt<1.5 then 1 end where MaCong='wt3' and ngay between @fromdate and @todate and ROUND(wt,2) not in (0,0.5,1,1.5,4)

		exec [dbo].[sp_XuLyDuLieuQuetKhachHang] @fromdate,@todate,@username
		set @ThongBao=N'Tính công kết thúc!'
	end
	select @ThongBao as ThongBao

END




GO
