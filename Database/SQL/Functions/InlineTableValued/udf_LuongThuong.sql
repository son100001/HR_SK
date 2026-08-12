--select * from [dbo].[udf_TinhLuong] (7,2019,'072019','2019-7-1','2019-7-31',0) where employee_id='19001138'
CREATE FUNCTION [dbo].[udf_LuongThuong]     
(
@month int,
@year int,
@fromdate datetime,    
@todate datetime
)      
RETURNS table      
AS     
RETURN (
	SELECT distinct
	empl.Employee_ID,
	empl.Employee_Firstname,
	empl.Employee_LastName,
	empl.StartedDate,
	empl.TernimationDate,
	empl.PositionCategoryName as PositionCategory_ID,
	(case when  isnull(DepartmentName,'')='Newcomer Orientation Department' then 'Management' else isnull(DepartmentName,'') end) as DepartmentCode,
	empl.SectionName  as SectionCode,
	empl.TeamName as TeamCode,
	ISNULL(empl.PositionName,'') as Position_ID,
	empl.Employee_Status,
	empl.OfficialDate,
	empl.Sex,
	empl.MaritalStatus,
	empl.Nationality,
	empl.BirthDate,
	empl.BirthPlace,
	empl.ID_number,
	empl.ID_date,
	empl.ID_place,
	empl.Address_Temporary,
	empl.Address_Permanent,
	empl.Tel,
	empl.BankAccount,
	empl.BankName,	
	empl.Card_Code,
	empl.ComStartedDate,
	empl.ChucDanh as Chucdanh,
	(case when isnull(empl.StartedDate,@fromdate)>@fromdate then 1 else 0 end) as nhanvienmoi,
	--(case when isnull(empl.OfficialDate,@fromdate)>@fromdate then 1 else 0 end) as dangthuviec,
	0 as dangthuviec,
	(case when isnull(empl.OfficialDate,@fromdate)>@fromdate and (DATEPART(month,isnull(empl.OfficialDate,@fromdate)) =DATEPART(month,@fromdate) and DATEPART(DAY,isnull(empl.OfficialDate,@fromdate))>14) then 1 else 0 end) as vaosau14,
	
	0 as NonContractualSalary,
	isnull(lcb.MucLuong,0)  as MucLuong,
	isnull(lcb.bacluong,0) as bacluong,
	isnull(lcb.nhomluong,'')  as nhomluong,
	
	(case when isnull(empl.OfficialDate,@fromdate)>@fromdate then isnull(lcb_tv.MucLuong,0) 
		when isnull(lcb_tangbac.MucLuong,0)<>0 then isnull(lcb_tangbac.MucLuong,0)
		else 0 end) as MucLuong_tv,
	(case when isnull(empl.OfficialDate,@fromdate)>@fromdate then isnull(lcb_tv.bacluong,0) 
		when isnull(lcb_tangbac.MucLuong,0)<>0 then isnull(lcb_tangbac.bacluong,0)
		else 0 end) as bacluong_tv,
	(case when isnull(empl.OfficialDate,@fromdate)>@fromdate then isnull(lcb_tv.nhomluong,'') 
		when isnull(lcb_tangbac.MucLuong,0)<>0 then isnull(lcb_tangbac.nhomluong,'')
		else '' end) as nhomluong_tv,
	isnull(dochai.VL,0) as pcDochai
	
from
(select * from [dbo].[udf_EmployeeFilter] ('VN',null,null,null,null,null,null,null,getdate()) 
)empl 

left join
(
	select * from udf_LuongCoBan(@fromdate,@todate)
)lcb on empl.Employee_ID COLLATE DATABASE_DEFAULT= lcb.Employee_ID

left join
(
	select * from udf_LuongCoBan_BacCu(@fromdate,@todate)
)lcb_tangbac on empl.Employee_ID COLLATE DATABASE_DEFAULT= lcb_tangbac.Employee_ID

left join
(
	select * from udf_LuongCoBan_thuviec(@fromdate,@todate)
)lcb_tv on empl.Employee_ID COLLATE DATABASE_DEFAULT= lcb_tv.Employee_ID

left join
(	
	select tf.Employee_ID,tf.VL,tf.EffectiveDate,tf.TypeOfTransfer from HR_TransferFloatType tf
	inner join
	(
		select employee_id, max(EffectiveDate) as EffectiveDate from HR_TransferFloatType
		where EffectiveDate <=@todate and TypeOfTransfer='HeavyAndToxic'
		group by employee_id
	)tf1 on tf1.Employee_ID = tf.Employee_ID and tf1.EffectiveDate = tf.EffectiveDate 
) dochai on empl.Employee_ID COLLATE DATABASE_DEFAULT= dochai.Employee_ID


left join
(
	select * from udf_LuongCoBan_NamSau(@fromdate,@todate)
)lcb_namsau on empl.Employee_ID COLLATE DATABASE_DEFAULT= lcb_namsau.Employee_ID


WHERE      
(
((empl.ComStartedDate <= @todate and  isnull(empl.Employee_Status,'Incumbent') <> 'Terminated' and empl.ComStartedDate<'2019/08/01' ) or ( isnull(empl.Employee_Status,'Incumbent') = 'Terminated' and ISNULL(TernimationDate,@todate)>'30/08/2019' and empl.ComStartedDate <= '2019/08/01')) 

 
)
)

--select Employee_ID,count(Employee_ID) as abc from udf_TinhLuong(7,2019,'201907','2019/07/01','2019/07/31',0.5) group by Employee_ID where Employee_ID='19000927'

--select * from SmartBooks_Employee  where  Employee_ID='19000092'
--select * from HR_EmpRegisLeave  where  Employee_ID='19000092'




GO
