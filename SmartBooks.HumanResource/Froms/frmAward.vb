Public Class frmAward
    Private Sub frmAward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        LoadGiaoDienTheoDieuKien()

        ' --- Load AwardType với cột Amount (thay vì gọi overload không có Amount) ---
        Dim sql As String = "select Category as Code," +
            IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) +
            " as Name, Amount from HR_Category where CategoryFather='KhenThuong'"
        Dim tabAward As DataTable = kn.ReadData(sql, "table")
        If tabAward IsNot Nothing Then
            AwardType.Properties.DataSource = tabAward
            AwardType.Properties.ValueMember = "Code"      ' <-- must be the key column
            AwardType.Properties.DisplayMember = "Name"
            AwardType.Properties.Columns.Clear()
            'AwardType.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code"))
            AwardType.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"))
            'AwardType.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Amount", "Amount", 90, DevExpress.Utils.FormatType.Numeric, "n0", True, DevExpress.Utils.HorzAlignment.Far))
            AwardType.Properties.NullText = ""
        End If
        ' ------------------------------------------------------------------------

        tvcn.SearchEmployee(Employee_ID)
        AwardDate.EditValue = Today

        ' ensure handler registered
        AddHandler Me.AwardType.EditValueChanged, AddressOf AwardType_EditValueChanged
        AddHandler Me.btnSave.Click, AddressOf btnSave_Click

        Search()
    End Sub

    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim QR As String = "exec [dbo].[sp_BangAward] '1900-1-1','" + Today.ToString("yyyy-MM-dd") + "',1,'" + obj.Lan + "',N'" + obj.UserName + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Public Overrides Sub AfterViewForm()
        If Not IsNothing(HRFORM_Gridview.Columns("AwardType")) Then
            Dim tab As DataTable = kn.ReadData("select Category as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name, Amount from HR_Category where CategoryFather='KhenThuong'", "table")
            tvcn.TaoDropDowTrenGrid(HRFORM_Gridview, "AwardType", tab)
            AddHandler Me.AwardType.EditValueChanged, AddressOf AwardType_EditValueChanged
        End If

        ' Delay formatting so it runs after HRFORM.Xem finishes (which overwrites formats)
        'Me.BeginInvoke(
        '    New MethodInvoker(
        '        Sub()
        '            Try
        '                Dim col = HRFORM_Gridview.Columns.ColumnByFieldName("Amount")
        '                If col IsNot Nothing Then
        '                    ' Column display format
        '                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '                    col.DisplayFormat.FormatString = "n0" ' no decimals

        '                    ' If column uses a repository editor, update it too
        '                    Dim repo = TryCast(col.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItem)
        '                    If repo IsNot Nothing Then
        '                        Dim repoText = TryCast(repo, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)
        '                        If repoText IsNot Nothing Then
        '                            repoText.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '                            repoText.DisplayFormat.FormatString = "n0"
        '                            repoText.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        '                            repoText.Mask.EditMask = "n0"
        '                            repoText.Mask.UseMaskAsDisplayFormat = True
        '                        End If

        '                        Dim repoSpin = TryCast(repo, DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit)
        '                        If repoSpin IsNot Nothing Then
        '                            repoSpin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '                            repoSpin.DisplayFormat.FormatString = "n0"
        '                            repoSpin.IsFloatValue = True
        '                            repoSpin.EditMask = "n0"
        '                        End If
        '                    End If

        '                    If col.SummaryItem IsNot Nothing Then
        '                        col.SummaryItem.DisplayFormat = "{0:#,0}"
        '                    End If
        '                End If
        '            Catch ex As Exception
        '                Debug.WriteLine("Format Amount column error: " & ex.Message)
        '            End Try
        '        End Sub))
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        If tvcn.CheckErrorProvider(TableLayoutPanel2, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel2, True, QuyenHRFORM)
        Employee_ID.Select()
        Search()
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        'Search()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub UpdatePriceFromAwardType()
        Dim amountObj As Object = Nothing

        ' Prefer selected DataRowView
        Try
            Dim drv = TryCast(AwardType.GetSelectedDataRow(), System.Data.DataRowView)
            If drv IsNot Nothing AndAlso drv.DataView.Table.Columns.Contains("Amount") Then
                amountObj = drv("Amount")
            End If
        Catch
            amountObj = Nothing
        End Try

        If amountObj Is Nothing Then
            Try
                amountObj = AwardType.GetColumnValue("Amount")
            Catch
                amountObj = Nothing
            End Try
        End If

        ' Parse using vi-VN culture and allow thousands separators
        Dim hasAmount As Boolean = False
        Dim amountDecimal As Decimal = 0D
        Dim ci As New Globalization.CultureInfo("vi-VN")
        If amountObj IsNot Nothing AndAlso Not Convert.IsDBNull(amountObj) Then
            Dim s As String = amountObj.ToString().Trim()
            If Decimal.TryParse(s, Globalization.NumberStyles.Number, ci, amountDecimal) Then
                hasAmount = True
            Else
                ' fallback: try invariant (if value stored as plain numeric without separators)
                If Decimal.TryParse(s, Globalization.NumberStyles.Number, Globalization.CultureInfo.InvariantCulture, amountDecimal) Then
                    hasAmount = True
                End If
            End If
        End If

        ' Format for display (vi-VN)
        Dim formatted As String = String.Empty
        If hasAmount Then
            If amountDecimal = Math.Floor(amountDecimal) Then
                formatted = amountDecimal.ToString("N0", ci)
            Else
                formatted = amountDecimal.ToString("N2", ci)
            End If
        End If

        ' Apply to Amount control(s)
        If TypeOf Me.Amount Is DevExpress.XtraEditors.TextEdit Then
            Dim txt As DevExpress.XtraEditors.TextEdit = CType(Me.Amount, DevExpress.XtraEditors.TextEdit)
            If hasAmount Then
                ' Gán giá trị số trực tiếp để DevExpress áp mask/format
                txt.EditValue = amountDecimal

                ' đảm bảo mask + hiển thị theo vi-VN
                txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                txt.Properties.Mask.EditMask = "n0" ' hoặc "n2" nếu luôn cần 2 chữ số thập phân
                txt.Properties.Mask.UseMaskAsDisplayFormat = True

                ' style / readonly
                txt.Properties.ReadOnly = True
                txt.Enabled = False
            Else
                txt.Properties.ReadOnly = False
                txt.Enabled = True
                txt.EditValue = Nothing
            End If

            ' debug nhanh (xóa sau khi OK)
            Debug.WriteLine("Assigned EditValue=" & If(txt.EditValue Is Nothing, "<null>", txt.EditValue.ToString()) & " Text='" & txt.Text & "'")
            Return
        End If

        Try
            Dim tb = DirectCast(Me.Amount, DevExpress.XtraEditors.TextEdit)
            If hasAmount Then
                tb.Text = formatted
                tb.ReadOnly = True
                tb.Enabled = False
            Else
                tb.ReadOnly = False
                tb.Enabled = True
                tb.Text = String.Empty
            End If
        Catch
            ' ignore unknown control
        End Try
    End Sub

    Private Sub AwardType_EditValueChanged(sender As Object, e As EventArgs)
        UpdatePriceFromAwardType()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class