Imports System.Windows.Forms
Imports DevExpress.Data
Imports DevExpress.Utils
Imports DevExpress.Xpo.DB.Helpers
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraTab
Imports DevExpress.XtraReports.UI
Imports System.Drawing

Public Class HRFORM
    Public obj As New DbSetting
    Public tvcn As New ThuVienChucNang
    Public Table, Report As DataTable
    Public kn As New connect(DbSetting.dataPath)
    Public bLuu As Boolean
    Public gridRow As GridRow
    'Public gridexrow As GridEXRow
    Public ListOfDatamemberOfGrid As String()
    Public AddNew As Boolean
    Public ReportCode As String
    Public ReportRow As DataRow
    Public QuyenHRFORM, TabList As String
    Public KeyOfForm1 As String
    Private OldReportCode As String

#Region " Property "
    Private _HRFORM_TableName, _HRFORM_MainFormName, _HRFORM_QueryView, _HRFORM_InputFormName, _HRFORM_SaveStore, _HRFORM_DeleteStore As String
    Private _HRFORM_Gridview As GridView
    Private _HRFORM_GridControl As GridControl
    ' Private _HRFORM_Gridex As GridEX
    Private _HRFORM_VisibleControl_ThemMoi = True, _HRFORM_VisibleControl_Xem = True, _HRFORM_VisibleControl_Luu = True, _HRFORM_VisibleControl_Sua = True, _HRFORM_VisibleControl_Xoa = True, _HRFORM_VisibleControl_Dong = True, _HRFORM_VisibleControl_ThucHien = True, _HRFORM_VisibleControl_GetTemplate = True, _HRFORM_VisibleControl_ImportExcel = True, _HRFORM_VisibleControl_ExportExcel = True, _HRFORM_VisibleControl_cbbReport = True, _HRFORM_VisibleControl_StatusBarFooter = True, _HRFORM_VisibleControl_SaveLayout = True, _HRFORM_VisibleControl_RefreshLayout = True, _HRFORM_VisibleControl_QuickPrint = True
    Private _HRFORM_TuDongDongSauKhiLuu = True
    Private _HRFORM_TypeOfForm As TypeOfForm 'Input: Nhập; View: Xem
    'Private _HRFORM_UltraTabControl As UltraTabControl
    Private _HRFORM_XTraTabControl As XtraTabControl

    Property HRFORM_TuDongDongSauKhiLuu() As Boolean
        Get
            Return _HRFORM_TuDongDongSauKhiLuu
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_TuDongDongSauKhiLuu = Value
        End Set
    End Property
    Property HRFORM_SaveStore() As String
        Get
            Return _HRFORM_SaveStore
        End Get
        Set(ByVal Value As String)
            _HRFORM_SaveStore = Value
        End Set
    End Property
    Property HRFORM_DeleteStore() As String
        Get
            Return _HRFORM_DeleteStore
        End Get
        Set(ByVal Value As String)
            _HRFORM_DeleteStore = Value
        End Set
    End Property

    Property HRFORM_InputForm() As String
        Get
            Return _HRFORM_InputFormName
        End Get
        Set(ByVal Value As String)
            _HRFORM_InputFormName = Value
        End Set
    End Property

    Public Enum TypeOfForm
        View = 0
        Input = 1
        ViewInput = 2
    End Enum

    Property HRFORM_TypeOfForm() As TypeOfForm
        Get
            Return _HRFORM_TypeOfForm
        End Get
        Set(ByVal Value As TypeOfForm)
            _HRFORM_TypeOfForm = Value
        End Set
    End Property

    Property HRFORM_VisibleControl_Xem() As Boolean
        Get
            Return _HRFORM_VisibleControl_Xem
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_VisibleControl_Xem = Value
        End Set
    End Property

    Property HRFORM_VisibleControl_Sua() As Boolean
        Get
            Return _HRFORM_VisibleControl_Sua
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_VisibleControl_Sua = Value
        End Set
    End Property

    Property HRFORM_VisibleControl_Luu() As Boolean
        Get
            Return _HRFORM_VisibleControl_Luu
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_VisibleControl_Luu = Value
        End Set
    End Property

    Property HRFORM_VisibleControl_ThemMoi() As Boolean
        Get
            Return _HRFORM_VisibleControl_ThemMoi
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_VisibleControl_ThemMoi = Value
        End Set
    End Property

    Property HRFORM_VisibleControl_Xoa() As Boolean
        Get
            Return _HRFORM_VisibleControl_Xoa
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_VisibleControl_Xoa = Value
        End Set
    End Property

    Property HRFORM_VisibleControl_Dong() As Boolean
        Get
            Return _HRFORM_VisibleControl_Dong
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_VisibleControl_Dong = Value
        End Set
    End Property

    Property HRFORM_VisibleControl_ThucHien() As Boolean
        Get
            Return _HRFORM_VisibleControl_ThucHien
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_VisibleControl_ThucHien = Value
        End Set
    End Property

    Property HRFORM_VisibleControl_GetTemplate() As Boolean
        Get
            Return _HRFORM_VisibleControl_GetTemplate
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_VisibleControl_GetTemplate = Value
        End Set
    End Property

    Property HRFORM_VisibleControl_ImportExcel() As Boolean
        Get
            Return _HRFORM_VisibleControl_ImportExcel
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_VisibleControl_ImportExcel = Value
        End Set
    End Property

    Property HRFORM_VisibleControl_ExportExcel() As Boolean
        Get
            Return _HRFORM_VisibleControl_ExportExcel
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_VisibleControl_ExportExcel = Value
        End Set
    End Property

    Property HRFORM_VisibleControl_cbbReport() As Boolean
        Get
            Return _HRFORM_VisibleControl_cbbReport
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_VisibleControl_cbbReport = Value
        End Set
    End Property

    Property HRFORM_VisibleControl_StatusBarFooter() As Boolean
        Get
            Return _HRFORM_VisibleControl_StatusBarFooter
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_VisibleControl_StatusBarFooter = Value
        End Set
    End Property

    Property HRFORM_VisibleControl_SaveLayout() As Boolean
        Get
            Return _HRFORM_VisibleControl_SaveLayout
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_VisibleControl_SaveLayout = Value
        End Set
    End Property

    Property HRFORM_VisibleControl_RefreshLayout() As Boolean
        Get
            Return _HRFORM_VisibleControl_RefreshLayout
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_VisibleControl_RefreshLayout = Value
        End Set
    End Property

    Property HRFORM_VisibleControl_QuickPrint() As Boolean
        Get
            Return _HRFORM_VisibleControl_QuickPrint
        End Get
        Set(ByVal Value As Boolean)
            _HRFORM_VisibleControl_QuickPrint = Value
        End Set
    End Property

    Property HRFORM_TableName() As String
        Get
            Return _HRFORM_TableName
        End Get
        Set(ByVal Value As String)
            _HRFORM_TableName = Value
        End Set
    End Property
    Property HRFORM_MainFormName() As String
        Get
            Return _HRFORM_MainFormName
        End Get
        Set(ByVal Value As String)
            _HRFORM_MainFormName = Value
        End Set
    End Property
    'Property HRFORM_Gridex() As GridEX
    '    Get
    '        Return _HRFORM_Gridex
    '    End Get
    '    Set(ByVal Value As GridEX)
    '        _HRFORM_Gridex = Value
    '    End Set
    'End Property
    Property HRFORM_Gridview() As GridView
        Get
            Return _HRFORM_Gridview
        End Get
        Set(ByVal Value As GridView)
            _HRFORM_Gridview = Value
        End Set
    End Property
    Property HRFORM_GridControl() As GridControl
        Get
            Return _HRFORM_GridControl
        End Get
        Set(ByVal Value As GridControl)
            _HRFORM_GridControl = Value
        End Set
    End Property
    'Property HRFORM_UltraTabControl() As UltraTabControl
    '    Get
    '        Return _HRFORM_UltraTabControl
    '    End Get
    '    Set(ByVal Value As UltraTabControl)
    '        _HRFORM_UltraTabControl = Value
    '    End Set
    'End Property
    Property HRFORM_QueryView() As String
        Get
            Return _HRFORM_QueryView
        End Get
        Set(ByVal Value As String)
            _HRFORM_QueryView = Value
        End Set
    End Property
    Property HRFORM_XtraTabControl() As XtraTabControl
        Get
            Return _HRFORM_XTraTabControl
        End Get
        Set(ByVal Value As XtraTabControl)
            _HRFORM_XTraTabControl = Value
        End Set
    End Property

#End Region

#Region " Overridable "
    Public Overridable Sub BeforeSubmit()

    End Sub

    Public Overridable Function BeforeSave() As Integer 'Trả về 0 thì không chạy tiếp các hàm sau đó
        Return 1
    End Function
    Public Overridable Function BeforeDelete() As Integer 'Trả về 0 thì không chạy tiếp các hàm sau đó
        Return 1
    End Function

    Public Overridable Sub BeforeLoad()

    End Sub

    Public Overridable Sub AfterImportExcel()

    End Sub

    Public Overridable Sub AfterSave()

    End Sub

    Public Overridable Sub AfterDelete()

    End Sub

    Public Overridable Sub AfterViewForm()

    End Sub

    Public Overridable Sub ExecSubOrFunctionOfVB()

    End Sub
#End Region

#Region "Function"
    Private Sub LoadDesign()
        btnGetTemplate.Visible = HRFORM_VisibleControl_GetTemplate
        btnImportExcel.Visible = HRFORM_VisibleControl_ImportExcel
        btnExportExcel.Visible = HRFORM_VisibleControl_ExportExcel
        btnExcute.Visible = HRFORM_VisibleControl_ThucHien
        btnRefresh.Visible = HRFORM_VisibleControl_Xem
        btnAdd.Visible = HRFORM_VisibleControl_ThemMoi
        btnEdit.Visible = HRFORM_VisibleControl_Sua
        btnLuu.Visible = HRFORM_VisibleControl_Luu
        btnRemove.Visible = HRFORM_VisibleControl_Xoa
        cbbReport.Visible = HRFORM_VisibleControl_cbbReport
        btnSaveLayout.Visible = HRFORM_VisibleControl_SaveLayout
        btnRefreshLayout.Visible = HRFORM_VisibleControl_RefreshLayout
        btnQuickPrint.Visible = HRFORM_VisibleControl_QuickPrint
        'btnDong.Visible = HRFORM_VisibleControl_Dong
        'btnGetTemplate.Visible = HRFORM_VisibleControl_GetTemplate
        'btnImportExcel.Visible = HRFORM_VisibleControl_ImportExcel
        'btnExportExcel.Visible = HRFORM_VisibleControl_ExportExcel
        'btnThucHien.Visible = HRFORM_VisibleControl_ThucHien
        'btnXem.Visible = HRFORM_VisibleControl_Xem
        'btnThemMoi.Visible = HRFORM_VisibleControl_ThemMoi
        'btnSua.Visible = HRFORM_VisibleControl_Sua
        'btnLuu.Visible = HRFORM_VisibleControl_Luu
        'btnXoa.Visible = HRFORM_VisibleControl_Xoa
        'UltraStatusBar1.Visible = HRFORM_VisibleControl_StatusBarFooter
    End Sub

    Public Sub LoadGiaoDienTheoDieuKien()
        'HRFORM_Gridview.OptionsSelection.MultiSelect = True
        'HRFORM_Gridview.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
        'If IsNothing(HRFORM_Gridview.GetDataRow(0)) Then
        btnQuickPrint.Enabled = True
        btnImportExcel.Enabled = True
        If Not IsNothing(HRFORM_Gridview) Then
            If IsNothing(HRFORM_Gridview.GetDataRow(0)) Then
                btnExportExcel.Enabled = False
                btnQuickPrint.Enabled = False
                'btnExportExcel.Enabled = False
            Else
                If HRFORM_VisibleControl_ExportExcel = True Then
                    btnExportExcel.Enabled = True
                End If
            End If
        End If
        'If Quyen.ToUpper <> "EDIT" Or IsNothing(HRFORM_Gridview.GetDataRow(0)) Then
        If QuyenHRFORM.ToUpper <> "EDIT" Or IsNothing(HRFORM_Gridview) Then
            btnGetTemplate.Enabled = True 'btnGetTemplate.Enabled = False
            btnImportExcel.Enabled = True 'btnImportExcel.Enabled = False
            btnAdd.Enabled = False 'btnThemMoi.Enabled = False
            btnEdit.Enabled = False 'btnSua.Enabled = False
            btnRemove.Enabled = False 'btnXoa.Enabled = False
            btnLuu.Enabled = False 'btnLuu.Enabled = False
            Exit Sub
        End If
        Dim tabTableInfor As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] N'" + HRFORM_TableName + "'", "table")
        Dim bPrimaryKey, bCheckKey As Boolean
        bPrimaryKey = True
        For Each rowData As DataRow In tabTableInfor.Rows
            bCheckKey = False
            'For Each col As GridEXColumn In HRFORM_Gridex.RootTable.Columns
            For Each col As GridColumn In HRFORM_Gridview.Columns
                'If CStr(rowData("COLUMN_NAME")).ToUpper = col.DataMember.ToUpper Then 
                If CStr(rowData("COLUMN_NAME")).ToUpper = col.FieldName.ToUpper Then
                    bCheckKey = True
                    Exit For
                End If
            Next
            If bCheckKey = False Then
                If Not IsDBNull(rowData("PrimaryName")) Then
                    bPrimaryKey = False
                End If
            End If
        Next
        If bPrimaryKey = False Then
            btnGetTemplate.Enabled = True
            btnImportExcel.Enabled = True
            btnAdd.Enabled = True
            btnEdit.Enabled = True
            btnRemove.Enabled = False
            btnLuu.Enabled = False
        Else
            If HRFORM_VisibleControl_GetTemplate = True Then
                btnGetTemplate.Enabled = True
            End If
            If HRFORM_VisibleControl_ImportExcel = True Then
                btnExportExcel.Enabled = True
            End If
            If HRFORM_VisibleControl_ThemMoi = True Then
                btnAdd.Enabled = True
            End If
            If HRFORM_VisibleControl_Sua = True Then
                btnEdit.Enabled = True
            End If
            If HRFORM_VisibleControl_Xoa = True Then
                btnRemove.Enabled = True
            End If
            If HRFORM_VisibleControl_Luu = True Then
                btnLuu.Enabled = True
            End If
        End If
        'Đổi màu gridview
        HRFORM_Gridview.OptionsView.EnableAppearanceEvenRow = True
        HRFORM_Gridview.OptionsView.EnableAppearanceOddRow = True

        ' Màu dòng chẵn
        HRFORM_Gridview.Appearance.EvenRow.BackColor = Color.White
        HRFORM_Gridview.Appearance.EvenRow.Options.UseBackColor = True

        ' Màu dòng lẻ
        HRFORM_Gridview.Appearance.OddRow.BackColor = Color.WhiteSmoke
        HRFORM_Gridview.Appearance.OddRow.Options.UseBackColor = True

        'Grid filter


        btnQuickPrint.Enabled = True
    End Sub

    Public Sub Xem(ByVal strQueryView As String, ByVal NhapExcel As Boolean, ByVal GridControl1 As GridControl, ByVal G As GridView) ', ByVal GridControl1 as GridControl, ByVal G As GridView)
        Dim FrozenColumn As Integer 'Son Sua
        If strQueryView = String.Empty And NhapExcel = False Then
            xem_Click()
        Else
            If strQueryView <> String.Empty Then
                Table = kn.ReadData(strQueryView, "table")
                If IsNothing(Table) Then
                    Exit Sub
                End If
                If Table.Columns.Contains("Picture") Then
                    Table.Columns.Remove("Picture")
                End If
                Table.AcceptChanges()
            End If
            Dim bReloadGridDesign As Boolean = False
            If Not IsNothing(G.GetDataRow(0)) Then 'G.GetDataRow(0)
                If IsNothing(Table) Then
                    bReloadGridDesign = True
                Else
                    If G.Columns.Count = Table.Columns.Count Then 'If G.Columns.Count = Table.Columns.Count Then 
                        For i As Integer = 0 To G.Columns.Count - 1 'For i As Integer = 0 To  G.Columns.Count - 1
                            If Table.Columns(i).Caption.ToUpper <> G.Columns(i).ToString().ToUpper Then 'If Table.Columns(i).Caption.ToUpper <> G.Columns(i).DataMember.ToUpper Then
                                bReloadGridDesign = True
                                Exit For
                            End If
                        Next
                    Else
                        bReloadGridDesign = True
                    End If
                End If
            End If

            'Handle MouseWheel for all form
            'RemoveHandler _HRFORM_GridControl.MouseWheel, AddressOf GridControl_MouseWheel
            AddHandler _HRFORM_GridControl.MouseWheel, AddressOf GridControl_MouseWheel

            Dim columnsDropdownFromCategoryCodeName = {"EMPLOYEE_STATUS", "GRADUATED", "TONGIAO", "QUALIFICATION", "QUANHEGIADINH", "SEX", "MARITALSTATUS", "NATIONALITY", "TYPEOFHIRING"}
            If IsNothing(G.GetDataRow(0)) Or bReloadGridDesign = True Then 'G.GetDataRow(0)
                Dim tableColumn As DataTable = kn.ReadData("SELECT Column_Name from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = N'" + HRFORM_TableName + "'", "table")

                If Not IsNothing(Table) Then
                    GridControl1.DataSource = Nothing
                    G.Columns.Clear()
                    GridControl1.DataSource = Table 'GridControl1.DataSource = Table
                End If

                GridControl1.DataSource = Table 'GridControl1.DataSource = Table
                Dim columnsDateDisableEdit = {"UPDATETDATE", "INSERTDATE"}
                Dim columnsDisableVisible = {"EMPLOYEE_ID1", "ID", "RN"}
                Dim columnsDisableEdit = {"USERNAME", "APPROVAL", "INSERTSOURCE", "PASSWORD"}
                Dim columnsNotDisableEdit As New List(Of String)()
                Dim columnsSum = {"System.Double", "System.Int32"}
                Dim numericTypes As Type() = {GetType(Double), GetType(Int32), GetType(Decimal)}

                For i = 0 To tableColumn.Rows.Count - 1
                    columnsNotDisableEdit.Add(tableColumn.Rows(i)("Column_Name").ToString.ToUpper)
                Next
                columnsNotDisableEdit.Add("EMPLOYEE_ID")
                For Each col As Columns.GridColumn In G.Columns 'For Each col As Columns.GridColumn In G.Columns
                    'Disable edit columns
                    'If HRFORM_TableName <> "abc" Then
                    '    col.OptionsColumn.AllowEdit = False
                    'End If
                    If columnsNotDisableEdit.Contains(col.FieldName.ToUpper) Then 'If columnsDisableEdit.Contains(cl.FieldName.ToUpper) Then
                        col.AppearanceHeader.ForeColor = System.Drawing.Color.LightSeaGreen
                        col.OptionsColumn.AllowEdit = True
                    End If
                    'If Not IsNothing(G.GetDataRow(0)) Then 'if not isnothing(G.GetDataRow(0)) then
                    If col.ColumnType.ToString.ToUpper = "SYSTEM.DATETIME" Then
                        Dim riDatetime As New RepositoryItemDateEdit()
                        riDatetime.AllowMouseWheel = False
                        col.ColumnEdit = riDatetime
                    ElseIf col.ColumnType.ToString.ToUpper = "SYSTEM.TIMESPAN" Then
                        Dim riDatetime As New RepositoryItemTimeSpanEdit()
                        riDatetime.AllowMouseWheel = False
                        col.ColumnEdit = riDatetime
                    ElseIf numericTypes.Contains(col.ColumnType) Then
                        col.DisplayFormat.FormatString = "{0:#,##0.##}".Replace(",", ".")
                    End If
                    If col.FieldName.ToUpper = "FACTORY_ID" And HRFORM_TableName.ToUpper <> "HR_Factory".ToUpper And HRFORM_TableName.ToUpper <> "SmartBooks_Department".ToUpper And HRFORM_TableName.ToUpper <> "SmartBooks_Team".ToUpper And HRFORM_TableName.ToUpper <> "SmartBooks_Section".ToUpper Then
                        Dim tab As DataTable = kn.ReadData("select * from [dbo].[udf_Factory]('" + obj.Lan + "')", "table")
                        tvcn.TaoDropDowTrenGrid(G, col.FieldName, tab)
                    ElseIf col.FieldName.ToUpper = "DEPARTMENTCODE" And HRFORM_TableName.ToUpper <> "SmartBooks_Department".ToUpper And HRFORM_TableName.ToUpper <> "SmartBooks_Team".ToUpper And HRFORM_TableName.ToUpper <> "SmartBooks_Section".ToUpper Then
                        Dim tab As DataTable = kn.ReadData("select * from [dbo].[udf_Department](null,'" + obj.Lan + "',1)", "table")
                        tvcn.TaoDropDowTrenGrid(G, col.FieldName, tab)
                    ElseIf col.FieldName.ToUpper = "SECTIONCODE" And HRFORM_TableName.ToUpper <> "SmartBooks_Section".ToUpper And HRFORM_TableName.ToUpper <> "SmartBooks_Team".ToUpper Then
                        Dim tab As DataTable = kn.ReadData("select * from [dbo].[udf_Section](null,null,'" + obj.Lan + "',1)", "table")
                        tvcn.TaoDropDowTrenGrid(G, col.FieldName, tab)
                    ElseIf col.FieldName.ToUpper = "TEAMCODE" And HRFORM_TableName.ToUpper <> "SmartBooks_Team".ToUpper Then
                        Dim tab As DataTable = kn.ReadData("select * from [dbo].[udf_Team](null,null,null,'" + obj.Lan + "','" + IIf(HRFORM_TableName.ToUpper <> "HR_Transfer".ToUpper, "1", "0") + "')", "table")
                        tvcn.TaoDropDowTrenGrid(G, col.FieldName, tab)
                    ElseIf col.FieldName.ToUpper = "POSITION_ID" And HRFORM_TableName.ToUpper <> "SmartBooks_Position".ToUpper Then
                        Dim tab As DataTable = kn.ReadData("select Position_ID as Code,Position_Name" + obj.Lan + " as Name from SmartBooks_Position", "table")
                        tvcn.TaoDropDowTrenGrid(G, col.FieldName, tab)
                    ElseIf col.FieldName.ToUpper = "POSITIONCATEGORY_ID" And HRFORM_TableName.ToUpper <> "SmartBooks_PositionCategory".ToUpper Then
                        Dim tab As DataTable = kn.ReadData("select PositionCategory_ID as Code,PositionCategory_Name" + obj.Lan + " as Name from SmartBooks_PositionCategory", "table")
                        tvcn.TaoDropDowTrenGrid(G, col.FieldName, tab)
                    ElseIf col.FieldName.ToUpper = "CHUCDANH" And HRFORM_TableName.ToUpper <> "HR_ChucDanh".ToUpper Then
                        Dim tab As DataTable = kn.ReadData("select ChucDanh as Code,Name" + obj.Lan + " as Name from HR_ChucDanh", "table")
                        tvcn.TaoDropDowTrenGrid(G, col.FieldName, tab)
                    ElseIf col.FieldName.ToUpper = "NATION" Then
                        Dim tab As DataTable = kn.ReadData("select MaDanToc as Code,TenDanToc as Name from HR_DanToc", "table")
                        tvcn.TaoDropDowTrenGrid(G, col.FieldName, tab)
                    ElseIf col.FieldName.ToUpper = "CONTRACTFLOW" Then
                        Dim tab As DataTable = kn.ReadData("select distinct [ContractFlow] as Code, [ContractFlow] as Name from [HR_ContractFlow]", "tab")
                        tvcn.TaoDropDowTrenGrid(G, col.FieldName, tab)
                        'ElseIf col.FieldName.ToUpper = "ID_PLACE" Then
                        '    Dim tab As DataTable = kn.ReadData("select MaTinhThanhPho as Code,TenTinhThanhPho as Name from HR_TinhThanhPho", "table")
                        '    tvcn.TaoDropDowTrenGrid(G, col.FieldName, tab)
                    ElseIf columnsDropdownFromCategoryCodeName.Contains(col.FieldName.ToUpper) = True Then
                        tvcn.GetDataOnDropDownCategoryCodeName(G, col.FieldName, col.FieldName)
                        'ElseIf col.FieldName.ToUpper = "FULLNAME" Then
                        'col.Fixed = FixedStyle.Left
                        'ElseIf col.FieldName.ToUpper = "EMPLOYEE_LASTNAME" Then
                        '    col.Fixed = FixedStyle.Left
                    ElseIf col.FieldName.ToUpper = "POSITION" Then
                        Dim tab As DataTable = kn.ReadData("select * from udf_Position('" + obj.Lan + "',0)", "table")
                        tvcn.TaoDropDowTrenGrid(G, col.FieldName, tab)
                        col.Width = 200
                    ElseIf col.FieldName.ToUpper = "LEAVETYPE_ID".ToUpper And HRFORM_TableName <> "SmartBooks_LeaveType" Then
                        Dim tab As DataTable = kn.ReadData("select LeaveType_ID as Code,LeaveType_" + obj.Lan + " + (case when NumberOfDate is not null or NumberOfMonth is not null then ' - ' else '' end)+ (case when NumberOfDate is not null then N'Tối đa:' + cast(NumberOfDate as varchar(10)) +' ngày ' else '' end) +(case when NumberOfMonth is not null then  N'Tối đa:' + cast(NumberOfMonth as varchar(10)) +' tháng' else '' end) as Name from SmartBooks_LeaveType", "table")
                        tvcn.TaoDropDowTrenGrid(G, col.FieldName, tab)
                    ElseIf col.FieldName.ToUpper = "TYPEOFOT".ToUpper Then
                        Dim tab As DataTable = kn.ReadData("select Category as Code,Name" + obj.Lan + " as Name from HR_Category where CategoryFather like '%TypeOfOT'", "table")
                        tvcn.TaoDropDowTrenGrid(G, col.FieldName, tab)
                    ElseIf col.FieldName.ToUpper = "HAZARD" And HRFORM_TableName.ToUpper <> "HR_HazardCategory".ToUpper Then
                        Dim tab As DataTable = kn.ReadData("select HAZARD as Code,Name" + obj.Lan + " as Name from HR_HazardCategory", "table")
                        tvcn.TaoDropDowTrenGrid(G, col.FieldName, tab)
                    ElseIf col.FieldName.ToUpper = "SHIFTNAME" And HRFORM_TableName <> "HR_Shifts" Then
                        Dim riLookup As New RepositoryItemLookUpEdit()
                        riLookup.DataSource = kn.ReadData("exec sp_BangCa", "table")
                        riLookup.ValueMember = "ShiftName"
                        riLookup.DisplayMember = "ShiftSign"
                        riLookup.NullText = ""
                        riLookup.BestFitMode = BestFitMode.BestFitResizePopup
                        col.ColumnEdit = riLookup
                        col.OptionsColumn.AllowEdit = True
                    ElseIf col.FieldName.ToUpper = "GIOVAOTHUCTE" Then
                        ' Editor cũng chỉ cho chỉnh giờ phút giây
                        Dim timeEdit As New DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit()
                        timeEdit.Mask.EditMask = "HH:mm:ss"
                        timeEdit.DisplayFormat.FormatString = "HH:mm:ss"
                        timeEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                        ' Gán editor cho cột
                        col.ColumnEdit = timeEdit
                        col.DisplayFormat.FormatString = "HH:mm:ss"
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    ElseIf col.FieldName.ToUpper = "INOUTSTATUS" Then
                        Dim tab As DataTable = kn.ReadData("Select Category as Code, Name" + obj.Lan + " as Name from HR_Category where CategoryFather = 'InOutStatus'", "table")
                        tvcn.TaoDropDowTrenGrid(G, col.FieldName, tab)
                    End If
                    'col.FilterEditType = FilterEditType.Combo
                    'End If
                    If IsNothing(HRFORM_TableName) = False Then
                        If col.FieldName.ToUpper = "ACCESSTIME" And HRFORM_TableName.ToUpper = "HR_TIMEKEEPING_DATA" Then
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            col.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss"
                        End If
                        'If col.DataMember.ToUpper = "ACCESSTIME" And HRFORM_TableName.ToUpper = "HR_TIMEKEEPING_DATA" Then
                        '    col.FormatString = "HH:mm:ss"
                        'End If
                    End If
                    If columnsDisableVisible.Contains(col.FieldName.ToUpper) Then
                        col.Visible = False
                    End If
                    If columnsDisableEdit.Contains(col.FieldName.ToUpper) Then 'If columnsDisableEdit.Contains(cl.FieldName.ToUpper) Then
                        col.OptionsColumn.AllowEdit = False 'cl.OptionsColumn.AllowEdit = False
                    End If
                    If columnsDateDisableEdit.Contains(col.FieldName.ToUpper) Then 'cl.OptionsColumn.AllowEdit = False 'If columnsDateDisableEdit.Contains(cl.FieldName.ToUpper) Then 'cl.OptionsColumn.AllowEdit = False
                        col.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss" 'cl.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss"
                        col.OptionsColumn.AllowEdit = False
                    End If
                    If col.FieldName.ToUpper = "EMPLOYEE_ID" Then 'ElseIf cl.FieldName.ToUpper = "EMPLOYEE_ID" Then
                        col.Fixed = FixedStyle.Left
                        col.Width = 75 'cl.Width = 75
                    ElseIf col.FieldName.ToUpper = "FULLNAME" Then 'If cl.FieldName.ToUpper = "FULLNAME" Then
                        col.Width = 150 'cl.Width = 150
                    End If

                    If col.FieldName.ToUpper = "GIOVAOTHUCTE" Then
                        ' Editor cũng chỉ cho chỉnh giờ phút giây
                        Dim timeEdit As New DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit()
                        timeEdit.Mask.EditMask = "HH:mm:ss"
                        timeEdit.DisplayFormat.FormatString = "HH:mm:ss"
                        timeEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                        ' Gán editor cho cột
                        col.ColumnEdit = timeEdit
                        col.DisplayFormat.FormatString = "HH:mm:ss"
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    End If
                Next
                'Dim LanFile As String
                'LanFile = tvcn.GetAppPath() & "\lang\lang." + DbSetting.Lan + ".js"
                'Dim ListOfLAN As String() = tvcn.DichNgonNgu(LanFile, ListOfLANCode.Remove(ListOfLANCode.Length - 1).Split(","))
                'Dim i As Integer = 0
                tvcn.ChangeLanguageToForm(Me, KeyOfForm1, 1)
            Else
                GridControl1.DataSource = Table
                For Each col As GridColumn In G.Columns 'For Each col as GridColumn in G then
                    If col.FieldName.ToUpper = "FULLNAME" Then 'If col.FieldName.ToUpper = "FULLNAME" Then 
                        col.Fixed = FixedStyle.Left 'col.Fixed = FixedStyle.Left
                        Exit For
                    ElseIf col.FieldName.ToUpper = "EMPLOYEE_LASTNAME" Then 'If col.FieldName.ToUpper = "EMPLOYEE_LASTNAME" Then 
                        col.Fixed = FixedStyle.Left 'col.Fixed = FixedStyle.Left
                        Exit For
                    End If
                Next
            End If
            'Son Sua
            'If G.FrozenColumns = 0 Then
            '    G.FrozenColumns = FrozenColumn
            'End If
            'tvcn.FocusGrd(G, 0, -2)
            'HRFORM_Gridex.FilterMode = FilterMode.None
            'HRFORM_Gridex.FilterMode = FilterMode.Automatic
        End If

        'Set up Default HRFORM_Gridview
        G.OptionsSelection.MultiSelect = True
        G.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
        G.OptionsSelection.CheckBoxSelectorColumnWidth = 25
        G.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False
        G.OptionsView.ColumnAutoWidth = False
        G.OptionsMenu.ShowAutoFilterRowItem = True
        G.OptionsView.ShowAutoFilterRow = True

        LoadGiaoDienTheoDieuKien()
        AfterViewForm()
        'btnSaveLayout_Click(False, G)
        btnResetLayout_Click(True, G)
        G.OptionsView.BestFitMode = BestFitMode.BestFit
        G.BestFitMaxRowCount = 250

        Dim countInt As Integer = 0
        Dim numericTypes1 As Type() = {GetType(Double), GetType(Int32), GetType(Decimal)}

        For Each cl As Columns.GridColumn In G.Columns
            ' Nếu cột là số
            If numericTypes1.Contains(cl.ColumnType) Then
                If cl.FieldName.ToUpper() <> "ID" Then
                    cl.SummaryItem.SummaryType = SummaryItemType.Sum
                    ' Hiển thị có dấu chấm phân cách nghìn
                    cl.SummaryItem.DisplayFormat = "{0:#,##0.##}".Replace(",", ".")
                End If
            End If

            ' Nếu là cột thứ 3
            If countInt = 3 Then
                cl.SummaryItem.SummaryType = SummaryItemType.Count
                cl.SummaryItem.DisplayFormat = "Số dòng: {0}"
            End If

            countInt += 1
        Next

        Dim groupCount As GridGroupSummaryItem = New GridGroupSummaryItem()
        groupCount.FieldName = G.Columns.Item(1).FieldName
        groupCount.SummaryType = SummaryItemType.Count
        groupCount.DisplayFormat = "Count: {0}"
        G.GroupSummary.Add(groupCount)
        G.Columns.Item(1).SummaryItem.SummaryType = SummaryItemType.Count
        G.OptionsBehavior.AutoExpandAllGroups = True

        HRFORM_Gridview.OptionsView.ShowFooter = True
        G.BestFitColumns()
    End Sub
    Private Sub InitStatusBar()
        lblBottomGetDate.Text = Date.Now.ToString("dddd dd-MM-yyyy")
        Dim row As DataRow() = kn.ReadData("select top 1 * from SmartBooks_Company", "TABLE").Select()
        If row.Length > 0 Then
            If Not IsDBNull(row(0)("company_name")) Then
                lblBottomCompanyName.Text = row(0)("company_name")
            End If
        End If
    End Sub

    Public Sub ChangePasswordFormat(sender As Object, e As CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName.ToUpper <> "PASSWORD" Then
            Return
        End If
        e.DisplayText = "********"
    End Sub

    Public Sub ChangePasswordShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedColumn.FieldName.ToUpper <> "PASSWORD" Then
            Return
        End If
        Dim edit As TextEdit = TryCast(view.ActiveEditor, TextEdit)
        edit.Properties.PasswordChar = "*"c
    End Sub
#End Region

#Region "Action Control"
    Private Sub HRFORM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If tvcn.CheckLicense(New Date(2019, 5, 31)) = False Then
        '    Exit Sub
        'End If
        InitStatusBar()
        'HRFORM_ControlFirstFocus.Select()
        LoadDesign()
        'Dim tabDoDaiMaNV As DataTable = kn.ReadData("select Value from setup where ID='DoDaiMaNV'", "TABLE")
        'If tabDoDaiMaNV.Rows.Count > 0 Then
        '    If Not IsDBNull(tabDoDaiMaNV.Rows(0)("Value")) Then
        '        DoDaiMaNV = tabDoDaiMaNV.Rows(0)("Value")
        '    End If
        'End If
        If _HRFORM_TypeOfForm <> TypeOfForm.Input Then
            cbbReport.DisplayMember = "Name" + obj.Lan
            If IsNothing(HRFORM_XtraTabControl) Then
                Report = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where isnull(NotUsing,0)=0 and ReportFather=N'" + Me.Name + "' order by OrderBy", "table")
                cbbReport.DataSource = Report
            ElseIf IsNothing(Report) Then
                Report = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where isnull(NotUsing,0)=0 and ReportFather=N'" + Me.Name + " ' " + "and TabKey = N'" + HRFORM_XtraTabControl.SelectedTabPage.Name + "'" + " order by OrderBy", "table")
                cbbReport.DataSource = Report
            End If
        Else
            tvcn.ChangeLanguageToForm(Me, Me.Name, 0)
            If AddNew = False Then
                tvcn.NhapDuLieuTuGridLenFormNhap(Me, ReportRow, ListOfDatamemberOfGrid) 'gridRow
            End If
        End If
        If TabList <> String.Empty Then
            For i As Integer = 0 To HRFORM_XtraTabControl.TabPages.Count - 1
                If TabList.ToUpper.Split(",").Contains(HRFORM_XtraTabControl.TabPages.Item(i).Name.ToUpper) Then
                    'If TabList.ToUpper.Split(",").Contains(HRFORM_XtraTabControl.TabPages.Item(i).Key.ToUpper) Then
                    HRFORM_XtraTabControl.TabPages.Item(i).Visible = True
                Else
                    HRFORM_XtraTabControl.TabPages.Item(i).Visible = False
                End If
            Next
        End If
    End Sub
    Private Sub getTemplate_Click()
        tvcn.LayTemplateEPPlus(HRFORM_TableName, 10, "ImportGeneralExcel.xlsx", Me)
    End Sub
    Private Sub importExcel_Click()
        Table = tvcn.NhapExcelToDatableEPPlus(HRFORM_TableName, 6, 11)
        Xem(String.Empty, True, HRFORM_GridControl, HRFORM_Gridview) 'HRFORM_Gridview
        AfterImportExcel()
    End Sub
    Private Sub exportExcel_Click()
        tvcn.XuatDanhSachNhanVienTheoLuoi(Me.Text, IIf(ReportCode = String.Empty, "ExportExcel", ReportCode), HRFORM_Gridview) 'HRFORM_Gridex
    End Sub

    Public Sub ThucHien(ByVal rc As String)
        If cbbReport.Text.Trim = String.Empty And rc = String.Empty Then
            Exit Sub
        End If
        Dim row As DataRow()
        If rc <> String.Empty Then
            row = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where ReportCode='" + rc + "'", "table").Select()
        Else
            row = Report.Select("ReportCode='" + cbbReport.SelectedItem("ReportCode") + "'")
        End If
        If row.Length <= 0 Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Baocaokhongtontaivuilongkiemtralai"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim bShowParaForm As Boolean = True
        Dim QR As String
        Dim frm As New frmPara
        frm.KeyOfForm1 = KeyOfForm1
        frm.Quyen = QuyenHRFORM
        frm.ReportInformation = row(0)
        If Not row(0)("PrintViewDocument_FieldKey").ToString = "" Then
            Dim DanhSachKey As String
            For numberRow As Integer = 0 To HRFORM_Gridview.SelectedRowsCount - 1
                DanhSachKey += HRFORM_Gridview.GetDataRow(HRFORM_Gridview.GetSelectedRows(numberRow)).Item(row(0)("PrintViewDocument_FieldKey")).ToString() + ","
            Next
            'For Each GridExRow As GridEXRow In HRFORM_Gridex.GetCheckedRows
            '    DanhSachKey += CStr(GridExRow.Cells(row(0)("PrintViewDocument_FieldKey")).Value) + ","
            'Next
            If DanhSachKey <> String.Empty Then
                DanhSachKey = DanhSachKey.Remove(DanhSachKey.Length - 1, 1)
            End If
            frm.para_DanhSachKey.Text = DanhSachKey
            If DanhSachKey = String.Empty Then
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Banvuilongchondongtrenluoideinvanban"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        If Not row(0)("ParameterFormNotShow").ToString = "" Then
            If row(0)("ParameterFormNotShow") = True Then
                bShowParaForm = False
            End If
        End If
        'If Not IsDBNull(row(0)("FrozenColumn")) Then
        '    HRFORM_Gridex.FrozenColumns = row(0)("FrozenColumn")
        'End If
        If bShowParaForm = True Then
            frm.ShowDialog()
        End If
        If frm.bThucHienLenh = True Then
            If Not IsDBNull(row(0)("ExecSubOrFunctionOfVB")) Then
                If row(0)("ExecSubOrFunctionOfVB") = True Then
                    ExecSubOrFunctionOfVB()
                    Exit Sub
                End If
            End If
            If frm.bViewOnGrid = True Then
                QR = frm.CreateQueryForReport()
                HRFORM_QueryView = QR
                If HRFORM_QueryView <> String.Empty Then
                    Xem(HRFORM_QueryView, False, HRFORM_GridControl, HRFORM_Gridview) 'HRFORM_Gridex
                End If
            ElseIf frm.bPrintView = True Then
                If IsDBNull(row(0)("TemplateFile")) Then
                    MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Phaimaukhongtontai"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                Dim TemplateFile As String = row(0)("TemplateFile")
                If Mid(TemplateFile, Len(TemplateFile) - 4) = ".repx" Then
                    PrintReport(TemplateFile, frm.ObjectParameter(), True)
                Else
                    PrintReport(TemplateFile, frm.ObjectParameter())
                End If
                'ElseIf frm.bPrintViewDocument = True Then
                '    If Not IsDBNull(row(0)("TemplateFile")) Then
                '        Dim TemplateFile As String = row(0)("TemplateFile")
                '        QR = frm.CreateQueryForReport()
                '        Dim table As DataTable = kn.ReadData(QR, "table")
                '        Dim PrinViewDocument_Excel As Boolean
                '        If Not IsDBNull(row(0)("PrinViewDocument_Excel")) Then
                '            PrinViewDocument_Excel = row(0)("PrinViewDocument_Excel")
                '        End If
                '        tvcn.PrintViewDocument(Me.ParentForm, table, TemplateFile, PrinViewDocument_Excel)
                '    Else
                '        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Phaimaukhongtontai"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    End If
            ElseIf frm.ExportDocumentFile.Checked = True Then
                Dim TemplateFile As String = row(0)("TemplateFile")
                QR = frm.CreateQueryForReport()
                Dim table As DataTable = kn.ReadData(QR, "table")
                Dim PrinViewDocument_Excel As Boolean
                If Not IsDBNull(row(0)("PrinViewDocument_Excel")) Then
                    PrinViewDocument_Excel = row(0)("PrinViewDocument_Excel")
                End If
                If PrinViewDocument_Excel = True Then
                    tvcn.DienGiaTriVaoKeyTrenFileExcel(table, TemplateFile + ".xlsx", False)
                Else
                    tvcn.XuatFileWord(False, TemplateFile + ".docx", TemplateFile + ".xlsx", table)
                End If
            End If
            tvcn.GhiNoiDungVaoFileDebug(tvcn.GetAppPath() + "\LOG\Debug.txt", DateTime.Now & QR)
        End If
        'btnSaveLayout_Click(False, HRFORM_Gridview)
        btnResetLayout_Click(True, HRFORM_Gridview)
    End Sub

    Private Sub btnThucHien_Click(sender As Object, e As EventArgs)
        ThucHien(String.Empty)
    End Sub

    Public Sub print_Click()
        If Not IsNothing(HRFORM_Gridview) Then
            HRFORM_Gridview.OptionsPrint.PrintSelectedRowsOnly = IIf(HRFORM_Gridview.SelectedRowsCount = 0, False, True)
            HRFORM_Gridview.ShowPrintPreview()
        Else
            MsgBox("Nothing to print", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub xem_Click()
        HRFORMXem()
    End Sub

    Public Sub HRFORMXem()
        If HRFORM_QueryView = String.Empty Then
            Dim row As DataRow()
            If Not IsNothing(Report) Then
                If Not IsNothing(HRFORM_XtraTabControl) Then
                    row = Report.Select("ReportFather='" + Me.Name + "' and TabKey='" + HRFORM_XtraTabControl.SelectedTabPage.Name + "' and ControlNameAction='btnXem'")
                Else
                    row = Report.Select("ReportFather='" + Me.Name + "' and ControlNameAction='btnXem'")
                End If
                If row.Length > 0 Then
                    Me.ReportCode = row(0)("ReportCode")
                    Dim frm As New frmPara
                    Dim bfrmParaShow As Boolean = False
                    frm.ReportInformation = row(0)
                    frm.ShowDialog()
                    If frm.bThucHienLenh = True Then
                        HRFORM_QueryView = frm.CreateQueryForReport()
                    End If
                End If
            End If
        End If
        If HRFORM_QueryView <> String.Empty Then
            Xem(HRFORM_QueryView, False, HRFORM_GridControl, HRFORM_Gridview) 'HRFORM_Gridex
        End If
    End Sub
    Private Sub btnAdd_Click()
        If tvcn.AddNewOrEdit(True, Me, HRFORM_TableName, HRFORM_Gridview, QuyenHRFORM, HRFORM_InputForm) Then 'HRFORM_GridView
            Xem(HRFORM_QueryView, False, HRFORM_GridControl, HRFORM_Gridview) 'HRFORM_GridView
        End If
    End Sub
    Private Sub btnEdit_Click()
        If tvcn.AddNewOrEdit(False, Me, HRFORM_TableName, HRFORM_Gridview, QuyenHRFORM, HRFORM_InputForm) Then 'HRFORM_GridView
            Xem(HRFORM_QueryView, False, HRFORM_GridControl, HRFORM_Gridview) 'HRFORM_GridView
        End If
    End Sub
    Private Sub btnLuu_Click()

        If BeforeSave() = 1 Then
            If HRFORM_TypeOfForm = TypeOfForm.Input Or HRFORM_TypeOfForm = TypeOfForm.ViewInput Then
                If tvcn.LuuHoacXoaTuForm(HRFORM_TableName, Me, True, QuyenHRFORM) Then
                    bLuu = True
                    If HRFORM_TuDongDongSauKhiLuu = True Then
                        Me.Close()
                    End If
                Else
                    Exit Sub
                End If
            Else
                If IsNothing(HRFORM_Gridview.GetDataRow(0)) Then 'HRFORM_Gridex.RootTable
                    Exit Sub
                End If
                If IsNothing(Table.GetChanges()) Then
                    Exit Sub
                End If
                If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonluu"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Sub
                End If
                If HRFORM_SaveStore = String.Empty Then
                    tvcn.LuuTuDataTable(HRFORM_TableName, Table, QuyenHRFORM)
                Else
                    tvcn.LuuTuDataTable(HRFORM_SaveStore, HRFORM_TableName, Table, QuyenHRFORM)
                End If
            End If
            AfterSave()
        End If
    End Sub
    Private Sub btnRestoreLayout()
        HRFORM_Gridview.RestoreLayoutFromXml(Application.StartupPath() + "\Layouts\" + IIf(ReportCode <> "", ReportCode, HRFORM_TableName) + "_save" + ".xml")
    End Sub
    Private Sub btnSaveLayout_Click(ByVal isModify As Boolean, ByVal grid As GridView) 'isModify: Save when User Modify gridview
        grid.SaveLayoutToXml(Application.StartupPath() + "\Layouts\" + IIf(ReportCode <> "", ReportCode, HRFORM_TableName) + IIf(isModify, "_save", "") + ".xml")
    End Sub
    Private Sub btnResetLayout_Click(ByVal isModify As Boolean, ByVal grid As GridView) 'isModify: Load when User Modify gridview
        Dim filePath = Application.StartupPath() + "\Layouts\" + IIf(ReportCode <> "", ReportCode, HRFORM_TableName) + IIf(isModify, "_save", "") + ".xml"
        If System.IO.File.Exists(filePath) Then
            grid.RestoreLayoutFromXml(filePath)
            If Not isModify Then
                grid.RestoreLayoutFromXml(filePath)
                'btnSaveLayout_Click(False, grid)
                HRFORM_Gridview.BestFitColumns()
            End If
        Else
            btnSaveLayout_Click(False, grid)
            HRFORM_Gridview.BestFitColumns()
        End If
    End Sub
    Private Sub btnXoa_Click()
        If BeforeDelete() = 1 Then
            'If HRFORM_TypeOfForm = TypeOfForm.View Then
            If IsNothing(HRFORM_Gridview.GetDataRow(0)) Then 'HRFORM_Gridex.RootTable
                Exit Sub
            End If
            If HRFORM_Gridview.SelectedRowsCount <= 0 Then 'HRFORM_Gridex.GetCheckedRows.Count <= 0 Then 
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Banvuilongchondongcanxoa"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'If MessageBox.Show("Bạn có thực sự muốn xóa?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '    If HRFORM_DeleteStore = String.Empty Then
            '        If tvcn.XoaDongLuaChonTrenGrid(HRFORM_Gridex, HRFORM_TableName, Quyen) = False Then
            '            Exit Sub
            '        End If
            '    Else
            '        If tvcn.XoaDongLuaChonTrenGrid(HRFORM_Gridex, HRFORM_TableName, Quyen, HRFORM_DeleteStore) = False Then
            '            Exit Sub
            '        End If
            '    End If
            'Else
            '    Exit Sub
            'End If
            If HRFORM_DeleteStore = String.Empty Then
                If tvcn.XoaDongLuaChonTrenGrid(HRFORM_Gridview, HRFORM_TableName, QuyenHRFORM) = False Then 'HRFORM_Gridex
                    Exit Sub
                End If
            Else
                If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonxoa"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If tvcn.XoaDongLuaChonTrenGrid(HRFORM_Gridview, HRFORM_TableName, QuyenHRFORM, HRFORM_DeleteStore) = False Then 'HRFORM_Gridex
                        Exit Sub
                    End If
                End If
            End If
            'Else
            '    If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonxoa"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '        If tvcn.LuuHoacXoaTuForm(HRFORM_TableName, Me, False, Quyen) = False Then
            '            Exit Sub
            '        End If
            '    Else
            '        Exit Sub
            '    End If
            'End If
            AfterDelete()
            Xem(HRFORM_QueryView, False, HRFORM_GridControl, HRFORM_Gridview) 'HRFORM_Gridex
        End If
    End Sub

    Public Sub windowsUIButtonPanel_Click(sender As Object, e As EventArgs)

    End Sub

    'Public Sub windowsUIButtonPanel_ButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles windowsUIButtonPanel.ButtonClick
    '    If e.Button.Properties.Caption = "btnGetTemplate" Then 'Get template
    '        getTemplate_Click()
    '    ElseIf e.Button.Properties.Caption = "btnImportExcel" Then 'Import Excel
    '        importExcel_Click()
    '    ElseIf e.Button.Properties.Caption = "btnExportExcel" Then 'Export Excel
    '        exportExcel_Click()
    '    ElseIf e.Button.Properties.Caption = "btnPrint" Then
    '        print_Click()
    '    ElseIf e.Button.Properties.Caption = "btnFunction" Then
    '        ThucHien(String.Empty)
    '    End If
    'End Sub

    Private Sub btnGetTemplate_Click(sender As Object, e As EventArgs) Handles btnGetTemplate.Click
        getTemplate_Click()
    End Sub

    Private Sub btnImportExcel_Click(sender As Object, e As EventArgs) Handles btnImportExcel.Click
        importExcel_Click()
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        exportExcel_Click()
    End Sub

    Private Sub btnQuickPrint_Click(sender As Object, e As EventArgs) Handles btnQuickPrint.Click
        print_Click()
    End Sub

    Private Sub btnExcute_Click(sender As Object, e As EventArgs) Handles btnExcute.Click
        ThucHien(String.Empty)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        xem_Click()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        btnAdd_Click()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        btnEdit_Click()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnLuu.Click
        btnLuu_Click()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        btnXoa_Click()
    End Sub

    Private Sub btnSaveLayout_Click(sender As Object, e As EventArgs) Handles btnSaveLayout.Click
        btnSaveLayout_Click(True, HRFORM_Gridview)
        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Luuthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnRefreshLayout_Click(sender As Object, e As EventArgs) Handles btnRefreshLayout.Click
        btnResetLayout_Click(False, HRFORM_Gridview)
    End Sub

    'Private Sub WindowsUIButtonPanel1_ButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonClick
    '    If e.Button.Properties.Caption = "btnRefresh" Then
    '        xem_Click()
    '    ElseIf e.Button.Properties.Caption = "btnAdd" Then 'Add new file
    '        btnAdd_Click()
    '    ElseIf e.Button.Properties.Caption = "btnEdit" Then 'Edit File
    '        btnEdit_Click()
    '    ElseIf e.Button.Properties.Caption = "btnSave" Then 'Print
    '        btnLuu_Click()
    '    ElseIf e.Button.Properties.Caption = "btnRemove" Then 'Remove file
    '        btnXoa_Click()
    '    ElseIf e.Button.Properties.Caption = "btnClose" Then
    '        Me.Close()
    '    ElseIf e.Button.Properties.Caption = "btnSaveLayout" Then
    '        btnSaveLayout_Click(True, HRFORM_Gridview)
    '    ElseIf e.Button.Properties.Caption = "btnResetLayout" Then
    '        btnResetLayout_Click(False, HRFORM_Gridview)
    '    End If
    'End Sub


    'Public Function CheckGridEX_CellUpdated(sender As Object, e As ColumnActionEventArgs) As Boolean
    '    Dim tableInf As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] '" + HRFORM_TableName + "'", "table")
    '    For Each r As DataRow In tableInf.Rows
    '        If e.Column.DataMember.ToUpper = r("COLUMN_NAME").ToString.ToUpper Then
    '            If IsDBNull(HRFORM_Gridex.GetRow.Cells(r("COLUMN_NAME")).Value) And r("IS_NULLABLE") = "NO" Then
    '                HRFORM_Gridex.CancelCurrentEdit()
    '                Return False
    '            End If
    '        End If
    '    Next
    '    Return True
    'End Function
    Public Sub Gridview_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.Q Then
            Me.Close()
        End If
        If IsNothing(HRFORM_Gridview.GetDataRow(0)) Then 'HRFORM_Gridex.RootTable
            Exit Sub
        End If
        Dim bLuu As Boolean = False
        If e.Control AndAlso e.KeyCode = Keys.S Then
            If btnLuu.Enabled = True Then
                HRFORM_Gridview.RefreshData()
                btnLuu_Click()
            End If
            'ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            '    If btnAdd.Enabled = True And btnAdd.Visible = True Then
            '        bLuu = tvcn.AddNewOrEdit(True, Me, HRFORM_TableName, HRFORM_Gridview, Quyen, HRFORM_InputForm) 'HRFORM_Gridex
            '    End If
            'ElseIf e.Control AndAlso e.KeyCode = Keys.E Then
            '    If btnEdit.Enabled = True And btnEdit.Visible = True Then
            '        bLuu = tvcn.AddNewOrEdit(False, Me, HRFORM_TableName, HRFORM_Gridview, Quyen, HRFORM_InputForm) 'HRFORM_Gridex
            '    End If
        ElseIf e.Control AndAlso e.KeyCode = Keys.D Then
            If btnRemove.Enabled = True Then
                If HRFORM_Gridview.SelectedRowsCount > 0 Then 'HRFORM_Gridview.SelectedRowsCount
                    btnXoa_Click()
                End If
            End If
            'ElseIf e.KeyCode = Keys.Tab Then
            '    For Each ct As Control In Panel1.Controls
            '        If ct.Enabled = True And ct.Visible = True Then
            '            ct.Focus()
            '            Exit Sub
            '        End If
            '    Next
        ElseIf e.Control AndAlso e.KeyCode = Keys.F Then
            tvcn.FocusGrd(HRFORM_Gridview, 0, -2) 'HRFORM_Gridex
        ElseIf e.KeyCode = Keys.F5 Then
            If HRFORM_QueryView = String.Empty Then
                xem_Click()
            Else
                bLuu = True
            End If
        End If
        If bLuu = True Then
            Xem(HRFORM_QueryView, False, HRFORM_GridControl, HRFORM_Gridview) 'HRFORM_Gridex
        End If
    End Sub
    Private Sub cbbReport_ValueChanged(sender As Object, e As EventArgs) Handles cbbReport.SelectedValueChanged
        If Not IsNothing(cbbReport.SelectedItem) Then
            If Report.Select("ReportCode='" + cbbReport.SelectedItem("ReportCode") + "'").Length >= 0 Then
                ReportRow = Report.Select("ReportCode='" + cbbReport.SelectedItem("ReportCode") + "'")(0)
            End If
        End If
        ReportCode = cbbReport.SelectedItem("ReportCode")
        'Try
        '    If Not cbbReport.SelectedItem = "" Then 'cbbReport.SelectedItem.Value = "" Then
        '        If Report.Select("ReportCode='" + cbbReport.SelectedItem("ReportCode") + "'").Length >= 0 Then 'cbbReport.SelectedItem.Value
        '            ReportRow = Report.Select("ReportCode='" + cbbReport.SelectedItem("ReportCode") + "'")(0) 'cbbReport.SelectedItem.Value
        '        End If
        '    End If
        '    ReportCode = cbbReport.SelectedItem
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub cbbReport_KeyUp(sender As Object, e As KeyEventArgs) Handles cbbReport.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnThucHien_Click(Nothing, Nothing)
        ElseIf e.Control AndAlso e.KeyCode = Keys.F Then
            Filter()
        End If
    End Sub
    'Public Sub HRFORM_UltraTabControl_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs)
    '    cbbReport.DisplayMember = "Name" + obj.Lan
    '    If Me.Name = "para_TimeKeeping_Data2" Or Me.Name = "para_TimeKeeping_Date" Then
    '        Dim KH As String = tvcn.getSetUp("KH")
    '        Dim KHFromDate, KHToDate As DateTime
    '        KHFromDate = CType(KH.Split("#"c)(0), Date)
    '        KHToDate = CType(KH.Split("#"c)(1), Date)
    '        If Today <= KHToDate And Today >= KHFromDate Then
    '            If Me.Name = "para_TimeKeeping_Data2" Then
    '                Report = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where ReportCode in ('GetAccessTimeFromMachine','GetAccessTimeFromMachine_FollowGrid') and isnull(NotUsing,0)=0 and ReportFather=N'" + Me.Name + "' order by OrderBy", "table")
    '            ElseIf Me.Name = "para_TimeKeeping_Date" Then
    '                Report = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where ReportCode not in ('LayDuLieuChamCong') and isnull(NotUsing,0)=0 and tabkey='TinhCong' and ReportFather=N'" + Me.Name + "' order by OrderBy", "table")
    '            End If
    '        Else
    '            Report = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where isnull(NotUsing,0)=0 and ReportFather=N'" + Me.Name + "' and TabKey=N'" + e.Tab.Key + "' order by OrderBy", "table")
    '        End If
    '    Else
    '        Report = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where isnull(NotUsing,0)=0 and ReportFather=N'" + Me.Name + "' and TabKey=N'" + e.Tab.Key + "' order by OrderBy", "table")
    '    End If
    '    'Report = kn.ReadData("select * from HR_Report where isnull(NotUsing,0)=0 and ReportFather=N'" + Me.Name + "' and TabKey=N'" + e.Tab.Key + "' order by OrderBy", "table")
    '    cbbReport.DataSource = Report
    '    HRFORM_QueryView = String.Empty
    '    cbbReport.Text = String.Empty
    'End Sub

    Public Sub HRFORM_XtraTabControl_SelectedTabChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs)
        cbbReport.DisplayMember = "Name" + obj.Lan
        If Me.Name = "para_TimeKeeping_Data2" Or Me.Name = "para_TimeKeeping_Date" Then
            Dim KH As String = tvcn.getSetUp("KH")
            Dim KHFromDate, KHToDate As DateTime
            KHFromDate = CType(KH.Split("#"c)(0), Date)
            KHToDate = CType(KH.Split("#"c)(1), Date)
            If Today <= KHToDate And Today >= KHFromDate Then
                If Me.Name = "para_TimeKeeping_Data2" Then
                    Report = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where ReportCode in ('GetAccessTimeFromMachine','GetAccessTimeFromMachine_FollowGrid') and isnull(NotUsing,0)=0 and ReportFather=N'" + Me.Name + "' order by OrderBy", "table")
                ElseIf Me.Name = "para_TimeKeeping_Date" Then
                    Report = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where ReportCode not in ('LayDuLieuChamCong') and isnull(NotUsing,0)=0 and tabkey='TinhCong' and ReportFather=N'" + Me.Name + "' order by OrderBy", "table")
                End If
            Else
                Report = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where isnull(NotUsing,0)=0 and ReportFather=N'" + Me.Name + "' and TabKey=N'" + e.Page.Name + "' order by OrderBy", "table")
            End If
        Else
            Report = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where isnull(NotUsing,0)=0 and ReportFather=N'" + Me.Name + "' and TabKey=N'" + e.Page.Name + "' order by OrderBy", "table")
        End If
        'Report = kn.ReadData("select * from HR_Report where isnull(NotUsing,0)=0 and ReportFather=N'" + Me.Name + "' and TabKey=N'" + e.Tab.Key + "' order by OrderBy", "table")
        cbbReport.DataSource = Report
        HRFORM_QueryView = String.Empty
        cbbReport.Text = String.Empty
    End Sub

    Public Sub HRFORM_XtraTabControl_SelectedTabChanged(ByVal XtraTab As XtraTabControl)
        cbbReport.DisplayMember = "Name" + obj.Lan
        If Me.Name = "para_TimeKeeping_Data2" Or Me.Name = "para_TimeKeeping_Date" Then
            Dim KH As String = tvcn.getSetUp("KH")
            Dim KHFromDate, KHToDate As DateTime
            KHFromDate = CType(KH.Split("#"c)(0), Date)
            KHToDate = CType(KH.Split("#"c)(1), Date)
            If Today <= KHToDate And Today >= KHFromDate Then
                If Me.Name = "para_TimeKeeping_Data2" Then
                    Report = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where ReportCode in ('GetAccessTimeFromMachine','GetAccessTimeFromMachine_FollowGrid') and isnull(NotUsing,0)=0 and ReportFather=N'" + Me.Name + "' order by OrderBy", "table")
                ElseIf Me.Name = "para_TimeKeeping_Date" Then
                    Report = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where ReportCode not in ('LayDuLieuChamCong') and isnull(NotUsing,0)=0 and tabkey='TinhCong' and ReportFather=N'" + Me.Name + "' order by OrderBy", "table")
                End If
            Else
                Report = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where isnull(NotUsing,0)=0 and ReportFather=N'" + Me.Name + "' and TabKey=N'" + XtraTab.TabPages(0).Name + "' order by OrderBy", "table")
            End If
        Else
            Report = kn.ReadData("select *, " + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Report where isnull(NotUsing,0)=0 and ReportFather=N'" + Me.Name + "' and TabKey=N'" + XtraTab.TabPages(0).Name + "' order by OrderBy", "table")
        End If
        'Report = kn.ReadData("select * from HR_Report where isnull(NotUsing,0)=0 and ReportFather=N'" + Me.Name + "' and TabKey=N'" + e.Tab.Key + "' order by OrderBy", "table")
        cbbReport.DataSource = Report
        HRFORM_QueryView = String.Empty
        cbbReport.Text = String.Empty
    End Sub

    Public Sub Filter()
        If Not IsNothing(HRFORM_Gridview.GetDataRow(0)) Then 'HRFORM_Gridex.RootTable
            Dim tvcn As New WindowsControlLibrary.ThuVienChucNang()
            tvcn.FocusGrd(HRFORM_Gridview, 0, -2) 'HRFORM_Gridex
        End If
    End Sub
    Private Sub btnGetTemplate_KeyUp(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub btnImportExcel_KeyUp(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub btnLuu_KeyUp(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub btnSua_KeyUp(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub btnThemMoi_KeyUp(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub btnThucHien_KeyUp(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub btnXem_KeyUp(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub btnXoa_KeyUp(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub btnExportExcel_KeyUp(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub btnDong_KeyUp(sender As Object, e As KeyEventArgs)

    End Sub

    Public Sub GridControl_MouseWheel(sender As Object, e As MouseEventArgs)
        _HRFORM_GridControl.FocusedView.CloseEditor()
    End Sub

#End Region

#Region "Dev-Express Report"
    Public Sub PrintReport(ByVal report As String, ByVal pValues() As Object, Optional ByVal DevexpressReport As Boolean = False)
        Cursor = Cursors.WaitCursor
        Dim link As String
        link = Application.StartupPath & "\" & "Teamleate\" & report
        If DevexpressReport Then
            Dim ReportViewer1 As New XtraReport()
            ReportViewer1.LoadLayout(link)
            ReportViewer1.ShowPreview()
        Else
            'Dim devexpressViewer As New IReportPrintTool(New Report)
            Dim rptViewer As New ReportViewer
            rptViewer.ShowReport(link, pValues)
            rptViewer.MdiParent = Me.MdiParent
            rptViewer.Show()
        End If
        Cursor = Cursors.Default
    End Sub
    Public Sub ExportReport(ByVal report As String, ByVal pValues() As Object, ByVal addressToExport As String)
        Cursor = Cursors.WaitCursor
        Dim rptViewer As New ReportExport
        Dim strReportFile As String
        strReportFile = Application.StartupPath & "\" & "Teamleate\" & report
        rptViewer.ExportReport(strReportFile, pValues, addressToExport)
    End Sub
#End Region

End Class