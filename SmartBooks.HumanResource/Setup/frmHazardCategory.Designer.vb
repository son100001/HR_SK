<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHazardCategory
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
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.lblToxicPercent = New System.Windows.Forms.Label()
        Me.ToxicPercent = New System.Windows.Forms.NumericUpDown()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblHAZARD = New System.Windows.Forms.Label()
        Me.HAZARD = New System.Windows.Forms.TextBox()
        Me.NameVN = New System.Windows.Forms.TextBox()
        Me.lblNameVN = New System.Windows.Forms.Label()
        Me.NameKR = New System.Windows.Forms.TextBox()
        Me.lblNameKR = New System.Windows.Forms.Label()
        Me.NameEN = New System.Windows.Forms.TextBox()
        Me.lblNameEN = New System.Windows.Forms.Label()
        Me.pnLuu = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.pnDuLieuNhap.SuspendLayout()
        CType(Me.ToxicPercent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 383)
        Me.PanelButton.Size = New System.Drawing.Size(1085, 51)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1085, 434)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1083, 409)
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
        Me.GridControl1.Size = New System.Drawing.Size(1079, 260)
        Me.GridControl1.TabIndex = 1322
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
        Me.TableLayoutPanel3.Controls.Add(Me.pnDuLieuNhap, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.pnLuu, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1083, 94)
        Me.TableLayoutPanel3.TabIndex = 1321
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.lblToxicPercent)
        Me.pnDuLieuNhap.Controls.Add(Me.ToxicPercent)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblHAZARD)
        Me.pnDuLieuNhap.Controls.Add(Me.HAZARD)
        Me.pnDuLieuNhap.Controls.Add(Me.NameVN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNameVN)
        Me.pnDuLieuNhap.Controls.Add(Me.NameKR)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNameKR)
        Me.pnDuLieuNhap.Controls.Add(Me.NameEN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNameEN)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(5, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(1003, 86)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'lblToxicPercent
        '
        Me.lblToxicPercent.BackColor = System.Drawing.Color.Transparent
        Me.lblToxicPercent.Location = New System.Drawing.Point(4, 34)
        Me.lblToxicPercent.Name = "lblToxicPercent"
        Me.lblToxicPercent.Size = New System.Drawing.Size(128, 23)
        Me.lblToxicPercent.TabIndex = 338
        Me.lblToxicPercent.Text = "Phần trăm độc hại"
        Me.lblToxicPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToxicPercent
        '
        Me.ToxicPercent.Location = New System.Drawing.Point(138, 35)
        Me.ToxicPercent.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.ToxicPercent.Name = "ToxicPercent"
        Me.ToxicPercent.Size = New System.Drawing.Size(128, 21)
        Me.ToxicPercent.TabIndex = 3
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.Color.Transparent
        Me.lblRemark.Location = New System.Drawing.Point(676, 32)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(82, 19)
        Me.lblRemark.TabIndex = 336
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(764, 10)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(184, 67)
        Me.Remark.TabIndex = 11
        Me.Remark.Text = ""
        '
        'lblHAZARD
        '
        Me.lblHAZARD.BackColor = System.Drawing.Color.Transparent
        Me.lblHAZARD.Location = New System.Drawing.Point(4, 10)
        Me.lblHAZARD.Name = "lblHAZARD"
        Me.lblHAZARD.Size = New System.Drawing.Size(130, 19)
        Me.lblHAZARD.TabIndex = 335
        Me.lblHAZARD.Text = "Mã nặng nhọc"
        Me.lblHAZARD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HAZARD
        '
        Me.HAZARD.Location = New System.Drawing.Point(138, 9)
        Me.HAZARD.Name = "HAZARD"
        Me.HAZARD.Size = New System.Drawing.Size(128, 21)
        Me.HAZARD.TabIndex = 1
        '
        'NameVN
        '
        Me.NameVN.Location = New System.Drawing.Point(395, 9)
        Me.NameVN.Name = "NameVN"
        Me.NameVN.Size = New System.Drawing.Size(240, 21)
        Me.NameVN.TabIndex = 5
        '
        'lblNameVN
        '
        Me.lblNameVN.BackColor = System.Drawing.Color.Transparent
        Me.lblNameVN.Location = New System.Drawing.Point(292, 9)
        Me.lblNameVN.Name = "lblNameVN"
        Me.lblNameVN.Size = New System.Drawing.Size(88, 19)
        Me.lblNameVN.TabIndex = 333
        Me.lblNameVN.Text = "Tên (VN)"
        Me.lblNameVN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NameKR
        '
        Me.NameKR.Location = New System.Drawing.Point(395, 56)
        Me.NameKR.Name = "NameKR"
        Me.NameKR.Size = New System.Drawing.Size(240, 21)
        Me.NameKR.TabIndex = 9
        '
        'lblNameKR
        '
        Me.lblNameKR.BackColor = System.Drawing.Color.Transparent
        Me.lblNameKR.Location = New System.Drawing.Point(293, 56)
        Me.lblNameKR.Name = "lblNameKR"
        Me.lblNameKR.Size = New System.Drawing.Size(88, 19)
        Me.lblNameKR.TabIndex = 332
        Me.lblNameKR.Text = "Tên (KR)"
        Me.lblNameKR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NameEN
        '
        Me.NameEN.Location = New System.Drawing.Point(395, 32)
        Me.NameEN.Name = "NameEN"
        Me.NameEN.Size = New System.Drawing.Size(240, 21)
        Me.NameEN.TabIndex = 7
        '
        'lblNameEN
        '
        Me.lblNameEN.BackColor = System.Drawing.Color.Transparent
        Me.lblNameEN.Location = New System.Drawing.Point(293, 32)
        Me.lblNameEN.Name = "lblNameEN"
        Me.lblNameEN.Size = New System.Drawing.Size(88, 19)
        Me.lblNameEN.TabIndex = 331
        Me.lblNameEN.Text = "Tên (EN)"
        Me.lblNameEN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1015, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 86)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 7)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 31
        Me.btnSave.Text = "Lưu"
        '
        'frmHazardCategory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1085, 434)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "HR_HazardCategory"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmHazardCategory"
        Me.Text = "frmHazardCategory"
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
        Me.pnDuLieuNhap.ResumeLayout(False)
        Me.pnDuLieuNhap.PerformLayout()
        CType(Me.ToxicPercent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents lblToxicPercent As Label
    Friend WithEvents ToxicPercent As NumericUpDown
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblHAZARD As Label
    Friend WithEvents HAZARD As TextBox
    Friend WithEvents NameVN As TextBox
    Friend WithEvents lblNameVN As Label
    Friend WithEvents NameKR As TextBox
    Friend WithEvents lblNameKR As Label
    Friend WithEvents NameEN As TextBox
    Friend WithEvents lblNameEN As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
