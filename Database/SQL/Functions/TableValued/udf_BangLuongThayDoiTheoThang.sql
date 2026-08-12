--select * from [dbo].[udf_BangLuongCoDinh]('2023-10-31',null) where Employee_ID = 'M01471'
--select * from [dbo].[udf_BangLuongThayDoiTheoThang](10,2023,null) where Employee_ID = 'M01471'
CREATE FUNCTION [dbo].[udf_BangLuongThayDoiTheoThang]
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_ReturnTableSetupHourTimeKeeping]('03-Shift3','2023-10-31',0)
	@Month int,
	@Year int,
	@Emp nvarchar(50)
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
	[Employee_ID] [nvarchar](50) NOT NULL,
	[HT1] float,
	[HT2] float,
	[HT3] float,
	[HT4] float,
	[HT5] float,
	[HT6] float,
	[HT7] float,
	[HT8] float,
	[HT9] float,
	[HT10] float,
	[HT11] float,
	[HT12] float,
	[HT13] float,
	[HT14] float,
	[HT15] float,
	[HT16] float,
	[HT17] float,
	[HT18] float,
	[HT19] float,
	[HT20] float
	,primary key ([Employee_ID])
)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Employee_ID nvarchar(50),@SalaryComponent varchar(50),@Amount float,@OrderBy int
	DECLARE cur CURSOR LOCAL FOR
	select sfm.Employee_ID,sfm.Amount,DanhMucLuong.OrderBy from
	[dbo].[HR_SalaryComponentFollowMonth] sfm
	left join
	HR_SalaryComponentCategory DanhMucLuong
	on sfm.SalaryComponent=DanhMucLuong.SalaryComponent
	where (case when isnull(@Emp,'')='' then '' else sfm.Employee_ID end)=isnull(@Emp,'')
		and sfm.Month_=@Month and sfm.Year_=@Year
	OPEN  cur
	FETCH NEXT FROM cur INTO @Employee_ID,@Amount,@OrderBy
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if @OrderBy=1 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT1]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT1]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=2 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT2]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT2]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=3 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT3]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT3]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=4 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT4]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT4]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=5 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT5]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT5]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=6 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT6]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT6]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=7 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT7]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT7]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=8 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT8]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT8]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=9 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT9]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT9]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=10 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT10]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT10]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=11 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT11]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT11]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=12 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT12]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT12]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=13 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT13]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT13]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=14 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT14]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT14]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=15 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT15]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT15]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=16 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT16]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT16]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=17 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT17]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT17]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=18 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT18]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT18]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=19 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT19]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT19]) values(@Employee_ID,@Amount)
			end
		end else if @OrderBy=20 begin
			if exists(select Employee_ID from @rtnTable where Employee_ID=@Employee_ID) begin
				update @rtnTable set [HT20]=@Amount where Employee_ID=@Employee_ID
			end else begin
				insert into @rtnTable(Employee_ID,[HT20]) values(@Employee_ID,@Amount)
			end
		end
	FETCH NEXT FROM cur INTO @Employee_ID,@Amount,@OrderBy
	END
	CLOSE cur
	DEALLOCATE cur

	RETURN
END



GO
