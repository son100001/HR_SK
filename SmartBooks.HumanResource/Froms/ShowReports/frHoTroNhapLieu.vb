Imports System.Text.RegularExpressions
Imports Appsettings
Public Class frHoTroNhapLieu
    Inherits System.Windows.Forms.Form
    Dim kn As New connect(DbSetting.dataPath)

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
    Friend WithEvents rtbGoc As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbHoTen As System.Windows.Forms.RadioButton
    Friend WithEvents rdbThoiGian As System.Windows.Forms.RadioButton
    Friend WithEvents rdbDiaChi As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btThucHien As System.Windows.Forms.Button
    Friend WithEvents rtbDich1 As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbDich2 As System.Windows.Forms.RichTextBox
    Friend WithEvents rdbThangNgayNam As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNgayThangNam As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNamThangNgay As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btCapNhatCSDL As System.Windows.Forms.Button
    Friend WithEvents rtbSQL As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.rtbGoc = New System.Windows.Forms.RichTextBox
        Me.rtbDich1 = New System.Windows.Forms.RichTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdbDiaChi = New System.Windows.Forms.RadioButton
        Me.rdbThoiGian = New System.Windows.Forms.RadioButton
        Me.rdbHoTen = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rdbNamThangNgay = New System.Windows.Forms.RadioButton
        Me.rdbThangNgayNam = New System.Windows.Forms.RadioButton
        Me.rdbNgayThangNam = New System.Windows.Forms.RadioButton
        Me.btThucHien = New System.Windows.Forms.Button
        Me.rtbDich2 = New System.Windows.Forms.RichTextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btCapNhatCSDL = New System.Windows.Forms.Button
        Me.rtbSQL = New System.Windows.Forms.RichTextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbGoc
        '
        Me.rtbGoc.Location = New System.Drawing.Point(8, 136)
        Me.rtbGoc.Name = "rtbGoc"
        Me.rtbGoc.Size = New System.Drawing.Size(184, 352)
        Me.rtbGoc.TabIndex = 0
        Me.rtbGoc.Text = ""
        '
        'rtbDich1
        '
        Me.rtbDich1.Location = New System.Drawing.Point(280, 136)
        Me.rtbDich1.Name = "rtbDich1"
        Me.rtbDich1.Size = New System.Drawing.Size(152, 352)
        Me.rtbDich1.TabIndex = 1
        Me.rtbDich1.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbDiaChi)
        Me.GroupBox1.Controls.Add(Me.rdbThoiGian)
        Me.GroupBox1.Controls.Add(Me.rdbHoTen)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 96)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Trường chuyển đổi"
        '
        'rdbDiaChi
        '
        Me.rdbDiaChi.Location = New System.Drawing.Point(16, 64)
        Me.rdbDiaChi.Name = "rdbDiaChi"
        Me.rdbDiaChi.TabIndex = 2
        Me.rdbDiaChi.Text = "Địa chỉ"
        '
        'rdbThoiGian
        '
        Me.rdbThoiGian.Location = New System.Drawing.Point(16, 40)
        Me.rdbThoiGian.Name = "rdbThoiGian"
        Me.rdbThoiGian.TabIndex = 1
        Me.rdbThoiGian.Text = "Thời gian"
        '
        'rdbHoTen
        '
        Me.rdbHoTen.Location = New System.Drawing.Point(16, 16)
        Me.rdbHoTen.Name = "rdbHoTen"
        Me.rdbHoTen.TabIndex = 0
        Me.rdbHoTen.Text = "Họ tên"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdbNamThangNgay)
        Me.GroupBox2.Controls.Add(Me.rdbThangNgayNam)
        Me.GroupBox2.Controls.Add(Me.rdbNgayThangNam)
        Me.GroupBox2.Location = New System.Drawing.Point(176, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 96)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tùy chọn định dạng giờ"
        '
        'rdbNamThangNgay
        '
        Me.rdbNamThangNgay.Location = New System.Drawing.Point(16, 64)
        Me.rdbNamThangNgay.Name = "rdbNamThangNgay"
        Me.rdbNamThangNgay.Size = New System.Drawing.Size(120, 24)
        Me.rdbNamThangNgay.TabIndex = 5
        Me.rdbNamThangNgay.Text = "Năm tháng ngày"
        '
        'rdbThangNgayNam
        '
        Me.rdbThangNgayNam.Location = New System.Drawing.Point(16, 40)
        Me.rdbThangNgayNam.Name = "rdbThangNgayNam"
        Me.rdbThangNgayNam.Size = New System.Drawing.Size(120, 24)
        Me.rdbThangNgayNam.TabIndex = 4
        Me.rdbThangNgayNam.Text = "Tháng ngày năm"
        '
        'rdbNgayThangNam
        '
        Me.rdbNgayThangNam.Location = New System.Drawing.Point(16, 16)
        Me.rdbNgayThangNam.Name = "rdbNgayThangNam"
        Me.rdbNgayThangNam.Size = New System.Drawing.Size(120, 24)
        Me.rdbNgayThangNam.TabIndex = 3
        Me.rdbNgayThangNam.Text = "Ngày tháng năm"
        '
        'btThucHien
        '
        Me.btThucHien.Location = New System.Drawing.Point(200, 280)
        Me.btThucHien.Name = "btThucHien"
        Me.btThucHien.TabIndex = 4
        Me.btThucHien.Text = "Thực hiện"
        '
        'rtbDich2
        '
        Me.rtbDich2.Location = New System.Drawing.Point(480, 136)
        Me.rtbDich2.Name = "rtbDich2"
        Me.rtbDich2.Size = New System.Drawing.Size(152, 352)
        Me.rtbDich2.TabIndex = 5
        Me.rtbDich2.Text = ""
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btCapNhatCSDL)
        Me.GroupBox3.Controls.Add(Me.rtbSQL)
        Me.GroupBox3.Location = New System.Drawing.Point(640, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(408, 472)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cập nhật cơ sở dữ liệu"
        '
        'btCapNhatCSDL
        '
        Me.btCapNhatCSDL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCapNhatCSDL.Location = New System.Drawing.Point(320, 440)
        Me.btCapNhatCSDL.Name = "btCapNhatCSDL"
        Me.btCapNhatCSDL.TabIndex = 5
        Me.btCapNhatCSDL.Text = "Cập nhật"
        '
        'rtbSQL
        '
        Me.rtbSQL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbSQL.Location = New System.Drawing.Point(8, 24)
        Me.rtbSQL.Name = "rtbSQL"
        Me.rtbSQL.Size = New System.Drawing.Size(392, 400)
        Me.rtbSQL.TabIndex = 1
        Me.rtbSQL.Text = ""
        '
        'frHoTroNhapLieu
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1056, 490)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.rtbDich2)
        Me.Controls.Add(Me.btThucHien)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rtbDich1)
        Me.Controls.Add(Me.rtbGoc)
        Me.Name = "frHoTroNhapLieu"
        Me.Text = "frHoTroNhapLieu"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub rdbThoiGian_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbThoiGian.CheckedChanged
        GroupBox2.Visible = True
    End Sub

    Private Sub rdbHoTen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbHoTen.CheckedChanged
        GroupBox2.Visible = False
    End Sub

    Private Sub rdbDiaChi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDiaChi.CheckedChanged
        GroupBox2.Visible = False
    End Sub

    Private Sub btThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btThucHien.Click
        Dim Sgoc As String
        If rdbHoTen.Checked = True Then
            Sgoc = Regex.Replace(rtbGoc.Text.Trim, "([ ]+)", " ")
            Sgoc = Sgoc + "-"
            Sgoc = Sgoc.Replace("-"c, CChar(vbLf))
            Sgoc = Regex.Replace(Sgoc, "([\s])([^\s]+[\n])", "-$2")
            Sgoc = Sgoc.Replace("-"c, CChar(vbTab))
            rtbDich1.Text = Sgoc.Trim
        ElseIf rdbThoiGian.Checked = True Then
            Dim tnn As String = String.Empty
            Dim i As Integer
            If rdbNgayThangNam.Checked = True Then
                i = 0
                For Each line As String In rtbGoc.Lines
                    line = Regex.Replace(line.Trim, "([ ]+)", "")
                    Dim s As String() = Split(line.Replace("/", "-").Replace("\", "-"), "-")
                    Try
                        tnn = tnn + s(2) + "-" + s(1) + "-" + s(0) + " "
                    Catch ex As Exception
                        MessageBox.Show("Bạn kiểm tra lại đầu vào bị sai. Giá trị sai: " + Line + ", dòng thứ: " + i.ToString)
                        Exit Sub
                    End Try
                    i += 1
                Next
                rtbDich1.Text = tnn.Replace(" "c, CChar(vbLf))
            ElseIf rdbThangNgayNam.Checked = True Then
                i = 0
                For Each line As String In rtbGoc.Lines
                    line = Regex.Replace(line.Trim, "([ ]+)", "")
                    Dim s As String() = Split(line.Replace("/", "-").Replace("\", "-"), "-")
                    Try
                        tnn = tnn + s(2) + "-" + s(0) + "-" + s(1) + " "
                    Catch ex As Exception
                        MessageBox.Show("Bạn kiểm tra lại đầu vào bị sai. Giá trị sai: " + Line + ", dòng thứ: " + i.ToString)
                        Exit Sub
                    End Try
                    i += 1
                Next
                rtbDich1.Text = tnn.Replace(" "c, CChar(vbLf))
            Else
                i = 0
                For Each line As String In rtbGoc.Lines
                    line = Regex.Replace(line.Trim, "([ ]+)", "")
                    Dim s As String() = Split(line.Replace("/", "-").Replace("\", "-"), "-")
                    Try
                        tnn = tnn + s(0) + "-" + s(1) + "-" + s(2) + " "
                    Catch ex As Exception
                        MessageBox.Show("Bạn kiểm tra lại đầu vào bị sai. Giá trị sai: " + Line + ", dòng thứ: " + i.ToString)
                        Exit Sub
                    End Try
                    i += 1
                Next
                rtbDich1.Text = tnn.Replace(" "c, CChar(vbLf))
            End If
        Else

        End If
    End Sub

    Private Sub frHoTroNhapLieu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GroupBox2.Visible = False
    End Sub

    Private Sub btCapNhatCSDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapNhatCSDL.Click
        If kn.SaveData(rtbSQL.Text) Then
            MessageBox.Show("Cập nhật thành công!")
        End If
    End Sub

End Class
