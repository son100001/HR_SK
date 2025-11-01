Imports OfficeOpenXml
Imports System.IO
Imports WindowsControlLibrary
Public Class frmTienCom
    Dim filepath As String
    Private Sub frmTienCom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        Ngay.DateTime = Today
        Fromdate.DateTime = Today
        Todate.DateTime = Today
        tvcn.SearchEmployee(Employee_ID)
    End Sub
    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim fd, td As DateTime
        Dim NgayChuyenDi As DateTime = tvcn.LayNgayChuyenDi(Employee_ID.Text.Trim, obj.PARA_FACTORY_ID, New DateTime(Ngay.DateTime.Year, Ngay.DateTime.Month, 2), New DateTime(Ngay.DateTime.Year, Ngay.DateTime.Month, 1).AddMonths(1).AddDays(-1))
        fd = New DateTime(Ngay.DateTime.Year, Ngay.DateTime.Month, 1)
        If NgayChuyenDi.Year = 1 Then
            td = fd.AddMonths(1).AddDays(-1)
        Else
            td = NgayChuyenDi.AddDays(-1)
        End If
        Dim QR As String = "[dbo].[sp_BangTienCom] '" + fd.ToString("yyyy-MM-dd") + "','" + td.ToString("yyyy-MM-dd") + "',1,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub TienCom_TextChanged(sender As Object, e As EventArgs) Handles TienCom.TextChanged
        tvcn.AmountFormat(TienCom)
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        HRFORM_XtraTabControl_SelectedTabChanged(sender, e)
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_TienCom]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
        End If
        Employee_ID.Select()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        'Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub btnChonAnh_Click(sender As Object, e As EventArgs) Handles btnChonAnh.Click
        If Me.OpenFileDialog1.ShowDialog(Me) = DialogResult.OK Then
            Try
                Dim img As Bitmap
                img = New Bitmap(Me.OpenFileDialog1.FileName)
                filepath = Me.OpenFileDialog1.FileName
                Picture.Image = img
            Catch
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Loidinhdanganh"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnXoaAnh_Click(sender As Object, e As EventArgs) Handles btnXoaAnh.Click
        Picture.Image = Nothing
    End Sub

    Private Sub btnSearchMealMenu_Click(sender As Object, e As EventArgs) Handles btnSearchMealMenu.Click
        Dim tabImage As DataTable = kn.ReadData("select picture from HR_MealMenu where Fromdate='" + Fromdate.DateTime.ToString("yyyy/MM/dd") + "'", "table")
        Picture.Image = Nothing
        If tabImage.Rows.Count > 0 Then
            If IsDBNull(tabImage.Rows(0)("picture")) = False Then
                Dim imageData As Byte() = DirectCast(tabImage.Rows(0)("picture"), Byte())
                If Not imageData Is Nothing Then
                    Dim ms As New MemoryStream(imageData, 0, imageData.Length)
                    ms.Write(imageData, 0, imageData.Length)
                    Picture.Image = Image.FromStream(ms, True)
                End If
            End If
        End If
    End Sub

    Private Sub btnLuuMealMenu_Click(sender As Object, e As EventArgs) Handles btnLuuMealMenu.Click
        Try
            Dim a As System.Drawing.Bitmap
            a = Me.Picture.Image
            If Not a Is Nothing Then
                Dim ms As New MemoryStream
                Picture.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim arrImage() As Byte = ms.GetBuffer
                kn.SaveData("exec usp_InsertUpdateHR_MealMenu '" + Fromdate.DateTime.ToString("yyyy/MM/dd") + "','" + Todate.DateTime.ToString("yyyy/MM/dd") + "',null")
                kn.UpdateImagesInformation("usp_InsertUpdateHR_MealMenu", arrImage, Fromdate.DateTime, Todate.DateTime)
            End If
        Catch ex As Exception
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Error") + ": " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
End Class