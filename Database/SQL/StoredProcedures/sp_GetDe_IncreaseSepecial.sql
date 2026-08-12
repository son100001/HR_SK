-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetDe_IncreaseSepecial] 
	-- Add the parameters for the stored procedure here
	@Month int null,
	@Year int null,
	@TypeOfReport int=1,--1 xem theo tháng; 2 xem all
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @TypeOfReport=1 begin
		select empl.DepartmentCode,empl.SectionCode,empl.TeamCode
		,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName) as FullName,empl.StartedDate,dis.*
		from
		[dbo].[HR_De_IncreaseSepecial] dis
		left join
		SmartBooks_Employee empl
		on dis.Employee_ID=empl.Employee_ID
		where 
			(case when @dept is null or @dept='' then '' else empl.DepartmentCode end)=(case when @dept is null or @dept='' then '' else @dept end)
			and (case when @sect is null or @sect='' then '' else empl.SectionCode end)=(case when @sect is null or @sect='' then '' else @sect end)
			and (case when @team is null or @team='' then '' else empl.TeamCode end)=(case when @team is null or @team='' then '' else @team end)
			and (case when @pos is null or @pos='' then '' else empl.Position_ID end)=(case when @pos is null or @pos='' then '' else @pos end)
			and (case when @posc is null or @posc='' then '' else empl.PositionCategory_ID end)=(case when @posc is null or @posc='' then '' else @posc end)
			and Month_=@Month and Year_=@Year
	end else if @TypeOfReport=2 begin
		select empl.DepartmentCode,empl.SectionCode,empl.TeamCode
		,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName) as FullName,empl.StartedDate,dis.*
		from
		[dbo].[HR_De_IncreaseSepecial] dis
		left join
		SmartBooks_Employee empl
		on dis.Employee_ID=empl.Employee_ID
		where 
			(case when @dept is null or @dept='' then '' else empl.DepartmentCode end)=(case when @dept is null or @dept='' then '' else @dept end)
			and (case when @sect is null or @sect='' then '' else empl.SectionCode end)=(case when @sect is null or @sect='' then '' else @sect end)
			and (case when @team is null or @team='' then '' else empl.TeamCode end)=(case when @team is null or @team='' then '' else @team end)
			and (case when @pos is null or @pos='' then '' else empl.Position_ID end)=(case when @pos is null or @pos='' then '' else @pos end)
			and (case when @posc is null or @posc='' then '' else empl.PositionCategory_ID end)=(case when @posc is null or @posc='' then '' else @posc end)
	end
	
END




GO
