Imports System.IO
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win.UltraWinTabControl
Imports OfficeOpenXml
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports ZXing
Imports System.Threading.Tasks
Imports System.Threading
Imports ZXing.Common
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class frmEmployeeInfo

    Private video As VideoCaptureDevice
    Private devices As FilterInfoCollection
    Private reader As BarcodeReader
    Private latestFrame As Bitmap ' chỉ giữ khung hình mới nhất
    Private decodeTask As Task
    Private cts As CancellationTokenSource
    Private decodingBusy As Boolean = False

    'Private Sub Gridex1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)#DEV#
    '    If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Then
    '        If IsNothing(Gridex1.RootTable) = True Then
    '            tvcn.ClearTextInControlOnForm(UltraTabControl2)
    '            Exit Sub
    '        End If
    '        If IsNothing(Gridex1.GetRow().Cells("Employee_ID").Value) = True Then
    '            tvcn.ClearTextInControlOnForm(UltraTabControl2)
    '            Exit Sub
    '        End If
    '        If IsDBNull(Gridex1.GetRow().Cells("Employee_ID").Value) = True Then
    '            tvcn.ClearTextInControlOnForm(UltraTabControl2)
    '            Exit Sub
    '        End If
    '        NhapDuLieuLenForm(Gridex1.GetRow().Cells("Employee_ID").Value)
    '        LoadDetailInfor()
    '    ElseIf e.KeyCode = Keys.Tab Then
    '        Card_Code.Select()
    '    Else
    '        Gridview_KeyUp(sender, e)
    '    End If
    'End Sub
    Private Sub frmEmployeeInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        HRFORM_SaveStore = "usp_InsertUpdateSmartBooks_Employee"
        tvcn.SearchEmployee(EmployeeSearch)
        tvcn.GetDataOnDropDownCategoryCodeName(ContractFlow, kn.ReadData("select distinct [ContractFlow] as Code, [ContractFlow] as Name from [HR_ContractFlow]", "tab"))
        tvcn.GetDataOnDropDownCategoryCodeName(ChucDanh, kn.ReadData("select ChucDanh as Code, Name" + obj.Lan + " as Name from hr_chucdanh", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(Employee_Status, "Employee_Status")
        tvcn.GetDataOnDropDownCategoryCodeName(Sex, "Sex")
        tvcn.GetDataOnDropDownCategoryCodeName(MaritalStatus, "MaritalStatus")
        tvcn.GetDataOnDropDownCategoryCodeName(Graduated, "Graduated")
        tvcn.GetDataOnDropDownCategoryCodeName(Nationality, "Nationality")
        tvcn.GetDataOnDropDownCategoryCodeName(TypeOfHiring, "TypeOfHiring")
        tvcn.GetDataOnDropDownCategoryCodeName(DecisionStatus, "DecisionStatus")
        tvcn.GetDataOnDropDownCategoryCodeName(Nation, kn.ReadData("select MaDanToc as Code,TenDanToc as Name from HR_DanToc", "Table"))
        tvcn.GetDataOnDropDownCategoryCodeName(TonGiao, "TonGiao")
        tvcn.GetDataOnDropDownCategoryCodeName(Factory_ID, kn.ReadData("select * from [dbo].[udf_Factory]('" + obj.Lan + "')", "table"))
        'tvcn.GetDataOnDropDownCategoryCodeName(departmentcode, kn.ReadData("select * from [dbo].[udf_Department]('','" + obj.Lan + "',1)", "table"))
        'tvcn.GetDataOnDropDownCategoryCodeName(sectioncode, kn.ReadData("select * from [dbo].[udf_Section]('',null,'" + obj.Lan + "',1)", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(teamcode, kn.ReadData("select * from [dbo].[udf_Team]('',null,null,'" + obj.Lan + "',1)", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(Qualification, "Qualification")
        'tvcn.GetDataOnDropDownCategoryCodeName(ID_place, kn.ReadData("select MaTinhThanhPho as Code,TenTinhThanhPho as Name from HR_TinhThanhPho", "table"))
        btnGetTemplate.Visible = False
        btnImportExcel.Visible = False
        IsNhapNhanVienMoi.Checked = False
        NhapNhanVienMoi(IsNhapNhanVienMoi.Checked)
        tvcn.GetDataOnDropDownCategoryCodeName(PositionCategory_ID, kn.ReadData("select PositionCategory_ID as Code,PositionCategory_Name" + obj.Lan + " as Name from SmartBooks_PositionCategory", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(Position_ID, kn.ReadData("select Position_ID as Code,Position_Name" + obj.Lan + " as Name from SmartBooks_Position", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(QuanHeVoiChuHo, "QuanHeGiaDinh")
        tvcn.ThemDauSaoChoTruongBuocNhap(Panel1, HRFORM_TableName)
        'Chọn Camera
        devices = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        cbbChonCam.Items.Clear()
        For Each d As FilterInfo In devices
            cbbChonCam.Items.Add(d.Name)
        Next
        If cbbChonCam.Items.Count > 0 Then cbbChonCam.SelectedIndex = 0

        ' Khởi tạo ZXing
        reader = New BarcodeReader() With {
            .AutoRotate = True,
            .TryInverted = True,
            .Options = New ZXing.Common.DecodingOptions With {
                .TryHarder = True,
                .PossibleFormats = New List(Of BarcodeFormat) From {BarcodeFormat.QR_CODE}
            }
        }
        'Kết thúc
        Search(TypeOfReport)
    End Sub

    Private Sub NhapDuLieuLenForm(EmpID As String)
        If EmpID = String.Empty Then
            tvcn.ClearTextInControlOnForm(XtraTabControl2)
            Exit Sub
        End If

        Dim tabEmployee As DataTable = kn.ReadData("exec sp_BangThongTinNhanVien '" + Today.ToString("yyyy-MM-dd") + "','" + Today.ToString("yyyy-MM-dd") + "',1,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "',N'" + obj.PARA_POSITIONCATEGORY_ID + "','" + EmpID.Replace("'", "''") + "'", "table")
        Dim i As Integer
        Dim ListOfFieldOfTable As String
        For i = 0 To tabEmployee.Columns.Count - 1
            ListOfFieldOfTable += tabEmployee.Columns(i).Caption + ","
        Next
        If tabEmployee.Rows.Count > 0 Then
            tvcn.NhapDuLieuTuGridLenFormNhap(XtraTabControl2, tabEmployee.Rows(0), ListOfFieldOfTable.ToUpper().Remove(ListOfFieldOfTable.Length - 1).Split(","))
        Else
            tvcn.ClearTextInControlOnForm(XtraTabControl2)
        End If

        Dim tabImage As DataTable = kn.ReadData("select picture from smartbooks_employee where Employee_ID='" + EmpID + "'", "table")
        Picture.Image = Nothing
        If tabImage.Rows.Count > 0 Then
            If IsDBNull(tabImage.Rows(0)("picture")) = False Then
                Dim imageData As Byte() = DirectCast(tabImage.Rows(0)("picture"), Byte())
                If Not imageData Is Nothing Then
                    Dim ms As New MemoryStream(imageData, 0, imageData.Length)
                    ms.Write(imageData, 0, imageData.Length)
                    Picture.Image = Image.FromStream(ms, True)
                End If
            End If
        End If
    End Sub
    Public Overrides Function BeforeSave() As Integer
        If XtraTabControl1.SelectedTabPage.Name = "General" Then
            'If Employee_ID.Text.Trim = String.Empty Then
            '    Employee_ID.Text = tvcn.ReturnEmployee_ID(StartedDate.DateTime)
            'End If
            UserName.Text = WindowsControlLibrary.DbSetting.UserName
            InsertDate.EditValue = Now
        End If
        Return 1
    End Function
    Public Overrides Sub AfterSave()
        If XtraTabControl1.SelectedTabPage.Name = "General" Then
            Try
                Dim a As System.Drawing.Bitmap
                a = Me.Picture.Image
                If Not a Is Nothing Then
                    Dim ms As New MemoryStream
                    Picture.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Dim arrImage() As Byte = ms.GetBuffer
                    kn.UpdateImagesInformation("UpdateImagesEmployee", arrImage, Employee_ID.Text.Trim)
                Else
                    kn.SaveData("UPDATE [dbo].[SmartBooks_Employee] SET [picture] = null WHERE Employee_ID = '" + Employee_ID.Text.Trim + "'")
                End If
            Catch ex As Exception
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Error") + ": " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            End Try
            tvcn.ClearTextInControlOnForm(XtraTabControl2)
        ElseIf XtraTabControl1.SelectedTabPage.Name = "NhapNVMoi" Then
            If kn.SaveData("exec sp_XuLyNhapNhanVienMoi '" + obj.UserName + "'") = False Then
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Coloitrongquatrinhnhapvitrichucvu"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Public Overrides Sub AfterDelete()
        If XtraTabControl1.SelectedTabPage.Name = "General" Then
            tvcn.ClearTextInControlOnForm(XtraTabControl2)
        End If
    End Sub

    Public Sub NhapNhanVienMoi(ByVal isNhapNhanVienMoi As Boolean)
        Factory_ID.Enabled = isNhapNhanVienMoi
        departmentcode.Enabled = isNhapNhanVienMoi
        sectioncode.Enabled = isNhapNhanVienMoi
        teamcode.Enabled = isNhapNhanVienMoi
        PositionCategory_ID.Enabled = isNhapNhanVienMoi
        ChucDanh.Enabled = isNhapNhanVienMoi
        RFID.Enabled = isNhapNhanVienMoi
        TypeOfHiring.Enabled = isNhapNhanVienMoi
        Position_ID.Enabled = isNhapNhanVienMoi
        JobCode.Enabled = isNhapNhanVienMoi
        IE_FLAG.Enabled = isNhapNhanVienMoi
        TypeOfHiring.Enabled = isNhapNhanVienMoi
        BankAccount.Enabled = isNhapNhanVienMoi

        Factory_ID.Text = ""
        departmentcode.Text = ""
        sectioncode.Text = ""
        teamcode.Text = ""
        PositionCategory_ID.Text = ""
        ChucDanh.Text = ""
        RFID.Text = ""
        TypeOfHiring.Text = ""
        Position_ID.Text = ""
        JobCode.Text = ""
        IE_FLAG.Text = ""
        TypeOfHiring.Text = ""
        BankAccount.Text = ""
        ClearAllInputs(XtraTabControl2)
    End Sub

    Private Sub ClearAllInputs(container As Control)
        For Each ctrl As Control In container.Controls
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Clear()

                'ElseIf TypeOf ctrl Is ComboBox Then
                '    CType(ctrl, ComboBox).SelectedIndex = -1   ' bỏ chọn
                '    CType(ctrl, ComboBox).Text = ""

            ElseIf ctrl.HasChildren Then
                ' đệ quy nếu có container lồng nhau (Panel, GroupBox, TabPage…)
                ClearAllInputs(ctrl)
            End If
        Next
        Employee_Status.Text = ""
        Employee_Status.EditValue = ""
        TernimationDate.EditValue = ""
        BirthDate.Text = ""
        BirthPlace.Text = ""
        NativePlace.Text = ""
        Address_Permanent.Text = ""
        Address_Temporary.Text = ""
    End Sub

    'Public Overrides Sub ExecSubOrFunctionOfVB()
    '    If ReportRow("ReportCode") = "GetEmployeeFromTimeMachine" Then
    '    End If
    'End Sub
    'Private Sub cbbOfficialDate_ValueChanged(sender As Object, e As EventArgs)
    '    If cbbOfficialDate.Text.Trim <> String.Empty Then
    '        OfficialDate.Value = StartedDate.DateTime.AddMonths(CInt(cbbOfficialDate.Text))
    '    End If
    'End Sub

    'Private Sub HealthCheckFee_TextChanged(sender As Object, e As EventArgs) Handles HealthCheckFee.TextChanged
    '    If HealthCheckFee.Text.Trim <> "0" Then
    '        Try
    '            HealthCheckFee.Text = CDbl(HealthCheckFee.Text).ToString("###,###") 'FormatCurrency(Amount.Text, 0).Replace("£", "").Replace("$", "")
    '            HealthCheckFee.SelectionStart = HealthCheckFee.Text.Length + 1
    '        Catch ex As Exception
    '            If HealthCheckFee.Text.Length > 0 Then
    '                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Loidinhdangtien"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                HealthCheckFee.Text = HealthCheckFee.Text.Remove(HealthCheckFee.Text.Trim.Length - 1, 1)
    '                HealthCheckFee.SelectionStart = HealthCheckFee.Text.Length + 1
    '                HealthCheckFee.Focus()
    '            End If
    '        End Try
    '    End If
    'End Sub

    Dim TypeOfReport As Integer = 1
    Private Sub UltraTabControl1_SelectedTabChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        cbbReport.Visible = True
        btnExportExcel.Visible = True
        btnGetTemplate.Visible = True
        btnImportExcel.Visible = True
        btnLuu.Visible = True
        btnRemove.Visible = True
        btnExcute.Visible = True
        btnRefresh.Visible = True
        If XtraTabControl1.SelectedTabPage.Name = "General" Then
            HRFORM_GridControl = GridControl1
            HRFORM_Gridview = GridView1
            HRFORM_TypeOfForm = TypeOfForm.ViewInput
            btnRemove.Visible = True
            btnGetTemplate.Visible = False
            btnImportExcel.Visible = False
            TypeOfReport = 1
            tvcn.ThemDauSaoChoTruongBuocNhap(Panel1, HRFORM_TableName)
        ElseIf XtraTabControl1.SelectedTabPage.Name = "NhapNVMoi" Then
            HRFORM_GridControl = GridControl2
            HRFORM_Gridview = GridView2
            HRFORM_TypeOfForm = TypeOfForm.View
            btnGetTemplate.Visible = False
            btnImportExcel.Visible = True
            TypeOfReport = 7
            GridView2.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
        ElseIf XtraTabControl1.SelectedTabPage.Name = "Utilities" Then
            cbbReport.Visible = False
            btnExportExcel.Visible = False
            btnGetTemplate.Visible = False
            btnImportExcel.Visible = False
            btnLuu.Visible = False
            btnRemove.Visible = False
            btnExcute.Visible = False
            btnRefresh.Visible = False
            If Not IsNothing(GridView1.Columns) Then
                Dim tab As DataTable = tvcn.GetColumnNameOfSQLTable("smartbooks_employee")
                tab.Columns.Add("NameTranslate", GetType(String))
                For Each row As DataRow In tab.Rows
                    If row("COLUMN_NAME") = "Employee_ID" Then
                        row.Delete()
                    End If
                    Try
                        row("NameTranslate") = GridView1.Columns(CStr(row("COLUMN_NAME"))).Caption
                    Catch ex As Exception
                        ' Nếu lỗi thì fallback luôn về COLUMN_NAME
                        'row.Delete()
                    End Try
                Next
                TruongCapNhat.Properties.DataSource = tab
                TruongCapNhat.Properties.DisplayMember = "COLUMN_NAME"
                TruongCapNhat.Properties.ValueMember = "COLUMN_NAME"
                TruongCapNhat.Properties.BestFitMode = BestFitMode.BestFitResizePopup
                TruongCapNhat.Properties.NullText = ""
                'tvcn.GetDataOnDropDownCategoryCodeName(TruongCapNhat, tab)
                btnLayTemplate.Enabled = True
                btnNhap.Enabled = True
            Else
                btnLayTemplate.Enabled = False
                btnNhap.Enabled = False
            End If
            'windowsUIButtonPanel1.Buttons.Item("btnRefresh").Properties.Enabled = False
            'windowsUIButtonPanel.Buttons.Item("btnFunction").Properties.Enabled = False
            'cbbReport.Enabled = False
            If QuyenHRFORM.ToUpper <> "EDIT" Then
                btnNhap.Enabled = False
                btnNhapAnh.Enabled = False
            End If
        End If
        LoadGiaoDienTheoDieuKien()
        HRFORM_XtraTabControl_SelectedTabChanged(sender, e)
        Search(TypeOfReport)
    End Sub
    Private Sub Search(ByVal typeofreport As Integer)
        Dim QR As String = "exec [dbo].[sp_BangThongTinNhanVien] '" + Today.ToString("yyyy-MM-dd") + "','" + Today.ToString("yyyy-MM-dd") + "'," + typeofreport.ToString + ",'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        If IsNothing(GridView1.GetFocusedRow().row("Employee_ID")) = True Then
            tvcn.ClearTextInControlOnForm(XtraTabControl2)
            Exit Sub
        End If
        If Not IsNothing(GridView1.Columns("Employee_ID")) Then
            If IsNothing(GridView1.GetFocusedRow().row("Employee_ID")) = True Then
                tvcn.ClearTextInControlOnForm(XtraTabControl2)
                Exit Sub
            End If
            If IsNothing(GridView1.GetFocusedRow().row("Employee_ID")) = True Then
                tvcn.ClearTextInControlOnForm(XtraTabControl2)
                Exit Sub
            End If
            If IsNothing(GridView1.GetFocusedRow().row("Employee_ID")) = True Then
                tvcn.ClearTextInControlOnForm(XtraTabControl2)
                Exit Sub
            End If
            NhapDuLieuLenForm(GridView1.GetFocusedRow().row("Employee_ID"))
            'LoadDetailInfor()
        End If
    End Sub

    Private Sub btnLayTemplate_Click(sender As Object, e As EventArgs) Handles btnLayTemplate.Click
        tvcn.LayTemplateEPPlus(Application.StartupPath() + "\Teamleate\TempCapNhatThongTinNhanVien.xlsx")
    End Sub

    Private Sub btnUrl_Click(sender As Object, e As EventArgs) Handles btnUrl.Click
        Dim ofd As New OpenFileDialog
        With ofd
            '.FileName = "C:" & "\" & "Received Files" 'Points it to the received files folder
            .Title = "Locate File"
            .Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        End With
        If ofd.ShowDialog() <> DialogResult.Cancel Then
            Url.Text = ofd.FileName
        End If
    End Sub

    Private Sub btnNhap_Click(sender As Object, e As EventArgs) Handles btnNhap.Click
        If QuyenHRFORM = "View" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If TruongCapNhat.Text.Trim = String.Empty Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Banvuilongnhaptruongcancapnhat"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim result As Integer = MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonthaydoithongtinnhanvien"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Exit Sub
        End If
        Dim ArrayValue As New ArrayList
        Dim i As Integer
        Dim Employee_ID As String
        Dim Truong As String
        Dim sql As String
        Dim ojValue As Object
        Dim index As Integer = 8
        Dim dt_Ngay As DateTime
        Dim rows As DataRow() = tvcn.GetInformationOfSQLTable("Smartbooks_Employee").Select("COLUMN_NAME='" + TruongCapNhat.EditValue + "'")

        Dim excel As New FileInfo(Url.Text.Trim)
        Using package = New ExcelPackage(excel)
            Dim workbook = package.Workbook
            Dim worksheet = workbook.Worksheets.First()

            While worksheet.Cells("A" + index.ToString).Text.Trim <> String.Empty
                Employee_ID = worksheet.Cells("A" + index.ToString).Text.Trim
                If rows(0)("DATA_TYPE") = "datetime" Then
                    If Not IsNothing(worksheet.Cells("B" + index.ToString).Value) Then
                        ojValue = "'" + CDate(worksheet.Cells("B" + index.ToString).Value).ToString("yyyy-MM-dd HH:mm:ss") + "'"
                    Else
                        ojValue = "null"
                    End If
                ElseIf rows(0)("DATA_TYPE") = "nvarchar" Then
                    If Not IsNothing(worksheet.Cells("B" + index.ToString).Value) Then
                        ojValue = "N'" + CStr(worksheet.Cells("B" + index.ToString).Value) + "'"
                    Else
                        ojValue = "null"
                    End If
                    'ElseIf rows(0)("DATA_TYPE") = "bit" Then
                    '    ojValue = worksheet.Cells("B" + index.ToString).Value
                Else
                    If Not IsNothing(worksheet.Cells("B" + index.ToString).Value) Then
                        ojValue = "'" + CStr(worksheet.Cells("B" + index.ToString).Value) + "'"
                    Else
                        ojValue = "null"
                    End If
                End If
                If kn.SaveData("update Smartbooks_Employee set " + TruongCapNhat.EditValue + "=" + ojValue + ",InsertDate='" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "',UserName=N'" + obj.UserName + "' where Employee_ID=N'" + Employee_ID + "'") = False Then
                    If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + ". " + tvcn.GetLanguagesTranslated("Popup.Bancomuontieptucthuchienkhong"), "", MessageBoxButtons.YesNo) = DialogResult.No Then
                        Exit While
                    End If
                End If
                index += 1
            End While
        End Using
        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Nhapketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    'Public Sub PrintReport1(ByVal report As String, ByVal pValues() As Object)
    '    Cursor = Cursors.WaitCursor
    '    Dim rptViewer As New ReportViewer
    '    Dim strReportFile As String
    '    strReportFile = Application.StartupPath & "\" & "Teamleate\" & report
    '    rptViewer.ShowReport(strReportFile, pValues)
    '    rptViewer.MdiParent = Me.MdiParent
    '    rptViewer.Show()
    '    Cursor = Cursors.Default
    'End Sub

    'Private Sub btnBrowsePic_Click(sender As Object, e As EventArgs) Handles btnBrowsePic.Click
    '    Dim dr As DialogResult = Me.OpenFileDialog1.ShowDialog()
    '    If (dr = System.Windows.Forms.DialogResult.OK) Then
    '        ' Read the files
    '        Dim file As String
    '        FlowLayoutPanel1.Controls.Clear()

    '        For Each file In OpenFileDialog1.FileNames
    '            ' Create a PictureBox for each file, and add that file to the FlowLayoutPanel.
    '            Try
    '                Dim filename = tvcn.GetOnlyFileNameFromPath(file, False)
    '                Dim txtpb As New TextBox
    '                txtpb.Name = "txtpb" + filename
    '                txtpb.Multiline = True
    '                txtpb.Text = filename
    '                txtpb.Size = New System.Drawing.Size(100, 100)
    '                FlowLayoutPanel1.Controls.Add(txtpb)

    '                Dim pb As New PictureBox()
    '                pb.Name = "pb" + filename
    '                pb.SizeMode = PictureBoxSizeMode.StretchImage
    '                pb.Height = 100 ' loadedImage.Height / 10
    '                pb.Width = 100 ' loadedImage.Width / 10
    '                Dim img As Bitmap = New Bitmap(file)
    '                pb.Image = img
    '                FlowLayoutPanel1.Controls.Add(pb)

    '                Dim btnpbAdd As New Button
    '                btnpbAdd.Name = "btnpbAdd" + filename
    '                btnpbAdd.Text = "Add"
    '                btnpbAdd.Size = New System.Drawing.Size(25, 25)
    '                AddHandler btnpbAdd.Click, AddressOf btnpbAdd_Click
    '                FlowLayoutPanel1.Controls.Add(btnpbAdd)

    '                Dim btnpbDel As New Button
    '                btnpbDel.Name = "btnpbDel" + filename
    '                ' btnpbDel.Image = My.Resources.delete.GetThumbnailImage(20, 20, Nothing, IntPtr.Zero)
    '                btnpbDel.Text = "Delete"
    '                btnpbDel.Size = New System.Drawing.Size(25, 25)
    '                AddHandler btnpbDel.Click, AddressOf btnpbDel_Click
    '                FlowLayoutPanel1.Controls.Add(btnpbDel)

    '                Dim btnpbSave As New Button
    '                btnpbSave.Name = "btnpbSave" + filename
    '                'btnpbSave.Image = My.Resources.Save_icon.GetThumbnailImage(20, 20, Nothing, IntPtr.Zero)
    '                btnpbSave.Text = "Save"
    '                btnpbSave.Size = New System.Drawing.Size(25, 25)
    '                AddHandler btnpbSave.Click, AddressOf btnpbSave_Click
    '                FlowLayoutPanel1.Controls.Add(btnpbSave)

    '                '    Me.FlowLayoutPanel1.SetFlowBreak(Me.Images, True)
    '            Catch SecEx As SecurityException
    '                ' The user lacks appropriate permissions to read files, discover paths, etc.
    '                MessageBox.Show("Security error. Please contact your administrator for details.\n\n" &
    '                    "Error message: " & SecEx.Message & "\n\n" &
    '                    "Details (send to Support):\n\n" & SecEx.StackTrace)
    '            Catch ex As Exception
    '                ' Could not load the image - probably permissions-related.
    '                MessageBox.Show(("Cannot display the image: " & file.Substring(file.LastIndexOf("\"c)) &
    '                ". You may not have permission to read the file, or " + "it may be corrupt." _
    '                & ControlChars.Lf & ControlChars.Lf & "Reported error: " & ex.Message))
    '            End Try
    '        Next file
    '    End If
    'End Sub
    Friend Sub btnpbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles btnChonAnh.Click
        Dim name = sender.Name.Replace("btnpbAdd", "")
        Dim pb = FlowLayoutPanel1.Controls("pb" + name)
        ChoosePicture(pb)
    End Sub
    Friend Sub btnpbDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles btnChonAnh.Click
        Dim name = sender.Name.Replace("btnpbDel", "")
        Dim pb = FlowLayoutPanel1.Controls("pb" + name)
        pb.Image = Nothing
    End Sub
    Friend Sub btnpbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles btnChonAnh.Click
        Dim name = sender.Name.Replace("btnpbSave", "")
        Dim pb = FlowLayoutPanel1.Controls("pb" + name)
        Dim arrImage1() As Byte = tvcn.GetDrawingImgToBytes(pb.Image)
        If tvcn.UpdateImageByEmployee_ID(FlowLayoutPanel1.Controls("txtpb" + name).Text, arrImage1) Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Nhapthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Nhapthatbai"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Public Sub ChoosePicture(ByRef pImages As PictureBox)
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Dim img As Bitmap
                img = New Bitmap(OpenFileDialog1.FileName)
                pImages.Image = img
            Catch
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Loidinhdanganh"), "ChoosePicture", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnChonAnh_Click(sender As Object, e As EventArgs) Handles btnChonAnh.Click
        If Me.OpenFileDialog1.ShowDialog(Me) = DialogResult.OK Then
            Try
                Dim img As Bitmap
                img = New Bitmap(Me.OpenFileDialog1.FileName)
                Picture.Image = img
            Catch
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Loidinhdanganh"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnXoaAnh_Click(sender As Object, e As EventArgs) Handles btnXoaAnh.Click
        Picture.Image = Nothing
    End Sub

    'Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
    '    NhapDuLieuLenForm(EmployeeSearch.Text.Trim)
    '    LoadDetailInfor()
    'End Sub

    'Private Sub EmployeeSearch_KeyUp(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        NhapDuLieuLenForm(EmployeeSearch.Text.Trim)
    '        LoadDetailInfor()
    '    End If
    'End Sub

    'Private Sub btnSaveImage_Click(sender As Object, e As EventArgs) Handles btnSaveImage.Click
    '    Try
    '        If FlowLayoutPanel1.Controls Is Nothing Then Exit Sub
    '        Dim iCount = 0
    '        Dim name = ""
    '        Dim arrImage1() As Byte
    '        For Each fctrl In FlowLayoutPanel1.Controls
    '            If fctrl.GetType().Name.ToUpper = "PictureBox".ToUpper Then
    '                name = fctrl.Name.ToString.Replace("pb", "")
    '                'Dim arrImage1() As Byte = GetDrawingImgToBytes(DirectCast(fctrl, PictureBox).Image)
    '                arrImage1 = tvcn.GetDrawingImgToBytes(fctrl.Image)
    '                If tvcn.UpdateImageByEmployee_ID(FlowLayoutPanel1.Controls("txtpb" + name).Text, arrImage1) Then
    '                    iCount += 1
    '                Else
    '                    iCount = -1
    '                End If
    '            End If
    '        Next
    '        If iCount > 0 Then
    '            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Nhapthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        ElseIf iCount = -1 Then
    '            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Nhapthatbai"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Error") + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
    '    End Try
    'End Sub

    'Private Sub BirthDateFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BirthDateFormat.SelectedIndexChanged
    '    BirthDate.FormatString = BirthDateFormat.Text.Trim
    'End Sub

    Private Sub btnDoiMaNV_Click(sender As Object, e As EventArgs) Handles btnDoiMaNV.Click
        If QuyenHRFORM = "View" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuondoimanhanvien"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If
        Dim tab_BangChuaMaNhanVien As DataTable = kn.ReadData("exec sp_BangChuaMaNhanVien", "table")
        Dim sql As String
        sql = "update ##### set Employee_ID=N'" + txtMaNVMoi.Text.Trim + "' where Employee_ID=N'" + txtMaNVCu.Text.Trim + "' "
        Dim sqlupdate As String
        For Each row As DataRow In tab_BangChuaMaNhanVien.Rows
            Me.Text = row("TableName")
            sqlupdate = sql.Replace("#####", row("TableName"))
            If kn.SaveData(sqlupdate) = False Then
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Error") + ": " + row("TableName"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Next
        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Thuchienketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    'Private Sub GridEX2_AddingRecord(sender As Object, e As CancelEventArgs) Handles GridEX2.AddingRecord
    '    For Each s As String In tvcn.GetColumns_ISNOTNULLABLE_OfTable("SmartBooks_Employee")
    '        If IsDBNull(GridEX2.GetRow.Cells(s).Value) Then
    '            e.Cancel = True
    '            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Banvuilongnhapdulieuvaonhungcotmaudo"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '        End If
    '    Next
    'End Sub

    Private Sub btnNhapAnh_Click(sender As Object, e As EventArgs) Handles btnNhapAnh.Click
        Dim dr As DialogResult = Me.OpenFileDialog1.ShowDialog()
        If (dr = System.Windows.Forms.DialogResult.OK) Then
            If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
            ' Read the files
            Dim file As String
            FlowLayoutPanel1.Controls.Clear()
            For Each file In OpenFileDialog1.FileNames
                Dim filename = tvcn.GetOnlyFileNameFromPath(file, False)
                If tvcn.LuuAnhNhanVien(file, filename) = False Then
                    If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancomuontieptucluu"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                        Exit Sub
                    End If
                End If
            Next file
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Nhapthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BirthDateFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BirthDateFormat.SelectedIndexChanged
        If BirthDateFormat.Text = "yyyy" Then
            BirthDate.Properties.EditMask = "yyyy"
        Else
            BirthDate.Properties.EditMask = "d"
        End If
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Not IsDBNull(EmployeeSearch.EditValue) Then
            NhapDuLieuLenForm(EmployeeSearch.EditValue)
        End If
    End Sub

    Private Sub EmployeeSearch_EditValueChanged(sender As Object, e As EventArgs) Handles EmployeeSearch.EditValueChanged
        If Not IsDBNull(EmployeeSearch.EditValue) Then
            NhapDuLieuLenForm(EmployeeSearch.EditValue)
        End If
    End Sub

    Private Sub DecisionStatus_EditValueChanged(sender As Object, e As EventArgs) Handles DecisionStatus.EditValueChanged

    End Sub

    Private Sub IsSeasonWorker_CheckedChanged(sender As Object, e As EventArgs) Handles IsSeasonWorker.CheckedChanged
        EndOfSeasonWorker.Enabled = IsSeasonWorker.Checked
    End Sub

    Private Sub IsNhapNhanVienMoi_CheckedChanged(sender As Object, e As EventArgs) Handles IsNhapNhanVienMoi.CheckedChanged
        NhapNhanVienMoi(IsNhapNhanVienMoi.Checked)
        Dim tab_BangChuaMaNhanVien As DataTable = kn.ReadData("exec sp_GexMaxEmployee_ID", "table")
        If (IsNhapNhanVienMoi.Checked) Then
            Employee_ID.Text = "C" + (tab_BangChuaMaNhanVien.Rows(0)("Data_") + 1).ToString
        Else
            Employee_ID.Text = ""
        End If
    End Sub

    Private Sub btnChonAnhCCCD_Click(sender As Object, e As EventArgs) Handles btnChonAnhCCCD.Click
        If video IsNot Nothing AndAlso video.IsRunning Then
            RemoveHandler video.NewFrame, AddressOf OnNewFrame
            video.SignalToStop()
            video.WaitForStop()
        End If
        If Me.OpenFileDialog1.ShowDialog(Me) = DialogResult.OK Then
            Try
                Dim txtQRRaw As String
                Dim img As Bitmap
                img = New Bitmap(Me.OpenFileDialog1.FileName)
                PictureCCCD.Image = img

                Dim qrText = DecodeQrFromImage(CType(PictureCCCD.Image, Bitmap))

                ' Thử parse theo định dạng phổ biến: các trường cách nhau bởi dấu |
                If Not String.IsNullOrWhiteSpace(qrText) AndAlso qrText.Contains("|") Then
                    ParseAndShow(qrText)
                End If

            Catch
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Loidinhdanganh"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnXoaAnhCCCD_Click(sender As Object, e As EventArgs) Handles btnXoaAnhCCCD.Click
        If video IsNot Nothing AndAlso video.IsRunning Then
            RemoveHandler video.NewFrame, AddressOf OnNewFrame
            video.SignalToStop()
            video.WaitForStop()
        End If
        PictureCCCD.Image = Nothing
        ClearParsedFields()
    End Sub

    Private Function DecodeQrFromImage(img As Bitmap) As String
        If img Is Nothing Then Return ""

        Dim bmp As Bitmap = CType(img.Clone(), Bitmap)

        ' Nếu ảnh nhỏ thì phóng to lên để dễ nhận QR
        If Math.Max(bmp.Width, bmp.Height) < 800 Then
            Dim scale As Double = 800 / Math.Max(bmp.Width, bmp.Height)
            Dim w As Integer = CInt(bmp.Width * scale)
            Dim h As Integer = CInt(bmp.Height * scale)
            Dim up As New Bitmap(w, h)
            Using g = Graphics.FromImage(up)
                g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
                g.SmoothingMode = Drawing2D.SmoothingMode.None
                g.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
                g.DrawImage(bmp, New Rectangle(0, 0, w, h))
            End Using
            bmp.Dispose()
            bmp = up
        End If

        Dim reader = New BarcodeReader() With {
            .AutoRotate = True,
            .TryInverted = True,
            .Options = New ZXing.Common.DecodingOptions() With {
                .PossibleFormats = New List(Of BarcodeFormat) From {BarcodeFormat.QR_CODE},
                .TryHarder = True
            }
        }

        Dim result = reader.Decode(bmp)
        bmp.Dispose()

        Return If(result IsNot Nothing, result.Text, "")

    End Function

    Private Function DecodeQR_FromImage_Robust(raw As Bitmap) As String
        If raw Is Nothing Then Return ""

        ' ZXing: bật TryHarder + tìm QR
        Dim reader As New BarcodeReader() With {
        .AutoRotate = True,
        .TryInverted = True,
        .Options = New DecodingOptions With {
            .TryHarder = True,
            .PossibleFormats = New List(Of BarcodeFormat) From {BarcodeFormat.QR_CODE},
            .ReturnCodabarStartEnd = False,
            .PureBarcode = False
        }
    }

        ' ====== cấu hình các “thử nghiệm” ======
        Dim rotations() As Integer = {0, 90, 180, 270}
        Dim scales() As Double = {1.0, 1.3, 1.6, 2.0, 2.5}  ' thêm 3.0 nếu cần
        ' các ROI: Full, Center(60%), 4 góc (45%)
        Dim rois As Func(Of Size, Rectangle)() = {
        Function(sz) New Rectangle(0, 0, sz.Width, sz.Height),                                    ' full
        Function(sz) New Rectangle(CInt(sz.Width * 0.2), CInt(sz.Height * 0.2),
                                   CInt(sz.Width * 0.6), CInt(sz.Height * 0.6)),                ' center
        Function(sz) New Rectangle(0, 0, CInt(sz.Width * 0.45), CInt(sz.Height * 0.45)),          ' top-left
        Function(sz) New Rectangle(sz.Width - CInt(sz.Width * 0.45), 0,
                                   CInt(sz.Width * 0.45), CInt(sz.Height * 0.45)),                 ' top-right
        Function(sz) New Rectangle(0, sz.Height - CInt(sz.Height * 0.45),
                                   CInt(sz.Width * 0.45), CInt(sz.Height * 0.45)),                 ' bottom-left
        Function(sz) New Rectangle(sz.Width - CInt(sz.Width * 0.45), sz.Height - CInt(sz.Height * 0.45),
                                   CInt(sz.Width * 0.45), CInt(sz.Height * 0.45))                  ' bottom-right
    }

        ' ====== vòng thử: rotation → ROI → scale → enhance → decode ======
        For Each rot In rotations
            Using rotated As Bitmap = RotateIfNeeded(raw, rot)
                For Each roiMaker In rois
                    Dim r As Rectangle = roiMaker(rotated.Size)
                    r.Intersect(New Rectangle(0, 0, rotated.Width, rotated.Height))
                    Using roiBmp As Bitmap = rotated.Clone(r, PixelFormat.Format24bppRgb)
                        For Each s In scales
                            Using scaled As Bitmap = ScaleIfNeeded(roiBmp, s, 900)   ' đảm bảo cạnh dài ~≥900px
                                ' 1) thử decode trực tiếp
                                Dim res = reader.Decode(scaled)
                                If res IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(res.Text) Then
                                    Return res.Text
                                End If

                                ' 2) tăng tương phản nhẹ rồi decode lại
                                Using boosted As Bitmap = BoostContrast(scaled, 1.25F, -0.1F)
                                    res = reader.Decode(boosted)
                                    If res IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(res.Text) Then
                                        Return res.Text
                                    End If
                                End Using
                            End Using
                        Next
                    End Using
                Next
            End Using
        Next

        ' Fallback cuối: thử toàn ảnh gốc 1 lần nữa
        Dim lastTry = reader.Decode(raw)
        Return If(lastTry IsNot Nothing, lastTry.Text, "")
    End Function

    ' ====== helpers gọn – chỉ dùng nội bộ hàm trên ======

    Private Function RotateIfNeeded(src As Bitmap, degrees As Integer) As Bitmap
        If degrees Mod 360 = 0 Then Return CType(src.Clone(), Bitmap)
        Dim bmp As New Bitmap(src.Height, src.Width) ' 90/270: đảo W/H
        If degrees Mod 180 = 0 Then bmp = New Bitmap(src.Width, src.Height)
        Using g = Graphics.FromImage(bmp)
            g.InterpolationMode = InterpolationMode.NearestNeighbor
            g.SmoothingMode = SmoothingMode.None
            g.TranslateTransform(bmp.Width / 2.0F, bmp.Height / 2.0F)
            g.RotateTransform(degrees)
            g.TranslateTransform(-src.Width / 2.0F, -src.Height / 2.0F)
            g.DrawImage(src, New Rectangle(0, 0, src.Width, src.Height))
        End Using
        Return bmp
    End Function

    ' scaleFactor: 1.0 giữ nguyên; hardMinLongSide: nếu ảnh còn nhỏ, tự nâng lên mức tối thiểu (ví dụ 900px)
    Private Function ScaleIfNeeded(src As Bitmap, scaleFactor As Double, hardMinLongSide As Integer) As Bitmap
        Dim longSide = Math.Max(src.Width, src.Height)
        Dim targetLong = Math.Max(CInt(longSide * scaleFactor), hardMinLongSide)
        If targetLong <= longSide AndAlso Math.Abs(scaleFactor - 1.0) < 0.001 Then
            Return CType(src.Clone(), Bitmap)
        End If
        Dim s = CDbl(targetLong) / longSide
        Dim w = Math.Max(1, CInt(src.Width * s))
        Dim h = Math.Max(1, CInt(src.Height * s))
        Dim up As New Bitmap(w, h)
        Using g = Graphics.FromImage(up)
            g.InterpolationMode = InterpolationMode.NearestNeighbor ' giữ biên QR sắc
            g.SmoothingMode = SmoothingMode.None
            g.PixelOffsetMode = PixelOffsetMode.Half
            g.DrawImage(src, New Rectangle(0, 0, w, h))
        End Using
        Return up
    End Function

    ' Tăng tương phản (contrastGain > 1) + bù sáng (brightnessOffset ~ -0.1 .. +0.1)
    Private Function BoostContrast(src As Bitmap, contrastGain As Single, brightnessOffset As Single) As Bitmap
        Dim cm As New ColorMatrix(New Single()() {
        New Single() {contrastGain, 0, 0, 0, 0},
        New Single() {0, contrastGain, 0, 0, 0},
        New Single() {0, 0, contrastGain, 0, 0},
        New Single() {0, 0, 0, 1, 0},
        New Single() {brightnessOffset, brightnessOffset, brightnessOffset, 0, 1}
    })
        Dim dst As New Bitmap(src.Width, src.Height, PixelFormat.Format24bppRgb)
        Using g As Graphics = Graphics.FromImage(dst)
            Using ia As New ImageAttributes()
                ia.SetColorMatrix(cm)
                g.DrawImage(src, New Rectangle(0, 0, dst.Width, dst.Height),
                        0, 0, src.Width, src.Height, GraphicsUnit.Pixel, ia)
            End Using
        End Using
        Return dst
    End Function

    '=== Tuỳ chọn: tách trường nếu QR theo định dạng có dấu | ===
    Private Sub ParseAndShow(qr As String)
        ' Ví dụ giả định: SoCCCD|HoTen|NgaySinh|GioiTinh|QuocTich|QueQuan|ThuongTru|NgayCap|NgayHetHan
        Dim parts = qr.Split("|"c)

        ' Kiểm tra số lượng phần tử tuỳ dữ liệu thực tế của bạn
        Dim partsName = SafeGet(parts, 2).Trim().Split(" "c)
        Dim hoTenDem = String.Join(" ", partsName.Take(partsName.Length - 1)), ten = partsName.Last()
        ID_number.Text = SafeGet(parts, 0)
        CCCDCu.Text = SafeGet(parts, 1)
        Employee_Firstname.Text = hoTenDem
        Employee_Lastname.Text = ten
        BirthDate.EditValue = ConvertStringToDate(SafeGet(parts, 3))
        Sex.EditValue = If(SafeGet(parts, 4).Trim().ToLower() = "nam",
                   "Male",
                   If(SafeGet(parts, 4).Trim().ToLower() = "nữ" Or SafeGet(parts, 4).Trim().ToLower() = "nu",
                      "Female",
                      SafeGet(parts, 4)))
        Address_Permanent.Text = SafeGet(parts, 5).Replace(",", " -")
        ID_date.EditValue = ConvertStringToDate(SafeGet(parts, 6))
        NgayHetHanCCCD.EditValue = TinhNgayHetHanCCCD(ConvertStringToDate(SafeGet(parts, 3)))
    End Sub

    Private Function TinhNgayHetHanCCCD(birthDate As DateTime) As DateTime
        Dim age As Integer = DateDiff(DateInterval.Year, birthDate, DateTime.Today)

        If age < 25 Then
            Return birthDate.AddYears(25)
        ElseIf age < 40 Then
            Return birthDate.AddYears(40)
        ElseIf age < 60 Then
            Return birthDate.AddYears(60)
        Else
            ' Sau 60 tuổi: không phải đổi nữa
            Return birthDate.AddYears(100)   ' Có thể trả về MaxValue hoặc Nothing
        End If
    End Function

    Private Function SafeGet(arr As String(), index As Integer) As String
        If arr Is Nothing Then Return ""
        If index < 0 OrElse index >= arr.Length Then Return ""
        Return arr(index)
    End Function

    Private Sub ClearParsedFields()
        ' Xoá các textbox parse nếu bạn có
        ' txtSoCCCD.Clear()
        ' txtHoTen.Clear()
        ' ...
    End Sub

    Private Function ConvertStringToDate(text As String)
        Dim rawDate As String = text.Trim()

        If rawDate <> "" AndAlso rawDate.Length = 8 Then
            Return DateTime.ParseExact(rawDate,
                                                      "ddMMyyyy",
                                                      Globalization.CultureInfo.InvariantCulture)
        Else
            Return Nothing
        End If
    End Function

    Private Sub btnStartCam_Click(sender As Object, e As EventArgs) Handles btnStartCam.Click
        StartCamera()
    End Sub

    Private Sub btnStopCam_Click(sender As Object, e As EventArgs) Handles btnStopCam.Click
        StopCamera()
    End Sub

    Private Sub OnNewFrame(sender As Object, e As NewFrameEventArgs)
        Dim frame As Bitmap = CType(e.Frame.Clone(), Bitmap)

        ' Clone riêng cho hiển thị (preview)
        Dim preview As Bitmap = CType(frame.Clone(), Bitmap)

        ' Preview
        If PicCam.InvokeRequired Then
            PicCam.BeginInvoke(Sub()
                                   Dim oldImg As Image = PicCam.Image
                                   PicCam.Image = preview
                                   If oldImg IsNot Nothing Then oldImg.Dispose()
                               End Sub)
        Else
            Dim oldImg As Image = PicCam.Image
            PicCam.Image = preview
            If oldImg IsNot Nothing Then oldImg.Dispose()
        End If

        ' Lưu frame mới nhất (ghi đè)
        SyncLock Me
            latestFrame?.Dispose()
            latestFrame = frame
        End SyncLock
    End Sub

    ' ====== VÒNG DECODE NỀN: mỗi 250–300ms, chỉ xử lý frame mới nhất ======
    Private Sub DecodeLoop(token As CancellationToken)
        Dim sw As New Stopwatch()
        sw.Start()

        While Not token.IsCancellationRequested
            ' giới hạn nhịp decode ~300ms
            If sw.ElapsedMilliseconds < 300 OrElse decodingBusy Then
                Thread.Sleep(30)
                Continue While
            End If
            sw.Restart()

            Dim src As Bitmap = Nothing
            SyncLock Me
                If latestFrame IsNot Nothing Then
                    src = CType(latestFrame.Clone(), Bitmap)
                End If
            End SyncLock
            If src Is Nothing Then
                Thread.Sleep(10)
                Continue While
            End If

            decodingBusy = True
            Try
                Dim qrText As String = Nothing

                ' --- ROI: cắt giữa khung 50% ---
                Dim roi As New Rectangle(src.Width \ 4, src.Height \ 4, src.Width \ 2, src.Height \ 2)
                Using crop As Bitmap = src.Clone(roi, Imaging.PixelFormat.Format24bppRgb)

                    ' --- Upscale nếu nhỏ (<800px cạnh dài) để tăng sắc nét QR ---
                    Dim cand As Bitmap = crop
                    If Math.Max(crop.Width, crop.Height) < 800 Then
                        Dim s = 800.0 / Math.Max(crop.Width, crop.Height)
                        Dim w = CInt(crop.Width * s)
                        Dim h = CInt(crop.Height * s)
                        Dim up As New Bitmap(w, h)
                        Using g = Graphics.FromImage(up)
                            g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
                            g.SmoothingMode = Drawing2D.SmoothingMode.None
                            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
                            g.DrawImage(crop, New Rectangle(0, 0, w, h))
                        End Using
                        cand = up
                    End If

                    ' ZXing với TryHarder + QR_ONLY
                    Dim r As New ZXing.BarcodeReader() With {
                    .AutoRotate = True,
                    .TryInverted = True,
                    .Options = New ZXing.Common.DecodingOptions With {
                        .TryHarder = True,
                        .PossibleFormats = New List(Of ZXing.BarcodeFormat) From {ZXing.BarcodeFormat.QR_CODE}
                    }
                }

                    Dim res = r.Decode(cand)
                    If Not Object.ReferenceEquals(cand, crop) Then cand.Dispose()

                    ' Fallback: thử toàn khung nếu ROI không ra
                    If res Is Nothing Then
                        res = r.Decode(src)
                    End If

                    If res IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(res.Text) Then
                        qrText = res.Text
                    End If
                End Using

                If Not String.IsNullOrEmpty(qrText) Then
                    ' Đẩy về UI thread để parse và gán control
                    If Me.InvokeRequired Then
                        Me.BeginInvoke(Sub() ParseAndShow(qrText))
                    Else
                        ParseAndShow(qrText)
                    End If

                    ' Nếu muốn dừng ngay khi đọc được:
                    ' Me.BeginInvoke(Sub() StopCamera())
                    ' Exit While
                End If

            Catch
                ' ignore lỗi lẻ
            Finally
                src.Dispose()
                decodingBusy = False
            End Try
        End While
    End Sub

    Private Sub StartCamera()
        If devices Is Nothing OrElse devices.Count = 0 Then
            MessageBox.Show("Không tìm thấy camera.")
            Return
        End If

        ' Nếu đã có camera đang chạy thì tắt trước
        StopCamera()

        ' Lấy camera theo combo box
        Dim index As Integer = cbbChonCam.SelectedIndex
        If index < 0 Then index = 0

        video = New VideoCaptureDevice(devices(index).MonikerString)

        ' Ưu tiên 1280x720; nếu không có thì lấy 640x480 hoặc cấu hình lớn vừa phải
        Dim caps = video.VideoCapabilities
        Dim cap720 = caps.FirstOrDefault(Function(c) c.FrameSize.Width = 1280 AndAlso c.FrameSize.Height = 720)
        If cap720 IsNot Nothing Then
            video.VideoResolution = cap720
        Else
            Dim capVga = caps.FirstOrDefault(Function(c) c.FrameSize.Width >= 640 AndAlso c.FrameSize.Height >= 480)
            If capVga IsNot Nothing Then video.VideoResolution = capVga
        End If

        AddHandler video.NewFrame, AddressOf OnNewFrame
        video.Start()

        ' Vòng decode nền
        cts = New CancellationTokenSource()
        decodeTask = Task.Run(Sub() DecodeLoop(cts.Token), cts.Token)
    End Sub

    Private Sub StopCamera()
        Try
            cts?.Cancel()
        Catch
        End Try

        If video IsNot Nothing Then
            RemoveHandler video.NewFrame, AddressOf OnNewFrame
            If video.IsRunning Then
                video.SignalToStop()
                video.WaitForStop()
            End If
            video = Nothing
        End If

        SyncLock Me
            latestFrame?.Dispose()
            latestFrame = Nothing
        End SyncLock
    End Sub

    Private Sub FrmCCCD_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If video IsNot Nothing AndAlso video.IsRunning Then
            video.SignalToStop()
            video.WaitForStop()
        End If
    End Sub

    Private Sub btnChup_Click(sender As Object, e As EventArgs) Handles btnChup.Click
        Dim snap As Bitmap = Nothing

        ' Lấy snapshot an toàn từ luồng camera
        SyncLock Me
            If latestFrame Is Nothing Then
                MessageBox.Show("Chưa có hình để lưu.")
                Exit Sub
            End If
            snap = CType(latestFrame.Clone(), Bitmap) ' <-- luôn clone
        End SyncLock

        ' Hiển thị ảnh chụp (dùng clone riêng cho PictureBox)
        If Picture.Image IsNot Nothing Then Picture.Image.Dispose()
        Picture.Image = CType(snap.Clone(), Bitmap)

        ' Chuyển sang byte[] và lưu SQL
        Dim imgBytes As Byte()
        Using ms As New MemoryStream()
            snap.Save(ms, Imaging.ImageFormat.Jpeg)   ' <-- lưu trên bản clone, không bị lock
            imgBytes = ms.ToArray()
        End Using
        snap.Dispose()
    End Sub

    Private Sub Factory_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Factory_ID.EditValueChanged
        tvcn.GetDataOnDropDownCategoryCodeName(departmentcode, kn.ReadData("select * from [dbo].[udf_Department]('','" + obj.Lan + "',1) where Code like N'" + Factory_ID.EditValue.ToString + "%'", "table"))
        'tvcn.GetDataOnDropDownCategoryCodeName(sectioncode, kn.ReadData("select * from [dbo].[udf_Section]('',null,'" + obj.Lan + "',1)", "table"))
    End Sub

    Private Sub departmentcode_EditValueChanged(sender As Object, e As EventArgs) Handles departmentcode.EditValueChanged
        tvcn.GetDataOnDropDownCategoryCodeName(sectioncode, kn.ReadData("select * from [dbo].[udf_Section]('',null,'" + obj.Lan + "',1) where Code like N'%" + departmentcode.EditValue.ToString + "%'", "table"))
    End Sub

    ''Load các bảng thông tin chi tiết
    'Private Sub LoadDetailInfor()
    '    If IsNothing(GridView1) = True Then
    '        tvcn.ClearTextInControlOnForm(UltraTabControl2)
    '        Exit Sub
    '    End If
    '    If Not IsNothing(GridView1.Columns("Employee_ID")) Then
    '        If IsNothing(Gridex1.GetRow()) Then
    '            tvcn.ClearTextInControlOnForm(UltraTabControl2)
    '            Exit Sub
    '        End If
    '        If IsNothing(GridView1.GetFocusedRow().row("Employee_ID")) = True Then
    '            tvcn.ClearTextInControlOnForm(UltraTabControl2)
    '            Exit Sub
    '        End If
    '        If IsNothing(GridView1.GetFocusedRow().row("Employee_ID")) = True Then
    '            tvcn.ClearTextInControlOnForm(UltraTabControl2)
    '            Exit Sub
    '        End If
    '        NhapDuLieuLenForm(Gridex1.GetRow().Cells("Employee_ID").Value)
    '    End If
    'End Sub

End Class