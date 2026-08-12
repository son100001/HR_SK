CREATE function [dbo].[udf_TinhPCXangXe]
(
	@fromdate datetime,
	@todate datetime
)
returns @rtnTinhPCXangXe table
(	--Select * from udf_TinhPCXangXe ('2023-07-01','2023-07-31') where Employee_ID = 'M01366'
	Employee_ID nvarchar(50), TienPCXangXe float, primary key (Employee_ID)
)
as
begin
	Declare @TienXangXeToiThieu float
	select @TienXangXeToiThieu = [Value] from HR_SetUpFollowDate where Group_='Salary' and Code = 'XangXeToiThieu' and Fromdate<=@todate and (Todate is null or Todate>=@fromdate) order by Fromdate asc
	insert into @rtnTinhPCXangXe (Employee_ID, TienPCXangXe)
	select empl.Employee_ID, @TienXangXeToiThieu + (case when isnull(empl.TernimationDate,@todate+1) between @fromdate and @todate then 0 when empl.DepartmentCode1 in ('MAT','MET') then (case when datediff(day,nkhdct.NgayKyHDChinhThuc,@todate)/30.3 between 3 and 6 then 100000 when datediff(day,nkhdct.NgayKyHDChinhThuc,@todate)/30.3 between 6.0000001 and 12 then 150000 when datediff(day,nkhdct.NgayKyHDChinhThuc,@todate)/30.3 > 12 then 200000  else 0 end) else 0 end)
	from
	udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,@todate) empl
	left join
	udf_NgayKyHDChinhThuc(@fromdate,@todate,null) nkhdct
	on empl.Employee_ID = nkhdct.Employee_ID
	return
end

GO
