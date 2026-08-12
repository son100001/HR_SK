CREATE procedure sp_ListBaoCom
@LoaiCom nvarchar(50),
@Date datetime,
@LAN nvarchar(50) = 'EN'
as
--exec sp_ListBaoCom '1', '2025-08-07', 'VN'
begin
	if (@LoaiCom = 'ComTrua' or @LoaiCom = '1') begin
		select Category as Code, case when @LAN = 'KR' then NameKR when @LAN = 'VN' then NameVN else NameEN end as [Name]
		from
		HR_Category
		where CategoryFather = 'BaoCom' and Category in ('ComChay','KhongAn')
	end 
	else if (@LoaiCom = 'ComChieu' or @LoaiCom = '2' and DATENAME(dw,@Date) in ('Tuesday','Thursday')) begin
		select Category as Code, case when @LAN = 'KR' then NameKR when @LAN = 'VN' then NameVN else NameEN end as [Name]
		from
		HR_Category
		where CategoryFather = 'BaoCom'
	end
	else if (@LoaiCom = 'ComChieu' or @LoaiCom = '2' and DATENAME(dw,@Date) in ('Monday','Wednesday','Friday','Saturday','Sunday')) begin
		select Category as Code, case when @LAN = 'KR' then NameKR when @LAN = 'VN' then NameVN else NameEN end as [Name]
		from
		HR_Category
		where CategoryFather = 'BaoCom' and Category in ('ComChay','KhongAn')
	end
end


GO
