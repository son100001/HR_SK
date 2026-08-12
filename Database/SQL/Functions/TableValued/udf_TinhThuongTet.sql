create function udf_TinhThuongTet
(
	@Year int
)
returns @rtnTinhThuongTet table 
(
	Employee_ID nvarchar(50), NgayNghiThaiSan datetime, NgayLamThaiSan datetime, LuongT1 float, LuongT2 float, LuongT3 float, LuongT4 float, LuongT5 float, LuongT6 float, LuongT7 float, LuongT8 float, LuongT9 float, LuongT10 float, LuongT11 float
	, LuongT12 float, primary key (Employee_ID)
)
as
begin
	Declare @NgayCuoiNam datetime
	select @NgayCuoiNam = cast(@Year as nvarchar(5)) + '-12-31'
	insert into @rtnTinhThuongTet(Employee_ID)
	select Employee_ID
	from
	udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,getdate()) empl
	return
end
GO
