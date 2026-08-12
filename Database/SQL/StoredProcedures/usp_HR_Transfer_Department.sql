CREATE PROCEDURE [dbo].[usp_HR_Transfer_Department] 
--exec usp_HR_Transfer_Department N'CG00767','2020-12-28',NULL,'J01',NULL,NULL,NULL,NULL,N'admin'
	-- Add the parameters for the stored procedure here
	@Employee_ID nvarchar(50),
	@EffectiveDate datetime,
	@Position varchar(100),
	@JobCode varchar(50),
	@ChucDanh varchar(50),
	@PositionCategory_ID varchar(50),
	@Position_ID varchar(50),
	@Remark nvarchar(max),
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @AssignType varchar(50), @ThongBao nvarchar(255),@SectionCode nvarchar(50),@OLDSectionCode nvarchar(50),@Factory_ID nvarchar(50),@OLDFactory_ID nvarchar(50),@OldDepartmentCode as varchar(50),@DepartmentCode varchar(50),@OldTeamCode as varchar(50),@OldPosition as varchar(100)
		,@OldED_P datetime,@OldED_JC datetime,@OldED_CD datetime,@OldED_LCV datetime
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@EffectiveDate,@UserName,'HR_Transfer_Position')

	if @ThongBao='' begin
		if isnull(@Position,'')<>'' begin
			select @OldED_P=max(EffectiveDate) from HR_Transfer where Employee_ID=@Employee_ID and TypeOfTransfer='Position'
			if (@OldED_P is null or @EffectiveDate>=@OldED_P) begin
				select top (1) @OldPosition=TransferCode from HR_Transfer where Employee_ID=@Employee_ID and TypeOfTransfer='Position' order by EffectiveDate desc
				if @Position<>isnull(@OldPosition,'') begin
					set @Factory_ID=''
					SELECT top 1 @Factory_ID=Data FROM Split(@Position,'_') 
					if @Factory_ID<>isnull(@OLDFactory_ID,'') begin
						set @AssignType='TRF'
					end

					if @AssignType is null begin
						set @DepartmentCode=''
						SELECT top 2 @DepartmentCode=@DepartmentCode+Data+'_' FROM Split(@Position,'_')
						set @DepartmentCode=LEFT(@DepartmentCode,len(@DepartmentCode)-1)
						if @DepartmentCode<>isnull(@OldDepartmentCode,'') begin
							set @AssignType='TRD'
						end
					end

					if @AssignType is null begin
						set @SectionCode=''
						SELECT top 3 @SectionCode=@SectionCode+Data+'_' FROM Split(@Position,'_')
						set @SectionCode=LEFT(@SectionCode,len(@SectionCode)-1)
						if @SectionCode<>isnull(@OldSectionCode,'') begin
							set @AssignType='TRS'
						end
					end
				
					if @AssignType is null begin
						set @AssignType='TRT'
					end
					if exists (select * from [dbo].[HR_Transfer] where Employee_ID=@Employee_ID and EffectiveDate=@EffectiveDate and [TypeOfTransfer]='Position') begin
						update [dbo].[HR_Transfer] set TransferCode=@Position,AssignType=@AssignType,Remark=@Remark,InsertDate=GETDATE(),UserName=@UserName where Employee_ID=@Employee_ID and EffectiveDate=@EffectiveDate and [TypeOfTransfer]='Position'
					end else begin
						insert into [dbo].[HR_Transfer]([Employee_ID],[TransferCode],[EffectiveDate],[TypeOfTransfer],[AssignType],[Remark],[InsertDate],[UserName])
						values(@Employee_ID,@Position,@EffectiveDate,'Position',@AssignType,@Remark,GETDATE(),@UserName)
					end
				end
			end else begin
				set @ThongBao=N'Ngaychuyenvitrikhonghople'
			end
		end
		--Lưu jobcode
		if isnull(@JobCode,'')<>'' begin
			select @OldED_JC=max(EffectiveDate) from HR_Transfer where Employee_ID=@Employee_ID and TypeOfTransfer='JobCode'
			if (@OldED_JC is null or @EffectiveDate>=@OldED_JC) begin
				Declare @JobCodeOld as varchar(50)
				select top (1) @JobCodeOld=TransferCode from HR_Transfer where Employee_ID=@Employee_ID and TypeOfTransfer='JobCode' order by EffectiveDate desc
				if @JobCode<>isnull(@JobCodeOld,'') begin
					if @AssignType is null begin
						set @AssignType='JOC'
					end
					if exists (select * from [dbo].[HR_Transfer] where Employee_ID=@Employee_ID and EffectiveDate=@EffectiveDate and [TypeOfTransfer]='JobCode') begin
						update [dbo].[HR_Transfer] set TransferCode=@JobCode,AssignType=@AssignType,Remark=@Remark,InsertDate=GETDATE(),UserName=@UserName where Employee_ID=@Employee_ID and EffectiveDate=@EffectiveDate and [TypeOfTransfer]='JobCode'
					end else begin
						insert into [dbo].[HR_Transfer]([Employee_ID],[TransferCode],[EffectiveDate],[TypeOfTransfer],[AssignType],[Remark],[InsertDate],[UserName])
						values(@Employee_ID,@JobCode,@EffectiveDate,'JobCode',@AssignType,@Remark,GETDATE(),@UserName)
					end
				end
			end else begin
				set @ThongBao=N'Ngaychuyenvitrikhonghople'
			end
		end
		--Lưu chucdanh
		if isnull(@ChucDanh,'')<>'' begin
			select @OldED_CD=max(EffectiveDate) from HR_Transfer where Employee_ID=@Employee_ID and TypeOfTransfer='ChucDanh'
			if (@OldED_CD is null or @EffectiveDate>=@OldED_CD) begin
				Declare @OldChucDanh varchar(50)
				select top (1) @OldChucDanh=TransferCode from HR_Transfer where Employee_ID=@Employee_ID and TypeOfTransfer='ChucDanh' order by EffectiveDate desc
				if @ChucDanh<>isnull(@OldChucDanh,'') begin
					if @AssignType is null begin
						set @AssignType='ChucDanh'
					end
					if exists (select * from [dbo].[HR_Transfer] where Employee_ID=@Employee_ID and EffectiveDate=@EffectiveDate and [TypeOfTransfer]='ChucDanh') begin
						update [dbo].[HR_Transfer] set TransferCode=@ChucDanh,AssignType=@AssignType,Remark=@Remark,InsertDate=GETDATE(),UserName=@UserName where Employee_ID=@Employee_ID and EffectiveDate=@EffectiveDate and [TypeOfTransfer]='ChucDanh'
					end else begin
						insert into [dbo].[HR_Transfer]([Employee_ID],[TransferCode],[EffectiveDate],[TypeOfTransfer],[AssignType],[Remark],[InsertDate],[UserName])
						values(@Employee_ID,@ChucDanh,@EffectiveDate,'ChucDanh',@AssignType,@Remark,GETDATE(),@UserName)
					end
				end
			end else begin
				set @ThongBao=N'Ngaychuyenvitrikhonghople'
			end
		end

		--Lưu loại chức vụ
		if isnull(@PositionCategory_ID,'')<>'' begin
			select @OldED_LCV=max(EffectiveDate) from HR_Transfer where Employee_ID=@Employee_ID and TypeOfTransfer='PositionCategory_ID'
			if (@OldED_LCV is null or @EffectiveDate>=@OldED_LCV) begin
				Declare @OldPositionCategory_ID varchar(50)
				select top (1) @OldPositionCategory_ID=TransferCode from HR_Transfer where Employee_ID=@Employee_ID and TypeOfTransfer='PositionCategory_ID' order by EffectiveDate desc
				if @PositionCategory_ID<>isnull(@OldPositionCategory_ID,'') begin
					if @AssignType is null begin
						set @AssignType='PositionCategory_ID'
					end
					if exists (select * from [dbo].[HR_Transfer] where Employee_ID=@Employee_ID and EffectiveDate=@EffectiveDate and [TypeOfTransfer]='PositionCategory_ID') begin
						update [dbo].[HR_Transfer] set TransferCode=@PositionCategory_ID,AssignType=@AssignType,Remark=@Remark,InsertDate=GETDATE(),UserName=@UserName where Employee_ID=@Employee_ID and EffectiveDate=@EffectiveDate and [TypeOfTransfer]='PositionCategory_ID'
					end else begin
						insert into [dbo].[HR_Transfer]([Employee_ID],[TransferCode],[EffectiveDate],[TypeOfTransfer],[AssignType],[Remark],[InsertDate],[UserName])
						values(@Employee_ID,@PositionCategory_ID,@EffectiveDate,'PositionCategory_ID',@AssignType,@Remark,GETDATE(),@UserName)
					end
				end
			end else begin
				set @ThongBao=N'Ngaychuyenvitrikhonghople'
			end
		end

		--Lưu chức vụ
		if isnull(@Position_ID,'')<>'' begin
			select @OldED_LCV=max(EffectiveDate) from HR_Transfer where Employee_ID=@Employee_ID and TypeOfTransfer='Position_ID'
			if (@OldED_LCV is null or @EffectiveDate>=@OldED_LCV) begin
				Declare @OldPosition_ID varchar(50)
				select top (1) @OldPosition_ID=TransferCode from HR_Transfer where Employee_ID=@Employee_ID and TypeOfTransfer='Position_ID' order by EffectiveDate desc
				if @Position_ID<>isnull(@OldPosition_ID,'') begin
					if @AssignType is null begin
						set @AssignType='Position_ID'
					end
					if exists (select * from [dbo].[HR_Transfer] where Employee_ID=@Employee_ID and EffectiveDate=@EffectiveDate and [TypeOfTransfer]='Position_ID') begin
						update [dbo].[HR_Transfer] set TransferCode=@Position_ID,AssignType=@AssignType,Remark=@Remark,InsertDate=GETDATE(),UserName=@UserName where Employee_ID=@Employee_ID and EffectiveDate=@EffectiveDate and [TypeOfTransfer]='Position_ID'
					end else begin
						insert into [dbo].[HR_Transfer]([Employee_ID],[TransferCode],[EffectiveDate],[TypeOfTransfer],[AssignType],[Remark],[InsertDate],[UserName])
						values(@Employee_ID,@Position_ID,@EffectiveDate,'Position_ID',@AssignType,@Remark,GETDATE(),@UserName)
					end
				end
			end else begin
				set @ThongBao=N'Ngaychuyenvitrikhonghople'
			end
		end
	end
	if @AssignType is null and isnull(@ThongBao,'')='' begin
		set @ThongBao=N'Vitricuvamoigiongnhau'
	end
	
	select @ThongBao as ThongBao
END




GO
