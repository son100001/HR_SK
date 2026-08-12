
CREATE PROCEDURE [dbo].[sp_TaoThangBangLuong]
	-- Add the parameters for the stored procedure here
	@Year int,
	@LuongToiThieuVung float,
	@BacToiDa int,
	@NhomToiDa int,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	Declare @BacStep int,@NhomStep int,@SalaryGroup varchar(50),@SalaryStep varchar(50),@Amount float,@AmountLuu int,@AmountBac1NhomTruoc float
		,@NgayDauNam datetime,@NgayCuoiNam datetime
	set @NgayDauNam=DATEFROMPARTS(@Year,1,1)
	set @NgayCuoiNam=DATEADD(year,1,@NgayDauNam)-1
	set @NhomStep=1
	while @NhomStep<=@NhomToiDa begin
		set @BacStep=1
		while @BacStep<=@BacToiDa begin
			if @NhomStep=1 begin
				if @BacStep=1 begin
					set @Amount=ROUND(105/100.0*107/100.0,4)*@LuongToiThieuVung
					set @AmountBac1NhomTruoc=@Amount
				end else begin
					set @Amount=@Amount*105/100.0
				end
			end else begin
				if @BacStep=1 begin
					set @Amount=@AmountBac1NhomTruoc*105/100.0
					set @AmountBac1NhomTruoc=@Amount
				end else begin
					set @Amount=@Amount*105/100.0
				end
			end
			set @SalaryGroup=Replicate('M', @NhomStep/1000)  -- convert từ số qua số la mã
            + REPLACE(REPLACE(REPLACE(  
                  Replicate('C', @NhomStep%1000/100),  
                  Replicate('C', 9), 'CM'),  
                  Replicate('C', 5), 'D'),  
                  Replicate('C', 4), 'CD')  
             + REPLACE(REPLACE(REPLACE(  
                  Replicate('X', @NhomStep%100 / 10),  
                  Replicate('X', 9),'XC'),  
                  Replicate('X', 5), 'L'),  
                  Replicate('X', 4), 'XL')  
             + REPLACE(REPLACE(REPLACE(  
                  Replicate('I', @NhomStep%10),  
                  Replicate('I', 9),'IX'),  
                  Replicate('I', 5), 'V'),  
                  Replicate('I', 4),'IV') 
			set @AmountLuu=round(@Amount,0)
			set @AmountLuu=(case when @AmountLuu%10=0 then @AmountLuu else @AmountLuu+10-@AmountLuu%10 end)
			if exists (select * from HR_MucLuong where SalaryGroup=@SalaryGroup and SalaryStep=@BacStep and fromdate=@NgayDauNam) begin
				update HR_MucLuong set Amount=@AmountLuu,insertdate=getdate(),UserName=@UserName where SalaryGroup=@SalaryGroup and SalaryStep=@BacStep and fromdate=@NgayDauNam
			end else begin
				insert into HR_MucLuong ([SalaryGroup],[SalaryStep],[Amount],[FromDate],[ToDate],[Remark],[InsertDate],[UserName])
				values(@SalaryGroup,@BacStep,@AmountLuu,@NgayDauNam,@NgayCuoiNam,null,GETDATE(),@UserName)
			end
			set @BacStep=@BacStep+1
		end
		set @NhomStep=@NhomStep+1
	end
END



GO
