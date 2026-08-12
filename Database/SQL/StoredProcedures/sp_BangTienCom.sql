-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-- exec sp_BangTienCom '2025-10-03','2025-10-15',3,N'VN',N'',N'',N'',N'',N'',N''
-- SELECT * FROM [dbo].[udf_EmployeeFilter]('VN', NULL, NULL, NULL, NULL, NULL, NULL, NULL, GETDATE())
CREATE PROCEDURE [dbo].[sp_BangTienCom]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@emp nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @TypeOfReport=1 begin
		select
			empl.Position
			,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Employee_ID
			,empl.StartedDate,c.TienCom,c.Ngay,c.Remark,c.InsertDate,c.UserName,c.ID
		from
		HR_TienCom c
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		on c.Employee_ID=empl.Employee_ID
		where c.Ngay between @fromdate and @todate
			and empl.Employee_ID is not null
	end else if @TypeOfReport = 2 begin
		select
			empl.Position
			,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Employee_ID
			,empl.StartedDate,c.TienCom,c.Ngay,c.Remark,c.InsertDate,c.UserName,c.ID
		from
		HR_TienCom c
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		on c.Employee_ID=empl.Employee_ID
		where c.Ngay between @fromdate and @todate
			and empl.Employee_ID is not null
	end else if @TypeOfReport = 3 begin
		-- Thống kê số lượng cho 3 dòng (Cơm thường, Cơm chay, Không ăn) cho 2 cột Cơm trưa và cơm tối
		select * from ( -- Bảng chính
			-- Cơm thường
			select 
				d.Ngay,
				N'Cơm thường' as LoaiCom,
				isnull(t.TongNguoi, 0) - isnull(dk.ComTruaChay, 0) - isnull(dk.ComTruaKhongAn, 0) as ComTrua,
				isnull(t.TongNguoi, 0) - isnull(dk.ComToiChay, 0) - isnull(dk.ComToiKhongAn, 0) as ComToi
			from
			(
				select distinct cast(AccessDate as date) as Ngay
				from HR_TimeKeeping_Data
				where AccessDate between @fromdate and @todate
			) as d
			left join -- Bảng phụ (lấy dữ liệu khớp với ngày)
			(
				-- Đếm số người quẹt thẻ buổi sáng
				select cast(tk.AccessDate as date) as Ngay,
				count(distinct tk.Employee_ID) as TongNguoi
				from HR_TimeKeeping_Data tk
				inner join [dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
				on tk.Employee_ID=empl.Employee_ID
				where tk.AccessDate between @fromdate and @todate
				and cast(tk.AccessTime as time) between '05:00:00' and '12:00:00'
				group by cast(tk.AccessDate as date)
			) as t
			on d.Ngay = t.Ngay
			left join -- Bảng phụ (lấy dữ liệu khớp với ngày)
			(
				-- Đếm số người dk Cơm chay và không ăn
				select
					dk.Ngay,
					sum(case when dk.ComTrua = 'ComChay' then 1 else 0 end) as ComTruaChay,
					sum(case when dk.ComTrua is null then 1 else 0 end) as ComTruaKhongAn,
					sum(case when dk.ComToi = 'ComChay' then 1 else 0 end) as ComToiChay,
					sum(case when dk.ComToi is null then 1 else 0 end) as ComToiKhongAn
				from HR_DangKyCom dk
				inner join [dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
				on dk.Employee_ID=empl.Employee_ID
				where dk.Ngay between @fromdate and @todate
				group by dk.Ngay
			)  as dk
			on d.Ngay = dk.Ngay
			
			union all
			-- Cơm chay
			select
				d.Ngay,
				N'Cơm chay' as LoaiCom,
				isnull(dk.ComTruaChay, 0) as ComTrua,
				isnull(dk.ComToiChay, 0) as ComToi
			from
			(
				select distinct cast(AccessDate as date) as Ngay
				from HR_TimeKeeping_Data
				where AccessDate between @fromdate and @todate
			) as d
			left join
			(
				select
					dk.Ngay,
					sum(case when dk.ComTrua = 'ComChay' then 1 else 0 end) as ComTruaChay,
					sum(case when dk.ComToi = 'ComChay' then 1 else 0 end) as ComToiChay
				from HR_DangKyCom dk
				inner join [dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
					on dk.Employee_ID = empl.Employee_ID
				where dk.Ngay between @fromdate and @todate
				group by dk.Ngay
			) as dk
			on d.Ngay = dk.Ngay

			union all

			--Không ăn
			select 
				d.Ngay,
				N'Không ăn' as LoaiCom,
				isnull(dk.ComTruaKhongAn, 0) as ComTrua,
				isnull(dk.ComToiKhongAn, 0) as ComToi
			from
			(
				select distinct cast(AccessDate as date) as Ngay
				from HR_TimeKeeping_Data
				where AccessDate between @fromdate and @todate
			) as d
			left join
			(
				select 
					dk.Ngay,
					sum(case when dk.ComTrua = 'KhongAn' then 1 else 0 end) as ComTruaKhongAn,
					sum(case when dk.ComToi = 'KhongAn' then 1 else 0 end) as ComToiKhongAn
				from HR_DangKyCom dk
				inner join [dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
					on dk.Employee_ID = empl.Employee_ID
				where dk.Ngay between @fromdate and @todate
				group by dk.Ngay
			) as dk
			on d.Ngay = dk.Ngay
		) as result
		-- Sắp xếp theo ngày, thứ tự Cơm
		order by result.Ngay,
		case result.LoaiCom
			when N'Cơm thường' then 1
			when N'Cơm chay' then 2
			when N'Không ăn' then 3
		end
	end	 
END 

GO
