-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
--select * from udf_TinhThuongLamDu('2019-10-1','2019-10-31') where employee_id='S000057'

CREATE FUNCTION [dbo].[udf_TinhThuongLamDu]
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),ThuongLamDu float,primary key ([Employee_ID])
)
AS
BEGIN
	insert into @rtnTable
	select empl.Employee_ID
	,(case when isnull(wt.wt,0)+(isnull(thp.LeaveComPay,0)+isnull(thp.KT,0)+isnull(thp.NT,0)+isnull(thp.CTCN,0))*8=(datediff(day,@fromdate,@todate)+1 - [dbo].[udf_CountSunDay](@fromdate,@todate))*8 then sc.Amount
		when ([dbo].[udf_CountWorkingDay](@fromdate,empl.StartedDate) = 2 and isnull(wt.wt,0)+(isnull(thp.LeaveComPay,0)+isnull(thp.KT,0)+isnull(thp.NT,0)+isnull(thp.CTCN,0))*8=(datediff(day,@fromdate,@todate)+1 - [dbo].[udf_CountSunDay](@fromdate,@todate))*8-8)-- người mới vào từ ngày workday thứ 2
			or
			(isnull(wt.wt,0)+(isnull(thp.LeaveComPay,0)+isnull(thp.KT,0)+isnull(thp.NT,0)+isnull(thp.CTCN,0))*8>=(datediff(day,@fromdate,@todate)+1 - [dbo].[udf_CountSunDay](@fromdate,@todate))*8-8 and isnull(VM_VS_RN.SoLanVaoMuon_VeSom_RaNgoai,0)<=1 and empl.starteddate<=@fromdate) -- người cũ làm thiếu tối đa 1 ngày và chỉ có 1 lần đi muộn về sớm hoặc ra ngoài giữa giờ
		then sc.Amount-100000
		else 0 end) as ThuongLamDu
		--,isnull(wt.wt,0)+(isnull(thp.LeaveComPay,0)+isnull(thp.KT,0)+isnull(thp.NT,0)+isnull(thp.CTCN,0))*8
	from
	[dbo].[udf_EmployeeFilter]('VN',null,null,null,null,null,null,null,isnull(@todate,getdate())) empl
	left join
	HR_SalaryComponent sc
	on empl.Employee_ID=sc.Employee_ID and sc.SalaryComponent='ThuongLamDu'
	left join
	(select Employee_ID,min(fromdate) as fromdate from [dbo].[HR_EmployeeRegisMaternityLeave] where LeaveType_ID='28' group by Employee_ID) sendingletter
	on empl.Employee_ID=sendingletter.Employee_ID
	left join
	[dbo].[udf_TraVeBangTongHopPhep](@fromdate,@todate) thp
	on empl.Employee_ID=thp.Employee_ID
	left join
	(
		select Employee_ID,sum(wt) as wt from
		HR_WTDaily wt
		left join
		HR_LoaiCong lc
		on wt.macong=lc.macong
		where lc.isWorkingTime=1 and wt.Ngay between @fromdate and @todate and DATENAME(weekday,wt.Ngay)<>'Sunday'
		group by Employee_ID
	) wt
	on empl.Employee_ID=wt.Employee_ID
	left join
	(
		select Employee_ID,count(Employee_ID) as SoLanVaoMuon_VeSom_RaNgoai
		from
		(
			select Employee_ID,sum(wt) as wt from
			HR_WTDaily wt
			left join
			HR_LoaiCong lc
			on wt.macong=lc.macong
			where lc.isWorkingTime=1 and wt.Ngay between @fromdate and @todate
			group by Employee_ID, ngay
		)VM_VS_RN where wt<8 and wt>0
		group by Employee_ID
	)VM_VS_RN
	on empl.Employee_ID=VM_VS_RN.Employee_ID
	where empl.starteddate<@todate and ((empl.[TernimationDate] is null and sendingletter.fromdate is null) or isnull(sendingletter.fromdate,empl.[TernimationDate])>@todate)
		and sc.Amount>0

	-- Return the result of the function
	RETURN

END




GO
