<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalary_Name
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
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnLuu = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.PIT = New System.Windows.Forms.CheckBox()
        Me.Name_KR = New System.Windows.Forms.TextBox()
        Me.lblName_KR = New System.Windows.Forms.Label()
        Me.Name_EN = New System.Windows.Forms.TextBox()
        Me.Name_VN = New System.Windows.Forms.TextBox()
        Me.lblName_EN = New System.Windows.Forms.Label()
        Me.lblName_VN = New System.Windows.Forms.Label()
        Me.Salary = New System.Windows.Forms.TextBox()
        Me.lblSalary = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.pnLuu.SuspendLayout()
        Me.pnDuLieuNhap.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 399)
        Me.PanelButton.Size = New System.Drawing.Size(1145, 49)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1145, 448)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1143, 423)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 96)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1139, 276)
        Me.GridControl1.TabIndex = 1319
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.pnLuu, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.pnDuLieuNhap, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1143, 94)
        Me.TableLayoutPanel3.TabIndex = 1318
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(883, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1327
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 70
        Me.btnSave.Text = "Lưu"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.PIT)
        Me.pnDuLieuNhap.Controls.Add(Me.Name_KR)
        Me.pnDuLieuNhap.Controls.Add(Me.lblName_KR)
        Me.pnDuLieuNhap.Controls.Add(Me.Name_EN)
        Me.pnDuLieuNhap.Controls.Add(Me.Name_VN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblName_EN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblName_VN)
        Me.pnDuLieuNhap.Controls.Add(Me.Salary)
        Me.pnDuLieuNhap.Controls.Add(Me.lblSalary)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(5, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(871, 86)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.Color.Transparent
        Me.lblRemark.Location = New System.Drawing.Point(601, 5)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(87, 19)
        Me.lblRemark.TabIndex = 197
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(694, 3)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(160, 56)
        Me.Remark.TabIndex = 11
        Me.Remark.Text = ""
        '
        'PIT
        '
        Me.PIT.Location = New System.Drawing.Point(100, 29)
        Me.PIT.Name = "PIT"
        Me.PIT.Size = New System.Drawing.Size(104, 24)
        Me.PIT.TabIndex = 3
        Me.PIT.Text = "Tính PIT"
        '
        'Name_KR
        '
        Me.Name_KR.Location = New System.Drawing.Point(338, 52)
        Me.Name_KR.Name = "Name_KR"
        Me.Name_KR.Size = New System.Drawing.Size(240, 21)
        Me.Name_KR.TabIndex = 9
        '
        'lblName_KR
        '
        Me.lblName_KR.BackColor = System.Drawing.Color.Transparent
        Me.lblName_KR.Location = New System.Drawing.Point(245, 44)
        Me.lblName_KR.Name = "lblName_KR"
        Me.lblName_KR.Size = New System.Drawing.Size(87, 24)
        Me.lblName_KR.TabIndex = 122
        Me.lblName_KR.Text = "Tên (KR)"
        Me.lblName_KR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Name_EN
        '
        Me.Name_EN.Location = New System.Drawing.Point(338, 28)
        Me.Name_EN.Name = "Name_EN"
        Me.Name_EN.Size = New System.Drawing.Size(240, 21)
        Me.Name_EN.TabIndex = 7
        '
        'Name_VN
        '
        Me.Name_VN.Location = New System.Drawing.Point(338, 4)
        Me.Name_VN.Name = "Name_VN"
        Me.Name_VN.Size = New System.Drawing.Size(240, 21)
        Me.Name_VN.TabIndex = 5
        '
        'lblName_EN
        '
        Me.lblName_EN.BackColor = System.Drawing.Color.Transparent
        Me.lblName_EN.Location = New System.Drawing.Point(245, 28)
        Me.lblName_EN.Name = "lblName_EN"
        Me.lblName_EN.Size = New System.Drawing.Size(87, 16)
        Me.lblName_EN.TabIndex = 121
        Me.lblName_EN.Text = "Tên (EN)"
        Me.lblName_EN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblName_VN
        '
        Me.lblName_VN.BackColor = System.Drawing.Color.Transparent
        Me.lblName_VN.Location = New System.Drawing.Point(245, 4)
        Me.lblName_VN.Name = "lblName_VN"
        Me.lblName_VN.Size = New System.Drawing.Size(87, 19)
        Me.lblName_VN.TabIndex = 120
        Me.lblName_VN.Text = "Tên (VN)"
        Me.lblName_VN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Salary
        '
        Me.Salary.Location = New System.Drawing.Point(100, 3)
        Me.Salary.Name = "Salary"
        Me.Salary.Size = New System.Drawing.Size(133, 21)
        Me.Salary.TabIndex = 1
        '
        'lblSalary
        '
        Me.lblSalary.BackColor = System.Drawing.Color.Transparent
        Me.lblSalary.Location = New System.Drawing.Point(4, 4)
        Me.lblSalary.Name = "lblSalary"
        Me.lblSalary.Size = New System.Drawing.Size(90, 19)
        Me.lblSalary.TabIndex = 113
        Me.lblSalary.Text = "Mã"
        Me.lblSalary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmSalary_Name
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 448)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "SmartBooks_Salary_Name"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmSalary_Name"
        Me.Text = "frmSalary_Name"
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.pnLuu.ResumeLayout(False)
        Me.pnDuLieuNhap.ResumeLayout(False)
        Me.pnDuLieuNhap.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents PIT As CheckBox
    Friend WithEvents Name_KR As TextBox
    Friend WithEvents lblName_KR As Label
    Friend WithEvents Name_EN As TextBox
    Friend WithEvents Name_VN As TextBox
    Friend WithEvents lblName_EN As Label
    Friend WithEvents lblName_VN As Label
    Friend WithEvents Salary As TextBox
    Friend WithEvents lblSalary As Label
End Class
