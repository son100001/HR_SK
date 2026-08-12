create proc [dbo].[sp_BangSurgeryHistory]
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
@emp nvarchar(MAX)=null

As
Begin
	-- exec sp_BangSurgeryHistory '2021-5-1','2021-5-1',2,'VN',null,null,null,null,null,null,null,'YDC001'
	if @TypeOfReport = 1 begin
		select dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName, sh.*
		from
		HR_SurgeryHistory sh
		left join
		SmartBooks_Employee empl
		on sh.Employee_ID = empl.Employee_ID
		where sh.SurgeryDate between @Fromdate and @Todate and (case when @emp is null or @emp = '' then '' else empl.Employee_ID end) in (case when  @emp is null or @emp = '' then '' else (select data from Split(@emp,',')) end)
	end else if @TypeOfReport = 2 begin
		select case when @LAN = 'EN' then cate1.NameEN when @LAN = 'KR' then cate1.NameKR else cate1.NameVN end as SurgeryReason, sh.SurgeryDate, case when @LAN = 'EN' then cate2.NameEN when @LAN = 'KR' then cate2.NameKR else cate2.NameVN end as PostSurgeryEffects
		from
		HR_SurgeryHistory sh
		left join
		HR_Category cate1
		on cate1.CategoryFather = 'SurgeryReason' and cate1.Category = sh.SurgeryReason
		left join
		HR_Category cate2
		on cate2.CategoryFather = 'Effects' and cate2.Category = sh.PostSurgeryEffects
		where Employee_ID = @emp
		order by sh.SurgeryDate
	end
end
GO
