CREATE FUNCTION [dbo].[udf_LuongCoBan_Emp]     
(
@fromdate datetime,    
@todate datetime,
@empID nvarchar(50)
)      
RETURNS table      
AS     
RETURN (
	select ct.Employee_ID,ct.NhomLuong,ct.BacLuong,ct.Fromdate,ct.Todate,tl.MucLuong from HR_ThangLuongChiTiet ct
	inner join
	(
		select distinct Employee_ID, max(Fromdate) as Fromdate from HR_ThangLuongChiTiet
		where Fromdate <@todate
		group by Employee_ID
	)ct1 on ct.Employee_ID=ct1.Employee_ID
	inner join HR_ThangLuong tl on ct.NhomLuong=tl.NhomLuong and ct.BacLuong=tl.BacLuong

	where ct.Employee_ID=@empID
)
--select * from udf_LuongCoBan_emp('2019/05/01','2019/05/31','19000002')




GO
