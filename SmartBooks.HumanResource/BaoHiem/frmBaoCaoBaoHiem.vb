
Imports DevExpress.XtraGrid
Imports WindowsControlLibrary
Public Class frmBaoCaoBaoHiem
    Private Sub frmBaoCaoBaoHiem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.GetDataOnDropDownCategoryCodeName(PhuongAn, "PhuongAnTangGiam")
        tvcn.GetDataOnDropDownCategoryCodeName(LoaiKhaiBao, "LoaiTangGiam")
        tvcn.ThemDauSaoChoTruongBuocNhap(XtraTabControl1, HRFORM_TableName)
        LoadGiaoDienTheoDieuKien()
        tvcn.SearchEmployee(Employee_ID)
        Search()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_IncreaseDecreaseInsurance]", XtraTabControl1, ErrorProvider1) Then
            Xem(HRFORM_QueryView, False, HRFORM_GridControl, HRFORM_Gridview)
        End If
        Employee_ID.Select()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim QR As String = "exec [dbo].[sp_BangBaoHiem] null,null,2,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Public Overrides Sub AfterViewForm()
        For Each col As Columns.GridColumn In HRFORM_Gridview.Columns
            If col.FieldName.ToUpper = "PHUONGAN" Then
                Dim tab As DataTable = kn.ReadData("select * from [dbo].[udf_GetCategory]('PhuongAnTangGiam','" + obj.Lan + "')", "table")
                tvcn.TaoDropDowTrenGrid(HRFORM_Gridview, col.FieldName, tab)
            End If
            If col.FieldName.ToUpper = "LOAIKHAIBAO" Then
                Dim tab As DataTable = kn.ReadData("select * from [dbo].[udf_GetCategory]('LoaiTangGiam','" + obj.Lan + "')", "table")
                tvcn.TaoDropDowTrenGrid(HRFORM_Gridview, col.FieldName, tab)
            End If
        Next
    End Sub

    Private Sub InsuranceSalary_TextChanged(sender As Object, e As EventArgs)
        tvcn.AmountFormat(InsuranceSalary)
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        Search()
    End Sub
End Class