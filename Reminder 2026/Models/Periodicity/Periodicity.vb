<Xml.Serialization.XmlInclude(GetType(OneTime))>
<Xml.Serialization.XmlInclude(GetType(TimeInterval))>
Public MustInherit Class Periodicity
    Inherits Notifier

    Private _Interval As TimeSpan
    Private _Text As String
    Private _FrequencyOfRepeate As Repetitions

    ''' <summary>
    ''' Признак повторяющегося задания.
    ''' </summary>
    ''' <returns>True если задание должно периодически повторяться и False в ином случае.</returns>
    Public Overridable ReadOnly Property IsPeriodic As Boolean

    ''' <summary>
    ''' Интервал между началом и следующим выполнением задания.
    ''' </summary>
    ''' <returns></returns>
    <Xml.Serialization.XmlIgnore>
    Public Property Interval As TimeSpan
        Get
            Return _Interval
        End Get
        Set
            SetValue(Of TimeSpan)(_Interval, Value)
        End Set
    End Property

    ' XmlSerializer does Not support TimeSpan, so use this property for serialization instead
    <System.ComponentModel.Browsable(False)>
    <Xml.Serialization.XmlElement(DataType:="duration", ElementName:="Interval")>
    Public Property IntervalString As String
        Get
            Return Xml.XmlConvert.ToString(Me.Interval)
        End Get
        Set(value As String)
            Me.Interval = IIf(String.IsNullOrEmpty(value), TimeSpan.Zero, Xml.XmlConvert.ToTimeSpan(value))
        End Set
    End Property

    ''' <summary>
    ''' Описание задания.
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
    ''' Периодичность повторения напоминания.
    ''' </summary>
    ''' <returns></returns>
    Public Overridable Property FrequencyOfRepeate As Repetitions
        Get
            Return _FrequencyOfRepeate
        End Get
        Set
            SetValue(Of Repetitions)(_FrequencyOfRepeate, Value)
        End Set
    End Property


End Class
