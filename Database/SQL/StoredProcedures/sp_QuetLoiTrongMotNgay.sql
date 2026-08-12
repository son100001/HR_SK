
-- sau ngày 15 mới đc


CREATE PROCEDURE [dbo].[sp_QuetLoiTrongMotNgay]     
(
	@fromdate DATETIME,
	@todate DATETIME,
	@Para_Minute INT=19
	
)      
AS
begin
	
	DECLARE @SoNgaySauKhiMangBauDuocHuongThaiSan INT
	SELECT @SoNgaySauKhiMangBauDuocHuongThaiSan=value
	FROM dbo.SetUp
	WHERE ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
	
	
	SELECT
		QuetLoi.Employee_ID		
		,dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName
		,empl.FactoryName
		,empl.DepartmentName
		,empl.SectionName
		,empl.ChucDanhName
		--,CASE WHEN empl.isTrucTiep=1 THEN N'Trực tiếp' ELSE N'Gián tiếp' END AS TrucTiep
		--,empl.PositionCategory_ID
		--,NULL AS DepCode
		, case when cast(QuetLoi.qv as time) < cast(sh.ToTime as time) then cast(QuetLoi.qv as time) else NULL end as RealTimeIn
		, case when cast(QuetLoi.qr as time) > cast(sh.FromTime as time) then cast(QuetLoi.qr as time) else NULL end as RealTimeOut
		,QuetLoi.AccessDate		
		,QuetLoi.AccessTime
		,QuetLoi.InsertSource		
		
	from
	(
		SELECT
			tkd.*, dlq.qr, dlq.qv, dlq.qv_qr, dlq.ShiftName
		from
		dbo.HR_TimeKeeping_Data tkd
		LEFT join
		(
			select 
				tkd.Employee_ID, tkd.AccessDate
				,case when dkc.ShiftName like '%Shift3' then Min(dateadd(day,1,tkd.AccessTime)) else MAX(tkd.AccessTime) end as qr
				,case when dkc.ShiftName like '%Shift3' then MAX(tkd.AccessTime) else MIN(tkd.AccessTime) end as qv
				,DATEDIFF(MINUTE, case when dkc.ShiftName like '%Shift3' then MAX(tkd.AccessTime) else MIN(tkd.AccessTime) end
								, isnull(case when dkc.ShiftName like '%Shift3' then Min(dateadd(day,1,tkd.AccessTime)) else MAX(tkd.AccessTime) end
										, case when dkc.ShiftName like '%Shift3' then MAX(tkd.AccessTime) else MIN(tkd.AccessTime) end)
						) AS qv_qr
				,dkc.ShiftName
			FROM [dbo].[HR_TimeKeeping_Data] tkd
			LEFT JOIN
			dbo.udf_DangKyCa(@fromdate,@fromdate,@SoNgaySauKhiMangBauDuocHuongThaiSan,NULL,NULL,NULL,NULL,NULL,NULL,NULL) dkc
			ON tkd.Employee_ID=dkc.Employee_ID AND tkd.AccessDate=dkc.AccessDate
			WHERE tkd.[AccessDate] between @fromdate and @todate
			GROUP by tkd.Employee_ID, tkd.AccessDate, dkc.ShiftName
		) as dlq
		ON tkd.Employee_ID=dlq.Employee_ID AND tkd.AccessDate=dlq.AccessDate
		where (qv_qr<=@Para_Minute or qv_qr >= 1200) AND tkd.AccessDate BETWEEN @fromdate AND @todate
	) AS QuetLoi
	left join
	HR_Shifts sh
	on QuetLoi.ShiftName = sh.ShiftName
	LEFT JOIN
    dbo.udf_EmployeeFilter('VN',NULL,NULL,NULL,NULL,NULL,NULL,NULL,@fromdate) empl
	ON QuetLoi.Employee_ID=empl.Employee_ID
	WHERE empl.Employee_ID IS NOT null
	ORDER BY QuetLoi.Employee_ID
	
END 

GO
