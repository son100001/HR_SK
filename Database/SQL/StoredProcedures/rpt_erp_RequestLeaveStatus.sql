
create PROCEDURE [dbo].[rpt_erp_RequestLeaveStatus]
(
	@UserName nvarchar(500),
    @error_code INT = NULL OUTPUT,
    @error_message nvarchar(max) = NULL OUTPUT
)
AS
BEGIN
    BEGIN TRY
		select count(Employee_ID) as CountDepending
		from
		HR_EmployeeLeaveRequests
		where ApproveLevel = @UserName and TrangThai = 'Pending'
		group by ApproverName, TrangThai
    END TRY
    BEGIN CATCH
        SET @error_message = ERROR_MESSAGE();
        SET @error_code = ERROR_NUMBER();
    END CATCH;

END;
GO
