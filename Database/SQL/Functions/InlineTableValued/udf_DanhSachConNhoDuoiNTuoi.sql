

CREATE FUNCTION [dbo].[udf_DanhSachConNhoDuoiNTuoi] 
(	
	-- Add the parameters for the function here
	@N int,--Số tuổi
	@fromdate datetime,
	@todate datetime,
	@LAN nvarchar(50),
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Emp  nvarchar(50)=null
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select empl.FactoryName,empl.DepartmentName,empl.SectionName, empl.Employee_ID, [dbo].[udf_FullName](Employee_Firstname,Employee_LastName) as FullNameOfEmployee ,empl.StartedDate,empl.ComStartedDate,empl.Employee_Status,empl.TernimationDate,empl.Sex as SexOfEmployee
			, ef.RelatedName, ef.RelatedType, ef.Sex, ef.BirthDate
			, dateadd(year,@N,ef.BirthDate) as [Expiredate]
	from
	udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,getdate())) empl
	inner join
	SmartBooks_Employee_Family ef
	on empl.Employee_ID=ef.Employee_ID
	where empl.ComStartedDate<=@todate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)
	and DATEADD(year,@N,ef.BirthDate)>=@fromdate and ef.BirthDate<=@todate and ef.RelatedType in ('6','7') and empl.Sex='Female'
)




GO
