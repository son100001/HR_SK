
CREATE PROCEDURE [dbo].[sp_QuyetToanThueTNCNTheoNam]
	-- Add the parameters for the stored procedure here
	--exec sp_QuyetToanThueTNCNTheoNam 2018,'2018-1-1','2018-12-31',2
	@Year int,
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,--1:toàn bộ nhân viên,2:thông tin nhân viên trong giao diện chuyển vị trí
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @TypeOfReport=1 begin
		IF OBJECT_ID('tempdb..#SmartBooks_Salary') IS NOT NULL DROP TABLE #SmartBooks_Salary
		select Employee_ID,s23,s25,s26,s34 into #SmartBooks_Salary from SmartBooks_Salary where Salary_Year=@year

		SELECT empl.MaSoThue,empl.ID_number,(isnull(empl.Employee_Firstname,'')+ (case when empl.Employee_LastName is null then '' else ' '+empl.Employee_LastName end)) as FullName
			,ss.ThuNhapChiuThue,ss.BaoHiemDuocTru,ss.ThuNhapTinhThue,ss.ThueTNCNDaKhauTru
			,ef.NumberOfDepend,GiamTruGiaCanh.TongSoTienGiamTruGiaCanh
		from
		SmartBooks_Employee empl
		left join
		(
			select Employee_ID,sum(isnull(s23,0)) as ThuNhapChiuThue
				,sum(isnull(s25,0)) as BaoHiemDuocTru
				,sum(isnull(s34,0)) as ThuNhapTinhThue
				,sum(isnull(s26,0)) as ThueTNCNDaKhauTru
			from
			#SmartBooks_Salary ss
			group by Employee_ID
		) ss
		on empl.Employee_ID=ss.Employee_ID
		left join
		(
			select Employee_ID, count(Employee_ID) as NumberOfDepend from SmartBooks_Employee_Family
			where isDepend=1 and DATEPART(YEAR,DependFromMonth)=@Year and (DATEPART(YEAR,DependToMonth)>=@Year or DependToMonth is null)
			group by Employee_ID
		)ef
		on empl.Employee_ID=ef.Employee_ID
		left join
		(
			select Employee_ID
				,sum(
						(case when DATEPART(YEAR,DependFromMonth)<@Year
							then (case when DependToMonth is null or DATEPART(year,DependToMonth)>@Year then 3600000*12 else 3600000*(DATEPART(MONTH,DependToMonth)) end)
							else (13-DATEPART(MONTH,DependFromMonth))*3600000
						end)
					)as TongSoTienGiamTruGiaCanh
			from SmartBooks_Employee_Family
			where isDepend=1 and DATEPART(YEAR,DependFromMonth)=@Year and (DATEPART(YEAR,DependToMonth)>=@Year or DependToMonth is null)
			group by Employee_ID
		)as GiamTruGiaCanh
		on empl.Employee_ID=GiamTruGiaCanh.Employee_ID
		where
		DATEPART(YEAR,empl.StartedDate)<=@Year and (empl.TernimationDate is null or DATEPART(YEAR,empl.TernimationDate)>@Year)
		and (case when @dept is null or @dept='' then '' else DepartmentCode end)=(case when @dept is null or @dept='' then '' else @dept end)
		and (case when @sect is null or @sect='' then '' else SectionCode end)=(case when @sect is null or @sect='' then '' else @sect end)
		and (case when @team is null or @team='' then '' else TeamCode end)=(case when @team is null or @team='' then '' else @team end)
		and (case when @pos is null or @pos='' then '' else Position_ID end)=(case when @pos is null or @pos='' then '' else @pos end)
		and (case when @posc is null or @posc='' then '' else PositionCategory_ID end)=(case when @posc is null or @posc='' then '' else @posc end)
	end else if @TypeOfReport=2 begin-- Tổng hợp các thành phần PIT theo năm chi tiết theo tháng
		set @fromdate=DATEADD(day,1-datepart(day,@fromdate),@fromdate)
		set @todate=DATEADD(month,1,DATEADD(day,1-datepart(day,@todate),@todate))-1
		declare @Salary varchar(50),@SQL nvarchar(max),@dNext datetime
		IF OBJECT_ID('tempdb..#tab') IS NOT NULL DROP TABLE #tab
		create table #tab
		(
			Employee_ID nvarchar(50)
		)
		insert into #tab
		--select cast(cast(Salary_Year as varchar(4))+'-'+cast(Salary_Month as varchar(2))+'-1' as datetime) as abc from SmartBooks_Salary
		select distinct Employee_ID from SmartBooks_Salary where cast(cast(Salary_Year as varchar(4))+'-'+cast(Salary_Month as varchar(2))+'-1' as datetime) between @fromdate and @todate
		DECLARE cur CURSOR LOCAL FOR
		select Salary from SmartBooks_Salary_Name where PIT=1
		OPEN  cur
		FETCH NEXT FROM cur INTO @Salary
		WHILE @@FETCH_STATUS = 0
		BEGIN
			set @dNext=@fromdate
			while @dNext<=@todate begin
				set @SQL='ALTER TABLE #tab ADD '+@Salary+cast(DATEPART(MONTH,@dNext) as varchar(2))+cast(DATEPART(YEAR,@dNext) as varchar(4))+' float '
				exec (@SQL)
				set @SQL='update #tab set #tab.'+@Salary+cast(DATEPART(MONTH,@dNext) as varchar(2))+cast(DATEPART(YEAR,@dNext) as varchar(4))+'=ss.'+@Salary
							+' from #tab t left join (select Employee_ID, sum(isnull('+@Salary+',0)) as '+@Salary+' from SmartBooks_Salary where Salary_Month='+cast(DATEPART(MONTH,@dNext) as varchar(2))+' and Salary_Year='+cast(DATEPART(YEAR,@dNext) as varchar(4))+' group by Employee_ID) ss on t.Employee_ID COLLATE DATABASE_DEFAULT=ss.Employee_ID'
				exec (@SQL)
				set @dNext=DATEADD(MONTH,1,@dNext)
			end
		FETCH NEXT FROM cur INTO @Salary
		END
		CLOSE cur
		DEALLOCATE cur
		select empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.StartedDate,empl.Employee_Status,empl.TernimationDate,t.*
		from
		#tab t
		left join
		SmartBooks_Employee empl
		on t.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
	end
	
END




GO
