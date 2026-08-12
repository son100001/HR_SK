CREATE PROCEDURE [dbo].[sp_InsertUpdateHR_MaxOvertime]
	--exec [dbo].[sp_InsertUpdateHR_MaxOvertime] null, '19000473','2019-5-4',4,1,null,'00-Shift0','',null,'admin'
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@workingdate datetime,
	@maxovertime float,
	@TypeOfOT varchar(20),
	@NgayNghiBu datetime,
	@ShiftName nvarchar(50),
	@PrintStatus bit,
	@isActualOT bit,
	@Remark nvarchar(max),
	@InsertDate datetime=null,
	@UserName [nvarchar](50),
	@UpdateDate [datetime]=null,
	@UpdateUserName [nvarchar](50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @SoNgayMangThaiDuocHuongCheDoThaiSan as int, @ThongBao nvarchar(max)--,@mot as float,@fromtime datetime,@totime datetime,@WeekOT as float,@WeekWT as float,@MonthOT float,@YearOT float, @DauTuan datetime, @CuoiTuan datetime,@DauThang datetime, @CuoiThang datetime,@DauNam datetime, @CuoiNam datetime,@Starteddate datetime
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@workingdate,@UserName,'HR_MaxoverTime')
	select @SoNgayMangThaiDuocHuongCheDoThaiSan=[Value] from setup where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
	if @TypeOfOT=null begin
		set @TypeOfOT='1'
	end
	select @ShiftName=shiftname from hr_shifts where shiftname=@shiftname or [ShiftSign]=@shiftname
	if exists(select * from HR_EmployeeRegisMaternityLeave where Employee_ID=@Employee_ID and @NgayNghiBu between Fromdate and ToDate) and @TypeOfOT=4 begin
		set @ThongBao=N'Ngaynghibutrungvoiphepdadangky'
	end
	if exists (select Employee_ID from HR_EmployeeRegisMaternityLeave where Employee_ID=@Employee_ID and @workingdate>=Fromdate and (@workingdate<=ToDate or ToDate is null) and LeaveType_ID<>'28')
	BEGIN
		set @ThongBao=N'Dadangkynghiphep'
	END
	/*if exists (select Employee_ID from udf_DanhSachHuongCheDo(@workingdate,@workingdate,@SoNgayMangThaiDuocHuongCheDoThaiSan) where (@workingdate between babyFromdate and babyToDate or @workingdate between pregFromdate and pregTodate or @workingdate between DisableFromDate and DisableToDate or @workingdate between OldFromdate and OldTodate or @workingdate between Duoi18Fromdate and Duoi18Todate) and Employee_ID=@Employee_ID)
	BEGIN
		set @ThongBao=N'Dangtrongchedokhongduoctangca'
	END*/--Thai sản
	if isnull(@ThongBao,'')='' begin
		if @maxovertime is null begin
			delete HR_MaxOvertime where (Employee_ID=@Employee_ID and workingdate=@workingdate and TypeOfOT=@TypeOfOT) or ID=isnull(@ID,0)
		end else begin
			if exists(select * from HR_MaxOvertime where (Employee_ID=@Employee_ID and workingdate=@workingdate and TypeOfOT=@TypeOfOT) or ID=isnull(@ID,0))
			BEGIN
				update HR_MaxOvertime set maxovertime=@maxovertime,PrintStatus=@PrintStatus,isActualOT=@isActualOT, Remark=@Remark, TypeOfOT=@TypeOfOT, NgayNghiBu=@NgayNghiBu, ShiftName=@ShiftName
					,InsertDate=GETDATE(),UserName=@UserName
				  where (Employee_ID=@Employee_ID and workingdate=@workingdate and TypeOfOT=@TypeOfOT) or ID=isnull(@ID,0)
			END ELSE BEGIN
				insert into HR_MaxOvertime ([Employee_ID],[workingdate],[maxovertime],[TypeOfOT],NgayNghiBu,ShiftName,PrintStatus,isActualOT,[Remark],[InsertDate],[UserName])
								values(@Employee_ID,@workingdate,@maxovertime,@TypeOfOT,@NgayNghiBu,@ShiftName,@PrintStatus,@isActualOT,@Remark,GETDATE(),@UserName)
			END
		end
	end
	select @ID=ID from HR_MaxOvertime where Employee_ID=@Employee_ID and workingdate=@workingdate and TypeOfOT=@TypeOfOT
	select @ThongBao as ThongBao,@ID as ID
END




GO
