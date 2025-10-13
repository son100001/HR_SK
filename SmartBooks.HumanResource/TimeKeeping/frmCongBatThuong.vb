Imports WindowsControlLibrary
 
Imports VBReport
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.IO
Public Class frmCongBatThuong
    Dim tabAccessTime, tabMaxOverTime As DataTable
    Private Sub LoadDetailInfor(ByVal LoadAccessTime As Boolean, ByVal LoadMaxOverTime As Boolean)
        If IsNothing(GridView3.GetFocusedDataRow) Then
            Exit Sub
        End If
        If IsNothing(GridView3.GetFocusedDataRow.Item("Employee_ID").ToString()) Then
            Exit Sub
        End If
        If CDate(GridView3.GetFocusedDataRow.Item("Ngay").ToString()).Year = 1 Then
            Exit Sub
        End If
        Dim strQuery As String
        If LoadAccessTime = True Then
            Dim fromdate, todate As DateTime
            fromdate = GridView3.GetFocusedDataRow.Item("Ngay").ToString()
            todate = GridView3.GetFocusedDataRow.Item("Ngay").ToString()
            If rdbAccessTimeThreeDay.Checked = True Then
                fromdate = fromdate.AddDays(-1)
                todate = todate.AddDays(1)
            ElseIf rdbAccessTimeInMonth.Checked = True Then
                fromdate = fromdate.AddDays(1 - fromdate.Day)
                todate = fromdate.AddMonths(1).AddDays(-1)
            End If
            strQuery = "select Employee_ID, AccessDate, cast(AccessTime as time(0)) as AccessTime,InOutStatus,InsertSource,ID from HR_TimeKeeping_Data where Employee_ID=N'" + GridView3.GetFocusedDataRow.Item("Employee_ID").ToString() + "' and AccessDate between '" + fromdate.ToString("yyyy-MM-dd") + "' and '" + todate.ToString("yyyy-MM-dd") + "' order by AccessDate, AccessTime asc"
            tvcn.Xem(strQuery, "", gridAccessTime, GridView1, tabAccessTime)
            GridView1.OptionsMenu.ShowAutoFilterRowItem = True
            GridView1.OptionsView.ShowAutoFilterRow = True
            GridView1.OptionsView.ShowGroupPanel = False
        End If
        If LoadMaxOverTime = True Then
            strQuery = "select Employee_ID,workingdate,maxovertime,TypeOfOT,ShiftName,NgayNghiBu,Remark,ID from HR_MaxOvertime where Employee_ID=N'" + GridView3.GetFocusedDataRow.Item("Employee_ID").ToString() + "' and workingdate='" + CDate(GridView3.GetFocusedDataRow.Item("Ngay").ToString()).ToString("yyyy-MM-dd") + "'"
            tvcn.Xem(strQuery, "", gridMaxOverTime, GridView2, tabMaxOverTime)
            GridView2.OptionsMenu.ShowAutoFilterRowItem = True
            GridView2.OptionsView.ShowAutoFilterRow = True
            GridView2.OptionsView.ShowGroupPanel = False
            'tvcn.DropDownInOut(gridMaxOverTime)
            'gridMaxOverTime.RowHeaders = InheritableBoolean.False
            'gridMaxOverTime.GroupByBoxVisible = False
            'gridMaxOverTime.FilterMode = False
        End If
    End Sub
    Private Sub Gridex2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl3.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Then
            LoadDetailInfor(True, True)
        End If
    End Sub

    Private Sub GridEX2_Click(sender As Object, e As EventArgs) Handles GridControl3.Click
        LoadDetailInfor(True, True)
    End Sub

    Private Sub rdbAccessTimeOneDay_CheckedChanged(sender As Object, e As EventArgs)
        If rdbAccessTimeOneDay.Checked = True Then
            LoadDetailInfor(True, False)
        End If
    End Sub

    Private Sub rdbAccessTimeThreeDay_CheckedChanged(sender As Object, e As EventArgs)
        If rdbAccessTimeThreeDay.Checked = True Then
            LoadDetailInfor(True, False)
        End If
    End Sub

    Private Sub rdbAccessTimeInMonth_CheckedChanged(sender As Object, e As EventArgs)
        If rdbAccessTimeInMonth.Checked = True Then
            LoadDetailInfor(True, False)
        End If
    End Sub

    Private Sub frmCongBatThuong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessTime.EditValue = Today
        tvcn.GetDataOnDropDownCategoryCodeName(InOutStatus, "InOutStatusCate")
        ShiftName.Properties.DataSource = kn.ReadData("exec sp_BangCa", "table")
        ShiftName.Properties.DisplayMember = "ShiftSign"
        ShiftName.Properties.ValueMember = "ShiftName"
        ShiftName.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        ShiftName.Properties.NullText = ""
        LoadGiaoDienTheoDieuKien()
    End Sub

    Private Sub rdbSuaDuLieuQuet_CheckedChanged(sender As Object, e As EventArgs) Handles rdbSuaDuLieuQuet.CheckedChanged
        Reason.Properties.DataSource = Nothing
        Reason.Properties.Columns.Clear()
        If rdbSuaDuLieuQuet.Checked = True Then
            pnSuaCa.Visible = False
            pnSuaGioQuet.Visible = True
            tvcn.GetDataOnDropDownCategoryCodeName(Reason, "ReasonOfEditAccessTime")
        Else
            pnSuaCa.Visible = True
            pnSuaGioQuet.Visible = False
            tvcn.GetDataOnDropDownCategoryCodeName(Reason, "ReasonOfEditShiftName")
        End If
    End Sub
    Private Sub btnNhap_Click(sender As Object, e As EventArgs) Handles btnNhap.Click
        If IsNothing(Reason.EditValue) Then
            Me.ErrorProvider1.SetError(Reason, ”Please enter some values”)
            Return
        Else
            Me.ErrorProvider1.Clear()
        End If
        If rdbSuaDuLieuQuet.Checked = True Then
            Dim tabCa, tabAccessTime As DataTable
            Dim dtr As DataRow()
            Dim random As New Random()
            Dim sn As String
            If rdbNhapTheoGioNhap.Checked = False Then
                tabCa = kn.ReadData("select * from HR_Shifts", "table")
            End If
            If IsNothing(AccessTime.EditValue) Then
                Me.ErrorProvider1.SetError(AccessTime, ”Please enter some values”)
                Return
            Else
                Me.ErrorProvider1.Clear()
            End If

            If IsNothing(InOutStatus.EditValue) Then
                Me.ErrorProvider1.SetError(InOutStatus, ”Please enter some values”)
                Return
            Else
                Me.ErrorProvider1.Clear()
            End If
            Dim bCheDo As Boolean
            Dim LeaveType_ID As String
            Dim gr As DataRow
            For numberRow As Integer = 0 To GridView3.SelectedRowsCount - 1
                gr = GridView3.GetDataRow(GridView3.GetSelectedRows(numberRow))
                bCheDo = False
                Try
                    If Not IsDBNull(gr.Item("CheDo")) Then
                        If gr.Item("CheDo") = "CheDo" Then
                            bCheDo = True
                        End If
                    End If
                    LeaveType_ID = String.Empty
                    If Not IsDBNull(gr.Item("LeaveType_ID")) Then
                        LeaveType_ID = gr.Item("LeaveType_ID").ToString
                    End If
                Catch ex As Exception

                End Try
                If rdbNhapTheoGioNhap.Checked = True Then
                    If InOutStatus.EditValue = 0 Then
                        GridView3.GetDataRow(GridView3.GetSelectedRows(numberRow)).Item("RealTimeIn") = AccessTime.Time.ToString("HH:mm")
                        'gr.Item("RealTimeIn") = AccessTime.Time.ToString("HH:mm")
                    Else
                        GridView3.GetDataRow(GridView3.GetSelectedRows(numberRow)).Item("RealTimeOut") = AccessTime.Time.ToString("HH:mm")
                        'gr.Item("RealTimeOut") = AccessTime.Time.ToString("HH:mm")
                    End If
                Else
                    If Not IsDBNull(gr.Item("ShiftName")) Then
                        sn = gr.Item("ShiftName").ToString
                    Else
                        sn = String.Empty
                    End If
                    dtr = tabCa.Select("ShiftName='" + sn + "'")
                    If dtr.Length = 1 Then
                        tabAccessTime = kn.ReadData("exec sp_XuLyGioQuetVaoRaTuDongTheoCa '" + CDate(gr.Item("Ngay").ToString).ToString("yyyy-MM-dd") + "','" + gr.Item("Employee_ID").ToString + "','" + sn + "','" + InOutStatus.EditValue.ToString() + "','" + LeaveType_ID + "','" + IIf(bCheDo = True, "1", "0") + "'," + IIf(cbGioTangCa.Checked = False, "null", maxovertime.Value.ToString()), "table")
                        If tabAccessTime.Rows.Count > 0 Then
                            If InOutStatus.EditValue = 0 Then
                                If rdbNhapTheoDungGioCa.Checked = True Then
                                    GridView3.GetDataRow(GridView3.GetSelectedRows(numberRow)).Item("RealTimeIn") = CDate(tabAccessTime.Rows(0)("AccessTime")).ToString("HH:mm")
                                    'gr.Item("RealTimeIn") = CDate(tabAccessTime.Rows(0)("AccessTime")).ToString("HH:mm")
                                Else
                                    GridView3.GetDataRow(GridView3.GetSelectedRows(numberRow)).Item("RealTimeIn") = CDate(tabAccessTime.Rows(0)("AccessTime")).AddMinutes(0 - random.Next(0, 15)).ToString("HH:mm")
                                    'gr.Item("RealTimeIn") = CDate(tabAccessTime.Rows(0)("AccessTime")).AddMinutes(0 - random.Next(0, 15)).ToString("HH:mm")
                                End If
                            Else
                                If rdbNhapTheoDungGioCa.Checked = True Then
                                    GridView3.GetDataRow(GridView3.GetSelectedRows(numberRow)).Item("RealTimeOut") = CDate(tabAccessTime.Rows(0)("AccessTime")).ToString("HH:mm")
                                    'gr.Item("RealTimeOut") = CDate(tabAccessTime.Rows(0)("AccessTime")).ToString("HH:mm")
                                Else
                                    GridView3.GetDataRow(GridView3.GetSelectedRows(numberRow)).Item("RealTimeOut") = CDate(tabAccessTime.Rows(0)("AccessTime")).AddMinutes(random.Next(0, 15)).ToString("HH:mm")
                                    'gr.Item("RealTimeOut") = CDate(tabAccessTime.Rows(0)("AccessTime")).AddMinutes(random.Next(0, 15)).ToString("HH:mm")
                                End If
                            End If
                        End If
                    End If
                End If
                GridView3.GetDataRow(GridView3.GetSelectedRows(numberRow)).Item("Reason") = Reason.EditValue
                GridView3.GetDataRow(GridView3.GetSelectedRows(numberRow)).Item("Remark") = Remark.Text.Trim
                'gr.Item("Reason").Value = Reason.EditValue
                'gr.Item("Remark").Value = Remark.Text.Trim
            Next
        End If
    End Sub

    Private Sub InOutStatus_ValueChanged(sender As Object, e As EventArgs) Handles InOutStatus.EditValueChanged
        If InOutStatus.EditValue = 1 Then
            maxovertime.Enabled = True
            cbGioTangCa.Enabled = True
        Else
            maxovertime.Value = 0
            cbGioTangCa.Checked = False
            cbGioTangCa.Enabled = False
            maxovertime.Enabled = False
        End If
        If Not IsNothing(InOutStatus.EditValue) Then
            Me.ErrorProvider1.Clear()
        Else
            Me.ErrorProvider1.SetError(InOutStatus, ”Please enter some values”)
            Return
        End If
    End Sub

    Private Sub Reason_ValueChanged(sender As Object, e As EventArgs) Handles Reason.EditValueChanged
        If Not IsNothing(Reason.EditValue) Then
            Me.ErrorProvider1.Clear()
        Else
            Me.ErrorProvider1.SetError(Reason, ”Please enter some values”)
            Return
        End If
    End Sub

    Private Sub AccessTime_ValueChanged(sender As Object, e As EventArgs) Handles AccessTime.EditValueChanged
        If IsNothing(AccessTime.EditValue) Then
            Me.ErrorProvider1.SetError(AccessTime, ”Please enter some values”)
            Return
        Else
            Me.ErrorProvider1.Clear()
        End If
    End Sub
    Private Sub ShiftName_ValueChanged(sender As Object, e As EventArgs) Handles ShiftName.EditValueChanged
        If IsNothing(ShiftName.EditValue) Then
            Me.ErrorProvider1.SetError(ShiftName, ”Please enter some values”)
            Return
        Else
            Me.ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub rdbNhapTheoGioNhap_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNhapTheoGioNhap.CheckedChanged
        If rdbNhapTheoGioNhap.Checked = True Then
            AccessTime.Enabled = True
        Else
            AccessTime.Enabled = False
        End If
    End Sub

    Private Sub btnXoaDKTangCa_Click(sender As Object, e As EventArgs) Handles btnXoaDKTangCa.Click
        If GridView3.SelectedRowsCount <= 0 Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Banvuilongchondongcanxoa"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonxoa"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If
        Dim tabCheck As DataTable
        Dim r As DataRow
        For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
            r = GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow))
            tabCheck = kn.ReadData("exec [dbo].[usp_DeleteHR_MaxOvertimeFollowEmpAndDay] '" + r.Item("Employee_ID").ToString + "','" + CDate(r.Item("Ngay").ToString).ToString("yyyy-MM-dd") + "',N'" + obj.UserName + "' ", "table")
            If tabCheck.Rows(0)("ThongBao") <> "" Then
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Dulieudabikhoa") + tvcn.GetLanguagesTranslated("Employee_ID") + ": " + r.Item("Employee_ID").ToString + ", " + tvcn.GetLanguagesTranslated("Ngay") + ": " + CDate(r.Item("Ngay").ToString).ToString("dd/MM/yyyy"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Next
        Xem(HRFORM_QueryView, False, HRFORM_GridControl, HRFORM_Gridview)
        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Thuchienketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If QuyenHRFORM = "View" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim Employee_ID, ShiftName, TimeDate, OldShiftName, TimeIn, TimeOut, TiToRemark, Reason As String
        If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonluu"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If
        Dim tabChange As DataTable = Table.GetChanges()
        Dim tabCheck As DataTable
        If Not IsNothing(tabChange) Then
            For Each r As DataRow In tabChange.Rows
                Employee_ID = "N'" + r("Employee_ID") + "'"
                TimeDate = "'" + CDate(r("Ngay")).ToString("yyyy-MM-dd") + "'"
                If Not IsDBNull(r("ShiftName")) Then
                    OldShiftName = "N'" + r("ShiftName") + "'"
                Else
                    OldShiftName = "null"
                End If
                If Not IsDBNull(r("RealTimeIn")) Then
                    TimeIn = "'" + CType(r("RealTimeIn"), TimeSpan).ToString() + "'"
                Else
                    TimeIn = "Null"
                End If
                If Not IsDBNull(r("RealTimeOut")) Then
                    TimeOut = "'" + CType(r("RealTimeOut"), TimeSpan).ToString() + "'"
                Else
                    TimeOut = "Null"
                End If
                If Not IsDBNull(r("Remark")) Then
                    TiToRemark = "N'" + r("Remark") + "'"
                Else
                    TiToRemark = "Null"
                End If
                If Not IsDBNull(r("Reason")) Then
                    Reason = "N'" + r("Reason") + "'"
                Else
                    Reason = "Null"
                End If
                tabCheck = kn.ReadData("[dbo].[usp_InsertUpdateAccessTimeAndShift] " + Employee_ID + "," + TimeDate + "," + OldShiftName + ",null,null," + TimeIn + "," + TimeOut + "," + Reason + "," + TiToRemark + ",N'" + obj.UserName + "'", "table")
                If Not IsNothing(tabCheck) Then
                    If tabCheck.Rows.Count > 0 Then
                        If tabCheck.Rows(0)("ThongBao") <> "" Then
                            MessageBox.Show("Lỗi: " + Employee_ID + " ngày " + TimeDate + "; " + tabCheck.Rows(0)("ThongBao"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit For
                        End If
                    End If
                End If
            Next
            Table.AcceptChanges()
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Luuketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnLuuDKTC_Click(sender As Object, e As EventArgs) Handles btnLuuDKTC.Click
        If IsNothing(Table) Then
            Exit Sub
        End If
        If QuyenHRFORM = "View" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim Employee_ID, ShiftName, workingdate, maxovertime, OldShiftName, OTRemark As String
        If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonluu"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If
        Dim tabChange As DataTable = Table.GetChanges()
        Dim tabCheck As DataTable
        If Not IsNothing(tabChange) Then
            For Each r As DataRow In tabChange.Rows
                Employee_ID = "N'" + r("Employee_ID") + "'"
                workingdate = "'" + CDate(r("Ngay")).ToString("yyyy-MM-dd") + "'"
                If Not IsDBNull(r("maxovertime")) Then
                    maxovertime = r("maxovertime").ToString()
                Else
                    maxovertime = "null"
                End If
                If Not IsDBNull(r("ShiftName")) Then
                    OldShiftName = "N'" + r("ShiftName") + "'"
                Else
                    OldShiftName = "null"
                End If
                If Not IsDBNull(r("ertsRemark")) Then
                    OTRemark = "N'" + r("ertsRemark") + "'"
                Else
                    OTRemark = "Null"
                End If
                tabCheck = kn.ReadData("[dbo].[sp_InsertUpdateHR_MaxOvertime] null," + Employee_ID + "," + workingdate + "," + maxovertime + ",1,null," + OldShiftName + ",null," + OTRemark + ",null,N'" + obj.UserName + "',null,null", "table")
                If Not IsNothing(tabCheck) Then
                    If tabCheck.Rows.Count > 0 Then
                        If tabCheck.Rows(0)("ThongBao") <> "" Then
                            MessageBox.Show("Lỗi: " + Employee_ID + " ngày " + workingdate + "; " + tabCheck.Rows(0)("ThongBao"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit For
                        End If
                    End If
                End If
            Next
            Table.AcceptChanges()
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Luuketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class