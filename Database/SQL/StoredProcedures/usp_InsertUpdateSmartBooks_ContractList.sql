CREATE PROCEDURE [dbo].[usp_InsertUpdateSmartBooks_ContractList]
	-- Add the parameters for the stored procedure here
	-- exec usp_InsertUpdateSmartBooks_ContractList 0,N'HT111111',N'abcd','2020-7-22','2020-1-1','2020-7-22','False','PLHD',null,null,'ads','2020-7-22',null,null
	@ID int,
	@Contract_ID nvarchar(50),
	@Employee_ID nvarchar(50),
	@CL_RegisterDate datetime,
	@CL_ExpiredDate datetime,
	@CL_StartDate datetime,
	@status bit,
	@Type nvarchar(50),
	@CL_FatherID nvarchar(50),
	@CL_Remark nvarchar(max),
	@InsertSource nvarchar(50),
	@InsertDate datetime,
	@UserName nvarchar(50),
	@ContractAnnexID nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255)
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@CL_StartDate,@UserName,'SmartBooks_ContractList')
	if ISNULL(@thongbao,'')='' begin
	set @ID=NULL
		if exists(select Employee_ID from SmartBooks_ContractList where (Employee_ID=@Employee_ID and CL_StartDate=@CL_StartDate) or ID=isnull(@ID,0))
		begin
			update SmartBooks_ContractList
			set Employee_ID=@Employee_ID,Contract_ID=@Contract_ID,CL_RegisterDate=@CL_RegisterDate,CL_StartDate=@CL_StartDate,CL_ExpiredDate=@CL_ExpiredDate,[Type]=@Type,[status]=@status,CL_FatherID=@CL_FatherID,InsertSource=@InsertSource,CL_Remark=@CL_Remark,UserName=@UserName,ContractAnnexID=@ContractAnnexID,InsertDate=GETDATE()
			where (Employee_ID=@Employee_ID and CL_StartDate=@CL_StartDate) or ID=isnull(@ID,0)
		end else begin
			Declare @AutoContractAnnexID nvarchar(50)
			Set @AutoContractAnnexID = (Select dbo.udf_GetContractAnnexID(@CL_StartDate))
			insert into SmartBooks_ContractList
			(
				[Contract_ID],
				[Employee_ID],
				CL_RegisterDate,
				CL_StartDate,
				CL_ExpiredDate,
				[status],
				[Type],
				CL_FatherID,
				[CL_Remark],
				InsertSource,
				[InsertDate],
				[UserName],
				[ContractAnnexID]
			)
			values(@Contract_ID,@Employee_ID,@CL_RegisterDate,@CL_StartDate,@CL_ExpiredDate,@status,@Type,@CL_FatherID,@CL_Remark,@InsertSource,GETDATE(),@UserName, @AutoContractAnnexID)
		end
	end
	select @ID=ID from SmartBooks_ContractList where Employee_ID=@Employee_ID and CL_StartDate=@CL_StartDate
	select @ThongBao as ThongBao,@ID as ID
END




GO
