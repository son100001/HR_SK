Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports Appsettings
Imports System.Runtime.CompilerServices

Public Class frmServerLogin
    Inherits System.Windows.Forms.Form
    Private LockChooseData As String
    Private DatabaseName As String
    Friend WithEvents cboDatabaseName As DevExpress.XtraEditors.LookUpEdit
    Private tvcn As New WindowsControlLibrary.ThuVienChucNang

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtServerLogin As System.Windows.Forms.TextBox
    Friend WithEvents txtServerPassword As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabSQLServer As System.Windows.Forms.TabPage
    Friend WithEvents TabAccess As System.Windows.Forms.TabPage
    Friend WithEvents btnTestConnection As System.Windows.Forms.Button
    Friend WithEvents btnChooseAccessFile As System.Windows.Forms.Button
    Friend WithEvents btnApplyModule As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txt_tkpdb As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeIDPlace As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeIDNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeAddressTemporary As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeMiddleName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeGender As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeIDDate As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckEmployeeDataMap As System.Windows.Forms.Button
    Friend WithEvents txtTimekeepingTable As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents lblRegDate As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeStartDate As System.Windows.Forms.TextBox
    Friend WithEvents txtTimekeepingEmployee As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTimekeepingDate As System.Windows.Forms.TextBox
    Friend WithEvents btnMauMay As System.Windows.Forms.Button
    Friend WithEvents cboTemplates As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeBirthday As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeTable As System.Windows.Forms.TextBox
    Friend WithEvents txtTimekeepingAccessTime As System.Windows.Forms.TextBox
    Friend WithEvents txtSQLPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtSQLUser As System.Windows.Forms.TextBox
    Friend WithEvents txtSQLServer As System.Windows.Forms.TextBox
    Friend WithEvents txtSQLDatabase As System.Windows.Forms.TextBox
    Friend WithEvents txtAccessFilePath As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtAccessPassword As System.Windows.Forms.TextBox
    Friend WithEvents grpEmployee As System.Windows.Forms.GroupBox
    Friend WithEvents grpTimekeeping As System.Windows.Forms.GroupBox
    Friend WithEvents btnTestTimeKeepping As System.Windows.Forms.Button
    Friend WithEvents cbSecond As System.Windows.Forms.CheckBox
    Friend WithEvents txtSQL As System.Windows.Forms.TextBox
    Friend WithEvents cbConfigSalary As System.Windows.Forms.CheckBox
    Friend WithEvents cbFull8h_AddOT As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.txtServerLogin = New System.Windows.Forms.TextBox()
        Me.txtServerPassword = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnMauMay = New System.Windows.Forms.Button()
        Me.btnApplyModule = New System.Windows.Forms.Button()
        Me.cboTemplates = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabSQLServer = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSQLPassword = New System.Windows.Forms.TextBox()
        Me.txtSQLUser = New System.Windows.Forms.TextBox()
        Me.txtSQLServer = New System.Windows.Forms.TextBox()
        Me.txtSQLDatabase = New System.Windows.Forms.TextBox()
        Me.TabAccess = New System.Windows.Forms.TabPage()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtAccessPassword = New System.Windows.Forms.TextBox()
        Me.btnChooseAccessFile = New System.Windows.Forms.Button()
        Me.txtAccessFilePath = New System.Windows.Forms.TextBox()
        Me.btnTestConnection = New System.Windows.Forms.Button()
        Me.grpEmployee = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEmployeeBirthday = New System.Windows.Forms.TextBox()
        Me.lblRegDate = New System.Windows.Forms.Label()
        Me.txtEmployeeStartDate = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.txtCheckEmployeeDataMap = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtEmployeeGender = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtEmployeeIDPlace = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtEmployeeIDDate = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtEmployeeIDNumber = New System.Windows.Forms.TextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtEmployeeAddressTemporary = New System.Windows.Forms.TextBox()
        Me.txtEmployeeLastName = New System.Windows.Forms.TextBox()
        Me.txtEmployeeMiddleName = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEmployeeFirstName = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtEmployeeTable = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.grpTimekeeping = New System.Windows.Forms.GroupBox()
        Me.cbFull8h_AddOT = New System.Windows.Forms.CheckBox()
        Me.cbSecond = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTimekeepingDate = New System.Windows.Forms.TextBox()
        Me.btnTestTimeKeepping = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTimekeepingAccessTime = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTimekeepingEmployee = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtTimekeepingTable = New System.Windows.Forms.TextBox()
        Me.txt_tkpdb = New System.Windows.Forms.TextBox()
        Me.txtSQL = New System.Windows.Forms.TextBox()
        Me.cbConfigSalary = New System.Windows.Forms.CheckBox()
        Me.cboDatabaseName = New DevExpress.XtraEditors.LookUpEdit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabSQLServer.SuspendLayout()
        Me.TabAccess.SuspendLayout()
        Me.grpEmployee.SuspendLayout()
        Me.grpTimekeeping.SuspendLayout()
        CType(Me.cboDatabaseName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SQL Server:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "SQL Server Login:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "SQL Server Password:"
        '
        'txtServer
        '
        Me.txtServer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtServer.Location = New System.Drawing.Point(144, 24)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(160, 21)
        Me.txtServer.TabIndex = 1
        '
        'txtServerLogin
        '
        Me.txtServerLogin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtServerLogin.Location = New System.Drawing.Point(144, 48)
        Me.txtServerLogin.Name = "txtServerLogin"
        Me.txtServerLogin.Size = New System.Drawing.Size(160, 21)
        Me.txtServerLogin.TabIndex = 3
        '
        'txtServerPassword
        '
        Me.txtServerPassword.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtServerPassword.Location = New System.Drawing.Point(144, 72)
        Me.txtServerPassword.Name = "txtServerPassword"
        Me.txtServerPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtServerPassword.Size = New System.Drawing.Size(160, 21)
        Me.txtServerPassword.TabIndex = 5
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.btnOK.Location = New System.Drawing.Point(608, 361)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 23)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(704, 361)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Database:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboDatabaseName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtServerLogin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtServer)
        Me.GroupBox1.Controls.Add(Me.txtServerPassword)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(320, 128)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "1 - Server Information"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnMauMay)
        Me.GroupBox2.Controls.Add(Me.btnApplyModule)
        Me.GroupBox2.Controls.Add(Me.cboTemplates)
        Me.GroupBox2.Controls.Add(Me.TabControl1)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 144)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(320, 240)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "2 - TimeKeepping Information"
        '
        'btnMauMay
        '
        Me.btnMauMay.Location = New System.Drawing.Point(8, 32)
        Me.btnMauMay.Name = "btnMauMay"
        Me.btnMauMay.Size = New System.Drawing.Size(64, 23)
        Me.btnMauMay.TabIndex = 21
        Me.btnMauMay.Text = "Model No"
        '
        'btnApplyModule
        '
        Me.btnApplyModule.Location = New System.Drawing.Point(232, 32)
        Me.btnApplyModule.Name = "btnApplyModule"
        Me.btnApplyModule.Size = New System.Drawing.Size(72, 23)
        Me.btnApplyModule.TabIndex = 20
        Me.btnApplyModule.Text = "Use It"
        '
        'cboTemplates
        '
        Me.cboTemplates.Location = New System.Drawing.Point(80, 32)
        Me.cboTemplates.Name = "cboTemplates"
        Me.cboTemplates.Size = New System.Drawing.Size(136, 21)
        Me.cboTemplates.TabIndex = 18
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabSQLServer)
        Me.TabControl1.Controls.Add(Me.TabAccess)
        Me.TabControl1.Location = New System.Drawing.Point(8, 72)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(296, 152)
        Me.TabControl1.TabIndex = 16
        '
        'TabSQLServer
        '
        Me.TabSQLServer.Controls.Add(Me.Label5)
        Me.TabSQLServer.Controls.Add(Me.Label6)
        Me.TabSQLServer.Controls.Add(Me.Label7)
        Me.TabSQLServer.Controls.Add(Me.Label8)
        Me.TabSQLServer.Controls.Add(Me.txtSQLPassword)
        Me.TabSQLServer.Controls.Add(Me.txtSQLUser)
        Me.TabSQLServer.Controls.Add(Me.txtSQLServer)
        Me.TabSQLServer.Controls.Add(Me.txtSQLDatabase)
        Me.TabSQLServer.Location = New System.Drawing.Point(4, 22)
        Me.TabSQLServer.Name = "TabSQLServer"
        Me.TabSQLServer.Size = New System.Drawing.Size(288, 126)
        Me.TabSQLServer.TabIndex = 0
        Me.TabSQLServer.Text = "SQL Server"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Server:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "User:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Password:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Database:"
        '
        'txtSQLPassword
        '
        Me.txtSQLPassword.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtSQLPassword.Location = New System.Drawing.Point(104, 64)
        Me.txtSQLPassword.Name = "txtSQLPassword"
        Me.txtSQLPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSQLPassword.Size = New System.Drawing.Size(160, 21)
        Me.txtSQLPassword.TabIndex = 10
        '
        'txtSQLUser
        '
        Me.txtSQLUser.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtSQLUser.Location = New System.Drawing.Point(104, 40)
        Me.txtSQLUser.Name = "txtSQLUser"
        Me.txtSQLUser.Size = New System.Drawing.Size(160, 21)
        Me.txtSQLUser.TabIndex = 9
        '
        'txtSQLServer
        '
        Me.txtSQLServer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtSQLServer.Location = New System.Drawing.Point(104, 16)
        Me.txtSQLServer.Name = "txtSQLServer"
        Me.txtSQLServer.Size = New System.Drawing.Size(160, 21)
        Me.txtSQLServer.TabIndex = 8
        '
        'txtSQLDatabase
        '
        Me.txtSQLDatabase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtSQLDatabase.Location = New System.Drawing.Point(104, 88)
        Me.txtSQLDatabase.Name = "txtSQLDatabase"
        Me.txtSQLDatabase.Size = New System.Drawing.Size(160, 21)
        Me.txtSQLDatabase.TabIndex = 11
        '
        'TabAccess
        '
        Me.TabAccess.Controls.Add(Me.Label21)
        Me.TabAccess.Controls.Add(Me.txtAccessPassword)
        Me.TabAccess.Controls.Add(Me.btnChooseAccessFile)
        Me.TabAccess.Controls.Add(Me.txtAccessFilePath)
        Me.TabAccess.Location = New System.Drawing.Point(4, 22)
        Me.TabAccess.Name = "TabAccess"
        Me.TabAccess.Size = New System.Drawing.Size(288, 126)
        Me.TabAccess.TabIndex = 1
        Me.TabAccess.Text = "Access"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label21.Location = New System.Drawing.Point(8, 48)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 13)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "Password"
        '
        'txtAccessPassword
        '
        Me.txtAccessPassword.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtAccessPassword.Location = New System.Drawing.Point(8, 80)
        Me.txtAccessPassword.Name = "txtAccessPassword"
        Me.txtAccessPassword.Size = New System.Drawing.Size(136, 21)
        Me.txtAccessPassword.TabIndex = 8
        '
        'btnChooseAccessFile
        '
        Me.btnChooseAccessFile.Location = New System.Drawing.Point(152, 40)
        Me.btnChooseAccessFile.Name = "btnChooseAccessFile"
        Me.btnChooseAccessFile.Size = New System.Drawing.Size(120, 23)
        Me.btnChooseAccessFile.TabIndex = 1
        Me.btnChooseAccessFile.Text = "Choose Access File"
        '
        'txtAccessFilePath
        '
        Me.txtAccessFilePath.Location = New System.Drawing.Point(8, 16)
        Me.txtAccessFilePath.Name = "txtAccessFilePath"
        Me.txtAccessFilePath.Size = New System.Drawing.Size(264, 20)
        Me.txtAccessFilePath.TabIndex = 0
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Location = New System.Drawing.Point(336, 360)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(104, 23)
        Me.btnTestConnection.TabIndex = 17
        Me.btnTestConnection.Text = "Test Connection"
        '
        'grpEmployee
        '
        Me.grpEmployee.Controls.Add(Me.Label9)
        Me.grpEmployee.Controls.Add(Me.txtEmployeeBirthday)
        Me.grpEmployee.Controls.Add(Me.lblRegDate)
        Me.grpEmployee.Controls.Add(Me.txtEmployeeStartDate)
        Me.grpEmployee.Controls.Add(Me.Label18)
        Me.grpEmployee.Controls.Add(Me.txtEmployeeID)
        Me.grpEmployee.Controls.Add(Me.txtCheckEmployeeDataMap)
        Me.grpEmployee.Controls.Add(Me.Label16)
        Me.grpEmployee.Controls.Add(Me.txtEmployeeGender)
        Me.grpEmployee.Controls.Add(Me.Label13)
        Me.grpEmployee.Controls.Add(Me.txtEmployeeIDPlace)
        Me.grpEmployee.Controls.Add(Me.Label15)
        Me.grpEmployee.Controls.Add(Me.txtEmployeeIDDate)
        Me.grpEmployee.Controls.Add(Me.Label14)
        Me.grpEmployee.Controls.Add(Me.txtEmployeeIDNumber)
        Me.grpEmployee.Controls.Add(Me.lblAddress)
        Me.grpEmployee.Controls.Add(Me.txtEmployeeAddressTemporary)
        Me.grpEmployee.Controls.Add(Me.txtEmployeeLastName)
        Me.grpEmployee.Controls.Add(Me.txtEmployeeMiddleName)
        Me.grpEmployee.Controls.Add(Me.Label11)
        Me.grpEmployee.Controls.Add(Me.txtEmployeeFirstName)
        Me.grpEmployee.Controls.Add(Me.Label10)
        Me.grpEmployee.Controls.Add(Me.txtEmployeeTable)
        Me.grpEmployee.Location = New System.Drawing.Point(336, 8)
        Me.grpEmployee.Name = "grpEmployee"
        Me.grpEmployee.Size = New System.Drawing.Size(448, 176)
        Me.grpEmployee.TabIndex = 12
        Me.grpEmployee.TabStop = False
        Me.grpEmployee.Text = "3 - Employee Data Map"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label9.Location = New System.Drawing.Point(232, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Birthday"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeBirthday
        '
        Me.txtEmployeeBirthday.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtEmployeeBirthday.Location = New System.Drawing.Point(304, 64)
        Me.txtEmployeeBirthday.Name = "txtEmployeeBirthday"
        Me.txtEmployeeBirthday.Size = New System.Drawing.Size(104, 21)
        Me.txtEmployeeBirthday.TabIndex = 33
        '
        'lblRegDate
        '
        Me.lblRegDate.AutoSize = True
        Me.lblRegDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.lblRegDate.Location = New System.Drawing.Point(8, 64)
        Me.lblRegDate.Name = "lblRegDate"
        Me.lblRegDate.Size = New System.Drawing.Size(54, 13)
        Me.lblRegDate.TabIndex = 30
        Me.lblRegDate.Text = "Hide Date"
        Me.lblRegDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeStartDate
        '
        Me.txtEmployeeStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtEmployeeStartDate.Location = New System.Drawing.Point(80, 64)
        Me.txtEmployeeStartDate.Name = "txtEmployeeStartDate"
        Me.txtEmployeeStartDate.Size = New System.Drawing.Size(104, 21)
        Me.txtEmployeeStartDate.TabIndex = 31
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label18.Location = New System.Drawing.Point(200, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 13)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "Employee ID"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtEmployeeID.Location = New System.Drawing.Point(304, 16)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(104, 21)
        Me.txtEmployeeID.TabIndex = 29
        '
        'txtCheckEmployeeDataMap
        '
        Me.txtCheckEmployeeDataMap.Location = New System.Drawing.Point(368, 144)
        Me.txtCheckEmployeeDataMap.Name = "txtCheckEmployeeDataMap"
        Me.txtCheckEmployeeDataMap.Size = New System.Drawing.Size(72, 23)
        Me.txtCheckEmployeeDataMap.TabIndex = 27
        Me.txtCheckEmployeeDataMap.Text = "Test"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label16.Location = New System.Drawing.Point(192, 144)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 13)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Gender"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeGender
        '
        Me.txtEmployeeGender.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtEmployeeGender.Location = New System.Drawing.Point(248, 144)
        Me.txtEmployeeGender.Name = "txtEmployeeGender"
        Me.txtEmployeeGender.Size = New System.Drawing.Size(104, 21)
        Me.txtEmployeeGender.TabIndex = 26
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label13.Location = New System.Drawing.Point(192, 120)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "ID Place"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeIDPlace
        '
        Me.txtEmployeeIDPlace.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtEmployeeIDPlace.Location = New System.Drawing.Point(248, 120)
        Me.txtEmployeeIDPlace.Name = "txtEmployeeIDPlace"
        Me.txtEmployeeIDPlace.Size = New System.Drawing.Size(104, 21)
        Me.txtEmployeeIDPlace.TabIndex = 24
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 144)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "ID Date"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeIDDate
        '
        Me.txtEmployeeIDDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtEmployeeIDDate.Location = New System.Drawing.Point(80, 144)
        Me.txtEmployeeIDDate.Name = "txtEmployeeIDDate"
        Me.txtEmployeeIDDate.Size = New System.Drawing.Size(104, 21)
        Me.txtEmployeeIDDate.TabIndex = 22
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 120)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 13)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "ID Number"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeIDNumber
        '
        Me.txtEmployeeIDNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtEmployeeIDNumber.Location = New System.Drawing.Point(80, 120)
        Me.txtEmployeeIDNumber.Name = "txtEmployeeIDNumber"
        Me.txtEmployeeIDNumber.Size = New System.Drawing.Size(104, 21)
        Me.txtEmployeeIDNumber.TabIndex = 20
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.lblAddress.Location = New System.Drawing.Point(8, 88)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(46, 13)
        Me.lblAddress.TabIndex = 17
        Me.lblAddress.Text = "Address"
        Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeAddressTemporary
        '
        Me.txtEmployeeAddressTemporary.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtEmployeeAddressTemporary.Location = New System.Drawing.Point(80, 88)
        Me.txtEmployeeAddressTemporary.Name = "txtEmployeeAddressTemporary"
        Me.txtEmployeeAddressTemporary.Size = New System.Drawing.Size(104, 21)
        Me.txtEmployeeAddressTemporary.TabIndex = 18
        '
        'txtEmployeeLastName
        '
        Me.txtEmployeeLastName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtEmployeeLastName.Location = New System.Drawing.Point(304, 40)
        Me.txtEmployeeLastName.Name = "txtEmployeeLastName"
        Me.txtEmployeeLastName.Size = New System.Drawing.Size(104, 21)
        Me.txtEmployeeLastName.TabIndex = 16
        '
        'txtEmployeeMiddleName
        '
        Me.txtEmployeeMiddleName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtEmployeeMiddleName.Location = New System.Drawing.Point(192, 40)
        Me.txtEmployeeMiddleName.Name = "txtEmployeeMiddleName"
        Me.txtEmployeeMiddleName.Size = New System.Drawing.Size(104, 21)
        Me.txtEmployeeMiddleName.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Full Name"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeFirstName
        '
        Me.txtEmployeeFirstName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtEmployeeFirstName.Location = New System.Drawing.Point(80, 40)
        Me.txtEmployeeFirstName.Name = "txtEmployeeFirstName"
        Me.txtEmployeeFirstName.Size = New System.Drawing.Size(104, 21)
        Me.txtEmployeeFirstName.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Table Name"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeTable
        '
        Me.txtEmployeeTable.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtEmployeeTable.Location = New System.Drawing.Point(80, 16)
        Me.txtEmployeeTable.Name = "txtEmployeeTable"
        Me.txtEmployeeTable.Size = New System.Drawing.Size(104, 21)
        Me.txtEmployeeTable.TabIndex = 10
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Access 2000-2003 (*.mdb)|*.mdb"
        '
        'grpTimekeeping
        '
        Me.grpTimekeeping.Controls.Add(Me.cbFull8h_AddOT)
        Me.grpTimekeeping.Controls.Add(Me.cbSecond)
        Me.grpTimekeeping.Controls.Add(Me.Label12)
        Me.grpTimekeeping.Controls.Add(Me.txtTimekeepingDate)
        Me.grpTimekeeping.Controls.Add(Me.btnTestTimeKeepping)
        Me.grpTimekeeping.Controls.Add(Me.Label17)
        Me.grpTimekeeping.Controls.Add(Me.txtTimekeepingAccessTime)
        Me.grpTimekeeping.Controls.Add(Me.Label19)
        Me.grpTimekeeping.Controls.Add(Me.txtTimekeepingEmployee)
        Me.grpTimekeeping.Controls.Add(Me.Label23)
        Me.grpTimekeeping.Controls.Add(Me.txtTimekeepingTable)
        Me.grpTimekeeping.Location = New System.Drawing.Point(336, 192)
        Me.grpTimekeeping.Name = "grpTimekeeping"
        Me.grpTimekeeping.Size = New System.Drawing.Size(448, 104)
        Me.grpTimekeeping.TabIndex = 13
        Me.grpTimekeeping.TabStop = False
        Me.grpTimekeeping.Text = "3 - TimeKeeping Data Map"
        '
        'cbFull8h_AddOT
        '
        Me.cbFull8h_AddOT.BackColor = System.Drawing.Color.Transparent
        Me.cbFull8h_AddOT.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbFull8h_AddOT.Location = New System.Drawing.Point(192, 72)
        Me.cbFull8h_AddOT.Name = "cbFull8h_AddOT"
        Me.cbFull8h_AddOT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbFull8h_AddOT.Size = New System.Drawing.Size(152, 19)
        Me.cbFull8h_AddOT.TabIndex = 128
        Me.cbFull8h_AddOT.Text = "Working Full 8h Then OT"
        Me.cbFull8h_AddOT.UseVisualStyleBackColor = False
        '
        'cbSecond
        '
        Me.cbSecond.BackColor = System.Drawing.Color.Transparent
        Me.cbSecond.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbSecond.Location = New System.Drawing.Point(8, 72)
        Me.cbSecond.Name = "cbSecond"
        Me.cbSecond.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbSecond.Size = New System.Drawing.Size(104, 19)
        Me.cbSecond.TabIndex = 127
        Me.cbSecond.Text = "Using Second"
        Me.cbSecond.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label12.Location = New System.Drawing.Point(192, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Date"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTimekeepingDate
        '
        Me.txtTimekeepingDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtTimekeepingDate.Location = New System.Drawing.Point(248, 24)
        Me.txtTimekeepingDate.Name = "txtTimekeepingDate"
        Me.txtTimekeepingDate.Size = New System.Drawing.Size(104, 21)
        Me.txtTimekeepingDate.TabIndex = 30
        '
        'btnTestTimeKeepping
        '
        Me.btnTestTimeKeepping.Location = New System.Drawing.Point(368, 72)
        Me.btnTestTimeKeepping.Name = "btnTestTimeKeepping"
        Me.btnTestTimeKeepping.Size = New System.Drawing.Size(72, 23)
        Me.btnTestTimeKeepping.TabIndex = 28
        Me.btnTestTimeKeepping.Text = "Test"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label17.Location = New System.Drawing.Point(192, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(29, 13)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "Time"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTimekeepingAccessTime
        '
        Me.txtTimekeepingAccessTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtTimekeepingAccessTime.Location = New System.Drawing.Point(248, 48)
        Me.txtTimekeepingAccessTime.Name = "txtTimekeepingAccessTime"
        Me.txtTimekeepingAccessTime.Size = New System.Drawing.Size(104, 21)
        Me.txtTimekeepingAccessTime.TabIndex = 26
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label19.Location = New System.Drawing.Point(8, 48)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "Employee ID"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTimekeepingEmployee
        '
        Me.txtTimekeepingEmployee.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtTimekeepingEmployee.Location = New System.Drawing.Point(80, 48)
        Me.txtTimekeepingEmployee.Name = "txtTimekeepingEmployee"
        Me.txtTimekeepingEmployee.Size = New System.Drawing.Size(104, 21)
        Me.txtTimekeepingEmployee.TabIndex = 22
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label23.Location = New System.Drawing.Point(8, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(63, 13)
        Me.Label23.TabIndex = 9
        Me.Label23.Text = "Table Name"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTimekeepingTable
        '
        Me.txtTimekeepingTable.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtTimekeepingTable.Location = New System.Drawing.Point(80, 24)
        Me.txtTimekeepingTable.Name = "txtTimekeepingTable"
        Me.txtTimekeepingTable.Size = New System.Drawing.Size(104, 21)
        Me.txtTimekeepingTable.TabIndex = 10
        '
        'txt_tkpdb
        '
        Me.txt_tkpdb.Location = New System.Drawing.Point(336, 296)
        Me.txt_tkpdb.Multiline = True
        Me.txt_tkpdb.Name = "txt_tkpdb"
        Me.txt_tkpdb.ReadOnly = True
        Me.txt_tkpdb.Size = New System.Drawing.Size(448, 56)
        Me.txt_tkpdb.TabIndex = 18
        Me.txt_tkpdb.Visible = False
        '
        'txtSQL
        '
        Me.txtSQL.Location = New System.Drawing.Point(336, 296)
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.Size = New System.Drawing.Size(448, 56)
        Me.txtSQL.TabIndex = 19
        '
        'cbConfigSalary
        '
        Me.cbConfigSalary.BackColor = System.Drawing.Color.Transparent
        Me.cbConfigSalary.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbConfigSalary.Location = New System.Drawing.Point(464, 360)
        Me.cbConfigSalary.Name = "cbConfigSalary"
        Me.cbConfigSalary.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbConfigSalary.Size = New System.Drawing.Size(112, 19)
        Me.cbConfigSalary.TabIndex = 128
        Me.cbConfigSalary.Text = "Not Config Salary"
        Me.cbConfigSalary.UseVisualStyleBackColor = False
        '
        'cboDatabaseName
        '
        Me.cboDatabaseName.Location = New System.Drawing.Point(144, 96)
        Me.cboDatabaseName.Name = "cboDatabaseName"
        Me.cboDatabaseName.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboDatabaseName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDatabaseName.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboDatabaseName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboDatabaseName.Size = New System.Drawing.Size(160, 20)
        Me.cboDatabaseName.TabIndex = 129
        '
        'frmServerLogin
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(793, 396)
        Me.Controls.Add(Me.txtSQL)
        Me.Controls.Add(Me.txt_tkpdb)
        Me.Controls.Add(Me.grpTimekeeping)
        Me.Controls.Add(Me.grpEmployee)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnTestConnection)
        Me.Controls.Add(Me.cbConfigSalary)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServerLogin"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Server Login"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabSQLServer.ResumeLayout(False)
        Me.TabSQLServer.PerformLayout()
        Me.TabAccess.ResumeLayout(False)
        Me.TabAccess.PerformLayout()
        Me.grpEmployee.ResumeLayout(False)
        Me.grpEmployee.PerformLayout()
        Me.grpTimekeeping.ResumeLayout(False)
        Me.grpTimekeeping.PerformLayout()
        CType(Me.cboDatabaseName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If txtServer.Text = "" Then
            MsgBox("Please specify Server!", MsgBoxStyle.Information)
            txtServer.Focus()
            Exit Sub
        End If
        If txtServerLogin.Text = "" Then
            MsgBox("Please specify SQL Server login name!", MsgBoxStyle.Information)
            txtServerLogin.Focus()
            Exit Sub
        End If
        If cboDatabaseName.Text = "" Then
            MsgBox("Please specify SQL Server database name!", MsgBoxStyle.Information)
            cboDatabaseName.Focus()
            Exit Sub
        End If

        Dim dsServer As New DataSet
        dsServer.ReadXml(GetAppPath() & "\login.xml")
        With dsServer.Tables(0).Rows(0)
            .Item("path") = txtServer.Text
            .Item("accountserver") = txtServerLogin.Text
            .Item("password") = tvcn.Encode(txtServerPassword.Text)
            .Item("database") = cboDatabaseName.Text

            ''' TimeKeeping Machine Config
            .Item("ConnectionType") = IIf(TabControl1.SelectedIndex = 1, "Access", "SQL")
            .Item("SQLServer") = txtSQLServer.Text
            .Item("SQLUser") = txtSQLUser.Text
            .Item("SQLPassword") = tvcn.Encode(txtSQLPassword.Text)
            .Item("SQLDatabase") = txtSQLDatabase.Text

            .Item("AccessFilePath") = txtAccessFilePath.Text
            .Item("AccessPassword") = txtAccessPassword.Text

            .Item("EmployeeTable") = txtEmployeeTable.Text
            .Item("EmployeeID") = txtEmployeeID.Text
            .Item("EmployeeBirthday") = txtEmployeeBirthday.Text
            .Item("EmployeeAddressTemporary") = txtEmployeeAddressTemporary.Text
            .Item("EmployeeStartDate") = txtEmployeeStartDate.Text
            .Item("EmployeeFirstName") = txtEmployeeFirstName.Text
            .Item("EmployeeMiddleName") = txtEmployeeMiddleName.Text
            .Item("EmployeeLastName") = txtEmployeeLastName.Text
            .Item("EmployeeIDNumber") = txtEmployeeIDNumber.Text
            .Item("EmployeeIDPlace") = txtEmployeeIDPlace.Text
            .Item("EmployeeIDDate") = txtEmployeeIDDate.Text
            .Item("EmployeeGender") = txtEmployeeGender.Text


            .Item("TimekeepingTable") = txtTimekeepingTable.Text
            .Item("TimekeepingDate") = txtTimekeepingDate.Text
            .Item("TimekeepingEmployee") = txtTimekeepingEmployee.Text
            .Item("TimekeepingAccessTime") = txtTimekeepingAccessTime.Text
            .Item("TimekeepingMapSQL") = txtSQL.Text
            .Item("UsingSecond") = cbSecond.Checked.ToString

            'SS
            If cbConfigSalary.Checked = True Then
                .Item("isConfigsalary") = "Yes"
            Else
                .Item("isConfigsalary") = "No"
            End If
            If cbFull8h_AddOT.Checked = True Then
                .Item("full8h") = "Yes"
            Else
                .Item("full8h") = "No"
            End If

            ''' Save TImekeeping Connection
            .Item("tkpdb") = txt_tkpdb.Text
        End With
        dsServer.WriteXml(GetAppPath() & "\login.xml")
        Me.Dispose()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub frmServerLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dsServer As New DataSet
        dsServer.ReadXml(GetAppPath() & "\login.xml")
        With dsServer.Tables(0).Rows(0)
            txtServer.Text = .Item("path")
            txtServerLogin.Text = .Item("accountserver")
            txtServerPassword.Text = tvcn.Decode(.Item("password"))
            cboDatabaseName.Text = .Item("database")
            LockChooseData = .Item("CExDay")
            DatabaseName = .Item("database")

            '''
            If dsServer.Tables(0).Columns.IndexOf("ConnectionType") > 0 Then
                TabControl1.SelectedIndex = IIf(.Item("ConnectionType") = "SQL", 0, 1)

                txtSQLServer.Text = .Item("SQLServer")
                txtSQLUser.Text = .Item("SQLUser")
                txtSQLPassword.Text = tvcn.Decode(.Item("SQLPassword"))
                txtSQLDatabase.Text = .Item("SQLDatabase")

                txtAccessFilePath.Text = .Item("AccessFilePath")
                txtAccessPassword.Text = .Item("AccessPassword")


                ''' DataMap

                txtEmployeeTable.Text = .Item("EmployeeTable")
                txtEmployeeID.Text = .Item("EmployeeID")
                txtEmployeeBirthday.Text = .Item("EmployeeBirthday")
                txtEmployeeAddressTemporary.Text = .Item("EmployeeAddressTemporary")
                txtEmployeeStartDate.Text = .Item("EmployeeStartDate")
                txtEmployeeFirstName.Text = .Item("EmployeeFirstName")
                txtEmployeeMiddleName.Text = .Item("EmployeeMiddleName")
                txtEmployeeLastName.Text = .Item("EmployeeLastName")
                txtEmployeeIDNumber.Text = .Item("EmployeeIDNumber")
                txtEmployeeIDPlace.Text = .Item("EmployeeIDPlace")
                txtEmployeeIDDate.Text = .Item("EmployeeIDDate")
                txtEmployeeGender.Text = .Item("EmployeeGender")

                txtTimekeepingTable.Text = .Item("TimekeepingTable")
                txtTimekeepingDate.Text = .Item("TimekeepingDate")
                txtTimekeepingEmployee.Text = .Item("TimekeepingEmployee")
                txtTimekeepingAccessTime.Text = .Item("TimekeepingAccessTime")
                txtSQL.Text = .Item("TimekeepingMapSQL")
                cbSecond.Checked = CType(.Item("UsingSecond"), Boolean)
                'SS
                If CType(.Item("isconfigsalary"), String).ToLower() = "yes" Then
                    cbConfigSalary.Checked = True
                Else
                    cbConfigSalary.Checked = False
                End If
                If CType(.Item("full8h"), String).ToLower() = "yes" Then
                    cbFull8h_AddOT.Checked = True
                Else
                    cbFull8h_AddOT.Checked = False
                End If
            End If
        End With
    End Sub

    Private Function GetAppPath() As String
        Dim f As New IO.DirectoryInfo(Application.ExecutablePath)
        Return f.Parent.FullName
    End Function

    Private Sub btnChooseAccessFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseAccessFile.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            ''' OK TiepTuc
            txtAccessFilePath.Text = OpenFileDialog1.FileName()
        End If
    End Sub

    Private Sub txtAccess_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccessFilePath.TextChanged
        _ChangeAccessConnection()
    End Sub

    Private Sub _ChangeSQLConnection()
        If TabControl1.SelectedIndex = 0 Then
            ''' DangChonTab Access
            txt_tkpdb.Text = CreateSQLConnectionString(txtSQLServer.Text, txtSQLUser.Text, txtSQLPassword.Text, txtSQLDatabase.Text)
        End If
    End Sub

    Private Sub _ChangeAccessConnection()
        If TabControl1.SelectedIndex = 1 Then
            ''' DangChonTab Access
            txt_tkpdb.Text = CreateAccessConnectionString(txtAccessFilePath.Text, txtAccessPassword.Text)
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        _ChangeAccessConnection()
        _ChangeSQLConnection()
    End Sub

    Private Sub txtTKServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSQLServer.TextChanged
        _ChangeSQLConnection()
    End Sub

    Private Sub txtTKUser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSQLUser.TextChanged
        _ChangeSQLConnection()
    End Sub

    Private Sub txtTKPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSQLPassword.TextChanged
        _ChangeSQLConnection()
    End Sub

    Private Sub txtTKDatabase_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSQLDatabase.TextChanged
        _ChangeSQLConnection()
    End Sub

    Private Sub btnTestConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestConnection.Click
        ''' Test ConnectionToTimekeepingMachine
        Dim dataman As New SmartBooks.BusinessLogic.DbAccess
        If (dataman.CheckConnectToTimeMachine(txt_tkpdb.Text)) Then
            MsgBox("Successful! at " + txt_tkpdb.Text)
        Else
            MsgBox("Error Access! at " + txt_tkpdb.Text)
        End If

    End Sub

    Private Sub btnApplyModule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyModule.Click
        ''' ThucHienSuDung Template Connection
        If cboTemplates.SelectedIndex < 0 Then
            MsgBox("B?n Ph?i Ch?n 1 Máy")
            Exit Sub
        End If
        Dim dsServer As New DataSet
        dsServer.ReadXml(GetAppPath() & "\ConfigTemplate\" & cboTemplates.Text)
        With dsServer.Tables(0).Rows(0)
            TabControl1.SelectedIndex = IIf(.Item("ConnectionType") = "SQL", 0, 1)

            txtSQLServer.Text = .Item("SQLServer")
            txtSQLUser.Text = .Item("SQLUser")
            txtSQLPassword.Text = .Item("SQLPassword")
            txtSQLDatabase.Text = .Item("SQLDatabase")

            'txtAccessFilePath.Text = .Item("AccessFilePath")
            'txtAccessPassword.Text = .Item("AccessPassword")


            txtEmployeeTable.Text = .Item("EmployeeTable")
            txtEmployeeID.Text = .Item("EmployeeID")
            txtEmployeeBirthday.Text = .Item("EmployeeBirthday")
            txtEmployeeAddressTemporary.Text = .Item("EmployeeAddressTemporary")
            txtEmployeeStartDate.Text = .Item("EmployeeStartDate")
            txtEmployeeFirstName.Text = .Item("EmployeeFirstName")
            txtEmployeeMiddleName.Text = .Item("EmployeeMiddleName")
            txtEmployeeLastName.Text = .Item("EmployeeLastName")
            txtEmployeeIDNumber.Text = .Item("EmployeeIDNumber")
            txtEmployeeIDPlace.Text = .Item("EmployeeIDPlace")
            txtEmployeeIDDate.Text = .Item("EmployeeIDDate")
            txtEmployeeGender.Text = .Item("EmployeeGender")

            txtTimekeepingTable.Text = .Item("TimekeepingTable")
            txtTimekeepingEmployee.Text = .Item("TimekeepingEmployee")
            txtTimekeepingDate.Text = .Item("TimekeepingDate")
            txtTimekeepingAccessTime.Text = .Item("TimekeepingAccessTime")
            txtSQL.Text = .Item("TimekeepingMapSQL")
            cbSecond.Checked = CType(.Item("UsingSecond"), Boolean)

        End With

    End Sub

    Private Sub txtCheckEmployeeDataMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCheckEmployeeDataMap.Click
        ''' KiemTraCoTonTaiColumnNayKo
        ''' Test ConnectionToTimekeepingMachine
        Dim dataman As New SmartBooks.BusinessLogic.DbAccess
        ''' Build sql
        Dim sql As String = ""
        Dim item As Control
        If (txtEmployeeTable.Text <> "") Then
            For Each item In grpEmployee.Controls
                If (TypeOf item Is TextBox) Then
                    If (item.Name <> "txtEmployeeTable" And item.Text <> "") Then
                        If (sql <> "") Then
                            sql = sql + ","
                        End If
                        sql = sql + item.Text
                    End If
                End If
            Next
            If (dataman.CheckConnectToTimeMachine(txt_tkpdb.Text, String.Format("SELECT {0} FROM {1}", sql, txtEmployeeTable.Text))) Then
                MsgBox("Successful")
            End If
        End If


    End Sub

    Private Sub btnMauMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMauMay.Click
        ''' Load Template MauMay
        ' make a reference to a directory
        Dim di As New IO.DirectoryInfo(Application.StartupPath() + "\ConfigTemplate\")
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo
        Dim _s As String = ""
        If (cboTemplates.SelectedIndex >= 0) Then
            _s = cboTemplates.SelectedValue
        End If
        cboTemplates.Items.Clear()
        'list the names of all files in the specified directory
        For Each dra In diar1
            cboTemplates.Items.Add(dra.Name)
        Next
        If _s <> "" Then
            cboTemplates.SelectedValue = _s
        End If
    End Sub

    Private Sub btnTestTimeKeepping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestTimeKeepping.Click
        ''' KiemTraCoTonTaiColumnNayKo
        ''' Test ConnectionToTimekeepingMachine
        Dim dataman As New SmartBooks.BusinessLogic.DbAccess
        ''' Build sql
        Dim sql As String = ""
        Dim item As Control
        If (txtTimekeepingTable.Text <> "") Then
            For Each item In grpTimekeeping.Controls
                If (TypeOf item Is TextBox) Then
                    If (item.Name <> "txtTimekeepingTable" And item.Text <> "") Then
                        If (sql <> "") Then
                            sql = sql + ","
                        End If
                        sql = sql + item.Text
                    End If
                End If
            Next
            If (dataman.CheckConnectToTimeMachine(txt_tkpdb.Text, String.Format("SELECT {0} FROM {1}", sql, txtTimekeepingTable.Text))) Then
                MsgBox("Successful")
            End If
        End If
    End Sub

    Private Sub cboDatabaseName_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        cboDatabaseName.EditValue = ""

        If txtServer.Text.Trim = String.Empty OrElse txtServerLogin.Text.Trim = String.Empty Then
            cboDatabaseName.EditValue = String.Empty
            Exit Sub
        End If
        LoadDatabaseName()
    End Sub

    Private Sub LoadDatabaseName()
        'Dim listDBName As New DataTable
        'Dim strConnection As String = "Provider=SQLOLEDB;workstation id=.;packet size=4096;user id=" & txtServerLogin.Text.Trim & ";data source=" & txtServer.Text.Trim & ";persist security info=True;initial catalog=" & cboDatabaseName.ValueMember & ";password=" & txtServerPassword.Text.Trim
        'Dim connection As New OleDb.OleDbConnection(strConnection)

        'Try
        '    connection.Open()
        'Catch ex As Exception

        'End Try

        'If listDBName Is Nothing Then
        '    cboDatabaseName.EditValue = ""
        'Else
        '    listDBName = connection.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Catalogs, New Object() {Nothing})
        '    Dim num As Short = CShort(listDBName.Rows.Count - 1)
        '    Dim i As Short = 0
        '    Dim list_Db As String
        '    Do While (i <= num)
        '        If LockChooseData = "1" Then
        '            If RuntimeHelpers.GetObjectValue(listDBName.Rows.Item(i).Item(0)) = DatabaseName Then
        '                cboDatabaseName.Add(RuntimeHelpers.GetObjectValue(listDBName.Rows.Item(i).Item(0)))
        '            End If
        '        Else
        '            list_Db = RuntimeHelpers.GetObjectValue(listDBName.Rows.Item(i).Item(0))
        '            If list_Db <> "master" And list_Db <> "model" And list_Db <> "Northwind" And list_Db <> "pubs" And list_Db <> "tempdb" And list_Db <> "msdb" Then
        '                cboDatabaseName..Add(RuntimeHelpers.GetObjectValue(listDBName.Rows.Item(i).Item(0)))
        '            End If
        '        End If
        '        i = CShort(i + 1)
        '    Loop

        '    connection.Close()
        'End If
    End Sub

    Private Sub txtAccessPassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccessPassword.TextChanged
        _ChangeAccessConnection()
    End Sub
End Class
