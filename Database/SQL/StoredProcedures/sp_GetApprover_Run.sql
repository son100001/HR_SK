CREATE procedure [dbo].[sp_GetApprover_Run]
@Account nvarchar(50),
@TypeOfReport int,
@LAN nvarchar(50) = 'VN',
@Date datetime = null
as
begin
--select * from udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,GETDATE())
--exec sp_GetApprover 'C10851',1,'EN'
--exec sp_GetApprover_Run NULL,1,'VN'
	set nocount on;
	if @Date is null set @Date = GETDATE();
	Declare @ShiftName nvarchar(50)
	select @ShiftName = Shiftname from udf_DangKyCa (@Date,@Date,181,null,null,null,null,null,null,@Account)
	
	Declare @rtnGetApprover table (Factory_ID nvarchar(50), DepartmentCode nvarchar(200), SectionName nvarchar(200), ChucDanh nvarchar(200), Employee_ID nvarchar(50), Code nvarchar(200), [Name] nvarchar(500), ChiGuiThongBao nvarchar(200)
									, primary key (Employee_ID, Code))

	if (@Shiftname not like N'%shift3') 
	begin
		Declare @EmployeeFilter table (
			Employee_ID nvarchar(50), FullName nvarchar(100), Factory_ID nvarchar(200),
			DepartmentName nvarchar(200), SectionName nvarchar(200),
			ChucDanh nvarchar(200), LvDuyet nvarchar(50), DepartmentCode1 nvarchar(200), primary key (Employee_ID)
		);

		insert into @EmployeeFilter (Employee_ID, FullName, Factory_ID, DepartmentName, SectionName, ChucDanh, LvDuyet, DepartmentCode1)
		select Employee_ID, dbo.udf_FullName(Employee_Firstname,Employee_LastName) as FullName, FactoryName, DepartmentName, SectionName, ChucDanh, LvDuyet, DepartmentCode1
		from udf_EmployeeFilter('VN',null,null,null,null,null,null,null,@Date)
		where Employee_ID not in ('BOD01','BOD02');

		Insert into @EmployeeFilter (Employee_ID, FullName, Factory_ID, DepartmentName, SectionName, ChucDanh, LvDuyet)
		values ('BOD02', 'Kim Jemin', null, null, null, 'Director', 1)
	
		Insert into @EmployeeFilter (Employee_ID, FullName, Factory_ID, DepartmentName, SectionName, ChucDanh, LvDuyet)
		values ('BOD01', 'Kim Dong Woo', null, null, null, 'General Director', 0)

		-- Tạo CTE dữ liệu gốc
		;WITH BaseCTE AS (
			select empl.Employee_ID, empl.Factory_ID, empl.DepartmentName, empl.SectionName, empl.ChucDanh, empl.LvDuyet,
				ld.ID, ld.LoaiDuyet, ld.LuongDuyet, ld.ThuTuDuyet, ld.CapBacDuyet, isnull(ld.ChiGuiThongBao,0) as ChiGuiThongBao
				, isnull(emplCap5.Employee_ID, isnull(emplCap4.Employee_ID, isnull(emplCap3.Employee_ID,isnull(emplCap2.Employee_ID,isnull(emplCap1.Employee_ID,emplCap0.Employee_ID))))) as Approver
				, isnull(emplCap5.FullName, isnull(emplCap4.FullName, isnull(emplCap3.FullName,isnull(emplCap2.FullName,isnull(emplCap1.FullName,emplCap0.FullName))))) as FullNameApprover
			from [User] us
			left join 
			@EmployeeFilter empl 
			on us.Employee_ID = empl.Employee_ID
			left join 
			HR_LuongDuyet ld 
			on empl.LvDuyet = ld.LuongDuyet
			left join 
			@EmployeeFilter emplCap5 
			on ld.CapBacDuyet = emplCap5.LvDuyet and empl.DepartmentName = emplCap5.DepartmentName and emplCap5.LvDuyet = 5
			left join 
			@EmployeeFilter emplCap4 
			--on ld.CapBacDuyet = emplCap4.LvDuyet and left(empl.DepartmentCode1, case when empl.LvDuyet = 6 then 5 else 2 end) = left(emplCap4.DepartmentCode1,case when empl.LvDuyet = 6 then 5 else 2 end) and emplCap4.LvDuyet = 4
			on ld.CapBacDuyet = emplCap4.LvDuyet and empl.Factory_ID = emplCap4.Factory_ID and emplCap4.LvDuyet = 4
			left join 
			@EmployeeFilter emplCap3 
			on ld.CapBacDuyet = emplCap3.LvDuyet and (case when empl.Factory_ID <> 'SK2' then 'SK1' else empl.Factory_ID end) = (case when emplCap3.Factory_ID <> 'SK2' then 'SK1' else emplCap3.Factory_ID end)
				and emplCap3.LvDuyet = 3 and emplCap3.Employee_ID in ('C14908','C10537')
			left join 
			@EmployeeFilter emplCap2 
			on ld.CapBacDuyet = emplCap2.LvDuyet and emplCap2.LvDuyet = 2
			left join 
			@EmployeeFilter emplCap1 
			on ld.CapBacDuyet = emplCap1.LvDuyet and emplCap1.LvDuyet = 1
			left join 
			@EmployeeFilter emplCap0 
			on ld.CapBacDuyet = emplCap0.LvDuyet and emplCap0.LvDuyet = 0
			where case when @Account is null then '' else us.UserName end = case when @Account is null then '' else @Account end --and isnull(ld.ChiGuiThongBao,0) = 0
		)

		-- Đưa vào bảng tạm
		SELECT 
			Employee_ID, Factory_ID, DepartmentName, SectionName, ChucDanh,
			ThuTuDuyet, Approver,FullNameApprover,ChiGuiThongBao
		INTO #ApproverTemp
		FROM BaseCTE;

		--select * from #ApproverTemp

		-- Tạo CTE cho từng ThuTuDuyet
		WITH D1 AS (
			SELECT Employee_ID, Factory_ID, DepartmentName, SectionName, ChucDanh, Approver as Approver1, FullNameApprover as FullNameApprover1, ChiGuiThongBao
			FROM #ApproverTemp WHERE ThuTuDuyet = 1
		)
		, D2 AS (
			SELECT Employee_ID, Approver as Approver2, FullNameApprover as FullNameApprover2, ChiGuiThongBao
			FROM #ApproverTemp WHERE ThuTuDuyet = 2
		)
		, D3 AS (
			SELECT Employee_ID, Approver as Approver3, FullNameApprover as FullNameApprover3, ChiGuiThongBao
			FROM #ApproverTemp WHERE ThuTuDuyet = 3
		)
		, D4 AS (
			SELECT Employee_ID, Approver as Approver4, FullNameApprover as FullNameApprover4, ChiGuiThongBao
			FROM #ApproverTemp WHERE ThuTuDuyet = 4
		)
		, D5 AS (
			SELECT Employee_ID, Approver as Approver5, FullNameApprover as FullNameApprover5, ChiGuiThongBao
			FROM #ApproverTemp WHERE ThuTuDuyet = 5
		)

		-- Combine CROSS JOIN theo yêu cầu
		insert into @rtnGetApprover (Factory_ID, DepartmentCode, SectionName, ChucDanh, Employee_ID, Code, [Name], ChiGuiThongBao)
		SELECT
			D1.Factory_ID, D1.DepartmentName, D1.SectionName, D1.ChucDanh, D1.Employee_ID
			, D1.Approver1 + (case when D2.Approver2 is not null and D2.ChiGuiThongBao = 0 then ',' + D2.Approver2 else '' end) + (case when D3.Approver3 is not null and D3.ChiGuiThongBao = 0 then ',' + D3.Approver3 else '' end) 
				+ (case when D4.Approver4 is not null and D4.ChiGuiThongBao = 0 then ',' + D4.Approver4 else '' end) + (case when D5.Approver5 is not null and D5.ChiGuiThongBao = 0 then ',' + D5.Approver5 else '' end) as Code
			,FullNameApprover1 + (case when D2.FullNameApprover2 is not null and D2.ChiGuiThongBao = 0 then ', ' + D2.FullNameApprover2 else '' end) + (case when D3.FullNameApprover3 is not null and D3.ChiGuiThongBao = 0 then ', ' + D3.FullNameApprover3 else '' end) 
				+ (case when D4.FullNameApprover4 is not null and D4.ChiGuiThongBao = 0 then ', ' + D4.FullNameApprover4 else '' end) + (case when D5.FullNameApprover5 is not null and D5.ChiGuiThongBao = 0 then ', ' + D5.FullNameApprover5 else '' end) as [Name]
			, (case when D1.Approver1 is not null and D1.ChiGuiThongBao = 1 then ',' + D2.Approver2 else '' end) + (case when D2.Approver2 is not null and D2.ChiGuiThongBao = 1 then ',' + D2.Approver2 else '' end) + (case when D3.Approver3 is not null and D3.ChiGuiThongBao = 1 then ',' + D3.Approver3 else '' end) 
				+ (case when D4.Approver4 is not null and D4.ChiGuiThongBao = 1 then ',' + D4.Approver4 else '' end) + (case when D5.Approver5 is not null and D5.ChiGuiThongBao = 1 then ',' + D5.Approver5 else '' end) as ChiGuiThongBao
			
			--, emplCap3.Employee_ID as Level3
		FROM D1
		LEFT JOIN D2 ON D1.Employee_ID = D2.Employee_ID
		LEFT JOIN D3 ON D1.Employee_ID = D3.Employee_ID
		LEFT JOIN D4 ON D1.Employee_ID = D4.Employee_ID
		LEFT JOIN D5 ON D1.Employee_ID = D5.Employee_ID
		where D1.Approver1 is not null;
		--left join 
		--@EmployeeFilter emplCap3 
		--on (case when D1.Factory_ID <> 'SK2' then 'SK1' else D1.Factory_ID end) = (case when emplCap3.Factory_ID <> 'SK2' then 'SK1' else emplCap3.Factory_ID end)
		--		and emplCap3.LvDuyet = 3 and emplCap3.Employee_ID in ('C14908','C10537');
	end else begin
		insert into @rtnGetApprover (Factory_ID, DepartmentCode, SectionName, ChucDanh, Employee_ID, Code, [Name], ChiGuiThongBao)
		select Null as Factory_ID, Null as DepartmentCode, Null as SectionName, Null as ChucDanh, @Account as Employee_ID
				, N'BV' as Code, case @LAN when N'VN' then N'Bảo vệ' when N'EN' then 'Guard' when N'KR' then N'경비원' when N'JP' then N'警備員' when N'CN' then N'保安' when 'KH' then N'បាវេ' end as [Name]
				, Null as ChiGuiThongBao
	end

	insert into @rtnGetApprover (Employee_ID, Code, [Name], ChiGuiThongBao)
	values ('All', 'C14908', N'Võ Thị Ngọc Hà', Null)

	insert into @rtnGetApprover (Employee_ID, Code, [Name], ChiGuiThongBao)
	values ('All', 'C10537', N'Lê Thị Hiệp', Null)

	Insert into @rtnGetApprover (Employee_ID, Code, [Name], ChiGuiThongBao)
	values ('All', 'BOD02', N'Kim Jemin', null)
	
	Insert into @rtnGetApprover (Employee_ID, Code, [Name], ChiGuiThongBao)
	values ('All', 'BOD01', N'Kim Dong Woo', null)
	
	Insert into @rtnGetApprover (Employee_ID, Code, [Name], ChiGuiThongBao)
	values ('All', 'BV', N'Bảo vệ', null)

	Delete HR_GetApprover
	where (case when @Account is null then '' else Employee_ID end = case when @Account is null then '' else @Account end)
			or (Employee_ID = 'All')
	
	insert into HR_GetApprover (Factory_ID, DepartmentCode, SectionCode, ChucDanh, Employee_ID, Code, [Name], ChiGuiThongBao)
	select * from @rtnGetApprover

	select * from @rtnGetApprover

	DROP TABLE #ApproverTemp;
end

GO
