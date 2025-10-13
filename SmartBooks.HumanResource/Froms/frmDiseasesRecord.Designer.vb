<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDiseasesRecord
    Inherits WindowsControlLibrary.HRFORM

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnSearch = New System.Windows.Forms.Panel()
        Me.cbFind = New System.Windows.Forms.CheckBox()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.Employee_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.MedicalExaminationDay = New DevExpress.XtraEditors.DateEdit()
        Me.TypeOfDiseases = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblMedicalExaminationDay = New System.Windows.Forms.Label()
        Me.lblDetailOfDiseases = New System.Windows.Forms.Label()
        Me.DetailOfDiseases = New System.Windows.Forms.RichTextBox()
        Me.lblTypeOfDiseases = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.pnLuu = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnSearch.SuspendLayout()
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDuLieuNhap.SuspendLayout()
        CType(Me.MedicalExaminationDay.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MedicalExaminationDay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeOfDiseases.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 380)
        Me.PanelButton.Size = New System.Drawing.Size(1153, 54)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1153, 434)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1151, 409)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 101)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1147, 252)
        Me.GridControl1.TabIndex = 1323
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoScroll = True
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.pnSearch, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnDuLieuNhap, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnLuu, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1151, 99)
        Me.TableLayoutPanel2.TabIndex = 1302
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.cbFind)
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(226, 77)
        Me.pnSearch.TabIndex = 1327
        '
        'cbFind
        '
        Me.cbFind.AutoSize = True
        Me.cbFind.Location = New System.Drawing.Point(72, 52)
        Me.cbFind.Name = "cbFind"
        Me.cbFind.Size = New System.Drawing.Size(15, 14)
        Me.cbFind.TabIndex = 1357
        Me.cbFind.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(4, 50)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1227
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(3, 24)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Employee_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Employee_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Employee_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Employee_ID.Size = New System.Drawing.Size(220, 20)
        Me.Employee_ID.TabIndex = 1225
        '
        'lblEmployee_ID
        '
        Me.lblEmployee_ID.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployee_ID.Location = New System.Drawing.Point(7, 5)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(99, 23)
        Me.lblEmployee_ID.TabIndex = 1226
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.AutoScroll = True
        Me.pnDuLieuNhap.Controls.Add(Me.MedicalExaminationDay)
        Me.pnDuLieuNhap.Controls.Add(Me.TypeOfDiseases)
        Me.pnDuLieuNhap.Controls.Add(Me.lblMedicalExaminationDay)
        Me.pnDuLieuNhap.Controls.Add(Me.lblDetailOfDiseases)
        Me.pnDuLieuNhap.Controls.Add(Me.DetailOfDiseases)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTypeOfDiseases)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(237, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(619, 91)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'MedicalExaminationDay
        '
        Me.MedicalExaminationDay.EditValue = Nothing
        Me.MedicalExaminationDay.Location = New System.Drawing.Point(404, 8)
        Me.MedicalExaminationDay.Name = "MedicalExaminationDay"
        Me.MedicalExaminationDay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MedicalExaminationDay.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MedicalExaminationDay.Properties.DisplayFormat.FormatString = ""
        Me.MedicalExaminationDay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.MedicalExaminationDay.Properties.EditFormat.FormatString = ""
        Me.MedicalExaminationDay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.MedicalExaminationDay.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.MedicalExaminationDay.Properties.MaskSettings.Set("mask", "d")
        Me.MedicalExaminationDay.Properties.UseMaskAsDisplayFormat = True
        Me.MedicalExaminationDay.Size = New System.Drawing.Size(196, 20)
        Me.MedicalExaminationDay.TabIndex = 1356
        '
        'TypeOfDiseases
        '
        Me.TypeOfDiseases.Location = New System.Drawing.Point(112, 8)
        Me.TypeOfDiseases.Name = "TypeOfDiseases"
        Me.TypeOfDiseases.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.TypeOfDiseases.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TypeOfDiseases.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.TypeOfDiseases.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TypeOfDiseases.Size = New System.Drawing.Size(143, 20)
        Me.TypeOfDiseases.TabIndex = 1355
        '
        'lblMedicalExaminationDay
        '
        Me.lblMedicalExaminationDay.BackColor = System.Drawing.SystemColors.Control
        Me.lblMedicalExaminationDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblMedicalExaminationDay.Location = New System.Drawing.Point(261, 7)
        Me.lblMedicalExaminationDay.Name = "lblMedicalExaminationDay"
        Me.lblMedicalExaminationDay.Size = New System.Drawing.Size(137, 20)
        Me.lblMedicalExaminationDay.TabIndex = 1354
        Me.lblMedicalExaminationDay.Text = "Ngày khám bệnh"
        Me.lblMedicalExaminationDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDetailOfDiseases
        '
        Me.lblDetailOfDiseases.BackColor = System.Drawing.SystemColors.Control
        Me.lblDetailOfDiseases.Location = New System.Drawing.Point(3, 40)
        Me.lblDetailOfDiseases.Name = "lblDetailOfDiseases"
        Me.lblDetailOfDiseases.Size = New System.Drawing.Size(103, 19)
        Me.lblDetailOfDiseases.TabIndex = 1352
        Me.lblDetailOfDiseases.Text = "Chi tiết loại bệnh"
        '
        'DetailOfDiseases
        '
        Me.DetailOfDiseases.Location = New System.Drawing.Point(112, 37)
        Me.DetailOfDiseases.Name = "DetailOfDiseases"
        Me.DetailOfDiseases.Size = New System.Drawing.Size(143, 22)
        Me.DetailOfDiseases.TabIndex = 5
        Me.DetailOfDiseases.Text = ""
        '
        'lblTypeOfDiseases
        '
        Me.lblTypeOfDiseases.BackColor = System.Drawing.SystemColors.Control
        Me.lblTypeOfDiseases.Location = New System.Drawing.Point(3, 11)
        Me.lblTypeOfDiseases.Name = "lblTypeOfDiseases"
        Me.lblTypeOfDiseases.Size = New System.Drawing.Size(103, 18)
        Me.lblTypeOfDiseases.TabIndex = 1351
        Me.lblTypeOfDiseases.Text = "Loại bệnh"
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(404, 35)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(196, 53)
        Me.Remark.TabIndex = 7
        Me.Remark.Text = ""
        '
        'lblRemark
        '
        Me.lblRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblRemark.Location = New System.Drawing.Point(261, 36)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(137, 20)
        Me.lblRemark.TabIndex = 1348
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(863, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1328
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSave.Location = New System.Drawing.Point(0, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(59, 77)
        Me.btnSave.TabIndex = 70
        Me.btnSave.Text = "Lưu"
        '
        'frmDiseasesRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1153, 434)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_TableName = "HR_DiseasesRecord"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmDiseasesRecord"
        Me.Text = "frmDiseasesRecord"
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.pnSearch.ResumeLayout(False)
        Me.pnSearch.PerformLayout()
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDuLieuNhap.ResumeLayout(False)
        CType(Me.MedicalExaminationDay.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MedicalExaminationDay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeOfDiseases.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents lblMedicalExaminationDay As Label
    Friend WithEvents lblDetailOfDiseases As Label
    Friend WithEvents DetailOfDiseases As RichTextBox
    Friend WithEvents lblTypeOfDiseases As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblRemark As Label
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnSearch As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents TypeOfDiseases As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents MedicalExaminationDay As DevExpress.XtraEditors.DateEdit
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbFind As CheckBox
End Class
