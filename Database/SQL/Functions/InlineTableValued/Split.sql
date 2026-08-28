CREATE FUNCTION [dbo].[Split]
    (
      @RowData NVARCHAR(max),
      @SplitOn NVARCHAR(5)
    )
RETURNS TABLE
AS
RETURN
(
    SELECT CAST(LTRIM(RTRIM(t.value('.', 'nvarchar(1000)'))) AS NVARCHAR(1000)) AS Data
    FROM (
        SELECT CAST(N'<x>' + REPLACE((SELECT @RowData AS [*] FOR XML PATH('')), @SplitOn, N'</x><x>') + N'</x>' AS XML) AS xdata
    ) AS src
    CROSS APPLY src.xdata.nodes('/x') AS t2(t)
);
GO
