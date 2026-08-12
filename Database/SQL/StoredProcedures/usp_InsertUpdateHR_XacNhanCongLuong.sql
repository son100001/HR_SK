
CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_XacNhanCongLuong]
	--exec [dbo].[usp_InsertUpdateHR_CapPhatAo] null,N'11111','M','Red',3,'2019-11-14',null,null,'admin'
	--select * from HR_CapPhatAo
	-- Add the parameters for the stored procedure here
	@Employee_ID nvarchar(50),
	@Month_ int,
	@Year_ int,
	@XacNhanCong nvarchar(50),
	@XacNhanLuong nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255)
	if ISNULL(@thongbao,'')='' begin
		if exists(select Employee_ID from HR_XacNhanCongLuong where Month_ = @Month_ and Year_ = @Year_ and Employee_ID = @Employee_ID)
		begin
		update HR_XacNhanCongLuong
		 set XacNhanCong = isnull(@XacNhanCong,XacNhanCong)
			, XacNhanLuong = isnull(@XacNhanLuong,XacNhanLuong)
		 where Month_ = @Month_ and Year_ = @Year_ and Employee_ID = @Employee_ID
		end
		else begin
			insert into HR_XacNhanCongLuong (Employee_ID,Month_,Year_,XacNhanCong,XacNhanLuong)
			values(@Employee_ID,@Month_,@Year_,@XacNhanCong,@XacNhanLuong)
		end
	end
	select @ThongBao as ThongBao
END




GO
