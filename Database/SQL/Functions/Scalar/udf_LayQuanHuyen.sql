-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
--select [dbo].[udf_LayQuanHuyen](N'A-B-C-D','4')
CREATE FUNCTION [dbo].[udf_LayQuanHuyen]
(
	-- Add the parameters for the function here
	@Address nvarchar(256),
	@LoaiLay int
)
RETURNS nvarchar(50)
AS
BEGIN
	DECLARE @XaPhuong NVARCHAR(50),@QuanHuyen NVARCHAR(50),@TinhTP NVARCHAR(50),@ThonXom NVARCHAR(50)
    DECLARE cur_ cursor scroll FOR
    SELECT Data FROM Split(@Address, '-')
    OPEN cur_;
    FETCH ABSOLUTE 1 FROM cur_ into @ThonXom;
    FETCH ABSOLUTE 2 FROM cur_ into @XaPhuong;
	FETCH ABSOLUTE 3 FROM cur_ into @QuanHuyen;
	FETCH ABSOLUTE 4 FROM cur_ into @TinhTP;
    CLOSE cur_;
    DEALLOCATE cur_;
    return --(case when @ThonXom is null then '0tx' else @ThonXom end)+'-'+(case when @XaPhuong is null then '0xp' else @XaPhuong end)+'-'+(case when @QuanHuyen is null then '0qh' else @QuanHuyen end)+'-'+(case when @TinhTP is null then '0ttp' else @TinhTP end)
	(case when @LoaiLay=4 then 
							(case when @TinhTP is null then (case when @QuanHuyen is null then (case when @XaPhuong is null then @ThonXom else @XaPhuong end) else @QuanHuyen end) 
								else @TinhTP 
							end)
	else (case when @LoaiLay=3 then
								(case when @TinhTP is null then (case when @QuanHuyen is null then (case when @XaPhuong is null then null else @ThonXom end) else @XaPhuong end) else @QuanHuyen end)
					else (case when @LoaiLay=2 then 
												(case when @TinhTP is null then (case when @QuanHuyen is null then null else @ThonXom end) else @XaPhuong end)
								else (case when @TinhTP is null then null else @ThonXom end)
	end)end)end)
	

END




GO
