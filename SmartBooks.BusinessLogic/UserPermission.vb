Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports Appsettings
Public Class UserPermission
    Friend Shadows WithEvents SqlConnection1 As SqlConnection
    Private obj As New Appsettings.DbSetting
    Private dataman As New BusinessLogic.DbAccess
    Public Sub New()
        Initialize()
    End Sub
    Private Sub Initialize()
        SqlConnection1 = New SqlConnection
        SqlConnection1.ConnectionString = Appsettings.DbSetting.dataPath
    End Sub
    Public UserName As String
    Public Sub DeleteUser(ByVal UserName As String)
        Try
            SqlConnection1.Open()
            Dim sqlCommand As New sqlCommand("sp_DeleteUser", SqlConnection1)
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Parameters.Add(New SqlParameter("@username", 12, 255)).Value = UserName
            sqlCommand.ExecuteNonQuery()
            SqlConnection1.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function Userpermission(ByVal UserName As String, ByVal FormID As String) As DataTable
        Try
            Dim sqlCommand As New sqlCommand("st_getpermission", SqlConnection1)
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Parameters.Add(New SqlParameter("@username", 12, 255)).Value = UserName
            sqlCommand.Parameters.Add(New SqlParameter("@FormID", 12, 255)).Value = FormID
            Dim sqlDataAdapter As New sqlDataAdapter(sqlCommand)
            Dim dstemp As New DataTable("temp")
            sqlDataAdapter.Fill(dstemp)
            Return dstemp
        Catch ex As Exception

        End Try
    End Function
    Public Function getAllUsers() As DataSet
        Try
            Dim sqlCommand As New sqlCommand("sp_getallusers", SqlConnection1)
            sqlCommand.CommandType = CommandType.StoredProcedure
            Dim sqlDataAdapter As New sqlDataAdapter(sqlCommand)
            Dim dsSet As New DataSet("Temp")
            sqlDataAdapter.Fill(dsSet)
            Return dsSet
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function getAllForm() As DataSet
        Try
            Dim sqlCommand As New sqlCommand("sp_getallForm", SqlConnection1)
            sqlCommand.CommandType = CommandType.StoredProcedure
            Dim sqlDataAdapter As New sqlDataAdapter(sqlCommand)
            Dim dsSet As New DataSet("Temp")
            sqlDataAdapter.Fill(dsSet)
            Return dsSet
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Sub InsertPermission(ByVal UserName As String, ByVal strSetUp As String, ByVal strEmployeeInformation As String, ByVal strTimekeeping As String, ByVal strpayroll As String)
        Try
            SqlConnection1.Open()
            Dim sqlCommand As New sqlCommand("sp_insertpermission", SqlConnection1)
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Parameters.Add(New SqlParameter("@username", 12, 255)).Value = UserName
            sqlCommand.Parameters.Add(New SqlParameter("@strSetUp", SqlDbType.NVarChar, 4000)).Value = strSetUp
            sqlCommand.Parameters.Add(New SqlParameter("@strEmployeeInformation", SqlDbType.NVarChar, 4000)).Value = strEmployeeInformation
            sqlCommand.Parameters.Add(New SqlParameter("@strTimekeeping", SqlDbType.NVarChar, 4000)).Value = strTimekeeping
            sqlCommand.Parameters.Add(New SqlParameter("@strpayroll", SqlDbType.NVarChar, 4000)).Value = strpayroll
            '      sqlCommand.Parameters.Add(New SqlParameter("@FormIDFAList", 12, 255)).Value = FormIDFAList
            sqlCommand.ExecuteNonQuery()
            SqlConnection1.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Interaction.MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Fill Contract")
        End Try
    End Sub
    Public Sub InsertUser(ByVal UserName As String, ByVal PassWord As String, ByVal FullName As String, ByVal isadmin As String, ByVal groupid As String)
        Try
            Dim pass As String
            pass = dataman.Encode(PassWord.Trim())
            SqlConnection1.Open()

            Dim sqlCommand As New SqlCommand("sp_InsertUser", SqlConnection1)
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Parameters.Add(New SqlParameter("@username", 12, 255)).Value = UserName
            sqlCommand.Parameters.Add(New SqlParameter("@Password", pass))
            sqlCommand.Parameters.Add(New SqlParameter("@FullName", 12, 255)).Value = FullName
            sqlCommand.Parameters.Add(New SqlParameter("@isadmin", 12, 255)).Value = isadmin
            sqlCommand.Parameters.Add(New SqlParameter("@groupid", 12, 50)).Value = groupid
            'sqlCommand.Parameters.Add(New SqlParameter("@Employee_ID", 12, 50)).Value = Employee_ID
            'sqlCommand.Parameters.Add(New SqlParameter("@",12,.Value = DepartmentCode

            sqlCommand.ExecuteNonQuery()
            SqlConnection1.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function CheckUserNameAndPassword(ByVal UserName As String, ByVal Password As String) As Boolean
        Try
            Dim pass As String
            pass = dataman.Encode(Password.Trim())

            Dim sqlCommand As New sqlCommand("sp_checkuserandpassword", SqlConnection1)
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Parameters.Add(New SqlParameter("@username", 12, 255)).Value = UserName
            sqlCommand.Parameters.Add(New SqlParameter("@Password", pass)) 'pass
            Dim sqlDataAdapter As New sqlDataAdapter(sqlCommand)
            Dim dstemp As New DataTable("temp")
            sqlDataAdapter.Fill(dstemp)
            If dstemp.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Sub ChangePassword(ByVal UserName As String, ByVal Password As String)
        Try
            Dim pass As String
            pass = dataman.Encode(Password.Trim())

            SqlConnection1.Open()
            Dim sqlCommand As New sqlCommand("sp_changePassword", SqlConnection1)
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Parameters.Add(New SqlParameter("@username", 12, 255)).Value = UserName
            sqlCommand.Parameters.Add(New SqlParameter("@Password", 12, 255)).Value = pass
            sqlCommand.ExecuteNonQuery()
            SqlConnection1.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function GetPermssion(ByVal UserName As String) As DataTable
        Try

            Dim sqlCommand As New sqlCommand("sp_getpermssion", SqlConnection1)
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Parameters.Add(New SqlParameter("@username", 12, 255)).Value = UserName
            Dim sqlDataAdapter As New sqlDataAdapter(sqlCommand)
            Dim dstemp As New DataTable("temp")
            sqlDataAdapter.Fill(dstemp)
            Return dstemp

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function CheckAdmin(ByVal UserName As String) As Boolean
        Try
            Dim sqlCommand As New sqlCommand("sp_checkisadmin", SqlConnection1)
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Parameters.Add(New SqlParameter("@username", 12, 255)).Value = UserName
            Dim sqlDataAdapter As New sqlDataAdapter(sqlCommand)
            Dim dstemp As New DataTable("temp")
            sqlDataAdapter.Fill(dstemp)
            If IsDBNull(dstemp.Rows(0).Item(0)) = False Then
                obj.Permision = Convert.ToString(dstemp.Rows(0).Item(0)).Trim()
                If Convert.ToString(dstemp.Rows(0).Item(0)).Trim().ToUpper = "ADMIN" Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function CheckManager(ByVal UserName As String) As Boolean
        Try
            Dim sqlCommand As New sqlCommand("sp_checkisadmin", SqlConnection1)
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Parameters.Add(New SqlParameter("@username", 12, 255)).Value = UserName
            Dim sqlDataAdapter As New sqlDataAdapter(sqlCommand)
            Dim dstemp As New DataTable("temp")
            sqlDataAdapter.Fill(dstemp)
            If IsDBNull(dstemp.Rows(0).Item(0)) = False Then
                obj.Permision = Convert.ToString(dstemp.Rows(0).Item(0)).Trim()
                If Convert.ToString(dstemp.Rows(0).Item(0)).Trim().ToUpper = "MANAGER" Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function CheckExsitUser(ByVal UserName As String) As Boolean
        Try
            Dim sqlCommand As New sqlCommand("sp_checkuser", SqlConnection1)
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Parameters.Add(New SqlParameter("@username", 12, 255)).Value = UserName
            Dim sqlDataAdapter As New sqlDataAdapter(sqlCommand)
            Dim dstemp As New DataTable("temp")
            sqlDataAdapter.Fill(dstemp)
            If dstemp.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function CheckExsitUser_ID(ByVal UserName As String) As Boolean
        Try
            Dim sqlCommand As New SqlCommand("sp_checkuser_ID", SqlConnection1)
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Parameters.Add(New SqlParameter("@username", 12, 255)).Value = UserName
            Dim sqlDataAdapter As New SqlDataAdapter(sqlCommand)
            Dim dstemp As New DataTable("temp")
            sqlDataAdapter.Fill(dstemp)
            If dstemp.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
End Class
