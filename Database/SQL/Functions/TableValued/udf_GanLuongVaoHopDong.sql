CREATE FUNCTION [dbo].[udf_GanLuongVaoHopDong]--CL_StartDate trong khoang @fromdate and @todate 
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_GanLuongVaoHopDong]('2019-3-1','2020-3-31',1)
	@fromdate datetime,
	@todate datetime,
	@FollowCL_StartDate bit
)
RETURNS  @rtnGanLuongVaoHopDong TABLE 
(
    -- columns returned by the function
    Contract_ID NVARCHAR(50),[Employee_ID] nvarchar(50),CL_StartDate datetime,MucLuong float,CD1 float,CD2 float,CD3 float,CD4 float,CD5 float,CD6 float,CD7 float,CD8 float,CD9 float,CD10 float,CD11 float,CD12 float,CD13 float,CD14 float,CD15 float,CD16 float,CD17 float,CD18 float,CD19 float,CD20 float,BacTayNghe float,primary key ([Employee_ID],CL_StartDate)
)
AS
BEGIN
	DECLARE @Contract_ID NVARCHAR(50),@CL_StartDate datetime,@Employee_ID nvarchar(50),@CD1 as float,@CD2 as float,@CD3 as float,@CD4 as float,@CD5 as float,@CD6 as float,@CD7 as float,@CD8 as float,@CD9 as float,@CD10 as float,@CD11 as float,@CD12 as float,@CD13 as float,@CD14 as float,@CD15 as float,@CD16 as float,@CD17 as float,@CD18 as float,@CD19 as float,@CD20 as float, @BacTayNghe as float
		,@MucLuong float
	DECLARE @HopDong TABLE
	(
		Employee_ID nvarchar(50) NOT NULL, 
		Contract_ID nvarchar(50) NOT NULL,
		CL_StartDate datetime,
		primary key (Employee_ID,CL_StartDate)
	)
	insert into @HopDong 
	SELECT Employee_ID,Contract_ID,CL_StartDate from [dbo].[udf_HopDongTuSinh](@fromdate,@todate,@FollowCL_StartDate,'',null,null,null,null,null,null,null)


	DECLARE cur CURSOR LOCAL FOR
	SELECT * from @HopDong
	--SmartBooks_Contract ct
	--on ctl.[Type]=ct.Contract_ID
	--where (Case when @FollowCL_StartDate=1 then CL_StartDate else CL_ExpiredDate end)between @fromdate AND @todate
	OPEN  cur
	FETCH NEXT FROM cur INTO @Employee_ID,@Contract_ID,@CL_StartDate
	WHILE @@FETCH_STATUS = 0
	BEGIN
		--insert into @rtnGanLuongVaoHopDong(Contract_ID) values(@Contract_ID)
		select @CD1=null,@CD2=null,@CD3=null,@CD4=null,@CD5=null,@CD6=null,@CD7=null,@CD8=null,@CD9=null,@CD10=null,@CD11=null,@CD12=null,@CD13=null,@CD14=null,@CD15=null,@CD16=null,@CD17=null,@CD18=null,@CD19=null,@CD20=null
		select @MucLuong=MucLuong FROM [dbo].[udf_MucLuongCuaCongNhanVien](@CL_StartDate,@Employee_ID)
		select @CD1=CD1,@CD2=CD2,@CD3=CD3,@CD4=CD4,@CD5=CD5,@CD6=CD6,@CD7=CD7,@CD8=CD8,@CD9=CD9,@CD10=CD10,@CD11=CD11,@CD12=CD12,@CD13=CD13,@CD14=CD14,@CD15=CD15,@CD16=CD16,@CD17=CD17,@CD18=CD18,@CD19=CD19,@CD20=CD20 from [dbo].[udf_BangLuongCoDinh](@CL_StartDate,@Employee_ID)
		select @BacTayNghe=Amount from [dbo].[udf_BacTayNgheCuaCongNhanVien](@CL_StartDate, @Employee_ID)
		insert into @rtnGanLuongVaoHopDong (Contract_ID,Employee_ID,CL_StartDate,MucLuong,CD1,CD2,CD3,CD4,CD5,CD6,CD7,CD8,CD9,CD10,CD11,CD12,CD13,CD14,CD15,CD16,CD17,CD18,CD19,CD20,BacTayNghe)
			values(@Contract_ID,UPPER(@Employee_ID),@CL_StartDate,@MucLuong,@CD1,@CD2,@CD3,@CD4,@CD5,@CD6,@CD7,@CD8,@CD9,@CD10,@CD11,@CD12,@CD13,@CD14,@CD15,@CD16,@CD17,@CD18,@CD19,@CD20,@BacTayNghe)
	FETCH NEXT FROM cur INTO @Employee_ID,@Contract_ID,@CL_StartDate
	END
	CLOSE cur
	DEALLOCATE cur

	RETURN

END




GO
