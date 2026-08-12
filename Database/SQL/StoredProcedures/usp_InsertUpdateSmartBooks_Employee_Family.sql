
--exec usp_InsertUpdateSmartBooks_Employee_Family null,N'17080499',N'Nguyễn Đăng Khôi','',N'6',N'',N'','2022-03-23',N'Male',N'',N'',N'',N'',N'',N'',N'','','0001-01-01',N'','2022-03-09',null,null,null,null,N'admin','2022-04-12 13:56:40',null

CREATE PROCEDURE [dbo].[usp_InsertUpdateSmartBooks_Employee_Family]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID [nvarchar](50),
	@RelatedName [nvarchar](500),
	@Tel [nvarchar](50),
	@RelatedType [nvarchar](50),
	@Address [nvarchar](max),
	@Occupation [nvarchar](50),
	@BirthDate [datetime],
	@Sex [nvarchar](50),
	@GKS_So [nvarchar](50),
	@GKS_QuyenSo [nvarchar](50),
	@GKS_TinhTP [nvarchar](128),
	@GKS_QuanHuyen [nvarchar](128),
	@GKS_PhuongXa [nvarchar](128),
	@MaSoThue [nvarchar](50),
	@QuocTich [nvarchar](50),
	@ID_Number [nvarchar](50),
	@ID_date [datetime],
	@ID_place [nvarchar](128),
	@DependFromMonth [datetime],
	@DependToMonth [datetime],
	@BabyCareStartDate [datetime],
	@DateOfDeath [datetime],
	@Remark [nvarchar](255),
	@UserName [nvarchar](50),
	@InsertDate [datetime],
	@isDaNopGiay [bit]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Declare @EmpID nvarchar(50), @ThongBao as nvarchar(max), @NonUNCRelatedName nvarchar(100)
	set @ThongBao=''
	if not exists(select Employee_ID from Smartbooks_Employee where Employee_ID=@Employee_ID) begin
		select @EmpID=Employee_ID from Smartbooks_Employee where ID_number=@Employee_ID and TernimationDate is null
	end else begin
		set @EmpID=@Employee_ID
	end
	set @ThongBao=@ThongBao+[dbo].[udf_KiemTraNhapDuLieuChung](@EmpID,GETDATE(),@UserName,'SmartBooks_Employee_Family')
    -- Insert statements for procedure here
	if isnull(@ThongBao,'')='' begin
		set @NonUNCRelatedName=REPLACE([dbo].[non_unicode_convert](@RelatedName),' ','')
		if exists(select * from SmartBooks_Employee_Family where (Employee_ID=@EmpID and BirthDate=@BirthDate and REPLACE([dbo].[non_unicode_convert](RelatedName),' ','')=@NonUNCRelatedName) or ID=isnull(@ID,0)) begin
			update SmartBooks_Employee_Family
			set Employee_ID=@EmpID,RelatedName=@RelatedName,Tel=@Tel,RelatedType=@RelatedType,[Address]=@Address,Occupation=@Occupation,BirthDate=@BirthDate,Sex=@Sex,GKS_So=@GKS_So,GKS_QuyenSo=@GKS_QuyenSo,GKS_TinhTP=@GKS_TinhTP,GKS_QuanHuyen=@GKS_QuanHuyen,GKS_PhuongXa=@GKS_PhuongXa,MaSoThue=@MaSoThue,QuocTich=@QuocTich,ID_Number=@ID_Number,ID_date=@ID_date,ID_place=@ID_place,DependFromMonth=@DependFromMonth,DependToMonth=@DependToMonth,BabyCareStartDate=@BabyCareStartDate,DateOfDeath=@DateOfDeath,isDaNopGiay=@isDaNopGiay,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
			where (Employee_ID=@EmpID and BirthDate=@BirthDate and REPLACE([dbo].[non_unicode_convert](RelatedName),' ','')=@NonUNCRelatedName) or ID=isnull(@ID,0)
		end else begin
			insert into SmartBooks_Employee_Family (Employee_ID,RelatedName,Tel,RelatedType,[Address],Occupation,BirthDate,Sex,GKS_So,GKS_QuyenSo,GKS_TinhTP,GKS_QuanHuyen,GKS_PhuongXa,MaSoThue,QuocTich,ID_Number,ID_date,ID_place,DependFromMonth,DependToMonth,BabyCareStartDate,DateOfDeath,isDaNopGiay,Remark,UserName,InsertDate)
			values(@EmpID,@RelatedName,@Tel,@RelatedType,@Address,@Occupation,@BirthDate,@Sex,@GKS_So,@GKS_QuyenSo,@GKS_TinhTP,@GKS_QuanHuyen,@GKS_PhuongXa,@MaSoThue,@QuocTich,@ID_Number,@ID_date,@ID_place,@DependFromMonth,@DependToMonth,@BabyCareStartDate,@DateOfDeath,@isDaNopGiay,@Remark,@UserName,GETDATE())
		end
	end
	select @ID=ID from SmartBooks_Employee_Family where Employee_ID=@EmpID and BirthDate=@BirthDate and REPLACE([dbo].[non_unicode_convert](RelatedName),' ','')=@NonUNCRelatedName
	select @ThongBao as ThongBao,@ID as ID
END




GO
