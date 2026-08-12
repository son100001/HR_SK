CREATE PROCEDURE [dbo].[usp_DeleteHR_WTDaily]
	-- Add the parameters for the stored procedure here
	--exec [usp_DeleteHR_MaxOvertime] '19000024','2019-1-1','1','admin'
	@Employee_ID nvarchar(50),
	@Ngay datetime,
	@MaCong varchar(20),
	@InsertSource varchar(10),
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Block_Date datetime
	declare @ThongBao nvarchar(max)
	select @Block_Date=Block_Date from HR_Khoa where [TableName]='HR_WTDaily' and Block_User=@UserName
	set @ThongBao=[dbo].[udf_KiemTraKhoaDuLieuNguoiThoiViec](@Employee_ID,@UserName)
	if @ThongBao='' begin
		if @Block_Date<@Ngay or @Block_Date is null begin
			if @InsertSource<>'NhapTay' begin
				set @ThongBao=N'Banchiduocxoadulieunhaptay'
			end else begin
				delete HR_WTDaily where Employee_ID=@Employee_ID and Ngay=@Ngay and MaCong=@MaCong and InsertSource=@InsertSource
			end
 		end else begin
			set @ThongBao=N'Dulieudabikhoa'
		end
	end
	select isnull(@ThongBao,'') as ThongBao
END
--select * from HR_TimeKeeping_Data




GO
