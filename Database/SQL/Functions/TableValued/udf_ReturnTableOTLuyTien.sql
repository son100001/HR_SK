CREATE FUNCTION [dbo].[udf_ReturnTableOTLuyTien]
--select * from [dbo].[udf_ReturnTableOTLuyTien](GETDATE())
(
	-- Add the parameters for the function here
	@Ngay datetime
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
	Employee_ID [nvarchar](50) NOT NULL,
	OTLuyTien [float] NOT NULL
)
AS
BEGIN
	-- Declare the return variable here
	declare @NgayDauNam datetime
	set @NgayDauNam=cast(DATEPART(YEAR,@Ngay) as varchar)+'-1-1'
	insert into @rtnTable (Employee_ID,OTLuyTien)
	select wt.Employee_ID,SUM(wt)as OTLuyTien from
		HR_WTDaily wt
		left join
		HR_LoaiCong lc
		on wt.MaCong=lc.MaCong
		where ngay between @NgayDauNam and @Ngay and isnull(lc.isWorkingTime,0)=0 and InsertSource <> 'TCLT' and InsertSource not like 'Alt%'
		group by Employee_ID
	
	RETURN
END
--select * from udf_ReturnTableSetupHourTimeKeeping('51-Shift1','2019-4-30',0)
--select * from HR_Shifts where ShiftName='41-Shift1'




GO
