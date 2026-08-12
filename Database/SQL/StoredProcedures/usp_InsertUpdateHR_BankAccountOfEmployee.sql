create PROCEDURE [dbo].[usp_InsertUpdateHR_BankAccountOfEmployee]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@BankAccount nvarchar(50),
	@BankName nvarchar(255),
	@isUsing bit,
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
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,getdate(),@UserName,'HR_BankAccountOfEmployee')
	
	if ISNULL(@thongbao,'')='' begin
		if @isUsing=1 begin
			update HR_BankAccountOfEmployee set @isUsing=0 where (Employee_ID=@Employee_ID and BankAccount=@BankAccount) or ID=isnull(@ID,0)
		end
		if exists(select Employee_ID from HR_BankAccountOfEmployee where (Employee_ID=@Employee_ID and BankAccount=@BankAccount) or ID=isnull(@ID,0))
		begin
			update HR_BankAccountOfEmployee
			set BankAccount=@BankAccount,BankName=@BankName,isUsing=@isUsing,
			Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
			where (Employee_ID=@Employee_ID and BankAccount=@BankAccount) or ID=isnull(@ID,0)
		end else begin
			insert into HR_BankAccountOfEmployee
			(
				Employee_ID,
				BankAccount,
				BankName,
				isUsing,
				Remark,
				InsertDate,
				UserName
			)
			values(
			@Employee_ID,
			@BankAccount,
			@BankName,
			@isUsing,
			@Remark,
			GETDATE()
			,@UserName)
		end
	end
	select @ID=ID from HR_BankAccountOfEmployee where Employee_ID=@Employee_ID and BankAccount=@BankAccount
		select @ThongBao as ThongBao,@ID as ID
END




GO
