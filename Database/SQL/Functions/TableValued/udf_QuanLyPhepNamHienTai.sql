

--select * from [dbo].[udf_QuanLyPhepNamHienTai](2025,'2025-06-23','VN',NULL,NULL,NULL,NULL,NULL,NULL,'00313')


create FUNCTION [dbo].[udf_QuanLyPhepNamHienTai]
(	
	-- Add the parameters for the function here
	--select * from smartbooks_employee
	
	@year INT,
	@NgayChot DATETIME,
	@Lan NVARCHAR(50)='VN',
	@fact NVARCHAR(50)=NULL,
	@dept NVARCHAR(50)=NULL,
	@sect NVARCHAR(50)=NULL,
	@team NVARCHAR(50)=NULL,
	@pos NVARCHAR(50)=NULL,
	@posc NVARCHAR(50)=NULL,
	@emp NVARCHAR(50)=NULL 
)
RETURNS @rtnQuanLyPhepNam TABLE 
(
    -- columns returned by the function
    [Employee_ID] NVARCHAR(50)
	,StartedDate datetime
	,NamThamNien FLOAT
	,PhepNamDuocHuong FLOAT
	,PhepNamTon FLOAT
	,TongPhepNamDaNghi FLOAT
	--,PhepNamDuocHuongDenHienTai_ChuaLamTron FLOAT
	,PhepNamDuocHuongDenHienTai FLOAT
	, PhepNamThamNienTinhDenCuoiNam FLOAT
	, PhepNamNNDHTinhDenCuoiNam FLOAT
	,DaysAdjust FLOAT
	,PendingLeave float
	PRIMARY KEY ([Employee_ID])
)
AS
BEGIN
	-- Declare the return variable here
	DECLARE
		@NgayDauNam DATETIME
		,@NgayCuoiNam DATETIME
		,@NgayHienTai DATETIME
		,@NgayDauThang DATETIME
		,@NgayCuoiThang datetime
	
	SET @NgayDauNam=CAST(@year AS VARCHAR)+'-1-1'
	SET @NgayCuoiNam=DATEADD(YEAR,1,@NgayDauNam)-1
	SET @NgayHienTai=GETDATE()	
	
	IF @NgayChot IS NOT NULL    
		SET @NgayHienTai=@NgayChot	
	ELSE 
		SET @NgayHienTai=GETDATE()	
	
	IF @NgayHienTai>@NgayCuoiNam
	BEGIN
		SET @NgayHienTai=@NgayCuoiNam			
	END	

	SET @NgayDauThang= DATEFROMPARTS(YEAR(@NgayHienTai),MONTH(@NgayHienTai),1)
	SET @NgayCuoiThang=EOMONTH(@NgayDauThang)
	-----------------------------------	

	DECLARE @tabPhepDaNghiTheoNgay TABLE(Employee_ID NVARCHAR(50),TongPhepNamDaNghi FLOAT, PRIMARY KEY (Employee_ID))
	
	INSERT INTO @tabPhepDaNghiTheoNgay
	SELECT
		Employee_ID, TongPhepNamDaNghi
	FROM [dbo].[udf_BangTongPhepNamDNghKoPhep](@NgayDauNam,@NgayCuoiNam,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL) 
	

	DECLARE @empl TABLE(
				Employee_ID NVARCHAR(50)
				,NamThamNien FLOAT
				,ThangThamNienLe FLOAT
				,StartedDate DATETIME
				,OfficialDate DATETIME
				--,StartedDate_PhepNam DATETIME
				,TernimationDate DATETIME
				,TernimationDate_PhepNam DATETIME
				,ThangTinhLuong DATETIME 
				PRIMARY KEY(Employee_ID)
				)

	INSERT INTO @empl
	SELECT
		empl.employee_id
		,DATEDIFF(DAY,StartedDate,@NgayCuoiNam)/365.0 AS NamThamNien
		,(DATEDIFF(DAY,StartedDate,@NgayHienTai)-DATEDIFF(YEAR,StartedDate,@NgayCuoiNam)*365)/365.0*12 AS ThangThamNienLe
		,empl.StartedDate
		,empl.OfficialDate
		
		--,CASE 
		--	WHEN TernimationDate IS NOT NULL THEN CASE WHEN DAY(OfficialDate)<=15 THEN OfficialDate ELSE DATEADD(MONTH,1,OfficialDate) END
		--	ELSE CASE WHEN DAY(StartedDate)<=15 THEN ComStartedDate ELSE DATEADD(MONTH,1,ComStartedDate) END
		--END AS StartedDate_PhepNam
		
		--Phép năm : Nếu người đó kí hợp đồng chính thức thì tính từ ngày vào làm, còn nếu không thì không được tính
		,TernimationDate
		
		--Nếu ngày thôi việc trước ngày 15 thì tháng đó ko có phép năm và ngày nghỉ tính phép năm sẽ là tháng trước
		,(CASE WHEN DAY(TernimationDate)<=14 THEN DATEADD(MONTH,-1,TernimationDate) ELSE TernimationDate END) AS TernimationDate_PhepNam
					
		,ta.ThangTinhLuong
	FROM
	SmartBooks_Employee empl
	LEFT JOIN
	HR_TerminationAsignment ta
	ON empl.Employee_ID=ta.Employee_ID
	WHERE (CASE WHEN ISNULL(@emp,'')='' THEN '' ELSE empl.Employee_ID END)=ISNULL(@emp,'')
	AND empl.StartedDate<=@NgayCuoiNam AND ISNULL(empl.TernimationDate, @NgayCuoiNam)>@NgayDauNam
	AND empl.Factory_ID<>'SES'
	----------------------------
	
	DECLARE @cong TABLE (Employee_ID NVARCHAR(50), ngay INT)
	INSERT INTO @cong
	(
	    Employee_ID,
	    ngay
	)
	SELECT
		empl.Employee_ID
		,COUNT(wt.ngay) AS Ngay
	FROM 
	@empl empl	
	LEFT JOIN
    (
		SELECT Employee_ID, Ngay, SUM(wt) AS wt
        FROM dbo.HR_WTDaily
		WHERE Ngay BETWEEN @NgayDauThang AND @NgayCuoiThang	
		GROUP BY Employee_ID, Ngay
	) wt	
	ON empl.Employee_ID=wt.Employee_ID
	WHERE empl.TernimationDate_PhepNam BETWEEN @NgayDauThang AND @NgayCuoiThang
	AND ISNULL(wt,0)>2
	GROUP BY empl.Employee_ID

	

	INSERT INTO @rtnQuanLyPhepNam (
					[Employee_ID]
					,StartedDate
					,NamThamNien
					,PhepNamDuocHuong
					,PhepNamTon
					,TongPhepNamDaNghi
					--,PhepNamDuocHuongDenHienTai_ChuaLamTron
					,PhepNamDuocHuongDenHienTai
					,PhepNamThamNienTinhDenCuoiNam
					--,PhepNamNNDHTinhDenCuoiNam
					,DaysAdjust
					,PendingLeave
					)
	SELECT
		empl.Employee_ID
		,empl.StartedDate
		,empl.NamThamNien
		,DATEDIFF(MONTH
					,CASE WHEN StartedDate<=@NgayDauNam THEN @NgayDauNam ELSE StartedDate END
					,CASE WHEN empl.TernimationDate_PhepNam IS NULL OR empl.TernimationDate_PhepNam>@NgayHienTai THEN @NgayHienTai ELSE empl.TernimationDate_PhepNam END
					)+1				 
		+ FLOOR(ISNULL(empl.NamThamNien,0)/5.0)
		--+ISNULL(nndh.SoPhepNamNNDH,0)
		
		--Đặc thù nửa phép Elensys cho người mới vào
		- CASE
			WHEN empl.StartedDate BETWEEN @NgayDauNam AND @NgayHienTai  /*AND empl.TernimationDate < @NgayHienTai*/
					THEN CASE
							WHEN DAY(empl.StartedDate) BETWEEN 1 AND 10 THEN 0
							WHEN DAY(empl.StartedDate) BETWEEN 11 AND 20 THEN 0.5 
							ELSE 1
						END 					 
			ELSE 0 END		
		AS PhepNamDuocHuong

		,CASE WHEN @NgayHienTai>=hdct.NgayKyHDChinhThuc THEN ISNULL(dvr.DaysRemain,0) ELSE 0 end AS PhepNamTon		
		
		,ISNULL(pndanghi.TongPhepNamDaNghi,0)+ISNULL(erl.HourLeave,0) AS TongPhepNamDaNghi
		
		--Số ngày phép cho cả thử việc, dùng trong trường hợp cuối năm tính phép tồn để chuyển sang năm sau
		--,DATEDIFF(MONTH
		--			,CASE WHEN StartedDate<=@NgayDauNam THEN @NgayDauNam ELSE StartedDate END
		--			,CASE WHEN empl.TernimationDate_PhepNam IS NULL OR empl.TernimationDate_PhepNam>@NgayHienTai THEN @NgayHienTai ELSE empl.TernimationDate_PhepNam END
		--			)+1			
		 		
		----+ROUND(ISNULL(nndh.SoNgayLamNNDH,0)/365.0*2,0)
		--+
		--- CASE
		--	WHEN empl.StartedDate BETWEEN @NgayDauNam AND @NgayHienTai /*AND empl.TernimationDate < @NgayHienTai*/
		--			THEN CASE
		--					WHEN day(empl.StartedDate) between 1 and 10 then 0
		--					WHEN day(empl.StartedDate) between 11 and 20 THEN 0.5 
		--					ELSE 1
		--				END
							
		--	ELSE 0
		--END	 as PhepNamDuocHuongDenHienTai_ChuaLamTron
			
		--Số ngày phép dùng để đăng ký nghỉ phép
		,CASE
			WHEN @NgayChot<hdct.NgayKyHDChinhThuc THEN 0
			ELSE DATEDIFF(MONTH
							,CASE WHEN StartedDate<=@NgayDauNam THEN @NgayDauNam ELSE StartedDate END
							,CASE WHEN empl.TernimationDate_PhepNam IS NULL or empl.TernimationDate_PhepNam>@NgayHienTai THEN @NgayHienTai ELSE empl.TernimationDate_PhepNam END
						)+1
		end
		+CASE 
			WHEN empl.NamThamNien >= 5 AND empl.NamThamNien <6 AND MONTH(@NgayHienTai)>=MONTH(empl.StartedDate) THEN 1
			WHEN empl.NamThamNien >= 6 THEN FLOOR(ISNULL(empl.NamThamNien,0)/5.0)
			ELSE 0
		end
		---trừ bớt phép nếu thử việc trong năm
		- CASE
			WHEN @NgayChot<hdct.NgayKyHDChinhThuc THEN 0
			WHEN empl.StartedDate BETWEEN @NgayDauNam AND @NgayHienTai
					THEN CASE
							WHEN day(empl.StartedDate) between 1 and 10 then 0
							WHEN day(empl.StartedDate) between 11 and 20 THEN 0.5 
							ELSE 1
						END
							
			ELSE 0
		END	

		---trừ trường hợp nghỉ việc sau 15 nhưng ko đủ công
		- CASE
			WHEN empl.TernimationDate_PhepNam BETWEEN @NgayDauThang AND @NgayCuoiThang
					AND isnull(cong.ngay,0)+ISNULL(pntt.TongHL,0)+ISNULL(pntt.TongTS,0) < 12 THEN 1
			ELSE 0
		end
        
		as PhepNamDuocHuongDenHienTai
								

		,CASE 
			WHEN empl.NamThamNien >= 5 AND empl.NamThamNien <6 AND MONTH(empl.OfficialDate)=MONTH(@NgayHienTai) THEN 1
			WHEN empl.NamThamNien >= 6 THEN FLOOR(ISNULL(empl.NamThamNien,0)/5.0)
			ELSE 0
		end as PhepNamThamNienTinhDenCuoiNam
		--,isnull(nndh.SoPhepNamNNDH,0) as PhepNamNNDHTinhDenCuoiNam
		,ISNULL(DaysAdjust,0) as DaysAdjust
		,ISNULL(erl.HourLeave,0) AS PendingLeave
	from
	@empl empl
	left join
	@tabPhepDaNghiTheoNgay pndanghi
	on empl.Employee_ID=pndanghi.Employee_ID
	LEFT JOIN
    @cong cong
	ON cong.Employee_ID=empl.Employee_ID
	LEFT JOIN
	dbo.udf_BangTongPhepNamDNghKoPhep(@NgayDauThang,@NgayCuoiThang,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) pntt
	ON empl.Employee_ID=pntt.Employee_ID
	left JOIN
	HR_DayVacationRemain dvr
	on empl.Employee_ID=dvr.Employee_ID and dvr.[Year]=@year-1
	LEFT JOIN
    (
		SELECT Employee_ID, SUM([dbo].[udf_CountWorkingDay](Fromdate,ToDate)*(CASE WHEN LeaveType_ID IN ('31','32') THEN 0.5 ELSE 1 END)) AS HourLeave
		FROM dbo.HR_EmployeeLeaveRequests
		WHERE Fromdate BETWEEN @NgayDauNam AND @NgayCuoiNam
		AND LeaveType_ID IN ('11','31','32')
		AND TrangThai='Pending'
		GROUP BY Employee_ID
	) erl
	ON empl.Employee_ID=erl.Employee_ID
	left join
	[dbo].[udf_PhepNangNhocDocHai](@NgayDauNam,@NgayCuoiNam,@fact,@dept,@sect,@team,@pos,@posc,@emp) nndh
	on empl.Employee_ID=nndh.Employee_ID
	left join
	[dbo].[udf_NgayKyHDChinhThuc](@NgayDauNam,@NgayCuoiNam,@emp) hdct
	on empl.Employee_ID=hdct.Employee_ID
	left join
	(
		SELECT Employee_ID,SUM(DaysAdjust) as DaysAdjust
		FROM [dbo].[HR_DayAdjustAnnual] 
		WHERE [Year]=@year and Months<=Month(@NgayHienTai)
		GROUP by Employee_ID,DaysAdjust
	) ad
	on empl.Employee_ID=ad.Employee_ID 
	where empl.StartedDate<=@NgayCuoiNam and (empl.TernimationDate is null or empl.TernimationDate>@NgayDauNam)
	AND empl.Employee_ID NOT LIKE '6%' AND empl.Employee_ID NOT LIKE '9%'
	--------------------------
	

	--UPDATE @rtnQuanLyPhepNam 
	--SET PhepNamDuocHuongDenHienTai=
	--	CASE 
	--		WHEN Employee_ID IN (SELECT Employee_ID FROM dbo.SmartBooks_Employee WHERE TernimationDate < @NgayHienTai )
	--				THEN ROUND(PhepNamDuocHuongDenHienTai,1) + ISNULL(PhepNamTon,0)
	--		ELSE ROUND(PhepNamDuocHuongDenHienTai,1) + PhepNamTon
	--	END         
		

	--Kết thúc làm tròn elensys
	-- Return the result of the function
	RETURN
END


GO
