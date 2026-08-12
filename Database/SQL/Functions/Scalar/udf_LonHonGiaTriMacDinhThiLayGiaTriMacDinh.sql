
CREATE FUNCTION [dbo].[udf_LonHonGiaTriMacDinhThiLayGiaTriMacDinh](@GiaTriDauVao float, @GiaTriMacDinh float)
RETURNS float
            AS
    BEGIN
		return (case when @GiaTriDauVao > @GiaTriMacDinh then @GiaTriMacDinh else @GiaTriDauVao end)
	END

 





GO
