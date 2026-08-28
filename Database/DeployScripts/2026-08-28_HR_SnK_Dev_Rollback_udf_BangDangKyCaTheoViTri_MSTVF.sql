/*
    ROLLBACK cho 2026-08-28_HR_SnK_Dev_Optimize_udf_BangDangKyCaTheoViTri.sql
    Khôi phục dbo.udf_BangDangKyCaTheoViTri về đúng bản multi-statement TVF như trước ngày 2026-08-28
    trên HR_SnK_Dev. Nội dung dưới đây lấy nguyên văn từ sys.sql_modules ngày 2026-08-28.
*/

IF OBJECT_ID('dbo.udf_BangDangKyCaTheoViTri', 'IF') IS NOT NULL DROP FUNCTION [dbo].[udf_BangDangKyCaTheoViTri];
IF OBJECT_ID('dbo.udf_BangDangKyCaTheoViTri', 'TF') IS NOT NULL DROP FUNCTION [dbo].[udf_BangDangKyCaTheoViTri];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
--select * from [dbo].[udf_BangDangKyCaTheoViTri]('2025-09-01','2025-09-30',null,null,null,null,null,null,null)
CREATE FUNCTION [dbo].[udf_BangDangKyCaTheoViTri]
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime,
	@fact as nvarchar(50)=null,
	@dept as nvarchar(50)=null,
	@sect as nvarchar(50)=null,
	@team as nvarchar(50)=null,
	@pos as nvarchar(50)=null,
	@posc as nvarchar(50)=null,
	@Employee_ID_ nvarchar(50)=null
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),ShiftName nvarchar(50),ComStartedDate datetime,TernimationDate datetime
	, FactoryName nvarchar(100), DepartmentName nvarchar(200), SectionName nvarchar(200), isManager bit, primary key (Employee_ID)
)
AS
BEGIN
	-- Add the SELECT statement with parameter references here
	insert into @rtnTable
	select [Employee_ID], su.[Value]
		/*(case when pc.CaMacDinh is not null
				then pc.CaMacDinh
				else (case when p.CaMacDinh is not null then p.CaMacDinh
							else (case when t.CaMacDinh is not null
										then t.CaMacDinh
										else (case when s.CaMacDinh is not null
													then s.CaMacDinh
													else (case when d.CaMacDinh is not null
																then d.CaMacDinh
																else su.value
															end)
												end)
									/*end)
						end)*/
		end) as ShiftName*/,empl.ComStartedDate,empl.TernimationDate, empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.isManager
		from
		udf_EmployeeFilter('VN',@fact,@dept,@sect,@team,@pos,@posc,@Employee_ID_,@todate) empl
		--left join
		--HR_Factory f
		--on empl.Factory_ID=f.Factory_ID
		--left join
		--dbo.SmartBooks_Department d
		--on empl.DepartmentCode COLLATE DATABASE_DEFAULT = d.Factory_ID+'_'+d.DepartmentCode
		--left join
		--dbo.SmartBooks_Section s
		--on empl.SectionCode COLLATE DATABASE_DEFAULT = s.Factory_ID+'_'+s.DepartmentCode+'_'+s.SectionCode
		--left join
		--dbo.SmartBooks_Team t
		--on empl.TeamCode COLLATE DATABASE_DEFAULT = t.Factory_ID+'_'+t.DepartmentCode+'_'+t.SectionCode+'_'+t.TeamCode
		--left join
		--dbo.SmartBooks_Position p
		--on empl.Position_ID COLLATE DATABASE_DEFAULT = p.Position_ID			
		--left join
		--dbo.SmartBooks_PositionCategory pc
		--on empl.PositionCategory_ID COLLATE DATABASE_DEFAULT = pc.PositionCategory_ID
		left join
		SetUp su
		on su.ID='CaMacDinh'
		--left join
		--HR_Shifts shifts
		--on 
		--(case when pc.CaMacDinh is not null
		--		then pc.CaMacDinh
		--		else (case when p.CaMacDinh is not null then p.CaMacDinh
		--					else (case when t.CaMacDinh is not null
		--								then t.CaMacDinh
		--								else (case when s.CaMacDinh is not null
		--											then s.CaMacDinh
		--											else (case when d.CaMacDinh is not null
		--														then d.CaMacDinh
		--														else null
		--													end)
		--										end)
		--							end)
		--				end)
		--end)=shifts.ShiftName

		where empl.ComStartedDate<=@todate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)

	-- Return the result of the function
	RETURN

END





GO
