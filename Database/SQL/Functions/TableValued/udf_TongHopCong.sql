
--select * from [dbo].[udf_TongHopCong]('2025-11-01','2025-11-30',2,'admin') where employee_id='C1009'

CREATE FUNCTION [dbo].[udf_TongHopCong]
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int,--1: all,2: thử việc, 3: Chính thức
	@UserName nvarchar(50)
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50)
	,wt1 float,wt2 float,wt3 float,wt4 float,wt5 FLOAT
	,wt6 float,wt7 float,wt8 float,wt9 float,wt10 FLOAT
	,wt11 float,wt12 float,wt13 float,wt14 float,wt15 float
	,CN_wt2 float,CN_wt3 float,CN_wt4 float,CN_wt5 FLOAT
	,CN_wt6 float,CN_wt7 float,CN_wt8 float,CN_wt10 FLOAT
	,CN_wt11 float,CN_wt12 float,CN_wt13 float,CN_wt14 float,CN_wt15 float
	, TV datetime, CT datetime, CT_v datetime, TongCongCT float
	,primary key ([Employee_ID])
)
AS
BEGIN
	-- Declare the return variable here
	declare @isKH nvarchar(100), @NgayCuoiThang datetime
	select @NgayCuoiThang = EOMONTH(@fromdate)
	select @isKH = [dbo].[udf_TrangThaiKH](@UserName)
	
	INSERT into @rtnTable
	SELECT
		wt.Employee_ID
		,sum(case when (MaCong='wt1' and @isKH in (1,0)) or (@isKH in (0,2) and MaCong = 'CN_wt1') then wt else 0 end)wt1
		,sum(case when (MaCong='wt2' and @isKH in (1,0)) or (@isKH in (0,2) and MaCong = 'CN_wt2') then wt else 0 end)wt2
		,sum(case when (MaCong='wt3' and @isKH in (1,0)) or (@isKH in (0,2) and MaCong = 'CN_wt3') then wt else 0 end)wt3
		,sum(case when (MaCong='wt4' and @isKH in (1,0)) or (@isKH in (0,2) and MaCong = 'CN_wt4') then wt else 0 end)wt4
		,sum(case when (MaCong='wt5' and @isKH in (1,0)) or (@isKH in (0,2) and MaCong = 'CN_wt5') then wt else 0 end)wt5
		,sum(case when (MaCong='wt6' and @isKH in (1,0)) or (@isKH in (0,2) and MaCong = 'CN_wt6') then wt else 0 end)wt6
		,sum(case when (MaCong='wt7' and @isKH in (1,0)) or (@isKH in (0,2) and MaCong = 'CN_wt7') then wt else 0 end)wt7
		,sum(case when (MaCong='wt8' and @isKH in (1,0)) or (@isKH in (0,2) and MaCong = 'CN_wt8') then wt else 0 end)wt8
		,sum(case when (MaCong='wt9' and @isKH in (1,0)) or (@isKH in (0,2) and MaCong = 'CN_wt9') then wt else 0 end)wt9
		,sum(case when (MaCong='wt10' and @isKH in (1,0)) or (@isKH in (0,2) and MaCong = 'CN_wt10') then wt else 0 end)wt10
		,sum(case when (MaCong='wt11' and @isKH in (1,0)) or (@isKH in (0,2) and MaCong = 'CN_wt11') then wt else 0 end)wt11
		,sum(case when (MaCong='wt12' and @isKH in (1,0)) or (@isKH in (0,2) and MaCong = 'CN_wt12') then wt else 0 end)wt12
		,sum(case when (MaCong='wt13' and @isKH in (1,0)) or (@isKH in (0,2) and MaCong = 'CN_wt13') then wt else 0 end)wt13
		,sum(case when (MaCong='wt14' and @isKH in (1,0)) or (@isKH in (0,2) and MaCong = 'CN_wt14') then wt else 0 end)wt14
		,sum(case when (MaCong='wt15' and @isKH in (1,0)) or (@isKH in (0,2) and MaCong = 'CN_wt15') then wt else 0 end)wt15
		,sum(case when @isKH in (1,2) and MaCong = 'CN_wt2' then wt else 0 end)CN_wt2
		,sum(case when @isKH in (1,2) and MaCong = 'CN_wt3' then wt else 0 end)CN_wt3
		,sum(case when @isKH in (1,2) and MaCong = 'CN_wt4' then wt else 0 end)CN_wt4
		,sum(case when @isKH in (1,2) and MaCong = 'CN_wt5' then wt else 0 end)CN_wt5
		,sum(case when @isKH in (1,2) and MaCong = 'CN_wt6' then wt else 0 end)CN_wt6
		,sum(case when @isKH in (1,2) and MaCong = 'CN_wt7' then wt else 0 end)CN_wt7
		,sum(case when @isKH in (1,2) and MaCong = 'CN_wt8' then wt else 0 end)CN_wt8
		,sum(case when @isKH in (1,2) and MaCong = 'CN_wt10' then wt else 0 end)CN_wt10
		,sum(case when @isKH in (1,2) and MaCong = 'CN_wt11' then wt else 0 end)CN_wt11
		,sum(case when @isKH in (1,2) and MaCong = 'CN_wt12' then wt else 0 end)CN_wt12
		,sum(case when @isKH in (1,2) and MaCong = 'CN_wt13' then wt else 0 end)CN_wt13
		,sum(case when @isKH in (1,2) and MaCong = 'CN_wt14' then wt else 0 end)CN_wt14
		,sum(case when @isKH in (1,2) and MaCong = 'CN_wt15' then wt else 0 end)CN_wt15
		,CT_TV.Ngay, nkhdct.NgayKyHDChinhThuc, nkhdct_v.NgayKyHDChinhThuc
		,sum(case when nkhdct.NgayKyHDChinhThuc < wt.Ngay and MaCong in ('wt1','wt9') then wt else 0 end)
	from
	HR_WTDaily wt
	left join
	[dbo].[udf_NgayDoiLuong](@fromdate,@todate)CT_TV
	on wt.Employee_ID=CT_TV.Employee_ID and CT_TV.TrangThai <> 'HetTV'
	left join
	udf_NgayKyHDChinhThuc (@fromdate, @todate, null) nkhdct
	on wt.Employee_ID = nkhdct.Employee_ID and nkhdct.NgayKyHDChinhThuc between @fromdate+1 and @todate
	left join
	udf_NgayKyHDChinhThuc (@fromdate, @todate, null) nkhdct_v
	on wt.Employee_ID = nkhdct_v.Employee_ID --and nkhdct_v.NgayKyHDChinhThuc between @fromdate+1 and @todate
	WHERE
	(
		(@TypeOfReport=2 and nkhdct_v.NgayKyHDChinhThuc between @fromdate and @todate and wt.Ngay < isnull(isnull(CT_TV.Ngay,nkhdct.NgayKyHDChinhThuc),case when nkhdct_v.NgayKyHDChinhThuc > @todate then @todate + 1 else @fromdate end))--isnull(CT_TV.Ngay,nkhdct.NgayKyHDChinhThuc))
		or (@TypeOfReport=3 and (wt.Ngay >= isnull(isnull(CT_TV.Ngay,nkhdct.NgayKyHDChinhThuc),case when nkhdct_v.NgayKyHDChinhThuc > @todate then @todate + 1 else @fromdate end) or (nkhdct_v.NgayKyHDChinhThuc > @NgayCuoiThang))) --=isnull(isnull(CT_TV.Ngay,nkhdct.NgayKyHDChinhThuc),@fromdate))
		or @TypeOfReport=1
	) and wt.Ngay between @fromdate and @todate	
	--or @TypeOfReport = 2
	group by wt.Employee_ID,CT_TV.Ngay, nkhdct.NgayKyHDChinhThuc, nkhdct_v.NgayKyHDChinhThuc
	-- Return the result of the function
	RETURN

END
--select * from udf_NgayKyHDChinhThuc ('2025-10-01','2025-10-31','C16744')
--select * from udf_NgayDoiLuong ('2025-08-01','2025-08-30')

GO
