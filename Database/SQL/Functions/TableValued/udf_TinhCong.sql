CREATE FUNCTION [dbo].[udf_TinhCong]
(
	-- Add the parameters for the function here
	-- select * from [dbo].[udf_TinhCong]('2026-06-01','2026-06-30',181,null,null,null,null,null,null,'')

	@fromdate datetime,
	@todate datetime,
	@SoNgaySauKhiMangBauDuocHuongThaiSan int,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Employee_ID_ nvarchar(50)=null
)
RETURNS  @rtnTinhCong TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),[AccessDate] datetime,[TimeDate] datetime,AccessTime datetime,InOutStatus varchar(10),[ShiftName] nvarchar(50),maxovertime float,isActualOT_After bit
		,maxovertimeB float,maxovertimeHol float,maxovertimeLunch float,[CheDo] int,HolSunTypeOfOT varchar(20), ChoPhepMuonSoPhut int,primary key ([Employee_ID],[AccessTime])
)
AS
BEGIN
	WITH EmployeeShifts AS (
        SELECT 
            e.Employee_ID,
            e.AccessDate,
            e.ShiftName,
            e.GioTCTruoc,
            e.CheDo,
            s.FromTime,
            s.ToTime,
            s.ChanDau,
            s.ChanCuoi,
			e.FactoryName,
			e.DepartmentName,
			e.SectionName,
			e.isManager
        FROM 
            [dbo].[udf_DangKyCa](@fromdate, @todate, @SoNgaySauKhiMangBauDuocHuongThaiSan, 
                               @fact, @dept, @sect, @team, @pos, @posc, @Employee_ID_) e
        LEFT JOIN 
            [dbo].[HR_Shifts] s ON e.ShiftName = s.ShiftName
    ),
    TimeCalculations AS (
        SELECT
            es.*,
            [dbo].[GhepGioVaoNgay](es.AccessDate, 
                DATEADD(MINUTE, -ISNULL(es.ChanDau,0)*60-ISNULL(motB.maxovertime,ISNULL(es.GioTCTruoc,0))*60, 
                es.FromTime)) AS TimeStart,
            DATEADD(MINUTE,
                (CASE WHEN ISNULL(motA.maxovertime,0)=0 THEN ISNULL(es.ChanCuoi,0)*60 
                      ELSE motA.maxovertime*60+240 END),
                [dbo].[GhepGioVaoNgay](
                    (CASE WHEN DATEPART(HOUR, es.FromTime) < DATEPART(HOUR, es.ToTime) 
                          THEN es.AccessDate ELSE es.AccessDate+1 END), 
                    es.ToTime)) AS TimeEnd
        FROM 
            EmployeeShifts es
        LEFT JOIN 
            [dbo].[HR_MaxOvertime] motA ON es.AccessDate = motA.workingdate 
                                      AND es.Employee_ID = motA.Employee_id 
                                      AND motA.[TypeOfOT] = '1'
        LEFT JOIN 
            [dbo].[HR_MaxOvertime] motB ON es.AccessDate = motB.workingdate 
                                      AND es.Employee_ID = motB.Employee_id 
                                      AND motB.[TypeOfOT] = '2'
    )

	insert into @rtnTinhCong
    SELECT 
        tc.Employee_ID,
        tc.AccessDate,
        tc.AccessDate AS TimeDate,
        tkd.AccessTime,
        tkd.InOutStatus,
        tc.ShiftName,
        ISNULL(isnull(isnull(motA.maxovertime,erpS.Remark), case when tc.isManager = 1 and datename(weekday,tc.AccessDate) <> 'Sunday' then 0 else null end), 10) AS maxovertime,
        motA.isActualOT AS isActualOT_After,
        ISNULL(motB.maxovertime, 
               CASE WHEN erp.ParameterValue = 'CaTuan' THEN erp.remark
					when erp.ParameterValue in ('T24','T246') and datename(dw,tc.AccessDate) in ('Monday','Wednesday') then erp.Remark
					when erp.ParameterValue in ('T246') and datename(dw,tc.AccessDate) in ('Friday') then erp.Remark
                    ELSE ISNULL(tc.GioTCTruoc,0) END) AS maxovertimeB,
        ISNULL(motHol.maxovertime,0) AS maxovertimeHol,
        case when tc.ShiftName = '30-Shift3' then 0 else isnull(motLunch.maxovertime,0) end as maxovertimeLunch,
        tc.CheDo,
        motHol.TypeOfOT AS HolSunTypeOfOT,
		isnull(erpDM.Remark,dep.JobCode) as ChoPhepMuonSoPhut
    FROM 
        TimeCalculations tc
    LEFT JOIN 
        [dbo].[DuLieuQuet](@fromdate, @todate+1) tkd ON tc.Employee_ID = tkd.Employee_ID
                                                   AND tkd.AccessTime BETWEEN tc.TimeStart AND tc.TimeEnd
    LEFT JOIN 
        [dbo].[HR_MaxOvertime] motA ON tc.AccessDate = motA.workingdate 
                                   AND tc.Employee_ID = motA.Employee_id 
                                   AND motA.[TypeOfOT] = '1'
    LEFT JOIN 
        [dbo].[HR_MaxOvertime] motB ON tc.AccessDate = motB.workingdate 
                                   AND tc.Employee_ID = motB.Employee_id 
                                   AND motB.[TypeOfOT] = '2'
    LEFT JOIN 
        [dbo].[HR_MaxOvertime] motHol ON tc.AccessDate = motHol.workingdate 
                                     AND tc.Employee_ID = motHol.Employee_id 
                                     AND motHol.[TypeOfOT] IN ('4','5')
    LEFT JOIN 
        [dbo].[HR_MaxOvertime] motLunch ON tc.AccessDate = motLunch.workingdate 
                                       AND tc.Employee_ID = motLunch.Employee_id 
                                       AND motLunch.[TypeOfOT] = '3'
    LEFT JOIN 
        [dbo].[SmartBooks_HolidaysPlan] hp ON tc.AccessDate = hp.H_date 
                                          AND hp.TypeOfLeave = '50'
    LEFT JOIN 
        [dbo].[HR_EmpRegisParameter] erp ON tc.Employee_ID = erp.Employee_ID 
                                        AND erp.Parameter = 'TCTruoc'
                                        AND tc.AccessDate BETWEEN erp.Fromdate AND erp.Todate
    LEFT JOIN 
        [dbo].[HR_EmpRegisParameter] erpS ON tc.Employee_ID = erpS.Employee_ID 
                                        AND erpS.Parameter = 'TCSau'
                                        AND tc.AccessDate BETWEEN erpS.Fromdate AND erpS.Todate
	Left join
		SmartBooks_Department dep on tc.FactoryName = dep.Factory_ID and tc.DepartmentName = dep.DepartmentCode
		
	left join
		HR_EmpRegisParameter erpDM on tc.Employee_ID = erpDM.Employee_ID 
										and tc.AccessDate between erpDM.Fromdate and erpDM.Todate 
										and erpDM.Parameter = 'DiMuon' and erpDM.ParameterValue = 'DiMuonSoPhut'

    WHERE 
        tkd.AccessTime IS NOT NULL

	-- Return the result of the function
	RETURN
END



GO
