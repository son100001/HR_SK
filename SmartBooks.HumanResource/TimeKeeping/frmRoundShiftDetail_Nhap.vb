Public Class frmRoundShiftDetail_Nhap
    Private Sub frmRoundShiftDetail_Nhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RoundCode.Select()
    End Sub
    Public Overrides Sub BeforeLoad()
        Dim shiftNameTab, roundCodeTab As DataTable
        shiftNameTab = kn.ReadData("select ShiftName as Code, ShiftSign as Name from HR_Shifts where ShiftSign is not null", "table")
        roundCodeTab = kn.ReadData("select distinct RoundCode as Code, ShiftName as Name from HR_RoundShiftDetail", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(ShiftName, shiftNameTab)
        tvcn.GetDataOnDropDownCategoryCodeName(RoundCode, roundCodeTab)
    End Sub
    Public Overrides Function BeforeSave() As Integer
        UserName.Text = WindowsControlLibrary.DbSetting.UserName
        InsertDate.EditValue = Now
        Return 1
    End Function
End Class