-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec [dbo].[sp_XuLyCongGioNeuLamDuGioCongTieuChuan] '2017-11-1','2017-11-12','','','','','','','20140003'
CREATE PROCEDURE [dbo].[sp_XuLyCongGioNeuLamDuGioCongTieuChuan] 
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@UserName nvarchar(50)=null,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Emp nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into SmartBooks_TimeKeeping_Date (WorkingDay,Employee_ID,WokingTime,MaCong,Remark,UserName,InsertDate)
	select WorkingDay,Employee_ID,(case when WokingTime>=GioTieuChuan then DuGioTieuChuanDuocCong else null end),td.MaCong,N'CongGioKhiDuGioTieuChuan',@UserName,GETDATE() from 
	SmartBooks_TimeKeeping_Date td
	left join
	HR_SetupHourTimeKeeping sht
	on td.SlotCode=sht.SlotCode
	where sht.[DuGioTieuChuanDuocCong]>0
		and Employee_ID in (select Employee_ID from udf_Smartbooks_EmployeeFilter('',@fact,@dept,@sect,@team,@pos,@posc) where (case when @Emp is null or @Emp='' then '' else Employee_ID end)=(case when @Emp is null or @Emp='' then '' else @Emp end)
)
END




GO
