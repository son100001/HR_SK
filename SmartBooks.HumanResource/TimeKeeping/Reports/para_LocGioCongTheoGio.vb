Imports Appsettings
Imports VBReport
Imports SmartBooks.BusinessLogic
Imports System.Globalization
Imports System.IO
Imports Excel1 = Microsoft.Office.Interop.Excel
Imports DevExpress.XtraEditors.Controls

Public Class para_LocGioCongTheoGio
    Inherits System.Windows.Forms.Form
    Private obj As New Appsettings.DbSetting
    Private user As New BusinessLogic.UserPermission
    Dim timekeeping As New Giang_TimeKeeping
    Dim Quyen As String = timekeeping.KiemTraQuyen("GioCongNgoaiLeBangDoc")
    Dim kn As New connect(DbSetting.dataPath)
    Dim tvcn As New ThuVienChucNang
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPercent As DevExpress.XtraEditors.LookUpEdit
    Dim tab_BangCong As DataTable

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
    Friend WithEvents rdbAll As System.Windows.Forms.RadioButton
    Friend WithEvents rdbBang As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNhoHonHoacBang As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNhoHon As System.Windows.Forms.RadioButton
    Friend WithEvents rdbLonHonHoacBang As System.Windows.Forms.RadioButton
    Friend WithEvents rdbLonHon As System.Windows.Forms.RadioButton
    Friend WithEvents tbPhepNam As System.Windows.Forms.TextBox
    Friend WithEvents cb_All As System.Windows.Forms.CheckBox
    Friend WithEvents lbLoaiCong As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.rdbAll = New System.Windows.Forms.RadioButton()
        Me.rdbBang = New System.Windows.Forms.RadioButton()
        Me.rdbNhoHonHoacBang = New System.Windows.Forms.RadioButton()
        Me.rdbNhoHon = New System.Windows.Forms.RadioButton()
        Me.rdbLonHonHoacBang = New System.Windows.Forms.RadioButton()
        Me.rdbLonHon = New System.Windows.Forms.RadioButton()
        Me.tbPhepNam = New System.Windows.Forms.TextBox()
        Me.lbLoaiCong = New System.Windows.Forms.Label()
        Me.cb_All = New System.Windows.Forms.CheckBox()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.txtPercent = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.txtPercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rdbAll
        '
        Me.rdbAll.Checked = True
        Me.rdbAll.Location = New System.Drawing.Point(88, 64)
        Me.rdbAll.Name = "rdbAll"
        Me.rdbAll.Size = New System.Drawing.Size(104, 24)
        Me.rdbAll.TabIndex = 64
        Me.rdbAll.TabStop = True
        Me.rdbAll.Text = "All"
        '
        'rdbBang
        '
        Me.rdbBang.Location = New System.Drawing.Point(88, 184)
        Me.rdbBang.Name = "rdbBang"
        Me.rdbBang.Size = New System.Drawing.Size(104, 24)
        Me.rdbBang.TabIndex = 62
        Me.rdbBang.Text = "="
        '
        'rdbNhoHonHoacBang
        '
        Me.rdbNhoHonHoacBang.Location = New System.Drawing.Point(88, 160)
        Me.rdbNhoHonHoacBang.Name = "rdbNhoHonHoacBang"
        Me.rdbNhoHonHoacBang.Size = New System.Drawing.Size(104, 24)
        Me.rdbNhoHonHoacBang.TabIndex = 61
        Me.rdbNhoHonHoacBang.Text = "<="
        '
        'rdbNhoHon
        '
        Me.rdbNhoHon.Location = New System.Drawing.Point(88, 136)
        Me.rdbNhoHon.Name = "rdbNhoHon"
        Me.rdbNhoHon.Size = New System.Drawing.Size(104, 24)
        Me.rdbNhoHon.TabIndex = 60
        Me.rdbNhoHon.Text = "<"
        '
        'rdbLonHonHoacBang
        '
        Me.rdbLonHonHoacBang.Location = New System.Drawing.Point(88, 112)
        Me.rdbLonHonHoacBang.Name = "rdbLonHonHoacBang"
        Me.rdbLonHonHoacBang.Size = New System.Drawing.Size(104, 24)
        Me.rdbLonHonHoacBang.TabIndex = 59
        Me.rdbLonHonHoacBang.Text = ">="
        '
        'rdbLonHon
        '
        Me.rdbLonHon.Location = New System.Drawing.Point(88, 88)
        Me.rdbLonHon.Name = "rdbLonHon"
        Me.rdbLonHon.Size = New System.Drawing.Size(104, 24)
        Me.rdbLonHon.TabIndex = 58
        Me.rdbLonHon.Text = ">"
        '
        'tbPhepNam
        '
        Me.tbPhepNam.Location = New System.Drawing.Point(88, 216)
        Me.tbPhepNam.Name = "tbPhepNam"
        Me.tbPhepNam.Size = New System.Drawing.Size(100, 20)
        Me.tbPhepNam.TabIndex = 57
        '
        'lbLoaiCong
        '
        Me.lbLoaiCong.BackColor = System.Drawing.Color.Transparent
        Me.lbLoaiCong.Location = New System.Drawing.Point(8, 32)
        Me.lbLoaiCong.Name = "lbLoaiCong"
        Me.lbLoaiCong.Size = New System.Drawing.Size(72, 23)
        Me.lbLoaiCong.TabIndex = 131
        Me.lbLoaiCong.Text = "Loại giờ công"
        Me.lbLoaiCong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cb_All
        '
        Me.cb_All.Location = New System.Drawing.Point(88, 0)
        Me.cb_All.Name = "cb_All"
        Me.cb_All.Size = New System.Drawing.Size(136, 24)
        Me.cb_All.TabIndex = 133
        Me.cb_All.Text = "Toàn bộ loại giờ công"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(88, 249)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(96, 23)
        Me.btnOK.TabIndex = 1228
        Me.btnOK.Text = "OK"
        '
        'txtPercent
        '
        Me.txtPercent.Location = New System.Drawing.Point(86, 34)
        Me.txtPercent.Name = "txtPercent"
        Me.txtPercent.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtPercent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPercent.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.txtPercent.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.txtPercent.Size = New System.Drawing.Size(132, 20)
        Me.txtPercent.TabIndex = 1229
        '
        'para_LocGioCongTheoGio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(280, 290)
        Me.Controls.Add(Me.txtPercent)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cb_All)
        Me.Controls.Add(Me.lbLoaiCong)
        Me.Controls.Add(Me.rdbAll)
        Me.Controls.Add(Me.rdbBang)
        Me.Controls.Add(Me.rdbNhoHonHoacBang)
        Me.Controls.Add(Me.rdbNhoHon)
        Me.Controls.Add(Me.rdbLonHonHoacBang)
        Me.Controls.Add(Me.rdbLonHon)
        Me.Controls.Add(Me.tbPhepNam)
        Me.Name = "para_LocGioCongTheoGio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "para_LocGioCongTheoGio"
        CType(Me.txtPercent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub para_LocGioCongTheoGio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Lọc Giờ Công Theo Tiêu Chí"
        txtPercent.Properties.DataSource = kn.ReadData("select LoaiCong from dbo.HR_LoaiCong", "HR_SetupHourTimeKeeping")
        txtPercent.Properties.DisplayMember = "HR_LoaiCong"
        txtPercent.Properties.ValueMember = "HR_LoaiCong"
        txtPercent.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        txtPercent.Properties.NullText = ""
    End Sub
    Private Sub cb_All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_All.CheckedChanged
        If cb_All.Checked Then
            txtPercent.Enabled = False
            lbLoaiCong.Enabled = False
        Else
            txtPercent.Enabled = True
            lbLoaiCong.Enabled = True
        End If
    End Sub
    Public Function Get_LoaiSoSanh() As String
        If rdbAll.Checked = True Then
            Return "all"
        ElseIf rdbLonHonHoacBang.Checked = True Then
            Return ">="
        ElseIf rdbLonHon.Checked = True Then
            Return ">"
        ElseIf rdbNhoHonHoacBang.Checked = True Then
            Return "<="
        ElseIf rdbNhoHon.Checked = True Then
            Return "<"
        Else
            Return "="
        End If
    End Function
    Public Function Get_GiaTriCanSoSanh() As Double
        Try
            Return CDbl(tbPhepNam.Text.Trim)
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function Get_LoaiCongCanSoSanh() As Integer
        If cb_All.Checked Then
            Return 0
        Else
            Try
                Return CInt(txtPercent.Text.Trim)
            Catch ex As Exception
                Return 0
            End Try
        End If
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
End Class
