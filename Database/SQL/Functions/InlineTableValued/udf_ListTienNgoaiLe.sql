-- =============================================  
-- Author:  Nguyen Tran Hieu 
-- ALTER  date: 12/06/2019 
-- Description: Load danh sach tien ngoai le trong thang

CREATE FUNCTION [dbo].[udf_ListTienNgoaiLe]     
(
	@nam int,
	@thang int
) 
RETURNS table      
AS                 
RETURN (
		select emp.Employee_ID as ID, emp.Employee_ID,emp.Employee_FirstName,emp.Employee_LastName,emp.Sex,emp.Employee_Status, 
        emp.StartedDate,emp.TernimationDate,emp.TeamCode,Position_NameVN as Position_ID,t.Amount,t.remark,t.Thang,t.Nam,DepartmentName_VN as DepartmentCode,SectionName_VN as SectionCode, emp.PositionCategory_ID 
        from SmartBooks_Employee emp 
		left join  
		(
			select * from HR_TienNgoaiLe where nam= @nam and thang=@thang
		)t on t.Employee_ID COLLATE DATABASE_DEFAULT = emp.Employee_ID 
		left join SmartBooks_Position p on p.Position_ID = emp.Position_ID
		left join SmartBooks_Department d on d.DepartmentCode = emp.DepartmentCode
		left join SmartBooks_Section  s on s.SectionCode = emp.SectionCode
)




GO
