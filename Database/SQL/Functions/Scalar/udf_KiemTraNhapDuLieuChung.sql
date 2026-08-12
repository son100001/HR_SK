CREATE FUNCTION [dbo].[udf_KiemTraNhapDuLieuChung]
(
--select  [dbo].[udf_KiemTraNhapDuLieuChung]('C3673','2025-10-29','admin','')
	-- Add the parameters for the function here
	@Employee_ID nvarchar(50),
	@Date_ datetime,
	@UserName nvarchar(50),
	@KeyBlock varchar(100)
)
RETURNS nvarchar(255)
AS
BEGIN
	declare @ThongBao nvarchar(255),@GroupID nvarchar(50),@QuyenTruyXuat varchar(100)
	set @ThongBao=''
	select @GroupID=GroupID,@QuyenTruyXuat=QuyenTruyXuat from [user] where UserName=@UserName
	if ISNULL(@GroupID,'')<>'admin' and @keyblock not in ('HR_BankAccountOfEmployee','HR_DanhSachNguoiPhuThuoc','HR_SalaryComponentFollowMonth') begin
		if exists(select employee_id from [dbo].[udf_EmployeeFilter_Full]('VN',@QuyenTruyXuat,null,null,null,null,null,@Employee_ID,@Date_) empl where TernimationDate<=@Date_)
		begin
			set @ThongBao=N'Dathoiviec'
		end
		if exists(select * from HR_EmployeeRegisMaternityLeave where Employee_ID=@Employee_ID and @Date_ >= fromdate and LeaveType_ID='28')
		begin
			set @ThongBao=N'Daguithumoi'
		end
	end
	if exists(select TableName from HR_Khoa where TableName=@KeyBlock and Block_Date>=@Date_ and Block_User=@UserName) begin
		set @ThongBao=N'Dulieudabikhoa'
	end
	if @keyblock not in ('HR_EmployeeRegisPregnant','HR_EmpRegisParameter') begin
		if exists(select Employee_ID from [dbo].udf_EmployeeFilter_Full('VN',@QuyenTruyXuat,null,null,null,null,null,@Employee_ID,@Date_) where StartedDate>@Date_)
		begin
			set @ThongBao=N'Nhanvienchuavaocongty'
		end
	end
	if not exists(select Employee_ID from [dbo].udf_EmployeeFilter_Full('VN',null,null,null,null,null,null,@Employee_ID,getdate()))
	begin
		if not exists(select Employee_ID from [dbo].udf_EmployeeFilter_Full('VN',null,null,null,null,null,null,@Employee_ID,@Date_)) begin
			set @ThongBao=@ThongBao+N'Nhanvienkhongtontai'
		end
	end
	return @ThongBao
END

--select * from HR_EmployeeRegisMaternityLeave where Employee_ID='19000882'




GO
