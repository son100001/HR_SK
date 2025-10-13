Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ReportCommon

    Public Shared ServerName As String = String.Empty
    Public Shared DatabaseName As String = String.Empty
    Public Shared UserName As String = String.Empty
    Public Shared Password As String = String.Empty

    Public Shared Function GetConnectionInfo() As ConnectionInfo
        Dim connectInfo As New ConnectionInfo

        connectInfo.ServerName = server
        connectInfo.DatabaseName = data
        connectInfo.UserID = uid
        connectInfo.Password = pass
        Return connectInfo
    End Function

    Public Shared Sub SetDBLogonForReport(ByVal connectionInfo As ConnectionInfo, ByVal rptDocument As ReportDocument)
        Dim mTableLogonInfo As New TableLogOnInfo
        Dim mTables As Tables = rptDocument.Database.Tables


        For Each mTable As CrystalDecisions.CrystalReports.Engine.Table In mTables
            mTableLogonInfo = mTable.LogOnInfo
            mTableLogonInfo.ConnectionInfo = connectionInfo
            mTable.ApplyLogOnInfo(mTableLogonInfo)

            If (mTable.TestConnectivity) Then
                If (mTable.Location.IndexOf(".") > 0) Then
                    mTable.Location = mTable.Location.Substring(mTable.Location.LastIndexOf(".") + 1)
                Else
                    mTable.Location = mTable.Location
                End If
            End If

            'If (mTable.Location.IndexOf(".") > 0) Then
            '    mTable.Location = mTable.Location.Substring(mTable.Location.LastIndexOf(".") + 1)
            'Else
            '    mTable.Location = mTable.Location
            'End If
        Next

        'Set Connection for SubReport
        'Dim mSubTableLogonInfo As New TableLogOnInfo
        'Dim mSubTables As Tables = Nothing
        'For Each mSubDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument In rptDocument.Subreports
        '    mSubTables = mSubDocument.Database.Tables
        '    For Each mSubTable As CrystalDecisions.CrystalReports.Engine.Table In mSubTables
        '        mSubTableLogonInfo = mSubTable.LogOnInfo
        '        mSubTableLogonInfo.ConnectionInfo = connectionInfo
        '        mSubTable.ApplyLogOnInfo(mSubTableLogonInfo)
        '        If (mSubTable.TestConnectivity) Then
        '            If (mSubTable.Location.IndexOf(".") > 0) Then
        '                mSubTable.Location = mSubTable.Location.Substring(mSubTable.Location.LastIndexOf(".") + 1)
        '            Else
        '                mSubTable.Location = mSubTable.Location
        '            End If
        '        End If
        '    Next
        'Next

    End Sub

End Class
