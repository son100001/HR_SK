/*
  Resolve approval flow code for one employee (web path only).
  Source: HR_ApprovalFlowJobTitle matched by effective ChucDanh (shared across request types).
  @RequestType is kept for call-site compatibility; scope does not vary by request type.
*/
CREATE FUNCTION [dbo].[udf_ResolveApprovalFlow]
(
    @Employee_ID nvarchar(50),
    @RequestType nvarchar(50),
    @Date datetime
)
RETURNS nvarchar(50)
AS
BEGIN
    DECLARE @FlowCode nvarchar(50);
    DECLARE @Emp nvarchar(50) = NULLIF(LTRIM(RTRIM(@Employee_ID)), N'');

    IF @Emp IS NULL
        RETURN NULL;

    SELECT TOP 1 @FlowCode = jt.FlowCode
    FROM SmartBooks_Employee empl
    LEFT JOIN udf_TraVeBangTransfer_Horizontal(@Date, @Emp) tf
        ON tf.Employee_ID = empl.Employee_ID
    INNER JOIN HR_ApprovalFlowJobTitle jt
        ON jt.ChucDanh = ISNULL(tf.ChucDanh, empl.ChucDanh)
       AND jt.IsActive = 1
    WHERE empl.Employee_ID = @Emp
      AND NULLIF(LTRIM(RTRIM(ISNULL(tf.ChucDanh, empl.ChucDanh))), N'') IS NOT NULL
    ORDER BY jt.ID;

    RETURN NULLIF(LTRIM(RTRIM(@FlowCode)), N'');
END

GO
