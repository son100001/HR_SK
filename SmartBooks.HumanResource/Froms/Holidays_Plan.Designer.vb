<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Holidays_Plan
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
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.H_date = New DevExpress.XtraEditors.DateEdit()
        Me.TypeOfLeave = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblGhiChu = New System.Windows.Forms.Label()
        Me.Description = New System.Windows.Forms.RichTextBox()
        Me.lblTypeOfLeave = New System.Windows.Forms.Label()
        Me.lblH_date = New System.Windows.Forms.Label()
        Me.pnNhap = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnDuLieuNhap.SuspendLayout()
        CType(Me.H_date.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.H_date.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeOfLeave.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnNhap.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 402)
        Me.PanelButton.Size = New System.Drawing.Size(1040, 54)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1040, 402)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1038, 377)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(3, 86)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1032, 289)
        Me.GridControl1.TabIndex = 1322
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1038, 86)
        Me.TableLayoutPanel2.TabIndex = 1321
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.H_date)
        Me.pnDuLieuNhap.Controls.Add(Me.TypeOfLeave)
        Me.pnDuLieuNhap.Controls.Add(Me.lblGhiChu)
        Me.pnDuLieuNhap.Controls.Add(Me.Description)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTypeOfLeave)
        Me.pnDuLieuNhap.Controls.Add(Me.lblH_date)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(4, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(789, 75)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'H_date
        '
        Me.H_date.EditValue = Nothing
        Me.H_date.Location = New System.Drawing.Point(163, 33)
        Me.H_date.Name = "H_date"
        Me.H_date.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.H_date.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.H_date.Properties.DisplayFormat.FormatString = ""
        Me.H_date.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.H_date.Properties.EditFormat.FormatString = ""
        Me.H_date.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.H_date.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.H_date.Properties.MaskSettings.Set("mask", "d")
        Me.H_date.Properties.UseMaskAsDisplayFormat = True
        Me.H_date.Size = New System.Drawing.Size(171, 20)
        Me.H_date.TabIndex = 3
        '
        'TypeOfLeave
        '
        Me.TypeOfLeave.Location = New System.Drawing.Point(163, 10)
        Me.TypeOfLeave.Name = "TypeOfLeave"
        Me.TypeOfLeave.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.TypeOfLeave.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TypeOfLeave.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.TypeOfLeave.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TypeOfLeave.Size = New System.Drawing.Size(171, 20)
        Me.TypeOfLeave.TabIndex = 1
        '
        'lblGhiChu
        '
        Me.lblGhiChu.Location = New System.Drawing.Point(453, 31)
        Me.lblGhiChu.Name = "lblGhiChu"
        Me.lblGhiChu.Size = New System.Drawing.Size(100, 16)
        Me.lblGhiChu.TabIndex = 245
        Me.lblGhiChu.Text = "Ghi chú"
        '
        'Description
        '
        Me.Description.Location = New System.Drawing.Point(565, 9)
        Me.Description.Name = "Description"
        Me.Description.Size = New System.Drawing.Size(208, 56)
        Me.Description.TabIndex = 5
        Me.Description.Text = ""
        '
        'lblTypeOfLeave
        '
        Me.lblTypeOfLeave.BackColor = System.Drawing.Color.Transparent
        Me.lblTypeOfLeave.Location = New System.Drawing.Point(5, 9)
        Me.lblTypeOfLeave.Name = "lblTypeOfLeave"
        Me.lblTypeOfLeave.Size = New System.Drawing.Size(152, 19)
        Me.lblTypeOfLeave.TabIndex = 243
        Me.lblTypeOfLeave.Text = "Loại nghỉ"
        Me.lblTypeOfLeave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblH_date
        '
        Me.lblH_date.BackColor = System.Drawing.Color.Transparent
        Me.lblH_date.Location = New System.Drawing.Point(5, 33)
        Me.lblH_date.Name = "lblH_date"
        Me.lblH_date.Size = New System.Drawing.Size(152, 19)
        Me.lblH_date.TabIndex = 242
        Me.lblH_date.Text = "Ngày"
        Me.lblH_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnNhap
        '
        Me.pnNhap.Controls.Add(Me.btnSave)
        Me.pnNhap.Location = New System.Drawing.Point(800, 4)
        Me.pnNhap.Name = "pnNhap"
        Me.pnNhap.Size = New System.Drawing.Size(57, 78)
        Me.pnNhap.TabIndex = 1325
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(2, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 37
        Me.btnSave.Text = "Lưu"
        '
        'Holidays_Plan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1040, 456)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "SmartBooks_HolidaysPlan"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "Holidays_Plan"
        Me.Text = "Holidays_Plan"
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
        Me.pnDuLieuNhap.ResumeLayout(False)
        CType(Me.H_date.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.H_date.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeOfLeave.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnNhap.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents H_date As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TypeOfLeave As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblGhiChu As Label
    Friend WithEvents Description As RichTextBox
    Friend WithEvents lblTypeOfLeave As Label
    Friend WithEvents lblH_date As Label
    Friend WithEvents pnNhap As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
