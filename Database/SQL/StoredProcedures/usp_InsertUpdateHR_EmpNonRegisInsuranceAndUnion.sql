
CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_EmpNonRegisInsuranceAndUnion]
	-- Add the parameters for the stored procedure here
	@Employee_ID nvarchar(50),
	@Thang int,
	@Nam int,
	@SocialInsurance bit,
	@HealthInsurance bit,
	@UnemploymentInsurance bit,
	@UnionFee bit,
	@Comment nvarchar(1024),
	@UserName nvarchar(50),
	@InsertDate datetime

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if @SocialInsurance is null and @HealthInsurance is null and @UnemploymentInsurance is null and @UnionFee is null begin
		delete HR_EmpNonRegisInsuranceAndUnion where Employee_ID=@Employee_ID and nam=@Nam and thang=@Thang
	end else begin
		-- Insert statements for procedure here
		if exists(select * from HR_EmpNonRegisInsuranceAndUnion where Employee_ID=@Employee_ID and Thang=@Thang and Nam=@Nam) begin
			update HR_EmpNonRegisInsuranceAndUnion set SocialInsurance=@SocialInsurance,HealthInsurance=@HealthInsurance,UnemploymentInsurance=@UnemploymentInsurance,UnionFee=@UnionFee
				,Comment=@Comment,UserName=@UserName, InsertDate=GETDATE()
			where Employee_ID=@Employee_ID and Thang=@Thang and Nam=@Nam
		end else begin
			insert into HR_EmpNonRegisInsuranceAndUnion(Employee_ID,thang,nam,SocialInsurance,HealthInsurance,UnemploymentInsurance,UnionFee,Comment,UserName,InsertDate)
			values(@Employee_ID,@Thang,@Nam,@SocialInsurance,@HealthInsurance,@UnemploymentInsurance,@UnionFee,@Comment,@UserName,GETDATE())
		end
	end
	select '' as ThongBao
END




GO
