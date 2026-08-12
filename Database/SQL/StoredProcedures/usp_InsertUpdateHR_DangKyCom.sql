
CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_DangKyCom]
	--exec [dbo].[usp_InsertUpdateHR_DangKyCom] null,N'C6608','2026-06-19',N'01-An',N'00-Khong',null
	-- Quy tắc nghiệp vụ:
	--   - Cơm trưa  chỉ được đăng ký / thay đổi trước 09:00 của chính ngày đăng ký.
	--   - Cơm chiều chỉ được đăng ký / thay đổi trước 15:00 của chính ngày đăng ký.
	--   - Ngày quá khứ: khóa cả hai bữa. Ngày tương lai: mở cả hai bữa.
	--   - Khi một bữa đã bị khóa, hệ thống GIỮ NGUYÊN giá trị đã đăng ký trước đó
	--     (bỏ qua thay đổi với bữa đó), các bữa còn hạn vẫn được lưu bình thường.
	@ID int,
	@Employee_ID nvarchar(50),
	@Ngay datetime,
	@ComTrua nvarchar(50) = null,
	@ComToi nvarchar(50) = null,
	@Remark nvarchar(500) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @ThongBao nvarchar(255) = NULL;

	DECLARE @NgayDate date = CAST(@Ngay AS date);
	DECLARE @Today    date = CAST(GETDATE() AS date);
	DECLARE @Now      time = CAST(GETDATE() AS time);

	-- Giá trị đã đăng ký trước đó (nếu có)
	DECLARE @ExistComTrua nvarchar(50) = NULL
		,@ExistComToi nvarchar(50) = NULL
		,@HasRow bit = 0;

	SELECT @ExistComTrua = ComTrua, @ExistComToi = ComToi, @HasRow = 1
	FROM HR_DangKyCom
	WHERE Ngay = @Ngay AND Employee_ID = @Employee_ID;

	-- Cờ khóa theo giờ: chỉ áp dụng mốc giờ cho NGÀY HÔM NAY,
	-- ngày quá khứ khóa toàn bộ, ngày tương lai mở toàn bộ.
	DECLARE @LockTrua bit = CASE
			WHEN @NgayDate < @Today THEN 1
			WHEN @NgayDate = @Today AND @Now >= '09:00:00.000' THEN 1
			ELSE 0 END;

	DECLARE @LockToi bit = CASE
			WHEN @NgayDate < @Today THEN 1
			WHEN @NgayDate = @Today AND @Now >= '15:00:00.000' THEN 1
			ELSE 0 END;

	-- Bữa đã khóa thì giữ nguyên giá trị cũ, ngược lại nhận giá trị mới gửi lên.
	DECLARE @FinalComTrua nvarchar(50) = CASE WHEN @LockTrua = 1 THEN @ExistComTrua ELSE @ComTrua END;
	DECLARE @FinalComToi  nvarchar(50) = CASE WHEN @LockToi  = 1 THEN @ExistComToi  ELSE @ComToi  END;

	IF @HasRow = 1
	BEGIN
		UPDATE HR_DangKyCom
		SET ComTrua = @FinalComTrua
			,ComToi = @FinalComToi
			,Remark = @Remark
		WHERE Ngay = @Ngay AND Employee_ID = @Employee_ID;
	END
	ELSE
	BEGIN
		INSERT INTO HR_DangKyCom (Employee_ID, Ngay, ComTrua, ComToi, Remark)
		VALUES (@Employee_ID, @Ngay, @FinalComTrua, @FinalComToi, @Remark);
	END

	SELECT @ThongBao AS ThongBao;
END

GO
