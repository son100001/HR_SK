' ====== 2) Dịch menu/grid text (chuột phải, group panel, v.v.) ======
Imports DevExpress.XtraGrid.Localization

Public Class VietnameseGridLocalizer
    Inherits GridLocalizer

    Public Overrides Function GetLocalizedString(id As GridStringId) As String
        Select Case id
            ' Menu cột
            Case GridStringId.MenuColumnFilter : Return "Lọc"
            Case GridStringId.MenuColumnClearFilter : Return "Xóa lọc"
            Case GridStringId.MenuColumnFindFilterShow : Return "Hiện ô tìm kiếm"
            Case GridStringId.MenuColumnFindFilterHide : Return "Ẩn ô tìm kiếm"
            Case GridStringId.MenuColumnSortAscending : Return "Sắp xếp tăng dần"
            Case GridStringId.MenuColumnSortDescending : Return "Sắp xếp giảm dần"
            Case GridStringId.MenuColumnBestFit : Return "Tự động vừa cột"
            Case GridStringId.MenuColumnBestFitAllColumns : Return "Tự động vừa tất cả cột"
            Case GridStringId.MenuColumnGroup : Return "Nhóm theo cột này"
            Case GridStringId.MenuColumnUnGroup : Return "Bỏ nhóm"
            Case GridStringId.MenuColumnGroupBox : Return "Hiện thanh nhóm"
            Case GridStringId.MenuColumnColumnCustomization : Return "Tùy chỉnh cột"

            ' Group panel / Find panel
            Case GridStringId.GridGroupPanelText : Return "Kéo cột vào đây để nhóm dữ liệu"
            Case GridStringId.FindControlFindButton : Return "Tìm kiếm"
            Case GridStringId.FindControlClearButton : Return "Xóa"
                'Case GridStringId.e : Return "Xóa"
        End Select

        Return MyBase.GetLocalizedString(id)
    End Function
End Class
