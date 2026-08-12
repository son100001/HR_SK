-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec sp_BaoCaoCongChiTietTheoNgay '2017-12-1','2017-12-20','wt1,wt2','P01'
CREATE PROCEDURE [dbo].[sp_BaoCaoCongChiTietTheoNgay]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@ListOfWT nvarchar(200),
	@ListOfLeaveType nvarchar(100),
	@NotSymbol bit = null,
	@LAN nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	declare @query nvarchar(max),@wt varchar(10)
	IF OBJECT_ID('tempdb..#tab') IS NOT NULL DROP TABLE #tab
	IF OBJECT_ID('tempdb..#tabDetail') IS NOT NULL DROP TABLE #tabDetail
	IF OBJECT_ID('tempdb..#tabCongChiTietTheoNgay') IS NOT NULL DROP TABLE #tabCongChiTietTheoNgay
	create table #tabCongChiTietTheoNgay(Employee_ID_ nvarchar(50))
	create table #tab(Date_ datetime,Employee_ID nvarchar(50),wt1 float,wt2 float,wt3 float,wt4 float,wt5 float,wt6 float,wt7 float,wt8 float,wt9 float,wt10 float,wt11 float,wt12 float,wt13 float,wt14 float,wt15 float,wt16 float,wt17 float,wt18 float,wt19 float,wt20 float,HourLeave float,LeaveType_ID nvarchar(50))
	create table #tabDetail(Date_ datetime,Employee_ID nvarchar(50),wt nvarchar(100))
	set @query='insert into #tabCongChiTietTheoNgay (Employee_ID_) select distinct Employee_ID from [dbo].[udf_CongTheoNgay]('''+CONVERT(varchar(10),@fromdate,112)+''','''+CONVERT(varchar(10),@todate,112)+''')'
	exec (@query)
	Declare @dNext datetime
	--LẤY BẢNG CÔNG NGUỒN
	insert into #tab
	select
	dt.Date_,empl.Employee_ID,isnull(wt1,0) as wt1,isnull(wt2,0) as wt2,isnull(wt3,0) as wt3,isnull(wt4,0) as wt4,isnull(wt5,0) as wt5,isnull(wt6,0) as wt6,isnull(wt7,0) as wt7,isnull(wt8,0) as wt8,isnull(wt9,0) as wt9,isnull(wt10,0) as wt10,isnull(wt11,0) as wt11,isnull(wt12,0) as wt12,isnull(wt13,0) as wt13,isnull(wt14,0) as wt14,isnull(wt15,0) as wt15,isnull(wt16,0) as wt16,isnull(wt17,0) as wt17,isnull(wt18,0) as wt18,isnull(wt19,0) as wt19,isnull(wt20,0) as wt20
	,isnull(erl.HourLeave,0) as HourLeave,erl.[LeaveType_ID]
	from
	[dbo].[udf_BangThoiGian](@fromdate,@todate) dt
	left join
	Smartbooks_Employee empl
	on dt.Date_>=empl.StartedDate-- and (empl.[TernimationDate] is null or dt.Date_<empl.[TernimationDate])
	left join
	[dbo].[udf_CongTheoNgay](@fromdate,@todate) ctn
	on dt.Date_=ctn.Ngay and ctn.Employee_ID=empl.Employee_ID
	left join
	[dbo].[HR_EmpRegisLeave] erl
	on dt.Date_=erl.[DateLeave] and erl.Employee_ID=empl.Employee_ID
	order by Employee_ID,Date_
	--LẤY BẢNG CÔNG CHI TIẾT
	insert into #tabDetail
	select Date_,tab.Employee_ID
		,(case when wt1>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt1') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt1 as varchar(10))+'/' else '('+cast(wt1 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt2>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt2') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt2 as varchar(10))+'/' else '('+cast(wt2 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt3>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt3') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt3 as varchar(10))+'/' else '('+cast(wt3 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt4>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt4') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt4 as varchar(10))+'/' else '('+cast(wt4 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt5>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt5') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt5 as varchar(10))+'/' else '('+cast(wt5 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt6>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt6') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt6 as varchar(10))+'/' else '('+cast(wt6 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt7>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt7') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt7 as varchar(10))+'/' else '('+cast(wt7 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt8>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt8') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt8 as varchar(10))+'/' else '('+cast(wt8 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt9>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt9') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt9 as varchar(10))+'/' else '('+cast(wt9 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt10>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt10') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt10 as varchar(10))+'/' else '('+cast(wt10 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt11>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt11') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt11 as varchar(10))+'/' else '('+cast(wt11 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt12>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt12') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt12 as varchar(10))+'/' else '('+cast(wt12 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt13>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt13') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt13 as varchar(10))+'/' else '('+cast(wt13 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt14>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt14') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt14 as varchar(10))+'/' else '('+cast(wt14 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt15>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt15') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt15 as varchar(10))+'/' else '('+cast(wt15 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt16>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt16') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt16 as varchar(10))+'/' else '('+cast(wt16 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt17>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt17') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt17 as varchar(10))+'/' else '('+cast(wt17 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt18>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt18') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt18 as varchar(10))+'/' else '('+cast(wt18 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt19>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt19') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt19 as varchar(10))+'/' else '('+cast(wt19 as varchar(10))+'wt1)' end) else '' end)
		+(case when wt20>0 and exists(select * from [dbo].[Split](@ListOfWT,',') where Data='wt20') then (case when @NotSymbol is null or @NotSymbol=0 then cast(wt20 as varchar(10))+'/' else '('+cast(wt20 as varchar(10))+'wt1)' end) else '' end)
		+(case when HourLeave>0 and exists(select * from [dbo].[Split](@ListOfLeaveType,',') where Data COLLATE DATABASE_DEFAULT=LeaveType_ID) then (case when @NotSymbol is null or @NotSymbol=0 then LeaveType_ID+'/' else '('+cast(HourLeave as varchar(10))+LeaveType_ID+')' end) else '' end)
		+(case when Date_>=empl.TernimationDate then N'TV/' else '' end)
		as wt
	from
	#tab tab
	left join
	Smartbooks_Employee empl
	on tab.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
	--CHUYỂN SANG CHIỀU NGANG
	set @dNext=@fromdate
	while @dNext<=@todate
	begin
		set @query='alter table #tabCongChiTietTheoNgay add _'+cast(datepart(day,@dNext)as varchar(2))+' nvarchar(50)'
		exec (@query)
		set @query='update #tabCongChiTietTheoNgay set _'+cast(datepart(day,@dNext)as varchar(2))+'=(case when len(isnull(tab.wt,''''))>0 then left(tab.wt,len(tab.wt)-1) else '''' end) '
		+'from '
		+'#tabCongChiTietTheoNgay ctn '
		+'inner join '
		+'#tabDetail tab '
		+'on ctn.Employee_ID_=tab.Employee_ID '
		+'where tab.Date_='''+CONVERT(varchar(10),@dNext,112)+''''
		exec (@query)
		print @query
		set @dNext=@dNext+1
	end
	--TỔNG CÔNG
	if @ListOfWT<>'' and @ListOfWT is not null begin
		DECLARE cur_ CURSOR LOCAL FOR    
		select Data from [dbo].[Split](@ListOfWT,',')
		OPEN  cur_     
		FETCH NEXT FROM cur_ INTO @wt    
		WHILE @@FETCH_STATUS = 0    
		BEGIN    
			set @query='alter table #tabCongChiTietTheoNgay add '+@wt+' float'
			exec (@query)
			set @query='update #tabCongChiTietTheoNgay set '+@wt+'=tab.wt '
			+'from '
			+'#tabCongChiTietTheoNgay ctn '
			+'inner join '
			+'(select Employee_ID,sum(isnull('+@wt+',0)) as wt from #tab group by Employee_ID) tab '
			+'on ctn.Employee_ID_=tab.Employee_ID'
			exec (@query)
		FETCH NEXT FROM cur_ INTO @wt    
		END    
		CLOSE cur_    
		DEALLOCATE cur_  
	end
	--TỔNG PHÉP
	if @ListOfLeaveType<>'' and @ListOfLeaveType is not null begin
		DECLARE cur_ CURSOR LOCAL FOR    
		select Data from [dbo].[Split](@ListOfLeaveType,',')
		OPEN  cur_     
		FETCH NEXT FROM cur_ INTO @wt    
		WHILE @@FETCH_STATUS = 0    
		BEGIN    
			set @query='alter table #tabCongChiTietTheoNgay add '+@wt+' float'
			exec (@query)
			set @query='update #tabCongChiTietTheoNgay set '+@wt+'=tab.wt '
			+'from '
			+'#tabCongChiTietTheoNgay ctn '
			+'inner join '
			+'(select Employee_ID,sum(isnull(HourLeave,0)) as wt from #tab where LeaveType_ID='''+@wt+''' group by Employee_ID) tab '
			+'on ctn.Employee_ID_=tab.Employee_ID'
			exec (@query)
		FETCH NEXT FROM cur_ INTO @wt    
		END    
		CLOSE cur_    
		DEALLOCATE cur_
	end  
	--show
	select empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.DepartmentName,empl.SectionName,empl.TeamName,empl.[PositionName],empl.[PositionCategoryName],ctn.*
	from
	#tabCongChiTietTheoNgay ctn
	left join
	udf_Smartbooks_Employee(@LAN) empl
	on ctn.Employee_ID_ COLLATE DATABASE_DEFAULT=empl.Employee_ID
	IF OBJECT_ID('tempdb..#tab') IS NOT NULL DROP TABLE #tab
	IF OBJECT_ID('tempdb..#tabDetail') IS NOT NULL DROP TABLE #tabDetail
	IF OBJECT_ID('tempdb..#tabCongChiTietTheoNgay') IS NOT NULL DROP TABLE #tabCongChiTietTheoNgay

END



--update #tabCongChiTietTheoNgay set _1=(case when len(isnull(tab.wt,'))>0 then left(tab.wt,len(tab.wt)-1) else null end) from #tabCongChiTietTheoNgay ctn inner join #tabDetail tab on ctn.Employee_ID_=tab.Employee_ID where tab.Date_='20171101'




GO
