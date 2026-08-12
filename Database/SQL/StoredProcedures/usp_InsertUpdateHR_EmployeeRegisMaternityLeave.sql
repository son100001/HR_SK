CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_EmployeeRegisMaternityLeave]
	-- Add the parameters for the stored procedure here
	--exec usp_InsertUpdateHR_EmployeeRegisMaternityLeave '8896',N'19000001',N'11','2019-08-04 00:00:00','2019-08-08 00:00:00',N'chua giay',N'Plan-Shift2',N'','2019-07-29 13:39:43',N'admin',null
	@ID [int],
	@Employee_ID [nvarchar](50),
	@LeaveType_ID [nvarchar](50),
	@Fromdate [datetime],
	@ToDate [datetime],
	@Reason [nvarchar](255),
	@PlanStatus [varchar](50),
	@Remark [nvarchar](225),
	@InsertDate [datetime],
	@UserName [nvarchar](50)=null,
	@isDaNopGiay bit,
	@isBlock bit,
	@isChoUngPhep bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	declare @ThongBao as nvarchar(255),@SoNgayNghiKhongPhep int,@NgayDauThangTruoc datetime,@NgayCuoiThangTruoc datetime,@today datetime,@NgayDauNam datetime, @TongSoPhepNamConLai float,@SoLanDiKhamThai int
		,@SoPNConLaiTheoPNHienTai float,@NgayChot datetime, @Department nvarchar(50)
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@Fromdate,@UserName,'HR_EmployeeRegisMaternityLeave')
	if @ThongBao='' begin
		set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@ToDate,@UserName,'HR_EmployeeRegisMaternityLeave')
	end
	select @Department = DepartmentCode from udf_EmployeeFilter ('VN',null,null,null,null,null,null,@Employee_ID,GETDATE())
	Declare @Thu7DuocNghi datetime = null
	--select @Thu7DuocNghi = [Value] from Setup where FunctionID = 'Thu7DuocNghi' and ID = 'T7DN'
	set @today=DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))
	set @NgayCuoiThangTruoc=@today-DATEPART(day,@today)
	set @NgayDauThangTruoc=dateadd(day,1-DATEPART(day,@NgayCuoiThangTruoc),@NgayCuoiThangTruoc)
	set @NgayDauNam=cast(cast(datepart(year,@fromdate) as varchar)+'-1-1' as datetime)
	--Khóa dữ liệu
	--if not(DATEPART(day,@today) between 1 and 3 and @Fromdate between @NgayDauThangTruoc and @NgayCuoiThangTruoc) begin
	--	if @Fromdate<@today-3 begin
	--		set @ThongBao=@ThongBao+N'Chỉ được sửa phép cách đay 3 ngày;'
	--	end
	--end
	if @LeaveType_ID = '11' and (Upper(left(datename(dw,@Fromdate),3)) = 'SUN' and @Department not like '%Soi%') begin
		set @ThongBao=N'PhepNamKhongDuocDangKyNgayNghi'
	end
	if @LeaveType_ID='16' begin
		set @ThongBao=N'Phepnghibucode16khongduocnhapogiaodiennay'
	end
	if exists(select * from HR_EmployeeRegisMaternityLeave where @Fromdate<=ToDate and @ToDate>=Fromdate and Employee_ID=@Employee_ID and ID<>isnull(@ID,0)) begin
		set @ThongBao=N'Nghipheptrungvoivoipheptruocdo'
	end

	if exists(select * from HR_MaxOvertime where @Fromdate<=NgayNghiBu and @ToDate>=NgayNghiBu and Employee_ID=@Employee_ID) begin
		set @ThongBao=N'Pheptrungvoivoipheptangcanghibu'
	end

	if exists(select * from SmartBooks_LeaveType where isNghiKhamThai=1 and LeaveType_ID=@LeaveType_ID) begin
		if not exists(select * from HR_EmployeeRegisPregnant where Employee_ID=@Employee_ID and @Fromdate between Fromdate and ToDate) begin
			set @ThongBao=N'Chuacotrongdanhsachmangthai'
		end else begin
			select @SoLanDiKhamThai=COUNT(erml.Employee_ID) from 
			HR_EmployeeRegisPregnant erp
			left join
			HR_EmployeeRegisMaternityLeave erml
			on erp.Employee_ID COLLATE DATABASE_DEFAULT=erml.Employee_ID and erml.Fromdate between erp.Fromdate and erp.ToDate
			where erp.Employee_ID=@Employee_ID and erml.LeaveType_ID=@LeaveType_ID and @fromdate between erp.fromdate and erp.todate and erml.ID<>isnull(@ID,0)
			--if @SoLanDiKhamThai>=5 begin
			--	set @ThongBao=N'Loainghinaydavuotquasongayquydinh'
			--end
		end
	end
	--xử lý loại nghỉ khám thai
	if exists(select LeaveType_ID from SmartBooks_LeaveType where isNghiKhamThai=1 and LeaveType_ID=@LeaveType_ID) begin
		if @Fromdate<>@ToDate begin
			set @ThongBao=N'Ngaykhamthaikhonghople'
		end
	end
	--Xử lý code 14 nghỉ ko phép
	--if @LeaveType_ID='14' begin
	--	if isnull(@isChoUngPhep,0)<>1 begin
	--		set @SoNgayNghiKhongPhep=0
	--		select @SoNgayNghiKhongPhep=@SoNgayNghiKhongPhep+DATEDIFF(day,(case when DATEADD(day,-30,@Fromdate)>=Fromdate then DATEADD(day,-30,@Fromdate) else Fromdate end),ToDate)+1 from HR_EmployeeRegisMaternityLeave where LeaveType_ID='14' and Fromdate<@Fromdate and ToDate between DATEADD(day,-30,@Fromdate) and @Fromdate-1 and Employee_ID=@Employee_ID and ID<>isnull(@ID,0)
	--		if @SoNgayNghiKhongPhep+DATEDIFF(day,@Fromdate,@ToDate)+1>5 begin
	--			set @ThongBao=N'Loainghinaydavuotquasongayquydinh'
	--		end
	--	end
	--end

	--xử lý nhập phép năm
	--if isnull(@isChoUngPhep,0)<>1 begin
	--	if exists(select LeaveType_ID from SmartBooks_LeaveType where PhepNam=1 and LeaveType_ID=@LeaveType_ID) begin
	--		set @NgayChot=DATEFROMPARTS(DATEPART(year,getdate()),DATEPART(month,getdate()),1)
	--		if DATEPART(year,@Fromdate)=DATEPART(year,@NgayChot) begin
	--			set @NgayChot=DATEADD(month,1,@NgayChot)-1
	--		end
	--		set @TongSoPhepNamConLai=0
	--		set @SoPNConLaiTheoPNHienTai=0
	--		select @TongSoPhepNamConLai=isnull(PhepNamDuocHuong,0)+isnull(PhepNamTon,0)-isnull(TongPhepNamDaNghi,0)
	--			,@SoPNConLaiTheoPNHienTai=isnull(PhepNamDuocHuongDenHienTai,0)+isnull(PhepNamTon,0)-isnull(TongPhepNamDaNghi,0)
	--		from [dbo].[udf_QuanLyPhepNam](DATEPART(year,@fromdate),@NgayChot,'VN',null,null,null,null,null,null,@Employee_ID)
	--		select @TongSoPhepNamConLai=@TongSoPhepNamConLai+[dbo].[udf_CountWorkingDay](Fromdate,ToDate)*(case when LeaveType_ID in ('31','32') then 0.5 else 1 end) from HR_EmployeeRegisMaternityLeave where (Employee_ID=@Employee_ID and Fromdate=@Fromdate) or ID=isnull(@ID,0)
	--		if @SoPNConLaiTheoPNHienTai-[dbo].[udf_CountWorkingDay](@Fromdate,@ToDate)*(case when @LeaveType_ID in ('31','32') then 0.5 else 1 end)<0 begin
	--			set @ThongBao=N'Loainghinaydavuotquasongayquydinh'
	--		end else if @TongSoPhepNamConLai-[dbo].[udf_CountWorkingDay](@Fromdate,@ToDate)*(case when @LeaveType_ID in ('31','32') then 0.5 else 1 end)<0 begin
	--			set @ThongBao=N'Loainghinaydavuotquasongayquydinh'
	--		end
	--	end
	--end
	
	--xử lý kiểm tra khóa theo record
	if exists(select Employee_ID from HR_EmployeeRegisMaternityLeave where ((Employee_ID=@Employee_ID and Fromdate=@Fromdate) or ID=isnull(@ID,0)) and isBlock=1) begin
		set @ThongBao=N'Dulieudabikhoa'
	end

	if isnull(@ThongBao,'')='' begin
		if exists(select Employee_ID from HR_EmployeeRegisMaternityLeave where (Employee_ID=@Employee_ID and Fromdate=@Fromdate) or ID=isnull(@ID,0))
		begin
			update HR_EmployeeRegisMaternityLeave
			set LeaveType_ID=@LeaveType_ID,Fromdate=@Fromdate,ToDate=@ToDate
			,Reason=@Reason,PlanStatus=@PlanStatus
			,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
			,isDaNopGiay=@isDaNopGiay,isBlock=@isBlock
			where (Employee_ID=@Employee_ID and Fromdate=@Fromdate) or ID=isnull(@ID,0)
		end else begin
			insert into HR_EmployeeRegisMaternityLeave
			(
				[Employee_ID],
				[LeaveType_ID],
				[Fromdate],
				[ToDate],
				Reason,
				PlanStatus,
				[Remark],
				[InsertDate],
				[UserName],
				[isDaNopGiay],
				[isBlock],
				isChoUngPhep
			)
			values(@Employee_ID,@LeaveType_ID,@Fromdate,@ToDate,@Reason,@PlanStatus,@Remark,GETDATE(),@UserName,@isDaNopGiay,@isBlock,null)
		end
	end
	if @LeaveType_ID in ('26','39','40','41') begin
		update HR_EmployeeRegisPregnant
		set MiscarriageDate = @Fromdate
		where @Fromdate between Fromdate and ToDate and Employee_ID = @Employee_ID and @Fromdate between Fromdate and ToDate
	end
	select @ID=ID from HR_EmployeeRegisMaternityLeave where Employee_ID=@Employee_ID and Fromdate=@Fromdate
	select @ThongBao as ThongBao,@ID as ID
END




GO
