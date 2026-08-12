






















create proc [dbo].[sp_changePassword]
@UserName as varchar(50),
@Password as varchar(50)
as
update [User] set [Password] = @Password
where [UserName]= @UserName 




























GO
