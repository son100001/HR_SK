Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.ApplicationBlocks.Data

Public Enum Mode
    ModeView = 0
    ModeNew = 1
    ModeEdit = 2
End Enum

Public Class DBConnection

    Public Const usp_Account As String = "usp_Account"
    Public Shared mRowCount As Int32 = 0
    'Public Shared mJRow As Janus.Windows.GridEX.GridEXRow
    Public Shared UserID As String = String.Empty
    Public Shared Language As String = String.Empty
    Public Shared strConnection As String = String.Empty

    Public Shared conn As SqlConnection
    Public Shared rateType As Int32 = 0

    Public Shared Function Connection() As SqlConnection
        conn = New SqlConnection(strConnection)
        'conn.Open()

        Return conn
    End Function

    'Public Shared Function CloseConnection() As SqlConnection
    '    conn.Close()
    '    Return conn
    'End Function

    Public Shared Function CreatePeriod() As String
        Dim Period As String
        Dim strMonth As String

        If Month(DateTime.Now) < 10 Then
            strMonth = "0" & Month(DateTime.Now)
        Else
            strMonth = Month(DateTime.Now)
        End If

        CreatePeriod = strMonth & Year(DateTime.Now)
    End Function

    'Public Shared Sub BindData4Status(ByVal multiCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
    '    Dim mTable As DataTable
    '    Dim mRow As DataRow

    '    mTable = New DataTable
    '    mTable.Columns.Add(New DataColumn("ID", GetType(String)))
    '    mTable.Columns.Add(New DataColumn("Descr", GetType(String)))

    '    mRow = mTable.NewRow
    '    mRow("ID") = "H"
    '    mRow("Descr") = "Hold"
    '    mTable.Rows.Add(mRow)

    '    mRow = mTable.NewRow
    '    mRow("ID") = "P"
    '    mRow("Descr") = "Posted"
    '    mTable.Rows.Add(mRow)

    '    multiCombo.DataSource = mTable
    '    multiCombo.DropDownList.Columns("Descr").Width = multiCombo.Width
    '    multiCombo.DisplayMember = "Descr"
    '    multiCombo.ValueMember = "ID"
    'End Sub

    'Public Shared Sub BindData4Handling(ByVal multiCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
    '    Dim mTable As DataTable
    '    Dim mRow As DataRow

    '    mTable = New DataTable
    '    mTable.Columns.Add(New DataColumn("ID", GetType(String)))
    '    mTable.Columns.Add(New DataColumn("Descr", GetType(String)))

    '    mRow = mTable.NewRow
    '    mRow("ID") = "H"
    '    mRow("Descr") = "Hold"
    '    mTable.Rows.Add(mRow)

    '    mRow = mTable.NewRow
    '    mRow("ID") = "R"
    '    mRow("Descr") = "Release"
    '    mTable.Rows.Add(mRow)

    '    multiCombo.DataSource = mTable
    '    multiCombo.DropDownList.Columns("Descr").Width = multiCombo.Width
    '    multiCombo.DisplayMember = "Descr"
    '    multiCombo.ValueMember = "ID"
    'End Sub

    Public Shared Sub BindData4Account(ByVal tb As String, ByVal lb As String, ByVal ctrModule As System.String)
        Dim mFind As New FINDNET.FindProcess(New SqlClient.SqlConnection(DBConnection.strConnection))
        Dim strHeaders() As String = {"Account No", "Description (VN)", "Description (EN)"}
        Dim strColumns() As String = {"Acct", "DescrVN", "DescrEN"}

        If (ctrModule = "GL") Then
            'mFind.Condition = "Acct like '11%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'GL' AND IsMaster = 1 And IsGA=0)"
        End If
        If (ctrModule = "AP") Then
            'mFind.Condition = "Acct like '331%' or Acct like '338%' or Acct like '336%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'AP' AND IsMaster = 1 And IsGA=0)"
        End If
        If (ctrModule = "AR") Then
            'mFind.Condition = "Acct like '131%' or Acct like '136%' or Acct like '138%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'AR' AND IsMaster = 1 And IsGA=0)"
        End If
        If (ctrModule = "CA") Then
            'mFind.Condition = "Acct like '11%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'CA' AND IsMaster = 1 And IsGA=0)"
        End If
        If (ctrModule = "FA") Then
            'mFind.Condition = "Acct like '11%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'FA' AND IsMaster = 1 And IsGA=0)"
        End If
        If (ctrModule = "IN") Then
            'mFind.Condition = "Acct like '11%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'IN' AND IsMaster = 1 And IsGA=0)"
        End If
        If (ctrModule = "PO") Then
            'mFind.Condition = "Acct like '11%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'PO' AND IsMaster = 1 And IsGA=0)"
        End If
        If (ctrModule = "TL") Then
            'mFind.Condition = "Acct like '11%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'TL' AND IsMaster = 1 And IsGA=0)"
        End If
        Dim mRow As DataRow = mFind.Find(strHeaders, "Account", strColumns)

        If Not IsDBNull(mRow.Item(0)) Then
            tb = mRow.Item("Acct")
            lb = mRow.Item("DescrVN")
        End If
    End Sub
    Public Shared Function BindData4AccountDeatails(ByVal ctrModule As System.String) As DataRow
        Dim mFind As New FINDNET.FindProcess(New SqlClient.SqlConnection(DBConnection.strConnection))
        Dim strHeaders() As String = {"Account No", "Description (VN)", "Description (EN)"}
        Dim strColumns() As String = {"Acct", "DescrVN", "DescrEN"}
        If (ctrModule = "GL") Then
            'mFind.Condition = "Acct like '11%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'GL' AND IsDetail = 1 And IsGA=0)"
        End If
        If (ctrModule = "AP") Then
            'mFind.Condition = "Acct like '331%' or Acct like '338%' or Acct like '336%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'AP' AND IsDetail = 1 And IsGA=0)"
        End If
        If (ctrModule = "AR") Then
            'mFind.Condition = "Acct like '131%' or Acct like '136%' or Acct like '138%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'AR' AND IsDetail = 1 And IsGA=0)"
        End If
        If (ctrModule = "CA") Then
            'mFind.Condition = "Acct like '11%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'CA' AND IsDetail = 1 And IsGA=0 )"
        End If
        If (ctrModule = "FA") Then
            'mFind.Condition = "Acct like '11%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'FA' AND IsDetail = 1 And IsGA=0)"
        End If
        If (ctrModule = "IN") Then
            'mFind.Condition = "Acct like '11%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'IN' AND IsDetail = 1 And IsGA=0)"
        End If
        If (ctrModule = "PO") Then
            'mFind.Condition = "Acct like '11%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'PO' AND IsDetail = 1 And IsGA=0)"
        End If
        If (ctrModule = "TL") Then
            'mFind.Condition = "Acct like '11%' And Status='AC'"
            mFind.Condition = "Acct IN  (SELECT Acct  FROM [SetupAcctModule] WHERE  AcctModule = 'TL' AND IsDetail = 1 And IsGA=0)"
        End If
        Dim mRow As DataRow = mFind.Find(strHeaders, "Account", strColumns)

        Return mRow
        'If Not IsDBNull(mRow.Item(0)) Then
        '    TextBox.Text = mRow.Item("Acct")
        '    ctrLabel.Text = mRow.Item("DescrVN")
        'End If
    End Function
    ''''''Edit by Quy 31-12-2011 vinakorea : chuyen rateExchange xuong luoi
    Public Shared Function BindData4CuryID(ByVal ctrModule As System.String) As DataRow
        Dim mFind As New FINDNET.FindProcess(New SqlClient.SqlConnection(DBConnection.strConnection))
        Dim strHeaders() As String = {"CuryID", "RateExchange"}
        Dim strColumns() As String = {"CuryID", "RateExchange"}
        If (ctrModule = "CuryID") Then
            'mFind.Condition = "Acct like '11%' And Status='AC'"
            mFind.Condition = "CuryID IN  (SELECT CuryID  FROM [Currency])"
        End If

        Dim mRow As DataRow = mFind.Find(strHeaders, "Currency", strColumns)

        Return mRow
        'If Not IsDBNull(mRow.Item(0)) Then
        '    TextBox.Text = mRow.Item("Acct")
        '    ctrLabel.Text = mRow.Item("DescrVN")
        'End If
    End Function
    ''''''Edit by Quy 31-12-2011 vinakorea : chuyen rateExchange xuong luoi

    Public Shared Function Encode(ByVal strDec As String) As String
        Dim strEnc As String
        Dim bt() As Byte
        ReDim bt(strDec.Length)

        bt = Encoding.Unicode.GetBytes(strDec)
        strEnc = Convert.ToBase64String(bt)
        Return strEnc
    End Function

    Public Shared Function Decode(ByVal strEnc As String) As String
        Dim bt() As Byte
        Dim strDec As String

        bt = Convert.FromBase64String(strEnc)
        strDec = Encoding.Unicode.GetString(bt)
        Return strDec
    End Function


    Public Shared Function CheckDetailAcct(ByVal pMasterAcct As String, ByVal pDetailAcct As String) As Boolean
        If pMasterAcct = pDetailAcct Then
            If (MessageBox.Show("[" & pDetailAcct & "] is same as Master Account. Do you want to continue ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    'Function CheckAllocation
    Public Shared Function CheckDisCosts(ByVal CostID As System.String) As System.Int32
        Dim param As SqlParameter = New SqlParameter
        Dim disAmt As System.Int32 = 0

        Try
            param = New SqlParameter("@CostID", SqlDbType.NVarChar, 50)
            param.Direction = ParameterDirection.Input
            param.Value = CostID

            disAmt = SqlHelper.ExecuteScalar(DBConnection.Connection, CommandType.StoredProcedure, "usp_CheckDisCosts", param)
            Return disAmt
        Catch ex As Exception
            Throw ex
        Finally
            If Not DBConnection.Connection Is Nothing Then
                CType(DBConnection.Connection, IDisposable).Dispose()
            End If
        End Try
    End Function

    'Function CheckDepreciation
    Public Shared Function CheckDepreciation(ByVal AssetID As System.String) As System.Int32
        Dim param As SqlParameter = New SqlParameter
        Dim disAmt As System.Int32 = 0

        Try
            param = New SqlParameter("@AssetID", SqlDbType.NVarChar, 50)
            param.Direction = ParameterDirection.Input
            param.Value = AssetID

            disAmt = SqlHelper.ExecuteScalar(DBConnection.Connection, CommandType.StoredProcedure, "usp_CheckDepreciation", param)
            Return disAmt
        Catch ex As Exception
            Throw ex
        Finally
            If Not DBConnection.Connection Is Nothing Then
                CType(DBConnection.Connection, IDisposable).Dispose()
            End If
        End Try
    End Function

    Public Shared Function CheckRefNbr(ByVal pIsModule As String, ByVal pTranType As String, ByVal pRefNbr As String, ByVal pPeriod As String, ByVal pBatNbr As String) As Boolean
        Dim params() As SqlParameter = New SqlParameter(5) {}
        Try
            params(0) = New SqlParameter("@IsModule", SqlDbType.NVarChar, 10)
            params(0).Direction = ParameterDirection.Input
            params(0).Value = pIsModule

            params(1) = New SqlParameter("@TranType", SqlDbType.NVarChar, 10)
            params(1).Direction = ParameterDirection.Input
            params(1).Value = pTranType

            params(2) = New SqlParameter("@RefNbr", SqlDbType.NVarChar, 20)
            params(2).Direction = ParameterDirection.Input
            params(2).Value = pRefNbr

            params(3) = New SqlParameter("@Period", SqlDbType.NVarChar, 10)
            params(3).Direction = ParameterDirection.Input
            params(3).Value = pPeriod

            params(4) = New SqlParameter("@BatNbr", SqlDbType.NVarChar, 10)
            params(4).Direction = ParameterDirection.Input
            params(4).Value = pBatNbr

            Return SqlHelper.ExecuteScalar(DBConnection.Connection, CommandType.StoredProcedure, "usp_CheckRefNbr", params)

        Catch ex As Exception
            Throw ex
        Finally
            If Not DBConnection.Connection Is Nothing Then
                CType(DBConnection.Connection, IDisposable).Dispose()
            End If
        End Try
    End Function

    Public Shared Function CheckInvoiceNbr(ByVal pIsModule As String, ByVal pTranType As String, ByVal pRefNbr As String, ByVal pPeriod As String, ByVal pBatNbr As String, ByVal pInvoiceNo As String) As Boolean
        Dim params() As SqlParameter = New SqlParameter(6) {}
        Try
            params(0) = New SqlParameter("@IsModule", SqlDbType.NVarChar, 10)
            params(0).Direction = ParameterDirection.Input
            params(0).Value = pIsModule

            params(1) = New SqlParameter("@TranType", SqlDbType.NVarChar, 10)
            params(1).Direction = ParameterDirection.Input
            params(1).Value = pTranType

            params(2) = New SqlParameter("@RefNbr", SqlDbType.NVarChar, 20)
            params(2).Direction = ParameterDirection.Input
            params(2).Value = pRefNbr

            params(3) = New SqlParameter("@Period", SqlDbType.NVarChar, 10)
            params(3).Direction = ParameterDirection.Input
            params(3).Value = pPeriod

            params(4) = New SqlParameter("@BatNbr", SqlDbType.NVarChar, 10)
            params(4).Direction = ParameterDirection.Input
            params(4).Value = pBatNbr

            params(5) = New SqlParameter("@InvoiceNo", SqlDbType.NVarChar, 50)
            params(5).Direction = ParameterDirection.Input
            params(5).Value = pInvoiceNo


            Return SqlHelper.ExecuteScalar(DBConnection.Connection, CommandType.StoredProcedure, "usp_CheckInvoiceNbr", params)

        Catch ex As Exception
            Throw ex
        Finally
            If Not DBConnection.Connection Is Nothing Then
                CType(DBConnection.Connection, IDisposable).Dispose()
            End If
        End Try
    End Function

    Public Shared Function GetModuleInfo(ByVal pIsModule As String, ByVal pIsType As String, ByVal pFormNo As String) As DataSet
        Dim params() As SqlParameter = New SqlParameter(2) {}
        Dim ds As New DataSet

        Try
            params(0) = New SqlParameter("@IsModule", SqlDbType.NVarChar, 50)
            params(0).Direction = ParameterDirection.Input
            params(0).Value = pIsModule

            params(1) = New SqlParameter("@IsType", SqlDbType.NVarChar, 5)
            params(1).Direction = ParameterDirection.Input
            params(1).Value = pIsType

            params(2) = New SqlParameter("@FormNo", SqlDbType.NVarChar, 10)
            params(2).Direction = ParameterDirection.Input
            params(2).Value = pFormNo

            ds = SqlHelper.ExecuteDataset(DBConnection.Connection, CommandType.StoredProcedure, "usp_GetBatNbrInfo", params)

            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            If Not DBConnection.Connection Is Nothing Then
                CType(DBConnection.Connection, IDisposable).Dispose()
            End If
        End Try
    End Function

#Region "Currency Methods"
    Public Shared Function GetMainCurrency() As DataTable
        Dim params() As SqlParameter = New SqlParameter(2) {}
        Dim ds As New DataSet

        Try
            params(0) = New SqlParameter("@Action", SqlDbType.NVarChar, 50)
            params(0).Direction = ParameterDirection.Input
            params(0).Value = "GetMainCuryID"

            ds = SqlHelper.ExecuteDataset(DBConnection.Connection, CommandType.StoredProcedure, "usp_Currency", params)
            Return ds.Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If Not DBConnection.Connection Is Nothing Then
                CType(DBConnection.Connection, IDisposable).Dispose()
            End If
        End Try
    End Function

    Public Shared Function GetRateExchange(ByVal mRateExchange As String) As System.Decimal
        If mRateExchange.IndexOf("/") <> -1 Then
            Dim index As Int32 = mRateExchange.IndexOf("/") + 1
            mRateExchange = mRateExchange.Substring(mRateExchange.IndexOf("/"), mRateExchange.Length - 1)
            Return mRateExchange.Substring(1)
        Else
            Return Convert.ToDecimal(mRateExchange.Trim())
        End If
    End Function

    Public Shared Function CheckRateExchangeFormat(ByVal mRate As String) As System.Boolean
        If mRate.Trim() <> String.Empty Then
            Dim r As New Regex("(^[1-9]{1}/[1-9]{1}\d*$)")
            Dim r0 As New Regex("(^[0-9]*\.[1-9]*$)")
            Dim r1 As New Regex("(^[1-9]{1}$)")
            Dim r2 As New Regex("(^[1-9]{1}\d*$)")
            If r0.IsMatch(mRate) Then
                'If r.IsMatch(mRate) Or r1.IsMatch(mRate) Or r2.IsMatch(mRate) Then  'true
                '    'Console.WriteLine("Match")
                rateType = 1
                Return True
                'Else
                '    Return tr
                'End If
            Else
                If r1.IsMatch(mRate) Or r2.IsMatch(mRate) Then   'true
                    'Console.WriteLine("Match")
                    rateType = 1
                    Return True
                Else
                    If r.IsMatch(mRate) Then
                        rateType = 0
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If

            'MessageBox.Show("Rate Exchange's Format is not right, please enter again!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'txtRateExchange1.Focus()
        End If


    End Function

#End Region


End Class
