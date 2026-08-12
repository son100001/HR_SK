CREATE PROCEDURE [dbo].[usp_InsertUpdateSmartBooks_Employee]
	-- Add the parameters for the stored procedure here
	--exec usp_InsertUpdateSmartBooks_Employee N'19001132',N'A b',N'C','1984-02-05 00:00:00',N'Tỉnh Thanh Hóa',N'Female',N'Single',N'Việt Nam',N'003456',N'12345678','2000-01-01 00:00:00',N'Tỉnh Bình Phước',N'adfafd - Phường Long Bình - Quận 9 - Thành phố Hồ Chí Minh',N' -Xã Tân Quan - Huyện Hớn Quản - Tỉnh Bình Phước',N'Tỉnh Thanh Hóa',N'Hiring','2019-07-01 00:00:00','2019-07-01 00:00:00',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,N'Cấp II',null,N'Trường Cấp II',null,null,N'252345',null,null,null,null,N'H?i Giáo',null,null,null,null,null,null,N'admin','2019-07-01 15:37:47',null
	@Employee_ID NVARCHAR(255),
    @Employee_Firstname NVARCHAR(255),
    @Employee_LastName NVARCHAR(255),
    @BirthDate DATETIME,
    @BirthPlace NVARCHAR(255),
    @Sex NVARCHAR(255),
    @MaritalStatus NVARCHAR(255),
    @Nationality NVARCHAR(255),
    @Nation NVARCHAR(50),
    @ID_number NVARCHAR(255),
    @ID_date DATETIME,
    @NgayHetHanCCCD DATETIME,
    @ID_place NVARCHAR(255),
    @Address_Temporary NVARCHAR(255),
    @Address_Permanent NVARCHAR(255),
    @NativePlace NVARCHAR(255),
    @Employee_Status NVARCHAR(255),
    @StartedDate DATETIME,
    @ComStartedDate DATETIME,
    @Factory_ID NVARCHAR(50),
    @DepartmentCode NVARCHAR(50),
    @SectionCode NVARCHAR(100),
    @TeamCode NVARCHAR(50),
    @Position_ID NVARCHAR(50),
    @PositionCategory_ID NVARCHAR(50),
    @ChucDanh NVARCHAR(50),
    @JobCode NVARCHAR(50),
    @CongViecPhaiLam NVARCHAR(MAX),
    @Card_No NVARCHAR(50),
    @Card_Code NVARCHAR(50),
    @TypeOfHiring NVARCHAR(50),
    @BankName NVARCHAR(255),
    @BankCode NVARCHAR(50),
    @DebitAccount NVARCHAR(50),
    @Qualification NVARCHAR(255),
    @OfficialDate DATETIME,
    @Graduated NVARCHAR(50),
    @GraduatedFrom NVARCHAR(255),
    @TernimationDate DATETIME,
    @Tel NVARCHAR(255),
    @Email NVARCHAR(50),
    @MaSoThue NVARCHAR(50),
    @SoNgayPhepNam FLOAT,
    @ContractFlow NVARCHAR(50),
    @TonGiao NVARCHAR(100),
    @NguoiLienHeGap NVARCHAR(MAX),
    @Height FLOAT,
    @Weight FLOAT,
    @Hospital NVARCHAR(255),
    @HealthCheckFee FLOAT,
    @Remark NVARCHAR(MAX),
    @UserName NVARCHAR(50),
    @InsertDate DATETIME,
    @Picture IMAGE,
    @RFID NVARCHAR(50),
    @BirthDateFormat VARCHAR(10),
    @TenChuHo NVARCHAR(50),
    @QuanHeVoiChuHo NVARCHAR(50),
    @isThuViec85PhanTram BIT,
    @NgayTGCongDoan DATETIME,
    @EndOfSeasonWorker DATETIME,
    @IsSeasonWorker BIT,
    @isManager BIT,
    @Camket BIT,
    @NguoiGT NVARCHAR(100),
    @Accountcode1 NVARCHAR(50),
    @Accountcode2 NVARCHAR(50),
    @Accountcode3 NVARCHAR(50),
    @PicCam IMAGE,
    @CCCDCu NVARCHAR(50),
    @CCCDCu_Date DATETIME,
    @CCCDCu_Place NVARCHAR(500),
    @isTanTat BIT,
    @TanTat NVARCHAR(100),
    @ResonTerminated nvarchar(200),
    @SoNhaThonXom nvarchar(100),
    @PhuongXa nvarchar(100),
    @QuanHuyen nvarchar(100),
    @TinhThanhPho nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255),@MaCongTy nvarchar(50),@countEmployee int
	select @MaCongTy=[Value] from SetUp where ID='MaCongTy'
	set @ThongBao=''
	if @Employee_ID is null begin
		if exists(select Employee_ID from SmartBooks_Employee where ID_number=@ID_number) begin
			set @ThongBao=N'CMTNDdatontai'
		end
	end
	if @Employee_Status='Incumbent' begin
		if @BirthDate is null begin
			set @ThongBao=N'Ngaysinhdangbitrong'
		--end else begin
		--	if DATEADD(YEAR,18,@BirthDate)>@StartedDate begin
		--		set @ThongBao=@ThongBao--@ThongBao+N'Nhỏ hơn 18 tuổi;'
		--	--end else if (DATEADD(YEAR,54,@BirthDate)<=@StartedDate and (@sex is null or @Sex='Female')) or (DATEADD(YEAR,59,@BirthDate)<=@StartedDate and @Sex='Male') begin
		--	--	set @ThongBao=@ThongBao+N'Sắp hoặc đã về hưu;'
		--	end
		end
	end

	--Biến update password
	Declare @Password varchar(500), @FullName nvarchar(500), @NgayHienTai datetime
	select @Password = CONVERT(VARCHAR(32),HASHBYTES('MD5', CONVERT(VARCHAR(5),FORMAT(cast(@BirthDate as datetime),'ddMM'))), 2)
	select @FullName = dbo.udf_FullName (@Employee_Firstname, @Employee_LastName)
	select @NgayHienTai = Getdate()

	if @NgayHetHanCCCD is null
		set @NgayHetHanCCCD = case when datediff(year,@BirthDate,@NgayHienTai) < 25 then dateadd(year, 25, @NgayHienTai) when datediff(year,@BirthDate,@NgayHienTai) < 40 then dateadd(year,40, @BirthDate) when datediff(year,@BirthDate,@NgayHienTai) < 60 then dateadd(year,60, @BirthDate) else dateadd(year,100, @BirthDate) end

	if ISNULL(@thongbao,'')='' begin
		--if @Employee_ID is null begin
		--	if @MaCongTy='JinHeoung' begin
		--		select @Employee_ID=isnull(max(Employee_ID),LEFT(convert(varchar, @StartedDate, 102),2)+'000000')+1 from SmartBooks_Employee where LEFT(convert(varchar, StartedDate, 102),2)= LEFT(convert(varchar, @StartedDate, 102),2)
		--	end else begin
		--		select @Employee_ID=isnull(max(Employee_ID),LEFT(convert(varchar, @StartedDate, 102),2) + '00000')+1 from SmartBooks_Employee where LEFT(convert(varchar, StartedDate, 102),2)= LEFT(convert(varchar, @StartedDate, 102),2)
		--	end
		--end
		if @Employee_Status is null begin
			set @Employee_Status='Incumbent'
		end
		if exists (select Employee_ID from SmartBooks_Employee where Employee_ID=@Employee_ID) begin
			update SmartBooks_Employee
			set 
			Employee_ID = @Employee_ID,
			Employee_Firstname = @Employee_Firstname,
			Employee_LastName = @Employee_LastName,
			BirthDate = @BirthDate,
			BirthPlace = @BirthPlace,
			Sex = @Sex,
			MaritalStatus = @MaritalStatus,
			Nationality = @Nationality,
			Nation = @Nation,
			ID_number = @ID_number,
			ID_date = @ID_date,
			NgayHetHanCCCD = @NgayHetHanCCCD,
			ID_place = @ID_place,
			Address_Temporary = @Address_Temporary,
			Address_Permanent = @SoNhaThonXom + '-' + @PhuongXa + '-' + @QuanHuyen + '-' + @TinhThanhPho,
			NativePlace = @NativePlace,
			Employee_Status = ISNULL(@Employee_Status, 'Incumbent'),
			StartedDate = @StartedDate,
			ComStartedDate = @ComStartedDate,
			Factory_ID = @Factory_ID,
			DepartmentCode = @DepartmentCode,
			SectionCode = @SectionCode,
			TeamCode = @TeamCode,
			Position_ID = @Position_ID,
			PositionCategory_ID = @PositionCategory_ID,
			ChucDanh = @ChucDanh,
			JobCode = @JobCode,
			CongViecPhaiLam = @CongViecPhaiLam,
			Card_No = @Card_No,
			Card_Code = @Card_Code,
			TypeOfHiring = @TypeOfHiring,
			BankName = @BankName,
			BankCode = @BankCode,
			DebitAccount = @DebitAccount,
			Qualification = @Qualification,
			OfficialDate = @OfficialDate,
			Graduated = @Graduated,
			GraduatedFrom = @GraduatedFrom,
			TernimationDate = @TernimationDate,
			Tel = @Tel,
			Email = @Email,
			MaSoThue = @MaSoThue,
			SoNgayPhepNam = @SoNgayPhepNam,
			ContractFlow = @ContractFlow,
			TonGiao = @TonGiao,
			NguoiLienHeGap = @NguoiLienHeGap,
			Height = @Height,
			Weight = @Weight,
			Hospital = @Hospital,
			HealthCheckFee = @HealthCheckFee,
			Remark = @Remark,
			UserName = @UserName,
			InsertDate = GETDATE(),
			Picture = @Picture,
			RFID = @RFID,
			BirthDateFormat = @BirthDateFormat,
			TenChuHo = @TenChuHo,
			QuanHeVoiChuHo = @QuanHeVoiChuHo,
			isThuViec85PhanTram = @isThuViec85PhanTram,
			NgayTGCongDoan = @NgayTGCongDoan,
			EndOfSeasonWorker = @EndOfSeasonWorker,
			IsSeasonWorker = @IsSeasonWorker,
			isManager = @isManager,
			Camket = @Camket,
			NguoiGT = @NguoiGT,
			Accountcode1 = @Accountcode1,
			Accountcode2 = @Accountcode2,
			Accountcode3 = @Accountcode3,
			PicCam = @PicCam,
			CCCDCu = @CCCDCu,
			CCCDCu_Date = @CCCDCu_Date,
			CCCDCu_Place = @CCCDCu_Place,
			isTanTat = @isTanTat,
			TanTat = @TanTat,
            ResonTerminated = @ResonTerminated,
            SoNhaThonXom = @SoNhaThonXom,
            PhuongXa = @PhuongXa,
            QuanHuyen = @QuanHuyen,
            TinhThanhPho = @TinhThanhPho
			where Employee_ID=@Employee_ID

			Exec usp_InsertUpdateUser_Account null, @Hospital, @Employee_ID, null, @Employee_ID, @FullName, null, @NgayHienTai, @UserName, null, null
		end else begin
			select @countEmployee=count(Employee_ID) from SmartBooks_Employee where Employee_Status in ('Incumbent','Hiring')
			if @countEmployee>1500 begin
				set @ThongBao=N'Exceed 1500 employees!'
			end else begin
				insert into SmartBooks_Employee
				(
                    Employee_ID,
                    Employee_Firstname,
                    Employee_LastName,
                    BirthDate,
                    BirthPlace,
                    Sex,
                    MaritalStatus,
                    Nationality,
                    Nation,
                    ID_number,
                    ID_date,
                    NgayHetHanCCCD,
                    ID_place,
                    Address_Temporary,
                    Address_Permanent,
                    NativePlace,
                    Employee_Status,
                    StartedDate,
                    ComStartedDate,
                    Factory_ID,
                    DepartmentCode,
                    SectionCode,
                    TeamCode,
                    Position_ID,
                    PositionCategory_ID,
                    ChucDanh,
                    JobCode,
                    CongViecPhaiLam,
                    Card_No,
                    Card_Code,
                    TypeOfHiring,
                    BankName,
                    BankCode,
                    DebitAccount,
                    Qualification,
                    OfficialDate,
                    Graduated,
                    GraduatedFrom,
                    TernimationDate,
                    Tel,
                    Email,
                    MaSoThue,
                    SoNgayPhepNam,
                    ContractFlow,
                    TonGiao,
                    NguoiLienHeGap,
                    Height,
                    [Weight],
                    Hospital,
                    HealthCheckFee,
                    Remark,
                    UserName,
                    InsertDate,
                    Picture,
                    RFID,
                    BirthDateFormat,
                    TenChuHo,
                    QuanHeVoiChuHo,
                    isThuViec85PhanTram,
                    NgayTGCongDoan,
                    EndOfSeasonWorker,
                    IsSeasonWorker,
                    isManager,
                    Camket,
                    NguoiGT,
                    Accountcode1,
                    Accountcode2,
                    Accountcode3,
                    PicCam,
                    CCCDCu,
                    CCCDCu_Date,
                    CCCDCu_Place,
                    isTanTat,
                    TanTat,
                    ResonTerminated,
                    SoNhaThonXom,
                    PhuongXa,
                    QuanHuyen,
                    TinhThanhPho
                )
                VALUES
                (
                    @Employee_ID,
                    @Employee_Firstname,
                    @Employee_LastName,
                    @BirthDate,
                    @BirthPlace,
                    @Sex,
                    @MaritalStatus,
                    @Nationality,
                    @Nation,
                    @ID_number,
                    @ID_date,
                    @NgayHetHanCCCD,
                    @ID_place,
                    @Address_Temporary,
                    @SoNhaThonXom + '-' + @PhuongXa + '-' + @QuanHuyen + '-' + @TinhThanhPho,
                    @NativePlace,
                    ISNULL(@Employee_Status, 'Incumbent'),
                    @StartedDate,
                    @ComStartedDate,
                    @Factory_ID,
                    @DepartmentCode,
                    @SectionCode,
                    @TeamCode,
                    @Position_ID,
                    @PositionCategory_ID,
                    @ChucDanh,
                    @JobCode,
                    @CongViecPhaiLam,
                    @Card_No,
                    @Card_Code,
                    @TypeOfHiring,
                    @BankName,
                    @BankCode,
                    @DebitAccount,
                    @Qualification,
                    @OfficialDate,
                    @Graduated,
                    @GraduatedFrom,
                    @TernimationDate,
                    @Tel,
                    @Email,
                    @MaSoThue,
                    @SoNgayPhepNam,
                    @ContractFlow,
                    @TonGiao,
                    @NguoiLienHeGap,
                    @Height,
                    @Weight,
                    @Hospital,
                    @HealthCheckFee,
                    @Remark,
                    @UserName,
                    GETDATE(),
                    @Picture,
                    @RFID,
                    @BirthDateFormat,
                    @TenChuHo,
                    @QuanHeVoiChuHo,
                    @isThuViec85PhanTram,
                    @NgayTGCongDoan,
                    @EndOfSeasonWorker,
                    @IsSeasonWorker,
                    @isManager,
                    @Camket,
                    @NguoiGT,
                    @Accountcode1,
                    @Accountcode2,
                    @Accountcode3,
                    @PicCam,
                    @CCCDCu,
                    @CCCDCu_Date,
                    @CCCDCu_Place,
                    @isTanTat,
                    @TanTat,
                    @ResonTerminated,
                    @SoNhaThonXom,
                    @PhuongXa,
                    @QuanHuyen,
                    @TinhThanhPho
                )
				Exec usp_InsertUpdateUser_Account null, @Hospital, @Employee_ID, @password, @Employee_ID, @FullName, 5, @NgayHienTai, @UserName, null, 5
			end
		end
	end
	select @ThongBao as ThongBao
END




GO
