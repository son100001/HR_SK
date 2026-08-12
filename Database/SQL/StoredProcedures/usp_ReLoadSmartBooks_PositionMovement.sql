CREATE PROCEDURE [dbo].[usp_ReLoadSmartBooks_PositionMovement]
	@Employee_ID nvarchar(50)
AS

SET NOCOUNT ON

IF EXISTS(SELECT [Employee_ID] FROM [dbo].[SmartBooks_PositionMovement] WHERE [Employee_ID] = @Employee_ID)
BEGIN
	UPDATE [dbo].[SmartBooks_Employee] SET
		[Factory_ID] = pm.Factory_ID
		,[DepartmentCode] = pm.DepartmentCode
		,[SectionCode] = pm.SectionCode
		,[TeamCode] = pm.TeamCode
		,[Position_ID] = pm.Position_ID
		,[PositionCategory_ID] = pm.PositionCategory_ID
		,[ChucDanh] = pm.ChucDanh
		,[JobCode] = pm.JobCode
	FROM [dbo].[SmartBooks_Employee] as emp
		left join
		(select top 1 * from SmartBooks_PositionMovement where Employee_ID = @Employee_ID order by EffectiveDate asc) as pm
		on emp.Employee_ID COLLATE DATABASE_DEFAULT = pm.Employee_ID
	where emp.Employee_ID = @Employee_ID
END

--exec [dbo].[usp_UpdateSmartBooks_PositionMovement] 6,N'13110003',N'Office',N'abc',N'Accounting',N'Account of section at factory',null,'2016-2-13',null




GO
