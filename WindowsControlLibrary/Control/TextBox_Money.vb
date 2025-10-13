Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class TextBox_Money
    Inherits TextBox
    Private mstrInitialValue As String
    <Category("Behavior"), _
    Description("Specifies the value the control " & _
    "must differ from in order to validate.")> _
    Public Property InitialValue() As String
        Get
            Return mstrInitialValue
        End Get
        Set(ByVal Value As String)
            mstrInitialValue = Value
        End Set
    End Property

    Public ReadOnly Property Valid() As Boolean
        Get
            Return IsValid()
        End Get
    End Property

    Private Function IsValid() As Boolean
        Return Me.Text <> mstrInitialValue
    End Function

    Protected Overrides Sub OnValidating( _
    ByVal e As CancelEventArgs)
        e.Cancel = Not IsValid()
        MyBase.OnValidating(e)
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)
        Dim regex As Regex = New Regex("[0-9]+|\.")
        Dim match As Match = regex.Match(e.KeyChar.ToString)
        If match.Success = False Then
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        Else
            If e.KeyChar = "." Then
                If MyBase.Text = String.Empty Then
                    MyBase.Text = "0."
                    MyBase.Select(MyBase.Text.Length, 0)
                    e.Handled = True
                Else
                    If MyBase.Text.IndexOf(".") >= 0 Then
                        e.Handled = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub InitializeComponent()

    End Sub
End Class
