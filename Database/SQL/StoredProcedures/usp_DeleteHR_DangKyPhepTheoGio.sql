CREATE PROCEDURE [dbo].[usp_DeleteHR_DangKyPhepTheoGio]
	-- Add the parameters for the stored procedure here
	--exec [usp_DeleteHR_MaxOvertime] '19000024','2019-1-1','1','admin'
	@Employee_ID nvarchar(50),
	@DateLeave datetime,
	@TypeOfLeave varchar(20),
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Block_Date datetime
	declare @ThongBao nvarchar(max)
	select @Block_Date=Block_Date from HR_Khoa where [TableName]='HR_DangKyPhepTheoGio' and Block_User=@UserName
	set @ThongBao=[dbo].[udf_KiemTraKhoaDuLieuNguoiThoiViec](@Employee_ID,@UserName)
	if @ThongBao='' begin
		if @Block_Date<@DateLeave or @Block_Date is null begin
			delete HR_DangKyPhepTheoGio where Employee_ID=@Employee_ID and DateLeave=@DateLeave and TypeOfLeave=@TypeOfLeave
 		end else begin
			set @ThongBao=N'Dulieudabikhoa'
		end
	end
	select isnull(@ThongBao,'') as ThongBao
END
--select * from HR_TimeKeeping_Data




GO
