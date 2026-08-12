
CREATE proc [dbo].[sp_BangAward] -- exec sp_BangAward '2025-01-01','2025-12-31',3,'VN',null,null,null,null,null,null,null,'YDC001'
@fromdate datetime,
@todate datetime,
@TypeOfReport int = 1,
@LAN nvarchar(50)='VN',
@UserName nvarchar(50)=null,
@fact nvarchar(50)=null,
@dept nvarchar(50)=null,
@sect nvarchar(50)=null,
@team nvarchar(50)=null,
@pos nvarchar(50)=null,
@posc nvarchar(50)=null,
@emp nvarchar(50)=null,
@DanhSachKey nvarchar(max) = null

As
Begin
	if @TypeOfReport = 1 begin
		select dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName, empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName, aw.*
		from
		HR_Award aw
		left join
		udf_EmployeeFilter (@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
		on aw.Employee_ID = empl.Employee_ID
		where aw.AwardDate between @Fromdate and @Todate and (aw.Employee_ID in (select data from Split(@DanhSachKey,',')) or @DanhSachKey is null)
	end else if @TypeOfReport = 2 begin
		select case when @LAN = 'KR' then N'상점' when @LAN = 'EN' then N'Award' else N'Khen thưởng' end as [AwardPenalty], case when @LAN = 'EN' then cate.NameEN when @LAN = 'KR' then cate.NameKR else cate.NameVN end as [AwardPenaltyType], aw.AwardDate as [Date], aw.Reason as Reason
		from
		HR_Award aw
		left join
		HR_Category cate
		on cate.CategoryFather = 'KhenThuong' and aw.AwardType = cate.Category
		where (case when @emp is null or @emp = '' then '' else aw.Employee_ID end) in (case when  @emp is null or @emp = '' then '' else (select data from Split(@emp,',')) end)
		union all
		select case when @LAN = 'KR' then N'벌점' when @LAN = 'EN' then N'Penalty' else N'Kỷ luật' end as [AwardPenalty], case when @LAN = 'EN' then cate.NameEN when @LAN = 'KR' then cate.NameKR else cate.NameVN end as [AwardPenaltyType], dis.DisciplineBegin as [Date], dis.Reason as Reason
		from
		HR_Discipline dis
		left join
		HR_Category cate
		on cate.CategoryFather = 'ViPhamKyLuat' and dis.BehaviorCode = cate.Category
		where (case when @emp is null or @emp = '' then '' else dis.Employee_ID end) in (case when  @emp is null or @emp = '' then '' else (select data from Split(@emp,',')) end)
		order by [Date]
	end else if @TypeOfReport = 3 begin
		select empl.Employee_ID,dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName, empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
				, sum(case when month(aw.AwardDate) = 1 then 1 else 0 end) as Jan, sum(case when month(aw.AwardDate) = 2 then 1 else 0 end) as Feb, sum(case when month(aw.AwardDate) = 3 then 1 else 0 end) as Mar
				, sum(case when month(aw.AwardDate) = 4 then 1 else 0 end) as Apr, sum(case when month(aw.AwardDate) = 5 then 1 else 0 end) as May, sum(case when month(aw.AwardDate) = 6 then 1 else 0 end) as Jun
				, sum(case when month(aw.AwardDate) = 7 then 1 else 0 end) as Jul, sum(case when month(aw.AwardDate) = 8 then 1 else 0 end) as Aug, sum(case when month(aw.AwardDate) = 9 then 1 else 0 end) as Sep
				, sum(case when month(aw.AwardDate) = 10 then 1 else 0 end) as Oct, sum(case when month(aw.AwardDate) = 11 then 1 else 0 end) as Nov, sum(case when month(aw.AwardDate) = 12 then 1 else 0 end) as [Dec]
		from
		HR_Award aw
		left join
		udf_EmployeeFilter (@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,@fromdate) empl
		on empl.Employee_ID = aw.Employee_ID
		where Year(aw.AwardDate) = Year(@fromdate)
		group by empl.Employee_ID, empl.Employee_Firstname,empl.Employee_LastName, empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
	end
end
GO
