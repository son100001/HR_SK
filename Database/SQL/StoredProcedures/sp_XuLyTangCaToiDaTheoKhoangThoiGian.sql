-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec sp_XuLyTangCaToiDaTheoKhoangThoiGian '2017-12-1','2017-12-31',null,null,null,null,null,'20140009'
CREATE PROCEDURE [dbo].[sp_XuLyTangCaToiDaTheoKhoangThoiGian]
	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@dep as nvarchar(50)=null,
	@sec as nvarchar(50)=null,
	@team as nvarchar(50)=null,
	@pos as nvarchar(50)=null,
	@posc as nvarchar(50)=null,
	@Emp nvarchar(50)=null   
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Employee_ID nvarchar(50),@maxovertime float,@fromdateOT datetime,@todateOT datetime,@DateNext datetime
		,@DanhSachMaCongTangCa nvarchar(100),@OTTotal float,@query nvarchar(max),@OTPass float,@MaCong nvarchar(10),@wt float
	set @DanhSachMaCongTangCa=''
	select @DanhSachMaCongTangCa=@DanhSachMaCongTangCa+MaCong+',' from HR_LoaiCong where isWorkingTime is null or isWorkingTime=0
	DECLARE cur CURSOR FOR
	select [Employee_ID],[Fromdate],[Todate],[maxovertime] from [dbo].[HR_MaxOvertimeInPeriod] where Fromdate>=@fromdate and Todate<=@todate
																										and Employee_ID in (select Employee_ID from smartbooks_employee where
																												(case when @dep is null or @dep='' then '' else DepartmentCode end)=(case when @dep is null or @dep='' then '' else @dep end)
																												and (case when @sec is null or @sec='' then '' else SectionCode end)=(case when @sec is null or @sec='' then '' else @sec end)
																												and (case when @team is null or @team='' then '' else TeamCode end)=(case when @team is null or @team='' then '' else @team end)
																												and (case when @pos is null or @pos='' then '' else Position_ID end)=(case when @pos is null or @pos='' then '' else @pos end)
																												and (case when @posc is null or @posc='' then '' else PositionCategory_ID end)=(case when @posc is null or @posc='' then '' else @posc end)
																												and (case when @Emp is null or @Emp='' then '' else Employee_ID end)=(case when @Emp is null or @Emp='' then '' else @Emp end)
																											)
	OPEN  cur     
	FETCH NEXT FROM cur INTO @Employee_ID,@fromdateOT,@todateOT,@maxovertime
	WHILE @@FETCH_STATUS = 0    
	BEGIN
		set @OTTotal=0
		set @DateNext=@fromdateOT
		while @DateNext<=@todateOT begin
			if exists(select * from HR_BangCongNgoaiLe where Employee_ID=@Employee_ID and Ngay=@DateNext) begin
				select @OTTotal=@OTTotal+(case when @DanhSachMaCongTangCa like '%wt1,%' then isnull(wt1,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt2,%' then isnull(wt2,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt3,%' then isnull(wt3,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt4,%' then isnull(wt4,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt5,%' then isnull(wt5,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt6,%' then isnull(wt6,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt7,%' then isnull(wt7,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt8,%' then isnull(wt8,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt9,%' then isnull(wt9,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt10,%' then isnull(wt10,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt11,%' then isnull(wt11,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt12,%' then isnull(wt12,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt13,%' then isnull(wt13,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt14,%' then isnull(wt14,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt15,%' then isnull(wt15,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt16,%' then isnull(wt16,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt17,%' then isnull(wt17,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt18,%' then isnull(wt18,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt19,%' then isnull(wt19,0) else 0 end)+
					(case when @DanhSachMaCongTangCa like '%wt20,%' then isnull(wt20,0) else 0 end)
				from HR_BangCongNgoaiLe where Employee_ID=@Employee_ID and Ngay=@DateNext
			end begin
				if exists(select * from HR_BangCongTheoNgay where Employee_ID=@Employee_ID and Ngay=@DateNext) begin
						select @OTTotal=@OTTotal+(case when @DanhSachMaCongTangCa like '%wt1,%' then isnull(wt1,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt2,%' then isnull(wt2,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt3,%' then isnull(wt3,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt4,%' then isnull(wt4,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt5,%' then isnull(wt5,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt6,%' then isnull(wt6,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt7,%' then isnull(wt7,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt8,%' then isnull(wt8,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt9,%' then isnull(wt9,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt10,%' then isnull(wt10,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt11,%' then isnull(wt11,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt12,%' then isnull(wt12,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt13,%' then isnull(wt13,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt14,%' then isnull(wt14,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt15,%' then isnull(wt15,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt16,%' then isnull(wt16,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt17,%' then isnull(wt17,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt18,%' then isnull(wt18,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt19,%' then isnull(wt19,0) else 0 end)+
						(case when @DanhSachMaCongTangCa like '%wt20,%' then isnull(wt20,0) else 0 end)
					from HR_BangCongTheoNgay where Employee_ID=@Employee_ID and Ngay=@DateNext
				end
			end
			if @OTTotal-@maxovertime>=0 begin
				set @OTPass=@OTTotal-@maxovertime
				if @OTPass=0 begin
					if @DateNext<@todateOT begin
						set @query='update HR_BangCongTheoNgay set '+REPLACE(@DanhSachMaCongTangCa,',','=null,')
						set @query=left(@query,len(@query)-1)+' where Employee_ID='''+@Employee_ID+''' and Ngay between '''+CONVERT(varchar(10),@DateNext+1,112)+''' and '''+CONVERT(varchar(10),@todateOT,112)+''''
						exec(@query)
						set @DateNext=@todateOT
					end
				end else begin
					DECLARE cur_ CURSOR LOCAL FOR
					select tp.MaCong,
						(case when tp.MaCong='wt1' then isnull(ctn.wt1,0) else
						(case when tp.MaCong='wt2' then isnull(ctn.wt2,0) else
						(case when tp.MaCong='wt3' then isnull(ctn.wt3,0) else
						(case when tp.MaCong='wt4' then isnull(ctn.wt4,0) else
						(case when tp.MaCong='wt5' then isnull(ctn.wt5,0) else
						(case when tp.MaCong='wt6' then isnull(ctn.wt6,0) else
						(case when tp.MaCong='wt7' then isnull(ctn.wt7,0) else
						(case when tp.MaCong='wt8' then isnull(ctn.wt8,0) else
						(case when tp.MaCong='wt9' then isnull(ctn.wt9,0) else
						(case when tp.MaCong='wt10' then isnull(ctn.wt10,0)
						end)end)end)end)end)end)end)end)end)end)
						+
						(case when tp.MaCong='wt11' then isnull(ctn.wt11,0) else
						(case when tp.MaCong='wt12' then isnull(ctn.wt12,0) else
						(case when tp.MaCong='wt13' then isnull(ctn.wt13,0) else
						(case when tp.MaCong='wt14' then isnull(ctn.wt14,0) else
						(case when tp.MaCong='wt15' then isnull(ctn.wt15,0) else
						(case when tp.MaCong='wt16' then isnull(ctn.wt16,0) else
						(case when tp.MaCong='wt17' then isnull(ctn.wt17,0) else
						(case when tp.MaCong='wt18' then isnull(ctn.wt18,0) else
						(case when tp.MaCong='wt19' then isnull(ctn.wt19,0) else
						(case when tp.MaCong='wt20' then isnull(ctn.wt20,0) else 0
						end)end)end)end)end)end)end)end)end)end)
					from
						HR_TimeIn_TimeOut tito
						left join
						HR_SetupHourTimeKeeping tp
						on tito.ShiftName=tp.ShiftName
						left join
						HR_BangCongTheoNgay ctn
						on tito.Employee_ID=ctn.Employee_ID and tito.OT_date=ctn.Ngay
						where tito.Employee_ID=@Employee_ID and OT_date=@DateNext
						order by tp.No_ desc
					OPEN  cur_
					FETCH NEXT FROM cur_ INTO @MaCong,@wt
					WHILE @@FETCH_STATUS = 0
					BEGIN
						if @OTPass>0 begin
							if isnull(@wt,0)>0 begin
								if @OTPass-@wt>=0 begin
									set @query='update HR_BangCongTheoNgay set '+@MaCong+'=null where Employee_ID='''+@Employee_ID+''' and Ngay='''+CONVERT(varchar(10),@DateNext,112)+''''
								end else begin
									set @query='update HR_BangCongTheoNgay set '+@MaCong+'='+convert(VARCHAR(50), sum(@wt-@OTPass),128)+' where Employee_ID='''+@Employee_ID+''' and Ngay='''+CONVERT(varchar(10),@DateNext,112)+''''
								end
								exec(@query)
								set @OTPass=@OTPass-@wt
							end
						end
					FETCH NEXT FROM cur_ INTO @MaCong,@wt
					END
					CLOSE cur_
					DEALLOCATE cur_
					if @DateNext<@todateOT begin
						set @query='update HR_BangCongTheoNgay set '+REPLACE(@DanhSachMaCongTangCa,',','=null,')
						set @query=left(@query,len(@query)-1)+' where Employee_ID='''+@Employee_ID+''' and Ngay between '''+CONVERT(varchar(10),@DateNext+1,112)+''' and '''+CONVERT(varchar(10),@todateOT,112)+''''
						exec(@query)
						set @DateNext=@todateOT
					end
				end
			end
			set @DateNext=@DateNext+1
		end
	FETCH NEXT FROM cur INTO @Employee_ID,@fromdateOT,@todateOT,@maxovertime    
	END    
	CLOSE cur    
	DEALLOCATE cur  
END




GO
