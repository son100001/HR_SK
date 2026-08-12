
--exec sp_ApproveLeaveRequest 61
CREATE PROCEDURE [dbo].[rpt_camketbaomat] 
	@TypeOfReport int = 5,
	@LAN nvarchar(50)=null,
	@ListOfKey nvarchar(50)=null
AS
BEGIN
	select *,SUBSTRING(empl.Employee_ID, 2, LEN(empl.Employee_ID)) + '/HĐTV S&K' AS EmpDisplayCKBM,
	([dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName)) as fullnameemployee,
	    (
        SELECT TOP 1 dbo.udf_FullName(emplbod.Employee_Firstname, emplbod.Employee_LastName)
        FROM SmartBooks_Employee emplbod
		where emplbod.Employee_ID='BOD01') AS fullnameemployeer,
		(
        SELECT TOP 1 UPPER(dbo.udf_FullName(emplbod1.Employee_Firstname, emplbod1.Employee_LastName))
        FROM SmartBooks_Employee emplbod1
		where emplbod1.Employee_ID='BOD01') AS UPPERfullnameemployeer
	From SmartBooks_Employee empl
	CROSS JOIN SmartBooks_Company
	where empl.Employee_ID in(select Data from Split(@ListOfKey,','))
END

GO
