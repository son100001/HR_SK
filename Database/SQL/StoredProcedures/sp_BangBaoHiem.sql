--exec [dbo].[sp_BangBaoHiem] null,null,2,'VN',N'',N'',N'',N'',N'','',N'17040042'
--exec [dbo].[sp_BangBaoHiem] 3,2022,4
CREATE PROCEDURE [dbo].[sp_BangBaoHiem]
	-- Add the parameters for the stored procedure here
	@Month int,
	@Year int,
	@TypeOfReport int=1,
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@emp nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @NgayDauThang datetime, @NgayCuoiThang datetime
	set @NgayDauThang=cast(@Year as varchar)+'-'+cast(@Month as varchar)+'-1'
	set @NgayCuoiThang=DATEADD(MONTH,1,@NgayDauThang)-1
	if @TypeOfReport=1 begin -- all theo tháng
		select
		empl.Position
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Employee_ID
		,idi.*
		from
		HR_IncreaseDecreaseInsurance idi
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,getdate()) empl
		on idi.Employee_ID=empl.Employee_ID
		where idi.Month_=@Month and idi.Year_=@Year and empl.Employee_ID is not null
	end else if @TypeOfReport=2 begin -- all
		select
		empl.Position
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Employee_ID
		,idi.*
		from
		HR_IncreaseDecreaseInsurance idi
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@NgayCuoiThang,getdate())) empl
		on idi.Employee_ID=empl.Employee_ID
		where empl.Employee_ID is not null 
	end else if @TypeOfReport in (3,4) begin --Mẫu D02 TM Tăng mới
		select empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,soBH.BookCode,idi.LoaiKhaiBao,idi.PhuongAn,empl.PositionName
			,case when idi.Month_<10 then '0' else '' end + cast(idi.Month_ as varchar)+'/'+cast(idi.Year_ as varchar) as TuThang
			,case when idi.Month_<10 then '0' else '' end + cast(idi.Month_ as varchar)+'/'+cast(idi.Year_ as varchar) as DenThang
			,case when @TypeOfReport=3 then N'Tăng lao động' else N'GIẢM LAO ĐỘNG' end as GhiChu,'32%' as TyLeDong
			,case when soBH.BookCode is null then 0 else 1 end as DaCoSo
			,empl.ID_number
			,empl.BirthDate,case when empl.Sex='Male' then 1 else 0 end as GioiTinh
			,empl.Nationality,empl.Nation
			,pxKS.MaTinhThanhPho as ttpks,pxKS.MaQuanHuyen as qhks,pxKS.MaPhuongXa as pxks
			,pxTT.MaTinhThanhPho as ttptt,pxTT.MaQuanHuyen as qhtt,pxTT.MaPhuongXa as pxtt
			,empl.Address_Permanent,empl.TenChuHo
			,N'Tăng lao động' as NoiDungYeuCauThayDoi
		from
		HR_IncreaseDecreaseInsurance idi
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,@NgayCuoiThang) empl
		on idi.Employee_ID=empl.Employee_ID
		left join
		HR_Insurance soBH
		on idi.Employee_ID=soBH.Employee_ID
		left join
		HR_TinhThanhPho ttpKS
		on [dbo].[non_unicode_convert](REPLACE(REPLACE(REPLACE(REPLACE([dbo].[udf_LayQuanHuyen](empl.BirthPlace,4),N'Tỉnh',''),N'Thành phố',''),'TP.',''),' ',''))=[dbo].[non_unicode_convert](REPLACE(REPLACE(REPLACE(REPLACE(ttpKS.TenTinhThanhPho,N'Tỉnh',''),N'Thành phố',''),'TP.',''),' ',''))
		left join
		HR_TinhThanhPho ttpTT
		on [dbo].[non_unicode_convert](REPLACE(REPLACE(REPLACE(REPLACE([dbo].[udf_LayQuanHuyen](empl.Address_Permanent,4),N'Tỉnh',''),N'Thành phố',''),'TP.',''),' ',''))=[dbo].[non_unicode_convert](REPLACE(REPLACE(REPLACE(REPLACE(ttpTT.TenTinhThanhPho,N'Tỉnh',''),N'Thành phố',''),'TP.',''),' ',''))
		left join
		HR_PhuongXa pxKS
		on [dbo].[non_unicode_convert](REPLACE(REPLACE(REPLACE(REPLACE([dbo].[udf_LayQuanHuyen](empl.BirthPlace,2),N'Xã',''),N'Thị trấn',''),'Phường',''),' ',''))=[dbo].[non_unicode_convert](REPLACE(REPLACE(REPLACE(REPLACE(pxKS.TenPhuongXa,N'Xã',''),N'Thị trấn',''),'Phường',''),' ',''))
			and pxKS.MaTinhThanhPho=ttpks.MaTinhThanhPho
		left join
		HR_PhuongXa pxTT
		on [dbo].[non_unicode_convert](REPLACE(REPLACE(REPLACE(REPLACE([dbo].[udf_LayQuanHuyen](empl.Address_Permanent,2),N'Xã',''),N'Thị trấn',''),'Phường',''),' ',''))=[dbo].[non_unicode_convert](REPLACE(REPLACE(REPLACE(REPLACE(pxTT.TenPhuongXa,N'Xã',''),N'Thị trấn',''),'Phường',''),' ',''))
			and pxTT.MaTinhThanhPho=ttpTT.MaTinhThanhPho
		where empl.Employee_ID is not null and idi.Month_=@Month and idi.Year_=@Year and case when @TypeOfReport=3 then idi.PhuongAn else idi.LoaiKhaiBao end=case when @TypeOfReport=3 then 'TM' else '3' end
	end
END



GO
