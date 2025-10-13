Imports System.IO
Imports System.Windows.Forms

Public Class DbSetting
    Public Shared UserLogin As String
    Public Shared PassUser As String
    Public Shared DayWork As Date
    Public Shared Lan As String
    Public Shared dataPath As String '= "D:\My Project\SmartBooks\Bin\data.mdb"
    Public Shared AccessFilePath As String
    Public Shared AccessPassword As String
    Public Shared tkpdatapath As String
    Public Shared DKN As String '= "200410"
    Public Shared fromdate As DateTime '= "01/10/2004"
    Public Shared todate As DateTime '= "31/10/2004"
    Public Shared UserName As String
    Public Shared ChuoiCN As String = "131,136,138,141,244,331,336,338,311,341,342"
    Public Shared ChuoiCN_AR As String = "131,136,138,141"
    Public Shared ChuoiCN_AP As String = "244,331,336,338,311,341,342"
    Public Shared CompanyCode As String
    ' Public Shared obj As String
    Public Shared AR_IN_NO As String
    Public Shared AR_CR_NO As String
    Public Shared AP_IN_NO As String
    Public Shared AP_CP_NO As String
    Public Shared GL_JE_NO As String
    Public Shared Level As Integer = 3
    'Hong-22-12-2006 add mot bien de check permision:ADMIN,EDIT or VIEW'
    Public Shared Permision As String
    Public Shared dataPath2 As String
    Public Shared dataPath1 As String
    Public Shared Terminal As String
    Public Shared group As String
    'BIẾN FORM PARA
    Public Shared PARA_FROMDATE As DateTime = Today
    Public Shared PARA_TODATE As DateTime = Today
    Public Shared PARA_NGAY As DateTime = Today
    Public Shared PARA_MONTH As Integer = Today.Month
    Public Shared PARA_YEAR As Integer = Today.Year
    Public Shared PARA_TYPEOFCONTRACT As String
    Public Shared PARA_FACTORY_ID As String
    Public Shared PARA_DEPARTMENTCODE As String
    Public Shared PARA_SECTIONCODE As String
    Public Shared PARA_TEAMCODE As String
    Public Shared PARA_POSITION_ID As String
    Public Shared PARA_POSITIONCATEGORY_ID As String
    Public Shared PARA_SALARYTABLE As String
    Public Shared PARA_NATIONALITY As String
    Public Shared PARA_YEAR_ As Integer = Today.Year

    Public Shared ExpDate As Date = #2/1/2017#
    Public Shared tkpdatapath2 As String

    Public Shared Function GetAppPath() As String
        Dim info1 As New DirectoryInfo(Application.ExecutablePath)
        Return info1.Parent.FullName
    End Function
    Public Shared Function isExpDate(ByVal OTDate As Date) As Boolean
        If OTDate >= ExpDate Then
            Return True
        End If
        Return False
    End Function
    Public ReadOnly Property FactoryName(ByVal Terminal As String) As String
        Get
            Dim Factory As String = ""
            Select Case Terminal
                Case "Terminal"
                    Factory = "Main Office"
                Case "Terminal1"
                    Factory = "Factory 1"
                Case "Terminal2"
                    Factory = "Factory 2"
                Case "Terminal3"
                    Factory = "Factory 3"
                Case "All"
                    Factory = "Long An"
            End Select
            Return Factory
        End Get
    End Property
    Public Shared Function todatestr(ByVal thang As Integer) As String
        Dim text1 As String = ""
        If (thang >= 10) Then
            Return thang.ToString
        End If
        Return ("0" & thang.ToString)
    End Function
    Public ReadOnly Property Delete(ByVal lan As String) As String
        Get
            If lan = "VN" Then
                Return "Bạn muốn xóa?"
            End If
            Return "Do you want to delete?"
        End Get
    End Property
    Public ReadOnly Property Save(ByVal lan As String) As String
        Get
            If lan = "VN" Then
                Return "Lưu hoàn tất."
            End If
            Return "Save successfully."
        End Get
    End Property
    Public ReadOnly Property ConfirmBatch(ByVal lan As String) As String
        Get
            If lan = "VN" Then
                Return "Lưu hoàn tất."
            End If
            Return "Please choose the un-Posted Batch"
        End Get
    End Property
    Public ReadOnly Property Version() As String
        Get
            Return "SmartBooks 2009"
        End Get
    End Property

End Class
