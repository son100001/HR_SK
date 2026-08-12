-- =============================================  
-- Author:  Nguyen Tran Hieu 
-- ALTER  date: 15/01/2017 
-- Description: load danh sach phi cap co dinh
-- select * from  udf_DanhSachPhuCapCoDinh('2019/05/01','2019/05/31') 
CREATE FUNCTION [dbo].[udf_DanhSachPhuCapCoDinh]     
(
	@fromdate datetime,        
	@todate datetime
) 
RETURNS table      
AS                 
RETURN (
	select pcct.Allowance_Code,[ID],pcct.Employee_ID,Employee_Firstname,Employee_LastName,StartedDate,OfficialDate,
	DepartmentCode,SectionCode,Position_ID,UpdateBy,UpdateDate,ERN_CODE,ERN_NAME,PAY_USE_CODE,PAY_USE_NAME,pcct.AMOUNT,pcct.fromdate,pcct.todate 
	from HR_PhuCapCoDinh_Chitiet pcct 
	inner join
	(
		select Employee_ID,max(fromdate) as fromdate from HR_PhuCapCoDinh_Chitiet where fromdate<=@todate
		group by Employee_ID
	) pcct1 on pcct1.Employee_ID =pcct.Employee_ID
	inner join HR_PhuCapCoDinh pccd on pcct.Allowance_Code = pccd.Allowance_Code
	left join SmartBooks_Employee emp on emp.Employee_ID COLLATE DATABASE_DEFAULT = pcct.Employee_ID
	--where pcct.Employee_ID='19000070'
)




GO
