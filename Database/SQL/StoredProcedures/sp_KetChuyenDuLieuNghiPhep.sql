-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec sp_KetChuyenDuLieuNghiPhep '1900-06-01', '2026-03-31'
CREATE PROCEDURE [dbo].[sp_KetChuyenDuLieuNghiPhep]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @rtnThaiSan table (Employee_ID nvarchar(50), LeaveType_ID nvarchar(50), Fromdate datetime, Todate datetime, primary key (Employee_ID, Fromdate))
	Declare @NgayDauNam datetime = datefromparts(Year(@todate),1,1)
    -- Insert statements for procedure here
	BEGIN TRY
    BEGIN TRANSACTION
	--kết chuyển dữ liệu nhân viên
		update erml
		set erml.ToDate = isnull(erp.ToDate,erp.NgayDuKienQuayLai)
		from
		HR_EmployeeRegisMaternityLeave erml
		left join
		HR_SNK.[dbo].HR_EmployeeRegisMaternityLeave erp
		on erml.Employee_ID COLLATE SQL_Latin1_General_CP1_CI_AS = erp.Employee_ID and erml.Fromdate = erp.Fromdate and NgayDuKienQuayLai = erml.ToDate
		where (erp.Fromdate between @fromdate and @todate ) or (erp.todate between @fromdate and @todate ) and erp.Employee_ID is not null
				/*and Remark <> 1*/ and erml.UserName = 'Auto'

		delete HR_EmployeeRegisMaternityLeave where (Fromdate between @fromdate and @todate ) or (todate between @fromdate and @todate )
		INSERT INTO HR_EmployeeRegisMaternityLeave
           ([Employee_ID]
		 ,LeaveType_ID
		 ,Fromdate
		 ,ToDate
		 ,Reason
		 ,PlanStatus
		 ,Remark
		 ,InsertDate
		 ,UserName
		 ,isDaNopGiay
		 ,isBlock
		 ,isChoUngPhep
		   )
     select 
           Employee_ID
		  ,[Type]--case when  = 4 and LeaveType_ID in ('P01','P01TS','P23') then '31' else LeaveType_ID end
		   ,Fromdate
		   ,isnull(ToDate,NgayDuKienQuayLai)
		   ,null
			,null
			,null
			,InsertDate
			,'Auto'
			,null
			,null
			,null
		from  HR_SNK.[dbo].HR_EmployeeRegisMaternityLeave erp 
		where (Fromdate between @fromdate and @todate or isnull(Todate,NgayDuKienQuayLai) between @fromdate and @todate) and Fromdate < isnull(ToDate,NgayDuKienQuayLai)
				and fromtime is null --and erp.[Type] in ('P15','P17','P18','P19','P16','P28','P29','P25')
				and Employee_ID COLLATE SQL_Latin1_General_CP1_CI_AS not in (select Employee_ID from HR_EmployeeRegisMaternityLeave where Fromdate between @fromdate and @todate or isnull(Todate,@todate+1) between @fromdate and @todate) --(Phép thai sản)--or (erp.HourLeave = 4 and erp.LeaveType_ID in ('P01','P01TS','P23')))
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

	update erml
	set LeaveType_ID = lt.LeaveType_ID
	from
	HR_EmployeeRegisMaternityLeave erml
	left join
	SmartBooks_LeaveType lt
	on erml.LeaveType_ID = lt.AbsentSign
	where lt.AbsentSign is not null and erml.UserName = 'Auto'
	
	--Xử lý sảy thai
	--update erp
	--set MiscarriageDate = @Fromdate
	--from
	--HR_EmployeeRegisPregnant erp
	--left join
	--HR_EmployeeRegisMaternityLeave erml
	--on erp.Employee_ID = erml.Employee_ID and erp.Fromdate 
	--where @Fromdate between Fromdate and ToDate and Employee_ID = @Employee_ID and @Fromdate between Fromdate and ToDate
	
	
	--Insert dữ liệu vào bảng Thai sản
	--Insert into @rtnThaiSan (Employee_ID, LeaveType_ID, Fromdate)
	--select rnFrom.Employee_ID, '24', rnFrom.Fromdate
	--from
	--(
	--	select Employee_ID, Fromdate, ROW_NUMBER() over (Partition by Employee_ID order by Fromdate) as RowN
	--	from
	--	HR_EmployeeRegisMaternityLeave erml
	--	where LeaveType_ID = '24' and Fromdate between @fromdate and @todate
	--) rnFrom
	--where rnFrom.RowN = 1

	----Update Todate
	--update ts
	--set ts.Todate = rnTo.Todate
	--from
	--@rtnThaiSan ts
	--left join
	--(
	--	select Employee_ID, Todate, ROW_NUMBER() over (Partition by Employee_ID order by Fromdate desc) as RowN
	--	from
	--	HR_EmployeeRegisMaternityLeave erml
	--	where LeaveType_ID = '24' and Fromdate between @fromdate and @todate
	--) rnTo
	--on ts.Employee_ID = rnTo.Employee_ID
	--where rnTo.RowN = 1

	----Xóa dữ liệu TS trùng
	--Delete HR_EmployeeRegisMaternityLeave
	--where Fromdate = ToDate and LeaveType_ID = '24'

	--Insert into HR_EmployeeRegisMaternityLeave (Employee_ID, LeaveType_ID, Fromdate, ToDate)
	--select *
	--from
	--@rtnThaiSan
	
	Declare @NgayDauThang datetime
	set @NgayDauThang = DATEFROMPARTS(Year(@todate),Month(@todate),1)

	exec sp_KetChuyenDuLieuNghiPhepTheoGio @NgayDauThang, @todate

END

GO
