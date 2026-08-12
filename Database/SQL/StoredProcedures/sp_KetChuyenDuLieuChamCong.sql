
--exec sp_KetChuyenDuLieuChamCong '2026-04-01', '2026-04-30'
CREATE PROCEDURE [dbo].[sp_KetChuyenDuLieuChamCong]
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
		delete HR_TimeKeeping_Data
		where AccessDate between @fromdate and @todate and InsertSource <> 'NhapTay' and UserName = 'Auto'
		INSERT INTO HR_TimeKeeping_Data
		(
		Employee_ID
		,AccessDate
		,AccessTime
		,Device_ID
		,CardNumber
		,DeviceIP
		,InOutStatus
		,InsertSource
		,Reason
		,Remark
		,UserName
		,InsertDate
		 )
     select distinct
	 sktd.Employee_ID
	 ,sktd.AccessDate
	 ,sktd.AccessTime
	 ,null
	 ,isnull(sktd.CardNumber,sktd.Employee_ID)
	 ,null
	 ,null
	 ,isnull(sktd.InsertSource,'')
	 ,null
	 ,sktd.Remark
	 ,'Auto'
	 ,null
		from HR_SNK.[dbo].HR_TimeKeeping_Data sktd
		left join
		HR_TimeKeeping_Data td
		on sktd.Employee_ID collate SQL_Latin1_General_CP1_CI_AS = td.Employee_ID and sktd.AccessDate = td.AccessDate and sktd.AccessTime = td.AccessTime
		where sktd.AccessDate between @fromdate and @todate and td.Employee_ID is null

	exec sp_XoaDuLieuQuetTheTrung @fromdate, @todate
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
