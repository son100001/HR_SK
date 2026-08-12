CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_EmpRegisTimeSheet]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@TimeDate datetime,
	@ShiftName nvarchar(50),
	@Remark nvarchar(max),
	@UserName nvarchar(50),
	@InsertDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255)
	select @ShiftName=shiftname from hr_shifts where shiftname=@shiftname or [ShiftSign]=@shiftname
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@TimeDate,@UserName,'HR_EmpRegisTimeSheet')
	if ISNULL(@thongbao,'')='' begin
		if exists(select Employee_ID from [dbo].[HR_EmpRegisTimeSheet] where (Employee_ID=@Employee_ID and TimeDate=@TimeDate) or ID=isnull(@ID,0))
		begin
			update [dbo].[HR_EmpRegisTimeSheet] set [ShiftName]=@ShiftName,Employee_ID=@Employee_ID,TimeDate=@TimeDate,[Remark]=@Remark,[UserName]=@UserName,[InsertDate]=GETDATE() where(Employee_ID=@Employee_ID and TimeDate=@TimeDate) or ID=isnull(@ID,0)
		end else begin
			insert into [dbo].[HR_EmpRegisTimeSheet] (Employee_ID,TimeDate,ShiftName,Remark,UserName,InsertDate) values(@Employee_ID,@TimeDate,@ShiftName,@Remark,@UserName,getdate())
		end
	end
	select @ID=ID from HR_EmpRegisTimeSheet where Employee_ID=@Employee_ID and TimeDate=@TimeDate
	select @ThongBao as ThongBao,@ID as ID
END




GO
