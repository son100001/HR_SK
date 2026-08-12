--select * from [dbo].[udf_MucLuongCuaCongNhanVien]('2020-7-1','HT000056')
CREATE FUNCTION [dbo].[udf_MucLuongCuaCongNhanVien]
(
	-- Add the parameters for the function here
	@Ngay datetime,
	@emp nvarchar(50)
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),SalaryGroup varchar(50),SalaryStep varchar(50),MucLuong float,primary key ([Employee_ID])
)
AS
BEGIN
	insert into @rtnTable
	select NhomBacLuong.Employee_ID,NhomBacLuong.SalaryGroup,NhomBacLuong.SalaryStep,ml.Amount from
	(
		select empl.Employee_ID, isnull(mlnv.SalaryGroup,isnull(pc.SalaryGroup,1)) as SalaryGroup,isnull(mlnv.SalaryStep,1) as SalaryStep from
		 SmartBooks_Employee empl
		 left join
		  [dbo].[udf_TraVeBangTransfer_Horizontal](@Ngay,@emp) vt
		  on empl.Employee_ID=vt.Employee_ID
		left join
		SmartBooks_PositionCategory pc
		on empl.PositionCategory_ID=pc.PositionCategory_ID
		left join
		(
			select mlnv.* from
			(select Employee_ID,max(FromDate) as FromDate from HR_MucLuongNhanVien where FromDate<=@Ngay and (ToDate is null or todate>=@Ngay) group by Employee_ID) mucluongmax
			left join
			HR_MucLuongNhanVien mlnv
			on mucluongmax.Employee_ID=mlnv.Employee_ID and mucluongmax.FromDate=mlnv.FromDate 
		) mlnv
		on empl.Employee_ID=mlnv.Employee_ID 
		where empl.StartedDate<=@Ngay and (empl.TernimationDate is null or empl.TernimationDate>DATEFROMPARTS(datepart(year,@Ngay),datepart(month,@ngay),1))
			and (case when @emp is null or @emp='' then '' else empl.Employee_ID end)=(case when @emp is null or @emp='' then '' else @emp end)
	)as NhomBacLuong
	left join
	(
		select mucluong.* from
		(select SalaryGroup,SalaryStep,max(FromDate) as FromDate from HR_MucLuong where FromDate<=@Ngay and (ToDate is null or todate>=@Ngay) group by SalaryGroup,SalaryStep) mucluongmax
		left join
		HR_MucLuong mucluong
		on mucluongmax.SalaryGroup=mucluong.SalaryGroup and mucluongmax.SalaryStep=mucluong.SalaryStep and mucluongmax.FromDate=mucluong.FromDate
	)ml
	on NhomBacLuong.SalaryGroup=ml.SalaryGroup and NhomBacLuong.SalaryStep=ml.SalaryStep
	
	-- Return the result of the function
	RETURN

END




GO
