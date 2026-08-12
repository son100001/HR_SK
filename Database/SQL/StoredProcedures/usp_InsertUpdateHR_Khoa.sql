
CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_Khoa]
	-- Add the parameters for the stored procedure here
	@ID [int],
	@TableName [nvarchar](50),
	@Block_Date [datetime],
	@Block_User [nvarchar](50),
	@Status [bit],
	@Remark [nvarchar](500),
	@InsertDate [datetime],
	@UserName [nvarchar](50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if exists(select * from HR_Khoa where (tablename=@TableName and Block_User=@Block_User) or ID=ISNULL(@ID,0))begin
		update HR_Khoa set TableName=@TableName,Block_Date=@Block_Date,Block_User=@Block_User,[Status]=@Status,Remark=@Remark,InsertDate=GETDATE(),UserName=@UserName
		where (tablename=@TableName and Block_User=@Block_User) or ID=ISNULL(@ID,0)
	end else begin
		insert into HR_Khoa (TableName,block_date,Block_User,[status],Remark,InsertDate,UserName)
		values(@TableName,@block_date,@Block_User,@status,@Remark,GETDATE(),@UserName)
	end
END




GO
