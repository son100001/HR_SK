
--select * from [dbo].[udf_BangDangKyCaTheoViTri]('2025-09-01','2025-09-30',null,null,null,null,null,null,null)
CREATE FUNCTION [dbo].[udf_BangDangKyCaTheoViTri]
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime,
	@fact as nvarchar(50)=null,
	@dept as nvarchar(50)=null,
	@sect as nvarchar(50)=null,
	@team as nvarchar(50)=null,
	@pos as nvarchar(50)=null,
	@posc as nvarchar(50)=null,
	@Employee_ID_ nvarchar(50)=null
)
RETURNS TABLE
AS
RETURN
(
	select
		empl.[Employee_ID] as Employee_ID,
		su.[Value] as ShiftName,
		empl.ComStartedDate as ComStartedDate,
		empl.TernimationDate as TernimationDate,
		empl.FactoryName as FactoryName,
		empl.DepartmentName as DepartmentName,
		empl.SectionName as SectionName,
		empl.isManager as isManager
	from
	udf_EmployeeFilter('VN',@fact,@dept,@sect,@team,@pos,@posc,@Employee_ID_,@todate) empl
	left join
	SetUp su
	on su.ID='CaMacDinh'
	where empl.ComStartedDate<=@todate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)
);

GO
