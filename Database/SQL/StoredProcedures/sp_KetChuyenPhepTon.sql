
--Declare @year int = 2022, @NgayDauNam datetime, @UserName nvarchar(50)
--set @NgayDauNam= datefromparts(@year,1,1)
--exec sp_KetChuyenPhepTon 2024, 'admin'
CREATE proc [dbo].[sp_KetChuyenPhepTon]
	@Year int,
	@UserName nvarchar(50)
as
begin
	Declare @NgayDauNam datetime, @NgayCuoiThang1 datetime, @ThongBao nvarchar(50) = ''
	set @NgayDauNam= datefromparts(@year,1,1)
	set @NgayCuoiThang1 = EOMONTH(@NgayDauNam)

	if GETDATE() not between @NgayDauNam and @NgayCuoiThang1 begin
		set @ThongBao = 'QuaThoiGianChuyenPhepTon'
	end else begin
		Delete HR_DayVacationRemain
		where [Year] = @Year-1

		insert into HR_DayVacationRemain ([Year], Employee_ID, DaysRemain, UserName, InsertDate)
		select @year-1,empl.Employee_ID, qlpn.PhepNamConLai, @UserName, GETDATE() from
		SmartBooks_Employee empl
		left join
		udf_QuanLyPhepNam(@year-1,GETDATE(),'VN',null,null,null,null,null,null,null) qlpn
		on empl.Employee_ID = qlpn.Employee_ID
		where isnull(empl.TernimationDate,@NgayDauNam) >= @NgayDauNam and isnull(qlpn.PhepNamConLai,0) <> 0
		set @ThongBao = 'ThanhCong'
	end

	select @ThongBao as ThongBao
end
GO
