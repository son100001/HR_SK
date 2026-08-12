
--exec sp_KetChuyenDuLieuBankAccount '2005-01-01','2025-05-31'
CREATE PROCEDURE [dbo].[sp_KetChuyenDuLieuBankAccount]
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
		delete HR_BankAccountOfEmployee
		--where AccessDate between @fromdate and @todate
		INSERT INTO HR_BankAccountOfEmployee
		(
		Employee_ID,
		BankAccount
		,BankName
		,isUsing
		,Remark
		,InsertDate
		,UserName
		 )
     select 
	 Employee_ID
	 ,BankAccount
	 ,null
	 ,1
	 ,null
	 ,null
	 ,null
		from HR_SNK.[dbo].SmartBooks_Employee 
		where BankAccount is not null
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
