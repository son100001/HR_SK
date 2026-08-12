CREATE PROCEDURE [dbo].[sp_BangDanhMucJobCode]
	-- Add the parameters for the stored procedure here
	@TypeOfReport int=1,
	@LAN varchar(50)='VN'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @TypeOfReport=1 begin
		select jc.JobCode
		,(case when @LAN='VN' then jc.NameVN when @LAN='EN' then jc.NameEN else jc.NameKR end) as Name
		,hc.NameVN as Hazard,hc.ToxicPercent
		from
		HR_JobCodeCategory jc
		left join
		HR_HazardCategory hc
		on jc.Hazard COLLATE DATABASE_DEFAULT=hc.Hazard
	end
END




GO
