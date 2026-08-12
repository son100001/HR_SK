--select * from [dbo].[udf_DangKyCa]('2025-09-01','2025-09-30',181,null,null,null,null,null,null,null)
CREATE FUNCTION [dbo].[udf_DangKyCa]
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime,
	@SoNgaySauKhiMangBauDuocHuongThaiSan int,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Emp nvarchar(50)=null
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [AccessDate] datetime,[Employee_ID] nvarchar(50),[ShiftName] nvarchar(50),ExtraHours float,GioTCTruoc float,[CheDo] int
	, FactoryName nvarchar(100), DepartmentName nvarchar(200), SectionName nvarchar(200), isManager bit,primary key ([Employee_ID],[AccessDate])
)
AS
BEGIN
	
	insert into @rtnTable
	select td.Date_,
		dkctvt.Employee_ID,
		(case when erts.ShiftName is not null then 
			erts.ShiftName
		 when cx.ShiftName is not null then cx.ShiftName
		 else dkctvt.ShiftName
		end) as ShiftName,
		cx.ExtraHours,cx.GioTCTruoc,
		isnull(erp.ParameterValue,(case when cdo.Employee_ID is not null then 
			(case when td.Date_ between cdo.OldFromdate and cdo.OldTodate then 2 when td.Date_ between cdo.babyFromdate and cdo.babyTodate then 3 else 1 end)
		else 0 end)) as CheDo
		, dkctvt.FactoryName, dkctvt.DepartmentName, dkctvt.SectionName, dkctvt.isManager
		--(case when hp.H_date is not null then 1 else 0 end) as isHoliday
		from
		udf_BangThoiGian(@fromdate,@todate) td
		left join
		udf_BangDangKyCaTheoViTri(@fromdate,@todate,@fact,@Dept,@Sect,@Team,@Pos,@PosC,@Emp) dkctvt
		on td.Date_>=dkctvt.ComStartedDate and (td.Date_<dkctvt.TernimationDate or dkctvt.TernimationDate is null)
		left join
		(
			select shifts.*,cx.TimeDate,cx.Employee_ID,cx.ExtraHours,cx.GioTCTruoc from
			udf_TraVeDangKyCaDuaVaoCaXoay(@fromdate,@todate,@fact,@Dept,@Sect,@Team,@Pos,@PosC,null) as cx
			left join
			HR_Shifts shifts
			on cx.ShiftName=shifts.ShiftName
		) cx
		on td.Date_=cx.TimeDate and dkctvt.Employee_ID=cx.Employee_ID
		left join
		(
			select shifts.*,erts.TimeDate,erts.Employee_ID from
			(select * from HR_EmpRegisTimeSheet where TimeDate between @fromdate and @todate) erts
			left join
			HR_Shifts shifts
			on erts.ShiftName=shifts.ShiftName
		) erts
		on td.Date_=erts.TimeDate and dkctvt.Employee_ID=erts.Employee_ID
		left join
		udf_DanhSachHuongCheDo(@fromdate,@todate,@SoNgaySauKhiMangBauDuocHuongThaiSan) cdo
		on dkctvt.Employee_ID=cdo.Employee_ID and (td.Date_ between cdo.babyFromdate and cdo.babyTodate or td.Date_ between cdo.pregFromdate and cdo.pregTodate or td.Date_ between cdo.DisableFromDate and cdo.DisableToDate or td.Date_ between cdo.OldFromdate and cdo.OldTodate)-- or td.Date_ between cdo.Duoi18Fromdate and cdo.Duoi18Todate)
		left join
		HR_EmpRegisParameter erp
		on dkctvt.Employee_ID = erp.Employee_ID and td.Date_ between erp.Fromdate and erp.Todate and erp.Parameter = 'HuongCheDo'
		where dkctvt.Employee_ID is not null

		--xóa ca ngày lễ và chủ nhật không có đk ca thêm vào ngày 18/2/2021
		--delete @rtnTable 
		--From @rtnTable rt
		--left join
		--SmartBooks_HolidaysPlan hp
		--on rt.AccessDate=hp.H_date
		--left join
		--HR_MaxOvertime mot
		--on rt.Employee_ID=mot.Employee_ID and rt.AccessDate=mot.workingdate
		--where (hp.H_date is not null or datename(dw,rt.AccessDate)='Sunday') and mot.Employee_ID is null
		--end

		update rtn
		set rtn.ShiftName = '02-Shift2'
		from @rtnTable rtn
		left join
		SmartBooks_HolidaysPlan hp
		on rtn.AccessDate = hp.H_date - 1 and hp.TypeOfLeave = '50'
		where rtn.ShiftName = '83-Shift3' and (DATENAME(dw,rtn.AccessDate) = 'Saturday' or hp.H_date is not null)

		delete t1 from
		@rtnTable t1
		inner join
		@rtnTable t2
		on t1.Employee_ID=t2.Employee_ID and t2.[AccessDate]=t1.[AccessDate]+1
		where t1.ShiftName like '%shift3' and (t2.ShiftName like '%shift0' or t2.ShiftName like '%shift1')
	RETURN

END

GO
