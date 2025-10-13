Imports System
Imports System.Reflection
Imports System.IO
Imports JSON.NET.Framework
Imports VB = Microsoft.VisualBasic
Imports SmartBooks.BusinessLogic
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Text.RegularExpressions
Imports WindowsControlLibrary.PublicFunction
Imports WindowsControlLibrary
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Localization

Public Class frmMain
    Inherits System.Windows.Forms.Form
    Private langDic As DataTable
    Private WithEvents frmLayout As Form1
    Private WithEvents frmLogin As Login
    Dim obj As New Appsettings.DbSetting
    Dim WCobj As New WindowsControlLibrary.DbSetting
    Private flagLogin As Boolean = False ' this flag is used for checking whether Login form have been used or not
    Private flagHomeLogin As Boolean = False ' this flag allowed user to press home menu after logging
    Dim dbdata As New DBData
    Public Quyen As String = String.Empty
    Friend WithEvents XtraTabbedMdiManager1 As DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    Friend WithEvents HelpProvider2 As HelpProvider
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Logout1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Login1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CongCu As DevExpress.XtraBars.BarSubItem
    Friend WithEvents HoTro As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents Home As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Language As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents File As DevExpress.XtraBars.BarSubItem
    Friend WithEvents Login2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Logout2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Exit1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SkinBarSubItem1 As DevExpress.XtraBars.SkinBarSubItem
    Friend WithEvents BarToggleSwitchItem1 As DevExpress.XtraBars.BarToggleSwitchItem
    Friend WithEvents SkinPaletteDropDownButtonItem1 As DevExpress.XtraBars.SkinPaletteDropDownButtonItem
    Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents SetupHolidaysSheet As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SetupShifts As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents setup As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SaoLuuDuLieu As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents KhoaThayDoi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents gioithieu As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents HuongDanSuDung As DevExpress.XtraBars.BarButtonItem
    Dim tvcn As New WindowsControlLibrary.ThuVienChucNang

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        SetupMethods()

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
    Friend WithEvents Limg As System.Windows.Forms.ImageList
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents icons1 As System.Windows.Forms.ImageList
    Friend WithEvents Licons As System.Windows.Forms.ImageList
    Friend WithEvents Simg As System.Windows.Forms.ImageList
    Friend WithEvents img As System.Windows.Forms.ImageList
    Friend WithEvents icons As System.Windows.Forms.ImageList
    Friend WithEvents ImageListSmall As System.Windows.Forms.ImageList
    Friend WithEvents imgLan As System.Windows.Forms.ImageList
    'Friend WithEvents DigitalClockCtrl1 As SriClocks.DigitalClockCtrl
    Friend WithEvents flag As System.Windows.Forms.ImageList
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    'Friend WithEvents UltraTabbedMdiManager1 As Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    'Friend WithEvents UltraToolbarsManager1 As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    'Friend WithEvents _frmMain_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    'Friend WithEvents _frmMain_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    'Friend WithEvents _frmMain_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    'Friend WithEvents _frmMain_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Limg = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.icons1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Licons = New System.Windows.Forms.ImageList(Me.components)
        Me.Simg = New System.Windows.Forms.ImageList(Me.components)
        Me.flag = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.img = New System.Windows.Forms.ImageList(Me.components)
        Me.icons = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageListSmall = New System.Windows.Forms.ImageList(Me.components)
        Me.imgLan = New System.Windows.Forms.ImageList(Me.components)
        Me.XtraTabbedMdiManager1 = New DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(Me.components)
        Me.HelpProvider2 = New System.Windows.Forms.HelpProvider()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.Home = New DevExpress.XtraBars.BarButtonItem()
        Me.Language = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.File = New DevExpress.XtraBars.BarSubItem()
        Me.Login2 = New DevExpress.XtraBars.BarButtonItem()
        Me.Logout2 = New DevExpress.XtraBars.BarButtonItem()
        Me.Exit1 = New DevExpress.XtraBars.BarButtonItem()
        Me.CongCu = New DevExpress.XtraBars.BarSubItem()
        Me.SetupHolidaysSheet = New DevExpress.XtraBars.BarButtonItem()
        Me.SetupShifts = New DevExpress.XtraBars.BarButtonItem()
        Me.setup = New DevExpress.XtraBars.BarButtonItem()
        Me.SaoLuuDuLieu = New DevExpress.XtraBars.BarButtonItem()
        Me.KhoaThayDoi = New DevExpress.XtraBars.BarButtonItem()
        Me.HoTro = New DevExpress.XtraBars.BarSubItem()
        Me.gioithieu = New DevExpress.XtraBars.BarButtonItem()
        Me.HuongDanSuDung = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.SkinBarSubItem1 = New DevExpress.XtraBars.SkinBarSubItem()
        Me.BarToggleSwitchItem1 = New DevExpress.XtraBars.BarToggleSwitchItem()
        Me.SkinPaletteDropDownButtonItem1 = New DevExpress.XtraBars.SkinPaletteDropDownButtonItem()
        Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.Logout1 = New DevExpress.XtraBars.BarButtonItem()
        Me.Login1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEditItem1 = New DevExpress.XtraBars.BarEditItem()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Limg
        '
        Me.Limg.ImageStream = CType(resources.GetObject("Limg.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Limg.TransparentColor = System.Drawing.Color.Fuchsia
        Me.Limg.Images.SetKeyName(0, "")
        Me.Limg.Images.SetKeyName(1, "")
        Me.Limg.Images.SetKeyName(2, "")
        Me.Limg.Images.SetKeyName(3, "")
        Me.Limg.Images.SetKeyName(4, "")
        Me.Limg.Images.SetKeyName(5, "")
        Me.Limg.Images.SetKeyName(6, "")
        Me.Limg.Images.SetKeyName(7, "")
        Me.Limg.Images.SetKeyName(8, "")
        Me.Limg.Images.SetKeyName(9, "")
        Me.Limg.Images.SetKeyName(10, "")
        Me.Limg.Images.SetKeyName(11, "")
        Me.Limg.Images.SetKeyName(12, "")
        Me.Limg.Images.SetKeyName(13, "")
        Me.Limg.Images.SetKeyName(14, "")
        Me.Limg.Images.SetKeyName(15, "")
        Me.Limg.Images.SetKeyName(16, "")
        Me.Limg.Images.SetKeyName(17, "")
        Me.Limg.Images.SetKeyName(18, "")
        Me.Limg.Images.SetKeyName(19, "")
        Me.Limg.Images.SetKeyName(20, "")
        Me.Limg.Images.SetKeyName(21, "")
        Me.Limg.Images.SetKeyName(22, "")
        Me.Limg.Images.SetKeyName(23, "")
        Me.Limg.Images.SetKeyName(24, "")
        Me.Limg.Images.SetKeyName(25, "")
        Me.Limg.Images.SetKeyName(26, "")
        Me.Limg.Images.SetKeyName(27, "")
        Me.Limg.Images.SetKeyName(28, "")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Empty
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "")
        Me.ImageList1.Images.SetKeyName(10, "")
        Me.ImageList1.Images.SetKeyName(11, "")
        Me.ImageList1.Images.SetKeyName(12, "")
        Me.ImageList1.Images.SetKeyName(13, "")
        Me.ImageList1.Images.SetKeyName(14, "")
        Me.ImageList1.Images.SetKeyName(15, "")
        Me.ImageList1.Images.SetKeyName(16, "")
        Me.ImageList1.Images.SetKeyName(17, "")
        '
        'icons1
        '
        Me.icons1.ImageStream = CType(resources.GetObject("icons1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.icons1.TransparentColor = System.Drawing.Color.Fuchsia
        Me.icons1.Images.SetKeyName(0, "")
        Me.icons1.Images.SetKeyName(1, "")
        Me.icons1.Images.SetKeyName(2, "")
        Me.icons1.Images.SetKeyName(3, "")
        Me.icons1.Images.SetKeyName(4, "")
        Me.icons1.Images.SetKeyName(5, "")
        Me.icons1.Images.SetKeyName(6, "")
        Me.icons1.Images.SetKeyName(7, "")
        Me.icons1.Images.SetKeyName(8, "")
        Me.icons1.Images.SetKeyName(9, "")
        Me.icons1.Images.SetKeyName(10, "")
        Me.icons1.Images.SetKeyName(11, "")
        Me.icons1.Images.SetKeyName(12, "")
        Me.icons1.Images.SetKeyName(13, "")
        Me.icons1.Images.SetKeyName(14, "")
        Me.icons1.Images.SetKeyName(15, "")
        Me.icons1.Images.SetKeyName(16, "")
        Me.icons1.Images.SetKeyName(17, "")
        Me.icons1.Images.SetKeyName(18, "")
        Me.icons1.Images.SetKeyName(19, "")
        Me.icons1.Images.SetKeyName(20, "")
        Me.icons1.Images.SetKeyName(21, "")
        Me.icons1.Images.SetKeyName(22, "")
        Me.icons1.Images.SetKeyName(23, "")
        Me.icons1.Images.SetKeyName(24, "")
        Me.icons1.Images.SetKeyName(25, "")
        Me.icons1.Images.SetKeyName(26, "")
        Me.icons1.Images.SetKeyName(27, "")
        Me.icons1.Images.SetKeyName(28, "")
        Me.icons1.Images.SetKeyName(29, "")
        Me.icons1.Images.SetKeyName(30, "")
        Me.icons1.Images.SetKeyName(31, "")
        Me.icons1.Images.SetKeyName(32, "")
        Me.icons1.Images.SetKeyName(33, "")
        Me.icons1.Images.SetKeyName(34, "")
        Me.icons1.Images.SetKeyName(35, "")
        Me.icons1.Images.SetKeyName(36, "")
        Me.icons1.Images.SetKeyName(37, "")
        Me.icons1.Images.SetKeyName(38, "")
        Me.icons1.Images.SetKeyName(39, "")
        Me.icons1.Images.SetKeyName(40, "")
        Me.icons1.Images.SetKeyName(41, "")
        Me.icons1.Images.SetKeyName(42, "")
        Me.icons1.Images.SetKeyName(43, "")
        Me.icons1.Images.SetKeyName(44, "")
        Me.icons1.Images.SetKeyName(45, "")
        Me.icons1.Images.SetKeyName(46, "")
        Me.icons1.Images.SetKeyName(47, "")
        Me.icons1.Images.SetKeyName(48, "")
        Me.icons1.Images.SetKeyName(49, "")
        Me.icons1.Images.SetKeyName(50, "")
        Me.icons1.Images.SetKeyName(51, "")
        Me.icons1.Images.SetKeyName(52, "")
        Me.icons1.Images.SetKeyName(53, "")
        Me.icons1.Images.SetKeyName(54, "")
        '
        'Licons
        '
        Me.Licons.ImageStream = CType(resources.GetObject("Licons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Licons.TransparentColor = System.Drawing.Color.Fuchsia
        Me.Licons.Images.SetKeyName(0, "")
        Me.Licons.Images.SetKeyName(1, "")
        Me.Licons.Images.SetKeyName(2, "")
        '
        'Simg
        '
        Me.Simg.ImageStream = CType(resources.GetObject("Simg.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Simg.TransparentColor = System.Drawing.Color.Fuchsia
        Me.Simg.Images.SetKeyName(0, "")
        Me.Simg.Images.SetKeyName(1, "")
        Me.Simg.Images.SetKeyName(2, "")
        Me.Simg.Images.SetKeyName(3, "")
        Me.Simg.Images.SetKeyName(4, "")
        Me.Simg.Images.SetKeyName(5, "")
        Me.Simg.Images.SetKeyName(6, "")
        Me.Simg.Images.SetKeyName(7, "")
        '
        'flag
        '
        Me.flag.ImageStream = CType(resources.GetObject("flag.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.flag.TransparentColor = System.Drawing.Color.Transparent
        Me.flag.Images.SetKeyName(0, "")
        Me.flag.Images.SetKeyName(1, "")
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList2.Images.SetKeyName(0, "")
        Me.ImageList2.Images.SetKeyName(1, "")
        Me.ImageList2.Images.SetKeyName(2, "")
        Me.ImageList2.Images.SetKeyName(3, "")
        Me.ImageList2.Images.SetKeyName(4, "")
        Me.ImageList2.Images.SetKeyName(5, "")
        Me.ImageList2.Images.SetKeyName(6, "")
        Me.ImageList2.Images.SetKeyName(7, "")
        Me.ImageList2.Images.SetKeyName(8, "")
        Me.ImageList2.Images.SetKeyName(9, "")
        Me.ImageList2.Images.SetKeyName(10, "")
        Me.ImageList2.Images.SetKeyName(11, "")
        Me.ImageList2.Images.SetKeyName(12, "")
        Me.ImageList2.Images.SetKeyName(13, "")
        Me.ImageList2.Images.SetKeyName(14, "")
        Me.ImageList2.Images.SetKeyName(15, "")
        Me.ImageList2.Images.SetKeyName(16, "")
        Me.ImageList2.Images.SetKeyName(17, "")
        Me.ImageList2.Images.SetKeyName(18, "")
        Me.ImageList2.Images.SetKeyName(19, "")
        Me.ImageList2.Images.SetKeyName(20, "")
        Me.ImageList2.Images.SetKeyName(21, "")
        Me.ImageList2.Images.SetKeyName(22, "")
        Me.ImageList2.Images.SetKeyName(23, "")
        Me.ImageList2.Images.SetKeyName(24, "")
        Me.ImageList2.Images.SetKeyName(25, "")
        Me.ImageList2.Images.SetKeyName(26, "")
        Me.ImageList2.Images.SetKeyName(27, "")
        Me.ImageList2.Images.SetKeyName(28, "")
        Me.ImageList2.Images.SetKeyName(29, "")
        Me.ImageList2.Images.SetKeyName(30, "")
        Me.ImageList2.Images.SetKeyName(31, "")
        Me.ImageList2.Images.SetKeyName(32, "")
        Me.ImageList2.Images.SetKeyName(33, "")
        Me.ImageList2.Images.SetKeyName(34, "")
        Me.ImageList2.Images.SetKeyName(35, "")
        Me.ImageList2.Images.SetKeyName(36, "")
        Me.ImageList2.Images.SetKeyName(37, "")
        Me.ImageList2.Images.SetKeyName(38, "")
        Me.ImageList2.Images.SetKeyName(39, "")
        Me.ImageList2.Images.SetKeyName(40, "")
        Me.ImageList2.Images.SetKeyName(41, "")
        Me.ImageList2.Images.SetKeyName(42, "")
        Me.ImageList2.Images.SetKeyName(43, "")
        Me.ImageList2.Images.SetKeyName(44, "")
        Me.ImageList2.Images.SetKeyName(45, "")
        Me.ImageList2.Images.SetKeyName(46, "")
        Me.ImageList2.Images.SetKeyName(47, "")
        Me.ImageList2.Images.SetKeyName(48, "")
        Me.ImageList2.Images.SetKeyName(49, "")
        Me.ImageList2.Images.SetKeyName(50, "")
        Me.ImageList2.Images.SetKeyName(51, "")
        Me.ImageList2.Images.SetKeyName(52, "")
        Me.ImageList2.Images.SetKeyName(53, "")
        Me.ImageList2.Images.SetKeyName(54, "")
        Me.ImageList2.Images.SetKeyName(55, "")
        Me.ImageList2.Images.SetKeyName(56, "")
        Me.ImageList2.Images.SetKeyName(57, "")
        '
        'img
        '
        Me.img.ImageStream = CType(resources.GetObject("img.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img.TransparentColor = System.Drawing.Color.Magenta
        Me.img.Images.SetKeyName(0, "")
        Me.img.Images.SetKeyName(1, "")
        Me.img.Images.SetKeyName(2, "")
        Me.img.Images.SetKeyName(3, "")
        Me.img.Images.SetKeyName(4, "")
        Me.img.Images.SetKeyName(5, "")
        Me.img.Images.SetKeyName(6, "")
        Me.img.Images.SetKeyName(7, "")
        Me.img.Images.SetKeyName(8, "")
        Me.img.Images.SetKeyName(9, "")
        Me.img.Images.SetKeyName(10, "")
        Me.img.Images.SetKeyName(11, "")
        Me.img.Images.SetKeyName(12, "")
        Me.img.Images.SetKeyName(13, "")
        Me.img.Images.SetKeyName(14, "")
        Me.img.Images.SetKeyName(15, "")
        '
        'icons
        '
        Me.icons.ImageStream = CType(resources.GetObject("icons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.icons.TransparentColor = System.Drawing.Color.Fuchsia
        Me.icons.Images.SetKeyName(0, "")
        Me.icons.Images.SetKeyName(1, "")
        Me.icons.Images.SetKeyName(2, "")
        Me.icons.Images.SetKeyName(3, "")
        Me.icons.Images.SetKeyName(4, "")
        Me.icons.Images.SetKeyName(5, "")
        Me.icons.Images.SetKeyName(6, "")
        Me.icons.Images.SetKeyName(7, "")
        Me.icons.Images.SetKeyName(8, "")
        Me.icons.Images.SetKeyName(9, "")
        Me.icons.Images.SetKeyName(10, "")
        Me.icons.Images.SetKeyName(11, "")
        Me.icons.Images.SetKeyName(12, "")
        Me.icons.Images.SetKeyName(13, "")
        Me.icons.Images.SetKeyName(14, "")
        Me.icons.Images.SetKeyName(15, "")
        Me.icons.Images.SetKeyName(16, "")
        Me.icons.Images.SetKeyName(17, "")
        Me.icons.Images.SetKeyName(18, "")
        Me.icons.Images.SetKeyName(19, "")
        Me.icons.Images.SetKeyName(20, "")
        Me.icons.Images.SetKeyName(21, "")
        Me.icons.Images.SetKeyName(22, "")
        Me.icons.Images.SetKeyName(23, "")
        Me.icons.Images.SetKeyName(24, "")
        Me.icons.Images.SetKeyName(25, "")
        Me.icons.Images.SetKeyName(26, "")
        Me.icons.Images.SetKeyName(27, "")
        Me.icons.Images.SetKeyName(28, "")
        Me.icons.Images.SetKeyName(29, "")
        Me.icons.Images.SetKeyName(30, "")
        Me.icons.Images.SetKeyName(31, "")
        Me.icons.Images.SetKeyName(32, "")
        Me.icons.Images.SetKeyName(33, "")
        Me.icons.Images.SetKeyName(34, "")
        Me.icons.Images.SetKeyName(35, "")
        Me.icons.Images.SetKeyName(36, "")
        Me.icons.Images.SetKeyName(37, "")
        Me.icons.Images.SetKeyName(38, "")
        Me.icons.Images.SetKeyName(39, "")
        Me.icons.Images.SetKeyName(40, "")
        Me.icons.Images.SetKeyName(41, "")
        Me.icons.Images.SetKeyName(42, "")
        Me.icons.Images.SetKeyName(43, "")
        Me.icons.Images.SetKeyName(44, "")
        Me.icons.Images.SetKeyName(45, "")
        Me.icons.Images.SetKeyName(46, "")
        Me.icons.Images.SetKeyName(47, "")
        Me.icons.Images.SetKeyName(48, "")
        Me.icons.Images.SetKeyName(49, "")
        Me.icons.Images.SetKeyName(50, "")
        Me.icons.Images.SetKeyName(51, "")
        Me.icons.Images.SetKeyName(52, "")
        Me.icons.Images.SetKeyName(53, "")
        Me.icons.Images.SetKeyName(54, "")
        Me.icons.Images.SetKeyName(55, "")
        Me.icons.Images.SetKeyName(56, "")
        Me.icons.Images.SetKeyName(57, "")
        Me.icons.Images.SetKeyName(58, "")
        Me.icons.Images.SetKeyName(59, "")
        Me.icons.Images.SetKeyName(60, "")
        Me.icons.Images.SetKeyName(61, "")
        Me.icons.Images.SetKeyName(62, "")
        Me.icons.Images.SetKeyName(63, "")
        Me.icons.Images.SetKeyName(64, "")
        Me.icons.Images.SetKeyName(65, "")
        Me.icons.Images.SetKeyName(66, "")
        Me.icons.Images.SetKeyName(67, "")
        Me.icons.Images.SetKeyName(68, "")
        Me.icons.Images.SetKeyName(69, "")
        Me.icons.Images.SetKeyName(70, "")
        Me.icons.Images.SetKeyName(71, "")
        Me.icons.Images.SetKeyName(72, "")
        Me.icons.Images.SetKeyName(73, "")
        Me.icons.Images.SetKeyName(74, "")
        Me.icons.Images.SetKeyName(75, "")
        Me.icons.Images.SetKeyName(76, "")
        Me.icons.Images.SetKeyName(77, "")
        Me.icons.Images.SetKeyName(78, "")
        Me.icons.Images.SetKeyName(79, "")
        Me.icons.Images.SetKeyName(80, "")
        Me.icons.Images.SetKeyName(81, "")
        Me.icons.Images.SetKeyName(82, "")
        Me.icons.Images.SetKeyName(83, "")
        Me.icons.Images.SetKeyName(84, "")
        Me.icons.Images.SetKeyName(85, "")
        Me.icons.Images.SetKeyName(86, "")
        Me.icons.Images.SetKeyName(87, "")
        Me.icons.Images.SetKeyName(88, "")
        '
        'ImageListSmall
        '
        Me.ImageListSmall.ImageStream = CType(resources.GetObject("ImageListSmall.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListSmall.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListSmall.Images.SetKeyName(0, "")
        Me.ImageListSmall.Images.SetKeyName(1, "")
        Me.ImageListSmall.Images.SetKeyName(2, "")
        Me.ImageListSmall.Images.SetKeyName(3, "")
        Me.ImageListSmall.Images.SetKeyName(4, "")
        Me.ImageListSmall.Images.SetKeyName(5, "")
        Me.ImageListSmall.Images.SetKeyName(6, "")
        Me.ImageListSmall.Images.SetKeyName(7, "")
        Me.ImageListSmall.Images.SetKeyName(8, "")
        Me.ImageListSmall.Images.SetKeyName(9, "")
        Me.ImageListSmall.Images.SetKeyName(10, "")
        Me.ImageListSmall.Images.SetKeyName(11, "")
        Me.ImageListSmall.Images.SetKeyName(12, "")
        Me.ImageListSmall.Images.SetKeyName(13, "")
        Me.ImageListSmall.Images.SetKeyName(14, "")
        Me.ImageListSmall.Images.SetKeyName(15, "")
        Me.ImageListSmall.Images.SetKeyName(16, "")
        '
        'imgLan
        '
        Me.imgLan.ImageStream = CType(resources.GetObject("imgLan.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLan.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLan.Images.SetKeyName(0, "")
        Me.imgLan.Images.SetKeyName(1, "")
        Me.imgLan.Images.SetKeyName(2, "")
        Me.imgLan.Images.SetKeyName(3, "")
        Me.imgLan.Images.SetKeyName(4, "")
        Me.imgLan.Images.SetKeyName(5, "")
        Me.imgLan.Images.SetKeyName(6, "")
        Me.imgLan.Images.SetKeyName(7, "")
        Me.imgLan.Images.SetKeyName(8, "")
        Me.imgLan.Images.SetKeyName(9, "")
        Me.imgLan.Images.SetKeyName(10, "")
        Me.imgLan.Images.SetKeyName(11, "")
        Me.imgLan.Images.SetKeyName(12, "")
        Me.imgLan.Images.SetKeyName(13, "")
        Me.imgLan.Images.SetKeyName(14, "")
        Me.imgLan.Images.SetKeyName(15, "")
        Me.imgLan.Images.SetKeyName(16, "")
        Me.imgLan.Images.SetKeyName(17, "")
        Me.imgLan.Images.SetKeyName(18, "")
        Me.imgLan.Images.SetKeyName(19, "")
        Me.imgLan.Images.SetKeyName(20, "")
        Me.imgLan.Images.SetKeyName(21, "")
        Me.imgLan.Images.SetKeyName(22, "")
        Me.imgLan.Images.SetKeyName(23, "")
        Me.imgLan.Images.SetKeyName(24, "")
        Me.imgLan.Images.SetKeyName(25, "")
        '
        'XtraTabbedMdiManager1
        '
        Me.XtraTabbedMdiManager1.MdiParent = Me
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.CongCu, Me.HoTro, Me.Home, Me.Language, Me.File, Me.Login2, Me.Logout2, Me.SkinBarSubItem1, Me.BarToggleSwitchItem1, Me.SkinPaletteDropDownButtonItem1, Me.BarStaticItem1, Me.Exit1, Me.SetupHolidaysSheet, Me.SetupShifts, Me.setup, Me.SaoLuuDuLieu, Me.KhoaThayDoi, Me.gioithieu, Me.HuongDanSuDung})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 30
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 1
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.Home, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.Language, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.Text = "Tools"
        '
        'Home
        '
        Me.Home.Caption = "Home"
        Me.Home.Id = 12
        Me.Home.ImageOptions.Image = Global.SmartBooks.HumanResource.My.Resources.Resources.home_16x161
        Me.Home.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.home_32x321
        Me.Home.Name = "Home"
        '
        'Language
        '
        Me.Language.Caption = "Language"
        Me.Language.Id = 13
        Me.Language.Name = "Language"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.File), New DevExpress.XtraBars.LinkPersistInfo(Me.CongCu), New DevExpress.XtraBars.LinkPersistInfo(Me.HoTro)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'File
        '
        Me.File.Caption = "File"
        Me.File.Id = 15
        Me.File.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.Login2), New DevExpress.XtraBars.LinkPersistInfo(Me.Logout2), New DevExpress.XtraBars.LinkPersistInfo(Me.Exit1)})
        Me.File.Name = "File"
        '
        'Login2
        '
        Me.Login2.Caption = "DangNhap"
        Me.Login2.Id = 16
        Me.Login2.ImageOptions.Image = Global.SmartBooks.HumanResource.My.Resources.Resources.bouser_16x161
        Me.Login2.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.bouser_32x321
        Me.Login2.Name = "Login2"
        '
        'Logout2
        '
        Me.Logout2.Caption = "DangXuat"
        Me.Logout2.Id = 17
        Me.Logout2.ImageOptions.Image = Global.SmartBooks.HumanResource.My.Resources.Resources.assignto_16x16
        Me.Logout2.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.assignto_32x32
        Me.Logout2.Name = "Logout2"
        '
        'Exit1
        '
        Me.Exit1.Caption = "Thoat"
        Me.Exit1.Id = 22
        Me.Exit1.ImageOptions.Image = Global.SmartBooks.HumanResource.My.Resources.Resources.cancel_16x161
        Me.Exit1.Name = "Exit1"
        '
        'CongCu
        '
        Me.CongCu.Caption = "CongCu"
        Me.CongCu.Id = 8
        Me.CongCu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SetupHolidaysSheet), New DevExpress.XtraBars.LinkPersistInfo(Me.SetupShifts), New DevExpress.XtraBars.LinkPersistInfo(Me.setup), New DevExpress.XtraBars.LinkPersistInfo(Me.SaoLuuDuLieu), New DevExpress.XtraBars.LinkPersistInfo(Me.KhoaThayDoi)})
        Me.CongCu.Name = "CongCu"
        '
        'SetupHolidaysSheet
        '
        Me.SetupHolidaysSheet.Caption = "TaoDieuChinhNghiPhepToanCongTy"
        Me.SetupHolidaysSheet.Id = 23
        Me.SetupHolidaysSheet.ImageOptions.Image = Global.SmartBooks.HumanResource.My.Resources.Resources.switchtimescalesto_16x16
        Me.SetupHolidaysSheet.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.switchtimescalesto_32x32
        Me.SetupHolidaysSheet.Name = "SetupHolidaysSheet"
        '
        'SetupShifts
        '
        Me.SetupShifts.Caption = "TaoDieuChinhCaLamViec"
        Me.SetupShifts.Id = 24
        Me.SetupShifts.ImageOptions.Image = Global.SmartBooks.HumanResource.My.Resources.Resources.linenumbering_16x16
        Me.SetupShifts.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.linenumbering_32x32
        Me.SetupShifts.Name = "SetupShifts"
        '
        'setup
        '
        Me.setup.Caption = "CaiDatTongQuat"
        Me.setup.Id = 25
        Me.setup.ImageOptions.Image = Global.SmartBooks.HumanResource.My.Resources.Resources.properties_16x16
        Me.setup.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.properties_32x32
        Me.setup.Name = "setup"
        '
        'SaoLuuDuLieu
        '
        Me.SaoLuuDuLieu.Caption = "SaoLuuDuLieu"
        Me.SaoLuuDuLieu.Id = 26
        Me.SaoLuuDuLieu.ImageOptions.Image = Global.SmartBooks.HumanResource.My.Resources.Resources.saveto_16x16
        Me.SaoLuuDuLieu.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.saveto_32x32
        Me.SaoLuuDuLieu.Name = "SaoLuuDuLieu"
        '
        'KhoaThayDoi
        '
        Me.KhoaThayDoi.Caption = "KhoaDuLieu"
        Me.KhoaThayDoi.Id = 27
        Me.KhoaThayDoi.ImageOptions.Image = Global.SmartBooks.HumanResource.My.Resources.Resources.deletedatasource_16x16
        Me.KhoaThayDoi.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.deletedatasource_32x32
        Me.KhoaThayDoi.Name = "KhoaThayDoi"
        '
        'HoTro
        '
        Me.HoTro.Caption = "HoTro"
        Me.HoTro.Id = 9
        Me.HoTro.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.gioithieu), New DevExpress.XtraBars.LinkPersistInfo(Me.HuongDanSuDung)})
        Me.HoTro.Name = "HoTro"
        '
        'gioithieu
        '
        Me.gioithieu.Caption = "GioiThieuHR"
        Me.gioithieu.Id = 28
        Me.gioithieu.ImageOptions.Image = Global.SmartBooks.HumanResource.My.Resources.Resources.info_16x16
        Me.gioithieu.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.info_32x32
        Me.gioithieu.Name = "gioithieu"
        '
        'HuongDanSuDung
        '
        Me.HuongDanSuDung.Caption = "HuongDanSuDung"
        Me.HuongDanSuDung.Id = 29
        Me.HuongDanSuDung.ImageOptions.Image = Global.SmartBooks.HumanResource.My.Resources.Resources.index_16x16
        Me.HuongDanSuDung.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.index_32x32
        Me.HuongDanSuDung.Name = "HuongDanSuDung"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(1191, 50)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 476)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1191, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 50)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 426)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1191, 50)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 426)
        '
        'SkinBarSubItem1
        '
        Me.SkinBarSubItem1.Caption = "SkinBarSubItem1"
        Me.SkinBarSubItem1.Id = 18
        Me.SkinBarSubItem1.Name = "SkinBarSubItem1"
        '
        'BarToggleSwitchItem1
        '
        Me.BarToggleSwitchItem1.Caption = "BarToggleSwitchItem1"
        Me.BarToggleSwitchItem1.Id = 19
        Me.BarToggleSwitchItem1.Name = "BarToggleSwitchItem1"
        '
        'SkinPaletteDropDownButtonItem1
        '
        Me.SkinPaletteDropDownButtonItem1.Id = 20
        Me.SkinPaletteDropDownButtonItem1.Name = "SkinPaletteDropDownButtonItem1"
        '
        'BarStaticItem1
        '
        Me.BarStaticItem1.Caption = "----------------"
        Me.BarStaticItem1.Id = 21
        Me.BarStaticItem1.Name = "BarStaticItem1"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'Logout1
        '
        Me.Logout1.Caption = "Logout1"
        Me.Logout1.Id = 5
        Me.Logout1.Name = "Logout1"
        '
        'Login1
        '
        Me.Login1.Caption = "Login1"
        Me.Login1.Id = 6
        Me.Login1.Name = "Login1"
        '
        'BarEditItem1
        '
        Me.BarEditItem1.Caption = "BarEditItem1"
        Me.BarEditItem1.Edit = Me.RepositoryItemTextEdit1
        Me.BarEditItem1.Id = 10
        Me.BarEditItem1.Name = "BarEditItem1"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1191, 476)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Human Resource"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Function GetAppPath() As String
        Dim f As New IO.DirectoryInfo(Application.ExecutablePath)
        Return f.Parent.FullName
    End Function

    'Private Sub UltraTabbedMdiManager1_TabSelected(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabbedMdi.MdiTabEventArgs) Handles UltraTabbedMdiManager1.TabSelected
    '    If e.Tab.Form.Text = "Main Menu" Then
    '        Me.UltraTabbedMdiManager1.TabSettings.AllowClose = Infragistics.Win.DefaultableBoolean.False
    '    Else
    '        Me.UltraTabbedMdiManager1.TabSettings.AllowClose = Infragistics.Win.DefaultableBoolean.True
    '    End If
    'End Sub

    Private Sub ShowAllForm()
        For Each k As String In listKey
            RunMethod(k)
        Next
    End Sub

    Private Sub ExportLanguage()
        Dim _langCode = New String() {"vi-VN", "en", "ko-KR"}
        Dim _lang As ArrayList = New ArrayList(New String() {"VN", "EN", "KR"})

        Dim ResultDic As New DataTable
        ResultDic.Columns.Add(New DataColumn("key"))
        ResultDic.Columns.Add(New DataColumn("val"))
        ' Dim ResultDic As StringDictionary = New StringDictionary
        Dim isExists As Boolean
        Dim _iKey As Integer
        If (Me.MdiChildren.Length > 0) Then
            For Each _f As Form In Me.MdiChildren
                isExists = False

                For _iKey = 0 To listKey.Count - 1
                    If (CType(listForm(_iKey), Type).Name = _f.Name) Then
                        isExists = True
                        Exit For
                    End If
                Next
                If (isExists) Then
                    getTextFromControl(ResultDic, _f, listModule(_iKey))
                    exportLangText(ResultDic, _f.Controls, String.Format("{0}.{1}", listModule(_iKey), _f.Name))

                    If (_f.Name = "Form1") Then
                        ExportForm1Language(ResultDic, CType(_f, Form1))
                    End If
                Else
                    getTextFromControl(ResultDic, _f, "")
                    exportLangText(ResultDic, _f.Controls, _f.Name)
                End If
            Next
        End If
        ' End
        CreateTXDFile(_langCode, _lang, ResultDic)
        CreateTXDFile(_langCode, _lang, checkDuplicateKey(ResultDic))

    End Sub

    Private Sub OptimalLanguage()
        Dim _langCode = New String() {"vi-VN", "en", "ko-KR"}
        Dim _lang As ArrayList = New ArrayList(New String() {"VN", "EN", "KR"})
        Dim GeneralDataTable = checkDuplicateKey(langDic)
        CreateTXDFile(_langCode, _lang, GeneralDataTable, "Optimal")

        Dim lastKey As String = ""
        Dim regexLastKey As Regex = New Regex("[^\.]+$")
        ' TinhChinhLaiFileNgonNgu
        For Each row As DataRow In GeneralDataTable.Select("")
            lastKey = regexLastKey.Match(row(0)).Value
            For Each _row As DataRow In langDic.Select(String.Format("[key] LIKE '%.{0}' AND [val] = '{1}'", lastKey, row(1)))
                _row.Delete()
            Next
            langDic.Rows.Add(New Object() {row(0), row(1)})
        Next
        CreateTXDFile(_langCode, _lang, langDic, "All")

    End Sub

    Sub CreateTXDFile(ByVal _langCode As String(), ByVal _lang As ArrayList, ByVal ResultDic As DataTable, Optional ByVal PreStr As String = "")
        ' Create an instance of StreamWriter to write text to a file.
        Dim filePath As String = String.Format("D:/lang/lang-{0}-{1}-{2}.txd", obj.Lan, Date.UtcNow.Ticks, PreStr)
        ' Add some text to the file.
        Dim noiDung As String = String.Format("<?xml version=""1.0"" encoding=""utf-8""?><translation xml:space=""preserve""><culture name=""{0}"">", _langCode(_lang.IndexOf(obj.Lan)))
        For Each _row As DataRow In ResultDic.Rows
            noiDung &= String.Format("<text key=""{0}"">{1}</text>", _row(0), _row(1).ToString.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;"))
        Next
        ' Arbitrary objects can also be written to the file.
        noiDung &= "</culture></translation>"
        WrireFileLanguage(filePath, noiDung)
    End Sub

    Private Function checkDuplicateKey(ByRef langDic As DataTable) As DataTable
        Dim dCount As Integer = 3
        Dim tmpTable As New DataTable
        tmpTable.Columns.Add("key")
        tmpTable.Columns.Add("val")
        tmpTable.Columns.Add("dCount", GetType(Integer))

        Dim lastKey As String = ""
        Dim lSQL As String = ""
        Dim regexLastKey As Regex = New Regex("[^\.]+$")
        '
        For Each row As DataRow In langDic.Rows
            ' KiemTraCoDuplicateHayKo
            lastKey = regexLastKey.Match(row(0)).Value
            lSQL = String.Format("[key] LIKE '%.{0}' AND [val] = '{1}'", lastKey, row(1).ToString().Replace("'", "''"))
            Console.WriteLine(lastKey)
            Console.WriteLine(lSQL)
            tmpTable.Rows.Add(New Object() {row(0), row(1), langDic.Select(lSQL).Length})
        Next

        ' LayRaNhungCaiKeyMaBiDuplicate > dCount

        Dim resultTable As New DataTable
        resultTable.Columns.Add("key")
        resultTable.Columns.Add("val")

        For Each row As DataRow In tmpTable.Select(String.Format("dCount >= {0}", dCount))
            lastKey = regexLastKey.Match(row(0)).Value
            lastKey = String.Format("General.{0}", lastKey)
            If (resultTable.Select(String.Format("[key] = '{0}'", lastKey)).Length = 0) Then
                resultTable.Rows.Add(New Object() {lastKey, row(1)})
            End If
            row.Delete()
        Next
        Return resultTable
    End Function

    Private Sub ExportForm1Language(ByRef ResultDic As DataTable, ByVal _f As Form1)
        For Each _GroupItem As DevExpress.XtraNavBar.NavBarGroup In _f.getMenuNavBarControl.Groups
            _GroupItem.Caption = getLangDicText(ResultDic, "TopMenu.Form1." & _GroupItem.Name)
        Next

        For Each _Item As DevExpress.XtraNavBar.NavBarItem In _f.getMenuNavBarControl.Items
            If (Not IsNothing(_Item.Name) And Not IsNothing(_Item.Caption)) Then
                If (_Item.Name <> "" And _Item.Caption <> "") Then
                    ResultDic.Rows.Add(New Object() {"TopMenu.Form1." & _Item.Name, _Item.Caption})
                End If
            End If
        Next

        'For Each _GroupItem As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup In _f.getMenuPanel.Groups
        '    ResultDic.Rows.Add(New Object() {"TopMenu.Form1." & _GroupItem.Key, _GroupItem.Text})
        '    For Each _Item As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem In _GroupItem.Items
        '        If (Not IsNothing(_Item.Key) And Not IsNothing(_Item.Text)) Then
        '            If (_Item.Key <> "" And _Item.Text <> "") Then
        '                ResultDic.Rows.Add(New Object() {"TopMenu.Form1." & _Item.Key, _Item.Text})
        '            End If
        '        End If
        '    Next
        'Next
    End Sub

    Private Sub ChangeLanguageToForm1(ByRef ResultDic As DataTable, ByVal _f As Form1)
        For Each _GroupItem As DevExpress.XtraNavBar.NavBarGroup In _f.getMenuNavBarControl.Groups
            _GroupItem.Caption = getLangDicText(ResultDic, "TopMenu.Form1." & _GroupItem.Name)
        Next

        For Each _Item As DevExpress.XtraNavBar.NavBarItem In _f.getMenuNavBarControl.Items
            If (Not IsNothing(_Item.Name) And Not IsNothing(_Item.Caption)) Then
                If (_Item.Name <> "" And _Item.Caption <> "") Then
                    _Item.Caption = getLangDicText(ResultDic, "TopMenu.Form1." & _Item.Name)
                End If
            End If
        Next

        'For Each _GroupItem As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup In _f.getMenuPanel.Groups
        '    _GroupItem.Text = getLangDicText(ResultDic, "TopMenu.Form1." & _GroupItem.Key)
        '    For Each _Item As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem In _GroupItem.Items
        '        If (Not IsNothing(_Item.Key) And Not IsNothing(_Item.Text)) Then
        '            If (_Item.Key <> "" And _Item.Text <> "") Then
        '                _Item.Text = getLangDicText(ResultDic, "TopMenu.Form1." & _Item.Key)
        '            End If
        '        End If
        '    Next
        'Next
    End Sub

    Private Sub WrireFileLanguage(ByVal filePath As String, ByVal text As String)
        ' Create an instance of StreamWriter to write text to a file.
        Dim sw As StreamWriter = New StreamWriter(filePath)
        ' Add some text to the file.
        sw.Write(text)
        sw.Close()
    End Sub

    Private Sub ExportMainMenu()
        Dim filePath As String = String.Format("D:/lang/lang-{0}-{1}.txd", obj.Lan, Date.UtcNow.Ticks)
        Dim _langCode = New String() {"vi-VN", "en", "ko-KR"}
        Dim _lang As ArrayList = New ArrayList(New String() {"VN", "EN", "KR"})
        Dim noiDung As String = String.Format("<?xml version=""1.0"" encoding=""utf-8""?><translation xml:space=""preserve""><culture name=""{0}"">", _langCode(_lang.IndexOf(obj.Lan)))
        'UltraToolbarsManager1
        'For Each _toolBar As DevExpress.XtraBars.BarItem In BarManager1.Items
        '    For Each _toolBarTool As Infragistics.Win.UltraWinToolbars.ToolBase In _toolBar.
        '        noiDung &= String.Format("<text key=""TopMenu.Form1.{0}"">{1}</text>", _toolBarTool.Key, _toolBarTool.SharedProps.Caption.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;"))
        '    Next
        'Next
        For Each _toolBar As DevExpress.XtraBars.BarItem In BarManager1.Items
            'noiDung &= String.Format("<text key=""TopMenu.Form1.{0}"">{1}</text>", _toolBar.Name, _toolBar.SharedProps.Caption.Replace("&", "&amp;"))
            noiDung &= String.Format("<text key=""TopMenu.Form1.{0}""></text>", _toolBar.Name)
        Next
        noiDung &= "</culture></translation>"
        WrireFileLanguage(filePath, noiDung)
    End Sub

    Public Sub ChangeLanguage(ByVal lang As String)
        'LuuXuong Login.xml

        obj.Lan = lang
        Dim dsServer As New DataSet
        dsServer.ReadXml(GetAppPath() & "\login.xml")
        dsServer.Tables(0).Rows(0).Item("lang") = obj.Lan
        dsServer.WriteXml(GetAppPath() & "\login.xml")

        ' DataJson
        langDic = tvcn.loadLanguage(obj.Lan)
        Select Case obj.Lan
            Case "VN"
                Language.ImageOptions.Image = Me.ImageList2.Images(55)
            Case "EN"
                Language.ImageOptions.Image = Me.ImageList2.Images(57)
            Case "KR"
                Language.ImageOptions.Image = Me.ImageList2.Images(56)
        End Select
        'Barmanager

        For i = 0 To BarManager1.Items.Count - 1
            BarManager1.Items(i).Caption = getLangDicText(langDic, "TopMenu.Form1." & BarManager1.Items(i).Name)
        Next
        'For Each _toolBar As Infragistics.Win.UltraWinToolbars.UltraToolbar In UltraToolbarsManager1.Toolbars
        '    For Each _toolBarTool As Infragistics.Win.UltraWinToolbars.ToolBase In _toolBar.Tools
        '        _toolBarTool.SharedProps.Caption = getLangDicText(langDic, "TopMenu.Form1." & _toolBarTool.Key)
        '    Next
        'Next

        'For Each _toolBarTool As Infragistics.Win.UltraWinToolbars.ToolBase In UltraToolbarsManager1.Tools
        '    _toolBarTool.SharedProps.Caption = getLangDicText(langDic, "TopMenu.Form1." & _toolBarTool.Key)
        'Next


        ' FetchAllForms ChangeLanguage

        If (Me.MdiChildren.Length > 0) Then
            For Each _f As Form In Me.MdiChildren
                ChangeLanguageToForm(_f)
            Next
        End If
    End Sub

    Public Function ChangeLanguageToForm(ByVal _f As Form) As String
        Dim isExists As Boolean
        Dim _iKey As Integer
        isExists = False

        For _iKey = 0 To listKey.Count - 1
            If (CType(listForm(_iKey), Type).Name = _f.Name) Then
                isExists = True
                Exit For
            End If
        Next
        If (isExists) Then
            setTextToControl(langDic, _f, listModule(_iKey))
            WindowsControlLibrary.PublicFunction.changeLangForm(langDic, _f.Controls, String.Format("{0}.{1}", listModule(_iKey), _f.Name), 0)
            'changeLangForm(langDic, _f.Controls, String.Format("{0}.{1}", listModule(_iKey), _f.Name))
            If (_f.Name = "Form1") Then
                ChangeLanguageToForm1(langDic, CType(_f, Form1))
            End If
            Return listModule(_iKey)
        Else
            setTextToControl(langDic, _f, "")
            WindowsControlLibrary.PublicFunction.changeLangForm(langDic, _f.Controls, _f.Name, 0)
            'changeLangForm(langDic, _f.Controls, _f.Name)
            Return String.Empty
        End If
    End Function

    Private Sub frmLogin_doIt() Handles frmLogin.doIt
        Try
            ChangeLanguage(obj.Lan)
            RunMethod("Home")
            flagLogin = True

            'Dim Factory As String = ""
            'Select Case obj.Terminal
            '    Case "Terminal"
            '        Factory = "Main Office"
            '    Case "Terminal1"
            '        Factory = "Factory 1"
            '    Case "Terminal2"
            '        Factory = "Factory 2"
            '    Case "Terminal3"
            '        Factory = "Factory 3"
            'End Select

            'Dim dataman As New BusinessLogic.DbAccess
            'Dim ds As New BusinessLogic.SmartData
            'dataman.Company_Fill(ds)
            Try
                Me.Text = "Human Resource Management"
            Catch ex As Exception

            End Try
            'ds.Clear()
            'UltraToolbarsManager1.Toolbars(1).Visible = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub Logout()
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next
        WindowsControlLibrary.DbSetting.PARA_FACTORY_ID = String.Empty
        WindowsControlLibrary.DbSetting.PARA_DEPARTMENTCODE = String.Empty
        WindowsControlLibrary.DbSetting.PARA_SECTIONCODE = String.Empty
        WindowsControlLibrary.DbSetting.PARA_TEAMCODE = String.Empty
        WindowsControlLibrary.DbSetting.PARA_POSITIONCATEGORY_ID = String.Empty
        WindowsControlLibrary.DbSetting.PARA_POSITION_ID = String.Empty
        flagLogin = False
        'UltraToolbarsManager1.Toolbars(1).Visible = False
    End Sub

    Sub Login()
        'Dim frm As Form
        'For Each frm In Me.OwnedForms
        '    If frm.Name = "Login" Then
        '        frm.Activate()
        '        Exit Sub
        '    End If
        'Next
        frmLogin = New Login
        frmLogin.Owner = Me
        frmLogin.ShowDialog()
    End Sub

    Private Sub frmMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        flagHomeLogin = False
        'UltraToolbarsManager1.Toolbars(1).Visible = False
        If flagLogin = False Then
            Login()
        End If

        Localizer.Active = New VietnameseEditorsLocalizer()
        GridLocalizer.Active = New VietnameseGridLocalizer()
    End Sub

    Public listKey As ArrayList
    Public listPermission As ArrayList
    Public listForm As ArrayList
    Public listCheckPermission As ArrayList
    Public listModule As ArrayList

    Public Sub addMethod(ByVal MyModule As String, ByVal key As String, ByVal MyType As Type, Optional ByVal cKey As String = "", Optional ByVal checkPermission As Boolean = True)
        listKey.Add(key)
        listForm.Add(MyType)
        If (cKey <> "") Then
            listPermission.Add(cKey)
        Else
            listPermission.Add(key)
        End If
        listCheckPermission.Add(checkPermission)
        listModule.Add(MyModule)
    End Sub

    Public Sub SetupMethods()
        listModule = New ArrayList
        listKey = New ArrayList
        listForm = New ArrayList
        listPermission = New ArrayList
        listCheckPermission = New ArrayList

        addMethod("TopMenu", "setup", GetType(frmSetUp), "setup")
        addMethod("TopMenu", "KhoaThayDoi", GetType(BlockFunction))
        addMethod("TopMenu", "SaoLuuDuLieu", GetType(DatabaseBackup))
        addMethod("TopMenu", "PhucHoiDuLieu", GetType(DatabaseRestore))
        addMethod("TopMenu", "Home", GetType(Form1), "", False)

        addMethod("Setup", "CompanyInformation", GetType(frmCompanyInformation))
        addMethod("Setup", "SetupShifts", GetType(frmShiftsSetting2))
        addMethod("Setup", "CreateEditDepartment", GetType(frmDepartment))
        addMethod("Setup", "CreateEditSection", GetType(frmSection))
        addMethod("Setup", "CreateEditTeam", GetType(frmTeam))
        addMethod("Setup", "Factory", GetType(frmFactory))
        addMethod("Setup", "CreateEditPosition", GetType(frmPosition))
        addMethod("Setup", "CreateEditContract", GetType(frmContract))
        addMethod("Setup", "CreateEditContractFlow", GetType(frmContractFlow))
        addMethod("Setup", "ListofUsers", GetType(frmUsers))
        'addMethod("Setup", "Setup Permission", GetType(frmSetupPermission))
        'addMethod("Setup", "ReportPermission", GetType(frmReportPermission))
        addMethod("Setup", "CreateEditPositionCategory", GetType(frmPositionCategory))
        addMethod("Setup", "TaoDieuChinhChucDanh", GetType(frmTaoDieuChinhChucDanh))
        addMethod("Setup", "TaoDieuChinhLoaiNghi", GetType(frmTaoDieuChinhLoaiNghi))
        'addMethod("Setup", "TaoDieuChinhBoPhan", GetType(frmFactory))
        addMethod("Setup", "TaoDieuChinhVungMien", GetType(frmVungMien))
        addMethod("Setup", "TaoDieuChinhDanhMuc", GetType(HR_Category))
        addMethod("Setup", "SetUpFollowDate", GetType(frmSetUpFollowDate))
        addMethod("Setup", "MayChamCong", GetType(frmMayChamCong))
        addMethod("Setup", "TaoDieuChinhLoaiCong", GetType(frmLoaiCong))
        addMethod("Setup", "TaoDieuChinhDanhMucLuong", GetType(frmTaoDieuChinhDanhMucLuong))
        addMethod("Setup", "HR_Hospital", GetType(frmHR_Hospital))
        addMethod("Setup", "Salary_Name", GetType(frmSalary_Name))
        addMethod("Setup", "Register", GetType(frmRegisterUser))
        addMethod("Setup", "RunQuerySQL", GetType(frmRunQuerySQL))
        addMethod("Setup", "JobCodeCategory", GetType(frmJobCodeCategory))
        addMethod("Setup", "HazardCategory", GetType(frmHazardCategory))
        addMethod("Setup", "SetupHolidaysSheet", GetType(Holidays_Plan))

        addMethod("EmployeeInformation", "CreateEditEmployee", GetType(frmEmployeeInfo))
        addMethod("EmployeeInformation", "EmployeeFamilyInformation", GetType(frmFamily))
        addMethod("EmployeeInformation", "TransferDepartment", GetType(frmChuyenViTri))
        'addMethod("EmployeeInformation", "ChuyenChucVu", GetType(frmChuyenChucVu))
        addMethod("EmployeeInformation", "QuanLyTheTuNhanVien", GetType(frmQuanLyTheTu))
        addMethod("EmployeeInformation", "Disable", GetType(frmDisable))
        addMethod("EmployeeInformation", "TerminationAsignment", GetType(frmTerminationAsignment))
        addMethod("EmployeeInformation", "Discipline", GetType(frmDiscipline))
        addMethod("EmployeeInformation", "Award", GetType(frmAward))
        addMethod("EmployeeInformation", "HeavyAndToxic", GetType(frmHeavyAndToxic))
        addMethod("EmployeeInformation", "CapPhatAo", GetType(frmCapPhatAo))
        addMethod("EmployeeInformation", "QuaTrinhHocTapCongTac", GetType(frmQuaTrinhHocTapCongTac))
        addMethod("EmployeeInformation", "TrainingRecord", GetType(frmTrainingRecord))
        addMethod("EmployeeInformation", "HealthCheck", GetType(frmHealthCheck))
        addMethod("EmployeeInformation", "License", GetType(frmLicense))
        addMethod("EmployeeInformation", "DiseasesRecord", GetType(frmDiseasesRecord))
        addMethod("EmployeeInformation", "SurgeryHistory", GetType(frmSurgeryHistory))

        addMethod("TimeKeeping", "EmpRegisTimeShift", GetType(frmEmpRegisTimeSheet))
        addMethod("TimeKeeping", "DanhSachDangKyDiLam", GetType(frmDanhSachDangKyDiLam))
        addMethod("TimeKeeping", "MaxOvertime", GetType(frmRegisMaxOvertime))
        addMethod("TimeKeeping", "TimeKeepingDaily", GetType(para_TimeKeeping_Date))
        addMethod("TimeKeeping", "CongBatThuong", GetType(frmCongBatThuong))
        addMethod("TimeKeeping", "EmpRegisPregnant", GetType(frmEmpRegisPregnant))
        addMethod("TimeKeeping", "DangKyNghiSinh", GetType(frmDangKyNghiSinh))
        addMethod("TimeKeeping", "TimeKeepingData", GetType(para_TimeKeeping_Data2))
        addMethod("TimeKeeping", "HR_MaxOvertimeInPeriod", GetType(frmHR_MaxOvertimeInPeriod))
        addMethod("TimeKeeping", "GoOut", GetType(frmGoOut))
        addMethod("TimeKeeping", "RoundShift", GetType(frmRoundShift))
        addMethod("TimeKeeping", "DayVacationRemain", GetType(frmDayVacationRemain))
        addMethod("TimeKeeping", "DangKyPhepTheoGio", GetType(frmDangKyPhepTheoGio))
        addMethod("TimeKeeping", "TienCom", GetType(frmTienCom))
        addMethod("TimeKeeping", "BaoCaoCong", GetType(frmBaoCaoCong))
        addMethod("TimeKeeping", "BankAccountOfEmployee", GetType(frmBankAccountOfEmployee))

        addMethod("Payroll", "DanhSachNguoiPhuThuoc", GetType(frmDanhSachNguoiPhuThuoc))
        addMethod("Payroll", "MucLuong", GetType(frmMucLuong))
        addMethod("Payroll", "MucLuongNhanVien", GetType(frmMucLuongNhanVien))
        addMethod("Payroll", "CaiDatPhuCap", GetType(frmCaiDatPhuCap))
        addMethod("Payroll", "BacTayNgheNhanVien", GetType(frmBacTayNgheNhanVien))
        addMethod("Payroll", "SalaryComponents", GetType(frmSalaryComponent))
        addMethod("Payroll", "luongcodinh", GetType(frmLuongCoDinh))
        addMethod("Payroll", "CreateEditEmployeeContract", GetType(frmContractList))
        'addMethod("Payroll", "ThanhToanBaoHiem", GetType(para_BHXH))
        'addMethod("Payroll", "KeKhaiThueTNCN", GetType(frmBangKeThueTNCN))
        addMethod("Payroll", "QuyetToanThueTNCN", GetType(frmQuyetToanThueTNCN))
        addMethod("Payroll", "chucdanh", GetType(frmTaoDieuChinhChucDanh))
        addMethod("Payroll", "tinhluong", GetType(para_Salary))
        'addMethod("Payroll", "Payslip", GetType(para_PhieuLuong))
        addMethod("Payroll", "BaoCaoLuong", GetType(frmBaoCaoLuong))
        addMethod("Payroll", "EmpRegisParameter", GetType(frmEmpRegisParameter))
        addMethod("Payroll", "BacTayNghe", GetType(frmBacTayNghe))

        'BangDuTruTinhNgoai 
        addMethod("BaoHiem", "BaoCaoBaoHiem", GetType(frmBaoCaoBaoHiem))
        addMethod("BaoHiem", "QuanLySoBHXH", GetType(frmInsurance))
        addMethod("BaoHiem", "TheBHYT", GetType(frmTheBHYT))
        addMethod("BaoHiem", "RegistSIHI", GetType(frmEmpNonRegisInsurance))

        'addMethod("Report", "Report", GetType(frmReport))
        'addMethod("Report", "CreateReportTemplate", GetType(frmCreateReportTemplate))
    End Sub

    Private Function CreateType(ByVal key As String, ByVal _type1 As System.Type, ByVal isCheckPermission As Boolean) As Object
        Dim Quyen, TabList As String
        Dim dtKiemTraQuyen As DataTable
        If isCheckPermission Then
            Dim KiemTraQuyen As New UserPermission
            dtKiemTraQuyen = KiemTraQuyen.Userpermission(Appsettings.DbSetting.UserName, key)
            If IsNothing(dtKiemTraQuyen) Then
                Console.WriteLine(String.Format("KoCoQuyen-{0}-{1}", key, _type1.Name))
                Return Nothing
            End If
            If dtKiemTraQuyen.Rows.Count = 0 Then
                Console.WriteLine(String.Format("KoCoQuyen-{0}-{1}", key, _type1.Name))
                Return Nothing
            End If
            If Not IsDBNull(dtKiemTraQuyen.Rows(0)(2)) Then
                Quyen = dtKiemTraQuyen.Rows(0)(2)
            End If
            If Not IsDBNull(dtKiemTraQuyen.Rows(0)("TabList")) Then
                TabList = dtKiemTraQuyen.Rows(0)("TabList")
            End If
        End If
        Dim num1 As Integer
        Dim flag1 As Boolean = False
        If (Me.MdiChildren.Length > 0) Then
            Dim num2 As Integer = (Me.MdiChildren.Length - 1)
            num1 = 0
            Do While (num1 <= num2)
                If _type1.Equals(Me.MdiChildren(num1).GetType) Then
                    flag1 = True
                    Exit Do
                End If
                num1 += 1
            Loop
        End If

        If Not flag1 Then
            Dim KOF As String
            Try
                Dim ctor As ConstructorInfo = _type1.GetConstructor(New System.Type() {})
                Dim frm = ctor.Invoke(New Object() {})
                frm.MdiParent = Me

                KOF = ChangeLanguageToForm(frm)
                Try
                    frm.QuyenHRFORM = Quyen
                    frm.TabList = TabList
                    frm.KeyOfForm1 = KOF
                Catch ex As Exception

                End Try
                frm.Show()
                Return frm
            Catch ex As Exception
                Console.WriteLine(String.Format("Error-{0}-{1}", key, _type1.Name))
            End Try
        Else
            Me.MdiChildren(num1).Activate()
            Return Me.MdiChildren(num1)
        End If
    End Function

    Public Function RunMethod(ByVal key As String) As Object
        Dim _iKey As Integer = listPermission.IndexOf(key)
        If (_iKey >= 0) Then
            Dim _f = CreateType(listPermission(_iKey), listForm(_iKey), listCheckPermission(_iKey))
            If (key = "Home") Then
                frmLayout = _f
            End If
            'Else 'KoTonTai
            '    MsgBox("KhongThayChucNangNay")
        End If
    End Function


    'Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UltraToolbarsManager1.ToolClick
    '    If (IsNothing(RunMethod(e.Tool.Key))) Then
    '        Select Case e.Tool.Key
    '            Case "Exit"
    '                Me.Close()
    '            Case "Login"
    '                flagHomeLogin = False
    '                If flagLogin = False Then
    '                    Login()
    '                End If
    '            Case "Language"
    '                Select Case obj.Lan
    '                    Case "VN"
    '                        WCobj.Lan = "EN"
    '                        obj.Lan = "EN"
    '                    Case "EN"
    '                        obj.Lan = "KR"
    '                        WCobj.Lan = "KR"
    '                    Case Else
    '                        obj.Lan = "VN"
    '                        WCobj.Lan = "VN"
    '                End Select
    '                Me.ChangeLanguage(obj.Lan)
    '                'lang_old(obj.Lan)
    '                'ExportMainMenu()
    '            Case "btnExportLanguage"
    '                'Me.OptimalLanguage()
    '                Me.ExportLanguage()
    '            Case "btnToiUuNgonNgu"
    '                Me.OptimalLanguage()
    '            Case "btnGetAllForm"
    '                Me.ShowAllForm()
    '            Case "gioithieu"
    '                Dim frm As New frmAbout
    '                frm.ShowDialog()
    '            Case "Logout"
    '                Logout()
    '            Case "HuongDanSuDung"
    '                Dim strHelpPath As String = System.IO.Path.Combine(Application.StartupPath, "HuongDanSuDungPhanMemNhanSu.chm")
    '                HelpProvider1.HelpNamespace = strHelpPath
    '                Help.ShowHelp(Me, HelpProvider1.HelpNamespace, HelpNavigator.TableOfContents)
    '            Case "Refresh"
    '                Dim kn As New connect(Appsettings.DbSetting.dataPath)
    '                If MessageBox.Show("Bạn có thự sự muốn thực hiện lệnh?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
    '                    Exit Sub
    '                End If
    '                If kn.SaveData("exec sp_RebuildIndex") = True Then
    '                    MessageBox.Show("Thực hiện lệnh thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Else
    '                    MessageBox.Show("Thực hiện lệnh không thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                End If

    '        End Select
    '    End If
    '    'www.serials.ws Serial: 123-119-119-046-204

    'End Sub

    Private Sub frmLayout_doMenu(ByVal ikey As String) Handles frmLayout.doMenu
        RunMethod(ikey)
    End Sub

    Private Sub BarManager1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarManager1.ItemClick
        If (IsNothing(RunMethod(e.Item.Name))) Then
            Select Case e.Item.Name
                Case "Exit1"
                    Me.Close()
                Case "Login2"
                    flagHomeLogin = False
                    If flagLogin = False Then
                        Login()
                    End If
                Case "Language"
                    Select Case obj.Lan
                        Case "VN"
                            WCobj.Lan = "EN"
                            obj.Lan = "EN"
                        Case "EN"
                            obj.Lan = "KR"
                            WCobj.Lan = "KR"
                        Case Else
                            obj.Lan = "VN"
                            WCobj.Lan = "VN"
                    End Select
                    Me.ChangeLanguage(obj.Lan)
                        'lang_old(obj.Lan)
                        'ExportMainMenu()
                Case "btnExportLanguage"
                    'Me.OptimalLanguage()
                    Me.ExportLanguage()
                Case "btnToiUuNgonNgu"
                    Me.OptimalLanguage()
                Case "btnGetAllForm"
                    Me.ShowAllForm()
                Case "gioithieu"
                    Dim frm As New frmAbout
                    frm.ShowDialog()
                Case "Logout2"
                    Logout()
                Case "HuongDanSuDung"
                    Dim webAddress As String = "https://hr.docs.ssaudit.com"
                    Process.Start(webAddress)
                Case "Refresh"
                    Dim kn As New connect(Appsettings.DbSetting.dataPath)
                    If MessageBox.Show("Bạn có thự sự muốn thực hiện lệnh?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Exit Sub
                    End If
                    If kn.SaveData("exec sp_RebuildIndex") = True Then
                        MessageBox.Show("Thực hiện lệnh thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Thực hiện lệnh không thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

            End Select
        End If
    End Sub
End Class
