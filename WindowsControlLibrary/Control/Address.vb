Public Class Address
    Inherits System.Windows.Forms.UserControl
    Dim kn As New connect(DbSetting.dataPath)

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents PhuongXa As Windows.Forms.ComboBox
    Friend WithEvents QuanHuyen As Windows.Forms.ComboBox
    Friend WithEvents SoNhaThonXom As Windows.Forms.TextBox
    Friend WithEvents TinhTP As Windows.Forms.ComboBox
    Friend WithEvents Khu As Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PhuongXa = New System.Windows.Forms.ComboBox()
        Me.QuanHuyen = New System.Windows.Forms.ComboBox()
        Me.SoNhaThonXom = New System.Windows.Forms.TextBox()
        Me.TinhTP = New System.Windows.Forms.ComboBox()
        Me.Khu = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'PhuongXa
        '
        Me.PhuongXa.DisplayMember = "TenPhuongXa"
        Me.PhuongXa.FormattingEnabled = True
        Me.PhuongXa.Location = New System.Drawing.Point(241, 3)
        Me.PhuongXa.Name = "PhuongXa"
        Me.PhuongXa.Size = New System.Drawing.Size(141, 21)
        Me.PhuongXa.TabIndex = 91
        Me.PhuongXa.ValueMember = "TenPhuongXa"
        '
        'QuanHuyen
        '
        Me.QuanHuyen.DisplayMember = "TenQuanHuyen"
        Me.QuanHuyen.FormattingEnabled = True
        Me.QuanHuyen.Location = New System.Drawing.Point(388, 3)
        Me.QuanHuyen.Name = "QuanHuyen"
        Me.QuanHuyen.Size = New System.Drawing.Size(141, 21)
        Me.QuanHuyen.TabIndex = 92
        Me.QuanHuyen.ValueMember = "TenQuanHuyen"
        '
        'SoNhaThonXom
        '
        Me.SoNhaThonXom.Location = New System.Drawing.Point(3, 3)
        Me.SoNhaThonXom.Name = "SoNhaThonXom"
        Me.SoNhaThonXom.Size = New System.Drawing.Size(113, 20)
        Me.SoNhaThonXom.TabIndex = 1
        '
        'TinhTP
        '
        Me.TinhTP.DisplayMember = "TenTinhThanhPho"
        Me.TinhTP.FormattingEnabled = True
        Me.TinhTP.Location = New System.Drawing.Point(535, 3)
        Me.TinhTP.Name = "TinhTP"
        Me.TinhTP.Size = New System.Drawing.Size(141, 21)
        Me.TinhTP.TabIndex = 93
        Me.TinhTP.ValueMember = "TenTinhThanhPho"
        '
        'Khu
        '
        Me.Khu.Location = New System.Drawing.Point(122, 3)
        Me.Khu.Name = "Khu"
        Me.Khu.Size = New System.Drawing.Size(113, 20)
        Me.Khu.TabIndex = 94
        '
        'Address
        '
        Me.Controls.Add(Me.Khu)
        Me.Controls.Add(Me.TinhTP)
        Me.Controls.Add(Me.QuanHuyen)
        Me.Controls.Add(Me.PhuongXa)
        Me.Controls.Add(Me.SoNhaThonXom)
        Me.Name = "Address"
        Me.Size = New System.Drawing.Size(682, 30)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Address_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim px, qh, ttp As String
        px = PhuongXa.Text.Trim
        qh = QuanHuyen.Text.Trim
        ttp = TinhTP.Text.Trim
        LoadPhuongXa()
        LoadQuanHuyen()
        LoadTinhTP()
        PhuongXa.Text = px
        QuanHuyen.Text = qh
        TinhTP.Text = ttp
    End Sub

    Overrides Property Text() As String
        Get
            Return IIf(SoNhaThonXom.Text.Trim = String.Empty, "", SoNhaThonXom.Text.Trim + " - ") + IIf(Khu.Text.Trim = String.Empty, "", Khu.Text.Trim + " - ") + IIf(PhuongXa.Text.Trim = String.Empty, "", PhuongXa.Text.Trim + " - ") + IIf(QuanHuyen.Text.Trim = String.Empty, "", QuanHuyen.Text.Trim + " - ") + IIf(TinhTP.Text.Trim = String.Empty, "", TinhTP.Text.Trim)
        End Get
        Set(ByVal Value As String)
            TinhTP.Text = String.Empty
            QuanHuyen.Text = String.Empty
            PhuongXa.Text = String.Empty
            Khu.Text = String.Empty
            SoNhaThonXom.Text = String.Empty
            Dim str As String() = Value.Split("-")
            If str.Length = 5 Then
                TinhTP.Text = str(4).Trim
                QuanHuyen.Text = str(3).Trim
                PhuongXa.Text = str(2).Trim
                Khu.Text = str(1).Trim
                SoNhaThonXom.Text = str(0).Trim
            ElseIf str.Length = 4 Then
                TinhTP.Text = str(3).Trim
                QuanHuyen.Text = str(2).Trim
                PhuongXa.Text = str(1).Trim
                Khu.Text = str(0).Trim
            ElseIf str.Length = 3 Then
                TinhTP.Text = str(2).Trim
                QuanHuyen.Text = str(1).Trim
                PhuongXa.Text = str(0).Trim
            ElseIf str.Length = 2 Then
                TinhTP.Text = str(1).Trim
                QuanHuyen.Text = str(0).Trim
            ElseIf str.Length = 1 Then
                TinhTP.Text = str(0).Trim
            End If
        End Set
    End Property

    Private Sub LoadPhuongXa()
        PhuongXa.DataSource = kn.ReadData("select TenPhuongXa from HR_PhuongXa", "table")
    End Sub

    Private Sub LoadQuanHuyen()
        QuanHuyen.DataSource = kn.ReadData("select TenQuanHuyen from HR_QuanHuyen", "table")
    End Sub

    Private Sub LoadTinhTP()
        TinhTP.DataSource = kn.ReadData("select TenTinhThanhPho from HR_TinhThanhPho", "table")
    End Sub
End Class
