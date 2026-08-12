CREATE PROCEDURE [dbo].[usp_HR_Transfer_PositionID] 
	-- Add the parameters for the stored procedure here
	--exec [dbo].[usp_HR_Transfer_PositionID] '190','2019-7-7','270',N'hà hà','admin'
	--exec [dbo].[usp_HR_Transfer_PositionID] '190','2019-7-5','111',N'hà hà','admin'
	@Employee_ID nvarchar(50),
	@EffectiveDate datetime,
	@Position_ID nvarchar(50),
	@Remark nvarchar(max),
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255),@OLDPosition_ID nvarchar(50),@OldEffectiveDate datetime
	--select @Block_Date=Block_Date from HR_Khoa where [TableName]='HR_Transfer_PositionID' and Block_User=@UserName
	if isnull(@Position_ID,'')<>'' begin
		set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@EffectiveDate,@UserName,'HR_Transfer_PositionID')
		if @ThongBao='' begin
			select @OldEffectiveDate=max(EffectiveDate) from HR_Transfer where Employee_ID=@Employee_ID and TypeOfTransfer='Position_ID'
			if (@OldEffectiveDate is null or @EffectiveDate>=@OldEffectiveDate) begin
				select top (1) @OLDPosition_ID=TransferCode from HR_Transfer where Employee_ID=@Employee_ID and TypeOfTransfer='Position_ID' order by EffectiveDate desc
				if ISNULL(@OLDPosition_ID,'')<>@Position_ID begin
					if exists(select Employee_ID from HR_Transfer where TypeOfTransfer='Position_ID' and Employee_ID=@Employee_ID and EffectiveDate=@EffectiveDate) begin
						update HR_Transfer set TransferCode=@Position_ID,AssignType='POS',Remark=@Remark,UserName=@UserName,InsertDate=GETDATE() where TypeOfTransfer='Position_ID' and Employee_ID=@Employee_ID and EffectiveDate=@EffectiveDate
					end else begin
						insert into HR_Transfer (Employee_ID,TransferCode,TypeOfTransfer,EffectiveDate,AssignType,Remark,UserName,InsertDate)
							values(@Employee_ID,@Position_ID,'Position_ID',@EffectiveDate,'POS',@Remark,@UserName,GETDATE())
					end
				end else begin
					set @ThongBao=N'Vitricuvamoigiongnhau'
				end
			end else begin
				set @ThongBao=N'Ngaychuyenvitrikhonghople'
			end
		end
	end else begin
		set @ThongBao=N'Dulieukhonghople'
	end
	
	select isnull(@ThongBao,'') as ThongBao
END




GO
