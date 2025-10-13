Imports System.Windows.Forms

Public Class EmployeeIDFullName
    Inherits System.Windows.Forms.UserControl
    Private tvcn As New ThuVienChucNang

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
    Friend WithEvents FullName As TextBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Employee_ID As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Employee_ID = New System.Windows.Forms.TextBox()
        Me.FullName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(0, 0)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Size = New System.Drawing.Size(120, 20)
        Me.Employee_ID.TabIndex = 2
        '
        'FullName
        '
        Me.FullName.Enabled = False
        Me.FullName.Location = New System.Drawing.Point(123, 0)
        Me.FullName.Name = "FullName"
        Me.FullName.ReadOnly = True
        Me.FullName.Size = New System.Drawing.Size(164, 20)
        Me.FullName.TabIndex = 286
        '
        'EmployeeIDFullName
        '
        Me.Controls.Add(Me.FullName)
        Me.Controls.Add(Me.Employee_ID)
        Me.Name = "EmployeeIDFullName"
        Me.Size = New System.Drawing.Size(288, 20)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Employee_ID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Employee_ID.Leave
        FullName.Text = tvcn.GetFullNameFromEmployeeID(Employee_ID.Text.Trim)
    End Sub
    Overrides Property Text() As String
        Get
            Return Employee_ID.Text
        End Get
        Set(ByVal Value As String)
            Employee_ID.Text = Value
        End Set
    End Property

    Private Sub Employee_ID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Employee_ID.KeyDown
        If e.KeyCode = Keys.F3 Then
            Dim frm As New para_NhanVien
            frm.ShowDialog()
            If frm.Employee_ID <> String.Empty Then
                Employee_ID.Text = frm.Employee_ID
            End If
        End If
    End Sub
End Class
