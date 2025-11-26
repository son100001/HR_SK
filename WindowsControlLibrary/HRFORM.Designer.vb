<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HRFORM
    Inherits System.Windows.Forms.Form

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
        Me.PanelButton = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnRefreshLayout = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGetTemplate = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExportExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnImportExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExcute = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLuu = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.btnQuickPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSaveLayout = New DevExpress.XtraEditors.SimpleButton()
        Me.cbbReport = New System.Windows.Forms.ComboBox()
        Me.pnStatusForm = New System.Windows.Forms.Panel()
        Me.lblBottomDate = New System.Windows.Forms.Label()
        Me.lblBottomNumber4 = New System.Windows.Forms.Label()
        Me.lblBottomGetDate = New System.Windows.Forms.Label()
        Me.lblBottomNumber3 = New System.Windows.Forms.Label()
        Me.lblBottomCompany = New System.Windows.Forms.Label()
        Me.lblBottomNumber2 = New System.Windows.Forms.Label()
        Me.lblBottomCompanyName = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Loc = New System.Windows.Forms.ToolStripMenuItem()
        Me.HuyLoc = New System.Windows.Forms.ToolStripMenuItem()
        Me.HuyLocToanBo = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelButton.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnStatusForm.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Controls.Add(Me.TableLayoutPanel1)
        Me.PanelButton.Controls.Add(Me.pnStatusForm)
        Me.PanelButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelButton.Location = New System.Drawing.Point(0, 355)
        Me.PanelButton.Name = "PanelButton"
        Me.PanelButton.Size = New System.Drawing.Size(1283, 51)
        Me.PanelButton.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 14
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnRefreshLayout, 13, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnGetTemplate, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExportExcel, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnImportExcel, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExcute, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnRemove, 11, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnLuu, 10, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEdit, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAdd, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnRefresh, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnQuickPrint, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSaveLayout, 12, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbbReport, 4, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1283, 27)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'btnRefreshLayout
        '
        Me.btnRefreshLayout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshLayout.ImageOptions.Image = Global.WindowsControlLibrary.My.Resources.Resources.refreshpivottable_16x16
        Me.btnRefreshLayout.Location = New System.Drawing.Point(1259, 3)
        Me.btnRefreshLayout.Name = "btnRefreshLayout"
        Me.btnRefreshLayout.Size = New System.Drawing.Size(21, 21)
        Me.btnRefreshLayout.TabIndex = 178
        Me.btnRefreshLayout.ToolTip = "Refresh Layout"
        '
        'btnGetTemplate
        '
        Me.btnGetTemplate.ImageOptions.Image = Global.WindowsControlLibrary.My.Resources.Resources.exporttoxlsx_16x161
        Me.btnGetTemplate.Location = New System.Drawing.Point(3, 3)
        Me.btnGetTemplate.Name = "btnGetTemplate"
        Me.btnGetTemplate.Size = New System.Drawing.Size(103, 21)
        Me.btnGetTemplate.TabIndex = 12
        Me.btnGetTemplate.Text = "Lấy file mẫu"
        Me.btnGetTemplate.ToolTip = "Get Template"
        '
        'btnExportExcel
        '
        Me.btnExportExcel.ImageOptions.Image = Global.WindowsControlLibrary.My.Resources.Resources.exporttoxlsx_16x16
        Me.btnExportExcel.Location = New System.Drawing.Point(222, 3)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(99, 21)
        Me.btnExportExcel.TabIndex = 168
        Me.btnExportExcel.Text = "Xuất Excel"
        Me.btnExportExcel.ToolTip = "Export Excel"
        '
        'btnImportExcel
        '
        Me.btnImportExcel.ImageOptions.Image = Global.WindowsControlLibrary.My.Resources.Resources.importmap_16x161
        Me.btnImportExcel.Location = New System.Drawing.Point(112, 3)
        Me.btnImportExcel.Name = "btnImportExcel"
        Me.btnImportExcel.Size = New System.Drawing.Size(104, 21)
        Me.btnImportExcel.TabIndex = 167
        Me.btnImportExcel.Text = "Nhập Excel"
        Me.btnImportExcel.ToolTip = "Import Data"
        '
        'btnExcute
        '
        Me.btnExcute.ImageOptions.Image = Global.WindowsControlLibrary.My.Resources.Resources.play_16x16
        Me.btnExcute.Location = New System.Drawing.Point(641, 3)
        Me.btnExcute.Name = "btnExcute"
        Me.btnExcute.Size = New System.Drawing.Size(102, 21)
        Me.btnExcute.TabIndex = 169
        Me.btnExcute.Text = "Thực hiện"
        Me.btnExcute.ToolTip = "Excute"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.ImageOptions.Image = Global.WindowsControlLibrary.My.Resources.Resources.cancel_16x16
        Me.btnRemove.Location = New System.Drawing.Point(1152, 3)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(74, 21)
        Me.btnRemove.TabIndex = 174
        Me.btnRemove.Text = "(D) Xóa"
        Me.btnRemove.ToolTip = " Delete"
        '
        'btnLuu
        '
        Me.btnLuu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLuu.ImageOptions.Image = Global.WindowsControlLibrary.My.Resources.Resources.save_16x16
        Me.btnLuu.Location = New System.Drawing.Point(1072, 3)
        Me.btnLuu.Name = "btnLuu"
        Me.btnLuu.Size = New System.Drawing.Size(74, 21)
        Me.btnLuu.TabIndex = 173
        Me.btnLuu.Text = "(S) Lưu"
        Me.btnLuu.ToolTip = "Save"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.ImageOptions.Image = Global.WindowsControlLibrary.My.Resources.Resources.edit_16x16
        Me.btnEdit.Location = New System.Drawing.Point(992, 3)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(74, 21)
        Me.btnEdit.TabIndex = 172
        Me.btnEdit.Text = "Sửa"
        Me.btnEdit.ToolTip = "Edit"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.ImageOptions.Image = Global.WindowsControlLibrary.My.Resources.Resources.add_16x16
        Me.btnAdd.Location = New System.Drawing.Point(912, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(74, 21)
        Me.btnAdd.TabIndex = 171
        Me.btnAdd.Text = "Thêm mới"
        Me.btnAdd.ToolTip = "Add"
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.ImageOptions.Image = Global.WindowsControlLibrary.My.Resources.Resources.refreshallpivottable_16x16
        Me.btnRefresh.Location = New System.Drawing.Point(832, 3)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(74, 21)
        Me.btnRefresh.TabIndex = 170
        Me.btnRefresh.Text = "Xem"
        Me.btnRefresh.ToolTip = "View"
        '
        'btnQuickPrint
        '
        Me.btnQuickPrint.ImageOptions.Image = Global.WindowsControlLibrary.My.Resources.Resources.printquick_16x16
        Me.btnQuickPrint.Location = New System.Drawing.Point(327, 3)
        Me.btnQuickPrint.Name = "btnQuickPrint"
        Me.btnQuickPrint.Size = New System.Drawing.Size(74, 21)
        Me.btnQuickPrint.TabIndex = 176
        Me.btnQuickPrint.Text = "In"
        Me.btnQuickPrint.ToolTip = "Quick Print"
        '
        'btnSaveLayout
        '
        Me.btnSaveLayout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveLayout.ImageOptions.Image = Global.WindowsControlLibrary.My.Resources.Resources.tight_16x16
        Me.btnSaveLayout.Location = New System.Drawing.Point(1232, 3)
        Me.btnSaveLayout.Name = "btnSaveLayout"
        Me.btnSaveLayout.Size = New System.Drawing.Size(21, 21)
        Me.btnSaveLayout.TabIndex = 177
        Me.btnSaveLayout.ToolTip = "Save Layout"
        '
        'cbbReport
        '
        Me.cbbReport.FormattingEnabled = True
        Me.cbbReport.Location = New System.Drawing.Point(407, 3)
        Me.cbbReport.Name = "cbbReport"
        Me.cbbReport.Size = New System.Drawing.Size(228, 21)
        Me.cbbReport.TabIndex = 2
        '
        'pnStatusForm
        '
        Me.pnStatusForm.Controls.Add(Me.lblBottomDate)
        Me.pnStatusForm.Controls.Add(Me.lblBottomNumber4)
        Me.pnStatusForm.Controls.Add(Me.lblBottomGetDate)
        Me.pnStatusForm.Controls.Add(Me.lblBottomNumber3)
        Me.pnStatusForm.Controls.Add(Me.lblBottomCompany)
        Me.pnStatusForm.Controls.Add(Me.lblBottomNumber2)
        Me.pnStatusForm.Controls.Add(Me.lblBottomCompanyName)
        Me.pnStatusForm.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnStatusForm.Location = New System.Drawing.Point(0, 30)
        Me.pnStatusForm.Name = "pnStatusForm"
        Me.pnStatusForm.Size = New System.Drawing.Size(1283, 21)
        Me.pnStatusForm.TabIndex = 1
        '
        'lblBottomDate
        '
        Me.lblBottomDate.AutoSize = True
        Me.lblBottomDate.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblBottomDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBottomDate.Location = New System.Drawing.Point(1020, 0)
        Me.lblBottomDate.Name = "lblBottomDate"
        Me.lblBottomDate.Size = New System.Drawing.Size(30, 13)
        Me.lblBottomDate.TabIndex = 6
        Me.lblBottomDate.Text = "Date"
        '
        'lblBottomNumber4
        '
        Me.lblBottomNumber4.AutoSize = True
        Me.lblBottomNumber4.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblBottomNumber4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBottomNumber4.Location = New System.Drawing.Point(1050, 0)
        Me.lblBottomNumber4.Name = "lblBottomNumber4"
        Me.lblBottomNumber4.Size = New System.Drawing.Size(14, 13)
        Me.lblBottomNumber4.TabIndex = 5
        Me.lblBottomNumber4.Text = ": "
        '
        'lblBottomGetDate
        '
        Me.lblBottomGetDate.AutoSize = True
        Me.lblBottomGetDate.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblBottomGetDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBottomGetDate.Location = New System.Drawing.Point(1064, 0)
        Me.lblBottomGetDate.Name = "lblBottomGetDate"
        Me.lblBottomGetDate.Size = New System.Drawing.Size(47, 13)
        Me.lblBottomGetDate.TabIndex = 4
        Me.lblBottomGetDate.Text = "GetDate"
        '
        'lblBottomNumber3
        '
        Me.lblBottomNumber3.AutoSize = True
        Me.lblBottomNumber3.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblBottomNumber3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBottomNumber3.Location = New System.Drawing.Point(1111, 0)
        Me.lblBottomNumber3.Name = "lblBottomNumber3"
        Me.lblBottomNumber3.Size = New System.Drawing.Size(17, 13)
        Me.lblBottomNumber3.TabIndex = 3
        Me.lblBottomNumber3.Text = " | "
        '
        'lblBottomCompany
        '
        Me.lblBottomCompany.AutoSize = True
        Me.lblBottomCompany.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblBottomCompany.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBottomCompany.Location = New System.Drawing.Point(1128, 0)
        Me.lblBottomCompany.Name = "lblBottomCompany"
        Me.lblBottomCompany.Size = New System.Drawing.Size(52, 13)
        Me.lblBottomCompany.TabIndex = 2
        Me.lblBottomCompany.Text = "Company"
        '
        'lblBottomNumber2
        '
        Me.lblBottomNumber2.AutoSize = True
        Me.lblBottomNumber2.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblBottomNumber2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBottomNumber2.Location = New System.Drawing.Point(1180, 0)
        Me.lblBottomNumber2.Name = "lblBottomNumber2"
        Me.lblBottomNumber2.Size = New System.Drawing.Size(14, 13)
        Me.lblBottomNumber2.TabIndex = 1
        Me.lblBottomNumber2.Text = ": "
        '
        'lblBottomCompanyName
        '
        Me.lblBottomCompanyName.AutoSize = True
        Me.lblBottomCompanyName.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblBottomCompanyName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBottomCompanyName.Location = New System.Drawing.Point(1194, 0)
        Me.lblBottomCompanyName.Name = "lblBottomCompanyName"
        Me.lblBottomCompanyName.Size = New System.Drawing.Size(89, 13)
        Me.lblBottomCompanyName.TabIndex = 0
        Me.lblBottomCompanyName.Text = "lblCompanyName"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Loc, Me.HuyLoc, Me.HuyLocToanBo})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(160, 70)
        '
        'Loc
        '
        Me.Loc.Name = "Loc"
        Me.Loc.Size = New System.Drawing.Size(159, 22)
        Me.Loc.Text = "Lọc"
        '
        'HuyLoc
        '
        Me.HuyLoc.Name = "HuyLoc"
        Me.HuyLoc.Size = New System.Drawing.Size(159, 22)
        Me.HuyLoc.Text = "Hủy Lọc"
        '
        'HuyLocToanBo
        '
        Me.HuyLocToanBo.Name = "HuyLocToanBo"
        Me.HuyLocToanBo.Size = New System.Drawing.Size(159, 22)
        Me.HuyLocToanBo.Text = "Hủy lọc toàn bộ"
        '
        'HRFORM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1283, 406)
        Me.Controls.Add(Me.PanelButton)
        Me.KeyPreview = True
        Me.Name = "HRFORM"
        Me.Text = "HRFORM"
        Me.PanelButton.ResumeLayout(False)
        Me.PanelButton.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnStatusForm.ResumeLayout(False)
        Me.pnStatusForm.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents PanelButton As Windows.Forms.Panel
    Public WithEvents ContextMenuStrip1 As Windows.Forms.ContextMenuStrip
    Public WithEvents Loc As Windows.Forms.ToolStripMenuItem
    Public WithEvents HuyLoc As Windows.Forms.ToolStripMenuItem
    Public WithEvents HuyLocToanBo As Windows.Forms.ToolStripMenuItem
    Public WithEvents cbbReport As Windows.Forms.ComboBox
    Public WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Public WithEvents btnImportExcel As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnExportExcel As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnExcute As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnRemove As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnLuu As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnRefresh As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnRefreshLayout As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnSaveLayout As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnGetTemplate As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnQuickPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnStatusForm As Windows.Forms.Panel
    Friend WithEvents lblBottomDate As Windows.Forms.Label
    Friend WithEvents lblBottomNumber4 As Windows.Forms.Label
    Friend WithEvents lblBottomGetDate As Windows.Forms.Label
    Friend WithEvents lblBottomNumber3 As Windows.Forms.Label
    Friend WithEvents lblBottomCompany As Windows.Forms.Label
    Friend WithEvents lblBottomNumber2 As Windows.Forms.Label
    Friend WithEvents lblBottomCompanyName As Windows.Forms.Label
End Class
