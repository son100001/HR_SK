
CREATE PROCEDURE [dbo].[sp_XuLyNhapNhanVienMoi]
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @Employee_ID nvarchar(50),@Factory_ID varchar(50),@DepartmentCode varchar(50),@SectionCode varchar(50),@TeamCode varchar(50),@Position_ID varchar(50),@PositionCategory_ID varchar(50),@ComStartedDate datetime,@Position varchar(100),@JobCode varchar(50),@ChucDanh varchar(50)
	DECLARE cur CURSOR LOCAL FOR
	select Employee_ID,Factory_ID,DepartmentCode,SectionCode,TeamCode,Position_ID,PositionCategory_ID,ChucDanh,JobCode,ComStartedDate from SmartBooks_Employee where Employee_Status='Hiring'
	OPEN  cur
	FETCH NEXT FROM cur INTO @Employee_ID,@Factory_ID,@DepartmentCode,@SectionCode,@TeamCode,@Position_ID,@PositionCategory_ID,@ChucDanh,@JobCode,@ComStartedDate
	WHILE @@FETCH_STATUS = 0
	BEGIN
		set @Position=isnull(@TeamCode,isnull(@SectionCode,isnull(@DepartmentCode,isnull(@Factory_ID,''))))
		if @Position<>'' begin
			if exists(select Employee_ID from [dbo].[HR_Transfer] where Employee_ID=@Employee_ID and [AssignType]='Hiring' and [TypeOfTransfer]='Position') begin
				update [dbo].[HR_Transfer] set [TransferCode]=@Position,[EffectiveDate]=@ComStartedDate,[InsertDate]=getdate(),[UserName]=@UserName where Employee_ID=@Employee_ID and [AssignType]='Hiring' and [TypeOfTransfer]='Position'
			end else begin
				insert into [dbo].[HR_Transfer] ([Employee_ID],[TransferCode],[EffectiveDate],[TypeOfTransfer],[AssignType],[InsertDate],[UserName])
					values(@Employee_ID,@Position,@ComStartedDate,'Position','Hiring',GETDATE(),@UserName)
			end
		end
		if ISNULL(@Position_ID,'')<>'' begin
			if exists(select Employee_ID from [dbo].[HR_Transfer] where Employee_ID=@Employee_ID and [AssignType]='Hiring' and [TypeOfTransfer]='Position_ID') begin
				update [dbo].[HR_Transfer] set [TransferCode]=@Position_ID,[EffectiveDate]=@ComStartedDate,[InsertDate]=getdate(),[UserName]=@UserName where Employee_ID=@Employee_ID and [AssignType]='Hiring' and [TypeOfTransfer]='Position_ID'
			end else begin
				insert into [dbo].[HR_Transfer] ([Employee_ID],[TransferCode],[EffectiveDate],[TypeOfTransfer],[AssignType],[InsertDate],[UserName])
					values(@Employee_ID,@Position_ID,@ComStartedDate,'Position_ID','Hiring',GETDATE(),@UserName)
			end
		end
		if ISNULL(@PositionCategory_ID,'')<>'' begin
			if exists(select Employee_ID from [dbo].[HR_Transfer] where Employee_ID=@Employee_ID and [AssignType]='Hiring' and [TypeOfTransfer]='PositionCategory_ID') begin
				update [dbo].[HR_Transfer] set [TransferCode]=@PositionCategory_ID,[EffectiveDate]=@ComStartedDate,[InsertDate]=getdate(),[UserName]=@UserName where Employee_ID=@Employee_ID and [AssignType]='Hiring' and [TypeOfTransfer]='PositionCategory_ID'
			end else begin
				insert into [dbo].[HR_Transfer] ([Employee_ID],[TransferCode],[EffectiveDate],[TypeOfTransfer],[AssignType],[InsertDate],[UserName])
					values(@Employee_ID,@PositionCategory_ID,@ComStartedDate,'PositionCategory_ID','Hiring',GETDATE(),@UserName)
			end
		end
		if ISNULL(@ChucDanh,'')<>'' begin
			if exists(select Employee_ID from [dbo].[HR_Transfer] where Employee_ID=@Employee_ID and [AssignType]='Hiring' and [TypeOfTransfer]='ChucDanh') begin
				update [dbo].[HR_Transfer] set [TransferCode]=@ChucDanh,[EffectiveDate]=@ComStartedDate,[InsertDate]=getdate(),[UserName]=@UserName where Employee_ID=@Employee_ID and [AssignType]='Hiring' and [TypeOfTransfer]='ChucDanh'
			end else begin
				insert into [dbo].[HR_Transfer] ([Employee_ID],[TransferCode],[EffectiveDate],[TypeOfTransfer],[AssignType],[InsertDate],[UserName])
					values(@Employee_ID,@ChucDanh,@ComStartedDate,'ChucDanh','Hiring',GETDATE(),@UserName)
			end
		end
		if ISNULL(@JobCode,'')<>'' begin
			if exists(select Employee_ID from [dbo].[HR_Transfer] where Employee_ID=@Employee_ID and [AssignType]='Hiring' and [TypeOfTransfer]='JobCode') begin
				update [dbo].[HR_Transfer] set [TransferCode]=@JobCode,[EffectiveDate]=@ComStartedDate,[InsertDate]=getdate(),[UserName]=@UserName where Employee_ID=@Employee_ID and [AssignType]='Hiring' and [TypeOfTransfer]='JobCode'
			end else begin
				insert into [dbo].[HR_Transfer] ([Employee_ID],[TransferCode],[EffectiveDate],[TypeOfTransfer],[AssignType],[InsertDate],[UserName])
					values(@Employee_ID,@JobCode,@ComStartedDate,'JobCode','Hiring',GETDATE(),@UserName)
			end
		end
		--udapte trạng thái
		update SmartBooks_Employee set Employee_Status='Incumbent' where Employee_ID=@Employee_ID
	FETCH NEXT FROM cur INTO @Employee_ID,@Factory_ID,@DepartmentCode,@SectionCode,@TeamCode,@Position_ID,@PositionCategory_ID,@ChucDanh,@JobCode,@ComStartedDate
	END
	CLOSE cur
	DEALLOCATE cur
    -- Insert statements for procedure here
	
END




GO
