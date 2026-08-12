--exec [dbo].[sp_TinhGioCacLoaiNghi]  '2019-6-1','2019-6-30'
CREATE PROCEDURE [dbo].[sp_ThemGioNghiViec]               
@FromDate as datetime,
@ToDate as datetime
AS
DECLARE @Employee_ID nvarchar(50),@EmpID nvarchar(50),  @TernimationDate datetime,  @JoinDate datetime,@UserName nvarchar(50),@tempDate datetime,@hol int,@h as float

DECLARE @ProbationDate datetime

DECLARE cur_Nghi CURSOR FOR
	select Employee_ID,TernimationDate from SmartBooks_Employee where TernimationDate is not null and TernimationDate between @FromDate and @ToDate

OPEN  cur_Nghi    
FETCH NEXT FROM cur_Nghi INTO  @Employee_ID, @TernimationDate
WHILE @@FETCH_STATUS = 0    
BEGIN

	set @tempDate=@FromDate
	while @tempDate<=@ToDate
	begin
		if @tempDate>=@TernimationDate
		begin
			if [dbo].[udf_DayOfWeek](@tempDate)<>'Sunday'
			begin
				if not exists(select Employee_ID,DateLeave from HR_EmpRegisLeave where DateLeave=@tempDate and Employee_ID=@Employee_ID and DateLeave>=@TernimationDate)
				begin
					insert into HR_EmpRegisLeave(Employee_ID,DateLeave,LeaveType_ID,HourLeave,Approval,InsertDate,UserName,isProbation)
					values(@Employee_ID,@tempDate,29,8,1,@FromDate,'Admin',0)
				end
				else
				begin
					update HR_EmpRegisLeave set LeaveType_ID = 29,HourLeave=8,isProbation=0 where DateLeave=@tempDate and Employee_ID=@Employee_ID
				end
			end
		end
		set @tempDate = DATEADD(day,1,@tempDate)
	end
FETCH NEXT FROM cur_Nghi INTO @Employee_ID, @TernimationDate
END
CLOSE cur_Nghi    
DEALLOCATE cur_Nghi


--them nguoi moi vao
DECLARE cur_moivao CURSOR FOR
	select Employee_ID,ComStartedDate from SmartBooks_Employee where ComStartedDate between @FromDate and @ToDate

OPEN  cur_moivao    
FETCH NEXT FROM cur_moivao INTO  @Employee_ID, @JoinDate
WHILE @@FETCH_STATUS = 0    
BEGIN

	set @tempDate=@FromDate
	while @tempDate<=@ToDate
	begin
		if @tempDate<@JoinDate
		begin
			if [dbo].[udf_DayOfWeek](@tempDate)<>'Sunday'
			begin
				if not exists(select Employee_ID,DateLeave from HR_EmpRegisLeave where DateLeave=@tempDate and Employee_ID=@Employee_ID )
				begin
					insert into HR_EmpRegisLeave(Employee_ID,DateLeave,LeaveType_ID,HourLeave,Approval,InsertDate,UserName,isProbation)
					values(@Employee_ID,@tempDate,20,8,1,@FromDate,'Admin',1)
				end
				else
				begin
					update HR_EmpRegisLeave set LeaveType_ID = 20,HourLeave=8,isProbation=1 where DateLeave=@tempDate and Employee_ID=@Employee_ID
				end
			end
		end
		set @tempDate = DATEADD(day,1,@tempDate)
	end
FETCH NEXT FROM cur_moivao INTO @Employee_ID, @JoinDate
END
CLOSE cur_moivao    
DEALLOCATE cur_moivao

--exec [dbo].[sp_ThemGioNghiViec] '2019-06-1', '2019-06-30'

-- select * from HR_EmpRegisLeave where LeaveType_ID=50 and DateLeave between '2019/05/01' and '2019/05/31'




GO
