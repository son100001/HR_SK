CREATE FUNCTION [dbo].[udf_TraVeBangTransfer_Horizontal]
(
	-- Add the parameters for the function here
	@Date datetime,
	@Empl nvarchar(50)
)
--select * from udf_TraVeBangTransfer_Horizontal (GETDATE(),null)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),Position nvarchar(200),[Position_ID] nvarchar(200),[PositionCategory_ID] nvarchar(200),ChucDanh nvarchar(50),JobCode nvarchar(50),RFID varchar(50) primary key ([Employee_ID])
)
AS
BEGIN
	insert into @rtnTable
	select Employee_ID,Position,Position_ID,PositionCategory_ID,ChucDanh,JobCode,RFID from
	(select tf.Employee_ID,tf.TransferCode,tf.TypeOfTransfer from
	(select Employee_ID,TypeOfTransfer,max(EffectiveDate) as EffectiveDate
		from HR_Transfer
		where EffectiveDate<=@Date and (case when @Empl is null or @Empl='' then '' else Employee_ID end)=(case when @Empl is null or @Empl='' then '' else @Empl end)
				--Đặc thù SK để kết chuyển
					and EffectiveDate > '2026-08-01'
		group by Employee_ID,TypeOfTransfer
	) maxtr
	left join
	HR_Transfer tf
	on maxtr.Employee_ID=tf.Employee_ID and maxtr.EffectiveDate=tf.EffectiveDate and maxtr.TypeOfTransfer=tf.TypeOfTransfer
	)SourceTable
	PIVOT (max(TransferCode) FOR TypeOfTransfer IN (Position,Position_ID,PositionCategory_ID,ChucDanh,JobCode,RFID)) pvTable

	-- Return the result of the function
	RETURN 

END




GO
