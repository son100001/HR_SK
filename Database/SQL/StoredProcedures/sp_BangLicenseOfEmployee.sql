create proc [dbo].[sp_BangLicenseOfEmployee] -- exec sp_BangLicenseOfEmployee '2021-5-1','2021-5-1',2,'VN',null,null,null,null,null,null,null,'YDC001'
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
	if @TypeOfReport = 1 begin
		select dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName, loe.*
		from
		HR_LicenseOfEmployee loe
		left join
		SmartBooks_Employee empl
		on loe.Employee_ID = empl.Employee_ID
		where loe.ValidFromdate <= @todate and isnull(loe.ValidTodate,'3099-1-1') >= @fromdate and (case when @emp is null or @emp = '' then '' else empl.Employee_ID end) in (case when  @emp is null or @emp = '' then '' else (select data from Split(@emp,',')) end)
	end else if @TypeOfReport = 2 begin
		select case when @LAN = 'EN' then cate.NameEN when @LAN = 'KR' then cate.NameKR else cate.NameVN end, loe.IssuedDate, loe.IssuedAt, cast(month(loe.ValidFromdate) as nvarchar) + '/' + cast(year(loe.ValidFromdate) as nvarchar) + ' ~ ' + isnull((cast(month(loe.ValidTodate) as nvarchar) + '/' + cast(year(loe.ValidTodate) as nvarchar)),'Now') as ValidDate
		from
		HR_LicenseOfEmployee loe
		left join
		HR_Category cate
		on cate.CategoryFather = 'BangCap' and cate.Category = loe.LicenseType
		where Employee_ID = @emp
		order by loe.IssuedDate
	end
end
GO
