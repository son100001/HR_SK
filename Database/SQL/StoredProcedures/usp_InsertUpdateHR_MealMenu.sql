
CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_MealMenu]
	--exec [dbo].[usp_InsertUpdateHR_CapPhatAo] null,N'11111','M','Red',3,'2019-11-14',null,null,'admin'
	--select * from HR_CapPhatAo
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@Picture image
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255)
	if ISNULL(@thongbao,'')='' begin
		if exists(select Fromdate from HR_MealMenu where Fromdate = @fromdate)
		begin
		update HR_MealMenu
		 set Todate=@todate, Picture = @Picture
		 where Fromdate = @fromdate
		end
		else begin
			insert into HR_MealMenu (Fromdate,Todate,Picture)
			values(@Fromdate,@todate,@Picture)
		end
	end
	select @ThongBao as ThongBao
END




GO
