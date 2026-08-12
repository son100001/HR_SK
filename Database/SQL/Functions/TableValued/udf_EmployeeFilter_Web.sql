CREATE   FUNCTION [dbo].[udf_EmployeeFilter_Web]
(
	-- Add the parameters for the function here
	--select * from udf_EmployeeFilter ('VN',null,null,null,null,null,null,'C16903',Getdate())

	@LAN nvarchar(50),
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Empl nvarchar(50)=null,
	@Date datetime
)
RETURNS  @rtnEmployeeFilter TABLE 
(
    -- columns returned by the function
	FactoryGroup nvarchar(200) null,
	[Employee_ID] [nvarchar](50) NOT NULL,
	[Employee_Firstname] [nvarchar](255) NULL,
	[Employee_LastName] [nvarchar](255) NULL,
	[ID_number] [nvarchar](50) NULL,
	[StartedDate] [Datetime],
	[ComStartedDate] [Datetime],
	[TernimationDate] [Datetime],
	[BirthPlace] [nvarchar](255) NULL,
	Gender [nvarchar](50) NULL,
	[BirthDate] [Datetime] NULL,
	[ID_date] [Datetime] NULL,
	[ID_place] [nvarchar](255) NULL,
	NgayHetHanCCCD datetime null,
	[Sex] [nvarchar](50) NULL,
	[MaritalStatus] [nvarchar](50) NULL,
	[Nationality] [nvarchar](50) NULL,
	[Nation] [nvarchar](50) NULL,
	[Address_Temporary] [nvarchar](255) NULL,
	Tinh_TP_TamTru nvarchar(100) null,
	Huyen_ThiXa_TamTru nvarchar(100) null,
	Xa_Phuong_TamTru nvarchar(100) null,
	[Address_Permanent] [nvarchar](255) NULL,
	Tinh_TP_ThuongTru nvarchar(100) null,
	Huyen_ThiXa_ThuongTru nvarchar(100) null,
	Xa_Phuong_ThuongTru nvarchar(100) null,
	[NativePlace] [nvarchar](255) NULL,
	Employee_Status [nvarchar](50) NULL,
	Factory_ID [nvarchar](50) NULL,
	DepartmentCode [nvarchar](200) NULL,
	SectionCode [nvarchar](200) NULL,
	TeamCode [nvarchar](200) NULL,
	position [nvarchar](255) NULL,
	EffectiveDateOfPosition [Datetime] NULL,
	[Position_ID] [nvarchar](200) NULL,
	EffectiveDateOfPos [Datetime] NULL,
	[PositionCategory_ID] [nvarchar](200) NULL,
	EffectiveDateOfPosC [Datetime] NULL,
	[ChucDanh] [nvarchar](200) NULL,
	EffectiveDateOfChucDanh [Datetime] NULL,
	[JobCode] [nvarchar](50) NULL,
	[Card_No] [nvarchar](50) NULL,
	[Card_Code] [nvarchar](50) NULL,
	[BankName] [nvarchar](255) NULL,
	[BankAccount] [nvarchar](50) NULL,
	[Tel] [nvarchar](50) NULL,
	BankCode [nvarchar](50) NULL,
	[DebitAccount] [nvarchar](50) NULL,
	[Qualification] [nvarchar](50) NULL,
	OfficialDate [Datetime] NULL,
	[Graduated] [nvarchar](50) NULL,
	[GraduatedFrom] [nvarchar](255) NULL,
	[Email] [nvarchar](50) NULL,
	[MaSoThue] [nvarchar](50) NULL,
	[SoNgayPhepNam] [Float] NULL,
	[ContractFlow] [nvarchar](50) NULL,
	[TonGiao] [nvarchar](50) NULL,
	[NguoiLienHeGap] [nvarchar](50) NULL,
	Height [float] NULL,
	[Weight] [float] NULL,
	Hospital [nvarchar](255) NULL,
	HealthCheckFee [float] NULL,
	[Remark] [nvarchar](max) NULL,
	[UserName] [nvarchar](50) NULL,
	[InsertDate] [Datetime] NULL,
	RFID [nvarchar](50) NULL,
	BirthDateFormat [nvarchar](50) NULL,
	AbsentStatus [nvarchar](50) NULL,
	NghiSinhTuNgay [Datetime] NULL,
	NgayDiLamLai [Datetime] NULL,
	TenChuHo [nvarchar](50) NULL,
	QuanHeVoiChuHo [nvarchar](50) NULL,
	isThuViec85PhanTram [bit] NULL,
	NgayTGCongDoan [Datetime] NULL,
	CVPL [nvarchar](max) NULL,
	TypeOfHiring [nvarchar](50) NULL,
	--HaveNoOT bit,
	isManager bit,
	isTanTat bit,
	Tantat nvarchar(100),
	CCCDCu nvarchar(50) null,
	CCCDCu_Date datetime null,
	CCCDCu_Place nvarchar(100) null,
	ResonTerminated1 nvarchar(200),
	Position_NameEN nvarchar(200) null,
	FactoryName [nvarchar](100) NULL,
	DepartmentName [nvarchar](200) NULL,
	SectionName [nvarchar](200) NULL,
	TeamName [nvarchar](200) NULL,
	PositionName [nvarchar](200) NULL,
	PositionCategoryName [nvarchar](200) NULL,
	ChucDanhName [nvarchar](200) NULL,
	HAZARD [varchar](50) NULL,
	Group_ nvarchar(50) null,
	PositionFullName [nvarchar](200) NULL,
	DiaChiLamViec [nvarchar](255) NULL,
	NgayNopDon [datetime] NULL,
	LyDoNghi [nvarchar](255) NULL,
	ThangTinhLuong [datetime] NULL,
	NgayBanGiao [datetime] NULL,
	NgayQuyetDinh [datetime] NULL,
	ResonTerminated nvarchar(200),
	DecisionStatus nvarchar(200),
	DecisionCode nvarchar(50),
	CongViecPhaiLam [nvarchar](max) NULL,
	NgayPhepNam [int] null,
	KhuVuc [nvarchar](max) null,
	isTrucTiep nvarchar(50) null,
	ChoPhepSoPhutMuon nvarchar(50) null,
	DepartmentCode1 nvarchar(200) null,
	DepartmentGroup nvarchar(200) null,
	SoSoBaoHiem nvarchar(50) null,
	LvDuyet nvarchar(5) null,
	primary key (Employee_ID)
)
AS
BEGIN
	Declare @NgayDauThang datetime = datefromparts(Year(@Date),Month(@Date),1)
	insert into @rtnEmployeeFilter
	select empl.DepartmentCode as FactoryGroup, 
	empl.*
	, pos.Position_NameEN
	,(case when @LAN='VN' then f.NameVN when @LAN='EN' then f.NameEN else f.NameKR end)as FactoryName
	,(case when @LAN='VN' then dept.DepartmentName_VN when @LAN='EN' then dept.DepartmentName_EN else dept.DepartmentName_KR end)as DepartmentName
	,(case when @LAN='VN' then sect.SectionName_VN when @LAN='EN' then sect.SectionName_EN else sect.SectionName_KR end)as SectionName
	,(case when @LAN='VN' then team.Description_VN when @LAN='EN' then team.Description_EN else team.Description_KR end)as TeamName
	,(case when @LAN='VN' then pos.Position_NameVN when @LAN='EN' then pos.Position_NameEN else pos.Position_NameKR end)as PositionName
	,(case when @LAN='VN' then posc.PositionCategory_NameVN when @LAN='EN' then posc.PositionCategory_NameEN else posc.PositionCategory_NameKR end)as PositionCategoryName
	,(case when @LAN='VN' then cd.NameVN when @LAN='EN' then cd.NameEN else cd.NameKR end)as ChucDanhName
	--,jcc.IE_FLAG,jcc.D_Code,(case when @LAN='VN' then cc.NameVN when @LAN='EN' then cc.NameEN else cc.NameKR end) as D_Code_Name,jcc.DutyCode,jcc.SkillType
	,hc.HAZARD, sect.Group_
	,p.[Name] as PositionFullName
	,f.DiaChi as DiaChiLamViec
	,ta.NgayNopDon
	,(case when @LAN='VN' then cate.NameVN when @LAN='EN' then cate.NameEN else cate.NameKR end) as LyDoNghi, ta.ThangTinhLuong,ta.ThangTinhLuong as NgayBanGiao
	,(Case when exists( select H_date from SmartBooks_HolidaysPlan where H_date = ta.PlanTernimationDate) then DATEADD(day, 1, ta.PlanTernimationDate) else ta.PlanTernimationDate end) as NgayQuyetDinh
	,isnull((case when @LAN='VN' then cate.NameVN when @LAN='EN' then cate.NameEN else cate.NameKR end),empl.ResonTerminated) as ResonTerminated, ta.DecisionStatus, ta.DecisionCode
	,ISNULL(jcc.NameVN, empl.CVPL) as CongViecPhaiLam
	, isnull(posc.AnnualLeaveDays,isnull(pos.AnnualLeaveDays,isnull(team.AnnualLeaveDays,isnull(sect.AnnualLeaveDays,isnull(dept.AnnualLeaveDays,isnull(f.AnnualLeaveDays,0)))))) as NgayPhepNam
	,f.Factory_ID as KhuVuc, cd.NameKR as isTrucTiep, dept.JobCode as ChoPhepSoPhutMuon, dept.DepartmentCode, dept.JobCode, ins.BookCode as SoSoBaoHiem
	,afjt.FlowCode AS LvDuyet
	from 
	(
		select empl.[Employee_ID],empl.[Employee_Firstname],empl.[Employee_LastName],empl.[ID_number],empl.[StartedDate],empl.[ComStartedDate],empl.[TernimationDate]
		,empl.[BirthPlace]
		,(case when empl.Sex='Male' then N'Nam' else N'Nữ' end) as Gender
		,empl.[BirthDate],empl.[ID_date]
		,empl.[ID_place], empl.NgayHetHanCCCD,empl.[Sex],empl.[MaritalStatus],empl.[Nationality],empl.[Nation]
		,empl.[Address_Temporary]
		,LTRIM(RTRIM(RIGHT(empl.Address_Temporary,
        CHARINDEX('-', REVERSE(empl.Address_Temporary) + '-') - 1))) AS Tinh_TP_TT,
		-- Huyện/Thị xã: phần giữa dấu '-' kế cuối và cuối
		LTRIM(RTRIM(RIGHT(LEFT(empl.Address_Temporary, LEN(empl.Address_Temporary) - CHARINDEX('-', REVERSE(empl.Address_Temporary) + '')), CHARINDEX('-', REVERSE(LEFT(empl.Address_Temporary, LEN(empl.Address_Temporary) - CHARINDEX('-', REVERSE(empl.Address_Temporary) + ''))) + '-') - 1))) AS Huyen_ThiXa_TT,
		-- Xã/Phường: phần giữa dấu '-' thứ 3 từ cuối và kế cuối
		LTRIM(RTRIM(RIGHT(LEFT(empl.Address_Temporary,LEN(empl.Address_Temporary) - CHARINDEX('-', REVERSE(empl.Address_Temporary) + '') - CHARINDEX('-', REVERSE(LEFT(empl.Address_Temporary, LEN(empl.Address_Temporary) - CHARINDEX('-', REVERSE(empl.Address_Temporary) + ''))) + '')),
			CHARINDEX('-', REVERSE(LEFT(empl.Address_Temporary,LEN(empl.Address_Temporary) - CHARINDEX('-', REVERSE(empl.Address_Temporary) + '') - CHARINDEX('-', REVERSE(LEFT(empl.Address_Temporary,LEN(empl.Address_Temporary) - CHARINDEX('-', REVERSE(empl.Address_Temporary) + ''))) + ''))) + '-') - 1))) AS Xa_Phuong_TT
		,empl.[Address_Permanent]
		,LTRIM(RTRIM(RIGHT(empl.Address_Permanent,CHARINDEX('-', REVERSE(empl.Address_Permanent) + '-') - 1))) AS Tinh_TP,
		-- Huyện/Thị xã: phần giữa dấu '-' kế cuối và cuối
		LTRIM(RTRIM(RIGHT(LEFT(empl.Address_Permanent,LEN(empl.Address_Permanent) - CHARINDEX('-', REVERSE(empl.Address_Permanent) + '')),CHARINDEX('-', REVERSE(LEFT(empl.Address_Permanent,LEN(empl.Address_Permanent) - CHARINDEX('-', REVERSE(empl.Address_Permanent) + ''))) + '-') - 1))) AS Huyen_ThiXa,
		-- Xã/Phường: phần giữa dấu '-' thứ 3 từ cuối và kế cuối
		LTRIM(RTRIM(RIGHT(LEFT(empl.Address_Permanent,LEN(empl.Address_Permanent) - CHARINDEX('-', REVERSE(empl.Address_Permanent) + '') - CHARINDEX('-', REVERSE(LEFT(empl.Address_Permanent,LEN(empl.Address_Permanent) - CHARINDEX('-', REVERSE(empl.Address_Permanent) + ''))) + '')),
			CHARINDEX('-', REVERSE(LEFT(empl.Address_Permanent,LEN(empl.Address_Permanent) - CHARINDEX('-', REVERSE(empl.Address_Permanent) + '') - CHARINDEX('-', REVERSE(LEFT(empl.Address_Permanent,LEN(empl.Address_Permanent) - CHARINDEX('-', REVERSE(empl.Address_Permanent) + ''))) + ''))) + '-') - 1))) AS Xa_Phuong
		,empl.[NativePlace],empl.Employee_Status
		,isnull(tf.Factory_ID, empl.Factory_ID) as Factory_ID
		,isnull(tf.DepartmentCode, empl.DepartmentCode) as DepartmentCode
		,tf.SectionCode
		,tf.TeamCode
		,isnull(tf.position, empl.DepartmentCode) as Position
		,tfEffectiveDate.EffectiveDateOfPosition
		,isnull(tf.[Position_ID],empl.[Position_ID]) as [Position_ID]
		,tfEffectiveDate.EffectiveDateOfPos
		,isnull(tf.[ChucDanh],isnull(empl.ChucDanh,isnull(tf.[PositionCategory_ID],empl.[PositionCategory_ID]))) as [PositionCategory_ID]
		,tfEffectiveDate.EffectiveDateOfPosC
		,isnull(tf.[ChucDanh],empl.[ChucDanh]) as [ChucDanh]
		,tfEffectiveDate.EffectiveDateOfChucDanh
		,tf.[JobCode]
		,empl.[Card_No],empl.[Card_Code],boe.[BankName],boe.[BankAccount],empl.[Tel],empl.BankCode,empl.[DebitAccount],empl.[Qualification]
		,isnull(empl.OfficialDate,hdct.NgayKyHDChinhThuc) as OfficialDate
		,empl.[Graduated],empl.[GraduatedFrom],empl.[Email],empl.[MaSoThue],empl.[SoNgayPhepNam],empl.[ContractFlow],empl.[TonGiao],empl.[NguoiLienHeGap],empl.Height,empl.[Weight],empl.Hospital,empl.HealthCheckFee,empl.[Remark],empl.[UserName],empl.[InsertDate]
		,isnull(tf.RFID,empl.RFID) as RFID
		,isnull(empl.BirthDateFormat,'dd/MM/yyyy') as BirthDateFormat
		,(case when @LAN='VN' then lt.LeaveType_VN when @LAN='EN' then lt.LeaveType_EN else lt.LeaveType_KR end) as AbsentStatus
		,(case when lt.LeaveType_ID='24' then erml.Fromdate else null end) as NghiSinhTuNgay
		,(case when lt.LeaveType_ID='24' then erml.ToDate+1 else null end) as NgayDiLamLai
		,empl.TenChuHo,empl.QuanHeVoiChuHo
		,empl.isThuViec85PhanTram,empl.NgayTGCongDoan
		,empl.[CongViecPhaiLam] as CVPL
		,empl.TypeOfHiring, empl.isManager, empl.isTanTat, empl.Tantat, empl.CCCDCu, empl.CCCDCu_Date, empl.CCCDCu_Place
		,empl.ResonTerminated
		from
		SmartBooks_Employee empl
		left join
		(select *,
			(case when len(position)-len(REPLACE(position,'_',''))=0 then position else LEFT(position, CHARINDEX('_', position)-1) end) as Factory_ID
			,(CASE 
					WHEN len(position)-len(REPLACE(position,'_','')) = 0 THEN NULL 
					WHEN len(position)-len(REPLACE(position,'_','')) = 1 THEN LEFT(position, CHARINDEX('_',position)) + isnull(Position_ID,'') 
					ELSE LEFT(position, CHARINDEX('_', position, CHARINDEX('_', position) + 1) - 1) 
				END) AS DepartmentCode
			,(case when len(position)-len(REPLACE(position,'_',''))<=1 then LEFT(position, CHARINDEX('_',position)) + Position_ID + '_' + RIGHT(position, LEN(position) - CHARINDEX('_', position)) when len(position)-len(REPLACE(position,'_',''))=2 then position else LEFT(position, CHARINDEX('_',position,CHARINDEX('_',position,CHARINDEX('_',position,CHARINDEX('_', position)+1))+1)-1) end) as SectionCode
			,(case when len(position)-len(REPLACE(position,'_',''))<=2 then null else position end) as TeamCode
		 from udf_TraVeBangTransfer_Horizontal(@Date,@Empl)) tf
		on empl.Employee_ID=tf.Employee_ID
		left join
		[dbo].[udf_TraVeBangEffectiveDateInTransfer_Horizontal](@Date,@Empl) tfEffectiveDate
		on empl.Employee_ID=tfEffectiveDate.Employee_ID 
		left join
		HR_EmployeeRegisMaternityLeave erml
		on empl.Employee_ID=erml.Employee_ID and convert(varchar, getdate(), 23) between erml.fromdate and erml.ToDate
		left join
		smartbooks_leavetype lt
		on erml.LeaveType_ID=lt.LeaveType_ID
		left join
		udf_NgayKyHDChinhThuc('1990-1-1','2990-1-1',null) hdct
		on empl.Employee_ID=hdct.Employee_ID
		left join
		HR_BankAccountOfEmployee boe
		on empl.Employee_ID=boe.Employee_ID and boe.isUsing=1
	)empl
	left join
	HR_TerminationAsignment ta
	on empl.Employee_ID=ta.Employee_ID and empl.TernimationDate=ta.[PlanTernimationDate]
	left join
	HR_Category cate
	on ta.ResonTerminated = cate.Category and CategoryFather = 'resigned'
	left join
	HR_Factory f
	on empl.Factory_ID=f.Factory_ID
	left join
	SmartBooks_Department dept
	on empl.DepartmentCode=dept.Factory_ID+'_'+dept.DepartmentCode
	left join
	SmartBooks_Section sect
	on empl.SectionCode=sect.Factory_ID+'_'+sect.DepartmentCode+'_'+sect.SectionCode
	--on empl.SectionCode=sect.Factory_ID/*+'_'+sect.DepartmentCode*/+'_'+sect.SectionCode
	left join
	SmartBooks_Team team
	on empl.TeamCode=team.Factory_ID+'_'+team.DepartmentCode+'_'+team.SectionCode+'_'+team.TeamCode
	left join
	SmartBooks_Position pos
	on empl.Position_ID=pos.Position_ID
	left join
	SmartBooks_PositionCategory posc
	on empl.PositionCategory_ID=posc.PositionCategory_ID
	left join
	HR_JobCodeCategory jcc
	on isnull(empl.JobCode,ISNULL(team.JobCode,isnull(sect.JobCode,isnull(dept.JobCode,isnull(f.JobCode,null)))))=jcc.JobCode
	left join
	[dbo].[HR_HazardCategory] hc
	on jcc.Hazard=hc.HAZARD
	--left join
	--HR_Category cc
	--on jcc.D_Code=cc.Category and cc.CategoryFather='D_CODE'
	left join
	udf_Position(@LAN,0) p
	on empl.Position=p.Code
	left join
	HR_ChucDanh cd
	on empl.ChucDanh=cd.ChucDanh
	left join
	HR_Insurance ins
	on empl.Employee_ID = ins.Employee_ID
	left join HR_ApprovalFlowJobTitle afjt
		on afjt.ChucDanh = empl.ChucDanh
		and afjt.IsActive = 1
		and NULLIF(LTRIM(RTRIM(empl.ChucDanh)), N'') IS NOT NULL
	--left join
	--[user] u
	--on isnull(u.QuyenTruyXuat,'')<>'' and u.UserName=@UserName
	where
	 (case when @fact is null or @fact='' then '' else empl.Factory_ID end) in (select data from [dbo].[Split](case when @fact is null or @fact='' then '' else @fact end,','))
			and (case when @dept is null or @dept='' then '' else empl.DepartmentCode end)=(case when @dept is null or @dept='' then '' else @dept end)
			and (case when @sect is null or @sect='' then '' else empl.SectionCode end)=(case when @sect is null or @sect='' then '' else @sect end)
			and (case when @team is null or @team='' then '' else empl.TeamCode end)=(case when @team is null or @team='' then '' else @team end)
			and (case when @pos is null or @pos='' then '' else empl.Position_ID end)=(case when @pos is null or @pos='' then '' else @pos end)
			and (case when @posc is null or @posc='' then '' else empl.PositionCategory_ID end)=(case when @posc is null or @posc='' then '' else @posc end)
			and (
					(case when @Empl is null or @Empl='' then '' else empl.Employee_ID end)=(case when @Empl is null or @Empl='' then '' else @Empl end)
					or
					(case when @Empl is null or @Empl='' then '' else empl.ID_number end)=(case when @Empl is null or @Empl='' then '' else @Empl end)
				)
				and (empl.TernimationDate is null or empl.TernimationDate >= dateadd(month,-2,@NgayDauThang))
	-- Return the result of the function
	RETURN 

END




GO
