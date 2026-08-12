-- =============================================  
-- Author:  Nguyen Tran Hieu 
-- ALTER  date: 15/01/2017 
-- Description: Xu ly tong hop cac loai nghi
-- select * from  udf_TongHopNghi('2019/07/01','2019/07/31') where employee_id='19001139'
-- select * from HR_EmpRegisLeave where employee_id='19000033'
-- select * from [dbo].[HR_EmployeeRegisMaternityLeave] where employee_id='19000033'
CREATE FUNCTION [dbo].[udf_TongHopNghi]     
(
	@fromdate datetime,        
	@todate datetime
) 
RETURNS table      
AS                 
RETURN (
	select Employee_ID,
	sum(case when rl.LeaveType_ID=11 then HourLeave else 0 end) as PhepNam,
	sum(case when rl.LeaveType_ID=12 then HourLeave else 0 end) as Nghicuoi,
	sum(case when rl.LeaveType_ID=13 then HourLeave else 0 end) as TaiNan,
	sum(case when rl.LeaveType_ID=14 then HourLeave else 0 end) as NghiKhongPhep,
	sum(case when rl.LeaveType_ID=15 then HourLeave else 0 end) as NghiDuongThai,
	sum(case when rl.LeaveType_ID=16 then HourLeave else 0 end) as NghiCoLyDo,
	sum(case when rl.LeaveType_ID=17 then HourLeave else 0 end) as NghiKhongCoViec,
	sum(case when rl.LeaveType_ID=19 then HourLeave else 0 end) as CaNhan,
	sum(case when rl.LeaveType_ID=20 then HourLeave else 0 end) as NghiKhongLuong,
	sum(case when rl.LeaveType_ID=21 then HourLeave else 0 end) as NghiOm,
	sum(case when rl.LeaveType_ID=22 then HourLeave else 0 end) as ConOm,
	sum(case when rl.LeaveType_ID=23 then HourLeave else 0 end) as NghiLyDoGiaDinh,
	sum(case when rl.LeaveType_ID=24 then HourLeave else 0 end) as SinhNhatCon,
	sum(case when rl.LeaveType_ID=25 then HourLeave else 0 end) as NghiTiemPhong,
	sum(case when rl.LeaveType_ID=26 then HourLeave else 0 end) as NghiThaiHu,
	sum(case when rl.LeaveType_ID=27 then HourLeave else 0 end) as DiNghiaVuQuanSu,
	sum(case when rl.LeaveType_ID=28 then HourLeave else 0 end) as ThuMoi,
	sum(case when rl.LeaveType_ID=29 then HourLeave else 0 end) as NghiChoThoiViec,
	sum(case when rl.LeaveType_ID=31 then HourLeave else 0 end) as PhepNuaNgay_truoc,
	sum(case when rl.LeaveType_ID=32 then HourLeave else 0 end) as PhepNuaNgay_Sau,
	sum(case when rl.LeaveType_ID=33 then HourLeave else 0 end) as NguoiNhaMat,
	sum(case when ISNULL(isLeave_nonPay,0)=1 and DateLeave<=DATEADD(day,14,@fromdate) then 1 else 0 end)+dbo.udf_CountSunDay(@fromdate,DATEADD(day,14,@fromdate))  as NghiKhongLuongDenNgay15,
	sum(case when ISNULL(isleave_compay,0)=1 or rl.LeaveType_ID=50 then HourLeave/8 else 0 end) as nghicoluong,
	sum(case when ISNULL(isLeave_nonPay,0)=1 and rl.LeaveType_ID not in (16,50) then 1 else 0 end) as nghikoluong,
	sum(case when rl.LeaveType_ID=50 then HourLeave/8 else 0 end) as nghile,
	sum(case when rl.LeaveType_ID=16 or rl.LeaveType_ID=20 or rl.LeaveType_ID=25 then 1 else 0 end) as nghikhongtrucc,
	sum(case when (rl.LeaveType_ID=13) or (ISNULL(isLeave_nonPay,0)=1 and rl.LeaveType_ID not in (16,25,50))  then HourLeave/8 else 0 end) as nghitrucc,
	
	sum(case when rl.LeaveType_ID=24 and HourLeave>0 and rl.DateLeave< DATEADD(day,14,@fromdate) then 1 else 0 end) as nghithaisan_truocngay16,
	sum(case when rl.LeaveType_ID=21 then 1 else 0 end) as NghiBH,
	isnull(isProbation,0) as isProbation

	from HR_EmpRegisLeave rl
	left join SmartBooks_LeaveType tl on rl.LeaveType_ID COLLATE DATABASE_DEFAULT = tl.LeaveType_ID


	where DateLeave between @fromdate and @todate
	group by Employee_ID,isProbation
)




GO
