Imports WindowsControlLibrary
Public Class Salary_Parameter
    Inherits HRFORM

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ds As SmartBooks.BusinessLogic.SmartData
    Friend WithEvents flag As System.Windows.Forms.ImageList
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents lblExchangeRate As Label
    Friend WithEvents ExchangeRate As TextBox
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblMonth As Label
    Friend WithEvents Salary_Year As Year
    Friend WithEvents Salary_Month As Month
    Friend WithEvents WorkingDay1 As TextBox
    Friend WithEvents WorkingDay As TextBox
    Friend WithEvents lblWorkingDay1 As Label
    Friend WithEvents lblWorkingDay As Label
    Friend WithEvents pnNhap As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Salary_Parameter))
        Me.ds = New SmartBooks.BusinessLogic.SmartData()
        Me.flag = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.lblExchangeRate = New System.Windows.Forms.Label()
        Me.ExchangeRate = New System.Windows.Forms.TextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.Salary_Year = New WindowsControlLibrary.Year()
        Me.Salary_Month = New WindowsControlLibrary.Month()
        Me.WorkingDay1 = New System.Windows.Forms.TextBox()
        Me.WorkingDay = New System.Windows.Forms.TextBox()
        Me.lblWorkingDay1 = New System.Windows.Forms.Label()
        Me.lblWorkingDay = New System.Windows.Forms.Label()
        Me.pnNhap = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnDuLieuNhap.SuspendLayout()
        Me.pnNhap.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 444)
        Me.PanelButton.Size = New System.Drawing.Size(840, 50)
        '
        'ds
        '
        Me.ds.DataSetName = "SmartData"
        Me.ds.Locale = New System.Globalization.CultureInfo("en-US")
        Me.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'flag
        '
        Me.flag.ImageStream = CType(resources.GetObject("flag.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.flag.TransparentColor = System.Drawing.Color.Transparent
        Me.flag.Images.SetKeyName(0, "")
        Me.flag.Images.SetKeyName(1, "")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "")
        Me.ImageList1.Images.SetKeyName(10, "")
        Me.ImageList1.Images.SetKeyName(11, "")
        Me.ImageList1.Images.SetKeyName(12, "")
        Me.ImageList1.Images.SetKeyName(13, "")
        Me.ImageList1.Images.SetKeyName(14, "")
        Me.ImageList1.Images.SetKeyName(15, "")
        Me.ImageList1.Images.SetKeyName(16, "")
        Me.ImageList1.Images.SetKeyName(17, "")
        Me.ImageList1.Images.SetKeyName(18, "")
        Me.ImageList1.Images.SetKeyName(19, "")
        Me.ImageList1.Images.SetKeyName(20, "")
        Me.ImageList1.Images.SetKeyName(21, "")
        Me.ImageList1.Images.SetKeyName(22, "")
        Me.ImageList1.Images.SetKeyName(23, "")
        Me.ImageList1.Images.SetKeyName(24, "")
        Me.ImageList1.Images.SetKeyName(25, "")
        Me.ImageList1.Images.SetKeyName(26, "")
        Me.ImageList1.Images.SetKeyName(27, "")
        Me.ImageList1.Images.SetKeyName(28, "")
        Me.ImageList1.Images.SetKeyName(29, "")
        Me.ImageList1.Images.SetKeyName(30, "")
        Me.ImageList1.Images.SetKeyName(31, "")
        Me.ImageList1.Images.SetKeyName(32, "")
        Me.ImageList1.Images.SetKeyName(33, "")
        Me.ImageList1.Images.SetKeyName(34, "")
        Me.ImageList1.Images.SetKeyName(35, "")
        Me.ImageList1.Images.SetKeyName(36, "")
        Me.ImageList1.Images.SetKeyName(37, "")
        Me.ImageList1.Images.SetKeyName(38, "")
        Me.ImageList1.Images.SetKeyName(39, "")
        Me.ImageList1.Images.SetKeyName(40, "")
        Me.ImageList1.Images.SetKeyName(41, "")
        Me.ImageList1.Images.SetKeyName(42, "")
        Me.ImageList1.Images.SetKeyName(43, "")
        Me.ImageList1.Images.SetKeyName(44, "")
        Me.ImageList1.Images.SetKeyName(45, "")
        Me.ImageList1.Images.SetKeyName(46, "")
        Me.ImageList1.Images.SetKeyName(47, "")
        Me.ImageList1.Images.SetKeyName(48, "")
        Me.ImageList1.Images.SetKeyName(49, "")
        Me.ImageList1.Images.SetKeyName(50, "")
        Me.ImageList1.Images.SetKeyName(51, "")
        Me.ImageList1.Images.SetKeyName(52, "")
        Me.ImageList1.Images.SetKeyName(53, "")
        Me.ImageList1.Images.SetKeyName(54, "")
        Me.ImageList1.Images.SetKeyName(55, "")
        Me.ImageList1.Images.SetKeyName(56, "")
        Me.ImageList1.Images.SetKeyName(57, "")
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.General
        Me.XtraTabControl1.Size = New System.Drawing.Size(840, 444)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(838, 419)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(0, 81)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(836, 335)
        Me.GridControl1.TabIndex = 1307
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.pnDuLieuNhap, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnNhap, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(838, 86)
        Me.TableLayoutPanel2.TabIndex = 1306
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.lblExchangeRate)
        Me.pnDuLieuNhap.Controls.Add(Me.ExchangeRate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblMonth)
        Me.pnDuLieuNhap.Controls.Add(Me.Salary_Year)
        Me.pnDuLieuNhap.Controls.Add(Me.Salary_Month)
        Me.pnDuLieuNhap.Controls.Add(Me.WorkingDay1)
        Me.pnDuLieuNhap.Controls.Add(Me.WorkingDay)
        Me.pnDuLieuNhap.Controls.Add(Me.lblWorkingDay1)
        Me.pnDuLieuNhap.Controls.Add(Me.lblWorkingDay)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(4, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(645, 75)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'lblExchangeRate
        '
        Me.lblExchangeRate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExchangeRate.Location = New System.Drawing.Point(239, 4)
        Me.lblExchangeRate.Name = "lblExchangeRate"
        Me.lblExchangeRate.Size = New System.Drawing.Size(77, 20)
        Me.lblExchangeRate.TabIndex = 1054
        Me.lblExchangeRate.Text = "Số tiền"
        Me.lblExchangeRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ExchangeRate
        '
        Me.ExchangeRate.Location = New System.Drawing.Point(326, 4)
        Me.ExchangeRate.Name = "ExchangeRate"
        Me.ExchangeRate.Size = New System.Drawing.Size(168, 21)
        Me.ExchangeRate.TabIndex = 8
        '
        'lblRemark
        '
        Me.lblRemark.Location = New System.Drawing.Point(239, 44)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(73, 16)
        Me.lblRemark.TabIndex = 1053
        Me.lblRemark.Text = "Ghi chú"
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(326, 28)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(208, 43)
        Me.Remark.TabIndex = 10
        Me.Remark.Text = ""
        '
        'lblMonth
        '
        Me.lblMonth.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonth.Location = New System.Drawing.Point(5, 3)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(104, 20)
        Me.lblMonth.TabIndex = 1050
        Me.lblMonth.Text = "Tháng"
        Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Salary_Year
        '
        Me.Salary_Year.Location = New System.Drawing.Point(173, 3)
        Me.Salary_Year.Name = "Salary_Year"
        Me.Salary_Year.Size = New System.Drawing.Size(56, 20)
        Me.Salary_Year.TabIndex = 2
        '
        'Salary_Month
        '
        Me.Salary_Month.Location = New System.Drawing.Point(117, 3)
        Me.Salary_Month.Name = "Salary_Month"
        Me.Salary_Month.Size = New System.Drawing.Size(40, 20)
        Me.Salary_Month.TabIndex = 1
        '
        'WorkingDay1
        '
        Me.WorkingDay1.Location = New System.Drawing.Point(117, 51)
        Me.WorkingDay1.Name = "WorkingDay1"
        Me.WorkingDay1.Size = New System.Drawing.Size(96, 21)
        Me.WorkingDay1.TabIndex = 6
        '
        'WorkingDay
        '
        Me.WorkingDay.Location = New System.Drawing.Point(117, 27)
        Me.WorkingDay.Name = "WorkingDay"
        Me.WorkingDay.Size = New System.Drawing.Size(96, 21)
        Me.WorkingDay.TabIndex = 4
        '
        'lblWorkingDay1
        '
        Me.lblWorkingDay1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkingDay1.Location = New System.Drawing.Point(5, 51)
        Me.lblWorkingDay1.Name = "lblWorkingDay1"
        Me.lblWorkingDay1.Size = New System.Drawing.Size(104, 20)
        Me.lblWorkingDay1.TabIndex = 1049
        Me.lblWorkingDay1.Text = "WorkingDay1"
        Me.lblWorkingDay1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWorkingDay
        '
        Me.lblWorkingDay.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkingDay.Location = New System.Drawing.Point(5, 27)
        Me.lblWorkingDay.Name = "lblWorkingDay"
        Me.lblWorkingDay.Size = New System.Drawing.Size(104, 20)
        Me.lblWorkingDay.TabIndex = 1048
        Me.lblWorkingDay.Text = "WorkingDay"
        Me.lblWorkingDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnNhap
        '
        Me.pnNhap.Controls.Add(Me.btnSave)
        Me.pnNhap.Location = New System.Drawing.Point(656, 4)
        Me.pnNhap.Name = "pnNhap"
        Me.pnNhap.Size = New System.Drawing.Size(57, 78)
        Me.pnNhap.TabIndex = 1325
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(2, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 40
        Me.btnSave.Text = "Lưu"
        '
        'Salary_Parameter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(840, 494)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "SmartBooks_Salary_Parameter"
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "Salary_Parameter"
        Me.Text = "Salary Parameter"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.pnDuLieuNhap.ResumeLayout(False)
        Me.pnDuLieuNhap.PerformLayout()
        Me.pnNhap.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmDependentPerson_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Private Sub Gridex1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Public Overrides Sub AfterViewForm()
        GridView1.Columns.ColumnByFieldName("ExchangeRate").DisplayFormat.FormatString = "N2"
    End Sub
    Private Sub ExchangeRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExchangeRate.TextChanged
        If ExchangeRate.Text.Trim <> "0" Then
            Try
                ExchangeRate.Text = CDbl(ExchangeRate.Text).ToString("###,###") 'FormatCurrency(ExchangeRate.Text, 0).Replace("£", "").Replace("$", "")
                ExchangeRate.SelectionStart = ExchangeRate.Text.Length + 1
            Catch ex As Exception
                If ExchangeRate.Text.Length > 0 Then
                    MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Loidinhdangtien"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ExchangeRate.Text = ExchangeRate.Text.Remove(ExchangeRate.Text.Trim.Length - 1, 1)
                    ExchangeRate.SelectionStart = ExchangeRate.Text.Length + 1
                    ExchangeRate.Focus()
                End If
            End Try
        End If
    End Sub
    Private Sub Search()
        Dim QR As String = "select * from SmartBooks_Salary_Parameter"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub
End Class