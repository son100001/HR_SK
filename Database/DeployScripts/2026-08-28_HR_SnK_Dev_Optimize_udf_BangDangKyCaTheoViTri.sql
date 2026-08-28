/*
    Mục đích: dbo.udf_BangDangKyCaTheoViTri chỉ là 1 câu SELECT duy nhất bọc trong multi-statement TVF
    (Pattern C1 của playbook — "chỉ đổi vỏ, không đổi logic") -> convert sang inline TVF để cardinality
    estimate chính xác hơn khi được gọi lồng bên trong dbo.udf_DangKyCa.
    Áp dụng cho: HR_SnK_Dev (113.161.180.44). Ngày: 2026-08-28.
    Tham khảo: markdowns/SQL_PERFORMANCE_PLAYBOOK.md mục A8 + C1, markdowns/SQL_PERFORMANCE_HISTORY.md.

    Thân hàm giữ nguyên 100% logic của bản MSTVF hiện có trên HR_SnK_Dev (chỉ bỏ phần comment code chết
    về CaMacDinh theo vị trí — vốn đã bị comment sẵn từ trước, không ảnh hưởng kết quả).

    Verify (2026-08-28, chạy trên chính HR_SnK_Dev): so cũ vs mới bằng EXCEPT 2 chiều trên 4 bộ tham số
    (không lọc / lọc SK2 / lọc FACTORY A / kỳ 2025-09) — 3.320 dòng, lệch 0 dòng cả 2 chiều.
    Bản MSTVF cũ khai báo PRIMARY KEY (Employee_ID) trên bảng trả về; inline TVF không có ràng buộc đó,
    nên đã kiểm tra riêng: bản mới KHÔNG sinh dòng trùng Employee_ID nào (0 nhóm trùng) -> an toàn.

    Đo được: đứng riêng KHÔNG nhanh hơn (cũ ~1.534 ms, mới ~1.631 ms — nằm trong biên độ nhiễu của
    server production đang có người dùng thật). Xem SQL_PERFORMANCE_HISTORY.md để biết kết quả đo
    trong ngữ cảnh caller thật (dbo.udf_DangKyCa) và quyết định giữ/rollback cuối cùng.

    Idempotent: DROP + CREATE lại (đổi loại object nên không ALTER được).
    Rollback: 2026-08-28_HR_SnK_Dev_Rollback_udf_BangDangKyCaTheoViTri_MSTVF.sql
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
RETURNS TABLE
AS
RETURN
(
	select
		empl.[Employee_ID] as Employee_ID,
		su.[Value] as ShiftName,
		empl.ComStartedDate as ComStartedDate,
		empl.TernimationDate as TernimationDate,
		empl.FactoryName as FactoryName,
		empl.DepartmentName as DepartmentName,
		empl.SectionName as SectionName,
		empl.isManager as isManager
	from
	udf_EmployeeFilter('VN',@fact,@dept,@sect,@team,@pos,@posc,@Employee_ID_,@todate) empl
	left join
	SetUp su
	on su.ID='CaMacDinh'
	where empl.ComStartedDate<=@todate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)
);
GO
