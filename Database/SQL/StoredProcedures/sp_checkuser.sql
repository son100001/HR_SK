












create proc [dbo].[sp_checkuser]
@UserName as varchar(50)
as
select * from [User]
where [UserName]= @UserName 






















GO
