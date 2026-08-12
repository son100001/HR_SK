CREATE function udf_FactorySK2
(
	@LAN nvarchar(50)
)
returns @rtnFactorySK2 table ([Code] nvarchar(50), [Name] nvarchar(50), primary key ([Code]))
--select * from udf_FactorySK2 ('VN')
as
begin
	insert into @rtnFactorySK2 ([Code], [Name])
	values ('SK2-Assembly','SK2-Assembly'), ('SK2-Machinery','SK2-Machinery'), ('SK2-QC','SK2-QC')
	return
end
GO
