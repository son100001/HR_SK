

CREATE FUNCTION [dbo].[udf_NhanVienDangActiveTheoKhoangThoiGian]     
(
@fromdate datetime,        
@todate datetime,
@LAN nvarchar(50)
)      
RETURNS table      
AS                
RETURN (
Select Employee_ID,[dbo].[udf_FullName]([Employee_Firstname],[Employee_LastName]) as FullName,StartedDate,Employee_Status,TernimationDate
,(case when @LAN='VN' then dept.DepartmentName_VN else
		(case when @LAN='EN' then dept.DepartmentName_EN else dept.DepartmentName_VN
	end)end)as DepartmentName
	,(case when @LAN='VN' then sect.SectionName_VN else
		(case when @LAN='EN' then sect.SectionName_EN else sect.SectionName_KR
	end)end)as SectionName
	,(case when @LAN='VN' then team.Description_VN else
		(case when @LAN='EN' then team.Description_EN else team.Description_KR
	end)end)as TeamName
	,(case when @LAN='VN' then pos.Position_NameVN else
		(case when @LAN='EN' then pos.Position_NameEN else pos.Position_NameKR
	end)end)as PositionName
	,(case when @LAN='VN' then posc.PositionCategory_NameVN else
		(case when @LAN='EN' then posc.PositionCategory_NameEN else posc.PositionCategory_NameKR
	end)end)as PositionCategoryName
,Card_Code
from SmartBooks_Employee empl
left join
SmartBooks_Department dept
on empl.DepartmentCode=dept.DepartmentCode
left join
SmartBooks_Section sect
on empl.SectionCode=sect.SectionCode
left join
SmartBooks_Team team
on empl.TeamCode=team.TeamCode
left join
SmartBooks_Position pos
on empl.Position_ID=pos.Position_ID
left join
SmartBooks_PositionCategory posc
on empl.PositionCategory_ID=posc.PositionCategory_ID
where
startedDate <= @todate and (TernimationDate > @fromdate or TernimationDate is null)
)







GO
