/*
  Resolve notify channel flags for one approval step in a flow.
  @StepOrder: specific step; NULL = aggregate across matching rules
  @IsNotifyOnly: NULL = any rule; 0 = approval steps; 1 = notify-only steps
  Returns one row; defaults 1,1,1 when no rule matches (backward compatible).
*/
CREATE FUNCTION [dbo].[udf_ApprovalNotifyChannels_Web]
(
    @RequestType nvarchar(50),
    @FlowCode nvarchar(50),
    @StepOrder int = NULL,
    @IsNotifyOnly bit = NULL
)
RETURNS @Channels TABLE (
    NotifyViaWeb bit NOT NULL,
    NotifyViaEmail bit NOT NULL,
    NotifyViaZalo bit NOT NULL
)
AS
BEGIN
    DECLARE @Req nvarchar(50) = ISNULL(NULLIF(LTRIM(RTRIM(@RequestType)), N''), N'RequestLeave');
    DECLARE @Flow nvarchar(50) = NULLIF(LTRIM(RTRIM(@FlowCode)), N'');

    IF @Flow IS NULL
    BEGIN
        INSERT INTO @Channels VALUES (1, 1, 1);
        RETURN;
    END

    IF @StepOrder IS NOT NULL
    BEGIN
        INSERT INTO @Channels (NotifyViaWeb, NotifyViaEmail, NotifyViaZalo)
        SELECT TOP 1
            CAST(ISNULL(r.NotifyViaWeb, 1) AS bit),
            CAST(ISNULL(r.NotifyViaEmail, 1) AS bit),
            CAST(ISNULL(r.NotifyViaZalo, 1) AS bit)
        FROM HR_ApprovalFlow f
        INNER JOIN HR_ApprovalStep st
            ON st.FlowID = f.FlowID
           AND st.IsActive = 1
        INNER JOIN HR_ApprovalRule r
            ON r.StepID = st.StepID
           AND r.IsActive = 1
        WHERE f.RequestType = @Req
          AND f.FlowCode = @Flow
          AND f.IsActive = 1
          AND st.StepOrder = @StepOrder
          AND (@IsNotifyOnly IS NULL OR r.IsNotifyOnly = @IsNotifyOnly)
        ORDER BY r.Priority, r.RuleID;
    END
    ELSE
    BEGIN
        -- MAX() on empty set returns NULL; ISNULL keeps default 1,1,1 when no rule matches
        INSERT INTO @Channels (NotifyViaWeb, NotifyViaEmail, NotifyViaZalo)
        SELECT
            CAST(ISNULL(MAX(CAST(ISNULL(r.NotifyViaWeb, 1) AS int)), 1) AS bit),
            CAST(ISNULL(MAX(CAST(ISNULL(r.NotifyViaEmail, 1) AS int)), 1) AS bit),
            CAST(ISNULL(MAX(CAST(ISNULL(r.NotifyViaZalo, 1) AS int)), 1) AS bit)
        FROM HR_ApprovalFlow f
        INNER JOIN HR_ApprovalStep st
            ON st.FlowID = f.FlowID
           AND st.IsActive = 1
        INNER JOIN HR_ApprovalRule r
            ON r.StepID = st.StepID
           AND r.IsActive = 1
        WHERE f.RequestType = @Req
          AND f.FlowCode = @Flow
          AND f.IsActive = 1
          AND (@IsNotifyOnly IS NULL OR r.IsNotifyOnly = @IsNotifyOnly);
    END

    IF NOT EXISTS (SELECT 1 FROM @Channels)
        INSERT INTO @Channels VALUES (1, 1, 1);

    RETURN;
END

GO
