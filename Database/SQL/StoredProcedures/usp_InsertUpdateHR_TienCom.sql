
CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_TienCom]
	--exec [dbo].[usp_InsertUpdateHR_CapPhatAo] null,N'11111','M','Red',3,'2019-11-14',null,null,'admin'
	--select * from HR_CapPhatAo
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@TienCom float,
	@Ngay datetime,
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
	--Hàm kiểm tra xem nhân viên có hợp lệ không
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@Ngay,@UserName,'HR_TienCom')
	if ISNULL(@thongbao,'')='' begin
		if exists(select Employee_ID from HR_TienCom where (Employee_ID=@Employee_ID and Ngay=@Ngay)or ID=isnull(@ID,0))
		begin
		update HR_TienCom
		 set Employee_ID=@Employee_ID, TienCom=@TienCom,Ngay=@Ngay,Remark=@Remark,InsertDate=Getdate(),username=@UserName
		 where (Employee_ID=@Employee_ID and Ngay=@Ngay)or ID=isnull(@ID,0)
		end
		else begin
			insert into HR_TienCom([Employee_ID],TienCom,Ngay,Remark,[InsertDate],[UserName])
			values(@Employee_ID,@TienCom,@Ngay,@Remark,Getdate(),@UserName)
		end
		select @ID=ID from HR_TienCom where Employee_ID=@Employee_ID and Ngay=@Ngay
	end
	select @ThongBao as ThongBao,@ID as ID
END




GO
