<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegisterUser
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
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.cboGroup = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblGroup_ = New System.Windows.Forms.Label()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NhomQuyen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ChucNang = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.QuyenSua = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.QuyenXem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.cboGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 559)
        Me.PanelButton.Size = New System.Drawing.Size(1101, 51)
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.General
        Me.XtraTabControl1.Size = New System.Drawing.Size(1101, 559)
        Me.XtraTabControl1.TabIndex = 1010
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.btnSave)
        Me.General.Controls.Add(Me.cboGroup)
        Me.General.Controls.Add(Me.lblGroup_)
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1099, 534)
        Me.General.Text = "General"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(266, 6)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 1328
        Me.btnSave.Text = "Save"
        '
        'cboGroup
        '
        Me.cboGroup.Location = New System.Drawing.Point(160, 7)
        Me.cboGroup.Name = "cboGroup"
        Me.cboGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboGroup.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboGroup.Size = New System.Drawing.Size(100, 20)
        Me.cboGroup.TabIndex = 1327
        '
        'lblGroup_
        '
        Me.lblGroup_.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup_.Location = New System.Drawing.Point(10, 6)
        Me.lblGroup_.Name = "lblGroup_"
        Me.lblGroup_.Size = New System.Drawing.Size(144, 23)
        Me.lblGroup_.TabIndex = 1326
        Me.lblGroup_.Text = "Danh sách người dùng"
        Me.lblGroup_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(3, 35)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1094, 496)
        Me.GridControl1.TabIndex = 1322
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ID, Me.NhomQuyen, Me.ChucNang, Me.QuyenSua, Me.QuyenXem})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupCount = 1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.NhomQuyen, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ID
        '
        Me.ID.Caption = "ID"
        Me.ID.FieldName = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = True
        Me.ID.VisibleIndex = 0
        Me.ID.Width = 92
        '
        'NhomQuyen
        '
        Me.NhomQuyen.Caption = "Nhóm Quyền"
        Me.NhomQuyen.FieldName = "NhomQuyen"
        Me.NhomQuyen.Name = "NhomQuyen"
        Me.NhomQuyen.Visible = True
        Me.NhomQuyen.VisibleIndex = 1
        Me.NhomQuyen.Width = 247
        '
        'ChucNang
        '
        Me.ChucNang.Caption = "Chức Năng"
        Me.ChucNang.FieldName = "ChucNang"
        Me.ChucNang.Name = "ChucNang"
        Me.ChucNang.Visible = True
        Me.ChucNang.VisibleIndex = 1
        Me.ChucNang.Width = 545
        '
        'QuyenSua
        '
        Me.QuyenSua.Caption = "Quyền Sửa"
        Me.QuyenSua.FieldName = "QuyenSua"
        Me.QuyenSua.Name = "QuyenSua"
        Me.QuyenSua.Tag = True
        Me.QuyenSua.Visible = True
        Me.QuyenSua.VisibleIndex = 2
        Me.QuyenSua.Width = 224
        '
        'QuyenXem
        '
        Me.QuyenXem.Caption = "Quyền Xem"
        Me.QuyenXem.FieldName = "QuyenXem"
        Me.QuyenXem.Name = "QuyenXem"
        Me.QuyenXem.Tag = True
        Me.QuyenXem.Visible = True
        Me.QuyenXem.VisibleIndex = 3
        Me.QuyenXem.Width = 208
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1099, 2)
        Me.TableLayoutPanel2.TabIndex = 1321
        '
        'frmRegisterUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 610)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "Permission"
        Me.HRFORM_VisibleControl_ExportExcel = False
        Me.HRFORM_VisibleControl_GetTemplate = False
        Me.HRFORM_VisibleControl_ImportExcel = False
        Me.HRFORM_VisibleControl_Luu = False
        Me.HRFORM_VisibleControl_QuickPrint = False
        Me.HRFORM_VisibleControl_StatusBarFooter = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_VisibleControl_Xem = False
        Me.HRFORM_VisibleControl_Xoa = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmRegisterUser"
        Me.Text = "frmRegisterUser"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        CType(Me.cboGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NhomQuyen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ChucNang As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents QuyenSua As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents QuyenXem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblGroup_ As Label
    Friend WithEvents cboGroup As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
