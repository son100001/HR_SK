-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[udf_BangCong]
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime,
	@CongKH bit
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
	[Employee_ID] [nvarchar](50) NOT NULL,
			[Ngay] [datetime] NOT NULL,
			[MaCong] [nvarchar](50) NOT NULL,
			[InsertSource] [varchar](10) NOT NULL,
			[wt] [float] NULL,
			[Remark] [nvarchar](150) NULL,
			[InsertDate] [datetime] NULL,
			[UserName] [nvarchar](50) NULL,
			primary key ([Employee_ID],Ngay,MaCong,InsertSource)
			--index ix nonclustered([Employee_ID],[Ngay])
)
AS
BEGIN
	if @CongKH=0 begin
		insert into @rtnTable
		select * from HR_WTDaily where ngay between @fromdate and @todate
	end else begin
		insert into @rtnTable
		select * from HR_WTDaily_Audit where ngay between @fromdate and @todate
	end

	-- Return the result of the function
	RETURN

END




GO
