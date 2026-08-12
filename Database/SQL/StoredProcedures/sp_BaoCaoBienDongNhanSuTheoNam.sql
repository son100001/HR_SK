
CREATE  PROCEDURE [dbo].[sp_BaoCaoBienDongNhanSuTheoNam]
	-- Add the parameters for the stored procedure here
	@Year as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @tab table(Month_ nvarchar(20),NewCome float,Terminated float)
	declare @MonthNext int,@NewCome float,@Terminated float
	set @MonthNext=1
	while @MonthNext<=12
	begin
		select @NewCome=count(Employee_ID) from SmartBooks_Employee where DATEPART(month,StartedDate)=@MonthNext and DATEPART(YEAR,StartedDate)=@Year
		select @Terminated=count(Employee_ID) from SmartBooks_Employee where DATEPART(month,TernimationDate)=@MonthNext and DATEPART(YEAR,TernimationDate)=@Year
		insert into @tab(Month_,NewCome,Terminated) values(cast(@MonthNext as nvarchar(20)),@NewCome,@Terminated)
		set @MonthNext=@MonthNext+1
	end
	select * from @tab
END

--exec sp_BaoCaoBienDongNhanSuTheoNam '2016'




GO
