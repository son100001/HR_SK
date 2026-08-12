--select * from smartbooks_contractlist
CREATE PROCEDURE [dbo].[sp_BangHopDong]
	--exec sp_BangHopDong '1990-1-1','2999-1-1',4,'VN',null,null,null,null,null,null,'0940-3/2023',null
	-- Add the parameters for the stored procedure here
	--select * from [dbo].[udf_GanLuongVaoHopDong]('2020-1-1','2020-12-1',0)
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,--1:ds hđ ký trong khoảng thời gian; 2: danh sách hđ hết hạn trong khoảng thời gian;3: danh sách hđ hiệu lực trong khoảng time;4:print
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@ListOfID Nvarchar(max)=null,
	@Empl nvarchar(50)=null
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @SalaryCatogory varchar(max),@SumAllSalaryCatogory varchar(max),@DynamicPivotQuery AS NVARCHAR(MAX)
	-- TẠO DANH MỤC PIVOT
	set @SalaryCatogory=''
	select @SalaryCatogory=@SalaryCatogory+SalaryComponent+',' from HR_SalaryComponentCategory where isnull(MonthlyChanging,0)=0
	set @SalaryCatogory=@SalaryCatogory+'MucLuong'
	-- TẠO SUM ALL LƯƠNG TRONG HĐ
	set @SumAllSalaryCatogory=''
	select @SumAllSalaryCatogory=@SumAllSalaryCatogory+'isnull('+SalaryComponent+',0)+' from HR_SalaryComponentCategory where isnull(MonthlyChanging,0)=0
	set @SumAllSalaryCatogory=@SumAllSalaryCatogory+'MucLuong'
	
	declare @Employee_ID nvarchar(50),@Contract_ID nvarchar(50),@CL_StartDate datetime,@OldCL_StartDate datetime,@OldContract_ID nvarchar(50),@OldCL_RegisterDate datetime,@OldCL_ExpiredDate datetime,@CL_RegisterDate datetime,@CL_ExpiredDate datetime
			,@Type nvarchar(50),@NumberOfDay int,@NumberOfMonth int,@NumberOfYear int

	if @TypeOfReport=1 or @TypeOfReport=2 begin
		--TẠO BẢNG TẠM HĐ GỒM LƯƠNG
		select empl.Position,empl.Position_ID,empl.PositionCategory_ID, empl.BirthDate, empl.Address_Permanent
		,empl.Employee_ID, [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
		,ctl.Contract_ID,ctl.[Type],ctl.CL_RegisterDate,ctl.CL_StartDate,datepart(year,CL_StartDate) as Nam,datepart(month,CL_StartDate) as Thang, Datepart(Day,CL_StartDate) as Ngay
		,ctl.CL_ExpiredDate
		,ctl.CL_FatherID,ctl.[status],ctl.CL_Remark,ctl.InsertDate,ctl.UserName,ctl.ContractAnnexID,ctl.ID
		--,sc.*
		from
		--[dbo].[udf_GanLuongVaoHopDong](@fromdate,@todate,(case when @TypeOfReport=1 then 1 else 0 end)) sc
		--left join
		--select * from [dbo].[udf_HopDongTuSinh]('2019-1-1','2021-1-1','1','VN',null,null,null,null,null,null,'HT001045,HT000972', null)
		[dbo].[udf_HopDongTuSinh](@fromdate,@todate,case when @TypeOfReport=1 then 1 else 0 end,@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Empl) ctl
		--on ctl.Contract_ID=sc.Contract_ID
		left join
		udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Empl,isnull(@todate,getdate())) empl
		on ctl.Employee_ID=empl.Employee_ID
		left join
		SmartBooks_Contract ctType
		on ctl.[Type]=ctType.Contract_ID
		where empl.Employee_ID is not null or (ctl.[Type] = 'HDVTH' and month(ctl.CL_StartDate) = Month(@todate))
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID,ctl.[Type],ctl.CL_StartDate
	end else if @TypeOfReport=3 begin
		select empl.Position
		,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
		,ctl.Contract_ID,ctl.[Type],ctl.CL_RegisterDate,ctl.CL_StartDate
		,ctl.CL_ExpiredDate
		,ctl.CL_FatherID,ctl.[status],ctl.CL_Remark,ctl.InsertDate,ctl.UserName,ctl.ContractAnnexID,ctl.ID
		--,sc.*
		from
		--[dbo].[udf_GanLuongVaoHopDong]('1990-1-1','2999-1-1',(case when @TypeOfReport=1 then 1 else 0 end)) sc
		--left join
		[dbo].[udf_HopDongTuSinh](@fromdate,@todate,1,@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Empl) ctl
		--on ctl.Contract_ID=sc.Contract_ID
		left join
		[dbo].[SmartBooks_Contract] ctType
		on ctl.[Type]=ctType.Contract_ID
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Empl,isnull(@todate,getdate())) empl
		on ctl.Employee_ID=empl.Employee_ID
		where ctl.CL_StartDate<=@todate and empl.Employee_ID is not null
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID,ctl.[Type],ctl.CL_StartDate
	end else if @TypeOfReport=4 begin
		
		
		DECLARE @BangHD TABLE(Employee_ID nvarchar(50) NOT NULL
		,PositionFullName nvarchar(255),PositionName nvarchar(255)
		,Contract_ID nvarchar(50),CL_RegisterDate datetime,CL_ExpiredDate datetime,CL_StartDate datetime,[Type] nvarchar(50)
		,NumberOfDay int,NumberOfMonth int,NumberOfYear int
		,[CD1] float,[CD2] float,[CD3] float,[CD4] float,[CD5] float,[CD6] float,[CD7] float,[CD8] float,[CD9] float,[CD10] float,[CD11] float,[CD12] float,[CD13] float,[CD14] float,[CD15] float,[CD16] float,[CD17] float,[CD18] float,[CD19] float,[CD20] float
		,primary key (contract_id))

		DECLARE cur CURSOR LOCAL FOR
		select Employee_ID,ctl.Contract_ID,CL_StartDate,CL_RegisterDate,CL_ExpiredDate,[Type]
		,NumberOfDay,NumberOfMonth,NumberOfYear
		from [dbo].[udf_HopDongTuSinh]('1990-1-1','2999-1-1',1,@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Empl) ctl
		left join
		SmartBooks_Contract ct
		on ctl.[Type]=ct.Contract_ID
		where isnull(ct.isAppendix,0)=0
		and ctl.Contract_ID in (select Data from Split(@ListOfID,','))
		OPEN  cur
		FETCH NEXT FROM cur INTO @Employee_ID,@Contract_ID,@CL_StartDate,@CL_RegisterDate,@CL_ExpiredDate,@Type,@NumberOfDay,@NumberOfMonth,@NumberOfYear
		WHILE @@FETCH_STATUS = 0
		BEGIN
			insert into @BangHD
			select @Employee_ID
				,bophan.Name as PositionFullName,pos.Position_NameVN as Position_Name
				,@Contract_ID,@CL_RegisterDate,@CL_ExpiredDate,@CL_StartDate,@Type
				,@NumberOfDay,@NumberOfMonth,@NumberOfYear
				,CD1,CD2,CD3,CD4,CD5,CD6,CD7,CD8,CD9,CD10,CD11,CD12,CD13,CD14,CD15,CD16,CD17,CD18,CD19,CD20
			from
			smartbooks_employee empl
			left join
			[dbo].[udf_TraVeBangTransfer_Horizontal](@CL_StartDate,@Employee_ID)ViTri
			on empl.Employee_ID=vitri.Employee_ID
			left join
			udf_position(@LAN,0) bophan
			on ViTri.Position=bophan.Code
			left join
			[dbo].[udf_BangLuongCoDinh](@CL_StartDate,@Employee_ID) lcd
			on empl.Employee_ID=lcd.Employee_ID
			left join
			SmartBooks_Position pos
			on ViTri.Position_ID=pos.Position_ID
			where empl.Employee_ID=@Employee_ID
		FETCH NEXT FROM cur INTO @Employee_ID,@Contract_ID,@CL_StartDate,@CL_RegisterDate,@CL_ExpiredDate,@Type,@NumberOfDay,@NumberOfMonth,@NumberOfYear
		END
		CLOSE cur
		DEALLOCATE cur
		--select * from @BangHD
		select
		[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate, empl.SectionCode, empl.Factory_ID
		,empl.Sex,empl.Address_Permanent,[dbo].[non_unicode_convert](empl.Address_Permanent) as Address_PermanentEN,empl.Address_Temporary,[dbo].[non_unicode_convert](empl.Address_Temporary) as Address_TemporaryEN,empl.Tel
		,empl.ID_number,empl.ID_place,empl.ID_date,empl.BirthDate,empl.BirthPlace,empl.CongViecPhaiLam,empl.DepartmentCode, empl.Factory_ID as BoPhan, empl.SectionCode as ChucVu, p.Position_NameVN as ChucDanhChuyenMon,DATEADD(DAY, -1, empl.OfficialDate) AS NgayHetThuViec, empl.Position_NameEN
		,CASE
        WHEN RIGHT(empl.Employee_ID, 4) LIKE '0%' THEN RIGHT(empl.Employee_ID, 3)
        ELSE RIGHT(empl.Employee_ID, 4)
		END AS SoHopDong
		--,ctl.Contract_ID,ctl.[Type],ctl.CL_RegisterDate,ctl.CL_StartDate
		--,ctl.CL_ExpiredDate
		--,ctl.CL_FatherID,ctl.[status],ctl.CL_Remark,ctl.InsertDate,ctl.UserName,ctl.ContractAnnexID,ctl.ID
		--,ctlTest.Contract_ID as TestContract_ID, ctlTest.CL_RegisterDate as TestCL_RegisterDate, ctlTest.CL_StartDate as TestCL_StartDate, ctlTest.CL_ExpiredDate as TestCL_ExpiredDate
		--,sc.*, dbo.udf_PCThamNien(empl.StartedDate, ctl.CL_StartDate, '') as PCThamNien
		,empl.isThuViec85PhanTram
		,hd.*
		,(isnull(CD1,0) + ISNULL(CD2,0) + ISNULL(CD3,0) + ISNULL(CD4,0) + ISNULL(CD5,0) + ISNULL(CD6,0) + ISNULL(CD7,0) + ISNULL(CD8,0) + ISNULL(CD9,0) + ISNULL(CD10,0) + ISNULL(CD11,0) + ISNULL(CD12,0) + ISNULL(CD13,0) + ISNULL(CD14,0) + ISNULL(CD15,0)
		 --+ ISNULL(dbo.udf_PCThamNien(empl.StartedDate, ctl.CL_StartDate, ''), 0)
		 )
		 as TongMucLuong
		from
		@BangHD hd
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Empl,isnull(@todate,getdate())) empl
		on hd.Employee_ID=empl.Employee_ID
		left join 
		SmartBooks_Position p
		on empl.Position_ID =p.Position_NameVN
		--left join 
		--[dbo].[udf_HopDongTuSinh]('1990-1-1','2999-1-1',1,@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Empl) ctl
		--on empl.Employee_ID = ctl.Employee_ID

		--where empl.Employee_ID=@Employee_ID
		
	end else if @TypeOfReport=5 begin-- lấy hđ theo mã nv
		IF OBJECT_ID('tempdb..#tabSalaryOfContract5') IS NOT NULL DROP TABLE #tabSalaryOfContract5
		select scMin.Contract_ID as Contract_ID,scDetail.* into #tabSalaryOfContract5 from
		(
			select ctl.Contract_ID,sc.Employee_ID,sc.SalaryComponent,max(Fromdate) as Fromdate from 
			(select * from [dbo].[udf_HopDongTuSinh](@fromdate,@todate,1,@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Empl) ctl where Employee_ID in ((select Data from Split(@ListOfID,',')))) ctl
			left join
			[dbo].[HR_SalaryComponent] sc
			on ctl.Employee_ID=sc.Employee_ID and sc.Fromdate<=ctl.CL_StartDate and (sc.Todate is null or sc.Todate>=ctl.CL_StartDate)
			group by ctl.Contract_ID,sc.Employee_ID,sc.SalaryComponent
		)scMin
		left join
		[dbo].[HR_SalaryComponent] scDetail
		on scMin.Employee_ID=scDetail.Employee_ID and scMin.SalaryComponent=scDetail.SalaryComponent and scMin.Fromdate=scDetail.Fromdate
		CREATE INDEX IDX ON #tabSalaryOfContract5 (Contract_ID)
		--TẠO BẢNG TẠM HĐ GỒM LƯƠNG
		IF OBJECT_ID('tempdb..#tab5') IS NOT NULL DROP TABLE #tab5
		select empl.FactoryName,empl.DepartmentName, empl.SectionName, empl.TeamName, empl.PositionName, empl.PositionCategoryName
		,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
		,ctl.Contract_ID,ctl.[Type],ctl.CL_RegisterDate,ctl.CL_StartDate
		,ctl.CL_ExpiredDate
		,ctl.CL_FatherID,ctl.[status],ctl.CL_Remark,ctl.InsertDate,ctl.UserName,ctl.ContractAnnexID,ctl.ID
		,ctl.ID,sc.SalaryComponent,sc.Amount into #tab5
		from
		#tabSalaryOfContract5 sc
		left join
		[dbo].[udf_HopDongTuSinh]('1990-1-1','2999-1-1',1,@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Empl) ctl
		on ctl.Contract_ID=sc.Contract_ID
		left join
		[dbo].[SmartBooks_Contract] ctType
		on ctl.[Type]=ctType.Contract_ID
		left join
		udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Empl,isnull(@todate,getdate())) empl
		on ctl.Employee_ID=empl.Employee_ID
		where empl.Employee_ID is not null
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID,ctl.[Type],ctl.CL_StartDate
		-- TẠO QUERY PIVOT
		SET @DynamicPivotQuery = 'select * from #tab5 ' + N' PIVOT ( SUM(Amount) FOR SalaryComponent IN ('+ @SalaryCatogory +')) AS pv'

		exec (@DynamicPivotQuery)
	end else if @TypeOfReport=6 begin -- phụ lục hợp đồng có lương cũ
		DECLARE @BangPhuLucHD TABLE(Employee_ID nvarchar(50) NOT NULL,OldContract_ID nvarchar(50),OldCL_RegisterDate datetime,OldCL_ExpiredDate datetime,OldCL_StartDate datetime
		,Contract_ID nvarchar(50),CL_RegisterDate datetime,CL_ExpiredDate datetime,CL_StartDate datetime,[Type] nvarchar(50)
		,OldPositionFullName nvarchar(255),OldPositionName nvarchar(255),PositionFullName nvarchar(255),PositionName nvarchar(255)
		,[OldCD1] float,[OldCD2] float,[OldCD3] float,[OldCD4] float,[OldCD5] float,[OldCD6] float,[OldCD7] float,[OldCD8] float,[OldCD9] float,[OldCD10] float,[OldCD11] float,[OldCD12] float,[OldCD13] float,[OldCD14] float,[OldCD15] float,[OldCD16] float,[OldCD17] float,[OldCD18] float,[OldCD19] float,[OldCD20] float
		,[CD1] float,[CD2] float,[CD3] float,[CD4] float,[CD5] float,[CD6] float,[CD7] float,[CD8] float,[CD9] float,[CD10] float,[CD11] float,[CD12] float,[CD13] float,[CD14] float,[CD15] float,[CD16] float,[CD17] float,[CD18] float,[CD19] float,[CD20] float
		,primary key (Employee_ID))

	
		DECLARE cur CURSOR LOCAL FOR
		select Employee_ID,ctl.Contract_ID,CL_StartDate,CL_RegisterDate,CL_ExpiredDate,[Type]
		from [dbo].[udf_HopDongTuSinh]('1990-1-1','2999-1-1',1,@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Empl) ctl
		left join
		SmartBooks_Contract ct
		on ctl.[Type]=ct.Contract_ID
		where ct.isAppendix=1 and ctl.Contract_ID in (select Data from Split(@ListOfID,','))
		OPEN  cur
		FETCH NEXT FROM cur INTO @Employee_ID,@Contract_ID,@CL_StartDate,@CL_RegisterDate,@CL_ExpiredDate,@Type
		WHILE @@FETCH_STATUS = 0
		BEGIN
			select @OldCL_StartDate=CL_StartDate,@OldContract_ID=Contract_ID,@OldCL_RegisterDate=CL_RegisterDate,@OldCL_ExpiredDate=@CL_ExpiredDate from [dbo].[udf_HopDongTuSinh]('1900-1-1',@CL_StartDate-1,1,'VN',NULL,NULL,NULL,NULL,NULL,NULL,@Employee_ID)
			where [Type] in (select contract_ID from smartbooks_contract where isnull(isappendix,0)=0) order by CL_StartDate asc
			insert into @BangPhuLucHD
			select @Employee_ID,@OldContract_ID,@OldCL_RegisterDate,@OldCL_ExpiredDate,@OldCL_StartDate
				,@Contract_ID,@CL_RegisterDate,@CL_ExpiredDate,@CL_StartDate,@Type
				,bophanCu.Name as OldPositionFullName,posCu.Position_NameVN as Position_NameCu,bophanMoi.Name as OldPositionFullName,posMoi.Position_NameVN as Position_NameVNMoi
				,LuongCu.CD1 as OldCD1,LuongCu.CD2 as OldCD2,LuongCu.CD3 as OldCD3,LuongCu.CD4 as OldCD4,LuongCu.CD5 as OldCD5,LuongCu.CD6 as OldCD6,LuongCu.CD7 as OldCD7,LuongCu.CD8 as OldCD8,LuongCu.CD9 as OldCD9,LuongCu.CD10 as OldCD10,LuongCu.CD11 as OldCD11,LuongCu.CD12 as OldCD12,LuongCu.CD13 as OldCD13,LuongCu.CD14 as OldCD14,LuongCu.CD15 as OldCD15,LuongCu.CD16 as OldCD16,LuongCu.CD17 as OldCD17,LuongCu.CD18 as OldCD18,LuongCu.CD19 as OldCD19,LuongCu.CD20 as OldCD20
				,LuongMoi.CD1,LuongMoi.CD2,LuongMoi.CD3,LuongMoi.CD4,LuongMoi.CD5,LuongMoi.CD6,LuongMoi.CD7,LuongMoi.CD8,LuongMoi.CD9,LuongMoi.CD10,LuongMoi.CD11,LuongMoi.CD12,LuongMoi.CD13,LuongMoi.CD14,LuongMoi.CD15,LuongMoi.CD16,LuongMoi.CD17,LuongMoi.CD18,LuongMoi.CD19,LuongMoi.CD20
			from
			smartbooks_employee empl
			left join
			[dbo].[udf_TraVeBangTransfer_Horizontal](@OldCL_StartDate,@Employee_ID)ViTriCu
			on empl.Employee_ID=ViTriCu.Employee_ID
			left join
			udf_position(@LAN,0) bophanCu
			on ViTriCu.Position=bophanCu.Code
			left join
			SmartBooks_Position posCu
			on ViTriCu.Position_ID=posCu.Position_ID
			left join
			[dbo].[udf_TraVeBangTransfer_Horizontal](@CL_StartDate,@Employee_ID)ViTriMoi
			on empl.Employee_ID=ViTriMoi.Employee_ID
			left join
			udf_position(@LAN,1) bophanMoi
			on ViTriMoi.Position=bophanMoi.Code
			left join
			SmartBooks_Position posMoi
			on ViTriMoi.Position_ID=posMoi.Position_ID
			left join
			[dbo].[udf_BangLuongCoDinh](@OldCL_StartDate,@Employee_ID) LuongCu
			on empl.Employee_ID=LuongCu.Employee_ID
			left join
			[dbo].[udf_BangLuongCoDinh](@CL_StartDate,@Employee_ID) LuongMoi
			on empl.Employee_ID=LuongMoi.Employee_ID
			where empl.Employee_ID=@Employee_ID

		FETCH NEXT FROM cur INTO @Employee_ID,@Contract_ID,@CL_StartDate,@CL_RegisterDate,@CL_ExpiredDate,@Type
		END
		CLOSE cur
		DEALLOCATE cur
		select pl.*
			,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
		,empl.Sex,empl.Address_Permanent,[dbo].[non_unicode_convert](empl.Address_Permanent) as Address_PermanentEN,empl.Address_Temporary,[dbo].[non_unicode_convert](empl.Address_Temporary) as Address_TemporaryEN,empl.Tel
		,empl.ID_number,empl.ID_place,empl.ID_date,empl.BirthDate,empl.BirthPlace
		from
		@BangPhuLucHD pl
		left join
		smartbooks_employee empl
		on pl.Employee_ID=empl.Employee_ID
	end
END

--select * from [dbo].[udf_HopDongTuSinh]('1900-1-1',getdate(),1,'VN',NULL,NULL,NULL,NULL,NULL,NULL,null)




GO
