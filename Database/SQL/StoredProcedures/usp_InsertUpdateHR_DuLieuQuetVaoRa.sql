-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE usp_InsertUpdateHR_DuLieuQuetVaoRa
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@Ngay datetime,
	@TimeIn datetime,
	@TimeOut datetime,
	@Remark nvarchar(max),
	@InsertDate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if exists(select ID from HR_DuLieuQuetVaoRa where (Employee_ID=@Employee_ID and Ngay=@Ngay) or ID=isnull(@ID,0))
	begin
		update HR_DuLieuQuetVaoRa
		set Employee_ID=@Employee_ID,Ngay=@Ngay,TimeIn=@TimeIn,[TimeOut]=@TimeOut,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
		where (Employee_ID=@Employee_ID and Ngay=@Ngay) or ID=isnull(@ID,0)
	end else begin
		insert into HR_DuLieuQuetVaoRa
		(
			Employee_ID,
			Ngay,
			TimeIn,
			[TimeOut],
			[Remark],
			[InsertDate],
			[UserName]
		)
		values(@Employee_ID,@Ngay,@TimeIn,@TimeOut,@Remark,GETDATE(),@UserName)
	end
END

GO
