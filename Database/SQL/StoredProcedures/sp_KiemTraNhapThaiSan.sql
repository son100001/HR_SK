-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_KiemTraNhapThaiSan]
	-- Add the parameters for the stored procedure here
	@Employee_ID nvarchar(50),
	@fromdate datetime,
	@todate datetime,
	@ID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @ID is not null begin
		SELECT * from [dbo].[HR_EmployeeRegisPregnant] where Employee_ID=@Employee_ID and ID<>@ID
														and 
														(
															@fromdate between Fromdate and todate
															or
															@todate between Fromdate and todate
															or
															Fromdate between @fromdate and @todate
															or
															todate between @fromdate and @todate
														)
	end else begin
		SELECT * from [dbo].[HR_EmployeeRegisPregnant] where Employee_ID=@Employee_ID
														and 
														(
															@fromdate between Fromdate and todate
															or
															@todate between Fromdate and todate
															or
															Fromdate between @fromdate and @todate
															or
															todate between @fromdate and @todate
														)
	end
END




GO
