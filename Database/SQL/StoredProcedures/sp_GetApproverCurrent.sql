CREATE proc [dbo].[sp_GetApproverCurrent]
@Account nvarchar(50),
@TypeOfReport int = 1,
@LAN nvarchar(50) = 'VN',
@Date datetime = null
as
begin
	set nocount on;
	select elr.ApproveLevel as Code, dbo.udf_FullName(empl.Employee_Firstname, empl.Employee_LastName) as [Name]
	from
	HR_EmployeeLeaveRequests elr
	left join
	SmartBooks_Employee empl
	on elr.ApproveLevel = empl.Employee_ID
	where elr.Employee_ID = @Account
		and empl.Employee_ID not in ('BOD01','BOD02')
	union
	select 'BOD02' as Code, 'Kim Jemin' as FullName
	union
	select 'BOD01' as Code, 'Kim Dong Woo' as FullName
	union
	Select 'C14908' as Code, N'Võ Thị Ngọc Hà' as FullName
	union
	select 'C10537' as Code, N'Lê Thị Hiệp' as FullName
	union
	select 'BV' as Code, N'Bảo vệ' as FullName
end
GO
