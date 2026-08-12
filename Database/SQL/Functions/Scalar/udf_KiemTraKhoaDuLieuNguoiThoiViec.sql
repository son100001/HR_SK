CREATE FUNCTION [dbo].[udf_KiemTraKhoaDuLieuNguoiThoiViec]
(
	-- Add the parameters for the function here
	@Employee_ID nvarchar(50),
	@UserName nvarchar(50)
)
RETURNS nvarchar(255)
AS
BEGIN
	declare @ThongBao nvarchar(255),@Block_Date_Termination datetime
	set @ThongBao=''
	select @Block_Date_Termination=Block_Date from HR_Khoa where TableName='HR_WTDaily_Termination' and username=@UserName
	if exists(select * from smartbooks_employee where employee_id=@Employee_ID and TernimationDate<=@Block_Date_Termination) begin
		set @ThongBao=@ThongBao+N'Dakhoadulieucuanguoithoiviec'
	end

	-- Return the result of the function
	RETURN @ThongBao

END




GO
