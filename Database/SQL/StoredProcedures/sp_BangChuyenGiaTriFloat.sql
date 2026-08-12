CREATE PROCEDURE [dbo].[sp_BangChuyenGiaTriFloat]
	-- Add the parameters for the stored procedure here
	--exec [dbo].[sp_BangChuyenGiaTriFloat]'2019-7-1','2019-7-15',1
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@emp nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @NgayDauThang datetime,@NgayCuoiThang datetime
	set @NgayDauThang=DATEADD(day,1-DATEPART(day,@fromdate),@fromdate)
	set @NgayCuoiThang=DATEADD(month,1,@NgayDauThang)-1
	if @TypeOfReport in (1,2) begin-- danh sách nặng nhọc độc hại
		IF OBJECT_ID('tempdb..#tab') IS NOT NULL DROP TABLE #tab
		select
				tf.Employee_ID, dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName, empl.StartedDate, empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
				, tf.Fromdate, tf.Todate, tf.Remark, tf.InsertDate, tf.UserName
		into #tab
		from
		[dbo].[HR_TransferFloatType] tf
		left join
		[dbo].[udf_EmployeeFilter_Full](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		on tf.Employee_ID=empl.Employee_ID
		--left join
		--HR_Disable d
		--on tf.Employee_ID=d.Employee_ID
		--left join
		--HR_HazardCategory hc
		--on empl.HAZARD=hc.HAZARD
		--left join
		--HR_JobCodeCategory jc
		--on empl.JobCode=jc.JobCode
		where empl.Employee_ID is not null 
				and 
				(
					tf.Fromdate between @fromdate and @todate
					or 
					@fromdate between tf.Fromdate and isnull(tf.Todate,@todate+1) 
					or
					@todate between tf.Fromdate and isnull(tf.Todate,@todate+1)
				)
				and
				(
					(@TypeOfReport = 1 and isnull(empl.TernimationDate,@todate + 1) > @todate) 
					or 
					(@TypeOfReport = 2 and empl.TernimationDate is not null and empl.TernimationDate >= @fromdate)
				)
		if @TypeOfReport in (1,2) begin--xem all
			select * from #tab
		end 
		--else if @TypeOfReport=2 begin
		--	select * from #tab where Position_ID in ('265','270','275','280','360','370')
		--end else if @TypeOfReport=3 begin --người thôi việc
		--	select * from #tab where TernimationDate between @fromdate and @todate
		--end else if @TypeOfReport=4 begin--Danh sách nặng nhọc độc hại (Adjustment)
		--	select
		--	t.DepartmentName,t.TeamName,t.Position_ID,t.PositionName,t.FullName,t.Employee_ID
		--	,t.Employee_Status,t.ComStartedDate,t.TernimationDate,t.HAZARD,t.HazardLevel,t.JobName,t.VL,tfOld.VL as OldVL
		--	from
		--	#tab t
		--	left join
		--	(
		--		select tf.* from
		--		(select Employee_ID,max(Fromdate) as Fromdate from HR_TransferFloatType where Fromdate<@NgayDauThang group by Employee_ID) maxtf
		--		left join
		--		HR_TransferFloatType tf
		--		on maxtf.Employee_ID=tf.Employee_ID and maxtf.Fromdate=tf.Fromdate
		--	)tfOld
		--	on t.Employee_ID=tfOld.Employee_ID
		--	where isnull(tfOld.VL,0)<>t.VL
		--end
	end
END




GO
