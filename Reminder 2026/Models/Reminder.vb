''' <summary>
''' Описывает 'Напоминание'
''' </summary>
Public Class Reminder
    Inherits Notifier

    Private _Number As Integer
    Private _PeriodicityText As String
    Private _IsActive As Boolean
    Private _Text As String
    Private _DateTo As DateTime
    Private _DateFrom As DateTime
    Private _NextDate As DateTime

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
    Public Property NextDate As DateTime
        Get
            Return _NextDate
        End Get
        Set
            SetValue(Of DateTime)(_NextDate, Value)
        End Set
    End Property

    ''' <summary>
    ''' Интервал выполнения для повторяющихся напоминаний.
    ''' </summary>
    ''' <returns></returns>
    Public Property Periodicity As IPeriodicity

    ''' <summary>
    ''' Обёртка свойства периодичности для привязки.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property PeriodicityText As String
        Get
            Return Periodicity.Text
        End Get
    End Property

    Public Sub New()
        Me.DateFrom = DateTime.Now
        Dim today As DateTime = DateTime.Now
        Me.DateTo = New DateTime(today.Year, today.Month, today.Day, 23, 59, 0)
    End Sub

End Class
