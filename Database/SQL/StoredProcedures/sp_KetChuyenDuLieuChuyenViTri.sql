CREATE proc [dbo].[sp_KetChuyenDuLieuChuyenViTri]
@fromdate datetime,
@todate datetime
as
begin
	--exec sp_KetChuyenDuLieuChuyenViTri '2015-01-01', '2025-12-31'
	delete tf
	from
	HR_Transfer tf
	left join
	HR_SNK.dbo.SmartBooks_PositionMovement pm
	on tf.Employee_ID collate Vietnamese_CI_AS = pm.Employee_ID and tf.EffectiveDate = pm.EffectiveDate and pm.ChucDanh is not null
	where tf.TypeOfTransfer = N'ChucDanh' and tf.EffectiveDate between @fromdate and @todate and pm.Employee_ID is not null
	
	delete tf
	from
	HR_Transfer tf
	left join
	HR_SNK.dbo.SmartBooks_Employee pm
	on tf.Employee_ID collate Vietnamese_CI_AS = pm.Employee_ID and tf.EffectiveDate = pm.InsertDate and pm.Position_ID is not null
	where tf.TypeOfTransfer = N'ChucDanh' and tf.EffectiveDate between @fromdate and @todate and pm.Employee_ID is not null

	delete tf
	from
	HR_Transfer tf
	left join
	HR_SNK.dbo.SmartBooks_PositionMovement pm
	on tf.Employee_ID collate Vietnamese_CI_AS = pm.Employee_ID and tf.EffectiveDate = pm.EffectiveDate and pm.DepartmentCode is not null
	where tf.TypeOfTransfer = N'Position' and tf.EffectiveDate between @fromdate and @todate and pm.Employee_ID is not null

	delete tf
	from
	HR_Transfer tf
	left join
	HR_SNK.dbo.SmartBooks_Employee pm
	on tf.Employee_ID collate Vietnamese_CI_AS = pm.Employee_ID and tf.EffectiveDate = pm.InsertDate and (isnull(pm.DepartmentCode,'') + (case when pm.SectionCode is null then '' else '_' + pm.SectionCode end) + case when pm.PositionCategory_ID is null then '' else '_' + pm.PositionCategory_ID end) is not null
	where tf.TypeOfTransfer = N'Position' and tf.EffectiveDate between @fromdate and @todate and pm.Employee_ID is not null

	insert into HR_Transfer (Employee_ID, TransferCode, EffectiveDate, TypeOfTransfer, AssignType, Remark, InsertDate, UserName)
	select Employee_ID, LTrim(Rtrim(isnull(ChucDanh, Position_ID))) as TransferCode, EffectiveDate, 'Chucdanh' as TypeOfTransfer, 'TRF' as AssignType, Remark, InsertDate, UserName
	from
	(
		select *, ROW_NUMBER () over (Partition by Employee_ID, EffectiveDate order by Employee_ID, EffectiveDate) as rn
		from
		HR_SNK.dbo.SmartBooks_PositionMovement
		where EffectiveDate between @fromdate and @todate and ChucDanh is not null
	) sn
	where sn.rn = 1
	--union all
	--select Employee_ID, Position_ID as TransferCode, InsertDate as EffectiveDate, 'ChucDanh' as TypeOfTransfer, 'TRF' as AssignType, 'BangTTNV' as Remark, InsertDate, UserName
	--from
	--HR_SNK.dbo.SmartBooks_Employee
	--where Position_ID is not null
	
	insert into HR_Transfer (Employee_ID, TransferCode, EffectiveDate, TypeOfTransfer, AssignType, Remark, InsertDate, UserName)
	select Employee_ID, LTrim(Rtrim(DepartmentCode)) 
						+ case when SectionCode is not null then '_' + LTrim(Rtrim(SectionCode)) else '' end 
						+ case when PositionCategory_ID is not null then '_' + LTrim(Rtrim(PositionCategory_ID)) else '' end as TransferCode, 
						EffectiveDate, 'Position' as TypeOfTransfer, 'TRF' as AssignType, Remark, InsertDate, UserName
	from
	(
		select *, ROW_NUMBER () over (Partition by Employee_ID, EffectiveDate order by Employee_ID, EffectiveDate) as rn
		from
		HR_SNK.dbo.SmartBooks_PositionMovement
		where EffectiveDate between @fromdate and @todate and DepartmentCode is not null
	) sn
	where sn.rn = 1
	--union all
	--select Employee_ID, isnull(DepartmentCode,'') + (case when SectionCode is null then '' else '_' + SectionCode end) + case when PositionCategory_ID is null then '' else '_' + PositionCategory_ID end as TransferCode
	--		, InsertDate as EffectiveDate, 'Position' as TypeOfTransfer
	--		, 'TRF' as AssignType, 'BangTTNV' as Remark, InsertDate, UserName
	--from
	--HR_SNK.dbo.SmartBooks_Employee
	--where DepartmentCode is not null

	--update HR_Transfer
	--set TransferCode = REPLACE(TransferCode, 'Factory H', 'SK2')
	--where TransferCode like N'Factory H%' and EffectiveDate between @fromdate and @todate
end
GO
