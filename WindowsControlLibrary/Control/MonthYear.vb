Public Class MonthYear
    Inherits System.Windows.Forms.UserControl
    Dim tvcn As New ThuVienChucNang

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents cboMonth As Windows.Forms.ComboBox
    Friend WithEvents cboYear As Windows.Forms.ComboBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lbl
        '
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.Location = New System.Drawing.Point(44, 0)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(8, 21)
        Me.lbl.TabIndex = 34
        Me.lbl.Text = "-"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMonth
        '
        Me.cboMonth.Location = New System.Drawing.Point(0, 0)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(35, 21)
        Me.cboMonth.TabIndex = 1312
        '
        'cboYear
        '
        Me.cboYear.Location = New System.Drawing.Point(62, 0)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(54, 21)
        Me.cboYear.TabIndex = 1313
        '
        'MonthYear
        '
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.lbl)
        Me.Name = "MonthYear"
        Me.Size = New System.Drawing.Size(120, 20)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MonthYear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.LoadMonth(cboMonth)
        tvcn.LoadYear(cboYear)
    End Sub

    Property Text_Month() As String
        Get
            Return cboMonth.Text
        End Get
        Set(ByVal Value As String)
            cboMonth.Text = Value
        End Set
    End Property

    Property Text_Year() As String
        Get
            Return cboYear.Text
        End Get
        Set(ByVal Value As String)
            cboYear.Text = Value
        End Set
    End Property

End Class
