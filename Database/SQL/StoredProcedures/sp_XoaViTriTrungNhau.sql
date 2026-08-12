-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec sp_XoaViTriTrungNhau 'WS000001'
CREATE PROCEDURE sp_XoaViTriTrungNhau
	-- Add the parameters for the stored procedure here
	@Empl nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Employee_ID nvarchar(50),@OldEmployee_ID nvarchar(50),@TransferCode varchar(50),@OldTransferCode varchar(50),@EffectiveDate datetime,@OldEffectiveDate datetime,@TypeOfTransfer varchar(50),@OldTypeOfTransfer varchar(50)
	
	DECLARE cur CURSOR LOCAL FOR
	select [Employee_ID],[TransferCode],[EffectiveDate],[TypeOfTransfer] from [dbo].[HR_Transfer]
	where case when isnull(@Empl,'')='' then '' else Employee_ID end=isnull(@Empl,'')
	union
	select 'ws900000000',null,null,null
	order by Employee_ID,[TypeOfTransfer],[EffectiveDate] asc
	OPEN  cur
	FETCH NEXT FROM cur INTO @Employee_ID,@TransferCode,@EffectiveDate,@TypeOfTransfer
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if @Employee_ID=@OldEmployee_ID and @TypeOfTransfer=@OldTypeOfTransfer and @TransferCode=@OldTransferCode begin
			delete [dbo].[HR_Transfer] where Employee_ID=@Employee_ID and TypeOfTransfer=@TypeOfTransfer and TransferCode=@TransferCode and EffectiveDate=@EffectiveDate
		end
		set @OldEmployee_ID=@Employee_ID set @OldTransferCode=@TransferCode set @OldEffectiveDate=@EffectiveDate set @OldTypeOfTransfer=@TypeOfTransfer
	FETCH NEXT FROM cur INTO @Employee_ID,@TransferCode,@EffectiveDate,@TypeOfTransfer
	END
	CLOSE cur
	DEALLOCATE cur
END

GO
