CREATE PROCEDURE [dbo].[sp_BangCa]
	-- Add the parameters for the stored procedure here
	--exec sp_BangCa 1
	@TypeOfReport int=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @TypeOfReport=1 begin
		select ShiftSign,ShiftName,cast(FromTime as time) as FromTime,cast(ToTime as time) as ToTime,cast(RestTimeFrom as time) as RestTimeFrom,cast(RestTimeTo as time) as RestTimeTo from HR_Shifts where isnull(ShiftSign,'')<>''
						union 
						select '' as ShiftSign,RoundCode+' '+sd.ShiftName as ShiftName,cast(s.FromTime as time) as FromTime,cast(s.ToTime as time) as ToTime,cast(s.RestTimeFrom as time) as RestTimeFrom,cast(s.RestTimeTo as time) as RestTimeTo  
						from 
						HR_RoundShiftDetail sd 
						left join 
						HR_Shifts s 
						on sd.ShiftName=s.ShiftName
				where isnull(ShiftSign,'') <> ''
						
	end
END




GO
