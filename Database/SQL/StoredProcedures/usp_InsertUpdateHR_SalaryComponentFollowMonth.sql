CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_SalaryComponentFollowMonth]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@SalaryComponent nvarchar(50),
	@Amount float,
	@Year_ int,
	@Month_ int,
	@Remark nvarchar(max),
	@InsertDate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255),@NgayDauThang datetime,@NgayCuoiThang datetime
	set @NgayDauThang=cast(@Year_ as varchar)+'-'+cast(@Month_ as varchar)+'-1'
	set @NgayCuoiThang=DATEADD(month,1,@NgayDauThang)-1
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@NgayCuoiThang,@UserName,'HR_SalaryComponentFollowMonth')
	if ISNULL(@thongbao,'')='' begin
		if exists(select Employee_ID from HR_SalaryComponentFollowMonth where (Employee_ID=@Employee_ID and SalaryComponent=@SalaryComponent and Year_=@Year_ and Month_=@Month_) or ID=isnull(@ID,0))
		begin
			update HR_SalaryComponentFollowMonth
			set Employee_ID=@Employee_ID,SalaryComponent=@SalaryComponent,Amount=@Amount,Year_=@Year_, Month_=@Month_,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
			where (Employee_ID=@Employee_ID and SalaryComponent=@SalaryComponent and Year_=@Year_ and Month_=@Month_) or ID=isnull(@ID,0)
		end else begin
			insert into HR_SalaryComponentFollowMonth
			(
				[Employee_ID],
				SalaryComponent,
				Amount,
				Year_,
				Month_,
				[Remark],
				[InsertDate],
				[UserName]
			)
			values(@Employee_ID,@SalaryComponent,@Amount,@Year_,@Month_,@Remark,GETDATE(),@UserName)
		end
	end
	select @ID=ID from HR_SalaryComponentFollowMonth where Employee_ID=@Employee_ID and SalaryComponent=@SalaryComponent and Year_=@Year_ and Month_=@Month_
	select @ThongBao as ThongBao,@ID as ID
END




GO
