





CREATE           FUNCTION [dbo].[udf_TongHopPhepThang]     
(
@fromdate datetime,        
@todate datetime
)      
RETURNS table      
AS                
RETURN (
select emp.Employee_ID, emp.Employee_Firstname, emp.Employee_LastName, TongGioPhepNam, TongGioKhongPhep, TongGioNghiPhepCTYTraLuong, TongGioNghiPhepBHTraLuong, TongGioNghiPhepKhongDuocTraLuong, TongGioNghiCoPhepKhongDuocTraLuong
from
SmartBooks_Employee emp
left join
(select Employee_ID, sum(isnull(HourLeave,0)) as TongGioPhepNam from HR_EmpRegisLeave where DateLeave between @fromdate and @todate and LeaveType_ID in (select [ID] from SmartBooks_LeaveType where PhepNam = '1') group by Employee_ID) as pn
on emp.Employee_ID COLLATE DATABASE_DEFAULT = pn.Employee_ID
left join
(select Employee_ID, sum(isnull(HourLeave,0)) as TongGioKhongPhep from HR_EmpRegisLeave where DateLeave between @fromdate and @todate and LeaveType_ID in (select [ID] from SmartBooks_LeaveType where NotAllow = '1') group by Employee_ID) as kp
on emp.Employee_ID COLLATE DATABASE_DEFAULT = kp.Employee_ID
left join
(select Employee_ID, sum(isnull(HourLeave,0)) as TongGioNghiPhepCTYTraLuong from HR_EmpRegisLeave where DateLeave between @fromdate and @todate and LeaveType_ID in (select [ID] from SmartBooks_LeaveType where isLeave_ComPay = '1') group by Employee_ID) as NghiDuocCTYTraLuong
on emp.Employee_ID COLLATE DATABASE_DEFAULT = NghiDuocCTYTraLuong.Employee_ID
left join
(select Employee_ID, sum(isnull(HourLeave,0)) as TongGioNghiPhepBHTraLuong from HR_EmpRegisLeave where DateLeave between @fromdate and @todate and LeaveType_ID in (select [ID] from SmartBooks_LeaveType where isLeave_InsPay = '1') group by Employee_ID) as NghiDuocBHTraLuong
on emp.Employee_ID COLLATE DATABASE_DEFAULT = NghiDuocBHTraLuong.Employee_ID
left join
(select Employee_ID, sum(isnull(HourLeave,0)) as TongGioNghiPhepKhongDuocTraLuong from HR_EmpRegisLeave where DateLeave between @fromdate and @todate and LeaveType_ID in (select [ID] from SmartBooks_LeaveType where isLeave_nonPay = '1') group by Employee_ID) as NghiKhongDuocTraLuong
on emp.Employee_ID COLLATE DATABASE_DEFAULT = NghiKhongDuocTraLuong.Employee_ID
left join
(select Employee_ID, sum(isnull(HourLeave,0)) as TongGioNghiCoPhepKhongDuocTraLuong from HR_EmpRegisLeave where DateLeave between @fromdate and @todate and LeaveType_ID in (select [ID] from SmartBooks_LeaveType where isLeave_nonPay = '1' and (NotAllow = '0' or NotAllow is null)) group by Employee_ID) as NghiCoPhepKhongDuocTraLuong
on emp.Employee_ID COLLATE DATABASE_DEFAULT = NghiCoPhepKhongDuocTraLuong.Employee_ID
)

--select * from udf_TongHopPhepThang('2015-2-1', '2015-2-28') where employee_id = '00018'














GO
