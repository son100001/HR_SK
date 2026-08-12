CREATE FUNCTION [dbo].[udf_TraVeNghiKhongPhep5LanTrong30Ngay]
(
	-- Add the parameters for the function here
	--select * from udf_TraVeNghiKhongPhep5LanTrong30Ngay('2019-12-1','2019-12-10')
	@fromdate datetime,
	@todate datetime,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Emp nvarchar(50)=null
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),[DanhSachNgayNghiKP] nvarchar(100),primary key ([Employee_ID])
)
AS
BEGIN
	declare @Employee_ID nvarchar(50),@DanhSachNgayNghiKP nvarchar(100),@Dateleave datetime,@Employee_IDDaXuLy nvarchar(max)
	
	set @Employee_IDDaXuLy=''
	DECLARE cur CURSOR LOCAL FOR
	select Employee_ID,Dateleave from [dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@Emp,null)
	where LeaveType_ID in (select LeaveType_ID from SmartBooks_LeaveType where NotAllow=1)
	order by Employee_ID,Dateleave desc
	OPEN  cur
	FETCH NEXT FROM cur INTO @Employee_ID,@Dateleave
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if @employee_id not in (select data from split(@Employee_IDDaXuLy,';')) and exists(select count(Employee_ID) from [dbo].[udf_BangPhepTheoNgay](2,DATEADD(day,-30,@Dateleave),@Dateleave,null,null,null,null,null,null,@Employee_ID,null) where LeaveType_ID in (select LeaveType_ID from SmartBooks_LeaveType where NotAllow=1) having count(Employee_ID)>=5) begin
			set @DanhSachNgayNghiKP=''
			select @DanhSachNgayNghiKP=@DanhSachNgayNghiKP+CONVERT(varchar,DateLeave,103)+';' from [dbo].[udf_BangPhepTheoNgay](2,DATEADD(day,-30,@Dateleave),@Dateleave,@fact,@dept,@sect,@team,@pos,@posc,@Employee_ID,null) where LeaveType_ID in (select LeaveType_ID from SmartBooks_LeaveType where NotAllow=1) order by dateleave
			insert into @rtnTable(Employee_ID,DanhSachNgayNghiKP) values(@Employee_ID,@DanhSachNgayNghiKP)
			set @Employee_IDDaXuLy=@Employee_IDDaXuLy+@Employee_ID+';'
		end
	FETCH NEXT FROM cur INTO @Employee_ID,@Dateleave
	END
	CLOSE cur
	DEALLOCATE cur
	
	Return
	
END




GO
