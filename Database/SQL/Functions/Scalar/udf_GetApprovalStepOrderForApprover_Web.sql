
/*
  Returns the configured approval step order for an approver in a flow.
  Used when earlier steps have no resolved approver (auto-skip) so ThuTuDuyet
  matches HR_ApprovalStep.StepOrder instead of always defaulting to 1.
*/
CREATE   FUNCTION [dbo].[udf_GetApprovalStepOrderForApprover_Web]
(
    @FlowCode nvarchar(50),
    @RequestType nvarchar(50),
    @ApproverEmployeeId nvarchar(50)
)
RETURNS int
AS
BEGIN
    IF @FlowCode IS NULL OR @ApproverEmployeeId IS NULL
        RETURN 1;

    DECLARE @StepOrder int;

    SELECT TOP 1
        @StepOrder = st.StepOrder
    FROM HR_ApprovalFlow f
    INNER JOIN HR_ApprovalStep st
        ON st.FlowID = f.FlowID
       AND st.IsActive = 1
       AND st.StepType = N'Approval'
    INNER JOIN HR_ApprovalRule r
        ON r.StepID = st.StepID
       AND r.IsActive = 1
    WHERE f.FlowCode = @FlowCode
      AND f.RequestType = @RequestType
      AND f.IsActive = 1
      AND (
            (
                r.ResolveType = N'ByLevelManager'
                AND EXISTS (
                    SELECT 1
                    FROM HR_ApprovalLevelMember lm
                    WHERE lm.LevelCode = NULLIF(LTRIM(RTRIM(r.TargetLevel)), N'')
                      AND lm.IsActive = 1
                      AND lm.Employee_ID = @ApproverEmployeeId
                )
            )
            OR (
                r.ResolveType = N'FixedEmployee'
                AND EXISTS (
                    SELECT 1
                    FROM HR_ApprovalRuleMember rm
                    WHERE rm.RuleID = r.RuleID
                      AND rm.IsActive = 1
                      AND rm.Employee_ID = @ApproverEmployeeId
                )
            )
          )
    ORDER BY st.StepOrder;

    RETURN ISNULL(@StepOrder, 1);
END

GO
