CREATE FUNCTION [dbo].[udf_LuongCoBan_BacCu]     
(
@fromdate datetime,    
@todate datetime
)      
RETURNS table      
AS     
RETURN (
	select ct.Employee_ID,ct.NhomLuong,ct.BacLuong,tl.MucLuong,ct.Fromdate from HR_ThangLuongChiTiet ct
	inner join
	(
		select Employee_ID, max(Fromdate) as Fromdate from HR_ThangLuongChiTiet
		where isnull(todate,@todate) <@todate and Todate is  not null
		group by Employee_ID
	)ct1 on ct.Employee_ID=ct1.Employee_ID and ct1.Fromdate = ct.Fromdate
	inner join HR_ThangLuong tl on ct.NhomLuong=tl.NhomLuong and ct.BacLuong=tl.BacLuong
	
)
--select * from udf_LuongCoBan_BacCu('2019/06/01','2019/06/30') where Employee_ID='19001066'
--select * from udf_LuongCoBan('2019/06/01','2019/06/30') where Employee_ID='19001066'




GO
