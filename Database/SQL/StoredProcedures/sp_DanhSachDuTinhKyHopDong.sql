CREATE PROCEDURE [dbo].[sp_DanhSachDuTinhKyHopDong] 
	-- Add the parameters for the stored procedure here
--exec [dbo].[sp_DanhSachDuTinhKyHopDong] '2019-9-1','2019-9-30'
	@fromdate datetime,
	@todate datetime,
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Employee_ID nvarchar(50),@CL_StartDate datetime,@CL_ExpiredDate datetime,@Contract_ID nvarchar(50),@Contract_IDWillSign as nvarchar(50),@ContractFlow nvarchar(50),@No int,@NumberOfDay int,@NumberOfMonth float,@NumberOfYear float
		,@isOnlyWorkingDay bit
	DECLARE @tab table(Employee_ID nvarchar(50),LoaiHD nvarchar(50),NgayHieuLuc datetime,NgayHetHan datetime)
	---Thêm hợp đồng tiếp theo của những người đã ký trước đó
	DECLARE cur_ CURSOR LOCAL FOR
	select * from (select ctl.Employee_ID,ctl.[Type] as Contract_ID,ctl.CL_ExpiredDate,empl.ContractFlow
	from
	[dbo].[SmartBooks_ContractList] ctl
	left join
	SmartBooks_Employee empl
	on ctl.Employee_ID=empl.Employee_ID
	where [CL_ExpiredDate] between @fromdate and @todate and ctl.CL_FatherID is null
	union all
	-- Lấy hợp đồng hết hạn trong thời gian nghỉ sinh
	select ctl.Employee_ID,ctl.[Type] as Contract_ID,HDNghiSinh.ToDate as CL_ExpiredDate,empl.ContractFlow from
	(
		select ctl.Employee_ID,max(ctl.CL_StartDate) as CL_StartDate,erml.ToDate from
		(select * from [dbo].[HR_EmployeeRegisMaternityLeave] where leaveType_ID = (select LeaveType_ID from SmartBooks_LeaveType where isMaternityLeave=1) and todate between @fromdate and @todate) as erml
		left join
		[dbo].[SmartBooks_ContractList] ctl
		on erml.Employee_ID COLLATE DATABASE_DEFAULT=ctl.Employee_ID and ctl.CL_ExpiredDate between erml.Fromdate and erml.ToDate and ctl.CL_FatherID is null
		where ctl.Employee_ID is not null
		group by ctl.Employee_ID,erml.ToDate
	)HDNghiSinh
	left join
	[dbo].[SmartBooks_ContractList] ctl
	on HDNghiSinh.Employee_ID=ctl.Employee_ID and HDNghiSinh.CL_StartDate=CTL.CL_StartDate and ctl.CL_FatherID is null
	left join
	SmartBooks_Employee empl
	on ctl.Employee_ID=empl.Employee_ID)abc

	OPEN  cur_
	FETCH NEXT FROM cur_ INTO @Employee_ID,@Contract_ID,@CL_ExpiredDate,@ContractFlow
	WHILE @@FETCH_STATUS = 0
	BEGIN
		set @No=0
		select @No=No_ from [dbo].[HR_ContractFlow] where [ContractFlow]=@ContractFlow and @Contract_ID in (select * from [dbo].[Split](Contract_ID,','))
		if @No>0 begin
			set @Contract_IDWillSign='' set @NumberOfDay=0 set @NumberOfMonth=0 set @NumberOfYear=0 set @CL_StartDate=@CL_ExpiredDate+1
			select @Contract_IDWillSign=(case when CHARINDEX( ',', Contract_ID,1)>0 then REVERSE(SUBSTRING(REVERSE(Contract_ID),0,CHARINDEX(',',REVERSE(Contract_ID)))) else Contract_ID end) from [dbo].[HR_ContractFlow] where [ContractFlow]=@ContractFlow and No_=@No+1
			select @CL_ExpiredDate=[dbo].[udf_TraVeNgayHetHanHD](@CL_StartDate,NumberOfDay,NumberOfMonth,NumberOfYear,isOnlyWorkingDay) from [dbo].[SmartBooks_Contract] where Contract_ID=@Contract_IDWillSign
			if not exists (select * from SmartBooks_ContractList where Employee_ID=@Employee_ID and CL_StartDate=@CL_StartDate) begin
				insert into @tab(Employee_ID,LoaiHD,NgayHieuLuc,NgayHetHan) values(@Employee_ID,@Contract_IDWillSign,@CL_StartDate,@CL_ExpiredDate)
			end
		end
	FETCH NEXT FROM cur_ INTO @Employee_ID,@Contract_ID,@CL_ExpiredDate,@ContractFlow
	END
	CLOSE cur_
	DEALLOCATE cur_
	--Thêm hợp đồng của những người mới ký lần đầu
	insert into @tab
	select empl.Employee_ID,(case when CHARINDEX( ',', ctf.Contract_ID,1)>0 then REVERSE(SUBSTRING(REVERSE(ctf.Contract_ID),0,CHARINDEX(',',REVERSE(ctf.Contract_ID)))) else ctf.Contract_ID end),empl.StartedDate
	,[dbo].[udf_TraVeNgayHetHanHD](empl.ComStartedDate,ct.NumberOfDay,ct.NumberOfMonth,ct.NumberOfYear,ct.isOnlyWorkingDay)
	from
	(
		select empl.Employee_ID,empl.StartedDate,empl.ComStartedDate
			,isnull(empl.[ContractFlow],isnull(posc.ContractFlow,isnull(pos.ContractFlow,isnull(team.ContractFlow,isnull(sect.ContractFlow,dept.ContractFlow))))) as ContractFlow
		from
		udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,isnull(@todate,getdate())) empl
		left join
		[dbo].[SmartBooks_Department] dept
		on empl.[DepartmentCode]=dept.[DepartmentCode]
		left join
		[dbo].[SmartBooks_Section] sect
		on empl.[SectionCode]=sect.[SectionCode]
		left join
		[dbo].[SmartBooks_Team] team
		on empl.TeamCode=team.TeamCode
		left join
		[dbo].[SmartBooks_Position] pos
		on empl.Position_ID=pos.Position_ID
		left join
		[dbo].[SmartBooks_PositionCategory] posc
		on empl.[PositionCategory_ID]=posc.[PositionCategory_ID]
	)empl
	left join
	[dbo].[HR_ContractFlow] ctf
	on empl.ContractFlow=ctf.ContractFlow and ctf.No_=1
	left join
	SmartBooks_Contract ct
	on ctf.Contract_ID=ct.Contract_ID
	where empl.StartedDate between @fromdate and @todate and Employee_ID not in (select Employee_ID from SmartBooks_ContractList where CL_StartDate between @fromdate and @todate and CL_FatherID is null)
	
	--show
	select empl.PositionFullName,empl.PositionName,tab.Employee_ID,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName)as FullName,empl.StartedDate
			,tab.LoaiHD,tab.NgayHieuLuc,tab.NgayHetHan
	from
	@tab tab
	left join
	udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,isnull(@todate,getdate())) empl
	on tab.Employee_ID=empl.Employee_ID
	left join
	(select * from [dbo].[HR_EmployeeRegisMaternityLeave] where leaveType_ID in (select LeaveType_ID from SmartBooks_LeaveType where isMaternityLeave=1)) as erml
	on tab.Employee_ID COLLATE DATABASE_DEFAULT=erml.Employee_ID and tab.NgayHieuLuc>=erml.Fromdate and (erml.ToDate is null or erml.ToDate>=tab.NgayHieuLuc)
	where (empl.TernimationDate is null or empl.TernimationDate>@todate)
		and erml.Employee_ID is null

END




GO
