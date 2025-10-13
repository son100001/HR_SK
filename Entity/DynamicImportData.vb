Public Class DynamicImportData

    'column_id , primary key
    'column_id , primary key
    '....

    'check trung
    'select column_id1, column_id2 from table_id where column_id = @dataofcolumnidwithprimarykey and...

    'if has data: update

    'update table_id set
    'column_id = @dataofcolumnid
    ', column2
    ', column3
    'where column_id = @dataofcolumnidwithprimarykey
    'and ...

    'if has no data : insert

    'insert into table_id (column_id_pri1, column_id_pri2,...,column_id1, column_id2....) values (@dataofcolumnidwithprimarykey1




    Public Function GetSQLCheckExisted(ByVal tableID As String, ByVal column_ID_PK_List As String(), ByVal data_PK_List As String(), ByVal column_ID_List As String()) As String
        Dim sql As String = String.Empty

        Dim pksql As String = ""
        For ipk As Integer = 0 To column_ID_PK_List.Length - 1
            'pksql = pksql
        Next

        sql = "SELECT " & " FROM " & tableID & " WHERE "
        Return sql
    End Function

    Public Function GetSQLInsert(ByVal tableID As String, ByVal column_ID_PK_List As String(), ByVal column_ID_List As String()) As String


        Dim __UserName As String
        Dim __Password As String
        Dim __isadmin As String
        Dim __FullName As String
        Dim __ismonthend As String
        Dim __GroupID As String
        '__UserName = "'" + UserName + "'"
        '__Password = "'" + Password + "'"
        '__isadmin = "'" + isadmin + "'"
        'If FullName <> String.Empty Then
        '    __FullName = "N'" + FullName + "'"
        'Else
        '    __FullName = "null"
        'End If
        'If ismonthend = True Then
        '    _ismonthend = "'1'"
        'Else
        '    __ismonthend = "'0'"
        'End If
        'If GroupID <> String.Empty Then
        '    __GroupID = "N'" + GroupID + "'"
        'Else
        '    __GroupID = "null"
        'End If
        Dim sql As String = String.Empty
        'sql = "INSERT INTO [User]([UserName],[Password],[isadmin],[FullName],[ismonthend],[GroupID])VALUES(" & _
        '__UserName + "," + __Password + "," + __isadmin + "," + __FullName + "," + __ismonthend + "," + __GroupID + ")"
        Return sql
    End Function
End Class
