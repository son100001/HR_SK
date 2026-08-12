CREATE FUNCTION [dbo].[udf_BangLuongCoDinh_Cu]
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_BangLuongCoDinh_Cu]('2025-08-01','2025-08-31',null)
	--select * from [dbo].[udf_BangLuongCoDinh]('2021-4-30','CG00004')
	@fromdate datetime,
	@todate datetime,
	@Emp nvarchar(50)
)
RETURNS  @rtnBangLuongCoDinh_Cu TABLE 
(
    -- columns returned by the function
	[Employee_ID] [nvarchar](50) NOT NULL,
	[CD1] float,
	[CD2] float,
	[CD3] float,
	[CD4] float,
	[CD5] float,
	[CD6] float,
	[CD7] float,
	[CD8] float,
	[CD9] float,
	[CD10] float,
	[CD11] float,
	[CD12] float,
	[CD13] float,
	[CD14] float,
	[CD15] float,
	[CD16] float,
	[CD17] float,
	[CD18] float,
	[CD19] float,
	[CD20] float
	,primary key ([Employee_ID])
)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Employee_ID nvarchar(50),@SalaryComponent varchar(50),@Amount float,@OrderBy int,@NgayKyHDChinhThuc datetime, @isThuViec85PhanTram bit



	DECLARE cur CURSOR LOCAL FOR
	select LuongChiTiet.Employee_ID,LuongChiTiet.Amount,DanhMucLuong.OrderBy,NgayKyHDChinhThuc,isThuViec85PhanTram from
	(
		select sc.Employee_ID,max(sc.fromdate) as fromdate,sc.SalaryComponent
		from
		[dbo].[HR_SalaryComponent] sc
		inner join
		[dbo].[udf_NgayDoiLuong](@fromdate,@todate) dl
		on sc.Employee_ID=dl.Employee_ID and sc.Fromdate<dl.Ngay
		where SalaryComponent in (select SalaryComponent from HR_SalaryComponentCategory where isnull(MonthlyChanging,0)=0) group by sc.Employee_ID,SalaryComponent
	) LuongHienTai
	left join
	[dbo].[HR_SalaryComponent] LuongChiTiet
	on LuongHienTai.Employee_ID=LuongChiTiet.Employee_ID and LuongHienTai.fromdate=LuongChiTiet.Fromdate and LuongHienTai.SalaryComponent=LuongChiTiet.SalaryComponent
	left join
	HR_SalaryComponentCategory DanhMucLuong
	on LuongHienTai.SalaryComponent=DanhMucLuong.SalaryComponent
	left join
	[dbo].[udf_NgayKyHDChinhThuc](@fromdate,@todate,@Emp) as nkhdct
	on LuongHienTai.Employee_ID=nkhdct.Employee_ID and nkhdct.NgayKyHDChinhThuc between @fromdate+1 and @todate
	left join
	smartbooks_employee empl
	on LuongHienTai.Employee_ID=empl.Employee_ID
	where (case when isnull(@Emp,'')='' then '' else LuongHienTai.Employee_ID end)=isnull(@Emp,'')
	OPEN  cur
	FETCH NEXT FROM cur INTO @Employee_ID,@Amount,@OrderBy,@NgayKyHDChinhThuc,@isThuViec85PhanTram
	WHILE @@FETCH_STATUS = 0
	BEGIN
		/*if @NgayKyHDChinhThuc is not null and @isThuViec85PhanTram=1 begin
			set @Amount=@Amount*85/100
		end*/
		if @OrderBy=1 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD1]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD1]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=2 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD2]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD2]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=3 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD3]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD3]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=4 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD4]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD4]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=5 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD5]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD5]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=6 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD6]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD6]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=7 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD7]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD7]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=8 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD8]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD8]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=9 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD9]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD9]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=10 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD10]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD10]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=11 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD11]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD11]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=12 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD12]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD12]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=13 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD13]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD13]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=14 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD14]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD14]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=15 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD15]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD15]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=16 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD16]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD16]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=17 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD17]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD17]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=18 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD18]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD18]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=19 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD19]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD19]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=20 begin
			if exists(select Employee_ID from @rtnBangLuongCoDinh_Cu where Employee_ID=@Employee_ID) begin
				update @rtnBangLuongCoDinh_Cu set [CD20]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnBangLuongCoDinh_Cu(Employee_ID,[CD20]) values(@Employee_ID,@Amount)
			end
		end
	FETCH NEXT FROM cur INTO @Employee_ID,@Amount,@OrderBy,@NgayKyHDChinhThuc,@isThuViec85PhanTram
	END
	CLOSE cur
	DEALLOCATE cur

	RETURN
END



GO
