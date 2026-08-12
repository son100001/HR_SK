CREATE function [dbo].[udf_BangTangNhanVienTrongThang] 
(
	@fromdate datetime,
	@todate datetime
)
returns @rtnBangTangNhanVienTrongThang table (DepartmentCode nvarchar(100), TongNV int, SoTangNV float, Under1Month float, From1To3Months float, From3To6Months float, From6To12Months float, Over1Year float, primary key (DepartmentCode))
as
begin
	insert into @rtnBangTangNhanVienTrongThang
	select empl.DepartmentCode1, count(empl.Employee_ID) as TongNV, count(tf.Employee_ID) as SoTangNV
			, sum(case when empl.TernimationDate is not null and datediff(day, empl.StartedDate, isnull(empl.TernimationDate,@todate)) <= 30 then 1 else 0 end) as Under1Month
			, sum(case when empl.TernimationDate is not null and datediff(day, empl.StartedDate, isnull(empl.TernimationDate,@todate)) between 30 and 90 then 1 else 0 end) as From1To3Months
			, sum(case when empl.TernimationDate is not null and datediff(day, empl.StartedDate, isnull(empl.TernimationDate,@todate)) between 91 and 180 then 1 else 0 end) as From3To6Months
			, sum(case when empl.TernimationDate is not null and datediff(day, empl.StartedDate, isnull(empl.TernimationDate,@todate)) between 181 and 365 then 1 else 0 end) as From6To12Months
			, sum(case when empl.TernimationDate is not null and datediff(day, empl.StartedDate, isnull(empl.TernimationDate,@todate)) > 365 then 1 else 0 end) as Over1Year
	from
	udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,GETDATE()) empl
	left join
	HR_Transfer tf
	on empl.Employee_ID = tf.Employee_ID and tf.TypeOfTransfer = 'Position' and tf.EffectiveDate between @fromdate and @todate
	where isnull(empl.TernimationDate,@todate) > @fromdate and empl.DepartmentCode1 is not null
	group by empl.DepartmentCode1
	return 
end
--select * from [dbo].[udf_BangTangNhanVienTrongThang] ('2023-01-01', '2023-01-31')
GO
