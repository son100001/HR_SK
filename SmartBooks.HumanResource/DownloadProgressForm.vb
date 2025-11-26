Imports System.Drawing

Public Class DownloadProgressForm
    Inherits Form

    Private progressBar As ProgressBar
    Private lblStatus As Label
    Private lblTitle As Label

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "Đang tải cập nhật"
        Me.Size = New Size(500, 180)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ControlBox = False
        Me.BackColor = Color.White

        ' Title
        lblTitle = New Label With {
            .Text = "HR Software - Cập nhật tự động",
            .Location = New Point(20, 15),
            .Size = New Size(450, 25),
            .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(0, 102, 204)
        }
        Me.Controls.Add(lblTitle)

        ' Status label
        lblStatus = New Label With {
            .Text = "Đang chuẩn bị tải xuống...",
            .Location = New Point(20, 50),
            .Size = New Size(450, 25),
            .Font = New Font("Segoe UI", 9.5F)
        }
        Me.Controls.Add(lblStatus)

        ' Progress bar
        progressBar = New ProgressBar With {
            .Location = New Point(20, 85),
            .Size = New Size(450, 35),
            .Style = ProgressBarStyle.Continuous,
            .Minimum = 0,
            .Maximum = 100,
            .Value = 0
        }
        Me.Controls.Add(progressBar)
    End Sub

    ''' <summary>
    ''' Cập nhật progress bar
    ''' </summary>
    Public Sub SetProgress(percentage As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Sub() SetProgress(percentage)))
            Return
        End If

        progressBar.Value = Math.Min(Math.Max(percentage, 0), 100)
        Application.DoEvents()
    End Sub

    ''' <summary>
    ''' Cập nhật status text
    ''' </summary>
    Public Sub SetStatus(status As String)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Sub() SetStatus(status)))
            Return
        End If

        lblStatus.Text = status
        Application.DoEvents()
    End Sub

End Class