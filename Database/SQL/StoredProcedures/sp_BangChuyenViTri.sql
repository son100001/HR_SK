CREATE PROCEDURE [dbo].[sp_BangChuyenViTri] 
	-- Add the parameters for the stored procedure here
	--exec [sp_BangChuyenViTri] '2019-5-1','2019-6-30',3
	--exec [dbo].[sp_BangChuyenViTri] '1900-1-1','2019-10-03',1,'VN',NULL,NULL,NULL,NULL,NULL,NULL,N'C13804'

	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,
	@LAN varchar(10)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Emp nvarchar (50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @EffectiveDate datetime,@PositionNew varchar(200),@JobCodeNew varchar(200), @Remark nvarchar(max),@InsertDate datetime,@UserName nvarchar(50),@KiemTraDuLieuNhap nvarchar(max)
		,@Emp_ID nvarchar(50),@Period datetime
	if @TypeOfReport=1 or @TypeOfReport=3 begin --lịch sử chuyển vị trí
		create table #tabTransfer (Period datetime,[ID] int,[Employee_ID] nvarchar(50),StartedDate datetime, Factory_Name nvarchar(100), DepartmentName nvarchar(100), SectionName nvarchar(100), ChucDanhName nvarchar(100),[InsertDate] datetime,[UserName] nvarchar(50))

		DECLARE cur_Employee CURSOR LOCAL FOR
		select Employee_ID from smartbooks_employee--[dbo].[udf_Smartbooks_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc)
			where Employee_ID in (select distinct Employee_ID from HR_Transfer) and (case when @Emp is null or @Emp='' then '' else Employee_ID end)=ISNULL(@Emp,'')
		OPEN  cur_Employee
		FETCH NEXT FROM cur_Employee INTO @Emp_ID
		WHILE @@FETCH_STATUS = 0
		BEGIN
			DECLARE cur_Period CURSOR LOCAL FOR
			select distinct EffectiveDate from HR_Transfer where Employee_ID=@Emp_ID and EffectiveDate between @fromdate and @todate and TypeOfTransfer in ('Position','JobCode','ChucDanh','PositionCategory_ID','Position_ID')
			OPEN  cur_Period
			FETCH NEXT FROM cur_Period INTO @Period
			WHILE @@FETCH_STATUS = 0
			BEGIN
				insert into #tabTransfer ([Period], [ID], [Employee_ID], StartedDate, Factory_Name, DepartmentName, SectionName, ChucDanhName, [InsertDate])
				select @Period as Period,
				null as ID,
				isnull(tf_pos.Employee_ID, tf_cd.Employee_ID) as Employee_ID,
				null as StartedDate,

				-- SK2_P2-Production Office_P2-P0-1-01
				-- Sk2_SK2-P3
				-- Factory_Name
				case when tf_pos.TransferCode is not null 
					and CHARINDEX('_', tf_pos.TransferCode) >= 1 
					then LEFT(tf_pos.TransferCode, CHARINDEX('_', tf_pos.TransferCode)-1) 
					else null 
				end as Factory_Name, 

				-- DepartmentName
				case when tf_pos.TransferCode is not null 
					and CHARINDEX('_', tf_pos.TransferCode) > 0 
					and CHARINDEX('_', tf_pos.TransferCode, CHARINDEX('_', tf_pos.TransferCode) + 1) > 0
					-- SUBSTRING ( expression , start , length )
					-- CHARINDEX ( expressionToFind , expressionToSearch [ , start_location
					then SUBSTRING(tf_pos.TransferCode, CHARINDEX('_', tf_pos.TransferCode)+1, -- Tìm dấu _ thứ nhất
					-- LENGTH
					CHARINDEX('_', tf_pos.TransferCode, CHARINDEX('_', tf_pos.TransferCode) + 1) -- Tìm dấu _ thứ hai sau dấu _ thứ nhất
                  - CHARINDEX('_', tf_pos.TransferCode) - 1 ) -- Vị trí dấu 2 - dấu 1 sẽ là chiều dài DepartmentName cần tìm
				  when tf_pos.TransferCode is not null
					 and CHARINDEX('_', tf_pos.TransferCode) > 0
					 and CHARINDEX('_', tf_pos.TransferCode, CHARINDEX('_', tf_pos.TransferCode) + 1) = 0 -- Tức là không có dấu _ thứ 2 sẽ trả về 0
					 and LEN(tf_pos.TransferCode) > CHARINDEX('_', tf_pos.TransferCode)
					then SUBSTRING(
							tf_pos.TransferCode,
							CHARINDEX('_', tf_pos.TransferCode) + 1,
							LEN(tf_pos.TransferCode) - CHARINDEX('_', tf_pos.TransferCode) -- Tổng độ dài chuỗi - phần độ dài đầu chuỗi dấu _
						 )
					else null 
				end as DepartmentName,

				-- SectionName
				case when tf_pos.TransferCode is not null 
					and CHARINDEX('_', tf_pos.TransferCode) > 0
					and CHARINDEX('_', tf_pos.TransferCode, CHARINDEX('_', tf_pos.TransferCode)+1) > 0
					and LEN(tf_pos.TransferCode) > CHARINDEX('_', tf_pos.TransferCode, CHARINDEX('_', tf_pos.TransferCode)+1)
					then SUBSTRING(
						tf_pos.TransferCode,
						CHARINDEX('_', tf_pos.TransferCode, CHARINDEX('_', tf_pos.TransferCode)+1) +1, -- Cộng thêm 1 bởi vì lấy sau dấu _ thứ 2 
						LEN(tf_pos.TransferCode) - CHARINDEX('_', tf_pos.TransferCode, CHARINDEX('_', tf_pos.TransferCode)+1) -- Độ dài chuỗi - phần độ dài chuỗi ở dấu _ thứ 2
						)
					else null
				end as SectionName,
				tf_cd.TransferCode as ChucDanhName,
				null as InsertDate
				from
				(
					select top 1 * from HR_Transfer
					where TypeOfTransfer = 'Position'
						and EffectiveDate <= @Period
						and Employee_ID = @Emp_ID
					order by EffectiveDate desc) as tf_pos
				full outer join 
				(
					select top 1 * from HR_Transfer
					where TypeOfTransfer = 'ChucDanh'
						and EffectiveDate <= @Period
						and Employee_ID = @Emp_ID
					order by EffectiveDate desc) as tf_cd
				on tf_pos.Employee_ID = tf_cd.Employee_ID

				--select @Period,tf.* from
				--(select TypeOfTransfer,max(EffectiveDate) as EffectiveDate from HR_Transfer where Employee_ID=@Emp_ID and EffectiveDate<=@Period and TypeOfTransfer in ('Position','JobCode','ChucDanh','PositionCategory_ID','Position_ID') group by TypeOfTransfer) as tfmax
				--left join
				--(select * from HR_Transfer where Employee_ID=@Emp_ID and TypeOfTransfer in ('Position','JobCode','ChucDanh','PositionCategory_ID','Position_ID'))tf
				--on tfmax.TypeOfTransfer=tf.TypeOfTransfer and tfmax.EffectiveDate=tf.EffectiveDate
			FETCH NEXT FROM cur_Period INTO @Period
			END
			CLOSE cur_Period
			DEALLOCATE cur_Period
		FETCH NEXT FROM cur_Employee INTO @Emp_ID
		END
		CLOSE cur_Employee
		DEALLOCATE cur_Employee

		if @TypeOfReport=1 begin--xem theo chiều ngang

			select 
				tf.Period,
				tf.Employee_ID,
				[dbo].[udf_FullName](empl.Employee_Firstname, empl.Employee_LastName) as FullName,
				empl.StartedDate,
				tf.Factory_Name,
				tf.DepartmentName,
				tf.SectionName,
				tf.ChucDanhName,
				tf.InsertDate,
				tf.UserName
			from
				#tabTransfer tf
			left join
				smartbooks_employee empl
					on tf.Employee_ID = empl.Employee_ID
			order by 
				tf.Employee_ID, tf.Period



			--select pvtable.Period,pvTable.Employee_ID,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName) as FullName, empl.StartedDate
			--,pvtable.Position,pvtable.JobCode,pvtable.chucdanh,pvtable.PositionCategory_ID,pvtable.Position_ID
			--from
			--(
			--	select Period,Employee_ID,TransferCode,TypeOfTransfer from #tabTransfer
			--)SourceTable
			--PIVOT (max(TransferCode) FOR TypeOfTransfer IN (Position,JobCode,ChucDanh,PositionCategory_ID,Position_ID)) pvTable
			--left join
			--smartbooks_employee empl
			--on pvTable.Employee_ID=empl.Employee_ID
		end else if @TypeOfReport=3 begin--xem theo chiều dọc
			select 
				tf.Period,
				[dbo].[udf_FullName](empl.Employee_Firstname, empl.Employee_LastName) as FullName,
				tf.Employee_ID,
				empl.StartedDate,
				tf.Factory_Name,
				tf.DepartmentName,
				tf.SectionName,
				tf.ChucDanhName,
				tf.InsertDate,
				tf.UserName
			from
				#tabTransfer tf
			left join
				SmartBooks_Employee empl
					on tf.Employee_ID = empl.Employee_ID
			order by 
				tf.Employee_ID, tf.Period



			--select tf.Period,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName) as FullName
			--,tf.Employee_ID, empl.StartedDate,tf.TransferCode
			--,isnull(p.Name,'')
			--	+(case when @LAN='VN' then isnull(jc.NameVN,'') when @LAN='EN' then isnull(jc.NameEN,'') else isnull(jc.NameKR,'') end) as Name
			--,tf.EffectiveDate,tf.TypeOfTransfer,tf.AssignType,tf.Remark,tf.InsertDate,tf.UserName,tf.ID
			--from
			--#tabTransfer tf
			--left join
			--SmartBooks_Employee empl
			--on tf.Employee_ID=empl.Employee_ID
			--left join
			--udf_Position(@LAN,0) p
			--on tf.TypeOfTransfer='Position' and tf.TransferCode COLLATE DATABASE_DEFAULT=p.code
			--left join
			--[dbo].[HR_JobCodeCategory] jc
			--on tf.TypeOfTransfer='JobCode' and tf.TransferCode COLLATE DATABASE_DEFAULT=jc.JobCode
		end
	end else if @TypeOfReport=2 begin --chuyển vị trí theo lưới
		select isnull(empl.TeamCode,isnull(empl.SectionCode,isnull(empl.DepartmentCode,isnull(empl.Factory_ID,'')))) as Position,empl.Position_ID,empl.PositionCategory_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.Employee_ID, @PositionNew as PositionNew,@JobCodeNew as JobCodeNew,@EffectiveDate as EffectiveDate,@Remark as Remark,@KiemTraDuLieuNhap as KiemTraDuLieuNhap,@InsertDate as InsertDate,@UserName as UserName
		from
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		where empl.StartedDate<=@fromdate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)
	end else if @TypeOfReport=4 begin--xem chuỷen chức vụ
		select empl.Position,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName) as FullName
		,tf.*
		from
		HR_Transfer tf
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		on tf.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
		where
		tf.EffectiveDate between @fromdate and @todate and empl.Employee_ID is not null
		and tf.TypeOfTransfer='Position_ID'
	end else if @TypeOfReport=5 begin--xem chuỷen RFID
		select empl.Position,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName) as FullName
		,tf.*
		from
		HR_Transfer tf
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		on tf.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
		where
		tf.EffectiveDate between @fromdate and @todate and empl.Employee_ID is not null
		and tf.TypeOfTransfer='RFID'
	end
END




GO
