CREATE function [dbo].[udf_TongHopLuongTheoBoPhan] 
--select * from udf_TongHopLuongTheoBoPhan (3,2023,null,null,null,null,null,null,null,'MonthlySalary')
(
	@Month int,
	@Year int,
	@MaCongViec nvarchar(50),
	@fact nvarchar(50),
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@SalaryKey varchar(50)=null
)
returns @rtnTongHopLuongTheoBoPhan table
(
	MaCongViec nvarchar(50), GroupbyChucDanh nvarchar(50), SoLuongNV int, BasicSalary float, PhuCap float, TienTangCa float, Luong1Gio float, GioLamViecKhongCoNghi float, GioTangCa150 float, GioTangCaCN200 float, GioTangCaDem210 float, GioTangCaDemCN270 float, GioTangCaLe300 float, GioTangCaDemLe390 float, TongTangCa float, TongTangCaVaHCDaChuyen float, GioLamDem130 float, TienCaDem130 float, TongLuong float, CongDoanCtyTra float, BHCtyTra float, TongChiPhi float, BHNVDong float, TTCN float, CongDoanNVDong float, TroCapConNho float, TroCapPhuNu float, HoTroKhac float, ThucNhan float, LuongChoViec float, primary key (MaCongViec,GroupbyChucDanh)
)
as
begin
	declare @fromdate datetime, @todate datetime
	set @fromdate = DATEFROMPARTS(@Year,@Month,1)
	set @todate = EOMONTH(@fromdate)
	insert into @rtnTongHopLuongTheoBoPhan
	select isnull(@MaCongViec,'All') as MaCongViec, empl.GroupbyChucDanh, count(s.Employee_ID) as SoLuongNV, sum(isnull(s.s1,0)) as BasicSalary, sum(isnull(s.s2,0)) + sum(isnull(s.s3,0)) + sum(isnull(s.s4,0)) + sum(isnull(s.s5,0)) + sum(isnull(s.s6,0)) + sum(isnull(s.s7,0)) + sum(isnull(s.s8,0)) + sum(isnull(s.s9,0)) + sum(isnull(s.s10,0)) + sum(isnull(s.s11,0)) + sum(isnull(s.s12,0))  as PhuCap, sum(isnull(s.s38,0)) as TienTangCa, sum(isnull(s.TongThuNhap,0))/(sum(isnull(s.s80,0)) - sum(isnull(s.s67,0)) - sum(isnull(s.s69,0))) as Luong1Gio, (sum(isnull(s.s17,0)) + sum(isnull(s.s19,0)))*8 - sum(isnull(s.s67,0)) - sum(isnull(s.s69,0)) as GioLamViecKhongCoNghi
			, sum(isnull(s.s23,0)) + sum(isnull(s.s31,0)) as GioTangCa150, sum(isnull(s.s24,0)) + sum(isnull(s.s32,0)) as GioTangCaCN200, sum(isnull(s.s25,0)) + sum(isnull(s.s33,0)) as GioTangCaDem210, sum(isnull(s.s26,0)) + sum(isnull(s.s34,0)) as GioTangCaDemCN270, sum(isnull(s.s27,0)) + sum(isnull(s.s35,0)) as GioTangCaLe300, sum(isnull(s.s28,0)) + sum(isnull(s.s36,0)) as GioTangCaDemLe390, sum(isnull(s.s82,0)) as TongTangCa, sum(isnull(s.s80,0)) - sum(isnull(s.s67,0)) - sum(isnull(s.s69,0)) as TongTangCaVaHCDaChuyen
			, (sum(isnull(s.s22,0)) + sum(isnull(s.s30,0)))*0.3 as GioLamDem130, sum(isnull(s.s37,0)) as TienCaDem130, sum(isnull(s.TONGTHUNHAP,0)) as TongLuong, sum(isnull(s.s41,0)) as CongDoanCtyTra, sum(isnull(s.s46,0)) - sum(isnull(s.s41,0)) as BHCtyTra, sum(isnull(s.TONGTHUNHAP,0)) + sum(isnull(s.s41,0)) + sum(isnull(s.s46,0)) as TongChiPhi, sum(isnull(s.s50,0)) as BHNVDong, sum(isnull(s.s55,0)) as TTCN, sum(isnull(s.s58,0)) as CongDoanNVDong, sum(isnull(s.s14,0)) as TroCapConNho, sum(isnull(s.s15,0)) as TroCapPhuNu, sum(isnull(s.s62,0)) as HoTroKhac, sum(isnull(s.s63,0)) as ThucNhan, sum(isnull(s.s81,0)) as LuongChoViec
	from
	SmartBooks_Salary s
	left join
	udf_EmployeeFilter ('VN',@fact,@dept,@sect,@team,@pos,@posc,null,@todate) empl
	on s.Employee_ID = empl.Employee_ID
	where s.[key] = @SalaryKey and s.Salary_Month = @Month and s.Salary_Year = @Year and (case when isnull(@MaCongViec,'') = '' then '' else empl.CongViecPhaiLam end) = (case when isnull(@MaCongViec,'') = '' then '' else @MaCongViec end) and ChucDanh is not null and empl.GroupbyChucDanh is not null
	group by case when @MaCongViec is null then 'All' else empl.CongViecPhaiLam end, empl.GroupbyChucDanh

	return
end
GO
