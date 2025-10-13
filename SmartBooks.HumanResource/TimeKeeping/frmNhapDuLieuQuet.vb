Imports WindowsControlLibrary
Public Class frmNhapDuLieuQuet
    Inherits HRFORM


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblAccessDate As System.Windows.Forms.Label
    Friend WithEvents lblAccessTime As System.Windows.Forms.Label
    Friend WithEvents lblCardNumber As System.Windows.Forms.Label
    Friend WithEvents Employee_ID As WindowsControlLibrary.EmployeeIDFullName
    Friend WithEvents lbLEmployee_ID As System.Windows.Forms.Label
    Friend WithEvents UserName As System.Windows.Forms.TextBox
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblInsertDate As System.Windows.Forms.Label
    Friend WithEvents lblRemark As System.Windows.Forms.Label
    Friend WithEvents Remark As System.Windows.Forms.RichTextBox
    Friend WithEvents lblInsertSource As System.Windows.Forms.Label
    Friend WithEvents ID As TextBox
    Friend WithEvents Device_ID As TextBox
    Friend WithEvents lblDevice_ID As Label
    Friend WithEvents lblInOutStatus As Label
    Friend WithEvents DeviceIP As TextBox
    Friend WithEvents lblDeviceIP As Label
    Friend WithEvents CardNumber As TextBox
    Friend WithEvents AccessDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents InOutStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents InsertSource As TextBox
    Friend WithEvents InsertDate As DevExpress.XtraEditors.DateTimeOffsetEdit
    Friend WithEvents AccessTime As DevExpress.XtraEditors.DateTimeOffsetEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblAccessDate = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblAccessTime = New System.Windows.Forms.Label()
        Me.lblCardNumber = New System.Windows.Forms.Label()
        Me.Employee_ID = New WindowsControlLibrary.EmployeeIDFullName()
        Me.lbLEmployee_ID = New System.Windows.Forms.Label()
        Me.UserName = New System.Windows.Forms.TextBox()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblInsertDate = New System.Windows.Forms.Label()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblInsertSource = New System.Windows.Forms.Label()
        Me.ID = New System.Windows.Forms.TextBox()
        Me.Device_ID = New System.Windows.Forms.TextBox()
        Me.lblDevice_ID = New System.Windows.Forms.Label()
        Me.lblInOutStatus = New System.Windows.Forms.Label()
        Me.DeviceIP = New System.Windows.Forms.TextBox()
        Me.lblDeviceIP = New System.Windows.Forms.Label()
        Me.CardNumber = New System.Windows.Forms.TextBox()
        Me.AccessDate = New DevExpress.XtraEditors.DateEdit()
        Me.AccessTime = New DevExpress.XtraEditors.DateTimeOffsetEdit()
        Me.InOutStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.InsertSource = New System.Windows.Forms.TextBox()
        Me.InsertDate = New DevExpress.XtraEditors.DateTimeOffsetEdit()
        CType(Me.AccessDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccessDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccessTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InOutStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InsertDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 318)
        Me.PanelButton.Size = New System.Drawing.Size(432, 55)
        '
        'lblAccessDate
        '
        Me.lblAccessDate.BackColor = System.Drawing.Color.Transparent
        Me.lblAccessDate.Location = New System.Drawing.Point(16, 88)
        Me.lblAccessDate.Name = "lblAccessDate"
        Me.lblAccessDate.Size = New System.Drawing.Size(66, 19)
        Me.lblAccessDate.TabIndex = 220
        Me.lblAccessDate.Text = "Ngày"
        Me.lblAccessDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblID
        '
        Me.lblID.BackColor = System.Drawing.Color.Transparent
        Me.lblID.Location = New System.Drawing.Point(18, 16)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(81, 19)
        Me.lblID.TabIndex = 224
        Me.lblID.Text = "ID"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessTime
        '
        Me.lblAccessTime.BackColor = System.Drawing.Color.Transparent
        Me.lblAccessTime.Location = New System.Drawing.Point(16, 140)
        Me.lblAccessTime.Name = "lblAccessTime"
        Me.lblAccessTime.Size = New System.Drawing.Size(64, 19)
        Me.lblAccessTime.TabIndex = 217
        Me.lblAccessTime.Text = "Giờ quẹt"
        Me.lblAccessTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCardNumber
        '
        Me.lblCardNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblCardNumber.Location = New System.Drawing.Point(16, 64)
        Me.lblCardNumber.Name = "lblCardNumber"
        Me.lblCardNumber.Size = New System.Drawing.Size(81, 19)
        Me.lblCardNumber.TabIndex = 227
        Me.lblCardNumber.Text = "Mã thẻ"
        Me.lblCardNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(120, 40)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Size = New System.Drawing.Size(288, 20)
        Me.Employee_ID.TabIndex = 1
        '
        'lbLEmployee_ID
        '
        Me.lbLEmployee_ID.Location = New System.Drawing.Point(16, 40)
        Me.lbLEmployee_ID.Name = "lbLEmployee_ID"
        Me.lbLEmployee_ID.Size = New System.Drawing.Size(72, 23)
        Me.lbLEmployee_ID.TabIndex = 239
        Me.lbLEmployee_ID.Text = "Mã nhân viên"
        '
        'UserName
        '
        Me.UserName.Enabled = False
        Me.UserName.Location = New System.Drawing.Point(120, 269)
        Me.UserName.Name = "UserName"
        Me.UserName.ReadOnly = True
        Me.UserName.Size = New System.Drawing.Size(120, 20)
        Me.UserName.TabIndex = 314
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Location = New System.Drawing.Point(16, 269)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(64, 19)
        Me.lblUserName.TabIndex = 316
        Me.lblUserName.Text = "UserName"
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInsertDate
        '
        Me.lblInsertDate.BackColor = System.Drawing.Color.Transparent
        Me.lblInsertDate.Location = New System.Drawing.Point(16, 293)
        Me.lblInsertDate.Name = "lblInsertDate"
        Me.lblInsertDate.Size = New System.Drawing.Size(64, 19)
        Me.lblInsertDate.TabIndex = 315
        Me.lblInsertDate.Text = "InsertDate"
        Me.lblInsertDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemark
        '
        Me.lblRemark.Location = New System.Drawing.Point(16, 245)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(64, 16)
        Me.lblRemark.TabIndex = 318
        Me.lblRemark.Text = "Ghi chú"
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(120, 237)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(208, 32)
        Me.Remark.TabIndex = 9
        Me.Remark.Text = ""
        '
        'lblInsertSource
        '
        Me.lblInsertSource.BackColor = System.Drawing.Color.Transparent
        Me.lblInsertSource.Location = New System.Drawing.Point(16, 213)
        Me.lblInsertSource.Name = "lblInsertSource"
        Me.lblInsertSource.Size = New System.Drawing.Size(81, 19)
        Me.lblInsertSource.TabIndex = 320
        Me.lblInsertSource.Text = "InsertSource"
        Me.lblInsertSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ID
        '
        Me.ID.Enabled = False
        Me.ID.Location = New System.Drawing.Point(121, 16)
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Size = New System.Drawing.Size(120, 20)
        Me.ID.TabIndex = 335
        '
        'Device_ID
        '
        Me.Device_ID.Location = New System.Drawing.Point(120, 166)
        Me.Device_ID.Name = "Device_ID"
        Me.Device_ID.Size = New System.Drawing.Size(121, 20)
        Me.Device_ID.TabIndex = 8
        '
        'lblDevice_ID
        '
        Me.lblDevice_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblDevice_ID.Location = New System.Drawing.Point(17, 166)
        Me.lblDevice_ID.Name = "lblDevice_ID"
        Me.lblDevice_ID.Size = New System.Drawing.Size(81, 19)
        Me.lblDevice_ID.TabIndex = 336
        Me.lblDevice_ID.Text = "Thiết bị"
        Me.lblDevice_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInOutStatus
        '
        Me.lblInOutStatus.Location = New System.Drawing.Point(15, 114)
        Me.lblInOutStatus.Name = "lblInOutStatus"
        Me.lblInOutStatus.Size = New System.Drawing.Size(99, 23)
        Me.lblInOutStatus.TabIndex = 1206
        Me.lblInOutStatus.Text = "Trạng thái Vào/Ra"
        '
        'DeviceIP
        '
        Me.DeviceIP.Location = New System.Drawing.Point(120, 190)
        Me.DeviceIP.Name = "DeviceIP"
        Me.DeviceIP.Size = New System.Drawing.Size(121, 20)
        Me.DeviceIP.TabIndex = 8
        '
        'lblDeviceIP
        '
        Me.lblDeviceIP.BackColor = System.Drawing.Color.Transparent
        Me.lblDeviceIP.Location = New System.Drawing.Point(17, 187)
        Me.lblDeviceIP.Name = "lblDeviceIP"
        Me.lblDeviceIP.Size = New System.Drawing.Size(81, 19)
        Me.lblDeviceIP.TabIndex = 1207
        Me.lblDeviceIP.Text = "IP thiết bị"
        Me.lblDeviceIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CardNumber
        '
        Me.CardNumber.Location = New System.Drawing.Point(120, 64)
        Me.CardNumber.Name = "CardNumber"
        Me.CardNumber.Size = New System.Drawing.Size(120, 20)
        Me.CardNumber.TabIndex = 1208
        '
        'AccessDate
        '
        Me.AccessDate.EditValue = Nothing
        Me.AccessDate.Location = New System.Drawing.Point(120, 89)
        Me.AccessDate.Name = "AccessDate"
        Me.AccessDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AccessDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AccessDate.Properties.DisplayFormat.FormatString = ""
        Me.AccessDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.AccessDate.Properties.EditFormat.FormatString = ""
        Me.AccessDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.AccessDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.AccessDate.Properties.MaskSettings.Set("mask", "d")
        Me.AccessDate.Properties.UseMaskAsDisplayFormat = True
        Me.AccessDate.Size = New System.Drawing.Size(120, 20)
        Me.AccessDate.TabIndex = 1350
        '
        'AccessTime
        '
        Me.AccessTime.EditValue = Nothing
        Me.AccessTime.Location = New System.Drawing.Point(120, 141)
        Me.AccessTime.Name = "AccessTime"
        Me.AccessTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AccessTime.Properties.MaskSettings.Set("mask", "t")
        Me.AccessTime.Size = New System.Drawing.Size(121, 20)
        Me.AccessTime.TabIndex = 1353
        '
        'InOutStatus
        '
        Me.InOutStatus.Location = New System.Drawing.Point(119, 115)
        Me.InOutStatus.Name = "InOutStatus"
        Me.InOutStatus.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.InOutStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InOutStatus.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.InOutStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.InOutStatus.Size = New System.Drawing.Size(122, 20)
        Me.InOutStatus.TabIndex = 1354
        '
        'InsertSource
        '
        Me.InsertSource.Location = New System.Drawing.Point(119, 214)
        Me.InsertSource.Name = "InsertSource"
        Me.InsertSource.Size = New System.Drawing.Size(121, 20)
        Me.InsertSource.TabIndex = 1355
        '
        'InsertDate
        '
        Me.InsertDate.EditValue = Nothing
        Me.InsertDate.Location = New System.Drawing.Point(120, 292)
        Me.InsertDate.Name = "InsertDate"
        Me.InsertDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InsertDate.Properties.MaskSettings.Set("mask", "G")
        Me.InsertDate.Size = New System.Drawing.Size(121, 20)
        Me.InsertDate.TabIndex = 1356
        '
        'frmNhapDuLieuQuet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(432, 373)
        Me.Controls.Add(Me.InsertDate)
        Me.Controls.Add(Me.InsertSource)
        Me.Controls.Add(Me.InOutStatus)
        Me.Controls.Add(Me.AccessTime)
        Me.Controls.Add(Me.AccessDate)
        Me.Controls.Add(Me.CardNumber)
        Me.Controls.Add(Me.DeviceIP)
        Me.Controls.Add(Me.lblDeviceIP)
        Me.Controls.Add(Me.lblInOutStatus)
        Me.Controls.Add(Me.Device_ID)
        Me.Controls.Add(Me.lblDevice_ID)
        Me.Controls.Add(Me.ID)
        Me.Controls.Add(Me.lblInsertSource)
        Me.Controls.Add(Me.lblRemark)
        Me.Controls.Add(Me.Remark)
        Me.Controls.Add(Me.UserName)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.lblInsertDate)
        Me.Controls.Add(Me.Employee_ID)
        Me.Controls.Add(Me.lbLEmployee_ID)
        Me.Controls.Add(Me.lblCardNumber)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.lblAccessDate)
        Me.Controls.Add(Me.lblAccessTime)
        Me.HRFORM_TableName = "HR_TimeKeeping_Data"
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
        Me.Name = "frmNhapDuLieuQuet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmNhapDuLieuQuet"
        Me.Controls.SetChildIndex(Me.lblAccessTime, 0)
        Me.Controls.SetChildIndex(Me.lblAccessDate, 0)
        Me.Controls.SetChildIndex(Me.lblID, 0)
        Me.Controls.SetChildIndex(Me.lblCardNumber, 0)
        Me.Controls.SetChildIndex(Me.lbLEmployee_ID, 0)
        Me.Controls.SetChildIndex(Me.Employee_ID, 0)
        Me.Controls.SetChildIndex(Me.lblInsertDate, 0)
        Me.Controls.SetChildIndex(Me.lblUserName, 0)
        Me.Controls.SetChildIndex(Me.UserName, 0)
        Me.Controls.SetChildIndex(Me.Remark, 0)
        Me.Controls.SetChildIndex(Me.lblRemark, 0)
        Me.Controls.SetChildIndex(Me.lblInsertSource, 0)
        Me.Controls.SetChildIndex(Me.ID, 0)
        Me.Controls.SetChildIndex(Me.lblDevice_ID, 0)
        Me.Controls.SetChildIndex(Me.Device_ID, 0)
        Me.Controls.SetChildIndex(Me.lblInOutStatus, 0)
        Me.Controls.SetChildIndex(Me.lblDeviceIP, 0)
        Me.Controls.SetChildIndex(Me.DeviceIP, 0)
        Me.Controls.SetChildIndex(Me.CardNumber, 0)
        Me.Controls.SetChildIndex(Me.AccessDate, 0)
        Me.Controls.SetChildIndex(Me.AccessTime, 0)
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.InOutStatus, 0)
        Me.Controls.SetChildIndex(Me.InsertSource, 0)
        Me.Controls.SetChildIndex(Me.InsertDate, 0)
        CType(Me.AccessDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccessDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccessTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InOutStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InsertDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmNhapDuLieuQuet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Employee_ID.Select()
    End Sub
    Public Overrides Function BeforeSave() As Integer
        If CardNumber.Text = String.Empty Then
            CardNumber.Text = Employee_ID.Text
        End If
        AccessTime.EditValue = New DateTime(AccessDate.EditValue.Year, AccessDate.EditValue.Month, AccessDate.EditValue.Day, AccessTime.EditValue.Hour, AccessTime.EditValue.Minute, AccessTime.EditValue.Second)
        InsertSource.Text = "NhapTay"
        UserName.Text = DbSetting.UserName
        InsertDate.EditValue = Now
        Return 1
    End Function

End Class
