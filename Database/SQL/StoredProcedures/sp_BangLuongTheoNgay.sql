-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE sp_BangLuongTheoNgay
	@Ngay datetime,
	@TypeOfReport int=1,
	@LAN nvarchar(50)='VN',
	@UserName nvarchar(50) null,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @DauThang datetime,@CuoiThang as datetime
	set @DauThang=DATEADD(day,1-day(@Ngay),@Ngay)
	set @CuoiThang=DATEADD(month,1,@dauthang)-1
	if @TypeOfReport=1 begin
		-- LƯƠNG LŨY KẾ CỦA BÁO CÁO LƯƠNG DAILY
		DECLARE @tabLuongLuyKe as table(Employee_ID nvarchar(50),LuongLuyKe float, primary key(Employee_ID))
		insert into @tabLuongLuyKe
		select Employee_ID,sum(isnull(s70,0)) as LuongLuyKe from SmartBooks_Salary_Daily
		where PayDate between @DauThang and @Ngay-1
			and PayDate not in (select h_date from SmartBooks_HolidaysPlan)
		group by Employee_ID
		-- END
		-- LƯƠNG NGÀY LỄ HOẶC NGÀY NGHỈ PHÉP TOÀN CÔNG TY
		DECLARE @tabLuongNgayPhepToanCty as table(Employee_ID nvarchar(50),LuongPhepToanCty float, primary key(Employee_ID))
		insert into @tabLuongNgayPhepToanCty
		select Employee_ID,sum(isnull(s70,0)) as LuongPhepToanCty from SmartBooks_Salary_Daily
		where PayDate between @DauThang and @CuoiThang
			and PayDate in (select h_date from SmartBooks_HolidaysPlan)
		group by Employee_ID
		-- Insert statements for procedure here
		SELECT (case when PositionName<>N'Công nhân' then N'Quản lý' else empl.SectionName end) as PositionFullName
			,sum(case when empl.StartedDate<=@ngay and (empl.TernimationDate is null or empl.TernimationDate>@Ngay) then 1 else 0 end) as SoLuongNV,sum(lk.LuongLuyKe) as LuongLuyKe
			,sum(isnull(sd.s29,0)) as s29,sum(isnull(sd.s52,0)) as s52,sum(isnull(sd.s53,0)) as s53,sum(isnull(sd.s54,0)) as s54,sum(isnull(sd.s55,0)) as s55,sum(isnull(sd.s56,0)) as s56
			,sum(isnull(sd.s57,0)) as s57,sum(isnull(sd.s58,0)) as s58,sum(isnull(sd.s59,0)) as s59,sum(isnull(sd.s60,0)) as s60,sum(isnull(sd.s51,0)) as s51,sum(isnull(sd.s27,0)) as s27
			,sum(lptcty.LuongPhepToanCty/[dbo].[udf_CountWorkingDay](@DauThang,@CuoiThang)) as LuongPhepToanCty
		from
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@Ngay) empl
		left join
		SmartBooks_Salary_Daily sd
		on empl.Employee_ID=sd.Employee_ID and sd.PayDate=@Ngay
		left join
		@tabLuongLuyKe lk
		on empl.Employee_ID=lk.Employee_ID
		left join
		@tabLuongNgayPhepToanCty lptcty
		on empl.Employee_ID=lptcty.Employee_ID
		where empl.StartedDate<=@Ngay and (empl.TernimationDate is null or empl.TernimationDate>@DauThang)
		group by (case when PositionName<>N'Công nhân' then N'Quản lý' else empl.SectionName end)
	end
END

GO
