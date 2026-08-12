CREATE PROCEDURE [dbo].[usp_InsertUpdateSmartBooks_Salary]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Key nvarchar(50),
	@Salary_Month int,
	@Salary_Year int,
	@Employee_ID nvarchar(50),
	@PayDate datetime,
	@username nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255),@ngaydauthang datetime,@ngaycuoithang datetime
	set @ngaydauthang=cast(@Salary_Year as varchar)+'-'+cast(@Salary_Month as varchar)+'-1'
	set @ngaycuoithang=DATEADD(month,1,@ngaydauthang)-1
	set @ThongBao=''
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@ngaycuoithang,@UserName,'SmartBooks_Salary')
	if ISNULL(@thongbao,'')='' begin
		if exists(select Employee_ID from SmartBooks_Salary where ((Employee_ID=@Employee_ID and Salary_Month=@Salary_Month and Salary_Year=@Salary_Year and [Key]=@Key) or ID=isnull(@ID,0)) and isnull(trangthai,0)<>1)
		begin
			if exists(select Employee_ID from SmartBooks_Salary where (Employee_ID=@Employee_ID and Salary_Month=@Salary_Month and Salary_Year=@Salary_Year and [Key]=@Key) or ID=isnull(@ID,0))
			begin
				update SmartBooks_Salary
				set PayDate=@PayDate,UserName=@UserName,InsertDate=GETDATE()
				where (Employee_ID=@Employee_ID and Salary_Month=@Salary_Month and Salary_Year=@Salary_Year and [Key]=@Key) or ID=isnull(@ID,0)
			end
		end else begin
			set @ThongBao=N'Dulieudabikhoa'
		end
	end
	select @ID=ID from SmartBooks_Salary where Employee_ID=@Employee_ID and Salary_Month=@Salary_Month and Salary_Year=@Salary_Year and [Key]=@Key
	select @ThongBao as ThongBao,@ID as ID
END

--select Employee_ID from SmartBooks_Salary where ((Employee_ID='0193' and Salary_Month=2 and Salary_Year=2020 and [Key]='TroCapThoiViec')) and isnull(trangthai,0)<>1



GO
