CREATE proc [dbo].[sp_InsertUpdateHR_TangCaNgoaiLe_SK1]
@ID int,
@Factory_ID_SK1 nvarchar(50),
@Ngay_SK1 datetime,
@Gio_SK1 float,
@insertDate datetime,
@UserName nvarchar(50)
as
begin
	if exists(select * from HR_TangCaNgoaiLe_SK1 where (Factory_ID_SK1=@Factory_ID_SK1 and Ngay_SK1 = @Ngay_SK1) or ID=isnull(@ID,0))
	BEGIN
		update HR_TangCaNgoaiLe_SK1 set Gio_SK1 = @Gio_SK1, @insertDate = GETDATE(), UserName = @UserName
			where (Factory_ID_SK1=@Factory_ID_SK1 and Ngay_SK1 = @Ngay_SK1) or ID=isnull(@ID,0)
	END ELSE BEGIN
		insert into HR_TangCaNgoaiLe_SK1 (Factory_ID_SK1, Ngay_SK1, Gio_SK1, InsertDate, UserName)
						values(@Factory_ID_SK1, @Ngay_SK1, @Gio_SK1, @insertDate, @UserName)
	END
end

GO
