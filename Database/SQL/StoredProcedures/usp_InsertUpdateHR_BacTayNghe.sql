CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_BacTayNghe]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Nhom varchar(50),
	@Bac varchar(50),
	@Amount float,
	@FromDate datetime,
	@ToDate datetime,
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
	if @ToDate<@Fromdate begin
		set @ThongBao=N'Dulieukhonghople'
	end
	if ISNULL(@thongbao,'')='' begin
		if exists(select ID from HR_BacTayNghe where (Nhom=@Nhom and Bac=@Bac and Fromdate=@Fromdate) or ID=isnull(@ID,0))
		begin
			update HR_BacTayNghe
			set Nhom=@Nhom,Bac=@Bac,Amount=@Amount,FromDate=@FromDate,ToDate=@ToDate,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
			where (Nhom=@Nhom and Bac=@Bac and Fromdate=@Fromdate) or ID=isnull(@ID,0)
		end else begin
			insert into HR_BacTayNghe
			(
				Nhom,
				Bac,
				Amount,
				FromDate,
				ToDate,
				[Remark],
				[InsertDate],
				[UserName]
			)
			values(@Nhom,@Bac,@Amount,@FromDate,@ToDate,@Remark,GETDATE(),@UserName)
		end
	end
	select @ID=ID from HR_BacTayNghe where Nhom=@Nhom and Bac=@Bac and Fromdate=@Fromdate
	select @ThongBao as ThongBao,@ID as ID
END




GO
