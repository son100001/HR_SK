-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
--select * from [dbo].[udf_TinhPhepNam](2019,0,null,'INJECTION',null,null,null) where Employee_ID='G000106'
CREATE FUNCTION [dbo].[udf_TinhPhepNam]
(
	-- Add the parameters for the function here
	@Year int,
	@Termination bit,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null
)
RETURNS @tabTongHopPhepNam table
(
	[Employee_ID] [nvarchar](50) PRIMARY KEY NOT NULL,
	[TongPhepNamDuocHuong] [float] NULL,
	[TongPhepNamTon] [float] NULL,
	[TongPhepNamDaNghi] [float] NULL,
	[TongTruPhepNamDoNghiDaiNgay] [float] NULL
)
AS
BEGIN
	DECLARE @HR_EmployeeRegisMaternityLeave TABLE
	(
	  Employee_ID nvarchar(50), 
	  fromdate datetime,
	  todate datetime,
	  LeaveType nvarchar(50)
	)
	
	Declare @MocTinhPhepNam nvarchar(50),@GioiHanNgayTinhPhepNam int
	select @GioiHanNgayTinhPhepNam=Value from setup where ID='GioiHanNgayTinhPhepNam'
	select @MocTinhPhepNam=Value from setup where ID='MocTinhPhepNam'
	insert into @HR_EmployeeRegisMaternityLeave
	select Employee_ID,Fromdate
		,(case when datepart(year,ToDate)>@Year
			then DATEADD(year,1,cast(@year as varchar(4))+'-1-1')-1
			else ToDate
			end)
		,[Type]
	from HR_EmployeeRegisMaternityLeave
	where Fromdate<dateadd(month,1,(cast(@year as varchar(4))+'-12-1'))-1
			and ToDate>cast(@year as varchar(4))+'-1-1'
	
		insert into @tabTongHopPhepNam (Employee_ID,TongPhepNamDuocHuong,TongPhepNamDaNghi,TongTruPhepNamDoNghiDaiNgay,TongPhepNamTon)
		select
		empl.Employee_ID
		,(case when empl.SoNgayPhepNam is not null then empl.SoNgayPhepNam else
		(case when posc.AnnualLeaveDays is not null then posc.AnnualLeaveDays else
		(case when pos.AnnualLeaveDays is not null then pos.AnnualLeaveDays else
		(case when team.AnnualLeaveDays is not null then team.AnnualLeaveDays else
		(case when sect.AnnualLeaveDays is not null then sect.AnnualLeaveDays else
		(case when dept.AnnualLeaveDays is not null then dept.AnnualLeaveDays else suPhepNam.Value
		end)end)end)end)end)end)
		--Trừ số ngày trc khi vào công ty
		-(case when empl.SoNgayPhepNam is not null then empl.SoNgayPhepNam else
		(case when posc.AnnualLeaveDays is not null then posc.AnnualLeaveDays else
		(case when pos.AnnualLeaveDays is not null then pos.AnnualLeaveDays else
		(case when team.AnnualLeaveDays is not null then team.AnnualLeaveDays else
		(case when sect.AnnualLeaveDays is not null then sect.AnnualLeaveDays else
		(case when dept.AnnualLeaveDays is not null then dept.AnnualLeaveDays else suPhepNam.Value
		end)end)end)end)end)end)/12*(case when empl.StartedDate>cast(@Year as varchar(4))+'-1-1' then DATEDIFF(month,cast(@Year as varchar(4))+'-1-1',(case when @MocTinhPhepNam='0' then empl.StartedDate else empl.OfficialDate end))+(case when DATEPART(day,(case when @MocTinhPhepNam='0' then empl.StartedDate else empl.OfficialDate end))>=@GioiHanNgayTinhPhepNam then 1 else 0 end) else 0 end)
		--Trừ số ngày phép của những người nghỉ việc
		-
		(case when empl.SoNgayPhepNam is not null then empl.SoNgayPhepNam else
		(case when posc.AnnualLeaveDays is not null then posc.AnnualLeaveDays else
		(case when pos.AnnualLeaveDays is not null then pos.AnnualLeaveDays else
		(case when team.AnnualLeaveDays is not null then team.AnnualLeaveDays else
		(case when sect.AnnualLeaveDays is not null then sect.AnnualLeaveDays else
		(case when dept.AnnualLeaveDays is not null then dept.AnnualLeaveDays else suPhepNam.Value
		end)end)end)end)end)end)/12*(case when empl.TernimationDate<dateadd(year,1,cast(@Year as varchar(4))+'-1-1')-1 then DATEDIFF(month,empl.TernimationDate,dateadd(year,1,cast(@Year as varchar(4))+'-1-1')-1)+(case when empl.TernimationDate<=@GioiHanNgayTinhPhepNam then 1 else 0 end) else 0 end)
		 as TongNgayNghiPhepNam
		,TongPhepNamDaNghi--số phép năm đã nghỉ
		,
		(case when empl.SoNgayPhepNam is not null then empl.SoNgayPhepNam else
		(case when posc.AnnualLeaveDays is not null then posc.AnnualLeaveDays else
		(case when pos.AnnualLeaveDays is not null then pos.AnnualLeaveDays else
		(case when team.AnnualLeaveDays is not null then team.AnnualLeaveDays else
		(case when sect.AnnualLeaveDays is not null then sect.AnnualLeaveDays else
		(case when dept.AnnualLeaveDays is not null then dept.AnnualLeaveDays else suPhepNam.Value
		end)end)end)end)end)end)/12*TongTruPhepNamDoNghiDaiNgay as TongTruPhepNamDoNghiDaiNgay
		,isnull(hle.HourLeave,0)/8 as TongPhepNamTonNamTruoc
	from
	SmartBooks_Employee empl
	left join
	SmartBooks_PositionCategory posc
	on empl.PositionCategory_ID=posc.PositionCategory_ID
	left join
	SmartBooks_Position pos
	on empl.Position_ID=pos.Position_ID
	left join
	SmartBooks_Team team
	on empl.TeamCode=team.TeamCode
	left join
	SmartBooks_Section sect
	on empl.SectionCode=sect.SectionCode
	left join
	SmartBooks_Department dept
	on empl.DepartmentCode=dept.DepartmentCode
	left join
	(select Employee_ID,sum(HourLeave)/8 as TongPhepNamDaNghi from HR_EmpRegisLeave where year(DateLeave)=@Year and LeaveType_ID in (select LeaveType_ID from SmartBooks_LeaveType where PhepNam=1) group by Employee_ID) erl
	on empl.Employee_ID=erl.Employee_ID
	left join
	(
		select Employee_ID
			,sum
			(
				(case when lt.isNghiTruPhepNam=1 then
					(case when lt.[isMaternityLeave]=1 then
						(case when DATEPART(MONTH,fromdate)= DATEPART(MONTH,todate) and DATEPART(YEAR,fromdate)= DATEPART(YEAR,todate) then 0 else
							datediff(month,fromdate,todate)+1+(case when DATEPART(DAY,fromdate)<=@GioiHanNgayTinhPhepNam then 0 else -1 end)+(case when DATEPART(DAY,todate)<=@GioiHanNgayTinhPhepNam then -1 else 0 end)
						end)
					else
						(case when DATEPART(MONTH,fromdate)= DATEPART(MONTH,todate) and DATEPART(YEAR,fromdate)= DATEPART(YEAR,todate) then 0 else
							datediff(month,fromdate,todate)+1+(case when DATEPART(DAY,fromdate)=1 then 0 else -1 end)+(case when DATEPART(DAY,todate)=DATEPART(day,dateadd(month,1,todate)-DATEPART(day,todate)-1) then 0 else -1 end)
						end)
					end)
				else 0 end)
				) as TongTruPhepNamDoNghiDaiNgay
		from
		@HR_EmployeeRegisMaternityLeave erml
		left join
		SmartBooks_LeaveType lt
		on erml.[LeaveType]=lt.ID
		group by erml.Employee_ID
	) TongTruPhepNamDoNghiDaiNgay
	on empl.Employee_ID=TongTruPhepNamDoNghiDaiNgay.Employee_ID
	left join
	(select Employee_ID,sum(HourLeave) as HourLeave from HR_HourLeaveException where [Year_]=@Year group by Employee_ID) hle
	on empl.Employee_ID COLLATE DATABASE_DEFAULT=hle.Employee_ID
	left join
	(select * from SetUp where ID='TongNgayPhepTrongNam') suPhepNam
	on 1=1
	where DATEPART(YEAR,empl.StartedDate)<=@Year and (DATEPART(YEAR,empl.TernimationDate)>=@Year or empl.TernimationDate is null)
			and (case when @fact is null or @fact='' then '' else empl.Factory_ID end)=(case when @fact is null or @fact='' then '' else @fact end)
			and (case when @dept is null or @dept='' then '' else empl.DepartmentCode end)=(case when @dept is null or @dept='' then '' else @dept end)
			and (case when @sect is null or @sect='' then '' else empl.SectionCode end)=(case when @sect is null or @sect='' then '' else @sect end)
			and (case when @team is null or @team='' then '' else empl.TeamCode end)=(case when @team is null or @team='' then '' else @team end)
			and (case when @pos is null or @pos='' then '' else empl.Position_ID end)=(case when @pos is null or @pos='' then '' else @pos end)
			and (case when @posc is null or @posc='' then '' else empl.PositionCategory_ID end)=(case when @posc is null or @posc='' then '' else @posc end)
	 and (case when @Termination=1 then TernimationDate else '' end)=(case when @Termination=1 then TernimationDate else '' end)

	return

END




GO
