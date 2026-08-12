
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_XoaDuLieuQuetDoNguoiDungDaChonXoa]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		delete [dbo].[HR_TimeKeeping_Data] where ID in (
		select td.ID from
		[dbo].[HR_TimeKeeping_Data] td
		left join
		[dbo].[HR_TimeKeeping_Data_Delete] tdd
		on td.Employee_ID=tdd.Employee_ID and td.AccessTime=tdd.AccessTime
		left join
		[dbo].[udf_EmployeeFilter]('VN',null,null,null,null,null,null,null,@todate) empl
		on td.Employee_ID=empl.Employee_ID
		--left join
		--[User] u
		--on u.UserName=@UserName
		where tdd.Employee_ID is not null and td.AccessDate between @fromdate and @todate
			--and empl.Factory_ID in (select data from split(u.QuyenTruyXuat,','))
	)
END





GO
