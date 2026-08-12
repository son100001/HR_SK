
CREATE FUNCTION [dbo].[MinuteToHour](@SoPhut int)
--Đổi phút sang giờ và phút
returns nvarchar(50)
as
begin

	declare @Result as nvarchar(50)
	set @Result=''
	declare @Gio as int
	Declare @Phut as int
	-- @SoPhut >0 thi moi chuyen 
	if @SoPhut>0
	begin
		--So Gio chia lay phan nguyen
		Set @Gio=@SoPhut/60
		-- Chia lay so du
		Set @Phut=@SoPhut%60

		if (@Gio >0) Set @Result=cast(@Gio as varchar)+':' 
		if (@Phut>0) Set @Result=@Result+ cast(@Phut as varchar) 
    end
	return @Result;

end












GO
