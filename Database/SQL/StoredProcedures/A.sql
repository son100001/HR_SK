-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[A]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Contract_ID VARCHAR(50),@CL_StartDate datetime,@Employee_ID nvarchar(50)
	DECLARE cur CURSOR LOCAL FOR
	SELECT ctl.Employee_ID,ctl.Contract_ID,ctl.CL_StartDate FROM
	[dbo].[udf_HopDongTuSinh]('2020-3-1','2020-3-31',1,'',null,null,null,null,null,null,null) ctl
	left join
	SmartBooks_Contract ct
	on ctl.[Type]=ct.Contract_ID
	where (Case when 1=1 then CL_StartDate else CL_ExpiredDate end)between '2020-3-1' AND '2020-3-31'
	OPEN  cur
	FETCH NEXT FROM cur INTO @Employee_ID,@Contract_ID,@CL_StartDate
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @Contract_ID=111
		--insert into @rtnGanLuongVaoHopDong (Contract_ID,Employee_ID,MucLuong)
		--select @Contract_ID,Employee_ID,MucLuong FROM [dbo].[udf_MucLuongCuaCongNhanVien](@CL_StartDate,@Employee_ID)
		--if exists(select * from @rtnGanLuongVaoHopDong where Contract_ID=@Contract_ID) begin
		--	update gl set gl.CD1=lcd.CD1,gl.CD2=lcd.CD2,gl.CD3=lcd.CD3,gl.CD4=lcd.CD4,gl.CD5=lcd.CD5,gl.CD6=lcd.CD6,gl.CD7=lcd.CD7,gl.CD8=lcd.CD8,gl.CD9=lcd.CD9,gl.CD10=lcd.CD10,gl.CD11=lcd.CD11,gl.CD12=lcd.CD12,gl.CD13=lcd.CD13,gl.CD14=lcd.CD14,gl.CD15=lcd.CD15,gl.CD16=lcd.CD16,gl.CD17=lcd.CD17,gl.CD18=lcd.CD18,gl.CD19=lcd.CD19,gl.CD20=lcd.CD20
		--	from
		--	@rtnGanLuongVaoHopDong gl
		--	inner join
		--	[dbo].[udf_BangLuongCoDinh](@CL_StartDate,@Employee_ID) lcd
		--	on gl.Employee_ID=lcd.Employee_ID
		--end else begin
		--	insert into @rtnGanLuongVaoHopDong (Contract_ID,Employee_ID,CD1,CD2,CD3,CD4,CD5,CD6,CD7,CD8,CD9,CD10,CD11,CD12,CD13,CD14,CD15,CD16,CD17,CD18,CD19,CD20)
		--	select @Contract_ID,Employee_ID,CD1,CD2,CD3,CD4,CD5,CD6,CD7,CD8,CD9,CD10,CD11,CD12,CD13,CD14,CD15,CD16,CD17,CD18,CD19,CD20 from [dbo].[udf_BangLuongCoDinh](@CL_StartDate,@Employee_ID)
		--end 
	FETCH NEXT FROM cur INTO @Employee_ID,@Contract_ID,@CL_StartDate
	END
	CLOSE cur
	DEALLOCATE cur
END



GO
