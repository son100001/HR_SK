--drop function [dbo].[udf_BangPhep]
CREATE FUNCTION [dbo].[udf_BangPhep]
(
	--select * from udf_BangPhep('2021-6-1','2021-6-30','ws000666')
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime,
	@Emp nvarchar(50)
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    ID int,[Employee_ID] nvarchar(50),[LeaveType_ID] nvarchar(50),Fromdate datetime,ToDate datetime,Reason nvarchar(255),PlanStatus varchar(50),isDaNopGiay bit,isBlock bit,isChoUngPhep bit,Remark nvarchar(255),InsertDate datetime,[UserName] nvarchar(50),primary key ([Employee_ID],[Fromdate])
)
AS
BEGIN
	insert into @rtnTable
	select * from
	(
		select ID,Employee_ID,LeaveType_ID,Fromdate,ToDate,Reason,PlanStatus,isDaNopGiay,isBlock,isChoUngPhep,Remark,InsertDate,UserName from [dbo].[HR_EmployeeRegisMaternityLeave]
			union
			select ID,Employee_ID,'16' as LeaveType_ID,NgayNghiBu as Fromdate,NgayNghiBu as ToDate,N'Nghỉ bù' as Reason, 'Plan-'+RIGHT(ShiftName,6) as PlanStatus,1 as isDaNopGiay, 1 as isBlock, 0 as isChoUngPhep,Remark,InsertDate,UserName from [dbo].[HR_MaxOvertime]
	)erl
	where fromdate<=@todate and todate>=@fromdate
		and (case when ISNULL(@Emp,'')='' then '' else Employee_ID end)=(case when ISNULL(@Emp,'')='' then '' else @Emp end)

	-- Return the result of the function
	RETURN

END




GO
