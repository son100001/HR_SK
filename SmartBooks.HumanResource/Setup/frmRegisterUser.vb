Imports WindowsControlLibrary.HRFORM
Imports SmartBooks.BusinessLogic
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class frmRegisterUser

    Dim tab_BangUserDuoiQuyen, tab_QuyenTheoUserDangNhap As DataTable
    Dim Key As New ArrayList
    Dim timekeeping As New Giang_TimeKeeping
    Dim Quyen As String = timekeeping.KiemTraQuyen("Register")

    Private Sub frmRegisterUser1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.GetDataOnDropDownCategoryCodeName(cboGroup, kn.ReadData("select UserName as Code, UserName as Name from [dbo].[User]", "tab"))
        cboGroup.ItemIndex = 0
    End Sub
    Dim BangQuyen As DataTable
    Private Function TaoBang(ByVal UserName As String) As DataTable
        'If obj.UserName.Trim.ToUpper = "ADMIN" Then
        '    BangQuyen = kn.ReadData("SELECT * FROM [dbo].[Permission]", "Permission")
        'Else

        'End If
        BangQuyen = kn.ReadData("SELECT * FROM [dbo].[Permission] where [UserName] = '" + cboGroup.EditValue.Trim + "'", "Permission")
        Dim BangChucNang As DataTable = New DataTable("EmpRegisTimeSheet")
        BangChucNang.BeginLoadData()

        Dim ID As DataColumn = New DataColumn("ID")
        ID.DataType = System.Type.GetType("System.String")
        BangChucNang.Columns.Add(ID)

        Dim NhomQuyen As DataColumn = New DataColumn("NhomQuyen")
        NhomQuyen.DataType = System.Type.GetType("System.String")
        BangChucNang.Columns.Add(NhomQuyen)

        Dim ChucNang As DataColumn = New DataColumn("ChucNang")
        ChucNang.DataType = System.Type.GetType("System.String")
        BangChucNang.Columns.Add(ChucNang)

        Dim QuyenSua As DataColumn = New DataColumn("QuyenSua")
        QuyenSua.DataType = System.Type.GetType("System.Boolean")
        BangChucNang.Columns.Add(QuyenSua)

        Dim QuyenXem As DataColumn = New DataColumn("QuyenXem")
        QuyenXem.DataType = System.Type.GetType("System.Boolean")
        BangChucNang.Columns.Add(QuyenXem)

        Dim Row, rowmang() As DataRow
        Dim ID_ As Integer = 0
        Dim frm As New Form1
        Dim frmM As New frmMain
        Dim i As Integer
        Dim Count As Integer = 0
        For i = 0 To frm.NavBarControl1.Groups.Count - 1
            If frm.NavBarControl1.Groups.Item(i).Visible = True Then
                Count += 1
            End If
        Next
        For i = 0 To Count - 1
            For j As Integer = 0 To frm.NavBarControl1.Groups(i).ItemLinks.Count - 1
                If (tab_QuyenTheoUserDangNhap.Select("FormID='" + frm.NavBarControl1.Groups(i).ItemLinks.Item(j).ItemName + "'").Length > 0 Or obj.UserName.Trim.ToUpper = "ADMIN") And frm.NavBarControl1.Groups(i).ItemLinks.Item(j).Visible = True And frm.NavBarControl1.Groups(i).ItemLinks.Item(j).ItemName <> String.Empty And frm.NavBarControl1.Groups(i).ItemLinks.Item(j).ItemName <> "Reports" And frm.NavBarControl1.Groups(i).ItemLinks.Item(j).ItemName <> "CaiDatTinhLuong" And frm.NavBarControl1.Groups(i).ItemLinks.Item(j).ItemName <> "TinhLuong" And frm.NavBarControl1.Groups(i).ItemLinks.Item(j).ItemName <> "QuanLyThongTinTinhCong" And frm.NavBarControl1.Groups(i).ItemLinks.Item(j).ItemName <> "DangKyCheDo" And frm.NavBarControl1.Groups(i).ItemLinks.Item(j).ItemName <> "QuanLyThongTinQuetVanTay" Then
                    ID_ += 1
                    Row = BangChucNang.NewRow()
                    Row.Item("ID") = ID_.ToString
                    Row.Item("NhomQuyen") = frm.NavBarControl1.Groups(i).Caption
                    Row.Item("ChucNang") = frm.NavBarControl1.Groups(i).ItemLinks.Item(j).Caption
                    rowmang = BangQuyen.Select("FormID = '" + frm.NavBarControl1.Groups(i).ItemLinks.Item(j).ItemName + "'")
                    If rowmang.Length > 0 Then
                        If rowmang(0)("Quyen") = "Edit" Then
                            Row.Item("QuyenSua") = True
                        Else
                            Row.Item("QuyenXem") = True
                        End If
                    End If
                    Key.Add(frm.NavBarControl1.Groups(i).ItemLinks.Item(j).ItemName)
                    If frm.NavBarControl1.Groups(i).ItemLinks.Item(j).ItemName = "RunQuerySQL" Then
                        If obj.UserName.ToUpper = "ADMIN" Then
                            BangChucNang.Rows.Add(Row)
                        End If
                    Else
                        BangChucNang.Rows.Add(Row)
                    End If

                End If
            Next
        Next
        'Công cụ
        i = 0
        Dim ChucNangCongCu() As String = {"Cài Đặt Ngày Nghỉ", "Cài Đặt Loại Nghỉ", "Cài Đặt Ca Làm Việc", "Cài Cấu Hình", "Sao Lưu Dữ Liệu", "Khóa Dữ Liệu"}
        Dim KeyCongCu() As String = {"Set up Holidays sheet", "SetUp Leave Type", "Setup Shifts", "SetUp", "SaoLuuDuLieu", "KhoaThayDoi"}
        For Each CNCC As String In ChucNangCongCu
            If (tab_QuyenTheoUserDangNhap.Select("FormID='" + KeyCongCu(i) + "'").Length > 0 Or obj.UserName.Trim.ToUpper = "ADMIN") Then
                ID_ += 1
                Row = BangChucNang.NewRow()
                Row.Item("ID") = ID_.ToString
                Row.Item("NhomQuyen") = "CÔNG CỤ"
                Row.Item("ChucNang") = CNCC
                If BangQuyen.Select("FormID = '" + KeyCongCu(i) + "'").Length > 0 Then
                    If BangQuyen.Select("FormID = '" + KeyCongCu(i) + "'")(0)("Quyen") = "Edit" Then
                        Row.Item("QuyenSua") = True
                    Else
                        Row.Item("QuyenXem") = True
                    End If
                End If
                Key.Add(KeyCongCu(i))
                i += 1
                BangChucNang.Rows.Add(Row)
            End If
        Next
        BangChucNang.EndLoadData()
        BangChucNang.AcceptChanges()
        Return BangChucNang
    End Function

    Private Sub Xem()
        tab_QuyenTheoUserDangNhap = kn.ReadData("SELECT * FROM [dbo].[Permission] where [UserName] = '" + cboGroup.EditValue.Trim + "'", "Permission")
        GridControl1.DataSource = TaoBang(cboGroup.EditValue.Trim)
        Table = kn.ReadData("SELECT * FROM [dbo].[Permission] where [UserName] = '" + cboGroup.EditValue.Trim + "'", "table")
    End Sub

    Private Sub btnLuu_Click()
        If Quyen = "View" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'GridEX1.Refresh()
        'Dim rowgrid As Gridview1
        Dim rowChild As DataRow
        For i = 0 To GridControl1.DataSource.Rows.Count - 1
            If GridControl1.DataSource.Rows.Count > 0 Then
                If Not (IsDBNull(GridControl1.DataSource.Rows(i)("QuyenSua").ToString) Or GridControl1.DataSource.Rows(i)("QuyenSua").ToString = "") Then
                    If (GridControl1.DataSource.Rows(i)("QuyenSua").ToString = "True") Then
                        If kn.SaveData("DELETE FROM [dbo].[Permission] WHERE UserName = N'" + cboGroup.EditValue.Trim + "' and FormID = N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "'") Then
                        End If
                        If kn.SaveData("INSERT INTO [dbo].[Permission]([UserName], [FormID], [Quyen]) VALUES(N'" + cboGroup.EditValue.Trim + "', N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "', 'Edit')") Then
                        End If
                    ElseIf Not (IsDBNull(GridControl1.DataSource.Rows(i)("QuyenXem").ToString) Or GridControl1.DataSource.Rows(i)("QuyenXem").ToString = "") Then
                        If GridControl1.DataSource.Rows(i)("QuyenXem").ToString = "True" Then
                            If kn.SaveData("DELETE FROM [dbo].[Permission] WHERE UserName = N'" + cboGroup.EditValue.Trim + "' and FormID = N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "'") Then
                            End If
                            If kn.SaveData("INSERT INTO [dbo].[Permission]([UserName], [FormID], [Quyen]) VALUES(N'" + cboGroup.EditValue.Trim + "', N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "', 'View')") Then
                            End If
                        End If
                    Else
                        If kn.SaveData("DELETE FROM [dbo].[Permission] WHERE UserName = N'" + cboGroup.EditValue.Trim + "' and FormID = N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "'") Then
                        End If
                    End If
                ElseIf Not (IsDBNull(GridControl1.DataSource.Rows(i)("QuyenXem").ToString) Or GridControl1.DataSource.Rows(i)("QuyenXem").ToString = "") Then
                    If GridControl1.DataSource.Rows(i)("QuyenXem").ToString = "True" Then
                        If kn.SaveData("DELETE FROM [dbo].[Permission] WHERE UserName = N'" + cboGroup.EditValue.Trim + "' and FormID = N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "'") Then
                        End If
                        If kn.SaveData("INSERT INTO [dbo].[Permission]([UserName], [FormID], [Quyen]) VALUES(N'" + cboGroup.EditValue.Trim + "', N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "', 'View')") Then
                        End If
                    Else
                        If kn.SaveData("DELETE FROM [dbo].[Permission] WHERE UserName = N'" + cboGroup.EditValue.Trim + "' and FormID = N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "'") Then
                        End If
                    End If
                Else
                    If kn.SaveData("DELETE FROM [dbo].[Permission] WHERE UserName = N'" + cboGroup.EditValue.Trim + "' and FormID = N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "'") Then
                    End If
                End If
            Else
                If Not (IsDBNull(GridControl1.DataSource.Rows(i)("QuyenSua").ToString) Or GridControl1.DataSource.Rows(i)("QuyenSua").ToString = "") Then
                    If GridControl1.DataSource.Rows(i)("QuyenSua").ToString = "True" Then
                        If kn.SaveData("DELETE FROM [dbo].[Permission] WHERE UserName = N'" + cboGroup.EditValue.Trim + "' and FormID = N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "'") Then
                        End If
                        If kn.SaveData("INSERT INTO [dbo].[Permission]([UserName], [FormID], [Quyen]) VALUES(N'" + cboGroup.EditValue.Trim + "', N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "', 'Edit')") Then
                        End If
                    ElseIf Not (IsDBNull(GridControl1.DataSource.Rows(i)("QuyenXem").ToString) Or GridControl1.DataSource.Rows(i)("QuyenXem").ToString = "") Then
                        If GridControl1.DataSource.Rows(i)("QuyenXem").ToString = "True" Then
                            If kn.SaveData("DELETE FROM [dbo].[Permission] WHERE UserName = N'" + cboGroup.EditValue.Trim + "' and FormID = N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "'") Then
                            End If
                            If kn.SaveData("INSERT INTO [dbo].[Permission]([UserName], [FormID], [Quyen]) VALUES(N'" + cboGroup.EditValue.Trim + "', N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "', 'View')") Then
                            End If
                        End If
                    Else
                        If kn.SaveData("DELETE FROM [dbo].[Permission] WHERE UserName = N'" + cboGroup.EditValue.Trim + "' and FormID = N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "'") Then
                        End If
                    End If
                ElseIf Not (IsDBNull(GridControl1.DataSource.Rows(i)("QuyenXem").ToString) Or GridControl1.DataSource.Rows(i)("QuyenXem").ToString = "") Then
                    If GridControl1.DataSource.Rows(i)("QuyenXem").ToString = "True" Then
                        If kn.SaveData("DELETE FROM [dbo].[Permission] WHERE UserName = N'" + cboGroup.EditValue.Trim + "' and FormID = N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "'") Then
                        End If
                        If kn.SaveData("INSERT INTO [dbo].[Permission]([UserName], [FormID], [Quyen]) VALUES(N'" + cboGroup.EditValue.Trim + "', N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "', 'View')") Then
                        End If
                    Else
                        If kn.SaveData("DELETE FROM [dbo].[Permission] WHERE UserName = N'" + cboGroup.EditValue.Trim + "' and FormID = N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "'") Then
                        End If
                    End If
                Else
                    If kn.SaveData("DELETE FROM [dbo].[Permission] WHERE UserName = N'" + cboGroup.EditValue.Trim + "' and FormID = N'" + Key(CInt(GridControl1.DataSource.Rows(i)("ID").ToString) - 1) + "'") Then
                    End If
                End If
            End If
        Next
        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Luuthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        btnLuu_Click()
    End Sub

    'Private Sub GridEX1_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridEX1.CellValueChanged
    '    If iSua = 1 Then
    '        iSua = 0
    '        Exit Sub
    '    End If
    '    If e.Column().DataMember = "QuyenSua" Then
    '        Dim rowmang As DataRow() = tab_QuyenTheoUserDangNhap.Select("FormID='" + Key(CInt(GridEX1.GetRow.Cells("ID").Value) - 1) + "'")
    '        If rowmang.Length > 0 Then
    '            If Not IsDBNull(rowmang(0)("Quyen")) Then
    '                If rowmang(0)("Quyen") = "View" Then
    '                    MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    iSua += 1
    '                    GridEX1.GetRow.Cells("QuyenSua").Value = DBNull.Value
    '                End If
    '            Else
    '                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                GridEX1.GetRow.Cells("QuyenSua").Value = DBNull.Value
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub cboGroup_EditValueChanged(sender As Object, e As EventArgs) Handles cboGroup.EditValueChanged
        Xem()
    End Sub

    'Private Sub GridEX1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridEX1.MouseUp
    '    If (e.Button = MouseButtons.Right) Then ' And hitTest = Janus.Windows.GridEX.GridArea.Cell) Then
    '        ColumnGrid = GridEX1.ColumnFromPoint(e.X, e.Y)
    '        If ColumnGrid.DataMember.ToUpper = "DEPARTMENTCODE" Then
    '            str_TenBangViTri = "SmartBooks_Department"
    '        ElseIf ColumnGrid.DataMember.ToUpper = "SECTIONCODE" Then
    '            str_TenBangViTri = "SmartBooks_Section"
    '        ElseIf ColumnGrid.DataMember.ToUpper = "TEAMCODE" Then
    '            str_TenBangViTri = "SmartBooks_Team"
    '        Else
    '            str_TenBangViTri = "TAB"
    '        End If
    '    End If
    'End Sub
End Class