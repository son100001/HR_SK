-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[udf_TraVeLoaiNgayCong]
(
	--select dbo.[udf_TraVeLoaiNgayCong] ('SS220613','2024-11-03')
	-- Add the parameters for the function here
	@Employee_ID nvarchar(50),
	@WorkingDate datetime
)
RETURNS varchar(10)
AS
BEGIN
	-- Declare the return variable here
	declare @LoaiCong varchar(10),@Thu7DuocNghi datetime, @Department nvarchar(50), @Factory_ID nvarchar(50)
	select @Department = DepartmentCode from udf_EmployeeFilter ('VN',null,null,null,null,null,null,@Employee_ID,GETDATE())
	select @Factory_ID = Factory_ID from udf_EmployeeFilter ('VN',null,null,null,null,null,null,@Employee_ID,GETDATE())

	--select @Thu7DuocNghi = [Value] from Setup where FunctionID = 'Thu7DuocNghi' and ID = 'T7DN'
	select @LoaiCong=ParameterValue from HR_EmpRegisParameter where Employee_ID=@Employee_ID and @WorkingDate between Fromdate and Todate and Parameter = 'NgayCongDacBiet'
	if @LoaiCong is null begin
		set @LoaiCong='Nor'
		if (DATENAME(dw,@workingdate)='Sunday' and @Department not like 'Production_Soi%' /*and isnull(@Factory_ID,'') <> 'Office'*/) or datediff(day,@Thu7DuocNghi,@workingdate) % 14 = 0 or exists(select H_date from SmartBooks_HolidaysPlan where H_date=@WorkingDate and TypeOfLeave='99') begin
			set @LoaiCong='Sun'
		end
		if exists(select H_date from SmartBooks_HolidaysPlan where H_date=@WorkingDate and TypeOfLeave='50') begin
			set @LoaiCong='Hol'
		end
		if exists(select LeaveType_ID from HR_BangPhepDaNghi where DateLeave=@WorkingDate and LeaveType_ID='53' and Employee_ID = @Employee_ID) begin
			set @LoaiCong='Sun'
		end
		if exists(select * from HR_SetUpFollowDate where Group_='Cong' and Code in ('Nor','Hol','Sun','Normal','Holiday','Sunday') and @WorkingDate between Fromdate and Todate) begin
			select @LoaiCong = Code from HR_SetUpFollowDate where Group_='Cong' and Code in ('Nor','Hol','Sun','Normal','Holiday','Sunday') and @WorkingDate between Fromdate and Todate
		end
	end
	-- Add the T-SQL statements to compute the return value here
	

	-- Return the result of the function
	RETURN @loaicong

END

GO
