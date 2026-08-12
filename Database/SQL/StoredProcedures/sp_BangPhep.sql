-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec sp_BangPhep '2019-4-1','2019-4-30',1,'VN'

CREATE PROCEDURE [dbo].[sp_BangPhep]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
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
	
	if @TypeOfReport=1 begin
		select
		empl.DepartmentName, empl.SectionName, empl.TeamName, empl.PositionName, empl.PositionCategoryName
		,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
		,erl.[LeaveType_ID],erl.HourLeave,erl.[DateLeave],erl.KhungGio,erl.Approval,erl.InsertSource,erl.Remark,erl.InsertDate,erl.UserName,erl.UpdateDate,erl.UpdateUserName,erl.ID
		from
		[dbo].[HR_EmpRegisLeave] erl
		left join
		[dbo].[udf_Smartbooks_Employee](@LAN) empl
		on erl.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
		where (case when @fact is null or @fact='' then '' else empl.Factory_ID end)=(case when @fact is null or @fact='' then '' else @fact end)
			and (case when @dept is null or @dept='' then '' else empl.DepartmentCode end)=(case when @dept is null or @dept='' then '' else @dept end)
			and (case when @sect is null or @sect='' then '' else empl.SectionCode end)=(case when @sect is null or @sect='' then '' else @sect end)
			and (case when @team is null or @team='' then '' else empl.TeamCode end)=(case when @team is null or @team='' then '' else @team end)
			and (case when @pos is null or @pos='' then '' else empl.Position_ID end)=(case when @pos is null or @pos='' then '' else @pos end)
			and (case when @posc is null or @posc='' then '' else empl.PositionCategory_ID end)=(case when @posc is null or @posc='' then '' else @posc end)
			and erl.DateLeave between @fromdate and @todate
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID, StartedDate,erl.DateLeave
	end else if @TypeOfReport=2 begin
		--declare @fromdate datetime, @todate datetime
		--set @fromdate ='2018-08-01'
		--set @todate ='2018-08-10'
		declare @NgayDauNam as datetime
		set @NgayDauNam=dateadd(day,1-datepart(day,@fromdate),dateadd(month,1-datepart(month,@fromdate),@fromdate))
		declare @s nvarchar(max); set @s=''
		select @s=@s + '[' + CONVERT(varchar(12),Date_,111) + '],' From [udf_BangThoiGian](@fromdate, @todate)
		set @s= left(@s,len(@s)-1)
		 IF OBJECT_ID('tempdb..#tab') IS NOT NULL DROP TABLE #tab
		 create table #tab(Employee_ID nvarchar(50))
		 Declare @dtNext datetime,@sql nvarchar(max)
		 set @dtNext=@fromdate
		 while @dtNext<=@todate begin
			set @sql='alter table #tab add [' + CONVERT(varchar(12),@dtNext,103) + '] nvarchar(20)'
			exec (@sql)
			set @dtNext=@dtNext+1
		 end
		set @sql = 'insert into #tab
					SELECT * FROM  
					(	SELECT Employee_ID,dateleave,LeaveType_ID+'''+'/'+'''+cast(HourLeave as varchar) as abc
						FROM [dbo].[HR_EmpRegisLeave] where dateleave between @fromdate and @todate) AS SourceTable  
					PIVOT  
					( 
						
						Max(abc) FOR dateleave IN (@s1)
					) AS PivotTable '

		set @sql = REPLACE(@sql, '@s1', @s)
		EXECUTE sp_executesql @sql
				  , N'@fromdate datetime, @todate datetime'
				  , @fromdate = @fromdate  
				  , @todate = @todate
		select
		empl.DepartmentName, empl.SectionName, empl.TeamName, empl.PositionName, empl.PositionCategoryName
		,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
		,datediff(month,(case when empl.StartedDate<@NgayDauNam then @NgayDauNam else empl.StartedDate end),getdate())+1 as SoThangDiLamTrongNam
		,tpn.TongPhepNamDuocHuong,tpn.TongPhepNamDaNghi,tpn.TongPhepNamTon,isnull(tpn.TongPhepNamDuocHuong,0)+isnull(tpn.TongPhepNamTon,0)-isnull(tpn.TongPhepNamDaNghi,0) as TongPhepNamConLai
		,erl.*
		from
		[dbo].[udf_Smartbooks_Employee](@LAN) empl
		left join
		#tab erl
		on empl.Employee_ID COLLATE DATABASE_DEFAULT=erl.Employee_ID
		left join
		[dbo].[udf_TinhPhepNam](DATEPART(YEAR,@fromdate),'0',@fact,@dept,@sect,@team,@pos,@posc) tpn
		on empl.Employee_ID COLLATE DATABASE_DEFAULT=tpn.Employee_ID
		where (case when @fact is null or @fact='' then '' else empl.Factory_ID end)=(case when @fact is null or @fact='' then '' else @fact end)
			and (case when @dept is null or @dept='' then '' else empl.DepartmentCode end)=(case when @dept is null or @dept='' then '' else @dept end)
			and (case when @sect is null or @sect='' then '' else empl.SectionCode end)=(case when @sect is null or @sect='' then '' else @sect end)
			and (case when @team is null or @team='' then '' else empl.TeamCode end)=(case when @team is null or @team='' then '' else @team end)
			and (case when @pos is null or @pos='' then '' else empl.Position_ID end)=(case when @pos is null or @pos='' then '' else @pos end)
			and (case when @posc is null or @posc='' then '' else empl.PositionCategory_ID end)=(case when @posc is null or @posc='' then '' else @posc end)
			and empl.StartedDate<=@todate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID, empl.StartedDate
	end
END




GO
