-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec sp_KetChuyenDuLieuNhanVienTuBanCu '2000-02-01','2026-09-30'
CREATE PROCEDURE [dbo].[sp_KetChuyenDuLieuNhanVienTuBanCu]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRY
    BEGIN TRANSACTION
	Declare @sql nvarchar(Max)
	--kết chuyển dữ liệu nhân viên
		--delete SmartBooks_Employee where StartedDate between @fromdate and @todate
		INSERT INTO [dbo].[SmartBooks_Employee]
           ([Employee_ID]
           ,[Employee_Firstname]
           ,[Employee_LastName]
           ,[BirthDate]
           ,[BirthPlace]
           ,[Sex]
           ,[MaritalStatus]
           ,[Nationality]
           ,[Nation]
           ,[ID_number]
           ,[ID_date]
           ,[ID_place]
           ,[Address_Temporary]
           ,[Address_Permanent]
           ,[NativePlace]
           ,[Employee_Status]
           ,[StartedDate]
           ,[ComStartedDate]
           ,[Factory_ID]
		   ,DepartmentCode
           ,[SectionCode]
           ,[TeamCode]
           ,[Position_ID]
           ,[PositionCategory_ID]
           ,[ChucDanh]
           ,[JobCode]
           ,[CongViecPhaiLam]
           ,[Card_No]
           ,[Card_Code]
           ,[BankName]
           ,[BankCode]
           ,[DebitAccount]
           ,[Qualification]
           ,[OfficialDate]
           ,[Graduated]
           ,[GraduatedFrom]
           ,[TernimationDate]
           ,[Tel]
           ,[Email]
           ,[MaSoThue]
           ,[SoNgayPhepNam]
           ,[ContractFlow]
           ,[TonGiao]
           ,[NguoiLienHeGap]
           ,[Height]
           ,[Weight]
           ,[Hospital]
           ,[HealthCheckFee]
           ,[Remark]
           ,[UserName]
           ,[InsertDate]
           ,[Picture]
           ,[BirthDateFormat]
           ,[TenChuHo]
           ,[QuanHeVoiChuHo]
           ,[isThuViec85PhanTram]
           ,[NgayTGCongDoan]
		   ,CCCDCu
		   ,CCCDCu_Date
		   ,CCCDCu_Place
		   ,NgayHetHanCCCD
		   ,ResonTerminated
		   ,SoNhaThonXom
		   ,PhuongXa
		   ,QuanHuyen
		   ,TinhThanhPho
		   ,isManager
		   )
     select 
            SBE.Employee_ID
           ,SBE.Employee_Firstname
           ,SBE.Employee_LastName
           ,case when SBE.BirthDate is null then '1900-01-01' else SBE.BirthDate end
           ,SBE.BirthPlace
           ,case when SBE.Sex = 'F' then 'Female' when SBE.sex is null then '' else SBE.Sex end
           ,SBE.MaritalStatus
           ,isnull(SBE.Nationality,SBE.Nationality_EN)
		   ,sbe.TemporaryContact_Relation as [Nation]
           ,case when SBE.ID_number is null then '0' else SBE.ID_number end
           ,SBE.ID_date
           ,SBE.ID_place
           ,isnull(SBE.Address_Temporary,SBE.Address_Temporary_EN)
           ,SBE.Address_Permanent
           ,SBE.NativePlace
           ,case when SBE.Employee_Status='Active' then 'Incumbent' else SBE.Employee_Status end
           ,SBE.StartedDate
           ,SBE.StartedDate
		   ,SBE.DepartmentCode
		   ,SBE.DepartmentCode + '_' + SBE.SectionCode
		   ,SBE.DepartmentCode + '_' + SBE.SectionCode + '_' +  SBE.PositionCategory_ID
		   ,null
		   ,SBE.SectionCode
		   ,SBE.Position_ID
		   ,isnull(sbe.Position_ID,SBE.ChucDanh)
		   ,null
		   ,SBE.CongViecPhaiLam
		   ,SBE.Card_No
		   ,SBE.Card_Code
		   ,SBE.BankName
		   ,isnull(SBE.BankAccount,SBE.BankCode)
		   ,SBE.DebitAccount
		   ,SBE.Qualification
		   ,case when SBE.ProbationDate = '1900-01-01' then null else SBE.ProbationDate end as OfficialDate
		   ,SBE.Qualification As Graduated
		   ,SBE.GraduatedFrom
		   ,SBE.TernimationDate
		   ,SBE.Tel
		   ,SBE.Email
		   ,SBE.MaSoThue
		   ,null as SoNgayPhepNam
		   ,Case	
		   		when DATEDIFF (day,SBE.StartedDate,SBE.ProbationDate) = 0 and sbe.ProbationDate <> '1900-01-01' THEN 'HDCT1NAM'
		   		when DATEDIFF (day,SBE.StartedDate,SBE.ProbationDate)>=50 and sbe.ProbationDate <> '1900-01-01' then 'HDTV2THANG'
		   		when DATEDIFF (DAY,SBE.StartedDate,SBE.ProbationDate)>=28 and sbe.ProbationDate <> '1900-01-01' then 'HDTV1THANG' 
				when sbe.ProbationDate = '1900-01-01' and sbe.DepartmentCode = 'FACTORY O' Then 'HDTV2THANG'
				when sbe.ProbationDate = '1900-01-01' and sbe.DepartmentCode <> 'FACTORY O' Then 'HDTV2THANG'
		   		else null end as ContractFlow
		   ,sbe.TonGiao
		   ,SBE.NguoiGiamHo
		   ,null
		   ,null
		   ,null
		   ,null
		   ,SBE.Training_note
		   ,'Auto'
		   ,SBE.InsertDate
		   ,SBE.Picture
		   ,null
		   ,null
		   ,null
		   ,null
		   ,null
		   ,sbe.OldID_Number
		   ,sbe.ID_Old_Date
		   ,sbe.ID_Old_Place
		   ,case when datediff(year,sbe.BirthDate,@todate) < 25 then dateadd(year, 25, sbe.BirthDate) when datediff(year,sbe.BirthDate,@todate) < 40 then dateadd(year,40, sbe.BirthDate) when datediff(year,sbe.BirthDate,@todate) < 60 then dateadd(year,60, sbe.BirthDate) else dateadd(year,100, sbe.BirthDate) end
		   ,sbe.ResonTerminated
		   ,sbe.SoNhaThonXom
		   ,sbe.PhuongXa
		   ,sbe.QuanHuyen
		   ,sbe.TinhThanhPho
		   ,sbe.isManager
		from
		HR_SNK.dbo.SmartBooks_Employee SBE
		LEFT JOIN
		SmartBooks_Employee SB
		ON SB.Employee_ID collate SQL_Latin1_General_CP437_CI_AS = SBE.Employee_ID 
		where SBE.StartedDate between @fromdate and @todate AND SB.Employee_ID IS NULL

	Update SB
	set  sb.[Employee_Firstname]   = SBE.Employee_Firstname
        ,sb.[Employee_LastName]	   = SBE.Employee_LastName
        ,sb.[BirthDate]			   = case when SBE.BirthDate is null then '1900-01-01' else SBE.BirthDate end
        ,sb.[BirthPlace]		   = SBE.BirthPlace
        ,sb.[Sex]				   = case when SBE.Sex = 'F' then 'Female' when SBE.sex is null then '' else SBE.Sex end
        ,sb.[MaritalStatus]		   = SBE.MaritalStatus
        ,sb.[Nationality]		   = isnull(SBE.Nationality,SBE.Nationality_EN)
        ,sb.[Nation]			   = sbe.TemporaryContact_Relation
        ,sb.[ID_number]			   = case when SBE.ID_number is null then '0' else SBE.ID_number end
        ,sb.[ID_date]			   = SBE.ID_date
        ,sb.[ID_place]			   = SBE.ID_place
        ,sb.[Address_Temporary]	   = isnull(SBE.Address_Temporary,SBE.Address_Temporary_EN)
        ,sb.[Address_Permanent]	   = SBE.Address_Permanent
        ,sb.[NativePlace]		   = SBE.NativePlace
        ,sb.[Employee_Status]	   = case when SBE.Employee_Status='Active' then 'Incumbent' else SBE.Employee_Status end
        ,sb.[StartedDate]		   = SBE.StartedDate
        ,sb.[ComStartedDate]	   = SBE.StartedDate
        ,sb.[Factory_ID]		   = SBE.DepartmentCode
		,sb.DepartmentCode		   = SBE.DepartmentCode + '_' + SBE.SectionCode
        ,sb.[SectionCode]		   = SBE.DepartmentCode + '_' + SBE.SectionCode + '_' +  SBE.PositionCategory_ID
        ,sb.[TeamCode]			   = null
        ,sb.[Position_ID]		   = SBE.SectionCode
        ,sb.[PositionCategory_ID]  = SBE.Position_ID
        ,sb.[ChucDanh]			   = isnull(sbe.Position_ID,SBE.ChucDanh)
        ,sb.[JobCode]			   = null
        ,sb.[CongViecPhaiLam]	   = SBE.CongViecPhaiLam
        ,sb.[Card_No]			   = SBE.Card_No
        ,sb.[Card_Code]			   = SBE.Card_Code
        ,sb.[BankName]			   = SBE.BankName
        ,sb.[BankCode]			   = isnull(SBE.BankAccount,SBE.BankCode)
        ,sb.[DebitAccount]		   = SBE.DebitAccount
        ,sb.[Qualification]		   = SBE.Qualification
        ,sb.[OfficialDate]		   = case when SBE.ProbationDate = '1900-01-01' then null else SBE.ProbationDate end
        ,sb.[Graduated]			   = SBE.Qualification
        ,sb.[GraduatedFrom]		   = SBE.GraduatedFrom
        ,sb.[TernimationDate]	   = SBE.TernimationDate
        ,sb.[Tel]				   = SBE.Tel
        ,sb.[Email]				   = SBE.Email
        ,sb.[MaSoThue]			   = SBE.MaSoThue
        ,sb.[SoNgayPhepNam]		   = null 
        ,sb.[ContractFlow]		   = Case	
		   								when DATEDIFF (day,SBE.StartedDate,SBE.ProbationDate) = 0 and sbe.ProbationDate <> '1900-01-01' THEN 'HDCT1NAM'
		   								when DATEDIFF (day,SBE.StartedDate,SBE.ProbationDate)>=50 and sbe.ProbationDate <> '1900-01-01' then 'HDTV2THANG'
		   								when DATEDIFF (DAY,SBE.StartedDate,SBE.ProbationDate)>=28 and sbe.ProbationDate <> '1900-01-01' then 'HDTV1THANG' 
										when sbe.ProbationDate = '1900-01-01' and sbe.DepartmentCode = 'FACTORY O' Then 'HDTV2THANG'
										when sbe.ProbationDate = '1900-01-01' and sbe.DepartmentCode <> 'FACTORY O' Then 'HDTV2THANG'
		   								else null end
        ,sb.[TonGiao]			   = sbe.TonGiao
        ,sb.[NguoiLienHeGap]	   = SBE.NguoiGiamHo		
        ,sb.[Height]			   = null		
        ,sb.[Weight]			   = null		
        ,sb.[Hospital]			   = null		
        ,sb.[HealthCheckFee]	   = null		
        ,sb.[Remark]			   = SBE.Training_note		
        ,sb.[UserName]			   = 'Auto'
        ,sb.[InsertDate]		   = SBE.InsertDate
        --,sb.[RFID]				   = SBE.SizeAo
        ,sb.[BirthDateFormat]	   = null
        ,sb.[TenChuHo]			   = null
        ,sb.[QuanHeVoiChuHo]	   = null
        ,sb.[isThuViec85PhanTram]  = null
        ,sb.[NgayTGCongDoan]	   = null
		,sb.CCCDCu				   = sbe.OldID_Number
		,sb.CCCDCu_Date			   = SBE.ID_Old_Date
		,sb.CCCDCu_Place		   = sbe.ID_Old_Place
		,sb.NgayHetHanCCCD		   = case when datediff(year,sbe.BirthDate,@todate) < 25 then dateadd(year,25, sbe.BirthDate) when datediff(year,sbe.BirthDate,@todate) < 40 then dateadd(year,40, sbe.BirthDate) when datediff(year,sbe.BirthDate,@todate) < 60 then dateadd(year,60, sbe.BirthDate) else dateadd(year,100, sbe.BirthDate) end
		,sb.ResonTerminated		   = sbe.ResonTerminated
		,sb.SoNhaThonXom		   = sbe.SoNhaThonXom
		,sb.PhuongXa			   = sbe.PhuongXa
		,sb.QuanHuyen			   = sbe.QuanHuyen
		,sb.TinhThanhPho		   = sbe.TinhThanhPho
		,sb.isManager			   = sbe.isManager
	from			 
	SmartBooks_Employee SB						 
	LEFT JOIN			
	HR_SNK.dbo.SmartBooks_Employee SBE				 
	ON SB.Employee_ID collate SQL_Latin1_General_CP437_CI_AS = SBE.Employee_ID 
	where SBE.StartedDate between @fromdate and @todate --AND SB.Employee_ID IS not NULL
									 
	Update empl
	set Factory_ID = isnull(f.Factory_ID, empl.Factory_ID)
	from
	SmartBooks_Employee empl
	left join
	HR_Factory f
	on empl.Factory_ID = f.NameVN

	--Update empl
	--set DepartmentCode = empl.Factory_ID + '_' + isnull(dp.DepartmentCode, empl.DepartmentCode)
	--from
	--SmartBooks_Employee empl
	--left join
	--SmartBooks_Department dp
	--on empl.DepartmentCode = dp.DepartmentName_VN

	Update empl
	set SectionCode = isnull(sec.SectionCode, empl.SectionCode)
	from
	SmartBooks_Employee empl
	left join
	SmartBooks_Section sec
	on empl.SectionCode = sec.SectionCode

	Update empl
	set TeamCode = isnull(t.TeamCode, empl.TeamCode)
	from
	SmartBooks_Employee empl
	left join
	SmartBooks_Team t
	on empl.TeamCode = t.TeamCode

	Update empl
	set PositionCategory_ID = isnull(pc.PositionCategory_ID, empl.PositionCategory_ID)
	from
	SmartBooks_Employee empl
	left join
	SmartBooks_PositionCategory pc
	on empl.PositionCategory_ID=pc.PositionCategory_ID

	Delete sb
	from
	SmartBooks_Employee sb
	left join
	HR_SNK.dbo.SmartBooks_Employee sbe
	ON SB.Employee_ID collate SQL_Latin1_General_CP437_CI_AS = SBE.Employee_ID 
	where sbe.Employee_ID is null

	delete HR_TerminationAsignment
	where PlanTernimationDate between @fromdate and @todate

	insert into HR_TerminationAsignment (Employee_ID, PlanTernimationDate, ResonTerminated, DecisionCode, DecisionStatus, NgayNopDon, Remark, InsertDate, UserName, ThangTinhLuong)
	select Employee_ID, TernimationDate, '25', Employee_ID + cast(Year(NgayQDNghiViec) as nvarchar(50)) as DecisionCode, 'Approved', null, ResonTerminated, NgayQDNghiViec, 'Auto', null
	from
	HR_SNK.dbo.SmartBooks_Employee
	where isnull(TernimationDate,@todate+1) between @fromdate and @todate

	--update SmartBooks_Employee
	--set Position_ID = 'Già hoá'
	--where Position_ID = 'già hóa'

	--update SmartBooks_Employee
	--set Position_ID = 'Kiểm Tra'
	--where Position_ID = 'Kiêm Tra'

	--Update empl
	--set Position_ID = isnull(p.Position_ID, empl.Position_ID)
	--from
	--SmartBooks_Employee empl
	--left join
	--SmartBooks_Position p
	--on empl.Position_ID = p.Position_NameVN

	--update SmartBooks_Employee
	--set ContractFlow = case 
	--					when ContractFlow = 'HDTV_VanPhong' then 'HDTV60NGAY'
	--					when ContractFlow = 'HDVoThoiHan_VanPhong' then 'HDVTH'
	--					when ContractFlow = 'HDLDDuoiMotThang' then 'HDTV6NGAY'
	--					when ContractFlow = 'HDTV6N_MotNam_CongNhan' then 'HDTV6NGAY1NAM'
	--					when ContractFlow = 'HDBaNam_VanPhong' then 'HD3NAM'
	--					when ContractFlow = 'HDTV_MotNam_CongNhan' then 'HD1NAM_1'
	--					when ContractFlow = 'HDBaNam_CongNhan' then 'HD3NAM'
	--					when ContractFlow = 'HDMotNam_CongNhan' then 'HD1NAM_1'
	--					when ContractFlow = 'HDMotNam_VanPhong' then 'HD1NAM_1'
	--					when ContractFlow = 'HDVoThoiHan_CongNhan' then 'HDVTH'
	--					else ContractFlow end
	
	--exec sp_XulyNhapNhanVienMoi 'admin'

	exec sp_KetChuyenDuLieuChuyenViTri @fromdate, @todate

	exec sp_KetChuyenDuLieuGiaDinh @fromdate, @todate

	--declare sqlQuere

	--exec sp_KetChuyenDuLieuNghiViec @fromdate, @todate

	select 'ThucHienThanhCong' as ThongBao
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRAN --RollBack in case of Error

		-- <EDIT>: From SQL2008 on, you must raise error messages as follows:
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  

		SELECT   
		   @ErrorMessage = ERROR_MESSAGE(),  
		   @ErrorSeverity = ERROR_SEVERITY(),  
		   @ErrorState = ERROR_STATE();  

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);  

		-- </EDIT>
	END CATCH
    COMMIT TRAN -- Transaction Success!
END

GO
