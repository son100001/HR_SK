<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapPhatAo
    Inherits WindowsControlLibrary.HRFORM

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnSearch = New System.Windows.Forms.Panel()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.Employee_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.Size = New DevExpress.XtraEditors.LookUpEdit()
        Me.DateIssued = New DevExpress.XtraEditors.DateEdit()
        Me.ReturnDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblReturnDate = New System.Windows.Forms.Label()
        Me.Number = New System.Windows.Forms.TextBox()
        Me.Color = New System.Windows.Forms.TextBox()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.lblNumber = New System.Windows.Forms.Label()
        Me.lblDateIssued = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
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
        CType(Me.Size.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateIssued.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateIssued.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReturnDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReturnDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 356)
        Me.PanelButton.Size = New System.Drawing.Size(1367, 50)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1367, 356)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1365, 331)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(1, 106)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1364, 230)
        Me.GridControl1.TabIndex = 1320
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1365, 104)
        Me.TableLayoutPanel2.TabIndex = 1319
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(316, 96)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(8, 53)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1224
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(7, 27)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Employee_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Employee_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Employee_ID.Size = New System.Drawing.Size(295, 20)
        Me.Employee_ID.TabIndex = 1
        '
        'lblEmployee_ID
        '
        Me.lblEmployee_ID.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployee_ID.Location = New System.Drawing.Point(5, 4)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(92, 23)
        Me.lblEmployee_ID.TabIndex = 1219
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.AutoScroll = True
        Me.pnDuLieuNhap.Controls.Add(Me.Size)
        Me.pnDuLieuNhap.Controls.Add(Me.DateIssued)
        Me.pnDuLieuNhap.Controls.Add(Me.ReturnDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblReturnDate)
        Me.pnDuLieuNhap.Controls.Add(Me.Number)
        Me.pnDuLieuNhap.Controls.Add(Me.Color)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblColor)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNumber)
        Me.pnDuLieuNhap.Controls.Add(Me.lblDateIssued)
        Me.pnDuLieuNhap.Controls.Add(Me.lblSize)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(327, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(746, 96)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'Size
        '
        Me.Size.Location = New System.Drawing.Point(79, 7)
        Me.Size.Name = "Size"
        Me.Size.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Size.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Size.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Size.Size = New System.Drawing.Size(111, 20)
        Me.Size.TabIndex = 5
        '
        'DateIssued
        '
        Me.DateIssued.EditValue = Nothing
        Me.DateIssued.Location = New System.Drawing.Point(320, 33)
        Me.DateIssued.Name = "DateIssued"
        Me.DateIssued.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateIssued.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateIssued.Properties.DisplayFormat.FormatString = ""
        Me.DateIssued.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateIssued.Properties.EditFormat.FormatString = ""
        Me.DateIssued.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateIssued.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.DateIssued.Properties.MaskSettings.Set("mask", "d")
        Me.DateIssued.Properties.UseMaskAsDisplayFormat = True
        Me.DateIssued.Size = New System.Drawing.Size(120, 20)
        Me.DateIssued.TabIndex = 11
        '
        'ReturnDate
        '
        Me.ReturnDate.EditValue = Nothing
        Me.ReturnDate.Location = New System.Drawing.Point(525, 7)
        Me.ReturnDate.Name = "ReturnDate"
        Me.ReturnDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ReturnDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ReturnDate.Properties.DisplayFormat.FormatString = ""
        Me.ReturnDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ReturnDate.Properties.EditFormat.FormatString = ""
        Me.ReturnDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ReturnDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.ReturnDate.Properties.MaskSettings.Set("mask", "d")
        Me.ReturnDate.Properties.UseMaskAsDisplayFormat = True
        Me.ReturnDate.Size = New System.Drawing.Size(120, 20)
        Me.ReturnDate.TabIndex = 13
        '
        'lblReturnDate
        '
        Me.lblReturnDate.BackColor = System.Drawing.Color.Transparent
        Me.lblReturnDate.Location = New System.Drawing.Point(440, 7)
        Me.lblReturnDate.Name = "lblReturnDate"
        Me.lblReturnDate.Size = New System.Drawing.Size(80, 19)
        Me.lblReturnDate.TabIndex = 1335
        Me.lblReturnDate.Text = "Ngày trả"
        Me.lblReturnDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Number
        '
        Me.Number.Location = New System.Drawing.Point(320, 6)
        Me.Number.Name = "Number"
        Me.Number.Size = New System.Drawing.Size(111, 21)
        Me.Number.TabIndex = 9
        '
        'Color
        '
        Me.Color.AcceptsReturn = True
        Me.Color.Location = New System.Drawing.Point(79, 33)
        Me.Color.Name = "Color"
        Me.Color.Size = New System.Drawing.Size(111, 21)
        Me.Color.TabIndex = 7
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(525, 32)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(168, 32)
        Me.Remark.TabIndex = 15
        Me.Remark.Text = ""
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemark.Location = New System.Drawing.Point(441, 35)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(78, 19)
        Me.lblRemark.TabIndex = 1334
        Me.lblRemark.Text = "Ghi chú"
        '
        'lblColor
        '
        Me.lblColor.BackColor = System.Drawing.SystemColors.Control
        Me.lblColor.Location = New System.Drawing.Point(11, 36)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(59, 18)
        Me.lblColor.TabIndex = 1333
        Me.lblColor.Text = "Màu sắc"
        '
        'lblNumber
        '
        Me.lblNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblNumber.Location = New System.Drawing.Point(216, 7)
        Me.lblNumber.Name = "lblNumber"
        Me.lblNumber.Size = New System.Drawing.Size(98, 18)
        Me.lblNumber.TabIndex = 1332
        Me.lblNumber.Text = "Số lượng"
        '
        'lblDateIssued
        '
        Me.lblDateIssued.BackColor = System.Drawing.SystemColors.Control
        Me.lblDateIssued.Location = New System.Drawing.Point(216, 35)
        Me.lblDateIssued.Name = "lblDateIssued"
        Me.lblDateIssued.Size = New System.Drawing.Size(98, 18)
        Me.lblDateIssued.TabIndex = 1331
        Me.lblDateIssued.Text = "Ngày cấp"
        '
        'lblSize
        '
        Me.lblSize.BackColor = System.Drawing.SystemColors.Control
        Me.lblSize.Location = New System.Drawing.Point(11, 10)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(62, 18)
        Me.lblSize.TabIndex = 1330
        Me.lblSize.Text = "Size"
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1080, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 30
        Me.btnSave.Text = "Lưu"
        '
        'frmCapPhatAo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1367, 406)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_DeleteStore = "usp_DeleteHR_CapPhatAo"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_CapPhatAo"
        Me.HRFORM_TableName = "HR_CapPhatAo"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmCapPhatAo"
        Me.Text = "frmCapPhatAo"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.pnSearch.ResumeLayout(False)
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDuLieuNhap.ResumeLayout(False)
        Me.pnDuLieuNhap.PerformLayout()
        CType(Me.Size.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateIssued.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateIssued.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReturnDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReturnDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnSearch As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents Size As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents DateIssued As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ReturnDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblReturnDate As Label
    Friend WithEvents Number As TextBox
    Friend WithEvents Color As TextBox
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblRemark As Label
    Friend WithEvents lblColor As Label
    Friend WithEvents lblNumber As Label
    Friend WithEvents lblDateIssued As Label
    Friend WithEvents lblSize As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
