CREATE FUNCTION [dbo].[udf_LuongCoBan]     
(
@fromdate datetime,    
@todate datetime
)      
RETURNS table      
AS     
RETURN (
	select ct.Employee_ID,ct.NhomLuong,ct.BacLuong,tl.MucLuong from HR_ThangLuongChiTiet ct
	inner join
	(
		select Employee_ID, max(Fromdate) as Fromdate from HR_ThangLuongChiTiet
		where Fromdate <=@todate and isnull(todate,@todate)>@fromdate
		group by Employee_ID
	)ct1 on ct.Employee_ID=ct1.Employee_ID and ct1.Fromdate = ct.Fromdate
	inner join HR_ThangLuong tl on ct.NhomLuong=tl.NhomLuong and ct.BacLuong=tl.BacLuong
)
--select * from udf_LuongCoBan('2019/07/01','2019/07/31') where Employee_ID='19001186'




GO
