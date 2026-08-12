--exec sp_ketchuyendulieuxinrangoai '2026-04-01','2026-06-30'
CREATE proc [dbo].[sp_ketchuyendulieuxinrangoai]
@fromdate datetime,
@todate datetime
as
begin
	BEGIN TRY
    BEGIN TRANSACTION
		delete HR_GoOut where (TimeDate between @fromdate and @todate ) and UserName = 'Auto'

		INSERT INTO HR_GoOut
		   ([Employee_ID]
		 ,TimeDate
		 ,TimeOut_
		 ,TimeIn
		 ,LeaveType_ID
		 ,Remark
		 ,InsertDate
		 ,UserName
		   )
	 select 
		   Employee_ID
		   ,Fromdate
		   ,fromtime
		   ,totime
		   ,'Private'
		   ,null
		   ,InsertDate
		   ,'Auto'
		   from
		   HR_SNK.[dbo].HR_EmployeeRegisMaternityLeave 
		   where (Fromdate between @fromdate and @todate ) and Fromdate = Todate and [Type] in ('P','P16') --and HourLeave < 8
					and ToTime is not null and FromTime is not null
	
	COMMIT TRAN -- Transaction Success!
	select 'ThucHienThanhCong' as ThongBao
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
end
GO
