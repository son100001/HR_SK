





CREATE  proc [dbo].[sp_getpermssion]
@username as varchar(50)
as
select formid from Permission
where username = @username
order by [formid]









GO
