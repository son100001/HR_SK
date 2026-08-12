--exec usp_InsertUpdateHR_EmpRegisParameter null,N'S000193',N'PCPhapDinh','1000000','2019-09-01',null,N'ghi chú','2019-10-12 14:11:53',N'admin'


CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_EmpRegisParameter]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@ParameterValue nvarchar(50),
	@Parameter varchar(50),
	@fromdate datetime,
	@todate datetime,
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
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@fromdate,@UserName,'HR_EmpRegisParameter')
	if exists(select Employee_ID from HR_EmpRegisParameter where Employee_ID=@Employee_ID and Parameter=@Parameter and (@fromdate between fromdate and Todate or @todate between Fromdate and Todate or Fromdate between @fromdate and @todate or Todate between @fromdate and @todate)) begin
		set @ThongBao=@ThongBao+'DuLieuBiTrung'
	end
	if ISNULL(@thongbao,'')='' begin
		if exists(select Employee_ID from HR_EmpRegisParameter where (Employee_ID=@Employee_ID and Parameter=@Parameter and fromdate=@fromdate) or ID=isnull(@ID,0))
		begin
			update HR_EmpRegisParameter
			set Employee_ID=@Employee_ID,Parameter=@Parameter,ParameterValue=@ParameterValue,fromdate=@fromdate,todate=@todate,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
			where (Employee_ID=@Employee_ID and Parameter=@Parameter and fromdate=@fromdate) or ID=isnull(@ID,0)
		end else begin
			if exists(select Employee_ID from HR_EmpRegisParameter where Employee_ID=@Employee_ID and Parameter=@Parameter and (@fromdate between Fromdate and Todate or @todate between Fromdate and Todate)) begin
				set @ThongBao=N'Dulieukhonghople'
			end else begin
				insert into HR_EmpRegisParameter
				(
					[Employee_ID],
					[ParameterValue],
					[Parameter],
					fromdate,
					todate,
					[Remark],
					[InsertDate],
					[UserName]
				)
				values(@Employee_ID,@ParameterValue,@Parameter,@fromdate,@todate,@Remark,GETDATE(),@UserName)
			end
		end
	end
	select @ID=ID from HR_EmpRegisParameter where Employee_ID=@Employee_ID and fromdate=@fromdate and Parameter=@Parameter
	select @ThongBao as ThongBao,@ID as ID
END




GO
