CREATE PROCEDURE [dbo].[sp_AsignmentHiring]
--exec sp_AsignmentHiring N'19001090',N'ADM',N'ADM_JH2000',N'ADM_JH2000_G007',N'ADM_JH2000_G007_1000',N'24',N'Management',N'10001',N'admin'

	-- Add the parameters for the stored procedure here
	@Employee_ID nvarchar(50),
	@fact nvarchar(50),
	@dept nvarchar(50),
	@sect nvarchar(50),
	@team nvarchar(50),
	@pos nvarchar(50),
	@posc nvarchar(50),
	@jobcode nvarchar(50),
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @EffectiveDate datetime,@Position varchar(100)
	select @EffectiveDate=StartedDate from SmartBooks_Employee where Employee_ID=@Employee_ID
	if exists(select * from SmartBooks_Employee where Employee_ID=@Employee_ID and Employee_Status=N'Hiring') begin
		set @Position=ISNULL(@team,ISNULL(@sect,isnull(@dept,isnull(@fact,''))))
		if @Position<>'' begin
			if exists(select * from HR_Transfer where EffectiveDate=@EffectiveDate and Employee_ID=@Employee_ID and TypeOfTransfer='Position') begin
				update HR_Transfer set TransferCode=@Position,InsertDate=GETDATE(),[AssignType]='Hiring',UserName=@UserName where EffectiveDate=@EffectiveDate and Employee_ID=@Employee_ID and TypeOfTransfer='Position'
			end else begin
				insert into HR_Transfer ([Employee_ID],[TransferCode],[EffectiveDate],[TypeOfTransfer],[AssignType],[InsertDate],[UserName])
					values(@Employee_ID,@Position,@EffectiveDate,'Position','Hiring',GETDATE(),@UserName)
			end
		end
		
		--Nhập position_id
		if isnull(@pos,'')<>'' begin
			if exists(select * from HR_Transfer where EffectiveDate=@EffectiveDate and Employee_ID=@Employee_ID and TypeOfTransfer='Position_ID') begin
				update HR_Transfer set TransferCode=@pos,InsertDate=GETDATE(),[AssignType]='Hiring',UserName=@UserName where EffectiveDate=@EffectiveDate and Employee_ID=@Employee_ID and TypeOfTransfer='Position_ID'
			end else begin
				insert into HR_Transfer ([Employee_ID],[TransferCode],[EffectiveDate],[TypeOfTransfer],[AssignType],[InsertDate],[UserName])
					values(@Employee_ID,@pos,@EffectiveDate,'Position_ID','Hiring',GETDATE(),@UserName)
			end
		end
		
		--Nhập PositionCategory_ID
		if isnull(@posc,'')<>'' begin
			if exists(select * from HR_Transfer where EffectiveDate=@EffectiveDate and Employee_ID=@Employee_ID and TypeOfTransfer='PositionCategory_ID') begin
				update HR_Transfer set TransferCode=@posc,InsertDate=GETDATE(),[AssignType]='Hiring',UserName=@UserName where EffectiveDate=@EffectiveDate and Employee_ID=@Employee_ID and TypeOfTransfer='PositionCategory_ID'
			end else begin
				insert into HR_Transfer ([Employee_ID],[TransferCode],[EffectiveDate],[TypeOfTransfer],[AssignType],[InsertDate],[UserName])
					values(@Employee_ID,@posc,@EffectiveDate,'PositionCategory_ID','Hiring',GETDATE(),@UserName)
			end
		end
		
		--Nhập JobCode
		if isnull(@JobCode,'')<>'' begin
			if exists(select * from HR_Transfer where EffectiveDate=@EffectiveDate and Employee_ID=@Employee_ID and TypeOfTransfer='JobCode') begin
				update HR_Transfer set TransferCode=@JobCode,InsertDate=GETDATE(),[AssignType]='Hiring',UserName=@UserName where EffectiveDate=@EffectiveDate and Employee_ID=@Employee_ID and TypeOfTransfer='JobCode'
			end else begin
				insert into HR_Transfer ([Employee_ID],[TransferCode],[EffectiveDate],[TypeOfTransfer],[AssignType],[InsertDate],[UserName])
					values(@Employee_ID,@JobCode,@EffectiveDate,'JobCode','Hiring',GETDATE(),@UserName)
			end
		end
		
		--udpate trạng thái làm việc trong bảng SmartBooks_Employee
		update SmartBooks_Employee set Employee_Status='Incumbent' where Employee_ID=@Employee_ID
		--Nhập 2 ngày phép cho người mới
		if not exists(select Employee_ID from HR_EmployeeRegisMaternityLeave where Employee_ID=@Employee_ID and @EffectiveDate between Fromdate and ToDate) begin
			insert into HR_EmployeeRegisMaternityLeave(Employee_ID,Fromdate,ToDate,LeaveType_ID,PlanStatus,Reason,UserName,InsertDate) values(@Employee_ID,@EffectiveDate,@EffectiveDate,'17',N'Plan-Shift0','Hiring',@UserName,getdate())
		end
				--Kiểm tra nếu trùng ngày cn hoặc ngày lễ
		set @EffectiveDate=@EffectiveDate+1
		while @EffectiveDate in (select H_date from SmartBooks_HolidaysPlan where H_date=@EffectiveDate) or DATENAME(WEEKDAY,@EffectiveDate)='Sunday' begin
			set @EffectiveDate=@EffectiveDate+1
		end
		if not exists(select Employee_ID from HR_EmployeeRegisMaternityLeave where Employee_ID=@Employee_ID and @EffectiveDate between Fromdate and ToDate) begin
			insert into HR_EmployeeRegisMaternityLeave(Employee_ID,Fromdate,ToDate,LeaveType_ID,PlanStatus,Reason,UserName,InsertDate) values(@Employee_ID,@EffectiveDate,@EffectiveDate,'17',N'Plan-Shift0','Hiring',@UserName,getdate())
		end
	end
END
--select * from HR_EmployeeRegisMaternityLeave





GO
