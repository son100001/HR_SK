--exec sp_GetUserInformation 1,'C10851','2901'
CREATE procedure [dbo].[sp_GetUserInformation]
@TypeOfReport int = 1,
@Username nvarchar(50),
@Password nvarchar(50) = null
as
begin
	if @TypeOfReport = 1 begin
		select us.*, empl.Email, QuyenTruyXuat as LicenseID
		from
		[User] us
		left join
		SmartBooks_Employee empl
		on us.Employee_ID = empl.Employee_ID
		where us.[UserName] = @Username and us.[Password] = @Password
	end else if @TypeOfReport = 2 begin
		select us.*, empl.Email, dbo.udf_FullName (empl.Employee_Firstname, empl.Employee_LastName) as FullName, QuyenTruyXuat as LicenseID
			from
			[User] us
			left join
			SmartBooks_Employee empl
			on us.Employee_ID = empl.Employee_ID
			where us.[UserName] = @Username
	end
end

--exec sp_GetUserInformation 1, N'00387', N'202cb962ac59075b964b07152d234b70'
GO
