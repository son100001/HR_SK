--exec [dbo].[sp_TinhGioCacLoaiNghi]  '2019-6-1','2019-6-30'
CREATE PROCEDURE [dbo].[sp_TinhGioCacLoaiNghi]               
@FromDate as datetime,
@ToDate as datetime
AS
DECLARE @Employee_ID nvarchar(50),@EmpID nvarchar(50), @LeaveType_ID nvarchar(50), @Fdate datetime, @TDate Datetime, @InsertDate datetime,@UserName nvarchar(50),@tempDate datetime,@hol int,@h as float

DECLARE @ProbationDate datetime
--xoa
delete HR_EmpRegisLeave where DateLeave between @FromDate and @ToDate
DECLARE cur_Nghi CURSOR FOR
	select Employee_ID,LeaveType_ID,fromdate,todate,insertdate,username from
	[dbo].[udf_BangPhep](@FromDate,@ToDate,null)

OPEN  cur_Nghi    
FETCH NEXT FROM cur_Nghi INTO  @Employee_ID, @LeaveType_ID, @Fdate, @TDate, @InsertDate,@UserName
WHILE @@FETCH_STATUS = 0    
BEGIN
	If @TDate>=@ToDate 
	begin
		set @TDate = @ToDate
	end
	If @Fdate<=@FromDate 
	begin
		set @Fdate = @FromDate
	end
	set @tempDate=@Fdate

	while @tempDate<=@TDate
	begin
		if [dbo].[udf_DayOfWeek](@tempDate)<>'Sunday'
		begin
			if not exists(select Employee_ID,DateLeave from HR_EmpRegisLeave where DateLeave=@tempDate and Employee_ID=@Employee_ID)
			begin
				if @LeaveType_ID=31 or @LeaveType_ID=32
				begin
					set @h=4
				end
				else
					set @h=8

				insert into HR_EmpRegisLeave(Employee_ID,DateLeave,LeaveType_ID,HourLeave,Approval,InsertDate,UserName)
				values(@Employee_ID,@tempDate,@LeaveType_ID,@h,1,@InsertDate,@UserName)
			end
			else
			begin
				if @LeaveType_ID=31 or @LeaveType_ID=32
				begin
					set @h=4
				end
				else
					set @h=8

				update HR_EmpRegisLeave set LeaveType_ID = @LeaveType_ID,HourLeave=@h where DateLeave=@tempDate and Employee_ID=@Employee_ID
			end
		end
		set @tempDate = DATEADD(day,1,@tempDate)
	end
FETCH NEXT FROM cur_Nghi INTO @Employee_ID, @LeaveType_ID, @Fdate, @TDate, @InsertDate,@UserName
END
CLOSE cur_Nghi    
DEALLOCATE cur_Nghi

--update nghi le vao
DECLARE cur_nv CURSOR FOR   
	SELECT  Employee_ID FROM SmartBooks_Employee empl
	where ((empl.ComStartedDate <= @todate and empl.Employee_Status = 'Incumbent' ) or (empl.Employee_Status <> 'Incumbent' and ISNULL(TernimationDate,@todate)>@todate)) 

OPEN  cur_nv    
FETCH NEXT FROM cur_nv INTO  @EmpID
WHILE @@FETCH_STATUS = 0    
BEGIN
	set @Fdate = @FromDate
	while @Fdate<=@ToDate
	begin
		-- Kiem tra xem trung ngay nghi le khong
			select @hol = count(sbhp.H_date) from SmartBooks_HolidaysPlan sbhp
			WHERE sbhp.H_date = @Fdate
		-- End Kiem tra xem trung ngay nghi le khong
		if @hol=1
		begin
			if not exists(select Employee_ID,DateLeave from HR_EmpRegisLeave where DateLeave=@Fdate and Employee_ID=@EmpID)
			begin
				insert into HR_EmpRegisLeave(Employee_ID,DateLeave,LeaveType_ID,HourLeave,Approval,InsertDate,UserName)
				values(@EmpID,@Fdate,50,8,1,@InsertDate,@UserName) -- mac dinh nghi le ma 50
			end
		end
		set @Fdate = DATEADD(day,1,@Fdate)
	end
FETCH NEXT FROM cur_nv INTO @EmpID
END
CLOSE cur_nv    
DEALLOCATE cur_nv

exec [dbo].[sp_ThemGioNghiViec] @FromDate, @ToDate

--end update nghi le


--exec [dbo].[sp_TinhGioCacLoaiNghi] '2019-06-1', '2019-06-30'

-- select * from HR_EmpRegisLeave where LeaveType_ID=50 and DateLeave between '2019/05/01' and '2019/05/31'




GO
