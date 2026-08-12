CREATE FUNCTION [dbo].[udf_HopDongTuSinh]
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_HopDongTuSinh]('1990-01-01','2030-05-01',1,'VN',null,null,null,null,null,null,'C6920')
	--SELECT * FROM [dbo].[udf_GanLuongVaoHopDong]('2020-01-01','2021-07-31',1) WHERE Contract_ID=N'004/HĐLĐ/CAPGLOBAL'
	@fromdate datetime,
	@todate datetime,
	@FollowCL_StartDate bit=1,
	@LAN varchar(50),
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Empl nvarchar(50)=null
)
RETURNS  @rtnHopDongTuSinh TABLE 
(
    -- columns returned by the function
    ID int,Contract_ID nvarchar(50),[Employee_ID] nvarchar(50),CL_RegisterDate datetime,CL_ExpiredDate datetime,CL_StartDate datetime,[status] bit,[Type]nvarchar(50),CL_FatherID nvarchar(50),ContractAnnexID nvarchar(50),CL_Remark nvarchar(max),InsertSource nvarchar(50),InsertDate datetime,UserName nvarchar(50),primary key ([Employee_ID],CL_StartDate,Contract_ID)
)
AS
BEGIN
	DECLARE @ID int,@StartedDate datetime,@CL_StartDate datetime,@CL_ExpiredDate datetime,@Employee_ID nvarchar(50),@ContractFlow varchar(50),@NumberOfDay int,@NumberOfMonth int,@NumberOfYear int,@isOnlyWorkingDay bit,@Contract_ID varchar(50),@Type varchar(50)
		,@InsertDate datetime,@UserName varchar(50),@InsertSource varchar(50),@status bit,@CL_Remark nvarchar(max),@CL_FatherID varchar(50),@NoContractFlow varchar(2)
		,@CL_StartDateDaLuu datetime,@CL_ExpiredDateDaluu datetime,@SalaryPercent float

	declare @LuongHDTuDanhSachHD table(Employee_ID nvarchar(50),[Type] nvarchar(50),CL_StartDate datetime,CL_ExpiredDate datetime)
	insert into @LuongHDTuDanhSachHD
	select ctl.Employee_ID,ctl.[Type],ctl.CL_StartDate,ctl.CL_ExpiredDate from
	(select Employee_ID,max(CL_StartDate) as CL_StartDate from SmartBooks_ContractList where [Type] in (select Contract_ID from SmartBooks_Contract where isnull(isAppendix,0)=0) group by Employee_ID) ctlMax
	left join
	SmartBooks_ContractList ctl
	on ctlMax.Employee_ID=ctl.Employee_ID and ctlMax.CL_StartDate=ctl.CL_StartDate
	where
	ctl.[Type] in (select Contract_ID from SmartBooks_Contract where isnull(isAppendix,0)=0)
	
	set @ID=1
	DECLARE cur CURSOR LOCAL FOR
	select empl.Employee_ID,empl.StartedDate,isnull(lhd.[Type],isnull(empl.ContractFlow,isnull(team.ContractFlow,isnull(sect.ContractFlow,dept.ContractFlow)))) as ContractFlow,lhd.CL_StartDate,lhd.CL_ExpiredDate
	from
	udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Empl,isnull(@todate,getdate())) empl
	left join
	@LuongHDTuDanhSachHD lhd
	on empl.Employee_ID=lhd.Employee_ID
	left join
	SmartBooks_Department dept
	on empl.DepartmentCode=dept.Factory_ID+'_'+dept.DepartmentCode
	left join
	SmartBooks_Section sect
	on empl.SectionCode=sect.Factory_ID+'_'+sect.DepartmentCode+'_'+sect.SectionCode
	left join
	SmartBooks_Team team
	on empl.TeamCode=team.Factory_ID+'_'+team.DepartmentCode+'_'+team.SectionCode+'_'+team.TeamCode
	where StartedDate<=@todate and (TernimationDate is null or TernimationDate>'1990-1-1')
	order by Employee_ID
	OPEN  cur
	FETCH NEXT FROM cur INTO @Employee_ID,@StartedDate,@ContractFlow,@CL_StartDateDaLuu,@CL_ExpiredDateDaLuu
	WHILE @@FETCH_STATUS = 0
	BEGIN
		set @CL_StartDate=isnull(@CL_StartDateDaLuu,@StartedDate)
		DECLARE cur1 CURSOR LOCAL FOR
		select ctf.Contract_ID,ct.NumberOfDay,ct.NumberOfMonth,ct.NumberOfYear,ct.isOnlyWorkingDay,ctf.No_,ct.SalaryPercent
		from
		HR_ContractFlow ctf
		left join
		SmartBooks_Contract ct
		on ctf.Contract_ID=ct.Contract_ID
			where ContractFlow=@ContractFlow order by ctf.No_ asc
		OPEN  cur1
		FETCH NEXT FROM cur1 INTO @Type,@NumberOfDay,@NumberOfMonth,@NumberOfYear,@isOnlyWorkingDay,@NoContractFlow,@SalaryPercent
		WHILE @@FETCH_STATUS = 0
		BEGIN
			set @CL_ExpiredDate=isnull(@CL_ExpiredDateDaLuu,[dbo].[udf_TraVeNgayHetHanHD](@CL_StartDate,@NumberOfDay,@NumberOfMonth,@NumberOfYear,@isOnlyWorkingDay))
			if @CL_StartDateDaLuu is null begin
				if @CL_StartDate between '1990-1-1' and @todate begin
					insert into @rtnHopDongTuSinh
					values(null--ID
					,@Employee_ID+convert(varchar,@CL_StartDate,12) --Contract_ID
					,@Employee_ID
					,@CL_StartDate--CL_RegisterDate
					,@CL_ExpiredDate
					,@CL_StartDate--@CL_StartDate
					,@status--status
					,@Type--Type
					,@CL_FatherID
					,null
					,@CL_Remark--CL_Remark
					,'Auto'
					,@InsertDate
					,@UserName
					)
				end
			end
			set @CL_StartDate=@CL_ExpiredDate+1
			set @CL_StartDateDaLuu=null set @CL_ExpiredDateDaLuu=null
			set @ID=@id+1
		FETCH NEXT FROM cur1 INTO @Type,@NumberOfDay,@NumberOfMonth,@NumberOfYear,@isOnlyWorkingDay,@NoContractFlow,@SalaryPercent
		END
		CLOSE cur1
		DEALLOCATE cur1
	FETCH NEXT FROM cur INTO @Employee_ID,@StartedDate,@ContractFlow,@CL_StartDateDaLuu,@CL_ExpiredDateDaLuu
	END
	CLOSE cur
	DEALLOCATE cur

	-- xóa hợp đồng đã tồn tại
	delete @rtnHopDongTuSinh from
	@rtnHopDongTuSinh hdts
	inner join
	SmartBooks_ContractList ctl
	on hdts.Employee_ID=ctl.Employee_ID and hdts.[Type]=ctl.[Type]

	--xóa hợp đồng ký sau khi đã thôi việc
	delete @rtnHopDongTuSinh from
	@rtnHopDongTuSinh hdts
	inner join
	SmartBooks_Employee empl
	on hdts.Employee_ID=empl.Employee_ID and hdts.CL_StartDate>=empl.TernimationDate

	--Nhập hợp đồng đã tồn tại
	insert into @rtnHopDongTuSinh
	select [ID],isnull([Contract_ID],Employee_ID+convert(varchar,CL_StartDate,12)),[Employee_ID],[CL_RegisterDate],[CL_ExpiredDate],[CL_StartDate],[status],[Type],[CL_FatherID],ContractAnnexID,[CL_Remark],[InsertSource],[InsertDate],[UserName] from SmartBooks_ContractList
	where CL_StartDate between '1990-1-1' and @todate

	-- đánh số thứ tự HĐ (Stt ký theo mã)
	update hdts set hdts.Contract_ID= Right(hdts.Employee_ID,4) + '-' + cast(Row# as nvarchar(4)) + '/' + cast(year(hdts.CL_StartDate) as varchar(4))
	FROM 
	(select ROW_NUMBER() OVER(Partition by Employee_ID ORDER BY Employee_ID,CL_StartDate ASC) AS Row#,* from @rtnHopDongTuSinh where [Type] <> 'PLHD' and [Type] not in (select Contract_ID from SmartBooks_Contract where SalaryPercent=85)) hdtsSTT
	INNER JOIN
	@rtnHopDongTuSinh hdts
	on hdtsSTT.Employee_ID=hdts.Employee_ID AND hdtsSTT.CL_StartDate=hdts.CL_StartDate
	where hdts.[Type] not in (select Contract_ID from SmartBooks_Contract where SalaryPercent=85) and hdts.[Type] <> 'PLHD'

	--PLHD
	update hdts set hdts.Contract_ID = left(hdtsmax.Contract_ID,len(hdtsmax.Contract_ID) - 4) + cast(year(hdts.CL_StartDate) as varchar(4)), CL_FatherID = hdtsmax.Contract_ID
	from
	@rtnHopDongTuSinh hdts
	left join
	(
		select hdts.Employee_ID, CL_StartDate as MaxStartDate, CL_ExpiredDate as MaxExpiredDate, Contract_ID
		from
		@rtnHopDongTuSinh hdts
		where hdts.[Type] not in (select Contract_ID from SmartBooks_Contract where SalaryPercent=85) and hdts.CL_StartDate > '2022-09-30' and hdts.[Type] <> 'PLHD'
		--group by hdts.Employee_ID
	) hdtsmax
	on hdtsmax.Employee_ID = hdts.Employee_ID and hdts.CL_StartDate between MaxStartDate and isnull(MaxExpiredDate,hdts.CL_StartDate)
	where hdts.[Type] = 'PLHD' and hdtsmax.MaxStartDate > '2022-09-30'

	-- xóa dữ liệu lọc
	if isnull(@Empl,'')='' begin
		delete @rtnHopDongTuSinh where (case when @FollowCL_StartDate=1 then CL_StartDate else CL_ExpiredDate end) not between @fromdate and @todate
	end else begin
		delete @rtnHopDongTuSinh where (case when @FollowCL_StartDate=1 then CL_StartDate else CL_ExpiredDate end) not between @fromdate and @todate
							or Employee_ID<>@Empl
	end
	
	----Nhập phụ lục
	----ID int,Contract_ID nvarchar(50),[Employee_ID] nvarchar(50),CL_RegisterDate datetime,CL_ExpiredDate datetime,CL_StartDate datetime,[Type]nvarchar(50),CL_Remark nvarchar(max),primary key (Employee_ID,CL_StartDate)
	--insert into @rtnHopDongTuSinh
	--select [ID],[Contract_ID],[Employee_ID],[CL_RegisterDate],[CL_ExpiredDate],[CL_StartDate],[status],[Type],[CL_FatherID],ContractAnnexID,[CL_Remark],[InsertSource],[InsertDate],[UserName]
	--from SmartBooks_ContractList
	--WHERE [Type] in (select Contract_ID from SmartBooks_Contract where isAppendix=1)
	--	and CL_StartDate between @fromdate and @todate
	--	and (case when isnull(@Empl,'')='' then '' else Employee_ID end)=isnull(@Empl,'')
	RETURN
END


GO
