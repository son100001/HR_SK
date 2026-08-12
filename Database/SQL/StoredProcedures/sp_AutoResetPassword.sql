--
CREATE proc [dbo].[sp_AutoResetPassword]
	@Employee_ID nvarchar(max)
as
--exec sp_AutoResetPassword 'C10851'
begin
	UPDATE us
SET us.[Password] = LOWER(
        CONVERT(VARCHAR(32),
            HASHBYTES('MD5',
                CAST(FORMAT(empl.BirthDate, 'ddMM') AS VARCHAR(255))
            ), 2)
    ),
    us.FirstTimeLogin = 1
	FROM [User] us
	JOIN SmartBooks_Employee empl 
		ON empl.Employee_ID = us.Employee_ID
		where us.Employee_ID in (select [Data] from Split(@Employee_ID, ','))

	select 'ThanhCong' as ThongBao
end

GO
