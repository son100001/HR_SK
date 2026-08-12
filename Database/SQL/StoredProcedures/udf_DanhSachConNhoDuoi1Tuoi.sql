
--EXEC [dbo].[udf_DanhSachConNhoDuoi1Tuoi] '2025-9-1','2025-9-30'

CREATE PROCEDURE [dbo].[udf_DanhSachConNhoDuoi1Tuoi]
(
	@fromdate DATETIME,
	@todate DATETIME
) 
AS
BEGIN 

	SELECT
		ef.[Employee_ID],[StartedDate],[TernimationDate]
		,empl.Factory_ID,empl.[DepartmentCode]		
		,[SectionCode],empl.[TeamCode]
		,empl.[Position_ID],[PositionCategory_ID]
		,empl.ChucDanh
		,empl.isTrucTiep
		,empl.Factory_ID +','+empl.Position_ID+','+CASE WHEN empl.isTrucTiep=1 THEN N'Trực tiếp' ELSE N'Gián tiếp' END AS DepGroup		
		
		,dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) AS FullName
		,ef.BirthDate
		,DATEADD(DAY,1,ef.BirthDate) AS BirthDateIns
		,DATEADD(YEAR,1,ef.BirthDate)+1 AS SinhNhat1Tuoi
		,DATEADD(YEAR,1,ef.BirthDate) AS ChildAllowanceEnd_1Year
		,DATEADD(YEAR,6,ef.BirthDate) AS ChildAllowanceEnd
	FROM
	(
		SELECT * 
		FROM [dbo].[SmartBooks_Employee_Family]
		WHERE RelatedType=6
		AND BirthDate <= @todate AND DATEADD(YEAR,1,BirthDate) >= @fromdate
	) AS ef
	LEFT JOIN
	dbo.udf_EmployeeFilter('VN',NULL,NULL,NULL,NULL,NULL,NULL,NULL,@todate) empl
	ON ef.Employee_ID COLLATE DATABASE_DEFAULT = empl.Employee_ID
	LEFT JOIN 
	dbo.HR_EmployeeRegisMaternityLeave erml
	ON ef.Employee_ID=erml.Employee_ID AND erml.LeaveType_ID=24 AND erml.Fromdate<=@todate AND erml.ToDate>=@fromdate
	WHERE 
	empl.StartedDate <= @todate		
	AND (TernimationDate IS NULL OR (TernimationDate > @fromdate AND TernimationDate > ef.[BirthDate]))
	AND empl.Sex = 'Female'
	AND erml.Employee_ID IS NULL	
	ORDER BY DepGroup

END

GO
