CREATE function [dbo].[udf_ListBaoCom]
(
	@LoaiCom nvarchar(50),
	@Date datetime,
	@LAN nvarchar(50) = 'EN'
)
returns @rtnListBaoCom table (Code nvarchar(50), [Name] nvarchar(50))
as
--select * from udf_ListBaoCom ('1', '2025-08-07', 'VN')
begin
	set @Date = isnull(@date,Getdate())
	if (@LoaiCom = 'ComTrua' or @LoaiCom = '1') begin
		insert into @rtnListBaoCom
		select Category as Code, case when @LAN = 'KR' then NameKR when @LAN = 'VN' then NameVN else NameEN end as [Name]
		from
		HR_Category
		where CategoryFather = 'BaoCom' and Category in ('ComChay','KhongAn')
	end 
	else if (@LoaiCom = 'ComChieu' or @LoaiCom = '2' and DATENAME(dw,@Date) in ('Tuesday','Thursday')) begin
		insert into @rtnListBaoCom
		select Category as Code, case when @LAN = 'KR' then NameKR when @LAN = 'VN' then NameVN else NameEN end as [Name]
		from
		HR_Category
		where CategoryFather = 'BaoCom'
	end
	else if (@LoaiCom = 'ComChieu' or @LoaiCom = '2' and DATENAME(dw,@Date) in ('Monday','Wednesday','Friday','Saturday','Sunday')) begin
		insert into @rtnListBaoCom
		select Category as Code, case when @LAN = 'KR' then NameKR when @LAN = 'VN' then NameVN else NameEN end as [Name]
		from
		HR_Category
		where CategoryFather = 'BaoCom' and Category in ('ComChay','KhongAn')
	end

	return;
end


GO
