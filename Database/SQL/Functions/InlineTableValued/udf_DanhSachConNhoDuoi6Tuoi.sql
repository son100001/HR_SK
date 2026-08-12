CREATE  FUNCTION [dbo].[udf_DanhSachConNhoDuoi6Tuoi]
(
	@date datetime
) 
RETURNS table      
AS                 
RETURN
(
	SELECT
		ef.[Employee_ID]
		,[Employee_Status],[StartedDate],[TernimationDate]		
		,empl.Factory_ID, empl.[DepartmentCode],[SectionCode],empl.[TeamCode]
		,empl.[Position_ID],[PositionCategory_ID]
				
		,dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName
		,(case when empl.Sex = N'Male' then N'Nam' else N'Nữ' end) as SexTranslate
		
		--, round(cast(DATEDIFF(month,ef.[BirthDate],@date) as float)/12,1) as TuoiCon
		,ef.[BirthDate],ef.Remark
		,DATEADD(YEAR,6,ef.BirthDate) AS ChildAllowanceEnd
	from
	(
		SELECT *
		FROM [dbo].[SmartBooks_Employee_Family]
		WHERE RelatedType = 6
		AND [BirthDate]>dateadd(year,-6,@date) and BirthDate <= @date
	) as ef
	LEFT JOIN
	dbo.udf_EmployeeFilter('VN',NULL,NULL,NULL,NULL,NULL,NULL,NULL,@date) empl
	ON ef.Employee_ID COLLATE DATABASE_DEFAULT = empl.Employee_ID
	where 	  
	empl.StartedDate <= @date AND ISNULL(empl.TernimationDate,@date+1) >= @date  
	

)


GO
