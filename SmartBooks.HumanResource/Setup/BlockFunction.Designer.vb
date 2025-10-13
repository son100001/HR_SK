<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BlockFunction
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNhapNgayKhoa = New DevExpress.XtraEditors.SimpleButton()
        Me.Block_Date = New DevExpress.XtraEditors.DateEdit()
        Me.TableName = New DevExpress.XtraEditors.LookUpEdit()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblBlock_Date = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.Block_Date.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Block_Date.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TableName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 415)
        Me.PanelButton.Size = New System.Drawing.Size(969, 49)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(969, 415)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.Panel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(967, 390)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 214)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(967, 176)
        Me.GridControl1.TabIndex = 16
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnNhapNgayKhoa)
        Me.Panel2.Controls.Add(Me.Block_Date)
        Me.Panel2.Controls.Add(Me.TableName)
        Me.Panel2.Controls.Add(Me.GridControl2)
        Me.Panel2.Controls.Add(Me.lblRemark)
        Me.Panel2.Controls.Add(Me.Remark)
        Me.Panel2.Controls.Add(Me.lblBlock_Date)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(967, 214)
        Me.Panel2.TabIndex = 15
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(629, 113)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 64)
        Me.btnSave.TabIndex = 154
        Me.btnSave.Text = "(&S) Lưu"
        '
        'btnNhapNgayKhoa
        '
        Me.btnNhapNgayKhoa.Location = New System.Drawing.Point(757, 35)
        Me.btnNhapNgayKhoa.Name = "btnNhapNgayKhoa"
        Me.btnNhapNgayKhoa.Size = New System.Drawing.Size(94, 20)
        Me.btnNhapNgayKhoa.TabIndex = 153
        Me.btnNhapNgayKhoa.Text = "Nhập ngày khóa"
        '
        'Block_Date
        '
        Me.Block_Date.EditValue = Nothing
        Me.Block_Date.Location = New System.Drawing.Point(629, 35)
        Me.Block_Date.Name = "Block_Date"
        Me.Block_Date.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Block_Date.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Block_Date.Properties.DisplayFormat.FormatString = ""
        Me.Block_Date.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Block_Date.Properties.EditFormat.FormatString = ""
        Me.Block_Date.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Block_Date.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.Block_Date.Properties.MaskSettings.Set("mask", "d")
        Me.Block_Date.Properties.UseMaskAsDisplayFormat = True
        Me.Block_Date.Size = New System.Drawing.Size(114, 20)
        Me.Block_Date.TabIndex = 152
        '
        'TableName
        '
        Me.TableName.Location = New System.Drawing.Point(629, 9)
        Me.TableName.Name = "TableName"
        Me.TableName.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.TableName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TableName.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.TableName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TableName.Size = New System.Drawing.Size(224, 20)
        Me.TableName.TabIndex = 151
        '
        'GridControl2
        '
        Me.GridControl2.Location = New System.Drawing.Point(3, 3)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(495, 208)
        Me.GridControl2.TabIndex = 150
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        '
        'lblRemark
        '
        Me.lblRemark.Location = New System.Drawing.Point(504, 71)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(64, 23)
        Me.lblRemark.TabIndex = 145
        Me.lblRemark.Text = "Ghi chú"
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(629, 68)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(224, 39)
        Me.Remark.TabIndex = 7
        Me.Remark.Text = ""
        '
        'lblBlock_Date
        '
        Me.lblBlock_Date.Location = New System.Drawing.Point(504, 38)
        Me.lblBlock_Date.Name = "lblBlock_Date"
        Me.lblBlock_Date.Size = New System.Drawing.Size(100, 23)
        Me.lblBlock_Date.TabIndex = 143
        Me.lblBlock_Date.Text = "Ngày khóa"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(504, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 142
        Me.Label1.Text = "Chức năng"
        '
        'BlockFunction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 464)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_Khoa"
        Me.HRFORM_TableName = "HR_Khoa"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "BlockFunction"
        Me.Text = "BlockFunction"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.Block_Date.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Block_Date.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TableName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblBlock_Date As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNhapNgayKhoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Block_Date As DevExpress.XtraEditors.DateEdit
End Class
