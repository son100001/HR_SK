CREATE FUNCTION [dbo].[udf_ChuyenCanGoc] 
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_ChuyenCanGoc] (7,2021) where Employee_ID = 'ws000021'
	@Month int,
	@Year int
)
RETURNS  @rtnChuyenCanGoc TABLE 
(
    -- columns returned by the function
     [Employee_ID] nvarchar(50),TienCC float
	 ,primary key ([Employee_ID])
)
AS
BEGIN
 declare @fromdate datetime,@todate datetime,@TienCC float
 set @fromdate=cast(@year as varchar)+'-'+cast(@month as varchar)+'-1'
 set @todate=dateadd(month,1,@fromdate)
	select @TienCC=Value from HR_SetUpFollowDate where Fromdate<=@todate and Group_='TienChuyenCan' order by Fromdate asc
	-- Return the result of the function
	insert into @rtnChuyenCanGoc
		select empl.Employee_ID,@TienCC from
		udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,@todate) empl
		where empl.Position_ID in ('CoNh','Totr','Totrtt')
			and empl.StartedDate<=@todate and (TernimationDate is null or TernimationDate>@fromdate)
	RETURN

END

GO
