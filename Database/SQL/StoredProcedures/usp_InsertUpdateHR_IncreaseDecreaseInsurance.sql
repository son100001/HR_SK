CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_IncreaseDecreaseInsurance] 
	-- Add the parameters for the stored procedure here
	@ID int,
	@Year_ int,
	@Month_ int,
	@Employee_ID nvarchar(50),
	@PhuongAn varchar(50),
	@LoaiKhaiBao varchar(50),
	@InsuranceSalary float,
	@InsertSource varchar(50),
	@NgayTangGiam datetime,
	@Remark nvarchar(50),
	@InsertDate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255)
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@NgayTangGiam,@UserName,'HR_IncreaseDecreaseInsurance')
	if @ThongBao='' begin
		set @InsertSource='NhapTay'
		if exists(select Employee_ID from HR_IncreaseDecreaseInsurance where (Employee_ID=@Employee_ID and Month_=@Month_ and Year_=@Year_) or ID=isnull(@ID,0)) begin
			update HR_IncreaseDecreaseInsurance set PhuongAn=@PhuongAn,LoaiKhaiBao=@LoaiKhaiBao,InsuranceSalary=@InsuranceSalary,InsertSource=@InsertSource,Remark=@Remark,InsertDate=GETDATE()
				,UserName=@UserName,Year_=@Year_,Month_=@Month_ where (Employee_ID=@Employee_ID and Month_=@Month_ and Year_=@Year_) or ID=isnull(@ID,0)
		end else begin
			insert into HR_IncreaseDecreaseInsurance(Year_,Month_,Employee_ID,PhuongAn,LoaiKhaiBao,InsuranceSalary,InsertSource,NgayTangGiam,Remark,InsertDate,UserName)
				values(@Year_,@Month_,@Employee_ID,@PhuongAn,@LoaiKhaiBao,@InsuranceSalary,@InsertSource,@NgayTangGiam,@Remark,@InsertDate,@UserName)
		end
	end
	
	select isnull(@ThongBao,'') as ThongBao
END


GO
