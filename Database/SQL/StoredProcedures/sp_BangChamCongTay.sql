CREATE PROCEDURE [dbo].[sp_BangChamCongTay]
	-- Add the parameters for the stored procedure here
	--exec sp_BangChamCongTay 6,2019,1,'vn'
	@Month int,
	@Year int,
	@TypeOfReport int=1,
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
	declare @NgayDauThang datetime,@NgayCuoiThang datetime,@NgayDauNam datetime
	set @NgayDauThang=cast(@Year as varchar)+'-'+cast(@Month as varchar)+'-1'
	set @NgayCuoiThang=DATEADD(month,1,@NgayDauThang)-1
	set @NgayDauNam=cast(@Year as varchar)+'-1-1'
	if @TypeOfReport=1 begin
		select empl.DepartmentName as DepartmentCode,empl.DepartmentName+(case when empl.TeamName is null then '' else ' | '+empl.TeamName end) as TeamCode,empl.Employee_ID
			,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,OTLuyTien.OTLuyTien,(case when @LAN='VN' then jc.NameVN when @LAN='EN' then jc.NameEN else jc.NameKR end) as JCName
			,Annual.Annual
			,al.PhepNamDuocHuong
		from 
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@NgayCuoiThang) empl
		left join
		(
			select wt.Employee_ID,SUM(wt)as OTLuyTien from
			HR_WTDaily wt
			left join
			HR_LoaiCong lc
			on wt.MaCong=lc.MaCong
			where ngay between @NgayDauNam and @NgayDauThang-1 and isnull(lc.isWorkingTime,0)=0 and InsertSource not in ('Sun-Alt','TCLT') 
			group by Employee_ID
		)OTLuyTien
		on empl.Employee_ID=OTLuyTien.Employee_ID
		left join
		(
			select Employee_ID
					,sum(case when lt.PhepNam=1 then datediff(day,case when fromdate>=@NgayDauNam then fromdate else @NgayDauNam end,case when ToDate>@NgayDauThang-1 then @NgayDauThang-1 else ToDate end)+1 else 0 end) as Annual
					from
					HR_EmployeeRegisMaternityLeave erml
					left join
					SmartBooks_LeaveType lt
					on erml.LeaveType_ID=lt.LeaveType_ID
					 where Fromdate<=@NgayDauThang-1 and ToDate>=@NgayDauNam
					group by Employee_ID
		)Annual
		on empl.Employee_ID=Annual.Employee_ID
		left join
		HR_JobCodeCategory jc
		on empl.JobCode=jc.JobCode
		left join
		HR_AnnualLeave al
		on empl.Employee_ID=al.Employee_ID
		where empl.ComStartedDate<=@NgayCuoiThang and (empl.TernimationDate is null or empl.TernimationDate>@NgayDauThang)
	end
END




GO
