-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[udf_BaoCaoGioiTinhNhanSu] 
(	
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select Nhom.DepartmentCode, Nhom.SectionCode, Male.SoLuong as MaleSoLuong, Female.SoLuong as FemaleSoLuong
	from
	(
		SELECT distinct DepartmentCode, SectionCode from SmartBooks_Employee
		where StartedDate <= @todate
			and (TernimationDate is null or TernimationDate > @todate)
	)as Nhom
	left join
	(
		SELECT DepartmentCode, SectionCode, Count(Employee_ID) as SoLuong from SmartBooks_Employee
		where StartedDate <= @todate
		and (TernimationDate is null or TernimationDate > @todate)
		and Sex = 'Male'
		group by DepartmentCode, SectionCode
	) as Male
	on Nhom.DepartmentCode = male.DepartmentCode and Nhom.SectionCode = male.SectionCode
	left join
	(
		SELECT DepartmentCode, SectionCode, Count(Employee_ID) as SoLuong from SmartBooks_Employee
		where StartedDate <= @todate
		and (TernimationDate is null or TernimationDate > @todate)
		and Sex = 'Female'
		group by DepartmentCode, SectionCode
	) as Female
	on Nhom.DepartmentCode = Female.DepartmentCode and Nhom.SectionCode = Female.SectionCode
		
)




GO
