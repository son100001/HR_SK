CREATE FUNCTION [dbo].[udf_TinhTruyPN]
--select * from [dbo].[udf_TinhTruyPN]('2020-5-1',dateadd(day,1,'2020-5-31'),null,null,null,null,null,null,'2354')
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@emp nvarchar(50)=null
)
RETURNS  @rtnTinhTruyPN TABLE 
(
    -- columns returned by the function
	Employee_ID [nvarchar](50) NOT NULL,
	SoPNAm [float] NOT NULL,
	TienTruyThuPN [float] NOT NULL,
	primary key ([Employee_ID])
	,tl nvarchar(max) null
)
AS
BEGIN
	-- Declare the return variable here
	declare @Employee_ID nvarchar(50),@PNAm float,@PNAmGoc float,@ThangTinhPN datetime,@PNCuaThang float,@DT datetime, @CT datetime,@TienTruyThuPN float,@tl float, @remark nvarchar(max), @AlreadyCalculateThanhToanPN nvarchar(50)
	DECLARE cur CURSOR LOCAL FOR
	select Employee_ID from [dbo].[udf_EmployeeFilter]('VN',@fact,@dept,@sect,@team,@pos,@posc,@emp,@todate) where TernimationDate between @fromdate and @todate
	OPEN  cur 
	FETCH NEXT FROM cur INTO @Employee_ID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		--Son Sua
		set @AlreadyCalculateThanhToanPN = ''
		select @AlreadyCalculateThanhToanPN = [key] from SmartBooks_Salary where Month(@todate) = Salary_Month and Year(@todate) = Salary_Year and Employee_ID = @Employee_ID and [key] = N'ThanhToanPhepNam'
		if @AlreadyCalculateThanhToanPN not like N'ThanhToanPhepNam' begin
			set @PNAm=0
			select @PNAm=abs(isnull(PhepNamDuocHuongDenHienTai,0)+isnull(PhepNamTon,0)-isnull(TongPhepNamDaNghi,0)) from [dbo].[udf_QuanLyPhepNam](datepart(year,@fromdate),null,'VN',null,null,null,null,null,null,@Employee_ID) where isnull(PhepNamDuocHuongDenHienTai,0)+isnull(PhepNamTon,0)-isnull(TongPhepNamDaNghi,0)<0
			if @PNAm>0 begin
				set @ThangTinhPN=@fromdate
				set @TienTruyThuPN=0
				set @PNAmGoc=@PNAm
				set @PNAm=@PNAm*8
				set @remark=''
				while @PNAm>0 and DATEPART(year,@ThangTinhPN)=DATEPART(YEAR,@fromdate) begin
					set @DT = DATEFROMPARTS(DATEPART(YEAR,@ThangTinhPN),DATEPART(MONTH,@ThangTinhPN),1)
					set @CT = DATEADD(MONTH,1,@DT)-1
					set @PNCuaThang=0
					select @PNCuaThang=sum(HourLeave) from udf_BangPhepTheoNgay(2,@DT,@CT,null,null,null,null,null,null,null,@Employee_ID) where LeaveType_ID in (select LeaveType_ID from SmartBooks_LeaveType where PhepNam=1)
					if @PNCuaThang>0 begin
						if @PNAm>@PNCuaThang begin
							select @TienTruyThuPN=@TienTruyThuPN+TienLuong/208.0*@PNCuaThang, @tl=TienLuong from [dbo].[udf_TienLuong](datepart(MONTH,@ThangTinhPN),datepart(YEAR,@ThangTinhPN),null,null,null,null,null,null,@Employee_ID)
							set @PNAm=@PNAm-@PNCuaThang
							set @remark=@remark+ N'Tháng: '+cast(DATEPART(month,@ThangTinhPN) as varchar(2)) + N' Tiền lương:'+cast(cast(@tl as int) as varchar(20))+' so gio:'+cast(@PNCuaThang as varchar(50))+';'
						end else begin
							select @TienTruyThuPN=@TienTruyThuPN+TienLuong/208.0*@PNAm, @tl=TienLuong from [dbo].[udf_TienLuong](datepart(MONTH,@ThangTinhPN),datepart(YEAR,@ThangTinhPN),null,null,null,null,null,null,@Employee_ID)
							set @remark=@remark+ N'Tháng: '+cast(DATEPART(month,@ThangTinhPN) as varchar(2)) + N' Tiền lương:'+cast(cast(@tl as int) as varchar(20))+' so gio:'+cast(@PNAm as varchar(50))+','
							set @PNAm=0
						end
					end
					set @ThangTinhPN=DATEADD(MONTH,-1,@ThangTinhPN)
				end
				insert into @rtnTinhTruyPN values(@Employee_ID,@PNAmGoc,@TienTruyThuPN,@remark)
			end
		end
	FETCH NEXT FROM cur INTO @Employee_ID
	END
	CLOSE cur    
	DEALLOCATE cur
	
	RETURN
END
--select * from udf_ReturnTableSetupHourTimeKeeping('51-Shift1','2019-4-30',0)
--select * from HR_Shifts where ShiftName='41-Shift1'



--select * from udf_BangPhepTheoNgay('2020-5-1','2020-5-31',null,null,null,null,null,null,'2354')where LeaveType_ID in (select LeaveType_ID from SmartBooks_LeaveType where PhepNam=1)


GO
