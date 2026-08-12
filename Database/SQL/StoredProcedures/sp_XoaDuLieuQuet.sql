-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec sp_XoaDuLieuQuet '11/01/2019 12:00:00 AM','11/30/2019 12:00:00 AM',N'X01',N'',N'',N'',N'',N'',N''

CREATE PROCEDURE [dbo].[sp_XoaDuLieuQuet] 
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@ListOfEmployee varchar(max)=null,
	@InsertSource nvarchar(50) = N'MayChamCong'
AS
BEGIN
	--exec sp_XoaDuLieuQuet '2023-03-01', '2023-03-01'
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @dNext datetime
	if isnull(@fact,'') = '' begin
		delete tkd
		from
		HR_TimeKeeping_Data tkd
		where tkd.AccessDate between @fromdate and @todate and tkd.InsertSource = @InsertSource
	end else begin
		set @dNext=@fromdate
		while @dNext<=@todate begin
			delete tkd
			from
			HR_TimeKeeping_Data tkd
			inner join
			udf_TraVeBangTransfer_Horizontal(@dNext,null) tf
			on tkd.Employee_ID=tf.Employee_ID and (case when @fact is null or @fact='' then '' else left(tf.Position,3) end) in (select data from [dbo].[Split](case when @fact is null or @fact='' then '' else @fact end,','))
			where tkd.AccessDate between @dNext and @dNext
				and (case when ISNULL(@ListOfEmployee,'')='' then '' else tkd.Employee_ID end) in (select data from Split(isnull(@ListOfEmployee,''),','))
				and tkd.InsertSource = @InsertSource
			set @dNext=@dNext+1
		end
	end
END




GO
