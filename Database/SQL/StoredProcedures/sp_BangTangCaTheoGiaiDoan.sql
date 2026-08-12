-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BangTangCaTheoGiaiDoan]
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
	if @TypeOfReport=1 begin
		SELECT motp.Employee_ID,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName)as FullName,empl.StartedDate,empl.TernimationDate,empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID
			,motp.maxovertime,motp.Fromdate,motp.Todate,motp.Remark,motp.InsertDate,motp.UserName,motp.ID
		from
		[dbo].[HR_MaxOvertimeInPeriod] motp
		left join
		SmartBooks_Employee empl
		on motp.Employee_ID=empl.Employee_ID
		where motp.Fromdate<=@todate and motp.Todate>=@fromdate
			and (case when @fact is null or @fact='' then '' else empl.Factory_ID end)=(case when @fact is null or @fact='' then '' else @fact end)
			and (case when @dept is null or @dept='' then '' else empl.DepartmentCode end)=(case when @dept is null or @dept='' then '' else @dept end)
			and (case when @sect is null or @sect='' then '' else empl.SectionCode end)=(case when @sect is null or @sect='' then '' else @sect end)
			and (case when @team is null or @team='' then '' else empl.TeamCode end)=(case when @team is null or @team='' then '' else @team end)
			and (case when @pos is null or @pos='' then '' else empl.Position_ID end)=(case when @pos is null or @pos='' then '' else @pos end)
			and (case when @posc is null or @posc='' then '' else empl.PositionCategory_ID end)=(case when @posc is null or @posc='' then '' else @posc end)
		order by motp.InsertDate desc
	end
END




GO
