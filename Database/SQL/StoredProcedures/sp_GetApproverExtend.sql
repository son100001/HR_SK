CREATE procedure [dbo].[sp_GetApproverExtend]
@Account nvarchar(50),
@TypeOfReport int,
@LAN nvarchar(50) = 'VN',
@Date datetime = null
as
begin
--select * from udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,GETDATE())
--exec sp_GetApproverExtend 'C10851',1,'EN'
	/*set nocount on;
	if @Date is null set @Date = GETDATE();

	Declare @EmployeeFilter table (
		Employee_ID nvarchar(50), FullName nvarchar(200), Factory_ID nvarchar(200),
		DepartmentCode nvarchar(200), position nvarchar(200), PositionCategory_ID nvarchar(200),
		ChucDanh nvarchar(200), LvDuyet nvarchar(50), primary key (Employee_ID)
	);

	Declare @BaseCTE table (Employee_ID nvarchar(50), Factory_ID nvarchar(200), DepartmentCode nvarchar(200), position nvarchar(200), PositionCategory_ID nvarchar(200), ChucDanh nvarchar(200), LvDuyet int
								, ID int, LoaiDuyet nvarchar(200), LuongDuyet nvarchar(200), ThuTuDuyet nvarchar(200), CapBacDuyet nvarchar(200), ChiGuiThongBao nvarchar(50), Approver nvarchar(50), FullNameApprover nvarchar(500))

	insert into @EmployeeFilter
	select Employee_ID, dbo.udf_FullName(Employee_Firstname,Employee_LastName), Factory_ID, DepartmentCode, position, PositionCategory_ID, ChucDanh, LvDuyet
	from udf_EmployeeFilter(@LAN,null,null,null,null,null,null,null,@Date)
		where Employee_ID not in ('BOD01','BOD02');

	Insert into @EmployeeFilter (Employee_ID, FullName, Factory_ID, DepartmentCode, position, PositionCategory_ID, ChucDanh, LvDuyet)
	values ('BOD02', 'Kim Jemin', null, null, null, null, 'Director', 1)
	
	Insert into @EmployeeFilter (Employee_ID, FullName, Factory_ID, DepartmentCode, position, PositionCategory_ID, ChucDanh, LvDuyet)
	values ('BOD01', 'Kim Dong Woo', null, null, null, null, 'General Director', 0)

	-- Tạo CTE dữ liệu gốc
	insert into @BaseCTE (Employee_ID, Factory_ID, DepartmentCode, position, PositionCategory_ID, ChucDanh, LvDuyet, ID, LoaiDuyet, LuongDuyet, ThuTuDuyet, CapBacDuyet, ChiGuiThongBao, Approver, FullNameApprover)
	select empl.Employee_ID, empl.Factory_ID, empl.DepartmentCode, empl.position, empl.PositionCategory_ID, empl.ChucDanh, empl.LvDuyet,
		ld.ID, ld.LoaiDuyet, ld.LuongDuyet, ld.ThuTuDuyet, ld.CapBacDuyet, ld.ChiGuiThongBao
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
	on ld.CapBacDuyet = emplCap5.LvDuyet and left(empl.PositionCategory_ID,5) = left(emplCap5.PositionCategory_ID,5) and emplCap5.LvDuyet = 5
	left join 
	@EmployeeFilter emplCap4 
	on ld.CapBacDuyet = emplCap4.LvDuyet and left(empl.PositionCategory_ID, case when empl.LvDuyet = 6 then 5 else 2 end) = left(emplCap4.PositionCategory_ID,case when empl.LvDuyet = 6 then 5 else 2 end) and emplCap4.LvDuyet = 4
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
	where us.UserName = @Account and isnull(ld.ChiGuiThongBao,0) = 0

	-- Đưa vào bảng tạm
	SELECT 
		Employee_ID, Factory_ID, DepartmentCode, position, PositionCategory_ID, ChucDanh,
		ThuTuDuyet, Approver,FullNameApprover
	INTO #ApproverTemp
	FROM @BaseCTE;

	-- Tạo CTE cho từng ThuTuDuyet
	WITH D1 AS (
		SELECT Employee_ID, Factory_ID, DepartmentCode, position, PositionCategory_ID, ChucDanh, Approver as Approver1, FullNameApprover as FullNameApprover1
		FROM #ApproverTemp WHERE ThuTuDuyet = 1
	)
	, D2 AS (
		SELECT Employee_ID, Approver as Approver2, FullNameApprover as FullNameApprover2
		FROM #ApproverTemp WHERE ThuTuDuyet = 2
	)
	, D3 AS (
		SELECT Employee_ID, Approver as Approver3, FullNameApprover as FullNameApprover3
		FROM #ApproverTemp WHERE ThuTuDuyet = 3
	)
	, D4 AS (
		SELECT Employee_ID, Approver as Approver4, FullNameApprover as FullNameApprover4
		FROM #ApproverTemp WHERE ThuTuDuyet = 4
	)
	, D5 AS (
		SELECT Employee_ID, Approver as Approver5, FullNameApprover as FullNameApprover5
		FROM #ApproverTemp WHERE ThuTuDuyet = 5
	)

	-- Combine CROSS JOIN theo yêu cầu
	SELECT
		D1.Factory_ID, D1.DepartmentCode, D1.position, D1.PositionCategory_ID, D1.ChucDanh, D1.Employee_ID
		, D1.Approver1 + (case when D2.Approver2 is not null then ',' + D2.Approver2 else '' end) + (case when D3.Approver3 is not null then ',' + D3.Approver3 else '' end) 
			+ (case when D4.Approver4 is not null then ',' + D4.Approver4 else '' end) + (case when D5.Approver5 is not null then ',' + D5.Approver5 else '' end) as Code
		,FullNameApprover1 + (case when D2.FullNameApprover2 is not null then ', ' + D2.FullNameApprover2 else '' end) + (case when D3.FullNameApprover3 is not null then ', ' + D3.FullNameApprover3 else '' end) 
			+ (case when D4.FullNameApprover4 is not null then ', ' + D4.FullNameApprover4 else '' end) + (case when D5.FullNameApprover5 is not null then ', ' + D5.FullNameApprover5 else '' end) as [Name]
	FROM D1
	LEFT JOIN D2 ON D1.Employee_ID = D2.Employee_ID
	LEFT JOIN D3 ON D1.Employee_ID = D3.Employee_ID
	LEFT JOIN D4 ON D1.Employee_ID = D4.Employee_ID
	LEFT JOIN D5 ON D1.Employee_ID = D5.Employee_ID
	union all
	select Factory_ID, DepartmentCode, position, PositionCategory_ID, ChucDanh, Employee_ID
			, Approver
			, FullNameApprover
	from
	@BaseCTE

	DROP TABLE #ApproverTemp;
	*/
	set nocount on;
	if @Date is null set @Date = GETDATE();
	Declare @ShiftName nvarchar(50)
	select @ShiftName = Shiftname from udf_DangKyCa (@Date,@Date,181,null,null,null,null,null,null,@Account)

	if (@Shiftname not like N'%shift3') 
	begin
		Select * from
		HR_GetApprover
		where Employee_ID = @Account --or Employee_ID = 'All'
		union
		select null as Factory_ID, null as DepartmentCode, null as SectionCode, null as PositionCategory_ID, null as ChucDanh
				, Employee_ID as Employee_ID, Employee_ID as Code, Employee_Firstname + ' ' + Employee_LastName as FullName, null
		from
		SmartBooks_Employee
	end else begin
		select Null as Factory_ID, Null as DepartmentCode, Null as SectionName, Null as ChucDanh, @Account as Employee_ID
				, N'BV' as Code, case @LAN when N'VN' then N'Bảo vệ' when N'EN' then 'Guard' when N'KR' then N'경비원' when N'JP' then N'警備員' when N'CN' then N'保安' when 'KH' then N'បាវេ' end as [Name]
				, Null as ChiGuiThongBao
	end
end

GO
