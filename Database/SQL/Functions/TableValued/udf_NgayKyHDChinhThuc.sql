CREATE FUNCTION [dbo].[udf_NgayKyHDChinhThuc] 
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_NgayKyHDChinhThuc] ('2025-08-01','2025-08-31',null) where Employee_ID='C16704'
	--select * from SmartBooks_Employee where employee_id='21121947'
	@fromdate datetime,
	@todate datetime,
	@Empl nvarchar(50)
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
     [Employee_ID] nvarchar(50),NgayKyHDChinhThuc datetime,primary key ([Employee_ID])
)
AS
BEGIN
 insert into @rtnTable
select empl.Employee_ID
,(case when empl.OfficialDate is not null then empl.OfficialDate
when ct.Contract_ID is null then empl.StartedDate else [dbo].[udf_TraVeNgayHetHanHD](empl.StartedDate,ct.NumberOfDay,ct.NumberOfMonth,ct.NumberOfYear,ct.isOnlyWorkingDay)+1 end) as NgayKyHD
from
SmartBooks_Employee empl
left join
SmartBooks_Contract ct
on empl.[ContractFlow]=ct.Contract_ID and ct.SalaryPercent=85
where (empl.StartedDate<=@todate and (empl.TernimationDate is null or empl.TernimationDate>=@fromdate))
	and (case when @Empl is null or @Empl='' then '' else empl.Employee_ID end)=(case when @Empl is null or @Empl='' then '' else @Empl end)
	-- Return the result of the function
	RETURN
END
GO
