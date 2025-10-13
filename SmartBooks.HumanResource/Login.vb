Imports SmartBooks.BL.TimeKeeping
Imports JSON
Imports System.IO
Imports Newtonsoft.Json
Imports WindowsControlLibrary
Imports System.Net

Public Class Login
    Inherits System.Windows.Forms.Form
    Private WithEvents frmLayout As Form1
    Private obj As New Appsettings.DbSetting
    Private WCobj As New WindowsControlLibrary.DbSetting
    Public Event doIt()
    Private dataman As New SmartBooks.BusinessLogic.DbAccess
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents CheckBoxIsOnline As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnServer As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtusername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtcompanycode As TextBox
    Friend WithEvents txtfromdate As DevExpress.XtraEditors.DateEdit
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
    Friend WithEvents odlgTextFile As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.odlgTextFile = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.CheckBoxIsOnline = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnServer = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtusername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtcompanycode = New System.Windows.Forms.TextBox()
        Me.txtfromdate = New DevExpress.XtraEditors.DateEdit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfromdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBoxIsOnline
        '
        Me.CheckBoxIsOnline.AutoSize = True
        Me.CheckBoxIsOnline.Location = New System.Drawing.Point(104, 172)
        Me.CheckBoxIsOnline.Name = "CheckBoxIsOnline"
        Me.CheckBoxIsOnline.Size = New System.Drawing.Size(134, 17)
        Me.CheckBoxIsOnline.TabIndex = 5
        Me.CheckBoxIsOnline.Text = "Log in with data Online"
        Me.CheckBoxIsOnline.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Company Code:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(320, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        '
        'btnServer
        '
        Me.btnServer.Enabled = False
        Me.btnServer.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnServer.Location = New System.Drawing.Point(8, 197)
        Me.btnServer.Name = "btnServer"
        Me.btnServer.Size = New System.Drawing.Size(80, 23)
        Me.btnServer.TabIndex = 35
        Me.btnServer.Text = "&Server"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(8, 122)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "From date:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Password:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "User name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLogin
        '
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnLogin.Image = CType(resources.GetObject("btnLogin.Image"), System.Drawing.Image)
        Me.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogin.Location = New System.Drawing.Point(144, 197)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(80, 23)
        Me.btnLogin.TabIndex = 33
        Me.btnLogin.Text = "&Login"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Location = New System.Drawing.Point(232, 197)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 23)
        Me.btnCancel.TabIndex = 34
        Me.btnCancel.Text = "Cancel"
        '
        'txtusername
        '
        Me.txtusername.Location = New System.Drawing.Point(104, 71)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(208, 20)
        Me.txtusername.TabIndex = 1
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(104, 95)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(208, 20)
        Me.txtPassword.TabIndex = 2
        '
        'txtcompanycode
        '
        Me.txtcompanycode.Location = New System.Drawing.Point(104, 145)
        Me.txtcompanycode.Name = "txtcompanycode"
        Me.txtcompanycode.Size = New System.Drawing.Size(208, 20)
        Me.txtcompanycode.TabIndex = 4
        '
        'txtfromdate
        '
        Me.txtfromdate.EditValue = Nothing
        Me.txtfromdate.Location = New System.Drawing.Point(103, 120)
        Me.txtfromdate.Name = "txtfromdate"
        Me.txtfromdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtfromdate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtfromdate.Properties.DisplayFormat.FormatString = ""
        Me.txtfromdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtfromdate.Properties.EditFormat.FormatString = ""
        Me.txtfromdate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtfromdate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.txtfromdate.Properties.MaskSettings.Set("mask", "d")
        Me.txtfromdate.Properties.UseMaskAsDisplayFormat = True
        Me.txtfromdate.Size = New System.Drawing.Size(209, 20)
        Me.txtfromdate.TabIndex = 3
        '
        'Login
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(320, 231)
        Me.Controls.Add(Me.txtfromdate)
        Me.Controls.Add(Me.txtcompanycode)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtusername)
        Me.Controls.Add(Me.CheckBoxIsOnline)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnServer)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfromdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Public Property changeUsername() As String
        Get
            Return Me.txtusername.Text.Trim
        End Get
        Set(ByVal Value As String)
            Me.txtusername.Text = Value
        End Set
    End Property
    Public Property changePassword() As String
        Get
            Return Me.txtPassword.Text.Trim
        End Get
        Set(ByVal Value As String)
            Me.txtPassword.Text = Value
        End Set
    End Property
    Private Function txtValidate() As Boolean
        If Me.txtusername.Text = "" Then
            MsgBox("Vui lòng nhập tên người sử dụng", MsgBoxStyle.Exclamation, "Login")
            Return False
        End If
        Return True
    End Function

    Private Function GetServerCompanyInforFromWeb(ByVal companyCode As String) As CompanyInfor
        'Encrypt companyCode
        companyCode = Security.Encrypt(companyCode, True)
        Dim companyCodeInformationUrl As String = "http://dev.ssaudit.com/smartbook/api/hr/get_information?companyCode=" + companyCode
        Dim webClient As WebClient = New WebClient()
        'Return webClient.DownloadString(New Uri(accountInformationUrl))

        Dim cpnInfor As CompanyInfor = JsonConvert.DeserializeObject(Of CompanyInfor)(webClient.DownloadString(New Uri(companyCodeInformationUrl)))
        Try
            If cpnInfor Is Nothing Then
                If obj.Lan = "VN" Then
                    MessageBox.Show("Mã công ty không tồn tại, vui lòng kiểm tra lại", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Company code does not exist, please check again", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                cpnInfor = Nothing
            End If

        Catch ex As WebException
            cpnInfor = Nothing
            If ex.Status = WebExceptionStatus.ProtocolError AndAlso ex.Response IsNot Nothing Then
                Dim resp = DirectCast(ex.Response, HttpWebResponse)
                If resp.StatusCode = HttpStatusCode.NotFound Then
                    ' HTTP 404
                    'other steps you want here
                    If obj.Lan = "VN" Then
                        MessageBox.Show("Mã công ty không tồn tại, vui lòng kiểm tra lại", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("Check the network connection", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                End If
            End If
            'throw any other exception - this should not occur
            Throw
        End Try
        Return cpnInfor

    End Function

    Private Function GetServerCompanyInfor(ByVal companyCode As String) As CompanyInfor
        Try
            Dim JSON As String = File.ReadAllText(Directory.GetCurrentDirectory + "\HR_CompanyInfor.json")
            Dim companyList As CompanyList = JsonConvert.DeserializeObject(Of CompanyList)(JSON)
            Dim CompanyCodeEncrypt As String = Security.Encrypt(companyCode, True)
            Dim cpnInfor As CompanyInfor = companyList.CompanyInfor.Find(Function(p) p.Code = CompanyCodeEncrypt)
            Return cpnInfor
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Enter, btnLogin.Click
        Me.login()
    End Sub
    Private Sub login()
        If Me.txtValidate Then

            'obj.dataPath = "Server=" & Me.txtFileName.Text & ";Database=" & Me.txtdatabase.Text & ";User ID=" & Me.txtusername.Text & ";Password=" & Me.txtPassword.Text & ";Trusted_Connection=False"
            obj.CompanyCode = Me.txtcompanycode.Text
            Dim companyInfor As CompanyInfor
            If CheckBoxIsOnline.Checked Then
                companyInfor = GetServerCompanyInforFromWeb(obj.CompanyCode)
            Else
                companyInfor = GetServerCompanyInfor(obj.CompanyCode)
            End If

            'Decrypt CompanyInfor
            companyInfor.ID = companyInfor.ID
            companyInfor.Name = companyInfor.Name
            companyInfor.DatabaseName = Security.Decrypt(companyInfor.DatabaseName)
            companyInfor.UserID = Security.Decrypt(companyInfor.UserID)
            companyInfor.Password = Security.Decrypt(companyInfor.Password)
            companyInfor.ServerName = Security.Decrypt(companyInfor.ServerName)
            companyInfor.Code = obj.CompanyCode

            Dim dsUser As New DataSet
            dsUser.ReadXml(GetAppPath() & "\login.xml")
            'obj.dataPath = "Server=" & Me.txtFileName.Text & ";Database=" & Me.txtdatabase.Text & ";User ID=" & Me.txtusername.Text & ";Password=" & Me.txtPassword.Text & ";Trusted_Connection=False"
            'If CType(Me.txtfromdate.Text, Date).Year > 2004 AndAlso CType(Me.txtfromdate.Text, Date).Month > 4 Then
            '    'Exit Sub
            'End If
            'Dim tkpdb As String
            'With dsUser.Tables(0).Rows(0)
            obj.dataPath = "Server=" & companyInfor.ServerName & ";Database=" & companyInfor.DatabaseName & ";User ID=" & companyInfor.UserID & ";Password=" & companyInfor.Password & ";Trusted_Connection=False"

            server = companyInfor.ServerName
            WindowsControlLibrary.PublicFunction.server = companyInfor.ServerName
            data = companyInfor.DatabaseName
            WindowsControlLibrary.PublicFunction.data = companyInfor.DatabaseName
            uid = companyInfor.UserID
            WindowsControlLibrary.PublicFunction.uid = companyInfor.UserID
            pass = companyInfor.Password
            WindowsControlLibrary.PublicFunction.pass = companyInfor.Password
            'Appsettings.DbSetting.Terminal = .Item("Terminal")
            obj.Lan = dsUser.Tables(0).Rows(0).Item("lang")
            'tkpdb = .Item("tkpdb")
            'Appsettings.DbSetting.AccessFilePath = .Item("AccessFilePath")
            'Appsettings.DbSetting.AccessPassword = .Item("AccessPassword")
            'Appsettings.DbSetting.tkpdatapath = tkpdb
            'Thư viện WindowsControlLibrary
            WCobj.dataPath = "Server=" & companyInfor.ServerName & ";Database=" & companyInfor.DatabaseName & ";User ID=" & companyInfor.UserID & ";Password=" & companyInfor.Password & ";Trusted_Connection=False"
            WCobj.Lan = dsUser.Tables(0).Rows(0).Item("lang")
            'End With

            obj.UserName = Me.txtusername.Text
            obj.fromdate = Me.txtfromdate.EditValue
            'Thư viện WindowsControlLibrary
            WCobj.UserName = Me.txtusername.Text
            WCobj.fromdate = Me.txtfromdate.EditValue
            WCobj.CompanyCode = Me.txtcompanycode.Text

            obj.dataPath1 = "PageTimeout=5;FIL=MS Access;MaxBufferSize=2048;DSN=IDTECK1;UID=admin;DBQ=Z:\Program Files\IDTECK\STAR505R,FINGER007V40(English)\Master.mdb;DriverId=25"
            obj.dataPath2 = " Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=fdmsamho; Data Source= ;Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=" & "Microsoft.Jet.OLEDB.4.0" & ";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False"
            Dim thang, nam As Integer
            thang = Me.txtfromdate.EditValue.Month
            nam = Me.txtfromdate.EditValue.Year
            obj.DKN = nam.ToString & obj.todatestr(thang)
            With dsUser.Tables(0).Rows(0)
                .Item("username") = Me.txtusername.Text
                .Item("fromdate") = Me.txtfromdate.Text
                .Item("CompanyCode") = Me.txtcompanycode.Text
                .Item("lang") = obj.Lan
                .Item("UseInforOnline") = Me.CheckBoxIsOnline.Checked
            End With
            Try
                Dim dataman As New BusinessLogic.DbAccess
                Dim user As New SmartBooks.BusinessLogic.UserPermission
                '=====================
                'If obj.username.ToUpper Like "ADMIN*" Then
                'obj.Level = 3
                'ElseIf obj.username.ToUpper Like "SUP*" Then
                '    obj.Level = 3
                'ElseIf obj.username.ToUpper Like "EDIT*" Then
                obj.Level = 2
                'ElseIf obj.username.ToUpper Like "ADD*" Then
                '    obj.Level = 1
                'Else
                '    obj.Level = 0
                'End If
                '=========================

                dsUser.WriteXml(GetAppPath() & "\login.xml")
                If user.CheckExsitUser(Me.txtusername.Text) = True Then
                    If user.CheckUserNameAndPassword(Me.txtusername.Text, Me.txtPassword.Text) = True Then
                        Appsettings.DbSetting.UserLogin = txtusername.Text
                        Appsettings.DbSetting.PassUser = txtPassword.Text
                        Appsettings.DbSetting.DayWork = txtfromdate.EditValue
                        RaiseEvent doIt()
                    Else
                        MsgBox("Incorrect Password !!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Else
                    MsgBox("Invalid user.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                Dim kn As New connect(WCobj.dataPath)
                Dim tabUser As DataTable = kn.ReadData("select QuyenTruyXuat from [user] where username='" + txtusername.Text + "'", "TABLE")
                If Not IsDBNull(tabUser.Rows(0)("QuyenTruyXuat")) Then
                    WCobj.PARA_FACTORY_ID = tabUser.Rows(0)("QuyenTruyXuat")
                End If
                Me.Close()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub
    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtusername.Select()
        Dim dsUser As New DataSet
        dsUser.ReadXml(GetAppPath() & "\login.xml")
        txtfromdate.EditValue = Today

        With dsUser.Tables(0).Rows(0)
            Me.txtusername.Text = .Item("username")
            Me.txtcompanycode.Text = .Item("CompanyCode")
            Me.CheckBoxIsOnline.Checked = .Item("UseInforOnline")
            'Me.txtdatabase.Text = .Item("database")
            'Me.txtFileName.Text = .Item("path")
            'Me.txtfromdate.Text = .Item("fromdate")
        End With
    End Sub
    Private Function GetAppPath() As String
        Dim f As New IO.DirectoryInfo(Application.ExecutablePath)
        Return f.Parent.FullName
    End Function
    Private Sub btnServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnServer.Click
        Dim serverlogin As New frmServerLogin
        serverlogin.ShowDialog(Me)
    End Sub
End Class