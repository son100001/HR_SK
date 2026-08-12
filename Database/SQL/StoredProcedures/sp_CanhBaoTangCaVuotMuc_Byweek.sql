CREATE PROCEDURE [dbo].[sp_CanhBaoTangCaVuotMuc_Byweek]               
@Week bit,
@month int,
@year int,
@SoGioChoPhep int
AS

begin
IF OBJECT_ID('tempdb..#bangtam') IS NOT NULL DROP TABLE #bangtam
CREATE TABLE #bangtam
(
Employee_ID nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS,
Employee_Firstname nvarchar(100),
Employee_LastName nvarchar(100) null, 
DepartmentCode nvarchar(50) null, 
SectionCode nvarchar(50) null, 
TeamCode nvarchar(50) null, 
Position_ID nvarchar(50) null, 
PositionCategory_ID nvarchar(50) null, 
ChucDanh nvarchar(50) null, 
Card_No nvarchar(50) null,
StartedDate datetime null,
NgayVuotGioiHan datetime null, 
SoGioChoPhep float,
TongSoGio float
)

DECLARE @Employee_ID nvarchar(50),@Employee_Firstname nvarchar(100),@Employee_LastName nvarchar(100), @DepartmentCode nvarchar(50), @SectionCode nvarchar(50), @TeamCode nvarchar(50), @Position_ID nvarchar(50), @PositionCategory_ID nvarchar(50), @ChucDanh nvarchar(50), @Card_No nvarchar(50),@StartedDate datetime
Declare @fdate datetime,@tdate datetime,@fromdate datetime,@loainghi nvarchar(100),@sotiengnghi float,@addtime float,@timein datetime,@timeout datetime,@ShiftName nvarchar(50)
declare @NgayVuotGioiHan datetime,@TongSoGio float,@t float
set @fdate=DATEFROMPARTS(@year, @month, 1)
set @tdate = dateadd(month,1,@fdate)
set @fromdate = @fdate

DECLARE cur_NhanVien CURSOR FOR   
select emp.Employee_ID,emp.Employee_Firstname,emp.Employee_LastName,emp.DepartmentCode,emp.SectionCode,emp.TeamCode,emp.Position_ID,emp.PositionCategory_ID,emp.ChucDanh,emp.Card_No,emp.StartedDate from dbo.SmartBooks_Employee emp where 
((emp.Employee_Status='Active' and emp.StartedDate<@tdate)  
or (emp.Employee_Status<>'Active' and emp.TernimationDate>@tdate and emp.StartedDate<@tdate))

OPEN  cur_NhanVien    
FETCH NEXT FROM cur_NhanVien INTO @Employee_ID,@Employee_Firstname,@Employee_LastName, @DepartmentCode, @SectionCode, @TeamCode, @Position_ID, @PositionCategory_ID, @ChucDanh, @Card_No,@StartedDate
WHILE @@FETCH_STATUS = 0
BEGIN
	set @fdate=@fromdate
	set @t=0

	WHILE (@fdate<=@tdate)                    
	BEGIN  
		
		select @t=@t+isnull(wt,0) from HR_WTDaily where [Employee_ID]=@Employee_ID and [Ngay]=@fdate
		and [MaCong] not in (select MaCong from HR_LoaiCong where isWorkingTime=0)

		if @t>=@SoGioChoPhep
		begin
			INSERT INTO #bangtam(Employee_ID,Employee_Firstname,Employee_LastName, DepartmentCode, SectionCode,TeamCode, Position_ID, PositionCategory_ID,ChucDanh,Card_No,StartedDate,NgayVuotGioiHan, SoGioChoPhep,TongSoGio)
			values(0,@Employee_ID,@Employee_Firstname,@Employee_LastName, @DepartmentCode, @SectionCode, @TeamCode, @Position_ID, @PositionCategory_ID, @ChucDanh, @Card_No,@StartedDate,@fdate,@SoGioChoPhep,@TongSoGio)
			break
		end
		
		set @fdate=DATEADD(day, 1,@fdate)       
	END
FETCH NEXT FROM cur_NhanVien INTO @Employee_ID,@Employee_Firstname,@Employee_LastName, @DepartmentCode, @SectionCode, @TeamCode, @Position_ID, @PositionCategory_ID, @ChucDanh, @Card_No,@StartedDate
END

CLOSE cur_NhanVien    
DEALLOCATE cur_NhanVien
    
	SELECT * FROM #bangtam
	Drop table #bangtam   
end

   
--exec sp_CanhBaoTangCaVuotMuc_Byweek 1,4,2019,12




GO
