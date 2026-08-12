CREATE PROCEDURE [dbo].[usp_DeleteHR_MaxOvertime]
	-- Add the parameters for the stored procedure here
	--exec [usp_DeleteHR_MaxOvertime] '19000024','2019-1-1','1','admin'
	@Employee_ID nvarchar(50),
	@workingdate datetime,
	@TypeOfOT varchar(20),
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Block_Date datetime
	declare @ThongBao nvarchar(max)
	select @Block_Date=Block_Date from HR_Khoa where [TableName]='HR_MaxOvertime' and Block_User=@UserName
	set @ThongBao=[dbo].[udf_KiemTraKhoaDuLieuNguoiThoiViec](@Employee_ID,@UserName)
	if @ThongBao='' begin
		if @Block_Date<@workingdate or @Block_Date is null begin
			delete HR_MaxOvertime where Employee_ID=@Employee_ID and workingdate=@workingdate and TypeOfOT=@TypeOfOT
 		end else begin
			set @ThongBao=N'Dulieudabikhoa'
		end
	end
	select isnull(@ThongBao,'') as ThongBao
END
--select * from HR_TimeKeeping_Data




GO
