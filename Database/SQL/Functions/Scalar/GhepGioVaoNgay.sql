






CREATE FUNCTION [dbo].[GhepGioVaoNgay](@Ngay datetime, @Gio datetime)
-- returns only the time portion of a DateTime, at the "base" date (1/1/1900)
returns varchar(20)
as
	 begin   
  		 RETURN DATEADD(SECOND, DATEDIFF(SECOND, 0, CAST(@Gio AS time)), CAST(CAST(@Ngay AS date) AS datetime))
   	 end













GO
