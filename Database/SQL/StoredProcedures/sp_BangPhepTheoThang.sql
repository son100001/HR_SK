-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BangPhepTheoThang]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	DECLARE @tbWorkingDay TABLE(Employee_ID nvarchar(50) not null
								,wd1 nvarchar(20) null,wd2 nvarchar(20) null,wd3 nvarchar(20) null,wd4 nvarchar(20) null,wd5 nvarchar(20) null,wd6 nvarchar(20) null,wd7 nvarchar(20) null,wd8 nvarchar(20) null,wd9 nvarchar(20) null,wd10 nvarchar(20) null,wd11 nvarchar(20) null,wd12 nvarchar(20) null,wd13 nvarchar(20) null,wd14 nvarchar(20) null,wd15 nvarchar(20) null,wd16 nvarchar(20) null,wd17 nvarchar(20) null,wd18 nvarchar(20) null,wd19 nvarchar(20) null,wd20 nvarchar(20) null,wd21 nvarchar(20) null,wd22 nvarchar(20) null,wd23 nvarchar(20) null,wd24 nvarchar(20) null,wd25 nvarchar(20) null,wd26 nvarchar(20) null,wd27 nvarchar(20) null,wd28 nvarchar(20) null,wd29 nvarchar(20) null,wd30 nvarchar(20) null,wd31 nvarchar(20) null
								)

	DECLARE @tbDate TABLE(date_ datetime not null)
	Declare @dtNext datetime
	set @dtNext = @fromdate
	WHILE @dtNext <= @todate
	BEGIN
	   insert into @tbDate (date_) values(@dtNext)
	   set @dtNext = DATEADD(day,1,@dtNext)
	END
	declare @Employee_ID_Old nvarchar(50), @Employee_ID nvarchar(50),@FullName nvarchar(50),@DepartmentCode nvarchar(50),@StartedDate datetime,@ProbationDate datetime,@TernimationDate datetime
			,@FullName_Old nvarchar(50),@DepartmentCode_Old nvarchar(50),@StartedDate_Old datetime,@ProbationDate_Old datetime,@TernimationDate_Old datetime
			,@wd1 nvarchar(50),@wd2 nvarchar(50),@wd3 nvarchar(50),@wd4 nvarchar(50),@wd5 nvarchar(50),@wd6 nvarchar(50),@wd7 nvarchar(50),@wd8 nvarchar(50),@wd9 nvarchar(50),@wd10 nvarchar(50),@wd11 nvarchar(50),@wd12 nvarchar(50),@wd13 nvarchar(50),@wd14 nvarchar(50),@wd15 nvarchar(50),@wd16 nvarchar(50),@wd17 nvarchar(50),@wd18 nvarchar(50),@wd19 nvarchar(50),@wd20 nvarchar(50),@wd21 nvarchar(50),@wd22 nvarchar(50),@wd23 nvarchar(50),@wd24 nvarchar(50),@wd25 nvarchar(50),@wd26 nvarchar(50),@wd27 nvarchar(50),@wd28 nvarchar(50),@wd29 nvarchar(50),@wd30 nvarchar(50),@wd31 nvarchar(50)
			,@wt1 float,@wt2 float,@wt3 float,@wt4 float,@wt5 float,@wt6 float
			,@Date datetime
			,@TypeLeave nvarchar(50),@isLeave_ComPay bit,@isLeave_nonPay bit
			,@H_date datetime
set @Employee_ID_Old = ''
Declare cur_WorkingDay CURSOR FOR
	select tbd.date_,empl.Employee_ID, empl.Employee_Firstname + (case when empl.Employee_LastName is null then '' else ' ' + empl.Employee_LastName end) as FullName,isnull(empl.DepartmentCode,0),empl.StartedDate,empl.ProbationDate,empl.TernimationDate
			,isnull(wt1,0)as wt1,isnull(wt2,0)as wt2,isnull(wt3,0)as wt3,isnull(wt4,0)as wt4,isnull(wt5,0)as wt5,isnull(wt6,0)as wt6
			,(case when hp.TypeOfLeave is null or lt.isMaternityLeave=1 or (erml.Fromdate<=@fromdate and (case when erml.ToDate is null
																						then (case when erml.NgayDuKienQuayLai is null 
																								then erml.Fromdate else erml.NgayDuKienQuayLai
																								end)
																						else erml.ToDate
																					end)>=@todate)
					then erml.[Type]
					else hp.TypeOfLeave
				end) as [Type]
			,isnull(lt.isLeave_ComPay,0)as isLeave_ComPay,isnull(lt.isLeave_nonPay,0)as isLeave_nonPay
			 from
	SmartBooks_Employee empl
	left join
	@tbDate tbd
	on tbd.date_ >= empl.StartedDate and (empl.Employee_Status = 'Active' or empl.TernimationDate is null or tbd.date_<TernimationDate)
	left join
	(
		select Employee_ID, Ngay, sum(isnull(wt1,0)) as wt1, sum(isnull(wt2,0)) as wt2, sum(isnull(wt3,0)) as wt3, sum(isnull(wt4,0)) as wt4, sum(isnull(wt5,0)) as wt5, sum(isnull(wt6,0)) as wt6, sum(isnull(wt7,0)) as wt7, sum(isnull(wt8,0)) as wt8, sum(isnull(wt9,0)) as wt9, sum(isnull(wt10,0)) as wt10, sum(isnull(wt11,0)) as wt11, sum(isnull(wt12,0)) as wt12, sum(isnull(wt13,0)) as wt13, sum(isnull(wt14,0)) as wt14, sum(isnull(wt15,0)) as wt15, sum(isnull(wt16,0)) as wt16, sum(isnull(wt17,0)) as wt17, sum(isnull(wt18,0)) as wt18, sum(isnull(wt19,0)) as wt19, sum(isnull(wt20,0)) as wt20
		from
		(
			select * from dbo.HR_BangCongTheoNgay
			union all
			select * from [dbo].[HR_BangCongNgoaiLe]
		)	as nc where Ngay between @fromdate and @todate group by Employee_ID, Ngay
	) as NoiCong
	on tbd.date_ = NoiCong.Ngay and empl.Employee_ID = NoiCong.Employee_ID
	left join
	SmartBooks_HolidaysPlan hp
	on hp.H_date=tbd.date_ and empl.StartedDate<=hp.H_date
	left join
	HR_EmployeeRegisMaternityLeave erml
	on empl.Employee_ID COLLATE DATABASE_DEFAULT=erml.Employee_ID and tbd.date_ between fromdate and (case when erml.ToDate is null then (case when erml.NgayDuKienQuayLai is null then erml.Fromdate else erml.NgayDuKienQuayLai end) else erml.ToDate end)
	left join
	SmartBooks_LeaveType lt
	on erml.[Type] = lt.ID or hp.TypeOfLeave = lt.ID
	where erml.Employee_ID is not null or hp.TypeOfLeave is not null
	order by empl.Employee_ID,tbd.date_
OPEN  cur_WorkingDay
FETCH NEXT FROM cur_WorkingDay INTO @Date,@Employee_ID,@FullName,@DepartmentCode,@StartedDate,@ProbationDate,@TernimationDate,@wt1,@wt2,@wt3,@wt4,@wt5,@wt6,@TypeLeave,@isLeave_ComPay,@isLeave_nonPay
WHILE @@FETCH_STATUS = 0
BEGIN
	if @Employee_ID_Old='' or @Employee_ID=@Employee_ID_Old begin
		 set @Employee_ID_Old=@Employee_ID set @FullName_Old=@FullName set @DepartmentCode_Old=@DepartmentCode set @StartedDate_Old=@StartedDate set @ProbationDate_Old=@ProbationDate set @TernimationDate_Old=@TernimationDate
	end else if @Employee_ID_Old<>@Employee_ID
	begin
		insert into @tbWorkingDay (Employee_ID,wd1,wd2,wd3,wd4,wd5,wd6,wd7,wd8,wd9,wd10,wd11,wd12,wd13,wd14,wd15,wd16,wd17,wd18,wd19,wd20,wd21,wd22,wd23,wd24,wd25,wd26,wd27,wd28,wd29,wd30,wd31)
		values(@Employee_ID_Old,@wd1,@wd2,@wd3,@wd4,@wd5,@wd6,@wd7,@wd8,@wd9,@wd10,@wd11,@wd12,@wd13,@wd14,@wd15,@wd16,@wd17,@wd18,@wd19,@wd20,@wd21,@wd22,@wd23,@wd24,@wd25,@wd26,@wd27,@wd28,@wd29,@wd30,@wd31)
		set @wd1='' set @wd2='' set @wd3='' set @wd4='' set @wd5='' set @wd6='' set @wd7='' set @wd8='' set @wd9='' set @wd10='' set @wd11='' set @wd12='' set @wd13='' set @wd14='' set @wd15='' set @wd16='' set @wd17='' set @wd18='' set @wd19='' set @wd20='' set @wd21='' set @wd22='' set @wd23='' set @wd24='' set @wd25='' set @wd26='' set @wd27='' set @wd28='' set @wd29='' set @wd30='' set @wd31=''
		set @Employee_ID_Old=@Employee_ID
	end
	if @wt1+@wt2<8 begin
		if DATEPART(day,@Date)=1 set @wd1 = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 2 set @wd2  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 3 set @wd3  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 4 set @wd4  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 5 set @wd5  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 6 set @wd6  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 7 set @wd7  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 8 set @wd8  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 9 set @wd9  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 10 set @wd10  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 11 set @wd11  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 12 set @wd12  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 13 set @wd13  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 14 set @wd14  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 15 set @wd15  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 16 set @wd16  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 17 set @wd17  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 18 set @wd18  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 19 set @wd19  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 20 set @wd20  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 21 set @wd21  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 22 set @wd22  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 23 set @wd23  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 24 set @wd24  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 25 set @wd25  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 26 set @wd26  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 27 set @wd27  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 28 set @wd28  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 29 set @wd29  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 30 set @wd30  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
		else if DATEPART(day,@Date)= 31 set @wd31  = (case when @wt1+@wt2=0 then '' else cast(8-@wt1-@wt2 as nvarchar(50)) end)+@TypeLeave
	end
FETCH NEXT FROM cur_WorkingDay INTO @Date,@Employee_ID,@FullName,@DepartmentCode,@StartedDate,@ProbationDate,@TernimationDate,@wt1,@wt2,@wt3,@wt4,@wt5,@wt6,@TypeLeave,@isLeave_ComPay,@isLeave_nonPay
END
CLOSE cur_WorkingDay
DEALLOCATE cur_WorkingDay
END
--NHAP DONG CUOI
insert into @tbWorkingDay (Employee_ID,wd1,wd2,wd3,wd4,wd5,wd6,wd7,wd8,wd9,wd10,wd11,wd12,wd13,wd14,wd15,wd16,wd17,wd18,wd19,wd20,wd21,wd22,wd23,wd24,wd25,wd26,wd27,wd28,wd29,wd30,wd31)
		values(@Employee_ID_Old,@wd1,@wd2,@wd3,@wd4,@wd5,@wd6,@wd7,@wd8,@wd9,@wd10,@wd11,@wd12,@wd13,@wd14,@wd15,@wd16,@wd17,@wd18,@wd19,@wd20,@wd21,@wd22,@wd23,@wd24,@wd25,@wd26,@wd27,@wd28,@wd29,@wd30,@wd31)
--SHOW DU LIEU
select wd.Employee_ID
	,empl.Employee_Firstname+(case when empl.Employee_LastName is null then '' else ' '+empl.Employee_LastName end) as FullName
	,empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID
	,empl.StartedDate
	,wd1,wd2,wd3,wd4,wd5,wd6,wd7,wd8,wd9,wd10,wd11,wd12,wd13,wd14,wd15,wd16,wd17,wd18,wd19,wd20,wd21,wd22,wd23,wd24,wd25,wd26,wd27,wd28,wd29,wd30,wd31
from
@tbWorkingDay wd
left join
SmartBooks_Employee empl
on wd.Employee_ID=empl.Employee_ID
order by empl.departmentcode,empl.sectioncode,empl.teamcode,empl.StartedDate

--exec [dbo].[sp_BangPhepTheoThang] '2017-1-1','2017-1-31'

--select * from HR_EmployeeRegisMaternityLeave where Fromdate='2017-1-16' and Employee_ID = 'S8241'





GO
