-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BangChuaMaNhanVien]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select tab.ColName,tab.TableName,t.DATA_TYPE
	from
	(
		 SELECT c.name AS ColName, t.name AS TableName
		   FROM sys.columns c
		JOIN sys.tables t ON c.object_id = t.object_id
	)tab
	left join
	(
		SELECT COLUMN_NAME, DATA_TYPE,  TABLE_NAME FROM INFORMATION_SCHEMA.COLUMNS 
	)t
	on tab.ColName=t.COLUMN_NAME and tab.TableName=t.TABLE_NAME
	WHERE tab.ColName = 'Employee_ID' and t.DATA_TYPE='nvarchar'
END




GO
