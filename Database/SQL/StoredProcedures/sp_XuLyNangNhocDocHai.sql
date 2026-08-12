
CREATE PROCEDURE [dbo].[sp_XuLyNangNhocDocHai]
	-- Add the parameters for the stored procedure here
	--exec sp_XuLyNangNhocDocHai '2019-7-2','2019-7-9',2,null,null,null,null,null,null,'admin'
	@fromdate datetime,
	@todate datetime,
	@TypeOfProcess int,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Block_Date datetime,@ThongBao nvarchar(max),@NgayDauThang datetime, @NgayCuoiThang datetime
	select @Block_Date=Block_Date from HR_Khoa where [TableName]='HR_TransferFloatType_HeavyAndToxic' and Block_User=@UserName
	if @Block_Date<@todate or @Block_Date is null begin
		set @NgayDauThang=DATEADD(day,1-DATEPART(day,@fromdate),@fromdate)
		set @NgayCuoiThang=DATEADD(month,1,@NgayDauThang)-1
		IF OBJECT_ID('tempdb..#tab') IS NOT NULL DROP TABLE #tab
		select empl.Employee_ID,@NgayDauThang as EffectiveDate,'HeavyAndToxic' as TypeOfTransfer
				,(case when Position_ID in ('250','260','265','24','25') then 0
						when Position_ID in ('280','270') or (Position_ID in ('380','390') and empl.JobCode='92015') then 5
						when tfNhapTayTruocDo.Employee_ID is not null and tfjobcode.Employee_ID is null then tfNhapTayTruocDo.VL
						else (case when d.Employee_ID is not null and isnull(hc.ToxicPercent,0)>5 then 5 else isnull(hc.ToxicPercent,0) end)
					end) as VL,(case when tfNhapTayTruocDo.Employee_ID is not null and tfjobcode.Employee_ID is null then tfNhapTayTruocDo.HAZARD when d.Employee_ID is not null then 'N0000' else empl.HAZARD end) as HAZARD
				,GETDATE() as InsertDate,@UserName as UserName,empl.TernimationDate,tf.VL as OldVL into #tab
			from
			[dbo].[udf_EmployeeFilter]('VN',@fact,@dept,@sect,@team,null,null,null,isnull(@todate,GETDATE())) empl
			left join
			[dbo].[HR_HazardCategory] hc
			on empl.Hazard=hc.HAZARD
			left join
			HR_Disable d
			on empl.Employee_ID=d.Employee_ID
			left join
			HR_TransferFloatType tf
			on empl.Employee_ID=tf.Employee_ID and tf.EffectiveDate between @NgayDauThang and @NgayCuoiThang and tf.TypeOfTransfer='HeavyAndToxic'
			left join
			(
				select tf.* from 
				(
					select Employee_ID,max(EffectiveDate) as EffectiveDate from HR_TransferFloatType where EffectiveDate<@NgayDauThang and TypeOfTransfer='HeavyAndToxic' and InsertSource='NhapTay' group by Employee_ID
				)tfmax
				left join
				HR_TransferFloatType tf
				on tfmax.Employee_ID=tf.Employee_ID and tfmax.EffectiveDate=tf.EffectiveDate and TypeOfTransfer='HeavyAndToxic' and InsertSource='NhapTay'
			)tfNhapTayTruocDo
			on empl.Employee_ID=tfNhapTayTruocDo.Employee_ID
			left join
			HR_Transfer tfjobcode
			on empl.Employee_ID=tfjobcode.Employee_ID and tfjobcode.EffectiveDate between tfNhapTayTruocDo.EffectiveDate and @todate and tfjobcode.TypeOfTransfer='JobCode'
			where empl.ComStartedDate<=@todate and (empl.TernimationDate is null or empl.TernimationDate>=@fromdate) AND isnull(tf.InsertSource,'')<>'NhapTay'
		if @TypeOfProcess=1 begin--xử lý toàn bộ nguoi dang lam viec
			delete HR_TransferFloatType where TypeOfTransfer='HeavyAndToxic' and EffectiveDate between @NgayDauThang and @NgayCuoiThang and Employee_ID in (select Employee_ID from SmartBooks_Employee where ComstartedDate<=@todate and (TernimationDate is null or TernimationDate>@NgayCuoiThang)) and isnull(InsertSource,'')<>'NhapTay'
			insert into HR_TransferFloatType (Employee_ID,EffectiveDate,TypeOfTransfer,VL,HAZARD,InsertDate,UserName)
			select Employee_ID,EffectiveDate,TypeOfTransfer,VL,HAZARD,InsertDate,UserName from #tab where Employee_ID in (select Employee_ID from SmartBooks_Employee where ComstartedDate<=@todate and (TernimationDate is null or TernimationDate>@NgayCuoiThang))
		end else if @TypeOfProcess=2 begin--xử lý người thôi việc
			insert into HR_TransferFloatType (Employee_ID,EffectiveDate,TypeOfTransfer,VL,HAZARD,InsertDate,UserName)
			select Employee_ID,EffectiveDate,TypeOfTransfer,VL,HAZARD,InsertDate,UserName
			from #tab where TernimationDate between @fromdate and @todate and OldVL is null
		end
 	end else begin
		set @ThongBao=N'Dữ liệu đã bị khóa ngày '+convert(varchar, @Block_Date, 103)+';'
	end
	if isnull(@ThongBao,'')='' begin
		set @ThongBao=N'Xử lý thành công'
	end
	select @ThongBao as ThongBao
END




GO
