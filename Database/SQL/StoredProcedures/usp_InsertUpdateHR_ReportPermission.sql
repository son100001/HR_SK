
CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_ReportPermission]
	@User_ nvarchar(50),
	@ReportCode varchar(50),
	@Remark nvarchar(256),
	@UserName nvarchar(50),
	@InsertDate datetime
AS

SET NOCOUNT ON

IF NOT EXISTS(SELECT ReportCode FROM HR_ReportPermission WHERE ReportCode=@ReportCode and User_=@User_)
BEGIN
	INSERT INTO [dbo].[HR_ReportPermission] (
		User_,
		ReportCode,
		Remark,
		UserName,
		InsertDate
	) VALUES (
		@User_,
		@ReportCode,
		@Remark,
		@UserName,
		@InsertDate
	)
END



--select * From HR_ReportPermission




GO
