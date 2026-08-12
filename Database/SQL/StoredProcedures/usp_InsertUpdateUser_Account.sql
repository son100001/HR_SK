CREATE PROCEDURE [dbo].[usp_InsertUpdateUser_Account]
	-- Add the parameters for the stored procedure here
	--exec usp_InsertUpdateSmartBooks_Employee N'19001132',N'A b',N'C','1984-02-05 00:00:00',N'Tỉnh Thanh Hóa',N'Female',N'Single',N'Việt Nam',N'003456',N'12345678','2000-01-01 00:00:00',N'Tỉnh Bình Phước',N'adfafd - Phường Long Bình - Quận 9 - Thành phố Hồ Chí Minh',N' -Xã Tân Quan - Huyện Hớn Quản - Tỉnh Bình Phước',N'Tỉnh Thanh Hóa',N'Hiring','2019-07-01 00:00:00','2019-07-01 00:00:00',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,N'Cấp II',null,N'Trường Cấp II',null,null,N'252345',null,null,null,null,N'H?i Giáo',null,null,null,null,null,null,N'admin','2019-07-01 15:37:47',null
	@ID nvarchar(50),
	@FatherUser nvarchar(50),
	@UserName nvarchar(50),
	@Password nvarchar(500),
	@Employee_ID [nvarchar](50),
	@FullName nvarchar(500),
	@GroupID nvarchar(50),
	@InsertDate datetime,
	@InsertBy nvarchar(50),
	@QuyenTruyXuat varchar(500),
	@Quyen float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255),@MaCongTy nvarchar(50)
	select @MaCongTy=[Value] from SetUp where ID='MaCongTy'
	if @Password is null
		select @Password = [Password] from [User] where Employee_ID = @Employee_ID
	if @GroupID is null
		select @GroupID = GroupID from [User] where Employee_ID = @Employee_ID
	if @Password is null
		select @Password = [Password] from [User] where Employee_ID = @Employee_ID
	if @FatherUser is null
		select @FatherUser = FatherUser from [User] where Employee_ID = @Employee_ID
	set @ThongBao=''
	if ISNULL(@thongbao,'')='' begin
		if exists (select Employee_ID from [User] where Employee_ID=@Employee_ID) begin
			update [User]
			set 
			FatherUser = @FatherUser,
			UserName = @UserName,
			[Password] = @Password,
			FullName = @FullName,
			GroupID = @GroupID,
			InsertDate = @InsertDate,
			InsertBy = @InsertBy,
			QuyenTruyXuat = @QuyenTruyXuat,
			Quyen = @Quyen
			where Employee_ID=@Employee_ID
		end else begin
			insert into [User]
			(
				FatherUser,
				UserName,
				[Password],
				Employee_ID,
				FullName,
				GroupID,
				InsertDate,
				InsertBy,
				QuyenTruyXuat,
				Quyen,
				FirstTimeLogin
			)
			values
			(
				@FatherUser,
				@UserName,
				@Password,
				@Employee_ID,
				@FullName,
				@GroupID,
				@InsertDate,
				@InsertBy,
				@QuyenTruyXuat,
				@Quyen,
				1
			)
		end
	end

	select @ThongBao as ThongBao
END
GO
