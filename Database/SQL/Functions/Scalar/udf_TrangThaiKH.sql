-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[udf_TrangThaiKH] 
(
	-- Add the parameters for the function here
	@UserName nvarchar(50)
)
RETURNS nvarchar(100)
AS
BEGIN
	-- Declare the return variable here
	/*
	DECLARE @AllFromDate datetime,@AllToDate datetime,@UserFromDate datetime,@UserToDate datetime,@NgayHienTai datetime
	set @NgayHienTai=FORMAT(getdate(),'yyyy-MM-dd')
	-- Add the T-SQL statements to compute the return value here
	select @AllFromDate=LEFT(Value,10),@AllToDate=RIGHT(Value,10) from setup where id='KH'
	select @UserFromDate=LEFT(Value,10),@UserToDate=RIGHT(Value,10) from setup where id=@UserName

	-- Return the result of the function
	RETURN case when @NgayHienTai between @AllFromDate and @AllToDate or @NgayHienTai between @UserFromDate and @UserToDate then 1 else 0 end
	*/
	Declare @AllValue nvarchar(100), @UserValue nvarchar(100)
	select @UserValue = [Value] from Setup where ID = @UserName
	select @AllValue = [Value]from Setup where ID = 'KH'
	return isnull(@UserValue,@AllValue)
END

GO
