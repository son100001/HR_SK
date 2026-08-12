CREATE FUNCTION [dbo].[udf_TinhCong_QuetVao]
(
	-- Add the parameters for the function here
	-- select * from [dbo].[udf_TinhCong]('2021-2-1','2021-2-17',181,null,null,null,null,null,null,'CG00354')

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
RETURNS  @rtnTinhCong_QuetVao TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),[AccessDate] datetime,[TimeDate] datetime,AccessTime datetime,InOutStatus varchar(10),[ShiftName] nvarchar(50),maxovertime float,isActualOT_After bit,maxovertimeB float,maxovertimeHol float,maxovertimeLunch float,[CheDo] int,HolSunTypeOfOT varchar(20),primary key ([Employee_ID],[AccessTime])
)
AS
BEGIN
	
	declare @tabTam as table ([Employee_ID] nvarchar(50),[AccessDate] datetime,[TimeDate] datetime,AccessTime datetime,InOutStatus varchar(10),[ShiftName] nvarchar(50),maxovertime float,isActualOT_After bit,maxovertimeB float,maxovertimeHol float,maxovertimeLunch float,[CheDo] int,HolSunTypeOfOT varchar(20), ChoPhepMuonSoPhut int, RowNumber int,primary key (Employee_ID,[AccessDate],RowNumber))

	insert into @tabTam
	SELECT tinhcong.* 
	,ROW_NUMBER() OVER (PARTITION BY Employee_ID,TimeDate,ShiftName,maxovertime ORDER BY Employee_ID, AccessTime asc) AS RowNum
	from udf_TinhCong(@fromdate,@todate,@SoNgaySauKhiMangBauDuocHuongThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@Employee_ID_)tinhcong

	insert into @rtnTinhCong_QuetVao select [Employee_ID],[AccessDate],[TimeDate],AccessTime,InOutStatus,[ShiftName],maxovertime,isActualOT_After,maxovertimeB,maxovertimeHol,maxovertimeLunch,[CheDo],HolSunTypeOfOT from @tabTam where RowNumber=1

	-- Return the result of the function
	RETURN
END



GO
