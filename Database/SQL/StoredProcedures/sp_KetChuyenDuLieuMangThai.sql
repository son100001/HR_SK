-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec sp_KetChuyenDuLieuMangThai '1900-02-01','2026-03-31'
CREATE PROCEDURE [dbo].[sp_KetChuyenDuLieuMangThai]
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
	--kết chuyển dữ liệu mang thai
		delete HR_EmployeeRegisPregnant where ((Fromdate between @fromdate and @todate ) or (todate between @fromdate and @todate ))  and UserName = 'Auto'
		INSERT INTO HR_EmployeeRegisPregnant
          (Employee_ID
		  , UltraPaper
		  , UltraDate
		  , PregWeeks
		  , PregDays
		  , Fromdate
		  , ToDate
		  , MiscarriageDate
		  , Remark
		  , InsertDate
		  , UserName
		  , Ngaynghitruocsinh
		  , Ngayvaosausinh)
     select 
           Employee_ID
		   ,null
		   ,InsertDate
		   ,null
			,null
			,Fromdate
			,ToDate
			,null
			,null
			,InsertDate
			,'Auto'
		  , Ngaynghitruocsinh
		  , Ngayvaosausinh
		  from
		  (
			select *, ROW_NUMBER () over (partition by Employee_ID, Fromdate order by Employee_ID, fromdate) as rn
			from HR_SNK.[dbo].HR_EmployeeRegisPregnant where (Fromdate between @fromdate and @todate ) or (todate between @fromdate and @todate )
			) erp
			where rn = 1
    COMMIT TRAN -- Transaction Success!
	--select 
	--rs.Employee_ID
	--,s.Employee_Firstname
	--,s.Factory_ID
	--,rs.UltraPaper
	--,rs.UltraDate
	--,rs.PregWeeks
	--,rs.PregDays
	--,rs.Fromdate
	--,rs.ToDate
	--,rs.MiscarriageDate
	--,rs.InsertDate
	--,null--rs.NgayHuongCheDo
	--From HR_EmployeeRegisPregnant rs
	--left join
	--SmartBooks_Employee s
	--on rs.Employee_ID = s.Employee_ID

	update erp
	set erp.MiscarriageDate = isnull(erml.Fromdate,bpdn.DateLeave)
	from
	HR_EmployeeRegisPregnant erp
	left join
	HR_EmployeeRegisMaternityLeave erml
	on erp.Employee_ID = erml.Employee_ID and erml.LeaveType_ID in ('26','39','40','41') and erml.Fromdate between erp.Fromdate and erp.ToDate
	left join
	(
		select bpdn.*, ROW_NUMBER () over(partition by erp.Employee_ID, erp.Fromdate order by DateLeave) as rn
		from
		HR_EmployeeRegisPregnant erp
		left join
		HR_DangKyPhepTheoGio bpdn
		on erp.Employee_ID = bpdn.Employee_ID and bpdn.LeaveType_ID in ('26','39','40','41') and bpdn.DateLeave between erp.Fromdate and erp.ToDate
		where (erp.Fromdate between @fromdate and @todate ) or (erp.todate between @fromdate and @todate )
	) bpdn
	on erp.Employee_ID = bpdn.Employee_ID and bpdn.LeaveType_ID in ('26','39','40','41') and bpdn.DateLeave between erp.Fromdate and erp.ToDate
	where (erp.Fromdate between @fromdate and @todate ) or (erp.todate between @fromdate and @todate ) and isnull(bpdn.rn,1) = 1 and erp.UserName = 'Auto'
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
