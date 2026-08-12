
CREATE proc [dbo].[sp_checkuserandpassword]
@UserName as varchar(50),
@Password as varchar(50)
as
select * from [User]
where [UserName]= @UserName and  isnull([Password],'')= @Password




GO
