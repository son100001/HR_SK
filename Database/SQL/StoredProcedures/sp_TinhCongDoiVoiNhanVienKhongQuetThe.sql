-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_TinhCongDoiVoiNhanVienKhongQuetThe]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@dept as nvarchar(50)=null,
	@sect as nvarchar(50)=null,
	@team as nvarchar(50)=null,
	@pos as nvarchar(50)=null,
	@posc as nvarchar(50)=null,
	@Employee_ID_ nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @TabDate TABLE
	(
	  Date_ datetime
	)
	Declare @DateNext datetime
	set @DateNext=@fromdate
	while @DateNext<=@todate
	begin
		insert into @TabDate (Date_) values(@DateNext)
		set @DateNext=@DateNext+1
	end
	select * from 
	@TabDate td
	left join
	SmartBooks_Employee empl
	on empl.StartedDate<=td.Date_ and (empl.TernimationDate is null or empl.TernimationDate>Date_)
	left join
	HR_EmpRegisLeave erl
	on empl.Employee_ID=erl.Employee_ID and td.Date_=erl.DateLeave
	left join
	HR_EmployeeRegisMaternityLeave erml
	on td.Date_ between @fromdate and @todate and empl.Employee_ID COLLATE DATABASE_DEFAULT=erml.Employee_ID
	where erml.Employee_ID is null

END




GO
