CREATE PROCEDURE [dbo].[sp_XuLyDuLieuQuetKhachHang]
	-- Add the parameters for the stored procedure here
	--exec  [dbo].[sp_XuLyDuLieuQuetKhachHang] '2021-1-1','2021-1-15','admin',null,null,null,null,null,null,null
	--select * from HR_DuLieuQuetKhachHang
	@fromdate datetime,
	@todate datetime,
	@UserName nvarchar(50),
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Emp nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan int,@ThongBao nvarchar(max),@Employee_ID nvarchar(50),@WorkingDate datetime,@TimeIn datetime,@TimeOut datetime,@RealTimeIn datetime,@RealTimeOut datetime,@CongTay bit
		,@fromtime datetime,@totime datetime,@RestTimeFrom datetime,@RestTimeTo datetime,@wt float,@EarlyOut float,@SoPhutChuan int,@CheDo bit
		,@OT_NB float, @OT_KH float
	delete HR_DuLieuQuetKhachHang where workingdate between @fromdate and @todate and Employee_ID in (select Employee_ID from [dbo].[udf_EmployeeFilter]('VN',@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate))
	select @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan=[Value] from [dbo].[SetUp] where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
	set @ThongBao=''
	if exists(select TableName from HR_Khoa where TableName='HR_WTDaily' and Block_Date>=@fromdate and Block_User=@UserName) begin
		set @ThongBao=@ThongBao+N'Dữ liệu đã bị khóa;'
	end
	if @ThongBao='' begin
		--nhap du lieu quet vao

		DECLARE cur CURSOR LOCAL FOR
		select CongNB.Employee_ID,CongNB.Ngay,tito.TimeIn,tito.RealTimeIn,tito.[TimeOut],tito.RealTimeOut
		,(case when CongTay.Employee_ID is not null then 1 else 0 end)
			,s.fromtime
			,(case when dkc.CheDo=1 then dateadd(hour,-1,s.totime) else s.ToTime end) as totime
			,s.RestTimeFrom,s.RestTimeTo,CongNB.wt,tito.EarlyOut
			,isnull(CongNB.OTKH,0) as OT_KH
			,isnull(CongNB.OTNB,0) as OT_NB
			,dkc.CheDo
		from
		[dbo].[udf_CongHC_TC](@fromdate,@todate,0) as CongNB--giờ hành chính
		left join
		HR_TimeIn_TimeOut tito
		on tito.Employee_ID=CongNB.Employee_ID and tito.OT_date=CongNB.Ngay
		left join
		[dbo].[udf_DangKyCa](@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@Emp) dkc
		on CongNB.Employee_ID=dkc.Employee_ID and CongNB.Ngay=dkc.accessdate
		left join
		HR_Shifts s
		on dkc.ShiftName=s.ShiftName
		left join
		(select distinct employee_id,Ngay from HR_WTDAILY where insertsource='NhapTay' and ngay between @fromdate and @todate) CongTay
		on CongNB.employee_id=congtay.employee_id and CongNB.Ngay=CongTay.Ngay
		where CongNB.Employee_ID in (select Employee_ID from [dbo].[udf_EmployeeFilter]('VN',@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate))
		OPEN  cur
		FETCH NEXT FROM cur INTO @Employee_ID,@WorkingDate,@TimeIn,@RealTimeIn,@TimeOut,@RealTimeOut,@CongTay,@fromtime,@totime,@RestTimeFrom,@RestTimeTo,@wt,@EarlyOut,@OT_KH,@OT_NB,@CheDo
		WHILE @@FETCH_STATUS = 0
		BEGIN
			set @SoPhutChuan=RAND()*(15-0)+0
			set @TimeIn=(case when @RealTimeIn is null or @CongTay=1 then 
							dateadd(minute,-@SoPhutChuan,[dbo].[udf_TraVeDuLieuQuetVaoDuaVaoGioCong](@WorkingDate,@fromtime,@totime,@RestTimeFrom,@RestTimeTo,@wt))
						else
							dateadd(minute,(case when isnull(@wt,0)>=0 then isnull(@EarlyOut,0)*60 else 0 end)
											,(case when @RealTimeIn>=DATEADD(MINUTE,-14,@TimeIn) then @RealTimeIn
												else DATEADD(minute,-@SoPhutChuan,@TimeIn)
											end)
							)
						end)
			
			set @SoPhutChuan=RAND()*(15-0)+0
			if @OT_KH=@OT_NB begin
				set @TimeOut=(case
					when @TimeOut is null then DATEADD(MINUTE,@SoPhutChuan,DATEADD(MINUTE,isnull(@OT_KH,0)*60,[dbo].[GhepGioVaoNgay](@workingdate,@ToTime)))
					 when @RealTimeOut<=DATEADD(MINUTE,14,@TimeOut) then @RealTimeOut
					else DATEADD(minute,-@SoPhutChuan,@TimeOut)
				end)
			end else if @OT_KH<>@OT_NB begin
				set @TimeOut=DATEADD(MINUTE,@SoPhutChuan,DATEADD(MINUTE,isnull(@OT_KH,0)*60,[dbo].[GhepGioVaoNgay](@workingdate,@ToTime)))
			end

			insert into HR_DuLieuQuetKhachHang (Employee_ID,workingdate,TimeIn,[TimeOut],UserName,InsertDate)
			values(@Employee_ID,@WorkingDate
			,@TimeIn,@TimeOut,@UserName,GETDATE())
		FETCH NEXT FROM cur INTO @Employee_ID,@WorkingDate,@TimeIn,@RealTimeIn,@TimeOut,@RealTimeOut,@CongTay,@fromtime,@totime,@RestTimeFrom,@RestTimeTo,@wt,@EarlyOut,@OT_KH,@OT_NB,@CheDo
		END
		CLOSE cur
		DEALLOCATE cur

		set @ThongBao=N'Thực hiện kết thúc!'
	end
	select @ThongBao as ThongBao
END


GO
