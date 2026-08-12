CREATE PROCEDURE [dbo].[usp_DeleteSmartBooks_Salary]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Key nvarchar(50),
	@Salary_Month int,
	@Salary_Year int,
	@Employee_ID nvarchar(50),
	@username nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255),@ngaydauthang datetime,@ngaycuoithang datetime,@Block_Date datetime
	set @ngaydauthang=cast(@Salary_Year as varchar)+'-'+cast(@Salary_Month as varchar)+'-1'
	set @ngaycuoithang=DATEADD(month,1,@ngaydauthang)-1
	set @ThongBao=''
	select @Block_Date=Block_Date from HR_Khoa where [TableName]='SmartBooks_Salary' and Block_User=@UserName
	if exists (select Employee_ID from SmartBooks_Salary where ((Employee_ID=@Employee_ID and Salary_Month=@Salary_Month and Salary_Year=@Salary_Year and [Key]=@Key) or ID=isnull(@ID,0)) and isnull(trangthai,0)=1) begin
		set @ThongBao=N'Dulieudabikhoa'
	end
	if @ThongBao='' begin
		delete SmartBooks_Salary where ((Employee_ID=@Employee_ID and Salary_Month=@Salary_Month and Salary_Year=@Salary_Year and [Key]=@Key) or ID=isnull(@ID,0)) and isnull(trangthai,0)=0
	end
	select isnull(@ThongBao,'') as ThongBao
END




GO
