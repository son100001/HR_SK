create proc [dbo].[sp_BangHealthCheck]
@fromdate datetime,
@todate datetime,
@TypeOfReport int = 1,
@LAN nvarchar(50)='VN',
@UserName nvarchar(50)=null,
@fact nvarchar(50)=null,
@dept nvarchar(50)=null,
@sect nvarchar(50)=null,
@team nvarchar(50)=null,
@pos nvarchar(50)=null,
@posc nvarchar(50)=null,
@emp nvarchar(MAX)=null

As
Begin
	if @TypeOfReport = 1 begin
		select dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName, hc.*
		from
		HR_HealthCheck hc
		left join
		SmartBooks_Employee empl
		on hc.Employee_ID = empl.Employee_ID
		where hc.HealthCheckDate between @Fromdate and @Todate and (case when @emp is null or @emp = '' then '' else empl.Employee_ID end) in (case when  @emp is null or @emp = '' then '' else (select data from Split(@emp,',')) end)
	end else if @TypeOfReport = 2 begin
		select hc.HealthCheckDate, hc.HospitalName
		from
		HR_HealthCheck hc
		where Employee_ID = @emp
		order by HealthCheckDate
	end
end
GO
