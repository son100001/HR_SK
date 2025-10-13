Public Class para_DieuKienPhepNam
    Inherits System.Windows.Forms.Form
    Private str_LoaiSoSanh As String

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
    Friend WithEvents rdbLonHon As System.Windows.Forms.RadioButton
    Friend WithEvents rdbLonHonHoacBang As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNhoHon As System.Windows.Forms.RadioButton
    Friend WithEvents tbPhepNam As System.Windows.Forms.TextBox
    Friend WithEvents rdbNhoHonHoacBang As System.Windows.Forms.RadioButton
    Friend WithEvents rdbBang As System.Windows.Forms.RadioButton
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents rdbAll As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tbPhepNam = New System.Windows.Forms.TextBox()
        Me.rdbLonHon = New System.Windows.Forms.RadioButton()
        Me.rdbLonHonHoacBang = New System.Windows.Forms.RadioButton()
        Me.rdbNhoHon = New System.Windows.Forms.RadioButton()
        Me.rdbNhoHonHoacBang = New System.Windows.Forms.RadioButton()
        Me.rdbBang = New System.Windows.Forms.RadioButton()
        Me.rdbAll = New System.Windows.Forms.RadioButton()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'tbPhepNam
        '
        Me.tbPhepNam.Location = New System.Drawing.Point(48, 176)
        Me.tbPhepNam.Name = "tbPhepNam"
        Me.tbPhepNam.Size = New System.Drawing.Size(100, 20)
        Me.tbPhepNam.TabIndex = 0
        '
        'rdbLonHon
        '
        Me.rdbLonHon.Location = New System.Drawing.Point(48, 48)
        Me.rdbLonHon.Name = "rdbLonHon"
        Me.rdbLonHon.Size = New System.Drawing.Size(104, 24)
        Me.rdbLonHon.TabIndex = 1
        Me.rdbLonHon.Text = ">"
        '
        'rdbLonHonHoacBang
        '
        Me.rdbLonHonHoacBang.Location = New System.Drawing.Point(48, 72)
        Me.rdbLonHonHoacBang.Name = "rdbLonHonHoacBang"
        Me.rdbLonHonHoacBang.Size = New System.Drawing.Size(104, 24)
        Me.rdbLonHonHoacBang.TabIndex = 2
        Me.rdbLonHonHoacBang.Text = ">="
        '
        'rdbNhoHon
        '
        Me.rdbNhoHon.Location = New System.Drawing.Point(48, 96)
        Me.rdbNhoHon.Name = "rdbNhoHon"
        Me.rdbNhoHon.Size = New System.Drawing.Size(104, 24)
        Me.rdbNhoHon.TabIndex = 3
        Me.rdbNhoHon.Text = "<"
        '
        'rdbNhoHonHoacBang
        '
        Me.rdbNhoHonHoacBang.Location = New System.Drawing.Point(48, 120)
        Me.rdbNhoHonHoacBang.Name = "rdbNhoHonHoacBang"
        Me.rdbNhoHonHoacBang.Size = New System.Drawing.Size(104, 24)
        Me.rdbNhoHonHoacBang.TabIndex = 4
        Me.rdbNhoHonHoacBang.Text = "<="
        '
        'rdbBang
        '
        Me.rdbBang.Location = New System.Drawing.Point(48, 144)
        Me.rdbBang.Name = "rdbBang"
        Me.rdbBang.Size = New System.Drawing.Size(104, 24)
        Me.rdbBang.TabIndex = 5
        Me.rdbBang.Text = "="
        '
        'rdbAll
        '
        Me.rdbAll.Checked = True
        Me.rdbAll.Location = New System.Drawing.Point(48, 24)
        Me.rdbAll.Name = "rdbAll"
        Me.rdbAll.Size = New System.Drawing.Size(104, 24)
        Me.rdbAll.TabIndex = 56
        Me.rdbAll.TabStop = True
        Me.rdbAll.Text = "All"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(104, 227)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 23)
        Me.btnOK.TabIndex = 1228
        Me.btnOK.Text = "OK"
        '
        'para_DieuKienPhepNam
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.rdbAll)
        Me.Controls.Add(Me.rdbBang)
        Me.Controls.Add(Me.rdbNhoHonHoacBang)
        Me.Controls.Add(Me.rdbNhoHon)
        Me.Controls.Add(Me.rdbLonHonHoacBang)
        Me.Controls.Add(Me.rdbLonHon)
        Me.Controls.Add(Me.tbPhepNam)
        Me.Name = "para_DieuKienPhepNam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "para_DieuKienPhepNam"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

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

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim db_Check As Double
        If rdbAll.Checked = False Then
            Try
                db_Check = CDbl(tbPhepNam.Text.Trim)
                Me.Close()
            Catch ex As Exception
                MessageBox.Show("Giá trị bạn nhập vào không đúng định dạng kiểu số!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Me.Close()
        End If
    End Sub

    Private Sub para_DieuKienPhepNam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Nhập Điều Kiện So Sánh"
    End Sub
End Class
