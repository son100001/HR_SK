Imports System
Imports System.Text
Imports System.Data
Imports Appsettings

#Region "SmartBooks_Salary"
    ''' <summary>
    ''' This object represents the properties and methods of a SmartBooks_Salary.
    ''' </summary>
    Public Class SmartBooks_Salary
        Private _key As System.String = String.Empty
        Private _salary_Month As System.Int32
        Private _salary_Year As System.Int32
        Private _employee_ID As System.String = String.Empty
        Private _s1 As System.Double
        Private _s2 As System.Double
        Private _s3 As System.Double
        Private _s4 As System.Double
        Private _s5 As System.Double
        Private _s6 As System.Double
        Private _s7 As System.Double
        Private _s8 As System.Double
        Private _s9 As System.Double
        Private _s10 As System.Double
        Private _s11 As System.Double
        Private _s12 As System.Double
        Private _s13 As System.Double
        Private _s14 As System.Double
        Private _s15 As System.Double
        Private _s16 As System.Double
        Private _s17 As System.Double
        Private _s18 As System.Double
        Private _s19 As System.Double
        Private _s20 As System.Double
        Private _s21 As System.Double
        Private _s22 As System.Double
        Private _s23 As System.Double
        Private _s24 As System.Double
        Private _s25 As System.Double
        Private _s26 As System.Double
        Private _s27 As System.Double
        Private _s28 As System.Double
        Private _s29 As System.Double
        Private _s30 As System.Double
        Private _s31 As System.Double
        Private _s32 As System.Double
        Private _s33 As System.Double
        Private _s34 As System.Double
        Private _s35 As System.Double
        Private _s36 As System.Double
        Private _s37 As System.Double
        Private _s38 As System.Double
        Private _s39 As System.Double
        Private _s40 As System.Double
        Private _s41 As System.Double
        Private _s42 As System.Double
        Private _s43 As System.Double
        Private _s44 As System.Double
        Private _s45 As System.Double
        Private _s46 As System.Double
        Private _s47 As System.Double
        Private _s48 As System.Double
        Private _s49 As System.Double
        Private _s50 As System.Double
        Private _s51 As System.Double
        Private _s52 As System.Double
        Private _s53 As System.Double
        Private _s54 As System.Double
        Private _s55 As System.Double
        Private _s56 As System.Double
        Private _s57 As System.Double
        Private _s58 As System.Double
        Private _s59 As System.Double
        Private _s60 As System.Double
        Private _s61 As System.Double
        Private _s62 As System.Double
        Private _s63 As System.Double
        Private _s64 As System.Double
        Private _s65 As System.Double
        Private _s66 As System.Double
        Private _s67 As System.Double
        Private _s68 As System.Double
        Private _s69 As System.Double
        Private _s70 As System.Double
        Private _s71 As System.Double
        Private _s72 As System.Double
        Private _s73 As System.Double
        Private _s74 As System.Double
        Private _s75 As System.Double
        Private _s76 As System.Double
        Private _s77 As System.Double
        Private _s78 As System.Double
        Private _s79 As System.Double
        Private _s80 As System.Double
        Private _s81 As System.Double
        Private _s82 As System.Double
        Private _s83 As System.Double
        Private _s84 As System.Double
        Private _s85 As System.Double
        Private _s86 As System.Double
        Private _s87 As System.Double
        Private _s88 As System.Double
        Private _s89 As System.Double
        Private _s90 As System.Double
        Private _s91 As System.Double
        Private _s92 As System.Double
        Private _s93 As System.Double
        Private _s94 As System.Double
        Private _s95 As System.Double
        Private _s96 As System.Double
        Private _s97 As System.Double
        Private _s98 As System.Double
        Private _s99 As System.Double
        Private kn As New connect(DbSetting.dataPath)

        Public Sub New()
        End Sub

        Public Sub New(ByVal Salary_Month As System.Int32, ByVal Salary_Year As System.Int32, ByVal Employee_ID As System.String)
            Dim name() As String = {"@Salary_Month", "@Salary_Year", "@Employee_ID"}
            Dim oj() As Object = {Salary_Month, Salary_Year, Employee_ID}
            Dim tp() As String = {"Int", "Int", "NVarChar"}
            Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSmartBooks_Salary", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Me.LoadFromDataRow(table.Select()(0))
            Else
                _salary_Month = Salary_Month
                _salary_Year = Salary_Year
                _employee_ID = Employee_ID
            End If
        Else
            _salary_Month = Salary_Month
            _salary_Year = Salary_Year
            _employee_ID = Employee_ID
        End If
        End Sub

        Public Sub New(ByVal _datarow As DataRow)
            If Not IsNothing(_datarow) Then
                If Not IsDBNull(_datarow("key")) Then
                    _key = _datarow("key")
                End If
                If Not IsDBNull(_datarow("Salary_Month")) Then
                    _salary_Month = _datarow("Salary_Month")
                End If
                If Not IsDBNull(_datarow("Salary_Year")) Then
                    _salary_Year = _datarow("Salary_Year")
                End If
                If Not IsDBNull(_datarow("Employee_ID")) Then
                    _employee_ID = _datarow("Employee_ID")
                End If
                If Not IsDBNull(_datarow("s1")) Then
                    _s1 = _datarow("s1")
                End If
                If Not IsDBNull(_datarow("s2")) Then
                    _s2 = _datarow("s2")
                End If
                If Not IsDBNull(_datarow("s3")) Then
                    _s3 = _datarow("s3")
                End If
                If Not IsDBNull(_datarow("s4")) Then
                    _s4 = _datarow("s4")
                End If
                If Not IsDBNull(_datarow("s5")) Then
                    _s5 = _datarow("s5")
                End If
                If Not IsDBNull(_datarow("s6")) Then
                    _s6 = _datarow("s6")
                End If
                If Not IsDBNull(_datarow("s7")) Then
                    _s7 = _datarow("s7")
                End If
                If Not IsDBNull(_datarow("s8")) Then
                    _s8 = _datarow("s8")
                End If
                If Not IsDBNull(_datarow("s9")) Then
                    _s9 = _datarow("s9")
                End If
                If Not IsDBNull(_datarow("s10")) Then
                    _s10 = _datarow("s10")
                End If
                If Not IsDBNull(_datarow("s11")) Then
                    _s11 = _datarow("s11")
                End If
                If Not IsDBNull(_datarow("s12")) Then
                    _s12 = _datarow("s12")
                End If
                If Not IsDBNull(_datarow("s13")) Then
                    _s13 = _datarow("s13")
                End If
                If Not IsDBNull(_datarow("s14")) Then
                    _s14 = _datarow("s14")
                End If
                If Not IsDBNull(_datarow("s15")) Then
                    _s15 = _datarow("s15")
                End If
                If Not IsDBNull(_datarow("s16")) Then
                    _s16 = _datarow("s16")
                End If
                If Not IsDBNull(_datarow("s17")) Then
                    _s17 = _datarow("s17")
                End If
                If Not IsDBNull(_datarow("s18")) Then
                    _s18 = _datarow("s18")
                End If
                If Not IsDBNull(_datarow("s19")) Then
                    _s19 = _datarow("s19")
                End If
                If Not IsDBNull(_datarow("s20")) Then
                    _s20 = _datarow("s20")
                End If
                If Not IsDBNull(_datarow("s21")) Then
                    _s21 = _datarow("s21")
                End If
                If Not IsDBNull(_datarow("s22")) Then
                    _s22 = _datarow("s22")
                End If
                If Not IsDBNull(_datarow("s23")) Then
                    _s23 = _datarow("s23")
                End If
                If Not IsDBNull(_datarow("s24")) Then
                    _s24 = _datarow("s24")
                End If
                If Not IsDBNull(_datarow("s25")) Then
                    _s25 = _datarow("s25")
                End If
                If Not IsDBNull(_datarow("s26")) Then
                    _s26 = _datarow("s26")
                End If
                If Not IsDBNull(_datarow("s27")) Then
                    _s27 = _datarow("s27")
                End If
                If Not IsDBNull(_datarow("s28")) Then
                    _s28 = _datarow("s28")
                End If
                If Not IsDBNull(_datarow("s29")) Then
                    _s29 = _datarow("s29")
                End If
                If Not IsDBNull(_datarow("s30")) Then
                    _s30 = _datarow("s30")
                End If
                If Not IsDBNull(_datarow("s31")) Then
                    _s31 = _datarow("s31")
                End If
                If Not IsDBNull(_datarow("s32")) Then
                    _s32 = _datarow("s32")
                End If
                If Not IsDBNull(_datarow("s33")) Then
                    _s33 = _datarow("s33")
                End If
                If Not IsDBNull(_datarow("s34")) Then
                    _s34 = _datarow("s34")
                End If
                If Not IsDBNull(_datarow("s35")) Then
                    _s35 = _datarow("s35")
                End If
                If Not IsDBNull(_datarow("s36")) Then
                    _s36 = _datarow("s36")
                End If
                If Not IsDBNull(_datarow("s37")) Then
                    _s37 = _datarow("s37")
                End If
                If Not IsDBNull(_datarow("s38")) Then
                    _s38 = _datarow("s38")
                End If
                If Not IsDBNull(_datarow("s39")) Then
                    _s39 = _datarow("s39")
                End If
                If Not IsDBNull(_datarow("s40")) Then
                    _s40 = _datarow("s40")
                End If
                If Not IsDBNull(_datarow("s41")) Then
                    _s41 = _datarow("s41")
                End If
                If Not IsDBNull(_datarow("s42")) Then
                    _s42 = _datarow("s42")
                End If
                If Not IsDBNull(_datarow("s43")) Then
                    _s43 = _datarow("s43")
                End If
                If Not IsDBNull(_datarow("s44")) Then
                    _s44 = _datarow("s44")
                End If
                If Not IsDBNull(_datarow("s45")) Then
                    _s45 = _datarow("s45")
                End If
                If Not IsDBNull(_datarow("s46")) Then
                    _s46 = _datarow("s46")
                End If
                If Not IsDBNull(_datarow("s47")) Then
                    _s47 = _datarow("s47")
                End If
                If Not IsDBNull(_datarow("s48")) Then
                    _s48 = _datarow("s48")
                End If
                If Not IsDBNull(_datarow("s49")) Then
                    _s49 = _datarow("s49")
                End If
                If Not IsDBNull(_datarow("s50")) Then
                    _s50 = _datarow("s50")
                End If
                If Not IsDBNull(_datarow("s51")) Then
                    _s51 = _datarow("s51")
                End If
                If Not IsDBNull(_datarow("s52")) Then
                    _s52 = _datarow("s52")
                End If
                If Not IsDBNull(_datarow("s53")) Then
                    _s53 = _datarow("s53")
                End If
                If Not IsDBNull(_datarow("s54")) Then
                    _s54 = _datarow("s54")
                End If
                If Not IsDBNull(_datarow("s55")) Then
                    _s55 = _datarow("s55")
                End If
                If Not IsDBNull(_datarow("s56")) Then
                    _s56 = _datarow("s56")
                End If
                If Not IsDBNull(_datarow("s57")) Then
                    _s57 = _datarow("s57")
                End If
                If Not IsDBNull(_datarow("s58")) Then
                    _s58 = _datarow("s58")
                End If
                If Not IsDBNull(_datarow("s59")) Then
                    _s59 = _datarow("s59")
                End If
                If Not IsDBNull(_datarow("s60")) Then
                    _s60 = _datarow("s60")
                End If
                If Not IsDBNull(_datarow("s61")) Then
                    _s61 = _datarow("s61")
                End If
                If Not IsDBNull(_datarow("s62")) Then
                    _s62 = _datarow("s62")
                End If
                If Not IsDBNull(_datarow("s63")) Then
                    _s63 = _datarow("s63")
                End If
                If Not IsDBNull(_datarow("s64")) Then
                    _s64 = _datarow("s64")
                End If
                If Not IsDBNull(_datarow("s65")) Then
                    _s65 = _datarow("s65")
                End If
                If Not IsDBNull(_datarow("s66")) Then
                    _s66 = _datarow("s66")
                End If
                If Not IsDBNull(_datarow("s67")) Then
                    _s67 = _datarow("s67")
                End If
                If Not IsDBNull(_datarow("s68")) Then
                    _s68 = _datarow("s68")
                End If
                If Not IsDBNull(_datarow("s69")) Then
                    _s69 = _datarow("s69")
                End If
                If Not IsDBNull(_datarow("s70")) Then
                    _s70 = _datarow("s70")
                End If
                If Not IsDBNull(_datarow("s71")) Then
                    _s71 = _datarow("s71")
                End If
                If Not IsDBNull(_datarow("s72")) Then
                    _s72 = _datarow("s72")
                End If
                If Not IsDBNull(_datarow("s73")) Then
                    _s73 = _datarow("s73")
                End If
                If Not IsDBNull(_datarow("s74")) Then
                    _s74 = _datarow("s74")
                End If
                If Not IsDBNull(_datarow("s75")) Then
                    _s75 = _datarow("s75")
                End If
                If Not IsDBNull(_datarow("s76")) Then
                    _s76 = _datarow("s76")
                End If
                If Not IsDBNull(_datarow("s77")) Then
                    _s77 = _datarow("s77")
                End If
                If Not IsDBNull(_datarow("s78")) Then
                    _s78 = _datarow("s78")
                End If
                If Not IsDBNull(_datarow("s79")) Then
                    _s79 = _datarow("s79")
                End If
                If Not IsDBNull(_datarow("s80")) Then
                    _s80 = _datarow("s80")
                End If
                If Not IsDBNull(_datarow("s81")) Then
                    _s81 = _datarow("s81")
                End If
                If Not IsDBNull(_datarow("s82")) Then
                    _s82 = _datarow("s82")
                End If
                If Not IsDBNull(_datarow("s83")) Then
                    _s83 = _datarow("s83")
                End If
                If Not IsDBNull(_datarow("s84")) Then
                    _s84 = _datarow("s84")
                End If
                If Not IsDBNull(_datarow("s85")) Then
                    _s85 = _datarow("s85")
                End If
                If Not IsDBNull(_datarow("s86")) Then
                    _s86 = _datarow("s86")
                End If
                If Not IsDBNull(_datarow("s87")) Then
                    _s87 = _datarow("s87")
                End If
                If Not IsDBNull(_datarow("s88")) Then
                    _s88 = _datarow("s88")
                End If
                If Not IsDBNull(_datarow("s89")) Then
                    _s89 = _datarow("s89")
                End If
                If Not IsDBNull(_datarow("s90")) Then
                    _s90 = _datarow("s90")
                End If
                If Not IsDBNull(_datarow("s91")) Then
                    _s91 = _datarow("s91")
                End If
                If Not IsDBNull(_datarow("s92")) Then
                    _s92 = _datarow("s92")
                End If
                If Not IsDBNull(_datarow("s93")) Then
                    _s93 = _datarow("s93")
                End If
                If Not IsDBNull(_datarow("s94")) Then
                    _s94 = _datarow("s94")
                End If
                If Not IsDBNull(_datarow("s95")) Then
                    _s95 = _datarow("s95")
                End If
                If Not IsDBNull(_datarow("s96")) Then
                    _s96 = _datarow("s96")
                End If
                If Not IsDBNull(_datarow("s97")) Then
                    _s97 = _datarow("s97")
                End If
                If Not IsDBNull(_datarow("s98")) Then
                    _s98 = _datarow("s98")
                End If
                If Not IsDBNull(_datarow("s99")) Then
                    _s99 = _datarow("s99")
                End If
            End If
        End Sub

        Protected Sub LoadFromDataRow(ByVal _datarow As DataRow)
            If Not IsNothing(_datarow) Then
                If Not IsDBNull(_datarow("key")) Then
                    _key = _datarow("key")
                End If
                If Not IsDBNull(_datarow("Salary_Month")) Then
                    _salary_Month = _datarow("Salary_Month")
                End If
                If Not IsDBNull(_datarow("Salary_Year")) Then
                    _salary_Year = _datarow("Salary_Year")
                End If
                If Not IsDBNull(_datarow("Employee_ID")) Then
                    _employee_ID = _datarow("Employee_ID")
                End If
                If Not IsDBNull(_datarow("s1")) Then
                    _s1 = _datarow("s1")
                End If
                If Not IsDBNull(_datarow("s2")) Then
                    _s2 = _datarow("s2")
                End If
                If Not IsDBNull(_datarow("s3")) Then
                    _s3 = _datarow("s3")
                End If
                If Not IsDBNull(_datarow("s4")) Then
                    _s4 = _datarow("s4")
                End If
                If Not IsDBNull(_datarow("s5")) Then
                    _s5 = _datarow("s5")
                End If
                If Not IsDBNull(_datarow("s6")) Then
                    _s6 = _datarow("s6")
                End If
                If Not IsDBNull(_datarow("s7")) Then
                    _s7 = _datarow("s7")
                End If
                If Not IsDBNull(_datarow("s8")) Then
                    _s8 = _datarow("s8")
                End If
                If Not IsDBNull(_datarow("s9")) Then
                    _s9 = _datarow("s9")
                End If
                If Not IsDBNull(_datarow("s10")) Then
                    _s10 = _datarow("s10")
                End If
                If Not IsDBNull(_datarow("s11")) Then
                    _s11 = _datarow("s11")
                End If
                If Not IsDBNull(_datarow("s12")) Then
                    _s12 = _datarow("s12")
                End If
                If Not IsDBNull(_datarow("s13")) Then
                    _s13 = _datarow("s13")
                End If
                If Not IsDBNull(_datarow("s14")) Then
                    _s14 = _datarow("s14")
                End If
                If Not IsDBNull(_datarow("s15")) Then
                    _s15 = _datarow("s15")
                End If
                If Not IsDBNull(_datarow("s16")) Then
                    _s16 = _datarow("s16")
                End If
                If Not IsDBNull(_datarow("s17")) Then
                    _s17 = _datarow("s17")
                End If
                If Not IsDBNull(_datarow("s18")) Then
                    _s18 = _datarow("s18")
                End If
                If Not IsDBNull(_datarow("s19")) Then
                    _s19 = _datarow("s19")
                End If
                If Not IsDBNull(_datarow("s20")) Then
                    _s20 = _datarow("s20")
                End If
                If Not IsDBNull(_datarow("s21")) Then
                    _s21 = _datarow("s21")
                End If
                If Not IsDBNull(_datarow("s22")) Then
                    _s22 = _datarow("s22")
                End If
                If Not IsDBNull(_datarow("s23")) Then
                    _s23 = _datarow("s23")
                End If
                If Not IsDBNull(_datarow("s24")) Then
                    _s24 = _datarow("s24")
                End If
                If Not IsDBNull(_datarow("s25")) Then
                    _s25 = _datarow("s25")
                End If
                If Not IsDBNull(_datarow("s26")) Then
                    _s26 = _datarow("s26")
                End If
                If Not IsDBNull(_datarow("s27")) Then
                    _s27 = _datarow("s27")
                End If
                If Not IsDBNull(_datarow("s28")) Then
                    _s28 = _datarow("s28")
                End If
                If Not IsDBNull(_datarow("s29")) Then
                    _s29 = _datarow("s29")
                End If
                If Not IsDBNull(_datarow("s30")) Then
                    _s30 = _datarow("s30")
                End If
                If Not IsDBNull(_datarow("s31")) Then
                    _s31 = _datarow("s31")
                End If
                If Not IsDBNull(_datarow("s32")) Then
                    _s32 = _datarow("s32")
                End If
                If Not IsDBNull(_datarow("s33")) Then
                    _s33 = _datarow("s33")
                End If
                If Not IsDBNull(_datarow("s34")) Then
                    _s34 = _datarow("s34")
                End If
                If Not IsDBNull(_datarow("s35")) Then
                    _s35 = _datarow("s35")
                End If
                If Not IsDBNull(_datarow("s36")) Then
                    _s36 = _datarow("s36")
                End If
                If Not IsDBNull(_datarow("s37")) Then
                    _s37 = _datarow("s37")
                End If
                If Not IsDBNull(_datarow("s38")) Then
                    _s38 = _datarow("s38")
                End If
                If Not IsDBNull(_datarow("s39")) Then
                    _s39 = _datarow("s39")
                End If
                If Not IsDBNull(_datarow("s40")) Then
                    _s40 = _datarow("s40")
                End If
                If Not IsDBNull(_datarow("s41")) Then
                    _s41 = _datarow("s41")
                End If
                If Not IsDBNull(_datarow("s42")) Then
                    _s42 = _datarow("s42")
                End If
                If Not IsDBNull(_datarow("s43")) Then
                    _s43 = _datarow("s43")
                End If
                If Not IsDBNull(_datarow("s44")) Then
                    _s44 = _datarow("s44")
                End If
                If Not IsDBNull(_datarow("s45")) Then
                    _s45 = _datarow("s45")
                End If
                If Not IsDBNull(_datarow("s46")) Then
                    _s46 = _datarow("s46")
                End If
                If Not IsDBNull(_datarow("s47")) Then
                    _s47 = _datarow("s47")
                End If
                If Not IsDBNull(_datarow("s48")) Then
                    _s48 = _datarow("s48")
                End If
                If Not IsDBNull(_datarow("s49")) Then
                    _s49 = _datarow("s49")
                End If
                If Not IsDBNull(_datarow("s50")) Then
                    _s50 = _datarow("s50")
                End If
                If Not IsDBNull(_datarow("s51")) Then
                    _s51 = _datarow("s51")
                End If
                If Not IsDBNull(_datarow("s52")) Then
                    _s52 = _datarow("s52")
                End If
                If Not IsDBNull(_datarow("s53")) Then
                    _s53 = _datarow("s53")
                End If
                If Not IsDBNull(_datarow("s54")) Then
                    _s54 = _datarow("s54")
                End If
                If Not IsDBNull(_datarow("s55")) Then
                    _s55 = _datarow("s55")
                End If
                If Not IsDBNull(_datarow("s56")) Then
                    _s56 = _datarow("s56")
                End If
                If Not IsDBNull(_datarow("s57")) Then
                    _s57 = _datarow("s57")
                End If
                If Not IsDBNull(_datarow("s58")) Then
                    _s58 = _datarow("s58")
                End If
                If Not IsDBNull(_datarow("s59")) Then
                    _s59 = _datarow("s59")
                End If
                If Not IsDBNull(_datarow("s60")) Then
                    _s60 = _datarow("s60")
                End If
                If Not IsDBNull(_datarow("s61")) Then
                    _s61 = _datarow("s61")
                End If
                If Not IsDBNull(_datarow("s62")) Then
                    _s62 = _datarow("s62")
                End If
                If Not IsDBNull(_datarow("s63")) Then
                    _s63 = _datarow("s63")
                End If
                If Not IsDBNull(_datarow("s64")) Then
                    _s64 = _datarow("s64")
                End If
                If Not IsDBNull(_datarow("s65")) Then
                    _s65 = _datarow("s65")
                End If
                If Not IsDBNull(_datarow("s66")) Then
                    _s66 = _datarow("s66")
                End If
                If Not IsDBNull(_datarow("s67")) Then
                    _s67 = _datarow("s67")
                End If
                If Not IsDBNull(_datarow("s68")) Then
                    _s68 = _datarow("s68")
                End If
                If Not IsDBNull(_datarow("s69")) Then
                    _s69 = _datarow("s69")
                End If
                If Not IsDBNull(_datarow("s70")) Then
                    _s70 = _datarow("s70")
                End If
                If Not IsDBNull(_datarow("s71")) Then
                    _s71 = _datarow("s71")
                End If
                If Not IsDBNull(_datarow("s72")) Then
                    _s72 = _datarow("s72")
                End If
                If Not IsDBNull(_datarow("s73")) Then
                    _s73 = _datarow("s73")
                End If
                If Not IsDBNull(_datarow("s74")) Then
                    _s74 = _datarow("s74")
                End If
                If Not IsDBNull(_datarow("s75")) Then
                    _s75 = _datarow("s75")
                End If
                If Not IsDBNull(_datarow("s76")) Then
                    _s76 = _datarow("s76")
                End If
                If Not IsDBNull(_datarow("s77")) Then
                    _s77 = _datarow("s77")
                End If
                If Not IsDBNull(_datarow("s78")) Then
                    _s78 = _datarow("s78")
                End If
                If Not IsDBNull(_datarow("s79")) Then
                    _s79 = _datarow("s79")
                End If
                If Not IsDBNull(_datarow("s80")) Then
                    _s80 = _datarow("s80")
                End If
                If Not IsDBNull(_datarow("s81")) Then
                    _s81 = _datarow("s81")
                End If
                If Not IsDBNull(_datarow("s82")) Then
                    _s82 = _datarow("s82")
                End If
                If Not IsDBNull(_datarow("s83")) Then
                    _s83 = _datarow("s83")
                End If
                If Not IsDBNull(_datarow("s84")) Then
                    _s84 = _datarow("s84")
                End If
                If Not IsDBNull(_datarow("s85")) Then
                    _s85 = _datarow("s85")
                End If
                If Not IsDBNull(_datarow("s86")) Then
                    _s86 = _datarow("s86")
                End If
                If Not IsDBNull(_datarow("s87")) Then
                    _s87 = _datarow("s87")
                End If
                If Not IsDBNull(_datarow("s88")) Then
                    _s88 = _datarow("s88")
                End If
                If Not IsDBNull(_datarow("s89")) Then
                    _s89 = _datarow("s89")
                End If
                If Not IsDBNull(_datarow("s90")) Then
                    _s90 = _datarow("s90")
                End If
                If Not IsDBNull(_datarow("s91")) Then
                    _s91 = _datarow("s91")
                End If
                If Not IsDBNull(_datarow("s92")) Then
                    _s92 = _datarow("s92")
                End If
                If Not IsDBNull(_datarow("s93")) Then
                    _s93 = _datarow("s93")
                End If
                If Not IsDBNull(_datarow("s94")) Then
                    _s94 = _datarow("s94")
                End If
                If Not IsDBNull(_datarow("s95")) Then
                    _s95 = _datarow("s95")
                End If
                If Not IsDBNull(_datarow("s96")) Then
                    _s96 = _datarow("s96")
                End If
                If Not IsDBNull(_datarow("s97")) Then
                    _s97 = _datarow("s97")
                End If
                If Not IsDBNull(_datarow("s98")) Then
                    _s98 = _datarow("s98")
                End If
                If Not IsDBNull(_datarow("s99")) Then
                    _s99 = _datarow("s99")
                End If
            End If
        End Sub

        Public Sub Delete()
            Dim name() As String = {"@Salary_Month", "@Salary_Year", "@Employee_ID"}
            Dim oj() As Object = {Salary_Month, Salary_Year, Employee_ID}
            Dim tp() As String = {"Int", "Int", "NVarChar"}
            kn.ExecStore("dbo.usp_DeleteSmartBooks_Salary", name, oj, tp)
        End Sub

        Public Sub Update()
            Dim name() As String = {"@key", "@Salary_Month", "@Salary_Year", "@Employee_ID", "@s1", "@s2", "@s3", "@s4", "@s5", "@s6", "@s7", "@s8", "@s9", "@s10", "@s11", "@s12", "@s13", "@s14", "@s15", "@s16", "@s17", "@s18", "@s19", "@s20", "@s21", "@s22", "@s23", "@s24", "@s25", "@s26", "@s27", "@s28", "@s29", "@s30", "@s31", "@s32", "@s33", "@s34", "@s35", "@s36", "@s37", "@s38", "@s39", "@s40", "@s41", "@s42", "@s43", "@s44", "@s45", "@s46", "@s47", "@s48", "@s49", "@s50", "@s51", "@s52", "@s53", "@s54", "@s55", "@s56", "@s57", "@s58", "@s59", "@s60", "@s61", "@s62", "@s63", "@s64", "@s65", "@s66", "@s67", "@s68", "@s69", "@s70", "@s71", "@s72", "@s73", "@s74", "@s75", "@s76", "@s77", "@s78", "@s79", "@s80", "@s81", "@s82", "@s83", "@s84", "@s85", "@s86", "@s87", "@s88", "@s89", "@s90", "@s91", "@s92", "@s93", "@s94", "@s95", "@s96", "@s97", "@s98", "@s99"}
            Dim oj() As Object = {key, Salary_Month, Salary_Year, Employee_ID, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18, s19, s20, s21, s22, s23, s24, s25, s26, s27, s28, s29, s30, s31, s32, s33, s34, s35, s36, s37, s38, s39, s40, s41, s42, s43, s44, s45, s46, s47, s48, s49, s50, s51, s52, s53, s54, s55, s56, s57, s58, s59, s60, s61, s62, s63, s64, s65, s66, s67, s68, s69, s70, s71, s72, s73, s74, s75, s76, s77, s78, s79, s80, s81, s82, s83, s84, s85, s86, s87, s88, s89, s90, s91, s92, s93, s94, s95, s96, s97, s98, s99}
            Dim tp() As String = {"NVarChar", "Int", "Int", "NVarChar", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float"}
            kn.ExecStore("dbo.usp_UpdateSmartBooks_Salary", name, oj, tp)
        End Sub

        Public Sub Create()
            Dim name() As String = {"@key", "@Salary_Month", "@Salary_Year", "@Employee_ID", "@s1", "@s2", "@s3", "@s4", "@s5", "@s6", "@s7", "@s8", "@s9", "@s10", "@s11", "@s12", "@s13", "@s14", "@s15", "@s16", "@s17", "@s18", "@s19", "@s20", "@s21", "@s22", "@s23", "@s24", "@s25", "@s26", "@s27", "@s28", "@s29", "@s30", "@s31", "@s32", "@s33", "@s34", "@s35", "@s36", "@s37", "@s38", "@s39", "@s40", "@s41", "@s42", "@s43", "@s44", "@s45", "@s46", "@s47", "@s48", "@s49", "@s50", "@s51", "@s52", "@s53", "@s54", "@s55", "@s56", "@s57", "@s58", "@s59", "@s60", "@s61", "@s62", "@s63", "@s64", "@s65", "@s66", "@s67", "@s68", "@s69", "@s70", "@s71", "@s72", "@s73", "@s74", "@s75", "@s76", "@s77", "@s78", "@s79", "@s80", "@s81", "@s82", "@s83", "@s84", "@s85", "@s86", "@s87", "@s88", "@s89", "@s90", "@s91", "@s92", "@s93", "@s94", "@s95", "@s96", "@s97", "@s98", "@s99"}
            Dim oj() As Object = {key, Salary_Month, Salary_Year, Employee_ID, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18, s19, s20, s21, s22, s23, s24, s25, s26, s27, s28, s29, s30, s31, s32, s33, s34, s35, s36, s37, s38, s39, s40, s41, s42, s43, s44, s45, s46, s47, s48, s49, s50, s51, s52, s53, s54, s55, s56, s57, s58, s59, s60, s61, s62, s63, s64, s65, s66, s67, s68, s69, s70, s71, s72, s73, s74, s75, s76, s77, s78, s79, s80, s81, s82, s83, s84, s85, s86, s87, s88, s89, s90, s91, s92, s93, s94, s95, s96, s97, s98, s99}
            Dim tp() As String = {"NVarChar", "Int", "Int", "NVarChar", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float"}
            kn.ExecStore("dbo.usp_InsertSmartBooks_Salary", name, oj, tp)
        End Sub

        Public Sub CreateUpdate()
            Dim name() As String = {"@key", "@Salary_Month", "@Salary_Year", "@Employee_ID", "@s1", "@s2", "@s3", "@s4", "@s5", "@s6", "@s7", "@s8", "@s9", "@s10", "@s11", "@s12", "@s13", "@s14", "@s15", "@s16", "@s17", "@s18", "@s19", "@s20", "@s21", "@s22", "@s23", "@s24", "@s25", "@s26", "@s27", "@s28", "@s29", "@s30", "@s31", "@s32", "@s33", "@s34", "@s35", "@s36", "@s37", "@s38", "@s39", "@s40", "@s41", "@s42", "@s43", "@s44", "@s45", "@s46", "@s47", "@s48", "@s49", "@s50", "@s51", "@s52", "@s53", "@s54", "@s55", "@s56", "@s57", "@s58", "@s59", "@s60", "@s61", "@s62", "@s63", "@s64", "@s65", "@s66", "@s67", "@s68", "@s69", "@s70", "@s71", "@s72", "@s73", "@s74", "@s75", "@s76", "@s77", "@s78", "@s79", "@s80", "@s81", "@s82", "@s83", "@s84", "@s85", "@s86", "@s87", "@s88", "@s89", "@s90", "@s91", "@s92", "@s93", "@s94", "@s95", "@s96", "@s97", "@s98", "@s99"}
            Dim oj() As Object = {key, Salary_Month, Salary_Year, Employee_ID, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18, s19, s20, s21, s22, s23, s24, s25, s26, s27, s28, s29, s30, s31, s32, s33, s34, s35, s36, s37, s38, s39, s40, s41, s42, s43, s44, s45, s46, s47, s48, s49, s50, s51, s52, s53, s54, s55, s56, s57, s58, s59, s60, s61, s62, s63, s64, s65, s66, s67, s68, s69, s70, s71, s72, s73, s74, s75, s76, s77, s78, s79, s80, s81, s82, s83, s84, s85, s86, s87, s88, s89, s90, s91, s92, s93, s94, s95, s96, s97, s98, s99}
            Dim tp() As String = {"NVarChar", "Int", "Int", "NVarChar", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float", "Float"}
            kn.ExecStore("dbo.usp_InsertUpdateSmartBooks_Salary", name, oj, tp)
        End Sub

        Public Function GetSQLInsert() As String
            Dim __key As String
            Dim __Salary_Month As String
            Dim __Salary_Year As String
            Dim __Employee_ID As String
            Dim __s1 As String
            Dim __s2 As String
            Dim __s3 As String
            Dim __s4 As String
            Dim __s5 As String
            Dim __s6 As String
            Dim __s7 As String
            Dim __s8 As String
            Dim __s9 As String
            Dim __s10 As String
            Dim __s11 As String
            Dim __s12 As String
            Dim __s13 As String
            Dim __s14 As String
            Dim __s15 As String
            Dim __s16 As String
            Dim __s17 As String
            Dim __s18 As String
            Dim __s19 As String
            Dim __s20 As String
            Dim __s21 As String
            Dim __s22 As String
            Dim __s23 As String
            Dim __s24 As String
            Dim __s25 As String
            Dim __s26 As String
            Dim __s27 As String
            Dim __s28 As String
            Dim __s29 As String
            Dim __s30 As String
            Dim __s31 As String
            Dim __s32 As String
            Dim __s33 As String
            Dim __s34 As String
            Dim __s35 As String
            Dim __s36 As String
            Dim __s37 As String
            Dim __s38 As String
            Dim __s39 As String
            Dim __s40 As String
            Dim __s41 As String
            Dim __s42 As String
            Dim __s43 As String
            Dim __s44 As String
            Dim __s45 As String
            Dim __s46 As String
            Dim __s47 As String
            Dim __s48 As String
            Dim __s49 As String
            Dim __s50 As String
            Dim __s51 As String
            Dim __s52 As String
            Dim __s53 As String
            Dim __s54 As String
            Dim __s55 As String
            Dim __s56 As String
            Dim __s57 As String
            Dim __s58 As String
            Dim __s59 As String
            Dim __s60 As String
            Dim __s61 As String
            Dim __s62 As String
            Dim __s63 As String
            Dim __s64 As String
            Dim __s65 As String
            Dim __s66 As String
            Dim __s67 As String
            Dim __s68 As String
            Dim __s69 As String
            Dim __s70 As String
            Dim __s71 As String
            Dim __s72 As String
            Dim __s73 As String
            Dim __s74 As String
            Dim __s75 As String
            Dim __s76 As String
            Dim __s77 As String
            Dim __s78 As String
            Dim __s79 As String
            Dim __s80 As String
            Dim __s81 As String
            Dim __s82 As String
            Dim __s83 As String
            Dim __s84 As String
            Dim __s85 As String
            Dim __s86 As String
            Dim __s87 As String
            Dim __s88 As String
            Dim __s89 As String
            Dim __s90 As String
            Dim __s91 As String
            Dim __s92 As String
            Dim __s93 As String
            Dim __s94 As String
            Dim __s95 As String
            Dim __s96 As String
            Dim __s97 As String
            Dim __s98 As String
            Dim __s99 As String
            If key <> String.Empty Then
                __key = "N'" + key + "'"
            Else
                __key = "null"
            End If
            __Salary_Month = "'" + Salary_Month.tostring + "'"
            __Salary_Year = "'" + Salary_Year.tostring + "'"
            If Employee_ID <> String.Empty Then
                __Employee_ID = "N'" + Employee_ID + "'"
            Else
                __Employee_ID = "null"
            End If
            __s1 = "'" + s1.tostring + "'"
            __s2 = "'" + s2.tostring + "'"
            __s3 = "'" + s3.tostring + "'"
            __s4 = "'" + s4.tostring + "'"
            __s5 = "'" + s5.tostring + "'"
            __s6 = "'" + s6.tostring + "'"
            __s7 = "'" + s7.tostring + "'"
            __s8 = "'" + s8.tostring + "'"
            __s9 = "'" + s9.tostring + "'"
            __s10 = "'" + s10.tostring + "'"
            __s11 = "'" + s11.tostring + "'"
            __s12 = "'" + s12.tostring + "'"
            __s13 = "'" + s13.tostring + "'"
            __s14 = "'" + s14.tostring + "'"
            __s15 = "'" + s15.tostring + "'"
            __s16 = "'" + s16.tostring + "'"
            __s17 = "'" + s17.tostring + "'"
            __s18 = "'" + s18.tostring + "'"
            __s19 = "'" + s19.tostring + "'"
            __s20 = "'" + s20.tostring + "'"
            __s21 = "'" + s21.tostring + "'"
            __s22 = "'" + s22.tostring + "'"
            __s23 = "'" + s23.tostring + "'"
            __s24 = "'" + s24.tostring + "'"
            __s25 = "'" + s25.tostring + "'"
            __s26 = "'" + s26.tostring + "'"
            __s27 = "'" + s27.tostring + "'"
            __s28 = "'" + s28.tostring + "'"
            __s29 = "'" + s29.tostring + "'"
            __s30 = "'" + s30.tostring + "'"
            __s31 = "'" + s31.tostring + "'"
            __s32 = "'" + s32.tostring + "'"
            __s33 = "'" + s33.tostring + "'"
            __s34 = "'" + s34.tostring + "'"
            __s35 = "'" + s35.tostring + "'"
            __s36 = "'" + s36.tostring + "'"
            __s37 = "'" + s37.tostring + "'"
            __s38 = "'" + s38.tostring + "'"
            __s39 = "'" + s39.tostring + "'"
            __s40 = "'" + s40.tostring + "'"
            __s41 = "'" + s41.tostring + "'"
            __s42 = "'" + s42.tostring + "'"
            __s43 = "'" + s43.tostring + "'"
            __s44 = "'" + s44.tostring + "'"
            __s45 = "'" + s45.tostring + "'"
            __s46 = "'" + s46.tostring + "'"
            __s47 = "'" + s47.tostring + "'"
            __s48 = "'" + s48.tostring + "'"
            __s49 = "'" + s49.tostring + "'"
            __s50 = "'" + s50.tostring + "'"
            __s51 = "'" + s51.tostring + "'"
            __s52 = "'" + s52.tostring + "'"
            __s53 = "'" + s53.tostring + "'"
            __s54 = "'" + s54.tostring + "'"
            __s55 = "'" + s55.tostring + "'"
            __s56 = "'" + s56.tostring + "'"
            __s57 = "'" + s57.tostring + "'"
            __s58 = "'" + s58.tostring + "'"
            __s59 = "'" + s59.tostring + "'"
            __s60 = "'" + s60.tostring + "'"
            __s61 = "'" + s61.tostring + "'"
            __s62 = "'" + s62.tostring + "'"
            __s63 = "'" + s63.tostring + "'"
            __s64 = "'" + s64.tostring + "'"
            __s65 = "'" + s65.tostring + "'"
            __s66 = "'" + s66.tostring + "'"
            __s67 = "'" + s67.tostring + "'"
            __s68 = "'" + s68.tostring + "'"
            __s69 = "'" + s69.tostring + "'"
            __s70 = "'" + s70.tostring + "'"
            __s71 = "'" + s71.tostring + "'"
            __s72 = "'" + s72.tostring + "'"
            __s73 = "'" + s73.tostring + "'"
            __s74 = "'" + s74.tostring + "'"
            __s75 = "'" + s75.tostring + "'"
            __s76 = "'" + s76.tostring + "'"
            __s77 = "'" + s77.tostring + "'"
            __s78 = "'" + s78.tostring + "'"
            __s79 = "'" + s79.tostring + "'"
            __s80 = "'" + s80.tostring + "'"
            __s81 = "'" + s81.tostring + "'"
            __s82 = "'" + s82.tostring + "'"
            __s83 = "'" + s83.tostring + "'"
            __s84 = "'" + s84.tostring + "'"
            __s85 = "'" + s85.tostring + "'"
            __s86 = "'" + s86.tostring + "'"
            __s87 = "'" + s87.tostring + "'"
            __s88 = "'" + s88.tostring + "'"
            __s89 = "'" + s89.tostring + "'"
            __s90 = "'" + s90.tostring + "'"
            __s91 = "'" + s91.tostring + "'"
            __s92 = "'" + s92.tostring + "'"
            __s93 = "'" + s93.tostring + "'"
            __s94 = "'" + s94.tostring + "'"
            __s95 = "'" + s95.tostring + "'"
            __s96 = "'" + s96.tostring + "'"
            __s97 = "'" + s97.tostring + "'"
            __s98 = "'" + s98.tostring + "'"
            __s99 = "'" + s99.tostring + "'"
            Dim sql As String = String.Empty
            sql = "INSERT INTO [SmartBooks_Salary]([key],[Salary_Month],[Salary_Year],[Employee_ID],[s1],[s2],[s3],[s4],[s5],[s6],[s7],[s8],[s9],[s10],[s11],[s12],[s13],[s14],[s15],[s16],[s17],[s18],[s19],[s20],[s21],[s22],[s23],[s24],[s25],[s26],[s27],[s28],[s29],[s30],[s31],[s32],[s33],[s34],[s35],[s36],[s37],[s38],[s39],[s40],[s41],[s42],[s43],[s44],[s45],[s46],[s47],[s48],[s49],[s50],[s51],[s52],[s53],[s54],[s55],[s56],[s57],[s58],[s59],[s60],[s61],[s62],[s63],[s64],[s65],[s66],[s67],[s68],[s69],[s70],[s71],[s72],[s73],[s74],[s75],[s76],[s77],[s78],[s79],[s80],[s81],[s82],[s83],[s84],[s85],[s86],[s87],[s88],[s89],[s90],[s91],[s92],[s93],[s94],[s95],[s96],[s97],[s98],[s99])VALUES(" & _
            __key + "," + __Salary_Month + "," + __Salary_Year + "," + __Employee_ID + "," + __s1 + "," + __s2 + "," + __s3 + "," + __s4 + "," + __s5 + "," + __s6 + "," + __s7 + "," + __s8 + "," + __s9 + "," + __s10 + "," + __s11 + "," + __s12 + "," + __s13 + "," + __s14 + "," + __s15 + "," + __s16 + "," + __s17 + "," + __s18 + "," + __s19 + "," + __s20 + "," + __s21 + "," + __s22 + "," + __s23 + "," + __s24 + "," + __s25 + "," + __s26 + "," + __s27 + "," + __s28 + "," + __s29 + "," + __s30 + "," + __s31 + "," + __s32 + "," + __s33 + "," + __s34 + "," + __s35 + "," + __s36 + "," + __s37 + "," + __s38 + "," + __s39 + "," + __s40 + "," + __s41 + "," + __s42 + "," + __s43 + "," + __s44 + "," + __s45 + "," + __s46 + "," + __s47 + "," + __s48 + "," + __s49 + "," + __s50 + "," + __s51 + "," + __s52 + "," + __s53 + "," + __s54 + "," + __s55 + "," + __s56 + "," + __s57 + "," + __s58 + "," + __s59 + "," + __s60 + "," + __s61 + "," + __s62 + "," + __s63 + "," + __s64 + "," + __s65 + "," + __s66 + "," + __s67 + "," + __s68 + "," + __s69 + "," + __s70 + "," + __s71 + "," + __s72 + "," + __s73 + "," + __s74 + "," + __s75 + "," + __s76 + "," + __s77 + "," + __s78 + "," + __s79 + "," + __s80 + "," + __s81 + "," + __s82 + "," + __s83 + "," + __s84 + "," + __s85 + "," + __s86 + "," + __s87 + "," + __s88 + "," + __s89 + "," + __s90 + "," + __s91 + "," + __s92 + "," + __s93 + "," + __s94 + "," + __s95 + "," + __s96 + "," + __s97 + "," + __s98 + "," + __s99 + ")"
            Return sql
        End Function

        Public Function GetSQLUpdate() As String
            Dim __key As String
            Dim __Salary_Month As String
            Dim __Salary_Year As String
            Dim __Employee_ID As String
            Dim __s1 As String
            Dim __s2 As String
            Dim __s3 As String
            Dim __s4 As String
            Dim __s5 As String
            Dim __s6 As String
            Dim __s7 As String
            Dim __s8 As String
            Dim __s9 As String
            Dim __s10 As String
            Dim __s11 As String
            Dim __s12 As String
            Dim __s13 As String
            Dim __s14 As String
            Dim __s15 As String
            Dim __s16 As String
            Dim __s17 As String
            Dim __s18 As String
            Dim __s19 As String
            Dim __s20 As String
            Dim __s21 As String
            Dim __s22 As String
            Dim __s23 As String
            Dim __s24 As String
            Dim __s25 As String
            Dim __s26 As String
            Dim __s27 As String
            Dim __s28 As String
            Dim __s29 As String
            Dim __s30 As String
            Dim __s31 As String
            Dim __s32 As String
            Dim __s33 As String
            Dim __s34 As String
            Dim __s35 As String
            Dim __s36 As String
            Dim __s37 As String
            Dim __s38 As String
            Dim __s39 As String
            Dim __s40 As String
            Dim __s41 As String
            Dim __s42 As String
            Dim __s43 As String
            Dim __s44 As String
            Dim __s45 As String
            Dim __s46 As String
            Dim __s47 As String
            Dim __s48 As String
            Dim __s49 As String
            Dim __s50 As String
            Dim __s51 As String
            Dim __s52 As String
            Dim __s53 As String
            Dim __s54 As String
            Dim __s55 As String
            Dim __s56 As String
            Dim __s57 As String
            Dim __s58 As String
            Dim __s59 As String
            Dim __s60 As String
            Dim __s61 As String
            Dim __s62 As String
            Dim __s63 As String
            Dim __s64 As String
            Dim __s65 As String
            Dim __s66 As String
            Dim __s67 As String
            Dim __s68 As String
            Dim __s69 As String
            Dim __s70 As String
            Dim __s71 As String
            Dim __s72 As String
            Dim __s73 As String
            Dim __s74 As String
            Dim __s75 As String
            Dim __s76 As String
            Dim __s77 As String
            Dim __s78 As String
            Dim __s79 As String
            Dim __s80 As String
            Dim __s81 As String
            Dim __s82 As String
            Dim __s83 As String
            Dim __s84 As String
            Dim __s85 As String
            Dim __s86 As String
            Dim __s87 As String
            Dim __s88 As String
            Dim __s89 As String
            Dim __s90 As String
            Dim __s91 As String
            Dim __s92 As String
            Dim __s93 As String
            Dim __s94 As String
            Dim __s95 As String
            Dim __s96 As String
            Dim __s97 As String
            Dim __s98 As String
            Dim __s99 As String
            If key <> String.Empty Then
                __key = "N'" + key + "'"
            Else
                __key = "null"
            End If
            __Salary_Month = "'" + Salary_Month.tostring + "'"
            __Salary_Year = "'" + Salary_Year.tostring + "'"
            If Employee_ID <> String.Empty Then
                __Employee_ID = "N'" + Employee_ID + "'"
            Else
                __Employee_ID = "null"
            End If
            __s1 = "'" + s1.tostring + "'"
            __s2 = "'" + s2.tostring + "'"
            __s3 = "'" + s3.tostring + "'"
            __s4 = "'" + s4.tostring + "'"
            __s5 = "'" + s5.tostring + "'"
            __s6 = "'" + s6.tostring + "'"
            __s7 = "'" + s7.tostring + "'"
            __s8 = "'" + s8.tostring + "'"
            __s9 = "'" + s9.tostring + "'"
            __s10 = "'" + s10.tostring + "'"
            __s11 = "'" + s11.tostring + "'"
            __s12 = "'" + s12.tostring + "'"
            __s13 = "'" + s13.tostring + "'"
            __s14 = "'" + s14.tostring + "'"
            __s15 = "'" + s15.tostring + "'"
            __s16 = "'" + s16.tostring + "'"
            __s17 = "'" + s17.tostring + "'"
            __s18 = "'" + s18.tostring + "'"
            __s19 = "'" + s19.tostring + "'"
            __s20 = "'" + s20.tostring + "'"
            __s21 = "'" + s21.tostring + "'"
            __s22 = "'" + s22.tostring + "'"
            __s23 = "'" + s23.tostring + "'"
            __s24 = "'" + s24.tostring + "'"
            __s25 = "'" + s25.tostring + "'"
            __s26 = "'" + s26.tostring + "'"
            __s27 = "'" + s27.tostring + "'"
            __s28 = "'" + s28.tostring + "'"
            __s29 = "'" + s29.tostring + "'"
            __s30 = "'" + s30.tostring + "'"
            __s31 = "'" + s31.tostring + "'"
            __s32 = "'" + s32.tostring + "'"
            __s33 = "'" + s33.tostring + "'"
            __s34 = "'" + s34.tostring + "'"
            __s35 = "'" + s35.tostring + "'"
            __s36 = "'" + s36.tostring + "'"
            __s37 = "'" + s37.tostring + "'"
            __s38 = "'" + s38.tostring + "'"
            __s39 = "'" + s39.tostring + "'"
            __s40 = "'" + s40.tostring + "'"
            __s41 = "'" + s41.tostring + "'"
            __s42 = "'" + s42.tostring + "'"
            __s43 = "'" + s43.tostring + "'"
            __s44 = "'" + s44.tostring + "'"
            __s45 = "'" + s45.tostring + "'"
            __s46 = "'" + s46.tostring + "'"
            __s47 = "'" + s47.tostring + "'"
            __s48 = "'" + s48.tostring + "'"
            __s49 = "'" + s49.tostring + "'"
            __s50 = "'" + s50.tostring + "'"
            __s51 = "'" + s51.tostring + "'"
            __s52 = "'" + s52.tostring + "'"
            __s53 = "'" + s53.tostring + "'"
            __s54 = "'" + s54.tostring + "'"
            __s55 = "'" + s55.tostring + "'"
            __s56 = "'" + s56.tostring + "'"
            __s57 = "'" + s57.tostring + "'"
            __s58 = "'" + s58.tostring + "'"
            __s59 = "'" + s59.tostring + "'"
            __s60 = "'" + s60.tostring + "'"
            __s61 = "'" + s61.tostring + "'"
            __s62 = "'" + s62.tostring + "'"
            __s63 = "'" + s63.tostring + "'"
            __s64 = "'" + s64.tostring + "'"
            __s65 = "'" + s65.tostring + "'"
            __s66 = "'" + s66.tostring + "'"
            __s67 = "'" + s67.tostring + "'"
            __s68 = "'" + s68.tostring + "'"
            __s69 = "'" + s69.tostring + "'"
            __s70 = "'" + s70.tostring + "'"
            __s71 = "'" + s71.tostring + "'"
            __s72 = "'" + s72.tostring + "'"
            __s73 = "'" + s73.tostring + "'"
            __s74 = "'" + s74.tostring + "'"
            __s75 = "'" + s75.tostring + "'"
            __s76 = "'" + s76.tostring + "'"
            __s77 = "'" + s77.tostring + "'"
            __s78 = "'" + s78.tostring + "'"
            __s79 = "'" + s79.tostring + "'"
            __s80 = "'" + s80.tostring + "'"
            __s81 = "'" + s81.tostring + "'"
            __s82 = "'" + s82.tostring + "'"
            __s83 = "'" + s83.tostring + "'"
            __s84 = "'" + s84.tostring + "'"
            __s85 = "'" + s85.tostring + "'"
            __s86 = "'" + s86.tostring + "'"
            __s87 = "'" + s87.tostring + "'"
            __s88 = "'" + s88.tostring + "'"
            __s89 = "'" + s89.tostring + "'"
            __s90 = "'" + s90.tostring + "'"
            __s91 = "'" + s91.tostring + "'"
            __s92 = "'" + s92.tostring + "'"
            __s93 = "'" + s93.tostring + "'"
            __s94 = "'" + s94.tostring + "'"
            __s95 = "'" + s95.tostring + "'"
            __s96 = "'" + s96.tostring + "'"
            __s97 = "'" + s97.tostring + "'"
            __s98 = "'" + s98.tostring + "'"
            __s99 = "'" + s99.tostring + "'"
            Dim sql As String = String.Empty
            sql = "UPDATE [SmartBooks_Salary] SET [key]=" + __key + ",[Salary_Month]=" + __Salary_Month + ",[Salary_Year]=" + __Salary_Year + ",[Employee_ID]=" + __Employee_ID + ",[s1]=" + __s1 + ",[s2]=" + __s2 + ",[s3]=" + __s3 + ",[s4]=" + __s4 + ",[s5]=" + __s5 + ",[s6]=" + __s6 + ",[s7]=" + __s7 + ",[s8]=" + __s8 + ",[s9]=" + __s9 + ",[s10]=" + __s10 + ",[s11]=" + __s11 + ",[s12]=" + __s12 + ",[s13]=" + __s13 + ",[s14]=" + __s14 + ",[s15]=" + __s15 + ",[s16]=" + __s16 + ",[s17]=" + __s17 + ",[s18]=" + __s18 + ",[s19]=" + __s19 + ",[s20]=" + __s20 + ",[s21]=" + __s21 + ",[s22]=" + __s22 + ",[s23]=" + __s23 + ",[s24]=" + __s24 + ",[s25]=" + __s25 + ",[s26]=" + __s26 + ",[s27]=" + __s27 + ",[s28]=" + __s28 + ",[s29]=" + __s29 + ",[s30]=" + __s30 + ",[s31]=" + __s31 + ",[s32]=" + __s32 + ",[s33]=" + __s33 + ",[s34]=" + __s34 + ",[s35]=" + __s35 + ",[s36]=" + __s36 + ",[s37]=" + __s37 + ",[s38]=" + __s38 + ",[s39]=" + __s39 + ",[s40]=" + __s40 + ",[s41]=" + __s41 + ",[s42]=" + __s42 + ",[s43]=" + __s43 + ",[s44]=" + __s44 + ",[s45]=" + __s45 + ",[s46]=" + __s46 + ",[s47]=" + __s47 + ",[s48]=" + __s48 + ",[s49]=" + __s49 + ",[s50]=" + __s50 + ",[s51]=" + __s51 + ",[s52]=" + __s52 + ",[s53]=" + __s53 + ",[s54]=" + __s54 + ",[s55]=" + __s55 + ",[s56]=" + __s56 + ",[s57]=" + __s57 + ",[s58]=" + __s58 + ",[s59]=" + __s59 + ",[s60]=" + __s60 + ",[s61]=" + __s61 + ",[s62]=" + __s62 + ",[s63]=" + __s63 + ",[s64]=" + __s64 + ",[s65]=" + __s65 + ",[s66]=" + __s66 + ",[s67]=" + __s67 + ",[s68]=" + __s68 + ",[s69]=" + __s69 + ",[s70]=" + __s70 + ",[s71]=" + __s71 + ",[s72]=" + __s72 + ",[s73]=" + __s73 + ",[s74]=" + __s74 + ",[s75]=" + __s75 + ",[s76]=" + __s76 + ",[s77]=" + __s77 + ",[s78]=" + __s78 + ",[s79]=" + __s79 + ",[s80]=" + __s80 + ",[s81]=" + __s81 + ",[s82]=" + __s82 + ",[s83]=" + __s83 + ",[s84]=" + __s84 + ",[s85]=" + __s85 + ",[s86]=" + __s86 + ",[s87]=" + __s87 + ",[s88]=" + __s88 + ",[s89]=" + __s89 + ",[s90]=" + __s90 + ",[s91]=" + __s91 + ",[s92]=" + __s92 + ",[s93]=" + __s93 + ",[s94]=" + __s94 + ",[s95]=" + __s95 + ",[s96]=" + __s96 + ",[s97]=" + __s97 + ",[s98]=" + __s98 + ",[s99]=" + __s99 + " WHERE [Salary_Month]=" + __Salary_Month + " and [Salary_Year]=" + __Salary_Year + " and [Employee_ID]=" + __Employee_ID
            Return sql
        End Function

        Public Function GetSQLDelete() As String
            Dim __Salary_Month As String
            Dim __Salary_Year As String
            Dim __Employee_ID As String
            __Salary_Month = "'" + Salary_Month.tostring + "'"
            __Salary_Year = "'" + Salary_Year.tostring + "'"
            If Employee_ID <> String.Empty Then
                __Employee_ID = "N'" + Employee_ID + "'"
            Else
                __Employee_ID = "null"
            End If
            Dim sql As String = String.Empty
            sql = "DELETE FROM [SmartBooks_Salary] WHERE [Salary_Month]=" + __Salary_Month + " and [Salary_Year]=" + __Salary_Year + " and [Employee_ID]=" + __Employee_ID
            Return sql
        End Function

        Public Shared Function NewSmartBooks_Salary(ByVal Salary_Month As System.Int32, ByVal Salary_Year As System.Int32, ByVal Employee_ID As System.String) As SmartBooks_Salary
            Dim newEntity As New SmartBooks_Salary
            newEntity._salary_Month = Salary_Month
            newEntity._salary_Year = Salary_Year
            newEntity._employee_ID = Employee_ID
            Return newEntity
        End Function

#Region "Public Properties"
        Public Property key() As System.String
            Get
                Return _key
            End Get
            Set(ByVal value As System.String)
                _key = value
            End Set
        End Property

        Public Property Salary_Month() As System.Int32
            Get
                Return _salary_Month
            End Get
            Set(ByVal value As System.Int32)
                _salary_Month = value
            End Set
        End Property

        Public Property Salary_Year() As System.Int32
            Get
                Return _salary_Year
            End Get
            Set(ByVal value As System.Int32)
                _salary_Year = value
            End Set
        End Property

        Public Property Employee_ID() As System.String
            Get
                Return _employee_ID
            End Get
            Set(ByVal value As System.String)
                _employee_ID = value
            End Set
        End Property

        Public Property s1() As System.Double
            Get
                Return _s1
            End Get
            Set(ByVal value As System.Double)
                _s1 = value
            End Set
        End Property

        Public Property s2() As System.Double
            Get
                Return _s2
            End Get
            Set(ByVal value As System.Double)
                _s2 = value
            End Set
        End Property

        Public Property s3() As System.Double
            Get
                Return _s3
            End Get
            Set(ByVal value As System.Double)
                _s3 = value
            End Set
        End Property

        Public Property s4() As System.Double
            Get
                Return _s4
            End Get
            Set(ByVal value As System.Double)
                _s4 = value
            End Set
        End Property

        Public Property s5() As System.Double
            Get
                Return _s5
            End Get
            Set(ByVal value As System.Double)
                _s5 = value
            End Set
        End Property

        Public Property s6() As System.Double
            Get
                Return _s6
            End Get
            Set(ByVal value As System.Double)
                _s6 = value
            End Set
        End Property

        Public Property s7() As System.Double
            Get
                Return _s7
            End Get
            Set(ByVal value As System.Double)
                _s7 = value
            End Set
        End Property

        Public Property s8() As System.Double
            Get
                Return _s8
            End Get
            Set(ByVal value As System.Double)
                _s8 = value
            End Set
        End Property

        Public Property s9() As System.Double
            Get
                Return _s9
            End Get
            Set(ByVal value As System.Double)
                _s9 = value
            End Set
        End Property

        Public Property s10() As System.Double
            Get
                Return _s10
            End Get
            Set(ByVal value As System.Double)
                _s10 = value
            End Set
        End Property

        Public Property s11() As System.Double
            Get
                Return _s11
            End Get
            Set(ByVal value As System.Double)
                _s11 = value
            End Set
        End Property

        Public Property s12() As System.Double
            Get
                Return _s12
            End Get
            Set(ByVal value As System.Double)
                _s12 = value
            End Set
        End Property

        Public Property s13() As System.Double
            Get
                Return _s13
            End Get
            Set(ByVal value As System.Double)
                _s13 = value
            End Set
        End Property

        Public Property s14() As System.Double
            Get
                Return _s14
            End Get
            Set(ByVal value As System.Double)
                _s14 = value
            End Set
        End Property

        Public Property s15() As System.Double
            Get
                Return _s15
            End Get
            Set(ByVal value As System.Double)
                _s15 = value
            End Set
        End Property

        Public Property s16() As System.Double
            Get
                Return _s16
            End Get
            Set(ByVal value As System.Double)
                _s16 = value
            End Set
        End Property

        Public Property s17() As System.Double
            Get
                Return _s17
            End Get
            Set(ByVal value As System.Double)
                _s17 = value
            End Set
        End Property

        Public Property s18() As System.Double
            Get
                Return _s18
            End Get
            Set(ByVal value As System.Double)
                _s18 = value
            End Set
        End Property

        Public Property s19() As System.Double
            Get
                Return _s19
            End Get
            Set(ByVal value As System.Double)
                _s19 = value
            End Set
        End Property

        Public Property s20() As System.Double
            Get
                Return _s20
            End Get
            Set(ByVal value As System.Double)
                _s20 = value
            End Set
        End Property

        Public Property s21() As System.Double
            Get
                Return _s21
            End Get
            Set(ByVal value As System.Double)
                _s21 = value
            End Set
        End Property

        Public Property s22() As System.Double
            Get
                Return _s22
            End Get
            Set(ByVal value As System.Double)
                _s22 = value
            End Set
        End Property

        Public Property s23() As System.Double
            Get
                Return _s23
            End Get
            Set(ByVal value As System.Double)
                _s23 = value
            End Set
        End Property

        Public Property s24() As System.Double
            Get
                Return _s24
            End Get
            Set(ByVal value As System.Double)
                _s24 = value
            End Set
        End Property

        Public Property s25() As System.Double
            Get
                Return _s25
            End Get
            Set(ByVal value As System.Double)
                _s25 = value
            End Set
        End Property

        Public Property s26() As System.Double
            Get
                Return _s26
            End Get
            Set(ByVal value As System.Double)
                _s26 = value
            End Set
        End Property

        Public Property s27() As System.Double
            Get
                Return _s27
            End Get
            Set(ByVal value As System.Double)
                _s27 = value
            End Set
        End Property

        Public Property s28() As System.Double
            Get
                Return _s28
            End Get
            Set(ByVal value As System.Double)
                _s28 = value
            End Set
        End Property

        Public Property s29() As System.Double
            Get
                Return _s29
            End Get
            Set(ByVal value As System.Double)
                _s29 = value
            End Set
        End Property

        Public Property s30() As System.Double
            Get
                Return _s30
            End Get
            Set(ByVal value As System.Double)
                _s30 = value
            End Set
        End Property

        Public Property s31() As System.Double
            Get
                Return _s31
            End Get
            Set(ByVal value As System.Double)
                _s31 = value
            End Set
        End Property

        Public Property s32() As System.Double
            Get
                Return _s32
            End Get
            Set(ByVal value As System.Double)
                _s32 = value
            End Set
        End Property

        Public Property s33() As System.Double
            Get
                Return _s33
            End Get
            Set(ByVal value As System.Double)
                _s33 = value
            End Set
        End Property

        Public Property s34() As System.Double
            Get
                Return _s34
            End Get
            Set(ByVal value As System.Double)
                _s34 = value
            End Set
        End Property

        Public Property s35() As System.Double
            Get
                Return _s35
            End Get
            Set(ByVal value As System.Double)
                _s35 = value
            End Set
        End Property

        Public Property s36() As System.Double
            Get
                Return _s36
            End Get
            Set(ByVal value As System.Double)
                _s36 = value
            End Set
        End Property

        Public Property s37() As System.Double
            Get
                Return _s37
            End Get
            Set(ByVal value As System.Double)
                _s37 = value
            End Set
        End Property

        Public Property s38() As System.Double
            Get
                Return _s38
            End Get
            Set(ByVal value As System.Double)
                _s38 = value
            End Set
        End Property

        Public Property s39() As System.Double
            Get
                Return _s39
            End Get
            Set(ByVal value As System.Double)
                _s39 = value
            End Set
        End Property

        Public Property s40() As System.Double
            Get
                Return _s40
            End Get
            Set(ByVal value As System.Double)
                _s40 = value
            End Set
        End Property

        Public Property s41() As System.Double
            Get
                Return _s41
            End Get
            Set(ByVal value As System.Double)
                _s41 = value
            End Set
        End Property

        Public Property s42() As System.Double
            Get
                Return _s42
            End Get
            Set(ByVal value As System.Double)
                _s42 = value
            End Set
        End Property

        Public Property s43() As System.Double
            Get
                Return _s43
            End Get
            Set(ByVal value As System.Double)
                _s43 = value
            End Set
        End Property

        Public Property s44() As System.Double
            Get
                Return _s44
            End Get
            Set(ByVal value As System.Double)
                _s44 = value
            End Set
        End Property

        Public Property s45() As System.Double
            Get
                Return _s45
            End Get
            Set(ByVal value As System.Double)
                _s45 = value
            End Set
        End Property

        Public Property s46() As System.Double
            Get
                Return _s46
            End Get
            Set(ByVal value As System.Double)
                _s46 = value
            End Set
        End Property

        Public Property s47() As System.Double
            Get
                Return _s47
            End Get
            Set(ByVal value As System.Double)
                _s47 = value
            End Set
        End Property

        Public Property s48() As System.Double
            Get
                Return _s48
            End Get
            Set(ByVal value As System.Double)
                _s48 = value
            End Set
        End Property

        Public Property s49() As System.Double
            Get
                Return _s49
            End Get
            Set(ByVal value As System.Double)
                _s49 = value
            End Set
        End Property

        Public Property s50() As System.Double
            Get
                Return _s50
            End Get
            Set(ByVal value As System.Double)
                _s50 = value
            End Set
        End Property

        Public Property s51() As System.Double
            Get
                Return _s51
            End Get
            Set(ByVal value As System.Double)
                _s51 = value
            End Set
        End Property

        Public Property s52() As System.Double
            Get
                Return _s52
            End Get
            Set(ByVal value As System.Double)
                _s52 = value
            End Set
        End Property

        Public Property s53() As System.Double
            Get
                Return _s53
            End Get
            Set(ByVal value As System.Double)
                _s53 = value
            End Set
        End Property

        Public Property s54() As System.Double
            Get
                Return _s54
            End Get
            Set(ByVal value As System.Double)
                _s54 = value
            End Set
        End Property

        Public Property s55() As System.Double
            Get
                Return _s55
            End Get
            Set(ByVal value As System.Double)
                _s55 = value
            End Set
        End Property

        Public Property s56() As System.Double
            Get
                Return _s56
            End Get
            Set(ByVal value As System.Double)
                _s56 = value
            End Set
        End Property

        Public Property s57() As System.Double
            Get
                Return _s57
            End Get
            Set(ByVal value As System.Double)
                _s57 = value
            End Set
        End Property

        Public Property s58() As System.Double
            Get
                Return _s58
            End Get
            Set(ByVal value As System.Double)
                _s58 = value
            End Set
        End Property

        Public Property s59() As System.Double
            Get
                Return _s59
            End Get
            Set(ByVal value As System.Double)
                _s59 = value
            End Set
        End Property

        Public Property s60() As System.Double
            Get
                Return _s60
            End Get
            Set(ByVal value As System.Double)
                _s60 = value
            End Set
        End Property

        Public Property s61() As System.Double
            Get
                Return _s61
            End Get
            Set(ByVal value As System.Double)
                _s61 = value
            End Set
        End Property

        Public Property s62() As System.Double
            Get
                Return _s62
            End Get
            Set(ByVal value As System.Double)
                _s62 = value
            End Set
        End Property

        Public Property s63() As System.Double
            Get
                Return _s63
            End Get
            Set(ByVal value As System.Double)
                _s63 = value
            End Set
        End Property

        Public Property s64() As System.Double
            Get
                Return _s64
            End Get
            Set(ByVal value As System.Double)
                _s64 = value
            End Set
        End Property

        Public Property s65() As System.Double
            Get
                Return _s65
            End Get
            Set(ByVal value As System.Double)
                _s65 = value
            End Set
        End Property

        Public Property s66() As System.Double
            Get
                Return _s66
            End Get
            Set(ByVal value As System.Double)
                _s66 = value
            End Set
        End Property

        Public Property s67() As System.Double
            Get
                Return _s67
            End Get
            Set(ByVal value As System.Double)
                _s67 = value
            End Set
        End Property

        Public Property s68() As System.Double
            Get
                Return _s68
            End Get
            Set(ByVal value As System.Double)
                _s68 = value
            End Set
        End Property

        Public Property s69() As System.Double
            Get
                Return _s69
            End Get
            Set(ByVal value As System.Double)
                _s69 = value
            End Set
        End Property

        Public Property s70() As System.Double
            Get
                Return _s70
            End Get
            Set(ByVal value As System.Double)
                _s70 = value
            End Set
        End Property

        Public Property s71() As System.Double
            Get
                Return _s71
            End Get
            Set(ByVal value As System.Double)
                _s71 = value
            End Set
        End Property

        Public Property s72() As System.Double
            Get
                Return _s72
            End Get
            Set(ByVal value As System.Double)
                _s72 = value
            End Set
        End Property

        Public Property s73() As System.Double
            Get
                Return _s73
            End Get
            Set(ByVal value As System.Double)
                _s73 = value
            End Set
        End Property

        Public Property s74() As System.Double
            Get
                Return _s74
            End Get
            Set(ByVal value As System.Double)
                _s74 = value
            End Set
        End Property

        Public Property s75() As System.Double
            Get
                Return _s75
            End Get
            Set(ByVal value As System.Double)
                _s75 = value
            End Set
        End Property

        Public Property s76() As System.Double
            Get
                Return _s76
            End Get
            Set(ByVal value As System.Double)
                _s76 = value
            End Set
        End Property

        Public Property s77() As System.Double
            Get
                Return _s77
            End Get
            Set(ByVal value As System.Double)
                _s77 = value
            End Set
        End Property

        Public Property s78() As System.Double
            Get
                Return _s78
            End Get
            Set(ByVal value As System.Double)
                _s78 = value
            End Set
        End Property

        Public Property s79() As System.Double
            Get
                Return _s79
            End Get
            Set(ByVal value As System.Double)
                _s79 = value
            End Set
        End Property

        Public Property s80() As System.Double
            Get
                Return _s80
            End Get
            Set(ByVal value As System.Double)
                _s80 = value
            End Set
        End Property

        Public Property s81() As System.Double
            Get
                Return _s81
            End Get
            Set(ByVal value As System.Double)
                _s81 = value
            End Set
        End Property

        Public Property s82() As System.Double
            Get
                Return _s82
            End Get
            Set(ByVal value As System.Double)
                _s82 = value
            End Set
        End Property

        Public Property s83() As System.Double
            Get
                Return _s83
            End Get
            Set(ByVal value As System.Double)
                _s83 = value
            End Set
        End Property

        Public Property s84() As System.Double
            Get
                Return _s84
            End Get
            Set(ByVal value As System.Double)
                _s84 = value
            End Set
        End Property

        Public Property s85() As System.Double
            Get
                Return _s85
            End Get
            Set(ByVal value As System.Double)
                _s85 = value
            End Set
        End Property

        Public Property s86() As System.Double
            Get
                Return _s86
            End Get
            Set(ByVal value As System.Double)
                _s86 = value
            End Set
        End Property

        Public Property s87() As System.Double
            Get
                Return _s87
            End Get
            Set(ByVal value As System.Double)
                _s87 = value
            End Set
        End Property

        Public Property s88() As System.Double
            Get
                Return _s88
            End Get
            Set(ByVal value As System.Double)
                _s88 = value
            End Set
        End Property

        Public Property s89() As System.Double
            Get
                Return _s89
            End Get
            Set(ByVal value As System.Double)
                _s89 = value
            End Set
        End Property

        Public Property s90() As System.Double
            Get
                Return _s90
            End Get
            Set(ByVal value As System.Double)
                _s90 = value
            End Set
        End Property

        Public Property s91() As System.Double
            Get
                Return _s91
            End Get
            Set(ByVal value As System.Double)
                _s91 = value
            End Set
        End Property

        Public Property s92() As System.Double
            Get
                Return _s92
            End Get
            Set(ByVal value As System.Double)
                _s92 = value
            End Set
        End Property

        Public Property s93() As System.Double
            Get
                Return _s93
            End Get
            Set(ByVal value As System.Double)
                _s93 = value
            End Set
        End Property

        Public Property s94() As System.Double
            Get
                Return _s94
            End Get
            Set(ByVal value As System.Double)
                _s94 = value
            End Set
        End Property

        Public Property s95() As System.Double
            Get
                Return _s95
            End Get
            Set(ByVal value As System.Double)
                _s95 = value
            End Set
        End Property

        Public Property s96() As System.Double
            Get
                Return _s96
            End Get
            Set(ByVal value As System.Double)
                _s96 = value
            End Set
        End Property

        Public Property s97() As System.Double
            Get
                Return _s97
            End Get
            Set(ByVal value As System.Double)
                _s97 = value
            End Set
        End Property

        Public Property s98() As System.Double
            Get
                Return _s98
            End Get
            Set(ByVal value As System.Double)
                _s98 = value
            End Set
        End Property

        Public Property s99() As System.Double
            Get
                Return _s99
            End Get
            Set(ByVal value As System.Double)
                _s99 = value
            End Set
        End Property

#End Region

        Public Shared Function GetSmartBooks_Salary(ByVal Salary_Month As System.Int32, ByVal Salary_Year As System.Int32, ByVal Employee_ID As System.String) As SmartBooks_Salary
            Return New SmartBooks_Salary(Salary_Month, Salary_Year, Employee_ID)
        End Function

        Public Shared Function GetSmartBooks_SalaryAll() As SmartBooks_Salary()
            Dim kn As New connect(DbSetting.dataPath)
            Dim table As DataTable = kn.ReadData("SELECT * FROM SmartBooks_Salary", "SmartBooks_Salary")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Salarys(table.Rows.Count - 1) As SmartBooks_Salary
                For Each dr As DataRow In table.Rows
                    SmartBooks_Salarys(i) = New SmartBooks_Salary(dr)
                    i += 1
                Next
                GetSmartBooks_SalaryAll = SmartBooks_Salarys
            End If
        End If
    End Function

    Public Shared Function GetSmartBooks_SalaryAllReturnDataTable() As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("SELECT * FROM SmartBooks_Salary", "SmartBooks_Salary")
        Return table
    End Function

    Public Shared Function GetSmartBooks_SalaryDynamic(ByVal WhereCondition As String, ByVal OrderByExpression As String) As SmartBooks_Salary()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
        Dim oj() As Object = {WhereCondition, OrderByExpression}
        Dim tp() As String = {"NVarChar", "NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSmartBooks_SalariesDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Salarys(table.Rows.Count - 1) As SmartBooks_Salary
                For Each dr As DataRow In table.Rows
                    SmartBooks_Salarys(i) = New SmartBooks_Salary(dr)
                    i += 1
                Next
                GetSmartBooks_SalaryDynamic = SmartBooks_Salarys
            End If
        End If
    End Function

    Public Shared Function GetSmartBooks_SalaryDynamicReturnDataTable(ByVal WhereCondition As String, ByVal OrderByExpression As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
        Dim oj() As Object = {WhereCondition, OrderByExpression}
        Dim tp() As String = {"NVarChar", "NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSmartBooks_SalariesDynamic", name, oj, tp)
        Return table
    End Function

    Public Shared Function GetSmartBooks_SalaryDynamic(ByVal WhereCondition As String) As SmartBooks_Salary()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSmartBooks_SalariesDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Salarys(table.Rows.Count - 1) As SmartBooks_Salary
                For Each dr As DataRow In table.Rows
                    SmartBooks_Salarys(i) = New SmartBooks_Salary(dr)
                    i += 1
                Next
                GetSmartBooks_SalaryDynamic = SmartBooks_Salarys
            End If
        End If
    End Function

    Public Shared Function GetSmartBooks_SalaryDynamicReturnDataTable(ByVal WhereCondition As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSmartBooks_SalariesDynamic", name, oj, tp)
        Return table
    End Function

    Public Shared Function GetSmartBooks_SalaryFullDynamic(ByVal sqlAfterSelectBeforeWhere As String, ByVal sqlAfterWhere As String) As SmartBooks_Salary()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select " + sqlAfterSelectBeforeWhere + " from SmartBooks_Salary where " + sqlAfterWhere, "SmartBooks_Salary")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Salarys(table.Rows.Count - 1) As SmartBooks_Salary
                For Each dr As DataRow In table.Rows
                    SmartBooks_Salarys(i) = New SmartBooks_Salary(dr)
                    i += 1
                Next
                GetSmartBooks_SalaryFullDynamic = SmartBooks_Salarys
            End If
        End If
    End Function

    Public Shared Function GetSmartBooks_SalaryFullDynamicReturnDataTable(ByVal sqlAfterSelectBeforeWhere As String, ByVal sqlAfterWhere As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select " + sqlAfterSelectBeforeWhere + " from SmartBooks_Salary where " + sqlAfterWhere, "SmartBooks_Salary")
        Return table
    End Function

    Public Shared Function DeleteSmartBooks_SalarysDynamic(ByVal WhereCondition As String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteSmartBooks_SalarysDynamic", name, oj, tp)
    End Function

    Public Shared Function SearchFromListFollowPrimaryKey(ByVal list() As SmartBooks_Salary, ByVal Salary_Month As System.Int32, ByVal Salary_Year As System.Int32, ByVal Employee_ID As System.String) As SmartBooks_Salary
        For Each SmartBooks_Salary1 As SmartBooks_Salary In list
            If SmartBooks_Salary1.Salary_Month = Salary_Month And SmartBooks_Salary1.Salary_Year = Salary_Year And SmartBooks_Salary1.Employee_ID = Employee_ID Then
                Return SmartBooks_Salary1
            End If
        Next
    End Function

    Public Shared Function SearchFromListFollowEmployee_ID(ByVal list() As SmartBooks_Salary, ByVal Employee_ID As System.String) As SmartBooks_Salary()
        Dim arl As New ArrayList
        For Each SmartBooks_Salary1 As SmartBooks_Salary In list
            If SmartBooks_Salary1.Employee_ID = Employee_ID Then
                arl.Add(SmartBooks_Salary1)
            End If
        Next
        Dim salary(arl.Count - 1) As SmartBooks_Salary
        For i As Integer = 0 To arl.Count - 1
            salary(i) = arl(i)
        Next
        Return salary
    End Function
End Class
#End Region