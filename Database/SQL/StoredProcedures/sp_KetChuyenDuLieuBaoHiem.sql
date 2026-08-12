
--exec sp_KetChuyenDuLieuBaoHiem '2010-01-01','2025-05-30'
create PROCEDURE [dbo].[sp_KetChuyenDuLieuBaoHiem]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRY
    BEGIN TRANSACTION
	--kết chuyển dữ liệu nhân viên
		delete HR_Insurance
		--where AccessDate between @fromdate and @todate
		INSERT INTO HR_Insurance
		(
		Employee_ID,
		BookCode
		,Remark
		, InsertDate
		, UserName
		,StartedDate
		 )
     select 
	 Employee_ID
	,BookCode
	,null
	,InsertDate
	,UserName
	,[Start_Date]
		from HR_SNK.[dbo].HR_Insurance
		--where AccessDate between @fromdate and @todate
    COMMIT TRAN -- Transaction Success!
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRAN --RollBack in case of Error

		-- <EDIT>: From SQL2008 on, you must raise error messages as follows:
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  

		SELECT   
		   @ErrorMessage = ERROR_MESSAGE(),  
		   @ErrorSeverity = ERROR_SEVERITY(),  
		   @ErrorState = ERROR_STATE();  

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);  
	
		-- </EDIT>
	END CATCH
END

GO
