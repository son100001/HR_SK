CREATE proc sp_GexMaxEmployee_ID
as
begin
	select max(cast(right(Employee_ID,len(Employee_ID) - 1) as int)) as Data_
	from
	SmartBooks_Employee
	where Employee_ID like 'C%'
end
GO
