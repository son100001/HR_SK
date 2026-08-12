CREATE FUNCTION [dbo].[udf_TinhCong_QuetRa]
(
@fromdate datetime,
@todate datetime,
@SoNgaySauKhiMangBauDuocHuongThaiSan int,
@fact nvarchar(50)=null,
@dept nvarchar(50)=null,
@sect nvarchar(50)=null,
@team nvarchar(50)=null,
@pos nvarchar(50)=null,
@posc nvarchar(50)=null,
@Employee_ID_ nvarchar(50)=null
)
RETURNS table      
AS                
RETURN (
	WITH tabQuetRa
	AS
	(
	SELECT tinhcong.* 
	,ROW_NUMBER() OVER (PARTITION BY Employee_ID,TimeDate,ShiftName,CheDo,maxovertime ORDER BY Employee_ID, AccessTime desc) AS RowNum
	from udf_TinhCong(@fromdate,@todate,@SoNgaySauKhiMangBauDuocHuongThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@Employee_ID_)tinhcong-- where Employee_ID=isnull(@Employee_ID,Employee_ID)
	)
	SELECT * FROM tabQuetRa WHERE RowNum = 1
)




GO
