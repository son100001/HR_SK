Imports Appsettings
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Math
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports Microsoft.ApplicationBlocks.Data
Imports System.Text

Public Class KetNoiCSDL
    Dim con As New SqlConnection(DbSetting.dataPath)
    Dim ketnoi As String

    Public Function ClsKetNoi()
        Dim a As String = con.ConnectionString
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
    End Function

    Public Function Select_CauLenhSQL(ByVal sql As String) As DataTable
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim command As New SqlCommand(sql, con)
            command.CommandTimeout = 9000
            Dim adapter As New SqlDataAdapter(command)
            Dim dt As New DataTable
            adapter.Fill(dt)
            con.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
    End Function

    Public Function Select_(ByVal StoreProcedure As String) As DataTable
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim command As New SqlCommand(StoreProcedure, con)
            command.CommandType = CommandType.StoredProcedure
            Dim adapter As New SqlDataAdapter(command)
            Dim dt As New DataTable
            adapter.Fill(dt)
            con.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
    End Function

    Public Function Select_(ByVal sql As String, ByVal name As String(), ByVal value As Object(), ByVal Nparameter As Integer)
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim command As New SqlCommand(sql, con)
            command.CommandType = CommandType.StoredProcedure
            For i As Integer = 0 To Nparameter - 1
                command.Parameters.Add(New SqlParameter(name(i), value(i)))
                command.Parameters(name(i)).Value = value(i)
            Next
            Dim adapter As New SqlDataAdapter(command)
            Dim dt As New DataTable
            adapter.Fill(dt)
            con.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
    End Function

    Public Function Upadate(ByVal sql As String) As Integer
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim command As New SqlCommand(sql, con)
            command.CommandType = CommandType.StoredProcedure
            Return command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
    End Function

    Public Function Upadate(ByVal sql As String, ByVal name As String(), ByVal value As Object(), ByVal Nparameter As Integer) As Integer
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim command As New SqlCommand(sql, con)
            command.CommandType = CommandType.StoredProcedure
            For i As Integer = 0 To Nparameter - 1
                command.Parameters.Add(New SqlParameter(name(i), value(i)))
                command.Parameters(name(i)).Value = value(i)
            Next
            Return command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
    End Function

    Public Function Insert(ByVal sql As String) As Integer
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim command As New SqlCommand(sql, con)
            command.CommandType = CommandType.StoredProcedure
            Return command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
    End Function

    Public Function Insert(ByVal sql As String, ByVal name As String(), ByVal value As Object(), ByVal Nparameter As Integer) As Integer
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim command As New SqlCommand(sql, con)
            command.CommandType = CommandType.StoredProcedure
            For i As Integer = 0 To Nparameter - 1
                command.Parameters.Add(New SqlParameter(name(i), value(i)))
                command.Parameters(name(i)).Value = value(i)
            Next
            Return command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
    End Function

    Public Function Exec(ByVal strSQL As String) As Integer
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As New SqlCommand(strSQL, con)
            Return cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
            Return 0
        End Try
    End Function

End Class