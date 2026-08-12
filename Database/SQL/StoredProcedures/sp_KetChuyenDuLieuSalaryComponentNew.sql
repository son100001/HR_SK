--Delete HR_SalaryComponent
--where fromdate <= '2020-01-01'
--exec sp_KetChuyenDuLieuSalaryComponent '2010-01-01','2018-02-28'
--exec sp_KetChuyenDuLieuSalaryComponent '2018-04-01','2023-09-30'
--exec sp_KetChuyenDuLieuSalaryComponentNew '2010-11-01','2026-04-30'
CREATE procedure [dbo].[sp_KetChuyenDuLieuSalaryComponentNew]
@fromdate datetime,
@todate datetime
as
begin

	delete sc
	from
	HR_SalaryComponent sc
	where ((fromdate between @fromdate and @todate) or (isnull(Todate,@todate+1) between @fromdate and @todate)) --and SalaryComponent in ('PCTN', 'PCDT', 'PCT', 'PCK', 'TKD','PCTT', 'LBH', 'LCB')

	--Insert into HR_KIDO_35.dbo.HR_SalaryComponent(Employee_ID, Fromdate, Todate, Amount, SalaryComponent, UserName) --1
	--select Employee_ID, fromdate, todate, Amount, 'PCTN'
	--from   HR_PREX.dbo.HR_PhuCapCoDinh_Chitiet sc
	--where ((fromdate between @fromdate and @todate) or (isnull(Todate,@todate+1) between @fromdate and @todate)) and Allowance_Code = 1

	Insert into HR_SnK_Dev.dbo.HR_SalaryComponent(Employee_ID, SalaryComponent, Amount, Fromdate, Todate, InsertSource, Remark, InsertDate, UserName) --2
	select Employee_ID, SalaryComponent, Amount, Fromdate, Todate, 'KetChuyen', Remark, InsertDate, UserName
	from   
	HR_SNK.dbo.HR_SalaryComponent
	where fromdate between @fromdate and @todate

	delete sc
	from
	HR_SalaryComponentFollowMonth sc
	where DATEFROMPARTS(Year_,Month_,1) between @fromdate and @todate

	Insert into HR_SnK_Dev.dbo.HR_SalaryComponentFollowMonth (Employee_ID, SalaryComponent, Amount, Year_, Month_, Remark, InsertDate, UserName)
	select Employee_ID, SalaryComponent, Amount, Year_, Month_, Remark, InsertDate, UserName
	from
	HR_SNK.dbo.HR_SalaryComponentFollowMonth
	where DATEFROMPARTS(Year_,Month_,1) between @fromdate and @todate and Month_ <= 12

	Update HR_SnK_Dev.dbo.HR_SalaryComponent
	set SalaryComponent = case SalaryComponent when 'A1LCB' then 'LCB'
												when 'A2PCTN' then 'TN'
												when 'A7PCDH' then 'PCNNDH'
												when 'A51PCCD' then 'PCCD'
												when 'A5PCDT' then 'PCDT'
												when 'A3PCXXNT' then 'TCXX'
												when 'A9PCABC' then 'TCABC'
												when 'A8PCPCCC' then 'PCCC'
												when 'A4PCCC' then 'TCC'
												else SalaryComponent end

	update HR_SnK_Dev.dbo.HR_SalaryComponentFollowMonth
	set SalaryComponent = case SalaryComponent when 'A9PCABC' then 'ABC'
												when 'B5PCNX' then 'TNS'
												when 'B1TCTN' then 'NTBHTN'
												when 'B14BONUS' then 'Thang13'
												when 'B12KDP' then 'TDP'
												else SalaryComponent end

	Delete HR_SalaryComponent
	where SalaryComponent in ('B4KBHNLD','A90PCXN')
			and Fromdate between @fromdate and @todate
end


GO
