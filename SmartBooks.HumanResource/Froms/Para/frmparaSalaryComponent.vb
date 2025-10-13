Imports Appsettings
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports Janus.Windows.GridEX
Public Class frmparaSalaryComponent
    Inherits WindowsControlLibrary.HRFORM
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Public bMonthlyChanging As Boolean
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOk = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 273)
        Me.PanelButton.Size = New System.Drawing.Size(952, 10)
        Me.PanelButton.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnOk)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 283)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(952, 39)
        Me.Panel1.TabIndex = 35
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(479, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 26)
        Me.btnCancel.TabIndex = 36
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(393, 3)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 26)
        Me.btnOk.TabIndex = 35
        Me.btnOk.Text = "Ok"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GridControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(952, 283)
        Me.Panel2.TabIndex = 36
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(952, 283)
        Me.GridControl1.TabIndex = 1323
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'frmparaSalaryComponent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(952, 322)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "abc"
        Me.Name = "frmparaSalaryComponent"
        Me.Text = "frmparaSalaryComponent"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If GridView1.SelectedRowsCount > 0 Then
            bLuu = True
        Else
            bLuu = False
        End If
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmparaSalaryComponent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Thành Phần Lương/Salary Component"
        If bMonthlyChanging = True Then
            GridControl1.DataSource = kn.ReadData("select * from HR_SalaryComponentCategory where MonthlyChanging=1 order by OrderBy", "table")
        Else
            GridControl1.DataSource = kn.ReadData("select * from HR_SalaryComponentCategory where MonthlyChanging=0 or MonthlyChanging is null order by OrderBy", "table")
        End If
        Dim ListOfLANCode As String
        For Each col As GridColumn In GridView1.Columns
            If col.FieldName <> String.Empty Then
                ListOfLANCode += col.FieldName + ","
            End If
        Next
        Dim LanFile As String
        LanFile = tvcn.GetAppPath() & "\lang\lang." + DbSetting.Lan + ".js"
        Dim ListOfLAN As String() = tvcn.DichNgonNgu(LanFile, ListOfLANCode.Remove(ListOfLANCode.Length - 1).Split(","))
        Dim i As Integer = 0
        For Each col As GridColumn In GridView1.Columns
            If col.FieldName <> String.Empty Then
                If Not IsNothing(ListOfLAN(i)) Then
                    col.Caption = ListOfLAN(i)
                End If
                i += 1
            End If
        Next
        'Set up Default HRFORM_Gridview
        HRFORM_Gridview.OptionsSelection.MultiSelect = True
        HRFORM_Gridview.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
        HRFORM_Gridview.OptionsSelection.CheckBoxSelectorColumnWidth = 25
        HRFORM_Gridview.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False
        HRFORM_Gridview.OptionsView.ColumnAutoWidth = False
        HRFORM_Gridview.OptionsMenu.ShowAutoFilterRowItem = True
        HRFORM_Gridview.OptionsView.ShowAutoFilterRow = True
    End Sub

    Public Function GetSalaryComponentCode() As String()
        Dim str As String
        For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
            str += GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("SalaryComponent").ToString() + "###"
        Next
        If str <> String.Empty Then
            Return Split(str.Remove(str.Length - 3, 3), "###")
        End If
    End Function

    Public Function GetSalaryComponentNamveVn() As String()
        Dim str As String
        For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
            str += GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("NameVN").ToString() + "###"
        Next
        If str <> String.Empty Then
            Return Split(str.Remove(str.Length - 3, 3), "###")
        End If
    End Function

    Private Sub Gridex1_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Tab Then
            btnOk.Focus()
        ElseIf e.Control AndAlso e.KeyCode = Keys.Enter Then
            btnOk_Click(Nothing, Nothing)
        End If
    End Sub
End Class
