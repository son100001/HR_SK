CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_WTDaily_AUDIT]
--exec usp_InsertUpdateHR_WTDaily_Audit N's000087','2019-10-31','wt1','NhapTay','1',null,'2019-11-13 14:29:40',N'admin'
	@Employee_ID nvarchar(50),
	@Ngay datetime,
	@MaCong nvarchar(50),
	@InsertSource varchar(50),
	@wt float,
	@Remark nvarchar(max),
	@InsertDate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON
	--xử lý nếu mã công và giờ công và ngày công trùng với dữ liệu TinhCong thì không xử lý
	IF not EXISTS(SELECT Employee_ID FROM [dbo].[HR_WTDaily] WHERE Employee_ID = @Employee_ID AND MaCong = @MaCong and Ngay=@Ngay and wt=@wt)
		BEGIN
			set @InsertSource='NhapTay'
			IF EXISTS(SELECT Employee_ID FROM [dbo].[HR_WTDaily] WHERE Employee_ID = @Employee_ID AND MaCong = @MaCong and Ngay=@Ngay and InsertSource=@InsertSource)
			BEGIN
				UPDATE [dbo].[HR_WTDaily] SET
					wt=@wt,
					Remark=@Remark,
					InsertDate=GETDATE(),
					UserName=@UserName,
					InsertSource=@InsertSource
				WHERE Employee_ID = @Employee_ID AND MaCong = @MaCong and Ngay=@Ngay and InsertSource=@InsertSource
			END
			ELSE BEGIN
				INSERT INTO [dbo].[HR_WTDaily] (
					[Employee_ID],
					[Ngay],
					[MaCong],
					[wt],
					[InsertSource],
					[Remark],
					[InsertDate],
					[UserName]
				) VALUES (
					@Employee_ID,
					@Ngay,
					@MaCong,
					@wt,
					@InsertSource,
					@Remark,
					GETDATE(),
					@UserName
				)
			END
		END
END




GO
