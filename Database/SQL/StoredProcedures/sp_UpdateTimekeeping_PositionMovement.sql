-- sp_UpdateTimekeeping_PositionMovement '2016/05/01','2016/05/01'
-- =============================================  
-- Author:  Hieu Nguyen 
-- Create date: Update Timekeeping PositionMovement
-- Description: Mot so nguoi chuyen bo phan nhung khong thay doi luong nen khong tach cong, can update lai 
-- =============================================  
CREATE PROCEDURE [dbo].[sp_UpdateTimekeeping_PositionMovement]  
 @Fromdate  datetime,  
 @ToDate  datetime 
AS  
BEGIN  
		update HR_BangCongTheoNgay
		set isNewPosition=0
		where Employee_ID not in
		(
			select Employee_ID from dbo.udf_ListPositionMovement( @fromdate, @todate)
		)
END




GO
