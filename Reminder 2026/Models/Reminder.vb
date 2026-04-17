''' <summary>
''' Описывает 'Напоминание'
''' </summary>
Public Class Reminder
    Inherits Notifier

    Private _Number As Integer
    Private _PeriodicityText As String
    Private _IsActive As Boolean
    Private _Text As String
    Private _ExecuteTo As Date
    Private _ExecuteFrom As Date
    Private _NextExecute As Date

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
    Public Property ExecuteTo As DateTime
        Get
            Return _ExecuteTo
        End Get
        Set
            SetValue(Of DateTime)(_ExecuteTo, Value)
        End Set
    End Property

    ''' <summary>
    ''' Дата окончания выполнения.
    ''' </summary>
    ''' <returns></returns>
    Public Property ExecuteFrom As DateTime
        Get
            Return _ExecuteFrom
        End Get
        Set
            SetValue(Of DateTime)(_ExecuteFrom, Value)
        End Set
    End Property

    ''' <summary>
    ''' Дата следующего выполнения.
    ''' </summary>
    ''' <returns></returns>
    Public Property NextExecute As DateTime
        Get
            Return _NextExecute
        End Get
        Set
            SetValue(Of DateTime)(_NextExecute, Value)
        End Set
    End Property

    ''' <summary>
    ''' Интервал выполнения для повторяющихся напоминаний.
    ''' </summary>
    ''' <returns></returns>
    Public Property Periodicity As IPeriodicity

    Public ReadOnly Property PeriodicityText As String
        Get
            Return Periodicity.Text
        End Get
    End Property
End Class
