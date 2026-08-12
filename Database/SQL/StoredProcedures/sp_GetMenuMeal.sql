CREATE procedure [dbo].[sp_GetMenuMeal]
@fromdate datetime
as
begin
	select Picture AS MenuImage, 'image/jpeg' AS MimeType
	from
	HR_MealMenu
	where @fromdate between Fromdate and Todate
	order by Fromdate
end
--exec [dbo].[sp_GetMenuMeal] '2025-01-01'
GO
