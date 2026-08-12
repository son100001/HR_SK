
CREATE PROCEDURE [dbo].[sp_BangKhongDongBHCD]
	-- Add the parameters for the stored procedure here
	--exec sp_BangKhongDongBHCD '07','2019'
	@Thang int,
	@Nam int,
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Empl nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @CuoiThang datetime,@DauThang datetime
	set @DauThang=cast(@Nam as varchar)+'-'+cast(@Thang as varchar)+'-1'
	set @CuoiThang=DATEADD(month,1,@DauThang)-1
	select
	empl.Position,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
	,@Thang as Thang,@Nam as Nam
	,en.HealthInsurance,en.SocialInsurance,en.UnemploymentInsurance,en.UnionFee,en.Comment,en.UserName,en.InsertDate
	from
	[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Empl,GETDATE()) empl
	left join
	HR_EmpNonRegisInsuranceAndUnion en
	on empl.Employee_ID=en.Employee_ID and en.Thang=@Thang and en.Nam=@Nam
	where
	empl.StartedDate<=@CuoiThang and (empl.TernimationDate is null or empl.TernimationDate>@DauThang)
END




GO
