CREATE FUNCTION [dbo].[udf_CongHC_TC]
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime,
	@BangCongKH bit
)
RETURNS  @rtnCongHC_TC TABLE 
(
    -- columns returned by the function
	[Employee_ID] [nvarchar](50) NOT NULL,
			[Ngay] [datetime] NOT NULL,
			[wt] [float] NULL,
			[OTKH] [float] NULL,
			[OTNB] [float] NULL
			primary key ([Employee_ID],Ngay)
			--index ix nonclustered([Employee_ID],[Ngay])
)
AS
BEGIN
	insert into @rtnCongHC_TC
	select wt.Employee_ID,wt.ngay
			,sum(case when isnull(lc.isWorkingTime,0)=1 then isnull(wt,0) else 0 end) as wt
			,sum(case when wt.MaCong not like 'CN%' and isnull(lc.isWorkingTime,0)=0 then isnull(wt,0) else 0 end) as OTKH
			,sum(case when isnull(lc.isWorkingTime,0)=0 then isnull(wt,0) else 0 end) as OTNB
		from
		HR_WTDaily wt
		left join
		HR_LoaiCong lc
		on wt.MaCong=lc.MaCong
		left join
		[dbo].[udf_NgayKyHDChinhThuc](@fromdate,@todate,null) hdct
		on wt.Employee_ID=hdct.Employee_ID
		where wt.Ngay between @fromdate and @todate
		group by wt.Employee_ID,wt.Ngay
	-- Return the result of the function
	RETURN

END



GO
