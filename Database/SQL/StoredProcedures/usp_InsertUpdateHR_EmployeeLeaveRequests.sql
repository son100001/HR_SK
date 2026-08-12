
CREATE   PROCEDURE [dbo].[usp_InsertUpdateHR_EmployeeLeaveRequests]
	-- Add the parameters for the stored procedure here
	
	@ID [INT],
	@Employee_ID [NVARCHAR](50),
	@LeaveType_ID [NVARCHAR](50),
	@Fromdate [DATETIME],
	@ToDate [DATETIME],
	@Reason [NVARCHAR](255),
	@PlanStatus [VARCHAR](50),
	@Remark [NVARCHAR](225),
	@TrangThai NVARCHAR(50),
	@ApproveDate DATETIME,
	@Approver NVARCHAR(200),
	@InsertDate [DATETIME],
	@UserName [NVARCHAR](50)=NULL,
	@isDaNopGiay BIT,
	@isBlock BIT,
	@isChoUngPhep BIT,
	@HourLeave FLOAT,
	@ImageBinary Nvarchar(max),
	@ImageFileName Nvarchar(255),
	@ImageFileType Nvarchar(50),
	@ImageFileSize Int
	--,@RasomVaoMuon nvarchar(50),
	--@ApproveLevel int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	DECLARE
		@ThongBao as nvarchar(255)
		,@SoNgayNghiKhongPhep INT
		,@NgayDauThangTruoc DATETIME
		,@NgayCuoiThangTruoc DATETIME
		,@today DATETIME
		,@NgayDauNam DATETIME
		,@TongSoPhepNamConLai FLOAT
		,@SoLanDiKhamThai INT
		,@SoPNConLaiTheoPNHienTai FLOAT
		,@SoNgayPhepDangKy FLOAT
		,@NgayChot DATETIME
		,@ApproveLevel nvarchar(200)
		,@ApproveLevelFirst nvarchar(50)
		,@ThuTuDuyet int = 1
		,@Fullname nvarchar(50), @Email nvarchar(100), @EmailDuPhong nvarchar(100)
		,@FlowCode nvarchar(50)
		,@RequestType nvarchar(50) = N'RequestLeave'
	
	SET @today=DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))
	SET @NgayCuoiThangTruoc=@today-DATEPART(DAY,@today)
	SET @NgayDauThangTruoc=DATEADD(DAY,1-DATEPART(DAY,@NgayCuoiThangTruoc),@NgayCuoiThangTruoc)
	SET @NgayDauNam=CAST(CAST(DATEPART(YEAR,@fromdate) AS VARCHAR)+'-1-1' AS DATETIME)
	SET @Fromdate = CAST(@Fromdate AS DATE)
	SET @ToDate = CAST(@ToDate AS DATE)

	-- Tạm tắt ứng phép (phase hiện tại không dùng)
	SET @isChoUngPhep = 0
	
	--SELECT @ApproveLevel = Quyen from [User] where @Approver = UserName
	SELECT @ApproveLevelFirst = [Data] from Split(@Approver, ',') where Order_ = 1
	SELECT
		@ApproveLevel = STRING_AGG(CAST(ap.[Data] AS nvarchar(max)), ',') WITHIN GROUP (ORDER BY ap.Order_)
	FROM Split(@Approver, ',') ap
	WHERE EXISTS (
		SELECT 1
		FROM HR_ApprovalLevelMember firstMember
		INNER JOIN HR_ApprovalLevelMember sameLevel
			ON sameLevel.LevelCode = firstMember.LevelCode
			AND sameLevel.IsActive = 1
		WHERE firstMember.Employee_ID = @ApproveLevelFirst
			AND firstMember.IsActive = 1
			AND sameLevel.Employee_ID = ap.[Data]
	)
	SET @ApproveLevel = ISNULL(NULLIF(@ApproveLevel, ''), @ApproveLevelFirst)
	select @ApproveDate = isnull(@ApproveDate,GETDATE())
	select @Fullname = Employee_FirstName + ' ' + Employee_Lastname from SmartBooks_Employee where Employee_ID = @Employee_ID
	select @Email  = Email from SmartBooks_Employee where Employee_ID = @ApproveLevelFirst
	-- select @EmailDuPhong = [Value] from SetUp where FunctionID = 'Email' and ID = 'EmailDuPhong' -- tắt email dự phòng

	SELECT @FlowCode = dbo.udf_ResolveApprovalFlow(@Employee_ID, @RequestType, GETDATE());
	IF @FlowCode IS NULL
	BEGIN
		SELECT TOP 1 @FlowCode = NULLIF(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N'')
		FROM udf_EmployeeFilter_Web(N'VN', NULL, NULL, NULL, NULL, NULL, NULL, @Employee_ID, GETDATE()) ef;
	END

	IF @FlowCode IS NOT NULL AND @ApproveLevelFirst IS NOT NULL
	BEGIN
		SET @ThuTuDuyet = dbo.udf_GetApprovalStepOrderForApprover_Web(
			@FlowCode,
			@RequestType,
			@ApproveLevelFirst
		);
	END
	------------------------

	--trung ngay nghi da dang ky
	if exists(select Employee_ID from HR_EmployeeRegisMaternityLeave where @Fromdate<=ToDate and @ToDate>=Fromdate and Employee_ID=@Employee_ID and ID<>isnull(@ID,0)) or 
		exists(select Employee_ID from HR_DangKyPhepTheoGio where DateLeave between @Fromdate and @todate and Employee_ID=@Employee_ID)
		set @ThongBao=N'Ngày phép trùng với phép đã đăng ký trước đó'
	

	--trung ngay nghi bu
	if exists(select * from HR_MaxOvertime where @Fromdate<=NgayNghiBu and @ToDate>=NgayNghiBu and Employee_ID=@Employee_ID)
		set @ThongBao=N'Ngày phép trùng với ngày tăng ca nghỉ bù'

	--IF @LeaveType_ID NOT IN ('24','46','21','15','11','31','32','25','26')
	--	SET @ThongBao=N'Loại nghỉ này không được đăng ký. Cần liên hệ với bộ phận HR'
	

	--nghi kham thai
	if exists(select * from SmartBooks_LeaveType where isNghiKhamThai=1 and LeaveType_ID=@LeaveType_ID)
	BEGIN
		if @Fromdate<>@ToDate		
			set @ThongBao=N'Ngày khám thai không hợp lệ'		
        
		if not exists(select * from HR_EmployeeRegisPregnant where Employee_ID=@Employee_ID and @Fromdate between Fromdate and ToDate)
		BEGIN
			set @ThongBao=N'Chưa đăng ký thai sản'
		END
		ELSE begin
			SELECT
				@SoLanDiKhamThai=COUNT(erml.Employee_ID)
			FROM 
			HR_EmployeeRegisPregnant erp
			left join
			HR_EmployeeRegisMaternityLeave erml
			on erp.Employee_ID COLLATE DATABASE_DEFAULT=erml.Employee_ID and erml.Fromdate between erp.Fromdate and erp.ToDate
			where erp.Employee_ID=@Employee_ID and erml.LeaveType_ID=@LeaveType_ID and @fromdate between erp.fromdate and erp.todate and erml.ID<>isnull(@ID,0)
			
			IF @SoLanDiKhamThai>=5			
				set @ThongBao=N'Số lần nghỉ khám thai vượt quá số ngày quy định'
		end
	end		
	-------------------------

	--dang ky nghi phep nam, kiem tra dieu kien ung phep
	IF EXISTS(SELECT LeaveType_ID FROM SmartBooks_LeaveType WHERE PhepNam=1 AND LeaveType_ID=@LeaveType_ID)
	BEGIN
		SET @NgayChot=EOMONTH(GETDATE())	
		
		--check lại thêm điều kiện được nghỉ quá 1 ngày cho những ai có thâm niên
		--gỡ duyệt phép cho tháng 6/2025, ứng trước phép của tháng 7/2025
		IF @Fromdate BETWEEN '2025-06-23' AND '2025-06-30'
			SET @NgayChot='2025-07-1'
		
		SELECT
			@TongSoPhepNamConLai=ISNULL(PhepNamDuocHuong,0)+ISNULL(PhepNamTon,0)-ISNULL(TongPhepNamDaNghi,0)
			,@SoPNConLaiTheoPNHienTai=ISNULL(PhepNamDuocHuongDenHienTai,0)+ISNULL(PhepNamTon,0)-ISNULL(TongPhepNamDaNghi,0)
		FROM [dbo].[udf_QuanLyPhepNam](DATEPART(YEAR,@fromdate),@NgayChot,'VN',NULL,NULL,NULL,NULL,NULL,NULL,@Employee_ID)
		
		---Xét ngày đăng ký mới có đủ phép năm để trừ không 
		SET @SoNgayPhepDangKy=[dbo].[udf_CountWorkingDay](@Fromdate,@todate)*(CASE WHEN @LeaveType_ID IN ('31','32') THEN 0.5 ELSE 1 END)
		SET	@TongSoPhepNamConLai=@TongSoPhepNamConLai-@SoNgayPhepDangKy
		SET @SoPNConLaiTheoPNHienTai=@SoPNConLaiTheoPNHienTai-@SoNgayPhepDangKy
						
		IF @employee_Id in (select Employee_ID from Smartbooks_Employee WHERE @Fromdate > ISNULL(TernimationDate,@Fromdate+1))
			SET @ThongBao=N'Không đủ phép năm để đăng ký hoặc đăng ký sau ngày nghỉ việc'
		-- Tạm tắt ứng phép (phase hiện tại không dùng)
		-- ELSE IF ISNULL(@isChoUngPhep,0)=1 AND @TongSoPhepNamConLai<0
		-- 	SET @ThongBao=N'Không đủ phép năm để ứng phép'
		ELSE IF @SoPNConLaiTheoPNHienTai<0
			---[dbo].[udf_CountWorkingDay](@Fromdate,@ToDate)*(CASE WHEN @LeaveType_ID IN ('31','32') THEN 0.5 ELSE 1 END)<0
			SET @ThongBao=N'Không đủ phép năm để đăng ký hoặc đăng ký sau ngày nghỉ việc'
				
	END
    
	----------------------------------------------------------
	
	--xử lý kiểm tra khóa theo record
	if exists(select Employee_ID from HR_EmployeeRegisMaternityLeave where ((Employee_ID=@Employee_ID and Fromdate=@Fromdate) or ID=isnull(@ID,0)) and isBlock=1)
	BEGIN
		set @ThongBao=N'Dữ liệu đã khóa'
	end

	DECLARE @ChiGuiThongBao NVARCHAR(MAX);

	SELECT @ChiGuiThongBao = ISNULL(ChiGuiThongBao, N'')
	FROM HR_GetApprover
	WHERE Code = @Approver
	  AND Employee_ID = @Employee_ID
	  AND RequestType = @RequestType;

	SET @ChiGuiThongBao = ISNULL(@ChiGuiThongBao, N'');
	
	SET @TrangThai = 'Pending'
	 --or isnull(@ThongBao,'')=N'Loainghinaydavuotquasongayquydinh'
	if isnull(@ThongBao,'')='' 
	BEGIN
		if exists(select Employee_ID from HR_EmployeeLeaveRequests where (Employee_ID=@Employee_ID and Fromdate=@Fromdate and ID IS NOT NULL))
		begin
			update HR_EmployeeLeaveRequests
			set LeaveType_ID=@LeaveType_ID
				,Fromdate=@Fromdate
				,ToDate=@ToDate
				,Reason=@Reason
				,PlanStatus=@PlanStatus
				,Remark=@Remark
				,UserName=@UserName
				,InsertDate=GETDATE()
				,isDaNopGiay=@isDaNopGiay
				,isBlock=@isBlock
				,TrangThai=@TrangThai
				,ApproverName=@Approver
				,ApproveDate=@ApproveDate
				,HourLeave=@HourLeave
				,ApproveLevel = @ApproveLevel
				,ThuTuDuyet = @ThuTuDuyet
				,ChiGuiThongBao = @ChiGuiThongBao
				,CurrentStepSince = GETDATE()
				,isChoUngPhep = @isChoUngPhep
				,ImageBinary = @ImageBinary
				,ImageFileName = @ImageFileName
				,ImageFileType = @ImageFileType
				,ImageFileSize = @ImageFileSize
			where (Employee_ID=@Employee_ID and Fromdate=@Fromdate) or ID=isnull(@ID,0)
		END
		ELSE begin
			insert into HR_EmployeeLeaveRequests(
				[Employee_ID],[LeaveType_ID],[Fromdate],[ToDate],Reason,PlanStatus,[Remark],
				[InsertDate],[UserName],[isDaNopGiay],[isBlock],isChoUngPhep,TrangThai,ApproveDate,
				ApproverName,HourLeave,ApproveLevel,ThuTuDuyet,ChiGuiThongBao,CurrentStepSince,ImageBinary,ImageFileName,ImageFileType,ImageFileSize
				)
			values(
				@Employee_ID,@LeaveType_ID,@Fromdate,@ToDate,@Reason,@PlanStatus,@Remark
				,GETDATE(),@UserName,@isDaNopGiay,@isBlock,@isChoUngPhep,isnull(@TrangThai,'Pending'),@ApproveDate
				,@Approver,@HourLeave,@ApproveLevel,@ThuTuDuyet,@ChiGuiThongBao,GETDATE(),@ImageBinary,@ImageFileName,@ImageFileType,@ImageFileSize
				)
		end
	end

	if @ApproveLevel is null begin
		Delete HR_DanhSachNguoiNhanThongBao
		where Employee_ID = @Employee_ID and Type_ = 'RequestLeave'

		insert into HR_DanhSachNguoiNhanThongBao (Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao, NotifyViaWeb, NotifyViaEmail, NotifyViaZalo)
		select @Employee_ID, dt.[Data], Employee_FirstName + ' ' + Employee_Lastname, 'RequestLeave', ISNULL(Email, ''), 0, case when @ApproveLevel is null then 1 else 0 end, ch.NotifyViaWeb, ch.NotifyViaEmail, ch.NotifyViaZalo
		from
		Split(@ChiGuiThongBao,',') dt
		left join
		SmartBooks_Employee empl
		on dt.[Data] = empl.Employee_ID
		CROSS APPLY dbo.udf_ApprovalNotifyChannels_Web(@RequestType, @FlowCode, NULL, 1) ch
		where dt.[Data] <> ''
	end else begin
		Delete HR_DanhSachNguoiNhanThongBao
		where Employee_ID = @Employee_ID and Type_ = 'RequestLeave'

		insert into HR_DanhSachNguoiNhanThongBao (Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao, NotifyViaWeb, NotifyViaEmail, NotifyViaZalo)
		select @Employee_ID, dt.[Data], @Fullname, 'RequestLeave', ISNULL(empl.Email, ''), 0, 0, ch.NotifyViaWeb, ch.NotifyViaEmail, ch.NotifyViaZalo
		from Split(@ApproveLevel, ',') dt
		left join SmartBooks_Employee empl
			on dt.[Data] = empl.Employee_ID
		CROSS APPLY dbo.udf_ApprovalNotifyChannels_Web(@RequestType, @FlowCode, @ThuTuDuyet, 0) ch
		where dt.[Data] <> ''
	end
	
	SELECT @ID=ID
	FROM HR_EmployeeLeaveRequests
	WHERE Employee_ID=@Employee_ID and Fromdate=@Fromdate
	--if isnull(@ThongBao,'')<>N'Loainghinaydavuotquasongayquydinh' begin
	
	--end
	select @ThongBao as ThongBao,@ID as ID
END

GO
