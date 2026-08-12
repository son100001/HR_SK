CREATE FUNCTION [dbo].[udf_TroCapTV] 
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_TroCapTV] (5,2020)
	@Month int,
	@Year int
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
     [Employee_ID] nvarchar(50),TienLuong1 float,TienLuong2 float,TienLuong3 float,TienLuong4 float,TienLuong5 float,TienLuong6 float,LuongBQ float
	 ,SoThangNghiBH int,SoThangTruoc2009 int,TongSoNam int,TongSoThang int,TroCapTV float,GhiChuNghiBH nvarchar(max)
	 ,primary key ([Employee_ID])
)
AS
BEGIN
 declare @fromdate datetime,@todate datetime
 set @fromdate=cast(@year as varchar)+'-'+cast(@month as varchar)+'-1'
 set @todate=dateadd(month,1,@fromdate)
 insert into @rtnTable
 select TroCapTV.Employee_ID,l6tgn.TienLuong1,l6tgn.TienLuong2,l6tgn.TienLuong3,l6tgn.TienLuong4,l6tgn.TienLuong5,l6tgn.TienLuong6,l6tgn.LuongBQ
,TroCapTV.SoThangNghiBH
,TroCapTV.SoThangTruoc2009
,floor((isnull(SoThangNghiBH,0)+isnull(SoThangTruoc2009,0))/12) as TongSoNam
,(isnull(SoThangNghiBH,0)+isnull(SoThangTruoc2009,0))%12 as TongSoThang
,(case when TroCapTV.SoThang>=6
			then (l6tgn.LuongBQ/2)*(TroCapTV.SoNam+1)
			else
				(case when TroCapTV.SoThang>=1 and TroCapTV.SoThang<6 then (l6tgn.LuongBQ/4) when TroCapTV.SoThang>=6 then (l6tgn.LuongBQ/2) else 0 end) + (l6tgn.LuongBQ/2)*TroCapTV.SoNam
end) as TroCapTV
,GhiChuNghiBH
 from 
	(
		select Employee_ID,SoThangNghiBH,SoThangTruoc2009,floor((isnull(SoThangNghiBH,0)+isnull(SoThangTruoc2009,0))/12) as SoNam,(isnull(SoThangNghiBH,0)+isnull(SoThangTruoc2009,0))%12 as SoThang
			,GhiChuNghiBH
		from	
		(select  empl.Employee_ID,TroCapTV.SoThangNghiBH
			,(case when empl.ComStartedDate>='2009-1-1' then 0 else
				left([dbo].[udf_TinhSoThangSoNgay](empl.ComStartedDate,'2008-12-31'),3)
			end) as SoThangTruoc2009
			,GhiChuNghiBH
			from
			SmartBooks_Employee empl
			left join
			(select erml.Employee_ID
				,sum(
						datediff(day,erml.fromdate,erml.todate)--cast (left([dbo].[udf_TinhSoThangSoNgay](erml.Fromdate,(case when empl.TernimationDate>erml.ToDate then erml.ToDate else empl.TernimationDate end)),2) as int)
					)/30
				as SoThangNghiBH
				,STUFF((SELECT  ','+lt.LeaveType_VN+'('+convert(varchar(10), gcNghiBH.Fromdate, 103)+'-'+convert(varchar(10), gcNghiBH.ToDate, 103)+')' FROM 
					HR_EmployeeRegisMaternityLeave gcNghiBH
					inner join
					SmartBooks_LeaveType lt
					on gcNghiBH.LeaveType_ID=lt.LeaveType_ID and lt.isLeave_InsPay=1
					WHERE Fromdate>='2009-1-1' and DATEDIFF(day,fromdate,todate)>=14 and gcNghiBH.Employee_ID = erml.Employee_ID  FOR XML PATH('')),1,1,'') as GhiChuNghiBH
				from
				SmartBooks_Employee empl
				inner join
				HR_EmployeeRegisMaternityLeave erml
				on erml.Employee_ID=empl.Employee_ID and empl.TernimationDate between @fromdate and @todate
				where erml.LeaveType_ID in (select LeaveType_ID from SmartBooks_LeaveType where isLeave_InsPay=1)
					and erml.Fromdate>='2009-1-1' and DATEDIFF(day,erml.fromdate,erml.todate)>=14
				group by erml.Employee_ID
			)TroCapTV
			on TroCapTV.Employee_ID=empl.Employee_ID
			left join
			[dbo].[udf_NgayKyHDChinhThuc](@fromdate,@todate)  NgayHDCT
			on empl.Employee_ID=NgayHDCT.Employee_ID
			where empl.TernimationDate between @fromdate and @todate and left([dbo].[udf_TinhSoThangSoNgay](NgayHDCT.NgayKyHDChinhThuc,empl.TernimationDate-1),3)>=12
		)TroCapTV
	)TroCapTV
	left join
	udf_Luong6ThangGanNhat(@fromdate,@todate,null,null,null,null,null,null,null) l6tgn
	on TroCapTV.Employee_ID=l6tgn.Employee_ID
	-- Return the result of the function
	RETURN

END



GO
