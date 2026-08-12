-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--select * from [udf_DangKyThongTinGiaDinhSai]()
CREATE FUNCTION [dbo].[udf_DangKyThongTinThaiSanBatThuong]
(	
	-- Add the parameters for the function here
	@SoNgaySauKhiMangBauDuocHuongThaiSan int
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select erp.[ID], erp.[Employee_ID], erp.FromDate, erp.ToDate, DATEADD(day, @SoNgaySauKhiMangBauDuocHuongThaiSan, erp.FromDate) as NgayHuongCheDo, erp.Remark, erp.InsertDate, erp.UserName
			,emp.BirthDate,emp.Employee_Firstname, emp.Employee_LastName, emp.Sex, emp.StartedDate, emp.TernimationDate, emp.Employee_Status, emp.DepartmentCode, emp.SectionCode, emp.TeamCode, emp.Position_ID, emp.PositionCategory_ID
			,emp.Employee_Firstname + (case when emp.Employee_LastName is null then '' else ' ' + emp.Employee_LastName end) as fullname
			,(case when [Sex] = N'Male' then N'Nam' else N'Nữ' end) as SexTranslate
	from
	(
		select distinct erp1.ID
		from
		[dbo].[HR_EmployeeRegisPregnant] erp1
		left join
		[dbo].[HR_EmployeeRegisPregnant] erp2
		on erp1.Employee_ID = erp2.Employee_ID and erp1.ID<>erp2.ID
		and
		(
			erp1.Fromdate between erp2.Fromdate and erp2.ToDate
			or
			erp1.todate between erp2.Fromdate and erp2.ToDate
			or
			erp2.Fromdate between erp1.Fromdate and erp1.ToDate
			or
			erp2.todate between erp1.Fromdate and erp1.ToDate
		)
		where erp2.Employee_ID is not null
		union
		select distinct erp1.ID
		from
		[dbo].[HR_EmployeeRegisPregnant] erp1
		left join
		[dbo].[HR_EmployeeRegisPregnant] erp2
		on erp1.Employee_ID = erp2.Employee_ID and erp1.ID<>erp2.ID
		and
		(
			erp1.Fromdate between erp2.Fromdate and erp2.ToDate
			or
			erp1.todate between erp2.Fromdate and erp2.ToDate
			or
			erp2.Fromdate between erp1.Fromdate and erp1.ToDate
			or
			erp2.todate between erp1.Fromdate and erp1.ToDate
		)
		where erp2.Employee_ID is not null
	) as erp_err
	left join
	[dbo].[HR_EmployeeRegisPregnant] erp
	on erp_err.ID = erp.ID
	left join
	SmartBooks_Employee emp
	on erp.Employee_ID COLLATE DATABASE_DEFAULT = emp.Employee_ID
)




GO
