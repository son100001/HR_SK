
create proc [dbo].[sp_BangDiseasesRecord]
@fromdate datetime,
@todate datetime,
@TypeOfReport int = 1,
@LAN nvarchar(50)='VN',
@UserName nvarchar(50)=null,
@fact nvarchar(50)=null,
@dept nvarchar(50)=null,
@sect nvarchar(50)=null,
@team nvarchar(50)=null,
@pos nvarchar(50)=null,
@posc nvarchar(50)=null,
@emp nvarchar(MAX)=null

As
Begin
	--exec sp_BangDiseasesRecord '2021-1-7','2021-7-31',3,'VN',null,null,null,null,null,null,null,'YDC001'
	if @TypeOfReport = 1 begin
		select dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName, dr.*
		from
		HR_DiseasesRecord dr
		left join
		SmartBooks_Employee empl
		on dr.Employee_ID = empl.Employee_ID
		where dr.MedicalExaminationDay between @Fromdate and @Todate and (case when @emp is null or @emp = '' then '' else empl.Employee_ID end) in (case when  @emp is null or @emp = '' then '' else (select data from Split(@emp,',')) end)
	end else if @TypeOfReport in (2,3) begin
		--select dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName, dr.*
		--from
		--(
		--	select dr.Employee_ID, dr.MedicalExaminationDay, case when dr.TypeOfDiseases = 1 then dr.DetailOfDiseases else '' end as 'Liver Enzymes'
		--	from HR_DiseasesRecord dr
		--	group by dr.Employee_ID, dr.MedicalExaminationDay, dr.TypeOfDiseases, dr.DetailOfDiseases
		--) dr
		--left join
		--SmartBooks_Employee empl
		--on dr.Employee_ID = empl.Employee_ID

		--IF OBJECT_ID('tempdb..#tabDiseasesRecord') IS NOT NULL DROP TABLE #tabDiseasesRecord
		-- TẠO DANH MỤC PIVOT
		
		declare @DynamicPivotQuery nvarchar(Max), @TypeOfDiseases nvarchar(MAX)
		--Get name of Type of diseases
		set @TypeOfDiseases=''
		select @TypeOfDiseases=@TypeOfDiseases + Category + ',' from HR_Category where CategoryFather = 'TypeOfDiseases'
		set @TypeOfDiseases=left(@TypeOfDiseases,len(@TypeOfDiseases)-1)

		IF OBJECT_ID('tempdb..#tabDiseasesRecord') IS NOT NULL DROP TABLE #tabDiseasesRecord
		select dr.MedicalExaminationDay as [Period],empl.PositionFullName
				,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
				,dr.MedicalExaminationDay,dr.TypeOfDiseases, dr.DetailOfDiseases
				into #tabDiseasesRecord
			from
			HR_DiseasesRecord dr
			left join
			udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,getdate())) empl
			on dr.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
			left join
			(
				select * from HR_Category cate where cate.CategoryFather = 'TypeOfDiseases'
			) cate
			on dr.TypeOfDiseases COLLATE DATABASE_DEFAULT=cate.Category
			where (case when @emp is null or @emp = '' then '' else empl.Employee_ID end) in (case when  @emp is null or @emp = '' then '' else (select data from Split(@emp,',')) end)

		-- TẠO QUERY PIVOT
		if @TypeOfReport = 2 begin
			SET @DynamicPivotQuery = 'select * from #tabDiseasesRecord ' + N' PIVOT ( Max(DetailOfDiseases) FOR TypeOfDiseases IN ('+ @TypeOfDiseases +')) AS pv'
		end else if @TypeOfReport = 3 begin
			SET @DynamicPivotQuery = 'select MedicalExaminationDay, ' + @TypeOfDiseases + ' from #tabDiseasesRecord ' + N' PIVOT ( Max(DetailOfDiseases) FOR TypeOfDiseases IN ('+ @TypeOfDiseases +')) AS pv'
		end
		exec (@DynamicPivotQuery)
	end
end
--exec sp_BangDiseasesRecord '2021-1-7','2021-7-31',2
GO
