Imports WindowsControlLibrary
 
Public Class frmDanhSachNguoiPhuThuoc
    Private Sub frmDanhSachNguoiPhuThuoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        Dim tabFamily, tabTinhTP, tabQuanHuyen, tabPhuongXa, tabQuocTich, tabRelatedType As DataTable
        tvcn.GetDataOnDropDownCategoryCodeName(RelatedType, "QuanHeGiaDinh")
        tvcn.GetDataOnDropDownCategoryCodeName(Sex, "Sex")
        tvcn.GetDataOnDropDownCategoryCodeName(RelatedType, "QuanHeGiaDinh")
        tabTinhTP = kn.ReadData("select MaTinhThanhPho as Code, TenTinhThanhPho as Name from HR_TinhThanhPho", "table")
        tabQuanHuyen = kn.ReadData("select MaTinhThanhPho+'_'+MaQuanHuyen as Code, TenQuanHuyen as Name from HR_QuanHuyen", "table")
        tabPhuongXa = kn.ReadData("select MaTinhThanhPho+'_'+MaQuanHuyen+'_'+MaPhuongXa as Code, TenPhuongXa as Name from HR_PhuongXa", "table")
        tabQuocTich = kn.ReadData("select Code,CountryName_EN as Name from HR_Country", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(GKS_PhuongXa, tabPhuongXa)
        tvcn.GetDataOnDropDownCategoryCodeName(GKS_QuanHuyen, tabQuanHuyen)
        tvcn.GetDataOnDropDownCategoryCodeName(GKS_TinhTP, tabTinhTP)
        tvcn.GetDataOnDropDownCategoryCodeName(QuocTich, tabQuocTich)
        DependFromMonth.EditValue = Today
        DependToMonth.EditValue = Today
        tvcn.SearchEmployee(Employee_ID)
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_DanhSachNguoiPhuThuoc]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
            ' tvcn.ClearTextInControlOnForm(UltraTabControl1)
        End If
        Employee_ID.Select()
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub
    Private Sub Employee_ID_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F3 Then
            Dim frm As New para_NhanVien
            frm.ShowDialog()
            If frm.Employee_ID <> String.Empty Then
                Employee_ID.Text = frm.Employee_ID
            End If
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            If btnSave.Enabled = True Then
                btnSave_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub cbDependToMonth_CheckedChanged(sender As Object, e As EventArgs) Handles cbDependToMonth.CheckedChanged
        DependToMonth.Enabled = True = cbDependToMonth.Checked
    End Sub

    Public Overrides Sub AfterViewForm()
        Dim tab As DataTable = kn.ReadData("select Category as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Category where CategoryFather='QuanHeGiaDinh'", "table")
        tvcn.TaoDropDowTrenGrid(GridView1, "RelatedType", tab)
        'Gridex1.RootTable.Columns("RelatedType").EditType = EditType.MultiColumnCombo
        'Gridex1.RootTable.Columns("RelatedType").FilterEditType = FilterEditType.Combo
        'Gridex1.RootTable.Columns("RelatedType").DropDown = Gridex1.DropDowns("RelatedType")
    End Sub

    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim QR As String = "exec [dbo].[sp_BangNguoiPhuThuocChiTiet] null,null,2,'" + obj.Lan + "',NULL,NULL,NULL,NULL,NULL,NULL,N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        'Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class