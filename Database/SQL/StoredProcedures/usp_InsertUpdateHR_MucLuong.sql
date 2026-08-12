CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_MucLuong]
	-- Add the parameters for the stored procedure here
	@ID int,
	@SalaryGroup varchar(50),
	@SalaryStep varchar(50),
	@Amount float,
	@FromDate datetime,
	@ToDate datetime,
	@Remark nvarchar(max),
	@InsertDate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255)
	set @ThongBao=''
	if @ToDate<@Fromdate begin
		set @ThongBao=N'Dulieukhonghople'
	end
	if ISNULL(@thongbao,'')='' begin
		if exists(select ID from HR_MucLuong where (SalaryGroup=@SalaryGroup and SalaryStep=@SalaryStep and Fromdate=@Fromdate) or ID=isnull(@ID,0))
		begin
			update HR_MucLuong
			set SalaryGroup=@SalaryGroup,SalaryStep=@SalaryStep,Amount=@Amount,FromDate=@FromDate,ToDate=@ToDate,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
			where (SalaryGroup=@SalaryGroup and SalaryStep=@SalaryStep and Fromdate=@Fromdate) or ID=isnull(@ID,0)
		end else begin
			insert into HR_MucLuong
			(
				SalaryGroup,
				SalaryStep,
				Amount,
				FromDate,
				ToDate,
				[Remark],
				[InsertDate],
				[UserName]
			)
			values(@SalaryGroup,@SalaryStep,@Amount,@FromDate,@ToDate,@Remark,GETDATE(),@UserName)
		end
	end
	select @ID=ID from HR_MucLuong where SalaryGroup=@SalaryGroup and SalaryStep=@SalaryStep and Fromdate=@Fromdate
	select @ThongBao as ThongBao,@ID as ID
END




GO
