Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

''' <summary>
''' Gọi API web HR (HrApprovalWorkerController) để gửi thông báo công/lương cho nhân viên:
''' web ghi dòng chuông (inbox) + đẩy Web Push tới thiết bị đã đăng ký.
''' Cấu hình lấy từ bảng SetUp: HRWeb_ApiBaseUrl (vd https://hr.ssaudit.com/approval)
''' và HRWeb_WorkerKey (trùng giá trị HR.ApprovalWorkerKey trong Web.config của web).
''' </summary>
Public Class WebNotificationClient

    ''' <returns>True nếu gửi thành công; False kèm errorMsg nếu lỗi.</returns>
    Public Shared Function GuiThongBao(ByVal typeOfNoti As String, ByVal title As String,
                                       ByVal message As String, ByVal actionUrl As String,
                                       ByVal employeeIds As List(Of String),
                                       ByRef errorMsg As String) As Boolean
        errorMsg = String.Empty
        Dim tvcn As New WindowsControlLibrary.ThuVienChucNang
        Dim baseUrl As String = tvcn.getSetUp("HRWeb_ApiBaseUrl")
        Dim workerKey As String = tvcn.getSetUp("HRWeb_WorkerKey")
        If baseUrl = String.Empty OrElse workerKey = String.Empty Then
            errorMsg = "Chưa cấu hình HRWeb_ApiBaseUrl / HRWeb_WorkerKey trong bảng SetUp."
            Return False
        End If

        ' Mã công ty bên web (CompanyInfor.json của web) KHÁC mã login app HR
        ' (vd web dùng SKTEST -> DB HR_SnK_Test). Cấu hình qua SetUp; nếu trống dùng mã app.
        Dim webCompanyCode As String = tvcn.getSetUp("HRWeb_CompanyCode")
        If webCompanyCode = String.Empty Then
            webCompanyCode = Appsettings.DbSetting.CompanyCode
        End If

        ' .NET 4.8 mặc định có thể chưa bật TLS 1.2 khi gọi HTTPS
        ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol Or SecurityProtocolType.Tls12

        Dim body As String = JsonConvert.SerializeObject(New With {
            .CompanyCode = webCompanyCode,
            .WorkerKey = workerKey,
            .TypeOfNoti = typeOfNoti,
            .Title = title,
            .Message = message,
            .ActionUrl = actionUrl,
            .RequesterEmployee_ID = Appsettings.DbSetting.UserName,
            .EmployeeIDs = employeeIds})

        Try
            Using wc As New TimeoutWebClient(60000) ' 60 giây — server ghi theo lô nên bình thường chỉ vài giây
                wc.Encoding = Encoding.UTF8
                wc.Headers(HttpRequestHeader.ContentType) = "application/json"
                Dim url As String = baseUrl.TrimEnd("/"c) + "/api/hr/approval/worker/send_custom_notifications"
                Dim resp As String = wc.UploadString(url, body)
                Dim j As JObject = JObject.Parse(resp)
                If j("ResultCode") IsNot Nothing AndAlso CInt(j("ResultCode")) = 0 Then
                    Return True
                End If
                errorMsg = If(j("Message") IsNot Nothing, CStr(j("Message")), "Lỗi không xác định từ máy chủ web.")
                Return False
            End Using
        Catch ex As Exception
            errorMsg = ex.Message
            Return False
        End Try
    End Function

    ''' <summary>WebClient chuẩn không cho chỉnh timeout (mặc định 100s) — subclass để đặt timeout ngắn hơn.</summary>
    Private Class TimeoutWebClient
        Inherits WebClient

        Private ReadOnly _timeoutMs As Integer

        Public Sub New(ByVal timeoutMs As Integer)
            _timeoutMs = timeoutMs
        End Sub

        Protected Overrides Function GetWebRequest(ByVal address As Uri) As WebRequest
            Dim request As WebRequest = MyBase.GetWebRequest(address)
            If request IsNot Nothing Then
                request.Timeout = _timeoutMs
            End If
            Return request
        End Function
    End Class

End Class
