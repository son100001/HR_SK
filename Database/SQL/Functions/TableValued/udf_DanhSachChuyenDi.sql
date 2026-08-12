--select * from [dbo].[udf_DanhSachChuyenDi]('2020-5-1','2020-5-30','X05',null)
CREATE FUNCTION [dbo].[udf_DanhSachChuyenDi]
(
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime,
	@ChuyenTuXuong nvarchar(50)=NULL,
	@empl nvarchar(50)=null
)
RETURNS  @rtnDanhSachChuyenDi TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),EffectiveDate datetime,OldPosition nvarchar(50),NewPosition nvarchar(50)
)
AS
BEGIN
	DECLARE @Employee_ID nvarchar(50),@EffectiveDate datetime,@OldPosition nvarchar(50),@NewPosition nvarchar(50)
	DECLARE cur CURSOR LOCAL FOR
	select Employee_id,EffectiveDate,[TransferCode] from HR_Transfer
	where EffectiveDate between @fromdate and @todate and [TypeOfTransfer]='Position' and AssignType='TRF'
		and (case when @Empl is null or @Empl='' then '' else Employee_ID end)=(case when @Empl is null or @Empl='' then '' else @Empl end)
		and (case when len([TransferCode])-len(REPLACE([TransferCode],'_',''))=0 then [TransferCode] else LEFT([TransferCode], CHARINDEX('_', [TransferCode])-1) end) not in (select data from [dbo].[Split](case when @ChuyenTuXuong is null or @ChuyenTuXuong='' then '' else @ChuyenTuXuong end,','))
	OPEN  cur
	FETCH NEXT FROM cur INTO @Employee_ID,@EffectiveDate,@NewPosition
	WHILE @@FETCH_STATUS = 0
	BEGIN
		set @OldPosition=null
		select top 1 @OldPosition=[TransferCode] from [dbo].[HR_Transfer]
		where [TypeOfTransfer]='Position' and EffectiveDate<@EffectiveDate and employee_id=@Employee_ID
			and (case when isnull(@ChuyenTuXuong,'')='' then '' else (case when len([TransferCode])-len(REPLACE([TransferCode],'_',''))=0 then [TransferCode] else LEFT([TransferCode], CHARINDEX('_', [TransferCode])-1) end)end) in (select data from [dbo].[Split](case when @ChuyenTuXuong is null or @ChuyenTuXuong='' then '' else @ChuyenTuXuong end,','))
		order by EffectiveDate desc
		if @OldPosition is not null begin
			insert into @rtnDanhSachChuyenDi values(@Employee_ID,@EffectiveDate,@OldPosition,@NewPosition)
		end
	FETCH NEXT FROM cur INTO @Employee_ID,@EffectiveDate,@NewPosition
	END
	CLOSE cur
	DEALLOCATE cur
	-- Return the result of the function
	RETURN 

END




GO
