--select * from [dbo].[udf_TongHopHopDongLaoDong]('2010-1-1',getdate(),null,null,null,null,null,null,'WS000001')
CREATE FUNCTION [dbo].[udf_TongHopHopDongLaoDong]
(
	@fromdate datetime,
	@todate datetime,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Empl nvarchar(50)=null
)
RETURNS  @rtnHopDong TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),HD1 varchar(50),NK1 datetime,HH1 datetime,HD2 varchar(50),NK2 datetime,HH2 datetime,HD3 varchar(50),NK3 datetime,HH3 datetime,HD4 varchar(50),NK4 datetime,HH4 datetime,primary key ([Employee_ID])
)
AS
BEGIN

	insert into @rtnHopDong (Employee_ID,HD1,HD2,HD3,HD4)
	select Employee_ID,[1],[2],[3],[4] from
	(
	select hdts.Employee_ID,hdts.[Type],ctfl.No_ from
	[dbo].[udf_HopDongTuSinh](@fromdate,@todate,1,'VN',@fact,@dept,@sect,@team,@pos,@posc,@Empl) hdts
	left join
	SmartBooks_Employee empl
	on hdts.Employee_ID=empl.Employee_ID
	left join
	HR_ContractFlow ctfl
	on empl.ContractFlow=ctfl.ContractFlow and hdts.[Type]=ctfl.Contract_ID
	)as st
	PIVOT  
	(  
	  max([Type])
	  FOR No_ IN ([1], [2], [3], [4])
	) AS PivotTable;

	update hd set hd.NK1=NK.[1],hd.NK2=NK.[2],hd.NK3=NK.[3],hd.NK4=NK.[4]
	from
	@rtnHopDong hd
	inner join
	(
		select Employee_ID,[1],[2],[3],[4] from
		(
			select hdts.Employee_ID,hdts.CL_StartDate,ctfl.No_ from
			[dbo].[udf_HopDongTuSinh](@fromdate,@todate,1,'VN',@fact,@dept,@sect,@team,@pos,@posc,@Empl) hdts
			left join
			SmartBooks_Employee empl
			on hdts.Employee_ID=empl.Employee_ID
			left join
			HR_ContractFlow ctfl
			on empl.ContractFlow=ctfl.ContractFlow and hdts.[Type]=ctfl.Contract_ID
		)as st
		PIVOT  
		(  
		  max(CL_StartDate)
		  FOR No_ IN ([1], [2], [3], [4])
		) AS PivotTable
	)NK
	on hd.Employee_ID=NK.employee_ID

	update hd set hd.NK1=NK.[1],hd.NK2=NK.[2],hd.NK3=NK.[3],hd.NK4=NK.[4]
	from
	@rtnHopDong hd
	inner join
	(
		select Employee_ID,[1],[2],[3],[4] from
		(
		select hdts.Employee_ID,hdts.CL_StartDate,ctfl.No_ from
		[dbo].[udf_HopDongTuSinh](@fromdate,@todate,1,'VN',@fact,@dept,@sect,@team,@pos,@posc,@Empl) hdts
		left join
		SmartBooks_Employee empl
		on hdts.Employee_ID=empl.Employee_ID
		left join
		HR_ContractFlow ctfl
		on empl.ContractFlow=ctfl.ContractFlow and hdts.[Type]=ctfl.Contract_ID
		)as st
		PIVOT  
		(  
		  max(CL_StartDate)
		  FOR No_ IN ([1], [2], [3], [4])
		) AS PivotTable
	)NK
	on hd.Employee_ID=NK.employee_ID

	update hd set hd.HH1=HH.[1],hd.HH2=HH.[2],hd.HH3=HH.[3],hd.HH4=HH.[4]
	from
	@rtnHopDong hd
	inner join
	(
		select Employee_ID,[1],[2],[3],[4] from
		(
		select hdts.Employee_ID
		,(case when empl.TernimationDate is null then hdts.CL_ExpiredDate else (case when hdts.CL_ExpiredDate<empl.TernimationDate then hdts.CL_ExpiredDate else '1990-1-1' end) end) as CL_ExpiredDate
		,ctfl.No_ from
		[dbo].[udf_HopDongTuSinh](@fromdate,@todate,1,'VN',@fact,@dept,@sect,@team,@pos,@posc,@Empl) hdts
		left join
		SmartBooks_Employee empl
		on hdts.Employee_ID=empl.Employee_ID
		left join
		HR_ContractFlow ctfl
		on empl.ContractFlow=ctfl.ContractFlow and hdts.[Type]=ctfl.Contract_ID
		where (case when isnull(@Empl,'')='' then '' else hdts.Employee_ID end)=isnull(@Empl,'')
		)as st
		PIVOT  
		(  
		  max(CL_ExpiredDate)
		  FOR No_ IN ([1], [2], [3], [4])
		) AS PivotTable
	)HH
	on hd.Employee_ID=HH.employee_ID

	RETURN
END


GO
