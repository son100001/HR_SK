/*
    Mục đích: dbo.udf_BangDangKyCaTheoViTri chỉ là 1 câu SELECT duy nhất bọc trong multi-statement TVF
    (Pattern C1 - "chỉ đổi vỏ, không đổi logic") -> convert sang inline TVF để cardinality estimate
    chính xác hơn khi được gọi lồng bên trong dbo.udf_DangKyCa.
    Áp dụng cho: HR_SnK_Dev_260811. Điều tra khi tối ưu dbo.sp_TinhCong (thử nghiệm sâu hơn theo yêu cầu
    người dùng, chấp nhận rủi ro vì đây là DB test).
    Tham khảo: markdowns/SQL_PERFORMANCE_PLAYBOOK.md mục A8, markdowns/SQL_PERFORMANCE_HISTORY.md.
    Verify: output so sánh trước/sau khớp 100% (1 dòng, cùng giá trị) cho nhân viên test.
    Kết quả đo: KHÔNG có cải thiện rõ rệt/đo được khi tách riêng (trong biên độ nhiễu của server), nhưng
    không gây regression trên tổng thể sp_TinhCong (đã đo full run trước/sau, checksum HR_TimeIn_TimeOut
    khớp 100%) - giữ lại vì an toàn & đúng hướng (cardinality chính xác hơn), không có bằng chứng cần
    rollback.
    Idempotent: DROP + CREATE lại (đổi loại object, không ALTER được).
*/
IF OBJECT_ID('dbo.udf_BangDangKyCaTheoViTri', 'IF') IS NOT NULL DROP FUNCTION [dbo].[udf_BangDangKyCaTheoViTri];
IF OBJECT_ID('dbo.udf_BangDangKyCaTheoViTri', 'TF') IS NOT NULL DROP FUNCTION [dbo].[udf_BangDangKyCaTheoViTri];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE FUNCTION [dbo].[udf_BangDangKyCaTheoViTri]
(
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
