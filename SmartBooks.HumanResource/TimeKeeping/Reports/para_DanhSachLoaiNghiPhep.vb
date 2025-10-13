 
Imports System.IO
Imports Appsettings
Imports SmartBooks.BusinessLogic
Imports System.Text
Public Class para_DanhSachLoaiNghiPhep
    Inherits WindowsControlLibrary.HRFORM
    Dim kn As New connect(DbSetting.dataPath)
    Dim timekeeping As New Giang_TimeKeeping
    Private strb_LoaiNghiPhep As New StringBuilder
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Private strb_TenLoaiNghiPhep As New StringBuilder

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnClose1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 407)
        Me.PanelButton.Size = New System.Drawing.Size(1240, 11)
        Me.PanelButton.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnClose1)
        Me.GroupBox2.Controls.Add(Me.btnOK)
        Me.GroupBox2.Location = New System.Drawing.Point(-4, 361)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1248, 56)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        '
        'btnClose1
        '
        Me.btnClose1.Location = New System.Drawing.Point(1150, 19)
        Me.btnClose1.Name = "btnClose1"
        Me.btnClose1.Size = New System.Drawing.Size(80, 23)
        Me.btnClose1.TabIndex = 1229
        Me.btnClose1.Text = "Close"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(1064, 19)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 23)
        Me.btnOK.TabIndex = 1228
        Me.btnOK.Text = "OK"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GridControl1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1240, 360)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(3, 16)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1234, 341)
        Me.GridControl1.TabIndex = 1323
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(1152, 19)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 1229
        Me.btnClose.Text = "Close"
        '
        'para_DanhSachLoaiNghiPhep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1240, 418)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "abc"
        Me.Name = "para_DanhSachLoaiNghiPhep"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "para_DanhSachLoaiNghiPhep"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose1.Click
        Me.Close()
    End Sub

    Private Sub para_DanhSachLoaiNghiPhep_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Danh Sách Loại Nghỉ"
        GridControl1.DataSource = kn.ReadData("select * from SmartBooks_LeaveType", "SmartBooks_LeaveType")
    End Sub

    Public Function getDanhSachLoaiNghiPhep() As String()
        If strb_LoaiNghiPhep.ToString <> String.Empty Then
            Return Split(strb_LoaiNghiPhep.ToString, ",")
        End If
    End Function
    Public Function getDanhSachTenLoaiNghiPhep() As String()
        If strb_TenLoaiNghiPhep.ToString <> String.Empty Then
            Return Split(strb_TenLoaiNghiPhep.ToString, ",")
        End If
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
            strb_LoaiNghiPhep.Append(GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("ID").ToString() + ",")
            strb_TenLoaiNghiPhep.Append(GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("LeaveType_VN").ToString() + ",")
        Next
        If strb_LoaiNghiPhep.ToString <> String.Empty Then
            strb_LoaiNghiPhep = strb_LoaiNghiPhep.Remove(strb_LoaiNghiPhep.Length - 1, 1)
        End If
        If strb_TenLoaiNghiPhep.ToString <> String.Empty Then
            strb_TenLoaiNghiPhep = strb_TenLoaiNghiPhep.Remove(strb_TenLoaiNghiPhep.Length - 1, 1)
        End If
        Me.Close()
    End Sub
End Class
