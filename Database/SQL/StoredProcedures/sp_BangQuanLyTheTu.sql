-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BangQuanLyTheTu]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,
	@fact nvarchar(50)=null,
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
	if @TypeOfReport = 1 begin
		select cc.Employee_ID, [dbo].[udf_FullName](emp.Employee_Firstname,emp.Employee_LastName) as FullName
			,Employee_Status,StartedDate,TernimationDate,emp.DepartmentCode,emp.SectionCode
			,emp.TeamCode,emp.Position_ID,emp.PositionCategory_ID,cc.Card_Code,cc.ExpiredDate,cc.Remark,cc.[InsertDate],cc.[UserName],cc.[ID]
        from
        dbo.HR_CardCode cc
        left join
        dbo.SmartBooks_Employee emp 
        on cc.Employee_ID COLLATE DATABASE_DEFAULT = emp.Employee_ID
		where (case when @fact is null or @fact='' then '' else emp.Factory_ID end)=(case when @fact is null or @fact='' then '' else @fact end)
			and (case when @dept is null or @dept='' then '' else emp.DepartmentCode end)=(case when @dept is null or @dept='' then '' else @dept end)
			and (case when @sect is null or @sect='' then '' else emp.SectionCode end)=(case when @sect is null or @sect='' then '' else @sect end)
			and (case when @team is null or @team='' then '' else emp.TeamCode end)=(case when @team is null or @team='' then '' else @team end)
			and (case when @pos is null or @pos='' then '' else emp.Position_ID end)=(case when @pos is null or @pos='' then '' else @pos end)
			and (case when @posc is null or @posc='' then '' else emp.PositionCategory_ID end)=(case when @posc is null or @posc='' then '' else @posc end)
		order by cc.InsertDate desc
	end
END




GO
