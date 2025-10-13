Imports Janus.Windows.GridEX
Imports System.IO
Imports DBA.Common
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports System.Globalization
Module MdlCRM
    Public Function ChangeCond(ByVal OldCond As String, ByVal cbo As Janus.Windows.EditControls.UIComboBox) As String
        Dim kq As String = ""
        Dim tam As String
        Dim chuoiChange As String
        Dim flag As Integer = 1
        tam = Trim(OldCond)
        For i As Integer = 1 To Len(tam)
            If Mid(tam, i, 1) = "[" Then
                kq = kq + Mid(tam, flag, i - flag)
                For j As Integer = i + 1 To Len(tam)
                    If Mid(tam, j, 1) = "]" Then
                        kq = kq + cbo.Items(Mid(tam, i + 1, j - i - 1)).Value
                        i = j
                        flag = j + 1
                        Exit For
                    End If
                Next
            End If
            If Mid(tam, i, 1) = "#" Then
                kq = kq + Mid(tam, flag, i - flag)
                For j As Integer = i + 1 To Len(tam)
                    If Mid(tam, j, 1) = "#" Then
                        kq = kq + "convert(smalldatetime, '" + Mid(tam, i + 1, j - i - 1) + "', 103)"
                        i = j
                        flag = j + 1
                        Exit For
                    End If
                Next
            End If
        Next
        If flag = 1 Then
            kq = OldCond
        Else
            kq = kq + Mid(tam, flag, Len(tam))
        End If
        Return kq
    End Function
    'SplitStreet: 1-street 0-Address
    Public Function SplitStreet(ByVal StreetName As String, ByVal lg As Integer) As String
        Dim j As Integer
        Dim tent As String
        tent = Trim(StreetName)
        For j = Len(tent) To 1 Step -1
            If Mid(tent, j, 1) = "," Then
                If lg = "1" Then
                    Return Right(tent, Len(tent) - j)
                Else
                    Return Left(tent, j)
                End If
                Exit For
            End If
        Next
    End Function
    'SplitName: 1-Ten 0-Ho
    Public Function SplitName(ByVal Name As String, ByVal lg As Integer) As String
        Dim j As Integer
        Dim tent As String
        tent = Trim(Name)
        For j = Len(tent) To 1 Step -1
            If Mid(tent, j, 1) = " " Then
                If lg = "1" Then
                    Return Right(tent, Len(tent) - j)
                Else
                    Return Left(tent, j)
                End If
                Exit For
            End If
        Next
    End Function
    Public Function TestEditPer(ByVal strMenuName As String) As Boolean
        If s_UserID = "admin" Then
            Return True
        End If
        If Not TestExistData("Select * From UMS_tblUserPermission Where MenuID='" & strMenuName & "' and UserGroupID = '" & s_UserID & "'") Then
            If TestExistData("Select * From UMS_tblUserPermission Where FEdit = '1' and MenuID='" & strMenuName & "' and UserGroupID = '" & s_UserGroup & "'") Then
                Return True
            Else
                Return False
            End If
            Exit Function
        End If

        If TestExistData("Select * From UMS_tblUserPermission Where FEdit = '1' and MenuID='" & strMenuName & "' and UserGroupID = '" & s_UserID & "'") Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function TestDelPer(ByVal strMenuName As String) As Boolean
        If s_UserID = "admin" Then
            Return True
        End If
        If Not TestExistData("Select * From UMS_tblUserPermission Where MenuID='" & strMenuName & "' and UserGroupID = '" & s_UserID & "'") Then
            If TestExistData("Select * From UMS_tblUserPermission Where FDel = '1' and MenuID='" & strMenuName & "' and UserGroupID = '" & s_UserGroup & "'") Then
                Return True
            Else
                Return False
            End If
            Exit Function
        End If

        If TestExistData("Select * From UMS_tblUserPermission Where FDel = '1' and MenuID='" & strMenuName & "' and UserGroupID = '" & s_UserID & "'") Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function ShowReport(ByVal RptCode As String, ByVal rptFileName As String, Optional ByVal Field01 As String = "", _
        Optional ByVal Field02 As String = "", Optional ByVal Field03 As String = "", _
        Optional ByVal Field04 As String = "", Optional ByVal Field05 As String = "", _
        Optional ByVal Field06 As String = "", Optional ByVal Field07 As Int16 = 0, Optional ByVal Field08 As Int16 = 0) As Boolean
        Dim RI_ID As Int16
        Dim SQL As String, s_ProcBef As String, s_ProcAff As String
        Dim sRptDescr As String
        Dim cr As New ReportDocument
        Dim f As New frmPrintReport
        Dim obj As New clsRptControl(mDAL)
        Dim objRt As New clsRptRuntime(mDAL)



        If Not obj.GetByKey(RptCode) Then
            MsgBox("Report code này không tồn tại.")
            Exit Function
        Else
            With obj
                sRptDescr = .RptDescr
                s_ProcAff = .ProcAff
                s_ProcBef = .ProcBef
            End With
        End If

        'Thuc thu Bef Procedure
        With objRt
            RI_ID = .GetMaxRI_IDByKey(RptCode, Environment.MachineName)
            RI_ID = RI_ID + 1

            .Field01 = Field01
            .Field02 = Field02
            .Field03 = Field03
            .Field04 = Field04
            .Field05 = Field05
            .Field06 = Field06
            .Field07 = Field07
            .Field08 = Field08
            .ReportDate = Now
            .ReportTitle = sRptDescr
            .RI_ID = RI_ID
            .RptCode = RptCode
            .RptDescr = sRptDescr
            .Perpost = s_Perpost
            .BegPerNbr = s_Perpost
            .EndPerNbr = s_Perpost
            .HostName = Environment.MachineName
            .Add()
        End With
        If s_ProcBef <> "" Then
            mDAL.ExecNonQuery(s_ProcBef, CommandType.Text)
        End If

        'Save Data

        'cr.Load(Application.StartupPath & "\REPORT\" & Trim(rptFileName) & ".rpt")
        cr.Load(s_Report & "\" & Trim(rptFileName) & ".rpt")




        Dim tbllginfo As New CrystalDecisions.Shared.TableLogOnInfo
        With tbllginfo.ConnectionInfo
            .DatabaseName = s_CnnDataBase
            .Password = s_CnnPassword
            .ServerName = s_CnnServer
            .UserID = s_CnnUserID
        End With



        With f.crpReport
            cr.Database.Tables.Item(0).ApplyLogOnInfo(tbllginfo)

            .ReportSource = cr
        End With

        f.Text = sRptDescr
        f.RptCode = RptCode
        f.ProcAff = s_ProcAff
        f.Show()
    End Function
    'Viet created 15/11/2008
    Public Sub Message(ByVal text As String)
        Dim f As New frmMsgBox
        f.lblText.Text = IIf(text = "", "Thao tác dữ liệu đã xong.", text)
        f.MdiParent = MDI.ActiveForm
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
    End Sub
    Public Function IsFormOpen(ByVal MDI As Form, ByVal Formname As String, Optional ByVal AccessibleDescription As String = vbNullString) As Form

        Dim x As Integer
        For x = 0 To MDI.MdiChildren.Length - 1
            If MDI.MdiChildren(x).Name = Formname Then
                IsFormOpen = MDI.MdiChildren(x)
                Exit Function
            End If
        Next

        'Dim x As Integer
        'If AccessibleDescription = vbNullString Then
        '    For x = 0 To MDI.MdiChildren.Length - 1
        '        If MDI.MdiChildren(x).Name = Formname Then
        '            IsFormOpen = MDI.MdiChildren(x)
        '            Exit Function
        '        End If
        '    Next
        'Else
        '    For x = 0 To MDI.MdiChildren.Length - 1
        '        If MDI.MdiChildren(x).Name = Formname And MDI.MdiChildren(x).AccessibleDescription = AccessibleDescription Then
        '            IsFormOpen = MDI.MdiChildren(x)
        '            Exit Function
        '        End If
        '    Next
        'End If
    End Function

    '========================================================================================================================
    '--Người tạo: TAMTM
    '--Ngày tạo: 27/05/2005
    '--Mục đích: Định dạng lưới
    '========================================================================================================================

    Public Sub FormatGridEX(ByVal pGrid As Janus.Windows.GridEX.GridEX, _
                                ByVal pStrHeader() As String, ByVal pStrField() As String, _
                                ByVal pStrWidth() As Int16, ByVal pStrFormat() As String)

        Dim i As Integer
        Dim Var_Field As String
        Dim VarFormat As String
        With pGrid
            .RootTable.Columns.Clear()
            .SelectionMode = SelectionMode.MultipleSelection
            .RootTable.ColumnHeaders = InheritableBoolean.True
            .RootTable.RepeatHeaders = InheritableBoolean.True
            .EnterKeyBehavior = EnterKeyBehavior.NextCell
            .AllowColumnDrag = False
            .EmptyRows = False
            i = 0

            If i <> pStrField.Length - 1 Then
                For Each Var_Field In pStrField
                    pGrid.RootTable.Columns.Add(pStrField(i))
                    pGrid.RootTable.Columns(i).Key = Var_Field
                    pGrid.RootTable.Columns(i).DataMember = Var_Field
                    pGrid.RootTable.Columns(i).Caption = pStrHeader(i)
                    pGrid.RootTable.Columns(i).Tag = pStrFormat(i)

                    If pStrFormat(i) <> vbNullString And pStrFormat(i) <> "D" Then
                        pGrid.RootTable.Columns(i).TextAlignment = TextAlignment.Far
                    End If

                    If pStrWidth(i) = 0 Then
                        pGrid.RootTable.Columns(i).Visible = False
                    Else
                        pGrid.RootTable.Columns(i).Width = pStrWidth(i)
                    End If

                    pGrid.RootTable.Columns(i).HeaderAlignment = TextAlignment.Center
                    i += 1
                Next
            End If
            pGrid.FocusCellFormatStyle.ForeColor = Color.Red
            pGrid.SelectedFormatStyle.ForeColor = Color.White
            pGrid.FocusCellFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True
            pGrid.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True
            'pGrid.FocusCellFormatStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(sApp_GridHighlightBackColor)
            'pGrid.SelectedFormatStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(sApp_GridHighlightBackColor) 'RGB(0, 20, 100))
            pGrid.SelectedFormatStyle.BackColor = Color.FromKnownColor(KnownColor.Highlight)   'System.Drawing.ColorTranslator.FromWin32(sApp_GridHighlightBackColor)
        End With
        pGrid = Nothing

    End Sub

    '========================================================================================================================
    '--Người tạo: TAMTM
    '--Ngày tạo: 27/05/2005
    '--Mục đích: Định dạng lưới
    '========================================================================================================================

    Public Sub FormatGridEX(ByVal pGrid As Janus.Windows.GridEX.GridEX)
        Dim i As Integer

        With pGrid
            .RootTable.ColumnHeaders = InheritableBoolean.True
            .RootTable.RepeatHeaders = InheritableBoolean.True
            .EnterKeyBehavior = EnterKeyBehavior.NextCell
            .EmptyRows = False
            For i = 0 To pGrid.RootTable.Columns.Count - 1
                pGrid.RootTable.Columns(i).HeaderAlignment = TextAlignment.Center
            Next

            pGrid.FocusCellFormatStyle.ForeColor = Color.Red
            pGrid.SelectedFormatStyle.ForeColor = Color.White
            pGrid.FocusCellFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True
            pGrid.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True
            'pGrid.FocusCellFormatStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(sApp_GridHighlightBackColor)
            'pGrid.SelectedFormatStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(sApp_GridHighlightBackColor) 'RGB(0, 20, 100))
            pGrid.SelectedFormatStyle.BackColor = Color.FromKnownColor(KnownColor.Highlight)
        End With
        pGrid = Nothing
    End Sub

    '========================================================================================================================
    '--Người tạo: TAMTM
    '--Ngày tạo: 20/9/2005
    '--Mục đích: Kiểm tra sự trùng lắp dữ liệu trên lưới, 1 chứng từ chỉ được xuất hiện 1 lần trên lưới
    '--Chưa hoàn chỉnh, đang nâng cấp và sữa chữa
    '--pRefID la gia tri can kiểm tra sự trùng lắp
    '========================================================================================================================

    Function CheckDuplicateOnGrid(ByVal Grid As Janus.Windows.GridEX.GridEX, ByVal pTable As DataTable, ByVal pColID As String) As Boolean
        Dim i As Integer
        Dim j As Integer
        Dim mRef_I As String
        Dim mRef_J As String
        CheckDuplicateOnGrid = False
        With Grid
            .Row = 0
            .Focus()
            If clsCommon.GetValue(.GetValue(pColID), GetType(String).FullName) <> vbNullString Then
                mRef_I = .GetValue(pColID)
                If mRef_I = vbNullString Then Exit Function
                If Grid.RowCount = 1 Then Exit Function
                For i = 0 To pTable.Rows.Count - 2
                    .Row = i
                    .Focus()
                    mRef_I = .GetValue(pColID)
                    For j = i + 1 To pTable.Rows.Count - 1
                        .Row = j
                        .Focus()
                        mRef_J = IIf(clsCommon.GetValue(.GetValue(pColID), GetType(String).FullName) <> vbNullString, .GetValue(pColID), "")
                        If mRef_I = mRef_J And mRef_I <> "" Then
                            .Col = .RootTable.Columns(pColID).Index
                            CheckDuplicateOnGrid = True
                            Exit Function
                        End If
                    Next
                Next
            End If
        End With
    End Function

    '========================================================================================================================
    '--Người tạo: TAMTM
    '--Ngày tạo: 20/9/2005
    '--Mục đích: Kiểm tra sự trùng lắp dữ liệu trên lưới, 1 chứng từ chỉ được xuất hiện 1 lần trên lưới
    '--Chưa hoàn chỉnh, đang nâng cấp và sữa chữa
    '--pRefID la gia tri can kiểm tra sự trùng lắp
    '========================================================================================================================

    Function CheckDuplicateOnGrid(ByVal Grid As Janus.Windows.GridEX.GridEX, ByVal pColID As String) As Boolean
        Dim i As Integer
        Dim j As Integer
        Dim mRef_I As String
        Dim mRef_J As String
        CheckDuplicateOnGrid = False
        With Grid
            .Row = 0
            .Focus()
            mRef_I = UCase(.GetValue(pColID))
            If mRef_I = vbNullString Then Exit Function
            If Grid.RowCount = 1 Then Exit Function
            For i = 0 To Grid.RecordCount - 2
                .Row = i
                .Focus()
                mRef_J = UCase(.GetValue(pColID))
                For j = i + 1 To Grid.RecordCount - 1
                    .Row = j
                    .Focus()
                    mRef_J = UCase(.GetValue(pColID))
                    If mRef_I = mRef_J And mRef_I <> "" Then
                        .Col = .RootTable.Columns(pColID).Index
                        CheckDuplicateOnGrid = True
                        Exit Function
                    End If
                Next
                'mRef_I = UCase(.GetValue(pColID))
            Next
        End With
    End Function

    Public Function TestExistData(ByVal SQL As String) As Boolean

        Dim dt As New DataTable
        Try
            dt = mDAL.ExecDataTable(SQL, CommandType.Text)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return False
    End Function

    Public Function LoadMsg(ByVal MsgCode As String, Optional ByVal Ascx As String = "") As String
        Dim dt As New DataTable

        Dim SQL As String = "Select * From Message Where MessCode='" & MsgCode & "'"
        If Ascx <> "" Then
            SQL = SQL & " And ascx='" & Ascx & "'"
        End If
        Try
            dt = mDAL.ExecDataTable(SQL, CommandType.Text)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0).Item("VN")
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return False
    End Function

    'TAMTM Date 02/12/2005
    'Note : Kiểm tra xem số đó có âm ko. Nếu âm thì trả về True và bắt nhập lại.
    'ptext la caption cua doi tuong truyen vao
    Public Function CheckNegative(ByVal pNuberic As Double, ByVal pText As String) As Boolean
        If pNuberic < 0 Then
            MessageBox.Show(pText & " không được nhập giá trị âm. Vui lòng nhập lại.", s_Title_Infor, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        Else
            Return False
        End If
    End Function
    'TAMTM Date 25/10/2005
    'Note : Gan mDataChange cua Form = True khi co sự thay đổi trên Control
    Public Sub TextChangeControl(ByVal parentct As Control)
        Dim ct As Control
        If parentct.GetType.Name = "EditBox" Or parentct.GetType.Name = "NumericEdit" _
         Or parentct.GetType.Name = "CalendarCombo" Or parentct.GetType.Name = "UICheckBox" _
         Or parentct.GetType.Name = "UIComboBox" Then
            AddHandler parentct.TextChanged, AddressOf TextChange
        End If

        If parentct.GetType.Name = "CalendarCombo" Then
            AddHandler CType(parentct, Janus.Windows.CalendarCombo.CalendarCombo).ValueChanged, AddressOf TextChange
        End If

        If parentct.GetType.Name = "UICheckBox" Then
            AddHandler CType(parentct, Janus.Windows.EditControls.UICheckBox).CheckedChanged, AddressOf TextChange
        End If

        If parentct.GetType.Name = "UIComboBox" Then
            AddHandler CType(parentct, Janus.Windows.EditControls.UIComboBox).SelectedValueChanged, AddressOf TextChange
        End If

        If parentct.Controls.Count = 0 Then Exit Sub
        For Each ct In parentct.Controls
            TextChangeControl(ct)
        Next
    End Sub

    'TAMTM Date 25/10/2005
    'Note : Tô màu khi di chuyển chuột đến Control
    Public Sub ColorControl(ByVal parentct As Control)
        Dim ct As Control
        If parentct.GetType.Name = "EditBox" Or parentct.GetType.Name = "UIComboBox" Or parentct.GetType.Name = "NumericEdit" Or _
           parentct.GetType.Name = "CalendarCombo" Then
            AddHandler parentct.Enter, AddressOf EnterTextbox
            AddHandler parentct.Leave, AddressOf LeaveTextbox
        End If
        If parentct.Controls.Count = 0 Then Exit Sub
        For Each ct In parentct.Controls
            ColorControl(ct)
        Next
    End Sub

    Public Sub FormatForm(ByVal F As System.Windows.Forms.Form)
        Dim Ctrl As Object
        Dim mHover As New HoverMode
        Dim mFieldInfo() As Reflection.FieldInfo
        Dim mRequireColor As Color = Color.FromKnownColor(KnownColor.Info)

        If File.Exists(Application.StartupPath & "\Icon.ico") Then
            F.Icon = New System.Drawing.Icon(Application.StartupPath & "\Icon.ico")
        End If

        F.KeyPreview = True
        F.FormBorderStyle = FormBorderStyle.FixedSingle
        F.StartPosition = FormStartPosition.CenterScreen
        F.Font = New Drawing.Font(s_SystemFont, F.Font.Size)
        mFieldInfo = F.GetType.GetFields(Reflection.BindingFlags.Instance Or Reflection.BindingFlags.Public Or Reflection.BindingFlags.NonPublic)

        For i As Integer = 0 To mFieldInfo.Length - 1
            Ctrl = mFieldInfo(i).GetValue(F)
            If TypeOf (Ctrl) Is Janus.Windows.GridEX.EditControls.NumericEditBox Then
                FormatTextNum(Ctrl)
            ElseIf TypeOf (Ctrl) Is Janus.Windows.CalendarCombo.CalendarCombo Then
                FormatDateTime(Ctrl)
            ElseIf TypeOf (Ctrl) Is Janus.Windows.GridEX.GridEX Then
                FormatGridNum(Ctrl)
            End If
        Next
    End Sub

    Public Sub ClearDataCtrl(ByVal F As System.Windows.Forms.Form, Optional ByVal StrName() As String = Nothing)

        Dim Ctrl As Object
        Dim mFieldInfo() As Reflection.FieldInfo
        mFieldInfo = F.GetType.GetFields(Reflection.BindingFlags.Instance Or Reflection.BindingFlags.Public Or Reflection.BindingFlags.NonPublic)
        Try
            For i As Integer = 0 To mFieldInfo.Length - 1
                If Not StrName Is Nothing Then
                    If StrName.IndexOf(StrName, Strings.Right(mFieldInfo(i).Name, Len(mFieldInfo(i).Name) - 1)) >= 0 Then
                        'co trong danh sach 
                        GetNetControl(StrName, F, F.ActiveControl)
                    Else
                        Ctrl = mFieldInfo(i).GetValue(F)
                        ClearDataCtrl(Ctrl)
                    End If
                Else
                    Ctrl = mFieldInfo(i).GetValue(F)
                    ClearDataCtrl(Ctrl)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearDataCtrl(ByVal ctrl As Object)

        If TypeOf (ctrl) Is Janus.Windows.GridEX.EditControls.EditBox Then
            CType(ctrl, Janus.Windows.GridEX.EditControls.EditBox).Text = ""
        ElseIf TypeOf (ctrl) Is System.Windows.Forms.RichTextBox Then
            CType(ctrl, System.Windows.Forms.RichTextBox).Text = ""
        ElseIf TypeOf (ctrl) Is Janus.Windows.EditControls.UICheckBox Then
            CType(ctrl, Janus.Windows.EditControls.UICheckBox).Checked = False
        ElseIf TypeOf (ctrl) Is Janus.Windows.CalendarCombo.CalendarCombo Then
            CType(ctrl, Janus.Windows.CalendarCombo.CalendarCombo).Value = Now
        ElseIf TypeOf (ctrl) Is Janus.Windows.EditControls.UIComboBox Then
            CType(ctrl, Janus.Windows.EditControls.UIComboBox).SelectedValue = vbNullString
            CType(ctrl, Janus.Windows.EditControls.UIComboBox).Text = vbNullString
        ElseIf TypeOf (ctrl) Is Janus.Windows.GridEX.EditControls.MultiColumnCombo Then
            CType(ctrl, Janus.Windows.GridEX.EditControls.MultiColumnCombo).Value = vbNullString
            CType(ctrl, Janus.Windows.GridEX.EditControls.MultiColumnCombo).Text = vbNullString
        ElseIf TypeOf (ctrl) Is Janus.Windows.GridEX.EditControls.NumericEditBox Then
            CType(ctrl, Janus.Windows.GridEX.EditControls.NumericEditBox).Text = 0
        ElseIf TypeOf (ctrl) Is Janus.Windows.CalendarCombo.CalendarCombo Then
            FormatDateTime(ctrl)
        ElseIf TypeOf (ctrl) Is Janus.Windows.GridEX.GridEX Then
            FormatGridNum(ctrl)
        End If
    End Sub

    Public Sub GetNetControl(ByVal StrName() As String, ByVal fr As Form, ByVal ctr As Control)
        Try
            Dim obj As Control
            obj = fr.GetNextControl(ctr, True)
            If obj.TabStop = False Or StrName.IndexOf(StrName, obj.Name) >= 0 Then
                GetNetControl(StrName, fr, obj)
            Else
                obj.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub KeyDownForm(ByVal Form As System.Windows.Forms.Form, ByRef m As System.Windows.Forms.Message, Optional ByVal StrName() As String = Nothing)
        Try

            Dim ctrl As Object
            Dim tapindex As Boolean
            Dim WM_KEYDOWN As Integer = &H100
            If m.Msg = WM_KEYDOWN Then
                If m.WParam.ToInt32 = Keys.Enter Then
                    If TypeOf Form.ActiveControl.Parent Is Janus.Windows.GridEX.GridEX Or _
                             TypeOf Form.ActiveControl Is Janus.Windows.GridEX.GridEX Then
                        Exit Sub
                    End If
                    If Form.ActiveControl.GetType.Name = "T" Then
                        If TypeOf Form.ActiveControl.Parent Is Janus.Windows.EditControls.UIComboBox Then
                            ctrl = Form.ActiveControl.Parent
                            If TypeOf ctrl.Parent Is Janus.Windows.GridEX.GridEX Then Exit Sub
                            If ctrl.DroppedDown = False And ctrl.ReadOnly = False Then
                                tapindex = False
                                ctrl.OpenCombo()
                                Exit Sub
                            End If
                        End If
                    End If
                    If StrName Is Nothing Then
                        SendKeys.Send("{TAB}")
                    Else
                        ' TabIndex dung de chan khi enter vao com bo thi su kien nay xay ra hai lan
                        If tapindex = False And StrName.IndexOf(StrName, Form.GetNextControl(Form.ActiveControl, True).Name) >= 0 Then
                            'co trong danh sach 
                            If Form.ActiveControl.GetType.Name = "T" Then tapindex = True
                            GetNetControl(StrName, Form, Form.ActiveControl)
                        ElseIf tapindex = True Then 'Luc su kien Enter vao combo lan thu nhat say ra
                            tapindex = False
                        Else
                            SendKeys.Send("{TAB}") 'Enter qua cac control khong nam trong danh sach StrName
                        End If
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Function ShowF3Form(ByVal FormName As Form, ByVal PVID As String, ByVal sReceive As String, Optional ByVal IsCheck As Boolean = False) As String
        Dim f As New F3
        f.PVID = PVID
        f.mForm = FormName
        f.sValReceive = sReceive
        f.IsCheck = IsCheck
        f.ReturnType = False
        f.ShowDialog()
        Return f.sValReturn
    End Function

    Public Function ShowF3Form(ByVal FormName As Form, ByVal PVID As String, ByVal sReceive As String, ByVal ReturnType As Integer) As DataRow
        Dim f As New F3
        f.PVID = PVID
        f.mForm = FormName
        f.sValReceive = sReceive
        f.IsCheck = False
        f.ReturnType = True
        f.ShowDialog()
        Return f.ReturnRow
    End Function
    Public Function ShowF3Form(ByVal FormName As Form, ByVal PVID As String, ByVal sReceive As String, ByVal ReturnType As Integer, ByVal ischeck As Boolean) As DataTable
        Dim f As New F3
        f.PVID = PVID
        f.mForm = FormName
        f.sValReceive = sReceive
        f.IsCheck = True
        f.ReturnType = True
        f.ShowDialog()
        Return f.ReturnTable
    End Function

    Public Function GetAutoID(ByVal Table As String) As String
        Dim dt As New DataTable
        Dim str As String
        Try

            dt = mDAL.ExecDataTable("exec usp_GetAutoID '" & Table & "'", CommandType.Text)
            If dt Is Nothing Then
                Return "0000"
            End If
            If dt.Rows.Count > 0 Then
                str = IIf(IsDBNull(dt.Rows(0).Item("ID")), "0000", dt.Rows(0).Item("ID"))
                Return str
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return False
    End Function

    Public Function DeleteRpRuntime(ByVal HostName As String)
        Dim obj As New clsRptRuntime(mDAL)
        obj.Delete(HostName)
    End Function

    Public Function GetDescrName(ByVal Table As String, ByVal Cond As String, ByVal DescrField As String) As String
        Dim str As String
        Try
            Dim dt As New DataTable
            Dim SQL As String = "Select * From " & Table & " Where " & Cond & ""
            dt = mDAL.ExecDataTable(SQL, CommandType.Text)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0).Item(DescrField)
            End If
        Catch ex As Exception
            MsgBox(s_Msg_SysError & vbCrLf & ex.Message, MsgBoxStyle.OkOnly, s_Title_Infor)
            Return ""
        End Try
    End Function


#Region "Tạo Column có số thứ tự tăng tự động"
    ' Comments: Phải có Column "No" trong cau SQL select
    Public Sub dTableMaster_RowDeleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        dTableMaster_RowChanged(sender, e)
    End Sub

    Public Sub dTableMaster_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        Static Dim blnExec As Boolean = True
        Try
            If blnExec Then
                If Not (e.Action = DataRowAction.Add OrElse e.Action = DataRowAction.Delete) Then
                    Return
                End If
                blnExec = False
                Dim i As Int32 = 1
                Dim row As DataRow
                If Not sender.GetChanges(DataRowState.Added Or DataRowState.Modified Or DataRowState.Unchanged) Is Nothing Then
                    For Each row In sender.Rows
                        If row.RowState = DataRowState.Added _
                         OrElse row.RowState = DataRowState.Modified _
                         OrElse row.RowState = DataRowState.Unchanged Then

                            row("No") = i
                            i += 1
                        End If

                    Next
                End If

                If e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Added Then
                    e.Row("No") = i
                End If

                blnExec = True
            End If
        Catch ex As Exception
            blnExec = True
        End Try
    End Sub

#End Region

#Region "Private"
    Private Function StrFormatDec(ByVal strKey As Integer) As String
        Dim st As String = ""
        Dim i As Integer

        If strKey > 0 Then
            st = st & "."
        End If
        For i = 0 To strKey - 1
            st = st & "0"
        Next
        Return st
    End Function

    Private Function StrFormatFrom(ByVal mChar As Char) As String
        Dim st As String
        Dim mst As String = "###,###,###,###,###,###,###,##0"
        If mChar = Nothing Then Exit Function
        Select Case mChar
            Case "Q" 'Số lượng 3 số lẻ
                st = mst & StrFormatDec(S_FormatQty)
            Case "T" 'Tiền việt 2 số lẻ
                st = mst & StrFormatDec(S_FormatTran)
            Case "C" 'Tiền 3 số lẻ
                st = mst & StrFormatDec(S_FormatCurr)
            Case "D" 'Ngày
                st = S_FormatDate
        End Select
        Return st

    End Function

    Private Sub FormatTextNum(ByVal mControl As Janus.Windows.GridEX.EditControls.NumericEditBox)
        Dim mChar As Char
        mChar = mChar.ToUpper(mControl.Tag)
        If mChar = Nothing Then Exit Sub
        mControl.FormatString = StrFormatFrom(mChar)
    End Sub

    Private Sub FormatDateTime(ByVal mControl As Janus.Windows.CalendarCombo.CalendarCombo)
        Dim mChar As Char
        mChar = mChar.ToUpper(mControl.Tag)
        If mChar = Nothing Then Exit Sub
        mControl.CustomFormat = StrFormatFrom(mChar)
        mControl.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom
        mControl.Value = Now
    End Sub

    Private Sub FormatGridNum(ByVal Grid As Janus.Windows.GridEX.GridEX)
        Dim mChar As Char
        Dim icol As Integer
        Try
            For icol = 0 To Grid.RootTable.Columns.Count - 1
                mChar = mChar.ToUpper(Grid.RootTable.Columns(icol).Tag)
                Grid.RootTable.Columns(icol).FormatString = StrFormatFrom(mChar)
                If mChar <> "D" And mChar <> vbNullString Then
                    If mChar = "Q" Then
                        Grid.RootTable.Columns(icol).MaxLength = 9
                    ElseIf mChar = "U" Or mChar = "B" Or mChar = "F" Then
                        Grid.RootTable.Columns(icol).MaxLength = 12
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextChange(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim obj As Object
        Select Case sender.GetType.Name
            Case "EditBox"
                obj = CType(sender, Janus.Windows.GridEX.EditControls.EditBox).FindForm()
            Case "NumericEdit"
                obj = CType(sender, Janus.Windows.GridEX.EditControls.NumericEdit).FindForm
            Case "CalendarCombo"
                obj = CType(sender, Janus.Windows.CalendarCombo.CalendarCombo).FindForm
            Case "UICheckBox"
                obj = CType(sender, Janus.Windows.EditControls.UICheckBox).FindForm
            Case "UIComboBox"
                obj = CType(sender, Janus.Windows.EditControls.UIComboBox).FindForm
        End Select
        ' Duy Edit 04052009
        'obj.mDataChange = True
    End Sub

    Private Sub EnterTextbox(ByVal sender As Object, ByVal e As System.EventArgs)
        setGotFocusColor(sender)
    End Sub

    Private Sub LeaveTextbox(ByVal sender As Object, ByVal e As System.EventArgs)
        setLostFocusColor(sender)
    End Sub

    Private Sub setGotFocusColor(ByVal ctrl As Object)
        ctrl.BackColor = System.Drawing.ColorTranslator.FromWin32(GotFocusColor)
    End Sub

    Private Sub setLostFocusColor(ByVal ctrl As Object)
        ctrl.BackColor = System.Drawing.ColorTranslator.FromWin32(LostFocusColor)
    End Sub

#End Region

    Public Sub ExportExcel(ByVal objFa As Janus.Windows.GridEX.GridEX)
        Dim objExcel As New Object
        Dim objBook As Object
        Dim objSheet As Object
        Dim ColDl As Integer
        Dim row1 As Integer
        Dim row2 As Integer = 0
        Dim row3 As Integer = 0
        Dim strTmp As String = 0
        Dim StrCulture As String = ""
        Dim iSSetCulture As Boolean = False
        Dim objCol As Janus.Windows.GridEX.GridEXColumn
        Dim IFields As Integer = 0
        Try
            StrCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Name
            If System.Threading.Thread.CurrentThread.CurrentCulture.Name <> "en-US" Then
                Dim myCI As New CultureInfo("en-US", True)
                System.Threading.Thread.CurrentThread.CurrentCulture = myCI
                iSSetCulture = True
            End If

            objExcel = CreateObject("Excel.Application")
            objBook = objExcel.Workbooks.Add
            objSheet = objBook.Worksheets(1)

            With objFa
                row1 = 0
                ColDl = 1
                row2 = 1

                For Each objCol In .RootTable.Columns
                    If objCol.Visible And objCol.Position > -1 Then
                        objSheet.cells(row2, objCol.Position + 1).Value() = objCol.Caption
                        IFields += 1
                    End If
                    ColDl += 1
                Next

                row2 = 2
                Dim CheckedRows() As Janus.Windows.GridEX.GridEXRow
                CheckedRows = objFa.GetCheckedRows()
                If CheckedRows.Length = 0 Then
                    For row1 = 0 To objFa.RowCount - 1
                        objFa.Row = row1
                        For Each objCol In objFa.RootTable.Columns
                            If objCol.Visible And objCol.Position > -1 Then
                                If objCol.DataMember = "EmpCode" Or objCol.DataMember = "Phone" Or objCol.DataMember = "HandPhone" Then
                                    objSheet.cells(row2, objCol.Position + 1).Value() = "'" & objFa.GetValue(objCol.Position)
                                Else
                                    objSheet.cells(row2, objCol.Position + 1).Value() = objFa.GetValue(objCol.Position)
                                End If
                                ColDl += 1
                            End If
                        Next
                        row2 += 1
                    Next
                Else
                    Dim row As Janus.Windows.GridEX.GridEXRow
                    mDAL.BeginTrans(IsolationLevel.ReadCommitted)
                    For Each row In CheckedRows
                        'For row1 = 0 To Fa.RowCount - 1
                        'Fa.Row = row1
                        For Each objCol In objFa.RootTable.Columns
                            If objCol.Visible And objCol.Position > -1 Then
                                If objCol.DataMember = "EmpCode" Or objCol.DataMember = "Phone" Or objCol.DataMember = "HandPhone" Then
                                    objSheet.cells(row2, objCol.Position + 1).Value() = "'" & row.Cells(objCol.DataMember.ToString).Value
                                Else
                                    objSheet.cells(row2, objCol.Position + 1).Value() = row.Cells(objCol.DataMember.ToString).Value
                                End If
                                ColDl += 1
                            End If
                        Next
                        row2 += 1
                    Next
                    mDAL.CommitTrans()
                End If
                strTmp = "A1:" & Chr(65 + IFields) & "1"
                objSheet.range("A1:AZ1").Font.Bold = True
                strTmp = "A1:" & Chr(65 + IFields) & row2
                objExcel.Columns("A:AJ").EntireColumn.AutoFit()
                objExcel.Columns("A:AJ").Font.Name = objFa.Font.Name
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
Exe:
        'Clear everything so you can display it to the user 
        objExcel.Visible = True
        objSheet = Nothing
        objBook = Nothing
        objExcel = Nothing

        If iSSetCulture Then
            Dim myCI As New CultureInfo(StrCulture, True)
            System.Threading.Thread.CurrentThread.CurrentCulture = myCI
        End If

    End Sub
    Public Function ImportData(ByVal FileName As String) As DataTable
        Dim odbDA As OleDb.OleDbDataAdapter
        Dim odbCnn As OleDb.OleDbConnection
        Dim odbCmd As OleDb.OleDbCommand
        Dim dtTable As DataTable

        Try
            odbCnn = New OleDb.OleDbConnection
            odbCnn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" _
             & "Data Source=" & FileName & ";" _
             & "Extended Properties=""Excel 8.0; HDR=Yes"";"
            odbCnn.Open()

            odbCmd = New OleDb.OleDbCommand
            odbCmd.CommandText = "SELECT * FROM [Sheet1$]"
            odbCmd.Connection = odbCnn

            odbDA = New OleDb.OleDbDataAdapter
            odbDA.SelectCommand = odbCmd

            dtTable = New DataTable
            dtTable.Columns.Add(New DataColumn("ProvID", GetType(String)))
            dtTable.Columns.Add(New DataColumn("Nbr", GetType(String)))
            dtTable.Columns.Add(New DataColumn("AttDate", GetType(String)))
            dtTable.Columns.Add(New DataColumn("Item", GetType(String)))
            dtTable.Columns.Add(New DataColumn("ItemName", GetType(String)))
            dtTable.Columns.Add(New DataColumn("Store", GetType(String)))
            dtTable.Columns.Add(New DataColumn("Unit", GetType(String)))
            dtTable.Columns.Add(New DataColumn("Quantity", GetType(Decimal)))
            dtTable.Columns.Add(New DataColumn("UnitPrice", GetType(Decimal)))
            dtTable.Columns.Add(New DataColumn("Amount", GetType(Decimal)))
            dtTable.Columns.Add(New DataColumn("RONbr", GetType(String)))
            dtTable.Columns.Add(New DataColumn("AcctCredit", GetType(String)))
            dtTable.Columns.Add(New DataColumn("AcctDebit", GetType(String)))
            dtTable.Columns.Add(New DataColumn("Memo", GetType(String)))
            odbDA.Fill(dtTable)

            Return dtTable
        Catch ex As Exception
            Return dtTable
            Throw ex
        End Try
    End Function
End Module
