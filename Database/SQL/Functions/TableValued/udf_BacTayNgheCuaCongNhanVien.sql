--select * from [dbo].[udf_BacTayNgheCuaCongNhanVien]('2020-7-1','HT000001')
CREATE FUNCTION [dbo].[udf_BacTayNgheCuaCongNhanVien]
(
	-- Add the parameters for the function here
	@Ngay datetime,
	@Emp nvarchar(50)
)
RETURNS  @rtnBacTayNghe TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),Nhom varchar(50),Bac varchar(50),Amount float,primary key ([Employee_ID])
)
AS
BEGIN
	insert into @rtnBacTayNghe
	select NhomBacTN.Employee_ID,NhomBacTN.Nhom,NhomBacTN.Bac,btn.Amount from
	(
		select empl.Employee_ID, isnull(btn.Nhom,isnull(pc.Nhom,1)) as Nhom,(case when btn.Bac is not null then btn.Bac else (case when pc.Nhom is null then 0 else isnull(btn.Bac,10)end)end) as Bac from
		[dbo].[udf_EmployeeFilter]('VN',null,null,null,null,null,null,@Emp,@Ngay) empl
		left join
		SmartBooks_PositionCategory pc
		on empl.PositionCategory_ID=pc.PositionCategory_ID
		left join
		(
			select btn.* from
			(select Employee_ID,max(FromDate) as FromDate from HR_BacTayNgheNhanVien where FromDate<=@Ngay and (ToDate is null or todate>=@Ngay) group by Employee_ID) BTNmax
			left join
			HR_BacTayNgheNhanVien btn
			on BTNmax.Employee_ID=btn.Employee_ID and BTNmax.FromDate=btn.FromDate 
		) btn
		on empl.Employee_ID=btn.Employee_ID
		where empl.StartedDate<=@Ngay and (empl.TernimationDate is null or empl.TernimationDate>DATEFROMPARTS(DATEPART(year,@ngay),DATEPART(month,@ngay),1))
	)as NhomBacTN
	left join
	(
		select btn.* from
		(select Nhom,Bac,max(FromDate) as FromDate from HR_BacTayNghe where FromDate<=@Ngay and (ToDate is null or todate>=@Ngay) group by Nhom,Bac) btnmax
		left join
		HR_BacTayNghe btn
		on btnmax.Nhom=btn.Nhom and btnmax.Bac=btn.Bac and btnmax.FromDate=btn.FromDate
	)btn
	on NhomBacTN.Nhom=btn.Nhom and NhomBacTN.Bac=btn.Bac
	
	-- Return the result of the function
	RETURN

END




GO
