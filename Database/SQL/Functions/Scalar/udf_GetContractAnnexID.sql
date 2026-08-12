CREATE function [dbo].[udf_GetContractAnnexID]
(
	@StartDate date
)
returns nvarchar(50)

	--Go
	--Select dbo.udf_GetContractAnnexID('2019-4-4')
	-- print dbo.udf_GetContractAnnexID()
As
Begin
	Declare @MaContractAnnexID nvarchar(50)
	Declare @MaxContractAnnexID nvarchar(50)
	Declare @Max int

	Select @MaxContractAnnexID = MAX(ContractAnnexID) from SmartBooks_ContractList sbcl
													  where [Type] = N'PLHD' 
													  and ( sbcl.CL_StartDate between (DATEADD(year, DATEDIFF(year, 0, @StartDate), 0)) 
													  and (DATEADD (day, -1, DATEADD(year, DATEDIFF(year, 0, @StartDate) +1, 0))) )

	If (@MaxContractAnnexID is null)
		set @Max = 1
	else
		set @Max = CONVERT(int, @MaxContractAnnexID) + 1
	
	set @MaContractAnnexID = CONVERT(nvarchar(50), @Max)
Return @MaContractAnnexID
End



GO
