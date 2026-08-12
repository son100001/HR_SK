--exec sp_GetUserEmployeeID 1, N'KR001'
create PROCEDURE [dbo].[sp_GetUserEmployeeID]
    @type int,
    @UserName NVARCHAR(50)
AS
BEGIN
    DECLARE @user_employee_id NVARCHAR(50),@user_employee_Name NVARCHAR(50);
    
    -- Lấy Employee_ID từ bảng User với UserName được cung cấp
    SELECT @user_employee_id = Employee_ID,@user_employee_Name=FullName FROM [User] WHERE UserName = @UserName;

    -- Trả về Employee_ID nếu tìm thấy, ngược lại trả về NULL
    IF @user_employee_id IS NOT NULL 
    BEGIN
        SELECT @user_employee_id AS Employee_ID,@user_employee_Name as FullName;
    END
    ELSE
    BEGIN
        SELECT NULL AS Employee_ID;
    END
END;


--select Employee_ID from [User] where UserName=N'KR001' 
--select * from [User] where UserName='" + obj.UserName + "' and GroupID='admin'
GO
