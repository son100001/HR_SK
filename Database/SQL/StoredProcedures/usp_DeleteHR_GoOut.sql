
CREATE PROCEDURE [dbo].[usp_DeleteHR_GoOut]
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
	declare @Block_Date datetime,@Employee_ID nvarchar(50),@TimeOut_ as datetime
	declare @ThongBao nvarchar(max)
	select @TimeOut_=TimeOut_,@Employee_ID=Employee_ID from HR_GoOut where ID=@ID
	select @Block_Date=Block_Date from HR_Khoa where [TableName]='HR_GoOut' and Block_User=@UserName
	if @Block_Date+1<@TimeOut_ or @Block_Date is null begin
		delete HR_GoOut where ID=@ID
	end else begin
		set @ThongBao=N'Dulieudabikhoa'
	end
	select isnull(@ThongBao,'') as ThongBao
END
--select * from HR_TimeKeeping_Data




GO
