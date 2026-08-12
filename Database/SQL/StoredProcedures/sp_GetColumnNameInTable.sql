
CREATE PROCEDURE [dbo].[sp_GetColumnNameInTable] 
	-- Add the parameters for the stored procedure here
	--exec [dbo].[sp_GetColumnNameInTable] 'SmartBooks_Employee'
	--exec [dbo].[sp_GetAllInformationInTable] 'SmartBooks_Employee'
	@TableName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select tableInf.COLUMN_NAME from
	INFORMATION_SCHEMA.COLUMNS tableInf
	left join
	(SELECT * FROM sys.identity_columns WHERE OBJECT_NAME(object_id) = @TableName)iden 
	on tableInf.COLUMN_NAME=iden.name
	left join
	(
		SELECT i.name AS IndexName, OBJECT_NAME(ic.OBJECT_ID) AS TableName, 
		COL_NAME(ic.OBJECT_ID,ic.column_id) AS ColumnName
		FROM sys.indexes AS i
		INNER JOIN sys.index_columns AS ic
		ON i.OBJECT_ID = ic.OBJECT_ID
		AND i.index_id = ic.index_id
		WHERE i.is_primary_key = 1
	)Pri
	on tableInf.COLUMN_NAME=pri.ColumnName and tableInf.TABLE_NAME=pri.TableName
	WHERE TABLE_NAME=@TableName
	order by tableInf.ORDINAL_POSITION
END




GO
