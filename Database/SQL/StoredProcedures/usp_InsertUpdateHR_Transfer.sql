CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_Transfer] 
	-- Add the parameters for the stored procedure here
	--exec usp_InsertUpdateHR_Transfer 0,'191211','24','2019-07-24','Position_ID','POS',N'ghi chú','2019-07-24','admin'
	--exec usp_InsertUpdateHR_Transfer null,'19001038','123','2019-07-24','RFID','RFID',N'ghi chus','2019-07-24 17:57:22','admin'

	@ID int,
	@Employee_ID nvarchar(50),
	@TransferCode nvarchar(50),
	@EffectiveDate datetime,
	@TypeOfTransfer varchar(50),
	@AssignType varchar(50),
	@Remark nvarchar(max),
	@InsertDate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255),@OLDTransferCode nvarchar(50),@OldEffectiveDate datetime
	set @ThongBao=''
	if isnull(@TransferCode,'')<>'' begin
		if @TypeOfTransfer='Position_ID' begin
			set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@EffectiveDate,@UserName,'HR_Transfer')
		end
		if @ThongBao='' begin
			select @OldEffectiveDate=max(EffectiveDate) from HR_Transfer where Employee_ID=@Employee_ID and TypeOfTransfer=@TypeOfTransfer
			if (@OldEffectiveDate is null or @EffectiveDate>=@OldEffectiveDate) begin
				select top (1) @OLDTransferCode=TransferCode from HR_Transfer where Employee_ID=@Employee_ID and TypeOfTransfer=@TypeOfTransfer order by EffectiveDate desc
				if ISNULL(@OLDTransferCode,'')<>@TransferCode begin
					if exists(select Employee_ID from HR_Transfer where TypeOfTransfer=@TypeOfTransfer and Employee_ID=@Employee_ID and EffectiveDate=@EffectiveDate) begin
						update HR_Transfer set TransferCode=@TransferCode,AssignType=@AssignType,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE() where TypeOfTransfer=@TypeOfTransfer and Employee_ID=@Employee_ID and EffectiveDate=@EffectiveDate
					end else begin
						insert into HR_Transfer (Employee_ID,TransferCode,TypeOfTransfer,EffectiveDate,AssignType,Remark,UserName,InsertDate)
							values(@Employee_ID,@TransferCode,@TypeOfTransfer,@EffectiveDate,@AssignType,@Remark,@UserName,GETDATE())
					end
				end else begin
					set @ThongBao=N'Dulieukhonghople'
				end
			end else begin
				set @ThongBao=N'Dulieukhonghople'
			end
		end
	end /*else begin
		set @ThongBao=N'Dulieukhonghople'
	end*/
	
	select isnull(@ThongBao,'') as ThongBao
END




GO
