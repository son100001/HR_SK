Imports System.Windows.Forms
Imports System.Drawing

''' <summary>
''' Dialog gửi thông báo công/lương lên web cho nhân viên.
''' Form gọi cần gán trước khi ShowDialog:
'''   DanhSachAll      - toàn bộ Employee_ID trong kỳ (distinct, từ DataTable của lưới)
'''   DanhSachSelected - Employee_ID các dòng đang chọn trên lưới
'''   TypeOfNoti       - "TimeKeepingNotice_yyyyMM" hoặc "SalaryNotice_yyyyMM"
'''   TieuDe           - tiêu đề push, vd "HR · Thông báo công tháng 6/2026"
'''   ActionUrl        - route web mở khi bấm thông báo
'''   DefaultMessage   - nội dung gợi ý sẵn cho HR sửa
''' </summary>
Public Class frmGuiThongBaoWeb
    Inherits Form

    Public DanhSachAll As New List(Of String)
    Public DanhSachSelected As New List(Of String)
    Public TypeOfNoti As String = ""
    Public TieuDe As String = ""
    Public ActionUrl As String = ""
    Public DefaultMessage As String = ""

    Private rdoAll As RadioButton
    Private rdoSelected As RadioButton
    Private lblSoNguoiNhan As Label
    Private lblNoiDung As Label
    Private txtMessage As TextBox
    Private btnSend As Button
    Private btnCancel As Button

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "Gửi thông báo lên web"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterParent
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ClientSize = New Size(520, 320)
        Me.Font = New Font("Segoe UI", 9.0F)

        rdoAll = New RadioButton()
        rdoAll.Location = New Point(16, 14)
        rdoAll.Size = New Size(480, 22)
        rdoAll.Checked = True
        Me.Controls.Add(rdoAll)

        rdoSelected = New RadioButton()
        rdoSelected.Location = New Point(16, 40)
        rdoSelected.Size = New Size(480, 22)
        Me.Controls.Add(rdoSelected)

        lblSoNguoiNhan = New Label()
        lblSoNguoiNhan.Location = New Point(16, 68)
        lblSoNguoiNhan.Size = New Size(480, 20)
        lblSoNguoiNhan.ForeColor = Color.DarkBlue
        Me.Controls.Add(lblSoNguoiNhan)

        lblNoiDung = New Label()
        lblNoiDung.Location = New Point(16, 94)
        lblNoiDung.Size = New Size(480, 20)
        lblNoiDung.Text = "Nội dung thông báo:"
        Me.Controls.Add(lblNoiDung)

        txtMessage = New TextBox()
        txtMessage.Location = New Point(16, 116)
        txtMessage.Size = New Size(488, 150)
        txtMessage.Multiline = True
        txtMessage.MaxLength = 450
        txtMessage.ScrollBars = ScrollBars.Vertical
        Me.Controls.Add(txtMessage)

        btnSend = New Button()
        btnSend.Location = New Point(316, 278)
        btnSend.Size = New Size(90, 30)
        btnSend.Text = "Gửi"
        Me.Controls.Add(btnSend)

        btnCancel = New Button()
        btnCancel.Location = New Point(414, 278)
        btnCancel.Size = New Size(90, 30)
        btnCancel.Text = "Hủy"
        Me.Controls.Add(btnCancel)
        Me.CancelButton = btnCancel

        AddHandler Me.Load, AddressOf frmGuiThongBaoWeb_Load
        AddHandler rdoAll.CheckedChanged, AddressOf CapNhatSoNguoiNhan
        AddHandler rdoSelected.CheckedChanged, AddressOf CapNhatSoNguoiNhan
        AddHandler btnSend.Click, AddressOf btnSend_Click
        AddHandler btnCancel.Click, Sub() Me.Close()
    End Sub

    Private Sub frmGuiThongBaoWeb_Load(ByVal sender As Object, ByVal e As EventArgs)
        If TieuDe <> String.Empty Then
            Me.Text = TieuDe
        End If
        rdoAll.Text = "Tất cả nhân viên trong kỳ (" & DanhSachAll.Count & ")"
        rdoSelected.Text = "Nhân viên đang chọn trên lưới (" & DanhSachSelected.Count & ")"
        If DanhSachSelected.Count = 0 Then
            rdoSelected.Enabled = False
        End If
        txtMessage.Text = DefaultMessage
        CapNhatSoNguoiNhan(Nothing, Nothing)
    End Sub

    Private Sub CapNhatSoNguoiNhan(ByVal sender As Object, ByVal e As EventArgs)
        Dim soNguoi As Integer = If(rdoAll.Checked, DanhSachAll.Count, DanhSachSelected.Count)
        lblSoNguoiNhan.Text = "Số người nhận: " & soNguoi
    End Sub

    Private Sub btnSend_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim danhSach As List(Of String) = If(rdoAll.Checked, DanhSachAll, DanhSachSelected)

        If txtMessage.Text.Trim = String.Empty Then
            MessageBox.Show("Vui lòng nhập nội dung thông báo.", "Gửi thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If danhSach.Count = 0 Then
            MessageBox.Show("Bạn vui lòng chọn nhân viên trên lưới.", "Gửi thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("Gửi thông báo tới " & danhSach.Count & " nhân viên?", "Gửi thông báo",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If

        Dim errorMsg As String = String.Empty
        Me.Cursor = Cursors.WaitCursor
        btnSend.Enabled = False
        Try
            If WebNotificationClient.GuiThongBao(TypeOfNoti, TieuDe, txtMessage.Text.Trim,
                                                 ActionUrl, danhSach, errorMsg) Then
                MessageBox.Show("Đã gửi thông báo tới " & danhSach.Count & " nhân viên.", "Gửi thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                ' Giữ dialog mở để HR sửa và thử lại
                MessageBox.Show("Không gửi được thông báo: " & errorMsg, "Gửi thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            Me.Cursor = Cursors.Default
            btnSend.Enabled = True
        End Try
    End Sub

End Class
