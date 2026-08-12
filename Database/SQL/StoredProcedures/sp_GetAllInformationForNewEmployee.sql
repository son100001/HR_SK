
CREATE proc [dbo].[sp_GetAllInformationForNewEmployee]
(
	@LAN nvarchar(50) = 'VN',
	@TypeOfReport int = 1
)
-- exec [sp_GetAllInformationForNewEmployee] null, 3
as
begin
	Declare @tab table (ID int,Sex nvarchar(50), MaritalStatus nvarchar(50), Nationality nvarchar(50), Contract_ID nvarchar(50), QuanHeGiaDinh nvarchar(50), QuanHeGiaDinhCode nvarchar(50), PositionCategory_ID nvarchar(50), Position_ID nvarchar(50),ChucDanh nvarchar(50), TenDanToc nvarchar(50), MaDanToc nvarchar(50), SectionCode nvarchar(50), DepartmentCode nvarchar(50),TeamCode nvarchar(50), Factory_ID nvarchar(50), Graduated nvarchar(50),TypeOfHiring nvarchar(50))
	declare @i int = 1
	Declare @tabNghiViec table (ID int, CodeThoiViec nvarchar(50), LyDoThoiViec nvarchar(50), CodeTrangThai nvarchar(50), TrangThai nvarchar(50))

	If @TypeOfReport = 1 begin
		while @i <= 500 begin
			Insert into @tab (ID)
			values (@i)
			set @i = @i + 1
		end

		-- Update Sex
		update @tab set Sex = Cate.Category
		from @tab tab left join ( select ROW_Number() OVER(order by Category) as _ROW, Category from HR_Category where CategoryFather = 'Sex' ) Cate on Cate._ROW = tab.ID

		-- Update MaritalStatus
		update @tab set MaritalStatus = Cate.Category
		from @tab tab left join ( select ROW_Number() OVER(order by Category) as _ROW, Category from HR_Category where CategoryFather = 'MaritalStatus' ) Cate on Cate._ROW = tab.ID

		-- Update Nationality
		update @tab set Nationality = Cate.Category
		from @tab tab left join ( select ROW_Number() OVER(order by Category) as _ROW, Category from HR_Category where CategoryFather = 'Nationality' ) Cate on Cate._ROW = tab.ID

		-- Update ContractFlow
		update @tab set Contract_ID = HR_ContractFlow.ContractFlow
		from @tab tab left join ( select distinct ContractFlow, ROW_Number() OVER(order by ContractFlow) as _ROW from HR_ContractFlow where No_ = 1 ) HR_ContractFlow on HR_ContractFlow._ROW = tab.ID

		-- Update QuanHeGiaDinh
		update @tab set QuanHeGiaDinhCode = Cate.Category, QuanHeGiaDinh = Cate.NameVN
		from @tab tab left join ( select ROW_Number() OVER(order by Category) as _ROW, Category, NameVN from HR_Category where CategoryFather = 'QuanHeGiaDinh' ) Cate on Cate._ROW = tab.ID

		-- Update PositionCategory_ID
		update @tab set PositionCategory_ID = sbpc.PositionCategory_ID
		from @tab tab left join ( select PositionCategory_ID, ROW_Number() OVER(order by PositionCategory_ID) as _ROW from SmartBooks_PositionCategory ) sbpc on sbpc._ROW = tab.ID

		-- Update Position_ID
		update @tab set Position_ID = sbp.Position_ID
		from @tab tab left join ( select Position_ID, ROW_Number() OVER(order by Position_ID) as _ROW from SmartBooks_Position ) sbp on sbp._ROW = tab.ID

		-- Update ChucDanh
		update @tab set ChucDanh = sbp.ChucDanh
		from @tab tab left join ( select ChucDanh, ROW_Number() OVER(order by ChucDanh) as _ROW from HR_ChucDanh ) sbp on sbp._ROW = tab.ID

		-- Update TenDanToc, MaDanToc
		update @tab set TenDanToc = dantoc.TenDanToc, MaDanToc = dantoc.MaDanToc
		from @tab tab left join ( select TenDanToc, MaDanToc, ROW_Number() OVER(order by TenDanToc) as _ROW from HR_DanToc ) dantoc on dantoc._ROW = tab.ID

		-- Update SectionCode
		update @tab set SectionCode = sect.SectionCode
		from @tab tab left join ( select (Factory_ID+'_'+ DepartmentCode+'_'+ SectionCode) as SectionCode, ROW_Number() OVER(order by Factory_ID) as _ROW from SmartBooks_Section ) sect on sect._ROW = tab.ID

		-- Update DepartmentCode
		update @tab set DepartmentCode = sbd.Factory_ID+'_'+sbd.DepartmentCode
		from @tab tab left join ( select DepartmentCode, Factory_ID, ROW_Number() OVER(order by DepartmentCode) as _ROW from SmartBooks_Department) sbd on sbd._ROW = tab.ID
		-- Update Factory_ID
		update @tab set Factory_ID = sbd.Factory_ID
		from @tab tab left join ( select Factory_ID, ROW_Number() OVER(order by Factory_ID) as _ROW from HR_Factory ) sbd on sbd._ROW = tab.ID
		-- Update TeamCode
		update @tab set TeamCode = sbd.TeamCode
		from @tab tab left join ( select TeamCode, ROW_Number() OVER(order by TeamCode) as _ROW from SmartBooks_Team) sbd on sbd._ROW = tab.ID
		-- Update Graduated
		update @tab set Graduated = Cate.Category
		from @tab tab left join ( select ROW_Number() OVER(order by Category) as _ROW, Category, NameVN from HR_Category where CategoryFather = 'Graduated' ) Cate on Cate._ROW = tab.ID
		-- Update TypeOfHiring
		update @tab set TypeOfHiring = Cate.Category
		from @tab tab left join ( select ROW_Number() OVER(order by Category) as _ROW, Category, NameVN from HR_Category where CategoryFather = 'TypeOfHiring' ) Cate on Cate._ROW = tab.ID

		select * from @tab
	end else if @TypeOfReport = 2 begin
		select Category as Code_, Case when @LAN = 'VN' then NameVN when @LAN = 'EN' then NameEN else NameKR end as Name_
		from
		HR_Category
		where CategoryFather = 'QuanHeGiaDinh'
	end else if @TypeOfReport = 3 begin
		while @i <= 100 begin
			Insert into @tabNghiViec (ID)
			values (@i)
			set @i = @i + 1
		end

		update tnv
		set tnv.CodeThoiViec = ct.Category, tnv.LyDoThoiViec = Case when @LAN = 'VN' then ct.NameVN when @LAN = 'EN' then ct.NameEN else ct.NameKR end
		from
		@tabNghiViec tnv
		left join
		(
			select *, ROW_NUMBER () over (order by Category) as Row_
			from
			HR_Category ct
			where ct.CategoryFather = 'resigned'
		) ct
		on tnv.ID = ct.Row_

		update tnv
		set tnv.CodeThoiViec = ct.Category, tnv.LyDoThoiViec = Case when @LAN = 'VN' then ct.NameVN when @LAN = 'EN' then ct.NameEN else ct.NameKR end
		from
		@tabNghiViec tnv
		left join
		(
			select *, ROW_NUMBER () over (order by Category) as Row_
			from
			HR_Category ct
			where ct.CategoryFather = 'resigned'
		) ct
		on tnv.ID = ct.Row_

		update @tabNghiViec
		set CodeTrangThai = 'Approved', TrangThai = N'Duyệt'
		where ID = 1
		
		update @tabNghiViec
		set CodeTrangThai = 'Plan', TrangThai = N'Kế hoạch'
		where ID = 2

		select * from @tabNghiViec
	end
end


GO
