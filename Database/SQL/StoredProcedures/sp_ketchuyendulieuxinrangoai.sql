--exec sp_ketchuyendulieuxinrangoai '2026-06-01','2026-08-31'
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
		   erml.Employee_ID
		   ,erml.Fromdate
		   ,erml.fromtime
		   ,erml.totime
		   ,'Private'
		   ,null
		   ,erml.InsertDate
		   ,'Auto'
		   from
		   HR_SNK.[dbo].HR_EmployeeRegisMaternityLeave erml
		   left join
		   HR_GoOut gt
		   on erml.Employee_ID collate SQL_Latin1_General_CP1_CI_AS = gt.Employee_ID and erml.Fromdate = gt.TimeDate
		   where (Fromdate between @fromdate and @todate ) and Fromdate = Todate and [Type] in ('P','P16') --and HourLeave < 8
					and ToTime is not null and FromTime is not null and gt.Employee_ID is null
	
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
