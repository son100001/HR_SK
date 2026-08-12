CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_Discipline]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@BehaviorCode nvarchar(50),
	@Reason nvarchar(max),
	@DisciplineBegin datetime,
	@DisciplineEnd datetime,
	@ViolationDate datetime,
	@SalaryIncreaseDate datetime,
	@Remark nvarchar(255),
	@InsertDate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255)
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@DisciplineBegin,@UserName,'HR_Discipline')
	--if @DisciplineEnd<@DisciplineBegin begin
	--	set @ThongBao=@ThongBao+N'Ngày kết thúc biên bản không hợp lệ;'
	--end
	--if @SalaryIncreaseDate<@DisciplineEnd begin
	--	set @ThongBao=@ThongBao+N'Ngày tăng lương không hợp lệ;'
	--end
	--if @ViolationDate>@DisciplineBegin begin
	--	set @ThongBao=@ThongBao+N'Ngày vi phạm không hợp lệ;'
	--end
	if ISNULL(@thongbao,'')='' begin
		if exists (select Employee_ID from HR_Discipline where (Employee_ID=@Employee_ID and DisciplineBegin=@DisciplineBegin) or ID=ISNULL(@ID,0)) begin
			update HR_Discipline set Employee_ID=@Employee_ID,BehaviorCode=@BehaviorCode,Reason=@Reason,DisciplineBegin=@DisciplineBegin,DisciplineEnd=@DisciplineEnd,ViolationDate=@ViolationDate,SalaryIncreaseDate=@SalaryIncreaseDate
				,Remark=@Remark,InsertDate=GETDATE(),UserName=@UserName
			where (Employee_ID=@Employee_ID and DisciplineBegin=@DisciplineBegin and BehaviorCode=@BehaviorCode) or ID=ISNULL(@ID,0)
		end else begin
			insert into
			HR_Discipline
			(
				Employee_ID,
				BehaviorCode,
				Reason,
				DisciplineBegin,
				DisciplineEnd,
				ViolationDate,
				SalaryIncreaseDate,
				Remark,
				InsertDate,
				UserName
			)
			values
			(
				@Employee_ID,
				@BehaviorCode,
				@Reason,
				@DisciplineBegin,
				@DisciplineEnd,
				@ViolationDate,
				@SalaryIncreaseDate,
				@Remark,
				GETDATE(),
				@UserName
			)
		end
	end
	select @ID=ID from HR_Discipline where Employee_ID=@Employee_ID and DisciplineBegin=@DisciplineBegin
	select @ThongBao as ThongBao,@ID as ID
END




GO
