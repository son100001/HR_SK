
CREATE PROCEDURE [dbo].[sp_BangPhepNamTon]
	-- Add the parameters for the stored procedure here
	@Year int,
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
		select 
		empl.Position,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		,dvr.*
		from
		HR_DayVacationRemain dvr
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,DATEFROMPARTS(@Year,12,31)) empl
		on empl.Employee_ID=dvr.Employee_ID
		where dvr.[Year]=@Year and empl.Employee_ID is not null
	end
END

GO
