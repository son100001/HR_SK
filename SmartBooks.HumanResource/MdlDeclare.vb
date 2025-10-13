Module MdlDeclare
    Public s_StringCnn As String
    Public s_CnnPassword As String
    Public s_CnnUserID As String
    Public s_CnnServer As String
    Public s_CnnDataBase As String
    Public mDAL As New DBA.DAL.DataAccess

    Public s_UserCreateID As String = "DUYVT"
    Public s_UserUpdateID As String = "DUYVT"
    Public s_UserGroup As String = "DUYVT"
    Public s_DateCreate As String = Now
    Public s_DateUpdate As String = Now
    Public s_Perpost As String = "200808"

    Public S_FormatDate As String = "dd/MM/yyyy"
    Public S_FormatQty As Int16 = 3
    Public S_FormatCurr As Int16 = 3
    Public S_FormatTran As Int16 = 2

    Public GotFocusColor As Integer = RGB(255, 255, 198)
    Public LostFocusColor As Integer = RGB(255, 255, 255)
    
    Public s_Title_Warning As String = "Thông báo"
    Public s_Title_Save As String = "Lưu"
    Public s_Title_Delete As String = "Xoá"
    Public s_Title_Infor As String = "Thông báo"
    Public s_Title_Search As String = "Tìm"
    Public s_Title_Print As String = "In"
    Public s_Title_Error As String = "Lỗi"
    Public s_Msg_SysError As String = "Chương trình phát sinh lỗi ngoài ý muốn. Vui lòng liên hệ với bộ phận kỹ thuật để được hổ trợ."

    Public s_SystemFont As System.String = "Arial"

    Public s_Pos_TopRebar As Int16 = 6
    Public s_Pos_cmdButtonBar As Int16 = 1
    Public s_Path_Iamge As String = ""
    Public s_Report As String = ""
    Public s_FlagLogIn As Boolean = True 'Log thất bại
    Public s_UserID, s_UserName, s_UserCode As String
    Public s_NgayLamViec As Date = Now

    Public piS_Add As Janus.Windows.UI.InheritableBoolean = Janus.Windows.UI.InheritableBoolean.True
    Public piS_Save As Janus.Windows.UI.InheritableBoolean = Janus.Windows.UI.InheritableBoolean.False
    Public piS_Delete As Janus.Windows.UI.InheritableBoolean = Janus.Windows.UI.InheritableBoolean.False
    Public piS_Search As Janus.Windows.UI.InheritableBoolean = Janus.Windows.UI.InheritableBoolean.True
    Public piS_Edit As Janus.Windows.UI.InheritableBoolean = Janus.Windows.UI.InheritableBoolean.False
    Public piS_Finish As Janus.Windows.UI.InheritableBoolean = Janus.Windows.UI.InheritableBoolean.True
    Public piS_SaveAs As Janus.Windows.UI.InheritableBoolean = Janus.Windows.UI.InheritableBoolean.False
    Public piS_Refresh As Janus.Windows.UI.InheritableBoolean = Janus.Windows.UI.InheritableBoolean.True
    Public piS_Cancel As Janus.Windows.UI.InheritableBoolean = Janus.Windows.UI.InheritableBoolean.False
    Public piS_Print As Janus.Windows.UI.InheritableBoolean = Janus.Windows.UI.InheritableBoolean.False
    Public piS_Close As Janus.Windows.UI.InheritableBoolean = Janus.Windows.UI.InheritableBoolean.True
End Module
