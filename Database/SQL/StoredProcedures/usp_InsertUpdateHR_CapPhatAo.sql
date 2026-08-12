CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_CapPhatAo]
	--exec [dbo].[usp_InsertUpdateHR_CapPhatAo] null,N'11111','M','Red',3,'2019-11-14',null,null,'admin'
	--select * from HR_CapPhatAo
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@Size nvarchar(10),
	@Color nvarchar(20),
	@Number int,
	@DateIssued datetime,
	@ReturnDate datetime,
	@Remark nvarchar(225),
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
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@DateIssued,@UserName,'HR_CapPhatAo')
	if ISNULL(@thongbao,'')='' begin
		if exists(select Employee_ID from HR_CapPhatAo where (Employee_ID=@Employee_ID and DateIssued=@DateIssued)or ID=isnull(@ID,0))
		begin
		update HR_CapPhatAo
		 set Employee_ID=@Employee_ID, Size=@Size, Color=@Color,Number=@Number,DateIssued=@DateIssued,ReturnDate=@ReturnDate,Remark=@Remark,InsertDate=Getdate(),username=@UserName
		 where (Employee_ID=@Employee_ID and DateIssued=@DateIssued)
		end
		else begin
			insert into HR_CapPhatAo([Employee_ID],Size,Color,Number,DateIssued,ReturnDate,Remark,[InsertDate],[UserName])
			values(@Employee_ID,@Size,@Color,@Number,@DateIssued,@ReturnDate,@Remark,Getdate(),@UserName)
		end
		select @ID=ID from HR_CapPhatAo where Employee_ID=@Employee_ID and DateIssued=@DateIssued
	end
	select @ThongBao as ThongBao,@ID as ID
END




GO
