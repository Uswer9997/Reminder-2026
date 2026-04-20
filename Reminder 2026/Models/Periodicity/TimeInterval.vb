Public Class TimeInterval
    Inherits Notifier
    Implements IPeriodicity

    Private _IsPeriodic As Boolean
    Private _Interval As TimeSpan
    Private _Text As String
    Private _FrequencyOfRepeate As Repetitions

    Public ReadOnly Property IsPeriodic As Boolean Implements IPeriodicity.IsPeriodic
        Get
            Return True
        End Get
    End Property

    Public Property Interval As TimeSpan Implements IPeriodicity.Interval
        Get
            Return _Interval
        End Get
        Set
            SetValue(Of TimeSpan)(_Interval, Value)
        End Set
    End Property

    Public Property Text As String Implements IPeriodicity.Text
        Get
            Return _Text
        End Get
        Set
            SetValue(Of String)(_Text, Value)
        End Set
    End Property


    Public Property FrequencyOfRepeate As Repetitions Implements IPeriodicity.FrequencyOfRepeate
        Get
            Return _FrequencyOfRepeate
        End Get
        Set
            SetValue(Of Repetitions)(_FrequencyOfRepeate, Value)
        End Set
    End Property
End Class
