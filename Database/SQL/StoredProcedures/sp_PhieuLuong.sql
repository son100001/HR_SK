create proc [dbo].[sp_PhieuLuong]
	@Month int,
	@Year int,
	@TypeOfReport int=1,--1:danh sách lương;2:Phiếu lương; 5: Văn phòng; 6: Công nhân
	@LAN nvarchar(50)='VN',
	@userName nvarchar(50)=null,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@SalaryKey varchar(50)=null,
	@ListOfID varchar(max)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @NgayTraLuong datetime,@NgayDauThang datetime,@NgayCuoiThang datetime,@TrangThaiKH bit,@tygia float
	set @NgayDauThang=datefromparts(@Year,@month,1)
	set @NgayCuoiThang= dateadd(day,-1,dateadd(month,1,@NgayDauThang))
	select @tygia=Value from HR_SetUpFollowDate where Fromdate<=@NgayCuoiThang and (Todate is null or todate>=@NgayCuoiThang) order by Fromdate asc
	select top 1 @NgayTraLuong=PayDate from SmartBooks_Salary where Salary_Month=@Month and Salary_Year=@Year and (case when @SalaryKey is null or @SalaryKey='' then '' else [key] end)=(case when @SalaryKey is null or @SalaryKey='' then '' else @SalaryKey end)
	-- set @TrangThaiKH=[dbo].[udf_TrangThaiKH](@UserName)
	--if @TrangThaiKH=1 and @SalaryKey<>'ThuongThang13' begin
	--	set @SalaryKey=@SalaryKey+'_TachCong'
	--end
	if @TypeOfReport=1 begin
		select 
		s.Employee_ID
		,empl.FactoryName
		,empl.DepartmentName
		,empl.PositionName
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		,empl.StartedDate,empl.Employee_Status,empl.TernimationDate,empl.MaSoThue
		,empl.ID_number,case when empl.BankAccount is null then N'TienMat' else empl.BankAccount end as BankAccount
		,s.*,null as LuongThang13
		,TrangThai,null as No_
		,TongThuNhap		
		,null as TBHNLD,null as TBHCTY,null as CDOANCT,PCDNLD
		,null as ThuBHNLD
		,PIT
		,ThucLanh
		,s.ID
		,s.ID as [key]
		,s.UserName
		,s.InsertDate
		,s.[key] as code
		,ISNULL(s53,0) + ISNULL(s54,0) +	ISNULL(s55,0) as bhnld
		,ISNULL(s41,0) as bhcty
		,ISNULL(s1,0) as lcb
		from
		SmartBooks_Salary s
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,isnull(@NgayTraLuong,getdate())) empl
		on s.Employee_ID=empl.Employee_ID
		where Salary_Month=@Month and Salary_Year=@Year
		--and s.Employee_ID in (select Data from Split(@ListOfID,','))
		order by empl.SectionCode,empl.DepartmentName,empl.Employee_ID asc
	end
end
GO
