
--exec sp_KetChuyenDuLieuDangKyBaoHiem '2021-11-01', '2025-05-30'
create PROCEDURE [dbo].[sp_KetChuyenDuLieuDangKyBaoHiem]
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
		delete HR_EmpNonRegisInsuranceAndUnion where EOMonth(DATEFROMPARTS(Nam,Thang,1)) between @fromdate and @todate
		--where AccessDate between @fromdate and @todate
		INSERT INTO HR_EmpNonRegisInsuranceAndUnion
		(
		Employee_ID,
		Thang,
		Nam,
		SocialInsurance,
		HealthInsurance,
		UnemploymentInsurance,
		UnionFee,
		Comment,
		UserName,
		InsertDate
		 )
     select 
	 Employee_ID
	,case when len(MonthYear) = 7 then left(MonthYear,2) else left(MonthYear,1) end
	,right(MonthYear,4)
	,SocialInsurance
	,HealthInsurance
	,UnemploymentInsurance
	,UnionFee
	,Comment
	,CreateBy
	,CreateDate
		from HR_SNK.[dbo].HR_EmpNonRegisInsuranceAndUnion
		where EOMonth(DATEFROMPARTS(right(MonthYear,4),case when len(MonthYear) = 7 then left(MonthYear,2) else left(MonthYear,1) end,1)) between @fromdate and @todate
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
