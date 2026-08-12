--select * from [dbo].[udf_NgayDoiLuong]('2025-08-01','2025-08-31') where employee_id='C11011'
CREATE FUNCTION [dbo].[udf_NgayDoiLuong]
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime
)
RETURNS  @rtnNgayDoiLuong TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),Ngay datetime,TrangThai varchar(10)
	,primary key ([Employee_ID],Ngay)
)
AS
BEGIN
	-- Declare the return variable here
	insert into @rtnNgayDoiLuong
	SELECT
		empl.Employee_ID
		,max(
			isnull(sc.Fromdate
				,nkhdct.NgayKyHDChinhThuc)) as Ngay
		,CASE
			WHEN Fromdate is null and nkhdct.NgayKyHDChinhThuc is not null then 'HetTV'
			ELSE 'DoiLuong' 
		END as TrangThai
	from
	SmartBooks_Employee empl
	left join
	HR_SalaryComponent sc
	on empl.Employee_ID = sc.Employee_ID and sc.Fromdate between @fromdate+1 and @todate-1
	left join
	udf_NgayKyHDChinhThuc (@fromdate, @todate, null) nkhdct
	on empl.Employee_ID = nkhdct.Employee_ID and nkhdct.NgayKyHDChinhThuc between @fromdate+1 and @todate
	where (((sc.Fromdate between @fromdate+1 and @todate) or (nkhdct.NgayKyHDChinhThuc between @fromdate+1 and @todate)) and empl.StartedDate <> sc.Fromdate)
	group by empl.Employee_ID,case when Fromdate is null and nkhdct.NgayKyHDChinhThuc is not null then 'HetTV' else 'DoiLuong' end
	-- Return the result of the function
	RETURN

END

GO
