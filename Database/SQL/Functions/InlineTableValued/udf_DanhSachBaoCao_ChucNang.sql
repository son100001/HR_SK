CREATE FUNCTION [dbo].[udf_DanhSachBaoCao_ChucNang] 
(	
	-- Add the parameters for the function here
	@ReportFather varchar(50),
	@TabKey nvarchar(50),
	@UserName nvarchar(50)
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select * from HR_Report
	where isnull(NotUsing,0)=0 and ReportFather=@ReportFather
		and case when @tabkey is null then '' else TabKey end=isnull(@TabKey,'')
		and ReportCode not in (select ReportCode from HR_ReportPermission WHERE USER_=@USERNAME)
)




GO
