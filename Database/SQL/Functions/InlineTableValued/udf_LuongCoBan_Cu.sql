CREATE FUNCTION [dbo].[udf_LuongCoBan_Cu]     
(
@fromdate datetime,    
@todate datetime
)      
RETURNS table      
AS     
RETURN (
	WITH MyRowSet
	AS
	(
		select ct.Employee_ID,ct.NhomLuong,tl.BacLuong,ct.Fromdate,ct.Todate,tl.MucLuong 
		,ROW_NUMBER() OVER (PARTITION BY Employee_ID ORDER BY Fromdate desc)  AS RowNum from HR_ThangLuongChiTiet ct
		inner join HR_ThangLuong tl on ct.NhomLuong=tl.NhomLuong and tl.BacLuong = ct.BacLuong
		where Fromdate between @fromdate and @todate --and isnull(Status,1)=1
	)
	
	SELECT * FROM MyRowSet WHERE RowNum = 2
)
--select * from udf_LuongCoBan_cu('2019/06/01','2019/06/30')
--select * from udf_LuongCoBan_cu('2019/06/01','2019/06/30')




GO
