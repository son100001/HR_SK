<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRoundShiftDetail_Nhap
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
        Me.lblRoundCode = New System.Windows.Forms.Label()
        Me.UserName = New System.Windows.Forms.TextBox()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblInsertDate = New System.Windows.Forms.Label()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.ID = New System.Windows.Forms.TextBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblShiftName = New System.Windows.Forms.Label()
        Me.lblRoundOrder = New System.Windows.Forms.Label()
        Me.lblRoundDays = New System.Windows.Forms.Label()
        Me.lblRoundMonths = New System.Windows.Forms.Label()
        Me.RoundDays = New System.Windows.Forms.TextBox()
        Me.RoundMonths = New System.Windows.Forms.TextBox()
        Me.RoundOrder = New System.Windows.Forms.NumericUpDown()
        Me.RoundCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.ShiftName = New DevExpress.XtraEditors.LookUpEdit()
        Me.InsertDate = New DevExpress.XtraEditors.DateTimeOffsetEdit()
        CType(Me.RoundOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RoundCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShiftName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InsertDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 283)
        Me.PanelButton.Size = New System.Drawing.Size(486, 55)
        '
        'lblRoundCode
        '
        Me.lblRoundCode.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoundCode.Location = New System.Drawing.Point(22, 38)
        Me.lblRoundCode.Name = "lblRoundCode"
        Me.lblRoundCode.Size = New System.Drawing.Size(72, 20)
        Me.lblRoundCode.TabIndex = 1054
        Me.lblRoundCode.Text = "Mã xoay ca"
        Me.lblRoundCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UserName
        '
        Me.UserName.Enabled = False
        Me.UserName.Location = New System.Drawing.Point(134, 225)
        Me.UserName.Name = "UserName"
        Me.UserName.ReadOnly = True
        Me.UserName.Size = New System.Drawing.Size(120, 20)
        Me.UserName.TabIndex = 1050
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Location = New System.Drawing.Point(22, 225)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(96, 19)
        Me.lblUserName.TabIndex = 1052
        Me.lblUserName.Text = "UserName"
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInsertDate
        '
        Me.lblInsertDate.BackColor = System.Drawing.Color.Transparent
        Me.lblInsertDate.Location = New System.Drawing.Point(22, 249)
        Me.lblInsertDate.Name = "lblInsertDate"
        Me.lblInsertDate.Size = New System.Drawing.Size(96, 19)
        Me.lblInsertDate.TabIndex = 1051
        Me.lblInsertDate.Text = "InsertDate"
        Me.lblInsertDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemark
        '
        Me.lblRemark.Location = New System.Drawing.Point(22, 177)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(100, 16)
        Me.lblRemark.TabIndex = 1047
        Me.lblRemark.Text = "Ghi chú"
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(134, 163)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(208, 56)
        Me.Remark.TabIndex = 11
        Me.Remark.Text = ""
        '
        'ID
        '
        Me.ID.Location = New System.Drawing.Point(134, 12)
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Size = New System.Drawing.Size(120, 20)
        Me.ID.TabIndex = 1043
        '
        'lblID
        '
        Me.lblID.Location = New System.Drawing.Point(21, 12)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(40, 23)
        Me.lblID.TabIndex = 1044
        Me.lblID.Text = "ID"
        '
        'lblShiftName
        '
        Me.lblShiftName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftName.Location = New System.Drawing.Point(21, 61)
        Me.lblShiftName.Name = "lblShiftName"
        Me.lblShiftName.Size = New System.Drawing.Size(72, 20)
        Me.lblShiftName.TabIndex = 1053
        Me.lblShiftName.Text = "Ca"
        Me.lblShiftName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRoundOrder
        '
        Me.lblRoundOrder.BackColor = System.Drawing.Color.Transparent
        Me.lblRoundOrder.Location = New System.Drawing.Point(22, 137)
        Me.lblRoundOrder.Name = "lblRoundOrder"
        Me.lblRoundOrder.Size = New System.Drawing.Size(93, 23)
        Me.lblRoundOrder.TabIndex = 1058
        Me.lblRoundOrder.Text = "Thứ tự ca xoay"
        Me.lblRoundOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRoundDays
        '
        Me.lblRoundDays.BackColor = System.Drawing.Color.Transparent
        Me.lblRoundDays.Location = New System.Drawing.Point(21, 88)
        Me.lblRoundDays.Name = "lblRoundDays"
        Me.lblRoundDays.Size = New System.Drawing.Size(93, 23)
        Me.lblRoundDays.TabIndex = 1060
        Me.lblRoundDays.Text = "Số ngày xoay"
        Me.lblRoundDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRoundMonths
        '
        Me.lblRoundMonths.BackColor = System.Drawing.Color.Transparent
        Me.lblRoundMonths.Location = New System.Drawing.Point(21, 111)
        Me.lblRoundMonths.Name = "lblRoundMonths"
        Me.lblRoundMonths.Size = New System.Drawing.Size(93, 23)
        Me.lblRoundMonths.TabIndex = 1062
        Me.lblRoundMonths.Text = "Số tháng xoay"
        Me.lblRoundMonths.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RoundDays
        '
        Me.RoundDays.Location = New System.Drawing.Point(134, 87)
        Me.RoundDays.Name = "RoundDays"
        Me.RoundDays.Size = New System.Drawing.Size(120, 20)
        Me.RoundDays.TabIndex = 5
        '
        'RoundMonths
        '
        Me.RoundMonths.Location = New System.Drawing.Point(134, 113)
        Me.RoundMonths.Name = "RoundMonths"
        Me.RoundMonths.Size = New System.Drawing.Size(120, 20)
        Me.RoundMonths.TabIndex = 7
        '
        'RoundOrder
        '
        Me.RoundOrder.Location = New System.Drawing.Point(135, 137)
        Me.RoundOrder.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.RoundOrder.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RoundOrder.Name = "RoundOrder"
        Me.RoundOrder.Size = New System.Drawing.Size(64, 20)
        Me.RoundOrder.TabIndex = 9
        Me.RoundOrder.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'RoundCode
        '
        Me.RoundCode.Location = New System.Drawing.Point(134, 39)
        Me.RoundCode.Name = "RoundCode"
        Me.RoundCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.RoundCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RoundCode.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.RoundCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.RoundCode.Size = New System.Drawing.Size(144, 20)
        Me.RoundCode.TabIndex = 1063
        '
        'ShiftName
        '
        Me.ShiftName.Location = New System.Drawing.Point(134, 63)
        Me.ShiftName.Name = "ShiftName"
        Me.ShiftName.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.ShiftName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ShiftName.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.ShiftName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.ShiftName.Size = New System.Drawing.Size(144, 20)
        Me.ShiftName.TabIndex = 1064
        '
        'InsertDate
        '
        Me.InsertDate.EditValue = Nothing
        Me.InsertDate.Location = New System.Drawing.Point(134, 249)
        Me.InsertDate.Name = "InsertDate"
        Me.InsertDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InsertDate.Properties.MaskSettings.Set("mask", "G")
        Me.InsertDate.Size = New System.Drawing.Size(208, 20)
        Me.InsertDate.TabIndex = 1065
        '
        'frmRoundShiftDetail_Nhap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 338)
        Me.Controls.Add(Me.InsertDate)
        Me.Controls.Add(Me.ShiftName)
        Me.Controls.Add(Me.RoundCode)
        Me.Controls.Add(Me.RoundMonths)
        Me.Controls.Add(Me.RoundDays)
        Me.Controls.Add(Me.lblRoundMonths)
        Me.Controls.Add(Me.lblRoundDays)
        Me.Controls.Add(Me.lblRoundOrder)
        Me.Controls.Add(Me.RoundOrder)
        Me.Controls.Add(Me.lblRoundCode)
        Me.Controls.Add(Me.lblShiftName)
        Me.Controls.Add(Me.UserName)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.lblInsertDate)
        Me.Controls.Add(Me.lblRemark)
        Me.Controls.Add(Me.Remark)
        Me.Controls.Add(Me.ID)
        Me.Controls.Add(Me.lblID)
        Me.HRFORM_TableName = "HR_RoundShiftDetail"
        Me.HRFORM_TypeOfForm = WindowsControlLibrary.HRFORM.TypeOfForm.Input
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_ExportExcel = False
        Me.HRFORM_VisibleControl_GetTemplate = False
        Me.HRFORM_VisibleControl_ImportExcel = False
        Me.HRFORM_VisibleControl_StatusBarFooter = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_VisibleControl_Xem = False
        Me.HRFORM_VisibleControl_Xoa = False
        Me.Name = "frmRoundShiftDetail_Nhap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmRoundShiftDetail_Nhap"
        Me.Controls.SetChildIndex(Me.lblID, 0)
        Me.Controls.SetChildIndex(Me.ID, 0)
        Me.Controls.SetChildIndex(Me.Remark, 0)
        Me.Controls.SetChildIndex(Me.lblRemark, 0)
        Me.Controls.SetChildIndex(Me.lblInsertDate, 0)
        Me.Controls.SetChildIndex(Me.lblUserName, 0)
        Me.Controls.SetChildIndex(Me.UserName, 0)
        Me.Controls.SetChildIndex(Me.lblShiftName, 0)
        Me.Controls.SetChildIndex(Me.lblRoundCode, 0)
        Me.Controls.SetChildIndex(Me.RoundOrder, 0)
        Me.Controls.SetChildIndex(Me.lblRoundOrder, 0)
        Me.Controls.SetChildIndex(Me.lblRoundDays, 0)
        Me.Controls.SetChildIndex(Me.lblRoundMonths, 0)
        Me.Controls.SetChildIndex(Me.RoundDays, 0)
        Me.Controls.SetChildIndex(Me.RoundMonths, 0)
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.RoundCode, 0)
        Me.Controls.SetChildIndex(Me.ShiftName, 0)
        Me.Controls.SetChildIndex(Me.InsertDate, 0)
        CType(Me.RoundOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RoundCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShiftName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InsertDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblRoundCode As Label
    Friend WithEvents UserName As TextBox
    Friend WithEvents lblUserName As Label
    Friend WithEvents lblInsertDate As Label
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents ID As TextBox
    Friend WithEvents lblID As Label
    Friend WithEvents lblShiftName As Label
    Friend WithEvents lblRoundOrder As Label
    Friend WithEvents lblRoundDays As Label
    Friend WithEvents lblRoundMonths As Label
    Friend WithEvents RoundDays As TextBox
    Friend WithEvents RoundMonths As TextBox
    Friend WithEvents RoundOrder As NumericUpDown
    Friend WithEvents RoundCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ShiftName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents InsertDate As DevExpress.XtraEditors.DateTimeOffsetEdit
End Class
