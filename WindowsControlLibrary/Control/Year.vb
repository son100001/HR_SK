Public Class Year
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

    Friend WithEvents cboYear As Windows.Forms.ComboBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cboYear
        '
        Me.cboYear.Location = New System.Drawing.Point(3, 3)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(54, 21)
        Me.cboYear.TabIndex = 1310
        '
        'Year
        '
        Me.Controls.Add(Me.cboYear)
        Me.Name = "Year"
        Me.Size = New System.Drawing.Size(60, 26)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Year_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.LoadYear(cboYear)
    End Sub
    Overrides Property Text() As String
        Get
            Return cboYear.Text
        End Get
        Set(ByVal Value As String)
            cboYear.Text = Value
        End Set
    End Property
End Class
