<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalaryComponent
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
        Me.Amount = New System.Windows.Forms.TextBox()
        Me.SalaryComponent = New DevExpress.XtraEditors.LookUpEdit()
        Me.Year_ = New WindowsControlLibrary.Year()
        Me.Month_ = New WindowsControlLibrary.Month()
        Me.lblmonth = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.lblSalaryComponent = New System.Windows.Forms.Label()
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
        CType(Me.SalaryComponent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 290)
        Me.PanelButton.Size = New System.Drawing.Size(1170, 52)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1170, 290)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1168, 265)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 99)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1164, 164)
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
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.pnSearch, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnDuLieuNhap, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnLuu, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1168, 97)
        Me.TableLayoutPanel2.TabIndex = 1322
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(316, 89)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(9, 56)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1223
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(9, 32)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Employee_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Employee_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Employee_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Employee_ID.Size = New System.Drawing.Size(295, 20)
        Me.Employee_ID.TabIndex = 1220
        '
        'lblEmployee_ID
        '
        Me.lblEmployee_ID.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployee_ID.Location = New System.Drawing.Point(12, 12)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(99, 20)
        Me.lblEmployee_ID.TabIndex = 1222
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.Amount)
        Me.pnDuLieuNhap.Controls.Add(Me.SalaryComponent)
        Me.pnDuLieuNhap.Controls.Add(Me.Year_)
        Me.pnDuLieuNhap.Controls.Add(Me.Month_)
        Me.pnDuLieuNhap.Controls.Add(Me.lblmonth)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAmount)
        Me.pnDuLieuNhap.Controls.Add(Me.lblSalaryComponent)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(327, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(647, 89)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'Amount
        '
        Me.Amount.Location = New System.Drawing.Point(151, 34)
        Me.Amount.Name = "Amount"
        Me.Amount.Size = New System.Drawing.Size(168, 21)
        Me.Amount.TabIndex = 1288
        '
        'SalaryComponent
        '
        Me.SalaryComponent.Location = New System.Drawing.Point(151, 9)
        Me.SalaryComponent.Name = "SalaryComponent"
        Me.SalaryComponent.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.SalaryComponent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SalaryComponent.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.SalaryComponent.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.SalaryComponent.Size = New System.Drawing.Size(168, 20)
        Me.SalaryComponent.TabIndex = 1287
        '
        'Year_
        '
        Me.Year_.Location = New System.Drawing.Point(460, 7)
        Me.Year_.Name = "Year_"
        Me.Year_.Size = New System.Drawing.Size(65, 20)
        Me.Year_.TabIndex = 11
        '
        'Month_
        '
        Me.Month_.Location = New System.Drawing.Point(404, 7)
        Me.Month_.Name = "Month_"
        Me.Month_.Size = New System.Drawing.Size(61, 20)
        Me.Month_.TabIndex = 9
        '
        'lblmonth
        '
        Me.lblmonth.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmonth.Location = New System.Drawing.Point(334, 8)
        Me.lblmonth.Name = "lblmonth"
        Me.lblmonth.Size = New System.Drawing.Size(64, 20)
        Me.lblmonth.TabIndex = 1278
        Me.lblmonth.Text = "Tháng"
        Me.lblmonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAmount
        '
        Me.lblAmount.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.Location = New System.Drawing.Point(13, 33)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(104, 20)
        Me.lblAmount.TabIndex = 1275
        Me.lblAmount.Text = "Số tiền"
        Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSalaryComponent
        '
        Me.lblSalaryComponent.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalaryComponent.Location = New System.Drawing.Point(13, 9)
        Me.lblSalaryComponent.Name = "lblSalaryComponent"
        Me.lblSalaryComponent.Size = New System.Drawing.Size(132, 20)
        Me.lblSalaryComponent.TabIndex = 1274
        Me.lblSalaryComponent.Text = "Thành phần lương"
        Me.lblSalaryComponent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(402, 32)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(231, 40)
        Me.Remark.TabIndex = 15
        Me.Remark.Text = ""
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemark.Location = New System.Drawing.Point(334, 37)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(64, 16)
        Me.lblRemark.TabIndex = 1271
        Me.lblRemark.Text = "Ghi chú"
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(981, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 89)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 8)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 37
        Me.btnSave.Text = "Lưu"
        '
        'frmSalaryComponent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1170, 342)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_DeleteStore = "usp_DeleteHR_SalaryComponentFollowMonth"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_SalaryComponentFollowMonth"
        Me.HRFORM_TableName = "HR_SalaryComponentFollowMonth"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmSalaryComponent"
        Me.Text = "frmSalaryComponent"
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
        CType(Me.SalaryComponent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Amount As TextBox
    Friend WithEvents SalaryComponent As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Year_ As WindowsControlLibrary.Year
    Friend WithEvents Month_ As WindowsControlLibrary.Month
    Friend WithEvents lblmonth As Label
    Friend WithEvents lblAmount As Label
    Friend WithEvents lblSalaryComponent As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblRemark As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
