CREATE PROCEDURE [dbo].[sp_BangUser]
--exec sp_BangUser 'Trang'
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	WITH #results
	AS (SELECT ID,FatherUser,UserName,[Password],FullName,GroupID,QuyenTruyXuat,InsertDate,InsertBy
		FROM dbo.[User]
		WHERE UserName = @UserName
		UNION ALL
		SELECT t.ID,t.FatherUser,t.UserName,t.[Password],t.FullName,t.GroupID,t.QuyenTruyXuat,t.InsertDate,t.InsertBy
		FROM dbo.[User] t
			INNER JOIN #results r
				ON t.FatherUser COLLATE DATABASE_DEFAULT= r.UserName)
	SELECT *
	FROM #results
	ORDER BY UserName;
END




GO
