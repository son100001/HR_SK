--exec Sp_TongHopPhep '2015-12-01','2015-12-12'
-- =============================================  
-- Author:  Nguyen Tran Hieu 
-- Create date: 25/01/2016  
-- Description: Tao bao cao tong hop phep
-- =============================================  
CREATE  PROCEDURE [dbo].[Sp_TongHopPhep]     
(
@fromdate datetime,        
@todate datetime
)  
as    
--tam thoi fix cung, sau truyen them bien danh sach loai nghi vao de xu ly
select emp.Employee_ID, emp.Employee_Firstname +' '+ emp.Employee_LastName as fullname,emp.Position_ID,emp.StartedDate,
(RTime+OTime+NTime+ONTime+SunTime+OSunTime+HolTime+OHolTime+SatTime+OSatTime) as giocong,isnull(songay,0) as songay,
 isnull(pn.Phepnam,0) as Phepnam,isnull(pr.pheprieng,0) as pheprieng,isnull(pb.phepbenh,0) as phepbenh,isnull(phepkethon,0) as phepkethon, isnull(phep_TNLD,0) as phep_TNLD,
isnull(Pheptang,0) as Pheptang,isnull(Nghile,0) as Nghile,isnull(NghiKhongPhep,0) as NghiKhongPhep,isnull(Otime,0) as OTime,
isnull(SunTime,0) as OSunday,isnull(HolTime,0) as HolTime,0 as NghiKhongLuong,isnull(DiTre,0) as DiTre,isnull(VeSom,0) as VeSom
from SmartBooks_Employee emp
left join
(	select Employee_ID, sum(isnull(HourLeave,0)) as Phepnam from HR_EmpRegisLeave
	where LeaveType_ID='PN' and  DateLeave between @fromdate and @todate 
	group by Employee_ID
) as pn on emp.Employee_ID COLLATE DATABASE_DEFAULT = pn.Employee_ID
left join
(	select Employee_ID, sum(isnull(HourLeave,0)) as pheprieng from HR_EmpRegisLeave
	where LeaveType_ID='PR' and  DateLeave between @fromdate and @todate 
	group by Employee_ID
) as pr on emp.Employee_ID COLLATE DATABASE_DEFAULT = pr.Employee_ID
left join
(	select Employee_ID, sum(isnull(HourLeave,0)) as phepbenh from HR_EmpRegisLeave
	where LeaveType_ID='PB' and  DateLeave between @fromdate and @todate 
	group by Employee_ID
) as pb on emp.Employee_ID COLLATE DATABASE_DEFAULT = pb.Employee_ID
left join
(	select Employee_ID, sum(isnull(HourLeave,0)) as phepkethon from HR_EmpRegisLeave
	where LeaveType_ID='WE' and  DateLeave between @fromdate and @todate 
	group by Employee_ID
) as pkh on emp.Employee_ID COLLATE DATABASE_DEFAULT = pkh.Employee_ID
left join
(	select Employee_ID, sum(isnull(HourLeave,0)) as phep_TNLD from HR_EmpRegisLeave
	where LeaveType_ID='TNLD' and  DateLeave between @fromdate and @todate 
	group by Employee_ID
) as ptnld on emp.Employee_ID COLLATE DATABASE_DEFAULT = ptnld.Employee_ID
left join
(	select Employee_ID, sum(isnull(HourLeave,0)) as Pheptang from HR_EmpRegisLeave
	where LeaveType_ID='PT' and  DateLeave between @fromdate and @todate 
	group by Employee_ID
) as pt on emp.Employee_ID COLLATE DATABASE_DEFAULT = pt.Employee_ID
left join
(	select Employee_ID, sum(isnull(HourLeave,0)) as Nghile from HR_EmpRegisLeave
	where LeaveType_ID='HOL' and  DateLeave between @fromdate and @todate 
	group by Employee_ID
) as hol on emp.Employee_ID COLLATE DATABASE_DEFAULT = hol.Employee_ID
left join
(	select Employee_ID, sum(isnull(HourLeave,0)) as NghiKhongPhep from HR_EmpRegisLeave
	where LeaveType_ID='KO' and  DateLeave between @fromdate and @todate 
	group by Employee_ID
) as kp on emp.Employee_ID COLLATE DATABASE_DEFAULT = kp.Employee_ID
left join 
(
	select employee_id,sum( case when [Percent]=100 then isnull(workingTime,0) else 0 end) as RTime,  
	sum(case when [Percent]=150 then isnull(workingTime,0) else 0 end) as OTime,
	sum(case when [Percent]=130 then isnull(workingTime,0) else 0 end) as NTime,
	sum(case when [Percent]=215 then isnull(workingTime,0) else 0 end) as ONTime,
	sum(case when [Percent]=200 then isnull(workingTime,0) else 0 end) as SunTime,
	sum(case when [Percent]=270 then isnull(workingTime,0) else 0 end) as OSunTime,
	sum(case when [Percent]=300 then isnull(workingTime,0) else 0 end) as HolTime,
	sum(case when [Percent]=390 then isnull(workingTime,0) else 0 end) as OHolTime,
	sum(case when [Percent]=170 then isnull(workingTime,0) else 0 end) as SatTime,
	sum(case when [Percent]=250 then isnull(workingTime,0) else 0 end) as OSatTime,
	isnull(songay,0) as songay
 	from udf_ExportCong1(@fromdate,@todate,15,55)
	group by employee_id,songay
)tk on emp.Employee_ID COLLATE DATABASE_DEFAULT= tk.Employee_ID 

left join (select Employee_ID, nghi, ditre,vesom from udf_ChuyenCan(@fromdate,@todate)) as cc
on emp.Employee_ID COLLATE DATABASE_DEFAULT= cc.Employee_ID

--select * from udf_ExportCong1('2015-12-01','2015-12-31',15,55)






GO
