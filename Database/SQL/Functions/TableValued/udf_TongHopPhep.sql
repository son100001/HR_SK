--select * from [dbo].[udf_TongHopPhep]('2024-11-01','2024-11-30',3) where Employee_ID = 'SAV009'
CREATE FUNCTION [dbo].[udf_TongHopPhep]
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int--1: all,2: thử việc, 3: Chính thức
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50)
	,PhepNam float,PhepHuongLuong float,KhongPhep FLOAT,HuongBH FLOAT
	,P float,TS float,PKT float,KetHon FLOAT
	,BoMeMat float,NgungViec float,KLKhongMatCC FLOAT--,KhongLuong FLOAT
	,NghiKhongLuong float,NghiLe float,CongTac float,NghiTuan FLOAT
	,NghiBHXH FLOAT,KLKCC float,PN FLOAT--,PN1 float, PN2 float, PKT1 FLOAT
	,PB FLOAT--,PB1 float, PB2 float
	,DS float, HL float, KL FLOAT
	, HuongBHKhongTS FLOAT, CongThucTeDiLam float, TongPhepCT float
	PRIMARY key ([Employee_ID])

)
AS
BEGIN

	-- Declare the return variable here
	-- Add the T-SQL statements to compute the return value here
	--Declare @isKH nvarchar(100)
	--select @isKH = [dbo].[udf_TrangThaiKH](@UserName)
	insert into @rtnTable
	SELECT
		erl.Employee_ID
		,sum(case when @typeOfReport = 5 then 0 when lt.PhepNam=1 then erl.HourLeave else 0 end) PhepNam
		,sum(case when @typeOfReport = 5 then 0 when ISNULL(lt.isLeave_ComPay,0)=1 then erl.HourLeave else 0 end) PhepHuongLuong
		,sum(case when @typeOfReport = 5 then 0 when ISNULL(lt.NotAllow,0)=1 then erl.HourLeave else 0 end) KhongPhep
		,sum(case when @typeOfReport = 5 then 0 when ISNULL(lt.isLeave_InsPay,0)=1 then erl.HourLeave else 0 end) HuongBH
		,Sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID='20' then erl.HourLeave else 0 end) PhepViecRieng
		,Sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID='24' then erl.HourLeave else 0 end) TS
		,Sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID='25' then erl.HourLeave else 0 end) PhepKhamThai
		,Sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID ='12' then erl.HourLeave else 0 end) KetHon
		,Sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID ='33' then erl.HourLeave else 0 end) BoMeMat
		,Sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID='47' then erl.HourLeave else 0 end) NgungViec
		,Sum(case when @typeOfReport = 5 then 0 when isnull(lt.KhongTruCC,0) = 1 AND ISNULL(lt.isLeave_ComPay,0)=0 then erl.HourLeave else 0 end) KLKhongMatCC
		--,sum(case when isnull(lt.isLeave_ComPay,0)=0 and isnull(lt.isLeave_InsPay,0)=0 then erl.HourLeave else 0 end) KhongLuong
		,sum(case when @typeOfReport = 5 then 0 when isnull(lt.isLeave_ComPay,0)=0 and lt.LeaveType_ID<>'53' then erl.HourLeave else 0 end) NghiKhongLuong
		,sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID='50' then erl.HourLeave else 0 end) NghiLe
		,sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID='52' then erl.HourLeave else 0 end) CongTac
		,sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID='53' then erl.HourLeave else 0 end) NghiTuan
		,sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID='54' then erl.HourLeave else 0 end) NghiBHXH
		,sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID='46' then erl.HourLeave else 0 end) KLKCC
		,sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID='11' then erl.HourLeave else 0 end) PN
		--,sum(case when lt.LeaveType_ID='58' then erl.HourLeave else 0 end) PN1
		--,sum(case when lt.LeaveType_ID='59' then erl.HourLeave else 0 end) PN2
		--,sum(case when lt.LeaveType_ID='60' then erl.HourLeave else 0 end) PKT1
		,sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID='21' then erl.HourLeave else 0 end) PB
		--,sum(case when lt.LeaveType_ID='61' then erl.HourLeave else 0 end) PB1
		--,sum(case when lt.LeaveType_ID='62' then erl.HourLeave else 0 end) PB2
		,sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID='48' then erl.HourLeave else 0 end) DS
		,sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID='19' then erl.HourLeave else 0 end) HL
		,sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID='18' then erl.HourLeave else 0 end) KL
		,sum(case when @typeOfReport = 5 then 0 when lt.isLeave_InsPay=1 and lt.LeaveType_ID <> '24' then erl.HourLeave else 0 end) HuongBHKhongTS
		,sum(case when @typeOfReport = 5 then 0 when lt.LeaveType_ID in ('52') then erl.HourLeave else 0 end) CongThucTeDiLam
		,sum(case when @typeOfReport = 5 then 0 when nkhdct.NgayKyHDChinhThuc < erl.DateLeave and ISNULL(lt.isLeave_ComPay,0)=1 then HourLeave else 0 end)
	from
	udf_BangPhepTheoNgay(2,@fromdate,@todate,null,null,null,null,null,null,null,null) erl
	left join
	[dbo].[udf_NgayDoiLuong](@fromdate,@todate)CT_TV
	on erl.Employee_ID=CT_TV.Employee_ID and CT_TV.TrangThai <> 'HetTV'
	left join
	udf_NgayKyHDChinhThuc (@fromdate, @todate, null) nkhdct
	on erl.Employee_ID = nkhdct.Employee_ID and nkhdct.NgayKyHDChinhThuc between @fromdate+1 and @todate
	left join
	SmartBooks_LeaveType lt
	on erl.LeaveType_ID=lt.LeaveType_ID
	where (
			(@TypeOfReport=2 and erl.DateLeave < isnull(CT_TV.Ngay,nkhdct.NgayKyHDChinhThuc))--isnull(CT_TV.Ngay,nkhdct.NgayKyHDChinhThuc))
			or (@TypeOfReport=3 and erl.DateLeave >= isnull(isnull(CT_TV.Ngay,nkhdct.NgayKyHDChinhThuc),@fromdate))--isnull(isnull(CT_TV.Ngay,nkhdct.NgayKyHDChinhThuc),@fromdate))
			or @TypeOfReport=1
		) and erl.DateLeave between @fromdate and @todate
	group by erl.Employee_ID
	-- Return the result of the function
	RETURN

END




GO
