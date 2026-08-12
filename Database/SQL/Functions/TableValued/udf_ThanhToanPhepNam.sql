
CREATE FUNCTION [dbo].[udf_ThanhToanPhepNam] 
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_ThanhToanPhepNam] (2,2020)
	@Month int,
	@Year int
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
     [Employee_ID] nvarchar(50),TienLuong1 float,TienLuong2 float,TienLuong3 float,TienLuong4 float,TienLuong5 float,TienLuong6 float,LuongBQ float
	 ,SoNgayPNTon float,TienPN float
	 ,primary key ([Employee_ID])
)
AS
BEGIN
 declare @fromdate datetime,@todate datetime,@fromdateThangTruoc datetime,@todateThangTruoc datetime
 set @fromdate=DATEFROMPARTS(@year,@Month,1)
 set @todate=dateadd(month,1,@fromdate)-1
 set @todateThangTruoc=@fromdate-1
 set @fromdateThangTruoc=dateadd(month,1,@fromdate)
 insert into @rtnTable
 select empl.Employee_ID,l6tgn.TienLuong1,l6tgn.TienLuong2,l6tgn.TienLuong3,l6tgn.TienLuong4,l6tgn.TienLuong5,l6tgn.TienLuong6,l6tgn.LuongBQ
		,isnull(pn.PhepNamDuocHuongDenHienTai,0)+isnull(pn.PhepNamTon,0)-isnull(pn.TongPhepNamDaNghi,0) as SoNgayPNTon
		,l6tgn.LuongBQ
		/(case when DATEPART(day,@todateThangTruoc)-[dbo].[udf_CountSunDay](@fromdateThangTruoc,@todateThangTruoc)>26 then 26 else DATEPART(day,@todateThangTruoc)-[dbo].[udf_CountSunDay](@fromdateThangTruoc,@todateThangTruoc) end)
		*(isnull(pn.PhepNamDuocHuongDenHienTai,0)+isnull(pn.PhepNamTon,0)-isnull(pn.TongPhepNamDaNghi,0))
 from
	SmartBooks_Employee empl
	left join
	[dbo].[udf_QuanLyPhepNam](@year,null,'VN',null,null,null,null,null,null,null) pn
	on empl.Employee_ID=pn.Employee_ID
	left join
	udf_Luong6ThangGanNhat(@fromdate,@todate+1,null,null,null,null,null,null,null) l6tgn
	on empl.Employee_ID=l6tgn.Employee_ID
	--Son Sua
	left join
	SmartBooks_Salary DaTinhTruyThuPN
	on empl.Employee_ID=DaTinhTruyThuPN.Employee_ID AND DaTinhTruyThuPN.[Key]='TruyThuPhepNam' and DaTinhTruyThuPN.Salary_Month = @Month and DaTinhTruyThuPN.Salary_Year = @Year
	where empl.TernimationDate between @fromdate and @todate+1 and isnull(pn.PhepNamDuocHuongDenHienTai,0)+isnull(pn.PhepNamTon,0)-isnull(pn.TongPhepNamDaNghi,0)>0 --and hrsl.[key] not like N'TruyThuPhepNam'
		and DaTinhTruyThuPN.Employee_ID is null
	-- Return the result of the function
	RETURN

END



GO
