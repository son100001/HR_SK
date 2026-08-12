CREATE PROCEDURE [dbo].[NhapMaNhanVienVaoBangDuLieuQuet1] 
	@FromDate datetime,
	@ToDate datetime,
	@UserName nvarchar(50)
AS

	update [dbo].[HR_TimeKeeping_Data] set [Employee_ID] = empl.Employee_ID
	from
	(select distinct CardNumber from [dbo].[HR_TimeKeeping_Data] where [AccessDate] between @FromDate and @ToDate) as tdo
	left join
	[dbo].[udf_EmployeeFilter]('VN',null,null,null,null,null,null,null,@todate) empl
	on tdo.CardNumber COLLATE DATABASE_DEFAULT = empl.[Card_Code] or tdo.CardNumber COLLATE DATABASE_DEFAULT = empl.[Card_No] or tdo.CardNumber=empl.Employee_ID
	left join
	[User] u
	on u.UserName=@UserName
	where HR_TimeKeeping_Data.CardNumber = empl.[Card_Code] or HR_TimeKeeping_Data.CardNumber = empl.[Card_No] or HR_TimeKeeping_Data.CardNumber = empl.Employee_ID
		and HR_TimeKeeping_Data.AccessDate >= empl.ComStartedDate
		and (empl.TernimationDate is null or HR_TimeKeeping_Data.AccessDate < empl.TernimationDate)
		and HR_TimeKeeping_Data.InsertSource = N'MayChamCong'
		and empl.Factory_ID in (select data from split(u.QuyenTruyXuat,','))
	--xoa dong khong co ma nhan vien
	delete HR_TimeKeeping_Data where AccessDate between @FromDate and @ToDate and isnull(Employee_ID,'')='' 
	--xoa du lieu trung
	IF OBJECT_ID('tempdb..#tabduplicate') IS NOT NULL DROP TABLE #tabduplicate
	SELECT ID,Employee_ID,ROW_NUMBER() OVER(PARTITION by Employee_ID, AccessTime ORDER BY ID) 
	AS duplicateRecCount into #tabduplicate
	FROM HR_TimeKeeping_Data where AccessDate between @FromDate and @ToDate

	delete HR_TimeKeeping_Data where ID in (select ID from #tabduplicate where duplicateRecCount>1)



GO
