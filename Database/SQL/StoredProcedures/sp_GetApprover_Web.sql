
CREATE PROCEDURE [dbo].[sp_GetApprover_Web]
    @Account nvarchar(50),
    @TypeOfReport int,
    @LAN nvarchar(50) = N'VN',
    @Date datetime = null,
    @RequestType nvarchar(50) = N'RequestLeave'
AS
BEGIN
    SET NOCOUNT ON;

    SET @RequestType = ISNULL(NULLIF(LTRIM(RTRIM(@RequestType)), N''), N'RequestLeave');

    SELECT *
    FROM HR_GetApprover
    WHERE Employee_ID = @Account
      AND RequestType = @RequestType;
END

GO
