-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
--select [dbo].[udf_TraVeTrangThaiPlanKhiDKNghi]('19000010','2019-5-8')
CREATE FUNCTION [dbo].[udf_TraVeTrangThaiPlanKhiDKNghi]
(
	-- Add the parameters for the function here
	@Employee_ID nvarchar(50),
	@Date datetime
)
RETURNS varchar(50)
AS
BEGIN
	declare @PlanStatus varchar(50),@ShiftGroup as varchar(50),@CrDate date,@NgayBaoNghiCaDem datetime
	set @CrDate=CAST(getdate() AS date)
	set @PlanStatus = 'UnKnownPlan'
	select @ShiftGroup=s.ShiftGroup
	from
	udf_TraVeDangKyCaDuaVaoCaXoay(@Date,@Date,null,null,null,null,null,null,@Employee_ID) rs
	left join
	HR_Shifts S
	ON RS.ShiftName=S.ShiftName
	
	if @ShiftGroup in ('Shift0','Shift1') begin
		if @Date<=@CrDate begin
			set @PlanStatus='UnPlan'
		end else begin
			set @PlanStatus='Plan'
		end
	end else begin
		set @NgayBaoNghiCaDem=@Date+1
		while exists(select H_date from SmartBooks_HolidaysPlan WHERE H_date = @NgayBaoNghiCaDem) or Upper(left(datename(dw,@NgayBaoNghiCaDem),3)) = 'SUN' begin
			set @NgayBaoNghiCaDem=@NgayBaoNghiCaDem+1
		end
		if GETDATE()<=DATEADD(HOUR,10,@NgayBaoNghiCaDem) begin
			set @PlanStatus='Plan'
		end else begin
			set @PlanStatus='UnPlan'
		end
	end
	return @PlanStatus + '-'+isnull(@ShiftGroup,'NoShift')

END




GO
