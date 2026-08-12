CREATE FUNCTION [dbo].[udf_LuongCoBan_NamSau]     
(
@fromdate datetime,    
@todate datetime
)      
RETURNS table      
AS     
RETURN (
	select ct.Employee_ID,ct.NhomLuong,ct.BacLuong,tl.MucLuong,tl1.MucLuong as MucLuongMoi from HR_ThangLuongChiTiet ct
	inner join
	(
		select Employee_ID, max(Fromdate) as Fromdate from HR_ThangLuongChiTiet
		where Fromdate <@todate and isnull(todate,@todate)>@fromdate
		group by Employee_ID
	)ct1 on ct.Employee_ID=ct1.Employee_ID and ct1.Fromdate = ct.Fromdate
	inner join HR_ThangLuong tl on ct.NhomLuong=tl.NhomLuong and ct.BacLuong=tl.BacLuong
	left join HR_ThangLuong tl1 on ct.NhomLuong=tl1.NhomLuong and ct.BacLuong+1=tl1.BacLuong
)
-- select * from udf_LuongCoBan_NamSau('2019/07/01','2019/07/31') where Employee_ID='19001015'
--select * from HR_ThangLuong where nhomluong='PG 2A' and bacluong=11




GO
