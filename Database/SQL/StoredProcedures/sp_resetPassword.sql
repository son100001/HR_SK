create procedure [dbo].[sp_resetPassword]
@UserName nvarchar(50),
@NewPassword nvarchar(Max),
@LicenseID nvarchar(Max)
as
begin
	--Declare @ThongBao nvarchar(50)
	update us
	set [Password] = @NewPassword
		, QuyenTruyXuat = Null
		, FirstTimeLogin = 'False'
	from
	dbo.[User] us
	where [UserName] = @UserName --and left(QuyenTruyXuat,450) = @LicenseID

	select 'Successfull' as Result
end
GO
