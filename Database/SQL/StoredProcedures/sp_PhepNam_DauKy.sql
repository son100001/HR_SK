CREATE PROCEDURE [dbo].[sp_PhepNam_DauKy]    
@Nam int,           
@FromDate as datetime,
@ToDate as datetime,
@PhepQuyDinh int
AS

DECLARE @Employee_ID nvarchar(50), @StartedDate datetime, @OfficialDate datetime,@sothanglamviec int,@PhepNamDuocHuong float,@phepnamtang int

DECLARE @ProbationDate datetime
DECLARE cur_phepnam CURSOR FOR   
select Employee_ID,StartedDate,isnull(OfficialDate,'2019/05/01') as OfficialDate from dbo.SmartBooks_Employee emp where 
((emp.StartedDate <= @todate and emp.Employee_Status = 'Incumbent' ) 
	or (emp.Employee_Status <> 'Incumbent' and ISNULL(TernimationDate,@todate)>=@todate)) 

OPEN  cur_phepnam    
FETCH NEXT FROM cur_phepnam INTO @Employee_ID, @StartedDate,@OfficialDate
WHILE @@FETCH_STATUS = 0    
BEGIN
	if DATEADD(year,5,isnull(@StartedDate,@fromdate)) > @fromdate 
		set @PhepNamDuocHuong=@PhepQuyDinh
	else
		set @PhepNamDuocHuong = @PhepQuyDinh+ ROUND(DATEDIFF(MONTH, isnull(@StartedDate,@fromdate),@fromdate),0)/60

	set @phepnamtang = @PhepNamDuocHuong-@PhepQuyDinh
	set @sothanglamviec =(case when DATEADD(year,1,@StartedDate)<@ToDate then datediff(month,@StartedDate,@fromdate)
	else datediff(year,@StartedDate,@fromdate)*12 + DATEPART(DAY,@StartedDate)/30.0 end)

	if exists (select * from HR_AnnualLeave where Employee_ID = @Employee_ID and NamLamViec = @Nam)
	begin
		update HR_AnnualLeave
		set ThamNienLamViec = @sothanglamviec,
			PhepNamDuocHuong =@PhepNamDuocHuong,
			PhepNamTang = @phepnamtang,
			SoPhepConLai =@PhepNamDuocHuong 
		where Employee_ID = @Employee_ID and NamLamViec = @Nam
	end
	else
	begin
		insert into HR_AnnualLeave(Employee_ID,StartedDate,NamLamViec,ThamNienLamViec,PhepNamDuocHuong,PhepNamTang,SoPhepConLai)
		values(@Employee_ID,@StartedDate,@Nam,@sothanglamviec,@PhepNamDuocHuong,@phepnamtang,@PhepNamDuocHuong)
	end
FETCH NEXT FROM cur_phepnam INTO @Employee_ID, @StartedDate,@OfficialDate
END
CLOSE cur_phepnam    
DEALLOCATE cur_phepnam


--exec [dbo].[sp_PhepNam_DauKy] 2019,'2019-01-1', '2019-01-31',12
--exec [dbo].[sp_PhepNam_DauKy] 2019,'2019-01-1', '2019-01-31',8 --rieng taekwang tach cty tu thang 5 nen phep cong ty con 8





GO
