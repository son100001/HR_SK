
--exec  [dbo].[usp_InsertUpdateHR_CardCode] 'G000010', '07459031', '06715311', '2016-5-27', ''
CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_CardCode]
	@Employee_ID nvarchar(50),
	@Card_Code_Moi nvarchar(50),
	@ExpiredDate datetime,
	@Remark nvarchar(max),
	@InsertDate datetime,
	@UserName nvarchar(50)
AS

SET NOCOUNT ON
--NHAP CARDCODE CUA NHAN VIEN CO THE BI CHUYEN CHO NGUOI KHAC
Declare @Card_Code_Cu nvarchar(50)
select @Card_Code_Cu = isnull(Card_Code, '') from [SmartBooks_Employee] where Employee_ID = @Employee_ID
if @Card_Code_Cu <> @Card_Code_Moi begin
	declare @Employee_IDCu nvarchar(50)
	if exists(select [Employee_ID] from [dbo].[SmartBooks_Employee] where [Card_Code] = @Card_Code_Moi) begin
		select @Employee_IDCu = [Employee_ID] from [dbo].[SmartBooks_Employee] where [Card_Code] = @Card_Code_Moi
		IF EXISTS(SELECT [Employee_ID], [Card_Code] FROM [dbo].[HR_CardCode] WHERE [Employee_ID] = @Employee_IDCu AND [Card_Code] = @Card_Code_Moi and [ExpiredDate] = @ExpiredDate)
		BEGIN
			UPDATE [dbo].[HR_CardCode] SET
				[Remark] = @Remark,
				[InsertDate] = @InsertDate,
				[UserName] = @UserName
			WHERE
				[Employee_ID] = @Employee_IDCu
				AND [Card_Code] = @Card_Code_Moi
				AND [ExpiredDate] = @ExpiredDate
		END
		ELSE
		BEGIN
			INSERT INTO [dbo].[HR_CardCode] (
				[Employee_ID],
				[Card_Code],
				[ExpiredDate],
				[Remark],
				[InsertDate],
				[UserName]
			) VALUES (
				@Employee_IDCu,
				@Card_Code_Moi,
				@ExpiredDate,
				@Remark,
				@InsertDate,
				@UserName
			)
		END
		--CAP NHAT TRANG THAI THE CUA NHAN VIEN CO THE BI CHUYEN CHO NGUOI KHAC
		UPDATE [dbo].[SmartBooks_Employee] set [Card_Code] = N'ChuyenThe' where [Card_Code] = @Card_Code_Moi
	end
	--CAP NHAT THE MOI CHO NHAN VIEN DUOC NHAN THE
	UPDATE [dbo].[SmartBooks_Employee] SET Card_Code = @Card_Code_Moi WHERE Employee_ID = @Employee_ID
	-- CAP NHAT LICH SU THE CHO NHAN VIEN DUOC DOI THE
	if @Card_Code_Cu is not null begin
		IF EXISTS(SELECT [Employee_ID], [Card_Code] FROM [dbo].[HR_CardCode] WHERE [Employee_ID] = @Employee_ID AND [Card_Code] = @Card_Code_Cu and [ExpiredDate] = @ExpiredDate)
		BEGIN
			UPDATE [dbo].[HR_CardCode] SET
				[Remark] = @Remark,
				[InsertDate] = @InsertDate,
				[UserName] = @UserName
			WHERE
				[Employee_ID] = @Employee_ID
				AND [Card_Code] = @Card_Code_Cu
				AND [ExpiredDate] = @ExpiredDate
		END
		ELSE
		BEGIN
			if @Card_Code_Cu <> '' and @Card_Code_Cu is not null begin
				INSERT INTO [dbo].[HR_CardCode] (
					[Employee_ID],
					[Card_Code],
					[ExpiredDate],
					[Remark],
					[InsertDate],
					[UserName]
				) VALUES (
					@Employee_ID,
					@Card_Code_Cu,
					@ExpiredDate,
					@Remark,
					@InsertDate,
					@UserName
				)
			end
		END

	end
end


--exec [dbo].[usp_InsertUpdateHR_CardCode] N'G000018', null, '2016-7-27',null,'2016-7-27 17:10:34',N'admin'




GO
