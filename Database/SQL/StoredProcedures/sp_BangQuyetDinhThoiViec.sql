CREATE PROCEDURE [dbo].[sp_BangQuyetDinhThoiViec]
	-- Add the parameters for the stored procedure here
	--exec [dbo].[sp_BangQuyetDinhThoiViec] '2019-7-1','2019-7-17',2,'VN',null,null,null,null,null,null,'117,105',null
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,--1:toàn bộ quyết định,2-- In quyết định
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@ListOfID varchar(max)=null,
	@Emp nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @TypeOfReport=1 begin--xuất danh sách
		select empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.PositionCategory_ID
		,UPPER([dbo].[udf_FullName](Employee_Firstname,Employee_LastName)) as FullName,empl.StartedDate,empl.ComStartedDate,ta.*
		from
		[dbo].[HR_TerminationAsignment] ta
		left join
		udf_EmployeeFilter_Full(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,GETDATE())) empl
		on ta.Employee_ID=empl.Employee_ID
		where [PlanTernimationDate] between @fromdate and @todate and empl.Employee_ID is not null
	end else if @TypeOfReport=2 begin
		select empl.Factory_ID
		,empl.Employee_ID
		,empl.FactoryName
		,empl.BirthDate
		,empl.DepartmentName, empl.SectionName, empl.TeamName, empl.PositionName, empl.PositionCategoryName,empl.ChucDanhName, empl.BirthDate
		,upper([dbo].[udf_FullName](Employee_Firstname,Employee_LastName)) as FullName,empl.ComStartedDate,empl.StartedDate,ta.[PlanTernimationDate]
		,ta.[ResonTerminated]
		,(case when len(ta.[DecisionCode])=1 then '00'+ta.[DecisionCode] when len(ta.[DecisionCode])=2 then '0'+ta.[DecisionCode] else ta.[DecisionCode] end) as [DecisionCode]
		,ta.[DecisionStatus],ta.[NgayNopDon],ta.[Remark],ta.[InsertDate],ta.[UserName]
		,[dbo].[udf_LastWorkingDay](ta.PlanTernimationDate) as NgayLamQuyetDinh
		,(Case when DATEPART(DAY,ta.PlanTernimationDate) between 1 and 8 then DATEADD(day,1-DATEPART(DAY,ta.PlanTernimationDate),ta.PlanTernimationDate)+8
				when DATEPART(DAY,ta.PlanTernimationDate) between 9 and 15 then DATEADD(day,1-DATEPART(DAY,ta.PlanTernimationDate),ta.PlanTernimationDate)+15
				when DATEPART(DAY,ta.PlanTernimationDate) between 16 and 22 then DATEADD(day,1-DATEPART(DAY,ta.PlanTernimationDate),ta.PlanTernimationDate)+22
				else DATEADD(MONTH,1,DATEADD(day,1-DATEPART(DAY,ta.PlanTernimationDate),ta.PlanTernimationDate))-1
			end)as NgayTT
		,(case when isnull(c.NameVN ,'')='' then ta.ResonTerminated else c.NameVN end) as LyDoNghi
		, ta.[PlanTernimationDate] - 1 as NgayHuongLuongCuoi
		, case when Sex='Male' then N'Anh' else N'Chị' end as XungHo
		, SUBSTRING(empl.Employee_ID, 2, LEN(empl.Employee_ID)) + '/QĐTV' + CAST(YEAR([dbo].[udf_LastWorkingDay](ta.PlanTernimationDate)) AS NVARCHAR(4)) AS EmpDisplay
		,SUBSTRING(empl.Employee_ID, 2, LEN(empl.Employee_ID)) + '/HĐLĐ-S&K' AS EmpDisplayHDLD
		,hdts.CL_RegisterDate
		from
		[dbo].[HR_TerminationAsignment] ta
		left join
		udf_EmployeeFilter_Full(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,GETDATE())) empl
		on ta.Employee_ID=empl.Employee_ID
		left join
		HR_Category c
		on ta.ResonTerminated=c.Category and c.CategoryFather='resigned'
		OUTER APPLY (
			SELECT TOP 1 *
			FROM dbo.udf_HopDongTuSinh('1900-1-1', @fromdate, 1, 'VN', null, NULL, NULL, NULL, NULL, NULL, NULL) h
			where h.Employee_ID = empl.Employee_ID
			ORDER BY h.CL_ExpiredDate DESC
		) hdts
		where ta.ID in (select Data from Split(@ListOfID,','))
	end
END




GO
