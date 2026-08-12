
--exec [sp_KetChuyenDuLieuHopDong] '1999-1-1','2025-7-15'
CREATE PROCEDURE [dbo].[sp_KetChuyenDuLieuHopDong]
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
		delete SmartBooks_ContractList
		where CL_StartDate between @fromdate and @todate or CL_ExpiredDate between @fromdate and @todate
		
		Declare @Smartbooks_ContractList table (Contract_ID nvarchar(50),Employee_ID nvarchar(50),CL_RegisterDate datetime,CL_ExpiredDate datetime,CL_StartDate datetime,[status] nvarchar(50),[Type] nvarchar(50),CL_FatherID nvarchar(50),CL_Remark nvarchar(50),InsertSource nvarchar(50),UserName nvarchar(50),InsertDate datetime, primary key (Employee_ID, CL_StartDate, [Type]))
		insert into @Smartbooks_ContractList (Contract_ID, Employee_ID, CL_RegisterDate, CL_ExpiredDate, CL_StartDate, [status], [Type], CL_FatherID, CL_Remark, InsertSource, UserName, InsertDate)
		select Contract_ID
		 ,Employee_ID
		 ,CL_RegisterDate
		 ,CL_ExpiredDate
		 ,CL_StartDate
		 ,[status]
		 ,[Type]
		 ,CL_FatherID
		 ,CL_Remark
		 ,'NhapTay'
		 ,UserName
		 ,InsertDate
		 from
		 (
			select ctl.Contract_ID, ctl.Employee_ID, ctl.CL_RegisterDate, ctl.CL_ExpiredDate, ctl.CL_StartDate, ctl.[status], ctl.[Type], ctl.CL_FatherID, ctl.CL_Remark, ctl.UserName, ctl.InsertDate
					, ROW_NUMBER () Over (Partition by Employee_ID, Contract_ID, CL_RegisterDate order by Employee_ID, CL_RegisterDate) as rn
			from HR_SNK.[dbo].SmartBooks_ContractList ctl
		) ctl
		where (CL_StartDate between @fromdate and @todate or CL_ExpiredDate between @fromdate and @todate) and ctl.rn = 1

		update sc
		set sc.Contract_ID = osc.Contract_ID
			, sc.CL_RegisterDate = osc.CL_RegisterDate
			, sc.CL_ExpiredDate = osc.CL_ExpiredDate
			, sc.[status] = osc.[status]
			, sc.[Type] = osc.[Type]
			, sc.CL_FatherID = osc.CL_FatherID
			, sc.CL_Remark = osc.CL_Remark
			, sc.InsertSource = 'NhapTay'
		from
		@Smartbooks_ContractList sc
		left join
		 HR_SNK.[dbo].SmartBooks_ContractList osc
		on sc.Employee_ID COLLATE SQL_Latin1_General_CP1_CI_AS = osc.Employee_ID and sc.CL_StartDate = osc.CL_StartDate  and sc.[Type] COLLATE SQL_Latin1_General_CP1_CI_AS = osc.[Type]
		
		
		INSERT INTO SmartBooks_ContractList
		(
		Contract_ID
		,Employee_ID
		,CL_RegisterDate
		,CL_ExpiredDate
		,CL_StartDate
		,[status]
		,[Type]
		,CL_FatherID
		,CL_Remark
		,InsertSource
		,ContractAnnexID
		,UserName
		,InsertDate
		 )
     select 
	 Contract_ID
	 ,Employee_ID
	 ,CL_RegisterDate
	 ,CL_ExpiredDate
	 ,CL_StartDate
	 ,[status]
	 ,[Type]
	 ,CL_FatherID
	 ,CL_Remark
	 ,InsertSource
	 ,null
	 ,UserName
	 ,InsertDate
		from @Smartbooks_ContractList
		where CL_StartDate between @fromdate and @todate or CL_ExpiredDate between @fromdate and @todate

	update SmartBooks_ContractList
	set [Type] = case 
						when [Type] like N'1_Nam%' then 'HD1NAM_1'
						when [Type] like N'3_Nam%' then 'HD3NAM'
						when [Type] = 'HV_1T' then 'HDTV1THANG'
						when [Type] = 'HV_2T' then 'HDTV2THANG'
						when [Type] = 'PL' then 'PLHD'
						when [Type] = 'VTH%' then 'HDVTH'
						else '' end
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
