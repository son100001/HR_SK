Public Class frmFamily
    Private Sub frmFamily_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        Dim tabFamily, tabTinhTP, tabQuanHuyen, tabPhuongXa, tabQuocTich, tabRelatedType As DataTable
        tvcn.GetDataOnDropDownCategoryCodeName(RelatedType, "QuanHeGiaDinh")
        tvcn.GetDataOnDropDownCategoryCodeName(Sex, "Sex")
        tabTinhTP = kn.ReadData("select MaTinhThanhPho as Code, TenTinhThanhPho as Name from HR_TinhThanhPho", "table")
        tabQuanHuyen = kn.ReadData("select MaTinhThanhPho+'_'+MaQuanHuyen as Code, TenQuanHuyen as Name from HR_QuanHuyen", "table")
        tabPhuongXa = kn.ReadData("select MaTinhThanhPho+'_'+MaQuanHuyen+'_'+MaPhuongXa as Code, TenPhuongXa as Name from HR_PhuongXa", "table")
        tabQuocTich = kn.ReadData("select Code,CountryName_EN as Name from HR_Country", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(GKS_PhuongXa, tabPhuongXa)
        tvcn.GetDataOnDropDownCategoryCodeName(GKS_QuanHuyen, tabQuanHuyen)
        tvcn.GetDataOnDropDownCategoryCodeName(GKS_TinhTP, tabTinhTP)
        tvcn.GetDataOnDropDownCategoryCodeName(QuocTich, tabQuocTich)
        tvcn.SearchEmployee(Employee_ID)
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Public Overrides Sub AfterViewForm()
        Dim tab As DataTable = kn.ReadData("select Category as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Category where CategoryFather='QuanHeGiaDinh'", "table")
        tvcn.TaoDropDowTrenGrid(GridView1, "RelatedType", tab)
    End Sub

    Private Function Save(ByVal ID As Integer, ByVal Employee_ID As String, ByVal RelatedName As String, ByVal Tel As String, ByVal RelatedType As String, ByVal Address As String, Occupation As String, ByVal BirthDate As DateTime, ByVal Sex As String, ByVal GKS_So As String, ByVal GKS_QuyenSo As String, ByVal GKS_TinhTP As String, ByVal GKS_QuanHuyen As String, ByVal GKS_PhuongXa As String, ByVal MaSoThue As String, ByVal QuocTich As String, ID_Number As String, ByVal ID_date As DateTime, ByVal ID_place As String, ByVal DependFromMonth As DateTime, ByVal DependToMonth As DateTime, ByVal BabyCareStartDate As DateTime, ByVal DateOfDeath As DateTime, ByVal Remark As String, ByVal isDaNopGiay As Boolean) As Boolean
        Dim tabCheck As DataTable
        Dim IDDate As String
        If ID_date.Year = 1 Then
            IDDate = "null"
        Else
            IDDate = "'" + ID_date.ToString("yyyy-MM-dd") + "'"
        End If
        tabCheck = kn.ReadData("exec usp_InsertUpdateSmartBooks_Employee_Family " + IIf(ID = 0, "null", ID.ToString()) + ",N'" + Employee_ID + "',N'" + RelatedName + "','" + Tel + "',N'" + RelatedType + "',N'" + Address + "',N'" + Occupation + "','" + BirthDate.ToString("yyyy-MM-dd") + "',N'" + Sex + "',N'" + GKS_So + "',N'" + GKS_QuyenSo + "',N'" + GKS_TinhTP + "',N'" + GKS_QuanHuyen + "',N'" + GKS_PhuongXa + "',N'" + MaSoThue + "',N'" + QuocTich + "','" + ID_Number + "'," + IDDate + ",N'" + ID_place + "'," + IIf(DependFromMonth.Year <> 1, "'" + DependFromMonth.ToString("yyyy-MM-dd") + "'", "null") + "," + IIf(DependToMonth.Year = 1, "null", "'" + DependToMonth.ToString("yyyy-MM-dd") + "'") + "," + IIf(BabyCareStartDate.Year = 1, "null", "'" + BabyCareStartDate.ToString("yyyy-MM-dd") + "'") + "," + IIf(DateOfDeath.Year = 1, "null", "'" + DateOfDeath.ToString("yyyy-MM-dd") + "'") + "," + IIf(Remark = String.Empty, "null", "N'" + Remark + "'") + ",N'" + obj.UserName + "','" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + IIf(isDaNopGiay = True, "1", "null"), "Table")
        If Not IsNothing(tabCheck) Then
            If tabCheck.Rows(0)("ThongBao") <> "" Then
                MessageBox.Show("Lỗi " + tabCheck.Rows(0)("ThongBao"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Else
            Return False
        End If
        MessageBox.Show("Nhập thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return True
    End Function

    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim QR As String = "exec [dbo].[sp_BangThongTinGiaDinh] '1900-1-1','" + Today.ToString("yyyy-MM-dd") + "',1,N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If QuyenHRFORM = "View" Then
            MessageBox.Show("Bạn không có quyền thay đổi!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If tvcn.CheckErrorProvider(TableLayoutPanel2, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        If MessageBox.Show("Bạn có thực sự muốn lưu?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If Save(0, Employee_ID.EditValue.ToString.Trim, RelatedName.Text.Trim, Tel.Text.Trim, RelatedType.EditValue, Address.Text.Trim, Occupation.Text.Trim, BirthDate.DateTime, Sex.EditValue, GKS_So.Text.Trim, GKS_QuyenSo.Text.Trim, GKS_TinhTP.EditValue, GKS_QuanHuyen.EditValue, GKS_PhuongXa.EditValue, MaSoThue.Text.Trim, QuocTich.EditValue, ID_Number.Text.Trim, ID_date.DateTime, ID_place.Text.Trim, DependFromMonth.DateTime, DependToMonth.DateTime, BabyCareStartDate.DateTime, DateOfDeath.DateTime, Remark.Text.Trim, isDaNopGiay.Checked) = True Then
                Search()
            End If
        End If
        tvcn.ClearTextInControlOnForm(TableLayoutPanel2)
        Employee_ID.Select()
    End Sub

    Private Sub btn18Tuoi_Click(sender As Object, e As EventArgs) Handles btn18Tuoi.Click
        If Not IsNothing(DependFromMonth.EditValue) Then
            DependToMonth.EditValue = BirthDate.DateTime.AddYears(18)
        Else
            MessageBox.Show("Bạn vui lòng nhập tháng bắt đầu phụ thuộc.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        Search()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class