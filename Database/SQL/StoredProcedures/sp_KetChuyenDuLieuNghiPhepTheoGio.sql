-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec sp_KetChuyenDuLieuNghiPhepTheoGio '2026-04-01', '2026-04-30'
CREATE PROCEDURE [dbo].[sp_KetChuyenDuLieuNghiPhepTheoGio]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Declare @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan int
	select @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan=[Value] from [dbo].[SetUp] where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'

    -- Insert statements for procedure here
	BEGIN TRY
    BEGIN TRANSACTION
	--kết chuyển dữ liệu nhân viên
		delete HR_DangKyPhepTheoGio where (DateLeave between @fromdate and @todate ) and UserName = 'Auto'
		INSERT INTO HR_DangKyPhepTheoGio
           ([Employee_ID]
		 ,DateLeave
		 ,TypeOfLeave
		 ,HourLeave
		 ,LeaveType_ID
		 ,Remark
		 ,InsertDate
		 ,UserName
		   )
     select 
           Employee_ID
		   ,DateLeave
		   ,'Rasom'
			,HourLeave
			,LeaveType_ID
			,null
			,InsertDate
			,'Auto'
		from  HR_SNK.[dbo].HR_EmpRegisLeave where (DateLeave between @fromdate and @todate ) and LeaveType_ID <> 'P15' --and HourLeave < 8
		
		INSERT INTO HR_DangKyPhepTheoGio
           ([Employee_ID]
		 ,DateLeave
		 ,TypeOfLeave
		 ,HourLeave
		 ,LeaveType_ID
		 ,Remark
		 ,InsertDate
		 ,UserName
		   )
     select 
           erml.Employee_ID
		   ,erml.Fromdate
		   ,'Rasom'
			,8
			,erml.[Type]
			,null
			,erml.InsertDate
			,'Auto'
		from  
		HR_SNK.[dbo].HR_EmployeeRegisMaternityLeave erml
		left join
		HR_DangKyPhepTheoGio dkptg
		on erml.Employee_ID COLLATE SQL_Latin1_General_CP1_CI_AS = dkptg.Employee_ID and erml.Fromdate = dkptg.DateLeave
		where (Fromdate between @fromdate and @todate ) and [Type] <> 'P15' and Fromdate = ToDate --and HourLeave < 8
				and dkptg.LeaveType_ID is null
		
		update erml
		set LeaveType_ID = lt.LeaveType_ID
		from
		HR_DangKyPhepTheoGio erml
		left join
		SmartBooks_LeaveType lt
		on erml.LeaveType_ID = lt.AbsentSign
		where lt.AbsentSign is not null and erml.UserName = 'Auto'

		update erml
		set HourLeave = HourLeave + 1
		from
		HR_DangKyPhepTheoGio erml
		left join
		udf_DanhSachHuongCheDo (@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan) dshcd
		on erml.Employee_ID = dshcd.Employee_ID and (erml.DateLeave between dshcd.babyFromdate and dshcd.babyTodate or erml.DateLeave between dshcd.pregFromdate and dshcd.pregTodate)
		where erml.DateLeave between @fromdate and @todate and erml.LeaveType_ID = '67' and erml.HourLeave < 7 and dshcd.Employee_ID is not null and erml.UserName = 'Auto'
	
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

	--delete HR_DangKyPhepTheoGio
	--where LeaveType_ID in ('P01','P01TS') and HourLeave = 4

END

GO
