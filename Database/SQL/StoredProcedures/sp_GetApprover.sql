CREATE procedure [dbo].[sp_GetApprover]
@Account nvarchar(50),
@TypeOfReport int,
@LAN nvarchar(50) = 'VN',
@Date datetime = null
as
begin
--select * from udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,GETDATE())
--exec sp_GetApprover 'C10851',1,'EN'
	set nocount on;
	if @Date is null set @Date = GETDATE();
	Declare @ShiftName nvarchar(50)
	select @ShiftName = Shiftname from udf_DangKyCa (@Date,@Date,181,null,null,null,null,null,null,@Account)

	if (@Shiftname not like N'%shift3') 
	begin
		Select * from
		HR_GetApprover
		where Employee_ID = @Account
	end else begin
		select Null as Factory_ID, Null as DepartmentCode, Null as SectionName, Null as ChucDanh, @Account as Employee_ID
				, N'BV' as Code, case @LAN when N'VN' then N'Bảo vệ' when N'EN' then 'Guard' when N'KR' then N'경비원' when N'JP' then N'警備員' when N'CN' then N'保安' when 'KH' then N'បាវេ' end as [Name]
				, Null as ChiGuiThongBao
	end
end

GO
