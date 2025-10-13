Imports System.Net
Imports WindowsControlLibrary
Public Class PhieuLuongMoi
    Dim bTHANHPHANLUONG As Boolean
    Dim MaCongTy, str_Loc, str_MANVSQL As String
    Private Sub PhieuLuongMoi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bTHANHPHANLUONG = False
        'MaCongTy = tvcn.MaCongTy()
        'tvcn.LayDieuKienTheoQuyen(obj.UserName, "InPhieuLuong", txtdepartmentcode, txtsectioncode, txtteamcode)

        txtSubject.Text = "Phiếu lương tháng " + cboMonth.Text + "/" + cboYear.Text

        Dim dsUser As New DataSet
        dsUser.ReadXml(Application.StartupPath & "\login.xml")

        With dsUser.Tables(0).Rows(0)
            Me.tbEmailFrom.Text = .Item("Mail")
            Me.tbpassemailfrom.Text = .Item("PassMail")
        End With
    End Sub


    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        Dim dsUser As New DataSet
        dsUser.ReadXml(Application.StartupPath & "\login.xml")
        Dim tkpdb As String
        If Me.tbEmailFrom.Text = "" Or Me.tbEmailFrom.Text = String.Empty Then
            MessageBox.Show("Please input sender email")
            Exit Sub
        End If

        If Me.tbpassemailfrom.Text = "" Or Me.tbpassemailfrom.Text = String.Empty Then
            MessageBox.Show("Please input sender email password")
            Exit Sub
        End If

        With dsUser.Tables(0).Rows(0)
            .Item("Mail") = Me.tbEmailFrom.Text
            .Item("PassMail") = Me.tbpassemailfrom.Text
        End With
        dsUser.WriteXml(obj.GetAppPath() & "\login.xml")

        MessageBox.Show("Save successful!")
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        txtSubject.Text = "Phiếu lương tháng " + cboMonth.Text + "/" + cboYear.Text
        Dim QR As String = "[dbo].[sp_BangTinhLuong] " + cboMonth.Text + "," + cboYear.Text + ",2,'" + obj.Lan + "','admin'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub btnGuiPhieuLuong_Click(sender As Object, e As EventArgs) Handles btnGuiPhieuLuong.Click
        Dim directory As New IO.DirectoryInfo(Application.StartupPath() + "\In\Private\")
        For Each file As IO.FileInfo In directory.GetFiles
            file.Delete()
        Next

        GuiEmailNhieuPhieuLuong()
    End Sub

    Private Sub GuiEmailNhieuPhieuLuong()
        Dim str_DanhSachEmailKhongGuiDuoc, EmpID, attachfile, attachfile_pdf, content, strsql, edate As String
        'Dim checkedRows() As Janus.Windows.GridEX.GridEXRow
        'Dim rowemp As Janus.Windows.GridEX.GridEXRow
        'checkedRows = Gridex1.GetCheckedRows()
        Dim row As DataRow()
        Dim listEmp As String = ""
        Dim Email As String
        For rowemp As Integer = 0 To GridView1.SelectedRowsCount - 1
            listEmp += "'" + GridView1.GetDataRow(GridView1.GetSelectedRows(rowemp)).Item("Employee_ID").ToString() + ","
        Next
        If listEmp <> "" Then
            listEmp = listEmp.Substring(0, listEmp.Length - 1)
        Else
            MessageBox.Show("Hãy chọn nhân viên để gửi mail", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        content = "Phiếu Lương Tháng " + cboMonth.Text + " Năm " + cboYear.Text
        edate = cboYear.Text + cboMonth.Text

        TaoPhieuLuongA4_ByEmp()

        For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
            EmpID = GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("Employee_ID").ToString()
            Email = GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("Email").ToString()
            attachfile = Application.StartupPath() + "\In\Private\" + edate + "_" + EmpID + ".xls"
            attachfile_pdf = Application.StartupPath() + "\In\Private\" + edate + "_" + EmpID + ".pdf"

            If SendEmail(tbEmailFrom.Text.Trim, tbpassemailfrom.Text, Email, tbCC.Text, tbBCC.Text, txtSubject.Text, attachfile_pdf, content) = 1 Then
                'str_DanhSachEmailKhongGuiDuoc += gridrow.Cells("Email").Value + ","
                'Exit Sub
            Else
                strsql = " Insert into HR_CannotSentEmail(eDate,Employee_ID,Email) "
                strsql += " values('" + edate + "','" + EmpID + "','" + Email + "')"
            End If
        Next
        MessageBox.Show("Send email completed!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub cboMonth_Click(sender As Object, e As EventArgs) Handles cboMonth.Click
        txtSubject.Text = "Phiếu lương tháng " + cboMonth.Text + "/" + cboYear.Text
    End Sub

    Private Sub cboYear_Click(sender As Object, e As EventArgs) Handles cboYear.Click
        txtSubject.Text = "Phiếu lương tháng " + cboMonth.Text + "/" + cboYear.Text
    End Sub

    Private Function TaoPhieuLuongA4_ByEmp() As Boolean
        Dim rc As String = "PhieuLuongTheoMa"
        Dim row As DataRow()
        row = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where ReportCode='" + rc + "'", "table").Select()
        If row.Length <= 0 Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Baocaokhongtontaivuilongkiemtralai"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End If
        Dim QR As String
        Dim frm As New frmPara
        Dim subArr As Object()
        Dim Employee_ID, addressToExport, Month, Year As String
        Month = cboMonth.Text
        Year = cboYear.Text
        frm.KeyOfForm1 = KeyOfForm1
        frm.Quyen = QuyenHRFORM
        frm.ReportInformation = row(0)
        If IsDBNull(row(0)("TemplateFile")) Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Phaimaukhongtontai"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        Dim TemplateFile As String = row(0)("TemplateFile")
        subArr = frm.ObjectParameter()
        For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
            Employee_ID = GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("Employee_ID").ToString()
            subArr.SetValue(Month, 0)
            subArr.SetValue(Year, 1)
            subArr.SetValue(Employee_ID, subArr.Length - 1)
            addressToExport = Application.StartupPath() + "\In\Private\" + cboYear.Text + cboMonth.Text + "_" + Employee_ID + ".pdf"
            ExportReport(TemplateFile, subArr, addressToExport)
        Next

        'PrintReport(TemplateFile, frm.ObjectParameter())
        'For Each GridExRow As GridEXRow In HRFORM_Gridex.GetCheckedRows
        '    DanhSachKey += CStr(GridExRow.Cells(row(0)("PrintViewDocument_FieldKey")).Value) + ","
        'Next
        'ExportReport()
    End Function

    Private Function SendEmail(ByVal EmailFrom As String, ByVal PassEmailFrom As String, ByVal EmailTo As String, ByVal EmailCC As String, ByVal EmailBCC As String, ByVal EmailSubject As String, ByVal LinkFileAttach As String, ByVal Content As String) As Integer
        'GỬI GMAIL
        Try
            Dim client = New System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
            Dim e_mail As New System.Net.Mail.MailMessage()
            Dim Attachment As System.Net.Mail.Attachment

            client.Credentials = New NetworkCredential(EmailFrom, PassEmailFrom)
            client.EnableSsl = True

            e_mail = New System.Net.Mail.MailMessage()
            e_mail.From = New System.Net.Mail.MailAddress(EmailFrom)
            e_mail.To.Add(EmailTo)
            e_mail.Subject = EmailSubject
            e_mail.Body = "Salary"

            Attachment = New System.Net.Mail.Attachment(LinkFileAttach) 'file path
            e_mail.Attachments.Add(Attachment) 'attachment

            client.Send(e_mail)

            'Dim cdomsg As Object

            'cdomsg = CreateObject("CDO.message")
            'With cdomsg.Configuration.Fields
            '    .Item("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2 '' Send the message using SMTP
            '    .Item("http://schemas.microsoft.com/cdo/configuration/smtpserver") = "smtp.gmail.com"
            '    .Item("http://schemas.microsoft.com/cdo/configuration/smptserverport") = 587  '' 465  '587
            '    .Item("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1 'Clear-text authentication
            '    .Item("http://schemas.microsoft.com/cdo/configuration/smtpusessl") = True
            '    .Item("http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout") = 120
            '    .Item("http://schemas.microsoft.com/cdo/configuration/sendusername") = EmailFrom
            '    .Item("http://schemas.microsoft.com/cdo/configuration/sendpassword") = PassEmailFrom
            '    .Update()
            'End With
            '' build email parts
            'With cdomsg
            '    .BodyPart.charset = "unicode-1-1-utf-8"
            '    .To = EmailTo
            '    If EmailCC <> "" Then .Cc = EmailCC
            '    If EmailBCC <> "" Then .Bcc = EmailBCC
            '    .From = EmailFrom
            '    .Subject = EmailSubject
            '    '.TextBody = "cố lên em yêu"
            '    If File.Exists(LinkFileAttach) Then
            '        .AddAttachment(LinkFileAttach)
            '    End If

            '    .HTMLBody = Content
            '    .Send()
            'End With

            'cdomsg = Nothing

            Return 0
        Catch ex As Exception
            MessageBox.Show("Bạn kiểm tra lại tài khoản Email hoặc kết nối Internet " + ex.ToString)
            Return 1
        End Try
    End Function
End Class