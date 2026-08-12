--exec usp_Company 'GetListData'
CREATE proc usp_Company
@Action nvarchar(50)
as
begin
	If @Action = 'GetListData' begin
		select CompanyID as cpnyID, company_name as cpnyName, Address_VN as [Address], null as Email
				, null as City, null as [State], null as Zip, null as Country, phone as Phone
				, fax as Fax, null as Director, null as Manager, null as ChiefAcct, null as ImpExpCode
				, null as BankAcct1, null as BankAcct2, null as BankAcct3, null as BankAcct4, null as BankAcct5
				, null as BankName1, null as BankName2, null as BankName3, null as BankName4, null as BankName5
				, null as S4Future01, null as S4Future02, null as S4Future03, null as CrtdUser, null as LUpdUser
				, null as Prepared, null as FiscalYear, GETDATE() as CrtdDate, GETDATE() as LUpdDate
		from
		SmartBooks_Company
	end
end
GO
