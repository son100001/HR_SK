
create FUNCTION [dbo].[udf_NgayHetHanHDThuViec] 
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_NgayHetHanHDThuViec] ('2021-3-1','2021-3-31',null)
	@fromdate datetime,
	@todate datetime,
	@Empl nvarchar(50)
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
     [Employee_ID] nvarchar(50),NgayHetHanHDThuViec datetime,primary key ([Employee_ID])
)
AS
BEGIN
 insert into @rtnTable
select empl.Employee_ID
, (case when ct.Contract_ID is null then empl.StartedDate else [dbo].[udf_TraVeNgayHetHanHD](empl.StartedDate,(case when ct.Contract_ID = 'HopDongTraining' then 30 else ct.NumberOfDay end),ct.NumberOfMonth,ct.NumberOfYear,ct.isOnlyWorkingDay) end) as NgayKyHD
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
