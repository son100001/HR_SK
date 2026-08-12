--select * from HR_GoOut where Employee_ID='21061872'
CREATE function [dbo].[udf_DiTreVeSomVaXinRaNgoai]
--select * from udf_DiTreVeSomVaXinRaNgoai ('2022-07-23','2022-07-23','VN',null,null,null,null,null,null,null) where Employee_ID = '19091346'
(
	@fromdate datetime,
	@todate datetime,
	@LAN nvarchar(5) = 'VN',
	@fact nvarchar(50) = null,
	@dept nvarchar(50) = null,
	@sect nvarchar(50) = null,
	@team nvarchar(50) = null,
	@pos nvarchar(50) = null,
	@posc nvarchar(50) = null,
	@Employee_ID  nvarchar(50) = null
)
returns @rtnDiTreVeSomVaXinRaNgoai table
(
	Employee_ID nvarchar(50)
	,ThoiGianDiTreVeSom_CT FLOAT, SoLanDiTreVeSom_CT INT
	,ThoiGianXinRaNgoai_CT FLOAT, SoLanXinRaNgoai_CT INT
	,SoLanQuenQuetVanTay_CT INT
	,ThoiGianDiTreVeSom_TV FLOAT, SoLanDiTreVeSom_TV INT
	,ThoiGianXinRaNgoai_TV float, SoLanXinRaNgoai_TV INT
	,SoLanQuenQuetVanTay_TV INT
	, primary key(Employee_ID)
)
as
begin
	insert @rtnDiTreVeSomVaXinRaNgoai
	SELECT
		tito.Employee_ID
		, sum(case /*when isnull(LateIn,0) <= isnull(sufdDM.[Value],0) and isnull(EarlyOut,0) <= isnull(sufdVS.[Value],0) then 0*/
				WHEN tito.OT_date >= isnull(nkhdct.NgayKyHDChinhThuc, @fromdate)
						THEN ((CASE
									WHEN isnull(LateIn,0) <= isnull(sufdDM.[Value],0) then 0
									ELSE isnull(LateIn,0)
								END)
							+ (CASE
									WHEN isnull(EarlyOut,0) <= isnull(sufdVS.[Value],0) then 0
									ELSE isnull(EarlyOut,0)
								END)
							)
				else 0
		END) as ThoiGianDiTreVeSom_CT
		, sum(CASE
					WHEN tito.OT_date >= isnull(nkhdct.NgayKyHDChinhThuc, @fromdate) /*and (gout.LeaveType_ID = 'Private' or gout.Employee_ID is null)*/
							THEN (CASE
										WHEN isnull(LateIn,0) <= isnull(sufdDM.[Value],0) then 0
										ELSE 1
									END
								+ CASE
										WHEN isnull(EarlyOut,0) <= isnull(sufdVS.[Value],0) then 0
										ELSE 1
									END)
					ELSE 0
			END) as SoLanDiTreVeSom_CT
		
		,sum(CASE
				WHEN tito.OT_date >= isnull(nkhdct.NgayKyHDChinhThuc, @fromdate) and gout.LeaveType_ID not in (N'KhongTruCC',N'Business')
						THEN DATEDIFF(MINUTE, gout.TimeOut_, gout.TimeIn)
				ELSE 0
		END) as ThoiGianXinRaNgoai_CT
		,sum(CASE
				WHEN tito.OT_date >= isnull(nkhdct.NgayKyHDChinhThuc, @fromdate) and gout.LeaveType_ID not in (N'KhongTruCC',N'Business') then 1
				ELSE 0
		END) as SoLanXinRaNgoai_CT
		
		,sum(CASE
				WHEN tito.OT_date >= isnull(nkhdct.NgayKyHDChinhThuc, @fromdate) then QuenQuet.SoLanQuenQuet
				ELSE 0
		END) as SoLanQuenQuetVanTay_CT
		
		,sum(case /*when isnull(LateIn,0) <= isnull(sufdDM.[Value],0) and isnull(EarlyOut,0) <= isnull(sufdVS.[Value],0) then 0*/
				WHEN tito.OT_date < isnull(nkhdct.NgayKyHDChinhThuc, @fromdate) 
						THEN ((CASE
									WHEN isnull(LateIn,0) <= isnull(sufdDM.[Value],0) then 0
									ELSE isnull(LateIn,0)
								END)
							+ (CASE
									WHEN isnull(EarlyOut,0) <= isnull(sufdVS.[Value],0) then 0
									ELSE isnull(EarlyOut,0)
								END)
							)
				ELSE 0
		end) as ThoiGianDiTreVeSom_TV		
		,sum(CASE
				when tito.OT_date < isnull(nkhdct.NgayKyHDChinhThuc, @fromdate) /*and (gout.LeaveType_ID = 'Private' or gout.Employee_ID is null)*/ 
						then (CASE
								when isnull(LateIn,0) <= isnull(sufdDM.[Value],0) then 0
								else 1
								end 
							+ CASE
								when isnull(EarlyOut,0) <= isnull(sufdVS.[Value],0) THEN 0
								else 1
								end)
				else 0
		end) as SoLanDiTreVeSom_TV

		,sum(CASE
				when tito.OT_date < isnull(nkhdct.NgayKyHDChinhThuc, @fromdate) and gout.LeaveType_ID not in (N'KhongTruCC',N'Business')
						THEN DATEDIFF(MINUTE, gout.TimeOut_, gout.TimeIn)
				ELSE 0
		end) as ThoiGianXinRaNgoai_TV
		, sum(CASE
				when tito.OT_date < isnull(nkhdct.NgayKyHDChinhThuc, @fromdate) and gout.LeaveType_ID not in (N'KhongTruCC',N'Business') then 1 
				else 0
		end) as SoLanXinRaNgoai_TV
		
		,sum(CASE
				when tito.OT_date < isnull(nkhdct.NgayKyHDChinhThuc, @fromdate) then QuenQuet.SoLanQuenQuet
				else 0
		end) as SoLanQuenQuetVanTay_TV
		--, gout.*
	from
	HR_TimeIn_TimeOut tito
	left join
	HR_GoOut gout
	on tito.Employee_ID = gout.Employee_ID and tito.OT_date = gout.TimeDate --and gout.LeaveType_ID not in (N'KhongTruCC',N'Business')
	left join
	(
		select Employee_ID,AccessDate as Ngay,count(Employee_ID) as SoLanQuenQuet
		from HR_TimeKeeping_Data
		where AccessDate between @fromdate and @todate and insertsource='NhapTay' and isnull(Reason,'')=N'ForgotScan' group by Employee_ID, AccessDate
		
		union
		select Employee_ID,Ngay, 0 as SoLanQuenQuet
		from HR_DuLieuQuetVaoRa
		WHERE Ngay between @fromdate and @todate
	)QuenQuet
	on tito.Employee_ID=QuenQuet.Employee_ID and tito.OT_date=QuenQuet.Ngay
	--left join
	--udf_NgayDoiLuong (@fromdate, @todate) ndl
	--on tito.Employee_ID = ndl.Employee_ID
	LEFT JOIN 
	dbo.udf_NgayKyHDChinhThuc(@fromdate,@todate,@Employee_ID) nkhdct
	ON tito.Employee_ID=nkhdct.Employee_ID
	left join
	HR_SetUpFollowDate sufdVS
	on tito.OT_date between sufdVS.Fromdate and sufdVS.Todate and sufdVS.Group_ = 'KhongTinhDMVS' and sufdVS.Code = 'KhongTinhVS'
	left join
	HR_SetUpFollowDate sufdDM
	on tito.OT_date between sufdDM.Fromdate and sufdDM.Todate and sufdDM.Group_ = 'KhongTinhDMVS' and sufdDM.Code = 'KhongTinhDM'
	where tito.OT_date between @fromdate and @todate
	AND (
			(isnull(LateIn,0) + isnull(EarlyOut,0) > 0
			OR (gout.Employee_ID is not null)
		) 
	OR QuenQuet.Employee_ID is not null)		
	group by tito.Employee_ID

	return
end

--select * from HR_GoOut

GO
