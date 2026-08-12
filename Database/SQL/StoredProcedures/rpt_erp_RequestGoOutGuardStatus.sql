CREATE PROCEDURE [dbo].[rpt_erp_RequestGoOutGuardStatus]
(
    @UserName nvarchar(500),
    @error_code INT = NULL OUTPUT,
    @error_message nvarchar(max) = NULL OUTPUT
)
AS
BEGIN
    BEGIN TRY
        SELECT COUNT(1) AS CountDepending
        FROM HR_GoOut
        WHERE GioVaoThucTe IS NULL;
    END TRY
    BEGIN CATCH
        SET @error_message = ERROR_MESSAGE();
        SET @error_code = ERROR_NUMBER();
    END CATCH;
END;

GO
