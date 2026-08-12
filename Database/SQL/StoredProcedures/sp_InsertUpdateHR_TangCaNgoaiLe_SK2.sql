CREATE proc [dbo].[sp_InsertUpdateHR_TangCaNgoaiLe_SK2]
@ID int,
@Factory_ID_SK2 nvarchar(50),
@Ngay_SK2 datetime,
@Gio_SK2 float,
@InsertDate datetime,
@UserName nvarchar(50)
as
begin
	if exists(select * from HR_TangCaNgoaiLe_SK2 where (Factory_ID_SK2=@Factory_ID_SK2 and Ngay_SK2 = @Ngay_SK2) or ID=isnull(@ID,0))
	BEGIN
		update HR_TangCaNgoaiLe_SK2 set Gio_SK2 = @Gio_SK2, InsertDate = @InsertDate, UserName = @UserName
			where (Factory_ID_SK2=@Factory_ID_SK2 and Ngay_SK2 = @Ngay_SK2) or ID=isnull(@ID,0)
	END ELSE BEGIN
		insert into HR_TangCaNgoaiLe_SK2 (Factory_ID_SK2, Ngay_SK2, Gio_SK2, InsertDate, UserName)
						values(@Factory_ID_SK2, @Ngay_SK2, @Gio_SK2, @InsertDate, @UserName)
	END
end

GO
