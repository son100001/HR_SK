CREATE PROCEDURE [dbo].[sp_LapBienBan]
	-- Add the parameters for the stored procedure here
	--exec [dbo].[sp_LapBienBan] '2026-06-12','2026-06-12',1,'VN',null,null,null,null,null,null,5,null
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,--1 Thu Moi XLKLLD, 2 - Bien Ban Vi Pham, Bien Ban Xet Ky Luat, Bien Ban Xu Ly Ky Luat
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@ListOfID varchar(max)=null,
	@Empl nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	/*declare @IDProcAsign nvarchar(50)
	declare @IDEmpl nvarchar(50)
	declare @DisciplineBegin datetime*/

    -- Insert statements for procedure here
	if @TypeOfReport=1
	BEGIN		
		SELECT
			empl.Factory_ID
			,empl.Employee_ID
			,empl.FactoryName
			,[dbo].[udf_FullName](Employee_Firstname,Employee_LastName) as FullName,empl.ComStartedDate,empl.StartedDate
			,cate.NameVN AS DisciplineAction, d.ViolationDate
			--,[dbo].[udf_GetProcAsignQuanLyViPham](@IDProcAsign) as ProcAsign
			--,(case when len(d.[DecisionCode])=1 then '00'+d.[DecisionCode] when len(d.[DecisionCode])=2 then '0'+d.[DecisionCode] else d.[DecisionCode] end) as [DecisionCode]
			,d.[Remark],d.[InsertDate],d.[UserName], d.DisciplineBegin
			,empl.DepartmentName, empl.SectionName, empl.TeamName
			,empl.PositionName, empl.PositionCategoryName,empl.ChucDanhName
					
		FROM
		[dbo].[HR_Discipline] d
		left join
		udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Empl,isnull(@todate,GETDATE())) empl
		on d.Employee_ID=empl.Employee_ID
		left join
		dbo.HR_Category cate
		on cate.Category=d.BehaviorCode AND cate.CategoryFather='ViPhamKyLuat'
		where d.ID in (select Data from Split(@ListOfID,','))
		/*)
		select * from InfomationTable
		update HR_Discipline
			set ProcAsign = tb.ProcAsign
		from InfomationTable tb left join HR_Discipline disc
		on tb.Employee_ID = disc.Employee_ID and tb.DisciplineBegin = disc.DisciplineBegin
		where tb.Employee_ID = disc.Employee_ID and tb.DisciplineBegin = disc.DisciplineBegin*/
	end
	
	
	IF @TypeOfReport=2
	BEGIN
		--set @IDProcAsign = 'BB';
		select distinct empl.Factory_ID
		,empl.Employee_ID
		,empl.FactoryName
		,[dbo].[udf_FullName](Employee_Firstname,Employee_LastName) as FullName,empl.ComStartedDate,empl.StartedDate
		,da.[DisciplineAction]
		--,[dbo].[udf_GetProcAsignQuanLyViPham](@IDProcAsign) as ProcAsign
		--,(case when len(d.[DecisionCode])=1 then '00'+d.[DecisionCode] when len(d.[DecisionCode])=2 then '0'+d.[DecisionCode] else d.[DecisionCode] end) as [DecisionCode]
		,d.[Remark],d.[InsertDate],d.[UserName]
		,empl.DepartmentName, empl.SectionName, empl.TeamName, empl.PositionName, empl.PositionCategoryName,empl.ChucDanhName, empl.BirthDate, empl.BirthPlace
		, empl.Address_Permanent, sb_cl.Contract_ID
		from
		[dbo].[HR_Discipline] d
		left join
		udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Empl,isnull(@todate,GETDATE())) empl
		on d.Employee_ID=empl.Employee_ID
		left join
		HR_DisciplineAction da
		on d.BehaviorCode=da.DisciplineCode
		left join
		SmartBooks_ContractList sb_cl
		on d.Employee_ID = sb_cl.Employee_ID
		where d.Employee_ID in (select Data from Split(@ListOfID,',')) --and (d.ViolationDate between @fromdate and @todate)
	end
END




GO
