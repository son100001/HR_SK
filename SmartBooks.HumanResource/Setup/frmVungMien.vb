Imports WindowsControlLibrary
Public Class frmVungMien
    Inherits HRFORM

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents DanToc As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TinhThanhPho As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents QuanHuyen As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PhuongXa As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl4 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl5 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DiaChi As DevExpress.XtraTab.XtraTabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.DanToc = New DevExpress.XtraTab.XtraTabPage()
        Me.TinhThanhPho = New DevExpress.XtraTab.XtraTabPage()
        Me.QuanHuyen = New DevExpress.XtraTab.XtraTabPage()
        Me.PhuongXa = New DevExpress.XtraTab.XtraTabPage()
        Me.DiaChi = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl4 = New DevExpress.XtraGrid.GridControl()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl5 = New DevExpress.XtraGrid.GridControl()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.DanToc.SuspendLayout()
        Me.TinhThanhPho.SuspendLayout()
        Me.QuanHuyen.SuspendLayout()
        Me.PhuongXa.SuspendLayout()
        Me.DiaChi.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 459)
        Me.PanelButton.Size = New System.Drawing.Size(1112, 55)
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.DanToc
        Me.XtraTabControl1.Size = New System.Drawing.Size(1112, 459)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.DanToc, Me.TinhThanhPho, Me.QuanHuyen, Me.PhuongXa, Me.DiaChi})
        '
        'DanToc
        '
        Me.DanToc.Controls.Add(Me.GridControl1)
        Me.DanToc.Name = "DanToc"
        Me.DanToc.Size = New System.Drawing.Size(1110, 434)
        Me.DanToc.Text = "Dân tộc"
        '
        'TinhThanhPho
        '
        Me.TinhThanhPho.Controls.Add(Me.GridControl2)
        Me.TinhThanhPho.Name = "TinhThanhPho"
        Me.TinhThanhPho.Size = New System.Drawing.Size(1110, 434)
        Me.TinhThanhPho.Text = "Tỉnh, thành phố"
        '
        'QuanHuyen
        '
        Me.QuanHuyen.Controls.Add(Me.GridControl3)
        Me.QuanHuyen.Name = "QuanHuyen"
        Me.QuanHuyen.Size = New System.Drawing.Size(1110, 434)
        Me.QuanHuyen.Text = "Quận Huyện"
        '
        'PhuongXa
        '
        Me.PhuongXa.Controls.Add(Me.GridControl4)
        Me.PhuongXa.Name = "PhuongXa"
        Me.PhuongXa.Size = New System.Drawing.Size(1110, 434)
        Me.PhuongXa.Text = "Phường xã"
        '
        'DiaChi
        '
        Me.DiaChi.Controls.Add(Me.GridControl5)
        Me.DiaChi.Name = "DiaChi"
        Me.DiaChi.Size = New System.Drawing.Size(1110, 434)
        Me.DiaChi.Text = "Địa chỉ"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1110, 434)
        Me.GridControl1.TabIndex = 1323
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(1110, 434)
        Me.GridControl2.TabIndex = 1324
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        '
        'GridControl3
        '
        Me.GridControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl3.Location = New System.Drawing.Point(0, 0)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(1110, 434)
        Me.GridControl3.TabIndex = 1324
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.Name = "GridView3"
        '
        'GridControl4
        '
        Me.GridControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl4.Location = New System.Drawing.Point(0, 0)
        Me.GridControl4.MainView = Me.GridView4
        Me.GridControl4.Name = "GridControl4"
        Me.GridControl4.Size = New System.Drawing.Size(1110, 434)
        Me.GridControl4.TabIndex = 1324
        Me.GridControl4.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.GridControl4
        Me.GridView4.Name = "GridView4"
        '
        'GridControl5
        '
        Me.GridControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl5.Location = New System.Drawing.Point(0, 0)
        Me.GridControl5.MainView = Me.GridView5
        Me.GridControl5.Name = "GridControl5"
        Me.GridControl5.Size = New System.Drawing.Size(1110, 434)
        Me.GridControl5.TabIndex = 1324
        Me.GridControl5.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView5})
        '
        'GridView5
        '
        Me.GridView5.GridControl = Me.GridControl5
        Me.GridView5.Name = "GridView5"
        '
        'frmVungMien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1112, 514)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmVungMien"
        Me.Text = "frmVungMien"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.DanToc.ResumeLayout(False)
        Me.TinhThanhPho.ResumeLayout(False)
        Me.QuanHuyen.ResumeLayout(False)
        Me.PhuongXa.ResumeLayout(False)
        Me.DiaChi.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmVungMien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If e.Page.Name = "DanToc" Then
            HRFORM_TableName = "HR_DanToc"
            HRFORM_Gridview = GridView1
            HRFORM_GridControl = GridControl1
        ElseIf e.Page.Name = "TinhThanhPho" Then
            HRFORM_TableName = "HR_TinhThanhPho"
            HRFORM_Gridview = GridView2
            HRFORM_GridControl = GridControl2
        ElseIf e.Page.Name = "QuanHuyen" Then
            HRFORM_TableName = "HR_QuanHuyen"
            HRFORM_Gridview = GridView3
            HRFORM_GridControl = GridControl3
        ElseIf e.Page.Name = "PhuongXa" Then
            HRFORM_TableName = "HR_PhuongXa"
            HRFORM_Gridview = GridView4
            HRFORM_GridControl = GridControl4
        ElseIf e.Page.Name = "DiaChi" Then
            HRFORM_TableName = "HR_DiaChi"
            HRFORM_Gridview = GridView5
            HRFORM_GridControl = GridControl5
        End If
        HRFORM_XtraTabControl_SelectedTabChanged(sender, e)
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub
    Private Sub gridDanToc_KeyUp(sender As Object, e As KeyEventArgs)
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub gridDiaChi_KeyUp(sender As Object, e As KeyEventArgs)
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub gridPhuongXa_KeyUp(sender As Object, e As KeyEventArgs)
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub gridQuanHuyen_KeyUp(sender As Object, e As KeyEventArgs)
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub gridTinhThanhPho_KeyUp(sender As Object, e As KeyEventArgs)
        Gridview_KeyUp(sender, e)
    End Sub
    Private Sub Search()
        Dim QR As String = "select * from " + HRFORM_TableName
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub
End Class
