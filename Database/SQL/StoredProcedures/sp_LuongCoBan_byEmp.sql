CREATE PROCEDURE [dbo].[sp_LuongCoBan_byEmp]               
@FromDate as datetime,
@ToDate as datetime,
@empID as nvarchar(50)
AS

Begin
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	IF OBJECT_ID('tempdb..#tb_LuongCoBan') IS NOT NULL DROP TABLE #tb_LuongCoBan

	CREATE TABLE #tb_LuongCoBan(
		Employee_ID nvarchar(50),
		PayGrade nvarchar(50),
		PayStep int,
		MucLuong decimal
	)

DECLARE @Employee_ID nvarchar(50), @OfficialDate nvarchar(50), @PayGrade nvarchar(50), @PayStep int, @MucLuong decimal
DECLARE @ProbationDate datetime
DECLARE cur_lcb CURSOR FOR   
select Employee_ID, OfficialDate from dbo.SmartBooks_Employee empl where 
((empl.StartedDate <= @todate and empl.Employee_Status = 'Incumbent' ) 
or (empl.Employee_Status <> 'Incumbent' and ISNULL(TernimationDate,@todate)>@todate)) 

OPEN  cur_lcb    
FETCH NEXT FROM cur_lcb INTO @Employee_ID, @OfficialDate
WHILE @@FETCH_STATUS = 0    
BEGIN
	SELECT @PayStep=s.PayStep FROM HR_Step s
	inner join(
	  select StepID, MAX(EffectiveDate) as EffectiveDate from HR_Step
	  where EffectiveDate<@ToDate
	  group by StepID
	) s1 on s.StepID = s1.StepID
	where s.Employee_ID = @Employee_ID

	SELECT @PayGrade=s.NhomLuong FROM HR_ThangLuongChiTiet s
	inner join(
		select MaThangLuong, MAX(Fromdate) as EffectiveDate from HR_ThangLuongChiTiet
		where Fromdate<@ToDate
		group by MaThangLuong
	) s1 on s.MaThangLuong = s1.MaThangLuong
	where s.Employee_ID = @Employee_ID

	SELECT @MucLuong= MucLuong FROM HR_ThangLuong s
	inner join(
		select ThangluongID, MAX(Beginingdate) as Beginingdate from HR_ThangLuong
		where Beginingdate<'2019/05/31'
		group by ThangluongID
	) s1 on s.ThangluongID = s1.ThangluongID
	where s.NhomLuong = @PayGrade and s.BacLuong = @PayStep

	insert into #tb_LuongCoBan(Employee_ID,PayGrade,PayStep,MucLuong)
	values(@Employee_ID,@PayGrade,@PayStep,@MucLuong)

FETCH NEXT FROM cur_lcb INTO @Employee_ID, @OfficialDate
END
CLOSE cur_lcb    
DEALLOCATE cur_lcb

End
select Employee_ID,PayGrade,PayStep,isnull(MucLuong,0) as MucLuong  from #tb_LuongCoBan where Employee_ID=@empID

--exec [dbo].[sp_LuongCoBan_byEmp] '2019-05-1', '2019-05-31','19000002' 




GO
