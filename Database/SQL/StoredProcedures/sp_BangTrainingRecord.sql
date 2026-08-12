create proc [dbo].[sp_BangTrainingRecord] -- exec sp_BangTrainingRecord '2021-5-5','2021-5-5',2,null,null,null,null,null,null,null,null,'YDC036'
@Fromdate datetime,
@Todate datetime,
@TypeOfReport int=1,
@LAN nvarchar(50)='VN',
@UserName nvarchar(50)=null,
@fact nvarchar(50)=null,
@dept nvarchar(50)=null,
@sect nvarchar(50)=null,
@team nvarchar(50)=null,
@pos nvarchar(50)=null,
@posc nvarchar(50)=null,
@emp nvarchar(MAX)=null
as
begin
	if @TypeOfReport = 1 begin
		select dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName, trr.*
		from
		HR_TrainingRecord trr
		left join
		SmartBooks_Employee empl
		on trr.Employee_ID = empl.Employee_ID
		where trr.Fromdate between @Fromdate and @Todate and (case when @emp is null or @emp = '' then '' else empl.Employee_ID end) in (case when  @emp is null or @emp = '' then '' else (select data from Split(@emp,',')) end)
	end else if @TypeOfReport = 2 begin
		select case when @LAN = 'KR' then cate.NameKR when @LAN = 'EN' then cate.NameEN else cate.NameVN end as TrainingType, [Group], TrainingSubject, Fromdate, TrainingHour, Trainer
		from
		HR_TrainingRecord trr
		left join
		HR_Category cate
		on cate.CategoryFather = 'TrainingType' and trr.TrainingType = cate.Category
		where @emp = Employee_ID
		order by Fromdate
	end
end
GO
