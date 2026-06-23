Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
''' <summary>
''' Описывает 'Напоминание'
''' </summary>
Public MustInherit Class Reminder
    Inherits Notifier
    Implements ICloneable

    Private _IsActive As Boolean
    Private _Text As String
    Private _DateFrom As DateTime
    Private _NextDate As Nullable(Of DateTime)
    Private _DateTo As DateTime
    Private _ExecIfLate As Boolean
    Private _ExecForever As Boolean

    ''' <summary>
    ''' Признак активности.
    ''' </summary>
    ''' <returns>True если напоминание активно и False в ином случае.</returns>
    Public Property IsActive As Boolean
        Get
            Return _IsActive
        End Get
        Set
            SetValue(Of Boolean)(_IsActive, Value)
        End Set
    End Property

    ''' <summary>
    ''' Текстовое описание напоминания.
    ''' </summary>
    ''' <returns></returns>
    Public Property Text As String
        Get
            Return _Text
        End Get
        Set
            SetValue(Of String)(_Text, Value)
        End Set
    End Property

    ''' <summary>
    ''' Дата начала выполнения.
    ''' </summary>
    ''' <returns></returns>
    Public Property DateFrom As DateTime
        Get
            Return _DateFrom
        End Get
        Set
            SetValue(Of DateTime)(_DateFrom, Value)
        End Set
    End Property

    ''' <summary>
    ''' Дата следующего выполнения.
    ''' </summary>
    ''' <returns></returns>
    Public Property NextDate As Nullable(Of DateTime)
        Get
            Return _NextDate
        End Get
        Set
            SetValue(Of Nullable(Of DateTime))(_NextDate, Value)
        End Set
    End Property

    ''' <summary>
    ''' Дата окончания выполнения.
    ''' </summary>
    ''' <returns></returns>
    Public Property DateTo As DateTime
        Get
            Return _DateTo
        End Get
        Set
            SetValue(Of DateTime)(_DateTo, Value)
        End Set
    End Property

    ''' <summary>
    ''' Флаг выполнения если напоминание опаздывает.
    ''' </summary>
    ''' <returns></returns>
    Public Property ExecIfLate As Boolean
        Get
            Return _ExecIfLate
        End Get
        Set
            SetValue(Of Boolean)(_ExecIfLate, Value)
        End Set
    End Property

    ''' <summary>
    ''' Фгал бесконечно выполняемого напоминания.
    ''' </summary>
    ''' <returns></returns>
    Public Property ExecForever As Boolean
        Get
            Return _ExecForever
        End Get
        Set
            SetValue(Of Boolean)(_ExecForever, Value)
        End Set
    End Property

    Public Sub New()
        Me.IsActive = True
        Me.DateFrom = DateTime.Now
    End Sub

    Public Overridable Function Clone() As Object Implements ICloneable.Clone
        Dim MeClone As PeriodicReminder = Me.MemberwiseClone()
        Return MeClone
    End Function

    ''' <summary>
    ''' Устанавливает дату следующего выполнения, от текущего момента времени.
    ''' </summary>
    ''' <param name="thisMoment">Текущий момент времени.</param>
    Public MustOverride Sub SetNextTime(ByVal thisMoment As DateTime)

End Class
