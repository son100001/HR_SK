
CREATE function udf_GetBasicInformationEmployee
()
returns @rtnGetBasicInformationEmployee table
(
	Employee_ID nvarchar(50),
	FullName nvarchar(500),
	BirthDate datetime,
	ID_Number nvarchar(20),
	StartedDate datetime,
	OfficialDate datetime,
	TernimationDate datetime,
	EmployeeStatus nvarchar(50),
	Card_Code nvarchar(50),
	FactoryName nvarchar(500),
	DepartmentName nvarchar(500),
	PositionFullName nvarchar(500),
	primary key (Employee_ID)
)
as
begin
	insert into @rtnGetBasicInformationEmployee
	select Employee_ID, dbo.udf_FullName(Employee_Firstname,Employee_LastName), BirthDate, ID_number, StartedDate, OfficialDate, TernimationDate, Employee_Status, Card_Code, FactoryName, DepartmentName, PositionFullName
	from
	udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,GETDATE())
	return
end
GO
