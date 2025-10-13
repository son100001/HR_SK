<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTrainingRecord
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
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.Employee_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.todate = New DevExpress.XtraEditors.DateEdit()
        Me.fromdate = New DevExpress.XtraEditors.DateEdit()
        Me.TrainingType = New DevExpress.XtraEditors.LookUpEdit()
        Me.TrainingRecordNo = New System.Windows.Forms.TextBox()
        Me.Trainer = New System.Windows.Forms.TextBox()
        Me.TrainingHour = New System.Windows.Forms.TextBox()
        Me.TrainingCost = New System.Windows.Forms.TextBox()
        Me.TrainingSubject = New System.Windows.Forms.TextBox()
        Me.Group = New System.Windows.Forms.TextBox()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.lblTrainingRecordNo = New System.Windows.Forms.Label()
        Me.lblTrainer = New System.Windows.Forms.Label()
        Me.lblTrainingHour = New System.Windows.Forms.Label()
        Me.lblTrainingCost = New System.Windows.Forms.Label()
        Me.lblTrainingSubject = New System.Windows.Forms.Label()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.lblTrainingType = New System.Windows.Forms.Label()
        Me.cbtodate = New System.Windows.Forms.CheckBox()
        Me.lbltodate = New System.Windows.Forms.Label()
        Me.lblfromdate = New System.Windows.Forms.Label()
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
        CType(Me.todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.todate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fromdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrainingType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 374)
        Me.PanelButton.Size = New System.Drawing.Size(1311, 60)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1311, 374)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1309, 349)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 137)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1304, 210)
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1309, 135)
        Me.TableLayoutPanel2.TabIndex = 1302
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(226, 94)
        Me.pnSearch.TabIndex = 1327
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
        Me.pnDuLieuNhap.Controls.Add(Me.todate)
        Me.pnDuLieuNhap.Controls.Add(Me.fromdate)
        Me.pnDuLieuNhap.Controls.Add(Me.TrainingType)
        Me.pnDuLieuNhap.Controls.Add(Me.TrainingRecordNo)
        Me.pnDuLieuNhap.Controls.Add(Me.Trainer)
        Me.pnDuLieuNhap.Controls.Add(Me.TrainingHour)
        Me.pnDuLieuNhap.Controls.Add(Me.TrainingCost)
        Me.pnDuLieuNhap.Controls.Add(Me.TrainingSubject)
        Me.pnDuLieuNhap.Controls.Add(Me.Group)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTrainingRecordNo)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTrainer)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTrainingHour)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTrainingCost)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTrainingSubject)
        Me.pnDuLieuNhap.Controls.Add(Me.lblGroup)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTrainingType)
        Me.pnDuLieuNhap.Controls.Add(Me.cbtodate)
        Me.pnDuLieuNhap.Controls.Add(Me.lbltodate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblfromdate)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(237, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(746, 127)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'todate
        '
        Me.todate.EditValue = Nothing
        Me.todate.Location = New System.Drawing.Point(355, 36)
        Me.todate.Name = "todate"
        Me.todate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.todate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.todate.Properties.DisplayFormat.FormatString = ""
        Me.todate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.todate.Properties.EditFormat.FormatString = ""
        Me.todate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.todate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.todate.Properties.MaskSettings.Set("mask", "d")
        Me.todate.Properties.UseMaskAsDisplayFormat = True
        Me.todate.Size = New System.Drawing.Size(112, 20)
        Me.todate.TabIndex = 1351
        '
        'fromdate
        '
        Me.fromdate.EditValue = Nothing
        Me.fromdate.Location = New System.Drawing.Point(355, 7)
        Me.fromdate.Name = "fromdate"
        Me.fromdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.fromdate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.fromdate.Properties.DisplayFormat.FormatString = ""
        Me.fromdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.fromdate.Properties.EditFormat.FormatString = ""
        Me.fromdate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.fromdate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.fromdate.Properties.MaskSettings.Set("mask", "d")
        Me.fromdate.Properties.UseMaskAsDisplayFormat = True
        Me.fromdate.Size = New System.Drawing.Size(112, 20)
        Me.fromdate.TabIndex = 1350
        '
        'TrainingType
        '
        Me.TrainingType.Location = New System.Drawing.Point(115, 7)
        Me.TrainingType.Name = "TrainingType"
        Me.TrainingType.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.TrainingType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TrainingType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.TrainingType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TrainingType.Size = New System.Drawing.Size(112, 20)
        Me.TrainingType.TabIndex = 1303
        '
        'TrainingRecordNo
        '
        Me.TrainingRecordNo.Location = New System.Drawing.Point(609, 8)
        Me.TrainingRecordNo.Name = "TrainingRecordNo"
        Me.TrainingRecordNo.Size = New System.Drawing.Size(124, 21)
        Me.TrainingRecordNo.TabIndex = 12
        '
        'Trainer
        '
        Me.Trainer.Location = New System.Drawing.Point(355, 93)
        Me.Trainer.Name = "Trainer"
        Me.Trainer.Size = New System.Drawing.Size(112, 21)
        Me.Trainer.TabIndex = 11
        '
        'TrainingHour
        '
        Me.TrainingHour.Location = New System.Drawing.Point(355, 63)
        Me.TrainingHour.Name = "TrainingHour"
        Me.TrainingHour.Size = New System.Drawing.Size(112, 21)
        Me.TrainingHour.TabIndex = 10
        '
        'TrainingCost
        '
        Me.TrainingCost.Location = New System.Drawing.Point(115, 93)
        Me.TrainingCost.Name = "TrainingCost"
        Me.TrainingCost.Size = New System.Drawing.Size(112, 21)
        Me.TrainingCost.TabIndex = 6
        '
        'TrainingSubject
        '
        Me.TrainingSubject.Location = New System.Drawing.Point(115, 63)
        Me.TrainingSubject.Name = "TrainingSubject"
        Me.TrainingSubject.Size = New System.Drawing.Size(112, 21)
        Me.TrainingSubject.TabIndex = 5
        '
        'Group
        '
        Me.Group.Location = New System.Drawing.Point(115, 36)
        Me.Group.Name = "Group"
        Me.Group.Size = New System.Drawing.Size(112, 21)
        Me.Group.TabIndex = 4
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(500, 57)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(233, 58)
        Me.Remark.TabIndex = 13
        Me.Remark.Text = ""
        '
        'lblRemark
        '
        Me.lblRemark.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemark.Location = New System.Drawing.Point(497, 33)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(106, 20)
        Me.lblRemark.TabIndex = 1348
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTrainingRecordNo
        '
        Me.lblTrainingRecordNo.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrainingRecordNo.Location = New System.Drawing.Point(497, 7)
        Me.lblTrainingRecordNo.Name = "lblTrainingRecordNo"
        Me.lblTrainingRecordNo.Size = New System.Drawing.Size(106, 20)
        Me.lblTrainingRecordNo.TabIndex = 1347
        Me.lblTrainingRecordNo.Text = "Khóa đào tạo"
        Me.lblTrainingRecordNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTrainer
        '
        Me.lblTrainer.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrainer.Location = New System.Drawing.Point(244, 95)
        Me.lblTrainer.Name = "lblTrainer"
        Me.lblTrainer.Size = New System.Drawing.Size(105, 20)
        Me.lblTrainer.TabIndex = 1346
        Me.lblTrainer.Text = "Bên đào tạo"
        Me.lblTrainer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTrainingHour
        '
        Me.lblTrainingHour.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrainingHour.Location = New System.Drawing.Point(244, 57)
        Me.lblTrainingHour.Name = "lblTrainingHour"
        Me.lblTrainingHour.Size = New System.Drawing.Size(105, 37)
        Me.lblTrainingHour.TabIndex = 1345
        Me.lblTrainingHour.Text = "Thời gian huấn luyện"
        Me.lblTrainingHour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTrainingCost
        '
        Me.lblTrainingCost.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrainingCost.Location = New System.Drawing.Point(3, 95)
        Me.lblTrainingCost.Name = "lblTrainingCost"
        Me.lblTrainingCost.Size = New System.Drawing.Size(106, 20)
        Me.lblTrainingCost.TabIndex = 1344
        Me.lblTrainingCost.Text = "Phí đào tạo"
        Me.lblTrainingCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTrainingSubject
        '
        Me.lblTrainingSubject.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrainingSubject.Location = New System.Drawing.Point(3, 62)
        Me.lblTrainingSubject.Name = "lblTrainingSubject"
        Me.lblTrainingSubject.Size = New System.Drawing.Size(106, 20)
        Me.lblTrainingSubject.TabIndex = 1343
        Me.lblTrainingSubject.Text = "Nội dung"
        Me.lblTrainingSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGroup
        '
        Me.lblGroup.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.Location = New System.Drawing.Point(3, 33)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(106, 20)
        Me.lblGroup.TabIndex = 1342
        Me.lblGroup.Text = "Group"
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTrainingType
        '
        Me.lblTrainingType.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrainingType.Location = New System.Drawing.Point(3, 4)
        Me.lblTrainingType.Name = "lblTrainingType"
        Me.lblTrainingType.Size = New System.Drawing.Size(106, 24)
        Me.lblTrainingType.TabIndex = 1341
        Me.lblTrainingType.Text = "Kiểu huấn luyện"
        Me.lblTrainingType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbtodate
        '
        Me.cbtodate.Location = New System.Drawing.Point(339, 35)
        Me.cbtodate.Name = "cbtodate"
        Me.cbtodate.Size = New System.Drawing.Size(16, 24)
        Me.cbtodate.TabIndex = 8
        '
        'lbltodate
        '
        Me.lbltodate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltodate.Location = New System.Drawing.Point(244, 33)
        Me.lbltodate.Name = "lbltodate"
        Me.lbltodate.Size = New System.Drawing.Size(83, 20)
        Me.lbltodate.TabIndex = 1337
        Me.lbltodate.Text = "Đến ngày"
        Me.lbltodate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblfromdate
        '
        Me.lblfromdate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfromdate.Location = New System.Drawing.Point(244, 7)
        Me.lblfromdate.Name = "lblfromdate"
        Me.lblfromdate.Size = New System.Drawing.Size(83, 20)
        Me.lblfromdate.TabIndex = 1336
        Me.lblfromdate.Text = "Từ ngày"
        Me.lblfromdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(990, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1328
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 70
        Me.btnSave.Text = "Lưu"
        '
        'frmTrainingRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1311, 434)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "HR_TrainingRecord"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmTrainingRecord"
        Me.Text = "frmTrainingRecord"
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
        CType(Me.todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.todate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fromdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrainingType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents TrainingRecordNo As TextBox
    Friend WithEvents Trainer As TextBox
    Friend WithEvents TrainingHour As TextBox
    Friend WithEvents TrainingCost As TextBox
    Friend WithEvents TrainingSubject As TextBox
    Friend WithEvents Group As TextBox
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblRemark As Label
    Friend WithEvents lblTrainingRecordNo As Label
    Friend WithEvents lblTrainer As Label
    Friend WithEvents lblTrainingHour As Label
    Friend WithEvents lblTrainingCost As Label
    Friend WithEvents lblTrainingSubject As Label
    Friend WithEvents lblGroup As Label
    Friend WithEvents lblTrainingType As Label
    Friend WithEvents cbtodate As CheckBox
    Friend WithEvents lbltodate As Label
    Friend WithEvents lblfromdate As Label
    Friend WithEvents pnSearch As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TrainingType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents todate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents fromdate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
