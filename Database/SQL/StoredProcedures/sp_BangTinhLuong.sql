CREATE PROCEDURE [dbo].[sp_BangTinhLuong]
	-- Add the parameters for the stored procedure here
	--exec [dbo].[sp_BangTinhLuong] 7,2025,2,'VN','ADMIN',null,null,null,null,null,null,'MonthlySalary',''
	@Month INT,
	@Year int,
	@TypeOfReport int=1,--1:danh sách lương;2:Phiếu lương; 5: Văn phòng; 6: Công nhân
	@LAN nvarchar(50)='VN',
	@UserName nvarchar(50) null,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@SalaryKey varchar(50)=null,
	@ListOfID varchar(max)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @NgayTraLuong datetime,@NgayDauThang datetime,@NgayCuoiThang datetime,@TrangThaiKH bit,@tygia float, @NgayDauThangTruoc datetime
	set @NgayDauThang=datefromparts(@Year,@month,1)
	set @NgayCuoiThang= dateadd(day,-1,dateadd(month,1,@NgayDauThang))
	set @NgayDauThangTruoc = dateadd(month,-1,@NgayDauThang)
	select @tygia=Value from HR_SetUpFollowDate where Fromdate<=@NgayCuoiThang and (Todate is null or todate>=@NgayCuoiThang) order by Fromdate asc
	select top 1 @NgayTraLuong=PayDate from SmartBooks_Salary where Salary_Month=@Month and Salary_Year=@Year and (case when @SalaryKey is null or @SalaryKey='' then '' else [key] end)=(case when @SalaryKey is null or @SalaryKey='' then '' else @SalaryKey end)
	
	Declare @ActualWorkingDay int, @PublicHoliday int, @SummerHoliday int, @WorkingSaturday int, @CalculateSalaryWorkingDay int, @SaturdayOT int, @SundayOT int
	Select @PublicHoliday = dbo.udf_CountHoliday(@NgayDauThang,@NgayCuoiThang)
	--@SummerHoliday
	Select @WorkingSaturday =  [dbo].[udf_CountSaturDayWorking] (@NgayDauThang,@NgayCuoiThang)
	select @SaturdayOT = dbo.[udf_CountSaturDayLeave] (@NgayDauThang,@NgayCuoiThang)
	Select @ActualWorkingDay = dbo.udf_CountWorkingDay(@NgayDauThang,@NgayCuoiThang) - @WorkingSaturday
	
	set @TrangThaiKH=[dbo].[udf_TrangThaiKH](@UserName)
	if @TrangThaiKH=1 begin
		set @SalaryKey=@SalaryKey+'_TachCong'
	end
	if @TypeOfReport=1 begin
		select
		s.trangthai,sect.group_ as sectionGroup,p.Name as ShortPositionName,empl.departmentName,empl.PositionCategory_ID,empl.Position_ID, empl.PositionName, empl.SectionName, @NgayCuoiThang as NgayCuoiThang
					,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
					,empl.StartedDate,empl.BirthDate,empl.BankAccount,s.*
					
		from
		SmartBooks_Salary s
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,isnull(@NgayTraLuong,getdate())) empl
		on s.Employee_ID=empl.Employee_ID
		left join
		SmartBooks_Section sect
		on empl.SectionCode=sect.Factory_ID+'_'+sect.DepartmentCode+'_'+sect.SectionCode
		left join
		[dbo].[udf_Position]('VN',0) p
		on empl.position=p.Code
		where (case when @SalaryKey='ThuongThang13' then 1 else Salary_Month end) = (case when @SalaryKey='ThuongThang13' then 1 else @Month end)
				and Salary_Year = (case when @SalaryKey='ThuongThang13' then @year+1 else @year end)
				and (case when @SalaryKey is null or @SalaryKey='' then '' else [key] end)=(case when @SalaryKey is null or @SalaryKey='' then '' else @SalaryKey end)
				and empl.Employee_ID is not null and s.Employee_ID is not null
		order by sect.group_, p.Name, empl.Employee_ID
	end 
	
	
	ELSE if @TypeOfReport=2 begin
		select
			empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName,empl.PositionCategory_ID,empl.FactoryName,empl.DepartmentName,empl.Position_ID, empl.SectionName, empl.TeamName, empl.PositionName, empl.PositionCategoryName, @NgayCuoiThang as NgayCuoiThang
					,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Factory_ID
					,empl.StartedDate,empl.BirthDate,empl.BankAccount,s.*,N'PHIẾU LƯƠNG THÁNG '+cast(s.Salary_Month as varchar)+'-'+cast(s.Salary_Year as varchar) as TieuDePhieLuong
			 
		from
		SmartBooks_Salary s
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,isnull(@NgayTraLuong,getdate())) empl
		on s.Employee_ID=empl.Employee_ID
		left join
		SmartBooks_Section sect
		on empl.SectionCode=sect.Factory_ID+'_'+sect.DepartmentCode+'_'+sect.SectionCode
		where (case when @SalaryKey='ThuongThang13' then 1 else Salary_Month end) = (case when @SalaryKey='ThuongThang13' then 1 else @Month end)
				and Salary_Year = (case when @SalaryKey='ThuongThang13' then @year+1 else @year end)
				and (case when @SalaryKey is null or @SalaryKey='' then '' else [key] end)=(case when @SalaryKey is null or @SalaryKey='' then '' else @SalaryKey end)
				and empl.Employee_ID is not null
				and isnull(empl.TernimationDate,'3099-1-1') > GETDATE()
				and (empl.TernimationDate is null or empl.TernimationDate>@NgayCuoiThang)
				and ((isnull(@ListOfID,'') <> '' and empl.Employee_ID in (select Data from Split(@ListOfID,','))) or ISNULL(@ListOfID,'')='')
		order by empl.SectionName
	
	END
	
	
	ELSE if @TypeOfReport=3 begin--Quyet toan PIT
		select empl.PositionFullName,empl.sectionName,ID_Number
			,empl.Employee_id,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.MaSoThue
			,qtpit.TongTNChiuThue
			,qtpit.PITDaKhauTru
			,qtpit.BHBatBuoc
			,qtpit.DependentPerson
			,qtpit.GiamTruCaNhan
		from
		udf_QuyetToanPITTheoThang(@month,@year) qtpit
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,isnull(@NgayTraLuong,getdate())) empl
		on qtpit.Employee_ID=empl.Employee_ID
		where empl.Employee_ID is not null
	end else if @TypeOfReport=4 begin
		select sNB.Employee_ID
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		,empl.SectionName,empl.StartedDate
		,sNB.s1,sNB.s2,sNB.s3,sNB.s4,sNB.s5,sNB.s6,sNB.s7,sNB.s8,sNB.s9,sNB.s10,sNB.s11,sNB.s12,sNB.s13,isnull(sNB.s14,0)-isnull(sKH.s14,0) as s14,isnull(sNB.s15,0)-isnull(sKH.s15,0) as s15,isnull(sNB.s16,0)-isnull(sKH.s16,0) as s16,isnull(sNB.s17,0)-isnull(sKH.s17,0) as s17,isnull(sNB.s18,0)-isnull(sKH.s18,0) as s18,isnull(sNB.s19,0)-isnull(sKH.s19,0) as s19,isnull(sNB.s20,0)-isnull(sKH.s20,0) as s20,isnull(sNB.s21,0)-isnull(sKH.s21,0) as s21,isnull(sNB.s22,0)-isnull(sKH.s22,0) as s22,isnull(sNB.s23,0)-isnull(sKH.s23,0) as s23,isnull(sNB.s24,0)-isnull(sKH.s24,0) as s24,isnull(sNB.s25,0)-isnull(sKH.s25,0) as s25,isnull(sNB.s26,0)-isnull(sKH.s26,0) as s26,isnull(sNB.s27,0)-isnull(sKH.s27,0) as s27,isnull(sNB.s28,0)-isnull(sKH.s28,0) as s28,isnull(sNB.s29,0)-isnull(sKH.s29,0) as s29,isnull(sNB.s30,0)-isnull(sKH.s30,0) as s30,isnull(sNB.s31,0)-isnull(sKH.s31,0) as s31,isnull(sNB.s32,0)-isnull(sKH.s32,0) as s32,isnull(sNB.s33,0)-isnull(sKH.s33,0) as s33,isnull(sNB.s34,0)-isnull(sKH.s34,0) as s34,isnull(sNB.s35,0)-isnull(sKH.s35,0) as s35,isnull(sNB.s36,0)-isnull(sKH.s36,0) as s36,isnull(sNB.s37,0)-isnull(sKH.s37,0) as s37,isnull(sNB.s38,0)-isnull(sKH.s38,0) as s38,isnull(sNB.s39,0)-isnull(sKH.s39,0) as s39,isnull(sNB.s40,0)-isnull(sKH.s40,0) as s40,isnull(sNB.s41,0)-isnull(sKH.s41,0) as s41,isnull(sNB.s42,0)-isnull(sKH.s42,0) as s42,isnull(sNB.s43,0)-isnull(sKH.s43,0) as s43,isnull(sNB.s44,0)-isnull(sKH.s44,0) as s44,isnull(sNB.s45,0)-isnull(sKH.s45,0) as s45,isnull(sNB.s46,0)-isnull(sKH.s46,0) as s46,isnull(sNB.s47,0)-isnull(sKH.s47,0) as s47,isnull(sNB.s48,0)-isnull(sKH.s48,0) as s48,isnull(sNB.s49,0)-isnull(sKH.s49,0) as s49,isnull(sNB.s50,0)-isnull(sKH.s50,0) as s50,isnull(sNB.s51,0)-isnull(sKH.s51,0) as s51,isnull(sNB.s52,0)-isnull(sKH.s52,0) as s52,isnull(sNB.s53,0)-isnull(sKH.s53,0) as s53,isnull(sNB.s54,0)-isnull(sKH.s54,0) as s54,isnull(sNB.s55,0)-isnull(sKH.s55,0) as s55,isnull(sNB.s56,0)-isnull(sKH.s56,0) as s56,isnull(sNB.s57,0)-isnull(sKH.s57,0) as s57,isnull(sNB.s58,0)-isnull(sKH.s58,0) as s58,isnull(sNB.s59,0)-isnull(sKH.s59,0) as s59,isnull(sNB.s60,0)-isnull(sKH.s60,0) as s60,isnull(sNB.s61,0)-isnull(sKH.s61,0) as s61,isnull(sNB.s62,0)-isnull(sKH.s62,0) as s62,isnull(sNB.s63,0)-isnull(sKH.s63,0) as s63,isnull(sNB.s64,0)-isnull(sKH.s64,0) as s64,isnull(sNB.s65,0)-isnull(sKH.s65,0) as s65,isnull(sNB.s66,0)-isnull(sKH.s66,0) as s66,isnull(sNB.s67,0)-isnull(sKH.s67,0) as s67,isnull(sNB.s68,0)-isnull(sKH.s68,0) as s68,isnull(sNB.s69,0)-isnull(sKH.s69,0) as s69,isnull(sNB.s70,0)-isnull(sKH.s70,0) as s70,isnull(sNB.s71,0)-isnull(sKH.s71,0) as s71,isnull(sNB.s72,0)-isnull(sKH.s72,0) as s72,isnull(sNB.s73,0)-isnull(sKH.s73,0) as s73,isnull(sNB.s74,0)-isnull(sKH.s74,0) as s74,isnull(sNB.s75,0)-isnull(sKH.s75,0) as s75,isnull(sNB.s76,0)-isnull(sKH.s76,0) as s76,isnull(sNB.s77,0)-isnull(sKH.s77,0) as s77,isnull(sNB.s78,0)-isnull(sKH.s78,0) as s78,isnull(sNB.s79,0)-isnull(sKH.s79,0) as s79,isnull(sNB.s80,0)-isnull(sKH.s80,0) as s80,isnull(sNB.s81,0)-isnull(sKH.s81,0) as s81,isnull(sNB.s82,0)-isnull(sKH.s82,0) as s82,isnull(sNB.s83,0)-isnull(sKH.s83,0) as s83,isnull(sNB.s84,0)-isnull(sKH.s84,0) as s84,isnull(sNB.s85,0)-isnull(sKH.s85,0) as s85,isnull(sNB.s86,0)-isnull(sKH.s86,0) as s86,isnull(sNB.s87,0)-isnull(sKH.s87,0) as s87,isnull(sNB.s88,0)-isnull(sKH.s88,0) as s88,isnull(sNB.s89,0)-isnull(sKH.s89,0) as s89,isnull(sNB.s90,0)-isnull(sKH.s90,0) as s90,isnull(sNB.s91,0)-isnull(sKH.s91,0) as s91,isnull(sNB.s92,0)-isnull(sKH.s92,0) as s92,isnull(sNB.s93,0)-isnull(sKH.s93,0) as s93,isnull(sNB.s94,0)-isnull(sKH.s94,0) as s94,isnull(sNB.s95,0)-isnull(sKH.s95,0) as s95,isnull(sNB.s96,0)-isnull(sKH.s96,0) as s96,isnull(sNB.s97,0)-isnull(sKH.s97,0) as s97,isnull(sNB.s98,0)-isnull(sKH.s98,0) as s98,isnull(sNB.s99,0)-isnull(sKH.s99,0) as s99,isnull(sNB.s100,0)-isnull(sKH.s100,0) as s100,isnull(sNB.s101,0)-isnull(sKH.s101,0) as s101,isnull(sNB.s102,0)-isnull(sKH.s102,0) as s102,isnull(sNB.s103,0)-isnull(sKH.s103,0) as s103,isnull(sNB.s104,0)-isnull(sKH.s104,0) as s104,isnull(sNB.s105,0)-isnull(sKH.s105,0) as s105,isnull(sNB.s106,0)-isnull(sKH.s106,0) as s106,isnull(sNB.s107,0)-isnull(sKH.s107,0) as s107,isnull(sNB.s108,0)-isnull(sKH.s108,0) as s108,isnull(sNB.s109,0)-isnull(sKH.s109,0) as s109,isnull(sNB.s110,0)-isnull(sKH.s110,0) as s110,isnull(sNB.s111,0)-isnull(sKH.s111,0) as s111,isnull(sNB.s112,0)-isnull(sKH.s112,0) as s112,isnull(sNB.s113,0)-isnull(sKH.s113,0) as s113,isnull(sNB.s114,0)-isnull(sKH.s114,0) as s114,isnull(sNB.s115,0)-isnull(sKH.s115,0) as s115,isnull(sNB.s116,0)-isnull(sKH.s116,0) as s116,isnull(sNB.s117,0)-isnull(sKH.s117,0) as s117,isnull(sNB.s118,0)-isnull(sKH.s118,0) as s118,isnull(sNB.s119,0)-isnull(sKH.s119,0) as s119,isnull(sNB.s120,0)-isnull(sKH.s120,0) as s120,isnull(sNB.s121,0)-isnull(sKH.s121,0) as s121,isnull(sNB.s122,0)-isnull(sKH.s122,0) as s122,isnull(sNB.s123,0)-isnull(sKH.s123,0) as s123,isnull(sNB.s124,0)-isnull(sKH.s124,0) as s124,isnull(sNB.s125,0)-isnull(sKH.s125,0) as s125,isnull(sNB.s126,0)-isnull(sKH.s126,0) as s126,isnull(sNB.s127,0)-isnull(sKH.s127,0) as s127,isnull(sNB.s128,0)-isnull(sKH.s128,0) as s128,isnull(sNB.s129,0)-isnull(sKH.s129,0) as s129,isnull(sNB.s130,0)-isnull(sKH.s130,0) as s130,isnull(sNB.s131,0)-isnull(sKH.s131,0) as s131,isnull(sNB.s132,0)-isnull(sKH.s132,0) as s132,isnull(sNB.s133,0)-isnull(sKH.s133,0) as s133,isnull(sNB.s134,0)-isnull(sKH.s134,0) as s134,isnull(sNB.s135,0)-isnull(sKH.s135,0) as s135,isnull(sNB.s136,0)-isnull(sKH.s136,0) as s136,isnull(sNB.s137,0)-isnull(sKH.s137,0) as s137,isnull(sNB.s138,0)-isnull(sKH.s138,0) as s138,isnull(sNB.s139,0)-isnull(sKH.s139,0) as s139,isnull(sNB.s140,0)-isnull(sKH.s140,0) as s140,isnull(sNB.s141,0)-isnull(sKH.s141,0) as s141,isnull(sNB.s142,0)-isnull(sKH.s142,0) as s142,isnull(sNB.s143,0)-isnull(sKH.s143,0) as s143,isnull(sNB.s144,0)-isnull(sKH.s144,0) as s144,isnull(sNB.s145,0)-isnull(sKH.s145,0) as s145,isnull(sNB.s146,0)-isnull(sKH.s146,0) as s146,isnull(sNB.s147,0)-isnull(sKH.s147,0) as s147,isnull(sNB.s148,0)-isnull(sKH.s148,0) as s148,isnull(sNB.s149,0)-isnull(sKH.s149,0) as s149,isnull(sNB.s150,0)-isnull(sKH.s150,0) as s150,isnull(sNB.s151,0)-isnull(sKH.s151,0) as s151,isnull(sNB.s152,0)-isnull(sKH.s152,0) as s152,isnull(sNB.s153,0)-isnull(sKH.s153,0) as s153,isnull(sNB.s154,0)-isnull(sKH.s154,0) as s154,isnull(sNB.s155,0)-isnull(sKH.s155,0) as s155,isnull(sNB.s156,0)-isnull(sKH.s156,0) as s156,isnull(sNB.s157,0)-isnull(sKH.s157,0) as s157,isnull(sNB.s158,0)-isnull(sKH.s158,0) as s158,isnull(sNB.s159,0)-isnull(sKH.s159,0) as s159,isnull(sNB.s160,0)-isnull(sKH.s160,0) as s160,isnull(sNB.s161,0)-isnull(sKH.s161,0) as s161,isnull(sNB.s162,0)-isnull(sKH.s162,0) as s162,isnull(sNB.s163,0)-isnull(sKH.s163,0) as s163,isnull(sNB.s164,0)-isnull(sKH.s164,0) as s164,isnull(sNB.s165,0)-isnull(sKH.s165,0) as s165,isnull(sNB.s166,0)-isnull(sKH.s166,0) as s166,isnull(sNB.s167,0)-isnull(sKH.s167,0) as s167,isnull(sNB.s168,0)-isnull(sKH.s168,0) as s168,isnull(sNB.s169,0)-isnull(sKH.s169,0) as s169,isnull(sNB.s170,0)-isnull(sKH.s170,0) as s170
		from 
		SmartBooks_Salary sNB
		left join
		SmartBooks_Salary sKH
		on sNB.Employee_ID=sKH.Employee_ID and sNB.Salary_Month=sKH.Salary_Month and sNB.Salary_Year=sKH.Salary_Year and sKH.[key]=replace(@SalaryKey,'_TachCong','')+'_TachCong'
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,isnull(@NgayTraLuong,getdate())) empl
		on sNB.Employee_ID=empl.Employee_ID
		left join
		SmartBooks_Section sect
		on empl.SectionCode=sect.Factory_ID+'_'+sect.DepartmentCode+'_'+sect.SectionCode

		where sNB.Salary_Month=@Month and sNB.Salary_Year=@Year and sNB.[key]=replace(@SalaryKey,'_TachCong','')
			and sNB.S68>sKH.S68
			and empl.Employee_ID is not null
		order by sect.OrderBy, empl.Employee_ID
	end else if @TypeOfReport=5 begin
		select
		s.trangthai,empl.PositionFullName,empl.PositionName, empl.SectionName
					,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
					,empl.StartedDate,empl.BirthDate,empl.BankAccount,s.*
		,isnull(pn.PhepNamDuocHuongDenHienTai,0)+isnull(pn.PhepNamTon,0)-isnull(pn.TongPhepNamDaNghi,0) as PNConLai
		from
		SmartBooks_Salary s
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,isnull(@NgayTraLuong,getdate())) empl
		on s.Employee_ID=empl.Employee_ID
		left join
		SmartBooks_Section sect
		on empl.SectionCode=sect.Factory_ID+'_'+sect.DepartmentCode+'_'+sect.SectionCode
		left join
		[dbo].[udf_QuanLyPhepNam](@year,@NgayCuoiThang,'VN',@fact,@dept,@sect,@team,@pos,@posc,null) pn
		on empl.Employee_ID=pn.Employee_ID
		where (case when @SalaryKey='ThuongThang13' then 1 else Salary_Month end) = (case when @SalaryKey='ThuongThang13' then 1 else @Month end)
				and Salary_Year = (case when @SalaryKey='ThuongThang13' then @year+1 else @year end)
				and (case when @SalaryKey is null or @SalaryKey='' then '' else [key] end)=(case when @SalaryKey is null or @SalaryKey='' then '' else @SalaryKey end)
				and empl.Employee_ID is not null
				--and empl.Factory_ID = 'OFFICE'
		order by sect.OrderBy, empl.Employee_ID
	end else if @TypeOfReport=10 begin
		select sd.ID,sd.[Key],sd.Salary_Year,sd.Salary_Month,sd.PayDate,empl.SectionName,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,s70 as TongChiPhi
		from SmartBooks_Salary_Daily sd
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,isnull(@NgayTraLuong,getdate())) empl
		on sd.Employee_ID=empl.Employee_ID
		where sd.Salary_Month=@Month and sd.Salary_Year=@Year
	end else if @TypeOfReport=11 begin
		select
			empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName,empl.PositionCategory_ID,empl.FactoryName,empl.DepartmentName,empl.Position_ID, empl.SectionName, empl.TeamName, empl.PositionName, empl.PositionCategoryName, @NgayCuoiThang as NgayCuoiThang
					,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Factory_ID
					,empl.StartedDate,empl.BirthDate,empl.BankAccount,s.*,N'PHIẾU LƯƠNG THÁNG '+cast(s.Salary_Month as varchar)+'-'+cast(s.Salary_Year as varchar) as TieuDePhieLuong
			 
		from
		SmartBooks_Salary s
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,isnull(@NgayTraLuong,getdate())) empl
		on s.Employee_ID=empl.Employee_ID
		left join
		SmartBooks_Section sect
		on empl.SectionCode=sect.Factory_ID+'_'+sect.DepartmentCode+'_'+sect.SectionCode
		where (case when @SalaryKey='ThuongThang13' then 1 else Salary_Month end) = (case when @SalaryKey='ThuongThang13' then 1 else @Month end)
				and Salary_Year = (case when @SalaryKey='ThuongThang13' then @year+1 else @year end)
				and (case when @SalaryKey is null or @SalaryKey='' then '' else [key] end)=(case when @SalaryKey is null or @SalaryKey='' then '' else @SalaryKey end)
				and empl.Employee_ID is not null
				and isnull(empl.TernimationDate,'3099-1-1') > GETDATE()
				and (empl.TernimationDate is null or empl.TernimationDate>@NgayCuoiThang)
				--and isnull(empl.TernimationDate,'3099-1-1') > GETDATE()
				and empl.Employee_ID in (select Data from Split(@ListOfID,','))
		order by empl.SectionName
	end else if @TypeOfReport=12 begin --Báo cáo tổng hợp lương theo bộ phận, 1. Direct, 2. Indirect, 3. Admin
		--exec sp_BangTinhLuong 1,2023,12,'VN','admin',null,null,null,null,null,null,'MonthlySalary'
		select cd.NameEN, cd.NameKR
			, thla.MaCongViec as MaCongViecAll, thla.GroupbyChucDanh as GroupbyChucDanhAll, thla.SoLuongNV as SoLuongNVAll, thla.BasicSalary as BasicSalaryAll, thla.PhuCap as PhuCapAll, thla.TienTangCa as TienTangCaAll, thla.Luong1Gio as Luong1GioAll, thla.GioLamViecKhongCoNghi as GioLamViecKhongCoNghiAll
			, thla.GioTangCa150 as GioTangCa150All, thla.GioTangCaCN200 as GioTangCaCN200All, thla.GioTangCaDem210 as GioTangCaDem210All, thla.GioTangCaDemCN270 as GioTangCaDemCN270All, thla.GioTangCaLe300 as GioTangCaLe300All, thla.GioTangCaDemLe390 as GioTangCaDemLe390All, thla.TongTangCa as TongTangCaAll, thla.TongTangCaVaHCDaChuyen as TongTangCaVaHCDaChuyenAll, thla.GioLamDem130 as GioLamDem130All, thla.TienCaDem130 as TienCaDem130All, thla.TongLuong as TongLuongAll
			, thla.CongDoanCtyTra as CongDoanCtyTraAll, thla.BHCtyTra as BHCtyTraAll, thla.TongChiPhi as TongChiPhiAll, thla.BHNVDong as BHNVDongAll, thla.TTCN as TTCNAll, thla.CongDoanNVDong as CongDoanNVDongAll, thla.TroCapConNho as TroCapConNhoAll, thla.TroCapPhuNu as TroCapPhuNuAll, thla.HoTroKhac as HoTroKhacAll, thla.ThucNhan as ThucNhanAll, thla.LuongChoViec as LuongChoViecAll

			, thlD1.MaCongViec as MaCongViecD1, thlD1.GroupbyChucDanh as GroupbyChucDanhD1, thlD1.SoLuongNV as SoLuongNVD1, thlD1.BasicSalary as BasicSalaryD1, thlD1.PhuCap as PhuCapD1, thlD1.TienTangCa as TienTangCaD1, thlD1.Luong1Gio as Luong1GioD1, thlD1.GioLamViecKhongCoNghi as GioLamViecKhongCoNghiD1
			, thlD1.GioTangCa150 as GioTangCa150D1, thlD1.GioTangCaCN200 as GioTangCaCN200D1, thlD1.GioTangCaDem210 as GioTangCaDem210D1, thlD1.GioTangCaDemCN270 as GioTangCaDemCN270D1, thlD1.GioTangCaLe300 as GioTangCaLe300D1, thlD1.GioTangCaDemLe390 as GioTangCaDemLe390D1, thlD1.TongTangCa as TongTangCaD1, thlD1.TongTangCaVaHCDaChuyen as TongTangCaVaHCDaChuyenD1, thlD1.GioLamDem130 as GioLamDem130D1, thlD1.TienCaDem130 as TienCaDem130D1, thlD1.TongLuong as TongLuongD1
			, thlD1.CongDoanCtyTra as CongDoanCtyTraD1, thlD1.BHCtyTra as BHCtyTraD1, thlD1.TongChiPhi as TongChiPhiD1, thlD1.BHNVDong as BHNVDongD1, thlD1.TTCN as TTCND1, thlD1.CongDoanNVDong as CongDoanNVDongD1, thlD1.TroCapConNho as TroCapConNhoD1, thlD1.TroCapPhuNu as TroCapPhuNuD1, thlD1.HoTroKhac as HoTroKhacD1, thlD1.ThucNhan as ThucNhanD1, thlD1.LuongChoViec as LuongChoViecD1
			
			, thlD2.MaCongViec as MaCongViecD2, thlD2.GroupbyChucDanh as GroupbyChucDanhD2, thlD2.SoLuongNV as SoLuongNVD2, thlD2.BasicSalary as BasicSalaryD2, thlD2.PhuCap as PhuCapD2, thlD2.TienTangCa as TienTangCaD2, thlD2.Luong1Gio as Luong1GioD2, thlD2.GioLamViecKhongCoNghi as GioLamViecKhongCoNghiD2
			, thlD2.GioTangCa150 as GioTangCa150D2, thlD2.GioTangCaCN200 as GioTangCaCN200D2, thlD2.GioTangCaDem210 as GioTangCaDem210D2, thlD2.GioTangCaDemCN270 as GioTangCaDemCN270D2, thlD2.GioTangCaLe300 as GioTangCaLe300D2, thlD2.GioTangCaDemLe390 as GioTangCaDemLe390D2, thlD2.TongTangCa as TongTangCaD2, thlD2.TongTangCaVaHCDaChuyen as TongTangCaVaHCDaChuyenD2, thlD2.GioLamDem130 as GioLamDem130D2, thlD2.TienCaDem130 as TienCaDem130D2, thlD2.TongLuong as TongLuongD2
			, thlD2.CongDoanCtyTra as CongDoanCtyTraD2, thlD2.BHCtyTra as BHCtyTraD2, thlD2.TongChiPhi as TongChiPhiD2, thlD2.BHNVDong as BHNVDongD2, thlD2.TTCN as TTCND2, thlD2.CongDoanNVDong as CongDoanNVDongD2, thlD2.TroCapConNho as TroCapConNhoD2, thlD2.TroCapPhuNu as TroCapPhuNuD2, thlD2.HoTroKhac as HoTroKhacD2, thlD2.ThucNhan as ThucNhanD2, thlD2.LuongChoViec as LuongChoViecD2
			
			, thlvta.MaCongViec as MaCongViecAllVT, thlvta.GroupByViTri as GroupbyViTriAllVT, thlvta.SoLuongNV as SoLuongNVAllVT, thlvta.BasicSalary as BasicSalaryAllVT, thlvta.PhuCap as PhuCapAllVT, thlvta.TienTangCa as TienTangCaAllVT, thlvta.Luong1Gio as Luong1GioAllVT, thlvta.GioLamViecKhongCoNghi as GioLamViecKhongCoNghiAllVT
			, thlvtA.GioTangCa150 as GioTangCa150AllVT, thlvta.GioTangCaCN200 as GioTangCaCN200AllVT, thlvta.GioTangCaDem210 as GioTangCaDem210AllVT, thlvta.GioTangCaDemCN270 as GioTangCaDemCN270AllVT, thlvta.GioTangCaLe300 as GioTangCaLe300AllVT, thlvta.GioTangCaDemLe390 as GioTangCaDemLe390AllVT, thlvta.TongTangCa as TongTangCaAllVT, thlvta.TongTangCaVaHCDaChuyen as TongTangCaVaHCDaChuyenAllVT, thlvta.GioLamDem130 as GioLamDem130AllVT, thlvta.TienCaDem130 as TienCaDem130AllVT, thlvta.TongLuong as TongLuongAllVT
			, thlvtA.CongDoanCtyTra as CongDoanCtyTraAllVT, thlvta.BHCtyTra as BHCtyTraAllVT, thlvta.TongChiPhi as TongChiPhiAllVT, thlvta.BHNVDong as BHNVDongAllVT, thlvta.TTCN as TTCNAllVT, thlvta.CongDoanNVDong as CongDoanNVDongAllVT, thlvta.TroCapConNho as TroCapConNhoAllVT, thlvta.TroCapPhuNu as TroCapPhuNuAllVT, thlvta.HoTroKhac as HoTroKhacAllVT, thlvta.ThucNhan as ThucNhanAllVT, thlvta.LuongChoViec as LuongChoViecAllVT
			
			, thlvtD1.MaCongViec as MaCongViecD1VT, thlvtD1.GroupByViTri as GroupbyViTriD1VT, thlvtD1.SoLuongNV as SoLuongNVD1VT, thlvtD1.BasicSalary as BasicSalaryD1VT, thlvtD1.PhuCap as PhuCapD1VT, thlvtD1.TienTangCa as TienTangCaD1VT, thlvtD1.Luong1Gio as Luong1GioD1VT, thlvtD1.GioLamViecKhongCoNghi as GioLamViecKhongCoNghiD1VT
			, thlvtD1.GioTangCa150 as GioTangCa150D1VT, thlvtD1.GioTangCaCN200 as GioTangCaCN200D1VT, thlvtD1.GioTangCaDem210 as GioTangCaDem210D1VT, thlvtD1.GioTangCaDemCN270 as GioTangCaDemCN270D1VT, thlvtD1.GioTangCaLe300 as GioTangCaLe300D1VT, thlvtD1.GioTangCaDemLe390 as GioTangCaDemLe390D1VT, thlvtD1.TongTangCa as TongTangCaD1VT, thlvtD1.TongTangCaVaHCDaChuyen as TongTangCaVaHCDaChuyenD1VT, thlvtD1.GioLamDem130 as GioLamDem130D1VT, thlvtD1.TienCaDem130 as TienCaDem130D1VT, thlvtD1.TongLuong as TongLuongD1VT
			, thlvtD1.CongDoanCtyTra as CongDoanCtyTraD1VT, thlvtD1.BHCtyTra as BHCtyTraD1VT, thlvtD1.TongChiPhi as TongChiPhiD1VT, thlvtD1.BHNVDong as BHNVDongD1VT, thlvtD1.TTCN as TTCND1VT, thlvtD1.CongDoanNVDong as CongDoanNVDongD1VT, thlvtD1.TroCapConNho as TroCapConNhoD1VT, thlvtD1.TroCapPhuNu as TroCapPhuNuD1VT, thlvtD1.HoTroKhac as HoTroKhacD1VT, thlvtD1.ThucNhan as ThucNhanD1VT, thlvtD1.LuongChoViec as LuongChoViecD1VT
			
			, thlvtD2.MaCongViec as MaCongViecD2VT, thlvtD2.GroupByViTri as GroupbyViTriD2VT, thlvtD2.SoLuongNV as SoLuongNVD2VT, thlvtD2.BasicSalary as BasicSalaryD2VT, thlvtD2.PhuCap as PhuCapD2VT, thlvtD2.TienTangCa as TienTangCaD2VT, thlvtD2.Luong1Gio as Luong1GioD2VT, thlvtD2.GioLamViecKhongCoNghi as GioLamViecKhongCoNghiD2VT
			, thlvtD2.GioTangCa150 as GioTangCa150D2VT, thlvtD2.GioTangCaCN200 as GioTangCaCN200D2VT, thlvtD2.GioTangCaDem210 as GioTangCaDem210D2VT, thlvtD2.GioTangCaDemCN270 as GioTangCaDemCN270D2VT, thlvtD2.GioTangCaLe300 as GioTangCaLe300D2VT, thlvtD2.GioTangCaDemLe390 as GioTangCaDemLe390D2VT, thlvtD2.TongTangCa as TongTangCaD2VT, thlvtD2.TongTangCaVaHCDaChuyen as TongTangCaVaHCDaChuyenD2VT, thlvtD2.GioLamDem130 as GioLamDem130D2VT, thlvtD2.TienCaDem130 as TienCaDem130D2VT, thlvtD2.TongLuong as TongLuongD2VT
			, thlvtD2.CongDoanCtyTra as CongDoanCtyTraD2VT, thlvtD2.BHCtyTra as BHCtyTraD2VT, thlvtD2.TongChiPhi as TongChiPhiD2VT, thlvtD2.BHNVDong as BHNVDongD2VT, thlvtD2.TTCN as TTCND2VT, thlvtD2.CongDoanNVDong as CongDoanNVDongD2VT, thlvtD2.TroCapConNho as TroCapConNhoD2VT, thlvtD2.TroCapPhuNu as TroCapPhuNuD2VT, thlvtD2.HoTroKhac as HoTroKhacD2VT, thlvtD2.ThucNhan as ThucNhanD2VT, thlvtD2.LuongChoViec as LuongChoViecD2VT

			, @ActualWorkingDay as ActualWorkingDay, @PublicHoliday as PublicHoliday, @WorkingSaturday as WorkingSaturday, @SaturdayOT as SaturdayOT
		from
		udf_TongHopLuongTheoBoPhan (@Month, @Year, null, @fact, @dept, @sect, @team, @pos, @posc, @SalaryKey) thla
		left join
		udf_TongHopLuongTheoBoPhan (@Month, @Year, 'D1', @fact, @dept, @sect, @team, @pos, @posc, @SalaryKey) thlD1
		on thla.GroupbyChucDanh = thlD1.GroupbyChucDanh
		left join
		udf_TongHopLuongTheoBoPhan (@Month, @Year, 'D2', @fact, @dept, @sect, @team, @pos, @posc, @SalaryKey) thlD2
		on thla.GroupbyChucDanh = thlD2.GroupbyChucDanh
		left join
		HR_ChucDanh cd
		on thla.GroupbyChucDanh = cd.NameKR
		left join
		udf_TongHopLuongTheoViTri (@Month, @Year, null, @fact, @dept, @sect, @team, @pos, @posc, @SalaryKey) thlvta
		on thla.GroupbyChucDanh = thlvta.GroupByViTri
		left join
		udf_TongHopLuongTheoViTri (@Month, @Year, 'D1', @fact, @dept, @sect, @team, @pos, @posc, @SalaryKey) thlvtD1
		on thla.GroupbyChucDanh = thlvtD1.GroupByViTri
		left join
		udf_TongHopLuongTheoViTri (@Month, @Year, 'D2', @fact, @dept, @sect, @team, @pos, @posc, @SalaryKey) thlvtD2
		on thla.GroupbyChucDanh = thlvtD2.GroupByViTri
		Order by cast(thla.GroupbyChucDanh as int)
	end else if @TypeOfReport=13 begin --Báo cáo tổng hợp lương theo bộ phận, 1. Direct, 2. Indirect, 3. Admin
		--exec sp_BangTinhLuong 2,2023,13,'VN','admin',null,null,null,null,null,null,'MonthlySalary'
		select null as SoLuongNhanVien,null as SoLuongNhanVienThangCu,null as ChucDanh1, null as ChucDanh,thl.*, @ActualWorkingDay as ActualWorkingDay, @PublicHoliday as PublicHoliday, @WorkingSaturday as WorkingSaturday, @SaturdayOT as SaturdayOT 
		from
		udf_TongHopLuong (@Month, @Year, null, @fact, @dept, @sect, @team, @pos, @posc, @SalaryKey) thl
		union
		select null as SoLuongNhanVien,null as SoLuongNhanVienThangCu,null as ChucDanh1, null as ChucDanh,thlatt.*, @ActualWorkingDay as ActualWorkingDay, @PublicHoliday as PublicHoliday, @WorkingSaturday as WorkingSaturday, @SaturdayOT as SaturdayOT 
		from 
		udf_TongHopLuong (Month(@NgayDauThangTruoc), Year(@NgayDauThangTruoc), null, @fact, @dept, @sect, @team, @pos, @posc, @SalaryKey) thlatt
		union
		select thlttbp.SoLuongNV, thlttbptt.SoLuongNV, isnull(thlttbp.ChucDanh,thlttbptt.ChucDanh) as ChucDanh1, thlttbp.*, @ActualWorkingDay as ActualWorkingDay, @PublicHoliday as PublicHoliday, @WorkingSaturday as WorkingSaturday, @SaturdayOT as SaturdayOT 
		from
		udf_TongHopLuongTheoTungBoPhan (@Month, @Year, null, @fact, @dept, @sect, @team, @pos, @posc, @SalaryKey) thlttbp
		full outer join
		udf_TongHopLuongTheoTungBoPhan (Month(@NgayDauThangTruoc), Year(@NgayDauThangTruoc), null, @fact, @dept, @sect, @team, @pos, @posc, @SalaryKey) thlttbptt
		on thlttbp.ChucDanh = thlttbptt.ChucDanh
		order by ChucDanh1
	end else if @TypeOfReport=14 begin
		select s.DepartmentCode1 as Position, sum (s1) as LCB, sum (s13-s1-s9-s10-s11-s12) as TongPhuCap, Round (sum((s16*s17+s18*s19)/24),0) as LuongThucTe,sum (s37) as PhuCapCaDem, sum(s38) as TongTienTangCa
		,sum(TongThuNhap) as TongLuong, sum(s46) as BaoHiemVaCongDoan
		from 
		dbo.SmartBooks_Salary sa
		left join
		[udf_EmployeeFilter]('VN',null,null,null,null,null,null,null,GETDATE()) s
		on DepartmentCode1=s.DepartmentCode1
		where [key]=@SalaryKey and Salary_Month =@Month and Salary_Year=@Year
		Group by DepartmentCode1
	end else if @TypeOfReport = 15 begin
		--exec sp_BangTinhLuong 2,2023,15,'VN','admin',null,null,null,null,null,null,'MonthlySalary'
		select empl.DepartmentCode1, count(empl.Employee_ID) as CountEmp, sum(isnull(thc.wt1,0)) as thc_wt1, sum(isnull(thc.wt9,0)) as thc_wt9, sum(isnull(thc.wt3,0)) as thc_wt3
				, sum(isnull(thc.wt4,0)) as thc_wt4, sum(isnull(thc.wt5,0)) as thc_wt5, sum(isnull(thc.wt6,0)) as thc_wt6, sum(isnull(thc.wt7,0)) as thc_wt7, sum(isnull(thc.wt8,0)) as thc_wt8
				, sum(case when isnull(empl.TernimationDate,@NgayCuoiThang + 1) between @NgayDauThang and @NgayCuoiThang then 1 else 0 end) as QCTTernimated
		from
		udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,GETDATE()) empl
		left join
		udf_TongHopCong (@NgayDauThang,@NgayCuoiThang,1,@UserName) thc
		on empl.Employee_ID = thc.Employee_ID
		where empl.DepartmentCode1 = 'QCT' and isnull(empl.TernimationDate,@NgayDauThang) >= @NgayDauThang
		group by empl.DepartmentCode1
	end else if @TypeOfReport = 16 begin
		--exec sp_BangTinhLuong 2,2023,16,'VN','admin',null,null,null,null,null,null,'MonthlySalary'
		select empl.DepartmentCode1, count(empl.Employee_ID) as CountEmp, sum(isnull(thc.wt1,0)) as thc_wt1, sum(isnull(thc.wt9,0)) as thc_wt9, sum(isnull(thc.wt3,0)) as thc_wt3
				, sum(isnull(thc.wt4,0)) as thc_wt4, sum(isnull(thc.wt5,0)) as thc_wt5, sum(isnull(thc.wt6,0)) as thc_wt6, sum(isnull(thc.wt7,0)) as thc_wt7, sum(isnull(thc.wt8,0)) as thc_wt8
				, sum(case when isnull(empl.TernimationDate,@NgayCuoiThang + 1) between @NgayDauThang and @NgayCuoiThang then 1 else 0 end) as QCTTernimated
		from
		udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,GETDATE()) empl
		left join
		udf_TongHopCong (@NgayDauThang,@NgayCuoiThang,1,@UserName) thc
		on empl.Employee_ID = thc.Employee_ID
		where empl.DepartmentCode1 in ('MAT','MET','MMT') and isnull(empl.TernimationDate,@NgayDauThang) >= @NgayDauThang
		group by empl.DepartmentCode1
		order by empl.DepartmentCode1
	end else if @TypeOfReport = 17 begin
		Select cd.NameEN, cd.NameKR,thla.GroupbyChucDanh as GroupbyChucDanhAll,thla.SoLuongNV as SLNV, thla1.SoLuongNV as SLNVCu, thla.BHNVDong as BHNVDong, thla.BHCtyTra as BHCTTra,thla1.BHNVDong as BHNVDong_old,thla1.BHCtyTra as BHCtyTra_old
		from
		udf_TongHopLuongTheoBoPhan (@Month, @Year, null, @fact, @dept, @sect, @team, @pos, @posc, @SalaryKey) thla
		left join 
		udf_TongHopLuongTheoBoPhan (@Month-1, @Year, null, @fact, @dept, @sect, @team, @pos, @posc, @SalaryKey) thla1
		on thla.GroupbyChucDanh=thla1.GroupbyChucDanh
		left join
		HR_ChucDanh cd
		on thla.GroupbyChucDanh = cd.NameKR
		Order by cast(thla.GroupbyChucDanh as int)
		--exec sp_BangTinhLuong 8,2023,17,'VN','admin',null,null,null,null,null,null,'MonthlySalary'
	end

END



GO
