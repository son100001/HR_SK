-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec sp_KetChuyenDuLieuGiaDinh '2010-03-01','2026-03-31'
CREATE PROCEDURE [dbo].[sp_KetChuyenDuLieuGiaDinh]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRY
    BEGIN TRANSACTION
	--kết chuyển dữ liệu nhân viên
		delete SmartBooks_Employee_Family
		where InsertDate between @fromdate and @todate and UserName = 'Auto'
		INSERT INTO SmartBooks_Employee_Family
		(
		Employee_ID
		, RelatedName
		, Tel
		, RelatedType
		, [Address]
		, Occupation
		, BirthDate
		, Sex
		, GKS_So
		, GKS_QuyenSo
		, GKS_TinhTP
		, GKS_QuanHuyen
		, GKS_PhuongXa
		, MaSoThue
		, QuocTich
		, ID_Number
		, ID_date
		, ID_place
		, DependFromMonth
		, DependToMonth
		, BabyCareStartDate
		, DateOfDeath
		, Remark
		, UserName
		, InsertDate
		, isDaNopGiay
		 )
     select 
		 ef.Employee_ID
		 ,CASE when ef.Related_Name is not null then ef.Related_Name
		 --when ef.Related_Name is null then'Nguyen Van E'
		 WHEN ef.rn = 1 THEN 'Nguyen Van A'
		   WHEN ef.rn = 2 THEN 'Nguyen Van B'
		   WHEN ef.rn = 3 THEN 'Nguyen Van C'
		   WHEN ef.rn = 4 THEN 'Nguyen Van D'
		   WHEN ef.rn = 5 THEN 'Nguyen Van E'
           ELSE ''
       END as RelatedName
		 ,null
		 ,CASE WHEN Upper(ef.Related_Type) IN ('Con', 'con','CON') THEN '6' ELSE NULL END
		 ,null
		 ,null
		 ,ef.BirthDate
		 ,Gender
		 ,null
		 ,null
		 ,null
		 ,null
		 ,null
		 ,null
		 ,QuocTich
		 ,null
		 ,null
		 ,null
		 ,null
		 ,null
		 ,null
		 ,null
		 ,null
		 ,'Auto'
		 ,Enterdate
		 ,null
		from (
		SELECT Employee_ID, Related_Name,Related_Type,BirthDate,Gender, QuocTich, UserName, Enterdate, ROW_NUMBER() OVER (PARTITION BY Employee_ID ORDER BY Employee_ID) as rn
		FROM HR_SNK.dbo.SmartBooks_Employee_Family
		where Enterdate between @fromdate and @todate
	) ef
		where ef.Related_Type is not null
	--update 
	--SmartBooks_Employee_Family
	--set RelatedName = case 
	--when [RelatedName] is null then 'Nguyen Van A'
	--else'' end
	--update 
	--SmartBooks_Employee_Family
	--set RelatedType = case 
	--when RelatedType= 'con' then '6'
	--when RelatedType='Con' then '6'
	--else'' end
    COMMIT TRAN -- Transaction Success!
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRAN --RollBack in case of Error

		-- <EDIT>: From SQL2008 on, you must raise error messages as follows:
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  

		SELECT   
		   @ErrorMessage = ERROR_MESSAGE(),  
		   @ErrorSeverity = ERROR_SEVERITY(),  
		   @ErrorState = ERROR_STATE();  

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);  
	
		-- </EDIT>
	END CATCH
END

GO
