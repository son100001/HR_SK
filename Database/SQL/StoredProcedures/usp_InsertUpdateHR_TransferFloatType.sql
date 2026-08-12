CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_TransferFloatType]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID [nvarchar](50),
	@Fromdate datetime,
	@todate datetime,
	@Remark [nvarchar](max),
	@InsertDate [datetime],
	@UserName [nvarchar](50),
	@VL [float],
	@HAZARD [varchar](50)
--exec [dbo].[usp_InsertUpdateHR_TransferFloatType] null,N'C10851','2025-10-14 00:00:00','2025-10-15 00:00:00',null,null,0,'2025-10-14 16:01:30',N'admin'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255)--,@Position_ID varchar(50)
	--if @TypeOfTransfer='HeavyAndToxic' begin
	--	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@EffectiveDate,@UserName,'HR_TransferFloatType_HeavyAndToxic')
	--end
	If exists (select Employee_ID from HR_TransferFloatType where Employee_ID = @Employee_ID and Fromdate <> @Fromdate and (@Fromdate between Fromdate and isnull(Todate,isnull(@todate,'2100-12-31')) or @todate between Fromdate and isnull(Todate,isnull(@todate,'2100-12-31')) ) )
		set @ThongBao = N'Công nhân đã được đăng ký làm nặng nhọc độc hại'

	if ISNULL(@thongbao,'')='' begin
		if exists(select Employee_ID from HR_TransferFloatType where (Employee_ID=@Employee_ID and Fromdate=@Fromdate) )
		begin
			update HR_TransferFloatType
			set Employee_ID=@Employee_ID,Fromdate=@Fromdate,Todate=@todate,VL=@VL,HAZARD=@HAZARD,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
			where (Employee_ID=@Employee_ID and Fromdate=@Fromdate)
		end else begin
			insert into HR_TransferFloatType
			(
				Employee_ID,
				VL,
				Fromdate,
				Todate,
				HAZARD,
				Remark,
				InsertDate,
				UserName
			)
			values(@Employee_ID,@VL,@Fromdate,@todate,@HAZARD,@Remark,GETDATE(),@UserName)
		end
	end
	--select @ID=ID from HR_TransferFloatType where Employee_ID=@Employee_ID and Fromdate=@Fromdate and Todate=@todate
	select isnull(@ThongBao,'') as ThongBao--,@ID as ID
END




GO
