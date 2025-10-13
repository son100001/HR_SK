Public Class HROption
    Inherits System.ComponentModel.Component

#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Initialize()

    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    Friend WithEvents ds As Appsettings.HRSetting
    Friend WithEvents daHROption As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ds = New Appsettings.HRSetting
        Me.daHROption = New System.Data.SqlClient.SqlDataAdapter
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'ds
        '
        Me.ds.DataSetName = "HRSetting"
        Me.ds.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'daHROption
        '
        Me.daHROption.DeleteCommand = Me.SqlDeleteCommand1
        Me.daHROption.InsertCommand = Me.SqlInsertCommand1
        Me.daHROption.SelectCommand = Me.SqlSelectCommand1
        Me.daHROption.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "HROption", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("OptionID", "OptionID"), New System.Data.Common.DataColumnMapping("RoundTimeType", "RoundTimeType"), New System.Data.Common.DataColumnMapping("RoundType", "RoundType"), New System.Data.Common.DataColumnMapping("FilterMinutes", "FilterMinutes"), New System.Data.Common.DataColumnMapping("NightTimeFrom", "NightTimeFrom"), New System.Data.Common.DataColumnMapping("OvertimeSalaryRate", "OvertimeSalaryRate"), New System.Data.Common.DataColumnMapping("NightTimeTo", "NightTimeTo"), New System.Data.Common.DataColumnMapping("NighttimeSalaryRate", "NighttimeSalaryRate"), New System.Data.Common.DataColumnMapping("SundaySalaryRate", "SundaySalaryRate"), New System.Data.Common.DataColumnMapping("AcceptWorkingEarlyTime", "AcceptWorkingEarlyTime"), New System.Data.Common.DataColumnMapping("HolidaySalaryRate", "HolidaySalaryRate"), New System.Data.Common.DataColumnMapping("UnionFee", "UnionFee"), New System.Data.Common.DataColumnMapping("MinimumSalaryBasic", "MinimumSalaryBasic"), New System.Data.Common.DataColumnMapping("ProbationSalaryPercent", "ProbationSalaryPercent")})})
        Me.daHROption.UpdateCommand = Me.SqlUpdateCommand1
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT OptionID, RoundTimeType, RoundType, FilterMinutes, NightTimeFrom, Overtime" & _
        "SalaryRate, NightTimeTo, NighttimeSalaryRate, SundaySalaryRate, AcceptWorkingEar" & _
        "lyTime, HolidaySalaryRate, UnionFee, MinimumSalaryBasic, ProbationSalaryPercent " & _
        "FROM HROption"
        Me.SqlSelectCommand1.Connection = Me.SqlConnection1
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = "INSERT INTO HROption(OptionID, RoundTimeType, RoundType, FilterMinutes, NightTime" & _
        "From, OvertimeSalaryRate, NightTimeTo, NighttimeSalaryRate, SundaySalaryRate, Ac" & _
        "ceptWorkingEarlyTime, HolidaySalaryRate, UnionFee, MinimumSalaryBasic, Probation" & _
        "SalaryPercent) VALUES (@OptionID, @RoundTimeType, @RoundType, @FilterMinutes, @N" & _
        "ightTimeFrom, @OvertimeSalaryRate, @NightTimeTo, @NighttimeSalaryRate, @SundaySa" & _
        "laryRate, @AcceptWorkingEarlyTime, @HolidaySalaryRate, @UnionFee, @MinimumSalary" & _
        "Basic, @ProbationSalaryPercent); SELECT OptionID, RoundTimeType, RoundType, Filt" & _
        "erMinutes, NightTimeFrom, OvertimeSalaryRate, NightTimeTo, NighttimeSalaryRate, " & _
        "SundaySalaryRate, AcceptWorkingEarlyTime, HolidaySalaryRate, UnionFee, MinimumSa" & _
        "laryBasic, ProbationSalaryPercent FROM HROption WHERE (OptionID = @OptionID)"
        Me.SqlInsertCommand1.Connection = Me.SqlConnection1
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OptionID", System.Data.SqlDbType.Int, 4, "OptionID"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RoundTimeType", System.Data.SqlDbType.Int, 4, "RoundTimeType"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RoundType", System.Data.SqlDbType.Int, 4, "RoundType"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FilterMinutes", System.Data.SqlDbType.Int, 4, "FilterMinutes"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NightTimeFrom", System.Data.SqlDbType.DateTime, 8, "NightTimeFrom"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OvertimeSalaryRate", System.Data.SqlDbType.Int, 4, "OvertimeSalaryRate"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NightTimeTo", System.Data.SqlDbType.DateTime, 8, "NightTimeTo"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NighttimeSalaryRate", System.Data.SqlDbType.Int, 4, "NighttimeSalaryRate"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SundaySalaryRate", System.Data.SqlDbType.Int, 4, "SundaySalaryRate"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@AcceptWorkingEarlyTime", System.Data.SqlDbType.Bit, 1, "AcceptWorkingEarlyTime"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HolidaySalaryRate", System.Data.SqlDbType.Int, 4, "HolidaySalaryRate"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnionFee", System.Data.SqlDbType.Float, 8, "UnionFee"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@MinimumSalaryBasic", System.Data.SqlDbType.Float, 8, "MinimumSalaryBasic"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProbationSalaryPercent", System.Data.SqlDbType.Int, 4, "ProbationSalaryPercent"))
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = "UPDATE HROption SET OptionID = @OptionID, RoundTimeType = @RoundTimeType, RoundTy" & _
        "pe = @RoundType, FilterMinutes = @FilterMinutes, NightTimeFrom = @NightTimeFrom," & _
        " OvertimeSalaryRate = @OvertimeSalaryRate, NightTimeTo = @NightTimeTo, Nighttime" & _
        "SalaryRate = @NighttimeSalaryRate, SundaySalaryRate = @SundaySalaryRate, AcceptW" & _
        "orkingEarlyTime = @AcceptWorkingEarlyTime, HolidaySalaryRate = @HolidaySalaryRat" & _
        "e, UnionFee = @UnionFee, MinimumSalaryBasic = @MinimumSalaryBasic, ProbationSala" & _
        "ryPercent = @ProbationSalaryPercent WHERE (OptionID = @Original_OptionID) AND (A" & _
        "cceptWorkingEarlyTime = @Original_AcceptWorkingEarlyTime OR @Original_AcceptWork" & _
        "ingEarlyTime IS NULL AND AcceptWorkingEarlyTime IS NULL) AND (FilterMinutes = @O" & _
        "riginal_FilterMinutes) AND (HolidaySalaryRate = @Original_HolidaySalaryRate OR @" & _
        "Original_HolidaySalaryRate IS NULL AND HolidaySalaryRate IS NULL) AND (MinimumSa" & _
        "laryBasic = @Original_MinimumSalaryBasic OR @Original_MinimumSalaryBasic IS NULL" & _
        " AND MinimumSalaryBasic IS NULL) AND (NightTimeFrom = @Original_NightTimeFrom OR" & _
        " @Original_NightTimeFrom IS NULL AND NightTimeFrom IS NULL) AND (NightTimeTo = @" & _
        "Original_NightTimeTo OR @Original_NightTimeTo IS NULL AND NightTimeTo IS NULL) A" & _
        "ND (NighttimeSalaryRate = @Original_NighttimeSalaryRate OR @Original_NighttimeSa" & _
        "laryRate IS NULL AND NighttimeSalaryRate IS NULL) AND (OvertimeSalaryRate = @Ori" & _
        "ginal_OvertimeSalaryRate OR @Original_OvertimeSalaryRate IS NULL AND OvertimeSal" & _
        "aryRate IS NULL) AND (ProbationSalaryPercent = @Original_ProbationSalaryPercent " & _
        "OR @Original_ProbationSalaryPercent IS NULL AND ProbationSalaryPercent IS NULL) " & _
        "AND (RoundTimeType = @Original_RoundTimeType) AND (RoundType = @Original_RoundTy" & _
        "pe) AND (SundaySalaryRate = @Original_SundaySalaryRate OR @Original_SundaySalary" & _
        "Rate IS NULL AND SundaySalaryRate IS NULL) AND (UnionFee = @Original_UnionFee OR" & _
        " @Original_UnionFee IS NULL AND UnionFee IS NULL); SELECT OptionID, RoundTimeTyp" & _
        "e, RoundType, FilterMinutes, NightTimeFrom, OvertimeSalaryRate, NightTimeTo, Nig" & _
        "httimeSalaryRate, SundaySalaryRate, AcceptWorkingEarlyTime, HolidaySalaryRate, U" & _
        "nionFee, MinimumSalaryBasic, ProbationSalaryPercent FROM HROption WHERE (OptionI" & _
        "D = @OptionID)"
        Me.SqlUpdateCommand1.Connection = Me.SqlConnection1
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OptionID", System.Data.SqlDbType.Int, 4, "OptionID"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RoundTimeType", System.Data.SqlDbType.Int, 4, "RoundTimeType"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RoundType", System.Data.SqlDbType.Int, 4, "RoundType"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FilterMinutes", System.Data.SqlDbType.Int, 4, "FilterMinutes"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NightTimeFrom", System.Data.SqlDbType.DateTime, 8, "NightTimeFrom"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OvertimeSalaryRate", System.Data.SqlDbType.Int, 4, "OvertimeSalaryRate"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NightTimeTo", System.Data.SqlDbType.DateTime, 8, "NightTimeTo"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NighttimeSalaryRate", System.Data.SqlDbType.Int, 4, "NighttimeSalaryRate"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SundaySalaryRate", System.Data.SqlDbType.Int, 4, "SundaySalaryRate"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@AcceptWorkingEarlyTime", System.Data.SqlDbType.Bit, 1, "AcceptWorkingEarlyTime"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HolidaySalaryRate", System.Data.SqlDbType.Int, 4, "HolidaySalaryRate"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnionFee", System.Data.SqlDbType.Float, 8, "UnionFee"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@MinimumSalaryBasic", System.Data.SqlDbType.Float, 8, "MinimumSalaryBasic"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProbationSalaryPercent", System.Data.SqlDbType.Int, 4, "ProbationSalaryPercent"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_OptionID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OptionID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_AcceptWorkingEarlyTime", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AcceptWorkingEarlyTime", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_FilterMinutes", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FilterMinutes", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_HolidaySalaryRate", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "HolidaySalaryRate", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_MinimumSalaryBasic", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MinimumSalaryBasic", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NightTimeFrom", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NightTimeFrom", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NightTimeTo", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NightTimeTo", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NighttimeSalaryRate", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NighttimeSalaryRate", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_OvertimeSalaryRate", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OvertimeSalaryRate", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProbationSalaryPercent", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProbationSalaryPercent", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_RoundTimeType", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RoundTimeType", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_RoundType", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RoundType", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_SundaySalaryRate", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SundaySalaryRate", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnionFee", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "UnionFee", System.Data.DataRowVersion.Original, Nothing))
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM HROption WHERE (OptionID = @Original_OptionID) AND (AcceptWorkingEarl" & _
        "yTime = @Original_AcceptWorkingEarlyTime OR @Original_AcceptWorkingEarlyTime IS " & _
        "NULL AND AcceptWorkingEarlyTime IS NULL) AND (FilterMinutes = @Original_FilterMi" & _
        "nutes) AND (HolidaySalaryRate = @Original_HolidaySalaryRate OR @Original_Holiday" & _
        "SalaryRate IS NULL AND HolidaySalaryRate IS NULL) AND (MinimumSalaryBasic = @Ori" & _
        "ginal_MinimumSalaryBasic OR @Original_MinimumSalaryBasic IS NULL AND MinimumSala" & _
        "ryBasic IS NULL) AND (NightTimeFrom = @Original_NightTimeFrom OR @Original_Night" & _
        "TimeFrom IS NULL AND NightTimeFrom IS NULL) AND (NightTimeTo = @Original_NightTi" & _
        "meTo OR @Original_NightTimeTo IS NULL AND NightTimeTo IS NULL) AND (NighttimeSal" & _
        "aryRate = @Original_NighttimeSalaryRate OR @Original_NighttimeSalaryRate IS NULL" & _
        " AND NighttimeSalaryRate IS NULL) AND (OvertimeSalaryRate = @Original_OvertimeSa" & _
        "laryRate OR @Original_OvertimeSalaryRate IS NULL AND OvertimeSalaryRate IS NULL)" & _
        " AND (ProbationSalaryPercent = @Original_ProbationSalaryPercent OR @Original_Pro" & _
        "bationSalaryPercent IS NULL AND ProbationSalaryPercent IS NULL) AND (RoundTimeTy" & _
        "pe = @Original_RoundTimeType) AND (RoundType = @Original_RoundType) AND (SundayS" & _
        "alaryRate = @Original_SundaySalaryRate OR @Original_SundaySalaryRate IS NULL AND" & _
        " SundaySalaryRate IS NULL) AND (UnionFee = @Original_UnionFee OR @Original_Union" & _
        "Fee IS NULL AND UnionFee IS NULL)"
        Me.SqlDeleteCommand1.Connection = Me.SqlConnection1
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_OptionID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OptionID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_AcceptWorkingEarlyTime", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AcceptWorkingEarlyTime", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_FilterMinutes", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FilterMinutes", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_HolidaySalaryRate", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "HolidaySalaryRate", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_MinimumSalaryBasic", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MinimumSalaryBasic", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NightTimeFrom", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NightTimeFrom", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NightTimeTo", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NightTimeTo", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NighttimeSalaryRate", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NighttimeSalaryRate", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_OvertimeSalaryRate", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OvertimeSalaryRate", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProbationSalaryPercent", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProbationSalaryPercent", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_RoundTimeType", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RoundTimeType", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_RoundType", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RoundType", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_SundaySalaryRate", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SundaySalaryRate", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnionFee", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "UnionFee", System.Data.DataRowVersion.Original, Nothing))
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=""GIANG-PC"";packet size=4096;user id=sa;data source=""."";persist sec" & _
        "urity info=False;initial catalog=DoosungCP150824"
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

#Region " Private varialble "

    Private mRoundType As TimeKeeping.RoundType
    Private mRoundTimeType As TimeKeeping.RoundTimeType
    Private mFilterMinutes As Integer
    Private mNightTimeFrom As Date
    Private mNightTimeTo As Date
    Private mOvertimeSalaryRate As Integer
    Private mNighttimeSalaryRate As Integer
    Private mSundaySalaryRate As Integer
    Private mHolidaySalaryRate As Integer
    Private mAcceptWorkingEarlyTime As Boolean
    Private mMinimumSalaryBasic As Double
    Private mUnionFee As Double
    Private mProbationSalaryPercent As Integer

#End Region

#Region " Property "

    Public Property RoundType() As TimeKeeping.RoundType
        Get
            Return mRoundType
        End Get
        Set(ByVal Value As TimeKeeping.RoundType)
            mRoundType = Value
        End Set
    End Property

    Public Property RoundTimeType() As TimeKeeping.RoundTimeType
        Get
            Return mRoundTimeType
        End Get
        Set(ByVal Value As TimeKeeping.RoundTimeType)
            mRoundTimeType = Value
        End Set
    End Property

    Public Property FilterMinutes() As Integer
        Get
            Return mFilterMinutes
        End Get
        Set(ByVal Value As Integer)
            mFilterMinutes = Value
        End Set
    End Property

    Public Property NightTimeFrom() As Date
        Get
            Return mNightTimeFrom
        End Get
        Set(ByVal Value As Date)
            mNightTimeFrom = Value
        End Set
    End Property

    Public Property NightTimeTo() As Date
        Get
            Return mNightTimeTo
        End Get
        Set(ByVal Value As Date)
            mNightTimeTo = Value
        End Set
    End Property

    Public Property OvertimeSalaryRate() As Integer
        Get
            Return mOvertimeSalaryRate
        End Get
        Set(ByVal Value As Integer)
            mOvertimeSalaryRate = Value
        End Set
    End Property

    Public Property NighttimeSalaryRate() As Integer
        Get
            Return mNighttimeSalaryRate
        End Get
        Set(ByVal Value As Integer)
            mNighttimeSalaryRate = Value
        End Set
    End Property

    Public Property SundaySalaryRate() As Integer
        Get
            Return mSundaySalaryRate
        End Get
        Set(ByVal Value As Integer)
            mSundaySalaryRate = Value
        End Set
    End Property

    Public Property HolidaySalaryRate() As Integer
        Get
            Return mHolidaySalaryRate
        End Get
        Set(ByVal Value As Integer)
            mHolidaySalaryRate = Value
        End Set
    End Property

    Public Property AcceptWorkingEarlyTime() As Boolean
        Get
            Return mAcceptWorkingEarlyTime
        End Get
        Set(ByVal Value As Boolean)
            mAcceptWorkingEarlyTime = Value
        End Set
    End Property

    Public Property MinimumSalaryBasic() As Double
        Get
            Return mMinimumSalaryBasic
        End Get
        Set(ByVal Value As Double)
            mMinimumSalaryBasic = Value
        End Set
    End Property

    Public Property UnionFee() As Double
        Get
            Return mUnionFee
        End Get
        Set(ByVal Value As Double)
            mUnionFee = Value
        End Set
    End Property

    Public Property ProbationSalaryPercent() As Integer
        Get
            Return mProbationSalaryPercent
        End Get
        Set(ByVal Value As Integer)
            mProbationSalaryPercent = Value
        End Set
    End Property

#End Region

    Private Sub Initialize()
        'GIANG KHONG HIEU VI SAO LOI NEN KHOA
        'Me.SqlConnection1.ConnectionString = DbSetting.dataPath
        'Try
        '    Option_Fill(ds)
        '    If ds.HROption.Count > 0 Then
        '        With ds.HROption.Rows(0)
        '            mRoundType = .Item("RoundType")
        '            mRoundTimeType = .Item("RoundTimeType")
        '            mFilterMinutes = .Item("FilterMinutes")
        '            mNightTimeFrom = .Item("NightTimeFrom")
        '            mNightTimeTo = .Item("NightTimeTo")
        '            mOvertimeSalaryRate = .Item("OvertimeSalaryRate")
        '            mNighttimeSalaryRate = .Item("NighttimeSalaryRate")
        '            mSundaySalaryRate = .Item("SundaySalaryRate")
        '            mHolidaySalaryRate = .Item("HolidaySalaryRate")
        '            mAcceptWorkingEarlyTime = .Item("AcceptWorkingEarlyTime")
        '            mMinimumSalaryBasic = .Item("MinimumSalaryBasic") '
        '            mUnionFee = .Item("UnionFee")
        '            mProbationSalaryPercent = .Item("ProbationSalaryPercent")
        '        End With
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Can not load program option, please check again database!")
        'End Try
    End Sub

    Public Function SaveSetting() As Boolean
        'GIANG KHONG HIEU VI SAO LOI NEN KHOA
        'Try
        '    With ds.HROption.Rows(0)
        '        .Item("RoundType") = mRoundType
        '        .Item("RoundTimeType") = mRoundTimeType
        '        .Item("FilterMinutes") = mFilterMinutes
        '        .Item("NightTimeFrom") = mNightTimeFrom
        '        .Item("NightTimeTo") = mNightTimeTo
        '        .Item("OvertimeSalaryRate") = mOvertimeSalaryRate
        '        .Item("NighttimeSalaryRate") = mNighttimeSalaryRate
        '        .Item("SundaySalaryRate") = mSundaySalaryRate
        '        .Item("HolidaySalaryRate") = mHolidaySalaryRate
        '        .Item("AcceptWorkingEarlyTime") = mAcceptWorkingEarlyTime
        '        .Item("MinimumSalaryBasic") = mMinimumSalaryBasic
        '        .Item("UnionFee") = mUnionFee
        '        .Item("ProbationSalaryPercent") = mProbationSalaryPercent
        '    End With
        '    Option_Update(ds)
        '    Return True
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error while save program option, please check again database!")
        '    Return False
        'End Try
    End Function

#Region " Private Functions "

    Private Function Option_Fill(ByVal ds As HRSetting) As Boolean
        Try
            If (Me.daHROption Is Nothing) Then
                Return False
            End If
            ds.HROption.Clear()
            daHROption.Fill(ds.HROption)
            Return True
        Catch DBExection As Exception
            Interaction.MsgBox(DBExection.ToString, MsgBoxStyle.Exclamation, "Read Option")
            Return False
        End Try
    End Function

    Private Function Option_Update(ByVal ds As HRSetting) As Boolean
        Try
            If Not ds.HasChanges Then Return True
            daHROption.Update(ds.HROption.GetChanges)
            ds.AcceptChanges()
            Return True
        Catch DBExection As Exception
            MsgBox(DBExection.ToString, MsgBoxStyle.Exclamation, "Update Option")
            Return False
        End Try
    End Function

#End Region

End Class
