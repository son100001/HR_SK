CREATE proc sp_UpdateAfterSendEmail
@Employee_ID nvarchar(50),
@TypeOfNoti nvarchar(50)
as
begin
	update HR_DanhSachNguoiNhanThongBao
	set Sended = 1
	where case when @Employee_ID is null then '' else Employee_ID end = case when @Employee_ID is null then '' else @Employee_ID end 
			 and Type_ = @TypeOfNoti and Sended = 0

	select 'ThanhCong' as ThongBao
end
GO
