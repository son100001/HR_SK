






















create proc [dbo].[st_getpermission]
@UserName as varchar(50),
@FormId as varchar(50)
as
select * from Permission
where UserName =@UserName
and FormId =@FormID




























GO
