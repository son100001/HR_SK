CREATE PROCEDURE [dbo].[usp_UpdateSmartBooks_PositionMovement]
	@PositionMovement_ID int,
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
	@UserName nvarchar(50)
AS

SET NOCOUNT ON

--IF @PositionMovement_ID = (SELECT max(PositionMovement_ID) as PositionMovement_ID FROM [dbo].[SmartBooks_PositionMovement] WHERE [Employee_ID] = @Employee_ID)
--Cập nhật chuyển vị trí vào bảng lịch sử chuyển vị trí
UPDATE [dbo].[SmartBooks_PositionMovement] SET
	[Factory_ID]=@Factory_ID
	,[DepartmentCode] = @DepartmentCode
	,[SectionCode] = @SectionCode
	,[TeamCode] = @TeamCode
	,[Position_ID] = @Position_ID
	,[PositionCategory_ID] = @PositionCategory_ID
	,[ChucDanh] = @ChucDanh
	,[JobCode]=@JobCode
	,[EffectiveDate] = @EffectiveDate
	,[Remark] = @Remark
	,[InsertDate]=@InsertDate
	,[UserName]=@UserName
WHERE
	[PositionMovement_ID]=@PositionMovement_ID
--Cập nhật chuyển vị trí vào bảng thông tin nhân viên
--SS: khong cap nhat ngay, het thang sau moi cap nhat
UPDATE [dbo].[SmartBooks_Employee] SET
	[Factory_ID] = @Factory_ID
	,[DepartmentCode] = pm.DepartmentCode
	,[SectionCode] = pm.SectionCode
	,[TeamCode] = pm.TeamCode
	,[Position_ID] = pm.Position_ID
	,[PositionCategory_ID] = pm.PositionCategory_ID
	,[ChucDanh] = pm.ChucDanh
	,[JobCode]= pm.JobCode
FROM [dbo].[SmartBooks_Employee] emp
LEFT JOIN (SELECT TOP 1 * FROM [dbo].[SmartBooks_PositionMovement] WHERE [Employee_ID] = @Employee_ID ORDER BY [EffectiveDate] desc) AS pm
ON emp.Employee_ID COLLATE DATABASE_DEFAULT = pm.Employee_ID
WHERE emp.[Employee_ID] = @Employee_ID




GO
