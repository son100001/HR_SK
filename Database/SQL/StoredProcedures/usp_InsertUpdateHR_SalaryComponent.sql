--exec usp_InsertUpdateHR_SalaryComponent null,N'S000193',N'PCPhapDinh','1000000','2019-09-01',null,N'ghi chú','2019-10-12 14:11:53',N'admin'
--exec usp_InsertUpdateHR_SalaryComponent null,N'HT000451',N'PCChucVu',663602,'2020-01-01',null,'Excel',null,'2020-07-06 10:32:44',N'admin'

CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_SalaryComponent]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@SalaryComponent nvarchar(50),
	@Amount float,
	@fromdate datetime,
	@todate datetime,
	@InsertSource varchar(50),
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
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@fromdate,@UserName,'HR_SalaryComponent')
	if ISNULL(@thongbao,'')='' begin
		if exists(select Employee_ID from HR_SalaryComponent where (Employee_ID=@Employee_ID and SalaryComponent=@SalaryComponent and fromdate=@fromdate) or ID=isnull(@ID,0))
		begin
			update HR_SalaryComponent
			set Employee_ID=@Employee_ID,SalaryComponent=@SalaryComponent,Amount=@Amount,fromdate=@fromdate,todate=@todate,InsertSource=@InsertSource,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
			where (Employee_ID=@Employee_ID and SalaryComponent=@SalaryComponent and fromdate=@fromdate) or ID=isnull(@ID,0)
		end else begin
			insert into HR_SalaryComponent
			(
				[Employee_ID],
				SalaryComponent,
				Amount,
				fromdate,
				todate,
				InsertSource,
				[Remark],
				[InsertDate],
				[UserName]
			)
			values(@Employee_ID,@SalaryComponent,@Amount,@fromdate,@todate,@InsertSource,@Remark,GETDATE(),@UserName)
		end
	end
	select @ID=ID from HR_SalaryComponent where Employee_ID=@Employee_ID and fromdate=@fromdate
	select @ThongBao as ThongBao,@ID as ID
END




GO
