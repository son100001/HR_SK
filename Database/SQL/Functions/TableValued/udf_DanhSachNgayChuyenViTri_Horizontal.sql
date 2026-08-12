--SELECT * FROM [dbo].[udf_DanhSachNgayChuyenViTri_Horizontal]('Position','')
CREATE FUNCTION [dbo].[udf_DanhSachNgayChuyenViTri_Horizontal]
(
	-- Add the parameters for the function here
	@TypeOfTransfer varchar(50),
	@Empl nvarchar(50)
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),[ncvt01] nvarchar(200),[ncvt02] nvarchar(200),[ncvt03] nvarchar(200),[ncvt04] nvarchar(200),[ncvt05] nvarchar(200),[ncvt06] nvarchar(200),[ncvt07] nvarchar(200),[ncvt08] nvarchar(200),[ncvt09] nvarchar(200),[ncvt10] nvarchar(200),[ncvt11] nvarchar(200),[ncvt12] nvarchar(200),[ncvt13] nvarchar(200),[ncvt14] nvarchar(200),[ncvt15] nvarchar(200),[ncvt16] nvarchar(200),[ncvt17] nvarchar(200),[ncvt18] nvarchar(200),[ncvt19] nvarchar(200),[ncvt20] nvarchar(200), primary key ([Employee_ID])
)
AS
BEGIN
	insert into @rtnTable
	select Employee_ID,[01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12],[13],[14],[15],[16],[17],[18],[19],[20] from
	(
		SELECT
			Employee_ID,convert(varchar, effectiveDate, 103)+': '+p.Name as ThongTinViTri,
			s_index = ROW_NUMBER() OVER(PARTITION BY [Employee_ID] ORDER BY effectiveDate)
		FROM
		dbo.hr_transfer t
		left join
		[dbo].[udf_Position]('VN',0) p
		on t.TransferCode=p.Code
		where TypeOfTransfer=@TypeOfTransfer and (case when ISNULL(@Empl,'')='' then '' else Employee_ID end)=ISNULL(@Empl,'')
	)as st
	PIVOT  
	(  
	  max([ThongTinViTri])
	  FOR s_index IN ([01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12],[13],[14],[15],[16],[17],[18],[19],[20])
	) AS PivotTable;

	-- Return the result of the function
	RETURN 

END




GO
