CREATE procedure [dbo].[sp_getLinkResetPassword]
@Username nvarchar(50),
@Email nvarchar(200),
@License nvarchar(Max)
as
begin
	--Declare @ThongBao nvarchar(50)
	update us
	set QuyenTruyXuat = @license
	from
	dbo.[User] us
	left join
	SmartBooks_Employee empl
	on us.UserName = empl.Employee_ID
	where us.UserName = isnull(@Username,'') or isnull(@Email,'') = empl.Email

	If exists (select QuyenTruyXuat from dbo.[User] where QuyenTruyXuat = @license)
		select empl.Email, su.Email as CP_Email, su.PassEmail as CP_PassEmail, su.SMTP_Client as CP_SMTP_Client, su.[Port] as CP_Port, su.[SSL] as CP_SSL
		from
		dbo.[User] us 
		left join
		SmartBooks_Employee empl
		on us.UserName = empl.Employee_ID
		left join
		(
			SELECT 
				MAX(CASE WHEN su.ID = 'Email' THEN su.[Value] END) AS Email,
				MAX(CASE WHEN su.ID = 'PassEmail' THEN su.[Value] END) AS PassEmail,
				MAX(CASE WHEN su.ID = 'SMTP_Client' THEN su.[Value] END) AS SMTP_Client,
				MAX(CASE WHEN su.ID = 'Port' THEN su.[Value] END) AS Port,
				MAX(CASE WHEN su.ID = 'SSL' THEN su.[Value] END) AS SSL
			FROM setup su
			WHERE su.FunctionID = 'Email'
		) su
		on 1=1
		where us.UserName = isnull(@Username,'') or isnull(@Email,'') = empl.Email
end
GO
