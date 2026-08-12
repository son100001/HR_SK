-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec [sp_TongHopCongTheoKhoangGio] '2017-11-1','2017-11-27','isnull(wt1,0)+isnull(wt2,0)+isnull(wt3,0)+isnull(wt4,0)+isnull(wt5,0)+isnull(wt6,0)+isnull(wt7,0)+isnull(wt8,0)+isnull(wt9,0)','DepartmentCode'
--exec [dbo].[sp_TongHopCongTheoKhoangGio] '2018-02-01','2018-02-28','isnull(wt1,0)+isnull(wt2,0)','DepartmentName','VN'

CREATE PROCEDURE [dbo].[sp_TongHopCongTheoKhoangGio]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@tongcong nvarchar(200),
	@GroupBy nvarchar(100),
	@LAN nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	declare @query nvarchar(max),@sum nvarchar(700),@dt nvarchar(10),@dtOld nvarchar(10),@indexDK int,@index int,@indexOld int,@DieuKien nvarchar(max),@DieuKienDao nvarchar(max),@TruCong nvarchar(max),@CountNV nvarchar(max)
	set @DieuKienDao=''
	set @TruCong=''
	set @CountNV=''
	if @GroupBy='DepartmentName' begin
		select @DieuKien=Value from SetUp where ID=N'BaoCaoCongTheoNhom_Department'
	end else if @GroupBy='SectionName' begin
		select @DieuKien=Value from SetUp where ID=N'BaoCaoCongTheoNhom_Section'
	end else begin
		select @DieuKien=Value from SetUp where ID=N'BaoCaoCongTheoNhom_Team'
	end
	set @indexDK=0
	create table #tabTongHopCong(Employee_ID nvarchar(50))
	create table #tab(Employee_ID nvarchar(50),wt float)
	--set @query='insert into #tabTongHopCong (GroupBy) select '+@GroupBy+' from '+(case when @GroupBy='DepartmentCode' then 'SmartBooks_Department' else (case when @GroupBy='SectionCode' then 'SmartBooks_Section' else 'SmartBooks_Team' end) end)
	set @query='insert into #tabTongHopCong (Employee_ID) select distinct Employee_ID from [dbo].[udf_CongTheoNgay]('''+CONVERT(varchar(10),@fromdate,112)+''','''+CONVERT(varchar(10),@todate,112)+''')'
	exec (@query)
	DECLARE cur_ CURSOR FOR
	select Data from [dbo].[Split](@DieuKien,',')
	OPEN  cur_
	FETCH NEXT FROM cur_ INTO @dt
	WHILE @@FETCH_STATUS = 0
	BEGIN
		set @DieuKienDao=','+@dt+@DieuKienDao
		set @index=1
		while @index<len(@dt) begin
			if ISNUMERIC(SUBSTRING(@dt,@index,1))=0 begin
				set @index=@index+1
			end else begin
				set @index=@index-1
				break
			end
		end
		set @CountNV=@CountNV+'sum((case when _'+REPLACE(LTRIM(RTRIM(RIGHT(@dt,LEN(@dt)-@index))),'.','')+'>0 then 1 else 0 end))as _'+REPLACE(LTRIM(RTRIM(RIGHT(@dt,LEN(@dt)-@index))),'.','')+','
		set @query='alter table #tabTongHopCong add _'+REPLACE(LTRIM(RTRIM(RIGHT(@dt,LEN(@dt)-@index))),'.','')+' float'
		exec (@query)
		set @query='insert into #tab '
			+'select empl.Employee_ID,sum('+@TongCong+') as wt '
			+'from '
			+'[dbo].[udf_CongTheoNgay]('''+CONVERT(varchar(10),@fromdate,112)+''','''+CONVERT(varchar(10),@todate,112)+''') ctn '
			+'left join '
			+'SmartBooks_Employee empl '
			+'on ctn.Employee_ID=empl.Employee_ID '
			+'group by empl.Employee_ID'
		exec (@query)
		set @query='update #tabTongHopCong '
		+'set #tabTongHopCong._'+REPLACE(LTRIM(RTRIM(RIGHT(@dt,LEN(@dt)-@index))),'.','')+'=tab.wt '
		+'from '
		+'#tabTongHopCong thc '
		+'inner join '
		+'#tab tab '
		+'on thc.Employee_ID=tab.Employee_ID '
		+'where tab.wt'+@dt
		exec (@query)
		delete #tab
	FETCH NEXT FROM cur_ INTO @dt
	END
	CLOSE cur_
	DEALLOCATE cur_
	set @DieuKienDao=right(@DieuKienDao,len(@DieuKienDao)-1)
	set @CountNV=left(@CountNV,len(@CountNV)-1)
	DECLARE cur_ CURSOR FOR
	select Data from [dbo].[Split](@DieuKienDao,',')
	OPEN  cur_
	FETCH NEXT FROM cur_ INTO @dt
	WHILE @@FETCH_STATUS = 0
	BEGIN
		set @index=1
		while @index<len(@dt) begin
			if ISNUMERIC(SUBSTRING(@dt,@index,1))=0 begin
				set @index=@index+1
			end else begin
				set @index=@index-1
				break
			end
		end
		if @indexDK>0 begin
			set @TruCong=@TruCong+'-isnull(_'+REPLACE(LTRIM(RTRIM(RIGHT(@dtOld,LEN(@dtOld)-@indexOld))),'.','')+',0)'
			set @query='update #tabTongHopCong set _'+REPLACE(LTRIM(RTRIM(RIGHT(@dt,LEN(@dt)-@index))),'.','')+'=isnull(_'+REPLACE(LTRIM(RTRIM(RIGHT(@dt,LEN(@dt)-@index))),'.','')+',0)'+@TruCong-- where '+'_'+REPLACE(LTRIM(RTRIM(RIGHT(@dt,LEN(@dt)-@index))),'.','')+'>0'
			exec (@query)
		end
		set @dtOld=@dt
		set @indexOld=@index
		set @indexDK=@indexDK+1
	FETCH NEXT FROM cur_ INTO @dt
	END
	CLOSE cur_
	DEALLOCATE cur_
	set @query='select empl.'+@GroupBy+', '+@CountNV
	+' from '
	+'#tabTongHopCong thc '
	+'left join '
	+'udf_Smartbooks_Employee('''+@LAN+''') empl '
	+'on thc.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID '
	+'group by empl.'+@GroupBy
	exec(@query)
	drop table #tabTongHopCong
	drop table #tab
END




GO
