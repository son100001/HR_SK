CREATE PROCEDURE [dbo].[sp_BangDangKyCa]
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
	@posc nvarchar(50)=null,
	@emp nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ID int, @ShiftName as nvarchar(50),@TimeDate datetime,@Remark nvarchar(max),@InsertDate datetime,@UserName nvarchar(50),@KiemTraDuLieuNhap nvarchar(max)
	if @TypeOfReport=1 begin
		select
		empl.Position
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate,erts.*
		from
		[dbo].[HR_EmpRegisTimeSheet] erts
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,GETDATE())) empl
		on erts.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
		where erts.TimeDate between @fromdate and @todate and empl.Employee_ID is not null
		order by empl.Position,empl.Position_ID,empl.PositionCategory_ID, StartedDate,erts.TimeDate
	end else if @TypeOfReport=2 begin
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
					(	SELECT Employee_ID,TimeDate,ShiftName
						FROM [dbo].[HR_EmpRegisTimeSheet] where TimeDate between @fromdate and @todate) AS SourceTable  
					PIVOT  
					( 
						
						Max(ShiftName) FOR TimeDate IN (@s1)
					) AS PivotTable '

		set @sql = REPLACE(@sql, '@s1', @s)
		EXECUTE sp_executesql @sql
				  , N'@fromdate datetime, @todate datetime'
				  , @fromdate = @fromdate  
				  , @todate = @todate
		select
		empl.Position
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
		,erl.*
		from
		#tab erl
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,GETDATE())) empl
		on erl.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
		where empl.Employee_ID is not null
		order by empl.Position,empl.Position_ID,empl.PositionCategory_ID, empl.StartedDate
	end else if @TypeOfReport=3 begin
		select empl.Position,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.Employee_ID,empl.StartedDate, @ShiftName as [ShiftName], @TimeDate as TimeDate,@Remark as Remark,@KiemTraDuLieuNhap as KiemTraDuLieuNhap,@InsertDate as InsertDate,@UserName as UserName,@ID as ID
		from
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,GETDATE())) empl
		where empl.ComStartedDate<=@fromdate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)
	end
END




GO
