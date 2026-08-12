CREATE PROCEDURE [dbo].[sp_InThe]
	-- Add the parameters for the stored procedure here
	--exec [dbo].[sp_InThe] 5,'VN','C11130'
	@TypeOfReport int=1,
	@LAN nvarchar(50)='VN',
	@ListOfKey nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @TypeOfReport=1 begin -- in thông tin nhân viên
	select empl.*, sempl.Picture from 
		[dbo].[udf_EmployeeFilter](@LAN,null,null,null,null,null,null,null,GETDATE()) empl 
		left join 
		SmartBooks_Employee sempl
		on empl.Employee_ID = sempl.Employee_ID
		where empl.Employee_ID in (select data from Split(@ListOfKey,','))
		select * from [dbo].[udf_EmployeeFilter](@LAN,null,null,null,null,null,null,null,GETDATE()) where Employee_ID in (select data from Split(@ListOfKey,','))
	end else if @typeofreport=2 begin -- in thư mời
		declare @Employee_ID nvarchar(50),@fromdate datetime,@Reason nvarchar(50)
		DECLARE @ThuMoi TABLE
		(
			Employee_ID nvarchar(50),
			Ngay datetime,
			DanhSachNgayNghiKP nvarchar(100),
			So nvarchar(50)
		)
		DECLARE cur CURSOR FOR    
		select Employee_ID,fromdate,Reason from [dbo].[HR_EmployeeRegisMaternityLeave] where ID in (select data from Split(@ListOfKey,','))
		OPEN  cur     
		FETCH NEXT FROM cur INTO @Employee_ID,@fromdate,@Reason
		WHILE @@FETCH_STATUS = 0    
		BEGIN
			insert into @ThuMoi
			select employee_id,@fromdate,DanhSachNgayNghiKP,@Reason from [udf_TraVeNghiKhongPhep5LanTrong30Ngay](dateadd(month,-1,@fromdate-1),@fromdate-1,null,null,null,null,null,null,@Employee_ID)
		FETCH NEXT FROM cur INTO @Employee_ID,@fromdate,@Reason
		END    
		CLOSE cur    
		DEALLOCATE cur
		select empl.PositionFullName,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
				,empl.[ID_number],empl.[ID_date],empl.[ID_place],FactoryName,DepartmentName,SectionName,TeamName,empl.PositionName,empl.PositionCategoryName
				,empl.startedDate,empl.birthdate
				,tm.*
		from
		@thumoi tm
		left join
		[dbo].[udf_EmployeeFilter](@LAN,null,null,null,null,null,null,null,getdate()) empl
		on tm.Employee_ID=empl.Employee_ID
	end else if @typeofreport=3 begin -- in hồ sơ nhân sự
		--quá trình công tác tại công ty
		declare @Emp_ID nvarchar(50),@Period datetime
		declare @tabTransfer as table (Period datetime,[ID] int,[Employee_ID] nvarchar(50),[TransferCode] varchar(50),EffectiveDate datetime,TypeOfTransfer varchar(50),AssignType varchar(50),[Remark] nvarchar(max),[InsertDate] datetime,[UserName] nvarchar(50))
		DECLARE cur_Employee CURSOR LOCAL FOR
		select Employee_ID from [dbo].[udf_EmployeeFilter](@LAN,null,null,null,null,null,null,null,getdate())
		OPEN  cur_Employee
		FETCH NEXT FROM cur_Employee INTO @Emp_ID
		WHILE @@FETCH_STATUS = 0
		BEGIN
			DECLARE cur_Period CURSOR LOCAL FOR
			select distinct EffectiveDate from HR_Transfer where Employee_ID=@Emp_ID and TypeOfTransfer in ('Position','JobCode','ChucDanh','PositionCategory_ID','Position_ID')
			OPEN  cur_Period
			FETCH NEXT FROM cur_Period INTO @Period
			WHILE @@FETCH_STATUS = 0
			BEGIN
				insert into @tabTransfer
				select @Period,tf.* from
				(select TypeOfTransfer,max(EffectiveDate) as EffectiveDate from HR_Transfer where Employee_ID=@Emp_ID and EffectiveDate<=@Period and TypeOfTransfer in ('Position','JobCode','ChucDanh','PositionCategory_ID','Position_ID') group by TypeOfTransfer) as tfmax
				left join
				(select * from HR_Transfer where Employee_ID=@Emp_ID and TypeOfTransfer in ('Position','JobCode','ChucDanh','PositionCategory_ID','Position_ID'))tf
				on tfmax.TypeOfTransfer=tf.TypeOfTransfer and tfmax.EffectiveDate=tf.EffectiveDate
			FETCH NEXT FROM cur_Period INTO @Period
			END
			CLOSE cur_Period
			DEALLOCATE cur_Period
		FETCH NEXT FROM cur_Employee INTO @Emp_ID
		END
		CLOSE cur_Employee
		DEALLOCATE cur_Employee

		select [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.BirthDate,empl.FactoryName,empl.Employee_ID,empl.StartedDate
			,anh.Picture
			,qtct.LoaiQuaTrinh
			--,qtct.FromDate
			,cast(year(qtct.FromDate) as varchar)+case when qtct.ToDate is null then '' else '~'+cast(year(qtct.ToDate) as varchar) end as KhoangThoiGian
			,qtct.[Description]
		 from
		[dbo].[udf_EmployeeFilter](@LAN,null,null,null,null,null,null,null,GETDATE()) empl
		left join
		SmartBooks_Employee anh
		on empl.Employee_ID=anh.Employee_ID
		left join
		HR_QuaTrinhHocTapCongTac qtct
		on empl.Employee_ID=qtct.Employee_ID
		left join
		HR_Category c
		on qtct.LoaiQuaTrinh=c.Category and c.CategoryFather='LoaiQuaTrinh'
		where empl.Employee_ID in (select data from Split(@ListOfKey,','))
		union all
		select [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.BirthDate,empl.FactoryName,empl.Employee_ID,empl.StartedDate
			,anh.Picture
			,'4.KhenThuongKyLuat' as LoaiQuaTrinh--N'KHEN THƯỞNG - KỶ LUẬT' as LoaiQuaTrinh
			--,disci.DisciplineBegin as fromdate
			,convert(varchar, disci.DisciplineBegin, 103) as KhoangThoiGian
			,disci.Reason as [Description]
		 from
		[dbo].[udf_EmployeeFilter](@LAN,null,null,null,null,null,null,null,GETDATE()) empl
		left join
		SmartBooks_Employee anh
		on empl.Employee_ID=anh.Employee_ID
		left join
		HR_Discipline disci
		on empl.Employee_ID=disci.Employee_ID
		where empl.Employee_ID in (select data from Split(@ListOfKey,','))
		union all
		select 
			[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.BirthDate,empl.FactoryName,empl.Employee_ID,empl.StartedDate
			,anh.Picture
			,'3.QuaTrinhCongTacTaiCongTy' AS LoaiQuaTrinh --N'QUÁ TRÌNH CÔNG TÁC TẠI CÔNG TY' as LoaiQuaTrinh
			--,quatrinhtaicty.Period as fromdate
			,convert(varchar, quatrinhtaicty.Period, 103) as KhoangThoiGian
			,N'Bộ phận: '+f.NameVN+N'; Chức vụ:'+p.Position_NameVN as [Description]
		from
		[dbo].[udf_EmployeeFilter](@LAN,null,null,null,null,null,null,null,GETDATE()) empl
		left join
		SmartBooks_Employee anh
		on empl.Employee_ID=anh.Employee_ID
		left join
		(
			select pvtable.Period,pvTable.Employee_ID,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName) as FullName
				,pvtable.Position,pvtable.JobCode,pvtable.chucdanh,pvtable.PositionCategory_ID,pvtable.Position_ID
				from
				(
					select Period,Employee_ID,TransferCode,TypeOfTransfer from @tabTransfer
				)SourceTable
				PIVOT (max(TransferCode) FOR TypeOfTransfer IN (Position,JobCode,ChucDanh,PositionCategory_ID,Position_ID)) pvTable
				left join
				[dbo].[udf_EmployeeFilter](@LAN,null,null,null,null,null,null,null,getdate()) empl
				on pvTable.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
		) quatrinhtaicty
		on empl.Employee_ID=quatrinhtaicty.Employee_ID
		left join
		HR_Factory f
		on quatrinhtaicty.Position like f.Factory_ID+'%'
		left join
		SmartBooks_Position p
		on quatrinhtaicty.Position_ID=p.Position_ID
		where empl.Employee_ID in (select data from Split(@ListOfKey,',')) 
	END
	
	
	ELSE if @TypeOfReport=4 begin -- in thông tin nhân viên
		select empl.*,emplPic.Picture
		FROM
		[dbo].[udf_EmployeeFilter_Full](@LAN,null,null,null,null,null,null,null,GETDATE()) empl
		left join
		SmartBooks_Employee emplPic
		on empl.Employee_ID=emplPic.Employee_ID
		where empl.Employee_ID in (select data from Split(@ListOfKey,','))
	END
	

	ELSE if @TypeOfReport=5
	begin
		select *
			,Employee_Firstname+(case when Employee_LastName is null or Employee_LastName='' then '' else ' '+Employee_LastName end) as FullName, 
			CONVERT(varchar(10),ID_date,103) as ID_Date_Only --103 style dd/MM/yyyy
		from [dbo].[udf_EmployeeFilter_Full](@LAN,null,null,null,null,null,null,null,GETDATE())
		where Employee_ID in (select data from Split(@ListOfKey,','))
	end
END




GO
