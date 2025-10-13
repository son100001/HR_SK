<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTaoDieuChinhLoaiNghi
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
        Me.AbsentSign = New System.Windows.Forms.TextBox()
        Me.lblAbsentSign = New System.Windows.Forms.Label()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.NumberOfMonth = New System.Windows.Forms.TextBox()
        Me.NumberOfDate = New System.Windows.Forms.TextBox()
        Me.lblNumberOfMonth = New System.Windows.Forms.Label()
        Me.lblNumberOfDate = New System.Windows.Forms.Label()
        Me.isNghiKhamThai = New System.Windows.Forms.CheckBox()
        Me.isNghiTruPhepNam = New System.Windows.Forms.CheckBox()
        Me.isMiscarriage = New System.Windows.Forms.CheckBox()
        Me.isMaternityLeave = New System.Windows.Forms.CheckBox()
        Me.ShortTermLeave = New System.Windows.Forms.CheckBox()
        Me.LongTermLeaving = New System.Windows.Forms.CheckBox()
        Me.Termination = New System.Windows.Forms.CheckBox()
        Me.PhepNam = New System.Windows.Forms.CheckBox()
        Me.NotAllow = New System.Windows.Forms.CheckBox()
        Me.isLeave_ComPay = New System.Windows.Forms.CheckBox()
        Me.isLeave_InsPay = New System.Windows.Forms.CheckBox()
        Me.isLeave_nonPay = New System.Windows.Forms.CheckBox()
        Me.LeaveType_KR = New System.Windows.Forms.TextBox()
        Me.LeaveType_ID = New System.Windows.Forms.TextBox()
        Me.LeaveType_EN = New System.Windows.Forms.TextBox()
        Me.LeaveType_VN = New System.Windows.Forms.TextBox()
        Me.lblLeaveType_KR = New System.Windows.Forms.Label()
        Me.lblLeaveType_ID = New System.Windows.Forms.Label()
        Me.lblLeaveType_EN = New System.Windows.Forms.Label()
        Me.lblLeaveType_VN = New System.Windows.Forms.Label()
        Me.pnLuu = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.KhongTruCC = New System.Windows.Forms.CheckBox()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.pnDuLieuNhap.SuspendLayout()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 423)
        Me.PanelButton.Size = New System.Drawing.Size(1096, 52)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1096, 423)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1094, 398)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 164)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1089, 232)
        Me.GridControl1.TabIndex = 1326
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1094, 162)
        Me.TableLayoutPanel3.TabIndex = 1325
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.KhongTruCC)
        Me.pnDuLieuNhap.Controls.Add(Me.AbsentSign)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAbsentSign)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.NumberOfMonth)
        Me.pnDuLieuNhap.Controls.Add(Me.NumberOfDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNumberOfMonth)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNumberOfDate)
        Me.pnDuLieuNhap.Controls.Add(Me.isNghiKhamThai)
        Me.pnDuLieuNhap.Controls.Add(Me.isNghiTruPhepNam)
        Me.pnDuLieuNhap.Controls.Add(Me.isMiscarriage)
        Me.pnDuLieuNhap.Controls.Add(Me.isMaternityLeave)
        Me.pnDuLieuNhap.Controls.Add(Me.ShortTermLeave)
        Me.pnDuLieuNhap.Controls.Add(Me.LongTermLeaving)
        Me.pnDuLieuNhap.Controls.Add(Me.Termination)
        Me.pnDuLieuNhap.Controls.Add(Me.PhepNam)
        Me.pnDuLieuNhap.Controls.Add(Me.NotAllow)
        Me.pnDuLieuNhap.Controls.Add(Me.isLeave_ComPay)
        Me.pnDuLieuNhap.Controls.Add(Me.isLeave_InsPay)
        Me.pnDuLieuNhap.Controls.Add(Me.isLeave_nonPay)
        Me.pnDuLieuNhap.Controls.Add(Me.LeaveType_KR)
        Me.pnDuLieuNhap.Controls.Add(Me.LeaveType_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.LeaveType_EN)
        Me.pnDuLieuNhap.Controls.Add(Me.LeaveType_VN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblLeaveType_KR)
        Me.pnDuLieuNhap.Controls.Add(Me.lblLeaveType_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblLeaveType_EN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblLeaveType_VN)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(5, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(1012, 154)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'AbsentSign
        '
        Me.AbsentSign.Location = New System.Drawing.Point(850, 63)
        Me.AbsentSign.Name = "AbsentSign"
        Me.AbsentSign.Size = New System.Drawing.Size(150, 21)
        Me.AbsentSign.TabIndex = 37
        '
        'lblAbsentSign
        '
        Me.lblAbsentSign.BackColor = System.Drawing.Color.Transparent
        Me.lblAbsentSign.Location = New System.Drawing.Point(737, 64)
        Me.lblAbsentSign.Name = "lblAbsentSign"
        Me.lblAbsentSign.Size = New System.Drawing.Size(107, 19)
        Me.lblAbsentSign.TabIndex = 351
        Me.lblAbsentSign.Text = "Kí hiệu"
        Me.lblAbsentSign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemark
        '
        Me.lblRemark.Location = New System.Drawing.Point(737, 92)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(107, 16)
        Me.lblRemark.TabIndex = 349
        Me.lblRemark.Text = "Ghi chú"
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(850, 89)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(150, 54)
        Me.Remark.TabIndex = 40
        Me.Remark.Text = ""
        '
        'NumberOfMonth
        '
        Me.NumberOfMonth.Location = New System.Drawing.Point(850, 37)
        Me.NumberOfMonth.Name = "NumberOfMonth"
        Me.NumberOfMonth.Size = New System.Drawing.Size(53, 21)
        Me.NumberOfMonth.TabIndex = 35
        '
        'NumberOfDate
        '
        Me.NumberOfDate.Location = New System.Drawing.Point(850, 13)
        Me.NumberOfDate.Name = "NumberOfDate"
        Me.NumberOfDate.Size = New System.Drawing.Size(53, 21)
        Me.NumberOfDate.TabIndex = 33
        '
        'lblNumberOfMonth
        '
        Me.lblNumberOfMonth.BackColor = System.Drawing.Color.Transparent
        Me.lblNumberOfMonth.Location = New System.Drawing.Point(737, 38)
        Me.lblNumberOfMonth.Name = "lblNumberOfMonth"
        Me.lblNumberOfMonth.Size = New System.Drawing.Size(107, 19)
        Me.lblNumberOfMonth.TabIndex = 348
        Me.lblNumberOfMonth.Text = "Số tháng"
        Me.lblNumberOfMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumberOfDate
        '
        Me.lblNumberOfDate.BackColor = System.Drawing.Color.Transparent
        Me.lblNumberOfDate.Location = New System.Drawing.Point(737, 14)
        Me.lblNumberOfDate.Name = "lblNumberOfDate"
        Me.lblNumberOfDate.Size = New System.Drawing.Size(107, 19)
        Me.lblNumberOfDate.TabIndex = 347
        Me.lblNumberOfDate.Text = "Số ngày"
        Me.lblNumberOfDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'isNghiKhamThai
        '
        Me.isNghiKhamThai.AutoSize = True
        Me.isNghiKhamThai.Location = New System.Drawing.Point(587, 103)
        Me.isNghiKhamThai.Name = "isNghiKhamThai"
        Me.isNghiKhamThai.Size = New System.Drawing.Size(96, 17)
        Me.isNghiKhamThai.TabIndex = 31
        Me.isNghiKhamThai.Text = "Nghỉ khám thai"
        Me.isNghiKhamThai.UseVisualStyleBackColor = True
        '
        'isNghiTruPhepNam
        '
        Me.isNghiTruPhepNam.AutoSize = True
        Me.isNghiTruPhepNam.Location = New System.Drawing.Point(729, 111)
        Me.isNghiTruPhepNam.Name = "isNghiTruPhepNam"
        Me.isNghiTruPhepNam.Size = New System.Drawing.Size(115, 17)
        Me.isNghiTruPhepNam.TabIndex = 29
        Me.isNghiTruPhepNam.Text = "Nghỉ trừ phép năm"
        Me.isNghiTruPhepNam.UseVisualStyleBackColor = True
        Me.isNghiTruPhepNam.Visible = False
        '
        'isMiscarriage
        '
        Me.isMiscarriage.AutoSize = True
        Me.isMiscarriage.Location = New System.Drawing.Point(587, 80)
        Me.isMiscarriage.Name = "isMiscarriage"
        Me.isMiscarriage.Size = New System.Drawing.Size(88, 17)
        Me.isMiscarriage.TabIndex = 27
        Me.isMiscarriage.Text = "Nghỉ sảy thai"
        Me.isMiscarriage.UseVisualStyleBackColor = True
        '
        'isMaternityLeave
        '
        Me.isMaternityLeave.AutoSize = True
        Me.isMaternityLeave.Location = New System.Drawing.Point(587, 57)
        Me.isMaternityLeave.Name = "isMaternityLeave"
        Me.isMaternityLeave.Size = New System.Drawing.Size(69, 17)
        Me.isMaternityLeave.TabIndex = 25
        Me.isMaternityLeave.Text = "Nghỉ sinh"
        Me.isMaternityLeave.UseVisualStyleBackColor = True
        '
        'ShortTermLeave
        '
        Me.ShortTermLeave.AutoSize = True
        Me.ShortTermLeave.Location = New System.Drawing.Point(587, 34)
        Me.ShortTermLeave.Name = "ShortTermLeave"
        Me.ShortTermLeave.Size = New System.Drawing.Size(101, 17)
        Me.ShortTermLeave.TabIndex = 23
        Me.ShortTermLeave.Text = "Nghỉ ngắn ngày"
        Me.ShortTermLeave.UseVisualStyleBackColor = True
        '
        'LongTermLeaving
        '
        Me.LongTermLeaving.AutoSize = True
        Me.LongTermLeaving.Location = New System.Drawing.Point(423, 126)
        Me.LongTermLeaving.Name = "LongTermLeaving"
        Me.LongTermLeaving.Size = New System.Drawing.Size(91, 17)
        Me.LongTermLeaving.TabIndex = 19
        Me.LongTermLeaving.Text = "Nghỉ dài ngày"
        Me.LongTermLeaving.UseVisualStyleBackColor = True
        '
        'Termination
        '
        Me.Termination.AutoSize = True
        Me.Termination.Location = New System.Drawing.Point(587, 12)
        Me.Termination.Name = "Termination"
        Me.Termination.Size = New System.Drawing.Size(68, 17)
        Me.Termination.TabIndex = 21
        Me.Termination.Text = "Thôi việc"
        Me.Termination.UseVisualStyleBackColor = True
        '
        'PhepNam
        '
        Me.PhepNam.AutoSize = True
        Me.PhepNam.Location = New System.Drawing.Point(423, 103)
        Me.PhepNam.Name = "PhepNam"
        Me.PhepNam.Size = New System.Drawing.Size(73, 17)
        Me.PhepNam.TabIndex = 17
        Me.PhepNam.Text = "Phép năm"
        Me.PhepNam.UseVisualStyleBackColor = True
        '
        'NotAllow
        '
        Me.NotAllow.AutoSize = True
        Me.NotAllow.Location = New System.Drawing.Point(423, 80)
        Me.NotAllow.Name = "NotAllow"
        Me.NotAllow.Size = New System.Drawing.Size(106, 17)
        Me.NotAllow.TabIndex = 15
        Me.NotAllow.Text = "Nghỉ không phép"
        Me.NotAllow.UseVisualStyleBackColor = True
        '
        'isLeave_ComPay
        '
        Me.isLeave_ComPay.AutoSize = True
        Me.isLeave_ComPay.Location = New System.Drawing.Point(423, 57)
        Me.isLeave_ComPay.Name = "isLeave_ComPay"
        Me.isLeave_ComPay.Size = New System.Drawing.Size(133, 17)
        Me.isLeave_ComPay.TabIndex = 13
        Me.isLeave_ComPay.Text = "Nghỉ công ty trả lương"
        Me.isLeave_ComPay.UseVisualStyleBackColor = True
        '
        'isLeave_InsPay
        '
        Me.isLeave_InsPay.AutoSize = True
        Me.isLeave_InsPay.Location = New System.Drawing.Point(424, 34)
        Me.isLeave_InsPay.Name = "isLeave_InsPay"
        Me.isLeave_InsPay.Size = New System.Drawing.Size(110, 17)
        Me.isLeave_InsPay.TabIndex = 11
        Me.isLeave_InsPay.Text = "Nghỉ BH trả lương"
        Me.isLeave_InsPay.UseVisualStyleBackColor = True
        '
        'isLeave_nonPay
        '
        Me.isLeave_nonPay.AutoSize = True
        Me.isLeave_nonPay.Location = New System.Drawing.Point(424, 11)
        Me.isLeave_nonPay.Name = "isLeave_nonPay"
        Me.isLeave_nonPay.Size = New System.Drawing.Size(109, 17)
        Me.isLeave_nonPay.TabIndex = 9
        Me.isLeave_nonPay.Text = "Nghỉ không lương"
        Me.isLeave_nonPay.UseVisualStyleBackColor = True
        '
        'LeaveType_KR
        '
        Me.LeaveType_KR.Location = New System.Drawing.Point(160, 82)
        Me.LeaveType_KR.Name = "LeaveType_KR"
        Me.LeaveType_KR.Size = New System.Drawing.Size(240, 21)
        Me.LeaveType_KR.TabIndex = 7
        '
        'LeaveType_ID
        '
        Me.LeaveType_ID.Location = New System.Drawing.Point(159, 10)
        Me.LeaveType_ID.Name = "LeaveType_ID"
        Me.LeaveType_ID.Size = New System.Drawing.Size(240, 21)
        Me.LeaveType_ID.TabIndex = 1
        '
        'LeaveType_EN
        '
        Me.LeaveType_EN.Location = New System.Drawing.Point(160, 58)
        Me.LeaveType_EN.Name = "LeaveType_EN"
        Me.LeaveType_EN.Size = New System.Drawing.Size(240, 21)
        Me.LeaveType_EN.TabIndex = 5
        '
        'LeaveType_VN
        '
        Me.LeaveType_VN.Location = New System.Drawing.Point(160, 34)
        Me.LeaveType_VN.Name = "LeaveType_VN"
        Me.LeaveType_VN.Size = New System.Drawing.Size(240, 21)
        Me.LeaveType_VN.TabIndex = 3
        '
        'lblLeaveType_KR
        '
        Me.lblLeaveType_KR.BackColor = System.Drawing.Color.Transparent
        Me.lblLeaveType_KR.Location = New System.Drawing.Point(5, 83)
        Me.lblLeaveType_KR.Name = "lblLeaveType_KR"
        Me.lblLeaveType_KR.Size = New System.Drawing.Size(143, 19)
        Me.lblLeaveType_KR.TabIndex = 330
        Me.lblLeaveType_KR.Text = "NameKR"
        Me.lblLeaveType_KR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLeaveType_ID
        '
        Me.lblLeaveType_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblLeaveType_ID.Location = New System.Drawing.Point(4, 11)
        Me.lblLeaveType_ID.Name = "lblLeaveType_ID"
        Me.lblLeaveType_ID.Size = New System.Drawing.Size(82, 19)
        Me.lblLeaveType_ID.TabIndex = 329
        Me.lblLeaveType_ID.Text = "LeaveType_ID"
        Me.lblLeaveType_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLeaveType_EN
        '
        Me.lblLeaveType_EN.BackColor = System.Drawing.Color.Transparent
        Me.lblLeaveType_EN.Location = New System.Drawing.Point(5, 59)
        Me.lblLeaveType_EN.Name = "lblLeaveType_EN"
        Me.lblLeaveType_EN.Size = New System.Drawing.Size(143, 19)
        Me.lblLeaveType_EN.TabIndex = 328
        Me.lblLeaveType_EN.Text = "NameEN"
        Me.lblLeaveType_EN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLeaveType_VN
        '
        Me.lblLeaveType_VN.BackColor = System.Drawing.Color.Transparent
        Me.lblLeaveType_VN.Location = New System.Drawing.Point(5, 35)
        Me.lblLeaveType_VN.Name = "lblLeaveType_VN"
        Me.lblLeaveType_VN.Size = New System.Drawing.Size(143, 19)
        Me.lblLeaveType_VN.TabIndex = 327
        Me.lblLeaveType_VN.Text = "NameVN"
        Me.lblLeaveType_VN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1024, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 154)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 41)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 1302
        Me.btnSave.Text = "Lưu"
        '
        'KhongTruCC
        '
        Me.KhongTruCC.AutoSize = True
        Me.KhongTruCC.Location = New System.Drawing.Point(587, 126)
        Me.KhongTruCC.Name = "KhongTruCC"
        Me.KhongTruCC.Size = New System.Drawing.Size(155, 17)
        Me.KhongTruCC.TabIndex = 352
        Me.KhongTruCC.Text = "Nghỉ không trừ chuyên cần"
        Me.KhongTruCC.UseVisualStyleBackColor = True
        '
        'frmTaoDieuChinhLoaiNghi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1096, 475)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "SmartBooks_LeaveType"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmTaoDieuChinhLoaiNghi"
        Me.Text = "frmTaoDieuChinhLoaiNghi"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
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
    Friend WithEvents AbsentSign As TextBox
    Friend WithEvents lblAbsentSign As Label
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents NumberOfMonth As TextBox
    Friend WithEvents NumberOfDate As TextBox
    Friend WithEvents lblNumberOfMonth As Label
    Friend WithEvents lblNumberOfDate As Label
    Friend WithEvents isNghiKhamThai As CheckBox
    Friend WithEvents isNghiTruPhepNam As CheckBox
    Friend WithEvents isMiscarriage As CheckBox
    Friend WithEvents isMaternityLeave As CheckBox
    Friend WithEvents ShortTermLeave As CheckBox
    Friend WithEvents LongTermLeaving As CheckBox
    Friend WithEvents Termination As CheckBox
    Friend WithEvents PhepNam As CheckBox
    Friend WithEvents NotAllow As CheckBox
    Friend WithEvents isLeave_ComPay As CheckBox
    Friend WithEvents isLeave_InsPay As CheckBox
    Friend WithEvents isLeave_nonPay As CheckBox
    Friend WithEvents LeaveType_KR As TextBox
    Friend WithEvents LeaveType_ID As TextBox
    Friend WithEvents LeaveType_EN As TextBox
    Friend WithEvents LeaveType_VN As TextBox
    Friend WithEvents lblLeaveType_KR As Label
    Friend WithEvents lblLeaveType_ID As Label
    Friend WithEvents lblLeaveType_EN As Label
    Friend WithEvents lblLeaveType_VN As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents KhongTruCC As CheckBox
End Class
