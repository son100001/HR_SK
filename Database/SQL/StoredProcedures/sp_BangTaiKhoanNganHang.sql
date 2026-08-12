-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BangTaiKhoanNganHang] 
	-- Add the parameters for the stored procedure here
	@Date datetime,
	@TypeOfReport int=1,
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@emp nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @TypeOfReport=1 begin
		select empl.Employee_ID, [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName, empl.FactoryName, empl.DepartmentName
				, empl.SectionName, empl.ChucDanhName, be.BankAccount, isnull(be.BankName,N'Sacombank') as BankName, be.isUsing, be.Remark, be.InsertDate, be.UserName
		--empl.PositionFullName,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.PositionName,be.* 
		from
		HR_BankAccountOfEmployee be
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,@Date) empl
		on be.Employee_ID=empl.Employee_ID
		where empl.StartedDate<=@Date and (empl.TernimationDate is null or empl.TernimationDate>@Date) and empl.Employee_ID is not null
	end else if @TypeOfReport=2 begin
		select empl.Employee_ID, [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName, empl.FactoryName, empl.DepartmentName
				, empl.SectionName, empl.ChucDanhName, be.BankAccount, isnull(be.BankName,N'Sacombank') as BankName, be.isUsing, be.Remark, be.InsertDate, be.UserName
		from
		HR_BankAccountOfEmployee be
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,@Date) empl
		on be.Employee_ID=empl.Employee_ID
		where empl.Employee_ID is not null
	end
END

GO
