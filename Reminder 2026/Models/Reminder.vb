Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
''' <summary>
''' Описывает 'Напоминание'
''' </summary>
Public Class Reminder
    Inherits Notifier
    Implements ICloneable ', IXmlSerializable

    Private _Number As Integer
    Private _PeriodicityText As String
    Private _IsActive As Boolean
    Private _Text As String
    Private _DateFrom As DateTime
    Private _DateTo As DateTime
    Private _NextDate As Nullable(Of DateTime)
    Private _ExecIfLate As Boolean
    Private _ExecForever As Boolean
    Private ReadOnly _DateToText As String

    ''' <summary>
    ''' Номер.
    ''' </summary>
    ''' <returns></returns>
    Public Property Number As Integer
        Get
            Return _Number
        End Get
        Set
            SetValue(Of Integer)(_Number, Value)
        End Set
    End Property

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

    ''' <summary>
    ''' Периодичность выполнения напоминаний.
    ''' </summary>
    ''' <returns></returns>
    Public Property Periodicity As Periodicity

    ''' <summary>
    ''' Обёртка свойства периодичности для привязки.
    ''' </summary>
    ''' <returns></returns>
    <System.Xml.Serialization.XmlIgnoreAttribute>
    Public ReadOnly Property PeriodicityText As String
        Get
            Return Periodicity.Text
        End Get
    End Property

    ''' <summary>
    ''' Обёртка свойства конечной даты для привязки.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property DateToText As String
        Get
            If ExecForever = True Then
                Return "Бесконечно"
            End If
            Return DateTo.ToString("g")
        End Get
    End Property

    Public Sub New()
        Me.IsActive = True
        Me.DateFrom = DateTime.Now
        Dim today As DateTime = DateTime.Now
        Me.DateTo = New DateTime(today.Year, today.Month, today.Day, 23, 59, 0)
    End Sub

    Public Function Clone() As Object Implements ICloneable.Clone
        Dim MeClone As Reminder = Me.MemberwiseClone()
        MeClone.Periodicity = CType(Me.Periodicity, ICloneable).Clone()
        Return MeClone
    End Function

    ''' <summary>
    ''' Устанавливает дату следующего выполнения, от текущего момента времени.
    ''' </summary>
    ''' <param name="thisMoment">Текущий момент времени.</param>
    Public Sub SetNextTime(ByVal thisMoment As DateTime)
        Dim newNextDate As DateTime ' дата следующего выполнения
        ' установим текущее значение даты следующего выполнения
        newNextDate = Me.DateFrom ' отсчёт от начала выполнения
        ' докрутим дату следующего выполнения пока она не превысит текущий момент
        While newNextDate < thisMoment
            ' установим дату следующего выполнения
            Select Case Me.Periodicity.FrequencyOfRepeate
                Case Repetitions.SomeMinuts
                    newNextDate = newNextDate.AddMinutes(Me.Periodicity.Interval.TotalMinutes)
                Case Repetitions.SomeHours
                    newNextDate = newNextDate.AddHours(Me.Periodicity.Interval.TotalHours)
                Case Repetitions.SomeDays
                    newNextDate = newNextDate.AddDays(Me.Periodicity.Interval.TotalDays)
                Case Repetitions.EveryMonth
                    newNextDate = newNextDate.AddMonths(1)
                Case Repetitions.EveryYear
                    newNextDate = newNextDate.AddYears(1)
                Case Repetitions.Once
                    newNextDate = thisMoment
            End Select
        End While

        Me.NextDate = newNextDate
    End Sub
End Class
