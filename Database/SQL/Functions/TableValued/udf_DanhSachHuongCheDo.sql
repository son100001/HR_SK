CREATE FUNCTION [dbo].[udf_DanhSachHuongCheDo]
(
	@fromdate datetime,
	@todate datetime,
	@SoNgaySauKhiMangBauDuocHuongThaiSan float
)
RETURNS  @rtnDanhSachHuongCheDo TABLE 
(
	--select * from udf_DanhSachHuongCheDo ('2024-04-01','2024-04-30',182) where Employee_id = 'M01604'
    -- columns returned by the function
	Employee_ID nvarchar(50)
	,pregFromdate datetime
	,pregTodate datetime
	,babyFromdate datetime
	,babyTodate datetime
	,DisableFromDate datetime
	,DisableToDate datetime
	,OldFromdate datetime
	,OldTodate datetime
	,Duoi18Fromdate datetime
	,Duoi18Todate datetime
	,primary key (Employee_ID)
)
AS
BEGIN
	-- Declare the return variable here
	select @SoNgaySauKhiMangBauDuocHuongThaiSan=Value from setup where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
	insert into @rtnDanhSachHuongCheDo
	select distinct 
	empl.[Employee_ID],
		 erp.[Fromdate] as pregFromdate,erp.ToDate as pregTodate
		 ,baby.Fromdate as babyFromdate
		 ,baby.ToDate as babyTodate
		 ,(case when d.Employee_ID is not null then d.Fromdate else null end) as DisableFromDate,(case when d.Employee_ID is not null then isnull(d.Todate,@todate) else null end) as DisableToDate
		--,(case when empl.Sex = N'Female' then (case when DATEADD(YEAR,54,empl.BirthDate)<@todate then DATEADD(YEAR,54,empl.BirthDate) else null end)
		--	else (case when DATEADD(YEAR,59,empl.BirthDate)<@todate then DATEADD(YEAR,59,empl.BirthDate) else null end) end) as OldFromdate
		,null as OldFromdate
		--,(case when (empl.Sex = N'Female' and DATEADD(YEAR,54,empl.BirthDate)<@todate) or (empl.Sex = N'Male' and DATEADD(YEAR,59,empl.BirthDate)<@todate) then @todate else null end) as OldTodate
		,null as OldTodate
		,null as Duoi18Fromdate--(case when DATEADD(YEAR,18,empl.BirthDate)>@fromdate and empl.StartedDate<DATEADD(YEAR,18,empl.BirthDate) then empl.StartedDate else null end) Duoi18Fromdate
		,null as Duoi18Todate--(case when DATEADD(YEAR,18,empl.BirthDate)>@fromdate and empl.StartedDate<DATEADD(YEAR,18,empl.BirthDate) then DATEADD(YEAR,18,empl.BirthDate)-1 else null end) Duoi18Todate
	from
	dbo.SmartBooks_Employee empl
	left join
	(select [Employee_ID], isnull(cast(Remark as datetime),DATEADD(DAY, @SoNgaySauKhiMangBauDuocHuongThaiSan, Fromdate)) as Fromdate,(case when MiscarriageDate is null then ToDate else MiscarriageDate end) as [ToDate], N'Thai sản' as [Content] from [dbo].[HR_EmployeeRegisPregnant] where DATEADD(DAY,@SoNgaySauKhiMangBauDuocHuongThaiSan, Fromdate) <= @todate and [ToDate] >= @fromdate) as erp
	on empl.Employee_ID = erp.Employee_ID
	left join
	(
		select baby.Employee_ID, baby.[BirthDate] as Fromdate, dateadd(month,11+NumberOfBaby,baby.[BirthDate]) as ToDate, N'Con nhỏ' as [Content]
		from
		(select distinct [Employee_ID], [BirthDate] from [dbo].[SmartBooks_Employee_Family] where RelatedType in ('6','7') and dateadd(year,1,BirthDate) >= @fromdate and BirthDate <= @todate) baby
		left join
		(select Employee_ID, count(Employee_ID) as NumberOfBaby from SmartBooks_Employee_Family where RelatedType in ('6','7') and dateadd(year,1,BirthDate) >= @fromdate and BirthDate <= @todate group by Employee_ID) NumberOfBaby
		on baby.Employee_ID = NumberOfBaby.Employee_ID
		left join
		SmartBooks_Employee empl
		on baby.Employee_ID = empl.Employee_ID
		where empl.Sex = 'Female' and empl.StartedDate < baby.BirthDate
	) baby
	on empl.Employee_ID COLLATE DATABASE_DEFAULT = baby.Employee_ID
	left join
	HR_Disable d
	on empl.Employee_ID=d.Employee_ID and d.PhanTram>=51 and d.Fromdate<=@todate and (d.Todate is null or d.Todate>=@fromdate)

	where empl.StartedDate <= @todate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate) 
		and empl.Employee_ID not like N'BV%'
		and 
		(
			(
				empl.Sex = N'Female'
				and (erp.Content = N'Thai sản' or baby.Content = N'Con nhỏ')
			)
			/*or d.Employee_ID is not null
			--or (empl.Sex = N'Female' and DATEADD(YEAR,54,empl.BirthDate)<@todate)
			--or (empl.Sex = N'Male' and DATEADD(YEAR,59,empl.BirthDate)<@todate)
			or (DATEADD(YEAR,18,empl.BirthDate)>@fromdate)*/
		)

	RETURN
END


GO
