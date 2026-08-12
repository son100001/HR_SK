create PROCEDURE [dbo].[sp_ThuMoiXLKLLD]
	-- Add the parameters for the stored procedure here
	--exec [dbo].[sp_ThuMoiXLKLLD] '2019-7-1','2019-7-17',2,'VN',null,null,null,null,null,null,'117,105',null
	@date datetime,
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
	if @TypeOfReport=2 begin
		select empl.Factory_ID
		,empl.Employee_ID
		,empl.FactoryName
		,[dbo].[udf_FullName](Employee_Firstname,Employee_LastName) as FullName,empl.ComStartedDate,empl.StartedDate
		,da.[DisciplineAction]
		--,(case when len(d.[DecisionCode])=1 then '00'+d.[DecisionCode] when len(d.[DecisionCode])=2 then '0'+d.[DecisionCode] else d.[DecisionCode] end) as [DecisionCode]
		,d.[Remark],d.[InsertDate],d.[UserName]
		,empl.DepartmentName, empl.SectionName, empl.TeamName, empl.PositionName, empl.PositionCategoryName,empl.ChucDanhName
		,@date as DesciplineDay
		from
		[dbo].[HR_Discipline] d
		left join
		udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@date,GETDATE())) empl
		on d.Employee_ID=empl.Employee_ID
		left join
		HR_DisciplineAction da
		on d.BehaviorCode=da.DisciplineCode
		where d.ID in (select Data from Split(@ListOfID,','))
	end
END




GO
