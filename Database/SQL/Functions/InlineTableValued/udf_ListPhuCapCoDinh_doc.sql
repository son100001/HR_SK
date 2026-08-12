-- =============================================  
-- Author:  Nguyen Tran Hieu 
-- ALTER  date: 15/01/2017 
-- Description: load danh sach phi cap co dinh - 1 nguoi nhieu dong
-- select * from  udf_ListPhuCapCoDinh_doc('2019/06/01','2019/06/30') 
CREATE FUNCTION [dbo].[udf_ListPhuCapCoDinh_doc]     
(
	@fromdate datetime,        
	@todate datetime
) 
RETURNS table      
AS                 
RETURN (
	select pcct.[ID],pcct.Employee_ID,Employee_Firstname,Employee_LastName,StartedDate,OfficialDate,
	d.DepartmentName_VN as DepartmentCode,s.SectionName_VN as SectionCode,p.Position_NameVN as Position_ID,UpdateBy,UpdateDate,pcct.Allowance_Code,pccd.Allowance_NameVN,pccd.Allowance_NameEN,pccd.Allowance_NameKR,
	ERN_CODE,ERN_NAME,PAY_USE_CODE,PAY_USE_NAME,pcct.AMOUNT,pcct.fromdate,pcct.todate 
	from HR_PhuCapCoDinh_Chitiet pcct 
	inner join
	(
		select Employee_ID,max(fromdate) as fromdate from HR_PhuCapCoDinh_Chitiet where fromdate<=@todate
		group by Employee_ID
	) pcct1 on pcct1.Employee_ID =pcct.Employee_ID
	inner join HR_PhuCapCoDinh pccd on pcct.Allowance_Code = pccd.Allowance_Code
	left join SmartBooks_Employee emp on emp.Employee_ID COLLATE DATABASE_DEFAULT = pcct.Employee_ID
	left join SmartBooks_Department d on d.DepartmentCode = emp.DepartmentCode
	left join SmartBooks_Section s on s.SectionCode = emp.SectionCode and s.DepartmentCode = emp.DepartmentCode
	left join SmartBooks_Position p on p.Position_ID = emp.Position_ID
	--where pcct.Employee_ID='19000070'

)




GO
