<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetUpFollowDate
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
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.Code = New System.Windows.Forms.TextBox()
        Me.Group_ = New System.Windows.Forms.TextBox()
        Me.FromDate = New DevExpress.XtraEditors.DateEdit()
        Me.ToDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.lblGroup_ = New System.Windows.Forms.Label()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblTodate = New System.Windows.Forms.Label()
        Me.cbTodate = New System.Windows.Forms.CheckBox()
        Me.lblFromdate = New System.Windows.Forms.Label()
        Me.Value = New System.Windows.Forms.TextBox()
        Me.lblValue = New System.Windows.Forms.Label()
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
        CType(Me.FromDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 391)
        Me.PanelButton.Size = New System.Drawing.Size(1109, 49)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1109, 440)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1107, 415)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(0, 91)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1105, 273)
        Me.GridControl1.TabIndex = 1325
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoScroll = True
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1107, 85)
        Me.TableLayoutPanel3.TabIndex = 1324
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.Code)
        Me.pnDuLieuNhap.Controls.Add(Me.Group_)
        Me.pnDuLieuNhap.Controls.Add(Me.FromDate)
        Me.pnDuLieuNhap.Controls.Add(Me.ToDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblCode)
        Me.pnDuLieuNhap.Controls.Add(Me.lblGroup_)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTodate)
        Me.pnDuLieuNhap.Controls.Add(Me.cbTodate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblFromdate)
        Me.pnDuLieuNhap.Controls.Add(Me.Value)
        Me.pnDuLieuNhap.Controls.Add(Me.lblValue)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(5, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(1017, 77)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'Code
        '
        Me.Code.Location = New System.Drawing.Point(123, 36)
        Me.Code.Name = "Code"
        Me.Code.Size = New System.Drawing.Size(240, 21)
        Me.Code.TabIndex = 332
        '
        'Group_
        '
        Me.Group_.Location = New System.Drawing.Point(123, 11)
        Me.Group_.Name = "Group_"
        Me.Group_.Size = New System.Drawing.Size(240, 21)
        Me.Group_.TabIndex = 331
        '
        'FromDate
        '
        Me.FromDate.EditValue = Nothing
        Me.FromDate.Location = New System.Drawing.Point(460, 35)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FromDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FromDate.Properties.DisplayFormat.FormatString = ""
        Me.FromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FromDate.Properties.EditFormat.FormatString = ""
        Me.FromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FromDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.FromDate.Properties.MaskSettings.Set("mask", "d")
        Me.FromDate.Properties.UseMaskAsDisplayFormat = True
        Me.FromDate.Size = New System.Drawing.Size(90, 20)
        Me.FromDate.TabIndex = 333
        '
        'ToDate
        '
        Me.ToDate.EditValue = Nothing
        Me.ToDate.Location = New System.Drawing.Point(665, 35)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ToDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ToDate.Properties.DisplayFormat.FormatString = ""
        Me.ToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ToDate.Properties.EditFormat.FormatString = ""
        Me.ToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ToDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.ToDate.Properties.MaskSettings.Set("mask", "d")
        Me.ToDate.Properties.UseMaskAsDisplayFormat = True
        Me.ToDate.Size = New System.Drawing.Size(99, 20)
        Me.ToDate.TabIndex = 334
        '
        'lblCode
        '
        Me.lblCode.BackColor = System.Drawing.Color.Transparent
        Me.lblCode.Location = New System.Drawing.Point(7, 36)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(110, 19)
        Me.lblCode.TabIndex = 330
        Me.lblCode.Text = "Mã"
        Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGroup_
        '
        Me.lblGroup_.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup_.Location = New System.Drawing.Point(7, 12)
        Me.lblGroup_.Name = "lblGroup_"
        Me.lblGroup_.Size = New System.Drawing.Size(110, 19)
        Me.lblGroup_.TabIndex = 329
        Me.lblGroup_.Text = "Nhóm"
        Me.lblGroup_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemark
        '
        Me.lblRemark.Location = New System.Drawing.Point(786, 27)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(100, 16)
        Me.lblRemark.TabIndex = 326
        Me.lblRemark.Text = "Ghi chú"
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(894, 6)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(120, 62)
        Me.Remark.TabIndex = 13
        Me.Remark.Text = ""
        '
        'lblTodate
        '
        Me.lblTodate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTodate.Location = New System.Drawing.Point(556, 32)
        Me.lblTodate.Name = "lblTodate"
        Me.lblTodate.Size = New System.Drawing.Size(83, 20)
        Me.lblTodate.TabIndex = 324
        Me.lblTodate.Text = "Đến ngày"
        Me.lblTodate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbTodate
        '
        Me.cbTodate.Location = New System.Drawing.Point(643, 32)
        Me.cbTodate.Name = "cbTodate"
        Me.cbTodate.Size = New System.Drawing.Size(16, 24)
        Me.cbTodate.TabIndex = 9
        '
        'lblFromdate
        '
        Me.lblFromdate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFromdate.Location = New System.Drawing.Point(380, 34)
        Me.lblFromdate.Name = "lblFromdate"
        Me.lblFromdate.Size = New System.Drawing.Size(74, 20)
        Me.lblFromdate.TabIndex = 321
        Me.lblFromdate.Text = "Từ ngày"
        Me.lblFromdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Value
        '
        Me.Value.Location = New System.Drawing.Point(460, 9)
        Me.Value.Name = "Value"
        Me.Value.Size = New System.Drawing.Size(240, 21)
        Me.Value.TabIndex = 5
        '
        'lblValue
        '
        Me.lblValue.BackColor = System.Drawing.Color.Transparent
        Me.lblValue.Location = New System.Drawing.Point(380, 9)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(74, 19)
        Me.lblValue.TabIndex = 309
        Me.lblValue.Text = "Giá trị"
        Me.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1029, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 34
        Me.btnSave.Text = "Lưu"
        '
        'frmSetUpFollowDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1109, 440)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "HR_SetUpFollowDate"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmSetUpFollowDate"
        Me.Text = "frmSetUpFollowDate"
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
        CType(Me.FromDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    'Friend WithEvents FromDate As DevExpress.XtraEditors.DateEdit
    'Friend WithEvents ToDate As DevExpress.XtraEditors.DateEdit
    'Friend WithEvents Code As DevExpress.XtraEditors.LookUpEdit
    'Friend WithEvents Group_ As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents lblCode As Label
    Friend WithEvents lblGroup_ As Label
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblTodate As Label
    Friend WithEvents cbTodate As CheckBox
    Friend WithEvents lblFromdate As Label
    Friend WithEvents Value As TextBox
    Friend WithEvents lblValue As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Code As TextBox
    Friend WithEvents Group_ As TextBox
    Friend WithEvents FromDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ToDate As DevExpress.XtraEditors.DateEdit
    'Friend WithEvents ToDate As DevExpress.XtraEditors.DateEdit
    'Friend WithEvents FromDate As DevExpress.XtraEditors.DateEdit
    'Friend WithEvents Code As TextBox
    'Friend WithEvents Group_ As TextBox
End Class
