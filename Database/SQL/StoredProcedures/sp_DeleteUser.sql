

















CREATE PROCEDURE [dbo].[sp_DeleteUser] 
@UserName nvarchar(50)
as
BEGIN

DELETE 
FROM [user]
WHERE ((([user].UserName) = @UserName ));
END

BEGIN
DELETE 
FROM Permission
WHERE (((Permission.UserName) = @UserName));
END





















GO
