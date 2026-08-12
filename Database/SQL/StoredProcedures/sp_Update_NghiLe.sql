CREATE PROCEDURE [dbo].[sp_Update_NghiLe]               
@FromDate as datetime,
@ToDate as datetime
AS
DECLARE @Employee_ID nvarchar(50),@EmpID nvarchar(50), @LeaveType_ID nvarchar(50), @Fdate datetime, @TDate Datetime, @InsertDate datetime,@UserName nvarchar(50),@tempDate datetime,@hol int
DECLARE @ProbationDate datetime
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
--end update nghi le

--exec [dbo].[sp_Update_NghiLe] '2019-05-1', '2019-05-31'

-- select * from HR_EmpRegisLeave where LeaveType_ID=50 and DateLeave between '2019/05/01' and '2019/05/31'

--select * from HR_EmpRegisLeave where DateLeave ='2019/05/01'
-- select * from SmartBooks_HolidaysPlan 
-- select count(sbhp.H_date) as abc from SmartBooks_HolidaysPlan sbhp WHERE sbhp.H_date = '2019/05/01'




GO
