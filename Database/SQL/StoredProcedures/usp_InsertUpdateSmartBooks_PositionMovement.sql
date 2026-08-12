
--exec [dbo].[usp_InsertUpdateSmartBooks_PositionMovement] N'1002',N'FacA',N'Accounting',null,null,null,null,'2019-02-22',null,'2019-02-22 16:05:20',N'admin',1


CREATE PROCEDURE [dbo].[usp_InsertUpdateSmartBooks_PositionMovement]
	@Employee_ID nvarchar(50),
	@Factory_ID varchar(50),
	@DepartmentCode nvarchar(50),
	@SectionCode nvarchar(50),
	@TeamCode nvarchar(50),
	@Position_ID nvarchar(50),
	@PositionCategory_ID nvarchar(50),
	@ChucDanh nvarchar(50),
	@JobCode varchar(50),
	@EffectiveDate datetime,
	@Remark nvarchar(255),
	@InsertDate datetime,
	@UserName nvarchar(50),
	@CapNhatChuyenViTri bit
AS

SET NOCOUNT ON
IF NOT EXISTS(SELECT [Employee_ID] FROM [dbo].[SmartBooks_Employee] WHERE [Employee_ID] = @Employee_ID AND Factory_ID=@Factory_ID AND [DepartmentCode]=@DepartmentCode AND [SectionCode]=@SectionCode AND [TeamCode]=@TeamCode AND [Position_ID]=@Position_ID AND [PositionCategory_ID]=@PositionCategory_ID AND [ChucDanh]=@ChucDanh AND JobCode=@JobCode)
BEGIN
	--Kiểm tra đã chuyển vị trí chưa
	if @CapNhatChuyenViTri = 1
	BEGIN
		IF EXISTS(SELECT [Employee_ID], [DepartmentCode], [SectionCode], [TeamCode], [Position_ID], [PositionCategory_ID], [EffectiveDate] FROM [dbo].[SmartBooks_PositionMovement] WHERE [Employee_ID] = @Employee_ID AND [EffectiveDate] = @EffectiveDate)
		BEGIN
			UPDATE [dbo].[SmartBooks_PositionMovement] SET
				[Factory_ID] = @Factory_ID
				,[DepartmentCode] = @DepartmentCode
				,[SectionCode] = @SectionCode
				,[TeamCode] = @TeamCode
				,[Position_ID] = @Position_ID
				,[PositionCategory_ID] = @PositionCategory_ID
				,[ChucDanh] = @ChucDanh
				,JobCode=@JobCode
				,[Remark] = @Remark
				,[InsertDate] = @InsertDate
				,[UserName] = @UserName
			WHERE
				[Employee_ID] = @Employee_ID
				AND [EffectiveDate] = @EffectiveDate
		END
		ELSE
		BEGIN
			--Kiểm tra lần chuyển vị trí đầu tiên
			IF NOT EXISTS(SELECT [Employee_ID] FROM [dbo].[SmartBooks_PositionMovement] WHERE [Employee_ID] = @Employee_ID)
			BEGIN
				INSERT INTO [dbo].[SmartBooks_PositionMovement] (
					[Employee_ID],
					[Factory_ID],
					[DepartmentCode],
					[SectionCode],
					[TeamCode],
					[Position_ID],
					[PositionCategory_ID],
					[ChucDanh],
					JobCode,
					[EffectiveDate],
					[InsertDate],
					[UserName]
				)
					SELECT
					Employee_ID,
					Factory_ID,
					DepartmentCode,
					SectionCode,
					TeamCode,
					Position_ID,
					PositionCategory_ID,
					ChucDanh,
					JobCode,
					StartedDate,
					@InsertDate,
					@UserName
					FROM dbo.SmartBooks_Employee WHERE Employee_ID = @Employee_ID
			END
			-- Lưu chuyển vị trí
			INSERT INTO [dbo].[SmartBooks_PositionMovement] (
				[Employee_ID],
				Factory_ID,
				[DepartmentCode],
				[SectionCode],
				[TeamCode],
				[Position_ID],
				[PositionCategory_ID],
				[ChucDanh],
				JobCode,
				[EffectiveDate],
				[Remark],
				[InsertDate],
				[UserName]
			) VALUES (
				@Employee_ID,
				@Factory_ID,
				@DepartmentCode,
				@SectionCode,
				@TeamCode,
				@Position_ID,
				@PositionCategory_ID,
				@ChucDanh,
				@JobCode,
				@EffectiveDate,
				@Remark,
				@InsertDate,
				@UserName
			)
		END
	END
	-- Cập nhật vị trí vào bảng thông tin nhân viên
	UPDATE [dbo].[SmartBooks_Employee] SET
		Factory_ID=@Factory_ID
		,[DepartmentCode] = @DepartmentCode
		,[SectionCode] = @SectionCode
		,[TeamCode] = @TeamCode
		,[Position_ID] = @Position_ID
		,[PositionCategory_ID] = @PositionCategory_ID
		,[ChucDanh] = @ChucDanh
		,JobCode=@JobCode
	WHERE [Employee_ID] = @Employee_ID	
END
	




GO
