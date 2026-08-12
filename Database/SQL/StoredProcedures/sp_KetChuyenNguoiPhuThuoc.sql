-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec sp_KetChuyenNguoiPhuThuoc '1999-1-1','2026-04-30'
CREATE PROCEDURE [dbo].[sp_KetChuyenNguoiPhuThuoc]
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
	declare @NumberTable table (Number int)
	insert into @NumberTable
	values (1), (2), (3), (4), (5), (6), (7)
	--kết chuyển dữ liệu nhân viên
		delete HR_DanhSachNguoiPhuThuoc
		--where AccessDate between @fromdate and @todate
		INSERT INTO HR_DanhSachNguoiPhuThuoc
		(
		Employee_ID,
		RelatedType
		,RelatedName
		,DependFromMonth
		,DependToMonth
		,Remark
		,InsertDate
		,UserName
		,BirthDate
	
		 )
     select 
		Employee_ID
		,6
		,CASE 
		 --when ef.Related_Name is null then'Nguyen Van E'
		 WHEN nt.Number = 1 THEN 'Nguyen Van A'
		   WHEN nt.Number = 2 THEN 'Nguyen Van B'
		   WHEN nt.Number = 3 THEN 'Nguyen Van C'
		   WHEN nt.Number = 4 THEN 'Nguyen Van D'
		   WHEN nt.Number = 5 THEN 'Nguyen Van E'
		   WHEN nt.Number = 6 THEN 'Nguyen Van G'
		   WHEN nt.Number = 7 THEN 'Nguyen Van H'
           ELSE ''
       END as RelatedName
		,DP_StartDate
		,null
		,ef.Comment
		,null
		,CreateBy
		,DP_StartDate
		from 
		@NumberTable nt
		left join
		(
			select Employee_ID, DependentPerson, DP_StartDate, Comment, CreateBy, ROW_NUMBER() over (partition by Employee_ID order by Dp_StartDate desc) as rn
			from
			HR_SnK.[dbo].HR_DependentPerson ef
			where DP_StartDate <= @todate
		) ef
		on nt.Number <= ef.DependentPerson and ef.rn = 1
		where ef.Employee_ID is not null
		--where AccessDate between @fromdate and @todate
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
