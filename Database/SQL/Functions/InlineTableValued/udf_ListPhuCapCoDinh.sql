
CREATE FUNCTION [dbo].[udf_ListPhuCapCoDinh]     
(
	@fromdate datetime,
	@todate datetime
)
RETURNS table      
AS                
RETURN (
select
emp.[Employee_ID],
emp.[Employee_Firstname],
emp.[Employee_LastName],
emp.[Employee_Status],
emp.[StartedDate],
emp.[OfficialDate],
emp.[TernimationDate],
emp.[DepartmentCode],
emp.[SectionCode],
emp.[TeamCode],
emp.[Position_ID],
emp.[PositionCategory_ID],
isnull( allow.pcChucvu,0) as AllowanceNonContract1,
isnull( allow.pcSangTao,0) as AllowanceNonContract2,
isnull( allow.pcDochai,0) as AllowanceNonContract3,
isnull( allow.pcNgoaiNgu,0) as AllowanceNonContract4,
isnull( allow.pcDichThuat,0) as AllowanceNonContract5,
isnull( allow.pcKyThuat,0) as AllowanceNonContract6,
isnull( allow.pcCongViec,0) as AllowanceNonContract7,
isnull( allow.pcTiemNang,0) as AllowanceNonContract8
from SmartBooks_Employee emp
with(index(index_employee_emp))
left join 
(
	select pcct.Employee_ID,
	sum(case when isnull(ERN_CODE,'')='E2002' then pc.Amount else 0 end) as pcChucvu,
	sum(case when isnull(ERN_CODE,'')='E2036' then pc.Amount else 0 end) as pcSangTao,
	sum(case when isnull(ERN_CODE,'')='E2001' then pc.Amount else 0 end) as pcDochai,
	sum(case when pcct.Allowance_Code=20 then pcct.Amount else 0 end) as pcNgoaiNgu,
	sum(case when pcct.Allowance_Code=21 then pcct.Amount else 0 end) as pcDichThuat,
	sum(case when pcct.Allowance_Code=22 then pcct.Amount else 0 end) as pcKyThuat,
	sum(case when pcct.Allowance_Code=23 then pcct.Amount else 0 end) as pcCongViec,
	sum(case when pcct.Allowance_Code=24 then pcct.Amount else 0 end) as pcTiemNang
	
	from HR_PhuCapCoDinh_Chitiet pcct
	inner join
	(
		select [ID], max(Fromdate) as fromdate from HR_PhuCapCoDinh_Chitiet
		where fromdate<=@todate
		group by [ID]
	)pcct1 on pcct1.[ID]=pcct.[ID]
	inner join HR_PhuCapCoDinh pc on pc.Allowance_Code = pcct.Allowance_Code
	group by pcct.Employee_ID
)as allow on allow.Employee_ID COLLATE DATABASE_DEFAULT = emp.Employee_ID

where ((emp.Employee_Status='Active' and emp.StartedDate<@todate)  or (emp.Employee_Status<>'Active' and emp.TernimationDate>@todate))
)

--select * from udf_ListPhuCapCoDinh('2017/11/01','2017/11/30')




GO
