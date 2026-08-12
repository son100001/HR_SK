CREATE PROCEDURE [dbo].[sp_BangQuyen]
--exec sp_BangQuyen 'admin','admin'
	-- Add the parameters for the stored procedure here
	@USCapTren as varchar(50),
	@USCapDuoi as varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select @USCapDuoi as UserName,f.Group_,usct.FormID,uscd.Quyen,cast(case when uscd.Quyen='Edit' then 1 else 0 end as bit) as Edit,cast(case when uscd.Quyen='View' then 1 else 0 end as bit) as [View],uscd.DepartmentCode,uscd.SectionCode,uscd.TeamCode,uscd.TabList,uscd.InsertBy,uscd.InsertDate from
	HR_Form f
	left join
	Permission usct
	on usct.FormID=f.FormID
	left join
	Permission uscd
	on usct.FormID=uscd.FormID and uscd.UserName=@USCapDuoi
	where usct.UserName=@USCapTren and (usct.Quyen is not null or @USCapTren='admin')
END

GO
