-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec [dbo].[sp_CongTongHop] '2018-2-1','2018-2-28'
CREATE PROCEDURE [dbo].[sp_CongTongHop]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@LAN nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @queryUpdate nvarchar(max),@LeaveType_ID nvarchar(50),@wtCode nvarchar(50)
	IF OBJECT_ID('tempdb..#tabListOfEmployee_ID') IS NOT NULL DROP TABLE #tabListOfEmployee_ID
	create table #tabListOfEmployee_ID (Employee_ID nvarchar(50), Item nvarchar(50))
	IF OBJECT_ID('tempdb..#tabWorkingTimeSummarization') IS NOT NULL DROP TABLE #tabWorkingTimeSummarization
	select Employee_ID,Employee_Firstname+(case when Employee_LastName is null then '' else ' '+Employee_LastName end) as FullName,
			DepartmentName,SectionName,TeamName,PositionName,PositionCategoryName,StartedDate,Employee_Status,TernimationDate into #tabWorkingTimeSummarization from udf_Smartbooks_Employee(@LAN) where StartedDate<=@todate and (TernimationDate is null or TernimationDate>@fromdate)

	DECLARE cur_MaCong CURSOR FOR    
	select MaCong from HR_LoaiCong order by MaCong    
	OPEN  cur_MaCong     
	FETCH NEXT FROM cur_MaCong INTO @wtCode    
	WHILE @@FETCH_STATUS = 0    
	BEGIN    
	exec ('alter table #tabWorkingTimeSummarization add wt_'+@wtCode+' float')    
	--<code thay the duyet cursor>    
	insert into #tabListOfEmployee_ID (Employee_ID,Item)    
	select Employee_ID,convert(VARCHAR(50),sum(wt),128)      
		from [dbo].[udf_ChuyenCongTheoChieuDoc_TachCongTheoHD](@fromdate,@todate) where MaCong=@wtCode group by Employee_ID    
	set @queryUpdate='UPDATE '    
		+'#tabWorkingTimeSummarization '    
		+'SET '    
		+'#tabWorkingTimeSummarization.wt_'+@wtCode+'= sce.Item '    
		+'FROM '    
		+'#tabWorkingTimeSummarization sc '    
		+'INNER JOIN '    
		+'#tabListOfEmployee_ID sce '    
		+'ON '    
		+'sc.employee_id COLLATE DATABASE_DEFAULT=sce.employee_id '    
	exec (@queryUpdate)
	Delete from #tabListOfEmployee_ID
	--</code thay the duyet cursor>
    
	FETCH NEXT FROM cur_MaCong INTO @wtCode    
	END    
	CLOSE cur_MaCong    
	DEALLOCATE cur_MaCong

	DECLARE cur CURSOR FOR    
	select ID from SmartBooks_LeaveType    
	OPEN  cur     
	FETCH NEXT FROM cur INTO @LeaveType_ID    
	WHILE @@FETCH_STATUS = 0    
	BEGIN    
		exec ('alter table #tabWorkingTimeSummarization add lv_'+@LeaveType_ID+' float')    
		--<code thay the duyet cursor>    
		insert into #tabListOfEmployee_ID (Employee_ID,Item)    
		select Employee_ID,convert(VARCHAR(50), sum(isnull(HourLeave,0)),128)      
			from HR_EmpRegisLeave where LeaveType_ID=@LeaveType_ID and DateLeave between @fromdate and @todate group by Employee_ID    
		set @queryUpdate='UPDATE '    
			+'#tabWorkingTimeSummarization '    
			+'SET '    
			+'#tabWorkingTimeSummarization.lv_'+@LeaveType_ID+'= sce.Item '    
			+'FROM '    
			+'#tabWorkingTimeSummarization sc '    
			+'INNER JOIN '    
			+'#tabListOfEmployee_ID sce '    
			+'ON '    
			+'sc.employee_id COLLATE DATABASE_DEFAULT=sce.employee_id '    
		exec (@queryUpdate)    
		Delete from #tabListOfEmployee_ID
	FETCH NEXT FROM cur INTO @LeaveType_ID    
	END    
	CLOSE cur    
	DEALLOCATE cur 

	select * from #tabWorkingTimeSummarization order by DepartmentName
END




GO
