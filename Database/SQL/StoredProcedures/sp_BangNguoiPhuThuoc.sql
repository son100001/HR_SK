-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec sp_bangcong '2018-08-01 00:00:00','2018-08-31 00:00:00',3,N'VN',N'FacA',N'',N'',N'',N''


CREATE PROCEDURE [dbo].[sp_BangNguoiPhuThuoc]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@LAN nvarchar(50)='VN',
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
	SELECT	empl.DepartmentName, empl.SectionName, empl.TeamName, empl.PositionName, empl.PositionCategoryName
				,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
				,empl.StartedDate,dp.DependentPerson,dp.Fromdate,dp.ToDate,dp.Remark,dp.InsertDate,dp.UserName,dp.ID
		from
		HR_DependentPerson dp
		left join
		udf_Smartbooks_Employee(@LAN) empl
		on dp.Employee_ID=empl.Employee_ID
		where (case when @fact is null or @fact='' then '' else empl.Factory_ID end)=(case when @fact is null or @fact='' then '' else @fact end)
			and (case when @dept is null or @dept='' then '' else empl.DepartmentCode end)=(case when @dept is null or @dept='' then '' else @dept end)
			and (case when @sect is null or @sect='' then '' else empl.SectionCode end)=(case when @sect is null or @sect='' then '' else @sect end)
			and (case when @team is null or @team='' then '' else empl.TeamCode end)=(case when @team is null or @team='' then '' else @team end)
			and (case when @pos is null or @pos='' then '' else empl.Position_ID end)=(case when @pos is null or @pos='' then '' else @pos end)
			and (case when @posc is null or @posc='' then '' else empl.PositionCategory_ID end)=(case when @posc is null or @posc='' then '' else @posc end)
			and dp.Fromdate<=@todate and (ToDate is null or ToDate>=@fromdate)
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID,empl.StartedDate
END




GO
