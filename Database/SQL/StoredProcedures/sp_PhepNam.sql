CREATE PROCEDURE [dbo].[sp_PhepNam]     
(   
@thang int,
@nam int,
@fromdate datetime,
@todate datetime
)  
as   

DECLARE @Employee_ID nvarchar(50), @phepnam float

DECLARE @ProbationDate datetime
DECLARE cur_Phepnam CURSOR FOR   
select Employee_ID, sum(HourLeave/8.0) as phepnam from dbo.HR_EmpRegisLeave where (LeaveType_ID=11 or LeaveType_ID=31 or LeaveType_ID=32)
	and DateLeave between @fromdate and @todate
	group by employee_id

OPEN  cur_Phepnam    
FETCH NEXT FROM cur_Phepnam INTO @Employee_ID, @phepnam
WHILE @@FETCH_STATUS = 0    
BEGIN
	if @thang=1
		UPDATE dbo.HR_AnnualLeave set Thang1=@phepnam where Employee_ID=@Employee_ID and NamLamViec=@nam
	if @thang=2
		UPDATE dbo.HR_AnnualLeave set Thang2=@phepnam where Employee_ID=@Employee_ID and NamLamViec=@nam
	if @thang=3
		UPDATE dbo.HR_AnnualLeave set Thang3=@phepnam where Employee_ID=@Employee_ID and NamLamViec=@nam
	if @thang=4
		UPDATE dbo.HR_AnnualLeave set Thang4=@phepnam where Employee_ID=@Employee_ID and NamLamViec=@nam
	if @thang=5
		UPDATE dbo.HR_AnnualLeave set Thang5=@phepnam where Employee_ID=@Employee_ID and NamLamViec=@nam
	if @thang=6
		UPDATE dbo.HR_AnnualLeave set Thang6=@phepnam where Employee_ID=@Employee_ID and NamLamViec=@nam
	if @thang=7
		UPDATE dbo.HR_AnnualLeave set Thang7=@phepnam where Employee_ID=@Employee_ID and NamLamViec=@nam
	if @thang=8
		UPDATE dbo.HR_AnnualLeave set Thang8=@phepnam where Employee_ID=@Employee_ID and NamLamViec=@nam
	if @thang=9
		UPDATE dbo.HR_AnnualLeave set Thang9=@phepnam where Employee_ID=@Employee_ID and NamLamViec=@nam
	if @thang=10
		UPDATE dbo.HR_AnnualLeave set Thang10=@phepnam where Employee_ID=@Employee_ID and NamLamViec=@nam
	if @thang=11
		UPDATE dbo.HR_AnnualLeave set Thang11=@phepnam where Employee_ID=@Employee_ID and NamLamViec=@nam
	if @thang=12
		UPDATE dbo.HR_AnnualLeave set Thang12=@phepnam where Employee_ID=@Employee_ID and NamLamViec=@nam

FETCH NEXT FROM cur_Phepnam INTO @Employee_ID, @phepnam
END
CLOSE cur_Phepnam    
DEALLOCATE cur_Phepnam


UPDATE dbo.HR_AnnualLeave set SoPhepConLai=PhepNamDuocHuong-ISNULL(thang1,0)-ISNULL(thang2,0)-ISNULL(thang3,0)-ISNULL(thang4,0)-ISNULL(thang5,0)-ISNULL(thang6,0)-ISNULL(thang7,0)-ISNULL(thang8,0)
	-ISNULL(thang9,0)-ISNULL(thang10,0)-ISNULL(thang11,0)-ISNULL(thang12,0)

	, SoPhepDaNghi = ISNULL(thang1,0)+ISNULL(thang2,0)+ISNULL(thang3,0)+ISNULL(thang4,0)+ISNULL(thang5,0)+ISNULL(thang6,0)+ISNULL(thang7,0)+ISNULL(thang8,0)
	+ISNULL(thang9,0)+ISNULL(thang10,0)+ISNULL(thang11,0)+ISNULL(thang12,0)
	 where  NamLamViec=@nam




GO
