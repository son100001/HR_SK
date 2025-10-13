Imports WindowsControlLibrary
Public Class frmHR_MaxOvertimeInPeriod_Nhap
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
    Friend WithEvents ID As System.Windows.Forms.TextBox
    Friend WithEvents lblToDate As System.Windows.Forms.Label
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSao As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblRemark As System.Windows.Forms.Label
    Friend WithEvents lblEmployee_ID As System.Windows.Forms.Label
    Friend WithEvents lblmaxovertime As System.Windows.Forms.Label
    Friend WithEvents maxovertime As System.Windows.Forms.NumericUpDown
    Friend WithEvents Employee_ID As EmployeeIDFullName
    Friend WithEvents UserName As TextBox
    Friend WithEvents lblUserName As Label
    Friend WithEvents lblInsertDate As Label
    Friend WithEvents fromdate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents todate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents InsertDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Remark As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ID = New System.Windows.Forms.TextBox()
        Me.lblToDate = New System.Windows.Forms.Label()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSao = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.lblmaxovertime = New System.Windows.Forms.Label()
        Me.maxovertime = New System.Windows.Forms.NumericUpDown()
        Me.Employee_ID = New WindowsControlLibrary.EmployeeIDFullName()
        Me.UserName = New System.Windows.Forms.TextBox()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblInsertDate = New System.Windows.Forms.Label()
        Me.fromdate = New DevExpress.XtraEditors.DateEdit()
        Me.todate = New DevExpress.XtraEditors.DateEdit()
        Me.InsertDate = New DevExpress.XtraEditors.DateEdit()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.maxovertime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fromdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.todate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InsertDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InsertDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 315)
        Me.PanelButton.Size = New System.Drawing.Size(480, 55)
        '
        'ID
        '
        Me.ID.Location = New System.Drawing.Point(139, 22)
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Size = New System.Drawing.Size(120, 20)
        Me.ID.TabIndex = 225
        '
        'lblToDate
        '
        Me.lblToDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToDate.Location = New System.Drawing.Point(8, 100)
        Me.lblToDate.Name = "lblToDate"
        Me.lblToDate.Size = New System.Drawing.Size(72, 20)
        Me.lblToDate.TabIndex = 234
        Me.lblToDate.Text = "Đến Ngày"
        Me.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFromDate
        '
        Me.lblFromDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFromDate.Location = New System.Drawing.Point(8, 77)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(72, 20)
        Me.lblFromDate.TabIndex = 233
        Me.lblFromDate.Text = "Từ ngày"
        Me.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(267, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 19)
        Me.Label2.TabIndex = 232
        Me.Label2.Text = "*"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSao
        '
        Me.lblSao.BackColor = System.Drawing.Color.Transparent
        Me.lblSao.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSao.ForeColor = System.Drawing.Color.Red
        Me.lblSao.Location = New System.Drawing.Point(435, 52)
        Me.lblSao.Name = "lblSao"
        Me.lblSao.Size = New System.Drawing.Size(24, 19)
        Me.lblSao.TabIndex = 229
        Me.lblSao.Text = "*"
        Me.lblSao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblID
        '
        Me.lblID.Location = New System.Drawing.Point(8, 22)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(40, 23)
        Me.lblID.TabIndex = 228
        Me.lblID.Text = "ID"
        '
        'lblRemark
        '
        Me.lblRemark.Location = New System.Drawing.Point(8, 150)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(100, 16)
        Me.lblRemark.TabIndex = 227
        Me.lblRemark.Text = "Ghi chú"
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(137, 150)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(208, 56)
        Me.Remark.TabIndex = 9
        Me.Remark.Text = ""
        '
        'lblEmployee_ID
        '
        Me.lblEmployee_ID.Location = New System.Drawing.Point(8, 54)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(72, 23)
        Me.lblEmployee_ID.TabIndex = 224
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        '
        'lblmaxovertime
        '
        Me.lblmaxovertime.BackColor = System.Drawing.Color.Transparent
        Me.lblmaxovertime.Location = New System.Drawing.Point(7, 124)
        Me.lblmaxovertime.Name = "lblmaxovertime"
        Me.lblmaxovertime.Size = New System.Drawing.Size(80, 23)
        Me.lblmaxovertime.TabIndex = 268
        Me.lblmaxovertime.Text = "Tăng ca tối đa"
        Me.lblmaxovertime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'maxovertime
        '
        Me.maxovertime.DecimalPlaces = 1
        Me.maxovertime.Location = New System.Drawing.Point(139, 124)
        Me.maxovertime.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.maxovertime.Name = "maxovertime"
        Me.maxovertime.Size = New System.Drawing.Size(64, 20)
        Me.maxovertime.TabIndex = 7
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(138, 51)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Size = New System.Drawing.Size(288, 20)
        Me.Employee_ID.TabIndex = 1
        '
        'UserName
        '
        Me.UserName.Enabled = False
        Me.UserName.Location = New System.Drawing.Point(137, 212)
        Me.UserName.Name = "UserName"
        Me.UserName.ReadOnly = True
        Me.UserName.Size = New System.Drawing.Size(127, 20)
        Me.UserName.TabIndex = 290
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Location = New System.Drawing.Point(8, 212)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(112, 19)
        Me.lblUserName.TabIndex = 292
        Me.lblUserName.Text = "UserName"
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInsertDate
        '
        Me.lblInsertDate.BackColor = System.Drawing.Color.Transparent
        Me.lblInsertDate.Location = New System.Drawing.Point(8, 236)
        Me.lblInsertDate.Name = "lblInsertDate"
        Me.lblInsertDate.Size = New System.Drawing.Size(112, 19)
        Me.lblInsertDate.TabIndex = 291
        Me.lblInsertDate.Text = "InsertDate"
        Me.lblInsertDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fromdate
        '
        Me.fromdate.EditValue = Nothing
        Me.fromdate.Location = New System.Drawing.Point(137, 76)
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
        Me.fromdate.Size = New System.Drawing.Size(122, 20)
        Me.fromdate.TabIndex = 1350
        '
        'todate
        '
        Me.todate.EditValue = Nothing
        Me.todate.Location = New System.Drawing.Point(137, 100)
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
        Me.todate.Size = New System.Drawing.Size(122, 20)
        Me.todate.TabIndex = 1351
        '
        'InsertDate
        '
        Me.InsertDate.EditValue = Nothing
        Me.InsertDate.Location = New System.Drawing.Point(137, 236)
        Me.InsertDate.Name = "InsertDate"
        Me.InsertDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InsertDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InsertDate.Properties.DisplayFormat.FormatString = ""
        Me.InsertDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.InsertDate.Properties.EditFormat.FormatString = ""
        Me.InsertDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.InsertDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.InsertDate.Properties.MaskSettings.Set("mask", "g")
        Me.InsertDate.Properties.UseMaskAsDisplayFormat = True
        Me.InsertDate.Size = New System.Drawing.Size(127, 20)
        Me.InsertDate.TabIndex = 1352
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(157, 269)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(78, 30)
        Me.btnSave.TabIndex = 1353
        Me.btnSave.Text = "Save"
        '
        'btnClose1
        '
        Me.btnClose1.Location = New System.Drawing.Point(247, 269)
        Me.btnClose1.Name = "btnClose1"
        Me.btnClose1.Size = New System.Drawing.Size(78, 30)
        Me.btnClose1.TabIndex = 1354
        Me.btnClose1.Text = "Close"
        '
        'frmHR_MaxOvertimeInPeriod_Nhap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(480, 370)
        Me.Controls.Add(Me.btnClose1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.InsertDate)
        Me.Controls.Add(Me.todate)
        Me.Controls.Add(Me.fromdate)
        Me.Controls.Add(Me.UserName)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.lblInsertDate)
        Me.Controls.Add(Me.Employee_ID)
        Me.Controls.Add(Me.lblmaxovertime)
        Me.Controls.Add(Me.maxovertime)
        Me.Controls.Add(Me.ID)
        Me.Controls.Add(Me.lblToDate)
        Me.Controls.Add(Me.lblFromDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblSao)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.lblRemark)
        Me.Controls.Add(Me.Remark)
        Me.Controls.Add(Me.lblEmployee_ID)
        Me.HRFORM_TableName = "HR_MaxOvertimeInPeriod"
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
        Me.Name = "frmHR_MaxOvertimeInPeriod_Nhap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmHR_MaxOvertimeInPeriod_Nhap"
        Me.Controls.SetChildIndex(Me.lblEmployee_ID, 0)
        Me.Controls.SetChildIndex(Me.Remark, 0)
        Me.Controls.SetChildIndex(Me.lblRemark, 0)
        Me.Controls.SetChildIndex(Me.lblID, 0)
        Me.Controls.SetChildIndex(Me.lblSao, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblFromDate, 0)
        Me.Controls.SetChildIndex(Me.lblToDate, 0)
        Me.Controls.SetChildIndex(Me.ID, 0)
        Me.Controls.SetChildIndex(Me.maxovertime, 0)
        Me.Controls.SetChildIndex(Me.lblmaxovertime, 0)
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.Employee_ID, 0)
        Me.Controls.SetChildIndex(Me.lblInsertDate, 0)
        Me.Controls.SetChildIndex(Me.lblUserName, 0)
        Me.Controls.SetChildIndex(Me.UserName, 0)
        Me.Controls.SetChildIndex(Me.fromdate, 0)
        Me.Controls.SetChildIndex(Me.todate, 0)
        Me.Controls.SetChildIndex(Me.InsertDate, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnClose1, 0)
        CType(Me.maxovertime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fromdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.todate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InsertDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InsertDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Overrides Function BeforeSave() As Integer
        UserName.Text = DbSetting.UserName
        InsertDate.EditValue = Now
        Return 1
    End Function
    Public Overrides Sub BeforeLoad()
        fromdate.EditValue = Today
        todate.EditValue = Today
    End Sub
    Private Sub frmHR_MaxOvertimeInPeriod_Nhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Employee_ID.Select()
    End Sub
End Class
