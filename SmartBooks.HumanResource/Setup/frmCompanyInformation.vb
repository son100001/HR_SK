Imports System.IO
Public Class frmCompanyInformation
    Private Sub frmCompanyInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel3, HRFORM_TableName)
        LoadGiaoDienTheoDieuKien()
        Dim dt As DataTable = kn.ReadData("select * from [dbo].[SmartBooks_Company] where CompanyID='" + CompanyID.Text.Trim + "'", "table")
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows(0)("Picture")) = False Then
                Dim imageData As Byte() = DirectCast(dt.Rows(0)("Picture"), Byte())
                If Not imageData Is Nothing Then
                    Dim ms As New MemoryStream(imageData, 0, imageData.Length)
                    ms.Write(imageData, 0, imageData.Length)
                    Picture.Image = Image.FromStream(ms, True)
                End If
            Else
                Picture.Image = Nothing
            End If
        End If
        Search()
    End Sub
    Private Sub Gridex1_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
    Private Sub btnChonAnh_Click(sender As Object, e As EventArgs) Handles btnChonAnh.Click
        If Me.OpenFileDialog1.ShowDialog(Me) = DialogResult.OK Then
            Try
                Dim img As Bitmap
                img = New Bitmap(Me.OpenFileDialog1.FileName)
                Picture.Image = img
            Catch
                MessageBox.Show("Invalid Picture.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnXoaAnh_Click(sender As Object, e As EventArgs) Handles btnXoaAnh.Click
        Picture.Image = Nothing
    End Sub
    Public Overrides Sub AfterSave()
        Try
            Dim a As System.Drawing.Bitmap
            a = Me.Picture.Image
            If Not a Is Nothing Then
                Dim ms As New MemoryStream
                Picture.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim arrImage() As Byte = ms.GetBuffer
                kn.UpdateImagesInformation("UpdateImagesCompany", arrImage, CompanyID.Text.Trim)
            Else
                kn.SaveData("UPDATE [dbo].[SmartBooks_Company] SET [picture] = null WHERE CompanyID = '" + CompanyID.Text.Trim + "'")
            End If
        Catch ex As Exception
            MessageBox.Show("Save Save Images Company Error!" + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.CheckErrorProvider(TableLayoutPanel3, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel3, True, QuyenHRFORM)
        CompanyID.Select()
        Search()
    End Sub
    Private Sub Search()
        Dim QR As String = "select * from SmartBooks_Company"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub
End Class