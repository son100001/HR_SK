-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_EmpRegisLeave]
	-- Add the parameters for the stored procedure here
	@Employee_ID nvarchar(50),
	@LeaveType_ID nvarchar(50),
	@DateLeave datetime,
	@InsertSource varchar(50),
	@HourLeave float,
	@Remark nvarchar(max),
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	IF ISNULL(@HourLeave,0)=0 or @LeaveType_ID is null--Xử lý @HourLeave=0 hoặc null
	BEGIN
		IF EXISTS(SELECT Employee_ID FROM [dbo].[HR_EmpRegisLeave] WHERE Employee_ID = @Employee_ID and DateLeave=@DateLeave)
		BEGIN
			delete [dbo].[HR_EmpRegisLeave] where Employee_ID = @Employee_ID and DateLeave=@DateLeave
		END
		return
	END ELSE BEGIN
		IF EXISTS(SELECT Employee_ID FROM [dbo].[HR_EmpRegisLeave] WHERE Employee_ID = @Employee_ID and DateLeave=@DateLeave)
		BEGIN
			update [dbo].[HR_EmpRegisLeave] set LeaveType_ID=@LeaveType_ID,HourLeave=@HourLeave,UserName=@UserName,InsertDate=getdate()
			where Employee_ID = @Employee_ID and DateLeave=@DateLeave
		END ELSE BEGIN
			insert into [dbo].[HR_EmpRegisLeave](Employee_ID,LeaveType_ID,DateLeave,InsertSource,HourLeave,Remark,InsertDate,UserName)
			values(@Employee_ID,@LeaveType_ID,@DateLeave,@InsertSource,@HourLeave,@Remark,getdate(),@UserName)
		END
	END
	
END




GO
