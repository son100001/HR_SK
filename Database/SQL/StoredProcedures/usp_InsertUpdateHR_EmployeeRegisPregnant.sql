
--exec [dbo].[usp_InsertUpdateHR_EmployeeRegisPregnant] null,N'1029',null,'2021-06-12 00:00:00',12,0,'2021-03-17 00:00:00','2021-12-27 00:00:00',null,null,'2021-12-27 11:24:24',N'admin'

CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_EmployeeRegisPregnant]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@UltraPaper nvarchar(50),
	@UltraDate datetime,
	@PregWeeks float,
	@PregDays int,
	@Fromdate datetime,
	@ToDate datetime,
	@MiscarriageDate datetime,
	@Remark nvarchar(225),
	@InsertDate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255)
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@ToDate,@UserName,'HR_EmployeeRegisPregnant')
	--set @Fromdate=@UltraDate-@PregWeeks*7-@PregDays
	--set @ToDate=dateadd(month,9,@Fromdate)+10
	if @ToDate<@Fromdate begin
		set @ThongBao=@ThongBao+N'Đến ngày nhỏ hơn từ ngày;'
	end
	if exists(select Employee_ID from HR_EmployeeRegisPregnant where Employee_ID=@Employee_ID and @ToDate>=Fromdate and @Fromdate<=isnull(MiscarriageDate,ToDate) and ID<>ISNULL(@ID,0)) begin
		set @ThongBao=@ThongBao+N'Đăng ký trùng dữ liệu;'
	end
	if ISNULL(@thongbao,'')='' begin
		--set @ToDate=dateadd(month,9,@fromdate)+10
		if exists(select Employee_ID from HR_EmployeeRegisPregnant where (Employee_ID=@Employee_ID and Fromdate=@Fromdate) or ID=isnull(@ID,0))
		begin
			update HR_EmployeeRegisPregnant
			set Employee_ID=@Employee_ID,MiscarriageDate=@MiscarriageDate,UltraPaper=@UltraPaper,UltraDate=@UltraDate,PregWeeks=@PregWeeks,PregDays=@PregDays,Fromdate=@Fromdate,ToDate=@ToDate,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
			where (Employee_ID=@Employee_ID and Fromdate=@Fromdate) or ID=isnull(@ID,0)
		end else begin
			insert into HR_EmployeeRegisPregnant
			(
				[Employee_ID],
				UltraPaper,
				UltraDate,
				PregWeeks,
				PregDays,
				[Fromdate],
				[ToDate],
				[MiscarriageDate],
				[Remark],
				[InsertDate],
				[UserName]
			)
			values(@Employee_ID,@UltraPaper,@UltraDate,@PregWeeks,@PregDays,@Fromdate,@ToDate,@MiscarriageDate,@Remark,GETDATE(),@UserName)
		end
	end
	select @ID=ID from HR_EmployeeRegisPregnant where Employee_ID=@Employee_ID and Fromdate=@Fromdate
	select @ThongBao as ThongBao,@ID as ID
END


GO
