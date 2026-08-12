








-- =============================================  
-- Author:  Nguyen Tran Hieu 
-- ALTER  date: 11/04/2014  
-- Description: Timekeeping_Daily
-- =============================================  

--sp_Timekeeping_Daily '03/01/2014','03/31/2014',''
CREATE   PROCEDURE [dbo].[AGiang_select_HolidaysPlan_ByH_date]
@H_date as datetime               

AS    

Select * from SmartBooks_HolidaysPlan where H_date = @H_date
  












GO
