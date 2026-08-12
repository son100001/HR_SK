
CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_TerminationAsignment]
--exec usp_InsertUpdateHR_TerminationAsignment null,N'a','2019-05-09',N'10',NULL,'Approved','2020-6-12',N'','2020-6-12',N'admin','2020-6-12'
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@PlanTernimationDate datetime,
	@ResonTerminated nvarchar(255),
	@DecisionCode varchar(50),
	@DecisionStatus varchar(50),
	@NgayNopDon datetime,
	@Remark nvarchar(max),
	@InsertDate datetime,
	@UserName nvarchar(50),
	@ThangTinhLuong datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--tao @DecisionCode
	declare @DC varchar(10), @ThongBao as nvarchar(max),@MaxPlanTernimationDate datetime,@NGayKyHDCT datetime
	set @NGayKyHDCT='1999-1-1'
	select @NGayKyHDCT=NgayKyHDChinhThuc from udf_NgayKyHDChinhThuc(null,null,@Employee_ID)
	--select @MaxPlanTernimationDate=max(PlanTernimationDate) from HR_TerminationAsignment where Employee_ID=@Employee_ID
	--set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@PlanTernimationDate)
	if @PlanTernimationDate<@NgayNopDon begin
		set @ThongBao=N'Dulieukhonghople'
	end
	if isnull(@DecisionStatus,'')='' begin
		set @DecisionStatus='Approved'
	end
	--update du lieu
	if isnull(@ThongBao,'')='' begin
		if exists(select Employee_ID from HR_TerminationAsignment where (Employee_ID=@Employee_ID and PlanTernimationDate=@PlanTernimationDate) or ID=isnull(@ID,0))
		begin
			update HR_TerminationAsignment
			set PlanTernimationDate=@PlanTernimationDate, NgayNopDon=@NgayNopDon,ResonTerminated=@ResonTerminated,DecisionStatus=@DecisionStatus,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE(),ThangTinhLuong=@ThangTinhLuong
			where (Employee_ID=@Employee_ID and PlanTernimationDate=@PlanTernimationDate) or ID=isnull(@ID,0)
		end else begin
			select @DC=max(cast(isnull(DecisionCode,'0') as int)) +1 from HR_TerminationAsignment where DATEPART(YEAR,PlanTernimationDate)=DATEPART(YEAR,@PlanTernimationDate) and DATEPART(MONTH,PlanTernimationDate)=DATEPART(MONTH,@PlanTernimationDate)
			if @DC is null begin
				set @DC='1'
			end
			insert into HR_TerminationAsignment
			(
				[Employee_ID],
				[PlanTernimationDate],
				[NgayNopDon],
				[ResonTerminated],
				[DecisionCode],
				[DecisionStatus],
				[Remark],
				[InsertDate],
				[UserName],
				ThangTinhLuong
			)
			values(@Employee_ID,@PlanTernimationDate,@NgayNopDon,@ResonTerminated,@DC,@DecisionStatus,@Remark,GETDATE(),@UserName,@ThangTinhLuong)
		end
		--update vào bảng thông tin nv
		if @DecisionStatus='Approved' begin
			update SmartBooks_Employee set TernimationDate=@PlanTernimationDate,Employee_Status='Terminated' where Employee_ID=@Employee_ID
		end else if @DecisionStatus = 'Plan' begin
			update SmartBooks_Employee set TernimationDate=@PlanTernimationDate,Employee_Status='Incumbent' where Employee_ID=@Employee_ID
		end else begin
			update SmartBooks_Employee set TernimationDate=null,Employee_Status='Incumbent' where Employee_ID=@Employee_ID
		end
	end
	select @ID=ID,@DC=DecisionCode from HR_TerminationAsignment where Employee_ID=@Employee_ID and PlanTernimationDate=@PlanTernimationDate
	select isnull(@ThongBao,'') as ThongBao, @DC as DecisionCode,@ID as ID
END

--select * from HR_TerminationAsignment



GO
