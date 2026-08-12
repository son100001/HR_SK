
CREATE PROCEDURE [dbo].[usp_DeleteHR_TimeKeeping_Data]
	-- Add the parameters for the stored procedure here
	--exec usp_DeleteHR_TimeKeeping_Data '8348','admin'
	@ID int,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Block_Date datetime,@Employee_ID nvarchar(50),@AccessTime as datetime,@AccessDate as datetime
	declare @ThongBao nvarchar(max)
	select @AccessTime=AccessTime,@Employee_ID=Employee_ID,@AccessDate=AccessDate from HR_TimeKeeping_Data where ID=@ID
	select @Block_Date=Block_Date from HR_Khoa where [TableName]='HR_TimeKeeping_Data' and Block_User=@UserName
	if @Block_Date+1<@AccessTime or @Block_Date is null begin
		delete HR_TimeKeeping_Data where ID=@ID
		if not exists(select Employee_ID from HR_TimeKeeping_Data_Delete where Employee_ID=@Employee_ID and AccessTime=@AccessTime) begin
			insert into HR_TimeKeeping_Data_Delete (Employee_ID,AccessDate,AccessTime,CardNumber,UserName,InsertDate) values(@Employee_ID,@AccessDate,@AccessTime,@Employee_ID,@UserName,GETDATE())
		end
	end else begin
		set @ThongBao=N'Dulieudabikhoa'
	end
	select isnull(@ThongBao,'') as ThongBao
END




GO
