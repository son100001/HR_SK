
--exec sp_DanhSachConNhoDuoi6Tuoi '2025-9-25'

CREATE PROCEDURE [dbo].[sp_DanhSachConNhoDuoi6Tuoi] 
	@date DATETIME

AS
BEGIN

	DECLARE @q NVARCHAR(4000), @c INT
	SELECT @q = '', @c = 0

	SELECT
		ROW_NUMBER() OVER(PARTITION BY employee_id ORDER BY departmentcode, employee_id, birthdate ASC) AS rc
		,employee_id, fullname
		,departmentcode,Factory_ID
		,[StartedDate],  [BirthDate], ChildAllowanceEnd
		,CAST(NULL AS DATETIME) AS a_c1, CAST(NULL AS DATETIME) AS a_c2, CAST(NULL AS DATETIME) AS a_c3, CAST(NULL AS DATETIME) AS a_c4, CAST(NULL AS DATETIME) AS a_c5
		,CAST(NULL AS DATETIME) AS b_c1, CAST(NULL AS DATETIME) AS b_c2, CAST(NULL AS DATETIME) AS b_c3, CAST(NULL AS DATETIME) AS b_c4, CAST(NULL AS DATETIME) AS b_c5
	INTO #r
	FROM [dbo].[udf_danhsachconnhoduoi6tuoi] (@date) 
	WHERE ISNULL(childallowanceend,'19000101') >= @date
	
	
	SELECT @c = MAX(rc)
	FROM #r

	IF @c > 0 
	BEGIN
		SELECT 
			DISTINCT employee_id
			,fullname, Factory_ID
			,starteddate
			,a_c1, a_c2, a_c3, a_c4, a_c5
			,b_c1, b_c2, b_c3, b_c4, b_c5
			,MAX(rc) AS childs
		INTO #k
		FROM #r
		GROUP BY employee_id, fullname, Factory_ID, starteddate, a_c1, a_c2, a_c3, a_c4, a_c5, b_c1, b_c2, b_c3, b_c4, b_c5
	END

	WHILE @c > 0
	BEGIN
		SELECT @q = 'update #k set a_c' + RTRIM(@c) + ' = b.a_c, b_c' + RTRIM(@c) + ' = b.b_c ' 
		SELECT @q = @q + 'from #k a, (select employee_id, birthdate as a_c, childallowanceend as b_c from #r where rc = ' + RTRIM(@c) + ') b where a.employee_id = b.employee_id'
		EXEC sp_executesql @q
		SELECT @c = @c - 1
	END
	-------------------------

	SELECT * FROM #k ORDER BY Factory_ID, Employee_ID
END	


GO
