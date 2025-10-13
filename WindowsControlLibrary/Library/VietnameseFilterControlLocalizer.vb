Imports DevExpress.XtraEditors.Controls

Public Class VietnameseEditorsLocalizer
    Inherits Localizer

    Public Overrides Function GetLocalizedString(id As StringId) As String
        Select Case id
            ' ==== Filter operators ====
            Case StringId.FilterClauseEquals : Return "Bằng"
            Case StringId.FilterClauseDoesNotEqual : Return "Khác"
            Case StringId.FilterClauseLess : Return "Nhỏ hơn"
            Case StringId.FilterClauseLessOrEqual : Return "Nhỏ hơn hoặc bằng"
            Case StringId.FilterClauseGreater : Return "Lớn hơn"
            Case StringId.FilterClauseGreaterOrEqual : Return "Lớn hơn hoặc bằng"
            Case StringId.FilterClauseLike : Return "Giống như"
            Case StringId.FilterClauseNotLike : Return "Không giống như"
            Case StringId.FilterClauseContains : Return "Chứa"
            Case StringId.FilterClauseDoesNotContain : Return "Không chứa"
            Case StringId.FilterClauseBeginsWith : Return "Bắt đầu với"
            Case StringId.FilterClauseEndsWith : Return "Kết thúc với"
            Case StringId.FilterClauseBetween : Return "Trong khoảng"
            Case StringId.FilterClauseNotBetween : Return "Ngoài khoảng"
            Case StringId.FilterClauseIsNull : Return "Rỗng"
            Case StringId.FilterClauseIsNotNull : Return "Không rỗng"

                ' ==== Filter menu (Text Filters, Custom Filter, Clear Filter) ====
                'Case StringId.Equal : Return "Bắt đầu với"
                'Case StringId.ManageRuleSpecificTextEndingWith : Return "Kết thúc với"
                'Case StringId.FilterClauseContains : Return "Chứa"
                'Case StringId.FilterClauseDoesNotContain : Return "Không chứa"
                'Case StringId.FilterClauseEquals : Return "Bằng"
                'Case StringId.FilterClauseDoesNotEqual : Return "Khác"
                'Case StringId.FilterClauseIsNull : Return "Rỗng"
                'Case StringId.FilterClauseIsNotNull : Return "Không rỗng"
                ''Case StringId.FilterClause : Return "Bộ lọc tùy chỉnh"
                'Case StringId.FilterMenuClearAll : Return "Xóa lọc"
        End Select

        Return MyBase.GetLocalizedString(id)
    End Function
End Class