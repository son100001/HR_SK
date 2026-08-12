
--select * from [dbo].[udf_PhepNangNhocDocHai]('2022-1-1','2022-12-31',null,null,null,null,null,null,null)
CREATE function [dbo].[udf_PhepNangNhocDocHai]
(
	@fromdate datetime,
	@todate datetime,
	@fact nvarchar(50),
	@dept nvarchar(50),
	@sect nvarchar(50),
	@team nvarchar(50),
	@pos nvarchar(50),
	@posc nvarchar(50),
	@emp nvarchar(50)
)
RETURNS @rtnTongThangLamNangNhocDocHai table (Employee_ID nvarchar(50), SoNgayLamNNDH int,SoPhepNamNNDH float,primary key (Employee_ID))
AS
begin
	declare @Employee_ID nvarchar(50),@OldEmployee_ID nvarchar(50),@EffectiveDate datetime,@OldEffectiveDate datetime,@AnnualLeaveDays float,@OldAnnualLeaveDays float,@TernimationDate datetime,@OldTernimationDate datetime,@SoNgay int
	set @SoNgay=0
	Declare cur Cursor local for
	select tf.Employee_ID,EffectiveDate
	,isnull(t.AnnualLeaveDays,isnull(s.AnnualLeaveDays,isnull(d.AnnualLeaveDays,isnull(f.AnnualLeaveDays,0))))
	,empl.TernimationDate
	from
	HR_Transfer tf
	left join
	SmartBooks_Employee empl
	on tf.Employee_ID=empl.Employee_ID
	left join
	HR_Factory f
	on (case when len(tf.TransferCode)-len(REPLACE(tf.TransferCode,'_',''))=0 then tf.TransferCode else LEFT(tf.TransferCode, CHARINDEX('_', tf.TransferCode)-1) end)=f.Factory_ID
	left join
	SmartBooks_Department d
	on (case when len(tf.TransferCode)-len(REPLACE(tf.TransferCode,'_',''))=0 then null when len(tf.TransferCode)-len(REPLACE(tf.TransferCode,'_',''))=1 then tf.TransferCode else LEFT(tf.TransferCode, CHARINDEX('_',tf.TransferCode,CHARINDEX('_', tf.TransferCode)+1)-1) end)=d.Factory_ID+'_'+d.DepartmentCode
	left join
	SmartBooks_Section s
	on (case when len(tf.TransferCode)-len(REPLACE(tf.TransferCode,'_',''))<=1 then null when len(tf.TransferCode)-len(REPLACE(tf.TransferCode,'_',''))=2 then tf.TransferCode else LEFT(tf.TransferCode, CHARINDEX('_',tf.TransferCode,CHARINDEX('_',tf.TransferCode,CHARINDEX('_',tf.TransferCode,CHARINDEX('_', tf.TransferCode)+1))+1)-1) end)=s.Factory_ID+'_'+s.DepartmentCode+'_'+s.SectionCode
	left join
	SmartBooks_Team t
	on (case when len(tf.TransferCode)-len(REPLACE(tf.TransferCode,'_',''))<=2 then null else tf.TransferCode end)=t.Factory_ID+'_'+t.DepartmentCode+'_'+t.SectionCode+'_'+t.TeamCode
	where EffectiveDate<=@todate and tf.TypeOfTransfer='Position' and empl.StartedDate<=@todate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)
		and (case when @emp is null or @emp='' then '' else empl.Employee_ID end)=(case when @emp is null or @emp='' then '' else @emp end)
	union
	select 'z900000000',null,null,null
	order by Employee_ID,EffectiveDate

	Open cur
	Fetch next from cur into @Employee_ID, @EffectiveDate, @AnnualLeaveDays, @TernimationDate
	While @@FETCH_STATUS = 0
	Begin
		if isnull(@OldEmployee_ID,'')<>@Employee_ID begin
			if @OldAnnualLeaveDays=14 begin
				set @SoNgay=@SoNgay+DATEDIFF(day
											,(case when @OldEffectiveDate<@fromdate then @fromdate else @OldEffectiveDate end)
											,case when @TernimationDate is null then @todate else @TernimationDate-1 end)+1
			end
			if @OldEmployee_ID is not null and @SoNgay>0 begin
				insert into @rtnTongThangLamNangNhocDocHai(Employee_ID,SoNgayLamNNDH,SoPhepNamNNDH) values(@OldEmployee_ID,@SoNgay,case when @SoNgay/30>=9 then 2 when @SoNgay/30>=3 then 1 else 0 end)
			end
			set @SoNgay=0
			set @OldEffectiveDate=null
		end else begin
			if @OldAnnualLeaveDays=14 begin
				set @SoNgay=@SoNgay+DATEDIFF(day
											,(case when @OldEffectiveDate<@fromdate then @fromdate else @OldEffectiveDate end)
											,@EffectiveDate)
			end
		end
		set @OldEmployee_ID=@Employee_ID set @OldEffectiveDate=@EffectiveDate set @OldAnnualLeaveDays=@AnnualLeaveDays set @OldTernimationDate=@TernimationDate
	FETCH NEXT FROM cur into @Employee_ID, @EffectiveDate, @AnnualLeaveDays, @TernimationDate
	END
	CLOSE cur
	DEALLOCATE cur
	return
end
GO
