Public Class Month
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

    Friend WithEvents cboMonth As Windows.Forms.ComboBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cboMonth
        '
        Me.cboMonth.Location = New System.Drawing.Point(3, 3)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(35, 21)
        Me.cboMonth.TabIndex = 1311
        '
        'Month
        '
        Me.Controls.Add(Me.cboMonth)
        Me.Name = "Month"
        Me.Size = New System.Drawing.Size(42, 26)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Month_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.LoadMonth(cboMonth)
    End Sub
    Overrides Property Text() As String
        Get
            Return cboMonth.Text
        End Get
        Set(ByVal Value As String)
            cboMonth.Text = Value
        End Set
    End Property

End Class
